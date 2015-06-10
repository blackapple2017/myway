using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;

public partial class Modules_BaoHiem_QuyDinhMucDongBaoHiem : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
        }
    }

    protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
    }
  

    protected void grp_QuyDinhMucDongBaoHiem_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        //int count;
        //grp_QuyDinhMucDongBaoHiem_Store.DataSource = new MucDongBaoHiemController().GetMucDongBaoHiemByMaDonVi(Session["MaDonVi"].ToString(), out count);
        //grp_QuyDinhMucDongBaoHiem_Store.DataBind();
    }

    protected void btnUpdateQuyDinhBienDong_Click(object sender, DirectEventArgs e)
    {
        //DAL.BHMUCDONGBAOHIEM md = new DAL.BHMUCDONGBAOHIEM();
        //MucDongBaoHiemController ctr = new MucDongBaoHiemController();
        //md.NgayHieuLuc =DateTime.Parse(dfNgayHieuLuc.Value.ToString());
        //if(!string.IsNullOrEmpty(nfSanBHXH.Text))
        //{
        //    md.SanBHXH=decimal.Parse(nfSanBHXH.Text.Replace('.',','));
        //}
        //if (!string.IsNullOrEmpty(nfSanBHYT.Text))
        //{
        //    md.SanBHYT = decimal.Parse(nfSanBHYT.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfSanBHTN.Text))
        //{
        //    md.SanBHTN = decimal.Parse(nfSanBHTN.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfTranBHXH.Text))
        //{
        //    md.TranBHXH = decimal.Parse(nfTranBHXH.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfTranBHYT.Text))
        //{
        //    md.TranBHXH = decimal.Parse(nfTranBHYT.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfTranBHTN.Text))
        //{
        //    md.TranBHXH = decimal.Parse(nfTranBHTN.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfBHXHNhanVien.Text))
        //{
        //    md.NVBYXH = decimal.Parse(nfBHXHNhanVien.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfBHYTNhanVien.Text))
        //{
        //    md.NVBYXH = decimal.Parse(nfBHYTNhanVien.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfBHTNNhanVien.Text))
        //{
        //    md.NVBYXH = decimal.Parse(nfBHTNNhanVien.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfBHXHDonVi.Text))
        //{
        //    md.DVBHXH = decimal.Parse(nfBHXHDonVi.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfBHYTDonVi.Text))
        //{
        //    md.DVBHXH = decimal.Parse(nfBHYTDonVi.Text.Replace('.', ','));
        //}
        //if (!string.IsNullOrEmpty(nfBHTNDonVi.Text))
        //{
        //    md.DVBHXH = decimal.Parse(nfBHTNDonVi.Text.Replace('.', ','));
        //}
        //md.DateCreate = DateTime.Now;
        //md.UserID = CurrentUser.ID;
        //md.MaDonVi = Session["MaDonVi"].ToString();

        //ctr.InsertMucDongBaoHiem(md);
        //grp_QuyDinhMucDongBaoHiem.Reload();
    }
}