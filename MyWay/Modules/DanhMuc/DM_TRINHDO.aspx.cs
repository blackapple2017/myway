using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TRINHDO : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            grpDanhMucTrinhDo.GetAddButton().Listeners.Click.Handler = "wdAddWindow.show();";
        }
        grpDanhMucTrinhDo.GetEditButton().DirectClick += new ComponentDirectEvent.DirectEventHandler(Modules_DanhMuc_DM_TRINHDO_DirectClick);
        grpDanhMucTrinhDo.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(Modules_DanhMuc_DM_TRINHDO_DirectClick);
    }
    /// <summary>
    /// Sự kiện khi click vào nút edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Modules_DanhMuc_DM_TRINHDO_DirectClick(object sender, DirectEventArgs e)
    {
        wdAddWindow.Title = "Sửa phụ cấp phúc lợi";
        wdAddWindow.Icon = Icon.Pencil;
        DAL.DM_TRINHDO trinhdo = new DM_TRINHDOController().GetByMaTrinhDo(grpDanhMucTrinhDo.GetSelectedRecordIDs().FirstOrDefault().ToString());
        txtMaTrinhDo.Text = trinhdo.MA_TRINHDO;
        txtMaTrinhDo.Disabled = true;
        txtTenTrinhDo.Text = trinhdo.TEN_TRINHDO;
        cbbNhomTrinhDo.SelectedItem.Value = trinhdo.NhomTrinhDo;
        txtGhiChu.Text = trinhdo.GHI_CHU;
        btnCapNhat.Hide();
        Button2.Hide();
        btnSua.Show();
        wdAddWindow.Show();
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        DAL.DM_TRINHDO trinhdo = new DM_TRINHDOController().GetByMaTrinhDo(txtMaTrinhDo.Text);
        if(trinhdo!=null)
        {
            grpDanhMucTrinhDo.GetResourceManager().RegisterClientScriptBlock("dfsdf", "alert('Mã trình độ này đã tồn tại')");
            return;
        }
        var dmtdc = new DM_TRINHDOController();
        trinhdo = new DAL.DM_TRINHDO();
        trinhdo.DATE_CREATE = DateTime.Now;
        trinhdo.GHI_CHU = txtGhiChu.Text;
        trinhdo.MA_DONVI = Session["MaDonVi"].ToString();
        trinhdo.MA_TRINHDO = txtMaTrinhDo.Text;
        trinhdo.NhomTrinhDo = cbbNhomTrinhDo.SelectedItem.Value;
        trinhdo.TEN_TRINHDO = txtTenTrinhDo.Text;
        trinhdo.USERNAME = CurrentUser.ID.ToString();
        dmtdc.Insert(trinhdo);
        grpDanhMucTrinhDo.GetGridPanel().Reload();
        grpDanhMucTrinhDo.GetResourceManager().RegisterClientScriptBlock("rmreset", "resetForm();");
        wdAddWindow.Title = "Thêm phụ cấp phúc lợi";
        wdAddWindow.Icon = Icon.Add;
        if (e.ExtraParams["Close"] == "True")
        {
            wdAddWindow.Hide();
        }
    }
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DAL.DM_TRINHDO trinhdo = new DM_TRINHDOController().GetByMaTrinhDo(txtMaTrinhDo.Text);
        trinhdo.MA_TRINHDO = txtMaTrinhDo.Text;
        trinhdo.TEN_TRINHDO = txtTenTrinhDo.Text;
        trinhdo.NhomTrinhDo = cbbNhomTrinhDo.SelectedItem.Value;
        trinhdo.GHI_CHU = txtGhiChu.Text;
        new DM_TRINHDOController().Update(trinhdo);
        grpDanhMucTrinhDo.GetGridPanel().Reload();
        wdAddWindow.Hide(); 
    }
}

//grpDanhMucTrinhDo.GetSelectedRecordIDs().FirstOrDefault().ToString()