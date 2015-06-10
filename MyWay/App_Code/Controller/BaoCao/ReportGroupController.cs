using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DM_ReportGroupController
/// </summary>
public class ReportGroupController : LinqProvider
{
    public ReportGroupController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<ReportGroup> GetReportGroupByParentID(string parentID, bool display)
    {
        return dataContext.ReportGroups.Where(t => t.DISPLAY == display && t.PARENT_ID == parentID).ToList();
    }

    public List<ReportGroup> GetAllReportGroup()
    {
        return dataContext.ReportGroups.Where(t => t.DISPLAY == true).ToList();
    }

    public List<MiniReportInfo> GetReportByGroupID(string GroupID)
    {
        var rs = from t in dataContext.ReportLists
                 where t.REPORT_GROUP_ID == GroupID && t.DISPLAY == true
                 select new MiniReportInfo
                 {
                     ID = t.ID,
                     Name = t.REPORT_NAME,
                     Tooltip = t.TOOLTIP,
                     ImageReportPreview = t.IMAGE_REPORT_PREVIEW,
                     Javascript = t.JAVASCRIPT
                 };
        return rs.ToList();
    }
}