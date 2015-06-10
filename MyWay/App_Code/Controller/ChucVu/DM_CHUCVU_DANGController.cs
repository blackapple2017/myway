using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUCVU_DANGController
/// </summary>
public class DM_CHUCVU_DANGController : LinqProvider
{
	public DM_CHUCVU_DANGController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_CHUCVU_DANG> GetByAll()
    {
        var rs = from t in dataContext.DM_CHUCVU_DANGs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CHUCVU_DANGs
                 select new StoreComboObject
                 {
                     MA = t.MA_CHUCVU_DANG,
                     TEN = t.TEN_CHUCVU_DANG
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
}