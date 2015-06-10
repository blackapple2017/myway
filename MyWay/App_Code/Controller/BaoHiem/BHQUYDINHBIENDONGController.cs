using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHQUYDINHBIENDONGController:LinqProvider
{
    public DataTable GetByPrkey(int pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetBHQUYDINHBIENDONGByPrkey", "@IDQuyDinhBienDong", pr_key);
    }
    //đức anh viết hàm linq
    public DAL.BHQUYDINHBIENDONG Lay1QuyDinhBienDong(int prkey)
    {
        return dataContext.BHQUYDINHBIENDONGs.Where(p => p.IDQuyDinhBienDong == prkey).SingleOrDefault();
    }
    public int LayIDBienDongByMa(string ma)
    {
        var tmp= dataContext.BHQUYDINHBIENDONGs.Where(p => p.MaBienDong == ma).SingleOrDefault();
        if (tmp != null)
            return tmp.IDQuyDinhBienDong;
        else return 0;
    }
    public void DeleteByPrkey(int pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteBHQUYDINHBIENDONGByPrkey", "@IDQuyDinhBienDong", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey, out int count,string MaDonVi)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountBHQUYDINHBIENDONG", "@searchKey","@MaDonVi", searchKey,MaDonVi).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectBHQUYDINHBIENDONG", "@start", "@limit", "@searchKey","@MaDonVi", start, limit, searchKey,MaDonVi);
    }

    public void Insert(BHQUYDINHBIENDONGInfo record)
    {
		DataController.DataHandler.GetInstance().ExecuteScalar("InsertBHQUYDINHBIENDONG" , "@MaBienDong", "@TenBienDong", "@LoaiAnhHuong", "@IDCheDoBaoHiem", "@IsBHXH", "@IsBHYT", "@IsBHTN", "@DangSuDung", "@UserID", "@DateCreate", "@MaDonVi" , record.MaBienDong, record.TenBienDong, record.LoaiAnhHuong, record.IDCheDoBaoHiem, record.IsBHXH, record.IsBHYT, record.IsBHTN, record.DangSuDung, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void Update(BHQUYDINHBIENDONGInfo record)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateBHQUYDINHBIENDONG" , "@IDQuyDinhBienDong", "@MaBienDong", "@TenBienDong", "@LoaiAnhHuong", "@IDCheDoBaoHiem", "@IsBHXH", "@IsBHYT", "@IsBHTN", "@DangSuDung", "@UserID", "@DateCreate", "@MaDonVi" , record.IDQuyDinhBienDong, record.MaBienDong, record.TenBienDong, record.LoaiAnhHuong, record.IDCheDoBaoHiem, record.IsBHXH, record.IsBHYT, record.IsBHTN, record.DangSuDung, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void DuplucateByPrkey(int pr_key)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateBHQUYDINHBIENDONGByPrkey", "@IDQuyDinhBienDong", pr_key);
    }

}
