using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TD_QLKTController
/// </summary>
public class DM_TD_QLKTController : LinqProvider
{
	public DM_TD_QLKTController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_TD_QLKT> GetByAll()
    {
        var rs = from t in dataContext.DM_TD_QLKTs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TD_QLKTs
                 select new StoreComboObject
                 {
                     MA = t.MA_TD_QLKT,
                     TEN = t.TEN_TD_QLKT
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}