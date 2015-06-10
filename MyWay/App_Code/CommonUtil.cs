using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoftCore.Security;
using Ext.Net;
using System.IO;
using SoftCore;
using ExtMessage;
using System.Data;

/// <summary>
/// Summary description for AttachFileMethods
/// 
/// daibx   16/09/2013
/// </summary>
public class CommonUtil
{
    public CommonUtil()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static CommonUtil Instance;

    public static CommonUtil GetInstance()
    {
        if (Instance == null)
            Instance = new CommonUtil();
        return Instance;
    }
    /// <summary>
    /// Get Store
    /// </summary>
    /// <param name="storeID"></param>
    /// <param name="handlerFile"></param>
    /// <param name="tableName"></param>
    /// <param name="valueField"></param>
    /// <param name="DisplayField"></param>
    /// <returns></returns>
    public Ext.Net.Store GetStore(string storeID, string handlerFile, string tableName, string valueField, string DisplayField)
    {
        Ext.Net.Store store = new Ext.Net.Store()
        {
            AutoLoad = false,
            ID = storeID,
        };
        store.BaseParams.Add(new Ext.Net.Parameter() { Name = "Table", Value = tableName });
        store.BaseParams.Add(new Ext.Net.Parameter() { Name = "ValueField", Value = valueField });
        store.BaseParams.Add(new Ext.Net.Parameter() { Name = "DisplayField", Value = DisplayField });
        JsonReader jsonReader = new JsonReader();
        jsonReader.IDProperty = "ID";
        jsonReader.Root = "Data";

        HttpProxy proxy = new HttpProxy()
        {
            Method = HttpMethod.GET,
            Url = handlerFile,// "~/Modules/Base/ComboHandler.ashx"
        };
        store.Proxy.Add(proxy);
        string[] columnName = { valueField, DisplayField };
        foreach (var item in columnName)
        {
            RecordField field = new RecordField();
            field.Name = item;
            jsonReader.Fields.Add(field);
        }
        store.Reader.Add(jsonReader);
        return store;
    }
    /// <summary>
    /// Lấy số thứ tự theo tuần trong năm của ngày tháng nhập vào. Mặc định là năm hiện tại
    /// </summary>
    /// <param name="day">Ngày</param>
    /// <param name="month">Tháng</param>
    /// <returns></returns>
    public int GetNumberOfWeek(int day, int month)
    {
        int numberOfDays = 0;
        for (int i = 1; i < month; i++)
        {
            numberOfDays += DateTime.DaysInMonth(DateTime.Now.Year, i);
        }
        numberOfDays += day;
        int weeks = numberOfDays / 7;
        if (numberOfDays % 7 != 0)
            weeks++;
        return weeks;
    }

    /// <summary>
    /// Lấy số thứ tự theo tuần trong năm của ngày tháng nhập vào
    /// </summary>
    /// <param name="day">Ngày cần tìm</param>
    /// <returns></returns>
    public int GetNumberOfWeek(DateTime day)
    {
        int numberOfDays = 0;
        for (int i = 1; i < day.Month; i++)
        {
            numberOfDays += DateTime.DaysInMonth(day.Year, i);
        }
        numberOfDays += day.Day;
        int weeks = numberOfDays / 7;
        if (numberOfDays % 7 != 0)
            weeks++;
        return weeks;
    }

