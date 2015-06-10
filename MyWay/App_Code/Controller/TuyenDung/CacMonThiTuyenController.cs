using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;

/// <summary>
/// Summary description for CacMonThiTuyenController
/// </summary>
public class CacMonThiTuyenController : LinqProvider
{
	public CacMonThiTuyenController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public IEnumerable<CacMonThiTuyenInfo> GetAllByPlanID(int planID)
    {
        var rs = from mt in dataContext.CacMonThiTuyens
                 join kh in dataContext.KeHoachTuyenDungs on mt.PlanID equals kh.ID into kh1
                 from kh2 in kh1.DefaultIfEmpty()
                 join m in dataContext.ThamSoTrangThais on mt.MaMonThi equals m.ID into m1
                 from m2 in m1.DefaultIfEmpty()
                 join ng in dataContext.HoiDongTuyenDungs on mt.NguoiChamThi equals ng.ID into ng1
                 from ng2 in ng1.DefaultIfEmpty()
                 where mt.PlanID == planID
                 select new CacMonThiTuyenInfo
                 {
                     ID = mt.ID,
                     PlanID = (int)mt.PlanID,
                     DiemDat = mt.DiemDat,
                     GhiChu = mt.GhiChu,
                     maMon = mt.MaMonThi,
                     tenMon = m2.Value,
                     TrongSo = mt.TrongSo,
                     VongThi = mt.Vong,
                     PrKeyHOSO = (decimal)ng2.PrKeyHoSo
                     //TTNGuoiCham = new HoSoController().GetByPrKey((decimal)ng2.PrKeyHoSo)
                 };
        return rs;
    }
    public void Insert(DAL.CacMonThiTuyen mt)
    {
        if (mt != null)
        {
            dataContext.CacMonThiTuyens.InsertOnSubmit(mt);
            Save();
        }
    }
    public void Update(DAL.CacMonThiTuyen mt)
    {
        DAL.CacMonThiTuyen temp = dataContext.CacMonThiTuyens.SingleOrDefault(t => t.ID == mt.ID);
        if (temp != null)
        {
            temp.GhiChu = mt.GhiChu;
            temp.MaMonThi = mt.MaMonThi;
            temp.NguoiChamThi = mt.NguoiChamThi;
            temp.PlanID = mt.PlanID;
            temp.TrongSo = mt.TrongSo;
            temp.Vong = mt.Vong;
            temp.DiemDat = mt.DiemDat;
            Save();
        }
    }
    public void Delete(int id)
    {
        DAL.CacMonThiTuyen temp = dataContext.CacMonThiTuyens.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.CacMonThiTuyens.DeleteOnSubmit(temp);
            Save();
        }
    }
}