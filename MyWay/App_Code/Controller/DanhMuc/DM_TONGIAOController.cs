using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TONGIAOController
/// </summary>
public class DM_TONGIAOController:LinqProvider
{
	public DM_TONGIAOController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_TONGIAO> GetByAll()
    {
        var rs = from t in dataContext.DM_TONGIAOs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TONGIAOs
                 select new StoreComboObject
                 {
                     MA = t.MA_TONGIAO,
                     TEN = t.TEN_TONGIAO
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}