using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TracNghiemController
/// @daibx
/// CreatedDate: 19/03/2014
/// UpdatedDate: 19/03/2014
/// </summary>
public class TracNghiemController : LinqProvider
{
	public TracNghiemController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Insert(DAL.TracNghiem tracNghiem)
    {
        if (tracNghiem != null)
        {
            dataContext.TracNghiems.InsertOnSubmit(tracNghiem);
            Save();
        }
    }

    public void Update(DAL.TracNghiem tracNghiem)
    {
        DAL.TracNghiem temp = dataContext.TracNghiems.SingleOrDefault(t => t.ID == tracNghiem.ID);
        if (temp != null)
        {
            temp.CriterionID = tracNghiem.CriterionID;
            temp.ExplainName = tracNghiem.ExplainName;
            temp.MaxPoint = tracNghiem.MaxPoint;
            temp.MinPoint = tracNghiem.MinPoint;
            temp.Order = tracNghiem.Order;
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.TracNghiem temp = dataContext.TracNghiems.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.TracNghiems.DeleteOnSubmit(temp);
            Save();
        }
    }

    public List<TracNghiemInfo> GetByCriterionID(string criterionID)
    {
        var rs = from t in dataContext.TracNghiems
                 where t.CriterionID == criterionID
                 select new TracNghiemInfo
                 {
                     CriterionID = t.CriterionID,
                     ExplainName = t.ExplainName,
                     ID = t.ID,
                     MaxPoint = t.MaxPoint,
                     MinPoint = t.MinPoint,
                     Order = t.Order
                 };
        return rs.OrderBy(t => t.Order).ToList();
    }
}