using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DieuKienChamCongDacBietController
/// </summary>
public class DieuKienChamCongDacBietController:LinqProvider
{
	public DieuKienChamCongDacBietController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DAL.DanhSachNhanVienChamCongDacBiet GetByID(int id)
    {
        return dataContext.DanhSachNhanVienChamCongDacBiets.Where(p => p.ID == id).SingleOrDefault();
    }
    public void Update(DAL.DanhSachNhanVienChamCongDacBiet  chamcongdacbiet)
    {
        var item = dataContext.DanhSachNhanVienChamCongDacBiets.Where(p => p.ID == chamcongdacbiet.ID).SingleOrDefault();
        item.SoLanChitTay = chamcongdacbiet.SoLanChitTay;
        Save();
    }
    public void Insert(DAL.DanhSachNhanVienChamCongDacBiet chamcongdacbiet)
    {
        dataContext.DanhSachNhanVienChamCongDacBiets.InsertOnSubmit(chamcongdacbiet);
        Save();
    }

    public List<DAL.DanhSachNhanVienChamCongDacBiet> GetByAll()
    {
        var rs = from t in dataContext.DanhSachNhanVienChamCongDacBiets
                 select t;
        return rs.ToList();
    }
}