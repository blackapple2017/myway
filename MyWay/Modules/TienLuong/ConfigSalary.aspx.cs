using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;
using SoftCore.Menu;
using SoftCore;
using System.Data;

public partial class Modules_TienLuong_ConfigSalary : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetVisibleByControlID(btnAddRecord, btnDeleteRecord, btnAddMenuSalary, btnAddAndDeleteRecord);
        if (!X.IsAjaxRequest)
        {
            LoadRole(this.TreePanelRole); //Load role cho việc thiết lập menu, chỉ load khi có quyền
            LoadTreeIncludeCheckBox(); //cái này chỉ áp dụng cho super admin để thêm module
        }
        if (btnDeleteRecord.Visible)
        {
            RowSelectionModel1.Listeners.RowSelect.Handler = "try{btnDeleteRecord.enable();}catch(e){}";
        }
    }
    #region Get Role for Insert Menu
    private void LoadTreeIncludeCheckBox()
    {
        List<MenuInfo> MenuPanelList = MenuController.GetInstance().GetMenus(-1, false, true);
        Ext.Net.TreeNode root2 = new Ext.Net.TreeNode();
        if (MenuTreePanel.Root.Count() == 0)
            MenuTreePanel.Root.Add(root2);
        foreach (MenuInfo panel in MenuPanelList)
        {
            List<MenuInfo> ChildMenu = MenuController.GetInstance().GetMenus(panel.ID, false, false); //Lấy các tree nằm trong panel
            Ext.Net.TreeNode root = new Ext.Net.TreeNode(panel.MenuName);
            root.NodeID = panel.ID.ToString();
            root.Checked = ThreeStateBool.False;
            root2.Nodes.Add(root);
            foreach (MenuInfo item in ChildMenu)
            {
                Ext.Net.TreeNode AfterRoot = new Ext.Net.TreeNode(item.MenuName);
                AfterRoot.NodeID = item.ID.ToString();
                AfterRoot.Checked = ThreeStateBool.False;
                AfterRoot.Expanded = false;
                root.Nodes.Add(AfterRoot);
                LoadAllChildMenuIncludeCheckBox(ref AfterRoot, item);
            }
        }
    }
    private void LoadAllChildMenuIncludeCheckBox(ref Ext.Net.TreeNode root, MenuInfo parent)
    {
        List<MenuInfo> MenuList = MenuController.GetInstance().GetMenus(parent.ID, false, false);
        foreach (MenuInfo item in MenuList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.MenuName, Icon.UserGray);
            root.Nodes.Add(node);
            node.Checked = ThreeStateBool.False;
            node.Expanded = false;
            node.NodeID = item.ID.ToString();
            List<MenuInfo> MenuList2 = MenuController.GetInstance().GetMenus(item.ID, false, false);
            if (MenuList2.Count() != 0)
            {
                LoadAllChildMenuIncludeCheckBox(ref node, item);
            }
        }
    }
    private void LoadRole(TreePanel TreePanelRole)
    {
        List<RoleInfo> RoleList = RoleController.GetInstance().GetAllRoles(0, 0, Session["MaDonVi"].ToString());
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        TreePanelRole.Root.Clear();
        TreePanelRole.Root.Add(root);
        foreach (RoleInfo ParentRole in RoleList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(ParentRole.RoleName);
            root.Nodes.Add(node);
            node.Checked = ThreeStateBool.False;
            node.Expanded = true;
            node.NodeID = ParentRole.ID.ToString();
            List<RoleInfo> ChildRoles = RoleController.GetInstance().GetAllRoles(ParentRole.ID, 0, Session["MaDonVi"].ToString());
            LoadChildRoles(ref node, ChildRoles);
        }
    }
    private void LoadChildRoles(ref Ext.Net.TreeNode root, List<RoleInfo> RoleList)
    {
        foreach (RoleInfo item in RoleList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.RoleName);
            root.Nodes.Add(node);
            node.Checked = ThreeStateBool.False;
            node.Expanded = true;
            node.NodeID = item.ID.ToString();
            List<RoleInfo> ChildRoles = RoleController.GetInstance().GetAllRoles(item.ID, 0, Session["MaDonVi"].ToString());
            LoadChildRoles(ref node, ChildRoles);
        }
    }
    #endregion
    protected void stSalaryConfig_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (hdfSalaryTable.Text != "")
            {
                stSalaryConfig.DataSource = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetSalaryBoardConfigByMenuID", "@MenuID", int.Parse(hdfSalaryTable.Text));
            }
            else
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương nào");
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void stChooseSalaryTable_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            stChooseSalaryTable.DataSource = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetSalaryTableForCombobox");
            stChooseSalaryTable.DataBind();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    [DirectMethod(Namespace = "SalaryBoardConfigX")]
    public void AfterEdit(int id, int prkey, string field, string oldValue, string newValue, SalaryBoardConfigInfo oj)
    {
        try
        {
            SalaryBoardConfigController sdc = new SalaryBoardConfigController();
            sdc.Update(id, prkey, field, newValue);
            this.grpSalaryConfig.Store.Primary.CommitChanges();
            if (field == "IsInUsed")
            {
                if (newValue == "" && oj.DataSourceFunction == "")
                    newValue = "0";
                string colName = oj.ColumnName;
                int menuID = int.Parse(hdfSalaryTable.Text);
                int v = bool.Parse(newValue) == true ? 1 : 0;

                if (v == 0)
                {
                    try
                    {
                        string sql = "UPDATE TienLuong.BangLuongDong SET " + colName + " = " + v +
                                        " WHERE IdBangLuong IN (SELECT dsbl.ID FROM TienLuong.DanhSachBangLuong dsbl WHERE dsbl.MenuID = " + menuID + ")";
                        DataController.DataHandler.GetInstance().ExecuteNonQuery(sql);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        catch (Exception ex) { ExtMessage.Dialog.ShowError(ex.Message); }
    }

    [DirectMethod(Namespace = "SalaryBoardConfigX")]
    public void Insert(int prkey, string field, string oldValue, string newValue, object oj)
    {

        this.grpSalaryConfig.Store.Primary.CommitChanges();
    }


    protected void btnUpdateMenu_Click(object sender, DirectEventArgs e)
    {
        if (e.ExtraParams["MenuCommand"].Equals("insert"))
        {
            InsertMenu();
        }
        else
        {
            UpdateMenu();
        }
        wdAddModule.Hide();
    }
    /// <summary>
    /// Thêm mới menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void InsertMenu()
    {
        MenuInfo menuInfo = new MenuInfo()
        {
            MenuName = txtMenuName.Text,
            IsDeleted = false,
            Order = 1,
            //ParentID = int.Parse(hdfParentID.Text),
            // id của menu Tiền lương đang là 87
            ParentID = 87,
            TabName = txtMenuName.Text,
            CreatedBy = CurrentUser.ID,
            EdittedBy = CurrentUser.ID,
            Icon = "money",
            IsPanel = chkIsMenuPanel.Checked,
            LinkUrl = "Modules/TienLuong/BangLuongDong.aspx"
        };
        int menuID = MenuController.GetInstance().InsertMenu(menuInfo);
        if (menuID > 0)
        {
            string[] roleID = hdfRoleID.Text.Split(',');
            foreach (string item in roleID)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    MenuController.GetInstance().AddRole(menuID, int.Parse(item), UsersController.GetInstance().GetCurrentUser().ID, false);
                }
            }
            // thêm một vài cột trước vào trong cấu hình bảng lương
            InsertFewToSalaryConfig(menuID);
            // thêm các functions vào trong csdl (phần phân quyền cho bảng lương)
            InsertFunctionToSqlForMenuSalary(menuID);

            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("add_menu_successful"));
        }
        else
        {
            Dialog.ShowError(GlobalResourceManager.GetInstance().GetLanguageValue("error"));
        }

    }
    private void InsertFewToSalaryConfig(int menu)
    {
        // thêm mới một số cột vào cấu hình bảng lương
        SalaryBoardConfigController control = new SalaryBoardConfigController();
        for (int i = 1; i < 11; i++)
        {
            DAL.SalaryBoardConfig sf = new DAL.SalaryBoardConfig();
            sf.MenuID = menu;
            sf.Order = i;
            sf.ColumnName = "C" + i;
            sf.ColumnDescription = "";
            sf.DisplayOnGrid = true;
            sf.AllowEditOnGrid = true;
            sf.RenderJS = "RenderNumber";
            sf.Align = "Right";
            sf.IsInUsed = true;
            sf.Width = 85;
            sf.AllowSum = false;
            sf.DataSourceFunction = "";
            sf.Formula = "";
            control.Insert(sf);
        }
    }
    private void InsertFunctionToSqlForMenuSalary(int menu)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_InsertFunctionsForMenuSalary", "@MenuID", menu);
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.Message);
        }
    }
    private void UpdateMenu()
    {
        MenuInfo menuInfo = MenuController.GetInstance().GetMenu(int.Parse(hdfTreeNodeID.Text));
        menuInfo.MenuName = txtMenuName.Text;
        menuInfo.TabName = txtTabName.Text;
        menuInfo.ParentID = int.Parse(hdfParentID.Text);
        menuInfo.Icon = txtIcon.Text;
        if (!string.IsNullOrEmpty(cbFile.SelectedItem.Value))
        {
            string LinkUrl = cbFile.SelectedItem.Value.Replace("\\", "/");
            menuInfo.LinkUrl = LinkUrl.Substring(LinkUrl.IndexOf("Modules/"));
        }
        menuInfo.EdittedBy = UsersController.GetInstance().GetCurrentUser().ID;
        menuInfo.EdittedDate = DateTime.Now;
        menuInfo.IsPanel = chkIsMenuPanel.Checked;
        bool updateStatus = MenuController.GetInstance().UpdateMenu(menuInfo);
        if (updateStatus)//update role cho menu
        {
            string[] roleID = hdfRoleID.Text.Split(',');
            foreach (string item in roleID)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    MenuController.GetInstance().AddRole(menuInfo, int.Parse(item), UsersController.GetInstance().GetCurrentUser().ID, false);
                }
            }
        }
    }
    //Lấy các file của Module
    protected void ModuleFileRefresh(object sender, StoreRefreshDataEventArgs e)
    {
        List<object> data = new List<object>();
        List<string> FileList = ModuleController.GetInstance().GetFileInModule(Server.MapPath("Modules") + "\\" + cbModule.SelectedItem.Value);
        foreach (string item in FileList)
        {
            data.Add(new { Path = item });
        }
        this.ModuleFileStore.DataSource = data;
        this.ModuleFileStore.DataBind();
    }
    #region Thêm bản ghi vào bảng lương
    protected void btnAddColumn_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.SalaryBoardConfig sf = new DAL.SalaryBoardConfig();
            sf.MenuID = int.Parse(hdfSalaryTable.Text);
            if (!string.IsNullOrEmpty(nfThuTu.Text))
            {
                sf.Order = int.Parse(nfThuTu.Text);
            }
            if (!string.IsNullOrEmpty(nfOrderDisplay.Text))
            {
                sf.OrderDisplay = int.Parse(nfOrderDisplay.Text);
            }
            if (!string.IsNullOrEmpty(nfWidth.Text))
            {
                sf.Width = int.Parse(nfWidth.Text);
            }
            sf.ColumnName = cbbColumnID.SelectedItem.Value;
            sf.ColumnDescription = txtDienGiai.Text;
            sf.DisplayOnGrid = ckDisplayOnGridView.Checked;
            sf.DisplayOnReport = ckDisplayOnReport.Checked;
            sf.IsInUsed = ckIsInUsed.Checked;
            sf.AllowEditOnGrid = ckAllowEditOnGrid.Checked;
            sf.RenderJS = cbbRenderJS.SelectedItem.Value;
            sf.Align = cbbAlign.SelectedItem.Value;
            sf.AllowSum = ckAllowSum.Checked;
            sf.DataSourceFunction = hdfDataSource.Text;
            sf.Formula = txtCongThuc.Text;
            if (!string.IsNullOrEmpty(nfDefaultValue.Text))
            {
                sf.DefaultValue = double.Parse(nfDefaultValue.Text.Replace(".", ","));
            }
            SalaryBoardConfigController control = new SalaryBoardConfigController();
            control.Insert(sf);
            if (e.ExtraParams["close"] == "true")
            {
                wdAddRecord.Hide();
            }
            RM.RegisterClientScriptBlock("reset", "resetWdAddRecord();");
            grpSalaryConfig.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.ToString());
        }
    }
    protected void btnDeleteRecord_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SalaryBoardConfigController control = new SalaryBoardConfigController();
            SelectedRowCollection selectedRows = RowSelectionModel1.SelectedRows;
            foreach (var item in selectedRows)
            {
                control.Delete(int.Parse(item.RecordID));
            }
            grpSalaryConfig.Reload();
            btnDeleteRecord.Disabled = true;
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.ToString());
        }
    }
    #endregion
    protected void stColumnID_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetColumnByMenuID", "@MenuID", hdfSalaryTable.Text);
            stColumnID.DataSource = data;
            stColumnID.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.Message);
        }
    }
}