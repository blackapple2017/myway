using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for ChartController
/// </summary>
public class ChartController : LinqProvider
{
    public ChartController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void GetGenderNumber(out int Male, out int Female, string maDV, int userID, int menuID)
    {
        string[] ds = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(','); //new DM_DONVIController().GetAllMaDonVi(maDV).Split(',');
        Male = (from t in dataContext.HOSOs
                where t.MA_GIOITINH == "M" && (t.DA_NGHI.Value == false || t.DA_NGHI == null)
                    && ds.Contains(t.MA_DONVI)
                select t.MA_GIOITINH).Count();
        Female = (from t in dataContext.HOSOs
                  where t.MA_GIOITINH == "F" && (t.DA_NGHI.Value == false || t.DA_NGHI == null)
                    && ds.Contains(t.MA_DONVI)
                  select t.MA_GIOITINH).Count();
    }

    public string[] GetListMaDonVi(string dsDonVi)
    {
        string[] lists = dsDonVi.Split(',');
        List<string> ds = new List<string>();
        foreach (var item in lists)
        {
            if (!ds.Contains(item))
            {
                string[] tmp = new DM_DONVIController().GetAllMaDonVi(item).Split(',');
                foreach (var it in tmp)
                {
                    if (!ds.Contains(it))
                        ds.Add(it);
                }
            }
        }
        return ds.ToArray();
    }

    public List<NhanSu> GetBaoCaoGioiTinhTheoDonVi(string dsDonVi, int userID, int menuID)
    {
        string[] lists = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(','); //GetListMaDonVi(dsDonVi);
        var rs = from t in dataContext.HOSOs
                 join d in dataContext.DM_DONVIs on t.MA_DONVI equals d.MA_DONVI into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where lists.Contains(t.MA_DONVI) && (t.DA_NGHI == false || t.DA_NGHI == null)
                 select new NhanSu
                 {
                     MaDonVi = t.MA_DONVI,
                     MaGioiTinh = t.MA_GIOITINH,
                     TenDonVi = t1.TEN_DONVI
                 };
        return rs.ToList();
    }

    public List<Int32> GetDanhSachNam(string maDV)
    {
        var rs = (from t in dataContext.HOSOs
                  let nam = t.NGAY_TUYEN_DTIEN.Value.Year
                  where t.MA_DONVI == maDV && nam != null
                  select nam).Distinct();
        return rs.ToList();
    }

    //public List<ThongKeQuocTichInfo> GetThongKeQuocTich(string maDV)
    //{
    //    string[] ds = new DM_DONVIController().GetAllMaDonVi(maDV).Split(',');
    //    var rs = from t in dataContext.DM_NUOCs
    //             join x in dataContext.HOSOs on t.MA_NUOC equals x.MA_NUOC
    //             where (x.DA_NGHI.HasValue == false || x.DA_NGHI.Value == false)
    //                && ds.Contains(x.MA_DONVI)
    //             group t by new
    //             {
    //                 t.TEN_NUOC,
    //             }
    //                 into grouped
    //                 select new ThongKeQuocTichInfo
    //                 {
    //                     TenNuoc = grouped.Key.TEN_NUOC,
    //                     Soluong = grouped.Count(),
    //                 };
    //    return rs.ToList();
    //}

    public List<ThongKeDoTuoi> GetDanhSachDoTuoi(string maDV, int userID, int menuID)
    {
        string[] ds = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(','); //new DM_DONVIController().GetAllMaDonVi(maDV).Split(',');
        var rs = from t in dataContext.HOSOs
                 let years = DateTime.Now.Year - t.NGAY_SINH.Value.Year
                 where years != null && (t.DA_NGHI.Value == false || t.DA_NGHI == null)
                    && ds.Contains(t.MA_DONVI)
                 select new ThongKeDoTuoi
                 {
                     Tuoi = years,
                     MaGioiTinh = t.MA_GIOITINH,
                 };
        return rs.ToList();
    }

    public List<BienDongNhanSu> GetBienDongNhanSu(string maDV, int cur_year, int userID, int menuID)
    {
        string[] ds = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(','); //new DM_DONVIController().GetAllMaDonVi(maDV).Split(',');
        var rs = from t in dataContext.HOSOs
                 let daNghi = t.DA_NGHI == null ? false : t.DA_NGHI.Value
                 where t.NGAY_TUYEN_DTIEN != null && daNghi == false
                    && t.NGAY_TUYEN_DTIEN.Value.Year <= cur_year
                    && ds.Contains(t.MA_DONVI)
                 select new BienDongNhanSu
                 {
                     keys = t.PR_KEY,
                     ngayNghi = t.NGAY_NGHI == null ? DateTime.Parse("1900-01-01") : t.NGAY_NGHI.Value,
                     ngayTuyenDTien = t.NGAY_TUYEN_DTIEN.Value,
                     daNghi = daNghi,
                 };
        return rs.ToList();
    }
}