using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for THUE_THUNHAPController
/// </summary>
public class THUE_THUNHAPController : LinqProvider
{
    public THUE_THUNHAPController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Lấy danh mục thuế thu nhập
    /// </summary>
    /// <param name="CountryCode"></param>
    /// <returns></returns>
    public List<DAL.DM_THUE_TN> GetAll(string CountryCode)
    {
        var rs = from t in dataContext.DM_THUE_TNs
                 where t.MA_LOAI_THUE.Substring(0, 2).ToLower() == CountryCode.ToLower()
                 select t;
        return rs.ToList();
    }

    /// <summary>
    /// Lấy ra thông tin để tính thuế thu nhập cá nhân
    /// </summary>
    /// <param name="TNTT">Thu nhập tính thuế = Tổng lương - các khoản trừ khác</param>
    /// <returns></returns>
    public DAL.DM_THUE_TN GetByRange(float TNTT)
    {
        return (from t in dataContext.DM_THUE_TNs where t.MUC_DUOI <= TNTT && TNTT <= t.MUC_TREN select t).FirstOrDefault();
    }
}