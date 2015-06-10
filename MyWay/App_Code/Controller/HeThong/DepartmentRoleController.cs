using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentRoleController
/// </summary>
public class DepartmentRoleController : LinqProvider
{
    public DepartmentRoleController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public const string DONVI_GOC = "0";

    public const int MENUID_DESKTOP = 1;
    public const int MENUID_CHART = 2;
    public const int MENUID_EMPLOYEE = 3;
    public const int MENUID_BIRTHDAY = 4;
    public const int MENUID_CONTRACT = 5;

    /// <summary>
    /// Lấy những đơn vị mà role có quyền kiểm soát (Thêm, sửa, xóa)
    /// </summary>
    /// <param name="roleID"></param>
    /// <returns></returns>
    public string GetMaDonViByRole(int roleID, int menuID)
    {
        return (from t in dataContext.Role_DonVi_Menus
                where t.RoleID == roleID && t.MenuID == menuID
                select t.DanhSachMaDonVi).FirstOrDefault();
    }

    public string GetMaBoPhanByRole(int userID, int menuID)
    {
        string sql = "SELECT MA_DONVI FROM f_GetDanhSachBoPhan(" + userID + "," + menuID + ")";
        return DataController.DataHandler.GetInstance().ExecuteScalar(sql).ToString();
    }
    /// <summary>
    /// Cấp phát thêm mã đơn vị cho quyền
    /// </summary>
    /// <param name="roleID"></param>
    /// <param name="menuID"></param>
    /// <param name="departmentIDList"></param>
    public bool AllowPermission(int roleID, int menuID, string departmentIDList)
    {
        try
        {
            DAL.Role_DonVi_Menu existing = dataContext.Role_DonVi_Menus.Where(t => t.MenuID == menuID && t.RoleID == roleID).FirstOrDefault();
            if (existing == null)
            {
                DAL.Role_DonVi_Menu item = new DAL.Role_DonVi_Menu()
                {
                    RoleID = roleID,
                    MenuID = menuID,
                    DanhSachMaDonVi = departmentIDList,
                };
                dataContext.Role_DonVi_Menus.InsertOnSubmit(item);
                Save();
                return true;
            }
            else
            {
                string[] id = departmentIDList.Split(',');
                string mdvList = "," + existing.DanhSachMaDonVi + ",";
                foreach (var item in id)
                {
                    if (!string.IsNullOrEmpty(item) && !mdvList.Contains("," + item + ","))
                    {
                        if (string.IsNullOrEmpty(existing.DanhSachMaDonVi))
                        {
                            existing.DanhSachMaDonVi += item;
                        }
                        else
                            existing.DanhSachMaDonVi += "," + item;
                    }
                }
                Save();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    public DAL.Role_DonVi_Menu Get(int roleID, int menuID)
    {
        return dataContext.Role_DonVi_Menus.Where(t => t.MenuID == menuID && t.RoleID == roleID).FirstOrDefault();
    }
    /// <summary>
    /// Hủy xem đơn vị của một quyền nào đó
    /// </summary>
    /// <param name="roleID"></param>
    /// <param name="menuID"></param>
    /// <param name="departmentIDList"></param>
    /// <returns></returns>
    public bool DenyPermission(int roleID, int menuID, string departmentIDList)
    {
        DAL.Role_DonVi_Menu existing = dataContext.Role_DonVi_Menus.Where(t => t.MenuID == menuID && t.RoleID == roleID).FirstOrDefault();
        if (existing != null)
        {
            string[] id = departmentIDList.Split(',');
            string mdvList = "," + existing.DanhSachMaDonVi + ",";
            foreach (var item in id)
            {
                if (!string.IsNullOrEmpty(item) && mdvList.Contains("," + item + ","))
                {
                    mdvList = mdvList.Replace("," + item + ",", ",");
                }
            }
            if (mdvList[0] == ',')
            {
                mdvList = mdvList.Substring(1);
            }
            if (!string.IsNullOrEmpty(mdvList) && mdvList[mdvList.Length - 1] == ',')
            {
                mdvList = mdvList.Remove(mdvList.LastIndexOf(","));
            }
            existing.DanhSachMaDonVi = mdvList;
            Save();
            return true;
        }
        return false;
    }
    /// <summary>
    /// Hủy toàn bộ quyền của một menu
    /// @Lê Anh
    /// </summary>
    /// <param name="roleID"></param>
    /// <param name="menuID"></param>
    /// <returns></returns>
    public bool DenyAll(int roleID, int menuID)
    {
        DAL.Role_DonVi_Menu existing = Get(roleID, menuID);
        if (existing != null)
        {
            existing.DanhSachMaDonVi = "";
            Save();
            return true;
        }
        return false;
    }
}