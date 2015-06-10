using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuanLyBienDongBaoHiemController
/// </summary>
public class QuanLyBienDongBaoHiemController : LinqProvider
{
    public QuanLyBienDongBaoHiemController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<NhanVienBienDongInfo> GetNhanVienBienDong(string madonvi, int start, int limit, string searchkey, out int count)
    {
        DateTime st = new DateTime(DateTime.Now.Month == 1 ? (DateTime.Now.Year - 1) : DateTime.Now.Year, DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1, 15);
        DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14);
        string[] ds = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        #region Có biến động bảo hiểm trong tháng
        List<NhanVienBienDongInfo> rs1 = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                          join q in dataContext.HOSOs on t.MaNhanVien equals q.MA_CB
                                          join x in dataContext.BHBIENDONGBAOHIEMs on t.IDNhanVien_BaoHiem equals x.IDNhanVien_BaoHiem
                                          join y in dataContext.DM_DONVIs on q.MA_DONVI equals y.MA_DONVI
                                          where ds.Contains(q.MA_DONVI) &&
                                                          (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                              || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)))
                                                          && (DateTime.Compare(x.TuNgay, st) >= 0 && DateTime.Compare(x.TuNgay, end) <= 0)
                                                          && (t.DaNghi == null || t.DaNghi == false)
                                          group t by new
                                          {
                                              t.IDNhanVien_BaoHiem,
                                              t.MaNhanVien,
                                              t.HoTen,
                                              t.Ten,
                                              y.TEN_DONVI,
                                              t.ThoiGianDongBaoHiem,
                                              t.LuongBaoHiem,
                                              t.PhuCapCV,
                                              t.PhuCapTNN,
                                              t.PhuCapTNVK,
                                              t.PhuCapKhac,
                                              t.DangDongBHXH,
                                              t.DangDongBHYT,
                                              t.DangDongBHTN,
                                              t.DaNghi
                                          } into g
                                          select new NhanVienBienDongInfo
                                          {
                                              IDNhanVien_BaoHiem = g.Key.IDNhanVien_BaoHiem,
                                              MaNhanVien = g.Key.MaNhanVien,
                                              HoTen = g.Key.HoTen,
                                              Ten = g.Key.Ten,
                                              PhongBan = g.Key.TEN_DONVI,
                                              ThoiGianDongBaoHiem = g.Key.ThoiGianDongBaoHiem,
                                              LuongBaoHiem = g.Key.LuongBaoHiem,
                                              PhuCapCV = g.Key.PhuCapCV,
                                              PhuCapTNN = g.Key.PhuCapTNN,
                                              PhuCapTNVK = g.Key.PhuCapTNVK,
                                              PhuCapKhac = g.Key.PhuCapKhac,
                                              DangDongBHXH = g.Key.DangDongBHXH,
                                              DangDongBHYT = g.Key.DangDongBHYT,
                                              DangDongBHTN = g.Key.DangDongBHTN,
                                              TrangThai = "1.Có biến động bảo hiểm trong tháng",
                                              DaNghi = g.Key.DaNghi
                                          }).ToList();
        #endregion
        #region Không có biến động bảo hiểm trong tháng
        List<NhanVienBienDongInfo> rs2 = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                          join q in dataContext.HOSOs on t.MaNhanVien equals q.MA_CB
                                          join y in dataContext.DM_DONVIs on q.MA_DONVI equals y.MA_DONVI
                                          where ds.Contains(q.MA_DONVI)
                                                          && (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                              || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)))
                                                          && !(from x in rs1 select x.MaNhanVien).ToList().Contains(t.MaNhanVien)
                                          select new NhanVienBienDongInfo
                                          {
                                              IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                                              MaNhanVien = t.MaNhanVien,
                                              HoTen = t.HoTen,
                                              Ten = t.Ten,
                                              PhongBan = y.TEN_DONVI,
                                              ThoiGianDongBaoHiem = t.ThoiGianDongBaoHiem,
                                              LuongBaoHiem = t.LuongBaoHiem,
                                              PhuCapCV = t.PhuCapCV,
                                              PhuCapTNN = t.PhuCapTNN,
                                              PhuCapTNVK = t.PhuCapTNVK,
                                              PhuCapKhac = t.PhuCapKhac,
                                              DangDongBHXH = t.DangDongBHXH,
                                              DangDongBHYT = t.DangDongBHYT,
                                              DangDongBHTN = t.DangDongBHTN,
                                              TrangThai = t.DaNghi == true ? "3.Đã nghỉ" : "2.Không có biến động bảo hiểm trong tháng",
                                              DaNghi = t.DaNghi
                                          }).ToList();
        #endregion
        var rs = (rs1.Concat(rs2)).ToList();
        rs = (from t in rs
              orderby t.TrangThai, t.Ten, t.HoTen
              select t
                ).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
    public List<BienDongTheoThangInfo> GetBienDongTheoThang(string madonvi, int thang, int nam, int start, int limit, string searchkey, out int count)
    {
        DateTime st = new DateTime();
        DateTime end = new DateTime();
        if (thang != 0)
        {
            st = new DateTime(thang == 1 ? (nam - 1) : nam, thang == 1 ? 12 : thang - 1, 15);
            end = new DateTime(nam, thang, 14);
        }
        else
        {
            st = new DateTime(nam - 1, 12, 15);
            end = new DateTime(nam, 12, 14);
        }
        string[] ds = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        List<BienDongTheoThangInfo> result = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                              join q in dataContext.HOSOs on t.MaNhanVien equals q.MA_CB
                                              join x in dataContext.BHBIENDONGBAOHIEMs on t.IDNhanVien_BaoHiem equals x.IDNhanVien_BaoHiem
                                              join u in dataContext.BHQUYDINHBIENDONGs on x.IDQuyDinhBienDong equals u.IDQuyDinhBienDong
                                              join y in dataContext.DM_DONVIs on q.MA_DONVI equals y.MA_DONVI
                                              where (string.IsNullOrEmpty(madonvi) || ds.Contains(q.MA_DONVI)) &&
                                                    (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                    || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)))
                                                    && (DateTime.Compare(x.TuNgay, st) >= 0 && DateTime.Compare(x.TuNgay, end) <= 0)
                                              orderby x.TuNgay descending, t.Ten, t.HoTen
                                              select new BienDongTheoThangInfo
                                              {
                                                  IDBienDongBaoHiem = x.IDBienDongBaoHiem,
                                                  IDQuyDinhBienDong = x.IDQuyDinhBienDong,
                                                  IDNhanVien_BaoHiem = x.IDNhanVien_BaoHiem,
                                                  MaCanBo = x.MaNhanVien,
                                                  HoTen = x.HoTen,
                                                  PhongBan = y.TEN_DONVI,
                                                  TenBienDong = u.TenBienDong,
                                                  Loai = x.Loai,
                                                  TuNgay = x.TuNgay,
                                                  DenNgay = x.DenNgay,
                                                  SoNgay = ((TimeSpan)(x.DenNgay.Value - x.TuNgay)).Days,
                                                  TienLuongCu = x.TienLuongCu,
                                                  TongPhuCapCu = x.PhuCapCVCu + x.PhuCapNgheCu + x.PhuCapTNVKCu,
                                                  TienLuongMoi = x.TienLuongMoi,
                                                  TongPhuCapMoi = x.PhuCapCVMoi + x.PhuCapTNNgheMoi + x.PhuCapTNVKMoi,
                                                  KhongTraThe = x.KhongTraThe,
                                                  DaCoSo = x.DaCoSo,
                                                  DienGiai = x.DienGiai,
                                                  Thang = getMonthToCQBH(x.TuNgay) //x.TuNgay.Month >= 10 ? "Tháng " + x.TuNgay.Month + "/" + x.TuNgay.Year : "Tháng 0" + x.TuNgay.Month + "/" + x.TuNgay.Year,
                                              }).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).ToList();
    }
    public string getMonthToCQBH(DateTime date)
    {
        int month = date.Day > 15 ? (date.Month == 12 ? 1 : date.Month + 1) : date.Month;
        int year = (date.Month == 12 && month == 1) ? date.Year + 1 : date.Year;
        return "Tháng " + (month < 10 ? ("0" + month.ToString()) : month.ToString()) + "/" + year.ToString();
    }
    public List<DanhSachBienDongInfo> GetDanhSachBienDong(string madonvi, int start, int limit, string searchkey, DateTime tungay, DateTime denngay, out int count)
    {
        string[] ds = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        var result = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                             join q in dataContext.HOSOs on t.MaNhanVien.Trim() equals q.MA_CB.Trim()
                                             join x in dataContext.BHBIENDONGBAOHIEMs on t.IDNhanVien_BaoHiem equals x.IDNhanVien_BaoHiem //&& DateTime.Compare(x.ThangDangKy, tungay) >= 0 && DateTime.Compare(x.ThangDangKy, denngay) <= 0
                                             
                                          where ds.Contains(q.MA_DONVI.Trim()) &&
                                                          (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                              || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)))
                                               && (DateTime.Compare(x.TuNgay, tungay) >= 0 && DateTime.Compare(x.TuNgay, denngay) <= 0 )
                                             select new DanhSachBienDongInfo
                                              {
                                                  IDBienDongBaoHiem = x.IDBienDongBaoHiem,
                                                  IDQuyDinhBienDong = x.IDQuyDinhBienDong,
                                                  IDNhanVien_BaoHiem = x.IDNhanVien_BaoHiem,
                                                  MaCanBo = x.MaNhanVien,
                                                  HoTen = x.HoTen,
                                                  Ten = x.HoTen,
                                                  MaSo = t.SoSoBHXH,
                                                  GioiTinh = !(bool)x.GioiTinh,
                                                  NgaySinh = x.NgaySinh,
                                                  Loai = x.BHQUYDINHBIENDONG.MaBienDong,
                                                  TuNgay = x.TuNgay,
                                                  DenNgay = x.DenNgay,
                                                  ThangDangKy = x.ThangDangKy,
                                                  SoNgay = ((TimeSpan)(x.DenNgay.Value - x.TuNgay)).Days,
                                                  TienLuongCu = x.TienLuongCu,
                                                  TongPhuCapCu = x.PhuCapCVCu + x.PhuCapNgheCu + x.PhuCapTNVKCu,
                                                  TienLuongMoi = x.TienLuongMoi,
                                                  TongPhuCapMoi = x.PhuCapCVMoi + x.PhuCapTNNgheMoi + x.PhuCapTNVKMoi,
                                                  KhongTraThe = x.KhongTraThe,
                                                  DaCoSo = x.DaCoSo,
                                                  DienGiai = x.DienGiai,
                                              }).ToList();
        foreach (var item in result)
        {
            switch (item.Loai)
            {
                case "TLD": item.TrangThai = "1.Tăng lao động"; break;
                case "GLD": item.TrangThai = "3.Giảm lao động"; break;
                case "TMD": item.TrangThai = "2.Tăng mức đóng"; break;
                case "GMD": item.TrangThai = "4.Giảm mức đóng"; break;
            }
        }
        result = (from t in result orderby t.TrangThai, t.Ten, t.HoTen select t).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).ToList();
    }
    public List<ChiTietNhanVienBienDongInfo> GetChiTienNhanVienBienDong(string manhanvien, int start, int limit, out int count)
    {
        List<ChiTietNhanVienBienDongInfo> rs = (from t in dataContext.BHBIENDONGBAOHIEMs
                                                where t.MaNhanVien == manhanvien
                                                orderby t.TuNgay descending
                                                select new ChiTietNhanVienBienDongInfo
                                                {
                                                    IDBienDongBaoHiem = t.IDBienDongBaoHiem,
                                                    IDQuyDinhBienDong = t.IDQuyDinhBienDong,
                                                    IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                                                    MaBienDong = t.BHQUYDINHBIENDONG.MaBienDong,
                                                    TenBienDong = t.BHQUYDINHBIENDONG.TenBienDong,
                                                    TuNgay = t.TuNgay,
                                                    Loai = t.Loai,
                                                    MaNhanVien = t.MaNhanVien,
                                                    HoTen = t.HoTen,
                                                    MaSo = t.MaSo,
                                                    NgaySinh = t.NgaySinh,
                                                    GioiTinh = t.GioiTinh,
                                                    ChucVu = t.ChucVu,
                                                    DenNgay = t.DenNgay,
                                                    SoNgayNghi = ((TimeSpan)(t.DenNgay.Value - t.TuNgay)).Days + 1,
                                                    TienLuongCu = t.TienLuongCu,
                                                    PhuCapCVCu = t.PhuCapCVCu,
                                                    PhuCapNgheCu = t.PhuCapNgheCu,
                                                    PhuCapTNVKCu = t.PhuCapTNVKCu,
                                                    TienLuongMoi = t.TienLuongMoi,
                                                    PhuCapCVMoi = t.PhuCapCVMoi,
                                                    PhuCapTNNgheMoi = t.PhuCapTNNgheMoi,
                                                    PhuCapTNVKMoi = t.PhuCapTNVKMoi,
                                                    KhongTraThe = t.KhongTraThe,
                                                    DaCoSo = t.DaCoSo,
                                                    DaDuyet = t.DaDuyet,
                                                    DateCreate = t.DateCreate,
                                                    ThangBienDong = string.Format("Tháng {0}/{1}", t.TuNgay.Month, t.TuNgay.Year),
                                                    //ThangDangKy = t.ThangDangKy, 
                                                    MaDonVi = t.MaDonVi

                                                }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
    public void InsertBienDongBaoHiem(DAL.BHBIENDONGBAOHIEM bdbh)
    {
        dataContext.BHBIENDONGBAOHIEMs.InsertOnSubmit(bdbh);
        Save();
    }
    public ChiTietNhanVienBienDongInfo GetByIDBienDongBaoHiem(int IDBienDongBaoHiem)
    {
        return (from t in dataContext.BHBIENDONGBAOHIEMs
                where t.IDBienDongBaoHiem == IDBienDongBaoHiem
                select new ChiTietNhanVienBienDongInfo
                {
                    IDBienDongBaoHiem = t.IDBienDongBaoHiem,
                    IDQuyDinhBienDong = t.IDQuyDinhBienDong,
                    IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                    MaBienDong = t.BHQUYDINHBIENDONG.MaBienDong,
                    TenBienDong = t.BHQUYDINHBIENDONG.TenBienDong,
                    TuNgay = t.TuNgay,
                    Loai = t.Loai,
                    MaNhanVien = t.MaNhanVien,
                    HoTen = t.HoTen,
                    MaSo = t.MaSo,
                    NgaySinh = t.NgaySinh,
                    GioiTinh = t.GioiTinh,
                    ChucVu = t.ChucVu,
                    DenNgay = t.DenNgay,
                    SoNgayNghi = ((TimeSpan)(t.DenNgay.Value - t.TuNgay)).Days,
                    TienLuongCu = t.TienLuongCu,
                    PhuCapCVCu = t.PhuCapCVCu,
                    PhuCapNgheCu = t.PhuCapNgheCu,
                    PhuCapTNVKCu = t.PhuCapTNVKCu,
                    TienLuongMoi = t.TienLuongMoi,
                    PhuCapCVMoi = t.PhuCapCVMoi,
                    PhuCapTNNgheMoi = t.PhuCapTNNgheMoi,
                    PhuCapTNVKMoi = t.PhuCapTNVKMoi,
                    KhongTraThe = t.KhongTraThe,
                    DaCoSo = t.DaCoSo,
                    DaDuyet = t.DaDuyet,
                    DateCreate = t.DateCreate,
                    ThangBienDong = string.Format("Tháng {0}/{1}", t.TuNgay.Month, t.TuNgay.Year),
                    DienGiai = t.DienGiai,
                    ThangDangKy = t.ThangDangKy,
                    MaDonVi = t.MaDonVi,
                    TruyThuBHXH = t.TruyThuBHXH,
                    TruyThuBHYT = t.TruyThuBHYT,
                    ThoaiThuBHXH = t.ThoaiThuBHXH,
                    ThoaiThuBHYT = t.ThoaiThuBHYT
                }).SingleOrDefault();
    }
    public DAL.BHBIENDONGBAOHIEM GetBienDongBaoHiemByID(int IDBienDongBaoHiem)
    {
        return (from t in dataContext.BHBIENDONGBAOHIEMs
                where t.IDBienDongBaoHiem == IDBienDongBaoHiem
                select t).SingleOrDefault();
        //dataContext.BHBIENDONGBAOHIEMs.Where(p => p.IDBienDongBaoHiem == IDBienDongBaoHiem).SingleOrDefault();
    }
    public void UpdateBienDongBaoHiem(DAL.BHBIENDONGBAOHIEM bdbh)
    {
        DAL.BHBIENDONGBAOHIEM item = dataContext.BHBIENDONGBAOHIEMs.SingleOrDefault(t => t.IDBienDongBaoHiem == bdbh.IDBienDongBaoHiem);
        if (item != null)
        {
            item.IDBienDongBaoHiem = bdbh.IDBienDongBaoHiem;
            item.IDNhanVien_BaoHiem = bdbh.IDNhanVien_BaoHiem;
            item.IDQuyDinhBienDong = bdbh.IDQuyDinhBienDong;
            item.ChucVu = bdbh.ChucVu;
            item.DaCoSo = bdbh.DaCoSo;
            item.DaDuyet = bdbh.DaDuyet;
            item.DateCreate = bdbh.DateCreate;
            item.DenNgay = item.DenNgay;
            item.DienGiai = bdbh.DienGiai;
            item.GioiTinh = bdbh.GioiTinh;
            item.HoTen = bdbh.HoTen;
            item.KhongTraThe = bdbh.KhongTraThe;
            item.Loai = bdbh.Loai;
            item.MaDonVi = bdbh.MaDonVi;
            item.MaNhanVien = bdbh.MaNhanVien;
            item.MaSo = bdbh.MaSo;
            item.NgaySinh = bdbh.NgaySinh;
            item.PhuCapCVCu = bdbh.PhuCapCVCu;
            item.PhuCapCVMoi = bdbh.PhuCapCVMoi;
            item.PhuCapNgheCu = bdbh.PhuCapNgheCu;
            item.PhuCapTNNgheMoi = bdbh.PhuCapTNNgheMoi;
            item.PhuCapTNVKCu = bdbh.PhuCapTNVKCu;
            item.PhuCapTNVKMoi = bdbh.PhuCapTNVKMoi;
            item.TienLuongCu = bdbh.TienLuongCu;
            item.TienLuongMoi = bdbh.TienLuongMoi;
            item.TuNgay = bdbh.TuNgay;
            item.ThangDangKy = bdbh.ThangDangKy;
            item.UserID = bdbh.UserID;
            Save();
        }

    }

    public void DeleteBienDongBaoHiem(DAL.BHBIENDONGBAOHIEM bdbh)
    {
        DAL.BHBIENDONGBAOHIEM item = new DAL.BHBIENDONGBAOHIEM();
        item = dataContext.BHBIENDONGBAOHIEMs.Where(p => p.IDBienDongBaoHiem == bdbh.IDBienDongBaoHiem).SingleOrDefault();
        dataContext.BHBIENDONGBAOHIEMs.DeleteOnSubmit(item);
        Save();
    }


}