using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CONGTRINHController
/// </summary>
public class DM_CONGTRINHController:LinqProvider
{
	public DM_CONGTRINHController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_CONGTRINH> GetByAll()
    {
        var rs = from t in dataContext.DM_CONGTRINHs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CONGTRINHs
                 select new StoreComboObject
                 {
                     MA = t.MA_CONGTRINH,
                     TEN = t.TEN_CONGTRINH
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}