    /// <summary>
    /// Lấy danh sách các ID con của 1 ParentID
    /// Kết quả trả về sẽ là ID1,ID2,....,IDn, và không bao gồm ID truyền vào
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="parentIDValue"></param>
    /// <param name="primaryKeyName"></param>
    /// <param name="parentIDCoumnName"></param>
    /// <returns></returns>
    public string GetChildIDListFromParentID(string tableName, string parentIDValue, string primaryKeyName, string parentIDCoumnName)
    {
        string rs = "";
        string sql = string.Format("select {0} from {1} where {2} = '{3}'", primaryKeyName, tableName, parentIDCoumnName, parentIDValue);
        System.Data.DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable(sql);
        foreach (DataRow row in table.Rows)
        {
            rs += row[0].ToString() + "," + GetChildIDListFromParentID(tableName, row[0].ToString(), primaryKeyName, parentIDCoumnName);
        }
        return rs;
    }
    /// <summary>
    /// Lấy diễn giải thứ ngày tháng của một ngày dạng
    /// Ví dụ như : Thứ 2, Ngày 5 tháng 1 năm 2014
    /// </summary>
    /// <param name="includeDateName"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    public string GetDescriptionDay(bool includeDateName, DateTime date)
    { 
        string desc = "ngày " + date.Day + " tháng " + date.Month + " năm " + date.Year;
        if (includeDateName)
            return Util.GetInstance().GetDateName(date) + "," + desc;
        return desc;
    }

    /// <summary>
    /// Lấy định dạng ngày
    /// </summary>
    /// <returns></returns>
    public string GetDateFormat(DateTime date)
    {
        if (GlobalResourceManager.GetInstance().GetCurrentCulture() == "vi-VN")
            return string.Format("{0:dd/MM/yyyy}", date);
        return string.Format("{0:MM/dd/yyyy}", date);
    }

    /// <summary>
    /// Get only file name from path of file
    /// </summary>
    /// <param name="pathOfFile">the path of file</param>
    /// <returns>the file name</returns>
    public string GetFileName(string pathOfFile)
    {
        int pos = pathOfFile.LastIndexOf('/');
        if (pos == -1)
            pos = pathOfFile.LastIndexOf('\\');
        if (pos != -1)
        {
            return pathOfFile.Substring(pos + 1);
        }
        return "";
    }

    /// <summary>
    /// Get first name and last name from full name
    /// </summary>
    /// <param name="fullName">full name of person</param>
    /// <param name="hoDem">last name</param>
    /// <param name="ten">first name</param>
    public void SplitHoTen(string fullName, out string hoDem, out string ten)
    {
        hoDem = "";
        ten = "";
        int pos = fullName.LastIndexOf(' ');
        if (pos != -1)
        {
            hoDem = fullName.Substring(0, pos).Trim();
            ten = fullName.Substring(pos + 1);
        }
    }

    /// <summary>
    /// Get only first name from full name
    /// </summary>
    /// <param name="fullName">full name of person</param>
    /// <returns>first name</returns>
    public string GetFirstNamFromFullName(string fullName)
    {
        int pos = fullName.LastIndexOf(' ');
        if (pos != -1)
            return fullName.Substring(pos + 1).Trim();
        return "";
    }

    /// <summary>
    /// Get only last name from full name
    /// </summary>
    /// <param name="fullName">full name of person</param>
    /// <returns>last name</returns>
    public string GetLastNameFromFullName(string fullName)
    {
        int pos = fullName.LastIndexOf(' ');
        if (pos != -1)
        {
            return fullName.Substring(0, pos).Trim();
        }
        return "";
    }

    public float GetNumberFromStringFormat(TextField sender, string fractional, string separator)
    {
        string number = sender.Text;
        number = number.Replace(separator, "");
        float rs = float.Parse(number);
        return rs;
    }

    public string GenerateMaSo(string TableName, string ColumnName, string suffix)
    {
        // get full suffix
        suffix = DateTime.Now.Year + "/" + suffix;
        // get max number of constract
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("GetSoHopDongByConfig", "@TableName", "@ColumnName", "@Suffix", TableName, ColumnName, suffix);
        if (table.Rows.Count > 0)   // có số hợp đồng lớn nhất
        {
            string sohd = table.Rows[0]["ColumnName"].ToString();
            int pos = sohd.IndexOf('/');
            if (pos != -1)
            {
                string stt = sohd.Trim().Substring(0, pos);
                int number = int.Parse(stt);
                stt = "000000" + (number + 1);
                stt = stt.Substring(stt.Length - 4);
                stt = stt + "/" + suffix;
                return stt;
            }
        }
        // chưa có số hợp đồng nào theo định dạng
        return "0001/" + suffix;
    }
}