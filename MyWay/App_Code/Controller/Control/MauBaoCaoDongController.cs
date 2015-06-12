using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for MauBaoCaoDongController
/// </summary>
public class MauBaoCaoDongController: LinqProvider
{
	public MauBaoCaoDongController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void InsertMauBCD(MauBaoCaoDong baocaodong)
    {
        dataContext.MauBaoCaoDongs.InsertOnSubmit(baocaodong);
        Save();
    }
    public IEnumerable<DAL.MauBaoCaoDong> GetByName()
    {
        return dataContext.MauBaoCaoDongs.OrderBy(t => t.ReportName);
    }
    public MauBaoCaoDongInfo GetContent(int ID)
    {
        var rs = from t in dataContext.MauBaoCaoDongs
                 where t.ID == ID
                 select new MauBaoCaoDongInfo { 
                    ID = t.ID,
                    ReportContent = t.ReportContent,
                    ReportName = t.ReportName,
                 };
        return rs.FirstOrDefault();
    }

    public void Update(DAL.MauBaoCaoDong baocao)
    {
        var bcd = dataContext.MauBaoCaoDongs.SingleOrDefault(t => t.ID == baocao.ID);
        if (bcd != null)
        {
            bcd.ReportContent = baocao.ReportContent;
            bcd.EditedDate = baocao.EditedDate;
            bcd.EditedBy = baocao.EditedBy;
            Save();
        }
    }
    public void Delete(int id)
    {
        DAL.MauBaoCaoDong bcd = dataContext.MauBaoCaoDongs.Where(t => t.ID == id).FirstOrDefault();
        dataContext.MauBaoCaoDongs.DeleteOnSubmit(bcd);
        Save();
    }
}