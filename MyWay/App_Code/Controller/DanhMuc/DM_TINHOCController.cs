using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TINHOCController
/// </summary>
public class DM_TINHOCController : LinqProvider
{
	public DM_TINHOCController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_TINHOC> GetByAll()
    {
        var rs = from t in dataContext.DM_TINHOCs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TINHOCs
                 select new StoreComboObject
                 {
                     MA = t.MA_TINHOC,
                     TEN = t.TEN_TINHOC
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}