using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NGUON_TUYENDUNGController   
/// </summary>
public class ChiPhiTuyenDungController : LinqProvider
{
    public ChiPhiTuyenDungController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Insert(DAL.ChiPhiTuyenDung chiPhiTuyenDung)
    {
        if (chiPhiTuyenDung != null)
        {
            dataContext.ChiPhiTuyenDungs.InsertOnSubmit(chiPhiTuyenDung);
            Save();
        }
    }

    public void Update(DAL.ChiPhiTuyenDung chiPhiTuyenDung)
    {
        DAL.ChiPhiTuyenDung temp = dataContext.ChiPhiTuyenDungs.SingleOrDefault(t => t.ID == chiPhiTuyenDung.ID);
        if (temp != null)
        {
            temp.CreatedBy = chiPhiTuyenDung.CreatedBy;
            temp.CreatedDate = chiPhiTuyenDung.CreatedDate;
            temp.ID = chiPhiTuyenDung.ID;
            temp.NgayChi = chiPhiTuyenDung.NgayChi;
            temp.NguonChi = chiPhiTuyenDung.NguonChi;
            temp.SoTien = chiPhiTuyenDung.SoTien;
            temp.TenChiPhi = chiPhiTuyenDung.TenChiPhi;
            temp.GhiChu = chiPhiTuyenDung.GhiChu;
            Save();
        }
    }
    public void Delete(int id)
    {
        DAL.ChiPhiTuyenDung temp = dataContext.ChiPhiTuyenDungs.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.ChiPhiTuyenDungs.DeleteOnSubmit(temp);
            Save();
        }
    }
    public IEnumerable<DAL.ChiPhiTuyenDung> GetByPlanID(int planID)
    {
        var rs = dataContext.ChiPhiTuyenDungs.Where(t => t.PlanID == planID);
        return rs;
    }
    /// <summary>
    /// Lấy chi phí tuyển dụng
    /// </summary>
    /// <param name="planID"></param>
    /// <returns></returns>
    public List<ChiPhiTuyenDungInfo> GetRecruitmentCosts(int planID)
    {
        var rs = from t in dataContext.ChiPhiTuyenDungs
                 join u in dataContext.Users on t.CreatedBy equals u.ID into q
                 from mcs in q.DefaultIfEmpty()
                 where t.PlanID == planID
                 select new ChiPhiTuyenDungInfo
                 {
                     ID = t.ID,
                     TenChiPhi = t.TenChiPhi,
                     SoTien = t.SoTien,
                     NguonChi = t.NguonChi,
                     NgayChi = t.NgayChi,
                     CreatedDate = t.CreatedDate,
                     CreatedBy = t.CreatedBy,
                     GhiChu = t.GhiChu,
                     NguoiTao = mcs.DisplayName
                 };
        return rs.OrderByDescending(p => p.CreatedDate).ToList();
    }
    public DAL.ChiPhiTuyenDung GetById(int id)
    {
        return dataContext.ChiPhiTuyenDungs.SingleOrDefault(t => t.ID == id);
    }
    public List<ChiPhiTuyenDungInfo> GetByAll(int start, int limit, string searchKey, out int count)
    {
        var rs = from t in dataContext.ChiPhiTuyenDungs
                 join mc in dataContext.KeHoachTuyenDungs on t.PlanID equals mc.ID into q
                 from mcs in q.DefaultIfEmpty()
                 where (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(mcs.TenKeHoach, searchKey))
                 select new ChiPhiTuyenDungInfo
                 {
                     ID = t.ID,
                     TenChiPhi = t.TenChiPhi,
                     SoTien = t.SoTien,
                     NguonChi = t.NguonChi,
                     NgayChi = t.NgayChi,
                     CreatedDate = t.CreatedDate,
                     CreatedBy = t.CreatedBy,
                     TenKeHoach = mcs.TenKeHoach,
                     GhiChu = t.GhiChu
                 };

        count = rs.Count();
        return rs.Take(limit).Skip(start).OrderByDescending(p => p.CreatedDate).ToList();
    }

}