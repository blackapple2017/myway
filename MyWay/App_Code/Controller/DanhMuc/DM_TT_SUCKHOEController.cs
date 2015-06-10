using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TT_SUCKHOEController
/// </summary>
public class DM_TT_SUCKHOEController : LinqProvider
{
	public DM_TT_SUCKHOEController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_TT_SUCKHOE> GetByAll()
    {
        var rs = from t in dataContext.DM_TT_SUCKHOEs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TT_SUCKHOEs
                 select new StoreComboObject
                 {
                     MA = t.MA_TT_SUCKHOE,
                     TEN = t.TEN_TT_SUCKHOE
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}