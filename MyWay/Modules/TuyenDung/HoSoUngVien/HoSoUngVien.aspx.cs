using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Ext.Net;
using DataController;
using ExtMessage;
using DAL;
using System.Net.Mail;
using SoftCore;
using SoftCore.Security;
using System.IO;
using SoftCore.Utilities;
using System.Collections;
using Controller.ThoiViec;
using System.Text;

public partial class Modules_NhanSu_KEHOACH_TUYENDUNG : WebBase
{
    private int a = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        df_NgayPhongVan.MinDate = DateTime.Now;
        df_NgayPhongVan.SetValue(DateTime.Now);
        df_NgayCap.MaxDate = DateTime.Now;
        dfKNLVTuNgay.MaxDate = DateTime.Now;
        dfNgayThiTuyen.MaxDate = DateTime.Now;
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
        uscTuyenDung_HoSoUngVien1.AfterUpdate += new EventHandler(uscTuyenDung_HoSoUngVien1_AfterUpdate);
        spnYear.SetValue(DateTime.Now.Year);
    }
    #region xuất dữ liệu ra Excel
    /// <summary>
    /// Xuất bảng lương
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportExcel_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int start = 0, limit = 10000000;
            try
            {
                limit = PagingToolbar1.PageIndex * int.Parse("0" + ComboBox1.Text);
                start = limit - int.Parse("0" + ComboBox1.Text);
            }
            catch (Exception ex) { }
            //Create Tempory Table
            var dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable("tuyendung_danhsachUV_ExportToExcel", "@SearchKey", "@DotTuyenDung", "@Start", "@Limit","@month", "@year", "@checkToHOSO",
                "%" + SoftCore.Util.GetInstance().GetKeyword(HoSoUngVien_txtSearchKey.Text) + "%", int.Parse("0" + cbx_dottuyendung.SelectedItem.Value), start, limit, cbxMonth.SelectedItem.Value, hdfYear.Value, (ck_ViewChuyenVaoHOSO.Checked ? 1 : 0));


            ExportToExcel("HOSOUNGVIENTUYENDUNG.xls", dtTemp, "Danh sách ứng viên tuyển dụng");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void ExportToExcel(string fileName, DataTable table, string title)
    {
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        Response.AddHeader("Content-Disposition", "Attachment; Filename=" + fileName);
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        try
        {
            StringBuilder sb = new StringBuilder();
            //Tạo dòng tiêu để cho bảng tính
            sb.Append(title);
            Response.Write(sb.ToString() + "\n\n");
            Response.Flush();
            sb = new StringBuilder();
            for (int count = 0; count < table.Columns.Count; count++)
            {
                if (table.Columns[count].ColumnName != null)
                    sb.Append(table.Columns[count].ColumnName);
                if (count < table.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi 
            int soDem = 0;
            while (table.Rows.Count >= soDem + 1)
            {
                sb = new StringBuilder();


                for (int col = 0; col < table.Columns.Count - 1; col++)
                {
                    if (table.Rows[soDem][col] != null)
                        sb.Append(table.Rows[soDem][col].ToString().Replace(",", " "));
                    sb.Append("\t");
                }
                if (table.Rows[soDem][table.Columns.Count - 1] != null)
                    sb.Append(table.Rows[soDem][table.Columns.Count - 1].ToString().Replace(",", " "));


                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                soDem = soDem + 1;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        table.Dispose();
        Response.End();
    }
    #endregion
    void uscTuyenDung_HoSoUngVien1_AfterUpdate(object sender, EventArgs e)
    {
        GridPanel1.Reload();
        checkboxSelection.ClearSelections();
        resetTabPanelAfterUpdate();
        btnDelete.Disabled = true;
        btnEdit.Disabled = true;
        btnNext.Disabled = true;
        btnPrint.Disabled = true;
        SetVisibleByRole();
    }
    /// <summary>
    /// Phân quyền
    /// </summary>
    private void SetVisibleByRole()
    {
        btn_Add_ChungChi.Disabled = true;
        btn_Edit_ChungChi.Disabled = true;
        btn_Delete_ChungChi.Disabled = true;
        btn_Add_KNLV.Disabled = true;
        btn_Edit_KNLV.Disabled = true;
        btn_Delete_KNLV.Disabled = true;
        btn_Add_QuaTrinhHocTap.Disabled = true;
        btn_Edit_QuaTrinhHocTap.Disabled = true;
        btn_Delete_QuaTrinhHocTap.Disabled = true;
        btn_Add_File.Disabled = true;
        btn_Download_File.Disabled = true;
        btn_Delete_File.Disabled = true;
        btn_Add_KetQuaPV.Disabled = true;
        btn_Edit_KetQuaPV.Disabled = true;
        btn_Delete_KetQuaPV.Disabled = true;
    }
    private void resetTabPanelAfterUpdate()
    {
        img_anhdaidien.ImageUrl = "../../NhanSu/ImageNhanSu/No_person.jpg";
        lblHoTen.Reset();
        lblGioiTinh.Reset();
        lblTTHN.Reset();
        lblEmail.Reset();
        lblTuoi.Reset();
        lblQuocGia.Reset();
        lblDanToc.Reset();
        lblTinhThanh.Reset();
        lblTonGiao.Reset();
        lblNoiOHienNay.Reset();
        lblChuyenNganh.Reset();
        lblTruongDaoTao.Reset();
        lblKinhNghiem.Reset();
        lblUuDiem.Reset();
        lblNhuocDiem.Reset();
        GridPanel_ChungChi.Reload();
        GridPanel_KinhNghiemLamViec.Reload();
        GridPanel_BangCap.Reload();
        GridPanel_TepTinDinhkem.Reload();
        GridPanel_KetQuaPV.Reload();

    }
    protected void cbx_tt_honnhanstore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_tt_honnhanstore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TT_HN,TEN_TT_HN from DM_TT_HN");
            cbx_tt_honnhanstore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void cbx_tenchungchiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_tenchungchiStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_CHUNGCHI,TEN_CHUNGCHI from DM_CHUNGCHI");
            cbx_tenchungchiStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void cbx_XepLoaiChungChiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_XepLoaiChungChiStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_XEPLOAI,TEN_XEPLOAI from DM_XEPLOAI");
            cbx_XepLoaiChungChiStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void Store_BangCapChungChi_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            Store_BangCapChungChi.DataSource = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetBangCapChungChi", "@MaUngVien", decimal.Parse("0" + hdfRecordID.Text));
            Store_BangCapChungChi.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void btnUpdateAtachFile_Click(object sender, DirectEventArgs e)
    {
        HttpPostedFile file = file_cv.PostedFile;
        string path = string.Empty;
        string tenfile = string.Empty;

        if (file != null)
        {
            if (!file_cv.PostedFile.FileName.EndsWith(".exe"))
            {
                if (file_cv.HasFile == false && file.ContentLength > 2000000)
                {
                    Dialog.ShowNotification("File không được lớn hơn 200kb");
                    return;
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Modules/TuyenDung/AttachFile"));
                    if (dir.Exists == false)
                        dir.Create();
                    tenfile = file_cv.FileName;
                    while (Util.GetInstance().FileIsExists("../../TuyenDung/AttachFile/" + tenfile) == true)
                    {
                        tenfile = Util.GetInstance().GetRandomString(3) + file_cv.FileName;
                    }
                    path = Server.MapPath("../../TuyenDung/AttachFile/" + tenfile);
                }

                if (string.IsNullOrEmpty(path) == false && string.IsNullOrEmpty(tenfile) == false)
                {
                    file.SaveAs(path);
                }
                DAL.TepTinDinhKem hsttdk = new DAL.TepTinDinhKem();

                hsttdk.TenTepTin = txtFileName.Text;
                hsttdk.GhiChu = txtGhiChu.Text;
                hsttdk.FR_KEY = decimal.Parse(hdfRecordID.Text);
                hsttdk.Link = tenfile;
                hsttdk.CreatedDate = DateTime.Now;
                hsttdk.CreatedBy = CurrentUser.ID;
                hsttdk.SizeKB = (file_cv.PostedFile.ContentLength / 1024);
                TepTinDinhKemControler hsttdkcontroller = new TepTinDinhKemControler();
                hsttdkcontroller.Insert(hsttdk);
                GridPanel_TepTinDinhkem.Reload();
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAttachFile.Hide();
                }
            }
            else
            {
                X.MessageBox.Alert("Cảnh báo", "Định dạng file upload không đúng").Show();
                return;
            }
        }

    }

    [DirectMethod]
    public void RemoveTepTinDinhKem(int id, string link)
    {
        try
        {
            DataHandler.GetInstance().ExecuteNonQuery("Delete from HOSO_TepTinDinhKem where PR_KEY = " + id);
            string serverPath = Server.MapPath("~/Modules/TuyenDung/AttachFile/" + link);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                X.Msg.Alert("Cảnh báo", "Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            else
            {
                FileInfo file = new FileInfo(serverPath);
                file.Delete();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void grpTepTinDinhKemStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            Store_TepTinDinhKem.DataSource = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetTepTinDinhKem", "@MaUngVien", decimal.Parse("0" + hdfRecordID.Text));
            Store_TepTinDinhKem.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnDownloadAttachFile_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(e.ExtraParams["AttachFile"]))
            {
                Dialog.ShowNotification("Không có tệp tin đính kèm");
                return;
            }
            string serverPath = Server.MapPath("~/Modules/TuyenDung/AttachFile/" + e.ExtraParams["AttachFile"]);
            Dialog.ShowError(serverPath);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            Response.Clear();
            //  Response.ContentType = "application/octet-stream";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + e.ExtraParams["AttachFile"].Replace(" ", "_"));
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        //dAddUngVien.Title = "Thêm mới ứng viên";
        //dAddUngVien.Icon = Icon.Add;
        //anhdaidien.ImageUrl = "ImageNhanSu/No_person.jpg";
        //Tab.ActiveTab = thongtinchung;
    }



    [DirectMethod]
    public void DeleteChungChi(int id)
    {
        try
        {
            new HOSO_UNGVIEN_CHUNGCHIController().Delete(id);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void RemoveBangCapUngVien(int id)
    {
        try
        {
            new HOSO_BANGCAP_UNGVIENController().DeleteBangCap(id);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void DeleteKinhNghiemLamViec(int id)
    {
        try
        {
            new HOSO_UNGVIEN_KINHNGHIEMLAMVIECController().DeleteKinhNghiemLamViec(id);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateChungChi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            ChungChiUngVienController ctrol = new ChungChiUngVienController();
            DAL.BangCapChungChi hschungchi = new BangCapChungChi();
            hschungchi.MaChungChi = hdfTenChungChi.Text;
            if (df_NgayCap.SelectedDate.ToString().Contains("0001") == false)
            {
                hschungchi.NgayCap = df_NgayCap.SelectedDate;
            }
            if (df_NgayHetHan.SelectedDate.ToString().Contains("0001") == false)
            {
                hschungchi.NgayHetHan = df_NgayHetHan.SelectedDate;
            }
            hschungchi.NoiDaoTao = cbx_NoiDaoTao.Text;
            hschungchi.MA_XEPLOAI = hdfTenXepLoai.Text;
            hschungchi.FR_KEY = decimal.Parse(hdfRecordID.Text);
            hschungchi.GhiChu = txtGhiChuChungChi.Text;
            if (e.ExtraParams["Command"] == "Edit")
            {
                hschungchi.ID = int.Parse("0" + RowSelectionModel_ChungChi.SelectedRecordID);
                ctrol.Update(hschungchi);
                wdAddChungChi.Hide();
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
            }
            else
            {
                ctrol.Insert(hschungchi);
                Dialog.ShowNotification("Thêm mới thành công!");
            }

            if (e.ExtraParams["Close"] == "True")
            {
                wdAddChungChi.Hide();
            }
            GridPanel_ChungChi.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateKinhNghiem_Click(object sender, DirectEventArgs e)
    {
        try
        {
            KinhNghiemLamViecControler control = new KinhNghiemLamViecControler();
            DAL.KinhNghiemLamViec kinhnghiem = new KinhNghiemLamViec();
            kinhnghiem.FR_KEY = decimal.Parse(hdfRecordID.Text);
            kinhnghiem.NoiLamViec = txt_noilamviec.Text;
            kinhnghiem.ViTriCongViec = txt_vitricongviec.Text;
            kinhnghiem.KinhNghiemDatDuoc = txtThanhTichTrongCongViec.Text;
            kinhnghiem.MucLuong = decimal.Parse("0" + nbfMucLuong.Text);
            kinhnghiem.LyDoThoiViec = txtLyDoThoiViec.Text;
            kinhnghiem.GhiChu = txtGhiChuKinhNghiemLamViec.Text;
            kinhnghiem.CreatedUser = CurrentUser.ID;
            if (dfKNLVTuNgay.SelectedDate.ToString().Contains("0001") == false)
            {
                kinhnghiem.TuThangNam = dfKNLVTuNgay.SelectedDate;
            }
            if (dfKNLVDenNgay.SelectedDate.ToString().Contains("0001") == false)
            {
                kinhnghiem.DenThangNam = dfKNLVDenNgay.SelectedDate;
            }
            if (e.ExtraParams["Command"] == "Edit")
            {
                kinhnghiem.ID = int.Parse("0" + RowSelectionModel_KinhNghiemLamViec.SelectedRecordID);
                control.Update(kinhnghiem);
                wdKinhNghiemLamViec.Hide();
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
            }
            else
            {
                control.Insert(kinhnghiem);
                Dialog.ShowNotification("Thêm mới thành công!");
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKinhNghiemLamViec.Hide();
                }
            }
            GridPanel_KinhNghiemLamViec.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void cbx_hinhthucdaotaobangStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_hinhthucdaotaobangStore.DataSource = new DM_HT_DAOTAOController().GetAll();
            cbx_hinhthucdaotaobangStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void cbx_trinhdobangcapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_trinhdobangcapStore.DataSource = new DM_TRINHDOController().GetAll();
            cbx_trinhdobangcapStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void cbx_xeploaiBangCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_xeploaiBangCapStore.DataSource = new DM_XEPLOAIController().GetAll();
            cbx_xeploaiBangCapStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnUpdateBangCap_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BangCapUngVienController control = new BangCapUngVienController();
            DAL.BangCapUngVien bcuv = new DAL.BangCapUngVien();
            bcuv.KHOA = txt_khoa.Text;
            bcuv.MA_HT_DAOTAO = hdfHinhThucDaoTao.Text;
            bcuv.MA_TRINHDO = hdfTrinhDoBangCap.Text;
            bcuv.USERNAME = CurrentUser.ID.ToString();
            bcuv.MA_TRUONG_DAOTAO = hdfMaTruongDaoTao.Text;
            bcuv.FR_KEY = decimal.Parse(hdfRecordID.Text);
            if (!string.IsNullOrEmpty(hdfMaChuyenNganh.Text))
                bcuv.MA_CHUYENNGANH = hdfMaChuyenNganh.Text;
            if (Chk_DaTotNghiep.Checked == true)
            {
                bcuv.DA_TN = true;
                if (!string.IsNullOrEmpty(txtNamNhanBang.Text))
                    bcuv.NGAY_NHANBANG = new DateTime(int.Parse("0" + txtNamNhanBang.Text), 1, 1);
                bcuv.MA_XEPLOAI = hdfXepLoaiBangCap.Text;
            }
            else
            {
                hdfXepLoaiBangCap.Reset();
                bcuv.DA_TN = false;
                bcuv.NGAY_NHANBANG = null;
                bcuv.MA_XEPLOAI = null;
            }
            if (!string.IsNullOrEmpty(txtTuNam.Text))
                bcuv.TU_NGAY = new DateTime(int.Parse(txtTuNam.Text), 1, 1);
            if (!string.IsNullOrEmpty(txtDenNam.Text))
                bcuv.DEN_NGAY = new DateTime(int.Parse(txtDenNam.Text), 1, 1);
            bcuv.DATE_CREATE = DateTime.Now;
            if (e.ExtraParams["Command"] == "Edit")
            {
                bcuv.ID = int.Parse("0" + RowSelectionModel_BangCap.SelectedRecordID);
                control.Update(bcuv);
                wdAddBangCap.Hide();
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
            }
            else
            {
                control.Insert(bcuv);
                Dialog.ShowNotification("Thêm mới thành công!");
            }

            if (e.ExtraParams["Close"] == "True")
            {
                wdAddBangCap.Hide();
            }
            GridPanel_BangCap.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString());
        }
    }
    //    
    protected void grpKetQuaPhongVanThiTuyen_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetKetQuaThiTuyen", "@MaUngVien", int.Parse("0" + hdfRecordID.Text));
        Store_KetQuaPV.DataSource = table;
        Store_KetQuaPV.DataBind();
    }
    public void CheckDaThoiViec(object sender, DirectEventArgs e)
    {
        try
        {
            if (cbb_NguoiChamThi.SelectedItem == null)
            {
                X.MessageBox.Alert("Thông báo", "Không tìm thấy cán bộ");
                return;
            }
            decimal prkeyHoSo = decimal.Parse(cbb_NguoiChamThi.SelectedItem.Value);
            DAL.DanhSachCanBoThoiViec tv = new DanhSachCanBoThoiViecController().GetByPrkeyHoSo(prkeyHoSo);
            if (tv != null) // exist in DanhSachCanBoThoiViec
            {
                // alert to user
                X.Msg.Confirm("Xác nhận", "Cán bộ được chọn nằm trong danh sách cán bộ đã thôi việc. Bạn có muốn tiếp tục?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "Ext.net.DirectMethods.DoYes()",
                        Text = "Đồng ý"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "Ext.net.DirectMethods.DoNo()",
                        Text = "Đóng lại"
                    }
                }).Show();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message);
        }
    }
    [DirectMethod]
    public void DoYes()
    {
        // nothing to do
    }

    [DirectMethod]
    public void DoNo()
    {
        wdChamDiemNhanXet.Hide();
    }
    protected void btnChamDiem_Click(object sender, DirectEventArgs e)
    {

        try
        {
            KetQuaThiTuyenController control = new KetQuaThiTuyenController();
            DAL.KetQuaThiTuyen kqthi = new DAL.KetQuaThiTuyen();
            kqthi.FR_KEY = decimal.Parse("0" + hdfRecordID.Text);
            kqthi.MaMonThi = int.Parse("0" + hdfMonThi.Text);
            kqthi.VongThi = int.Parse("0" + txt_vongPV.Text);
            kqthi.NhanXet = txtNhanXet.Text;
            kqthi.NguoiChamThi = decimal.Parse("0" + hdfNguoiChamThi.Text);
            kqthi.CreatedDate = DateTime.Now;
            if (!dfNgayThiTuyen.SelectedDate.ToString().Contains("0001"))
                kqthi.NgayThiTuyen = Convert.ToDateTime(dfNgayThiTuyen.Value);
            kqthi.CreatedBy = CurrentUser.ID;
            kqthi.Diem = float.Parse("0" + txtDiemSo.Text);
            if (e.ExtraParams["Command"] == "Edit")
            {
                kqthi.ID = int.Parse("0" + RowSelectionModel_KetQuaPV.SelectedRecordID);
                control.Update(kqthi);
                wdChamDiemNhanXet.Hide();
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
            }
            else
            {
                control.Insert(kqthi);
                Dialog.ShowNotification("Thêm mới thành công!");
            }

            if (e.ExtraParams["Close"] == "True")
            {
                wdChamDiemNhanXet.Hide();
            }
            GridPanel_KetQuaPV.Reload();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void StoreKinhNghiemLamViec_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {

            Store_KinhNghiemLamViec.DataSource = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetKinhNghiemLamViec", "@MaUngVien", decimal.Parse("0" + hdfRecordID.Text));
            Store_KinhNghiemLamViec.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void Store_BangCap_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {

            Store_BangCap.DataSource = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetBangCapUngVien", "@MaUngVien", decimal.Parse("0" + hdfRecordID.Text));
            Store_BangCap.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void StoreQHGD_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("select * from v_HOSO_QH_GIADINH where FR_KEY = " + hdfRecordID.Text);//+ grp_dm_kehoach_tuyendung.GetPrimaryKey());
        //    StoreQHGD.DataSource = table;
        //    StoreQHGD.DataBind();
    }

    protected void cbDotTuyenDungStore_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<MiniDM_DotTuyenDungInfo> data = new TuyenDungController().GetAll();
        //    cbDotTuyenDungStore.DataSource = data;
        //  cbDotTuyenDungStore.DataBind();
    }

    [DirectMethod]
    public void DeleteKeHoachTD(int id)
    {
        try
        {
            HoSoUngVienController controller = new HoSoUngVienController();

            hdfRecordID.Text = "";
            btnEdit.Disabled = true;
            btnDelete.Disabled = true;
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    /// <summary>
    /// Lấy dữ liệu tỉnh thành
    /// </summary> 
    protected void LoadTinhThanh()
    {
        //try
        //{
        //    List<DM_TINHTHANH> tinhThanh = new DM_TINHTHANHController().GetByAll();
        //    foreach (DM_TINHTHANH item in tinhThanh)
        //    {
        //        cbx_tinhthanh.Items.Add(new Ext.Net.ListItem()
        //        {
        //            Text = item.TEN_TINHTHANH,
        //            Value = item.MA_TINHTHANH
        //        });
        //    }
        //}
        //catch (Exception ex)
        //{
        //    X.MessageBox.Alert("Cảnh báo", ex.Message).Show();
        //}
    }

    protected void btn_UpdateUngVien_Click(object sender, DirectEventArgs e)
    {

    }

    private static bool FileExists(string sPathName)
    {
        try
        {
            return (System.IO.Directory.Exists(sPathName));  //Exception for folder
        }
        catch (Exception)
        {
            return (false);                                   //Error occured, return False
        }
    }
    protected void cbLoaiHopDongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            //   cbLoaiHopDongStore.DataSource = new DM_LOAI_HDONGController().GetAll();
            //      cbLoaiHopDongStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void cbx_dottuyendungStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        //try
        //{
        //    cbx_dottuyendungStore.DataSource = new DotTuyenDungController().GetDotTuyenDungByTrangThaiXuLy(string.Empty);
        //    cbx_dottuyendungStore.DataBind();
        //}
        //catch (Exception ex)
        //{
        //    X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        //}
    }
    protected void cbx_Chuyen_LyDo_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            string s = "";
            if (Equals(hdfType.Text, "black"))
            {
                s += "LyDoDuaVaoDanhSachHanChe";
            }
            else
            {
                if (Equals(hdfType.Text, "store"))
                    s += "LyDoDuaVaoKho";
            }
            cbx_Chuyen_LyDo_Store.DataSource = DataHandler.GetInstance().ExecuteDataTable("select ID, Value from dbo.ThamSoTrangThai where ParamName = '" + s + "' AND IsInUsed = 1");
            cbx_Chuyen_LyDo_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    public void btnChuyenTiep_Click(object sender, DirectEventArgs e)
    {
        string type = "";
        bool datrungtuyen = false;
        HoSoUngVienController hosoungvien = new HoSoUngVienController();
        DAL.HoSoUngVien hsuv = new DAL.HoSoUngVien();
        if (Equals(hdfType.Text, "DaTrungTuyen"))
        {
            type = "DaTrungTuyen";
            hsuv.DaTrungTuyen = true;
            datrungtuyen = true;
        }
        else
        {
            if (Equals(hdfType.Text, "store"))
            {
                type = "store";
            }
            else
            {
                if (Equals(hdfType.Text, "black"))
                {
                    type = "black";
                }
            }
        }
        try
        {
            foreach (var item in checkboxSelection.SelectedRows)
            {
                hsuv.MaUngVien = decimal.Parse("0" + item.RecordID);
                hsuv.BlackListOrStore = type;
                hsuv.GhiChu = txt_Chuyen_GhiChu.Text;
                hsuv.MaLyDo = int.Parse("0" + hdfChuyen_LyDo.Text);
                hosoungvien.ChuyenDanhSach(hsuv, datrungtuyen);
            }
            btnDelete.Disabled = true;
            btnEdit.Disabled = true;
            btnNext.Disabled = true;
            btnPrint.Disabled = true;
            GridPanel1.Reload();
            resetTabPanelAfterUpdate();
            checkboxSelection.ClearSelections();
            wdChuyenLyDo.Hide();
            Dialog.ShowNotification("Chuyển thành công!");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Thông báo", "Có lỗi xảy ra: " + ex.Message);
        }
    }
    public void btn_ChuyenLichHenPV_Click(object sender, DirectEventArgs e)
    {
        try
        {
            LichPhongVanController lichphongvan = new LichPhongVanController();
            DAL.LichHenPhongVan lpv = new DAL.LichHenPhongVan();
            HoSoUngVienController hosoungvien = new HoSoUngVienController();
            DAL.HoSoUngVien hsuv = new DAL.HoSoUngVien();
            foreach (var item in checkboxSelection.SelectedRows)
            {

                lpv.FR_KEY = decimal.Parse("0" + item.RecordID);
                lpv.CreatedBy = CurrentUser.ID;
                lpv.CreatedDate = DateTime.Now;
                if (!df_NgayPhongVan.SelectedDate.ToString().Contains("0001"))
                    lpv.LichHen = Convert.ToDateTime(df_NgayPhongVan.SelectedDate);
                lpv.ThoiGian = tf_GioPhongVan.Text;
                lpv.ThuTuPhongVan = int.Parse("0" + txt_ThuTuPhongVan.Text);
                lpv.VongPhongVan = int.Parse("0" + txt_VongPhongVan.Text);
                lpv.GhiChu = txt_ghichu.Text;
                lichphongvan.InsertByHoSoUngVien(lpv);
                hsuv.MaUngVien = decimal.Parse("0" + item.RecordID);
                hsuv.BlackListOrStore = "";
                hosoungvien.ChuyenDanhSach(hsuv, false);
            }
            btnDelete.Disabled = true;
            btnEdit.Disabled = true;
            btnNext.Disabled = true;
            btnPrint.Disabled = true;
            wdChuyenLichHenPV.Hide();
            GridPanel1.Reload();
            resetTabPanelAfterUpdate();
            checkboxSelection.ClearSelections();
            Dialog.ShowNotification("Chuyển thành công!");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Thông báo", "Có lỗi xảy ra: " + ex.Message);
        }
    }
    public void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in checkboxSelection.SelectedRows)
            {
                new HoSoUngVienController().Delete(int.Parse("0" + item.RecordID));
            }
            btnDelete.Disabled = true;
            btnEdit.Disabled = true;
            btnNext.Disabled = true;
            btnPrint.Disabled = true;
            GridPanel1.Reload();
            resetTabPanelAfterUpdate();
            checkboxSelection.ClearSelections();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btn_Delete_ChungChi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel_ChungChi.SelectedRows)
            {
                new ChungChiUngVienController().Delete(int.Parse("0" + item.RecordID));
            }
            btn_Edit_ChungChi.Disabled = true;
            btn_Delete_ChungChi.Disabled = true;
            GridPanel_ChungChi.Reload();
            RowSelectionModel_ChungChi.ClearSelections();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btn_Delete_KNLV_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel_KinhNghiemLamViec.SelectedRows)
            {
                new KinhNghiemLamViecControler().Delete(int.Parse("0" + item.RecordID));
            }
            btn_Edit_KNLV.Disabled = true;
            btn_Delete_KNLV.Disabled = true;
            GridPanel_KinhNghiemLamViec.Reload();
            RowSelectionModel_KinhNghiemLamViec.ClearSelections();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btn_Delete_QuaTrinhHocTap_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel_BangCap.SelectedRows)
            {
                new BangCapUngVienController().Delete(int.Parse("0" + item.RecordID));
            }
            btn_Edit_QuaTrinhHocTap.Disabled = true;
            btn_Delete_QuaTrinhHocTap.Disabled = true;
            GridPanel_BangCap.Reload();
            RowSelectionModel_BangCap.ClearSelections();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btn_Delete_File_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel_TepTinDinhKem.SelectedRows)
            {
                new TepTinDinhKemControler().Delete(int.Parse("0" + item.RecordID));
            }
            btn_Download_File.Disabled = true;
            btn_Delete_File.Disabled = true;
            GridPanel_TepTinDinhkem.Reload();
            RowSelectionModel_BangCap.ClearSelections();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btn_Delete_KetQuaPV_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel_KetQuaPV.SelectedRows)
            {
                new KetQuaThiTuyenController().Delete(int.Parse("0" + item.RecordID));
            }
            btn_Edit_KetQuaPV.Disabled = true;
            btn_Delete_KetQuaPV.Disabled = true;
            GridPanel_KetQuaPV.Reload();
            GridPanel1.Reload();
            RowSelectionModel_KetQuaPV.ClearSelections();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}


