using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_DANTOCController
/// </summary>
public class DM_DANTOCController:LinqProvider
{
	public DM_DANTOCController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_DANTOC> GetByAll()
    {
        var rs = from t in dataContext.DM_DANTOCs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_DANTOCs
                 select new StoreComboObject
                 {
                     MA = t.MA_DANTOC,
                     TEN = t.TEN_DANTOC
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}