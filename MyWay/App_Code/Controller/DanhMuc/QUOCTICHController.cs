using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QUOCTICHController
/// </summary>
public class QuocTichController:LinqProvider
{
	public QuocTichController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_NUOC> GetByAll()
    {
        var r = from t in dataContext.DM_NUOCs
                select t;
        return r.ToList();
    }

}