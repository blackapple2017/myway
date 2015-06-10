using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TD_QUANLYController
/// </summary>
public class DM_TD_QUANLYController : LinqProvider
{
	public DM_TD_QUANLYController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_TD_QUANLY> GetByAll()
    {
        var rs = from t in dataContext.DM_TD_QUANLies
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TD_QUANLies
                 select new StoreComboObject
                 {
                     MA = t.MA_TD_QUANLY,
                     TEN = t.TEN_TD_QUANLY
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}