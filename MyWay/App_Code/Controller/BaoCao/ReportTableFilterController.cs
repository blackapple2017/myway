using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReportTableFilterController
/// </summary>
public class ReportTableFilterController : LinqProvider
{
    public ReportTableFilterController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Lấy các bảng chứa điều kiện lọc theo reportID
    /// @Lê Anh
    /// </summary>
    /// <param name="reportID"></param>
    /// <returns></returns>
    public List<ReportTableFilterInfo> GetTableFilter(int reportID)
    {
        var rs = from t in dataContext.ReportList_ReportTableFilters
                 where t.ReportID == reportID
                 orderby t.Order
                 select new ReportTableFilterInfo
                 {
                     ID = t.ReportFilterID,
                     DescriptionTableName = string.IsNullOrEmpty(t.NewDescriptionTableAlias) ? t.ReportTableFilter.DescriptionTableName : t.NewDescriptionTableAlias,
                     WhereField = t.WhereField
                 };
        return rs.ToList();
    }
}