using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_HinhThucKhenThuongController
/// </summary>
public class DM_HinhThucKhenThuongController:LinqProvider
{
    public List<DAL.DM_HT_KTHUONG> GetByAll()
    {
        var rs = from t in dataContext.DM_HT_KTHUONGs
                 select t;
        return rs.ToList();
    }

}