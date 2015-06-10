using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NGACHController
/// </summary>
public class DM_NGACHController : LinqProvider
{
    public DM_NGACHController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetPrimaryKeyByName(string TenNgach)
    {
        var rs = from t in dataContext.DM_NGACHes
                 where t.TEN_NGACH.Equals(TenNgach)
                 select t.MA_NGACH;
        return rs.FirstOrDefault();
    }
    public List<DAL.DM_NGACH> GetByAll()
    {
        var rs = from t in dataContext.DM_NGACHes
                 select t;
        return rs.ToList();
    }

    public List<DM_NGACHInfo> GetAll()
    {
        var rs = from t in dataContext.DM_NGACHes 
                 select new DM_NGACHInfo
                 {
                     MA_NGACH = t.MA_NGACH,
                     TEN_NGACH = t.TEN_NGACH
                 };
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_NGACHes
                 select new StoreComboObject
                 {
                     MA = t.MA_NGACH,
                     TEN = t.TEN_NGACH
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }

    public List<StoreComboObject> GetByMaNhomNgach(string maNhom)
    {
        var rs = from t in dataContext.DM_NGACHes
                 where t.MA_NHOM_NGACH == maNhom
                 select new StoreComboObject
                 {
                     MA = t.MA_NGACH,
                     TEN = t.TEN_NGACH
                 };
        return rs.ToList();
    }

    public int GetMaxBacLuong()
    {
        var rs = from t in dataContext.DM_NHOM_NGACHes
                  select t;
        return rs.OrderByDescending(p => p.SOBAC_TOIDA).FirstOrDefault().SOBAC_TOIDA;
    }

    public DM_NGACHInfo GetByMaNgach(string maNgach)
    {
        var rs = from t in dataContext.DM_NGACHes
                 join n in dataContext.DM_NHOM_NGACHes on t.MA_NHOM_NGACH equals n.MA_NHOM_NGACH into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where t.MA_NGACH == maNgach
                 select new DM_NGACHInfo
                 {
                     MA_NGACH = t.MA_NGACH,
                     TEN_NGACH = t.TEN_NGACH,
                     TEN_NHOM_NGACH = t1.TEN_NHOM_NGACH,
                     MA_NHOM_NGACH = t1.MA_NHOM_NGACH
                 };
        return rs.FirstOrDefault();
    }
}