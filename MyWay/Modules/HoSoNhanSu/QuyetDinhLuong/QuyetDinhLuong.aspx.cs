using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DAL;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using SoftCore;
using System.Data;
using DataController;

public partial class Modules_HoSoNhanSu_QuyetDinhLuong : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            //   hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            HideColumn();
            hdfUserID.SetValue(CurrentUser.ID);
            hdfMenuID.SetValue(MenuID);
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');Store1.reload();",
            }.AddDepartmentList(br, CurrentUser.ID, true);
            SetVisibleByControlID(btnCauHinh, btnDownloadAttachFile,//btnPrintQuyetDinh,
                                  btnDelete, btnEdit, btnTaoQuyetDinh, tbPhuCap, btnAddPhuCap, btnSuaPhuCap, btnDeletePhuCap,
                                  mnuTaoQDChoMotCB, mnuTaoQDHangLoat);

            // Handle config in manifest
            List<ManifestInfo> lists = new XMLProcess().GetManifestByVisible(Server.MapPath("../../../") + "Manifest.xml", "SalaryDecision", false);
            foreach (var item in lists)
            {
                FindControl(item.id).Visible = item.visible;
            }
            // show/hide column
            if (cbxNgachHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(5, true);
            if (cbxBacLuongHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(6, true);
            if (txtHeSoLuongHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(7, true);
            if (txtMucLuongHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(8, true);
            if (txtLuongDongBHHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(9, true);
            if (dfNgayHuongLuongHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(10, true);
            if (txtPhanTramHuongLuongHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(11, true);
            if (txtBacLuongNBHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(12, true);
            if (dfNgayHuongLuongNBHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(13, true);
            if (cbxLoaiLuongHL.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(14, true);
            if (txtLuongTrachNhiem.Visible == false)
                grp_DanhSachQuyetDinh.ColumnModel.SetHidden(15, true);
        }

        if (btnEdit.Visible)
        {
            GridPanel1.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
            GridPanel1.DirectEvents.RowDblClick.Before += "#{hdfButtonClick}.setValue('Edit');#{btnCapNhat}.hide();#{btnCapNhatSua}.show();#{btnCapNhatDongLai}.hide();";
            GridPanel1.DirectEvents.RowDblClick.EventMask.ShowMask = true;
        }

        if (btnSuaPhuCap.Visible)
        {
            grpPhuCap.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaPhuCap_Click);
            grpPhuCap.DirectEvents.RowDblClick.Before = "btnCapNhatPhuCap.show();btnThemPhuCap.hide();if(cbLoaiPhuCap.store.getCount()==0){cbLoaiPhuCapStore.reload();}";
            grpPhuCap.DirectEvents.RowDblClick.EventMask.ShowMask = true;
            grpPhuCap.DirectEvents.RowDblClick.ExtraParams.Add(new Ext.Net.Parameter()
            {
                Name = "RecordID",
                Value = "RowSelectionModel2.getSelected().id",
                Mode = ParameterMode.Raw
            });
        }

        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    #region cấu hình cột cho gridpanel
    private void HideColumn()
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("SystemConfig_GetConfigByPrefix", "@Prefix", "@MaDonVi", "QDL_", Session["MaDonVi"].ToString());
            List<string> columnList = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                if (bool.Parse(row["VAR_VALUE"].ToString()) == false)
                    columnList.Add(row["VAR_NAME"].ToString());
            }
            foreach (var item in GridPanel1.ColumnModel.Columns)
            {
                if (columnList.Contains(item.ColumnID))
                {
                    item.Hidden = true;
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    [DirectMethod]
    public void LoadConfigGridPanel()
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("SystemConfig_GetConfigByPrefix", "@Prefix", "@MaDonVi", "QDL_", Session["MaDonVi"].ToString());
            foreach (DataRow item in table.Rows)
            {
                switch (item["VAR_NAME"].ToString())
                {
                    case SystemConfigParameter.QDL_LUONGCUNG:
                        chkLuongCung.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_HESOLUONG:
                        chkHeSoLuong.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_PHANTRAMHL:
                        chkPhanTramHL.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_LOAILUONG:
                        chkLoaiLuong.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_LUONGDONGBHXH:
                        chkLuongDongBHXH.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_BACLUONG:
                        chkBacLuong.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_BACLUONGNB:
                        chkBacLuongNB.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;

                    case SystemConfigParameter.QDL_NGAYHL:
                        chkNgayHL.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_NGAYHLNB:
                        chkNgayHLNB.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_SOQD:
                        chkSoQD.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_NGAYQD:
                        chkNgayQD.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_NGAYHIEULUC:
                        chkNgayHieuLuc.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_NGAYHETHIEULUC:
                        chkNgayHetHieuLuc.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.QDL_NGUOIQD:
                        chkNguoiQD.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnCapNhatCauHinh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            HeThongController controller = new HeThongController();

            controller.CreateOrSave(SystemConfigParameter.QDL_LUONGCUNG, chkLuongCung.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_HESOLUONG, chkHeSoLuong.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_PHANTRAMHL, chkPhanTramHL.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_LOAILUONG, chkLoaiLuong.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_LUONGDONGBHXH, chkLuongDongBHXH.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_BACLUONG, chkBacLuong.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_BACLUONGNB, chkBacLuongNB.Checked.ToString(), CurrentUser.ID, maDV);

            controller.CreateOrSave(SystemConfigParameter.QDL_NGAYHL, chkNgayHL.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_NGAYHLNB, chkNgayHLNB.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_SOQD, chkSoQD.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_NGAYQD, chkNgayQD.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_NGAYHIEULUC, chkNgayHieuLuc.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_NGAYHETHIEULUC, chkNgayHetHieuLuc.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.QDL_NGUOIQD, chkNguoiQD.Checked.ToString(), CurrentUser.ID, maDV);

            Dialog.ShowNotification("Đã lưu cấu hình");
            wdConfigGridPanel.Hide();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        // hdfTotalRecord.Text = ucChooseEmployee1.SelectedRow.Count.ToString();        
        foreach (var item in ucChooseEmployee1.SelectedRow)
        {
            // pr_keyhoso, ma_cb, ho_ten, ten_donvi, ten_chucvu, mangach, bacluong, hesoluong, luongcung, luongdongbhxh, ngayhuongluong, bacluongnb, ngayhuongluongnb, phantramhuongluong, maloailuong, trangthai
            // get employee information
            HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
            string pr_keyhoso = hs.PR_KEY.ToString();
            string ma_cb = hs.MA_CB;
            string ho_ten = hs.HO_TEN;
            string ten_donvi = new DM_DONVIController().GetNameById(hs.MA_DONVI);
            string ten_chucvu = "";
            if (hs.DM_CHUCVU != null)
                ten_chucvu = hs.DM_CHUCVU.TEN_CHUCVU;
            // insert record to grid
            RM.RegisterClientScriptBlock("insert" + pr_keyhoso, string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '', '', '', '', '', '', '', '', '', '', '');", pr_keyhoso, ma_cb, ho_ten, ten_donvi, ten_chucvu));
        }
    }

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
    /// Delete Attach file of table include: delete column TepTinDinhKem in database and delete physical file in server
    /// </summary>
    /// <param name="TableName">Name of table</param>
    /// <param name="Prkey">Prkey of employee</param>
    public void DeleteTepTinDinhKem(string tableName, decimal prkey, Hidden sender)
    {
        // xóa trong csdl
        DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteTepTinDinhKem", "@TableName", "@Prkey", tableName, prkey);
        // xóa file trong thư mục
        string serverPath = Server.MapPath(sender.Text);
        if (Util.GetInstance().FileIsExists(serverPath) == false)
        {
            Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
            return;
        }
        File.Delete(serverPath);
    }

    public void DeleteTepTinDinhKem(string tableName, int id, Hidden sender)
    {
        // xóa trong csdl
        DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteAttachFile", "@TableName", "@ID", tableName, id);
        // xóa file trong thư mục
        string serverPath = Server.MapPath(sender.Text);
        if (Util.GetInstance().FileIsExists(serverPath) == false)
        {
            Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
            return;
        }
        File.Delete(serverPath);
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

    public void DownloadAttachFile(string TableName, string path)
    {
        try
        {
            if (string.IsNullOrEmpty(path))
            {
                Dialog.ShowNotification("Không có tệp tin đính kèm");
                return;
            }
            string serverPath = Server.MapPath(path);
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
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }
    /// <summary>
    /// Get only file name from path of file
    /// </summary>
    /// <param name="pathOfFile">the path of file</param>
    /// <returns>the file name</returns>
    public string GetFileName(string pathOfFile)
    {
        int pos = pathOfFile.LastIndexOf('/');
        if (pos != -1)
        {
            return pathOfFile.Substring(pos + 1);
        }
        return "";
    }
    #endregion

    #region các hàm xử lý sự kiện direct event click
    protected void btnDownloadAttachFile_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfRecordID.Text == "")
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy quyết định lương").Show();
            }
            HOSO_LUONG hsl = new HoSoLuongController().GetByID(int.Parse("0" + hdfRecordID.Text));
            DownloadAttachFile("HOSO_LUONG", hsl.TepTinDinhKem);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    /// <summary>
    /// #############################################
    /// Create salary decision for employee
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int idQDLCu = -1, idQDLMoi = -1;
            double? mucLuongCu = -1, mucLuongMoi = -1;
            #region lấy thông tin quyết định lương cũ
            try
            {
                DAL.HOSO_LUONG hslCu = new HoSoLuongController().GetNewestSalaryDevelopment(decimal.Parse("0" + hdfChonCanBo.Text), -1);
                if (hslCu != null)
                {
                    idQDLCu = hslCu.ID;
                    mucLuongCu = hslCu.LuongCung;
                }
            }
            catch (Exception)
            {

            }
            #endregion

            HoSoLuongController controller = new HoSoLuongController();
            DAL.HOSO_LUONG hsl = new HOSO_LUONG();
            // upload file
            string path = string.Empty;
            if (fufTepTinDinhKem.HasFile)
            {
                path = UploadFile(fufTepTinDinhKem, "../File/QuyetDinhLuong");
            }
            // decide information
            hsl.PrKeyHoSo = decimal.Parse("0" + hdfChonCanBo.Text);
            if (txtSoQDMoi.Visible)
                hsl.SoQuyetDinh = txtSoQDMoi.Text;
            if (dfNgayQDMoi.Visible && !dfNgayQDMoi.SelectedDate.ToString().Contains("0001"))
                hsl.NgayQuyetDinh = dfNgayQDMoi.SelectedDate;
            if (txtTenQDMoi.Visible)
                hsl.TenQuyetDinh = txtTenQDMoi.Text;
            if (dfNgayHieuLucMoi.Visible && !dfNgayHieuLucMoi.SelectedDate.ToString().Contains("0001"))
                hsl.NgayHieuLuc = dfNgayHieuLucMoi.SelectedDate;
            if (dfNgayHetHieuLucMoi.Visible && !dfNgayHetHieuLucMoi.SelectedDate.ToString().Contains("0001"))
                hsl.NgayKetThucHieuLuc = dfNgayHetHieuLucMoi.SelectedDate;
            if (!string.IsNullOrEmpty(hdfNguoiQuyetDinh.Text))
            {
                hsl.prKeyHoSoNguoiQuyetDinh = decimal.Parse("0" + hdfNguoiQuyetDinh.Text);
            }
            if (cbHopDongLoaiHopDongMoi.SelectedItem.Value != null)
            {
                hsl.PrKeyHoSoHopDong = decimal.Parse("0" + hdfLoaiHopDong.Text);
            }

            //Đức anh fix cứng trạng thái vào
            hsl.TrangThai = "DaDuyet";
            //hsl.TrangThai = cbTrangThaiMoi.SelectedItem.Value;
            //   hsl.TrangThai = cbTrangThaiMoi.SelectedItem.Value;
            // attach file
            if (path != "")
                hsl.TepTinDinhKem = path;
            else
                hsl.TepTinDinhKem = hdfTepTinDinhKem.Text;
            if (txtGhiChuMoi.Visible)
                hsl.GhiChu = txtGhiChuMoi.Text;

            // salary information
            if (cbx_ngachMoi.Visible)
                hsl.MaNgach = cbx_ngachMoi.SelectedItem.Value;
            if (cbxBacMoi.Visible)
                hsl.BacLuong = cbxBacMoi.SelectedItem.Value;
            if (txtHeSoLuongMoi.Visible && !string.IsNullOrEmpty(txtHeSoLuongMoi.Text))
                hsl.HeSoLuong = double.Parse(txtHeSoLuongMoi.Text.Replace('.', ','));
            if (txtMucLuongMoi.Visible && !string.IsNullOrEmpty(txtMucLuongMoi.Text))
                hsl.LuongCung = double.Parse(txtMucLuongMoi.Text.Replace('.', ','));
            if (txtLuongDongBHMoi.Visible && !string.IsNullOrEmpty(txtLuongDongBHMoi.Text))
                hsl.LuongDongBHXH = double.Parse(txtLuongDongBHMoi.Text.Replace('.', ','));
            if (dfNgayHLMoi.Visible && !dfNgayHLMoi.SelectedDate.ToString().Contains("0001"))
                hsl.NgayHuongLuong = dfNgayHLMoi.SelectedDate;
            if (txtBacLuongNBMoi.Visible)
                hsl.BacLuongNB = txtBacLuongNBMoi.Text;
            if (dfNgayHLNBMoi.Visible && !dfNgayHLNBMoi.SelectedDate.ToString().Contains("0001"))
                hsl.NgayHuongLuongNB = dfNgayHLNBMoi.SelectedDate;
            if (txtPhanTramHLMoi.Visible && !string.IsNullOrEmpty(txtPhanTramHLMoi.Text))
                hsl.PhanTramHuongLuong = int.Parse(txtPhanTramHLMoi.Text);
            if (txtLuongTrachNhiemMoi.Visible)
                hsl.LuongTrachNhiem = txtLuongTrachNhiemMoi.Text;
            if (cbLoaiLuong.Visible)
                hsl.MaLoaiLuong = cbLoaiLuong.SelectedItem.Value;
            // not allow null
            hsl.CreatedBy = CurrentUser.ID;
            hsl.CreatedDate = DateTime.Now;

            if (e.ExtraParams["Command"] == "Edit")
            {
                hsl.ID = int.Parse("0" + hdfRecordID.Text);
                new HoSoLuongController().Update(hsl);
                wdTaoQuyetDinhLuong.Hide();
            }
            else
            {
                // old prkey hoso
                decimal prkeyHoSo = hsl.PrKeyHoSo;

                // add salary decision
                new HoSoLuongController().Add(hsl);

                if (chkSuDungPhuCapCu.Checked == true)
                {
                    // get newest salary decision
                    DAL.HOSO_LUONG hoSoLuong = new HoSoLuongController().GetNewestSalaryDevelopment(prkeyHoSo, -1);

                    // add old allowance for employee
                    HoSoPhuCapPhucLoiController phuCapController = new HoSoPhuCapPhucLoiController();
                    IEnumerable<HoSoPhuCapInfo> lists = new HoSoPhuCapPhucLoiController().GetListPhuCap(decimal.Parse(hoSoLuong.ID.ToString()));
                    foreach (var item in lists)
                    {
                        DAL.HOSO_PHUCAP hspc = new HOSO_PHUCAP()
                        {
                            MaPhuCap = item.MaPhuCap,
                            HeSo = item.HeSo,
                            SoTien = item.SoTien,
                            NgayQuyetDinh = item.NgayQuyetDinh,
                            NgayHieuLuc = item.NgayHieuLuc,
                            prKeyHoSoNguoiQuyetDinh = item.PrkeyNguoiQuyetDinh,
                            FrKeyHOSO_LUONG = hsl.ID,
                            TrangThai = item.TrangThai
                        };
                        phuCapController.Add(hspc);
                    }
                }

                if (e.ExtraParams["Close"] == "True")
                {
                    wdTaoQuyetDinhLuong.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("resetform1", "ResetWdTaoQuyetDinhLuong(); Ext.net.DirectMethods.GenerateSoQD();");
                    //GenerateSoQD();
                }
            }
            RM.RegisterClientScriptBlock("rlgr", "Store1.reload();");

            #region Cập nhật thông tin sang bảo hiểm
            try
            {
                idQDLMoi = hsl.ID;
                mucLuongMoi = hsl.LuongCung;
                // nếu có sự thay đổi mức lương thì cập nhật lương đóng bảo hiểm vào phân hệ bảo hiểm
                //comment lại đoạn dưới, vì thực hiện nghiệp vụ so sanh mức lương cũ và mới ở store
                #region codecu
                //if (mucLuongCu != mucLuongMoi)
                //{
                //    DataController.DataHandler.GetInstance().ExecuteNonQuery("BaoHiem_CapNhatQuyetDinhLuong",
                //            "@PrkeyHoSo", "@IdQDLCu", "@IdQDLMoi", "@CreatedId", "@MaDonVi",
                //            hsl.PrKeyHoSo, idQDLCu, idQDLMoi, CurrentUser.ID, Session["MaDonVi"].ToString());
                //} 
                #endregion
                //chạy trực tiếp store luôn, không cần so sánh mức lương cũ và mới, vì đã làm trong store
                DataController.DataHandler.GetInstance().ExecuteNonQuery("BaoHiem_CapNhatQuyetDinhLuong",
                            "@PrkeyHoSo", "@IdQDLCu", "@IdQDLMoi", "@CreatedId", "@MaDonVi",
                            hsl.PrKeyHoSo, idQDLCu, idQDLMoi, CurrentUser.ID, Session["MaDonVi"].ToString());
            }
            catch (Exception exp)
            {
                Dialog.ShowError("Lỗi xảy ra khi cập nhật thông tin lương đóng bảo hiểm: " + exp.Message);
            }
            #endregion
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra khi lưu quyết định lương: " + ex.Message).Show();
        }
    }
    protected void btnQDLDownload_Click(object sender, DirectEventArgs e)
    {
        DownloadAttachFile("HOSO_LUONG", hdfTepTinDinhKem);
    }
    protected void btnQDLDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdfRecordID.Text != "")
        {
            DeleteTepTinDinhKem("HOSO_LUONG", int.Parse("0" + hdfRecordID.Text), hdfTepTinDinhKem);
            hdfTepTinDinhKem.Text = "";
        }
    }

    [DirectMethod]
    public void GenerateSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOQDLUONG, Session["MaDonVi"].ToString());
        string soqd = new HoSoController().GenerateSoHopDong("HOSO_LUONG", "SoQuyetDinh", suffix);
        txtSoQDMoi.Text = soqd;
    }
    /////////////////////////////////////////////////

    //###############################################
    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        try
        {
            SoftCore.Util util = new Util();
            HoSoLuongController hslController = new HoSoLuongController();
            string errorStr = string.Empty;
            // upload file
            string path = string.Empty;
            if (cpfAttachHL.Visible && fufTepTinDinhKemHL.HasFile)
            {
                path = UploadFile(fufTepTinDinhKemHL, "../File/QuyetDinhLuong");
            }
            ChangeRecords<QuyetDinhLuongHangLoatInfo> qdLuong = e.DataHandler.ObjectData<QuyetDinhLuongHangLoatInfo>();

            foreach (QuyetDinhLuongHangLoatInfo created in qdLuong.Created)
            {
                int idQDLCu = -1, idQDLMoi = -1;
                double? mucLuongCu = -1, mucLuongMoi = -1;
                #region lấy thông tin quyết định lương cũ
                try
                {
                    DAL.HOSO_LUONG hslCu = new HoSoLuongController().GetNewestSalaryDevelopment(created.PR_KEY, -1);
                    if (hslCu != null)
                    {
                        idQDLCu = hslCu.ID;
                        mucLuongCu = hslCu.LuongCung;
                    }
                }
                catch (Exception)
                {

                }
                #endregion

                HOSO_LUONG hsl = new HOSO_LUONG();
                // decision information
                if (txtSoQDHL.Visible)
                    hsl.SoQuyetDinh = txtSoQDHL.Text.Trim();
                if (txtTenQDHL.Visible)
                    hsl.TenQuyetDinh = txtTenQDHL.Text.Trim();
                if (dfNgayQDHL.Visible && !util.IsDateNull(dfNgayQDHL.SelectedDate))
                    hsl.NgayQuyetDinh = dfNgayQDHL.SelectedDate;
                if (dfNgayHieuLucHL.Visible && !util.IsDateNull(dfNgayHieuLucHL.SelectedDate))
                    hsl.NgayHieuLuc = dfNgayHieuLucHL.SelectedDate;
                if (dfNgayHetHieuLucHL.Visible && !util.IsDateNull(dfNgayHetHieuLucHL.SelectedDate))
                    hsl.NgayKetThucHieuLuc = dfNgayHetHieuLucHL.SelectedDate;
                if (hdfNguoiQuyetDinhHL.Visible && !string.IsNullOrEmpty(hdfNguoiQuyetDinhHL.Text))
                    hsl.prKeyHoSoNguoiQuyetDinh = decimal.Parse("0" + hdfNguoiQuyetDinhHL.Text);
                //if (cbHopDongLoaiHopDongMoiHL.SelectedItem.Value != null)
                //{
                //    hsl.PrKeyHoSoHopDong = decimal.Parse(cbHopDongLoaiHopDongMoiHL.SelectedItem.Value);
                //}
                // if (cbxTrangThaiQDHL.Visible)
                hsl.TrangThai = "DaDuyet";
                if (path != "")
                    hsl.TepTinDinhKem = path;
                else
                    hsl.TepTinDinhKem = hdfTepTinDinhKemHL.Text;
                hsl.GhiChu = txtGhiChuHL.Text;
                // salary information
                hsl.PrKeyHoSo = created.PR_KEY;
                if (cbxNgachHL.Visible)
                    hsl.MaNgach = created.MaNgach;
                if (cbxBacLuongHL.Visible)
                    hsl.BacLuong = created.BacLuong;
                if (txtHeSoLuongHL.Visible)
                    hsl.HeSoLuong = created.HeSoLuong;
                if (txtMucLuongHL.Visible)
                    hsl.LuongCung = created.LuongCung;
                if (txtLuongDongBHHL.Visible)
                    hsl.LuongDongBHXH = created.LuongDongBHXH;
                if (dfNgayHuongLuongHL.Visible && !util.IsDateNull(created.NgayHuongLuong))
                    hsl.NgayHuongLuong = created.NgayHuongLuong;
                if (txtBacLuongNBHL.Visible)
                    hsl.BacLuongNB = created.BacLuongNB;
                if (dfNgayHuongLuongNBHL.Visible && !util.IsDateNull(created.NgayHuongLuongNB))
                    hsl.NgayHuongLuongNB = created.NgayHuongLuongNB;
                if (txtPhanTramHuongLuongHL.Visible)
                    hsl.PhanTramHuongLuong = created.PhanTramHuongLuong;
                if (txtLuongTrachNhiem.Visible)
                    hsl.LuongTrachNhiem = created.LuongTrachNhiem;
                if (cbxLoaiLuongHL.Visible)
                    hsl.MaLoaiLuong = created.MaLoaiLuong;
                // not allow null
                hsl.CreatedBy = CurrentUser.ID;
                hsl.CreatedDate = DateTime.Now;

                decimal prkeyHoSo = hsl.PrKeyHoSo;

                // insert salary decision
                hslController.Add(hsl);

                if (chkSuDungPhuCapHL.Checked == true)
                {
                    // get newest salary decision
                    DAL.HOSO_LUONG hoSoLuong = new HoSoLuongController().GetNewestSalaryDevelopment(prkeyHoSo, -1);
                    // add old allowance for employee
                    HoSoPhuCapPhucLoiController phuCapController = new HoSoPhuCapPhucLoiController();
                    IEnumerable<HoSoPhuCapInfo> lists = new HoSoPhuCapPhucLoiController().GetListPhuCap(decimal.Parse(hoSoLuong.ID.ToString()));
                    foreach (var item in lists)
                    {
                        DAL.HOSO_PHUCAP hspc = new HOSO_PHUCAP()
                        {
                            MaPhuCap = item.MaPhuCap,
                            HeSo = item.HeSo,
                            SoTien = item.SoTien,
                            NgayQuyetDinh = item.NgayQuyetDinh,
                            NgayHieuLuc = item.NgayHieuLuc,
                            prKeyHoSoNguoiQuyetDinh = item.PrkeyNguoiQuyetDinh,
                            FrKeyHOSO_LUONG = hsl.ID,
                            TrangThai = item.TrangThai
                        };
                        phuCapController.Add(hspc);
                    }
                }

                #region Cập nhật thông tin sang bảo hiểm
                try
                {
                    idQDLMoi = hsl.ID;
                    mucLuongMoi = hsl.LuongCung;
                    // nếu có sự thay đổi mức lương thì cập nhật lương đóng bảo hiểm vào phân hệ bảo hiểm
                    if (mucLuongCu != mucLuongMoi)
                    {
                        DataController.DataHandler.GetInstance().ExecuteNonQuery("BaoHiem_CapNhatQuyetDinhLuong",
                                "@PrkeyHoSo", "@IdQDLCu", "@IdQDLMoi", "@CreatedId", "@MaDonVi",
                                hsl.PrKeyHoSo, idQDLCu, idQDLMoi, CurrentUser.ID, Session["MaDonVi"].ToString());
                    }
                }
                catch (Exception exp)
                {
                    Dialog.ShowError("Lỗi xảy ra khi cập nhật thông tin lương đóng bảo hiểm: " + exp.Message);
                }
                #endregion
            }
            if (hdfIsCloseWindows.Text == "True")
            {
                wdTaoQuyetDinhLuongHangLoat.Hide();
            }
            else
            {
                RM.RegisterClientScriptBlock("resetform", "ResetWdTaoQuyetDinhLuongHangLoat(); Ext.net.DirectMethods.GenerateSoQDHL();");
            }
            RM.RegisterClientScriptBlock("rlst", "Store1.reload();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra khi tạo quyết định hàng loạt: " + ex.Message).Show();
        }
    }

    protected void btnHLDownload_Click(object sender, DirectEventArgs e)
    {
        DownloadAttachFile("HOSO_LUONG", hdfTepTinDinhKemHL);
    }

    protected void btnHLDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdfRecordID.Text != "")
        {
            DeleteTepTinDinhKem("HOSO_LUONG", decimal.Parse("0" + hdfTepTinDinhKemHL.Text), hdfTepTinDinhKemHL);
            hdfTepTinDinhKemHL.Text = "";
        }
    }

    [DirectMethod]
    public void DownloadAttach(string path)
    {
        try
        {
            string serverPath = Server.MapPath("") + "/" + path;
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

    [DirectMethod]
    public void GenerateSoQDHL()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOQDLUONG, Session["MaDonVi"].ToString());
        string soqd = new HoSoController().GenerateSoHopDong("HOSO_LUONG", "SoQuyetDinh", suffix);
        txtSoQDHL.Text = soqd;
    }
    /////////////////////////////////////////////////

    protected void cbxChonCanBo_Selected(object sender, DirectEventArgs e)
    {
        try
        {
            decimal prkey = decimal.Parse(cbxChonCanBo.SelectedItem.Value);
            HOSO hs = new HoSoController().GetByPrKey(prkey);
            if (hs != null)
            {
                // set general infomation
                if (hs.DM_CHUCVU != null)
                    txtChucVu.Text = hs.DM_CHUCVU.TEN_CHUCVU;
                if (hs.DM_CONGVIEC != null)
                    txtCongViec.Text = hs.DM_CONGVIEC.TEN_CONGVIEC;
                cbx_bophan.SetValue(hs.MA_DONVI);

                // get newest salary development
                DAL.HOSO_LUONG hsl = new HoSoLuongController().GetNewestSalaryDevelopment(prkey, -1);
                if (hsl != null)
                {
                    if (!string.IsNullOrEmpty(hsl.SoQuyetDinh))
                        txtSoQDCu.Text = hsl.SoQuyetDinh;
                    txtTenQDCu.Text = hsl.TenQuyetDinh;
                    dfNgayQDCu.SetValue(hsl.NgayQuyetDinh);
                    //if (hsl.HOSO != null)
                    //    txtNguoiQDCu.Text = hsl.HOSO.HO_TEN;
                    if (hsl.prKeyHoSoNguoiQuyetDinh != null)
                    {
                        #region Chơi bẩn tý :D
                        var ten = DataController.DataHandler.GetInstance().ExecuteScalar("SELECT HO_TEN FROM HOSO WHERE PR_KEY = " + hsl.prKeyHoSoNguoiQuyetDinh);
                        #endregion
                        txtNguoiQDCu.Text = ten.ToString();
                    }
                    dfNgayCoHieuLucCu.SetValue(hsl.NgayHieuLuc);
                    cbxNgachCu.SetValue(hsl.MaNgach);
                    if (!string.IsNullOrEmpty(hsl.BacLuong))
                        txtBacLuongCu.Text = hsl.BacLuong;
                    if (hsl.HeSoLuong != null)
                        txtHeSoLuongCu.SetValue(hsl.HeSoLuong);
                    if (hsl.LuongCung != null)
                        txtMucLuongCu.SetValue(hsl.LuongCung);
                    if (hsl.LuongDongBHXH != null)
                        txtLuongDongBHCu.SetValue(hsl.LuongDongBHXH);
                    if (hsl.PhanTramHuongLuong != null)
                        txtPhanTramHLCu.SetValue(hsl.PhanTramHuongLuong);
                    cbxLoaiLuongCu.SetValue(hsl.MaLoaiLuong);
                    object objTenLoaiHD = DataHandler.GetInstance().ExecuteScalar("HoSoNhanSu_QDLuong_LayTenHopDongCu", "@MaHOSOSoHD", decimal.Parse("0" + hsl.PrKeyHoSoHopDong));
                    if (objTenLoaiHD != null)
                        cbHopDongLoaiHopDongCu.Text = "" + objTenLoaiHD.ToString();
                }
                else
                {
                    txtSoQDCu.Text = "";
                    txtTenQDCu.Text = "";
                    dfNgayQDCu.SetValue("");
                    txtNguoiQDCu.Text = "";
                    dfNgayCoHieuLucCu.SetValue("");
                    cbxNgachCu.Text = "";
                    txtBacLuongCu.Text = "";
                    txtHeSoLuongCu.Text = "";
                    txtMucLuongCu.Text = "";
                    txtLuongDongBHCu.Text = "";
                    txtPhanTramHLCu.Text = "";
                    cbxLoaiLuongCu.Text = "";
                    cbHopDongLoaiHopDongCu.Text = "";
                }
            }
            else
            {
                txtChucVu.Text = "";
                txtCongViec.Text = "";
                cbx_bophan.Text = "";
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra khi chọn cán bộ: " + ex.Message).Show();
        }
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HoSoLuongController salaryController = new HoSoLuongController();
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                // delete phu cap
                new HoSoPhuCapPhucLoiController().DeleteByPrkeyHoSoLuong(int.Parse(item.RecordID));
                // delete salary decision
                salaryController.Delete(int.Parse(item.RecordID));
            }
            btnEdit.Disabled = true;
            btnDelete.Disabled = true;
            GridPanel1.Reload();
            grpPhuCap.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    /// <summary>
    /// Mở window thêm phụ cấp
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddPhuCap_Click(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.ExtraParams["ngayQuyetDinh"]))
        {
            dfNgayQuyetDinhPhuCap.SelectedDate = GetDateTimeFromString(e.ExtraParams["ngayQuyetDinh"]);
        }
        if (!string.IsNullOrEmpty(e.ExtraParams["ngayHieuLuc"]))
        {
            dfNgayHieuLucPhuCap.SelectedDate = GetDateTimeFromString(e.ExtraParams["ngayHieuLuc"]);
        }
        if (!string.IsNullOrEmpty(e.ExtraParams["hetHieuLuc"]))
        {
            dfHetHieuLucPhuCap.SelectedDate = GetDateTimeFromString(e.ExtraParams["hetHieuLuc"]);
        }
    }

    protected void btnSuaPhuCap_Click(object sender, DirectEventArgs e)
    {
        DAL.HOSO_PHUCAP phuCap = new HoSoPhuCapPhucLoiController().GetByID(int.Parse(e.ExtraParams["RecordID"]));
        if (phuCap != null)
        {
            txtHeSoPhuCap.Text = phuCap.HeSo > 0 ? phuCap.HeSo.ToString() : "";
            txtSoTien.Text = phuCap.SoTien > 0 ? phuCap.SoTien.ToString() : "";
            txtPhanTram.Text = phuCap.PhanTram > 0 ? phuCap.PhanTram.ToString() : "";
            cbLoaiPhuCap.SetValue(phuCap.MaPhuCap);
            if (!SoftCore.Util.GetInstance().IsDateNull(phuCap.NgayHetHieuLuc))
            {
                dfHetHieuLucPhuCap.SelectedDate = phuCap.NgayHetHieuLuc.Value;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(phuCap.NgayQuyetDinh))
            {
                dfNgayQuyetDinhPhuCap.SelectedDate = phuCap.NgayQuyetDinh.Value;
            }
            dfNgayHieuLucPhuCap.SelectedDate = phuCap.NgayHieuLuc.Value;
            // cbTrangThaiPhuCap.SetValue(phuCap.TrangThai);
            
            if (phuCap.prKeyHoSoNguoiQuyetDinh!=null)
            {
                object objTenNguoiQD = DataHandler.GetInstance().ExecuteScalar("HoSo_GetFullNameByPrKey", "@PrKeyHOSO", phuCap.prKeyHoSoNguoiQuyetDinh).ToString();
                cbNguoiQuyetDinhPhuCap.Text = objTenNguoiQD.ToString(); ;
            }
            hdfNguoiQuyetDinhPhuCap.Text = phuCap.prKeyHoSoNguoiQuyetDinh.ToString();
        }
        wdThemPhuCap.Show();
        X.Js.Call("btnCapNhatPhuCap.show");
        X.Js.Call("btnThemPhuCap.hide");
    }

    protected void btnDeletePhuCap_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HoSoPhuCapPhucLoiController phuCapController = new HoSoPhuCapPhucLoiController();
            foreach (var item in RowSelectionModel2.SelectedRows)
            {
                phuCapController.DeleteByID(int.Parse(item.RecordID));
                try
                {
                    //cập nhật biến động bảo hiểm
                    DataController.DataHandler.GetInstance().ExecuteNonQuery("[sp_BHCapNhatBienDongBaoHiemKhiThemSuaPhuCap]", "@IDQuyetDinhLuong", hdfRecordID.Text);
                }
                catch (Exception ex)
                {
                    Dialog.ShowError("" + ex.Message);
                }
            }
            grpPhuCap.Reload();
            btnDeletePhuCap.Disabled = true;
            btnSuaPhuCap.Disabled = true;
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnThemPhuCap_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_PHUCAP phuCap = new HOSO_PHUCAP()
            {
                FrKeyHOSO_LUONG = int.Parse(hdfRecordID.Text),
                MaPhuCap = int.Parse(cbLoaiPhuCap.SelectedItem.Value),
                SoTien = !string.IsNullOrEmpty(txtSoTien.Text) ? double.Parse(txtSoTien.Text.Replace('.', ',')) : 0,
                PhanTram = !string.IsNullOrEmpty(txtPhanTram.Text) ? double.Parse(txtPhanTram.Text.Replace('.', ',')) : 0,
                TrangThai = "DaDuyet", //cbTrangThaiPhuCap.SelectedItem.Value,
                HeSo = !string.IsNullOrEmpty(txtHeSoPhuCap.Text) ? double.Parse(txtHeSoPhuCap.Text.Replace('.', ',')) : 0,
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(dfNgayQuyetDinhPhuCap.SelectedDate))
            {
                phuCap.NgayQuyetDinh = dfNgayQuyetDinhPhuCap.SelectedDate;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(dfNgayHieuLucPhuCap.SelectedDate))
            {
                phuCap.NgayHieuLuc = dfNgayHieuLucPhuCap.SelectedDate;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(dfHetHieuLucPhuCap.SelectedDate))
            {
                phuCap.NgayHetHieuLuc = dfHetHieuLucPhuCap.SelectedDate;
            }
            if (!string.IsNullOrEmpty(hdfNguoiQuyetDinhPhuCap.Text))
            {
                phuCap.prKeyHoSoNguoiQuyetDinh = decimal.Parse(hdfNguoiQuyetDinhPhuCap.Text);
            }
            if (e.ExtraParams["Command"] == "Update")
            {
                phuCap.ID = int.Parse(e.ExtraParams["RecordID"]);
                // check exist phu cap
                bool isSuccess = new HoSoPhuCapPhucLoiController().UpdateNgayHetHieuLucPhuCap(phuCap);
                if (isSuccess == true)
                {
                    new HoSoPhuCapPhucLoiController().Update(phuCap);
                }
                else
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Ngày hiệu lực của phụ cấp mới phải lớn hơn ngày hiệu lực của phụ cấp cùng loại trước đó").Show();
                    return;
                }
            }
            else
            {
                // check exist phu cap
                bool isSuccess = new HoSoPhuCapPhucLoiController().UpdateNgayHetHieuLucPhuCap(phuCap);
                if (isSuccess == true)
                {
                    // add phu cap
                    new HoSoPhuCapPhucLoiController().Add(phuCap);
                }
                else
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Loại phụ cấp này đã tồn tại. Ngày hiệu lực của phụ cấp mới phải lớn hơn ngày hiệu lực của phụ cấp cùng loại trước đó").Show();
                    return;
                }
            }
            try
            {
                //cập nhật biến động bảo hiểm
                DataController.DataHandler.GetInstance().ExecuteNonQuery("[sp_BHCapNhatBienDongBaoHiemKhiThemSuaPhuCap]", "@IDQuyetDinhLuong", hdfRecordID.Text);
            }
            catch (Exception ex)
            {
                Dialog.ShowError("" + ex.Message);
            }
            grpPhuCap.Reload();
            wdThemPhuCap.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion

    private DateTime GetDateTimeFromString(string dateTime)
    {
        string[] date = dateTime.Remove(dateTime.IndexOf("T")).Split('-');
        return new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
    }

    /// <summary>
    /// Sửa thông tin quyết định lương
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_LUONG hsLuong = new HoSoLuongController().GetByID(int.Parse(hdfRecordID.Text));
            if (hsLuong == null)
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy quyết định lương").Show();
                return;
            }
            // load general information for employee
            HOSO hs = new HoSoController().GetByPrKey(hsLuong.PrKeyHoSo);
            if (hs != null)
            {
                hdfChonCanBo.Text = hs.PR_KEY.ToString();
                cbxChonCanBo.Text = hs.HO_TEN;
                cbx_bophan.SetValue(hs.MA_DONVI);
                if (hs.DM_CHUCVU != null)
                    txtChucVu.Text = hs.DM_CHUCVU.TEN_CHUCVU;
                if (hs.DM_CONGVIEC != null)
                    txtCongViec.Text = hs.DM_CONGVIEC.TEN_CONGVIEC;
            }
            // load newest salary decision information
            DAL.HOSO_LUONG hsl = new HoSoLuongController().GetNewestSalaryDevelopment(hsLuong.PrKeyHoSo, -1);
            if (hsl != null)
            {
                if (txtSoQDCu.Visible == true && !string.IsNullOrEmpty(hsl.SoQuyetDinh))
                    txtSoQDCu.Text = hsl.SoQuyetDinh;
                if (txtTenQDCu.Visible == true)
                    txtTenQDCu.Text = hsl.TenQuyetDinh;
                if (dfNgayQDCu.Visible == true)
                    dfNgayQDCu.SetValue(hsl.NgayQuyetDinh);
                //if (txtNguoiQDCu.Visible == true && hsl.HOSO != null)
                //    txtNguoiQDCu.Text = hsl.HOSO.HO_TEN;
                if (txtNguoiQDCu.Visible == true && hsl.prKeyHoSoNguoiQuyetDinh != null)
                {
                    #region Chơi bẩn tý :D
                    var ten = DataController.DataHandler.GetInstance().ExecuteScalar("SELECT HO_TEN FROM HOSO WHERE PR_KEY = " + hsl.prKeyHoSoNguoiQuyetDinh);
                    #endregion
                    txtNguoiQDCu.Text = ten.ToString();
                }
                if (dfNgayCoHieuLucCu.Visible == true)
                    dfNgayCoHieuLucCu.SetValue(hsl.NgayHieuLuc);
                if (cbxNgachCu.Visible == true)
                    cbxNgachCu.SetValue(hsl.MaNgach);
                if (txtBacLuongCu.Visible == true && !string.IsNullOrEmpty(hsl.BacLuong))
                    txtBacLuongCu.Text = hsl.BacLuong;
                if (txtHeSoLuongCu.Visible == true && hsl.HeSoLuong != null)
                    txtHeSoLuongCu.SetValue(hsl.HeSoLuong);
                if (txtMucLuongCu.Visible == true && hsl.LuongCung != null)
                    txtMucLuongCu.SetValue(hsl.LuongCung);
                if (txtLuongDongBHCu.Visible == true && hsl.LuongDongBHXH != null)
                    txtLuongDongBHCu.SetValue(hsl.LuongDongBHXH);
                if (txtPhanTramHLCu.Visible == true && hsl.PhanTramHuongLuong != null)
                    txtPhanTramHLCu.SetValue(hsl.PhanTramHuongLuong);
                if (cbxLoaiLuongCu.Visible == true)
                    cbxLoaiLuongCu.SetValue(hsl.MaLoaiLuong);
                object objTenLoaiHD = DataHandler.GetInstance().ExecuteScalar("HoSoNhanSu_QDLuong_LayTenHopDongCu", "@MaHOSOSoHD", decimal.Parse("0" + hsl.PrKeyHoSoHopDong));
                if (objTenLoaiHD != null)
                    cbHopDongLoaiHopDongCu.Text = objTenLoaiHD.ToString();
            }
            // load current decision information
            if (txtSoQDMoi.Visible == true)
                txtSoQDMoi.Text = hsLuong.SoQuyetDinh;
            if (dfNgayQDMoi.Visible == true)
                dfNgayQDMoi.SetValue(hsLuong.NgayQuyetDinh);
            if (txtTenQDMoi.Visible == true)
                txtTenQDMoi.Text = hsLuong.TenQuyetDinh;
            if (dfNgayHieuLucMoi.Visible == true)
                dfNgayHieuLucMoi.SetValue(hsLuong.NgayHieuLuc);
            if (dfNgayHetHieuLucMoi.Visible == true && !SoftCore.Util.GetInstance().IsDateNull(hsLuong.NgayKetThucHieuLuc))
                dfNgayHetHieuLucMoi.SetValue(hsLuong.NgayKetThucHieuLuc);
            hdfNguoiQuyetDinh.Text = hsLuong.prKeyHoSoNguoiQuyetDinh.ToString();
            if (cbxChonNguoiQuyetDinh.Visible == true && hsLuong.prKeyHoSoNguoiQuyetDinh != null)
            {
                #region Chơi bẩn tý :D
                var ten = DataController.DataHandler.GetInstance().ExecuteScalar("SELECT HO_TEN FROM HOSO WHERE PR_KEY = " + hsLuong.prKeyHoSoNguoiQuyetDinh);
                #endregion
                cbxChonNguoiQuyetDinh.Text = ten.ToString();
            }
            if (hsLuong.PrKeyHoSoHopDong != null)
            {
                hdfLoaiHopDong.SetValue(hsLuong.PrKeyHoSoHopDong);
                object objTenLoaiHD = DataHandler.GetInstance().ExecuteScalar("HoSoNhanSu_QDLuong_LayTenHopDongCu", "@MaHOSOSoHD", decimal.Parse("0" + hsLuong.PrKeyHoSoHopDong));
                if (objTenLoaiHD != null)
                    cbHopDongLoaiHopDongMoi.Text = "" + objTenLoaiHD.ToString();
            }
            // them ten nguoi qd
            //  cbTrangThaiMoi.SetValue(hsLuong.TrangThai);
            hsl.TrangThai = "DaDuyet";
            if (composifieldAttach.Visible == true)
            {
                hdfTepTinDinhKem.Text = hsLuong.TepTinDinhKem;
                if (!string.IsNullOrEmpty(hsLuong.TepTinDinhKem))
                {
                    hdfTepTinDinhKem.Text = hsLuong.TepTinDinhKem;
                    fufTepTinDinhKem.Text = GetFileName(hsLuong.TepTinDinhKem);
                }
            }
            if (txtGhiChuMoi.Visible == true)
                txtGhiChuMoi.Text = hsLuong.GhiChu;
            // load current salary information
            if (cbx_ngachMoi.Visible == true)
                cbx_ngachMoi.SetValue(hsLuong.MaNgach);
            if (cbxBacMoi.Visible == true)
                cbxBacMoi.SetValue(hsLuong.BacLuong);
            if (txtHeSoLuongMoi.Visible == true)
                txtHeSoLuongMoi.SetValue(hsLuong.HeSoLuong);
            if (txtMucLuongMoi.Visible == true)
                txtMucLuongMoi.SetValue(hsLuong.LuongCung);
            if (txtLuongDongBHMoi.Visible == true)
                txtLuongDongBHMoi.SetValue(hsLuong.LuongDongBHXH);
            if (dfNgayHLMoi.Visible == true && !SoftCore.Util.GetInstance().IsDateNull(hsLuong.NgayHuongLuong))
                dfNgayHLMoi.SetValue(hsLuong.NgayHuongLuong);
            if (txtBacLuongNBMoi.Visible == true)
                txtBacLuongNBMoi.Text = hsLuong.BacLuongNB;
            if (dfNgayHLNBMoi.Visible == true && !SoftCore.Util.GetInstance().IsDateNull(hsLuong.NgayHuongLuongNB))
                dfNgayHLNBMoi.SetValue(hsLuong.NgayHuongLuongNB);
            if (txtPhanTramHLMoi.Visible == true)
                txtPhanTramHLMoi.SetValue(hsLuong.PhanTramHuongLuong);
            if (txtLuongTrachNhiemMoi.Visible)
                txtLuongTrachNhiemMoi.SetValue(hsLuong.LuongTrachNhiem);
            if (cbLoaiLuong.Visible == true)
                cbLoaiLuong.SetValue(hsLuong.MaLoaiLuong);

            // update form information
            chkSuDungPhuCapCu.Hide();
            wdTaoQuyetDinhLuong.Title = "Cập nhật thông tin quyết định lương";
            wdTaoQuyetDinhLuong.Icon = Icon.Pencil;
            wdTaoQuyetDinhLuong.Show();
            X.Js.Call("btnCapNhat.hide");
            X.Js.Call("btnCapNhatDongLai.hide");
            X.Js.Call("btnCapNhatSua.show");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra: ", ex.Message).Show();
        }
    }

    protected void cbLoaiLuongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbxLoaiLuongCu_Store.DataSource = new DM_LOAI_LUONGController().GetAll();
            cbxLoaiLuongCu_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    #region store onrefreshdata
    protected void cbHopDongLoaiHopDongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hdfChonCanBo.Text))
            {
                List<HoSoHopDongInfo> datas = new HOSO_HOPDONGController().GetAllByFrkey(decimal.Parse(hdfChonCanBo.Text));
                if (datas.Count() == 0)
                {
                    RM.RegisterClientScriptBlock("rl1", "alert('Không tìm thấy hợp đồng nào còn hiệu lực. Vui lòng tạo hợp đồng mới trước khi tạo quyết định lương!');");
                }
                cbHopDongLoaiHopDongStore.DataSource = datas;
                cbHopDongLoaiHopDongStore.DataBind();
            }
            else
            {
                cbHopDongLoaiHopDongStore.DataSource = new List<HoSoHopDongInfo>();
                cbHopDongLoaiHopDongStore.DataBind();
                RM.RegisterClientScriptBlock("rl", "alert('Bạn chưa chọn cán bộ'); cbxChonCanBo.focus();");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    public void cbxBacStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DM_NHOM_NGACH nhom = new DanhMucNhomNgachController().GetByMaNgach(cbx_ngachMoi.SelectedItem.Value);
        if (nhom != null)
        {
            List<StoreComboObject> objs = new List<StoreComboObject>();
            for (int i = 1; i <= nhom.SOBAC_TOIDA; i++)
            {
                StoreComboObject stob = new StoreComboObject
                {
                    MA = i.ToString(),
                    TEN = "Bậc " + i
                };
                objs.Add(stob);
            }
            cbxBacStore.DataSource = objs;
            cbxBacStore.DataBind();
        }
    }

    protected void cbxBacLuongHLStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DM_NHOM_NGACH nhom = new DanhMucNhomNgachController().GetByMaNgach(cbxNgachHL.SelectedItem.Value);
        if (nhom != null)
        {
            List<StoreComboObject> objs = new List<StoreComboObject>();
            for (int i = 1; i <= nhom.SOBAC_TOIDA; i++)
            {
                StoreComboObject stob = new StoreComboObject
                {
                    MA = i.ToString(),
                    TEN = "Bậc " + i
                };
                objs.Add(stob);
            }
            cbxBacLuongHLStore.DataSource = objs;
            cbxBacLuongHLStore.DataBind();
        }
    }

    protected void cbxNgachCu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxNgachCu_Store.DataSource = new DM_NGACHController().GetAll1();
        cbxNgachCu_Store.DataBind();
    }

    protected void grpPhuCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        grpPhuCapStore.DataSource = new HoSoPhuCapPhucLoiController().GetListPhuCap(int.Parse(hdfRecordID.Text));
        grpPhuCapStore.DataBind();
    }

    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(Session["MaDonVi"].ToString());
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            obj.Add(new { MA = info.MA, TEN = info.TEN });
            obj = LoadMenuCon(obj, info.MA, 1);
        }
        cbx_bophan_Store.DataSource = obj;
        cbx_bophan_Store.DataBind();
    }

    private List<object> LoadMenuCon(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "- ";
            obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            obj = LoadMenuCon(obj, item.MA, k + 1);
        }
        return obj;
    }

    protected void cbLoaiPhuCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            var count = 0;
            cbLoaiPhuCapStore.DataSource = new DanhMucPhuCapPhucLoiController().GetAllDonVi(Session["MaDonVi"].ToString(), out count);
            cbLoaiPhuCapStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion

    [DirectMethod]
    public void GetThongTinLuong()
    {
        DM_MUCLUONG_NGACHInfo info = new DM_MUCLUONG_NGACHController().GetByMaNgachAndBacLuong(cbx_ngachMoi.SelectedItem.Value, int.Parse(cbxBacMoi.SelectedItem.Value));
        if (info != null)
        {
            txtHeSoLuongMoi.SetValue(info.HeSoLuong);
            txtMucLuongMoi.SetValue(info.MucLuong);
        }
        else
        {
            txtHeSoLuongMoi.Text = "0";
            txtMucLuongMoi.Text = "0";
        }
    }

    [DirectMethod]
    public void GetThongTinLuong1()
    {
        DM_MUCLUONG_NGACHInfo info = new DM_MUCLUONG_NGACHController().GetByMaNgachAndBacLuong(cbxNgachHL.SelectedItem.Value, int.Parse(cbxBacLuongHL.SelectedItem.Value));
        if (info != null)
        {
            txtHeSoLuongHL.SetValue(info.HeSoLuong);
            txtMucLuongHL.SetValue(info.MucLuong);
        }
        else
        {
            txtHeSoLuongHL.Text = "0";
            txtMucLuongHL.Text = "0";
        }
    }
}