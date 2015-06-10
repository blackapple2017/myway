using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using System.Data;
using System.IO;
using ExtMessage;
using SoftCore;
using System.Text.RegularExpressions;
using DAL;
using DataController;

public partial class Modules_HoSoNhanSu_QuanLy_HopDong : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!X.IsAjaxRequest)
        {
            hdfUserID.Text = CurrentUser.ID.ToString();
            hdfMenuID.Text = MenuID.ToString();
            // load west
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');#{txtSearch}.reset();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();"
            }.AddDepartmentList(brlayout, CurrentUser.ID, true);
            SetVisibleByControlID(btnAdd, btnEdit, btnDelete);
        }
        if (btnEdit.Visible)
        {
            RowSelectionModel1.Listeners.RowSelect.Handler += "btnEdit.enable(); ";
            RowSelectionModel1.Listeners.RowDeselect.Handler += "btnEdit.disable(); ";
            grp_HopDong.Listeners.RowDblClick.Handler += "if(CheckSelectedRows(grp_HopDong)){btnUpdateHopDong.hide();btnEditHopDong.show();Button20.hide();}";
            grp_HopDong.DirectEvents.RowDblClick.Event += btnEdit_Click;
        }
        if (btnDelete.Visible)
        {
            RowSelectionModel1.Listeners.RowSelect.Handler += "btnDelete.enable(); ";
            RowSelectionModel1.Listeners.RowDeselect.Handler += "btnDelete.disable(); ";
        }
        ucChooseEmployee.AfterClickAcceptButton += new EventHandler(ucChooseEmployee_AfterClickAcceptButton);
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);

    }

    private void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        SelectedRowCollection SelectedRow = ucChooseEmployee1.SelectedRow;
        foreach (var item in SelectedRow)
        {
            DAL.HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
            switch (hdfTypeWindow.Text)
            {
                case "One":
                    tgf_NguoiKyHD.Text = hs.HO_TEN;
                    hdfPrkeyNguoiKyHD.Text = hs.PR_KEY.ToString();
                    break;
                case "More":
                    hdfNguoiKyHangLoat.Text = hs.PR_KEY.ToString();
                    txt_NguoiKyHDHL2.Text = hs.HO_TEN;
                    break;
                default:
                    break;
            }
        }
    }
    #region Combobox OnRefresh
    protected void cbHopDongLoaiHopDongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbHopDongLoaiHopDongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LOAI_HDONG,TEN_LOAI_HDONG from DM_LOAI_HDONG");
            cbHopDongLoaiHopDongStore.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void cbHopDongTinhTrangHopDongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbHopDongTinhTrangHopDongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TT_HDONG,TEN_TT_HDONG from DM_TT_HDONG");
            cbHopDongTinhTrangHopDongStore.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void StoreCongViec_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        StoreCongViec.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_CONGVIEC, TEN_CONGVIEC from DM_CONGVIEC");
        StoreCongViec.DataBind();
    }

    protected void cbx_HopDongChucVu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_HopDongChucVu_Store.DataSource = new DanhMucChucVuController().GetAll();
        cbx_HopDongChucVu_Store.DataBind();
    }
    #endregion

    #region DirecMethods
    [DirectMethod]
    public void GenerateSoQD()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOHOPDONG, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_HOPDONG", "SO_HDONG", suffix);
        txtHopDongSoHopDong.Text = sohd;
    }
    [DirectMethod]
    public void GenerateSoQDHL()
    {
        string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOHOPDONG, Session["MaDonVi"].ToString());
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_HOPDONG", "SO_HDONG", suffix);
        txtHopDongSoHopDongHL.Text = sohd;
    }
    [DirectMethod]
    public void SetNgayHetHD()
    {
        string ma_hd = cbHopDongLoaiHopDong.SelectedItem != null ? cbHopDongLoaiHopDong.SelectedItem.Value : "";
        if (ma_hd != "" && !dfNgayCoHieuLuc.SelectedDate.ToString().Contains("0001"))
        {
            string month = new DM_LOAI_HDONGController().GetMonth(ma_hd);
            int mont = int.Parse("0" + month);
            if (mont > 0)
            {
                DateTime ngay_bd = dfNgayCoHieuLuc.SelectedDate;
                ngay_bd = ngay_bd.AddMonths(mont);
                ngay_bd = ngay_bd.AddDays(-1);

                dfHopDongNgayKiKet.SetValue(ngay_bd);
            }
        }
    }
    [DirectMethod]
    public void SetNgayHetHDHL()
    {
        string ma_hd = cbHopDongLoaiHopDongHL.SelectedItem != null ? cbHopDongLoaiHopDongHL.SelectedItem.Value : "";
        if (ma_hd != "" && !dfNgayCoHieuLucHL.SelectedDate.ToString().Contains("0001"))
        {
            string month = new DM_LOAI_HDONGController().GetMonth(ma_hd);
            int mont = int.Parse("0" + month);
            if (mont > 0)
            {
                DateTime ngay_bd = dfNgayCoHieuLucHL.SelectedDate;
                ngay_bd = ngay_bd.AddMonths(mont);
                ngay_bd = ngay_bd.AddDays(-1);

                dfHopDongNgayKiKetHL.SetValue(ngay_bd);
            }
        }
    }
    #endregion

    #region DirectEvent
    protected void btnUpdateHopDong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufHopDongTepTin.HasFile)
            {
                string directory = Server.MapPath("../");
                path = UploadFile(fufHopDongTepTin, "File/HopDong");
            }
            DAL.HOSO_HOPDONG hopdong = new HOSO_HOPDONG()
            {
                FR_KEY = decimal.Parse(hdfPrKey.Text),
                MA_CONGVIEC = cbHopDongCongViec.SelectedItem.Value,
                MA_LOAI_HDONG = cbHopDongLoaiHopDong.SelectedItem.Value,
                MA_TT_HDONG = cbHopDongTinhTrangHopDong.SelectedItem.Value,
                NGAY_HDONG = dfHopDongNgayHopDong.SelectedDate,
                TrangThaiHopDong = "DaDuyet"
            };
            // sinh số hợp đồng
            string suffix = new HeThongController().GetValueByName(SystemConfigParameter.SUFFIX_SOHOPDONG, Session["MaDonVi"].ToString());
            hopdong.SO_HDONG = new HoSoController().GenerateSoHopDong("HOSO_HOPDONG", "SO_HDONG", suffix);
            if (!string.IsNullOrEmpty(txtHopDongSoHopDong.Text))
                hopdong.SO_HDONG = txtHopDongSoHopDong.Text;

            if (!dfHopDongNgayKiKet.SelectedDate.ToString().Contains("0001"))
                hopdong.NGAYKT_HDONG = dfHopDongNgayKiKet.SelectedDate;
            if (!dfNgayCoHieuLuc.SelectedDate.ToString().Contains("0001"))
                hopdong.NgayCoHieuLuc = dfNgayCoHieuLuc.SelectedDate;

            if (!string.IsNullOrEmpty(hdfPrkeyNguoiKyHD.Text))
            {
                hopdong.PrkeyNguoiDaiDienKyHD = decimal.Parse("0" + hdfPrkeyNguoiKyHD.Text);
            }
            //hopdong.PrkeyNguoiDaiDienKyHD = txt_NguoiKyHD.Text;
            //if (cbx_HopDongChucVu.SelectedItem.Value != null)
            //    hopdong.MaChucVuNguoiKyHD = cbx_HopDongChucVu.SelectedItem.Value;
            if (path != "")
                hopdong.TepTinDinhKem = path;
            else
                hopdong.TepTinDinhKem = hdfHopDongTepTinDK.Text;
            hopdong.GhiChu = txtHopDongGhiChu.Text;
            hopdong.CreatedBy = CurrentUser.ID;
            hopdong.CreatedDate = DateTime.Now;
            if (e.ExtraParams["Command"] == "Update")
            {
                hopdong.PR_KEY = decimal.Parse("0" + hdfRecordID.Text);
                new HOSO_HOPDONGController().Update(hopdong);
                // update Hợp đồng lại Hồ sơ nếu như có sự thay đổi
                if (hopdong.MA_LOAI_HDONG != hdfMaHopDongOld.Text)
                {
                    new HoSoController().UpdateLoaiHopDong(hopdong.MA_LOAI_HDONG, hopdong.FR_KEY);
                }
                wdHopDong.Hide();
            }
            else
            {
                // kiểm tra còn hợp đồng nào chưa hết hạn không
                if (new HOSO_HOPDONGController().CheckBeforeInsert(decimal.Parse(hdfRecordID.Text), hopdong.NgayCoHieuLuc) == false)  // cán bộ còn ít nhất 1 hợp đồng có giá trị
                {
                    X.Msg.Alert("Thông báo", "Hợp đồng hiện tại của cán bộ vẫn còn hiệu lực. Bạn không được phép thay đổi loại hợp đồng.").Show();
                    return;
                }
                new HOSO_HOPDONGController().Insert(hopdong);
                // update hợp đồng mới vào Hồ sơ nhân sự
                new HoSoController().UpdateLoaiHopDong(hopdong.MA_LOAI_HDONG, hopdong.FR_KEY);

                if (e.ExtraParams["Close"] == "True")
                {
                    wdHopDong.Hide();
                }
                else
                {
                    GenerateSoQD();
                }
            }
            grp_HopDong.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnHopDongAttachDownload_Click(object sender, DirectEventArgs e)
    {
        string directory = Server.MapPath("");
        DownloadAttachFile("HOSO_HOPDONG", hdfHopDongTepTinDK);
    }

    protected void btnHopDongAttachDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hdfRecordID.Text))
            {
                DeleteTepTinDinhKem("HOSO_HOPDONG", decimal.Parse(hdfRecordID.Text), hdfHopDongTepTinDK);
                hdfHopDongTepTinDK.Reset();
                fufHopDongTepTin.Reset();
                hdfHopDongTepTinDKHL.Reset();
                //grp_HopDong.Reload();
            }
            else
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa!");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string id = hdfRecordID.Text;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_HOPDONG hopdong = new HoSoController().GetHopDong(decimal.Parse(id));
                txtHopDongSoHopDong.Text = hopdong.SO_HDONG;
                cbHopDongLoaiHopDong.SetValue(hopdong.MA_LOAI_HDONG);
                hdfMaHopDongOld.Text = hopdong.MA_LOAI_HDONG;
                cbHopDongTinhTrangHopDong.SetValue(hopdong.MA_TT_HDONG);
                cbHopDongCongViec.SetValue(hopdong.MA_CONGVIEC);
                if (hopdong.NGAYKT_HDONG != null && !hopdong.NGAYKT_HDONG.ToString().Contains("0001"))
                    dfHopDongNgayKiKet.SetValue(hopdong.NGAYKT_HDONG);
                if (hopdong.NGAY_HDONG != null && !hopdong.NGAY_HDONG.ToString().Contains("0001"))
                    dfHopDongNgayHopDong.SetValue(hopdong.NGAY_HDONG);
                if (hopdong.NgayCoHieuLuc != null && !hopdong.NgayCoHieuLuc.ToString().Contains("0001"))
                    dfNgayCoHieuLuc.SetValue(hopdong.NgayCoHieuLuc);

                hdfPrkeyNguoiKyHD.Text = hopdong.PrkeyNguoiDaiDienKyHD.ToString();
                #region Chơi bẩn tý :D
                if (!string.IsNullOrEmpty(hopdong.PrkeyNguoiDaiDienKyHD.ToString()))
                {
                    var ten = DataController.DataHandler.GetInstance().ExecuteScalar("SELECT HO_TEN FROM HOSO WHERE PR_KEY = " + hopdong.PrkeyNguoiDaiDienKyHD);
                
                    if (ten != null)
                    {
                        tgf_NguoiKyHD.Text = ten.ToString();
                    }
                }
                #endregion
                //cbx_HopDongChucVu.SetValue(hopdong.MaChucVuNguoiKyHD);
                if (!string.IsNullOrEmpty(hopdong.TepTinDinhKem))
                {
                    int pos = hopdong.TepTinDinhKem.LastIndexOf('/');
                    if (pos != -1)
                    {
                        string tenTT = hopdong.TepTinDinhKem.Substring(pos + 1);
                        fufHopDongTepTin.Text = tenTT;
                    }
                    hdfHopDongTepTinDK.Text = hopdong.TepTinDinhKem;
                }

                txtHopDongGhiChu.Text = hopdong.GhiChu;

                wdHopDong.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                new HOSO_HOPDONGController().Delete(decimal.Parse("0" + item.RecordID));
            }
            RM.RegisterClientScriptBlock("Grid_Reload", "ReloadGrid();");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    public void ucChooseEmployee_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            hdfTotalRecord.Text = ucChooseEmployee.SelectedRow.Count.ToString();
            foreach (var item in ucChooseEmployee.SelectedRow)
            {
                // get employee information
                DAL.HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
                string pr_keyhoso = hs.PR_KEY.ToString();
                string ma_cb = hs.MA_CB;
                string ho_ten = hs.HO_TEN;
                string ten_donvi = new DM_DONVIController().GetNameById(hs.MA_DONVI);
                // insert record to grid
                RM.RegisterClientScriptBlock("insert" + pr_keyhoso, string.Format("addRecord('{0}', '{1}', '{2}', '{3}');", pr_keyhoso, ma_cb, ho_ten, ten_donvi));
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    public string UploadFile(object sender, string relativePath)
    {
        FileUploadField obj = (FileUploadField)sender;
        HttpPostedFile file = obj.PostedFile;
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("../") + relativePath);  // save file to directory HoSoNhanSu/File
        // if directory not exist then create this
        if (dir.Exists == false)
            dir.Create();
        string rdstr = SoftCore.Util.GetInstance().GetRandomString(7);
        string path = Server.MapPath("../") + relativePath + "/" + rdstr + "_" + obj.FileName;
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
            string serverPath = Server.MapPath("../") + sender.Text;
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
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }

    public void DeleteTepTinDinhKem(string tableName, decimal prkey, Hidden sender)
    {
        try
        {
            // xóa trong csdl
            //   DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteTepTinDinhKem", "@TableName", "@Prkey", tableName, prkey).ToString();
            // xóa file trong thư mục
            string serverPath = Server.MapPath("../") + sender.Text;
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
    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        try
        {
            ChangeRecords<ShortHoSoInfo> hd = e.DataHandler.ObjectData<ShortHoSoInfo>();
            string er = string.Empty;
            foreach (ShortHoSoInfo created in hd.Created)
            {
                // upload file
                string path = string.Empty;
                if (fufHopDongTepTinHL.HasFile)
                {
                    string directory = Server.MapPath("../");
                    path = UploadFile(fufHopDongTepTinHL, "File/HopDong");
                }
                DAL.HOSO_HOPDONG hopdong = new HOSO_HOPDONG()
                {
                    FR_KEY = created.PR_KEY,
                    MA_CONGVIEC = cbHopDongCongViecHL.SelectedItem.Value,
                    MA_LOAI_HDONG = cbHopDongLoaiHopDongHL.SelectedItem.Value,
                    MA_TT_HDONG = cbHopDongTinhTrangHopDongHL.SelectedItem.Value,
                    NGAY_HDONG = dfHopDongNgayHopDongHL.SelectedDate,
                    TrangThaiHopDong = ""
                };
                hopdong.SO_HDONG = txtHopDongSoHopDongHL.Text;
                if (!dfHopDongNgayKiKetHL.SelectedDate.ToString().Contains("0001"))
                    hopdong.NGAYKT_HDONG = dfHopDongNgayKiKetHL.SelectedDate;
                if (!dfNgayCoHieuLucHL.SelectedDate.ToString().Contains("0001"))
                    hopdong.NgayCoHieuLuc = dfNgayCoHieuLucHL.SelectedDate;
                if (!string.IsNullOrEmpty(hdfNguoiKyHangLoat.Text))
                {
                    hopdong.PrkeyNguoiDaiDienKyHD = decimal.Parse("0" + hdfNguoiKyHangLoat.Text);
                }
                //if (cbx_HopDongChucVuHL.SelectedItem.Value != null)
                //    hopdong.MaChucVuNguoiKyHD = cbx_HopDongChucVuHL.SelectedItem.Value;
                if (path != "")
                    hopdong.TepTinDinhKem = path;
                else
                    hopdong.TepTinDinhKem = hdfHopDongTepTinDKHL.Text;
                hopdong.GhiChu = txtHopDongGhiChuHL.Text;
                hopdong.CreatedBy = CurrentUser.ID;
                hopdong.CreatedDate = DateTime.Now;
                if (new HOSO_HOPDONGController().CheckBeforeInsert(created.PR_KEY, hopdong.NgayCoHieuLuc) == true)
                {
                    new HOSO_HOPDONGController().Insert(hopdong);
                    new HoSoController().UpdateLoaiHopDong(hopdong.MA_LOAI_HDONG, hopdong.FR_KEY);

                    //X.Msg.Alert("Thông báo", "Hợp đồng hiện tại của cán bộ vẫn còn hiệu lực. Bạn không được phép thay đổi loại hợp đồng.").Show();
                    //return;
                }
                else
                {
                    er += created.MA_CB + ", ";
                }
            }
            if (!string.IsNullOrEmpty(er))
            {
                X.Msg.Alert("Thông báo", "Hợp đồng hiện tại của cán bộ có mã: " + er + " vẫn còn hiệu lực. Bạn không được phép thay đổi loại hợp đồng.").Show();
            }
            wdHopDongHangLoat.Hide();
            grp_HopDong.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    [DirectMethod]
    public void DownloadAttach(string path)
    {
        try
        {
            string serverPath = Server.MapPath("../") + path;
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            string str = path.Replace(" ", "_");
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + str);
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }
}