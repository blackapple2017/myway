using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChungChiController
/// </summary>
public class ChungChiController : LinqProvider
{
	public ChungChiController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Delete(int id)
    {
        DAL.HOSO_UNGVIEN_CHUNGCHI oldObj = dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.ID == id).FirstOrDefault();
        if (oldObj.FR_KEY_HOSO <= 0)
        {
            dataContext.HOSO_UNGVIEN_CHUNGCHIs.DeleteOnSubmit(oldObj);
            Save();
        }
        else
        {
            oldObj.PrKeyHoSoTuCapNhat = -1;
            Save();
        }
    }
}