using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for QuanLyNghiBuController
/// </summary>
public class QuanLyNghiBuController : LinqProvider
{
	public QuanLyNghiBuController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Update(DAL.QuanLyNghiBu nb)
    {
        DAL.QuanLyNghiBu temp = dataContext.QuanLyNghiBus.SingleOrDefault(t => t.ID == nb.ID);
        if (temp != null)
        {
            temp.GiamT1 = nb.GiamT1;
            temp.GiamT10 = nb.GiamT10;
            temp.GiamT11 = nb.GiamT11;
            temp.GiamT12 = nb.GiamT12;
            temp.GiamT2 = nb.GiamT2;
            temp.GiamT3 = nb.GiamT3;
            temp.GiamT4 = nb.GiamT4;
            temp.GiamT5 = nb.GiamT5;
            temp.GiamT6 = nb.GiamT6;
            temp.GiamT7 = nb.GiamT7;
            temp.GiamT8 = nb.GiamT8;
            temp.GiamT9 = nb.GiamT9;
            temp.TangT1 = nb.TangT1;
            temp.TangT10 = nb.TangT10;
            temp.TangT11 = nb.TangT11;
            temp.TangT12 = nb.TangT12;
            temp.TangT2 = nb.TangT2;
            temp.TangT3 = nb.TangT3;
            temp.TangT4 = nb.TangT4;
            temp.TangT5 = nb.TangT5;
            temp.TangT6 = nb.TangT6;
            temp.TangT7 = nb.TangT7;
            temp.TangT8 = nb.TangT8;
            temp.TangT9 = nb.TangT9; 
            Save();
        }
    }
}