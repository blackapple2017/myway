using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;

/// <summary>
/// Summary description for MucDongBaoHiemController
/// </summary>
/// Đức Anh 
public class MucDongBaoHiemController: LinqProvider
{
	public MucDongBaoHiemController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DAL.BHMUCDONGBAOHIEM GetByPrKey(int prkey)
    {
        var rs = from t in dataContext.BHMUCDONGBAOHIEMs
                 where t.ID == prkey
                 select t;
        return rs.FirstOrDefault();
    }
    public List<BHMUCDONGBAOHIEM> GetAll()
    {
       List<DAL.BHMUCDONGBAOHIEM> rs = (from p in dataContext.BHMUCDONGBAOHIEMs
                 select p).ToList();
        return rs;
    }
    public void DeleteMucDongBaoHiem(int prkey)
    {
        dataContext.BHMUCDONGBAOHIEMs.DeleteOnSubmit(dataContext.BHMUCDONGBAOHIEMs.Where(p => p.ID == prkey).SingleOrDefault());
        Save();
    }
    public void InsertMucDongBaoHiem(DAL.BHMUCDONGBAOHIEM item)
    {
        dataContext.BHMUCDONGBAOHIEMs.InsertOnSubmit(item);
        Save();
    }
    public void UpdateMucDongBaoHiem(DAL.BHMUCDONGBAOHIEM item)
    {
        DAL.BHMUCDONGBAOHIEM tmp = dataContext.BHMUCDONGBAOHIEMs.SingleOrDefault(p => p.ID == item.ID);
        tmp = item;
        Save();
    }
    public List<DAL.BHMUCDONGBAOHIEM> GetMucDongBaoHiemByMaDonVi(string MaDonVi, out int count)
    {
        DM_DONVI dv = new DM_DONVIController().GetById(MaDonVi);
        List<BHMUCDONGBAOHIEM> rs = (from t in dataContext.BHMUCDONGBAOHIEMs
                                     where t.MaDonVi.Equals(MaDonVi)
                                     select t).ToList();
        count = rs.Count();
        return rs;
    }
}