using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TD_VANHOAController
/// </summary>
public class DM_TD_VANHOAController : LinqProvider
{
	public DM_TD_VANHOAController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_TD_VANHOA> GetByAll()
    {
        var rs = from t in dataContext.DM_TD_VANHOAs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TD_VANHOAs
                 select new StoreComboObject
                 {
                     MA = t.MA_TD_VANHOA,
                     TEN = t.TEN_TD_VANHOA
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}