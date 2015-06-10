using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NOICAPBAOHIEMXHController
/// </summary>
public class DM_NOICAPBAOHIEMXHController:LinqProvider
{
	public DM_NOICAPBAOHIEMXHController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_NOICAP_BHXH> GetByAll()
    {
        var r = from t in dataContext.DM_NOICAP_BHXHs select t;
        return r.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NOICAP_BHXHs
                 select new StoreComboObject
                 {
                     MA = t.MA_NOICAP_BHXH,
                     TEN = t.TEN_NOICAP_BHXH
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
    public string GetTenByMa(string ma)
    {
        var rs = dataContext.DM_NOICAP_BHXHs.Where(p => p.MA_NOICAP_BHXH == ma).SingleOrDefault();
        if (rs != null) return rs.TEN_NOICAP_BHXH;
        else return "";
    }
}