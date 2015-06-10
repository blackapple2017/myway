using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TimeSheetConfigController
/// </summary>
public class TimeSheetConfigController
{
    public TimeSheetConfigController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable getAll()
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM ChamCong.TimeSheetConfig ORDER BY [ORDER] ASC");
    }
    public void Update(int ID, string field, string value, string columnID)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateTimeSheetConfig", "@id", "@field", "@newValue","@columnID", ID, field, value, columnID);
    }
    public List<Ext.Net.Column> GetTimeSheetColumnList()
    {
        List<Ext.Net.Column> columnList = new List<Ext.Net.Column>();
        foreach (var item in GetAllTimeSheetConfigInfo())
        {
            Ext.Net.Column column = new Ext.Net.Column()
            {
                ColumnID = item.ColumnName,//this meaning dataIndex
                DataIndex = item.ColumnName,
                Header = item.ColumnDescription,
                Width = item.Width,
                Editable = true
            };
            if (!string.IsNullOrEmpty(item.RenderJS))
            {
                column.Renderer.Fn = item.RenderJS;
            }
            columnList.Add(column);
        }
        return columnList;
    }
    public List<TimeSheetConfigInfo> GetAllTimeSheetConfigInfo()
    {
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM ChamCong.TimeSheetConfig WHERE DisplayOnGrid = 1 ORDER BY [ORDER] ASC");
        List<TimeSheetConfigInfo> result = new List<TimeSheetConfigInfo>();
        foreach (DataRow item in table.Rows)
        {
            TimeSheetConfigInfo itemConfig = new TimeSheetConfigInfo()
            {
                ColumnDescription = item["ColumnDescription"].ToString(),
                ColumnName = item["ColumnName"].ToString(),
                Width = int.Parse("0" + item["Width"].ToString()),
                RenderJS = item["RenderJS"].ToString()
            };
            result.Add(itemConfig);
        }
        return result;
    }
}