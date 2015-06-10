using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
/// <summary>
/// Summary description for BHDONGBAOHIEMTHANGControllor
/// </summary>
public class BHDONGBAOHIEMTHANGControllor : LinqProvider
{
    public BHDONGBAOHIEMTHANGControllor()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<BHDONGBAOHIEMTHANGInfo> GetBHDONGBAOHIEMTHANG(string madonvi, int idbangluong, bool locquanlyBH, int start, int limit, string searkey, out int count)
    {
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        string[] s2 = dataContext.BHNHANVIEN_BAOHIEMs.Select(p => p.MaNhanVien).ToArray();
        List<BHDONGBAOHIEMTHANGInfo> rs = (from p in dataContext.DanhSachBangLuongs.Where(p => p.ID == idbangluong)
                                           join q in dataContext.BangThanhToanLuongs on p.ID equals q.IdBangLuong
                                           join h in dataContext.HOSOs on q.MaCB equals h.MA_CB
                                           where (madonvi != "" ? s1.Contains(h.MA_DONVI) : 1 == 1)
                                           && (string.IsNullOrEmpty(searkey) ? 1 == 1 : System.Data.Linq.SqlClient.SqlMethods.Like(h.HO_TEN, searkey) || System.Data.Linq.SqlClient.SqlMethods.Like(h.MA_CB, searkey))
                                           && (!locquanlyBH || s2.Contains(h.MA_CB))
                                           orderby h.TEN_CB, h.HO_TEN
                                           select new BHDONGBAOHIEMTHANGInfo
                                           {
                                               ID = q.ID,
                                               SoTienDVBHTN = q.DVBHTN,
                                               SoTienDVBHXH = q.DVBHXH,
                                               SoTienDVBHYT = q.DVBHYT,
                                               SoTienNVBHTN = q.GiamTruBHTN,
                                               SoTienNVBHXH = q.GiamTruBHXH,
                                               SoTienNVBHYT = q.GiamTruBHYT,
                                               HoTen = h.HO_TEN,
                                               MaNhanVien = h.MA_CB,
                                               LuongDongBH = q.LuongBaoHiem,
                                               TongTienDongBHNV = q.GiamTruBHTN + q.GiamTruBHXH + q.GiamTruBHYT,
                                               TongTienDongBHDV = q.DVBHTN + q.DVBHXH + q.DVBHYT,
                                               TongCong = q.GiamTruBHTN + q.GiamTruBHXH + q.GiamTruBHYT + q.DVBHTN + q.DVBHXH + q.DVBHYT
                                           }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
    public List<BHDONGBAOHIEMTHANG> GetNhanVien_BaoHiemByMaNhanVien(int IdNhanVien_BH)
    {
        return dataContext.BHDONGBAOHIEMTHANGs.Where(p => p.IDNhanVien_BaoHiem == IdNhanVien_BH).ToList();
    }
    public List<BHDONGBAOHIEMTHANG> GetNhanVien_BaoHiemByThang(DateTime tungay, int id)
    {
        var rs = from p in dataContext.BHDONGBAOHIEMTHANGs
                 where (p.IDNhanVien_BaoHiem == id) && (p.TuNgay <= tungay)
                 select p;
        return rs.ToList();
    }
    public DAL.BHDONGBAOHIEMTHANG GetLuongThangLienKeByNgay(DateTime tungay, int idnhanvien)
    {
        var rs = (from p in dataContext.BHDONGBAOHIEMTHANGs where (Convert.ToDateTime(p.TuNgay) == tungay) && p.IDNhanVien_BaoHiem == idnhanvien select p).FirstOrDefault();
        return rs;
    }
}