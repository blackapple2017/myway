using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachNgayLeController
/// </summary>
public class DanhSachNgayLeController : LinqProvider
{
    public DanhSachNgayLeController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DAL.DanhSachNgayLe GetByID(int id)
    {
        return dataContext.DanhSachNgayLes.Where(p => p.ID == id).SingleOrDefault();
    }
    public void Update(DAL.DanhSachNgayLe ngayle)
    {
        var item = dataContext.DanhSachNgayLes.Where(p => p.ID == ngayle.ID).SingleOrDefault();
        item.AmLich = ngayle.AmLich;
        item.KiHieuChamCong = ngayle.KiHieuChamCong;
        item.Ngay = ngayle.Ngay;
        item.Thang = ngayle.Thang;
        item.TenNgayLe = ngayle.TenNgayLe;
        Save();
    }
    public void Insert(DAL.DanhSachNgayLe ngayle)
    {
        dataContext.DanhSachNgayLes.InsertOnSubmit(ngayle);
        Save();
    }

    public List<DAL.DanhSachNgayLe> GetHolidayInMonth(int month, int year)
    {
        List<DAL.DanhSachNgayLe> dsNgayLe = new List<DAL.DanhSachNgayLe>(); 
        dsNgayLe = dataContext.DanhSachNgayLes.Where(t => t.Thang == month && t.AmLich == false).ToList();
        return dsNgayLe;
    }

    public List<DAL.DanhSachNgayLe> GetHolidayInMonth(DateTime fromDate, DateTime toDate)
    {
        var rs = from t in dataContext.DanhSachNgayLes
                 where (fromDate.Month == toDate.Month && t.Thang >= fromDate.Month && t.Ngay >= fromDate.Day && t.Thang <= toDate.Month && t.Ngay <= toDate.Day)
                    || (fromDate.Month < toDate.Month && (t.Thang >= fromDate.Month && t.Ngay >= fromDate.Day || t.Thang <= toDate.Month && t.Ngay <= toDate.Day))
                 select t;
        return rs.ToList();
    }
}