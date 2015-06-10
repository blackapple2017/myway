using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_HT_DAOTAOController
/// </summary>
public class DM_HT_DAOTAOController : LinqProvider
{
	public DM_HT_DAOTAOController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DM_HT_DAOTAOInfo> GetAll()
    {
        var rs = from t in dataContext.DM_HT_DAOTAOs
                 select new DM_HT_DAOTAOInfo
                 {
                     MA_HT_DAOTAO = t.MA_HT_DAOTAO,
                     TEN_HT_DAOTAO = t.TEN_HT_DAOTAO
                 };
        return rs.ToList();
    }
}