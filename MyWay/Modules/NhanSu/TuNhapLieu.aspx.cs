using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using System.Data;
using DataController;
using ExtMessage;
using DAL;
using System.IO;
using SoftCore;
using System.Data.SqlClient;

public partial class Modules_NhanSu_TuNhapLieu : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            GetDataForUpdating();
            SetVisibleByControlID(btnUpdateInformation, CloseTab1, mnuKhaNang, mnuKhenThuong, mnuQuanHeGiaDinh,
               mnuQuaTrinhDieuChuyen, mnuTaiSan, MenuItemAttachFile, MenuItemHocTap, MenuItemKNLV, MenuItemBangCapChungChi,
                mnuTaiNanLaoDong, btnAddRecordInDetailTable, btnDeleteRecord, btnEditRecord, btnDuplicateRecord);
            dfNgaySinh.MaxDate = DateTime.Now; df_ngaybatdauhoc.MaxDate = DateTime.Now; df_NgayCap.MaxDate = DateTime.Now; dfKNLVTuNgay.MaxDate = DateTime.Now;
            dfNgayCapBHXH.MaxDate = DateTime.Now; dfNgayDongBHYT.MaxDate = DateTime.Now;
        }

        if (btnEditRecord.Visible)
        {
            #region RowSelect
            RowSelectionModelQHGD.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModel_BangCap.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelKinhNghiemLamViec.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModel_ChungChi.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            //RowSelectionModelDaiBieu.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelTaiSan.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            RowSelectionModelKhaNang.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            //RowSelectionModelDeTai.Listeners.RowSelect.Handler += "#{btnEditRecord}.enable();";
            #endregion
            #region Listener Active
            //pnl_QuanHeGiaDinh.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_QuaTrinhHocTap.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_KinhNghiemLamViec.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_BangCapChungChi.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_DaiBieu.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_TaiSan.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_KhaNang.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_DeTai.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            //pnl_TepTinDinhKem.Listeners.Activate.Handler += "#{btnEditRecord}.disable();";
            #endregion
            #region DblClick
            GridPanelQHGD.Listeners.RowDblClick.Handler += "if(#{cbQuanHeGiaDinh}.store.getCount()==0){#{cbQuanHeGiaDinhStore}.reload();};#{btnUpdateQuanHeGiaDinh}.hide();#{btnUpdate}.show();#{btnCapNhatVaDongQHGD}.hide();Ext.net.DirectMethods.GetDataForQuanHeGiaDinh();#{wdQuanHeGiaDinh}.show();";
            GridPanelKinhNghiemLamViec.Listeners.RowDblClick.Handler += "#{Update}.hide(); #{UpdateandClose}.hide();#{btnEditKinhNghiem}.show();Ext.net.DirectMethods.GetDataForKinhNghiemLamViec();#{wdKinhNghiemLamViec}.show();";
            GridPanel_ChungChi.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForChungChi();#{btnUpdateChungChi}.hide();#{btnUpdateandCloseChungChi}.hide();#{btnEditChungChi}.show();";
            //GridPanel_ChungChi.Listeners.RowDblClick.Handler += "if(#{cbx_tenchungchi}.store.getCount()==0){cbx_tenchungchiStore.reload();}if(#{cbx_XepLoaiChungChi}.store.getCount()==0){cbx_XepLoaiChungChiStore.reload();}if(#{cbx_TrinhDoChungChi}.store.getCount()==0){cbx_TrinhDoChungChiStore.reload();}#{btnUpdateChungChi}.hide();#{btnUpdateandCloseChungChi}.hide();#{btnEditChungChi}.show();Ext.net.DirectMethods.GetDataForChungChi();#{wdAddChungChi}.show();";
            // GridPanel_DaiBieu.Listeners.RowDblClick.Handler += "#{btnCapNhatDaiBieu}.hide();#{btnEditDaiBieu}.show();#{btnEditAndCloseDaiBieu}.hide();Ext.net.DirectMethods.GetDataForDaiBieu();#{wdDaiBieu}.show();";
            GridPanelTaiSan.Listeners.RowDblClick.Handler += "#{DirectMethods}.GetDataForTaiSan();#{btnUpdateCloseTaiSan}.hide();#{btnEditTaiSan}.show();#{btnUpdateTaiSan}.hide();";
            GridPanelKhaNang.Listeners.RowDblClick.Handler += "if(#{cbKhaNang}.store.getCount()==0){#{cbKhaNangStore}.reload();};if(#{cbKhaNangXepLoai}.store.getCount()==0){#{cbKhaNangXepLoaiStore}.reload();};#{btnUpdateKhaNang}.hide();#{btnEditKhaNang}.show();#{btnCapNhatVaDongKhaNang}.hide();Ext.net.DirectMethods.GetDataForKhaNang();#{wdKhaNang}.show();";
            // GridPanelDetai.Listeners.RowDblClick.Handler += "#{btnUpdateDeTai}.hide();#{btnEditDeTai}.show();#{btnCapNhatVaDongDeTai}.hide();Ext.net.DirectMethods.GetDataForDeTai();#{wdDeTai}.show();";
            #endregion
        }

        if (btnDeleteRecord.Visible)
        {
            #region RowSelect
            RowSelectionModelQHGD.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModel_BangCap.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelKinhNghiemLamViec.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModel_ChungChi.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            // RowSelectionModelDaiBieu.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelTaiSan.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            RowSelectionModelKhaNang.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            //RowSelectionModelDeTai.Listeners.RowSelect.Handler += "#{btnDeleteRecord}.enable();";
            #endregion
            #region Listener Active
            //pnl_QuanHeGiaDinh.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_QuaTrinhHocTap.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_KinhNghiemLamViec.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_BangCapChungChi.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_DaiBieu.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_TaiSan.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_KhaNang.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_DeTai.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            //pnl_TepTinDinhKem.Listeners.Activate.Handler += "#{btnDeleteRecord}.disable();";
            #endregion
        }

        if (btnAddRecordInDetailTable.Visible)
        {
            #region Panel Active
            pnl_QuanHeGiaDinh.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            pnl_QuaTrinhHocTap.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            pnl_KinhNghiemLamViec.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            pnl_BangCapChungChi.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            //pnl_DaiBieu.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            pnl_TaiSan.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            pnl_KhaNang.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            //pnl_DeTai.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            pnl_TepTinDinhKem.Listeners.Activate.Handler += "#{btnAddRecordInDetailTable}.enable();";
            #endregion
        }

        if (btnDownloadFile.Visible)
        {
            RowSelectionModelTepTinDinhKem.Listeners.RowSelect.Handler += "#{btnDownloadFile}.enable();";
        }
        ucChooseEmployee1.AfterClickAcceptButton += ucChooseEmployee1_AfterClickAcceptButton;
    }
    //Chọn người quyết định
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            string macb = ucChooseEmployee1.SelectedRow[0].RecordID;
            string prKeyHoSo = new HoSoController().GetByMaCB(macb).PR_KEY.ToString();
            string hoTen = ucChooseEmployee1.DanhSachHoTen;

            //Thiết lập giá trị cho form khen thưởng
            hdfKhenThuongNguoiQD.Text = prKeyHoSo;
            tgf_KhenThuong_NguoiRaQD.Text = hoTen;

            //Thiết lập giá trị cho form công tác 
            hdfQTCTNguoiQuyetDinh.Text = prKeyHoSo;
            tgf_QTCTNguoiQuyetDinh.Text = hoTen;

            //Thiết lập giá trị cho form điều chuyển
            hdfQTDCNguoiQuyetDinh.Text = prKeyHoSo;
            tgfQTDCNguoiQuyetDinh.Text = hoTen;
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
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
        if (obj.HasFile)
        {
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
        else
            return "";
    }

    /// <summary>
    /// Delete Attach file of table include: delete column TepTinDinhKem in database and delete physical file in server
    /// </summary>
    /// <param name="TableName">Name of table</param>
    /// <param name="Prkey">Prkey of employee</param>
    public void DeleteTepTinDinhKem(string tableName, decimal prkey, Hidden sender)
    {
        // xóa trong csdl
        DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteTepTinDinhKem", "@TableName", "@Prkey", tableName, prkey).ToString();
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
        DataController.DataHandler.GetInstance().ExecuteNonQuery("HOSO_DeleteAttachFile", "@TableName", "@ID", tableName, id).ToString();
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
            int pos = sender.Text.LastIndexOf("/");
            Response.AddHeader("Content-Disposition", "attachment; filename=" + sender.Text.Replace(" ", "_"));
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
        return pathOfFile;
    }
    #endregion

    private void GetDataForUpdating()
    {
        try
        {
            DAL.HOSO_TUCAPNHAT tuCapNhat = new TuCapNhatController().GetByUserId(CurrentUser.ID);
            if (tuCapNhat != null)
            { 
                FillDataToForm(tuCapNhat);
            }
            else
            {
                hdfCommandType.SetValue("Insert");  
                hdf_PR_KEY.Text = "";
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message); 
        }
    }

    protected void cbxCongViecMoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbxCongViecMoi_Store.DataSource = new DM_CONGVIECController().GetAll();
            cbxCongViecMoi_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    private void FillDataToForm(DAL.HOSO_TUCAPNHAT tuCapNhat)
    {
        SoftCore.Util util = new Util();
        hdf_PR_KEY.Text = tuCapNhat.PR_KEY.ToString();
        // ho so nhan vien
        if (tuCapNhat.PHOTO != null)
            img_anhdaidien.ImageUrl = tuCapNhat.PHOTO;
        else
            img_anhdaidien.ImageUrl = "~/Modules/NhanSu/ImageNhanSu/No_person.jpg"; 
        txt_hoten.Text = tuCapNhat.HO_TEN;
        txt_bidanh.Text = tuCapNhat.BI_DANH;

        if (!util.IsDateNull(tuCapNhat.NGAY_SINH))
            dfNgaySinh.SetValue(tuCapNhat.NGAY_SINH);
        cbx_gioitinh.SetValue(tuCapNhat.MA_GIOITINH);
        txt_quequan.Text = tuCapNhat.QueQuan;
        cbx_tthonnhan.SetValue(tuCapNhat.MA_TT_HN);
        cbx_tpbanthan.SetValue(tuCapNhat.MA_TP_BANTHAN);
        cbx_tpgiadinh.SetValue(tuCapNhat.MA_TP_GIADINH);
        txt_noisinh.Text = tuCapNhat.NOI_SINH;
        hdfQuocTich.SetValue(tuCapNhat.MA_NUOC);
        cbx_quoctich.SetValue(tuCapNhat.MA_NUOC);
        hdfDanToc.SetValue(tuCapNhat.MA_DANTOC);
        cbx_dantoc.SetValue(tuCapNhat.MA_DANTOC);
        cbx_tongiao.SetValue(tuCapNhat.MA_TONGIAO);
        txt_hokhau.Text = tuCapNhat.HO_KHAU;
        hdfTinhThanh.SetValue(tuCapNhat.MA_TINHTHANH);
        cbx_tinhthanh.SetValue(tuCapNhat.MA_TINHTHANH);
        txt_sohochieu.Text = tuCapNhat.SO_HOCHIEU;
        date_ngaycaphc.SetValue(tuCapNhat.NGAYCAP_HOCHIEU);
        cbx_noicaphc.SetValue(tuCapNhat.MA_NOICAP_HOCHIEU);
        date_hethanhc.SetValue(tuCapNhat.NGAY_HETHAN_HOCHIEU);
        hdfViTriCongViec.SetValue(tuCapNhat.MA_CONGVIEC);
        cbx_congviec.SetValue(tuCapNhat.MA_CONGVIEC);
        txt_didong.Text = tuCapNhat.DI_DONG;
        txt_dtcoquan.Text = tuCapNhat.DT_CQUAN;
        txt_dtnha.Text = tuCapNhat.DT_NHA;
        txt_email.Text = tuCapNhat.EMAIL;
        txt_diachilienhe.Text = tuCapNhat.DIA_CHI_LH;
        txt_emailkhac.Text = tuCapNhat.EMAIL_RIENG;
        cbx_trinhdo.SetValue(tuCapNhat.MA_TRINHDO);
        txt_tiledongbh.Text = tuCapNhat.TYLE_DONG_BH;
        cbx_httuyen.SetValue(tuCapNhat.MA_HT_TUYENDUNG);
        cbx_congtrinh.SetValue(tuCapNhat.MA_CONGTRINH);
        if (tuCapNhat.MA_CHUYENNGANH != null)
        {
            hdfMaChuyenNganh.Text = tuCapNhat.MA_CHUYENNGANH;
            cbxChuyenNganh.Text = new DM_CHUYENNGANHController().GetNameByPrimaryKey(tuCapNhat.MA_CHUYENNGANH);
        }
        //cbx_chuyennganh.SetValue(tuCapNhat.MA_CHUYENNGANH);
        if (tuCapNhat.MA_TRUONG_DAOTAO != null)
        {
            hdfMaTruongDaoTao.Text = tuCapNhat.MA_TRUONG_DAOTAO;
            cbxTruongDaoTao.Text = new DM_TRUONG_DAOTAOController().GetNameByMaTruong(tuCapNhat.MA_TRUONG_DAOTAO);
        }
        //cbx_truong.SetValue(tuCapNhat.MA_TRUONG_DAOTAO);
        cbx_xeploai.SetValue(tuCapNhat.MA_XEPLOAI);
        cbx_tinhoc.SetValue(tuCapNhat.MA_TINHOC);
        cbx_ngoaingu.SetValue(tuCapNhat.MA_NGOAINGU);
        cbx_tdvanhoa.SetValue(tuCapNhat.MA_TD_VANHOA);
        tf_namtotnghiep.Text = tuCapNhat.NAM_TN.ToString();

        cbx_bophan.SetValue(tuCapNhat.MA_DONVI);
        if (!util.IsDateNull(tuCapNhat.NGAY_TUYEN_DTIEN))
            date_tuyendau.SetValue(tuCapNhat.NGAY_TUYEN_DTIEN);
        if (!util.IsDateNull(tuCapNhat.NGAY_TUYEN_CHINHTHUC))
            date_ngaynhanct.SetValue(tuCapNhat.NGAY_TUYEN_CHINHTHUC);
        cbxHinhThucLamViec.SetValue(tuCapNhat.HinhThucLamViec);
        hdfChucVu.SetValue(tuCapNhat.MA_CHUCVU);
        cbx_chucvu.SetValue(tuCapNhat.MA_CHUCVU);

        // ho so nhap them
        cbx_huongcs.SetValue(tuCapNhat.MA_LOAI_CS);
        txt_sothebhyt.Text = tuCapNhat.SOTHE_BHYT;
        cbx_noikcb.SetValue(tuCapNhat.MA_NOI_KCB);
        txt_sothebhxh.Text = tuCapNhat.SOTHE_BHXH;
        cbx_noicapbhxh.SetValue(tuCapNhat.MA_NOICAP_BHXH);
        txt_socmnd.Text = tuCapNhat.SO_CMND;
        cbx_noicapcmnd.SetValue(tuCapNhat.MA_NOICAP_CMND);
        if (!util.IsDateNull(tuCapNhat.NGAY_DONGBH))
            dfNgayDongBHYT.SetValue(tuCapNhat.NGAY_DONGBH);
        if (!util.IsDateNull(tuCapNhat.NGAY_HETHAN_BHYT))
            dfNgayHetHanBHYT.SetValue(tuCapNhat.NGAY_HETHAN_BHYT);
        if (!util.IsDateNull(tuCapNhat.NGAYCAP_BHXH))
            dfNgayCapBHXH.SetValue(tuCapNhat.NGAYCAP_BHXH);
        date_capcmnd.SetValue(tuCapNhat.NGAYCAP_CMND);

        cbx_trinhdochinhtri.SetValue(tuCapNhat.MA_TD_CHINHTRI);
        date_thamgiacm.SetValue(tuCapNhat.NGAY_TGCM);
        if (tuCapNhat.LaDangVien != null)
            chkLaDangVien.Checked = tuCapNhat.LaDangVien.Value;
        if (chkLaDangVien.Checked == true)
        {
            date_vaodang.SetValue(tuCapNhat.NGAYVAO_DANG);
            cbx_chuvudang.SetValue(tuCapNhat.MA_CHUCVU_DANG);
            date_ngayvaodangct.SetValue(tuCapNhat.NGAY_CTHUC_DANG);
            txt_noiketnapdang.Text = tuCapNhat.NOI_KETNAP_DANG;
            txt_noisinhhoatdang.Text = tuCapNhat.NoiSinhHoatDang;
        }
        if (tuCapNhat.DaThamGiaQuanDoi != null)
            chkDaThamGiaQuanDoi.Checked = tuCapNhat.DaThamGiaQuanDoi.Value;
        if (chkDaThamGiaQuanDoi.Checked == true)
        {
            date_nhapngu.SetValue(tuCapNhat.NGAYVAO_QDOI);
            date_xuatngu.SetValue(tuCapNhat.NGAYRA_QDOI);
            cbx_bacquandoi.SetValue(tuCapNhat.MA_CAPBAC_QDOI);
            cbx_chucvuquandoi.SetValue(tuCapNhat.MA_CHUCVU_QDOI);
        }
        date_ngayvaodoan.SetValue(tuCapNhat.NGAYVAO_DOAN);
        cbx_chucvudoan.SetValue(tuCapNhat.MA_CHUCVU_DOAN);
        date_vaodang.SetValue(tuCapNhat.NGAYVAO_DANG);
        txt_noiketnapdoan.Text = tuCapNhat.NOI_KETNAP_DOAN;

        date_vaocongdoan.SetValue(tuCapNhat.NgayVaoCongDoan);
        txt_chucvucongdoan.Text = tuCapNhat.ChucVuCongDoan;

        if (tuCapNhat.LaThuongBinh != null)
            chkLaThuongBinh.Checked = tuCapNhat.LaThuongBinh.Value;
        if (chkLaThuongBinh.Checked == true)
        {
            txt_HangThuongTat.Text = tuCapNhat.HangThuongTat;
            txt_SoThuongTat.Text = tuCapNhat.SoThuongTat;
            txt_HinhThucThuongTat.Text = tuCapNhat.HinhThucThuongTat;
        }

        // thong tin khac
        cbNhommau.SetValue(tuCapNhat.NHOM_MAU);
        txt_chieucao.SetValue(tuCapNhat.CHIEU_CAO);
        txt_cannang.SetValue(tuCapNhat.CAN_NANG);
        txtSOTHICH.Text = tuCapNhat.SO_THICH;
        cbx_ttsuckhoe.SetValue(tuCapNhat.MA_TT_SUCKHOE);
        txt_sohieucbccvc.Text = tuCapNhat.SOHIEU_CCVC;
        date_bonhiemcv.SetValue(tuCapNhat.NGAY_BN_CHUCVU);
        date_bnngach.SetValue(tuCapNhat.NGAY_BN_NGACH);
        txt_UuDiem.Text = tuCapNhat.UU_DIEM;
        cbx_ngach.SetValue(tuCapNhat.MA_NGACH);
        txt_NhuocDiem.Text = tuCapNhat.NHUOC_DIEM;
        txt_nguoilienhe.Text = tuCapNhat.NguoiLienHe;
        cbx_nganhang.SetValue(tuCapNhat.TAI_NH);
        txtMoiQH.Text = tuCapNhat.QuanHeVoiCanBo;
        txt_sdtnguoilh.Text = tuCapNhat.SDTNguoiLienHe;
        txt_emailnguoilh.Text = tuCapNhat.EmailNguoiLienHe;
        txt_diachinguoilienhe.Text = tuCapNhat.DiaChiNguoiLienHe;
        cbx_trinhdoquanly.SetValue(tuCapNhat.MA_TD_QUANLY);
        cbx_trinhdoquanlykt.SetValue(tuCapNhat.MA_TD_QLKT);

        txt_sotaikhoan.Text = tuCapNhat.SO_TAI_KHOAN;

        txt_masothuecanhan.Text = tuCapNhat.MST_CANHAN;

        hdfCommandType.SetValue("Edit");
    }
    protected void btnUpdateInformation_Click(object sender, DirectEventArgs e)
    {
        try
        { 
            SoftCore.Util util = new Util();
            TuCapNhatController controller = new TuCapNhatController();
            DAL.HOSO_TUCAPNHAT tuCapNhat = new HOSO_TUCAPNHAT();
            LinqProvider linq = new LinqProvider(); 
            bool insert = (hdfCommandType.Text == "Insert");
            if (!insert)
            {
                tuCapNhat = linq.GetDataContext().HOSO_TUCAPNHATs.Where(t => t.UserID == CurrentUser.ID).FirstOrDefault(); 
            } 

            if (string.IsNullOrEmpty(fufUploadControl.FileName) == false)
                tuCapNhat.PHOTO = hdfImageFolder.Text + "/" + fufUploadControl.FileName;
            tuCapNhat.HO_TEN = txt_hoten.Text.Trim();
            tuCapNhat.TEN_CB = (tuCapNhat.HO_TEN.LastIndexOf(' ') == -1) ? tuCapNhat.HO_TEN : tuCapNhat.HO_TEN.Substring(tuCapNhat.HO_TEN.LastIndexOf(' ') + 1).Trim();
            tuCapNhat.HO_CB = (tuCapNhat.HO_TEN.LastIndexOf(' ') == -1) ? "" : tuCapNhat.HO_TEN.Substring(0, tuCapNhat.HO_TEN.LastIndexOf(' ')).Trim();
            tuCapNhat.BI_DANH = txt_bidanh.Text.Trim();
            if (!util.IsDateNull(dfNgaySinh.SelectedDate))
                tuCapNhat.NGAY_SINH = dfNgaySinh.SelectedDate;

            tuCapNhat.MA_GIOITINH = cbx_gioitinh.SelectedItem.Value;
            tuCapNhat.QueQuan = txt_quequan.Text;
            tuCapNhat.MA_TT_HN = cbx_tthonnhan.SelectedItem.Value;
            tuCapNhat.MA_TP_BANTHAN = cbx_tpbanthan.SelectedItem.Value;
            tuCapNhat.MA_TP_GIADINH = cbx_tpgiadinh.SelectedItem.Value;
            tuCapNhat.NOI_SINH = txt_noisinh.Text;

            tuCapNhat.MA_NUOC = hdfQuocTich.Text;
            tuCapNhat.MA_DANTOC = cbx_dantoc.SelectedItem.Value;
            tuCapNhat.MA_TONGIAO = cbx_tongiao.SelectedItem.Value;
            tuCapNhat.TYLE_DONG_BH = txt_tiledongbh.Text;
            tuCapNhat.HO_KHAU = txt_hokhau.Text;
            tuCapNhat.MA_TINHTHANH = hdfTinhThanh.Text; //cbx_tinhthanh.SelectedItem.Value;
            tuCapNhat.SO_HOCHIEU = txt_sohochieu.Text;
            if (!SoftCore.Util.GetInstance().IsDateNull(date_ngaycaphc.SelectedDate))
                tuCapNhat.NGAYCAP_HOCHIEU = date_ngaycaphc.SelectedDate;

            tuCapNhat.MA_TT_SUCKHOE = cbx_ttsuckhoe.SelectedItem.Value;
            tuCapNhat.MA_NOICAP_HOCHIEU = cbx_noicaphc.SelectedItem.Value;
            if (!SoftCore.Util.GetInstance().IsDateNull(date_hethanhc.SelectedDate))
                tuCapNhat.NGAY_HETHAN_HOCHIEU = date_hethanhc.SelectedDate;
            tuCapNhat.DI_DONG = txt_didong.Text;
            tuCapNhat.DT_CQUAN = txt_dtcoquan.Text;
            tuCapNhat.DT_NHA = txt_dtnha.Text;
            tuCapNhat.EMAIL = txt_email.Text;
            tuCapNhat.DIA_CHI_LH = txt_diachilienhe.Text;
            tuCapNhat.MA_HT_TUYENDUNG = cbx_httuyen.SelectedItem.Value;
            tuCapNhat.MA_TRINHDO = cbx_trinhdo.SelectedItem.Value;
            tuCapNhat.MA_CHUYENNGANH = hdfMaChuyenNganh.Text; //cbx_chuyennganh.SelectedItem.Value;
            tuCapNhat.MA_TRUONG_DAOTAO = hdfMaTruongDaoTao.Text; //cbx_truong.SelectedItem.Value;
            tuCapNhat.MA_XEPLOAI = cbx_xeploai.SelectedItem.Value;
            tuCapNhat.MA_TINHOC = cbx_tinhoc.SelectedItem.Value;
            tuCapNhat.MA_NGOAINGU = cbx_ngoaingu.SelectedItem.Value;
            tuCapNhat.EMAIL_RIENG = txt_emailkhac.Text;
            if (!date_vaocongdoan.SelectedDate.ToString().Contains("0001"))
                tuCapNhat.NgayVaoCongDoan = date_vaocongdoan.SelectedDate;
            tuCapNhat.ChucVuCongDoan = txt_chucvucongdoan.Text;

            if (!string.IsNullOrEmpty(tf_namtotnghiep.Text))
                tuCapNhat.NAM_TN = Decimal.Parse(tf_namtotnghiep.Text);
            else
                tuCapNhat.NAM_TN = null;

            tuCapNhat.MA_DONVI = cbx_bophan.SelectedItem.Value;
            tuCapNhat.MA_TD_VANHOA = cbx_tdvanhoa.SelectedItem.Value;

            // Thong tin dien them 
            tuCapNhat.MA_LOAI_CS = cbx_huongcs.SelectedItem.Value;
            tuCapNhat.SOTHE_BHYT = txt_sothebhyt.Text;

            tuCapNhat.MA_NOI_KCB = cbx_noikcb.SelectedItem.Value;
            tuCapNhat.SOTHE_BHXH = txt_sothebhxh.Text;

            tuCapNhat.MA_NOICAP_BHXH = cbx_noicapbhxh.SelectedItem.Value;
            tuCapNhat.SO_CMND = txt_socmnd.Text;
            tuCapNhat.MA_NOICAP_CMND = cbx_noicapcmnd.SelectedItem.Value;
            tuCapNhat.MA_CHUCVU = hdfChucVu.Text; //cbx_chucvu.SelectedItem.Value;
            tuCapNhat.MA_CONGVIEC = hdfViTriCongViec.Text; //cbx_congviec.SelectedItem.Value;
            if (!SoftCore.Util.GetInstance().IsDateNull(date_tuyendau.SelectedDate))
            {
                tuCapNhat.NGAY_TUYEN_DTIEN = date_tuyendau.SelectedDate;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(date_ngaynhanct.SelectedDate))
            {
                tuCapNhat.NGAY_TUYEN_CHINHTHUC = date_ngaynhanct.SelectedDate;
            }
            tuCapNhat.MA_CONGTRINH = cbx_congtrinh.Text;
            if (!util.IsDateNull(dfNgayDongBHYT.SelectedDate))
                tuCapNhat.NGAY_DONGBH = dfNgayDongBHYT.SelectedDate;
            if (!util.IsDateNull(dfNgayHetHanBHYT.SelectedDate))
                tuCapNhat.NGAY_HETHAN_BHYT = dfNgayHetHanBHYT.SelectedDate;
            if (!util.IsDateNull(dfNgayCapBHXH.SelectedDate))
                tuCapNhat.NGAYCAP_BHXH = dfNgayCapBHXH.SelectedDate;
            if (!SoftCore.Util.GetInstance().IsDateNull(date_capcmnd.SelectedDate))
                tuCapNhat.NGAYCAP_CMND = date_capcmnd.SelectedDate;

            tuCapNhat.MA_TD_CHINHTRI = cbx_trinhdochinhtri.SelectedItem.Value;
            if (!date_thamgiacm.SelectedDate.ToString().Contains("0001"))
                tuCapNhat.NGAY_TGCM = date_thamgiacm.SelectedDate;
            tuCapNhat.LaDangVien = chkLaDangVien.Checked;
            if (chkLaDangVien.Checked == true)
            {
                if (!date_vaodang.SelectedDate.ToString().Contains("0001"))
                    tuCapNhat.NGAYVAO_DANG = date_vaodang.SelectedDate;
                if (!date_ngayvaodangct.SelectedDate.ToString().Contains("0001"))
                    tuCapNhat.NGAY_CTHUC_DANG = date_ngayvaodangct.SelectedDate;
                tuCapNhat.NOI_KETNAP_DANG = txt_noiketnapdang.Text;
                tuCapNhat.MA_CHUCVU_DANG = cbx_chuvudang.SelectedItem.Value;
                tuCapNhat.NoiSinhHoatDang = txt_noisinhhoatdang.Text;
            }
            tuCapNhat.DaThamGiaQuanDoi = chkDaThamGiaQuanDoi.Checked;
            if (chkDaThamGiaQuanDoi.Checked == true)
            {
                if (!SoftCore.Util.GetInstance().IsDateNull(date_nhapngu.SelectedDate))
                    tuCapNhat.NGAYVAO_QDOI = date_nhapngu.SelectedDate;
                if (!date_xuatngu.SelectedDate.ToString().Contains("0001"))
                    tuCapNhat.NGAYRA_QDOI = date_xuatngu.SelectedDate;
                tuCapNhat.MA_CAPBAC_QDOI = cbx_bacquandoi.SelectedItem.Value;
                tuCapNhat.MA_CHUCVU_QDOI = cbx_chucvuquandoi.SelectedItem.Value;
            }

            if (!date_ngayvaodoan.SelectedDate.ToString().Contains("0001"))
                tuCapNhat.NGAYVAO_DOAN = date_ngayvaodoan.SelectedDate;
            tuCapNhat.MA_CHUCVU_DOAN = cbx_chucvudoan.SelectedItem.Value;
            tuCapNhat.NOI_KETNAP_DOAN = txt_noiketnapdoan.Text;

            // Thong tin khac
            tuCapNhat.NHUOC_DIEM = txt_NhuocDiem.Text.Trim();
            tuCapNhat.SO_THICH = txtSOTHICH.Text.Trim();
            tuCapNhat.UU_DIEM = txt_UuDiem.Text.Trim();
            if (cbNhommau.SelectedIndex >= 0)
            {
                tuCapNhat.NHOM_MAU = cbNhommau.SelectedItem.Value;
            }
            else
            {
                tuCapNhat.NHOM_MAU = "";
            }
            if (!string.IsNullOrEmpty(txt_chieucao.Text.Trim()))
                tuCapNhat.CHIEU_CAO = Decimal.Parse(txt_chieucao.Text);
            if (!string.IsNullOrEmpty(txt_cannang.Text.Trim()))
                tuCapNhat.CAN_NANG = Decimal.Parse(txt_cannang.Text);
            tuCapNhat.SOHIEU_CCVC = txt_sohieucbccvc.Text;
            if (!date_bonhiemcv.SelectedDate.ToString().Contains("0001"))
                tuCapNhat.NGAY_BN_CHUCVU = date_bonhiemcv.SelectedDate;

            tuCapNhat.MA_NGACH = cbx_ngach.SelectedItem.Value;
            if (!date_bnngach.SelectedDate.ToString().Contains("0001"))
                tuCapNhat.NGAY_BN_NGACH = date_bnngach.SelectedDate;

            tuCapNhat.MA_TD_QUANLY = cbx_trinhdoquanly.SelectedItem.Value;
            tuCapNhat.MA_TD_QLKT = cbx_trinhdoquanlykt.SelectedItem.Value;
            tuCapNhat.NguoiLienHe = txt_nguoilienhe.Text;
            tuCapNhat.QuanHeVoiCanBo = txtMoiQH.Text;
            tuCapNhat.SDTNguoiLienHe = txt_sdtnguoilh.Text;
            tuCapNhat.EmailNguoiLienHe = txt_emailnguoilh.Text;
            tuCapNhat.DiaChiNguoiLienHe = txt_diachinguoilienhe.Text;

            tuCapNhat.LaThuongBinh = chkLaThuongBinh.Checked;
            if (tuCapNhat.LaThuongBinh == true)
            {
                tuCapNhat.HangThuongTat = txt_HangThuongTat.Text;
                tuCapNhat.SoThuongTat = txt_SoThuongTat.Text;
                tuCapNhat.HinhThucThuongTat = txt_HinhThucThuongTat.Text;
            }

            tuCapNhat.SO_TAI_KHOAN = txt_sotaikhoan.Text;
            tuCapNhat.TAI_NH = cbx_nganhang.SelectedItem.Value;
            tuCapNhat.MST_CANHAN = txt_masothuecanhan.Text;
            tuCapNhat.UserID = CurrentUser.ID;
            tuCapNhat.DATE_CREATE = DateTime.Now;
            tuCapNhat.TrangThaiDuyet = "ChuaDuyet";
            if (cbxHinhThucLamViec.Value != null)
                tuCapNhat.HinhThucLamViec = int.Parse(cbxHinhThucLamViec.SelectedItem.Value);
            if (!string.IsNullOrEmpty(hdfUploadedImage.Text))
            {
                tuCapNhat.PHOTO = hdfUploadedImage.Text;
            }
            if (insert)
            {
                controller.Add(tuCapNhat);
                Dialog.ShowNotification("Thêm mới thành công");
            }
            else
            { 
                linq.Save();
                Dialog.ShowNotification("Cập nhật thành công");
            }
            hdf_PR_KEY.Text = tuCapNhat.PR_KEY.ToString();
        }
        catch (SqlException sql)
        {
            X.Msg.Alert("Có lỗi dữ liệu xảy ra", sql.Message).Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
      
    #region các DirectMethod

    [DirectMethod]
    public void DeleteDonViTinh(string maDVT)
    {
        try
        {
            new DanhMucDonViTinhController().Delete(maDVT);
            hdfMaDonViTinh.Text = "";
        }
        catch (Exception ex)
        {
            if (ex.Message.ToString().Contains("FK_HOSO_TAISAN_DM_DVT"))
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Đơn vị tính đang được sử dụng. Bạn không được phép xóa").Show();
            }
        }
    }

    [DirectMethod]
    public void SaveDonViTinh(string maDVT, string tenDVT, string ghiChu)
    {
        try
        {
            DanhMucDonViTinhController controller = new DanhMucDonViTinhController();
            DAL.DM_DVT dvt = new DAL.DM_DVT()
            {
                MA_DVT = maDVT,
                TEN_DVT = tenDVT,
                GHI_CHU = ghiChu,
                MA_DONVI = Session["MaDonVi"].ToString(),
                USERNAME = CurrentUser.ID.ToString(),
                DATE_CREATE = DateTime.Now,
            };
            if (hdfMaDonViTinh.Text != "")
            {
                string maDonViTinh = hdfMaDonViTinh.Text;
                dvt.MA_DVT = maDonViTinh;
                controller.Update(dvt);
            }
            else
            {
                controller.Insert(dvt);
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo lỗi", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuanHeGiaDinh()
    {
        string id = RowSelectionModelQHGD.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_QH_GIADINH giadinh = new HoSoController().GetQuanHeGiaDinh(decimal.Parse(id));
            txtQHGDHoTen.Text = giadinh.HO_TEN;
            cbQHGDGioiTinh.SetValue(giadinh.GIOI_TINH);
            txtQHGDNamSinh.Text = giadinh.TUOI;
            cbQuanHeGiaDinh.SelectedItem.Value = giadinh.MA_QUANHE;
            txtQHGDNgheNghiep.Text = giadinh.NGHE_NGHIEP;
            txtQHGDNoiLamViec.Text = giadinh.NOI_LAMVIEC;
            txtQHGDGhiChu.Text = giadinh.GHI_CHU;
            chkQHGDLaNguoiPhuThuoc.SetValue(giadinh.LaNguoiPhuThuoc);
            if (giadinh.LaNguoiPhuThuoc == true)
            {
                if (!SoftCore.Util.GetInstance().IsDateNull(giadinh.NgayBatDauGiamTru))
                    dfQHGDBatDauGiamTru.SetValue(giadinh.NgayBatDauGiamTru);
                if (!SoftCore.Util.GetInstance().IsDateNull(giadinh.NgayKetThucGiamTru))
                    dfQHGDKetThucGiamTru.SetValue(giadinh.NgayKetThucGiamTru);
            }
            wdQuanHeGiaDinh.Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuaTrinhHocTap()
    {
        try
        {
            string id = RowSelectionModel_BangCap.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_BANGCAP_UNGVIEN bangcap = new HoSoController().getQuaTrinhHocTap(int.Parse(id));
                cbx_NoiDaoTaoBangCap.SetValue(bangcap.MA_TRUONG_DAOTAO);
                cbx_hinhthucdaotaobang.SetValue(bangcap.MA_HT_DAOTAO);
                txt_khoa.Text = bangcap.KHOA;
                if (bangcap.TU_NGAY.HasValue && bangcap.TU_NGAY.Value.ToString().Contains("0001") == false)
                {
                    df_ngaybatdauhoc.SelectedDate = bangcap.TU_NGAY.Value;
                }
                Chk_DaTotNghiep.Checked = bangcap.DA_TN.Value;
                cbx_ChuyenNganhBangCap.SetValue(bangcap.MA_CHUYENNGANH);
                cbx_trinhdobangcap.SetValue(bangcap.MA_TRINHDO);
                cbx_xeploaiBangCap.SetValue(bangcap.MA_XEPLOAI);
                if (bangcap.DEN_NGAY.HasValue && bangcap.DEN_NGAY.Value.ToString().Contains("0001") == false)
                {
                    df_ngayketthuchoc.SelectedDate = bangcap.DEN_NGAY.Value;
                }
                if (!SoftCore.Util.GetInstance().IsDateNull(bangcap.NGAY_NHANBANG))
                {
                    df_NgayNhanBang.SelectedDate = bangcap.NGAY_NHANBANG.Value;
                }
                wdAddBangCap.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GetDataForKinhNghiemLamViec()
    {
        #region code cũ
        //string id = RowSelectionModelKinhNghiemLamViec.SelectedRecordID;
        //if (id == "")
        //{
        //    X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        //}
        //else
        //{
        //    DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC knlv = new HoSoController().GetKinhNghiemLamViec(int.Parse(id));
        //    if (knlv == null)
        //    {
        //        return;
        //    }
        //    txt_noilamviec.Text = knlv.NoiLamViec;
        //    txt_vitriconviec.Text = knlv.ViTriCongViec;
        //    //txt_conviecdamnhiem.Text = knlv.CongViecDamNhiem;
        //    if (!SoftCore.Util.GetInstance().IsDateNull(knlv.TuThangNam))
        //        dfKNLVTuNgay.SetValue(knlv.TuThangNam);
        //    if (!SoftCore.Util.GetInstance().IsDateNull(knlv.DenThangNam))
        //        dfKNLVTuNgay.SetValue(knlv.DenThangNam);
        //    txt_lydochuyen.Text = knlv.KinhNghiemDatDuoc;
        //    wdKinhNghiemLamViec.Show();
        //}
        #endregion
        string id = RowSelectionModelKinhNghiemLamViec.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC knlv = new HoSoController().GetKinhNghiemLamViec(int.Parse(id));
            if (knlv == null)
            {
                return;
            }
            txt_noilamviec.Text = knlv.NoiLamViec;
            txt_vitriconviec.Text = knlv.ViTriCongViec;
            txtLyDoThoiViec.Text = knlv.LyDoThoiViec;
            nbfMucLuong.Value = knlv.MucLuong;
            txtGhiChuKinhNghiemLamViec.Text = knlv.GhiChu;
            if (!SoftCore.Util.GetInstance().IsDateNull(knlv.TuThangNam))
                dfKNLVTuNgay.SetValue(knlv.TuThangNam);
            if (!SoftCore.Util.GetInstance().IsDateNull(knlv.DenThangNam))
                dfKNLVDenNgay.SetValue(knlv.DenThangNam);
            txtThanhTichTrongCongViec.Text = knlv.KinhNghiemDatDuoc;
            wdKinhNghiemLamViec.Show();
        }
    }

    [DirectMethod]
    public void GetDataForDaiBieu()
    {
        //string id = RowSelectionModelDaiBieu.SelectedRecordID;
        //if (id == "")
        //{
        //    X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        //}
        //else
        //{
        //    DAL.HOSO_DAIBIEU daibieu = new HoSoController().GetDaiBieu(decimal.Parse(id));
        //    txtDBLoaiHinh.Text = daibieu.LOAI_HINH;
        //    txtDBNhiemKy.Text = daibieu.NHIEM_KY;
        //    if (daibieu.TU_NGAY != "")
        //        dfDBTuNgay.SelectedDate = DateTime.Parse(daibieu.TU_NGAY);
        //    if (daibieu.DEN_NGAY != "")
        //        dfDBDenNgay.SelectedDate = DateTime.Parse(daibieu.DEN_NGAY);
        //    txtDBGhiChu.Text = daibieu.GHI_CHU;
        //    wdDaiBieu.Show();
        //}
    }

    [DirectMethod]
    public void GetDataForKhaNang()
    {
        string id = RowSelectionModelKhaNang.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_KHANANG khanang = new HoSoController().GetKhaNang(decimal.Parse(id));
            cbKhaNang.SelectedItem.Value = khanang.MA_KHANANG;
            cbKhaNangXepLoai.SelectedItem.Value = khanang.MA_XEPLOAI;
            txtKhaNangGhiChu.Text = khanang.GHI_CHU;
            wdKhaNang.Show();
        }
    }
    [DirectMethod]
    public void GetDataForChungChi()
    {
        try
        {
            string id = RowSelectionModel_ChungChi.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_UNGVIEN_CHUNGCHI chungChi = new DM_CHUNGCHIController().GetById(int.Parse(id));
                if (chungChi == null)
                {
                    return;
                }
                cbx_tenchungchi.SetValue(chungChi.DM_CHUNGCHI.MA_CHUNGCHI);
                cbx_NoiDaoTao.Text = chungChi.NoiDaoTao;
                txtGhiChuChungChi.Text = chungChi.GhiChu;
                if (chungChi.NgayCap.HasValue && chungChi.NgayCap.Value.ToString().Contains("0001") == false)
                {
                    df_NgayCap.SelectedDate = chungChi.NgayCap.Value;
                }
                cbx_XepLoaiChungChi.SetValue(chungChi.MA_XEPLOAI);
                if (chungChi.NgayHetHan.HasValue && chungChi.NgayHetHan.Value.ToString().Contains("0001") == false)
                {
                    df_NgayHetHan.SelectedDate = chungChi.NgayHetHan.Value;
                }
                wdAddChungChi.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void GetDataForTepTin()
    {
        string id = RowSelectionModelTepTinDinhKem.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_TepTinDinhKem teptin = new HoSoController().GetTepTin(int.Parse(id));
            if (teptin != null)
            {
                txtFileName.Text = teptin.TenTepTin;
                if (!string.IsNullOrEmpty(teptin.Link))
                {
                    file_cv.Text = new CommonUtil().GetFileName(teptin.Link);
                    hdfAttachFile.Text = teptin.Link;
                }
                txtGhiChu.Text = teptin.GhiChu;
                wdAttachFile.Show();
            }
        }
    }

    [DirectMethod]
    public void GetDataForTaiSan()
    {
        string id = RowSelectionModelTaiSan.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_TAISAN taisan = new HoSoController().GetTaiSan(decimal.Parse(id));
            cbTaiSan.SelectedItem.Value = taisan.MA_VTHH;
            if (taisan.NGAY_NHAN != null && !taisan.NGAY_NHAN.ToString().Contains("0001"))
                tsDateField.SelectedDate = taisan.NGAY_NHAN.Value;
            tsTxtinhTrang.Text = taisan.TINH_TRANG;
            tsGhiChu.Text = taisan.GHI_CHU;
            txtTaiSanSoLuong.Text = taisan.SoLuong.ToString();
            cbxDonViTinh.SetValue(taisan.MaDonViTinh);
            wdAddTaiSan.Show();
        }
    }

    [DirectMethod]
    public void GetDataForKhenThuong()
    {
        string id = RowSelectionModelKhenThuong.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_KHENTHUONG khenthuong = new HoSoKhenThuongController().GetKhenThuong(decimal.Parse(id));
            txtKhenThuongSoQuyetDinh.Text = khenthuong.SO_QD;
            dfKhenThuongNgayQuyetDinh.SelectedDate = khenthuong.NGAY_QD.Value;
            cbHinhThucKhenThuong.SelectedItem.Value = khenthuong.MA_HT_KTHUONG;
            cbLyDoKhenThuong.Value = khenthuong.LYDO_KTHUONG;
            txtKhenThuongSoTien.Text = khenthuong.SO_TIEN.ToString();
            txtKhenThuongGhiCHu.Text = khenthuong.GHI_CHU;
            if (khenthuong.PrkeyNguoiQuyetDinh != null)
            {
                HOSO tmp = new HoSoController().GetByPrKey(khenthuong.PrkeyNguoiQuyetDinh.Value);
                if (tmp != null)
                {
                    tgf_KhenThuong_NguoiRaQD.Text = tmp.HO_TEN;
                    hdfKhenThuongNguoiQD.Text = khenthuong.PrkeyNguoiQuyetDinh.ToString();
                }
            }
            if (!string.IsNullOrEmpty(khenthuong.TepTinDinhKem))
            {
                int pos = khenthuong.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = khenthuong.TepTinDinhKem.Substring(pos + 1);
                    fufKhenThuongTepTinDinhKem.Text = tenTT;
                }
                hdfKhenThuongTepTinDinhKem.Text = khenthuong.TepTinDinhKem;
            }
            wdKhenThuong.Show();
        }
    }

    [DirectMethod]
    public void GetDataForTaiNan()
    {
        try
        {
            string id = RowSelectionModelTaiNanLaoDong.SelectedRecordID;
            if (id == "")
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
            }
            else
            {
                DAL.HOSO_TAINANLAODONG taiNan = new HoSoController().getTaiNan(int.Parse(id));
                if (taiNan.NGAY_XAY_RA.HasValue)
                {
                    TaiNan_dfNgayXayRa.SelectedDate = taiNan.NGAY_XAY_RA.Value;
                }
                TaiNan_txtBoiThuong.Text = taiNan.BOI_THUONG;
                TaiNan_txtDiaDiemXayRa.Text = taiNan.DIA_DIEM;
                TaiNan_txtGhiChu.Text = taiNan.GHI_CHU;
                TaiNan_txtLydo.Text = taiNan.LY_DO;
                TaiNan_txtThietHai.Text = taiNan.THIET_HAI;
                TaiNan_txtThuongTat.Text = taiNan.THUONG_TAT;
                if (taiNan.NgayBoiThuong.HasValue)
                    TaiNan_txtNgayBoiThuong.SetValue(taiNan.NgayBoiThuong);
                wdTaiNanLaoDong.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void CopyRecord(string tabTitle)
    {
        switch (tabTitle)
        {
            case "Tài sản":
                DataHandler.GetInstance().ExecuteNonQuery("insert into HOSO_TAISAN(FR_KEY,MA_VTHH,NGAY_NHAN,TINH_TRANG,GHI_CHU) " +
                    "select FR_KEY,MA_VTHH,NGAY_NHAN,TINH_TRANG,GHI_CHU from HOSO_TAISAN where PR_KEY = " + RowSelectionModelTaiSan.SelectedRecordID);
                GridPanelTaiSan.Reload();
                break;
            case "Khả năng":
                DataHandler.GetInstance().ExecuteNonQuery("insert into HOSO_KHANANG(FR_KEY,MA_KHANANG,MA_XEPLOAI,GHI_CHU)" +
                                                          "select FR_KEY,MA_KHANANG,MA_XEPLOAI,GHI_CHU from HOSO_KHANANG where PR_KEY =" + RowSelectionModelKhaNang.SelectedRecordID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreKhaNang}.reload();");
                GridPanelKhaNang.Reload();
                break;
            case "Khen thưởng":
                DataHandler.GetInstance().ExecuteNonQuery("insert into HOSO_KHENTHUONG(FR_KEY,SO_QD,NGAY_QD,LYDO_KTHUONG,MA_HT_KTHUONG,SO_TIEN,GHI_CHU)" +
                                                          "select FR_KEY,SO_QD,NGAY_QD, LYDO_KTHUONG,MA_HT_KTHUONG,SO_TIEN,GHI_CHU from HOSO_KHENTHUONG where PR_KEY =" + RowSelectionModelKhenThuong.SelectedRecordID);

                GridPanelKhenThuong.Reload();
                break;
            case "Quan hệ gia đình":
                DataHandler.GetInstance().ExecuteNonQuery("insert into HOSO_QH_GIADINH(FR_KEY,HO_TEN,TUOI,MA_QUANHE,NGHE_NGHIEP,NOI_LAMVIEC,GIOI_TINH,GHI_CHU)" +
                                                          "select FR_KEY,HO_TEN,TUOI,MA_QUANHE,NGHE_NGHIEP,NOI_LAMVIEC,GIOI_TINH,GHI_CHU from HOSO_QH_GIADINH where PR_KEY =" + RowSelectionModelQHGD.SelectedRecordID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQHGD}.reload();");
                GridPanelQHGD.Reload();
                break;
            case "Quá trình công tác":
                DataHandler.GetInstance().ExecuteNonQuery("insert into HOSO_QT_CTAC(FR_KEY,TU_NGAY,DEN_NGAY,CONG_VIEC,DON_VI,CHUC_VU,MA_NUOC,LY_DO,CQ_QUYETDINH,SO_TIEN,GHI_CHU)" +
                                                          "select FR_KEY,TU_NGAY,DEN_NGAY,CONG_VIEC,DON_VI,CHUC_VU,MA_NUOC,LY_DO,CQ_QUYETDINH,SO_TIEN,GHI_CHU from HOSO_QT_CTAC where PR_KEY =" + RowSelectionModelQuaTrinhCongTac.SelectedRecordID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQuaTrinhCongTac}.reload();");
                GridPanelQuaTrinhCTAC.Reload();
                break;
            case "Quá trình điều chuyển":
                DataHandler.GetInstance().ExecuteNonQuery("insert into HOSO_QT_DIEUCHUYEN(FR_KEY,TU_NGAY,DEN_NGAY,DON_VI,MA_PHONG,MA_CHUCVU,MA_NGACH,HS_LUONG,PHUCAP,GHI_CHU)" +
                                                          "select FR_KEY,TU_NGAY,DEN_NGAY,DON_VI,MA_PHONG,MA_CHUCVU,MA_NGACH,HS_LUONG,PHUCAP,GHI_CHU from HOSO_QT_DIEUCHUYEN where PR_KEY =" + RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQuaTrinhDieuChuyen}.reload();");
                GridPanelQuaTrinhDieuChuyen.Reload();
                break;
            case "Tai nạn lao động":
                new HoSoController().DuplidateTaiNanLaoDong(int.Parse(RowSelectionModelTaiNanLaoDong.SelectedRecordID), CurrentUser.ID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreTaiNanLaoDong}.reload();");
                GridPanelTaiNanLaoDong.Reload();
                break;
            case "Bằng cấp chứng chỉ":
                new HoSoController().DuplidateBangCapChungChi(int.Parse(RowSelectionModel_ChungChi.SelectedRecordID));
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{Store_BangCapChungChi}.reload();");
                GridPanel_ChungChi.Reload();
                break;
            case "Kinh nghiệm làm việc":
                new HoSoController().DuplicateKinhNghiemLamViec(int.Parse(RowSelectionModelKinhNghiemLamViec.SelectedRecordID), CurrentUser.ID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreKinhNghiemLamViec}.reload();");
                GridPanelKinhNghiemLamViec.Reload();
                break;
            case "Quá trình học tập":
                new HoSoController().DuplicateQuaTrinhHocTap(int.Parse(RowSelectionModel_BangCap.SelectedRecordID), CurrentUser.ID);
                //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{Store_BangCap}.reload();");
                GridPanel_BangCap.Reload();
                break;
        }
    }

    [DirectMethod]
    public void GetDataForQuaTrinhCongTac()
    {
        string id = RowSelectionModelQuaTrinhCongTac.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_QT_CTAC qtCongTac = new HOSO_QT_CTACController().GetQuaTrinhCongTac(decimal.Parse(id));
            txtQTCTSoQD.Text = qtCongTac.SoQuyetDinh;
            if (qtCongTac.PrkeyNguoiQuyetDinh != null)
            {
                HOSO hs = new HoSoController().GetByPrKey(qtCongTac.PrkeyNguoiQuyetDinh.Value);
                if (hs != null)
                {
                    hdfQTCTNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
                    tgf_QTCTNguoiQuyetDinh.Text = hs.HO_TEN;
                }
            }
            dfQTCTNgayQuyetDinh.SetValue(qtCongTac.NgayQuyetDinh);
            dfQTCTNgayBatDau.SetValue(qtCongTac.ThoiGianBatDau);
            dfQTCTNgayKetThuc.SetValue(qtCongTac.ThoiGianKetThuc);
            txtQTCTNoiDungCongViec.Text = qtCongTac.NoiDungCongViec;
            txtQTCTNguoiLienQuan.Text = qtCongTac.NguoiLienQuan;
            cbCongTacQuocGia.SetValue(qtCongTac.MaQuocGia);
            txtQTCTDiaDiemCT.Text = qtCongTac.DiaDiemCongTac;
            if (!string.IsNullOrEmpty(qtCongTac.TepTinDinhKem))
            {
                int pos = qtCongTac.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = qtCongTac.TepTinDinhKem.Substring(pos + 1);
                    fufQTCTTepTinDinhKem.Text = tenTT;
                }
                hdfQTCTTepTinDinhKem.Text = qtCongTac.TepTinDinhKem;
            }
            txtCongTacGhiChu.Text = qtCongTac.GHI_CHU;
            wdQuaTrinhCongTac.Show();
        }
    }

    [DirectMethod]
    public void GetDataForQuaTrinhDieuChuyen()
    {
        string id = RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID;
        if (id == "")
        {
            X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
        }
        else
        {
            DAL.HOSO_QT_DIEUCHUYEN dieuchuyen = new HOSO_QT_DIEUCHUYENController().GetQuaTrinhDieuChuyen(decimal.Parse(id));
            txtQTDCSoQuyetDinh.Text = dieuchuyen.SoQuyetDinh;
            if (dieuchuyen.PrkeyNguoiQuyetDinh != null)
            {
                HOSO hs = new HoSoController().GetByPrKey(dieuchuyen.PrkeyNguoiQuyetDinh.Value);
                if (hs != null)
                {
                    hdfQTDCNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
                    tgfQTDCNguoiQuyetDinh.Text = hs.HO_TEN;
                }
            }
            dfQTDCNgayQuyetDinh.SetValue(dieuchuyen.NgayQuyetDinh);
            dfQTDCNgayCoHieuLuc.SetValue(dieuchuyen.NgayCoHieuLuc);
            dfQTDCNgayHetHieuLuc.SetValue(dieuchuyen.NgayHetHieuLuc);
            cbxQTDCBoPhanMoi.SetValue(dieuchuyen.MaBoPhanMoi);
            cbxQTDCChucVuMoi.SetValue(dieuchuyen.MaChucVuMoi);
            cbxCongViecMoi.SetValue(dieuchuyen.MaCongViecMoi);
            if (!string.IsNullOrEmpty(dieuchuyen.TepTinDinhKem))
            {
                int pos = dieuchuyen.TepTinDinhKem.LastIndexOf('/');
                if (pos != -1)
                {
                    string tenTT = dieuchuyen.TepTinDinhKem.Substring(pos + 1);
                    fufQTDCTepTinDinhKem.Text = tenTT;
                }
                hdfQTDCTepTinDinhKem.Text = dieuchuyen.TepTinDinhKem;
            }
            txtDieuChuyenGhiChu.Text = dieuchuyen.GhiChu;
            wdQuaTrinhDieuChuyen.Show();
        }
    }

    //public void GetDataForQuaTrinhDieuChuyen()
    //{
    //    string id = RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID;
    //    if (id == "")
    //    {
    //        X.Msg.Alert("Thông báo", "Bạn chưa chọn bản ghi nào").Show();
    //    }
    //    else
    //    {
    //        DAL.HOSO_QT_DIEUCHUYEN dieuchuyen = new HOSO_QT_DIEUCHUYENController().GetQuaTrinhDieuChuyen(decimal.Parse(id));
    //        txtQTDCSoQuyetDinh.Text = dieuchuyen.SoQuyetDinh;
    //        if (dieuchuyen.PrkeyNguoiQuyetDinh != null)
    //        {
    //            HOSO hs = new HoSoController().GetByPrKey(dieuchuyen.PrkeyNguoiQuyetDinh.Value);
    //            if (hs != null)
    //            {
    //                hdfQTDCNguoiQuyetDinh.Text = hs.PR_KEY.ToString();
    //                tgfQTDCNguoiQuyetDinh.Text = hs.HO_TEN;
    //            }
    //        }
    //        dfQTDCNgayQuyetDinh.SetValue(dieuchuyen.NgayQuyetDinh);
    //        dfQTDCNgayCoHieuLuc.SetValue(dieuchuyen.NgayCoHieuLuc);
    //        dfQTDCNgayHetHieuLuc.SetValue(dieuchuyen.NgayHetHieuLuc);
    //        cbxQTDCBoPhanMoi.SetValue(dieuchuyen.MaBoPhanMoi);
    //        cbxQTDCChucVuMoi.SetValue(dieuchuyen.MaChucVuMoi);
    //        cbQTDCChucVuCu.SetValue(dieuchuyen.MaChucVuCu);
    //        cbQTDCBoPhanCu.SetValue(dieuchuyen.MaBoPhanCu);
    //        if (!string.IsNullOrEmpty(dieuchuyen.TepTinDinhKem))
    //        {
    //            int pos = dieuchuyen.TepTinDinhKem.LastIndexOf('/');
    //            if (pos != -1)
    //            {
    //                string tenTT = dieuchuyen.TepTinDinhKem.Substring(pos + 1);
    //                fufQTDCTepTinDinhKem.Text = tenTT;
    //            }
    //            hdfQTDCTepTinDinhKem.Text = dieuchuyen.TepTinDinhKem;
    //        }
    //        txtDieuChuyenGhiChu.Text = dieuchuyen.GhiChu;
    //        wdQuaTrinhDieuChuyen.Show();
    //    }
    //}
    #endregion

    protected void btnUpdateImage_Click(object sender, DirectEventArgs e)
    {
        try
        { 
            HttpPostedFile file = fufUploadControl.PostedFile; 
            if (fufUploadControl.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                string path = string.Empty;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath(hdfImageFolder.Text));
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath(hdfImageFolder.Text + "/") + fufUploadControl.FileName;
                    file.SaveAs(path);
                    hdfUploadedImage.Text = hdfImageFolder.Text + "/" + fufUploadControl.FileName;
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
            wdUploadImageWindow.Hide(); 
            img_anhdaidien.ImageUrl = hdfImageFolder.Text + "/" + fufUploadControl.FileName;
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }
    protected void StoreQHGD_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_TUCAPNHAT_GetQuanHeGiaDinh", "@PrKeyHoSoTuCapNhat", decimal.Parse("0" + hdf_PR_KEY.Text));
        StoreQHGD.DataSource = table;
        StoreQHGD.DataBind();
    }

    protected void StoreKinhNghiemLamViec_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreKinhNghiemLamViec.DataSource = DataHandler.GetInstance().ExecuteDataTable("HOSO_TUCAPNHAT_GetKinhNghiemLamViec", "@prkeyHoSoTuCapNhat", decimal.Parse("0" + hdf_PR_KEY.Text));
            StoreKinhNghiemLamViec.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID("0");
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            obj.Add(new { MA = info.MA, TEN = info.TEN });
            obj = LoadMenuCon(obj, info.MA, 1);
        }
        cbx_bophan_Store.DataSource = obj;
        cbx_bophan_Store.DataBind();
    }

    protected void cbxHinhThucLamViec_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxHinhThucLamViec_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("HinhThucLamViec", true);
        cbxHinhThucLamViec_Store.DataBind();
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

    protected void Store_BangCapChungChi_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (hdf_PR_KEY.Text != "")
            {
                Store_BangCapChungChi.DataSource = new HOSO_UNGVIEN_CHUNGCHIController().GetByPrKeyTuCapNhat(decimal.Parse(hdf_PR_KEY.Text));
                Store_BangCapChungChi.DataBind();
                hdfBangCapChungChi.Text = "";
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
     
    protected void Store_BangCap_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (hdf_PR_KEY.Text != "")
            {
                Store_BangCap.DataSource = DataHandler.GetInstance().ExecuteDataTable("StoreBangCap", "@PrKeyHoSoTuCapNhat", hdf_PR_KEY.Text);
                Store_BangCap.DataBind();
                hdfQuaTrinhHocTapState.Text = "";
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void StoreTaiSan_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_TUCAPNHAT_GetTaiSan", "@PrKeyHoSoTuCapNhat", hdf_PR_KEY.Text);
        StoreTaiSan.DataSource = table;
        StoreTaiSan.DataBind();
    }


    protected void StoreKhaNang_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_TUCAPNHAT_GetHoSoKhaNang", "@PrKeyHoSoTuCapNhat", hdf_PR_KEY.Text);
        StoreKhaNang.DataSource = table;
        StoreKhaNang.DataBind();
    }
     
    protected void grpTepTinDinhKemStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (hdf_PR_KEY.Text != "")
            {
                grpTepTinDinhKemStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select * from HOSO_TepTinDinhKem where PrKeyHoSoTuCapNhat = " + hdf_PR_KEY.Text);
                grpTepTinDinhKemStore.DataBind();
                hdfTepTinDinhKem.Text = "";
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }


    protected void cbQuanHeGiaDinhStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbQuanHeGiaDinhStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_QUANHE,TEN_QUANHE from DM_QUANHE");
            cbQuanHeGiaDinhStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
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
            string serverPath = Server.MapPath(e.ExtraParams["AttachFile"]);
            //Dialog.ShowError(serverPath);
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
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void btnUpdateQuanHeGiaDinh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_QH_GIADINH qhgd = new HOSO_QH_GIADINH()
            {
                FR_KEY = -1,
                GHI_CHU = txtQHGDGhiChu.Text,
                HO_TEN = txtQHGDHoTen.Text,
                GIOI_TINH = cbQHGDGioiTinh.Text,
                MA_QUANHE = cbQuanHeGiaDinh.SelectedItem.Value,
                NOI_LAMVIEC = txtQHGDNoiLamViec.Text,
                TUOI = txtQHGDNamSinh.Text,
                NGHE_NGHIEP = txtQHGDNgheNghiep.Text,
                LaNguoiPhuThuoc = chkQHGDLaNguoiPhuThuoc.Checked,
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
                Duyet = false,
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(dfQHGDBatDauGiamTru.SelectedDate))
            {
                qhgd.NgayBatDauGiamTru = dfQHGDBatDauGiamTru.SelectedDate;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(dfQHGDKetThucGiamTru.SelectedDate))
            {
                qhgd.NgayKetThucGiamTru = dfQHGDKetThucGiamTru.SelectedDate;
            }
            if (e.ExtraParams["Command"] == "Update")
            {
                wdQuanHeGiaDinh.Hide();
                qhgd.PR_KEY = decimal.Parse(RowSelectionModelQHGD.SelectedRecordID);
                new QuanHeGiaDinhController().Update(qhgd);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuanHeGiaDinh.Hide();
                }
            }
            else //Nếu insert
            {
                new HoSoController().InsertQuanHeGiaDinh(qhgd);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuanHeGiaDinh.Hide();
                }
            }
            hdfQuanHeGiaDinh.Text = "changed";
            GridPanelQHGD.Reload();

            //reset các giá trị
            RM.RegisterClientScriptBlock("resetQHGD", "resetFormQuanHeGiaDinh();");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbx_tenchungchiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<DM_CHUNGCHIInfo> db = new DM_CHUNGCHIController().GetAll();
            cbx_tenchungchiStore.DataSource = db;
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
            cbx_XepLoaiChungChiStore.DataSource = new DM_XEPLOAIController().GetAll();
            cbx_XepLoaiChungChiStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
      
    protected void StoreKhenThuong_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("HOSO_TUCAPNHAT_GetKhenThuong", "@PrKeyHoSoTuCapNhat", hdf_PR_KEY.Text);
        StoreKhenThuong.DataSource = table;
        StoreKhenThuong.DataBind();
    }

    protected void btnUpdateChungChi_Click(object sender, DirectEventArgs e)
    {
        #region code cũ
        //try
        //{
        //    HOSO_UNGVIEN_CHUNGCHIController ctrol = new HOSO_UNGVIEN_CHUNGCHIController();
        //    DAL.HOSO_UNGVIEN_CHUNGCHI hschungchi;
        //    if (e.ExtraParams["Command"] == "Edit")
        //    {
        //        hschungchi = new HOSO_UNGVIEN_CHUNGCHIController().GetByID(int.Parse(RowSelectionModel_ChungChi.SelectedRecordID));
        //    }
        //    hschungchi = new HOSO_UNGVIEN_CHUNGCHI()
        //    {
        //        MaChungChi = cbx_tenchungchi.SelectedItem.Value,
        //        NoiDaoTao = cbx_NoiDaoTao.Text,                
        //        MA_XEPLOAI = cbx_XepLoaiChungChi.SelectedItem.Value,
        //        FR_KEY_HOSO = 0,
        //        PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
        //        GhiChu = txtGhiChuChungChi.Text,
        //    };

        //    if (!Util.GetInstance().IsDateNull(df_NgayCap.SelectedDate))
        //    {
        //        hschungchi.NgayCap = df_NgayCap.SelectedDate;
        //    }
        //    if (!Util.GetInstance().IsDateNull(df_NgayHetHan.SelectedDate))
        //    {
        //        hschungchi.NgayHetHan = df_NgayHetHan.SelectedDate;
        //    }
        //    if (ctrol.GetByMaCCandPrKeyHoSoTuCapNhat(cbx_tenchungchi.SelectedItem.Value, decimal.Parse(hdf_PR_KEY.Text)) != null)
        //    {
        //        ctrol.UpdateForTuCapNhat(hschungchi);
        //    }
        //    else
        //        if (e.ExtraParams["Command"] == "Edit")
        //        {
        //            hschungchi.ID = int.Parse(RowSelectionModel_ChungChi.SelectedRecordID);
        //            ctrol.UpdateForTuCapNhat(hschungchi);
        //            wdAddChungChi.Hide();
        //        }
        //        else
        //        {
        //            ctrol.Insert(hschungchi);
        //            if (e.ExtraParams["Close"] == "True")
        //            {
        //                GridPanel_ChungChi.Reload();
        //                wdAddChungChi.Hide();                    
        //            }
        //            else
        //            {
        //                RM.RegisterClientScriptBlock("rs1", "resetWdChungChi();");
        //            }
        //        }           
        //    GridPanel_ChungChi.Reload();
        //    RM.RegisterClientScriptBlock("resetWdChungChi", "resetWdChungChi()");
        //    hdfBangCapChungChi.Text = "changed";
        //}
        //catch (Exception ex)
        //{
        //    Dialog.ShowError(ex.Message.ToString());
        //}
        #endregion
        try
        {
            HOSO_UNGVIEN_CHUNGCHIController ctrol = new HOSO_UNGVIEN_CHUNGCHIController();
            DAL.HOSO_UNGVIEN_CHUNGCHI hschungchi = new HOSO_UNGVIEN_CHUNGCHI();
            hschungchi.MaChungChi = cbx_tenchungchi.SelectedItem.Value;
            hschungchi.PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text);
            if (df_NgayCap.SelectedDate.ToString().Contains("0001") == false)
            {
                hschungchi.NgayCap = df_NgayCap.SelectedDate;// DateTime.Parse(df_NgayCap.Value.ToString());                
            }
            if (df_NgayHetHan.SelectedDate.ToString().Contains("0001") == false)
            {
                hschungchi.NgayHetHan = df_NgayHetHan.SelectedDate;// DateTime.Parse(df_NgayHetHan.Value.ToString());                
            }
            hschungchi.NoiDaoTao = cbx_NoiDaoTao.Text;
            hschungchi.MA_XEPLOAI = cbx_XepLoaiChungChi.SelectedItem.Value;
            hschungchi.FR_KEY_HOSO = 0;
            hschungchi.GhiChu = txtGhiChuChungChi.Text;
            if (e.ExtraParams["Command"] == "Edit")
            {
                hschungchi.ID = int.Parse("0" + hdfChungChiID.Text);
                ctrol.UpdateForTuCapNhat(hschungchi);
                wdAddChungChi.Hide();
            }
            else
            {
                ctrol.Insert(hschungchi);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddChungChi.Hide();
                }
            }
            GridPanel_ChungChi.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void UpdateKinhNghiemLamViec_Click(object sender, DirectEventArgs e)
    {
        #region code cũ
        //try
        //{
        //    HOSO_UNGVIEN_KINHNGHIEMLAMVIECController kingnghiemlamviec = new HOSO_UNGVIEN_KINHNGHIEMLAMVIECController();
        //    DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC kinhnghiem = new HOSO_UNGVIEN_KINHNGHIEMLAMVIEC()
        //    {
        //        FR_KEY = -1,
        //        NoiLamViec = txt_noilamviec.Text,
        //        KinhNghiemDatDuoc = txt_lydochuyen.Text,
        //        //TuThangNam = cbxKNLVTuNgay.SelectedItem.Value + "/" + nfKNLVTuNgay.Text,
        //        ViTriCongViec = txt_vitriconviec.Text,
        //        //DenThangNam = cbxKNLVDenNgay.SelectedItem.Value + "/" + nfKNLVDenNgay.Text,
        //        //CongViecDamNhiem = txt_conviecdamnhiem.Text,
        //        CreatedUser = CurrentUser.ID,
        //        PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
        //    };
        //    if (!SoftCore.Util.GetInstance().IsDateNull(dfKNLVTuNgay.SelectedDate))
        //        kinhnghiem.TuThangNam = dfKNLVTuNgay.SelectedDate;
        //    if (!SoftCore.Util.GetInstance().IsDateNull(dfKNLVDenNgay.SelectedDate))
        //        kinhnghiem.DenThangNam = dfKNLVDenNgay.SelectedDate;
        //    if (e.ExtraParams["Command"] == "Edit")
        //    {
        //        kinhnghiem.ID = int.Parse(RowSelectionModelKinhNghiemLamViec.SelectedRecordID);
        //        kingnghiemlamviec.UpdateForTuCapNhat(kinhnghiem);
        //        wdKinhNghiemLamViec.Hide();
        //    }
        //    else
        //    {
        //        kingnghiemlamviec.Insert(kinhnghiem);
        //        if (e.ExtraParams["Close"] == "True")
        //        {
        //            wdKinhNghiemLamViec.Hide();
        //        }
        //    }

        //    hdfKinhNghiemLamViecStatus.Text = "changed";
        //}
        //catch (Exception ex)
        //{
        //    Dialog.ShowError(ex.Message);
        //}
        //GridPanelKinhNghiemLamViec.Reload();
        #endregion
        try
        {
            HOSO_UNGVIEN_KINHNGHIEMLAMVIECController kingnghiemlamviec = new HOSO_UNGVIEN_KINHNGHIEMLAMVIECController();
            DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC kinhnghiem = new HOSO_UNGVIEN_KINHNGHIEMLAMVIEC()
            {
                FR_KEY = -1,
                NoiLamViec = txt_noilamviec.Text,
                KinhNghiemDatDuoc = txtThanhTichTrongCongViec.Text,
                LyDoThoiViec = txtLyDoThoiViec.Text,
                MucLuong = decimal.Parse("0" + nbfMucLuong.Text),
                GhiChu = txtGhiChuKinhNghiemLamViec.Text,
                ViTriCongViec = txt_vitriconviec.Text,
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text)
            };
            if (!SoftCore.Util.GetInstance().IsDateNull(dfKNLVTuNgay.SelectedDate))
                kinhnghiem.TuThangNam = dfKNLVTuNgay.SelectedDate;//txt_tuthangnam.Text; 
            if (!SoftCore.Util.GetInstance().IsDateNull(dfKNLVDenNgay.SelectedDate))
                kinhnghiem.DenThangNam = dfKNLVDenNgay.SelectedDate;//txt_denthangnam.Text; 
            kinhnghiem.CreatedUser = CurrentUser.ID;

            if (e.ExtraParams["Command"] == "Edit")
            {
                kinhnghiem.ID = int.Parse(RowSelectionModelKinhNghiemLamViec.SelectedRecordID);
                kingnghiemlamviec.Update(kinhnghiem);
                wdKinhNghiemLamViec.Hide();
                GridPanelKinhNghiemLamViec.Reload();
            }
            else
            {
                kingnghiemlamviec.Insert(kinhnghiem);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKinhNghiemLamViec.Hide();
                }
                GridPanelKinhNghiemLamViec.Reload();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    private string GetSelectedKhoaDaoTao(string[] arr, string MaKhoaDaoTao)
    {
        foreach (var item in arr)
        {
            if (item.StartsWith(MaKhoaDaoTao))
            {
                return item;
            }
        }
        return "";
    }
      
    protected void grpDonViTinh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        grpDonViTinh_Store.DataSource = new DanhMucDonViTinhController().GetByAll();
        grpDonViTinh_Store.DataBind();
    }

    protected void cbTaiSanStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<DM_VTHHInfo> vthh = new DM_VTHHController().GetAll();
            cbTaiSanStore.DataSource = vthh;
            cbTaiSanStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message.ToString());
        }
    }

    protected void btnUpdateTaiSan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_TAISAN ts = new HOSO_TAISAN()
            {
                FR_KEY = -1,
                GHI_CHU = tsGhiChu.Text,
                MA_VTHH = cbTaiSan.SelectedItem.Value,
                NGAY_NHAN = tsDateField.SelectedDate,
                TINH_TRANG = tsTxtinhTrang.Text,
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
                MaDonViTinh = cbxDonViTinh.SelectedItem.Value,
                SoLuong = int.Parse(txtTaiSanSoLuong.Text),
            };
            if (e.ExtraParams["Command"] == "Update")
            {
                ts.PR_KEY = decimal.Parse(RowSelectionModelTaiSan.SelectedRecordID);
                new HOSO_TAISANController().Update(ts);
                wdAddTaiSan.Hide();
            }
            else
            {
                new HoSoController().InsertTaiSan(ts);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddTaiSan.Hide();
                }
            }
            hdfTaiSanState.Text = "changed";
            GridPanelTaiSan.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }

    protected void btnUpdateBangCap_Click(object sender, DirectEventArgs e)
    {
        HOSO_BANGCAP_UNGVIENController hsbangcapuv = new HOSO_BANGCAP_UNGVIENController();
        DAL.HOSO_BANGCAP_UNGVIEN hsbangcap = new DAL.HOSO_BANGCAP_UNGVIEN()
        {
            KHOA = txt_khoa.Text,
            MA_HT_DAOTAO = cbx_hinhthucdaotaobang.SelectedItem.Value,
            MA_TRINHDO = cbx_trinhdobangcap.SelectedItem.Value,
            USERNAME = CurrentUser.ID.ToString(),
            MA_TRUONG_DAOTAO = cbx_NoiDaoTaoBangCap.SelectedItem.Value,
            FR_KEY = -1,
            MA_CHUYENNGANH = cbx_ChuyenNganhBangCap.SelectedItem.Value,
            DA_TN = Chk_DaTotNghiep.Checked,
            TU_NGAY = df_ngaybatdauhoc.SelectedDate,
            DEN_NGAY = df_ngayketthuchoc.SelectedDate,
            DATE_CREATE = DateTime.Now,
            PrkeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text)
        };
        if (Chk_DaTotNghiep.Checked)
        {
            hsbangcap.MA_XEPLOAI = cbx_xeploaiBangCap.SelectedItem.Value;
            if (!SoftCore.Util.GetInstance().IsDateNull(df_NgayNhanBang.SelectedDate))
                hsbangcap.NGAY_NHANBANG = df_NgayNhanBang.SelectedDate;
        }
        else
        {
            hsbangcap.MA_XEPLOAI = null;
            hsbangcap.NGAY_NHANBANG = null;
        }
        if (e.ExtraParams["Command"] == "Edit")
        {
            hsbangcap.ID = int.Parse(RowSelectionModel_BangCap.SelectedRecordID);
            hsbangcapuv.UpdateForTuCapNhat(hsbangcap);
            wdAddBangCap.Hide();
        }
        else
        {
            hsbangcapuv.Insert(hsbangcap);
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddBangCap.Hide();
            }
            else
            {
                RM.RegisterClientScriptBlock("rs1", "ResetWdQuaTrinhHocTap();");
            }
        }
        hdfQuaTrinhHocTapState.Text = "changed";
        GridPanel_BangCap.Reload();
    }

    protected void cbKhaNangStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbKhaNangStore.DataSource = DataHandler.GetInstance().ExecuteDataTable(" select MA_KHANANG,TEN_KHANANG from DM_KHANANG");
            cbKhaNangStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message.ToString());
        }
    }
    protected void cbxDonViTinh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxDonViTinh_Store.DataSource = new DanhMucDonViTinhController().GetByAll();
        cbxDonViTinh_Store.DataBind();
    }
    protected void cbKhaNangXepLoaiStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbKhaNangXepLoaiStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_XEPLOAI,TEN_XEPLOAI from DM_XEPLOAI");
            cbKhaNangXepLoaiStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message.ToString());
        }
    }

    protected void btnUpdateKhaNang_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_KHANANG khaNang = new HOSO_KHANANG()
            {
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
                GHI_CHU = txtKhaNangGhiChu.Text,
                MA_KHANANG = cbKhaNang.SelectedItem.Value,
                MA_XEPLOAI = cbKhaNangXepLoai.SelectedItem.Value,
                FR_KEY = -1,

            };
            if (e.ExtraParams["Command"] == "Update")
            {
                khaNang.PR_KEY = decimal.Parse(RowSelectionModelKhaNang.SelectedRecordID);
                wdKhaNang.Hide();
                new KhaNangController().Update(khaNang);
            }
            else
            {
                new HoSoController().InsertKhaNang(khaNang);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKhaNang.Hide();
                }
            }
            hdfKhaNangState.Text = "changed";
            GridPanelKhaNang.Reload();
            RM.RegisterClientScriptBlock("resetKhaNang", "resetKhaNang()");
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message.ToString());
        }
    }

    protected void btnUpdateKhenThuong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufKhenThuongTepTinDinhKem.HasFile)
            {
                path = UploadFile(fufKhenThuongTepTinDinhKem, "../HoSoNhanSu/File/KhenThuong");
            }
            // insert ly do khen thuong (neu co)
            string maLyDoKT = "";
            if (hdfIsDanhMuc.Text == "0")
            {
                try
                {
                    DAL.DM_LYDO_KTHUONG lyDo = new DM_LYDO_KTHUONG();
                    lyDo.TEN_LYDO_KTHUONG = cbLyDoKhenThuong.Text;
                    lyDo.MA_DONVI = Session["MaDonVi"].ToString();
                    lyDo.USERNAME = CurrentUser.DisplayName;
                    lyDo.DATE_CREATE = DateTime.Now;
                    lyDo.MA_LYDO_KTHUONG = CommonUtil.GetInstance().GenerateMaSo("DM_LYDO_KTHUONG", "MA_LYDO_KTHUONG", "KT");
                    new DM_LyDoKhenThuongControllercs().Insert(lyDo);
                    maLyDoKT = cbLyDoKhenThuong.Text;
                }
                catch (Exception)
                {
                    maLyDoKT = cbLyDoKhenThuong.Text;
                }
            }
            else
            {
                maLyDoKT = cbLyDoKhenThuong.SelectedItem.Text;
            }
            if (string.IsNullOrEmpty(maLyDoKT))
            {
                X.Msg.Alert("Thông báo", "Không tìm thấy lý do khen thưởng. Vui lòng thử lại!").Show();
                return;
            }
            DAL.HOSO_KHENTHUONG khenthuong = new HOSO_KHENTHUONG()
            {
                FR_KEY = decimal.Parse(hdf_PR_KEY.Text),
                GHI_CHU = txtKhenThuongGhiCHu.Text,
                LYDO_KTHUONG = maLyDoKT,
                MA_HT_KTHUONG = cbHinhThucKhenThuong.SelectedItem.Value,
                SO_QD = txtKhenThuongSoQuyetDinh.Text,
                SO_TIEN = decimal.Parse("0" + txtKhenThuongSoTien.Text),
                NGAY_QD = dfKhenThuongNgayQuyetDinh.SelectedDate,
                PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfKhenThuongNguoiQD.Text),
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
            };
            if (path != "")
                khenthuong.TepTinDinhKem = path;
            else
                khenthuong.TepTinDinhKem = hdfKhenThuongTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                wdKhenThuong.Hide();
                khenthuong.PR_KEY = decimal.Parse(RowSelectionModelKhenThuong.SelectedRecordID);
                new KhenThuongController().Update(khenthuong);
            }
            else
            {
                new HoSoKhenThuongController().InsertKhenThuong(khenthuong);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKhenThuong.Hide();
                }
            }
            GridPanelKhenThuong.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnKhenThuongDownload_Click(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(hdf_PR_KEY.Text))
        {
            DownloadAttachFile("HOSO_KHENTHUONG", hdfKhenThuongTepTinDinhKem);
        }
    }
    protected void cbLyDoKhenThuongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbLyDoKhenThuongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LYDO_KTHUONG,TEN_LYDO_KTHUONG from DM_LYDO_KTHUONG");
        cbLyDoKhenThuongStore.DataBind();
    }
    protected void cbHinhThucKhenThuongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbHinhThucKhenThuongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_HT_KTHUONG,TEN_HT_KTHUONG from DM_HT_KTHUONG");
            cbHinhThucKhenThuongStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnKhenThuongDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(RowSelectionModelKhenThuong.SelectedRecordID))
            {
                DeleteTepTinDinhKem("HOSO_KHENTHUONG", decimal.Parse(RowSelectionModelKhenThuong.SelectedRecordID), hdfKhenThuongTepTinDinhKem);
                hdfKhenThuongTepTinDinhKem.Text = "";
                GridPanelKhenThuong.Reload();
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

    // ky luat
    protected void btnCapNhatKyLuat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufKyLuatTepTinDinhKem.HasFile)
            {
                path = UploadFile(fufKyLuatTepTinDinhKem, "../HoSoNhanSu/File/KyLuat");
            }
            DAL.HOSO_KYLUAT kyluat = new HOSO_KYLUAT()
            {
                FR_KEY = decimal.Parse(hdf_PR_KEY.Text),
                GHI_CHU = txtKyLuatGhiChu.Text,
                MA_HT_KYLUAT = cbHinhThucKyLuat.SelectedItem.Value, 
                SO_TIEN = decimal.Parse("0" + txtKyLuatSoTien.Text),
                SO_QD = txtKyLuatSoQD.Text,
                NGAY_QD = dfKyLuatNgayQuyetDinh.SelectedDate,
                PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfKyLuatNguoiQD.Text),
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
            };
            if (path != "")
                kyluat.TepTinDinhKem = path;
            else
                kyluat.TepTinDinhKem = hdfKyLuatTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                kyluat.PR_KEY = decimal.Parse(RowSelectionModelKyLuat.SelectedRecordID);
                new HoSoKyLuatController().Update(kyluat);
                wdKyLuat.Hide();
            }
            else
            {
                new HoSoKyLuatController().InsertKyluat(kyluat);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdKyLuat.Hide();
                }
                else
                {
                    GenerateKyLuatSoQD();
                }
            } 
            GridPanelKyLuat.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void cbLyDoKyLuatStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbLyDoKyLuatStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LYDO_KYLUAT,TEN_LYDO_KYLUAT from DM_LYDO_KYLUAT");
        cbLyDoKyLuatStore.DataBind();
    }
    protected void cbHinhThucKyLuatStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbHinhThucKyLuatStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_HT_KYLUAT,TEN_HT_KYLUAT from DM_HT_KYLUAT");
        cbHinhThucKyLuatStore.DataBind();
    }
    protected void btnKyLuatDownload_Click(object sender, DirectEventArgs e)
    {
        if (hdf_PR_KEY.Text != "")
        {
            DownloadAttachFile("HOSO_KYLUAT", hdfKyLuatTepTinDinhKem);
        }
    }
    protected void btnKyLuatDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdf_PR_KEY.Text != "")
        {
            DeleteTepTinDinhKem("HOSO_KYLUAT", decimal.Parse(RowSelectionModelKyLuat.SelectedRecordID), hdfKyLuatTepTinDinhKem);
            hdfKyLuatTepTinDinhKem.Text = "";
            GridPanelKyLuat.Reload();
        }
    }
    [DirectMethod]
    public void GenerateKyLuatSoQD()
    {
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_KYLUAT", "SO_QD", "QĐ-KL");
        txtKyLuatSoQD.Text = sohd;
    }
    protected void StoreKyLuat_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("select * from v_HOSO_KYLUAT where PrKeyHoSoTuCapNhat = " + hdf_PR_KEY.Text);
        StoreKyLuat.DataSource = table;
        StoreKyLuat.DataBind();
    }

    // qua trinh cong tac
    protected void btnCapNhatQuaTrinhCongTac_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (fufQTCTTepTinDinhKem.HasFile)
            {
                path = UploadFile(fufQTCTTepTinDinhKem, "../HoSoNhanSu/File/QuaTrinhCongTac");
            }
            DAL.HOSO_QT_CTAC qtcongTac = new HOSO_QT_CTAC()
            {
                FR_KEY = -1,
                MaQuocGia = cbCongTacQuocGia.SelectedItem.Value,
                NguoiLienQuan = txtQTCTNguoiLienQuan.Text,
                NoiDungCongViec = txtQTCTNoiDungCongViec.Text,
                SoQuyetDinh = txtQTCTSoQD.Text,
                DiaDiemCongTac = txtQTCTDiaDiemCT.Text,
                GHI_CHU = txtCongTacGhiChu.Text,
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
                PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfQTCTNguoiQuyetDinh.Text)
            };
            if (!Util.GetInstance().IsDateNull(dfQTCTNgayQuyetDinh.SelectedDate))
                qtcongTac.NgayQuyetDinh = dfQTCTNgayQuyetDinh.SelectedDate;
            if (!Util.GetInstance().IsDateNull(dfQTCTNgayBatDau.SelectedDate))
                qtcongTac.ThoiGianBatDau = dfQTCTNgayBatDau.SelectedDate;
            if (!Util.GetInstance().IsDateNull(dfQTCTNgayKetThuc.SelectedDate))
                qtcongTac.ThoiGianKetThuc = dfQTCTNgayKetThuc.SelectedDate;
            if (path != null && path != "")
                qtcongTac.TepTinDinhKem = path;
            else
                qtcongTac.TepTinDinhKem = hdfQTCTTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                qtcongTac.PR_KEY = decimal.Parse(RowSelectionModelQuaTrinhCongTac.SelectedRecordID);
                new HOSO_QT_CTACController().Update(qtcongTac);
                wdQuaTrinhCongTac.Hide();
            }
            else
            {
                new HOSO_QT_CTACController().InsertQuaTrinhCongTac(qtcongTac);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuaTrinhCongTac.Hide();
                }
                else
                {
                    GenerateQTCTSoQD();
                }
            }
            GridPanelQuaTrinhCTAC.Reload();
            RM.RegisterClientScriptBlock("ResetWdQuaTrinhCongTac", "ResetWdQuaTrinhCongTac();");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnQTCTDownload_Click(object sender, DirectEventArgs e)
    {
        if (hdf_PR_KEY.Text != "")
        {
            DownloadAttachFile("HOSO_QT_CTAC", hdfQTCTTepTinDinhKem);
        }
    }
    protected void btnQTCTDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdf_PR_KEY.Text != "")
        {
            DeleteTepTinDinhKem("HOSO_QT_CTAC", decimal.Parse(RowSelectionModelQuaTrinhCongTac.SelectedRecordID), hdfQTCTTepTinDinhKem);
            hdfQTCTTepTinDinhKem.Text = "";
            GridPanelQuaTrinhCTAC.Reload();
        }
    }
    protected void StoreQuaTrinhCongTac_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    { 
        StoreQuaTrinhCongTac.DataSource = new HOSO_QT_CTACController().GetByprKeyTuCapNhat(decimal.Parse(hdf_PR_KEY.Text));
        StoreQuaTrinhCongTac.DataBind();
    }
    [DirectMethod]
    public void GenerateQTCTSoQD()
    {
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_QT_CTAC", "SoQuyetDinh", "QĐ-CT");
        txtQTCTSoQD.Text = sohd;
    }
    protected void cbCongTacQuocGiaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbCongTacQuocGiaStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_NUOC,TEN_NUOC from DM_NUOC");
        cbCongTacQuocGiaStore.DataBind();
    }
     
    protected void btnUpdateQuaTrinhDC_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HoSoController hsController = new HoSoController();
            HOSO_QT_DIEUCHUYENController dcController = new HOSO_QT_DIEUCHUYENController();
            // upload file
            string path = string.Empty;
            if (fufQTDCTepTinDinhKem.HasFile)
            {
                string directory = Server.MapPath("");
                path = UploadFile(fufQTDCTepTinDinhKem, "File/QuaTrinhDieuChuyen");
            }
            DAL.HOSO_QT_DIEUCHUYEN dieuchuyen = new HOSO_QT_DIEUCHUYEN()
            {
                FR_KEY = -1,
                SoQuyetDinh = txtQTDCSoQuyetDinh.Text,
                MaBoPhanMoi = cbxQTDCBoPhanMoi.SelectedItem.Value,
                MaChucVuMoi = cbxQTDCChucVuMoi.SelectedItem.Value,
                MaCongViecMoi = cbxCongViecMoi.SelectedItem.Value,
                GhiChu = txtDieuChuyenGhiChu.Text,
                PrKeyHosoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
                PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfQTDCNguoiQuyetDinh.Text)
            };
            if (hdfQTDCNguoiQuyetDinh.Text != "")
                dieuchuyen.PrkeyNguoiQuyetDinh = decimal.Parse("0" + hdfQTDCNguoiQuyetDinh.Text);
            if (!dfQTDCNgayQuyetDinh.SelectedDate.ToString().Contains("0001"))
                dieuchuyen.NgayQuyetDinh = dfQTDCNgayQuyetDinh.SelectedDate;
            if (!dfQTDCNgayCoHieuLuc.SelectedDate.ToString().Contains("0001"))
                dieuchuyen.NgayCoHieuLuc = dfQTDCNgayCoHieuLuc.SelectedDate;
            if (!dfQTDCNgayHetHieuLuc.SelectedDate.ToString().Contains("0001"))
                dieuchuyen.NgayHetHieuLuc = dfQTDCNgayHetHieuLuc.SelectedDate;
            if (path != "")
                dieuchuyen.TepTinDinhKem = path;
            else
                dieuchuyen.TepTinDinhKem = hdfQTDCTepTinDinhKem.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                dieuchuyen.PR_KEY = decimal.Parse(RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID);
                dcController.Update(dieuchuyen);
                // cập nhật đơn vị cho hồ sơ nếu có sự thay đổi
                // cập nhật bộ phận mới
                if (cbxQTDCBoPhanMoi.SelectedItem != null && dieuchuyen.MaBoPhanCu != cbxQTDCBoPhanMoi.SelectedItem.Value)
                {
                    hsController.UpdateMaDonVi(dieuchuyen.FR_KEY, dieuchuyen.MaBoPhanMoi);
                }
                // cập nhật chức vụ mới
                if (cbxQTDCChucVuMoi.SelectedItem != null && dieuchuyen.MaChucVuCu != cbxQTDCChucVuMoi.SelectedItem.Value)
                {
                    hsController.UpdateMaChucVu(dieuchuyen.FR_KEY, dieuchuyen.MaChucVuMoi);
                }
                //cập nhật công việc mới
                if (cbxCongViecMoi.SelectedItem != null && dieuchuyen.MaCongViecCu != cbxCongViecMoi.SelectedItem.Value)
                {
                    hsController.UpdateMaCongViec(dieuchuyen.FR_KEY, dieuchuyen.MaCongViecMoi);
                }
                wdQuaTrinhDieuChuyen.Hide();
            }
            else
            {
                HOSO hs = hsController.GetByPrKey(dieuchuyen.FR_KEY);
                if (hs != null)
                {
                    dieuchuyen.MaBoPhanCu = hs.MA_DONVI;
                    dieuchuyen.MaChucVuCu = hs.MA_CHUCVU;
                    dieuchuyen.MaCongViecCu = hs.MA_CONGVIEC;
                }
                dcController.Insert(dieuchuyen);
                // cập nhật đơn vị cho HOSO
                hsController.UpdateMaDonVi(dieuchuyen.FR_KEY, dieuchuyen.MaBoPhanMoi);
                hsController.UpdateMaChucVu(dieuchuyen.FR_KEY, dieuchuyen.MaChucVuMoi);
                hsController.UpdateMaCongViec(dieuchuyen.FR_KEY, dieuchuyen.MaCongViecMoi);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdQuaTrinhDieuChuyen.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rs23", "ResetWdQuaTrinhDieuChuyen();");
                }
            }
            //grp_NhanSu_NhapHoSoNhanSu.CallScriptUsingResourceManager("#{StoreQuaTrinhDieuChuyen}.reload();");
            GridPanelQuaTrinhDieuChuyen.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    protected void btnQTDCDownload_Click(object sender, DirectEventArgs e)
    {
        if (hdf_PR_KEY.Text != "")
        {
            DownloadAttachFile("HOSO_QT_DIEUCHUYEN", hdfQTDCTepTinDinhKem);
        }
    }
    protected void btnQTDCDelete_Click(object sender, DirectEventArgs e)
    {
        if (hdf_PR_KEY.Text != "")
        {
            DeleteTepTinDinhKem("HOSO_QT_DIEUCHUYEN", decimal.Parse(RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID), hdfQTDCTepTinDinhKem);
            hdfQTDCTepTinDinhKem.Text = "";
            GridPanelQuaTrinhDieuChuyen.Reload();
        }
    }
    protected void StoreQuaTrinhDieuChuyen_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    { 
        StoreQuaTrinhDieuChuyen.DataSource = new HOSO_QT_DIEUCHUYENController().GetByPrKeyTuCapNhat(decimal.Parse(hdf_PR_KEY.Text));
        StoreQuaTrinhDieuChuyen.DataBind();
    }
    [DirectMethod]
    public void GenerateQTDCSoQD()
    {
        string sohd = new HoSoController().GenerateSoHopDong("HOSO_QT_DIEUCHUYEN", "SoQuyetDinh", "QĐ-ĐC");
        txtQTDCSoQuyetDinh.Text = sohd;
    }
    protected void cbxQTDCBoPhanMoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID("0");
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA = item.MA, TEN = item.TEN });
            LoadMenuCon(obj, item.MA, 1);
        }
        cbxQTDCBoPhanMoi_Store.DataSource = obj;
        cbxQTDCBoPhanMoi_Store.DataBind();
    }
    protected void cbxQTDCChucVuMoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbxQTDCChucVuMoi_Store.DataSource = new DanhMucChucVuController().GetAll();
            cbxQTDCChucVuMoi_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }

    // tai nan lao dong
    protected void btnUpdateTaiNan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.HOSO_TAINANLAODONG taiNan = new HOSO_TAINANLAODONG()
            {
                BOI_THUONG = TaiNan_txtBoiThuong.Text.Trim(),
                DIA_DIEM = TaiNan_txtDiaDiemXayRa.Text.Trim(),
                GHI_CHU = TaiNan_txtGhiChu.Text.Trim(),
                LY_DO = TaiNan_txtLydo.Text.Trim(),
                FR_KEY = -1,
                THIET_HAI = TaiNan_txtThietHai.Text.Trim(),
                THUONG_TAT = TaiNan_txtThuongTat.Text.Trim(),
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
            };
            if (!Util.GetInstance().IsDateNull(TaiNan_dfNgayXayRa.SelectedDate))
            {
                taiNan.NGAY_XAY_RA = TaiNan_dfNgayXayRa.SelectedDate;
            }
            if (!Util.GetInstance().IsDateNull(TaiNan_txtNgayBoiThuong.SelectedDate))
            {
                taiNan.NgayBoiThuong = TaiNan_txtNgayBoiThuong.SelectedDate;
            }
            if (e.ExtraParams["Command"] == "Update")
            {
                taiNan.ID = int.Parse(RowSelectionModelTaiNanLaoDong.SelectedRecordID);
                new TaiNanLaoDongController().Update(taiNan);
            }
            else
            {
                new HoSoController().InsertTaiNanLaoDong(taiNan);
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdTaiNanLaoDong.Hide();
            }
            RM.RegisterClientScriptBlock("ResetWdTaiNanLaoDong", "ResetWdTaiNanLaoDong()");
            GridPanelTaiNanLaoDong.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void StoreTaiNanLaoDong_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreTaiNanLaoDong.DataSource = DataHandler.GetInstance().ExecuteDataTable(
                                             @"select ID,LY_DO,NGAY_XAY_RA,DIA_DIEM,THIET_HAI,
                                              THUONG_TAT,BOI_THUONG,GHI_CHU,NgayBoiThuong 
                                              from HOSO_TAINANLAODONG where PrKeyHoSoTuCapNhat = " + hdf_PR_KEY.Text);
            StoreTaiNanLaoDong.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
      
    protected void btnUpdateAtachFile_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // upload file
            string path = string.Empty;
            if (file_cv.HasFile)
            {
                path = UploadFile(file_cv, "../HoSoNhanSu/File/TepTinDinhKem");
            }
            DAL.HOSO_TepTinDinhKem attach = new HOSO_TepTinDinhKem()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Duyet = false,
                FR_KEY = -1,
                GhiChu = txtGhiChu.Text,
                TenTepTin = txtFileName.Text,
                PrKeyHoSoTuCapNhat = decimal.Parse(hdf_PR_KEY.Text),
            };
            if (path != "")
            {
                attach.Link = path;
                HttpPostedFile file = file_cv.PostedFile;
                attach.SizeKB = file.ContentLength / 1024;
            }
            else
                attach.Link = hdfAttachFile.Text;
            if (e.ExtraParams["Command"] == "Update")
            {
                attach.PR_KEY = int.Parse(RowSelectionModelTepTinDinhKem.SelectedRecordID);
                new HOSO_TEPTINDINHKEMControllor().Update(attach);
                wdAttachFile.Hide();
            }
            else
            {
                new HoSoController().InsertTepTin(attach);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAttachFile.Hide();
                }
            }
            hdfTepTinDinhKem.Text = "changed";
            grpTepTinDinhKem.Reload();
            RM.RegisterClientScriptBlock("resetFormAttachFile", "resetAttachFile()"); 
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    #region Lấy dữ liệu cho combobox

    protected void cbx_chucvu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_chucvu_Store.DataSource = new DanhMucChucVuController().GetAll();
            cbx_chucvu_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }
    //protected void cbx_congtrinh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbx_congtrinh_Store.DataSource = new DM_CONGTRINHController().GetAll();
    //    cbx_congtrinh_Store.DataBind();
    //}
    protected void cbx_congviec_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_congviec_Store.DataSource = new DM_CONGVIECController().GetAll();
        cbx_congviec_Store.DataBind();
    }
    protected void cbx_tthonnhan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tthonnhan_Store.DataSource = new DM_TT_HNController().GetAll();
        cbx_tthonnhan_Store.DataBind();
    }

    protected void cbx_tpbanthan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tpbanthan_Store.DataSource = new DM_TP_BANTHANController().GetAll();
        cbx_tpbanthan_Store.DataBind();
    }

    protected void cbx_tpgiadinh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tpgiadinh_Store.DataSource = new DM_TP_GIADINHController().GetAll();
        cbx_tpgiadinh_Store.DataBind();
    }

    protected void cbx_quoctich_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_quoctich_Store.DataSource = new DM_NUOCController().GetAll();
        cbx_quoctich_Store.DataBind();
    }

    protected void cbx_dantoc_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_dantoc_Store.DataSource = new DM_DANTOCController().GetAll();
        cbx_dantoc_Store.DataBind();
    }

    protected void cbx_tongiao_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tongiao_Store.DataSource = new DM_TONGIAOController().GetAll();
        cbx_tongiao_Store.DataBind();
    }

    protected void cbx_tinhthanh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tinhthanh_Store.DataSource = new DM_TINHTHANHController().GetAll();
        cbx_tinhthanh_Store.DataBind();
    }

    protected void cbx_ttsuckhoe_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_ttsuckhoe_Store.DataSource = new DM_TT_SUCKHOEController().GetAll();
        cbx_ttsuckhoe_Store.DataBind();
    }

    //protected void cbx_truong_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbx_truong_Store.DataSource = new DM_TRUONG_DAOTAOController().GetAll1();
    //    cbx_truong_Store.DataBind();
    //}

    //protected void cbx_chuyennganh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbx_chuyennganh_Store.DataSource = new DM_CHUYENNGANHController().GetAll1();
    //    cbx_chuyennganh_Store.DataBind();
    //}

    protected void cbx_xeploai_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_xeploai_Store.DataSource = new DM_XEPLOAIController().GetAll1();
        cbx_xeploai_Store.DataBind();
    }

    protected void cbx_tinhoc_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tinhoc_Store.DataSource = new DM_TINHOCController().GetAll();
        cbx_tinhoc_Store.DataBind();
    }

    protected void cbx_ngoaingu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_ngoaingu_Store.DataSource = new DM_NGOAINGUController().GetAll();
        cbx_ngoaingu_Store.DataBind();
    }

    protected void cbx_trinhdo_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdo_Store.DataSource = new DM_TRINHDOController().GetAll1();
        cbx_trinhdo_Store.DataBind();
    }

    protected void cbx_tdvanhoa_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_tdvanhoa_Store.DataSource = new DM_TD_VANHOAController().GetAll();
        cbx_tdvanhoa_Store.DataBind();
    }

    protected void cbx_noicapbhxh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicapbhxh_Store.DataSource = new DM_NOICAPBAOHIEMXHController().GetAll();
        cbx_noicapbhxh_Store.DataBind();
    }

    protected void cbx_noikcb_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noikcb_Store.DataSource = new DM_NOI_KCBController().GetAll();
        cbx_noikcb_Store.DataBind();
    }

    protected void cbx_huongcs_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_huongcs_Store.DataSource = new DM_LOAI_CSController().GetAll();
        cbx_huongcs_Store.DataBind();
    }

    protected void cbx_noicapcmnd_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicapcmnd_Store.DataSource = new DM_NOICAP_CMNDController().GetAll();
        cbx_noicapcmnd_Store.DataBind();
    }

    protected void cbx_trinhdochinhtri_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdochinhtri_Store.DataSource = new DM_TD_CHINHTRIController().GetAll();
        cbx_trinhdochinhtri_Store.DataBind();
    }

    protected void cbx_chuvudang_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_chuvudang_Store.DataSource = new DM_CHUCVU_DANGController().GetAll();
        cbx_chuvudang_Store.DataBind();
    }

    protected void cbx_bacquandoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_bacquandoi_Store.DataSource = new DM_CAPBAC_QDOIController().GetAll();
        cbx_bacquandoi_Store.DataBind();
    }

    protected void cbx_chucvuquandoi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_chucvuquandoi_Store.DataSource = new DM_CHUCVU_QDOIController().GetAll();
        cbx_chucvuquandoi_Store.DataBind();
    }

    protected void cbx_chucvudoan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_chucvudoan_Store.DataSource = new DM_CHUCVU_DOANController().GetAll();
        cbx_chucvudoan_Store.DataBind();
    }

    protected void cbx_noicaphc_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_noicaphc_Store.DataSource = new DM_NOICAP_HOCHIEUController().GetAll();
        cbx_noicaphc_Store.DataBind();
    }

    protected void cbx_httuyen_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_httuyen_Store.DataSource = new DM_HT_TUYENDUNGController().GetAll();
        cbx_httuyen_Store.DataBind();
    }

    protected void cbx_ngach_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_ngach_Store.DataSource = new DM_NGACHController().GetAll1();
        cbx_ngach_Store.DataBind();
    }

    protected void cbx_trinhdoquanly_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdoquanly_Store.DataSource = new DM_TD_QUANLYController().GetAll();
        cbx_trinhdoquanly_Store.DataBind();
    }

    protected void cbx_trinhdoquanlykt_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdoquanlykt_Store.DataSource = new DM_TD_QLKTController().GetAll();
        cbx_trinhdoquanlykt_Store.DataBind();
    }

    protected void cbx_nganhang_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_nganhang_Store.DataSource = new DM_NGANHANGController().GetAll();
        cbx_nganhang_Store.DataBind();
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

    protected void cbx_ChuyenNganhBangCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_ChuyenNganhBangCapStore.DataSource = new DM_CHUYENNGANHController().GetAll();
            cbx_ChuyenNganhBangCapStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void cbx_NoiDaoTaoBangCapStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_NoiDaoTaoBangCapStore.DataSource = new DM_TRUONG_DAOTAOController().GetAll();
            cbx_NoiDaoTaoBangCapStore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    /// <summary>
    /// Xóa các bản ghi trên Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void HandleChangesDelete(object sender, BeforeStoreChangedEventArgs e)
    {
        string deleted = e.DataHandler.JsonData;
        string prkey = deleted.Remove(deleted.IndexOf(','));
        prkey = prkey.Substring(prkey.LastIndexOf(':') + 1);
        Ext.Net.Store store = sender as Ext.Net.Store;
        switch (store.ID)
        {
            case "StoreKinhNghiemLamViec":
                new KinhNghiemLamViecController().Delete(int.Parse(prkey));
                break; 
            case "StoreKhaNang":
                new KhaNangController().Delete(decimal.Parse(prkey));
                break;
            case "StoreQHGD":
                new QuanHeGiaDinhController().Delete(decimal.Parse(prkey));
                break;
            case "StoreTaiSan":
                new HOSO_TAISANController().Delete(decimal.Parse(prkey));
                break;
            case "Store_BangCapChungChi":
                new ChungChiController().Delete(int.Parse(RowSelectionModel_ChungChi.SelectedRecordID));
                break;
            case "StoreKhenThuong":
                DataHandler.GetInstance().ExecuteNonQuery("delete from HOSO_KHENTHUONG where PR_KEY = " + prkey);
                break;
            case "grpTepTinDinhKemStore":
                string linkFile = string.Empty;
                new HOSO_TEPTINDINHKEMControllor().Delete(int.Parse(RowSelectionModelTepTinDinhKem.SelectedRecordID), out linkFile);
                if (!string.IsNullOrEmpty(linkFile))
                {
                    FileInfo f = new FileInfo(linkFile);
                    if (f.Exists)
                    {
                        f.Delete();
                    }
                }
                break;
            case "Store_BangCap":
                new HOSO_BANGCAP_UNGVIENController().Delete(int.Parse(RowSelectionModel_BangCap.SelectedRecordID));
                break;
            case "StoreTaiNanLaoDong":
                new TaiNanLaoDongController().Delete(int.Parse(RowSelectionModelTaiNanLaoDong.SelectedRecordID));
                break;
            case "StoreQuaTrinhCongTac":
                new HOSO_QT_CTACController().Delete(decimal.Parse(RowSelectionModelQuaTrinhCongTac.SelectedRecordID));
                break;
            case "StoreQuaTrinhDieuChuyen":
                new HOSO_QT_DIEUCHUYENController().Delete(decimal.Parse(RowSelectionModelQuaTrinhDieuChuyen.SelectedRecordID));
                break;
        }
        btnEditRecord.Disabled = true;
        btnDeleteRecord.Disabled = true;
    }
}