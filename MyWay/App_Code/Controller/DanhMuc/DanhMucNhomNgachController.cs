using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhMucNhomNgachController
/// </summary>
public class DanhMucNhomNgachController : LinqProvider
{
	public DanhMucNhomNgachController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DAL.DM_NHOM_NGACH GetByID(string id)
    {
        var rs = from t in dataContext.DM_NHOM_NGACHes
                 where t.MA_NHOM_NGACH == id
                 select t;
        return rs.FirstOrDefault();
    }

    public List<StoreComboObject> GetByAll()
    {
        var rs = from t in dataContext.DM_NHOM_NGACHes
                 select new StoreComboObject
                 {
                     MA = t.MA_NHOM_NGACH,
                     TEN = t.TEN_NHOM_NGACH
                 };
        return rs.ToList();
    }

    public DAL.DM_NHOM_NGACH GetByMaNgach(string maNgach)
    {
        var rs = from t in dataContext.DM_NGACHes
                 join p in dataContext.DM_NHOM_NGACHes on t.MA_NHOM_NGACH equals p.MA_NHOM_NGACH into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where t.MA_NGACH == maNgach
                 select t1;
        return rs.FirstOrDefault();
    }
}