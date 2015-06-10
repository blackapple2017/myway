using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CongThucLuongKinhDoanhController
/// </summary>
public class CongThucLuongKinhDoanhController:LinqProvider
{
	public CongThucLuongKinhDoanhController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.CongThucLuongKinhDoanh lkd)
    {
        if (lkd != null)
        {
            dataContext.CongThucLuongKinhDoanhs.InsertOnSubmit(lkd);
            Save();
        }
    }

    public void Update(DAL.CongThucLuongKinhDoanh lkd)
    {
        DAL.CongThucLuongKinhDoanh temp = dataContext.CongThucLuongKinhDoanhs.SingleOrDefault(t => t.ID == lkd.ID);
        if (temp != null)
        {
            temp.Nhom = lkd.Nhom;
            temp.MaChucVu = lkd.MaChucVu;
            temp.PhanTramTu = lkd.PhanTramTu;
            temp.PhanTramDen = lkd.PhanTramDen;
            temp.SanLuongTu = lkd.SanLuongTu;
            temp.SanLuongDen = lkd.SanLuongDen;
            temp.TienThuong = lkd.TienThuong;
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.CongThucLuongKinhDoanh temp = dataContext.CongThucLuongKinhDoanhs.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.CongThucLuongKinhDoanhs.DeleteOnSubmit(temp);
            Save();
        }
    }

    public DAL.CongThucLuongKinhDoanh GetById(int id)
    {
        return dataContext.CongThucLuongKinhDoanhs.SingleOrDefault(t => t.ID == id);
    }
}