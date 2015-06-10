using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HoSoKhenThuongController
/// </summary>
public class HoSoKhenThuongController : LinqProvider
{
	public HoSoKhenThuongController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DAL.HOSO_KHENTHUONG GetKhenThuong(decimal Pr_key)
    {
        return dataContext.HOSO_KHENTHUONGs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }

    public void InsertKhenThuong(DAL.HOSO_KHENTHUONG khenthuong)
    {
        dataContext.HOSO_KHENTHUONGs.InsertOnSubmit(khenthuong);
        Save();
    }

    public void UpdateKhenThuong(DAL.HOSO_KHENTHUONG hskt)
    {
        DAL.HOSO_KHENTHUONG khenthuong = GetKhenThuong(hskt.PR_KEY);
        if (khenthuong != null)
        {
            khenthuong.GHI_CHU = hskt.GHI_CHU;
            khenthuong.MA_HT_KTHUONG = hskt.MA_HT_KTHUONG;
            khenthuong.LYDO_KTHUONG = hskt.LYDO_KTHUONG;
            khenthuong.NGAY_QD = hskt.NGAY_QD;
            khenthuong.SO_QD = hskt.SO_QD;
            khenthuong.SO_TIEN = hskt.SO_TIEN;
            khenthuong.PrkeyNguoiQuyetDinh = hskt.PrkeyNguoiQuyetDinh;
            khenthuong.TepTinDinhKem = hskt.TepTinDinhKem;
            khenthuong.SoDiem = hskt.SoDiem;
            Save();
        }
    }
}