using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReportWorldgame
/// </summary>
public class ReportWorldgame
{
    public ReportWorldgame()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Lấy tên chi nhánh để đưa vào báo cáo
    /// </summary>
    /// <param name="departmentID"></param>
    /// <returns></returns>
    public string GetLocationName(string departmentID)
    {
        DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("report_WGGetChiNhanh", "@mabophan", departmentID);
        string location = "";
        foreach (DataRow row in data.Rows)
        {
            location += row["DIA_CHI"].ToString() + ", ";
        }
        if (!string.IsNullOrEmpty(location))
        {
            return "Chi nhánh : " + location.Remove(location.LastIndexOf(","));
        }
        return location;
    }
}