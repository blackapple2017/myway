using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// @Thế Tư
/// </summary>
public class TongHopCongTheoNgayController : LinqProvider
{
    public TongHopCongTheoNgayController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DAL.TongHopCongTheoNgay GetByID(decimal ID)
    {
        var rs = from t in dataContext.TongHopCongTheoNgays
                 where t.ID == ID
                 select t;
        return rs.FirstOrDefault();
    }
    public DAL.TongHopCongTheoNgay GetByMaChamCongNgayThang(string maChamCong, DateTime ngayThang)
    {
        var rs = from t in dataContext.TongHopCongTheoNgays
                 where t.MaChamCong == maChamCong && t.NgayThang.Date == ngayThang.Date
                 select t;
        return rs.FirstOrDefault();
    }
    public void Insert(string prKey, string maCa, string kyHieuChamCong, string ghiChu, DateTime ngayChamCong)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("insert_TongHopCongTheoNgay", "@PR_KEY", "@MACA", "@KyHieuChamCong", "@GhiChu", "@NgayChamCong",
                                                                  prKey, maCa, kyHieuChamCong, ghiChu, ngayChamCong);
    }

    public void Update(decimal ID, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_UpdateTongHopCongTheoNgay", "@ID", "@Field", "@Value",
                                                                  ID, field, value);
    }
    public void Delete(int id)
    {
        DAL.TongHopCongTheoNgay tmp = dataContext.TongHopCongTheoNgays.SingleOrDefault(t => t.ID == id);
        if (tmp != null)
        {
            dataContext.TongHopCongTheoNgays.DeleteOnSubmit(tmp);
            Save();
        }
    }

    public void DeleteByDay(DateTime day, string maChamCong)
    {
        List<DAL.TongHopCongTheoNgay> list = (from t in dataContext.TongHopCongTheoNgays
                                              where t.NgayThang.Month == day.Month
                                                && t.NgayThang.Year == day.Year
                                                && t.MaChamCong == maChamCong
                                              select t).ToList();
        if (list.Count > 0)
        {
            dataContext.TongHopCongTheoNgays.DeleteAllOnSubmit(list);
            Save();
        }
    }
}