using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TepTinDinhKemControler
/// </summary>
public class TepTinDinhKemControler : LinqProvider
{
	public TepTinDinhKemControler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.TepTinDinhKem dinhkem)
    {
        dataContext.TepTinDinhKems.InsertOnSubmit(dinhkem);
        Save();
    }
    public void Update(DAL.TepTinDinhKem dinhkem)
    {
        DAL.TepTinDinhKem temp = dataContext.TepTinDinhKems.SingleOrDefault(t => t.ID == dinhkem.ID);
        if (temp != null)
        {
            temp.CreatedBy = dinhkem.CreatedBy;
            temp.CreatedDate = dinhkem.CreatedDate;
            temp.FR_KEY = dinhkem.FR_KEY;
            temp.GhiChu = dinhkem.GhiChu;
            temp.ID = dinhkem.ID;
            temp.Link = dinhkem.Link;
            temp.SizeKB = dinhkem.SizeKB;
            temp.TenTepTin = dinhkem.TenTepTin; 
            Save();
        }
    }
    public void Delete(int id)
    {
        DAL.TepTinDinhKem temp = dataContext.TepTinDinhKems.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.TepTinDinhKems.DeleteOnSubmit(temp);
            Save();
        }
    }
}