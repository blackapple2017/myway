using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TEPTINDINHKEMController
/// </summary>
public class AttachFileController:LinqProvider
{
	public AttachFileController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.HOSO_TepTinDinhKem ttdk)
    {
        dataContext.HOSO_TepTinDinhKems.InsertOnSubmit(ttdk);
        Save();
    }
}