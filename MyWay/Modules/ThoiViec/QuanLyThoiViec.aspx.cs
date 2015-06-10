using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using Controller.ThoiViec;
using ExtMessage;
using SoftCore;
using System.IO;
using System.Data;
using DataController;
public partial class Modules_ThoiViec_QuanLyThoiViec : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            //dfNgayTraThe.SelectedDate = DateTime.Now;
            //dfNgayTraSo.SelectedDate = DateTime.Now;

            // add params for store
            Store1.BaseParams.Add(new Ext.Net.Parameter("uID", CurrentUser.ID.ToString()));
            Store1.BaseParams.Add(new Ext.Net.Parameter("mID", MenuID.ToString()));
        }

        // lọc theo phòng ban
        new DTH.BorderLayout()
        {
            menuID = MenuID,
            script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');#{PagingToolbar1}.pageIndex = 0;#{DirectMethods}.SetValueQuery();"
        }.AddDepartmentList(brlayout, CurrentUser.ID, true);


        SetVisibleByControlID(btnThemNhanVien, btnCapNhatThuTuc, btnHuyThuTuc,
            pnlCongNoNhanVien, btnThemCongNo,
            pnlBanGiaoTaiSan);

        if (pnlBanGiaoTaiSan.Visible)
        {
            pnlBanGiaoTaiSan.Listeners.Activate.Handler = "if(hdfRecordID.getValue()!=Hidden1.getValue() && hdfRecordID.getValue()!=''){grpBanGiaoTaiSanStore.reload();Hidden1.setValue(hdfRecordID.getValue());}";
        }
        if (pnlCongNoNhanVien.Visible)
        {
            pnlCongNoNhanVien.Listeners.Activate.Handler = "if(hdfRecordID.getValue()!=hdfLoadedEmployee.getValue() && hdfRecordID.getValue()!=''){grpCongNoNhanVienStore.reload();hdfLoadedEmployee.setValue(hdfRecordID.getValue());}";
        }

        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        string rtStr = string.Empty;
        string maCB = "";
        SelectedRowCollection selectedRow = sender as SelectedRowCollection;
        foreach (var item in selectedRow)
        {
            maCB += item.RecordID + ",";
        }
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("hoso_ThemNhanVienThoiViec", "@MaCB", "@CreatedBy",
                                                                                                   maCB, CurrentUser.ID);
        foreach (DataRow item in table.Rows)
        {
            rtStr += item["HO_TEN"] + "(" + item["MA_CB"] + "),";
        } 
        if (!string.IsNullOrEmpty(rtStr))
        {
            rtStr = rtStr.Remove(rtStr.LastIndexOf(','));
            Dialog.ShowError("Cán bộ: " + rtStr + " đã có trong danh sách thôi việc.");
        }
        RM.RegisterClientScriptBlock("rlst", "Store1.reload();");
    }

    #region Ghi chú và đính kèm
    #region các hàm dùng chung
    /// <summary>
    /// upload file from computer to server
    /// </summary>
    /// <param name="sender">ID of FileUploadField</param>
    /// <param name="directory">directory of folder HoSoNhanSu</param>
    /// <param name="relativePath">the relative path to place you want to save file</param>
    /// <returns>The path of file after upload to server</returns>
    public string UploadFile(object sender, string relativePath)
    {
        FileUploadField obj = (FileUploadField)sender;
        HttpPostedFile file = obj.PostedFile;
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath(relativePath));  // save file to directory HoSoNhanSu/File
        // if directory not exist then create this
        if (dir.Exists == false)
            dir.Create();
        string rdstr = SoftCore.Util.GetInstance().GetRandomString(7);
        string path = Server.MapPath(relativePath) + "/" + rdstr + "_" + obj.FileName;
        if (File.Exists(path))
            return "";
        FileInfo info = new FileInfo(path);
        file.SaveAs(path);
        return relativePath + "/" + rdstr + "_" + obj.FileName;
    }

    /// <summary>
    /// Return attach file to client when user click download button
    /// </summary>
    /// <param name="TableName">Name of table</param>
    /// <param name="Prkey">Prkey of employee</param>
    public void DownloadAttachFile(string TableName, Hidden sender)
    {
        try
        {
            if (string.IsNullOrEmpty(sender.Text))
            {
                Dialog.ShowNotification("Không có tệp tin đính kèm");
                return;
            }
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            Response.Clear();
            //  Response.ContentType = "application/octet-stream";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + sender.Text.Replace(" ", "_"));
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }

    public void DeleteTepTinDinhKem(string tableName, int id, Hidden sender)
    {
        try
        {
            // xóa trong csdl
//            DataController.DataHandler.GetInstance().ExecuteNonQuery(string.Format("update {0} set {1} = N'' where ID = {2}", tableName, "AttachFile", id));
            // xóa file trong thư mục
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            File.Delete(serverPath);
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }
    #endregion

    [DirectMethod]
    public void DownloadAttach(string path)
    {
        try
        {
            string serverPath = string.Empty;
            serverPath = Server.MapPath("") + "/" + path;
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            Response.Clear();
            //  Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + path.Replace(" ", "_"));
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }

    protected void btnDownload_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string directory = Server.MapPath("");
            DownloadAttachFile("DanhSachCanBoThoiViec", hdfTepTinDinhKem);
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }
    #endregion

    /// <summary>
    /// Bind danh sách công nợ của nhân viên lên grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grpCongNoNhanVienStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfRecordID.Text))
            {
                return;
            }
            decimal prKeyHoSo = new DanhSachCanBoThoiViecController().GetHoSoPrimaryKey(int.Parse(hdfRecordID.Text));
            grpCongNoNhanVienStore.DataSource = new BangTamUngController().GetByPrKeyHoSo(prKeyHoSo);
            grpCongNoNhanVienStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo lỗi", ex.Message).Show();
        }
    }

    protected void btnChuaThanhToan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BangTamUngController controller = new BangTamUngController();
            RowSelectionModel sm = grpCongNoNhanVien.SelectionModel.Primary as RowSelectionModel;
            foreach (var item in sm.SelectedRows)
            {
                BangTamUngInfo tmp = new BangTamUngInfo
                {
                    ID = int.Parse(item.RecordID),
                    GhiChu = txtGhiChuThanhToan.Text,
                    DaThanhToanHet = false,
                    SoTienConLai = decimal.Parse(nbfSoTienConNo.Text)
                };
                controller.UpdateThanhToanCongNo(tmp);
            }
            RM.RegisterClientScriptBlock("grpCongNoNhanVienStore", "grpCongNoNhanVienStore.reload();Store1.reload();");
            wdCapNhatThanhToanCongNo.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo lỗi", ex.Message).Show();
        }
    }

    protected void btnDaThanhToan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fup_fileAttachment.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fup_fileAttachment, "File/AttachFile");
            }
            if (path.Equals("-1"))
            {
                X.Msg.Alert("Thông báo", "Kích thước của tệp tin vượt quá quy định (10MB)").Show();
                return;
            }

            BangTamUngController controller = new BangTamUngController();
            RowSelectionModel sm = grpCongNoNhanVien.SelectionModel.Primary as RowSelectionModel;
            foreach (var item in sm.SelectedRows)
            {
                BangTamUngInfo tmp = new BangTamUngInfo
                {
                    ID = int.Parse(item.RecordID),
                    GhiChu = txtGhiChuThanhToan.Text,
                    NgayThanhToan = dfNgayThanhToan.SelectedDate,
                    DaThanhToanHet = chkDaThanhToanDu.Checked,
                    SoTienDaTra = decimal.Parse(nbfSoTienThanhToan.Text)
                };
                if (path != "")
                    tmp.AttachFile = path;
                else
                    tmp.AttachFile = hdfFileAttachment.Text;

                controller.UpdateThanhToanCongNo(tmp);
            }
            RM.RegisterClientScriptBlock("grpCongNoNhanVienStore", "grpCongNoNhanVienStore.reload();Store1.reload();");
            wdCapNhatThanhToanCongNo.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo lỗi", ex.Message).Show();
        }
    }

    protected void cbx_lydonghi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DAL.DM_LYDO_NGHI> lists = new DM_LYDO_NGHIController().GetByAll();
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA_LYDO_NGHI = item.MA_LYDO_NGHI, TEN_LYDO_NGHI = item.TEN_LYDO_NGHI });
        }
        cbx_lydonghi_Store.DataSource = obj;
        cbx_lydonghi_Store.DataBind();
    }

    protected void cbxLyDoHanChe_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DAL.ThamSoTrangThai> list = new DanhSachCanBoThoiViecController().GetByParamName("LyDoDuaVaoDanhSachHanChe", Session["MaDonVi"].ToString());
        object[] obj = new object[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            obj[i] = new { MA_LYDO_HC = list[i].ID, TEN_LYDO_HC = list[i].Value };
        }
        cbxLyDoHanChe_Store.DataSource = obj;
        cbxLyDoHanChe_Store.DataBind();
    }

    protected void grpBanGiaoTaiSanStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            grpBanGiaoTaiSanStore.DataSource = new HOSO_TAISANController().GetTaiSanBanGiao(new DanhSachCanBoThoiViecController().GetHoSoPrimaryKey(int.Parse(hdfRecordID.Text)));
            grpBanGiaoTaiSanStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo lỗi " + hdfRecordID.Text, ex.Message).Show();
        }
    }
    protected void btnDaBanGiao_Click(object sender, DirectEventArgs e)
    {
        // upload file
        string path = string.Empty;
        if (fufAttach_AttachFile.HasFile)
        {
            string directory = Server.MapPath("");
            path = UploadFile(fufAttach_AttachFile, "File/AttachFile");
        }
        if (path.Equals("-1"))
        {
            X.Msg.Alert("Thông báo", "Kích thước của tệp tin vượt quá quy định (10MB)").Show();
            return;
        }
        RowSelectionModel sm = GridPanel2.SelectionModel.Primary as RowSelectionModel;
        HOSO_TAISANController controller = new HOSO_TAISANController();
        foreach (var item in sm.SelectedRows)
        {
            DAL.HOSO_TAISAN ts = new DAL.HOSO_TAISAN()
            {
                PR_KEY = decimal.Parse(item.RecordID),
                NgayBanGiao = dfNgayBanGiao.SelectedDate,
                GhiChuSauBanGiao = txtGhiChu.Text,
            };
            if (path != "")
                ts.TepTinDinhKem = path;
            else
                ts.TepTinDinhKem = hdfAttach_AttachFile.Text;
            controller.UpdateBanGiaoTaiSan(ts);
        }
        RM.RegisterClientScriptBlock("grpBanGiaoTaiSanStore", "grpBanGiaoTaiSanStore.reload();Store1.reload();");
        wdCapNhatTaiSan.Hide();
    }
    protected void btnChuaBanGiao_Click(object sender, DirectEventArgs e)
    {
        // upload file
        string path = string.Empty;
        if (fufAttach_AttachFile.HasFile)
        {
            string directory = Server.MapPath("");
            path = UploadFile(fufAttach_AttachFile, "File/AttachFile");
        }
        if (path.Equals("-1"))
        {
            X.Msg.Alert("Thông báo", "Kích thước của tệp tin vượt quá quy định (10MB)").Show();
            return;
        }
        RowSelectionModel sm = GridPanel2.SelectionModel.Primary as RowSelectionModel;
        HOSO_TAISANController controller = new HOSO_TAISANController();
        foreach (var item in sm.SelectedRows)
        {
            DAL.HOSO_TAISAN ts = new DAL.HOSO_TAISAN()
            {
                PR_KEY = decimal.Parse(item.RecordID),
                NgayBanGiao = null,
                GhiChuSauBanGiao = txtGhiChu.Text,
            };
            if (path != "")
                ts.TepTinDinhKem = path;
            else
                ts.TepTinDinhKem = hdfAttach_AttachFile.Text;
            controller.UpdateBanGiaoTaiSan(ts);
        }
        RM.RegisterClientScriptBlock("grpBanGiaoTaiSanStore", "grpBanGiaoTaiSanStore.reload();Store1.reload();");
        wdCapNhatTaiSan.Hide();
    }

    /// <summary>
    /// Load dữ liệu về cán bộ thôi việc (nếu có)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCapNhatThuTuc_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfRecordID.Text == "")
                return;
            int id = int.Parse("0" + hdfRecordID.Text);
            DAL.DanhSachCanBoThoiViec employee = new DanhSachCanBoThoiViecController().GetByID(id);
            dfNgayNghi.SetValue(employee.NgayNghi);
            if (employee.MaLyDoNghi != null)
                cbx_lydonghi.SetValue(employee.MaLyDoNghi);
            cbSoBHXH.SetValue(employee.DaTraSoBHXH.ToString());
            dfNgayTraThe.SetValue(employee.NgayTraThe);
            if (Equals("True", employee.DaTraTheBHYT.ToString()))
            {
                dfNgayTraThe.Disabled = false;
            }
            else
            {
                dfNgayTraThe.Disabled = true;
            }
            txtSoQuyetDinh.Text = employee.SoQuyetDinh;
            cbTraTheBHYT.SetValue(employee.DaTraTheBHYT.ToString());
            dfNgayTraSo.SetValue(employee.NgayTraSo);
            if (Equals("True",employee.DaTraSoBHXH.ToString()))
            {
                dfNgayTraSo.Disabled = false;
            }
            else
            {
                dfNgayTraSo.Disabled = true;
            }
            chkHoanTatThuTuc.Checked = employee.DaHoanThanhThuTuc;
            if (!string.IsNullOrEmpty(employee.AttachFile))
            {
                int pos = employee.AttachFile.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = employee.AttachFile.Substring(pos + 1);
                    fufTepTinDinhKem.Text = tenTT;
                }
                hdfTepTinDinhKem.Text = employee.AttachFile;
            }
            txtGhiChuTV.Text = employee.GhiChu;
            // lấy cán bộ duyệt nghỉ
            DAL.HOSO hs = new HoSoController().GetByPrKey(decimal.Parse(employee.FrCBDuyetNghi != null ? employee.FrCBDuyetNghi.ToString() : "-1"));
            if (hs != null)
            {
                hdfCanBoDuyet.Text = hs.PR_KEY.ToString();
                cbxCanBoDuyet.Text = hs.HO_TEN;
            }
            chkThemVaoDsHanChe.Checked = employee.IsBelongToBlackList;
            cbxLyDoHanChe.SetValue(employee.MaLyDoBiHanChe);
            wdCapNhatThuTuc.Show();

        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    /// <summary>
    /// Cập nhật lại các thủ tục
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CapNhatThuTuc_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufTepTinDinhKem, "File/ThoiViec");
            }

            // cập nhật thủ tục
            DAL.DanhSachCanBoThoiViec tv = new DAL.DanhSachCanBoThoiViec();
            tv.ID = int.Parse("0" + hdfRecordID.Text);
            if (!dfNgayNghi.SelectedDate.ToString().Contains("0001"))
                tv.NgayNghi = dfNgayNghi.SelectedDate;
            if (cbx_lydonghi.SelectedItem.Value != null)
                tv.MaLyDoNghi = cbx_lydonghi.SelectedItem.Value;
            tv.DaTraTheBHYT = cbTraTheBHYT.SelectedItem.Value;
            if (!dfNgayTraThe.SelectedDate.ToString().Contains("0001"))
                tv.NgayTraThe = dfNgayTraThe.SelectedDate;
            tv.DaTraSoBHXH = bool.Parse(cbSoBHXH.SelectedItem.Value);
            if (!dfNgayTraSo.SelectedDate.ToString().Contains("0001"))
                tv.NgayTraSo = dfNgayTraSo.SelectedDate;
            if (hdfCanBoDuyet.Text != "")
                tv.FrCBDuyetNghi = decimal.Parse("0" + hdfCanBoDuyet.Text);
            tv.IsBelongToBlackList = chkThemVaoDsHanChe.Checked;
            if (cbxLyDoHanChe.SelectedItem.Value != null)
                tv.MaLyDoBiHanChe = int.Parse(cbxLyDoHanChe.SelectedItem.Value);
            tv.DaHoanThanhThuTuc = chkHoanTatThuTuc.Checked;
            tv.GhiChu = txtGhiChuTV.Text;
            tv.SoQuyetDinh = txtSoQuyetDinh.Text;
            if (path != "")
                tv.AttachFile = path;
            else
                tv.AttachFile = hdfTepTinDinhKem.Text;

            //    if (tv.DaHoanThanhThuTuc == true)
            //      {
            //bool htTaiSan = new BanGiaoTaiSanController().KiemTraHoanThanhBGTaiSan(tv.ID);
            //if (htTaiSan == false)
            //{
            //    X.Msg.Alert("Thông báo", "Bạn không thể cập nhật trạng thái Hoàn tất thủ tục khi chưa hoàn thành bàn giao tất cả tài sản").Show();
            //    return;
            //}
            //bool htCongNo = new ThanhToanCongNoController().KiemTraHoanThanhCongNo(tv.ID);
            //if (htCongNo == false)
            //{
            //    X.Msg.Alert("Thông báo", "Bạn không thể cập nhật trạng thái Hoàn tất thủ tục khi chưa hoàn thành thanh toán công nợ").Show();
            //    return;
            //}
            // }

            new DanhSachCanBoThoiViecController().UpdateThuTuc(tv);
            if (tv.DaHoanThanhThuTuc == true)
            {
                // cập nhật trạng thái đã nghỉ trong bảng HOSO
                DAL.HOSO hs = new DAL.HOSO();
                DAL.DanhSachCanBoThoiViec ds = new DanhSachCanBoThoiViecController().GetByID(tv.ID);
                hs.PR_KEY = ds.PrKeyHoSo;
                hs.DA_NGHI = true;
                hs.NGAY_NGHI = tv.NgayNghi;
                hs.MA_LYDO_NGHI = tv.MaLyDoNghi;
                new DanhSachCanBoThoiViecController().UpdateNghiViecHoSo(hs);

                // cập nhật thông tin bảo hiểm nhân viên (trạng thái đã trả thẻ hay chưa)
                DAL.BHNHANVIEN_BAOHIEM nvbh = new NhanVien_BaoHiemController().GetNhanVien_BaoHiemByIDNhanVien_BaoHiem(int.Parse(ds.PrKeyHoSo.ToString()));
                if (nvbh != null)
                {
                    if (tv.DaTraSoBHXH == true)
                        nvbh.TrangThaiCapSoBHXH = "DaTraSo";
                    if (tv.DaTraTheBHYT == "True")
                        nvbh.TrangThaiCapTheBHYT = "DaTraThe";
                    new NhanVien_BaoHiemController().UpdateNhanVien_BaoHiem(nvbh);
                }
            }
            RM.RegisterClientScriptBlock("rsl", "Store1.reload();wdCapNhatThuTuc.hide(); LoadDataInSouthPanel();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    protected void btnAttachDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hdfRecordID.Text))
            {
                DeleteTepTinDinhKem("DanhSachCanBoThoiViec", int.Parse(hdfRecordID.Text.Trim()), hdfTepTinDinhKem);
                hdfTepTinDinhKem.Reset();
                fufTepTinDinhKem.Reset();
                //GridPanel1.Reload();
                //Dialog.ShowNotification("Xóa tệp tin đính kèm thành công");
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    /// <summary>
    /// Hủy thủ tục cho các cán bộ được chọn
    /// </summary> 
    protected void mnuHuyThuTuc_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SelectedRowCollection SelectedRow = checkboxSelection.SelectedRows;
            foreach (var item in SelectedRow)
            {
                if (item.RecordID == "")
                    continue;
                int id = int.Parse("0" + item.RecordID);
                DAL.DanhSachCanBoThoiViec tv = new DanhSachCanBoThoiViecController().GetByID(id);
                if (tv != null)
                {
                    // xóa công nợ
                    //  new ThanhToanCongNoController().DeleteByIdCanBoThoiViec(tv.ID);
                    // xóa khỏi danh sách cán bộ thôi việc
                    new DanhSachCanBoThoiViecController().Delete(tv.ID);
                    // cập nhật trạng thái đã nghỉ trong hồ sơ
                    new HoSoController().UpdateDaNghiStatus(tv.PrKeyHoSo, false);
                }
            }
            hdfRecordID.Reset();
            RM.RegisterClientScriptBlock("rload", "Store1.reload(); LoadDataInSouthPanel();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    [DirectMethod]
    public void SetValueQuery()
    {
        string query = string.Empty;
        query += cbx_TinhTrang.SelectedItem.Value != null ? cbx_TinhTrang.SelectedItem.Value : "-1"; query += ";";
        query += cbxDaTraTheBHYT.SelectedItem.Value != null ? cbxDaTraTheBHYT.SelectedItem.Value : "-1"; query += ";";
        query += cbxDaTraSoBHXH.SelectedItem != null ? cbxDaTraSoBHXH.SelectedItem.Value : "-1"; query += ";";
        query += cbHoanTatCongNo.SelectedItem != null ? cbHoanTatCongNo.SelectedItem.Value : "-1"; query += ";";
        query += cbBanGiaoTaiSan.SelectedItem != null ? cbBanGiaoTaiSan.SelectedItem.Value : "-1";

        hdfQuery.Text = query;
        PagingToolbar1.PageIndex = 0;
        GridPanel1.Reload();
    }

    private List<object> LoadMenuCon(List<object> obj, string parentID, int k)
    {
        List<DAL.DM_DONVI> lists = new DM_DONVIController().GetByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "- ";
            obj.Add(new { MA_DONVI = item.MA_DONVI, TEN_DONVI = tmp + item.TEN_DONVI });
            obj = LoadMenuCon(obj, item.MA_DONVI, k + 1);
        }
        return obj;
    }
}