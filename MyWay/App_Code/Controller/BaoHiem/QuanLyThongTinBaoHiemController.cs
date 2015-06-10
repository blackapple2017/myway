using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for QuanLyThongTinBaoHiemController
/// </summary>
public class QuanLyThongTinBaoHiemController : LinqProvider
{
    public QuanLyThongTinBaoHiemController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<ThongTinNhanVienBaoHiemInfo> GetNhanVienBaoHiem(string madonvi, int start, int limit, string searchkey, out int count)
    {
        var cm = new CommonUtil();
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        #region Đăng ký trong tháng
        List<ThongTinNhanVienBaoHiemInfo> rs1 = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                                 join q in dataContext.HOSOs on t.IDNhanVien_BaoHiem equals q.PR_KEY into q1
                                                 from q2 in q1.DefaultIfEmpty()
                                                 join x in dataContext.DM_DONVIs on q2.MA_DONVI equals x.MA_DONVI into x1
                                                 from x2 in x1.DefaultIfEmpty()
                                                 join dm in dataContext.DM_NOICAP_BHXHs on t.NoiCapSoBHXH equals dm.MA_NOICAP_BHXH into dm1
                                                 from dmnc in dm1.DefaultIfEmpty()
                                                 where (string.IsNullOrEmpty(madonvi) || s1.Contains(q2.MA_DONVI))
                                                        && (string.IsNullOrEmpty(searchkey) || (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                                                                || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)
                                                                                                || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoSoBHXH, searchkey)
                                                                                                || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoTheBHYT, searchkey)))
                                                         && (t.NgayDangKyBHXH.Value.Month == DateTime.Now.Month && t.NgayDangKyBHXH.Value.Year == DateTime.Now.Year)
                                                         && (t.DaNghi == false)
                                                 select new ThongTinNhanVienBaoHiemInfo
                                                 {
                                                     MaNhanVien = t.MaNhanVien,
                                                     HoTen = t.HoTen,
                                                     HoDem = cm.GetLastNameFromFullName(t.HoTen),
                                                     Ten = cm.GetFirstNamFromFullName(t.HoTen),
                                                     PhongBan = x2.TEN_DONVI,
                                                     LuongBaoHiem = t.LuongBaoHiem,
                                                     PhuCapCV = t.PhuCapCV,
                                                     PhuCapVuotKhung = t.PhuCapTNVK,
                                                     PhuCapKhac = t.PhuCapKhac,
                                                     PhuCapNghe = t.PhuCapTNN,
                                                     NgayDangKyBHXH = t.NgayDangKyBHXH,
                                                     SoSoBHXH = t.SoSoBHXH,
                                                     ThoiGianDongBaoHiem = t.ThoiGianDongBaoHiem,
                                                     DangDongBHXH = t.DangDongBHXH,
                                                     DangDongBHYT = t.DangDongBHYT,
                                                     DangDongBHTN = t.DangDongBHTN,
                                                     SoTheBHYT = t.SoTheBHYT,
                                                     TuThangBHYT = t.TuThangBHYT,
                                                     DenThangBHYT = t.DenThangBHYT,
                                                     BHXHTrangThaiDangKyCQBH = t.BHXHTrangThaiDangKyCQBH,
                                                     TrangThai = "1.Thêm mới trong tháng " + "(" + DateTime.Now.ToString("MM/yyyy") + ")",
                                                     NoiCapBHXH = dmnc.TEN_NOICAP_BHXH == null ? t.NoiCapSoBHXH : dmnc.TEN_NOICAP_BHXH,
                                                 }
                                       ).ToList();
        #endregion
        #region Thay đổi thông tin
        List<ThongTinNhanVienBaoHiemInfo> rs2 = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                                 join q in dataContext.HOSOs on t.IDNhanVien_BaoHiem equals q.PR_KEY into q1
                                                 from q2 in q1.DefaultIfEmpty()
                                                 join x in dataContext.DM_DONVIs on q2.MA_DONVI equals x.MA_DONVI into x1
                                                 from x2 in x1.DefaultIfEmpty()
                                                 join dm in dataContext.DM_NOICAP_BHXHs on t.NoiCapSoBHXH equals dm.MA_NOICAP_BHXH into dm1
                                                 from dmnc in dm1.DefaultIfEmpty()
                                                 where (string.IsNullOrEmpty(madonvi) || s1.Contains(q2.MA_DONVI))
                                                 && (t.DaNghi == false)
                                                        && (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)
                                                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoSoBHXH, searchkey)
                                                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoTheBHYT, searchkey)))
                                                        && (t.HoTen != q2.HO_TEN.ToString() || t.NgaySinh != q2.NGAY_SINH || t.GioiTinh != (q2.MA_GIOITINH != "F") ||
                                                           t.SoCMTND != q2.SO_CMND.ToString() || t.NgayCapCMTND != q2.NGAYCAP_CMND || t.NoiCapCMTND != q2.MA_NOICAP_CMND.ToString() ||
                                                           t.DiaChiLienHe != q2.DIA_CHI_LH.ToString() || t.NoiDangKyKCB != q2.MA_NOI_KCB)
                                                 select new ThongTinNhanVienBaoHiemInfo
                                                 {
                                                     MaNhanVien = t.MaNhanVien,
                                                     HoTen = t.HoTen,
                                                     HoDem = cm.GetLastNameFromFullName(t.HoTen),
                                                     Ten = cm.GetFirstNamFromFullName(t.HoTen),
                                                     PhongBan = x2.TEN_DONVI,
                                                     LuongBaoHiem = t.LuongBaoHiem,
                                                     PhuCapCV = t.PhuCapCV,
                                                     PhuCapVuotKhung = t.PhuCapTNVK,
                                                     PhuCapKhac = t.PhuCapKhac,
                                                     PhuCapNghe = t.PhuCapTNN,
                                                     NgayDangKyBHXH = t.NgayDangKyBHXH,
                                                     SoSoBHXH = t.SoSoBHXH,
                                                     ThoiGianDongBaoHiem = t.ThoiGianDongBaoHiem,
                                                     DangDongBHXH = t.DangDongBHXH,
                                                     DangDongBHYT = t.DangDongBHYT,
                                                     DangDongBHTN = t.DangDongBHTN,
                                                     SoTheBHYT = t.SoTheBHYT,
                                                     TuThangBHYT = t.TuThangBHYT,
                                                     DenThangBHYT = t.DenThangBHYT,
                                                     BHXHTrangThaiDangKyCQBH = t.BHXHTrangThaiDangKyCQBH,
                                                     NoiCapBHXH = dmnc.TEN_NOICAP_BHXH == null ? t.NoiCapSoBHXH : dmnc.TEN_NOICAP_BHXH,
                                                     TrangThai = "2.Thay đổi thông tin"
                                                 }).ToList();
        #endregion
        #region Không thay đổi thông tin
        List<ThongTinNhanVienBaoHiemInfo> rs3 = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                                 join q in dataContext.HOSOs on t.IDNhanVien_BaoHiem equals q.PR_KEY into q1
                                                 from q2 in q1.DefaultIfEmpty()
                                                 join x in dataContext.DM_DONVIs on q2.MA_DONVI equals x.MA_DONVI into x1
                                                 from x2 in x1.DefaultIfEmpty()
                                                 join dm in dataContext.DM_NOICAP_BHXHs on t.NoiCapSoBHXH equals dm.MA_NOICAP_BHXH into dm1
                                                 from dmnc in dm1.DefaultIfEmpty()
                                                 where (string.IsNullOrEmpty(madonvi) || s1.Contains(q2.MA_DONVI))
                                                        && (string.IsNullOrEmpty(searchkey)
                                                        || (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                        || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)
                                                        || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoSoBHXH, searchkey)
                                                        || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoTheBHYT, searchkey)))
                                                     //&& (!(((from y in rs1 select y.MaNhanVien).Union(from z in rs2 select z.MaNhanVien)).ToList().Contains(t.MaNhanVien)))
                                                        && (!((from y in rs1 select y.MaNhanVien).ToList().Contains(t.MaNhanVien) || (from y in rs2 select y.MaNhanVien).ToList().Contains(t.MaNhanVien)))
                                                 //   && (t.DaNghi == null || t.DaNghi == false)
                                                 select new ThongTinNhanVienBaoHiemInfo
                                                 {
                                                     MaNhanVien = t.MaNhanVien,
                                                     HoTen = t.HoTen,
                                                     HoDem = cm.GetLastNameFromFullName(t.HoTen),
                                                     Ten = cm.GetFirstNamFromFullName(t.HoTen),
                                                     PhongBan = x2.TEN_DONVI,
                                                     LuongBaoHiem = t.LuongBaoHiem,
                                                     PhuCapCV = t.PhuCapCV,
                                                     PhuCapVuotKhung = t.PhuCapTNVK,
                                                     PhuCapKhac = t.PhuCapKhac,
                                                     PhuCapNghe = t.PhuCapTNN,
                                                     NgayDangKyBHXH = t.NgayDangKyBHXH,
                                                     SoSoBHXH = t.SoSoBHXH,
                                                     ThoiGianDongBaoHiem = t.ThoiGianDongBaoHiem,
                                                     DangDongBHXH = t.DangDongBHXH,
                                                     DangDongBHYT = t.DangDongBHYT,
                                                     DangDongBHTN = t.DangDongBHTN,
                                                     SoTheBHYT = t.SoTheBHYT,
                                                     TuThangBHYT = t.TuThangBHYT,
                                                     DenThangBHYT = t.DenThangBHYT,
                                                     BHXHTrangThaiDangKyCQBH = t.BHXHTrangThaiDangKyCQBH,
                                                     NoiCapBHXH = dmnc.TEN_NOICAP_BHXH == null ? t.NoiCapSoBHXH : dmnc.TEN_NOICAP_BHXH,
                                                     TrangThai = t.DaNghi ? "4.Đã nghỉ" : "3.Không thay đổi thông tin"
                                                 }).ToList();
        #endregion
        var rs = (rs1.Concat(rs2.Concat(rs3))).ToList();
        rs = (from t in rs
              orderby t.TrangThai, t.Ten, t.HoDem
              select t
                ).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();

    }

    public void GetHoSoHopDong(decimal idNhanVien, out bool bhxh, out bool bhyt, out bool bhtn, out string tenloaihdong)
    {
        bhxh = false;
        bhyt = false;
        bhtn = false;
        tenloaihdong = "";
        HOSO_HOPDONG hh = new HOSO_HOPDONGController().GetHoSoHopDongById(idNhanVien);
        if (hh != null)
        {
            DataTable a = DataController.DataHandler.GetInstance().ExecuteDataTable(String.Format("SELECT BHXH,BHYT,BHTN FROM DM_LOAI_HDONG WHERE MA_LOAI_HDONG='{0}'", hh.MA_LOAI_HDONG));
            if (a.Rows.Count > 0)
            {
                bhxh = bool.Parse(a.Rows[0]["BHXH"].ToString());
                bhyt = bool.Parse(a.Rows[0]["BHYT"].ToString());
                bhtn = bool.Parse(a.Rows[0]["BHTN"].ToString());
            }
        }
        if (hh != null)
        {
            tenloaihdong = new DM_LOAI_HDONGController().GetByID(hh.MA_LOAI_HDONG).TEN_LOAI_HDONG;
        }
    }

    public void LuuNhanVienDongMoi(BHNHANVIEN_BAOHIEM nvbh)
    {
        BHNHANVIEN_BAOHIEM nv = new BHNHANVIEN_BAOHIEM();
        nv = nvbh;
        dataContext.BHNHANVIEN_BAOHIEMs.InsertOnSubmit(nv);
        dataContext.SubmitChanges();
        //Lưu biến động bảo hiểm
        DAL.BHBIENDONGBAOHIEM bdbh = new DAL.BHBIENDONGBAOHIEM();
        bdbh.IDQuyDinhBienDong = dataContext.BHQUYDINHBIENDONGs.SingleOrDefault(p => p.MaBienDong == "TDMBH").IDQuyDinhBienDong;
        bdbh.IDNhanVien_BaoHiem = nvbh.IDNhanVien_BaoHiem;
        bdbh.TuNgay = nv.NgayDangKyBHXH == null ? DateTime.Now : nv.NgayDangKyBHXH.Value;
        bdbh.Loai = dataContext.BHQUYDINHBIENDONGs.SingleOrDefault(p => p.MaBienDong == "TDMBH").LoaiAnhHuong;
        bdbh.MaNhanVien = nvbh.MaNhanVien;
        bdbh.HoTen = nvbh.HoTen;
        bdbh.MaSo = nvbh.SoSoBHXH;
        bdbh.NgaySinh = nvbh.NgaySinh;
        bdbh.GioiTinh = nvbh.GioiTinh ?? true;
        bdbh.ChucVu = "";
        if (dataContext.DM_CHUCVUs.SingleOrDefault(p => p.MA_CHUCVU == nvbh.MaChucVu) != null)
        {
            var singleOrDefault = dataContext.DM_CHUCVUs.SingleOrDefault(p => p.MA_CHUCVU == nvbh.MaChucVu);
            if (singleOrDefault != null)
                bdbh.ChucVu = singleOrDefault.TEN_CHUCVU;
        }
        bdbh.TienLuongMoi = nvbh.LuongBaoHiem;
        bdbh.PhuCapCVMoi = nvbh.PhuCapCV;
        bdbh.PhuCapTNNgheMoi = nvbh.PhuCapTNN;
        bdbh.PhuCapTNVKMoi = nvbh.PhuCapTNVK;
        bdbh.ThangDangKy = nvbh.NgayDangKyBHXH ?? DateTime.Now;
        bdbh.DaCoSo = string.IsNullOrEmpty(nvbh.SoSoBHXH) ? bdbh.DaCoSo = false : bdbh.DaCoSo = true;
        bdbh.DaDuyet = true;
        bdbh.UserID = nvbh.UserID;
        bdbh.DateCreate = DateTime.Now;
        bdbh.MaDonVi = nvbh.MaDonVi;
        bdbh.DienGiai = "";
        dataContext.BHBIENDONGBAOHIEMs.InsertOnSubmit(bdbh);
        dataContext.SubmitChanges();
    }
    public decimal? GetLuongDongBaoHiem(decimal prkeyhoso)
    {
        var ngayhieuluc = (from t in dataContext.HOSO_LUONGs
                           where t.NgayHieuLuc <= DateTime.Now && t.PrKeyHoSo == prkeyhoso
                           select t).ToList();
        if (ngayhieuluc.Count < 1) return 0;
        DateTime NgayHieuLucMax = ngayhieuluc.Max(p => p.NgayHieuLuc);
        //if(ngayhieuluc.Count<1) return 0;
        //DateTime NgayHieuLucMax=new DateTime(1992,1,1);
        //foreach(var item in ngayhieuluc)
        //{
        //    if(item.NgayHieuLuc>NgayHieuLucMax) NgayHieuLucMax=item.NgayHieuLuc;
        //}
        DAL.HOSO_LUONG dong = (from t in ngayhieuluc
                               where t.NgayHieuLuc == NgayHieuLucMax
                               orderby t.NgayQuyetDinh descending
                               select t).FirstOrDefault();
        if (dong == null) return 0;
        if (dong.LuongDongBHXH == null) return 0;
        return (decimal)dong.LuongDongBHXH;
    }
}