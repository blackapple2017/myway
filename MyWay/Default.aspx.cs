using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore;
using SoftCore.Module;
using SoftCore.Menu;
using DataController;
using ExtMessage;
using SoftCore.Security;
using SoftCore.User;
using SoftCore.Function;
using WebUI.BaseControl;
using SoftCore.AccessHistory;
using System.Reflection;
using System.Data;

public partial class _Default : DefaultHomepage
{
    enum MenuCommand { insert, update };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            ltrApplicationName.Text = GlobalResourceManager.GetInstance().GetLanguageValue("software_online_system");
            //load combobox để thực hiện cho việc add module - super user
            if (CurrentUser.IsSuperUser)
            {
                List<ModuleInfo> ModulesList = ModuleController.GetInstance().GetAllModules(Server.MapPath("Modules"));
                foreach (ModuleInfo item in ModulesList)
                {
                    cbModule.Items.Add(new Ext.Net.ListItem(item.ModuleName));
                }
                LoadRole(this.TreePanel1); //Load role cho việc thiết lập menu, chỉ load khi có quyền
                LoadTreeIncludeCheckBox(); //cái này chỉ áp dụng cho super admin để thêm module
                //hiện phân quyền
                btnSystem.Visible = true;
                btnSystem_PermissionList.Visible = true;
            } 
            try
            {
                string menuType = new HeThongController().GetValueByName("MENU_TYPE", Session["MaDonVi"].ToString());
                if (menuType.Equals("Horizontal"))
                {
                    LoadTopMenu(); //load menu ngang 
                }
                else
                {
                    if (menuType.Equals("VerticalCollapsed"))
                    {
                        LoadLeftMenu(true); //Load menu dọc thu nhỏ
                    }
                    else
                    {
                        LoadLeftMenu(false); //Load menu dọc 
                    }
                }
            }
            catch (Exception ex)
            {
                Dialog.ShowError("Default.aspx = " + ex.Message);
            }
            ModuleFileRefresh(null, null);
            if (!string.IsNullOrEmpty(CurrentUser.DisplayName))
            {
                btnDisplayName.Text = CurrentUser.DisplayName;
            }
            else
            {
                btnDisplayName.Text = CurrentUser.FirstName + " " + CurrentUser.LastName;
            }
            SetVisibleByRole();
        } 
        LoadRole(this.TreePanelRole);  
    }

    private void SetVisibleByRole()
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("role_roleOfDesktop", "@StartmenuID", "@EndmenuID", "@UserID", 6000, 6999, CurrentUser.ID);
        foreach (DataRow item in table.Rows)
        {
            switch (item[0].ToString())
            {
                case "6001":
                    btnSystem.Visible = true;
                    btnSystem_PermissionList.Visible = true;
                    break;
                case "6002":
                    btnSystem.Visible = true;
                    btnSystem_UsersList.Visible = true;
                    break;
                case "6003":
                    btnSystem.Visible = true;
                    mnuSystemConfig.Visible = true;
                    break;
                case "6004":
                    btnSystem.Visible = true;
                    MenuItem7.Visible = true;
                    break;
                case "6006":
                    mnuAddMenu.Visible = true;
                    break;
                case "6007":
                    mnuAddTheSameMenu.Visible = true;
                    break;
                case "6008":
                    MenuItem9.Visible = true;
                    break;
                case "6009":
                    MnuDeleteMenu.Visible = true;
                    break;
                case "6010":
                    mnuOrder.Visible = true;
                    break;
                case "6011":
                    MenuItem1.Visible = true;
                    break;
            }
        }
    }

    //logout 
    protected void BtnLogout_Click(object sender, DirectEventArgs e)
    {
        NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
        {
            MOTA = GlobalResourceManager.GetInstance().GetLanguageValue("software_online_system"),
            CHUCNANG = GlobalResourceManager.GetInstance().GetLanguageValue("software_online_system"),
            IsError = false,
            USERNAME = CurrentUser.UserName,
            THOIGIAN = DateTime.Now,
            MANGHIEPVU = "Users",
            TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
            IPMAY = Request.UserHostAddress,
            THAMCHIEU = "",
        };
        new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);

        Session.Abandon();
        Response.Redirect("Login.aspx");
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

    protected void btnUpdatePassword_Click(object sender, DirectEventArgs e)
    {
        if (CurrentUser == null)
        {
            CurrentUser = Session["CURRENTUSER"] as UserInfo;
            // CurrentUser = UsersController.GetInstance().GetCurrentUser();
        }
        if (CurrentUser.Password != Hash.GetSHA256(txtOldPassword.Text))
        {
            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("old_password_not_valid"));
            return;
        }
        if (CurrentUser.ChangePassword(txtNewPassword.Text))
        {
            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("change_password_successful"));
        }
        else
        {
            Dialog.ShowError(GlobalResourceManager.GetInstance().GetLanguageValue("error"));
        }
        wdChangePassword.Hide();
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

    #region Load cây menu chức năng
    /// <summary>
    /// Load thanh menu ngang
    /// </summary>
    private void LoadTopMenu()
    {
        List<MenuInfo> MenuPanelList = MenuController.GetInstance().GetMenus(-1, false, true, CurrentUser.ID).OrderByDescending(p => p.Order).ToList();
        foreach (MenuInfo item in MenuPanelList)
        {
            Ext.Net.Button btn = new Ext.Net.Button(item.MenuName.ToUpper());
            btn.ID = "mnu" + item.ID;
            //  btn.IconCls = item.Icon;
            Toolbar1.Items.Insert(0, btn);
            LoadSubTopMenu(btn, item);
        }
        Ext.Net.ImageButton btnLogo = new Ext.Net.ImageButton();
        btnLogo.ImageUrl = "Resource/images/logo.png";
        btnLogo.OverImageUrl = "Resource/images/logoHover.png";
        Toolbar1.Items.Insert(0, btnLogo);
        Ext.Net.Label lblApplication = new Ext.Net.Label();
        lblApplication.Html = "<b style='color:#15428B !important;font-family:verdana !important;'>" + ltrApplicationName.Text.ToUpper() + "</b>";
        Toolbar1.Items.Insert(1, lblApplication);
        Toolbar1.Items.Insert(1, new ToolbarSpacer()
        {
            ID = "tbspacer",
            Width = 5
        });
    }
    /// <summary>
    /// Load menu con của menu ngang
    /// </summary>
    /// <param name="parentComponent"></param>
    /// <param name="parentMenu"></param>
    private void LoadSubTopMenu(Component parentComponent, MenuInfo parentMenu)
    {
        List<MenuInfo> ChildMenu;
        //  if (CurrentUser.IsSuperUser)
        ChildMenu = MenuController.GetInstance().GetMenus(parentMenu.ID, false, false); //Lấy các tree nằm trong panel
        //  else
        //      ChildMenu = MenuController.GetInstance().GetMenus(parentMenu.ID, false, false, CurrentUser.ID);
        if (ChildMenu == null || ChildMenu.Count() == 0)
        {
            return;
        }
        Ext.Net.Menu menu = new Ext.Net.Menu();
        if (parentComponent.InstanceOf.Contains("Button"))
        {
            Ext.Net.Button btn = parentComponent as Ext.Net.Button;
            btn.Menu.Add(menu);
        }
        else
        {
            Ext.Net.MenuItem menuItem = parentComponent as Ext.Net.MenuItem;
            menuItem.Menu.Add(menu);
        }
        foreach (MenuInfo item in ChildMenu)
        {
            Ext.Net.MenuItem mnu = new Ext.Net.MenuItem(item.MenuName);
            if (string.IsNullOrEmpty(item.Icon))
            {
                mnu.Icon = Icon.BulletBlue;
            }
            else
            {
                mnu.IconCls = item.Icon;
            }
            mnu.ID = item.ID + "mnu";
            if (!string.IsNullOrEmpty(item.LinkUrl))
            {
                if (item.LinkUrl.Contains("?") == false)
                    item.LinkUrl += "?mId=" + item.ID;
                else
                    item.LinkUrl += "&mId=" + item.ID;
                mnu.Listeners.Click.Handler = "addTab(#{pnTabPanel},'dm_file" + item.ID + "','" + item.LinkUrl + "', '" + item.TabName + "')";
            }
            menu.Items.Add(mnu);
            LoadSubTopMenu(mnu, item);
        }
    }

    private void LoadLeftMenu(bool isCollapsed)
    {
        try
        {
            Ext.Net.Panel westPanel = new Ext.Net.Panel(GlobalResourceManager.GetInstance().GetLanguageValue("MenuChucNang"), Icon.Table);
            westPanel.ID = "WestPanel";
            westPanel.Width = 245;
            westPanel.Layout = "Accordion";
            westPanel.LoadMask.ShowMask = true;
            westPanel.LoadMask.Msg = GlobalResourceManager.GetInstance().GetLanguageValue("LoadingMask");
            westPanel.Collapsed = isCollapsed;

            BorderLayout1.West.Items.Add(westPanel);
            BorderLayout1.West.MarginsSummary = "5 0 0 5";
            BorderLayout1.West.CMarginsSummary = "5 5 0 5";
            BorderLayout1.West.MinWidth = 245;
            BorderLayout1.West.MaxWidth = 400;
            BorderLayout1.West.Collapsible = true;

            Ext.Net.ImageButton btnLogo = new Ext.Net.ImageButton();
            btnLogo.ImageUrl = "Resource/images/logo.png";
            btnLogo.OverImageUrl = "Resource/images/logoHover.png";
            Toolbar1.Items.Insert(0, btnLogo);

            Ext.Net.Label lblApplication = new Ext.Net.Label();
            lblApplication.Html = "<b style='color:#15428B !important;font-family:verdana !important;'>" + ltrApplicationName.Text.ToUpper() + "</b>";
            Toolbar1.Items.Insert(1, lblApplication);

            List<MenuInfo> MenuPanelList = null;
            if (CurrentUser.IsSuperUser == false)
                MenuPanelList = MenuController.GetInstance().GetMenus(-1, false, true, CurrentUser.ID);
            else
                MenuPanelList = MenuController.GetInstance().GetMenus(-1, false, true);
            westPanel.Items.Clear();
            foreach (MenuInfo panel in MenuPanelList)
            {
                Ext.Net.TreePanel tree = new Ext.Net.TreePanel();
                westPanel.Items.Add(tree);
                tree.RootVisible = false;
                tree.IconCls = panel.Icon;
                tree.Title = panel.MenuName;
                tree.AutoScroll = true;
                tree.Border = false;
                tree.ContextMenuID = "Menu4";
                tree.Animate = true;
                List<MenuInfo> ChildMenu = new List<MenuInfo>();
                if (CurrentUser.IsSuperUser)
                    ChildMenu = MenuController.GetInstance().GetMenus(panel.ID, false, false); //Lấy các tree nằm trong panel
                else
                    ChildMenu = MenuController.GetInstance().GetMenus(panel.ID, false, false, CurrentUser.ID);
                Ext.Net.TreeNode root = new Ext.Net.TreeNode();
                tree.Root.Add(root);
                LoadAllChildMenu(ref root, ChildMenu);
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

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
    private void LoadAllChildMenu(ref Ext.Net.TreeNode root, List<MenuInfo> MenuList)
    {
        foreach (MenuInfo item in MenuList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.MenuName);
            root.Nodes.Add(node);
            node.Listeners.ContextMenu.Handler = "SetTreeNodeID('" + item.ID + "');";
            node.IconCls = item.Icon;
            node.Expanded = false;//Tạm thời cho thu nhỏ hết tất cả các node
            if (!string.IsNullOrEmpty(item.LinkUrl))
            {
                if (item.LinkUrl.Contains("?") == false)
                    item.LinkUrl += "?mId=" + item.ID;
                else
                    item.LinkUrl += "&mId=" + item.ID;
                node.Listeners.Click.Handler = "addTab(#{pnTabPanel},'dm_file" + item.ID + "','" + item.LinkUrl + "', '" + item.TabName + "')";
            }
            List<MenuInfo> MenuList2 = new List<MenuInfo>();
            if (CurrentUser.IsSuperUser)
                MenuList2 = MenuController.GetInstance().GetMenus(item.ID, false, false);
            else
                MenuList2 = MenuController.GetInstance().GetMenus(item.ID, false, false, CurrentUser.ID);
            LoadAllChildMenu(ref node, MenuList2);
        }
    }

    protected void btnAddFunction_Click(object sender, DirectEventArgs e)
    {
        try
        {
            FunctionInfo info = new FunctionInfo()
            {
                ControlText = txtControlText.Text,
                Description = txtDescription.Text,
                MenuID = int.Parse(hdfTreeNodeID.Text),
                ParentID = int.Parse(cbxChucNangCha.SelectedItem.Value.ToString())
            };
            FunctionController.GetInstance().CreateFunction(info);
            if (e.ExtraParams["Continue"] == "No")
                wdFunction.Hide();

            if (string.IsNullOrEmpty(hdfRoleID.Text) == false || AjaxSearchUser.GetValue() != null)
            {
                Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("SetPermissionSuccess"));
            }
            else
            {
                Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("AddFunctionSuccess"));
            }
            ResourceManager1.RegisterClientScriptBlock("ds", "resetWdFunction();");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("DefaultErrorMessage"));

            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("AddFunction") + " Default/btnAddFunction_Click",
                MOTA = ex.Message.Replace("'", " "),
                IsError = true,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "Functions",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
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
    #endregion

    public void cbxChucNangChaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<FunctionInfo> lists = FunctionController.GetInstance().GetFunctionByMenuId(int.Parse("0" + hdfTreeNodeID.Text));
        List<object> obj = new List<object>();
        obj.Add(new { ID = -1, Description = "Là gốc" });
        foreach (FunctionInfo item in lists)
        {
            if (item.ParentID == -1)
            {
                obj.Add(new { ID = item.ID, Description = item.Description });
                obj = LoadChucNangCon(obj, item.ID, 1);
            }
        }
        cbxChucNangChaStore.DataSource = obj;
        cbxChucNangChaStore.DataBind();
    }

    private List<object> LoadChucNangCon(List<object> obj, int menuID, int k)
    {
        List<FunctionInfo> lists = FunctionController.GetInstance().GetByParentID(menuID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "- ";
            obj.Add(new { ID = item.ID, Description = tmp + " " + item.Description });
            obj = LoadChucNangCon(obj, item.ID, k + 1);
        }
        return obj;
    }

    #region Các sự kiện của MenuContext trên menu
    /// <summary>
    /// Xóa menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MnuDeleteMenu_Click(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfTreeNodeID.Text))
        {
            try
            {
                MenuController.GetInstance().DeleteMenu(int.Parse(hdfTreeNodeID.Text));
                Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("delete_successful_refresh_page"));
            }
            catch (Exception ex)
            {
                Dialog.ShowError(ex.Message);
            }
        }
    }

    /// <summary>
    /// Hiện form để sắp xếp lại thứ tự của menu panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuOrder_Click(object sender, DirectEventArgs e)
    {
        List<MenuInfo> MenuPanelList = MenuController.GetInstance().GetMenus(-1, false, true);
        string menuStr = "";
        foreach (MenuInfo menu in MenuPanelList)
        {
            menuStr = string.Concat(menuStr, string.Format("<li id='{0}'>{1}</li>", menu.ID.ToString(), menu.MenuName));
        }
        string output = @" <div class='demo'>
                            <ul id='sortable'>
                             {0}
                            </ul>
                        </div>";

        string script = @" $(function () {
                                $('#sortable').sortable();
                                $('#sortable').disableSelection();
                            });";

        lblOutput.Html = string.Format(output, menuStr);
        wdSortAscending.Show();
        ResourceManager1.RegisterClientScriptBlock("load", script);
    }
    /// <summary>
    /// cập nhật lại thứ tự của menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveOrderedMenu_Click(object sender, DirectEventArgs e)
    {
        string[] menuPanelID = e.ExtraParams["order"].Split(',');
        short count = 0;
        foreach (string item in menuPanelID)
        {
            MenuController.GetInstance().UpdateOrder(int.Parse(item), count);
            count++;
        }
        wdSortAscending.Hide();
        //  this.WestPanel.Items.Clear(); //lLoadMenu();
    }

    /// <summary>
    /// Load dữ liệu và hiện form cập nhật menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuAddMenu_Click(object sender, DirectEventArgs e)
    {
        MenuInfo menuInfo = MenuController.GetInstance().GetMenu(int.Parse(hdfTreeNodeID.Text));
        if (e.ExtraParams["Note"].Equals("AddMenu")) //thêm menu cùng cấp
        {
            MenuInfo ParentMenu = MenuController.GetInstance().GetMenu(menuInfo.ParentID);
            ddfParentMenu.Text = ParentMenu.MenuName;
            hdfParentID.Text = menuInfo.ParentID.ToString();
            wdAddModule.Title = "Thêm mới menu";
            hdfMenuCommand.Text = MenuCommand.insert.ToString();
        }
        else if (e.ExtraParams["Note"].Equals("AddChildMenu"))//thêm menu con
        {
            ddfParentMenu.Text = menuInfo.MenuName;
            hdfParentID.Text = menuInfo.ID.ToString();
            wdAddModule.Title = "Thêm mới menu";
            hdfMenuCommand.Text = MenuCommand.insert.ToString();
        }
        else//cập nhật menu
        {
            wdAddModule.Title = "Cập nhập thông tin menu";
            ddfParentMenu.Text = MenuController.GetInstance().GetMenu(menuInfo.ParentID).MenuName;
            hdfParentID.Text = menuInfo.ParentID.ToString();
            txtMenuName.Text = menuInfo.MenuName;
            txtTabName.Text = menuInfo.TabName;
            txtIcon.Text = menuInfo.Icon;
            chkIsMenuPanel.Checked = menuInfo.IsPanel;
            if (!string.IsNullOrEmpty(menuInfo.LinkUrl))
            {
                string module = menuInfo.LinkUrl.Replace("Modules/", "");
                cbModule.SetValue(module.Remove(module.IndexOf("/")));
                cbFile.SetValue(menuInfo.LinkUrl);
            }
            hdfMenuCommand.Text = MenuCommand.update.ToString();
            //lấy danh sách quyền của menu
            ddfRole.Text = "";
            hdfOldMenuRole.Text = "";
            List<RoleInfo> roleList = MenuController.GetInstance().GetMenuRoles(menuInfo.ID);
            foreach (RoleInfo roleInfo in roleList)
            {
                ddfRole.Text += roleInfo.RoleName + ", ";
                hdfOldMenuRole.Text += roleInfo.ID + ",";
            }
        }
        wdAddModule.Show();
    }
    #endregion

    #region sự kiện của window wdAddModule
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

    /// <summary>
    /// Cập nhật thông tin menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdateMenu_Click(object sender, DirectEventArgs e)
    {
        if (e.ExtraParams["MenuCommand"].Equals(MenuCommand.insert.ToString()))
        {
            InsertMenu();
        }
        else
        {
            UpdateMenu();
        }
        wdAddModule.Hide();
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
            ParentID = int.Parse(hdfParentID.Text),
            TabName = txtTabName.Text,
            CreatedBy = CurrentUser.ID,
            EdittedBy = CurrentUser.ID,
            Icon = txtIcon.Text,
            IsPanel = chkIsMenuPanel.Checked
        };
        if (!string.IsNullOrEmpty(cbFile.SelectedItem.Value))
        {
            string LinkUrl = cbFile.SelectedItem.Value.Replace("\\", "/");
            menuInfo.LinkUrl = LinkUrl.Substring(LinkUrl.IndexOf("Modules/"));
        }
        else
            menuInfo.LinkUrl = txtMenuLink.Text;

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
            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetLanguageValue("add_menu_successful"));
        }
        else
        {
            Dialog.ShowError(GlobalResourceManager.GetInstance().GetLanguageValue("error"));
        }
    }
    #endregion
}