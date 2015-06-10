using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VaoRaCaController
/// </summary>
public class VaoRaCaController : LinqProvider
{
    public VaoRaCaController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Insert(DAL.VaoRaCa item)
    {
        if (item != null)
        {
            dataContext.VaoRaCas.InsertOnSubmit(item);
            Save();
        }
    }

    public void InsertAndUpdate(DAL.VaoRaCa item)
    {
        DAL.VaoRaCa tmp = dataContext.VaoRaCas.SingleOrDefault(t => t.ID == item.ID);
        if (tmp != null)
        {
            tmp.Time = item.Time;
            tmp.NgayChamCong = item.NgayChamCong;
            Save();
        }
        else
            Insert(item);
    }

    public bool CheckExistTimeInOut(string maChamCong, string time, DateTime ngayChamCong)
    {
        DAL.VaoRaCa tmp = dataContext.VaoRaCas.SingleOrDefault(t => t.MaChamCong == maChamCong && t.NgayChamCong.Date == ngayChamCong.Date && t.Time == time);
        if (tmp != null)
        {
            return true;
        }
        return false;
    }
    public void UpdateTime(DAL.VaoRaCa item, string oldTime, DateTime ngayChamCong)
    {
        if (CheckExistTimeInOut(item.MaChamCong, item.Time, item.NgayChamCong))
        {
            DateTime a = DateTime.Parse("1992-10-01 " + item.Time);
            a = a.AddSeconds(1);
            item.Time = (a.Hour < 10 ? ("0"+ a.Hour.ToString()):a.Hour.ToString()) + ":" + (a.Minute<10?("0"+a.Minute.ToString()):a.Minute.ToString()) + ":" + (a.Second<10?("0"+a.Second.ToString()):a.Second.ToString());
            item.NgayChamCong.AddSeconds(1);
        }
        DAL.VaoRaCa tmp = dataContext.VaoRaCas.SingleOrDefault(t => t.MaChamCong == item.MaChamCong &&
                                                                    t.NgayChamCong.Date == item.NgayChamCong.Date &&
                                                                    t.Time == oldTime);
        if (tmp != null)
        {
            tmp.Time = item.Time;
            tmp.NgayChamCong = ngayChamCong;
            Save();
        }
    }
    /// <summary>
    /// Lấy thông tin giờ vào ra theo mã chấm công và ngày truyền vào
    /// </summary>
    /// <param name="maChamCong">Mã chấm công</param>
    /// <param name="ngay">Ngày truyền vào</param>
    /// <returns>Danh sách thông tin giờ vào ra</returns>
    public List<DAL.VaoRaCa> GetByMaChamCongAndDay(string maChamCong, DateTime ngay)
    {
        var rs = from t in dataContext.VaoRaCas
                 where t.MaChamCong == maChamCong
                    && (t.NgayChamCong == null || t.NgayChamCong.Day == ngay.Day
                        && t.NgayChamCong.Month == ngay.Month
                        && t.NgayChamCong.Year == ngay.Year)
                 select t;
        return rs.ToList();
    }

    public void DeleteByMaChamCongAndMonthYear(string maChamCong, DateTime time)
    {
        List<DAL.VaoRaCa> list = (from t in dataContext.VaoRaCas
                                  where t.MaChamCong == maChamCong
                                      //&& t.NgayChamCong.Day == time.Day
                                         && t.NgayChamCong.Month == time.Month
                                         && t.NgayChamCong.Year == time.Year
                                  select t).ToList();
        if (list.Count > 0)
        {
            dataContext.VaoRaCas.DeleteAllOnSubmit(list);
            Save();
        }
    }

    public DAL.VaoRaCa GetById(string id)
    {
        var rs = from t in dataContext.VaoRaCas
                 where t.ID == id
                 select t;
        return rs.FirstOrDefault();
    }
    //public List<VaoRaCaInfo> GetAllRecord(int start, int limit, DateTime ngay, string searchKey, out int count)
    //{
    //    var rs = from t in dataContext.VaoRaCas
    //             join h in dataContext.HOSOs on t.MaChamCong equals h.ID_MAY_CHAMCONG
    //             into hs
    //             from ht in hs.DefaultIfEmpty()
    //             where (t.NgayChamCong==ngay)
    //             select new VaoRaCaInfo()
    //             {
    //                 MA_CB = ht.MA_CB,
    //                 HO_TEN = ht.HO_TEN,
    //                 ID = t.ID,
    //                 MaChamCong = t.MaChamCong,
    //                 MaCa = t.MaCa,
    //                 NgayChamCong = t.NgayChamCong,
    //                 Order = t.Order,
    //                 DiVao = t.DiVao,
    //                 Time = t.Time

    //             };
    //    count = rs.ToList().Count;
    //    return rs.OrderBy(t => t.MaChamCong).ToList();
    //    //return rs.OrderBy(t => t.NgayChamCong).Skip(start).Take(limit).ToList();
    //}
}