using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUCVU_DOANController
/// </summary>
public class DM_CHUCVU_DOANController : LinqProvider
{
	public DM_CHUCVU_DOANController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_CHUCVU_DOAN> GetByAll()
    {
        var rs = from t in dataContext.DM_CHUCVU_DOANs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CHUCVU_DOANs
                 select new StoreComboObject
                 {
                     MA = t.MA_CHUCVU_DOAN,
                     TEN = t.TEN_CHUCVU_DOAN
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}