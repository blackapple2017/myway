using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TD_CHINHTRIController
/// </summary>
public class DM_TD_CHINHTRIController : LinqProvider
{
	public DM_TD_CHINHTRIController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_TD_CHINHTRI> GetByAll()
    {
        var rs = from t in dataContext.DM_TD_CHINHTRIs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TD_CHINHTRIs
                 select new StoreComboObject
                 {
                     MA = t.MA_TD_CHINHTRI,
                     TEN = t.TEN_TD_CHINHTRI
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}