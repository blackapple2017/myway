using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;

/// <summary>
/// Summary description for QuyDinhBienDongBaoHiemController
/// </summary>
/// Đức anh
public class QuyDinhBienDongBaoHiemController:LinqProvider
{
	public QuyDinhBienDongBaoHiemController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public BHQUYDINHBIENDONG GetQuyDinhBienDongByPrKey(int prkey)
    {
        var rs = from t in dataContext.BHQUYDINHBIENDONGs
                 where t.IDQuyDinhBienDong == prkey
                 select t;
        return rs.FirstOrDefault();
    }
    public void DeleteQuyDinhBienDong(int prkey)
    {
        dataContext.BHQUYDINHBIENDONGs.DeleteOnSubmit(dataContext.BHQUYDINHBIENDONGs.Where(p => p.IDQuyDinhBienDong == prkey).SingleOrDefault());
        Save();
    }
    public void InsertQuyDinhBienDong(BHQUYDINHBIENDONG item)
    {
        dataContext.BHQUYDINHBIENDONGs.InsertOnSubmit(item);
        Save();
    }
    public void UpdateQuyDinhBienDong(BHQUYDINHBIENDONG item)
    {
        BHQUYDINHBIENDONG tmp = dataContext.BHQUYDINHBIENDONGs.SingleOrDefault(p => p.IDQuyDinhBienDong == item.IDQuyDinhBienDong);
        tmp = item;
        Save();
    }
    public List<BHQUYDINHBIENDONG> GetQuyDinhBienDongByMaDonVi(string MaDonVi, out int count)
    {
        DM_DONVI dv = new DM_DONVIController().GetById(MaDonVi);
        List<BHQUYDINHBIENDONG> rs = (from t in dataContext.BHQUYDINHBIENDONGs
                                      where t.MaDonVi.Equals(MaDonVi)
                                      select t).ToList();
        count = rs.Count();
        return rs;
    }

}