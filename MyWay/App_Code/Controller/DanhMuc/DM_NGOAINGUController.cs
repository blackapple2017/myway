using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NGOAINGUController
/// </summary>
public class DM_NGOAINGUController:LinqProvider
{
	public DM_NGOAINGUController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_NGOAINGU> GetByAll()
    {
        var rs = from t in dataContext.DM_NGOAINGUs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NGOAINGUs
                 select new StoreComboObject
                 {
                     MA = t.MA_NGOAINGU,
                     TEN = t.TEN_NGOAINGU
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}