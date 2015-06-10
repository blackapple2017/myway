using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExtMessage;
using System.Collections;
using System.Data;
/// <summary>
/// Summary description for TinhVaTrich
/// </summary>
public class TinhVaTrichController : LinqProvider
{
    public TinhVaTrichController()
    {

    }

    public List<ThangTrichBHInfo> GetThangTrich(string madonvi, int start, int limit, out int count)
    {
        var rs = (
                  from t in dataContext.BangThanhToanLuongs.GroupBy(p => p.IdBangLuong)
                  join q in dataContext.DanhSachBangLuongs on t.Key equals q.ID
                  orderby q.Year descending, q.Month descending
                  select new ThangTrichBHInfo
                  {
                      IDBangLuong = q.ID,
                      TenBangLuong = q.Title,
                      DaKhoa = q.DaKhoa,
                      ThangNam = q.Month + q.Year * 12,
                      SoNhanVien = t.Count(),
                      TienDonViTrich = t.Sum(p => p.DVBHTN + p.DVBHXH + p.DVBHYT),
                      TienNhanVienTrich = t.Sum(p => p.GiamTruBHTN + p.GiamTruBHYT + p.GiamTruBHXH),
                      TongTien = t.Sum(p => p.DVBHTN + p.DVBHXH + p.DVBHYT + p.GiamTruBHTN + p.GiamTruBHYT + p.GiamTruBHXH)
                  }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
    public int TinhVaTrichLuongThang(int idbangluong, bool checkSoNgayDiLam)
    {
        int count = 0;
        var bangluong = dataContext.DanhSachBangLuongs.Where(p => p.ID == idbangluong).FirstOrDefault();
        DateTime thangnam = new DateTime(bangluong.Year, bangluong.Month, 1).AddMonths(-1);
        string[] listnvbangluong = dataContext.BangThanhToanLuongs.Where(p => p.IdBangLuong == idbangluong).Select(p => p.MaCB).ToArray();
        var mucdongbh = (from t in dataContext.BHMUCDONGBAOHIEMs
                         where t.NgayHieuLuc <= thangnam
                         orderby t.NgayHieuLuc descending
                         select t).FirstOrDefault();
        var listNhanVienDuocDong = (from t in dataContext.TongHopCongs
                                    join q in dataContext.BHNHANVIEN_BAOHIEMs on t.MA_CB equals q.MaNhanVien
                                    join x in dataContext.DanhSachBangTongHopCongs on t.IdDanhSachBangTongHopCong equals x.ID
                                    where 
                                    //(!checkSoNgayDiLam || ((thangnam.Month == x.FromDate.Month) && (thangnam.Year == x.FromDate.Year) && t.GioCongThucTe >= 14))
                                 //   && 
                                    listnvbangluong.Contains(q.MaNhanVien)
                                    select new
                                    {
                                        q.IDNhanVien_BaoHiem,
                                        MaNhanVien = q.MaNhanVien,
                                        HoTen = q.HoTen,
                                        LuongBaoHiem = q.LuongBaoHiem,
                                        TongPhuCap = q.PhuCapCV + q.PhuCapKhac + q.PhuCapTNN + q.PhuCapTNVK,
                                        q.DangDongBHYT,
                                        q.DangDongBHXH,
                                        q.DangDongBHTN
                                    }).ToList();

        foreach (var item in listNhanVienDuocDong)
        {
            decimal luongBHXH = 0, luongBHYT = 0, LuongBHTN = 0;
            if (item.LuongBaoHiem > mucdongbh.TranBHXH)
                luongBHXH = mucdongbh.TranBHXH;
            else if (item.LuongBaoHiem < mucdongbh.SanBHXH)
                luongBHXH = mucdongbh.SanBHXH;
            else luongBHXH = item.LuongBaoHiem;

            if (item.LuongBaoHiem > mucdongbh.TranBHYT)
                luongBHYT = mucdongbh.TranBHYT;
            else if (item.LuongBaoHiem < mucdongbh.SanBHYT)
                luongBHYT = mucdongbh.SanBHYT;
            else luongBHYT = item.LuongBaoHiem;

            if (item.LuongBaoHiem > mucdongbh.TranBHTN)
                LuongBHTN = mucdongbh.TranBHTN;
            else if (item.LuongBaoHiem < mucdongbh.SanBHTN)
                LuongBHTN = mucdongbh.SanBHTN;
            else LuongBHTN = item.LuongBaoHiem;

            if (!item.DangDongBHTN) LuongBHTN = 0;
            if (!item.DangDongBHYT) luongBHYT = 0;
            if (!item.DangDongBHXH) luongBHXH = 0;


            DAL.BangThanhToanLuong dong = dataContext.BangThanhToanLuongs.Where(p => p.MaCB == item.MaNhanVien && p.IdBangLuong == idbangluong).FirstOrDefault();
            dong.DVBHTN = (double)(LuongBHTN * mucdongbh.DVBHTN / 100);
            dong.DVBHXH = (double)(luongBHXH * mucdongbh.DVBHXH / 100);
            dong.DVBHYT = (double)(luongBHYT * mucdongbh.DVBHYT / 100);
            dong.GiamTruBHTN = (double)(LuongBHTN * mucdongbh.NVBHTN / 100);
            dong.GiamTruBHXH = (double)(luongBHXH * mucdongbh.NVBYXH / 100);
            dong.GiamTruBHYT = (double)(luongBHYT * mucdongbh.NVBHYT / 100);
            dataContext.SubmitChanges();
            count++;

        }

        return count;
    }
    public bool CheckSoBanGhiThem(string madonvi, DateTime thangnam)
    {
        var rs = (from t in dataContext.BHDONGBAOHIEMTHANGs
                  where t.MaDonVi == madonvi && t.TuNgay.Month == thangnam.Month
                  && t.TuNgay.Year == thangnam.Year
                  select new
                  {
                      t.IDDongBaoHiemThang
                  }).ToList();
        if (rs.Count > 0) return true;
        else return false;
    }
    public bool XoaThangNam(string madonvi, int thangnam)
    {
        try
        {
            var litem = (from t in dataContext.BHDONGBAOHIEMTHANGs
                         where t.TuNgay.Month == thangnam % 12 && t.TuNgay.Year == thangnam / 12
                         select t).ToList();
            dataContext.BHDONGBAOHIEMTHANGs.DeleteAllOnSubmit(litem);
            Save();
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }

    public void UpdateTienTrichBH(int id, double nvbhxh, double nvbhyt, double nvbhtn, double dvbhxh, double dvbhyte, double dvbhtn)
    {
        var item = dataContext.BangThanhToanLuongs.Where(p => p.ID == id).FirstOrDefault();
        item.GiamTruBHXH = nvbhxh;
        item.GiamTruBHYT = nvbhyt;
        item.GiamTruBHTN = nvbhtn;
        item.DVBHXH = dvbhxh;
        item.DVBHYT = dvbhyte;
        item.DVBHTN = dvbhtn;
        Save();
    }
}