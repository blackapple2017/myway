using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;
using DataController;

/// <summary>
/// Summary description for HETHONGController
/// </summary>
public class HeThongController
{
    public HeThongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetValueByName(string ParameterName, string MaDonVi)
    {
        Object objData = DataHandler.GetInstance().ExecuteScalar("SystemConfig_GetParameterValueByName", "@ParemeterName", "@MaDonVi", ParameterName, MaDonVi);
        if (objData != null)
        {
            return objData.ToString();
        }
        return string.Empty;
    }

    public int SaveValue(string ParameterName, string Value, string MaDonVi)
    {
        return DataHandler.GetInstance().ExecuteNonQuery("SystemConfig_SaveValue", "@ParameterName", "@ParameterValue", "@MaDonVi", ParameterName, Value, MaDonVi);
    }

    public int CreateParameter(string ParameterName, string Value, string MaDonVi, int CreatedUser)
    {
        return DataHandler.GetInstance().ExecuteNonQuery("SystemConfig_CreateParameter", "@ParameterName", "@ParameterValue",
                                                                                         "@MaDonVi", "@CreatedUser", ParameterName, Value, MaDonVi, CreatedUser);
    }
    /// <summary>
    /// Tạo mới hoặc lưu giá trị của tham số
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="paramValue"></param>
    /// <param name="createdUser"></param>
    /// <param name="maDonVi"></param>
    public void CreateOrSave(string paramName, string paramValue, int createdUser, string maDonVi)
    {
        DataHandler.GetInstance().ExecuteNonQuery("SystemConfig_AddParameter", "@ParameterName", "@ParameterValue",
                                                  "@CreatedUser", "@CreatedBy", "@MaDonVi",
                                                  paramName, paramValue, createdUser, createdUser, maDonVi);

    }

    public string GetValueByCity(string s) //xoa ngay ham nay
    {
        return "";
    }

    public string GetValueByCompanyName(string n) //xoa ham nay ngay
    {
        return "";
    }
}