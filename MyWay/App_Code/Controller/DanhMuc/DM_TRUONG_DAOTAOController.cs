using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TRUONG_DAOTAOController
/// </summary>
public class DM_TRUONG_DAOTAOController:LinqProvider
{
	public DM_TRUONG_DAOTAOController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_TRUONG_DAOTAO> GetByAll()
    {
        var rs = from t in dataContext.DM_TRUONG_DAOTAOs
                 select t;
        return rs.ToList();

    }

    public List<DM_TRUONGDAOTAOInfo> GetAll()
    {
        var rs = from t in dataContext.DM_TRUONG_DAOTAOs
                 select new DM_TRUONGDAOTAOInfo
                 {
                     MA_TRUONG_DAOTAO = t.MA_TRUONG_DAOTAO,
                     TEN_TRUONG_DAOTAO = t.TEN_TRUONG_DAOTAO
                 };
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_TRUONG_DAOTAOs
                 select new StoreComboObject
                 {
                     MA = t.MA_TRUONG_DAOTAO,
                     TEN = t.TEN_TRUONG_DAOTAO
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }

    public string GetNameByMaTruong(string maTruong)
    {
        var rs = from t in dataContext.DM_TRUONG_DAOTAOs
                 where t.MA_TRUONG_DAOTAO == maTruong
                 select t.TEN_TRUONG_DAOTAO;
        return rs.FirstOrDefault();
    }
}