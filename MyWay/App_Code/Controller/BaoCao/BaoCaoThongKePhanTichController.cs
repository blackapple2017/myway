using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for BaoCaoThongKePhanTichController
/// </summary>
public class BaoCaoThongKePhanTichController : LinqProvider
{
    public BaoCaoThongKePhanTichController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Lấy ra danh sách bộ phận theo các chỉ tiêu giới tính, trình độ (loại hdong chưa làm)
    /// </summary>
    /// <param name="mabophan"></param>
    /// <param name="danghi"></param>
    /// <returns></returns>
    public List<BaoCaoThongKeDanhSachCanBoNghiViecInfo> ThongKeDanhSachCanBoNghiViec(string mabophan, bool danghi)
    {
        List<string> a = new List<string>();
        foreach (var item in mabophan.Split(','))
            a.Add(item);
        List<DonViInfo> donvi = new List<DonViInfo>();
        new DM_DONVIController().LayCon(a, ref donvi, 1);
        var result = (from t in donvi
                      select new BaoCaoThongKeDanhSachCanBoNghiViecInfo
                      {
                          MaPhongBan = t.MaDonVi,
                          TenPhongBan = t.TenDonVi,
                          Level = t.Level,
                          ParentID = t.ParentID,
                          Nam = 0,
                          Nu = 0,
                          SauDaiHoc = 0,
                          DaiHoc = 0,
                          CaoDang = 0,
                          TrungCap = 0,
                          PTTH = 0,
                          Khac = 0,
                          Duoi6Thang = 0,
                          Duoi1Nam = 0,
                          Duoi3Nam = 0,
                          Tren3Nam = 0,
                          HDThuViec = 0,
                          HDChinhThuc = 0,
                          Tong = 0
                      }).ToList();
        var hoso = (from t in dataContext.HOSOs
                    where (danghi == true ? t.DA_NGHI == true : t.DA_NGHI == false || t.DA_NGHI == null)
                    select new
                    {
                        MaPhongBan = t.MA_DONVI,
                        GioiTinh = t.MA_GIOITINH,
                        TrinhDo = ((t.MA_TRINHDO == "" || t.MA_TRINHDO == null) ? "6.K" : t.DM_TRINHDO.NhomTrinhDo),
                        ThamNien = (danghi == true ? ((t.NGAY_NGHI == null ? DateTime.Now : t.NGAY_NGHI.Value) -
                                            (t.NGAY_TUYEN_CHINHTHUC == null ? DateTime.Now : t.NGAY_TUYEN_CHINHTHUC.Value)).Days :
                                            (DateTime.Now - (t.NGAY_TUYEN_CHINHTHUC == null ? DateTime.Now : t.NGAY_TUYEN_CHINHTHUC.Value)).Days) / 30.5,
                        LoaiHDong = 0,
                        DaNghi = t.DA_NGHI,
                        HoTen = t.HO_TEN
                    }).ToList();
        var tinhtoan = (from t in hoso
                        group t by t.MaPhongBan into g
                        select new
                        {
                            MaPhongBan = g.Key,
                            Nam = g.Where(t => t.GioiTinh == "M").ToList().Count,
                            Nu = g.Where(t => t.GioiTinh == "F").ToList().Count,
                            SauDaiHoc = g.Where(t => t.TrinhDo == "1.SDH").ToList().Count,
                            DaiHoc = g.Where(t => t.TrinhDo == "2.DH").ToList().Count,
                            CaoDang = g.Where(t => t.TrinhDo == "3.CD").ToList().Count,
                            TrungCap = g.Where(t => t.TrinhDo == "4.TC").ToList().Count,
                            PTTH = g.Where(t => t.TrinhDo == "5.PTTH").ToList().Count,
                            Khac = g.Where(t => t.TrinhDo == "6.K").ToList().Count,
                            Duoi6Thang = g.Where(t => t.ThamNien < 6).ToList().Count,
                            Duoi1Nam = g.Where(t => t.ThamNien >= 6 && t.ThamNien < 12).ToList().Count,
                            Duoi3Nam = g.Where(t => t.ThamNien >= 12 && t.ThamNien < 36).ToList().Count,
                            Tren3Nam = g.Where(t => t.ThamNien >= 36).ToList().Count,
                            HDThuViec = 0,
                            HDChinhThuc = 0,
                        }).ToList();
        foreach (var item in result)
        {
            var row = tinhtoan.Where(t => t.MaPhongBan == item.MaPhongBan).SingleOrDefault();
            if (row != null)
            {
                item.Nam = row.Nam;
                item.Nu = row.Nu;
                item.SauDaiHoc = row.SauDaiHoc;
                item.DaiHoc = row.DaiHoc;
                item.CaoDang = row.CaoDang;
                item.TrungCap = row.TrungCap;
                item.PTTH = row.PTTH;
                item.Khac = row.Khac;
                item.Duoi6Thang = row.Duoi6Thang;
                item.Duoi1Nam = row.Duoi1Nam;
                item.Duoi3Nam = row.Duoi3Nam;
                item.Tren3Nam = row.Tren3Nam;
                item.HDThuViec = 0;
                item.HDChinhThuc = row.Nam + row.Nu;
                item.Tong = row.Nam + row.Nu;
            }
        }
        //xử lý cộng tổng lên
        try
        {

            int i = result.Max(t => t.Level) - 1;
            for (; i >= 1; i--)
            {
                foreach (var item in result)
                {
                    if (item.Level == i)
                    {
                        var t = result.Where(p => p.ParentID == item.MaPhongBan).ToList();
                        item.Nam += t.Sum(p => p.Nam);
                        item.Nu += t.Sum(p => p.Nu);
                        item.SauDaiHoc += t.Sum(p => p.SauDaiHoc);
                        item.DaiHoc += t.Sum(p => p.DaiHoc);
                        item.CaoDang += t.Sum(p => p.CaoDang);
                        item.TrungCap += t.Sum(p => p.TrungCap);
                        item.PTTH += t.Sum(p => p.PTTH);
                        item.Khac += t.Sum(p => p.Khac);
                        item.Duoi6Thang += t.Sum(p => p.Duoi6Thang);
                        item.Duoi1Nam += t.Sum(p => p.Duoi1Nam);
                        item.Duoi3Nam += t.Sum(p => p.Duoi3Nam);
                        item.Tren3Nam += t.Sum(p => p.Tren3Nam);
                        item.HDThuViec += 0;
                        item.HDChinhThuc += t.Sum(p => p.HDChinhThuc);
                        item.Tong += t.Sum(p => p.Tong);
                    }
                }
            }

        }
        catch
        {

        }

        return result.Where(p => p.CaoDang != 0 || p.DaiHoc != 0 || p.Duoi1Nam != 0 || p.Duoi3Nam != 0 || p.Duoi6Thang != 0 || p.HDChinhThuc != 0 || p.HDThuViec != 0 || p.Khac != 0 || p.Nam != 0 || p.Nu != 0 || p.PTTH != 0 || p.SauDaiHoc != 0 || p.Tong != 0 || p.Tren3Nam != 0 || p.TrungCap != 0).ToList();

    }


}