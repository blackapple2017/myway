using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NOICAP_CMNDController
/// </summary>
public class DM_NOICAP_CMNDController : LinqProvider
{
	public DM_NOICAP_CMNDController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_NOICAP_CMND> GetByAll()
    {
        var rs = from t in dataContext.DM_NOICAP_CMNDs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NOICAP_CMNDs
                 select new StoreComboObject
                 {
                     MA = t.MA_NOICAP_CMND,
                     TEN = t.TEN_NOICAP_CMND
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
    public string GetTenByMa(string ma)
    {
        var rs = dataContext.DM_NOICAP_CMNDs.Where(p => p.MA_NOICAP_CMND == ma).SingleOrDefault();
        if (rs != null) return rs.TEN_NOICAP_CMND;
        else return "";
    }
}
