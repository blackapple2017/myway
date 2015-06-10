using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoiDongTuyenDungController
/// </summary>
public class HoiDongTuyenDungController : LinqProvider
{
	public HoiDongTuyenDungController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.HoiDongTuyenDung hd)
    {
        if (hd!=null)
        {
            dataContext.HoiDongTuyenDungs.InsertOnSubmit(hd);
            Save();
        }
    }
    public void Update(DAL.HoiDongTuyenDung hd)
    {
        DAL.HoiDongTuyenDung temp = dataContext.HoiDongTuyenDungs.SingleOrDefault(t => t.ID == hd.ID);
        if (temp!=null)
        {
            temp.Note = hd.Note;
            temp.PlanID = hd.PlanID;
            temp.PrKeyHoSo = hd.PrKeyHoSo;
            temp.VongThi = hd.VongThi;
            temp.CreatedBy = hd.CreatedBy;
            temp.CreatedDate = hd.CreatedDate;
            Save();
        }
    }
    public void Delete(int ID)
    {
        DAL.HoiDongTuyenDung temp = dataContext.HoiDongTuyenDungs.SingleOrDefault(t => t.ID == ID);

//        DAL.HoiDongTuyenDung temp = dataContext.HoiDongTuyenDungs.FirstOrDefault(t => t.ID == ID);
        if (temp!=null)
        {
            dataContext.HoiDongTuyenDungs.DeleteOnSubmit(temp);
            Save();
        }
    }
}