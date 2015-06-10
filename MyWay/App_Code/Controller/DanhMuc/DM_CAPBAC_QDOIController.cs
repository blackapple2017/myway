using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CAPBAC_QDOIController
/// </summary>
public class DM_CAPBAC_QDOIController : LinqProvider
{
	public DM_CAPBAC_QDOIController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_CAPBAC_QDOI> GetByAll()
    {
        var rs = from t in dataContext.DM_CAPBAC_QDOIs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CAPBAC_QDOIs
                 select new StoreComboObject
                 {
                     MA = t.MA_CAPBAC_QDOI,
                     TEN = t.TEN_CAPBAC_QDOI
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}