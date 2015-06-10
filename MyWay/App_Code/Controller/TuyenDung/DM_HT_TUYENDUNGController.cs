using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_HT_TUYENDUNGController
/// </summary>
public class DM_HT_TUYENDUNGController : LinqProvider
{
	public DM_HT_TUYENDUNGController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_HT_TUYENDUNG> GetByAll()
    {
        var rs = from t in dataContext.DM_HT_TUYENDUNGs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_HT_TUYENDUNGs
                 select new StoreComboObject
                 {
                     MA = t.MA_HT_TUYENDUNG,
                     TEN = t.TEN_HT_TUYENDUNG
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}