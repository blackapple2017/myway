using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;

public partial class Modules_ChamCongDoanhNghiep_QuanLyNghiBu : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMenuID.SetValue(MenuID);
            hdfUserID.SetValue(CurrentUser.ID);

            hdfYear.SetValue(DateTime.Now.Year.ToString());
            spfYear.SetValue(DateTime.Now.Year.ToString());
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "'); PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }
    }
    protected void btnDieuChinhNghiBu_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.QuanLyNghiBu qlnb = new DAL.QuanLyNghiBu();
            QuanLyNghiBuController ctrol = new QuanLyNghiBuController();
            qlnb.GiamT1 = double.Parse("0" + nbfGiamT1.Text.Replace(".", ","));
            qlnb.GiamT2 = double.Parse("0" + nbfGiamT2.Text.Replace(".", ","));
            qlnb.GiamT3 = double.Parse("0" + nbfGiamT3.Text.Replace(".", ","));
            qlnb.GiamT4 = double.Parse("0" + nbfGiamT4.Text.Replace(".", ","));
            qlnb.GiamT5 = double.Parse("0" + nbfGiamT5.Text.Replace(".", ","));
            qlnb.GiamT6 = double.Parse("0" + nbfGiamT6.Text.Replace(".", ","));
            qlnb.GiamT7 = double.Parse("0" + nbfGiamT7.Text.Replace(".", ","));
            qlnb.GiamT8 = double.Parse("0" + nbfGiamT8.Text.Replace(".", ","));
            qlnb.GiamT9 = double.Parse("0" + nbfGiamT9.Text.Replace(".", ","));
            qlnb.GiamT10 = double.Parse("0" + nbfGiamT10.Text.Replace(".", ","));
            qlnb.GiamT11 = double.Parse("0" + nbfGiamT11.Text.Replace(".", ","));
            qlnb.GiamT12 = double.Parse("0" + nbfGiamT12.Text.Replace(".", ","));
            qlnb.TangT1 = double.Parse("0" + nbfTangT1.Text.Replace(".", ","));
            qlnb.TangT2 = double.Parse("0" + nbfTangT2.Text.Replace(".", ","));
            qlnb.TangT3 = double.Parse("0" + nbfTangT3.Text.Replace(".", ","));
            qlnb.TangT4 = double.Parse("0" + nbfTangT4.Text.Replace(".", ","));
            qlnb.TangT5 = double.Parse("0" + nbfTangT5.Text.Replace(".", ","));
            qlnb.TangT6 = double.Parse("0" + nbfTangT6.Text.Replace(".", ","));
            qlnb.TangT7 = double.Parse("0" + nbfTangT7.Text.Replace(".", ","));
            qlnb.TangT8 = double.Parse("0" + nbfTangT8.Text.Replace(".", ","));
            qlnb.TangT9 = double.Parse("0" + nbfTangT9.Text.Replace(".", ","));
            qlnb.TangT10 = double.Parse("0" + nbfTangT10.Text.Replace(".", ","));
            qlnb.TangT11 = double.Parse("0" + nbfTangT11.Text.Replace(".", ","));
            qlnb.TangT12 = double.Parse("0" + nbfTangT12.Text.Replace(".", ","));
            qlnb.ID = decimal.Parse("0" + hdfRecordID.Text);
            ctrol.Update(qlnb);
            wdDieuChinhNghiBu.Hide();
            grpDanhSachNgayNghiBu.Reload();
            Dialog.ShowNotification("Cập nhật thành công!");
        }
        catch (Exception ex)
        {
            if (Equals(ex.Message, "Input string was not in a correct format."))
            {
                Dialog.ShowError("Có lỗi xảy ra", "Dữ liệu nhập vào phải là kiểu số! (VD: 1.5)");
            }
            else
            {
                Dialog.ShowError("Có lỗi xảy ra", ex.Message);
            }
        }
    }
}