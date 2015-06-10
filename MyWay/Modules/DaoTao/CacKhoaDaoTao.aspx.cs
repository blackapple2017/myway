using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;

public partial class Modules_DaoTao_CacKhoaDaoTao : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            grpKhoaDaoTao.GetAddButton().Listeners.Click.Handler = "wdDaotao.show();frm_txtMaKhoaDaoTao.enable();btn_EditKhoaDaoTao.hide();";
            grpKhoaDaoTao.GetGridPanel().Listeners.ViewReady.Handler = "cbx_chungchi.store.reload();btn_EditKhoaDaoTao.show();";
        }
        grpKhoaDaoTao.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnEditKhoaDaoTao_Click);
        grpKhoaDaoTao.GetGridPanel().DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEditKhoaDaoTao_Click);
    }



    protected void btnEditKhoaDaoTao_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //Dialog.ShowNotification(grpKhoaDaoTao.GetSelectedRecordIDs().FirstOrDefault());
            //Không lấy được ID khi kick vào xóa 1 cột ? Khi click vào khi để cập nhập không được
            DAL.KHOA_DAOTAO khoadaotao = new KHOA_DAOTAOController().GetKhoaDaoTaoByMaDaoTao(grpKhoaDaoTao.GetSelectedRecordIDs().FirstOrDefault());
            if (khoadaotao != null)
            {
                frm_txtMaKhoaDaoTao.Text = khoadaotao.MA_KHOA;
                frm_txtNhanVienDongGop.Text = khoadaotao.NhanVienDong.ToString();
                frm_txtMaKhoaDaoTao.Disabled = true;
                frm_txtKinhPhiDuKien.Text = khoadaotao.CHIPHIDUKIEN.ToString();
                frm_txtThoigiandukien.Text = khoadaotao.ThoiGianDuKien;
                frm_txtCongTyHoTro.Text = khoadaotao.CongTyHoTro.ToString();
                frm_txtsoluonghocvien.Text = khoadaotao.SOLUONGHOCVIEN.ToString();
                frm_txtdiadiemdaotao.Text = khoadaotao.DIA_DIEM_DAO_TAO;
                frm_txtTenKhoaDaoTao.Text = khoadaotao.TEN_KHOAHOC;
                cbx_chungchi.Text = khoadaotao.MA_CHUNGCHI;
                chk_nganhan.Checked = khoadaotao.IsNganHan;
                hdfChonTenDonViPhuTrach.Text = khoadaotao.MA_DONVIPHUTRACH;
                if (khoadaotao.MA_DONVIPHUTRACH != null)
                    cbxDonViPhuTrach.Text = khoadaotao.DM_DOITACDAOTAO.Ten;

                frm_txtKinhPhiThucTe.Text = khoadaotao.CHIPHITHUCTE.ToString();
                hdfCommand.Text = "Edit";
                wdDaotao.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void cbx_chungchi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DAL.DM_CHUNGCHI> lists = new KHOA_DAOTAOController().GetByAll();
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA_CHUNGCHI = item.MA_CHUNGCHI, TEN_CHUNGCHI = item.TEN_CHUNGCHI });
        }
        cbx_chungchi_Store.DataSource = obj;
        cbx_chungchi_Store.DataBind();
    }
    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            KHOA_DAOTAOController daotao = new KHOA_DAOTAOController();
            DAL.KHOA_DAOTAO khoadaotao = new DAL.KHOA_DAOTAO();
            khoadaotao.TEN_KHOAHOC = frm_txtTenKhoaDaoTao.Text;
            khoadaotao.CreatedUser = CurrentUser.ID;
            khoadaotao.DIA_DIEM_DAO_TAO = frm_txtdiadiemdaotao.Text;
            if (!string.IsNullOrEmpty(frm_txtsoluonghocvien.Text))
            {
                khoadaotao.SOLUONGHOCVIEN = int.Parse(frm_txtsoluonghocvien.Text);
            }
            if (!string.IsNullOrEmpty(frm_txtNhanVienDongGop.Text))
            {
                khoadaotao.NhanVienDong = decimal.Parse(frm_txtNhanVienDongGop.Text);
            }
            if (!string.IsNullOrEmpty(frm_txtCongTyHoTro.Text))
            {
                khoadaotao.CongTyHoTro = decimal.Parse(frm_txtCongTyHoTro.Text);
            }
            khoadaotao.MA_KHOA = frm_txtMaKhoaDaoTao.Text;
            if (!string.IsNullOrEmpty(frm_txtKinhPhiDuKien.Text))
            {
                khoadaotao.CHIPHIDUKIEN = decimal.Parse(frm_txtKinhPhiDuKien.Text);
            }
            if (!string.IsNullOrEmpty(frm_txtKinhPhiThucTe.Text))
            {
                khoadaotao.CHIPHITHUCTE = decimal.Parse(frm_txtKinhPhiThucTe.Text);
            }

                khoadaotao.IsNganHan = chk_nganhan.Checked;
           
            
            khoadaotao.MA_DONVI = Session["MaDonVi"].ToString();
            if (cbx_chungchi.SelectedItem.Value != null)
                khoadaotao.MA_CHUNGCHI = cbx_chungchi.SelectedItem.Value;
            khoadaotao.ThoiGianDuKien = frm_txtThoigiandukien.Text;

            if (!string.IsNullOrEmpty(hdfChonTenDonViPhuTrach.Text))
            {
                khoadaotao.MA_DONVIPHUTRACH = hdfChonTenDonViPhuTrach.Text;
            }

            if (e.ExtraParams["Command"] == "Edit")
            {
                daotao.UpdateKhoaDaoTao(khoadaotao);
                grpKhoaDaoTao.GetGridPanel().Reload();
                Dialog.ShowNotification("Cập nhật thành công");
                wdDaotao.Hide();
            }
            else
            {
                daotao.InsertKhoaDaoTao(khoadaotao);
                grpKhoaDaoTao.GetGridPanel().Reload();
                if (e.ExtraParams["Close"] == "True")
                {
                    wdDaotao.Hide();
                }
                else
                {
                    grpKhoaDaoTao.GetResourceManager().RegisterClientScriptBlock("rsf", "ResetValue()");
                }
                Dialog.ShowNotification("Cập nhật thành công");
            }
            grpKhoaDaoTao.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
            {
                Dialog.ShowError("Mã Khoa viên không được trùng !");
            }
            else
                Dialog.ShowError(ex.Message);
        }
    }





}