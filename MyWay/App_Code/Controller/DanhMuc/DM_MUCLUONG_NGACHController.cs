using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_MUCLUONG_NGACHController
/// </summary>
public class DM_MUCLUONG_NGACHController : LinqProvider
{
    public DM_MUCLUONG_NGACHController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Insert(DAL.DM_MUCLUONG_NGACH ngach)
    {
        if (ngach != null)
        {
            dataContext.DM_MUCLUONG_NGACHes.InsertOnSubmit(ngach);
            Save();
        }
    }

    public void Update(DAL.DM_MUCLUONG_NGACH ngach)
    {
        var tmp = dataContext.DM_MUCLUONG_NGACHes.SingleOrDefault(t => t.PR_KEY == ngach.PR_KEY);
        if (tmp != null)
        {
            tmp.MA_NHOM_NGACH = ngach.MA_NHOM_NGACH;
            tmp.MA_NGACH = ngach.MA_NGACH;
            tmp.BAC_LUONG = ngach.BAC_LUONG;
            tmp.CAP = ngach.CAP;
            tmp.HS_LUONG = ngach.HS_LUONG;
            tmp.MUC_LUONG = ngach.MUC_LUONG;
            tmp.GHI_CHU = ngach.GHI_CHU;

            Save();
        }
    }

    public void Delete(decimal prkey)
    {
        DAL.DM_MUCLUONG_NGACH tmp = dataContext.DM_MUCLUONG_NGACHes.SingleOrDefault(t => t.PR_KEY == prkey);
        if (tmp != null)
        {
            dataContext.DM_MUCLUONG_NGACHes.DeleteOnSubmit(tmp);
            Save();
        }
    }

    public List<DM_MUCLUONG_NGACHInfo> GetAllRecord(int start, int limit, string maDonVi, string searchKey, out int count)
    {
        var rs = from t in dataContext.DM_MUCLUONG_NGACHes
                 join n in dataContext.DM_NGACHes on t.MA_NGACH equals n.MA_NGACH into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where t.MA_DONVI == maDonVi 
                    && (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t1.TEN_NGACH, searchKey) || 
                        System.Data.Linq.SqlClient.SqlMethods.Like(t.MA_NGACH, searchKey))
                 select new DM_MUCLUONG_NGACHInfo()
                 {
                     MaNgach = t.MA_NGACH,
                     TenNgach = t1.TEN_NGACH,
                     MaNhomNgach = t.MA_NHOM_NGACH,
                     //TenNhomNgach = t.DM_NHOM_NGACH.TEN_NHOM_NGACH,
                     BacLuong = t.BAC_LUONG,
                     HeSoLuong = t.HS_LUONG,
                     MucLuong = t.MUC_LUONG,
                     Cap = t.CAP
                 };
        count = rs.ToList().Count;
        return rs.OrderBy(t => t.MaNgach).Skip(start).Take(limit).ToList();
    }

    public DM_MUCLUONG_NGACHInfo GetByMaNgachAndBacLuong(string maNgach, int bac)
    {
        var rs = from t in dataContext.DM_MUCLUONG_NGACHes
                 where t.MA_NGACH == maNgach && t.BAC_LUONG == bac
                 select new DM_MUCLUONG_NGACHInfo()
                 {
                     BacLuong = t.BAC_LUONG,
                     Cap = t.CAP,
                     CreatedDate = t.DATE_CREATE.Value,
                     GhiChu = t.GHI_CHU,
                     HeSoLuong = t.HS_LUONG,
                     MaNgach = t.MA_NGACH,
                     MaNhomNgach = t.MA_NHOM_NGACH,
                     MucLuong = t.MUC_LUONG,
                     PR_KEY = t.PR_KEY,
                     TenNgach = t.DM_NGACH == null ? "" : t.DM_NGACH.TEN_NGACH,
                     TenNhomNgach = t.DM_NHOM_NGACH == null ? "" : t.DM_NHOM_NGACH.TEN_NHOM_NGACH,
                     UserName = t.USERNAME
                 };
        return rs.FirstOrDefault();
    }

    public List<int> GetExistBacLuong(string maNgach)
    {
        var rs = from t in dataContext.DM_MUCLUONG_NGACHes
                  where t.MA_NGACH == maNgach
                  select t.BAC_LUONG.Value;
        return rs.ToList();
    }

    public DAL.DM_MUCLUONG_NGACH GetByNhomNgachBacNgach(string maNhomNgach, string maNgach, int bac)
    {
        var rs = from t in dataContext.DM_MUCLUONG_NGACHes
                 where t.MA_NHOM_NGACH == maNhomNgach
                    && t.MA_NGACH == maNgach
                    && t.BAC_LUONG == bac
                 select t;
        return rs.FirstOrDefault();
    }
}