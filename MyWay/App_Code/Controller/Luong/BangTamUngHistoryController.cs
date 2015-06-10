using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangTamUngHistoryController
/// </summary>
public class BangTamUngHistoryController:LinqProvider
{
	public BangTamUngHistoryController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DAL.BangTamUngHistory GetByPrKey(int prkey)
    {
        return dataContext.BangTamUngHistories.Where(t => t.ID == prkey).FirstOrDefault();
    }
    public void Insert(DAL.BangTamUngHistory tamung)
    {
        dataContext.BangTamUngHistories.InsertOnSubmit(tamung);
        Save();
    }
    public void Update(DAL.BangTamUngHistory tamung)
    {
        var item = dataContext.BangTamUngHistories.Where(p =>p.ID == tamung.ID).FirstOrDefault();
        item.BangTamUngID = tamung.BangTamUngID;
        item.NgayTra = tamung.NgayTra;
        item.SoTienThanhToan = tamung.SoTienThanhToan;
        item.FB = tamung.FB;
        item.LoaiThanhToan = tamung.LoaiThanhToan;
        item.Description = tamung.Description;
        item.CreatedBy = tamung.CreatedBy;
        item.CreatedDate = tamung.CreatedDate;
        Save();
    }
    public void Delete(int id)
    {
        DAL.BangTamUngHistory extsting = GetByPrKey(id);
        if (extsting != null)
        {
            dataContext.BangTamUngHistories.DeleteOnSubmit(extsting);
            Save();
        }
    }
}