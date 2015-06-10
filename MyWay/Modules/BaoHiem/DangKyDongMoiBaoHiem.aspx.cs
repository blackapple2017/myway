using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore;
using SoftCore.AccessHistory;
using ExtMessage;
using DAL;
using System.Data.SqlClient;

public partial class Modules_BaoHiem_DangKyDongMoiBaoHiem : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {

            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            hdfThang.Text = DateTime.Now.Month.ToString();
            hdfNam.Text = DateTime.Now.Year.ToString();
            cbxThang.Value = DateTime.Now.Month;
            spnNam.Value = DateTime.Now.Year;

            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearch.reset();PagingToolbar1.pageIndex = 0; grpDangKyDongMoiBaoHiem_store.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }
    }

    [DirectMethod]
    public void ThemNhanVienVaoDongBaoHiem(string manhanvien, string machucvu, bool bhxh, bool bhyt, bool bhtn,
                                    decimal LuongDongBaoHiem,
                                    decimal phucapcv,
                                    decimal phucaptnn,
                                    decimal phucaptnvk,
                                    decimal phucapkhac)
    {
        //RowSelectionModel sm = grpDangKyDongMoiBaoHiem.SelectionModel.Primary as RowSelectionModel;
        DangKyDongMoiController dkc = new DangKyDongMoiController();
        DateTime? ngaydangky = new BaoHiemController().SetValueDatetime(spnNam, cbxThang, 1);
        //lấy thông tin từ trên grid, đỡ phải tính toán thêm lần nữa
        try
        {
            dkc.LuuNhanVienDongMoi(manhanvien,
                                    Session["MaDonVi"].ToString(),
                                    machucvu,
                                    CurrentUser.ID,
                                    DateTime.Now,
                                    bhxh, bhyt, bhtn,
                                    LuongDongBaoHiem,
                                    phucapcv,
                                    phucaptnn,
                                    phucaptnvk,
                                    phucapkhac,
                                    ngaydangky);
            grpDangKyDongMoiBaoHiem.Reload();
            wdChonThangDangKy.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }

}