using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUCVU_QDOIController
/// </summary>
public class DM_CHUCVU_QDOIController : LinqProvider
{
	public DM_CHUCVU_QDOIController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_CHUCVU_QDOI> GetByAll()
    {
        var rs = from t in dataContext.DM_CHUCVU_QDOIs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CHUCVU_QDOIs
                 select new StoreComboObject
                 {
                     MA = t.MA_CHUCVU_QDOI,
                     TEN = t.TEN_CHUCVU_QDOI
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}