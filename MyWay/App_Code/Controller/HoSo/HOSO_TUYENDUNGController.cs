using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_TUYENDUNGController
/// </summary>
public class HOSO_TUYENDUNGController : LinqProvider
{
	public HOSO_TUYENDUNGController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.HOSO_TUYENDUNG> GetTuyenDungByHosoKey(decimal hsKey)
    {
        return dataContext.HOSO_TUYENDUNGs.Where(t => t.FR_KEY == hsKey).ToList();
    }
    public void InsertHosoTuyenDung(DAL.HOSO_TUYENDUNG hstd)
    {
        dataContext.HOSO_TUYENDUNGs.InsertOnSubmit(hstd);
        Save();
    }
}