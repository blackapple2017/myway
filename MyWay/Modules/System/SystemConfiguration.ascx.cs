using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUI.Interface;
using WebUI.BaseControl;
using DataController;
using ExtMessage;
using WebUI.Controller;
using WebUI.Entity;
using DAL;
using Ext.Net;
using SoftCore.Security;
using System.Data;
using System.IO;

public partial class Modules_System_SystemConfiguration : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnUpdateConfig_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (txtSystemMail.Text.Contains("@gmail.com") == false && !string.IsNullOrEmpty(txtSystemMail.Text))
            {
                X.MessageBox.Alert("Thông báo", "Hệ thống chỉ chấp nhận định dạng gmail").Show();
                return;
            }
            string maDonVi = Session["MaDonVi"].ToString();
            HeThongController htController = new HeThongController();
            // tab thông tin chung
            htController.CreateOrSave(SystemConfigParameter.EMAIL, txtSystemMail.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.PASSWORD_EMAIL, txtPassword.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.MENU_TYPE, cbMenuType.SelectedItem.Value, CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.COMPANY_NAME, txtCompanyName.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.CITY, txtCity.Text.Trim(), CurrentUser.ID, maDonVi);
           // htController.CreateOrSave(SystemConfigParameter.LUONG_CB, txtLuongCB.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.PREFIX, txtTienTo.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.NUMBER_OF_CHARACTER, txtSoLuong.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.COMPANY_ADDRESS, txt_DiaChi.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.COMPANY_MASOTHUE, txt_MaSoThue.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.COMPANY_DIENTHOAI, txt_DienThoai.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.COMPANY_FAX, txt_Fax.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.COMPANY_EMAIL, txt_Email.Text.Trim(), CurrentUser.ID, maDonVi);
         //   htController.CreateOrSave(SystemConfigParameter.BAO_HET_HAN_HOP_DONG, txtNotification.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.LOGO_COMPANY, hdfLogoCongTy.Text.Trim(), CurrentUser.ID, maDonVi);

            // tab sinh mã, số quyết định
            htController.CreateOrSave(SystemConfigParameter.SUFFIX_SOHOPDONG, txtSoHopDong.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.SUFFIX_SOQDLUONG, txtSoQuyetDinhLuong.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.SUFFIX_SOQDKHENTHUONG, txtSoQDKhenThuong.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.SUFFIX_SOQDKYLUAT, txtSoQDKyLuat.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.SUFFIX_SOQDCONGTAC, txtSoQDCongTac.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.SUFFIX_SOQDDIEUCHUYEN, txtSoQĐieuChuyen.Text.Trim(), CurrentUser.ID, maDonVi);

            // tab cấu hình chữ ký báo cáo
            htController.CreateOrSave(SystemConfigParameter.SuDungTenDangNhap, chknguoidangnhap.Checked.ToString(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.chuky1, txtnguoiky1.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.chuky2, txtnguoiky2.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.chuky3, txtnguoiky3.Text.Trim(), CurrentUser.ID, maDonVi);
            htController.CreateOrSave(SystemConfigParameter.chuky4, txtnguoiky4.Text.Trim(), CurrentUser.ID, maDonVi);

            wdWindow.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo", ex.Message).Show();
        }
    }

  //  [DirectMethod]
   // public void FillData()
    protected void wdWindow_BeforeShow(object sender, DirectEventArgs e)
    {
        try
        {
            string strMau = "Mẫu: 001/" + DateTime.Now.Year + "/";
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("SystemConfig_GetConfigByMaDonVi", "@MaDonVi", Session["MaDonVi"].ToString());
            foreach (DataRow item in table.Rows)
            {
                switch (item["VAR_NAME"].ToString())
                {
                    case SystemConfigParameter.EMAIL:
                        txtSystemMail.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.PASSWORD_EMAIL:
                        txtPassword.Text = item["VAR_VALUE"].ToString();
                        txtConfirmPassword.Text = txtPassword.Text;
                        break;
                    case SystemConfigParameter.MENU_TYPE:
                        cbMenuType.SetValue(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.COMPANY_NAME:
                        //if (string.IsNullOrEmpty(item["VAR_VALUE"].ToString()))
                        //{
                        //    txtCompanyName.Text = new DM_DONVIController().GetById(Session["MaDonVi"].ToString()).TEN_DONVI;
                        //}
                        //else
                        //{
                            txtCompanyName.Text = item["VAR_VALUE"].ToString();
                      //  }
                        break;
                    case SystemConfigParameter.COMPANY_ADDRESS:
                        txt_DiaChi.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.COMPANY_MASOTHUE:
                        txt_MaSoThue.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.COMPANY_DIENTHOAI:
                        txt_DienThoai.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.COMPANY_FAX:
                        txt_Fax.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.COMPANY_EMAIL:
                        txt_Email.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.LOGO_COMPANY:
                        imgLogoCongTy.ImageUrl = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.CITY:
                        txtCity.Text = item["VAR_VALUE"].ToString();
                        break;
                    //case SystemConfigParameter.LUONG_CB:
                    //    txtLuongCB.SetValue(item["VAR_VALUE"].ToString());
                    //    break;
                    case SystemConfigParameter.PREFIX:
                        txtTienTo.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.NUMBER_OF_CHARACTER:
                        txtSoLuong.Text = item["VAR_VALUE"].ToString();
                        break;
                    //case SystemConfigParameter.CONG_CHUAN:
                    //    txtSoNgayCongChuan.Text = item["VAR_VALUE"].ToString();
                    //    break;
                    // tab sinh mã, số quyết định
                    case SystemConfigParameter.SUFFIX_SOHOPDONG:
                        txtSoHopDong.Text = item["VAR_VALUE"].ToString();
                        txtSoHopDong.Note = strMau + item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.SUFFIX_SOQDLUONG:
                        txtSoQuyetDinhLuong.Text = item["VAR_VALUE"].ToString();
                        txtSoQuyetDinhLuong.Note = strMau + item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.SUFFIX_SOQDKHENTHUONG:
                        txtSoQDKhenThuong.Text = item["VAR_VALUE"].ToString();
                        txtSoQDKhenThuong.Note = strMau + item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.SUFFIX_SOQDKYLUAT:
                        txtSoQDKyLuat.Text = item["VAR_VALUE"].ToString();
                        txtSoQDKyLuat.Note = strMau + item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.SUFFIX_SOQDCONGTAC:
                        txtSoQDCongTac.Text = item["VAR_VALUE"].ToString();
                        txtSoQDCongTac.Note = strMau + item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.SUFFIX_SOQDDIEUCHUYEN:
                        txtSoQĐieuChuyen.Text = item["VAR_VALUE"].ToString();
                        txtSoQĐieuChuyen.Note = strMau + item["VAR_VALUE"].ToString();
                        break;

                    // tab sinh người ký báo cáo
                    case SystemConfigParameter.SuDungTenDangNhap:
                       // chknguoidangnhap.SetValue(Boolean.Parse(item["VAR_VALUE"].ToString()));
                        chknguoidangnhap.Checked = Boolean.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.chuky1:
                        txtnguoiky1.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.chuky2:
                        txtnguoiky2.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.chuky3:
                        txtnguoiky3.Text = item["VAR_VALUE"].ToString();
                        break;
                    case SystemConfigParameter.chuky4:
                        txtnguoiky4.Text = item["VAR_VALUE"].ToString();
                        break;
                }
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
            {
                DM_DONVI dv = new DM_DONVIController().GetById(Session["MaDonVi"].ToString());
                txtCompanyName.Text = dv.TEN_DONVI;
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo", ex.Message).Show();
        }
    }
    protected void btnUpdateImage_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //upload file
            HttpPostedFile file = fufUploadControl.PostedFile;
            string path = string.Empty;
            hdfImageFolder.SetValue("~/Modules/System/AttackFile");
            if (fufUploadControl.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Modules/System/AttackFile")); ;
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath(hdfImageFolder.Text + "/" + fufUploadControl.FileName);
                    file.SaveAs(path);
                    //update ảnh vào csdl
                    //  hdfUploadedImage.Text = hdfImageFolder.Text + "/" + fufUploadControl.FileName;                   
                    hdfLogoCongTy.SetValue(hdfImageFolder.Text + "/" + fufUploadControl.FileName);
                    imgLogoCongTy.ImageUrl = hdfImageFolder.Text + "/" + fufUploadControl.FileName;
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
            wdUploadImageWindow.Hide(); 
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}