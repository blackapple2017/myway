using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;

public partial class Modules_TuyenDung_HoSoUngVien_ucPhanLoaiUngVien : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Next_Click(object sender, DirectEventArgs e)
    {
        int index = int.Parse(e.ExtraParams["index"]);

        if ((index + 1) < this.WizardPanel.Items.Count)
        {
            this.WizardPanel.ActiveIndex = index + 1;
        }

        this.CheckButtons();
    }

    protected void Prev_Click(object sender, DirectEventArgs e)
    {
        int index = int.Parse(e.ExtraParams["index"]);

        if ((index - 1) >= 0)
        {
            this.WizardPanel.ActiveIndex = index - 1;
        }

        this.CheckButtons();
    }

    private void CheckButtons()
    {
        int index = this.WizardPanel.ActiveIndex;

        this.btnNext.Disabled = index == (this.WizardPanel.Items.Count - 1);
        this.btnPrev.Disabled = index == 0;
    }

    public void cbxTrinhDo_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DM_TRINHDO> lists = new DM_TRINHDOController().GetByAll();
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA_TRINHDO = item.MA_TRINHDO, TEN_TRINHDO = item.TEN_TRINHDO });
        }
        cbxTrinhDo_Store.DataSource = obj;
        cbxTrinhDo_Store.DataBind();
    }
    //public void cbxTrangThaiXuLy_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    cbxTrangThaiXuLy_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("TrangThaiTuyenDung", true);
    //    cbxTrangThaiXuLy_Store.DataBind();
    //}


    public void cbxXepLoai_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DM_XEPLOAI> lists = new DM_XEPLOAIController().GetByAll();
        /*List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA_XEPLOAI = item.MA_XEPLOAI, TEN_XEPLOAI = item.TEN_XEPLOAI });
        }*/
        cbxXepLoai_Store.DataSource = lists;
        cbxXepLoai_Store.DataBind();
    }

    public void cbxChuyenNganh_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DM_CHUYENNGANH> lists = new DM_CHUYENNGANHController().GetByAll();
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA_CHUYENNGANH = item.MA_CHUYENNGANH, TEN_CHUYENNGANH = item.TEN_CHUYENNGANH });
        }
        cbxChuyenNganh_Store.DataSource = obj;
        cbxChuyenNganh_Store.DataBind();
    }
    public void cbxTDNgoaiNgu_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DM_NGOAINGU> lists = new DM_NGOAINGUController().GetByAll();
        List<object> obj = new List<object>();
        foreach (var item in lists)
        {
            obj.Add(new { MA_NGOAINGU = item.MA_NGOAINGU, TEN_NGOAINGU = item.TEN_NGOAINGU });
        }
        cbxTDNgoaiNgu_Store.DataSource = obj;
        cbxTDNgoaiNgu_Store.DataBind();
    }
    //
     //grpDanhSachThamSoStore.DataSource = new ThamSoTrangThaiController().GetByParamName(cbDanhSachThamSo.SelectedItem.Value, true);
     //           grpDanhSachThamSoStore.DataBind();
    public void cbxTrangThaiUngVien_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxTrangThaiUngVien_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("TrangThaiUngVien", true);
        cbxTrangThaiUngVien_Store.DataBind();
    }
}