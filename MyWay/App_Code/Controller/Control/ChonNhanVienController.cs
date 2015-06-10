using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChonNhanVienController
/// </summary>
public class ChonNhanVienController : LinqProvider
{
    public ChonNhanVienController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<ChonNhanVienInfo> ChonNhanVien(int start,int limit, string name, out int count)
    {
        var rs = from t in dataContext.HOSOs
                 join dv in dataContext.DM_DONVIs
                 on t.MA_DONVI equals dv.MA_DONVI
                 where System.Data.Linq.SqlClient.SqlMethods.Like(t.HO_TEN, name)
                 orderby t.TEN_CB,t.HO_TEN
                 select new ChonNhanVienInfo
                 {
                     MaCB = t.MA_CB,
                     HoTen = t.HO_TEN,
                     PR_KEY = t.PR_KEY,
                     PhongBan = dv.TEN_DONVI,
                     NgaySinh = t.NGAY_SINH
                 };
        count = rs.Count();
        return rs.ToList();
    }

}

public class ChonNhanVienInfo
{
    public decimal PR_KEY { get; set; }
    public string MaCB { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public DateTime? NgaySinh { get; set; }
}