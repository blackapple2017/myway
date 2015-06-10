using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangCapUngVienController
/// </summary>
public class ChungChiUngVienController : LinqProvider
{
    public ChungChiUngVienController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.BangCapChungChi chungchi)
    {
        dataContext.BangCapChungChis.InsertOnSubmit(chungchi);
        Save();
    }
    public void Update(DAL.BangCapChungChi chungchi)
    {
        DAL.BangCapChungChi temp = dataContext.BangCapChungChis.SingleOrDefault(t => t.ID == chungchi.ID);
        if (temp != null)
        {
            temp.FR_KEY = chungchi.FR_KEY;
            temp.GhiChu = chungchi.GhiChu;
            temp.ID = chungchi.ID;
            temp.MA_XEPLOAI = chungchi.MA_XEPLOAI;
            temp.MaChungChi = chungchi.MaChungChi;
            temp.NoiDaoTao = chungchi.NoiDaoTao;
            temp.NgayCap = chungchi.NgayCap;
            temp.NgayHetHan = chungchi.NgayHetHan;            
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.BangCapChungChi temp = dataContext.BangCapChungChis.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.BangCapChungChis.DeleteOnSubmit(temp);
            Save();
        }
    }
     
}