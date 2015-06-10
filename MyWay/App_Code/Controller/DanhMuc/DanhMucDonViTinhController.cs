using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhMucDonViTinhController
/// </summary>
public class DanhMucDonViTinhController : LinqProvider
{
	public DanhMucDonViTinhController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<DAL.DM_DVT> GetByAll()
    {
        var rs = from t in dataContext.DM_DVTs
                 select t;
        return rs.ToList();
    }

    public void Delete(string maDVT)
    {
        var tmp = dataContext.DM_DVTs.SingleOrDefault(t => t.MA_DVT == maDVT);
        if (tmp != null)
        {
            dataContext.DM_DVTs.DeleteOnSubmit(tmp);
            Save();
        }
    }

    public void Insert(DAL.DM_DVT dvt)
    {
        dataContext.DM_DVTs.InsertOnSubmit(dvt);
        Save();
    }

    public void Update(DAL.DM_DVT dvt)
    {
        var tmp = dataContext.DM_DVTs.SingleOrDefault(t => t.MA_DVT == dvt.MA_DVT);
        if (tmp != null)
        {
            tmp.TEN_DVT = dvt.TEN_DVT;
            tmp.GHI_CHU = dvt.GHI_CHU;
            tmp.DATE_CREATE = dvt.DATE_CREATE;
            tmp.MA_DONVI = dvt.MA_DONVI;
            tmp.USERNAME = dvt.USERNAME;
            Save();
        }
    }
}