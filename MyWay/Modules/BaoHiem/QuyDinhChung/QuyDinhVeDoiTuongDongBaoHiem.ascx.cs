using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using System.Data;

public partial class Modules_BaoHiem_QuyDinhChung_QuyDinhVeDoiTuongDongBaoHiem :UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DataTable record = new DM_LOAI_HDONGBHController().GetByPrkey(hdfRecordID.Text);
        if (record.Rows.Count > 0)
        {

            if (!string.IsNullOrEmpty(record.Rows[0]["BHXH"].ToString()))
            {
                chkIsBHXH.Checked = (Boolean)record.Rows[0]["BHXH"];
            }
            if (!string.IsNullOrEmpty(record.Rows[0]["BHYT"].ToString()))
            {
                chkIsBHYT.Checked = (Boolean)record.Rows[0]["BHYT"];
            }
            if (!string.IsNullOrEmpty(record.Rows[0]["BHTN"].ToString()))
            {
                chkIsBHTN.Checked = (Boolean)record.Rows[0]["BHTN"];
            }

            hdfCommand.Text = "Update";
            wdAddWindow.Icon = Icon.Pencil;
            wdAddWindow.Title = "Sửa quy định về đối tượng đóng bảo hiểm";
            wdAddWindow.Show();
        }
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        DM_LOAI_HDONGInfo obj = new DM_LOAI_HDONGInfo();
        DM_LOAI_HDONGBHController ctr = new DM_LOAI_HDONGBHController();
        obj.BHXH = chkIsBHXH.Checked;
        obj.BHYT = chkIsBHYT.Checked;
        obj.BHTN = chkIsBHTN.Checked;
        if (e.ExtraParams["Command"]=="Edit")
        {
            obj.MA_LOAI_HDONG = hdfRecordID.Text;
            ctr.Update(obj);
            wdAddWindow.Hide();
           
        }
        GridPanel1.Reload();
      
    }
}