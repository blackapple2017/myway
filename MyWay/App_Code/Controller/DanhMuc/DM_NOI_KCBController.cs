using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_NOI_KCBController
/// </summary>
public class DM_NOI_KCBController : LinqProvider
{
	public DM_NOI_KCBController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_NOI_KCB> GetByAll()
    {
        var rs = from t in dataContext.DM_NOI_KCBs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_NOI_KCBs
                 select new StoreComboObject
                 {
                     MA = t.MA_NOI_KCB,
                     TEN = t.TEN_NOI_KCB
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }

    public List<DMNoiKCBInfo> GetNoiKCB(string madonvi, string searchkey, int start, int limit, out int count)
    {
        List<DMNoiKCBInfo> rs=(from t in dataContext.DM_NOI_KCBs
                               where (string.IsNullOrEmpty(searchkey)?1==1:(System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_NOI_KCB,searchkey)))
                               orderby t.TEN_NOI_KCB
                               select new DMNoiKCBInfo
                               {
                                   MaNoiKCB=t.MA_NOI_KCB,
                                   TenNoiKCB=t.TEN_NOI_KCB
                               }).ToList();
        count=rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
    //DucAnh lay id tra ve ten 
    public string GetTenByMa(string ma)
    {
        var rs = dataContext.DM_NOI_KCBs.Where(p => p.MA_NOI_KCB == ma).SingleOrDefault();
        if (rs != null) return rs.TEN_NOI_KCB;
        else return "";
    }
}