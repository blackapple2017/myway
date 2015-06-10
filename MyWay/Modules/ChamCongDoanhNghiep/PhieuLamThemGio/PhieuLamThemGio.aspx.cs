using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;
using Controller.ChamCongDoanhNghiep;
using ExtMessage;
using System.Data;
using SoftCore;

public partial class Modules_ChamCongDoanhNghiep_PhieuLamThemGio_PhieuLamThemGio : WebBase
{
    SoftCore.Util util = new SoftCore.Util();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            cbxMonth.SetValue(0);
            spnYear.SetValue(DateTime.Now.Year);
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearch.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee_AfterClickAcceptButton);
    }
    public void ucChooseEmployee_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            hdfTotalRecord.Text = ucChooseEmployee1.SelectedRow.Count.ToString();
            foreach (var item in ucChooseEmployee1.SelectedRow)
            {
                // get employee information
                DAL.HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
                string pr_keyhoso = hs.PR_KEY.ToString();
                string ma_cb = hs.MA_CB;
                string ho_ten = hs.HO_TEN;
                string ten_donvi = new DM_DONVIController().GetNameById(hs.MA_DONVI);
                // insert record to grid
                RM.RegisterClientScriptBlock("insert" + pr_keyhoso, string.Format("addRecord('{0}', '{1}', '{2}', '{3}');", pr_keyhoso, ma_cb, ho_ten, ten_donvi));
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void btnCapNhatHL_Click(object sender, DirectEventArgs e)
    {
        try
        {
            PhieuLamThemGioController controller = new PhieuLamThemGioController();
            List<ShortHoSoInfo> rs = Ext.Net.JSON.Deserialize<List<ShortHoSoInfo>>(e.ExtraParams["json"]);
            foreach (ShortHoSoInfo created in rs)
            {
                PhieuLamThemGio p = new PhieuLamThemGio();
                p.PrkeyHoSo = created.PR_KEY;
                p.TuGio = tfStart.Text;
                p.DenGio = tfEnd.Text;
                if (!string.IsNullOrEmpty(txt_L_AM.Text))
                    p.LamThemNgayLe_AM = double.Parse(txt_L_AM.Value.ToString());
                if (!string.IsNullOrEmpty(txt_N_AM.Text))
                    p.LamThemNgayNghi_AM = double.Parse(txt_N_AM.Value.ToString());
                if (!string.IsNullOrEmpty(txt_T_AM.Text))
                    p.LamThemNgayThuong_AM = double.Parse(txt_T_AM.Value.ToString());
                if (!string.IsNullOrEmpty(txt_L_PM.Text))
                    p.LamThemNgayLe_PM = double.Parse(txt_L_PM.Value.ToString());
                if (!string.IsNullOrEmpty(txt_N_PM.Text))
                    p.LamThemNgayNghi_PM = double.Parse(txt_N_PM.Value.ToString());
                if (!string.IsNullOrEmpty(txt_T_PM.Text))
                    p.LamThemNgayThuong_PM = double.Parse(txt_T_PM.Value.ToString());
                if (!util.IsDateNull(dfDate.SelectedDate))
                    p.NgayDangKy = dfDate.SelectedDate;
                p.NoiDung = txtCongViecHL.Text;
                controller.Insert(p);
            }
            if (e.ExtraParams["close"] == "True")
            {
                wdThemCanBoHL.Hide();
            }
            RM.RegisterClientScriptBlock("resetform", "ResetWdThemCanBoHL();");
            grpPhieuLamThemGio.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    } 
    #region Direct Event
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            PhieuLamThemGioController controller = new PhieuLamThemGioController();
            DAL.PhieuLamThemGio dk = new PhieuLamThemGio();
            dk.DenGio = tfGioKetThuc.Text;
            if (!string.IsNullOrEmpty(txtLamNgayLe.Text))
                dk.LamThemNgayLe_AM = double.Parse(txtLamNgayLe.Value.ToString());
            if (!string.IsNullOrEmpty(txtLamNgayNghi.Text))
                dk.LamThemNgayNghi_AM = double.Parse(txtLamNgayNghi.Value.ToString());
            if (!string.IsNullOrEmpty(txtLamNgayThuong.Text))
                dk.LamThemNgayThuong_AM = double.Parse(txtLamNgayThuong.Value.ToString());
            if (!string.IsNullOrEmpty(txtLamNgayLe_PM.Text))
                dk.LamThemNgayLe_PM = double.Parse(txtLamNgayLe_PM.Value.ToString());
            if (!string.IsNullOrEmpty(txtLamNgayNghi_PM.Text))
                dk.LamThemNgayNghi_PM = double.Parse(txtLamNgayNghi_PM.Value.ToString());
            if (!string.IsNullOrEmpty(txtLamNgayThuong_PM.Text))
                dk.LamThemNgayThuong_PM = double.Parse(txtLamNgayThuong_PM.Value.ToString());
            if (!util.IsDateNull(dfNgayDK.SelectedDate))
                dk.NgayDangKy = dfNgayDK.SelectedDate;
            dk.NoiDung = txtNoiDungCongViec.Text;
            dk.PrkeyHoSo = decimal.Parse(hdfChonCanBo.Text);
            dk.TuGio = tfGioBatDau.Text;
            if (e.ExtraParams["Edit"] == "True")
            {
                dk.ID = int.Parse(hdfRecordID.Text);
                controller.Update(dk);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công");
                wdThemCanBo.Hide();
            }
            else
            {
                controller.Insert(dk);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdThemCanBo.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rs1", "ResetWdThemCanBo();");
                }
            }
            grpPhieuLamThemGio.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnDieuChinh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfRecordID.Text == "")
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy dũ liệu").Show();
                return;
            }
            DAL.PhieuLamThemGio dky = new PhieuLamThemGioController().GetById(decimal.Parse(hdfRecordID.Text));
            if (dky != null)
            {
                DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("HOSO_GetHoSoInfo", "@Prkey", dky.PrkeyHoSo);
                hdfChonCanBo.SetValue(dky.PrkeyHoSo);
                if (table.Rows.Count > 0)
                {
                    cbxChonCanBo.Text = table.Rows[0]["HO_TEN"].ToString();
                }
                if (!util.IsDateNull(dky.NgayDangKy))
                    dfNgayDK.SetValue(dky.NgayDangKy);
                tfGioBatDau.SetValue(dky.TuGio);
                tfGioKetThuc.SetValue(dky.DenGio);
                txtNoiDungCongViec.Text = dky.NoiDung;
                txtLamNgayLe.SetValue(dky.LamThemNgayLe_AM);
                txtLamNgayNghi.SetValue(dky.LamThemNgayNghi_AM);
                txtLamNgayThuong.SetValue(dky.LamThemNgayThuong_AM);
                txtLamNgayThuong_PM.SetValue(dky.LamThemNgayThuong_PM);
                txtLamNgayNghi_PM.SetValue(dky.LamThemNgayNghi_PM);
                txtLamNgayLe_PM.SetValue(dky.LamThemNgayLe_PM);

                wdThemCanBo.Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnXoa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SelectedRowCollection selectedRows = RowSelectionModel1.SelectedRows;
            foreach (var item in selectedRows)
            {
                new PhieuLamThemGioController().Delete(decimal.Parse(item.RecordID));
            }
            grpPhieuLamThemGio.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Other Functions
    private string GetTime(string time)
    {
        if (time == "" || time.Contains("-"))
            return "";
        int pos = time.LastIndexOf(':');
        if (pos == -1)
            return "";
        return time.Substring(0, pos);
    }
    #endregion
}