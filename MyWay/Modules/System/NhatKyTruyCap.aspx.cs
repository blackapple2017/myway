using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.AccessHistory;
using SoftCore;
using SoftCore.Security;
using DataController;

public partial class Modules_System_NhatKyTruyCap : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!X.IsAjaxRequest)
        //{
            
        //}
        grp_nhatkytrucap.AddComponent(btnTruncateHistory, 2);
        grp_nhatkytrucap.HiddenDuplicateButton(true);
        if (!X.IsAjaxRequest)
        {
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("History"),
                MOTA = GlobalResourceManager.GetInstance().GetHistoryAccessValue("History"),
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "NHATKY_TRUYCAP",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
        Ext.Net.Button btnChooseTime = new Ext.Net.Button()
        {
            Text = "Chọn thời gian",
            Icon = Icon.Clock,
        };
        btnChooseTime.Listeners.Click.Handler = "#{wdChooseTime}.show();";
        if (!X.IsAjaxRequest)
        {
            grp_nhatkytrucap.HiddenAddButton(true);
            grp_nhatkytrucap.HiddenEditButton(true);
            grp_nhatkytrucap.HiddenHelpButton(true);
            grp_nhatkytrucap.HiddenTienIch(true);
        }
        grp_nhatkytrucap.AddComponent(btnChooseTime, 0);
    }

    protected void btnTruncateHistory_Click(object sender, DirectEventArgs e)
    {
        DataHandler.GetInstance().ExecuteNonQuery("truncate table NHATKY_TRUYCAP");
        grp_nhatkytrucap.ReloadStore();
    }

    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string startTime = "'" + DateTime1.GetValue().ToString() + "'";
            string endTime = "'" + DateTime2.GetValue().ToString() + "'";
            grp_nhatkytrucap.OutSideQuery = " THOI_GIAN > " + startTime + " and THOI_GIAN < " + endTime;
            grp_nhatkytrucap.ReloadStore();
            // Dialog.ShowNotification(startTime + "  " + endTime);
            wdChooseTime.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}