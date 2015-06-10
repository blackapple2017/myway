using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for HOSO_QH_GIADINHController
/// </summary>
public class HOSO_QH_GIADINHController : LinqProvider
{
	public HOSO_QH_GIADINHController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<HOSO_QH_GIADINH> GetFamilyRelationships(decimal Fr_key)
    {
        var qhgd = (from t in dataContext.HOSO_QH_GIADINHs
                    where t.FR_KEY == Fr_key
                    select t);
        return qhgd.ToList();
    }
}