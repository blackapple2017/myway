using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NUOCController
/// </summary>
public class DM_NUOCController:LinqProvider
{
	public DM_NUOCController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_NUOC> GetByAll()
    {
        var rs = from t in dataContext.DM_NUOCs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NUOCs
                 select new StoreComboObject
                 {
                     MA = t.MA_NUOC,
                     TEN = t.TEN_NUOC
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}