using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhieuLamThemGioController
/// </summary>
public class PhieuLamThemGioController : LinqProvider
{
	public PhieuLamThemGioController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DAL.PhieuLamThemGio GetById(decimal id)
    {
        return dataContext.PhieuLamThemGios.SingleOrDefault(t => t.ID == id);
    }

    public void Insert(DAL.PhieuLamThemGio tg)
    {
        if (tg != null)
        {
            dataContext.PhieuLamThemGios.InsertOnSubmit(tg);
            Save();
            // cập nhật số ngày sang tổng hợp công cuối tháng
            UpdateToTongHopCongCuoiThang(tg.PrkeyHoSo, tg.NgayDangKy.Month, tg.NgayDangKy.Year);
        }
    }

    public void Update(DAL.PhieuLamThemGio tg)
    {
        DAL.PhieuLamThemGio temp = dataContext.PhieuLamThemGios.SingleOrDefault(t => t.ID == tg.ID);
        if (temp != null)
        {
            temp.DenGio = tg.DenGio;
            temp.LamThemNgayLe_AM = tg.LamThemNgayLe_AM;
            temp.LamThemNgayNghi_AM = tg.LamThemNgayNghi_AM;
            temp.LamThemNgayThuong_AM = tg.LamThemNgayThuong_AM;
            temp.LamThemNgayLe_PM = tg.LamThemNgayLe_PM;
            temp.LamThemNgayNghi_PM = tg.LamThemNgayNghi_PM;
            temp.LamThemNgayThuong_PM = tg.LamThemNgayThuong_PM;
            temp.NgayDangKy = tg.NgayDangKy;
            temp.NoiDung = tg.NoiDung;
            temp.TuGio = tg.TuGio;
            Save();
            // cập nhật số ngày sang tổng hợp công cuối tháng
            UpdateToTongHopCongCuoiThang(temp.PrkeyHoSo, temp.NgayDangKy.Month, temp.NgayDangKy.Year);
        }
    }
    public void UpdateToTongHopCongCuoiThang(decimal Prkey, int month, int year)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_CapNhatPhieuLamThemVaoTongHopCongCuoiThang", "@PrKeyHoSo", "@Month", "@Year", Prkey, month, year);
    }
    public void Delete(decimal id)
    {
        DAL.PhieuLamThemGio tg = dataContext.PhieuLamThemGios.SingleOrDefault(t => t.ID == id);
        if (tg != null)
        {
            dataContext.PhieuLamThemGios.DeleteOnSubmit(tg);
            // cập nhật số ngày sang tổng hợp công cuối tháng
            UpdateToTongHopCongCuoiThang(tg.PrkeyHoSo, tg.NgayDangKy.Month, tg.NgayDangKy.Year);
            Save();
        }
    }
}