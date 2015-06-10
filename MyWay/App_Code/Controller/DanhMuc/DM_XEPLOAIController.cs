using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_XEPLOAIController
/// </summary>
public class DM_XEPLOAIController : LinqProvider
{
	public DM_XEPLOAIController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DM_XEPLOAIInfo> GetAll()
    {
        var rs = from t in dataContext.DM_XEPLOAIs
                 select new DM_XEPLOAIInfo
                 {
                     MA_XEPLOAI = t.MA_XEPLOAI,
                     TEN_XEPLOAI = t.TEN_XEPLOAI
                 };
        return rs.ToList();
    }

    public List<DAL.DM_XEPLOAI> GetByAll()
    {
        var rs = from t in dataContext.DM_XEPLOAIs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_XEPLOAIs
                 select new StoreComboObject
                 {
                     MA = t.MA_XEPLOAI,
                     TEN = t.TEN_XEPLOAI
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}