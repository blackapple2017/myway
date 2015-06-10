using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LyDoKhenThuongControllercs
/// </summary>
public class DM_LyDoKhenThuongControllercs:LinqProvider
{
	public DM_LyDoKhenThuongControllercs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_LYDO_KTHUONG> GetAll()
    {
        var rs = from t in dataContext.DM_LYDO_KTHUONGs select t;
                 return rs.ToList();
    }

    public string Insert(DAL.DM_LYDO_KTHUONG lyDo)
    {
        if (lyDo != null)
        {
            dataContext.DM_LYDO_KTHUONGs.InsertOnSubmit(lyDo);
            Save();
            return lyDo.MA_LYDO_KTHUONG;
        }
        return "";
    }
}