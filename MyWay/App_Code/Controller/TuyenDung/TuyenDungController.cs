using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TuyenDungController
/// </summary>
public class TuyenDungController : LinqProvider
{
    public TuyenDungController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
     
    //public DAL.KEHOACH_TUYENDUNG GetUngVien(decimal pr_key)
    //{
    //    return dataContext.KEHOACH_TUYENDUNGs.Where(t => t.PR_KEY == pr_key).FirstOrDefault();
    //}

    public List<MiniDM_DotTuyenDungInfo> GetAll()
    {
        //return (from t in dataContext.DM_DOTTUYENDUNGs
        //        orderby t.ID descending
        //        select new MiniDM_DotTuyenDungInfo
        //        {
        //            ID = t.ID,
        //            TenKeHoach = t.TenKeHoach,
        //            TrangThai = t.TrangThaiXuLy,
        //        }).ToList();
        return null;
    }

    public IEnumerable<MiniDM_DotTuyenDungInfo> GetAll(int start, int limit)
    {
        //return (from t in dataContext.DM_DOTTUYENDUNGs
        //        orderby t.ID descending
        //        select new MiniDM_DotTuyenDungInfo
        //        {
        //            ID = t.ID,
        //            TenKeHoach = t.TenKeHoach,
        //            TrangThai = t.TrangThaiXuLy,
        //        }).Skip(start).Take(limit);
        return null;
    }

    public MiniDM_DotTuyenDungInfo GetByID(int ID)
    {
        //return (from t in dataContext.DM_DOTTUYENDUNGs
        //        where t.ID == ID
        //        select new MiniDM_DotTuyenDungInfo
        //        {
        //            EndDate = t.NgayKetThuc,
        //            StartDate = t.NgayBatDau,
        //            ID = t.ID,
        //            MA_CONGVIEC = t.MA_CONGVIEC,
        //            MA_PHONG = t.MA_PHONGBAN,
        //            SoLuong = t.SoLuongCanTuyen,
        //            TenKeHoach = t.TenKeHoach,
        //            TrangThai = t.TrangThaiXuLy,
        //        }).FirstOrDefault();
        return null;
    }

    //public void Insert(DAL.DM_DOTTUYENDUNG tuyendung)
    //{
    //    dataContext.DM_DOTTUYENDUNGs.InsertOnSubmit(tuyendung);
    //    Save();
    //}
}