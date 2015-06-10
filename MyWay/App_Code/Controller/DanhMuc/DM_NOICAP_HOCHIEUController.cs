using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NOICAP_HOCHIEUController
/// </summary>
public class DM_NOICAP_HOCHIEUController : LinqProvider
{
	public DM_NOICAP_HOCHIEUController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_NOICAP_HOCHIEU> GetByAll()
    {
        var rs = from t in dataContext.DM_NOICAP_HOCHIEUs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NOICAP_HOCHIEUs
                 select new StoreComboObject
                 {
                     MA = t.MA_NOICAP_HOCHIEU,
                     TEN = t.TEN_NOICAP_HOCHIEU
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}