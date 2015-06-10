using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KinhNghiemLamViecControler
/// </summary>
public class KinhNghiemLamViecControler : LinqProvider
{
	public KinhNghiemLamViecControler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.KinhNghiemLamViec kinhnghiem)
    {
        dataContext.KinhNghiemLamViecs.InsertOnSubmit(kinhnghiem);
        Save();
    }
    public void Update(DAL.KinhNghiemLamViec kinhnghiem)
    {
        DAL.KinhNghiemLamViec temp = dataContext.KinhNghiemLamViecs.SingleOrDefault(t => t.ID == kinhnghiem.ID);
        if (temp != null)
        {
            temp.CreatedUser = kinhnghiem.CreatedUser;            
            temp.DenThangNam = kinhnghiem.DenThangNam;
            temp.DiaChiCongTy = kinhnghiem.DiaChiCongTy;            
            temp.FR_KEY = kinhnghiem.FR_KEY;
            temp.GhiChu = kinhnghiem.GhiChu;           
            temp.KinhNghiemDatDuoc = kinhnghiem.KinhNghiemDatDuoc;
            temp.LyDoThoiViec = kinhnghiem.LyDoThoiViec;
            temp.MucLuong = kinhnghiem.MucLuong;
            temp.NoiLamViec = kinhnghiem.NoiLamViec;
            temp.TuThangNam = kinhnghiem.TuThangNam;
            temp.ViTriCongViec = kinhnghiem.ViTriCongViec;
            temp.ID = kinhnghiem.ID;
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.KinhNghiemLamViec temp = dataContext.KinhNghiemLamViecs.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.KinhNghiemLamViecs.DeleteOnSubmit(temp);
            Save();
        }
    }
         
}