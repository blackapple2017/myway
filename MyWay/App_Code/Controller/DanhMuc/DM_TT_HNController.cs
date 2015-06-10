using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DM_TT_HNController
/// </summary>
public class DM_TT_HNController : LinqProvider
{
	public DM_TT_HNController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DM_TT_HN> GetByAll()
    {
        var rs = from t in dataContext.DM_TT_HNs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TT_HNs
                 select new StoreComboObject()
                 {
                     MA = t.MA_TT_HN,
                     TEN = t.TEN_TT_HN
                 };
        return rs.ToList();
    }
}