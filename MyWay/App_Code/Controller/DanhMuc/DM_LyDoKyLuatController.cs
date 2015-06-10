using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LyDoKyLuatController
/// </summary>
public class DM_LyDoKyLuatController : LinqProvider
{
	public DM_LyDoKyLuatController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Insert(DAL.DM_LYDO_KYLUAT lyDo)
    {
        if (lyDo != null)
        {
            dataContext.DM_LYDO_KYLUATs.InsertOnSubmit(lyDo);
            Save();
            return lyDo.MA_LYDO_KYLUAT;
        }
        return "";
    }
}