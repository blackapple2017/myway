using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LYDO_NGHIController
/// </summary>
public class DM_LYDO_NGHIController:LinqProvider
{
	public DM_LYDO_NGHIController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_LYDO_NGHI> GetByAll()
    {
        var rs = from t in dataContext.DM_LYDO_NGHIs
                 select t;
        return rs.ToList();     
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_LYDO_NGHIs
                 select new StoreComboObject
                 {
                     MA = t.MA_LYDO_NGHI,
                     TEN = t.TEN_LYDO_NGHI
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}