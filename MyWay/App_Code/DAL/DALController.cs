using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DALController
/// </summary>
public class DALController
{
    public DALController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region singleton

    private static DALController Instance { get; set; }

    public static DALController GetInstance()
    {
        if (Instance == null)
        {
            Instance = new DALController();
        }
        return Instance;
    }

    #endregion

    private string ColumnName { get; set; }
    private string ValueList { get; set; }
    private string UpdateQuery { get; set; }

    /// <summary>
    /// Tiến hành insert một bản ghi vào CSDL
    /// </summary>
    /// <param name="wrapperComponent">container chứa các control</param>
    /// <param name="tableName">Tên bảng muốn insert</param>
    /// <returns></returns>
    /// 
    
    public bool Add(Ext.Net.Component wrapperComponent, string tableName)
    {
        try
        {
            string sql = "insert into " + tableName + "({0}) values({1})";
            GetChildControl(wrapperComponent);
       //     sql = string.Format(sql, ColumnName.Remove(ColumnName.LastIndexOf(",")), ValueList.Remove(ValueList.LastIndexOf(",")));
            return (DataController.DataHandler.GetInstance().ExecuteNonQuery(string.Format(sql, ColumnName.Remove(ColumnName.LastIndexOf(",")), ValueList.Remove(ValueList.LastIndexOf(",")))) > 0);
        }
        catch (Exception ex)
        {
            throw ex;
        } 
    }

     public bool Add(Ext.Net.Component wrapperComponent, string tableName, string[] parameters,  string [] values)
    {
        try
        {
            string sql = "insert into " + tableName + "({0}) values({1})";

            for(int i=0; i<parameters.Count();i++)
            {
             if (!string.IsNullOrEmpty(parameters[i]))
            {
                ColumnName += "[" + parameters[i] + "],";
                ValueList += "N'" + values[i] + "',";
                UpdateQuery += "[" + parameters[i] + "] = N'" +  values[i] + "',";
            }
            }
            GetChildControl(wrapperComponent);
       //     sql = string.Format(sql, ColumnName.Remove(ColumnName.LastIndexOf(",")), ValueList.Remove(ValueList.LastIndexOf(",")));
            return (DataController.DataHandler.GetInstance().ExecuteNonQuery(string.Format(sql, ColumnName.Remove(ColumnName.LastIndexOf(",")), ValueList.Remove(ValueList.LastIndexOf(",")))) > 0);
        }
        catch (Exception ex)
        {
            throw ex;
        } 
    }

    public bool Update(Ext.Net.Component wrapperComponent, string tableName, string primaryKeyValue)
    {
        try
        {
            string sql = "update " + tableName + " set {0} where #### = N'" + primaryKeyValue + "'";
            GetChildControl(wrapperComponent);
            sql = string.Format(sql, UpdateQuery.Remove(UpdateQuery.LastIndexOf(",")));
            return DataController.DataHandler.GetInstance().ExecuteNonQuery("DAL_Update", "@sqlQuery", "@tableName", "@primaryKeyValue", sql, tableName, primaryKeyValue) > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void Delete(string tableName, object primaryKeyValue)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DAL_Delete", "@TableName", "@PrimaryKeyValue", tableName, primaryKeyValue.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region phụ trợ

    public void GetChildControl(Ext.Net.Component wrapperComponent)
    {
        switch (wrapperComponent.ToString())
        {
            case "Ext.Net.Window":
                Ext.Net.Window window = (Ext.Net.Window)wrapperComponent;
                GenSql(window.Items);
                break;
            case "Ext.Net.Container":
                Ext.Net.Container ctainer = (Ext.Net.Container)wrapperComponent;
                GenSql(ctainer.Items);
                break;
            case "Ext.Net.FieldSet":
                Ext.Net.FieldSet fs = (Ext.Net.FieldSet)wrapperComponent;
                GenSql(fs.Items);
                break;
            default:
                break;
        }
    }

    private void GenSql(Ext.Net.ItemsCollection<Ext.Net.Component> collection)
    {
        object value = "";
        foreach (var item in collection)
        {
            string colName = GetFieldName(item, ref value);
            if (!string.IsNullOrEmpty(colName))
            {
                ColumnName += "[" + colName + "],";
                ValueList += "N'" + value + "',";
                UpdateQuery += "[" + colName + "] = N'" + value + "',";
            }
        }
    }

    /// <summary>
    /// Lấy fieldname và giá trị
    /// </summary>
    /// <param name="control"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private string GetFieldName(Ext.Net.Component control, ref object value)
    {
        switch (control.ToString())
        {
            case "Ext.Net.TextField":
                Ext.Net.TextField txtControl = (Ext.Net.TextField)control;
                value = txtControl.Text;
                if (!txtControl.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return txtControl.ID.Substring(txtControl.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.Hidden":
                Ext.Net.Hidden hdfControl = (Ext.Net.Hidden)control;
                value = hdfControl.Text;
                if (!hdfControl.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return hdfControl.ID.Substring(hdfControl.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.Checkbox":
                Ext.Net.Checkbox chk = (Ext.Net.Checkbox)control;
                value = chk.Checked==true ? 1 : 0;
                if (!chk.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return chk.ID.Substring(chk.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.DateField":
                Ext.Net.DateField dfDate = (Ext.Net.DateField)control;
                if (!SoftCore.Util.GetInstance().IsDateNull(dfDate.SelectedDate))
                {
                    value = dfDate.SelectedDate.Month + "/" + dfDate.SelectedDate.Day + "/" + dfDate.SelectedDate.Year;
                }
                else
                    value = "";
                if (!dfDate.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return dfDate.ID.Substring(dfDate.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.NumberField":
                Ext.Net.NumberField nbf = (Ext.Net.NumberField)control;
                value = nbf.Text;
                if (!nbf.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return nbf.ID.Substring(nbf.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.ComboBox":
                Ext.Net.ComboBox cbBox = (Ext.Net.ComboBox)control;
                value = cbBox.SelectedItem.Value;
                if (!cbBox.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return cbBox.ID.Substring(cbBox.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.SpinnerField":
                Ext.Net.SpinnerField spinnerField = (Ext.Net.SpinnerField)control;
                value = spinnerField.Text;
                if (!spinnerField.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return spinnerField.ID.Substring(spinnerField.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.TextArea":
                Ext.Net.TextArea txtArea = (Ext.Net.TextArea)control;
                value = txtArea.Text;
                if (!txtArea.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return txtArea.ID.Substring(txtArea.ID.IndexOf("_") + 1);
                }
            case "Ext.Net.Container":
                Ext.Net.Container cContainer = (Ext.Net.Container)control;
                GetChildControl(cContainer);
                break;
            case "Ext.Net.FieldSet":
                Ext.Net.FieldSet fieldSet = (Ext.Net.FieldSet)control;
                GetChildControl(fieldSet);
                break;
            case "Ext.Net.HtmlEditor":
                Ext.Net.HtmlEditor htmlEditor = (Ext.Net.HtmlEditor)control;
                value = htmlEditor.Text;
                if (!htmlEditor.ID.Contains("_"))
                {
                    return "";
                }
                else
                {
                    return htmlEditor.ID.Substring(htmlEditor.ID.IndexOf("_") + 1);
                }
        }
        return "";
    }

    #endregion
}