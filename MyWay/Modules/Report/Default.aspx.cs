using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using DataController;
using SoftCore;
using Ext.Net.Utilities;
using SoftCore.Security;
using Controller.DanhGia;

public partial class Modules_Report_Default : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            BindReportGroup();
            LoadDepartment();
            hdfMaDonvi.Text = Session["MaDonVi"].ToString();
            spfyear.Text = DateTime.Now.Year.ToString();
            dfReportDate.SelectedDate = DateTime.Now;
        }
    }
    /// <summary>
    /// get department list to display on html tree
    /// </summary>
    private void LoadDepartment()
    {
        List<DonViInfo> childList = new DM_DONVIController().GetEntityByParentID("0");
        string s = "";
        foreach (var item in childList)
        {
            s += string.Format("<li id='{0}' item-expanded='true'>{1}{2}</li>", item.MaDonVi, item.TenDonVi, BindChildDepartment(item.MaDonVi));
        }
        ldlMenuTree.Text = s;
    }

    private string BindChildDepartment(string parentID)
    {
        List<DonViInfo> childList = new DM_DONVIController().GetEntityByParentID(parentID);
        if (childList.Count() == 0)
        {
            return "";
        }
        string str = "";
        string function = "";
        foreach (var item in childList)
        {
            str += string.Format("<li id='{0}' item-expanded='true'>{1}{2}{3}</li>", item.MaDonVi, item.TenDonVi, BindChildDepartment(item.MaDonVi), function);
        }
        return string.Format("<ul>{0}</ul>", str);
    }
    /// <summary>
    /// Lấy danh sách các mã đơn vị được chọn
    /// </summary>
    /// <returns></returns>
    public string GetSelectedDepartment()
    {
        return hdfMaDonViList.Text;
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void AfterEdit(int id, string field, string oldValue, string newValue, object customer)
    {
        this.grpSelectedReportFilter.Store.Primary.CommitChanges();
    }

    private void BindReportGroup()
    {
        Ext.Net.TreeNode node = new Ext.Net.TreeNode()
        {
            Text = "Report",
            Expanded = true,
            NodeID = "0"
        };
        TreePanel1.Root.Add(node);
        BindChildGroup(node);
    }
    private void BindChildGroup(Ext.Net.TreeNode parentNode)
    {
        List<DAL.ReportGroup> reportGroupList = new ReportGroupController().GetReportGroupByParentID(parentNode.NodeID, true);
        foreach (var item in reportGroupList)
        {
            Ext.Net.TreeNode chidNode = new Ext.Net.TreeNode()
            {
                Text = item.REPORT_GROUP_NAME,
                NodeID = item.REPORT_GROUP_ID,
                Icon = Icon.Folder,
                Qtip = item.REPORT_GROUP_NAME
            };
            parentNode.Nodes.Add(chidNode);
            BindChildGroup(chidNode);
            BindChild(chidNode);
        }
    }
    private void BindChild(Ext.Net.TreeNode parentNode)
    {
        List<MiniReportInfo> dm_report = new ReportGroupController().GetReportByGroupID(parentNode.NodeID);
        string script = "";
        int number = 0;
        foreach (var item in dm_report)
        {
            Ext.Net.TreeNode chidNode = new Ext.Net.TreeNode()
            {
                Text = (++number) + ", " + item.Name,
                NodeID = item.ID.ToString(),
                // Qtip = item.Tooltip,
            };
            chidNode.Listeners.DblClick.Handler = "hdfReportID.setValue('" + item.ID + "'); document.getElementById('divReportPreview').style.display = 'none';hdfTitle.setValue('" + item.Name + "');txtReportTitle.setValue('" + item.Name.ToUpper() + "');wdReportFilter.show();" + item.Javascript;
            //chidNode.Listeners.Click.Handler = "getReportPreview('" + item.ImageReportPreview + "');hdfReportID.setValue('" + chidNode.NodeID + "');";
            chidNode.Listeners.ContextMenu.Handler = "hdfReportID.setValue('" + item.ID + "');";
            parentNode.Nodes.Add(chidNode);
            if (!string.IsNullOrEmpty(item.Javascript))
            {
                script += "if(hdfReportID.getValue()=='" + item.ID + "'){alert(hdfReportID.getValue());" + item.Javascript + "}";
            }
        }
        ltrShowSettingDialog.Text = "<script type='text/javascript'>var ShowSettingDialog = function(){document.getElementById('divReportPreview').style.display = 'none';" + script + "}</script>";
    }
    protected void cbxDotDanhGia_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        int year = int.Parse("0" + spfyear.Text);
        cbxDotDanhGiaStore.DataSource = new DotDanhGiaController().GetByYear(year);
        cbxDotDanhGiaStore.DataBind();
    }

    #region window filter
    struct WhereClause
    {
        public string WhereField { get; set; }
        public string WhereValue { get; set; }
    };
    private bool GetMinMaxNumber(out int minNumber, out int maxNumber, string regex)
    {
        minNumber = 0;
        maxNumber = 1000;
        if (string.IsNullOrEmpty(regex))
        {
            return true;
        }
        regex = regex.Trim();
        if (!string.IsNullOrEmpty(regex))
        {
            try
            {
                if (regex.StartsWith("="))
                {
                    minNumber = int.Parse(regex.Replace("=", ""));
                }
                else if (regex.Contains(">"))
                {
                    if (regex.Replace(">", "").Contains("="))
                    {
                        minNumber = int.Parse(regex.Replace(">", "").Replace("=", ""));
                    }
                    else
                    {
                        minNumber = int.Parse(regex.Replace(">", ""));
                    }
                }
                else if (regex.Contains("<"))
                {
                    if (regex.Replace("<", "").Contains("="))
                    {
                        maxNumber = int.Parse(regex.Replace("<", "").Replace("=", ""));
                    }
                    else
                    {
                        maxNumber = int.Parse(regex.Replace("<", ""));
                    }
                }
                else if (regex.Contains("-"))
                {
                    string[] tmp = regex.Split('-');
                    minNumber = int.Parse(tmp[0]);
                    maxNumber = int.Parse(tmp[1]);
                }
            }
            catch
            {
                return false;
            }
        }
        return true;
    }
    protected void btnShowReport_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int minSeniority = 0;
            int maxSeniority = 100000;
            int minAge = 0;
            int maxAge = 200;
            if (!GetMinMaxNumber(out minSeniority, out maxSeniority, txtSeniority.Text))
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Định dạng thâm niên nhập vào không hợp lệ ").Show();
                return;
            }
            if (!GetMinMaxNumber(out minAge, out maxAge, txtAge.Text))
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Định dạng tuổi nhập vào không hợp lệ ").Show();
                return;
            }
            List<WhereClause> whereList = new List<WhereClause>();
            string sql = "(";
            string lastWhere = "";
            if (!string.IsNullOrEmpty(e.ExtraParams["SQL"]))
            {
                string[] filter = e.ExtraParams["SQL"].Split(';');
                foreach (string item in filter)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        string[] pair = item.Split('=');
                        whereList.Add(new WhereClause()
                        {
                            WhereField = pair[0],
                            WhereValue = pair[1]
                        });
                    }
                }
                lastWhere = whereList.OrderBy(t => t.WhereField).FirstOrDefault().WhereField;
                foreach (var item in whereList.OrderBy(t => t.WhereField))
                {
                    if (item.WhereField == lastWhere)
                    {

                        sql += " " + item.WhereField + " = N'" + item.WhereValue + "' or";
                    }
                    else
                    {
                        if (sql.EndsWith("or"))
                        {
                            sql = sql.Remove(sql.LastIndexOf("or"));
                            sql += ") and (";
                        }
                        else if (sql.EndsWith("and"))
                        {
                            sql = sql.Remove(sql.LastIndexOf("and"));
                            sql += " ) ";
                        }
                        sql += " " + item.WhereField + " = N'" + item.WhereValue + "' or";
                    }
                    lastWhere = item.WhereField;
                }
                sql = sql.Remove(sql.LastIndexOf(" ")) + ")";
                //    Dialog.ShowNotification(sql);
            }
            else
                sql = "1 = 1";
            ReportFilter reportFilter = new ReportFilter()
            {
                ReportTitle = txtReportTitle.Text.Trim(),
                EmployeeCode = decimal.Parse("0" + hdfChonCanBo.Text),
                Note = htmlNote.Value.ToString(),
                WhereClause = sql,
                Reporter = GetReporter(Session["MaDonVi"].ToString()),
                Gender = cbGender.SelectedItem.Value,
                SelectedDepartment = hdfMaDonViList.Text,
                SessionDepartment = Session["MaDonVi"].ToString(),
                StartMonth = ReportController.GetInstance().GetStartMonth(cbMonth.SelectedItem.Value),
                EndMonth = ReportController.GetInstance().GetEndMonth(cbMonth.SelectedItem.Value),
                MinSeniority = minSeniority,
                MaxSeniority = maxSeniority,
                MinAge = minAge,
                MaxAge = maxAge,
                Title1 = txttieudechuky1.Text,
                Title2 = txttieudechuky2.Text,
                Title3 = txttieudechuky3.Text,
                Name1 = txtnguoiky1.Text,
                Name2 = txtnguoiky2.Text,
                Name3 = txtnguoiky3.Text,
                ReportedDate = dfReportDate.SelectedDate,
                MaSoThue = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_MASOTHUE, Session["MaDonVi"].ToString()),
                CompanyAddress = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_ADDRESS, Session["MaDonVi"].ToString()),
                CompanyPhone = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_DIENTHOAI, Session["MaDonVi"].ToString()),
                CompanyFax = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_FAX, Session["MaDonVi"].ToString()),
                CompanyName = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_NAME, Session["MaDonVi"].ToString()),
                CompanyEmail = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_EMAIL, Session["MaDonVi"].ToString())
            };
            DataTable tbl = DataController.DataHandler.GetInstance().ExecuteDataTable("HOSO_GetHoSoInfo", "@Prkey", reportFilter.EmployeeCode);
            if (tbl.Rows.Count > 0)
            {
                reportFilter.MaCanBo = tbl.Rows[0]["MA_CB"].ToString();
            }
            // đánh giá
            if (cbxDotDanhGia.SelectedItem.Value != null)
            {
                reportFilter.MaDotDanhGia = cbxDotDanhGia.SelectedItem.Value;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(dfStartDate.SelectedDate))
            {
                reportFilter.StartDate = dfStartDate.SelectedDate;
            }
            if (!SoftCore.Util.GetInstance().IsDateNull(dfEndDate.SelectedDate))
            {
                reportFilter.EndDate = dfEndDate.SelectedDate;
            }
            if (string.IsNullOrEmpty(spfyear.Text))
            {
                reportFilter.Year = DateTime.Now.Year;
            }
            else
            {
                reportFilter.Year = int.Parse(spfyear.Text);
            }
            if (string.IsNullOrEmpty(reportFilter.Gender))
            {
                reportFilter.Gender = "";
            }
            if (string.IsNullOrEmpty(cbWorkingStatus.SelectedItem.Value))
            {
                reportFilter.WorkingStatus = -1;
            }
            else
            {
                reportFilter.WorkingStatus = int.Parse(cbWorkingStatus.SelectedItem.Value);
            }

            Session["rp"] = reportFilter;
            string s = Util.GetInstance().RemoveSpaceAndVietnamese(hdfTitle.Text);
            RM.RegisterClientScriptBlock("addTabReport", string.Format("addTabReport(pnTabReport,hdfReportID.getValue(),'BaoCao_Main.aspx?type={0}',hdfTitle.getValue());", s.Replace(",", "")));
            RM.RegisterClientScriptBlock("RemoveAndAddNewTab", "RemoveAndAddNewTab('" + hdfReportID.Text + "')");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    private string GetReporter(string maDonVi)
    {
        string name = CurrentUser.DisplayName;
        string a = new HeThongController().GetValueByName(SystemConfigParameter.SuDungTenDangNhap, maDonVi);
        bool isDangNhap = false;
        if (!string.IsNullOrEmpty(a))
        {
            isDangNhap = bool.Parse(a);
        }
        if (isDangNhap == false)
            name = new HeThongController().GetValueByName(SystemConfigParameter.chuky1, maDonVi);
        return name;
    }

    protected void storeFilterTable_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            storeFilterTable.DataSource = new ReportTableFilterController().GetTableFilter(int.Parse("0" + hdfReportID.Text));
            storeFilterTable.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void storeFilterValues_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(cbChooseFilterTable.SelectedItem.Value))
            {
                storeFilterValues.DataSource = new DataTable();
            }
            else
                storeFilterValues.DataSource = DataHandler.GetInstance().ExecuteDataTable("report_GetTableFilter", "@ID", cbChooseFilterTable.SelectedItem.Value);// new ReportTableFilterController().GetTableFilter(int.Parse("0" + hdfReportID.Text));
            storeFilterValues.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion
}