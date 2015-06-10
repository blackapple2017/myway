using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DataController;

/// <summary>
/// Summary description for SalaryBoardConfigController
/// </summary>
public class SalaryBoardConfigController : LinqProvider
{
    public SalaryBoardConfigController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Update(int ID, decimal MenuID, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateSalaryBoardConfig", "@id", "@MenuID", "@field", "@newValue", ID, MenuID, field, value);
    }
    /// <summary>
    /// Tạm thời chưa xét đến
    /// @Ngô Công Vĩ
    /// </summary>
    /// <param name="MenuID"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    public void Insert(decimal MenuID, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_InsertSalaryBoardConfig", "@MenuID", "@field", "@newValue", MenuID, field, value);
    }
    public void Insert(DAL.SalaryBoardConfig info)
    {
        //DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_AddRecordSalaryBoardConfig",
        //    "@MenuID", "@Order", "@ColumnName", "@ColumnDescription", "@DisplayOnGrid", "@IsInUsed", "@AllowEditOnGrid",
        //info.MenuID, info.Order, info.ColumnName, info.ColumnDescription, info.DisplayOnGrid, info.IsInUsed, info.AllowEditOnGrid);
        dataContext.SalaryBoardConfigs.InsertOnSubmit(info);
        Save();
    }
    public void Delete(int ID)
    {
        DAL.SalaryBoardConfig tmp = dataContext.SalaryBoardConfigs.SingleOrDefault(t => t.ID == ID);
        if (tmp != null)
        {
            dataContext.SalaryBoardConfigs.DeleteOnSubmit(tmp);
            Save();
        }
    }
    /// <summary>
    /// Lấy các cấu hình bảng lương dựa vào menuID
    /// @Lê Anh
    /// </summary>
    /// <param name="menuID"></param>
    /// <returns></returns>
    public List<SalaryBoardConfigInfo> GetSalaryConfigByMenuID(int menuID)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("TienLuong_GetSalaryConfig", "@menuID", menuID);
        List<SalaryBoardConfigInfo> result = new List<SalaryBoardConfigInfo>();
        foreach (DataRow item in table.Rows)
        {
            SalaryBoardConfigInfo itemConfig = new SalaryBoardConfigInfo()
            {
                AllowSum = bool.Parse(item["AllowSum"].ToString()),
                ColumnDescription = item["ColumnDescription"].ToString(),
                ColumnName = item["ColumnName"].ToString(),
                Width = int.Parse("0" + item["Width"].ToString()),
                RenderJS = item["RenderJS"].ToString(),
                EditOnGrid = bool.Parse(item["AllowEditOnGrid"].ToString())
            };
            result.Add(itemConfig);
        }
        return result;
    }

    /// <summary>
    /// Lấy các cột để hiển thị lên grid cho bảng lương
    /// </summary>
    /// <param name="menuID"></param>
    /// <returns></returns>
    public List<Ext.Net.Column> GetSalaryColumnList(int menuID)
    {
        List<Ext.Net.Column> columnList = new List<Ext.Net.Column>();
        foreach (var item in GetSalaryConfigByMenuID(menuID))
        {
            Ext.Net.Column column = new Ext.Net.Column()
            {
                ColumnID = item.ColumnName,//this meaning dataIndex
                DataIndex = item.ColumnName,
                Header = item.ColumnDescription,
                Width = item.Width,
                Editable = item.EditOnGrid,
            };
            if (!item.EditOnGrid)
            {
                column.Css = "background:#E1E5F1;";
            }
            if (!string.IsNullOrEmpty(item.RenderJS))
            {
                column.Renderer.Fn = item.RenderJS;
            }
            columnList.Add(column);
        }
        return columnList;
    }

    public List<SalaryBoardConfigInfo> GetSalaryBoardConfig(int menuID)
    {
        List<SalaryBoardConfigInfo> lists = new List<SalaryBoardConfigInfo>();
        foreach (var item in GetSalaryConfigByMenuID(menuID))
        {
            SalaryBoardConfigInfo info = new SalaryBoardConfigInfo()
            {
                AllowSum = item.AllowSum,
                ColumnDescription = item.ColumnDescription,
                ColumnName = item.ColumnName,
                RenderJS = item.RenderJS,
                Width = item.Width,
                EditOnGrid = item.EditOnGrid
            };
            lists.Add(info);
        }
        return lists;
    }
}