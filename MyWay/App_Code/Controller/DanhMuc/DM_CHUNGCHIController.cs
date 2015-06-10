using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUNGCHIController
/// </summary>
public class DM_CHUNGCHIController : LinqProvider
{
    public DM_CHUNGCHIController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<DM_CHUNGCHIInfo> GetAll()
    {
        var rs = from t in dataContext.DM_CHUNGCHIs
                 select new DM_CHUNGCHIInfo
                 {
                     MA_CHUNGCHI = t.MA_CHUNGCHI,
                     TEN_CHUNGCHI = t.TEN_CHUNGCHI
                 };
        return rs.ToList();
    }

    public DAL.HOSO_UNGVIEN_CHUNGCHI GetById(int p)
    {
        return dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.ID == p).FirstOrDefault();
    }
}