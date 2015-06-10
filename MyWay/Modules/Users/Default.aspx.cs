using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using SoftCore.AccessHistory;
using SoftCore;
using Ext.Net.Utilities;
using ExtMessage;
using SoftCore.Utilities;
using SoftCore.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;

public partial class Modules_Users_Users : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!X.IsAjaxRequest)
        {
            hdfMaDonViOfCurrentUser.Text = Session["MaDonVi"].ToString();
            List<RoleInfo> RoleList = RoleController.GetInstance().GetAllRoles(0, 0, Session["MaDonVi"].ToString());
            LoadRole(RoleList); LoadRole2(RoleList);
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        SelectedRowCollection s = (SelectedRowCollection)sender;
        hdfIdList.Text = "";
        foreach (var item in ucChooseEmployee1.SelectedRow)
        {
            hdfIdList.Text += item.RecordID + ",";
        }
        grpUserAcc.Reload();
    }

    protected void grp_roleListStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        grp_roleListStore.DataSource = RoleController.GetInstance().GetAllRoles(-1, 0, Session["MaDonVi"].ToString());
        grp_roleListStore.DataBind();
    }

    protected void btnTaoTaiKhoan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string[] tmp = hdfJsonData.Text.Replace("[", "").Replace("]", "").Replace("},", "#").Split('#');
            HoSoController hsController = new HoSoController();
            LinqProvider linq = new LinqProvider();
            string email = string.Empty;
            string password = string.Empty;
            if (Checkbox1.Checked)
            {
                HeThongController ht = new HeThongController();
                object objEmail = ht.GetValueByName(SystemConfigParameter.EMAIL, Session["MaDonVi"].ToString());
                object objPassword = ht.GetValueByName(SystemConfigParameter.PASSWORD_EMAIL, Session["MaDonVi"].ToString());
                if (objEmail != null)
                {
                    email = objEmail.ToString();
                }
                if (objPassword != null)
                {
                    password = objPassword.ToString();
                }
            }
            int countDuplicate = 0;
            int success = 0;
            foreach (var item in tmp)
            {
                try
                {
                    DAL.HOSO hs = linq.GetDataContext().HOSOs.Where(t => t.MA_CB == Util.GetInstance().Getproperties(item, "UserID")).FirstOrDefault();//hsController.GetByMaCB(Util.GetInstance().Getproperties(item, "UserID"));
                    if (hs == null)
                    {
                        continue;
                    }
                    UserInfo uInfo = new UserInfo()
                    {
                        Gender = hs.MA_GIOITINH == "M" ? true : false,
                        Address = hs.DIA_CHI_LH,
                        Birthday = hs.NGAY_SINH,
                        DisplayName = hs.HO_TEN,
                        Image = "",
                        CreatedBy = CurrentUser.ID,
                        CreatedOn = DateTime.Now,
                        EdittedBy = CurrentUser.ID,
                        EdittedOn = DateTime.Now,
                        IsLock = false,
                        Email = hs.EMAIL,
                        IsSuperUser = false,
                        Phone = hs.DI_DONG,
                        FirstName = hs.HO_CB,
                        LastName = hs.TEN_CB,
                        Password = Util.GetInstance().Getproperties(item, "Password"),
                        UserName = Util.GetInstance().Getproperties(item, "UserName"),
                    };
                    int uID = UsersController.GetInstance().CreateUser(uInfo);
                    if (uID > 0)
                    {
                        hs.UserID = uID;
                        linq.Save();

                        //Gán quyền cho người dùng
                        foreach (var roleItem in CheckboxSelectionModelRoleList.SelectedRows)
                        {
                            UsersController.GetInstance().SetRoles(uID, int.Parse(roleItem.RecordID));
                        }

                        new DM_DONVIController().AddUserIntoDonVi(hdfMaDonViOfCurrentUser.Text, uID);

                        //Gửi email thông báo
                        if (Checkbox1.Checked && string.IsNullOrEmpty(hs.EMAIL) == false)
                        {
                            string content = GlobalResourceManager.GetInstance().GetLanguageValue("NotifyUserName");
                            Email.SendEmail(email, password, "Thông báo mật khẩu", hs.EMAIL, "Thông báo mật khẩu", string.Format(content, uInfo.UserName, uInfo.Password));
                        }
                    }
                    success++;
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate key"))
                    {
                        countDuplicate++;
                    }
                }
            }
            wdTaoTaiKhoanNhanVien.Hide();
            string notifies = "";
            if (success > 0)
                notifies += "Tạo tài khoản thành công cho " + success + " cán bộ.";
            if (countDuplicate > 0)
                notifies += " Có " + countDuplicate + " tài khoản đã tồn tại.";
            X.Msg.Alert("Thông báo từ hệ thống", notifies).Show();
            ReloadStore();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID("0");
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            obj.Add(new { MA = info.MA, TEN = info.TEN });
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        cbx_bophan_Store.DataSource = obj;
        cbx_bophan_Store.DataBind();
    }

    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "-- ";
            obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }

    protected void btnUpdatePassword_Click(object sender, DirectEventArgs e)
    {
        if (hdfRecordID.Text != "")
        {
            bool rs = UsersController.GetInstance().GetUser(int.Parse(hdfRecordID.Text)).ChangePassword(txtNewPassword.Text);
            if (rs)
            {
                wdChangePassword.Hide();
                Dialog.ShowNotification("Đổi mật khẩu thành công !");
                //   X.MessageBox.Alert("Thông báo", "Đổi mật khẩu thành công !").Show();
            }
        }
        else
        {
            X.MessageBox.Alert("Thông báo", "Bạn chưa chọn nhân viên nào").Show();
        }
    }

    protected void btnAddRole_Click(object sender, DirectEventArgs e)
    { 
        try
        { 
            //check xem user này đã có trong bảng DOnvi_User chưa
            foreach (var selectedUsers in RowSelectionModel1.SelectedRows)
            {
                if (!new DM_DONVIController().UserIsInAnyDepartments(int.Parse(selectedUsers.RecordID)))
                { 
                    X.MessageBox.Alert("Cảnh báo", "Người dùng có <b>mã tài khoản = " + selectedUsers.RecordID + "</b> không thể thiết lập quyền vì chưa nằm trong bộ phận nào !").Show();
                    return;
                }
            }
            // Xóa quyền cũ để thiết lập quyền mới
            foreach (var selectedUsers in RowSelectionModel1.SelectedRows)
            { 
                UsersController.GetInstance().DeleteUserRoleByUserID(int.Parse(selectedUsers.RecordID)); 
            }

            string[] roleList = hdfSelectedNodeID.Text.Split(',');
            foreach (var item in roleList)
            {
                if (item.Length != 0)
                {
                    int roleId = int.Parse(item);
                    foreach (var selectedUsers in RowSelectionModel1.SelectedRows)
                    { 
                        UsersController.GetInstance().SetRoles(int.Parse(selectedUsers.RecordID), roleId);
                    } 
                }
            } 
        }
        catch (Exception ex)
        { 
            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetErrorMessageValue("DefaultErrorMessage"));
        }
        wdAssignRole.Hide();
        Dialog.ShowNotification("Thiết lập quyền thành công !");
    }
    /// <summary>
    /// Reset mật khẩu người dùng
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuResetPassword_Click(object sender, DirectEventArgs e)
    {
        string userid = "";
        string failUserId = "";
        try
        {
            string[] ds = hdfListUserID.Text.Split(',');
            List<string> userIDList = new List<string>();
            for (int i = 0; i < ds.Count(); i++)
            {
                if (ds[i] != "")
                    userIDList.Add(ds[i]);
            }
            string mailContent = Util.GetInstance().ReadFile(Server.MapPath("EmailHTML/ResetPassword.htm"));
            string systemName = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_NAME, Session["MaDonVi"].ToString()).ToString();
            string systemEmail = new HeThongController().GetValueByName(SystemConfigParameter.EMAIL, Session["MaDonVi"].ToString());
            string systemPassword = new HeThongController().GetValueByName(SystemConfigParameter.PASSWORD_EMAIL, Session["MaDonVi"].ToString());
            foreach (var item in userIDList)
            {
                string password = Util.GetInstance().GetRandomString(7);
                UserInfo u = UsersController.GetInstance().GetUser(int.Parse(item));
                if (Email.SendEmail(systemEmail, systemPassword, systemName, u.Email, "Thông báo mật khẩu mới", string.Format(mailContent, password, u.DisplayName)))
                {
                    u.Password = password;
                    UsersController.GetInstance().UpdateUser(u);
                    userid += item + ", ";
                }
                else
                {
                    failUserId += item + ", ";
                }
            }
            if (!string.IsNullOrEmpty(failUserId))
            {
                X.MessageBox.Alert("Thông báo", "Các mã tài khoản sau không đổi đổi được mật khẩu: " + failUserId).Show();
            }
            else
            {
                X.MessageBox.Alert("Thông báo", GlobalResourceManager.GetInstance().GetLanguageValue("ResetPasswordSuccess")).Show();
            }
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("ResetPassword"),
                MOTA = GlobalResourceManager.GetInstance().GetHistoryAccessValue("ResetPassword"),
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "Users",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "Các UserId bị reset mật khẩu : " + userid,
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
        catch (Exception ex)
        {
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("ResetPassword"),
                MOTA = ex.Message.Replace("'", " "),
                IsError = true,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "Users",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "Các UserId bị reset mật khẩu : " + userid,
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetErrorMessageValue("DefaultErrorMessage"));
        }
    }
    /// <summary>
    /// Load danh mục quyền bên trái
    /// </summary>
    /// <param name="RoleList"></param>
    private void LoadRole(List<RoleInfo> RoleList)
    {
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        TreePanel1.Root.Clear();
        TreePanel1.Root.Add(root);
        Ext.Net.TreeNode nodeAll = new Ext.Net.TreeNode("Danh mục quyền")
        {
            NodeID = "-1",
            Icon = Icon.Group,
            Expanded = true
        };
        nodeAll.Listeners.Click.Handler = @"#{hdfNodeID}.setValue(-1);#{hdfRecordID}.setValue('');#{Store1}.reload();
                                            btnShowWindowRole.disable();btnShowWindowRole.disable();btnEditUser.disable();
                                            btnDeleteUser.disable();";
        root.Nodes.Add(nodeAll);

        foreach (RoleInfo ParentRole in RoleList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(ParentRole.RoleName);
            nodeAll.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = ParentRole.ID.ToString();
            node.Listeners.Click.Handler = "#{hdfNodeID}.setValue(" + node.NodeID + ");#{hdfRecordID}.setValue('');#{Store1}.reload();" +
                                            "btnShowWindowRole.disable();btnShowWindowRole.disable();btnEditUser.disable();" +
                                            "btnDeleteUser.disable();";
        }
    }
    private void LoadRole2(List<RoleInfo> RoleList)
    {
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        treeRole.Root.Clear();
        treeRole.Root.Add(root);
        Ext.Net.TreeNode nodeAll = new Ext.Net.TreeNode("Danh mục quyền")
        {
            NodeID = "-1",
            Icon = Icon.Group,
            Expanded = true
        };
        root.Nodes.Add(nodeAll);
        hdfAllNodeID.Text = "";
        foreach (RoleInfo item in RoleList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.RoleName);
            nodeAll.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = item.ID.ToString();
            node.Checked = ThreeStateBool.False;
            hdfAllNodeID.Text += item.ID + ",";
        }
    }
    protected void mnuLockUser_Click(object sender, DirectEventArgs e)
    {
        if (RowSelectionModel1.SelectedRows.Count() == 0)
        {
            Dialog.ShowNotification("Bạn chưa chọn tài khoản nào !");
            return;
        }
        foreach (var item in RowSelectionModel1.SelectedRows)
        {
            UsersController.GetInstance().LockUser(int.Parse(item.RecordID));
        }
        Dialog.ShowNotification("Khóa tài khoản thành công");
        ReloadStore();
    }

    protected void mnuUnlockUser_Click(object sender, DirectEventArgs e)
    {
        if (RowSelectionModel1.SelectedRows.Count() == 0)
        {
            Dialog.ShowNotification("Bạn chưa chọn tài khoản nào !");
            return;
        }
        foreach (var item in RowSelectionModel1.SelectedRows)
        {
            UsersController.GetInstance().UnLockUser(int.Parse(item.RecordID));
        }
        Dialog.ShowNotification("Mở tài khoản thành công");
        ReloadStore();
    }

    protected void btnShowWindowRole_Click(object sender, DirectEventArgs e)
    {
        if (string.IsNullOrEmpty(hdfRecordID.Text))
        {
            return;
        }
        hdfRoleID.Text = "";
        List<int> idList = RoleController.GetInstance().GetRolesByUser(int.Parse(hdfRecordID.Text));
        foreach (var item in idList)
        {
            hdfRoleID.Text += item + ",";
        }
        wdAssignRole.Show();
    }

    [DirectMethod]
    public void DeleteUser(int id)
    {
        try
        {
            UsersController.GetInstance().DeleteUser(id);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnEditUser_Click(object sender, DirectEventArgs e)
    {
        try
        {
            UserInfo userInfo = UsersController.GetInstance().GetUser(int.Parse(hdfRecordID.Text));
            txtAddress.Text = userInfo.Address;
            txtDisplayName.Text = userInfo.DisplayName;
            txtEmail.Text = userInfo.Email;
            txtFirstName.Text = userInfo.FirstName;
            txtLastName.Text = userInfo.LastName;
            txtPhone.Text = userInfo.Phone;
            txtAddress.Text = userInfo.Address;
            txtUserName.Text = userInfo.UserName;
            DAL.DM_DONVI department = new UserController().GetDonViByUserID(userInfo.ID).FirstOrDefault();
            if (department != null)
            {
                hdfSelectedDepartmentID.Text = department.MA_DONVI;
                cbx_bophan.Text = department.TEN_DONVI;
            }
            if (userInfo.Gender)
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            if (userInfo.Birthday.HasValue)
                dfBirthday.SelectedDate = userInfo.Birthday.Value;
            hdfUserCommand.Text = "Update";
            wdAddUser.Icon = Icon.Pencil;
            wdAddUser.Title = "Sửa tài khoản người dùng";
            wdAddUser.Show();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddUser.Title = "Thêm mới người dùng";
        wdAddUser.Icon = Icon.Add;
    }

    protected void btnAddUser_Click(object sender, DirectEventArgs e)
    {
        try
        {
            UsersController uController = new UsersController();
            UserInfo uInfo = new UserInfo()
            {
                Address = txtAddress.Text,
                CreatedBy = CurrentUser.ID,
                CreatedOn = DateTime.Now,
                DisplayName = txtDisplayName.Text.Trim(),
                EdittedBy = CurrentUser.ID,
                EdittedOn = DateTime.Now,
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                Gender = rdNam.Checked,
                UserName = txtUserName.Text,
                IsLock = false,
                IsSuperUser = false,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text
            };
            if (!dfBirthday.SelectedDate.ToString().Contains("0001"))
            {
                uInfo.Birthday = dfBirthday.SelectedDate;
            }
            else
            {
                uInfo.Birthday = new DateTime(1900, 1, 1);
            }
            //Insert
            if (e.ExtraParams["Command"] != "Update")
            {
                int userID = uController.CreateUser(uInfo);
                // new DM_DONVIController().AddUserIntoDonVi(Session["MaDonVi"].ToString(), userID);
                new DM_DONVIController().AddUserIntoDonVi(hdfSelectedDepartmentID.Text, userID);
                Dialog.ShowNotification("Thêm mới tài khoản thành công");
            }
            else
            {
                uInfo.Password = "";
                uInfo.ID = int.Parse(hdfRecordID.Text);
                uController.UpdateUser(uInfo);
                new DM_DONVIController().UpdateUserIntoDonVi(hdfSelectedDepartmentID.Text, uInfo.ID);
                Dialog.ShowNotification("Cập nhật tài khoản thành công");
            }
            GridPanel1.Reload();
            if (!string.IsNullOrEmpty(txtEmail.Text) && chkSendMail.Checked)
            {
                sendEmailCreateAccount(uInfo);
            }

            if (e.ExtraParams["Close"] == "True")
            {
                wdAddUser.Hide();
            }
            else
            {
                ResourceManager1.RegisterClientScriptBlock("resetForm", "resetForm();");
            }

        }
        catch (SqlException sqlex)
        {
            switch (sqlex.Number)
            {
                case 2627:
                    X.MessageBox.Alert("Có lỗi xảy ra", "Tài khoản này đã tồn tại, bạn vui lòng chọn tài khoản khác").Show();
                    break;
                default:
                    X.MessageBox.Alert("Có lỗi xảy ra", sqlex.Message).Show();
                    break;
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    private void sendEmailCreateAccount(UserInfo uInfo)
    {
        // send email to user
        HeThongController htController = new HeThongController();
        object mailFrom = htController.GetValueByName(SystemConfigParameter.EMAIL, Session["MaDonVi"].ToString());
        string from = mailFrom != null ? mailFrom.ToString() : "";

        string mailPassword = htController.GetValueByName(SystemConfigParameter.PASSWORD_EMAIL, Session["MaDonVi"].ToString());
        string fromEmailPassword = mailPassword != null ? mailPassword.ToString() : "";

        if (from == "" || fromEmailPassword != "")
        {
            from = "dsofthrm@gmail.com";
            fromEmailPassword = "dsofthrm123";
        }

        string mailName = GlobalResourceManager.GetInstance().GetLanguageValue("email_title_create_account");
        string subject = GlobalResourceManager.GetInstance().GetLanguageValue("email_title_create_account");
        string content = Util.GetInstance().ReadFile(Server.MapPath("../../Modules/MailTemplate/CreateAccount." + GlobalResourceManager.GetInstance().GetCurrentCulture() + ".html"));

        if (uInfo.DisplayName == null)
        {
            content = string.Format(content, uInfo.UserName, uInfo.UserName, uInfo.Password);
        }
        else
        {
            content = string.Format(content, uInfo.DisplayName, uInfo.UserName, uInfo.Password);
        }

        if (mailFrom != "" && mailPassword != "")
        {
            SoftCore.Utilities.Email.SendEmail(from, fromEmailPassword, mailName, uInfo.Email, subject, content);

            X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), GlobalResourceManager.GetInstance().GetLanguageValue("email_notice_create_account")).Show();
        }
        // end send email to user
    }

    private void ReloadStore()
    {
        ResourceManager1.RegisterClientScriptBlock("d", "#{Store1}.reload();");
    }

    protected void StoreAcc_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<object> objData = new List<object>();
        List<DM_CBInfo> cbInfoList = new HoSoController().GetList("," + hdfIdList.Text);
        string newIdList = "";

        HoSoController hsController = new HoSoController();
        foreach (var item in cbInfoList)//.Where(t => string.IsNullOrEmpty(t.EMAIL) == false))
        {
            UserAccountInfo accInfo = new UserAccountInfo
            {
                UserID = item.MA_CB,
                FullName = item.HO_TEN,
                //UserName = hsController.CreateUserAcc(item.HO_TEN),
                Password = Util.GetInstance().GetRandomString(7),
                Email = item.EMAIL
            };
            if (rdSuDungEmail.Checked == true)
                accInfo.UserName = item.EMAIL;
            else
                accInfo.UserName = hsController.CreateUserAcc(item.HO_TEN);
            objData.Add(accInfo);
            newIdList += item.MA_CB + ",";
        }
        StoreAcc.DataSource = objData;
        StoreAcc.DataBind();

        //Thông báo nếu không có email
//        int hasNoEmail = cbInfoList.Where(t => string.IsNullOrEmpty(t.EMAIL)).Count();
//        if (hasNoEmail > 0)
//        {
//            X.MessageBox.Alert("Thông báo", string.Format(@"Có {0} nhân viên chưa có thông tin email. 
//                              Chức năng này chỉ áp dụng cho các đối tượng đã có địa chi email", hasNoEmail)).Show();
//        }
        hdfIdList.Text = newIdList;
        hdfJsonData.Text = Ext.Net.JSON.Serialize(objData);
    }
}