using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using DataController;
using DAL;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using SoftCore;
using SoftCore.AccessHistory;
using System.Data.SqlClient;


/// <summary>
/// Summary description for KEHOACH_TUYENDUNGController
/// </summary>
public class HoSoUngVienController : LinqProvider
{

    public DataTable GetALL(int start, int limit, string searchKey, out int count)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("tuyendung_CountdanhsachUV", "@searchKey", searchKey).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("tuyendung_danhsachUV", "@start", "@limit", "@searchKey", start, limit, searchKey);
    }
    public DAL.HoSoUngVien GetByCMDN(string cmdn, int maungvien)
    {
        return (from t in dataContext.HoSoUngViens
                where t.SoCMT == cmdn && t.MaUngVien != maungvien
                select t).FirstOrDefault();
    }

    public void Insert(DAL.HoSoUngVien hosoungvien)
    {
        if (hosoungvien != null)
        {
            dataContext.HoSoUngViens.InsertOnSubmit(hosoungvien);
            Save();
        }
    }

    public void Update(DAL.HoSoUngVien hosoungvien)
    {
        DAL.HoSoUngVien temp = dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == hosoungvien.MaUngVien);
        if (temp != null)
        {
            temp.Anh = hosoungvien.Anh;
            temp.BlackListOrStore = hosoungvien.BlackListOrStore;
            temp.CanNang = hosoungvien.CanNang;
            temp.ChieuCao = hosoungvien.ChieuCao;
            temp.DaTrungTuyen = hosoungvien.DaTrungTuyen;
            temp.DiaChiLienHe = hosoungvien.DiaChiLienHe;
            temp.DiDong = hosoungvien.DiDong;
            temp.DTCoDinh = hosoungvien.DTCoDinh;
            temp.Email = hosoungvien.Email;
            temp.GhiChu = hosoungvien.GhiChu;
            temp.GioiTinh = hosoungvien.GioiTinh;
            temp.HinhThucLamViec = hosoungvien.HinhThucLamViec;
            temp.HoDem = hosoungvien.HoDem;
            temp.HoKhauThuongTru = hosoungvien.HoKhauThuongTru;
            temp.KinhNghiem = hosoungvien.KinhNghiem;
            temp.MaDanToc = hosoungvien.MaDanToc;
            temp.MaDotTuyenDung = hosoungvien.MaDotTuyenDung;
            temp.MaLyDo = hosoungvien.MaLyDo;
            temp.MaNoiCapHoChieu = hosoungvien.MaNoiCapHoChieu;
            temp.MaNguonTuyenDung = hosoungvien.MaNguonTuyenDung;
            temp.MaQuocTich = hosoungvien.MaQuocTich;
            temp.MaTinhThanh = hosoungvien.MaTinhThanh;
            temp.MaTinhTrangHonNhan = hosoungvien.MaTinhTrangHonNhan;
            temp.MaTinhTrangSucKhoe = hosoungvien.MaTinhTrangSucKhoe;
            temp.MaTonGiao = hosoungvien.MaTonGiao;
            temp.MaTrinhDoHocVan = hosoungvien.MaTrinhDoHocVan;
            temp.MaTruongDaoTao = hosoungvien.MaTruongDaoTao;
            temp.MaChuyenNganh = hosoungvien.MaChuyenNganh;
            temp.MaTrinhDoNgoaiNgu = hosoungvien.MaTrinhDoNgoaiNgu;
            temp.MaTrinhDoTinHoc = hosoungvien.MaTrinhDoTinHoc;
            temp.MaTrinhDoVH = hosoungvien.MaTrinhDoVH;
            temp.MaUngVien = hosoungvien.MaUngVien;
            temp.MaViTriCongViec = hosoungvien.MaViTriCongViec;
            temp.MucLuongMongMuon = hosoungvien.MucLuongMongMuon;
            temp.MucLuongToiThieu = hosoungvien.MucLuongToiThieu;
            temp.NoiCapCMT = hosoungvien.NoiCapCMT;
            temp.NoiSinh = hosoungvien.NoiSinh;
            temp.NgayCapCMT = hosoungvien.NgayCapCMT;
            temp.NgayCapHoChieu = hosoungvien.NgayCapHoChieu;
            temp.NgayCoTheDiLam = hosoungvien.NgayCoTheDiLam;
            temp.NgayHetHanHoChieu = hosoungvien.NgayHetHanHoChieu;
            temp.NgayNopHS = hosoungvien.NgayNopHS;
            temp.NgaySinh = hosoungvien.NgaySinh;
            temp.NhomMau = hosoungvien.NhomMau;
            temp.NhuocDiem = hosoungvien.NhuocDiem;
            temp.SoCMT = hosoungvien.SoCMT;
            temp.SoHoChieu = hosoungvien.SoHoChieu;
            temp.SoThich = hosoungvien.SoThich;
            temp.Ten = hosoungvien.Ten;
            temp.UuDiem = hosoungvien.UuDiem;
            temp.HoTen = hosoungvien.HoTen;
            temp.NhomMau = hosoungvien.NhomMau;
            temp.ChieuCao = hosoungvien.ChieuCao;
            temp.CanNang = hosoungvien.CanNang;
            temp.MaKhaNang = hosoungvien.MaKhaNang;
            temp.NguoiLienHeTrongTruongHopKhanCap = hosoungvien.NguoiLienHeTrongTruongHopKhanCap;
            temp.QuanHeVoiUngVien = hosoungvien.QuanHeVoiUngVien;
            temp.EmailNguoiLienHe = hosoungvien.EmailNguoiLienHe;
            temp.DienThoaiNguoiLienHe = hosoungvien.DienThoaiNguoiLienHe;
            temp.DiaChiNguoiLienHe = hosoungvien.DiaChiNguoiLienHe;
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.HoSoUngVien temp = dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == id);
        if (temp != null)
        {
            dataContext.HoSoUngViens.DeleteOnSubmit(temp);
            Save();
        }
    }
    public void ChuyenDanhSach(DAL.HoSoUngVien hosoungvien, bool datrungtuyen)
    {
        DAL.HoSoUngVien temp = dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == hosoungvien.MaUngVien);
        if (temp != null)
        {
            temp.MaUngVien = hosoungvien.MaUngVien;
            temp.DaTrungTuyen = hosoungvien.DaTrungTuyen;
            temp.BlackListOrStore = hosoungvien.BlackListOrStore;
            temp.XacNhanDiLam = hosoungvien.XacNhanDiLam;
            if (datrungtuyen == false)
            {
                temp.MaLyDo = hosoungvien.MaLyDo;
                temp.GhiChu = hosoungvien.GhiChu;
            }
            Save();
        }
    }
    public int? GetMaDotTuyenDungByID(decimal id)
    {
        return dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == id).MaDotTuyenDung;
    }
    public void XacNhanDiLam(DAL.HoSoUngVien hosoungvien)
    {
        DAL.HoSoUngVien temp = dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == hosoungvien.MaUngVien);
        if (temp != null)
        {
            temp.XacNhanDiLam = hosoungvien.XacNhanDiLam;
            Save();
        }
    }

    public void CopyToHoSo(decimal MaUngVien, string maDV, int planID, DateTime ngayThuViec, string newMaCB)
    {
        try
        {
            DAL.HOSO hs = new DAL.HOSO();
            DAL.HoSoUngVien hsuv = dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == MaUngVien);
            DAL.KeHoachTuyenDung khtd = dataContext.KeHoachTuyenDungs.SingleOrDefault(t => t.ID == planID);
            //Insert bảng HOSO
            hs.MA_CB = newMaCB;
            hs.CAN_NANG = decimal.Parse("0" + hsuv.CanNang);
            hs.CHIEU_CAO = decimal.Parse("0" + hsuv.ChieuCao);
            hs.DI_DONG = hsuv.DiDong;
            hs.DIA_CHI_LH = hsuv.DiaChiLienHe;
            hs.DiaChiNguoiLienHe = hsuv.DiaChiNguoiLienHe;
            hs.EMAIL = hsuv.Email;
            hs.DT_NHA = hsuv.DTCoDinh;
            hs.EmailNguoiLienHe = hsuv.EmailNguoiLienHe;
            hs.HO_CB = hsuv.HoDem;
            hs.HO_KHAU = hsuv.HoKhauThuongTru;
            hs.HO_TEN = hsuv.HoTen;
            hs.MA_CHUYENNGANH = hsuv.MaChuyenNganh;
            hs.MA_CONGVIEC = hsuv.MaViTriCongViec;
            hs.MA_CHUCVU = khtd.MaChucVu;
            hs.MA_DANTOC = hsuv.MaDanToc;
            hs.MA_DONVI = khtd.MA_DONVI;
            hs.MA_GIOITINH = hsuv.GioiTinh;
            hs.MA_HT_TUYENDUNG = hsuv.HinhThucTuyenDung;
            hs.MA_NGOAINGU = hsuv.MaTrinhDoNgoaiNgu;
            hs.MA_NOICAP_CMND = hsuv.NoiCapCMT;
            hs.MA_NOICAP_HOCHIEU = hsuv.MaNoiCapHoChieu;
            hs.MA_NUOC = hsuv.MaQuocTich;
            hs.MA_TD_VANHOA = hsuv.MaTrinhDoVH;
            hs.MA_TINHOC = hsuv.MaTrinhDoTinHoc;
            hs.MA_TINHTHANH = hsuv.MaTinhThanh;
            hs.MA_TONGIAO = hsuv.MaTonGiao;
            hs.MA_TRINHDO = hsuv.MaTrinhDoHocVan;
            hs.MA_TRUONG_DAOTAO = hsuv.MaTruongDaoTao;
            hs.MA_TT_HN = hsuv.MaTinhTrangHonNhan;
            hs.MA_TT_SUCKHOE = hsuv.MaTinhTrangSucKhoe;
            hs.NHOM_MAU = hsuv.NhomMau;
            hs.UU_DIEM = hsuv.UuDiem;
            hs.TEN_CB = hsuv.Ten;
            hs.SO_THICH = hsuv.SoThich;
            hs.SO_HOCHIEU = hsuv.SoHoChieu;
            hs.SO_CMND = hsuv.SoCMT;
            hs.SDTNguoiLienHe = hsuv.DienThoaiNguoiLienHe;
            hs.QueQuan = hsuv.NoiSinh;
            hs.QuanHeVoiCanBo = hsuv.QuanHeVoiUngVien;
            hs.PHOTO = hsuv.Anh;
            hs.NOI_SINH = hsuv.NoiSinh;
            hs.NHUOC_DIEM = hsuv.NhuocDiem;
            hs.NguoiLienHe = hsuv.NguoiLienHeTrongTruongHopKhanCap;
            hs.NGAY_SINH = hsuv.NgaySinh;
            hs.NGAY_TUYEN_DTIEN = ngayThuViec;
            hs.NGAYCAP_CMND = hsuv.NgayCapCMT;
            hs.NGAYCAP_HOCHIEU = hsuv.NgayCapHoChieu;
            hs.DATE_CREATE = DateTime.Now;
            hs.NgayDuyet = DateTime.Now;
            hs.HinhThucLamViec = int.Parse("0" + hsuv.HinhThucLamViec);
            dataContext.HOSOs.InsertOnSubmit(hs);
            hsuv.BlackListOrStore = "DaChuyenSangBangHOSO";
            hsuv.DaTrungTuyen = false;
            Save();

            //Insert bảng HOSO_TUYENDUNG
            DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_InsertHOSO_TUYENDUNGFromHoSoUngVien", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);

            //Insert bảng HOSO_UNGVIEN_CHUNGCHI(insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra nếu ứng viên có chứng chỉ thì mới insert
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT ID FROM TuyenDung.BangCapChungChi bccc WHERE bccc.FR_KEY = '" + MaUngVien + "'");

            if (dt.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyChungChiUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Insert bảng HOSO_UNGVIEN_KINHNGHIEMLAMVIEC (insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra nếu ứng viên có kinh nghiệm thì mới insert
            DataTable dt1 = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.KinhNghiemLamViec knlv WHERE knlv.FR_KEY = '" + MaUngVien + "'");
            if (dt1.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyKinhNghiemLamViecUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Insert bảng HOSO_TepTinDinhKem (insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra ứng viên có tệp tin đính kèm mới insert
            DataTable dt2 = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.TepTinDinhKem ttdk WHERE ttdk.FR_KEY = '" + MaUngVien + "'");
            if (dt2.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyTepTinUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Insert bảng HOSO_BANGCAP_UNGVIEN (insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra nếu ứng viên có bằng cấp thì mới insert
            DataTable dt3 = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.BangCapUngVien bcuv WHERE bcuv.FR_KEY ='" + MaUngVien + "'");
            if (dt3.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyBangCapUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Update trạng thái của ứng viên trong bảng HoSoUngVien
            DataController.DataHandler.GetInstance().ExecuteNonQuery("UPDATE TuyenDung.HoSoUngVien SET BlackListOrStore = N'DaChuyenSangBangHOSO' WHERE MaUngVien = " + int.Parse("0" + MaUngVien.ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
            //  Dialog.ShowError(ex.Message);
        }
    }
    public void CopyToHoSo(decimal MaUngVien, string maDV, int planID, DateTime ngayThuViec, string newMaCB, string maDonViKyHopDong, string maDiaDiemLamViec)
    {
        try
        {
            DAL.HOSO hs = new DAL.HOSO();
            DAL.HoSoUngVien hsuv = dataContext.HoSoUngViens.SingleOrDefault(t => t.MaUngVien == MaUngVien);
            DAL.KeHoachTuyenDung khtd = dataContext.KeHoachTuyenDungs.SingleOrDefault(t => t.ID == planID);
            //Insert bảng HOSO
            hs.BI_DANH = maDiaDiemLamViec;
            hs.MA_HT_TUYENDUNG = maDonViKyHopDong;
            hs.MA_CB = newMaCB;
            hs.CAN_NANG = decimal.Parse("0" + hsuv.CanNang);
            hs.CHIEU_CAO = decimal.Parse("0" + hsuv.ChieuCao);
            hs.DI_DONG = hsuv.DiDong;
            hs.DIA_CHI_LH = hsuv.DiaChiLienHe;
            hs.DiaChiNguoiLienHe = hsuv.DiaChiNguoiLienHe;
            hs.EMAIL = hsuv.Email;
            hs.DT_NHA = hsuv.DTCoDinh;
            hs.EmailNguoiLienHe = hsuv.EmailNguoiLienHe;
            hs.HO_CB = hsuv.HoDem;
            hs.HO_KHAU = hsuv.HoKhauThuongTru;
            hs.HO_TEN = hsuv.HoTen;
            hs.MA_CHUYENNGANH = hsuv.MaChuyenNganh;
            hs.MA_CONGVIEC = hsuv.MaViTriCongViec;
            hs.MA_CHUCVU = khtd.MaChucVu;
            hs.MA_DANTOC = hsuv.MaDanToc;
            hs.MA_DONVI = khtd.MA_DONVI;
            hs.MA_GIOITINH = hsuv.GioiTinh;
            //hs.MA_HT_TUYENDUNG = hsuv.HinhThucTuyenDung;
            hs.MA_NGOAINGU = hsuv.MaTrinhDoNgoaiNgu;
            hs.MA_NOICAP_CMND = hsuv.NoiCapCMT;
            hs.MA_NOICAP_HOCHIEU = hsuv.MaNoiCapHoChieu;
            hs.MA_NUOC = hsuv.MaQuocTich;
            hs.MA_TD_VANHOA = hsuv.MaTrinhDoVH;
            hs.MA_TINHOC = hsuv.MaTrinhDoTinHoc;
            hs.MA_TINHTHANH = hsuv.MaTinhThanh;
            hs.MA_TONGIAO = hsuv.MaTonGiao;
            hs.MA_TRINHDO = hsuv.MaTrinhDoHocVan;
            hs.MA_TRUONG_DAOTAO = hsuv.MaTruongDaoTao;
            hs.MA_TT_HN = hsuv.MaTinhTrangHonNhan;
            hs.MA_TT_SUCKHOE = hsuv.MaTinhTrangSucKhoe;
            hs.NHOM_MAU = hsuv.NhomMau;
            hs.UU_DIEM = hsuv.UuDiem;
            hs.TEN_CB = hsuv.Ten;
            hs.SO_THICH = hsuv.SoThich;
            hs.SO_HOCHIEU = hsuv.SoHoChieu;
            hs.SO_CMND = hsuv.SoCMT;
            hs.SDTNguoiLienHe = hsuv.DienThoaiNguoiLienHe;
            hs.QueQuan = hsuv.NoiSinh;
            hs.QuanHeVoiCanBo = hsuv.QuanHeVoiUngVien;
            hs.PHOTO = hsuv.Anh;
            hs.NOI_SINH = hsuv.NoiSinh;
            hs.NHUOC_DIEM = hsuv.NhuocDiem;
            hs.NguoiLienHe = hsuv.NguoiLienHeTrongTruongHopKhanCap;
            hs.NGAY_SINH = hsuv.NgaySinh;
            hs.NGAY_TUYEN_DTIEN = ngayThuViec;
            hs.NGAYCAP_CMND = hsuv.NgayCapCMT;
            hs.NGAYCAP_HOCHIEU = hsuv.NgayCapHoChieu;
            hs.DATE_CREATE = DateTime.Now;
            hs.NgayDuyet = DateTime.Now;
            hs.HinhThucLamViec = int.Parse("0" + hsuv.HinhThucLamViec);
            dataContext.HOSOs.InsertOnSubmit(hs);
            hsuv.BlackListOrStore = "DaChuyenSangBangHOSO";
            Save();

            //Insert bảng HOSO_TUYENDUNG
            DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_InsertHOSO_TUYENDUNGFromHoSoUngVien", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);

            //Insert bảng HOSO_UNGVIEN_CHUNGCHI(insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra nếu ứng viên có chứng chỉ thì mới insert
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT ID FROM TuyenDung.BangCapChungChi bccc WHERE bccc.FR_KEY = '" + MaUngVien + "'");

            if (dt.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyChungChiUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Insert bảng HOSO_UNGVIEN_KINHNGHIEMLAMVIEC (insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra nếu ứng viên có kinh nghiệm thì mới insert
            DataTable dt1 = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.KinhNghiemLamViec knlv WHERE knlv.FR_KEY = '" + MaUngVien + "'");
            if (dt1.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyKinhNghiemLamViecUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Insert bảng HOSO_TepTinDinhKem (insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra ứng viên có tệp tin đính kèm mới insert
            DataTable dt2 = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.TepTinDinhKem ttdk WHERE ttdk.FR_KEY = '" + MaUngVien + "'");
            if (dt2.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyTepTinUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            //Insert bảng HOSO_BANGCAP_UNGVIEN (insert xong thì delete dữ liệu liên quan của ứng viên trong bảng luôn)
            //Kiểm tra nếu ứng viên có bằng cấp thì mới insert
            DataTable dt3 = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.BangCapUngVien bcuv WHERE bcuv.FR_KEY ='" + MaUngVien + "'");
            if (dt3.Rows.Count > 0)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_CopyBangCapUngVienToHOSO", "@MaUngVien", "@MaCB", MaUngVien, newMaCB);
            }

            ////Update trạng thái của ứng viên trong bảng HoSoUngVien
            //DataController.DataHandler.GetInstance().ExecuteNonQuery("UPDATE TuyenDung.HoSoUngVien SET BlackListOrStore = N'DaChuyenSangBangHOSO' WHERE MaUngVien = " + int.Parse("0" + MaUngVien.ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
            //  Dialog.ShowError(ex.Message);
        }
    }
}