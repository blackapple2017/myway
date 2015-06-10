using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TP_GIADINHController
/// </summary>
public class DM_TP_GIADINHController : LinqProvider
{
	public DM_TP_GIADINHController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_TP_GIADINH> GetByAll()
    {
        var rs = from t in dataContext.DM_TP_GIADINHs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TP_GIADINHs
                 select new StoreComboObject
                 {
                     MA = t.MA_TP_GIADINH,
                     TEN = t.TEN_TP_GIADINH
                 };
        return rs.ToList();
    }
}