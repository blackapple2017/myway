using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUYENNGANHController
/// </summary>
public class DM_CHUYENNGANHController : LinqProvider
{
    public DM_CHUYENNGANHController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Lấy khóa chính dựa vào tên chuyên ngành
    /// </summary>
    /// <param name="TenChuyenNganh"></param>
    /// <returns></returns>
    public string GetPrimaryKeyByName(string TenChuyenNganh)
    {
        var rs = from t in dataContext.DM_CHUYENNGANHs
                 where t.TEN_CHUYENNGANH.Equals(TenChuyenNganh)
                 select t.MA_CHUYENNGANH;
        return rs.FirstOrDefault();
    }
    public string GetNameByPrimaryKey(string MaChuyenNganh)
    {
        var rs = from t in dataContext.DM_CHUYENNGANHs
                 where t.MA_CHUYENNGANH.Equals(MaChuyenNganh)
                 select t.TEN_CHUYENNGANH;
        return rs.FirstOrDefault();
    }
    public List<DAL.DM_CHUYENNGANH> GetByAll()
    {
        var rs = from t in dataContext.DM_CHUYENNGANHs
                 select t;
        return rs.ToList();
    }

    public List<DM_CHUYENNGANHInfo> GetAll()
    {
        var rs = from t in dataContext.DM_CHUYENNGANHs
                 select new DM_CHUYENNGANHInfo
                 {
                     MA_CHUYENNGANH = t.MA_CHUYENNGANH,
                     TEN_CHUYENNGANH = t.TEN_CHUYENNGANH
                 };
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_CHUYENNGANHs
                 select new StoreComboObject
                 {
                     MA = t.MA_CHUYENNGANH,
                     TEN = t.TEN_CHUYENNGANH
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}