using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangThanhToanLuongNgoaiGioController
/// </summary>
public class BangThanhToanLuongNgoaiGioController : LinqProvider
{
    public BangThanhToanLuongNgoaiGioController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<BangThanhToanLamThemGioInfo> GetAll(int IDBangChamCong, int start, int limit, string searchkey, out int count)
    {
        var bangcong = dataContext.DanhSachBangTongHopCongs.Where(p => p.ID == IDBangChamCong).FirstOrDefault();
        DateTime dauthang = new DateTime(bangcong.FromDate.Year, bangcong.FromDate.Month, 1);
        DateTime cuoithang = dauthang.AddMonths(1).AddDays(-1);
        var dangky = (from t in dataContext.DangKyLamThemGios
                      where t.DenNgay >= dauthang && t.TuNgay <= cuoithang
                      select new
                      {
                          MaCB = t.MaCB,
                          ThoiGian = (t.TuNgay < dauthang ? dauthang : t.TuNgay).Day + "/" +
                          (t.TuNgay < dauthang ? dauthang : t.TuNgay).Month + "/" +
                          (t.TuNgay < dauthang ? dauthang : t.TuNgay).Year + " - " +
                          (t.DenNgay > cuoithang ? cuoithang : t.DenNgay).Day + "/" +
                          (t.DenNgay > cuoithang ? cuoithang : t.DenNgay).Month + "/" +
                          (t.DenNgay > cuoithang ? cuoithang : t.DenNgay).Year
                      }).ToList();
        List<string> dsma = new List<string>();
        foreach (var item in dangky)
        {
            if (!dsma.Contains(item.MaCB)) dsma.Add(item.MaCB);
        }
        var result = (from t in dataContext.TongHopCongs
                      join q in dataContext.HOSOs on t.MA_CB equals q.MA_CB
                      join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI
                      where t.IdDanhSachBangTongHopCong == IDBangChamCong
                      && dsma.Contains(t.MA_CB)
                      && (System.Data.Linq.SqlClient.SqlMethods.Like(q.MA_CB, searchkey) || System.Data.Linq.SqlClient.SqlMethods.Like(q.HO_TEN, searchkey) || searchkey == "")
                      select new BangThanhToanLamThemGioInfo
                      {
                          PRKEY = q.PR_KEY,
                          BoPhan = x.TEN_DONVI,
                          GioCongLamThemNgayLe = t.SoPhutLamThemNgayLe / 60,
                          GioCongLamThemNgayNghi = t.SoPhutLamThemNgayNghi / 60,
                          GioCongLamThemNgayThuong = t.SoPhutLamThemNgayThuong / 60,
                          HoTen = q.HO_TEN,
                          LuongCung = 0,
                          MaNhanVien = q.MA_CB,
                          NgayDangKyLamThem = "",
                          SoTienLamThemNgayLe = 0,
                          SoTienLamThemNgayNghi = 0,
                          SoTienLamThemNgayThuong = 0,
                          TongCongTien = 0
                      }).Skip(start).Take(limit).ToList();
        List<decimal> dsprkey = result.Select(p => p.PRKEY).ToList();

        var luong = (from t in dataContext.HOSO_LUONGs.Where(p => p.NgayHieuLuc <= DateTime.Now && p.TrangThai == "DaDuyet" && dsprkey.Contains(p.PrKeyHoSo))
                     group t by t.PrKeyHoSo into gp
                     let ngaymax = gp.Max(x => x.NgayHieuLuc)
                     select new
                     {
                         PRKey = gp.Key,
                         LuongCung = gp.First(y => y.NgayHieuLuc == ngaymax).LuongCung
                     }).ToList();

        foreach (var item in result)
        {
            item.LuongCung = luong.Where(p => p.PRKey == item.PRKEY).FirstOrDefault() == null ? 0 : Convert.ToDouble(luong.Where(p => p.PRKey == item.PRKEY).FirstOrDefault().LuongCung);
            item.SoTienLamThemNgayLe = item.GioCongLamThemNgayLe * item.LuongCung / 192 * 3;
            item.SoTienLamThemNgayNghi = item.GioCongLamThemNgayNghi * item.LuongCung / 192 * 2;
            item.SoTienLamThemNgayThuong = item.GioCongLamThemNgayThuong * item.LuongCung / 192 * 1.5;
            item.TongCongTien = item.SoTienLamThemNgayLe + item.SoTienLamThemNgayNghi + item.SoTienLamThemNgayThuong;
            item.NgayDangKyLamThem = string.Join("<br/>", dangky.Where(p => p.MaCB == item.MaNhanVien).Select(p => p.ThoiGian).ToArray());
        }
        count = result.Count;
        return result;
    }
}