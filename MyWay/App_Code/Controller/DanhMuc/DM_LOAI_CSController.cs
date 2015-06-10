using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LOAI_CSController
/// </summary>
public class DM_LOAI_CSController : LinqProvider
{
	public DM_LOAI_CSController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_LOAI_C> GetByAll()
    {
        var rs = from t in dataContext.DM_LOAI_Cs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_LOAI_Cs
                 select new StoreComboObject
                 {
                     MA = t.MA_LOAI_CS,
                     TEN = t.TEN_LOAI_CS
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}