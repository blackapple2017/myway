using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
using SoftCore.Menu;
using DataController;
using SoftCore.Function;
using System.Data;
/// <summary>
/// Author : Lê Văn Anh
/// </summary>
public partial class Modules_Role_Default : WebBase
{
    enum RoleCommand { Update, Insert };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            LoadMenu();
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }

    private void LoadMenu()
    {
        List<MenuInfo> menuList = MenuController.GetInstance().GetMenus(-1, false, true);
        string s = "";
        foreach (var item in menuList)
        {
            s += string.Format("<li id='{0}'>{1}{2}</li>", item.ID, item.MenuName, BindChildMenu(item.ID));
        }
        ldlMenuTree.Text = s;
    }

    private string BindChildMenu(int parentID)
    {
        List<MenuInfo> menuList = MenuController.GetInstance().GetMenus(parentID, false, false);
        if (menuList.Count() == 0)
        {
            return "";
        }
        string str = "";
        string function = "";
        foreach (var item in menuList)
        {
            BindFunctionOfMenu(item.ID);
            str += string.Format("<li id='{0}'>{1}{2}{3}</li>", item.ID, item.MenuName, BindChildMenu(item.ID), function);
        }
        return string.Format("<ul>{0}</ul>", str);
    }

    /// <summary>
    /// Bind danh sách các nút chức năng trên form
    /// </summary>
    /// <param name="child"></param>
    /// <param name="parentID">MenuID</param>
    private string BindFunctionOfMenu(int menuID)
    {

        FunctionController controller = new FunctionController();
        List<FunctionInfo> functionInfoList = controller.GetFunctionByMenuId(menuID);
        string rs = "";
        foreach (var item in functionInfoList)
        {
            //rs += string.Format("<li id='F{0}'>[{1}]</li>", item.ID, item.ControlText);
            if (item.ParentID == -1)    // la cha
            {
                List<FunctionInfo> childList = controller.GetByParentID(item.ID);
                string cap2 = "";
                foreach (FunctionInfo tmp in childList)
                {
                    List<FunctionInfo> chauList = controller.GetByParentID(tmp.ID);
                    string cap3 = "";
                    foreach (FunctionInfo t in chauList)
                    {
                        cap3 += string.Format("<li id='F{0}'>[{1}]</li>", t.ID, t.Description);
                    }
                    if (cap3 != "")
                        cap3 = "<ul>" + cap3 + "</ul>";

                    cap2 += string.Format("<li id='F{0}'>[{1}]{2}</li>", tmp.ID, tmp.Description, cap3);
                }
                if (cap2 != "")
                    cap2 = "<ul>" + cap2 + "</ul>";
                rs += string.Format("<li id='F{0}'>[{1}]{2}</li>", item.ID, item.Description, cap2);
            }
            //else
            //{
            //    rs += string.Format("<li id='F{0}'>[{1}]</li>", item.ID, item.ControlText);
            //}
        }
        if (!string.IsNullOrEmpty(rs))
        {
            rs = "<div class='functionTree' id='functionTree{0}' style='display:none;'><ul>" + rs + "</ul></div>";
        }

        Literal1.Text += string.Format(rs, menuID);
        return rs;
    }

    [DirectMethod]
    public void LoadMenuOfRole()
    {
        List<int> menuID = MenuController.GetInstance().GetMenuIDOfRole(int.Parse(hdfRecordID.Text), false); //Chỉ lấy các node được checked, còn undefine thì ko lấy
        hdfMenusOfRole.Text = "";
        foreach (var item in menuID)
        {
            hdfMenusOfRole.Text += item + ",";
        }
        //Lấy các function của role
        hdfFunctionOfMenu.Text = "";
        List<FunctionFullInfo> functionList = FunctionController.GetInstance().GetFunctionsOfRole(int.Parse(hdfRecordID.Text));
        foreach (var item in functionList)
        {
            hdfFunctionOfMenu.Text += item.ID + ";" + item.IsUndefined + ",";
        }
        //List<Function_RoleInfo> funcRoleList = FunctionController.GetInstance().Get
        RM.RegisterClientScriptBlock("ds", "checkItem();");
    }

    protected void btnDuplicateRole_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataHandler.GetInstance().ExecuteNonQuery("role_DuplicateRole", "@sessionMaDonVi", "@createdBy", "@roleName", "@Description", "@oldRoleID",
                Session["MaDonVi"].ToString(), CurrentUser.ID, txtRoleName.Text, txtDescription.Text, hdfRecordID.Text);
            RM.RegisterClientScriptBlock("ds", "#{Store1}.reload();");
            wdAddRole.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void UpdateRoleForMenu(string checkedNode, string undefinedNode, string selectedFunction)
    {
        try
        {
            //Thêm các node được check, tức là ko undefined
            string[] roleArr = checkedNode.Split(',');
            string menuIDNeedToDelete = "";
            int roleID = int.Parse(hdfRecordID.Text);
            FunctionController.GetInstance().RemoveRoleInAllFunction(roleID); //xóa tất cả các chức năng của role để thiết lập lại cho dễ
            foreach (var item in roleArr)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(item) && item.StartsWith("F") == false)
                {
                    MenuController.GetInstance().AddRole(int.Parse(item), roleID, CurrentUser.ID, false);
                    menuIDNeedToDelete += item + ",";
                }
            }
            //thêm các nút undefined
            string[] undefinedRoleArr = undefinedNode.Split(',');
            foreach (var item in undefinedRoleArr)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                if (item.StartsWith("F") == false)
                {
                    MenuController.GetInstance().AddRole(int.Parse(item), roleID, CurrentUser.ID, true);
                    menuIDNeedToDelete += item + ",";
                }
            }
            //Xóa đi những menu mà bị hủy khỏi role
            if (menuIDNeedToDelete.LastIndexOf(',') != -1)
                DataHandler.GetInstance().ExecuteNonQuery("delete from Menu_Role where RoleID = " + hdfRecordID.Text + " and MenuID not in (" + menuIDNeedToDelete.Remove(menuIDNeedToDelete.LastIndexOf(',')) + ")");
            else
                DataHandler.GetInstance().ExecuteNonQuery("delete from Menu_Role where RoleID = " + hdfRecordID.Text);

            //Lưu function
            string[] tmpFunction = selectedFunction.Split(',');
            foreach (var item in tmpFunction)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    //FunctionController.GetInstance().AddRoleToFunction(int.Parse(item), roleID);
                    string[] tmp = item.Split(';');

                    Function_RoleInfo funcInfo = new Function_RoleInfo()
                    {
                        RoleID = roleID,
                        FunctionID = int.Parse(tmp[0]),
                        IsUndefined = bool.Parse(tmp[1]),
                        CreatedBy = CurrentUser.ID,
                        CreatedDate = DateTime.Now
                    };

                    Function_RoleInfo funcRoleInfo = FunctionController.GetInstance().GetFunctionRoleByMenuIDAndFunctionID(int.Parse(tmp[0]), roleID);
                    if (funcRoleInfo == null) // chưa có
                    {
                        FunctionController.GetInstance().AddRoleToFunction(funcInfo);
                    }
                    else
                    {
                        funcInfo.ID = funcRoleInfo.ID;
                        FunctionController.GetInstance().UpdateFunctionRole(funcInfo);
                    }
                }
            }
            Dialog.ShowNotification("Thiết lập quyền thành công");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddRole.Title = "Thêm mới quyền";
        wdAddRole.Icon = Icon.KeyAdd;
        RM.RegisterClientScriptBlock("ds", "#{Store1}.reload();");
    }

    [DirectMethod]
    public void DeleteRole(int id)
    {
        try
        {
            RoleController.GetInstance().DeleteRole(id);
            hdfRecordID.Text = "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa được vì dữ liệu này đang được sử dụng ở một bảng khác").Show();
            }
            else
                X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnEditRole_Click(object sender, DirectEventArgs e)
    {
        try
        {
            RoleInfo roleInfo = RoleController.GetInstance().GetRole(int.Parse(hdfRecordID.Text));
            txtRoleName.Text = roleInfo.RoleName;
            txtDescription.Text = roleInfo.Description;
            txtRoleCommand.Text = "Update";
            wdAddRole.Title = "Sửa đổi thông tin quyền";
            wdAddRole.Show();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void grpDepartmentStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfRecordID.Text))
            {
                return;
            }
            string departmentList = "," + new DepartmentRoleController().GetMaDonViByRole(int.Parse("0" + hdfRecordID.Text), int.Parse("0" + cbMenuList.SelectedItem.Value)) + ",";
            List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID("0");//(Session["MaDonVi"].ToString());
            List<object> obj = new List<object>();

            foreach (var info in lists)
            {
                obj.Add(new { MA = info.MA, TEN = "<b>" + info.TEN + "</b>", Check = departmentList.Contains("," + info.MA + ",") });
                obj = LoadMenuCon(obj, info.MA, 1, departmentList);
            }
            grpDepartmentStore.DataSource = obj;
            grpDepartmentStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void grpDepartment_RowDblClick(object sender, DirectEventArgs e)
    {
        try
        {
            bool flag = false;
            if (e.ExtraParams["Checked"] == "true")
            {
                flag = new DepartmentRoleController().DenyPermission(int.Parse("0" + hdfRecordID.Text), int.Parse("0" + cbMenuList.SelectedItem.Value), e.ExtraParams["DepartmentID"]);
            }
            else
            {
                flag = new DepartmentRoleController().AllowPermission(int.Parse("0" + hdfRecordID.Text), int.Parse("0" + cbMenuList.SelectedItem.Value), e.ExtraParams["DepartmentID"]);

            }
            if (flag)
            {
                grpDepartment.Reload();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnAllow_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string id = "";
            if (e.ExtraParams["Command"] == "AllowSelected")
            {
                foreach (var item in RowSelectionModel2.SelectedRows)
                {
                    id += item.RecordID + ",";
                }
            }
            else
            {
                foreach (var item in new DM_DONVIController().GetAllMaDonVi())
                {
                    id += item + ",";
                }
            }
            if (!string.IsNullOrEmpty(id))
            {
                id = id.Remove(id.LastIndexOf(","));
            }
            new DepartmentRoleController().AllowPermission(int.Parse("0" + hdfRecordID.Text), int.Parse("0" + cbMenuList.SelectedItem.Value), id);
            grpDepartment.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnDeny_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (e.ExtraParams["Command"] == "DenySelected")
            {
                string id = "";
                foreach (var item in RowSelectionModel2.SelectedRows)
                {
                    id += item.RecordID + ",";
                }
                new DepartmentRoleController().DenyPermission(int.Parse("0" + hdfRecordID.Text), int.Parse("0" + cbMenuList.SelectedItem.Value), id);
            }
            else
            {
                new DepartmentRoleController().DenyAll(int.Parse("0" + hdfRecordID.Text), int.Parse("0" + cbMenuList.SelectedItem.Value));
            }
            grpDepartment.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbMenuListStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<object> menuList = new List<object>();
            List<MenuForSetPermissionInfo> lists = new MenuForSetPermissionController().GetByParentID(0);
            foreach (var menuItem in lists)
            {
                menuList.Add(new { ID = menuItem.MenuID, MenuName = menuItem.MenuName });
                menuList = GetChildMenu(menuList, menuItem.MenuID, 1);
            }
            cbMenuListStore.DataSource = menuList;
            cbMenuListStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    private List<object> GetChildMenu(List<object> menuList, int parentID, int k)
    {
        List<MenuForSetPermissionInfo> data = new MenuForSetPermissionController().GetByParentID(parentID);
        foreach (var item in data)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "-- ";
            menuList.Add(new { ID = item.MenuID, MenuName = tmp + item.MenuName });
            menuList = GetChildMenu(menuList, item.MenuID, k + 1);
        }
        return menuList;
    }

    private List<object> LoadMenuCon(List<object> obj, string parentID, int k, string departmentList)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "----";
            if (k == 1)
            {
                obj.Add(new { MA = item.MA, TEN = "<b>" + tmp + item.TEN + "</b>", Check = departmentList.Contains("," + item.MA + ",") });
            }
            else
            {
                obj.Add(new { MA = item.MA, TEN = tmp + item.TEN, Check = departmentList.Contains("," + item.MA + ",") });
            }
            obj = LoadMenuCon(obj, item.MA, k + 1, departmentList);
        }
        return obj;
    }

    protected void btnUpdateRole_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (e.ExtraParams["Command"] != "Update")
            {
                RoleController.GetInstance().CreateRole(txtRoleName.Text, txtDescription.Text, 0, Session["MaDonVi"].ToString());
            }
            else
            {
                RoleController.GetInstance().UpdateRole(new RoleInfo()
                {
                    RoleName = txtRoleName.Text,
                    Description = txtDescription.Text,
                    EdittedBy = CurrentUser.ID,
                    ID = int.Parse(hdfRecordID.Text),
                    IsDeleted = false,
                    EdittedOn = DateTime.Now,
                    MaDonVi = Session["MaDonVi"].ToString(),
                    Order = 1
                });
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddRole.Hide();
            }

        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}