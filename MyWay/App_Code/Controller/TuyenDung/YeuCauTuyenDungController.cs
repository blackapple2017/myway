using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for YeuCauTuyenDungController
/// </summary>
public class YeuCauTuyenDungController : LinqProvider
{
    public YeuCauTuyenDungController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DAL.YeuCauTuyenDung GetByID(int id)
    {
        return dataContext.YeuCauTuyenDungs.SingleOrDefault(t => t.ID == id);
    }
    public void Insert(DAL.YeuCauTuyenDung yc)
    {
        if (yc != null)
        {
            dataContext.YeuCauTuyenDungs.InsertOnSubmit(yc);
            Save();
        }
    }
    public List<DAL.YeuCauTuyenDung> GetAllByPlanID(int planID)
    {
        var rs = from yc in dataContext.YeuCauTuyenDungs
                 join kh in dataContext.KeHoachTuyenDungs on yc.PlanID equals kh.ID into kh1
                 from kh2 in kh1.DefaultIfEmpty()
                 where yc.PlanID == planID
                 select new DAL.YeuCauTuyenDung
                 {
                     ID = yc.ID,
                     PlanID = yc.PlanID,
                     MaThaoTac = yc.MaThaoTac,
                     RecordRelation = yc.RecordRelation,
                     ThuTu = yc.ThuTu,
                     UuTien = yc.UuTien,
                     YeuCau = yc.YeuCau,
                     DapUng = yc.DapUng
                 };
        return rs.ToList();
    }
}