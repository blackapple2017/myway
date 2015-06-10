using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachChamCongDacBietController
/// </summary>
public class DanhSachChamCongDacBietController:LinqProvider
{
	public DanhSachChamCongDacBietController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DAL.DanhSachNhanVienChamCongDacBiet GetByID(int id)
    {
        return dataContext.DanhSachNhanVienChamCongDacBiets.Where(p => p.ID == id).SingleOrDefault();
    }
    public DAL.DanhSachNhanVienChamCongDacBiet GetByMaCB(string macb)
    {
        return dataContext.DanhSachNhanVienChamCongDacBiets.Where(p => p.MaCB == macb).FirstOrDefault();
    }
    public void Insert(DAL.DanhSachNhanVienChamCongDacBiet nhanviendacbiet)
    {
        dataContext.DanhSachNhanVienChamCongDacBiets.InsertOnSubmit(nhanviendacbiet);
        Save();
    }
    public void Update(DAL.DanhSachNhanVienChamCongDacBiet nhanviendacbiet)
    {
        DAL.DanhSachNhanVienChamCongDacBiet item = dataContext.DanhSachNhanVienChamCongDacBiets.Where(p => p.MaCB == nhanviendacbiet.MaCB).SingleOrDefault();
        item.SoLanChitTay = nhanviendacbiet.SoLanChitTay;
        Save();
    }
    public void Delete(string macb)
    {
        DAL.DanhSachNhanVienChamCongDacBiet item = dataContext.DanhSachNhanVienChamCongDacBiets.Where(p => p.MaCB == macb).SingleOrDefault();
        dataContext.DanhSachNhanVienChamCongDacBiets.DeleteOnSubmit(item);
    }

}