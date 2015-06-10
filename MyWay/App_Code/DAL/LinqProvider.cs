using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DAL;
/// <summary>
/// Summary description for BaseBiz
/// </summary>
public class LinqProvider
{
    protected DBHRMDataContext dataContext;

    public LinqProvider()
    {
        dataContext = new DBHRMDataContext(ConfigurationManager.ConnectionStrings["StandardConfig"].ConnectionString);
    }

    public DBHRMDataContext GetDataContext()
    {
        return dataContext;
    }

    public void Save()
    {
        dataContext.SubmitChanges();
    }

    protected void SubmitChanges()
    {
        try
        {
            dataContext.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }
        catch
        {
            foreach (System.Data.Linq.ObjectChangeConflict occ in dataContext.ChangeConflicts)
            {
                occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
            }
            dataContext.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
        }
    }
}
