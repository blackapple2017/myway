using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DM_TP_BANTHANController
/// </summary>
public class DM_TP_BANTHANController : LinqProvider
{
	public DM_TP_BANTHANController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DM_TP_BANTHAN> GetByAll()
    {
        var rs = from t in dataContext.DM_TP_BANTHANs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TP_BANTHANs
                 select new StoreComboObject()
                 {
                     MA = t.MA_TP_BANTHAN,
                     TEN = t.TEN_TP_BANTHAN
                 };
        return rs.ToList();
    }
}