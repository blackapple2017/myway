using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NGANHANGController
/// </summary>
public class DM_NGANHANGController:LinqProvider
{
	public DM_NGANHANGController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_NH> GetByAll()
    {
        var r = from t in dataContext.DM_NHs select t;
        return r.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NHs
                 select new StoreComboObject
                 {
                     MA = t.MA_NH,
                     TEN = t.TEN_NH
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }

    public DAL.DM_NH GetById(string id)
    {
        return dataContext.DM_NHs.SingleOrDefault(t => t.MA_NH == id);
    }
}