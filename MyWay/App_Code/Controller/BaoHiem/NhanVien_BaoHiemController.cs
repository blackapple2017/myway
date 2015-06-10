using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
/// <summary>
/// Summary description for NhanVien_BaoHiemController
/// </summary>
public class NhanVien_BaoHiemController : LinqProvider
{
    public NhanVien_BaoHiemController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public BHNHANVIEN_BAOHIEM GetNhanVien_BaoHiemByMaNhanVien(string manhanvien)
    {
        return dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.MaNhanVien == manhanvien).SingleOrDefault();
    }
    public BHNHANVIEN_BAOHIEM GetNhanVien_BaoHiemByIDNhanVien_BaoHiem(int IDNhanVien_BaoHiem)
    {
        return dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.IDNhanVien_BaoHiem == IDNhanVien_BaoHiem).SingleOrDefault();
    }
    public BHNHANVIEN_BAOHIEM GetNhanVien_BaoHiemByMaNhanVien(int IdNhanVien_BH)
    {
        return dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.IDNhanVien_BaoHiem == IdNhanVien_BH).SingleOrDefault();
    }
    public void UpdateNhanVien_BaoHiem(BHNHANVIEN_BAOHIEM nvbh)
    {
        BHNHANVIEN_BAOHIEM item = dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.IDNhanVien_BaoHiem == nvbh.IDNhanVien_BaoHiem).SingleOrDefault();
        //item = nvbh;
        item.DangDongBHTN = nvbh.DangDongBHTN;
        item.DangDongBHXH = nvbh.DangDongBHXH;
        item.DangDongBHYT = nvbh.DangDongBHYT;
        item.LuongBaoHiem = nvbh.LuongBaoHiem;
        item.PhuCapCV = nvbh.PhuCapCV;
        item.PhuCapKhac = nvbh.PhuCapKhac;
        item.PhuCapTNN = nvbh.PhuCapTNN;
        item.PhuCapTNVK = nvbh.PhuCapTNVK;
        item.DaNghi = nvbh.DaNghi;
        item.TrangThaiCapTheBHYT = nvbh.TrangThaiCapTheBHYT;
        item.TrangThaiCapSoBHXH = nvbh.TrangThaiCapSoBHXH;
        Save();

        HOSO hs = dataContext.HOSOs.Where(p => p.PR_KEY == (decimal)item.IDNhanVien_BaoHiem).SingleOrDefault();
        hs.SOTHE_BHXH = nvbh.SoSoBHXH;
        hs.SOTHE_BHYT = nvbh.SoTheBHYT;
        hs.NGAY_DONGBH = nvbh.TuThangBHYT;
        hs.NGAY_HETHAN_BHYT = nvbh.DenThangBHYT;
        hs.MA_NOI_KCB = nvbh.NoiDangKyKCB;
        hs.NGAYCAP_BHXH = nvbh.NgayDangKyBHXH;
        hs.MA_NOICAP_BHXH = nvbh.NoiCapSoBHXH;
        Save();
    }
    public void UpdateNhanVien_BaoHiem_IdNHanVienBH(BHNHANVIEN_BAOHIEM nvbh)
    {
        BHNHANVIEN_BAOHIEM item = dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.IDNhanVien_BaoHiem == nvbh.IDNhanVien_BaoHiem).SingleOrDefault();
        item = nvbh;
        Save();
    }
    public List<BHNHANVIEN_BAOHIEMInfo> GetHoSoInfoByMaDonVi(string madonvi, string maphong, string mato, int start, int limit, out int count, string searchkey, bool IsDaNghi)
    {
        DM_DONVI dv = new DM_DONVIController().GetById(madonvi);
        List<BHNHANVIEN_BAOHIEMInfo> rs1 = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                                            join q in dataContext.HOSOs on t.MaNhanVien equals q.MA_CB
                                            where (string.IsNullOrEmpty(madonvi) ? 1 == 1 : t.MaDonVi == madonvi)
                                                   && (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)
                                                       || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaNhanVien, searchkey)
                                                       || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoSoBHXH, searchkey)
                                                       || System.Data.Linq.SqlClient.SqlMethods.Like(t.SoTheBHYT, searchkey)))
                                            orderby t.Ten, t.HoTen
                                            select new BHNHANVIEN_BAOHIEMInfo
                                            {
                                                MaNhanVien = t.MaNhanVien,
                                                HoTen = t.HoTen,
                                                NgaySinh = t.NgaySinh,
                                                GioiTinh = t.GioiTinh,
                                                SoCMTND = t.SoCMTND,
                                                DiaChiLienHe = t.DiaChiLienHe

                                            }

                                       ).ToList();
        count = rs1.Count();
        return rs1.Skip(start).Take(limit).ToList();
    }
    public int TinhSoThangDongBaoHiem(int idNhanVien, int ThoiGianDongTruoc)
    {
        var macb = new NhanVien_BaoHiemController().GetMaCBByIDNhanVienBH(idNhanVien);
        var rs = (from t in dataContext.BangThanhToanLuongs
                  where t.MaCB == macb
                  select t).ToList();
        return ThoiGianDongTruoc + rs.Count;
    }

    public string GetMaCBByIDNhanVienBH(int idnhanvienbaohiem)
    {
        var nhanvien = dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.IDNhanVien_BaoHiem == idnhanvienbaohiem).FirstOrDefault();
        if (nhanvien != null) return nhanvien.MaNhanVien;
        else return "";
    }


    public List<BHNHANVIEN_BAOHIEMLiteInfo> GetNhanVienBaoHiemCBBSearch(string MaDonVi, int start, int limit, string searchkey, out int count)
    {
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(MaDonVi).Split(',');
        var rs = (from t in dataContext.BHNHANVIEN_BAOHIEMs
                  join q in dataContext.HOSOs on t.MaNhanVien equals q.MA_CB
                  join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI into tq
                  from abc in tq.DefaultIfEmpty()
                  where (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(t.HoTen, searchkey)))
                  && s1.Contains(t.MaDonVi)
                  select new BHNHANVIEN_BAOHIEMLiteInfo
                  {
                      HoTen = t.HoTen,
                      MaNhanVien = t.MaNhanVien,
                      NgaySinh = t.NgaySinh,
                      PR_KEY = t.IDNhanVien_BaoHiem,
                      SoSoBHXH = t.SoSoBHXH,
                      SoTheBHYT = t.SoTheBHYT,
                      TenPhong = abc != null ? abc.TEN_DONVI : "",
                  }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();

    }
    public void DeleteNhanVienBH(string maNhanVien)
    {
        DAL.BHNHANVIEN_BAOHIEM tmp = dataContext.BHNHANVIEN_BAOHIEMs.SingleOrDefault(t => t.MaNhanVien == maNhanVien);
        if (tmp != null)
        {
            var bdbh = dataContext.BHBIENDONGBAOHIEMs.Where(t => t.IDNhanVien_BaoHiem == tmp.IDNhanVien_BaoHiem);
            if (bdbh != null)
            {
                dataContext.BHBIENDONGBAOHIEMs.DeleteAllOnSubmit(bdbh);
            }
            var cdbh = dataContext.BHCHITIETCHEDOBAOHIEMs.Where(t => t.IDNhanVien_BaoHiem == tmp.IDNhanVien_BaoHiem);
            if (cdbh != null)
            {
                dataContext.BHCHITIETCHEDOBAOHIEMs.DeleteAllOnSubmit(cdbh);
            }
            dataContext.BHNHANVIEN_BAOHIEMs.DeleteOnSubmit(tmp);
            Save();
        }
    }
}