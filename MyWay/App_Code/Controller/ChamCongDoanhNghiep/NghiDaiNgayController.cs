using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for NghiDaiNgayController
/// </summary>
public class NghiDaiNgayController : LinqProvider
{
    public NghiDaiNgayController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<NghiDaiNgayInfo> GetAll(string madonvi, int start, int limit, string searchkey, out int count)
    {
        var result = (from t in dataContext.NghiDaiNgays
                      join q in dataContext.HOSOs on t.PR_KEYHOSO equals q.PR_KEY
                      where (string.IsNullOrEmpty(searchkey) ? 1 == 1 :
                      System.Data.Linq.SqlClient.SqlMethods.Like(q.HO_TEN, searchkey)
                                                      || System.Data.Linq.SqlClient.SqlMethods.Like(q.MA_CB, searchkey))
                      select new NghiDaiNgayInfo
                      {
                          DongBH = t.DongBH,
                          GhiChu = t.GhiChu,
                          HoTen = q.HO_TEN,
                          ID = t.ID,
                          LyDoNghi = t.MaLyDoNghi,
                          NgayDangKyNghi = t.NgayDangKyNghi,
                          NgayDiLamLai = t.NgayDiLamLai,
                          NgayDiLamLaiThucTe = t.NgayDiLamLaiThucTe,
                          NgayNopDon = t.NgayNopDon,
                          NgayNghiThucTe = t.NgayNghiThucTe,
                          PR_KEYHOSO = t.PR_KEYHOSO
                      }).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).OrderByDescending(p => p.NgayNopDon).ToList();
    }
    public DAL.NghiDaiNgay GetNghiDaiNgayByID(int id)
    {
        return dataContext.NghiDaiNgays.Where(p => p.ID == id).SingleOrDefault();
    }
    public void Insert(DAL.NghiDaiNgay nghidaingay)
    {
        dataContext.NghiDaiNgays.InsertOnSubmit(nghidaingay);
        Save();
    }
    public void Update(DAL.NghiDaiNgay nghidaingay)
    {
        var item = dataContext.NghiDaiNgays.Where(p => p.ID == nghidaingay.ID).SingleOrDefault();
        item.DongBH = nghidaingay.DongBH;
        item.GhiChu = nghidaingay.GhiChu;
        item.MaLyDoNghi = nghidaingay.MaLyDoNghi;
        item.NgayDangKyNghi = nghidaingay.NgayDangKyNghi;
        item.NgayDiLamLai = nghidaingay.NgayDiLamLai;
        item.NgayDiLamLaiThucTe = nghidaingay.NgayDiLamLaiThucTe;
        item.NgayNopDon = nghidaingay.NgayNopDon;
        item.NgayNghiThucTe = nghidaingay.NgayNghiThucTe;
        Save();
    }
    public void Delete(int id)
    {
        var item = dataContext.NghiDaiNgays.Where(p => p.ID == id).SingleOrDefault();
        dataContext.NghiDaiNgays.DeleteOnSubmit(item);
        Save();
    }
    /// <summary>
    /// Nếu có trùng thì trả về true ngược lại trả về false
    /// </summary>
    /// <param name="prkey"></param>
    /// <param name="ngaybatdau"></param>
    /// <param name="ngayketthuc"></param>
    /// <returns></returns>
    public bool CheckTrungThoiGian(decimal prkey, DateTime ngaybatdau, DateTime ngayketthuc,int id)
    {
        bool cotrung = false;
        var result = (from t in dataContext.NghiDaiNgays
                      where t.PR_KEYHOSO == prkey &&t.ID!=id
                      select new
                      {
                          ngaybatdau = t.NgayDangKyNghi,
                          ngayketthuc = t.NgayDiLamLai
                      }).ToList();
        foreach (var item in result)
        {
            if (ngaybatdau >= item.ngaybatdau.Value && ngaybatdau <= item.ngayketthuc.Value) cotrung = true;
            if (ngayketthuc >= item.ngaybatdau.Value && ngayketthuc <= item.ngayketthuc.Value) cotrung = true;
            if (ngaybatdau <= item.ngaybatdau.Value && ngayketthuc >= item.ngayketthuc.Value) cotrung = true;
            if (ngaybatdau >= item.ngaybatdau.Value && ngayketthuc <= item.ngayketthuc.Value) cotrung = true;
        }
        return cotrung;
    }
}