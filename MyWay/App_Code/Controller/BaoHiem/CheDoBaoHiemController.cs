using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for CheDoBaoHiemController
/// </summary>

public class CheDoBaoHiemController : LinqProvider
{
    public CheDoBaoHiemController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<DAL.BHCHEDOBAOHIEM> GetAll(string MaDonVi, out int count)
    {
        DM_DONVI dv = new DM_DONVIController().GetById(MaDonVi);
        List<BHCHEDOBAOHIEM> rs = (from t in dataContext.BHCHEDOBAOHIEMs
                                   where t.MaDonVi.Equals(MaDonVi)
                                   select t).ToList();
        count = rs.Count();
        return rs;
    }
    public List<DAL.BHCHEDOBAOHIEM> GetAllChild(string MaDonVi, out int count)
    {
        List<BHCHEDOBAOHIEM> rs = (from t in dataContext.BHCHEDOBAOHIEMs
                                   where t.ParentID != 0
                                   orderby t.ParentID, t.TenCheDoBaoHiem
                                   select t).ToList();
        count = rs.Count();
        return rs;
    }
    //public List<DAL.BHCHEDOBAOHIEM> GetAllChild(string MaDonVi, out int count)
    //{
    //    List<BHCHEDOBAOHIEM> rs = (from t in dataContext.BHCHEDOBAOHIEMs
    //                               where t.MaDonVi.Equals(MaDonVi) && t.ParentID != 0
    //                               orderby t.ParentID, t.TenCheDoBaoHiem
    //                               select t).ToList();
    //    count = rs.Count();
    //    return rs;
    //}
    public List<DAL.BHCHEDOBAOHIEM> GetPrekey(int Prekey)
    {
        List<DAL.BHCHEDOBAOHIEM> rs = (from t in dataContext.BHCHEDOBAOHIEMs
                                       where t.IDCheDoBaoHiem == Prekey
                                       orderby t.ParentID, t.TenCheDoBaoHiem
                                       select t).ToList();

        return rs;
    }
    public List<CheDoBaoHiemInfo> GetbyParentID(int parentID, int nguoiDangNhap)
    {
        var rs = (from t in dataContext.BHCHEDOBAOHIEMs
                  where t.ParentID == parentID
                  select new CheDoBaoHiemInfo()
                  {
                      IDCheDoBaoHiem = t.IDCheDoBaoHiem,
                      ParentID = t.ParentID,
                      TenCheDoBaoHiem = t.TenCheDoBaoHiem,

                  }).OrderBy(T => T.TenCheDoBaoHiem).ToList();
        return rs;
    }
    public List<CheDoBaoHiemInfo> LayConTheoMaCha(int parentid)
    {
        return (from t in dataContext.BHCHEDOBAOHIEMs
                where t.ParentID == parentid
                select new CheDoBaoHiemInfo
                {
                    IDCheDoBaoHiem = t.IDCheDoBaoHiem,
                    MaCheDoBaohiem = t.MaCheDoBaohiem,
                    TenCheDoBaoHiem = t.TenCheDoBaoHiem,
                    ParentID = parentid
                }).ToList();
    }
    public List<NhanVienCheDoInfo> GetNhanVienCheDo(string madonvi, int start, int limit, string searchkey, out int count)
    {
        var cm = new CommonUtil();
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        int[] a1 = dataContext.BHCHEDOBAOHIEMs.Where(p => p.ParentID == dataContext.BHCHEDOBAOHIEMs.SingleOrDefault(x => x.MaCheDoBaohiem == "NOD").IDCheDoBaoHiem).Select(y => y.IDCheDoBaoHiem).ToArray();
        int[] a2 = dataContext.BHCHEDOBAOHIEMs.Where(p => p.ParentID == dataContext.BHCHEDOBAOHIEMs.SingleOrDefault(x => x.MaCheDoBaohiem == "TS").IDCheDoBaoHiem).Select(y => y.IDCheDoBaoHiem).ToArray();
        int[] a3 = dataContext.BHCHEDOBAOHIEMs.Where(p => p.ParentID == dataContext.BHCHEDOBAOHIEMs.SingleOrDefault(x => x.MaCheDoBaohiem == "DSPHSK").IDCheDoBaoHiem).Select(y => y.IDCheDoBaoHiem).ToArray();

        var result = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                      join q in dataContext.HOSOs on t.IDNhanVien_BaoHiem equals q.PR_KEY
                      join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI
                      where (string.IsNullOrEmpty(searchkey)
                            || (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)
                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoSoBHXH, searchkey)
                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoTheBHYT, searchkey)
                          )) && (string.IsNullOrEmpty(madonvi) || s1.Contains(q.MA_DONVI))
                      select new NhanVienCheDoInfo
                      {
                          IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                          MaNhanVien = t.MaNhanVien,
                          TenNhanVien = t.HoTen,
                          PhongBan = x.TEN_DONVI,
                          HoDem = cm.GetLastNameFromFullName(t.HoTen),
                          Ten = cm.GetFirstNamFromFullName(t.HoTen),
                          SoSoBHXH = t.SoSoBHXH,
                          SoTheBHYT = t.SoTheBHYT,
                          SoThangDongBH = t.ThoiGianDongBaoHiem,
                          SoNgayNghiOmDau = 0,
                          SoNgayNghiThaiSan = 0,
                          SoNgayNghiDSPHSK = 0,
                          TongTienThanhToan = 0,
                          TrangThai = "3.Đã nghỉ",
                          DaNghi = t.DaNghi
                      }).ToList();

        int[] loc = result.Select(t => t.IDNhanVien_BaoHiem).ToArray();

        var temp = (from t in dataContext.BHCHITIETCHEDOBAOHIEMs
                    where loc.Contains(t.IDNhanVien_BaoHiem)
                          && (t.NgayKetThuc > new DateTime(DateTime.Now.Year, 1, 1) && t.NgayBatDau < new DateTime(DateTime.Now.Year, 12, 31))
                    //                           && (t.TinhTrangThanhToan == true)
                    select t).ToList();

        var temp1 = temp.Where(t => t.TinhTrangThanhToan == true).ToList();
        #region Tính số ngày nghỉ và tổng tiền thanh toán
        foreach (var item in result)
        {

            var SoNgayNghiDSPHSK = (from t in temp1
                                    where a3.Contains(t.BHBANGTINHCHEDOBAOHIEM.IDCheDoBaoHiem)
                                         && t.IDNhanVien_BaoHiem == item.IDNhanVien_BaoHiem
                                    group t by new
                                    {
                                        t.IDNhanVien_BaoHiem
                                    } into y
                                    select new { songaynghi = y.Sum(t => t.SoNgayNghi) }
                                      ).SingleOrDefault();
            var SoNgayNghiThaiSan = (from t in temp1
                                     where a1.Contains(t.BHBANGTINHCHEDOBAOHIEM.IDCheDoBaoHiem)
                                          && t.IDNhanVien_BaoHiem == item.IDNhanVien_BaoHiem
                                     group t by new
                                     {
                                         t.IDNhanVien_BaoHiem
                                     } into y
                                     select new { songaynghi = y.Sum(t => t.SoNgayNghi) }
                                     ).SingleOrDefault();
            var SoNgayNghiOmDau = (from t in temp1
                                   where a2.Contains(t.BHBANGTINHCHEDOBAOHIEM.IDCheDoBaoHiem)
                                        && t.IDNhanVien_BaoHiem == item.IDNhanVien_BaoHiem
                                   group t by new
                                   {
                                       t.IDNhanVien_BaoHiem
                                   } into y
                                   select new { songaynghi = y.Sum(t => t.SoNgayNghi) }
                                      ).SingleOrDefault();
            var TongTienThanhToan = (from t in temp1
                                     where t.IDNhanVien_BaoHiem == item.IDNhanVien_BaoHiem
                                     group t by new
                                     {
                                         t.IDNhanVien_BaoHiem
                                     } into y
                                     select new { TongTienThanhToan = y.Sum(t => t.SoTienDeNghi) }
                                      ).SingleOrDefault();
            DateTime st = new DateTime(DateTime.Now.Month == 1 ? (DateTime.Now.Year - 1) : DateTime.Now.Year, DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1, 15);
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14);
            var tmp = temp.Where(x => x.IDNhanVien_BaoHiem == item.IDNhanVien_BaoHiem && (DateTime.Compare(x.NgayBatDau, st) >= 0 && DateTime.Compare(x.NgayBatDau, end) <= 0)).ToList();
            item.SoNgayNghiDSPHSK = SoNgayNghiDSPHSK == null ? 0 : (int)SoNgayNghiDSPHSK.songaynghi;
            item.SoNgayNghiOmDau = SoNgayNghiThaiSan == null ? 0 : (int)SoNgayNghiThaiSan.songaynghi;
            item.SoNgayNghiThaiSan = SoNgayNghiOmDau == null ? 0 : (int)SoNgayNghiOmDau.songaynghi;
            item.TongTienThanhToan = TongTienThanhToan == null ? 0 : (decimal)TongTienThanhToan.TongTienThanhToan;
            item.TrangThai = (item.DaNghi == null || item.DaNghi == false) ? (tmp.Count > 0 ? "1.Phát sinh chế độ trong tháng" : "2.Không phát sinh chế độ trong tháng") : item.TrangThai = item.TrangThai;
        }
        #endregion
        count = result.Count;
        result = (from t in result
                  orderby t.TrangThai, t.Ten, t.HoDem
                  select t).ToList();
        return result.Skip(start).Take(limit).ToList();
    }
    public List<DanhSachCheDoBaoCaoInfo> GetDanhSachCheDoBaoCao(string madonvi, string mabaocao, int start, int limit, DateTime tungay, DateTime denngay, string searchkey, out int count)
    {
        int[] a = dataContext.BHCHEDOBAOHIEMs.Select(y => y.IDCheDoBaoHiem).ToArray();
        int[] b;
        switch (mabaocao)
        {
            case "C66a-HD":
                a = dataContext.BHCHEDOBAOHIEMs.Where(p => p.ParentID == dataContext.BHCHEDOBAOHIEMs.SingleOrDefault(x => x.MaCheDoBaohiem == "NOD").IDCheDoBaoHiem).Select(y => y.IDCheDoBaoHiem).ToArray();
                break;
            case "C67a-HD":
                a = dataContext.BHCHEDOBAOHIEMs.Where(p => p.ParentID == dataContext.BHCHEDOBAOHIEMs.SingleOrDefault(x => x.MaCheDoBaohiem == "TS").IDCheDoBaoHiem).Select(y => y.IDCheDoBaoHiem).ToArray();
                break;
            case "C68a-HD":
                a = dataContext.BHCHEDOBAOHIEMs.Where(p => p.MaCheDoBaohiem == "DSPHSK_SAUOMDAU").Select(y => y.IDCheDoBaoHiem).ToArray();
                break;
            case "C69a-HD":
                a = dataContext.BHCHEDOBAOHIEMs.Where(p => p.MaCheDoBaohiem == "NDPHSK_SAUTHAISAN").Select(y => y.IDCheDoBaoHiem).ToArray();
                break;
            case "C70a-HD":
                a = dataContext.BHCHEDOBAOHIEMs.Select(y => y.IDCheDoBaoHiem).ToArray();
                break;
        }
        b = (from t in dataContext.BHBANGTINHCHEDOBAOHIEMs
             where a.Contains(t.IDCheDoBaoHiem)
             select t.IDBangTinhCheDoBaoHiem).ToArray();

        var result = (from t in dataContext.BHCHITIETCHEDOBAOHIEMs
                      join q in dataContext.BHNHANVIEN_BAOHIEMs on t.IDNhanVien_BaoHiem equals q.IDNhanVien_BaoHiem
                      join x in dataContext.BHBANGTINHCHEDOBAOHIEMs on t.IDBangTinhCheDoBaoHiem equals x.IDBangTinhCheDoBaoHiem
                      join y in dataContext.BHCHEDOBAOHIEMs on x.IDCheDoBaoHiem equals y.IDCheDoBaoHiem
                      where (madonvi == "" || t.MaDonVi == madonvi)
                      && b.Contains(t.IDBangTinhCheDoBaoHiem)
                      && t.NgayBatDau >= tungay && t.NgayBatDau <= denngay
                      orderby q.HoTen
                      select new DanhSachCheDoBaoCaoInfo
                      {
                          IDCheDoBaoHiem = x.IDCheDoBaoHiem,
                          IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                          MaCanBo = q.MaNhanVien,
                          HoTen = q.HoTen,
                          Ten = q.Ten,
                          SoSoBHXH = q.SoSoBHXH,
                          DieuKienTinhHuong = x.TenDieuKienHuong,
                          ThoiGianDongBHXH = q.ThoiGianDongBaoHiem,
                          TienLuongTinhHuong = t.TienLuongTinhHuong,
                          SoNgayNghi = t.SoNgayNghi,
                          LuyKeTuDauNam = 0,
                          SoTienDeNghi = t.SoTienDeNghi,
                          GhiChu = t.GhiChu,
                          GroupField = y.TenCheDoBaoHiem
                      }).ToList();
        foreach (var item in result)
        {
            item.LuyKeTuDauNam = TinhSoNgayNghiNhanVien(item.IDNhanVien_BaoHiem, item.IDCheDoBaoHiem);
        }
        result = (from t in result
                  orderby t.GroupField, t.Ten, t.HoTen
                  select t).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).ToList();
    }



    public List<NhanVienCheDoTheoThangInfo> GetNhanVienCheDoTheoThang(string madonvi, int thang, int nam, int start, int limit, string searchkey, out int count)
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
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        var result = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                      join q in dataContext.HOSOs on t.IDNhanVien_BaoHiem equals q.PR_KEY
                      join x in dataContext.BHCHITIETCHEDOBAOHIEMs on t.IDNhanVien_BaoHiem equals x.IDNhanVien_BaoHiem
                      join u in dataContext.BHBANGTINHCHEDOBAOHIEMs on x.IDBangTinhCheDoBaoHiem equals u.IDBangTinhCheDoBaoHiem
                      join e in dataContext.BHCHEDOBAOHIEMs on u.IDCheDoBaoHiem equals e.IDCheDoBaoHiem
                      join y in dataContext.DM_DONVIs on q.MA_DONVI equals y.MA_DONVI
                      where (string.IsNullOrEmpty(madonvi) || s1.Contains(q.MA_DONVI)) &&
                            (string.IsNullOrEmpty(searchkey) || (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                            || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)))
                            && (DateTime.Compare(x.NgayBatDau, st) >= 0 && DateTime.Compare(x.NgayBatDau, end) <= 0)
                      //&& (nam == 0 || x.NgayBatDau.Year == nam)
                      orderby x.NgayKetThuc descending, t.Ten, t.HoTen
                      select new NhanVienCheDoTheoThangInfo
                      {
                          IDChiTietCheDoBaoHiem = x.IDChiTietCheDoBaoHiem,
                          IDBangTinhCheDoBaoHiem = x.IDBangTinhCheDoBaoHiem,
                          IDNhanVien_BaoHiem = x.IDNhanVien_BaoHiem,
                          MaCheDo = e.MaCheDoBaohiem,
                          TenCheDo = e.TenCheDoBaoHiem,
                          DieuKienHuong = u.TenDieuKienHuong,
                          MaNhanVien = t.MaNhanVien,
                          HoTen = t.HoTen,
                          Ten = t.Ten,
                          PhongBan = y.TEN_DONVI,
                          NgayBatDau = x.NgayBatDau,
                          NgayKetThuc = x.NgayKetThuc,
                          SoNgayNghi = x.SoNgayNghi,
                          SoTienDeNghi = x.SoTienDeNghi,
                          TinhTrangThanhToan = x.TinhTrangThanhToan,
                          TienLuongTinhHuong = x.TienLuongTinhHuong,
                          Thang = getMonthToCQBH(x.NgayBatDau),//x.NgayKetThuc.Month >= 10 ? "Tháng " + x.NgayKetThuc.Month + "/" + x.NgayKetThuc.Year : "Tháng 0" + x.NgayKetThuc.Month + "/" + x.NgayKetThuc.Year,
                          GhiChu = x.GhiChu
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
    public int TinhSoNgayNghiNhanVien(int idnhanvienbaohiem, int idchedobaohiem)
    {
        int[] a1 = dataContext.BHBANGTINHCHEDOBAOHIEMs.Where(p => p.IDCheDoBaoHiem == idchedobaohiem).Select(y => y.IDBangTinhCheDoBaoHiem).ToArray();
        var temp1 = (from t in dataContext.BHCHITIETCHEDOBAOHIEMs
                     where t.IDNhanVien_BaoHiem == idnhanvienbaohiem
                          && (t.NgayKetThuc > new DateTime(DateTime.Now.Year, 1, 1) && t.NgayBatDau < new DateTime(DateTime.Now.Year, 12, 31))
                             && (t.TinhTrangThanhToan == true)
                     select new
                     {
                         IDBangTinhCheDoBaoHiem = t.IDBangTinhCheDoBaoHiem,
                         SoNgayNghi = t.SoNgayNghi
                     }).ToList();
        var temp2 = (from t in temp1
                     where a1.Contains(t.IDBangTinhCheDoBaoHiem)
                     select t).ToList();
        if (temp2.Count > 0)
        {
            return (int)temp2.Sum(p => p.SoNgayNghi);
        }
        else
        {
            return 0;
        }
    }

    public List<ChiTietNhanVienCheDoInfo> GetChiTietNhanVienCheDo(int IDNhanVienBaoHiem, int start, int limit, out int count)
    {
        var result = (from t in dataContext.BHCHITIETCHEDOBAOHIEMs
                      join q in dataContext.BHBANGTINHCHEDOBAOHIEMs on t.IDBangTinhCheDoBaoHiem equals q.IDBangTinhCheDoBaoHiem
                      join x in dataContext.BHCHEDOBAOHIEMs on q.IDCheDoBaoHiem equals x.IDCheDoBaoHiem
                      where t.IDNhanVien_BaoHiem == IDNhanVienBaoHiem
                      orderby t.NgayKetThuc descending
                      select new ChiTietNhanVienCheDoInfo
                      {
                          IDChiTietCheDoBaoHiem = t.IDChiTietCheDoBaoHiem,
                          IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                          MaCheDo = x.MaCheDoBaohiem,
                          TenCheDo = x.TenCheDoBaoHiem,
                          DieuKienHuong = q.TenDieuKienHuong,
                          TuNgay = t.NgayBatDau,
                          DenNgay = t.NgayKetThuc,
                          SoNgayNghi = t.SoNgayNghi,
                          SoTienDeNghi = t.SoTienDeNghi,
                          TinhTrangThanhToan = t.TinhTrangThanhToan,
                          GhiChu = t.GhiChu
                      }).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).ToList();
    }

    public DAL.BHCHITIETCHEDOBAOHIEM GetChiTietCheDoBaoHiemByID(int IDChiTietCheDoBaoHiem)
    {
        return dataContext.BHCHITIETCHEDOBAOHIEMs.SingleOrDefault(p => p.IDChiTietCheDoBaoHiem == IDChiTietCheDoBaoHiem);
    }
    public void InsertChiTietCheDoBaoHiem(BHCHITIETCHEDOBAOHIEM chitiet)
    {
        dataContext.BHCHITIETCHEDOBAOHIEMs.InsertOnSubmit(chitiet);
        Save();

    }

    public void CapNhatChiTietCheDoBaoHiem(BHCHITIETCHEDOBAOHIEM chitiet)
    {
        DAL.BHCHITIETCHEDOBAOHIEM item = dataContext.BHCHITIETCHEDOBAOHIEMs.SingleOrDefault(p => p.IDChiTietCheDoBaoHiem == chitiet.IDChiTietCheDoBaoHiem);
        item.IDBangTinhCheDoBaoHiem = chitiet.IDBangTinhCheDoBaoHiem;
        item.IDChiTietCheDoBaoHiem = chitiet.IDChiTietCheDoBaoHiem;
        item.IDNhanVien_BaoHiem = chitiet.IDNhanVien_BaoHiem;
        item.MucDoSuyGiamKhaNangLaoDong = chitiet.MucDoSuyGiamKhaNangLaoDong;
        item.NgayBatDau = chitiet.NgayBatDau;
        item.NgayKetThuc = chitiet.NgayKetThuc;
        item.SoNgayNghi = chitiet.SoNgayNghi;
        item.SoTienDeNghi = chitiet.SoTienDeNghi;
        item.TinhTrangThanhToan = chitiet.TinhTrangThanhToan;
        item.GhiChu = chitiet.GhiChu;
        Save();
    }

    public void DeleteChiTietCheDoBaoHiem(BHCHITIETCHEDOBAOHIEM chitiet)
    {
        DAL.BHCHITIETCHEDOBAOHIEM item = new DAL.BHCHITIETCHEDOBAOHIEM();
        item = dataContext.BHCHITIETCHEDOBAOHIEMs.SingleOrDefault(p => p.IDChiTietCheDoBaoHiem == chitiet.IDChiTietCheDoBaoHiem);
        dataContext.BHCHITIETCHEDOBAOHIEMs.DeleteOnSubmit(item);
        Save();
    }

}