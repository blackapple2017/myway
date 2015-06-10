using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LOAI_HDONGController
/// </summary>
public class DM_LOAI_HDONGController : LinqProvider
{
    public DM_LOAI_HDONGController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<DAL.DM_LOAI_HDONG> GetByAll()
    {
        var rs = from t in dataContext.DM_LOAI_HDONGs
                 select t;
        return rs.ToList();
    }
    public string GetMonth(string idmaloaihd)
    {
        var r = from t in dataContext.DM_LOAI_HDONGs where t.MA_LOAI_HDONG == idmaloaihd select t.THOI_HAN_HOPDONG_MONTH_;

        return r.FirstOrDefault().ToString();
    }
    public IEnumerable<DM_LOAIHOPDONGInfo> GetAll()
    {
        var rs = from t in dataContext.DM_LOAI_HDONGs
                 select new DM_LOAIHOPDONGInfo
                 {
                     MA_LOAI_HDONG = t.MA_LOAI_HDONG,
                     TEN_LOAI_HDONG = t.TEN_LOAI_HDONG
                 };
        return rs;
    }

    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_LOAI_HDONGs
                 select new StoreComboObject
                 {
                     MA = t.MA_LOAI_HDONG,
                     TEN = t.TEN_LOAI_HDONG
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }

    public IEnumerable<DM_LOAIHOPDONGInfo> GetAll(int start, int limit, string searchKey, out int count)
    {
        var rs = from t in dataContext.DM_LOAI_HDONGs
                 where System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_LOAI_HDONG, searchKey) || string.IsNullOrEmpty(searchKey)
                 select new DM_LOAIHOPDONGInfo
                 {
                     MA_LOAI_HDONG = t.MA_LOAI_HDONG,
                     TEN_LOAI_HDONG = t.TEN_LOAI_HDONG,
                     GHI_CHU = t.GHI_CHU,
                     THOI_HAN_HOPDONG = t.THOI_HAN_HOPDONG_MONTH_,
                     HE_SO = t.HeSo
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }
    public DAL.DM_LOAI_HDONG GetByID(string maloaihd)
    {
        return dataContext.DM_LOAI_HDONGs.Where(t => t.MA_LOAI_HDONG == maloaihd).FirstOrDefault();
    }

    public void Insert(DAL.DM_LOAI_HDONG loaihd)
    {
        dataContext.DM_LOAI_HDONGs.InsertOnSubmit(loaihd);
        Save();

    }
    public void DeleteLoaiHD(string maloaihd)
    {
        DAL.DM_LOAI_HDONG d = dataContext.DM_LOAI_HDONGs.Where(t => t.MA_LOAI_HDONG == maloaihd).FirstOrDefault();
        dataContext.DM_LOAI_HDONGs.DeleteOnSubmit(d);
        Save();
    }
    public void Update(DAL.DM_LOAI_HDONG a)
    {
        DAL.DM_LOAI_HDONG loaihd = GetByID(a.MA_LOAI_HDONG);
        loaihd.TEN_LOAI_HDONG = a.TEN_LOAI_HDONG;
        loaihd.THOI_HAN_HOPDONG_MONTH_ = a.THOI_HAN_HOPDONG_MONTH_;
        loaihd.GHI_CHU = a.GHI_CHU;
        loaihd.HeSo = a.HeSo;
        Save();
    }
}