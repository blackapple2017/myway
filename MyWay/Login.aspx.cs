using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore;
using ExtMessage;
using Ext.Net;
using DAL;
using SoftCore.AccessHistory;
using System.Threading;
using System.Globalization;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }

    protected void btnLogin_Click(object sender, DirectEventArgs e)
    { 
        try
        {
            string donviId = ""; 
            UserController c = new UserController(); 
            DAL.User user = new UserController().CheckLogin(txtUserName.Text, txtPassword.Text);
            if (user != null)
            {
                // lấy danh sách các bộ phận được truy cập tìm cán bộ sinh nhật trong tháng
                string dsDv = new DepartmentRoleController().GetMaBoPhanByRole(user.ID, DepartmentRoleController.MENUID_BIRTHDAY);
                DAL.DM_DONVI department = c.GetDonViByUserID(user.ID).FirstOrDefault(); 
                if (department != null)
                {
                    donviId = department.MA_DONVI;
                    SoftCore.User.UserInfo uInfo = new SoftCore.User.UserInfo(user.ID, user.UserName, user.FirstName, user.LastName, user.Image, user.DisplayName, user.Email, user.IsSuperUser, user.IsLock, user.Phone, user.Address, user.CreatedBy, user.CreatedOn, user.EdittedBy, user.EdittedOn, user.Password, user.Birthday, user.Gender);
                    Session["CURRENTUSER"] = uInfo;
                    Session["USERNAME"] = txtUserName.Text;
                    object objCount = DataController.DataHandler.GetInstance().ExecuteScalar("Hopdong_CountDanhSachNhanVienSapHetHopDong", "@day", "@MaDonVi", "@UserID", "@MenuID", 30, donviId, uInfo.ID, DepartmentRoleController.MENUID_CONTRACT);
                    object objSNhat = DataController.DataHandler.GetInstance().ExecuteScalar("report_CountBirthdayOfEmployee", "@MaDonVi", "@MaBoPhan", "@startMonth", "@endMonth", "@Gender", "@whereClause",
                            donviId, dsDv, DateTime.Now.Month, DateTime.Now.Month, "", "1=1");
                    Session["DataHomePage"] = objSNhat + ";" + objCount;
                    Session["MaDonVi"] = donviId;
                    Session["Language"] = cbLanguage.SelectedItem.Value;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    X.MessageBox.Alert("Có lỗi xảy ra","Tài khoản này chưa được cấp phát quyền đăng nhập").Show();
                }
            }
            else
            {
                RM.RegisterClientScriptBlock("al", "Ext.Msg.alert('" + GlobalResourceManager.GetInstance().GetErrorMessageValue("LoginFail") + "', '" + GlobalResourceManager.GetInstance().GetErrorMessageValue("LoginFailMessage") + "');");
            }
        }
        catch (Exception ex)
        {
            RM.RegisterClientScriptBlock("al", "Ext.Msg.alert('Error', \"" + ex.Message + "\");"); 
        }
    }

    /// <summary>
    /// Ghi log lịch sử truy cập
    /// </summary>
    private void SaveLog(string userName)
    {
        NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
        {
            MOTA = GlobalResourceManager.GetInstance().GetHistoryAccessValue("Login"),
            CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("Login"),
            IsError = false,
            USERNAME = userName,
            THOIGIAN = DateTime.Now,
            MANGHIEPVU = "Users",
            TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
            IPMAY = Request.UserHostAddress,
            THAMCHIEU = "",
        };
        new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
    }

    [DirectMethod]
    public void DirectLogin()
    {
        btnLogin_Click(null, null);
    }

    /*
     * Reset password
     */
    protected void btnResetPassword_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string userName = txtResetUsername.Text;
            string email = txtResetEmail.Text;
            string maDonVi = string.Empty;//Mã đơn vị của người khôi phục mật khẩu
            if (new UserController().CheckUserResetPassword(userName, email,ref maDonVi))
            {
                string newPassword = Util.GetInstance().GetRandomString(7); 

                HeThongController htController = new HeThongController();
                string systemGmail = htController.GetValueByName(SystemConfigParameter.EMAIL,maDonVi );  
                string systemGmailPassword = htController.GetValueByName(SystemConfigParameter.PASSWORD_EMAIL, maDonVi);

                if (string.IsNullOrEmpty(systemGmail) || string.IsNullOrEmpty(systemGmailPassword))
                {
                    X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), "Chưa có thông tin Email của hệ thống, bạn hãy liên hệ với người quản lý phần mềm để được hỗ trợ !").Show();
                    return;
                }

                string mailName = GlobalResourceManager.GetInstance().GetLanguageValue("email_title_forgot_password");
                string subject = GlobalResourceManager.GetInstance().GetLanguageValue("email_title_forgot_password");
                string content = Util.GetInstance().ReadFile(Server.MapPath("Modules/MailTemplate/ForgotPassword." + GlobalResourceManager.GetInstance().GetCurrentCulture() + ".html"));
                SoftCore.User.UserInfo uinfo = UsersController.GetInstance().GetUser(userName);
                
                if (uinfo.DisplayName == null)
                {
                    content = string.Format(content, userName, userName, newPassword);
                }
                else
                {
                    content = string.Format(content, uinfo.DisplayName, userName, newPassword);
                }
                if (SoftCore.Utilities.Email.SendEmail(systemGmail, systemGmailPassword, mailName, email, subject, content))
                {
                    uinfo.ChangePassword(newPassword);
                    X.Msg.Alert("Đổi mật khẩu thành công", GlobalResourceManager.GetInstance().GetLanguageValue("email_notice_forgot_password")).Show();
                    wdResetPassword.Hide();
                }
                else
                {
                    X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), "Xin lỗi ,Khôi phục mật khẩu không thành công !").Show();
                }
            }
            else
            {
                X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), GlobalResourceManager.GetInstance().GetLanguageValue("email_error_forgot_password")).Show();
            }
            txtResetUsername.Clear();
            txtResetEmail.Clear();
        }
        catch (Exception ex)
        {
            X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show(); 
        }
    }
}