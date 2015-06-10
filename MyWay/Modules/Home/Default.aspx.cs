using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Utilities;
using ExtMessage;
using System.Xml.Linq;
using System.IO;
using SoftCore.Security;
using SoftCore.AccessHistory;
using SoftCore;
using DAL;
using DataController;
using System.Data;

public partial class Modules_Home_Default : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfCurrentUserID.Text = CurrentUser.ID.ToString();
            // chon nam 
            cbxChonNamStore.DataSource = getYear(Session["MaDonVi"].ToString());
            cbxChonNamStore.DataBind();


            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            SetChartDefault();
            try
            {
                string[] tmp = Session["DataHomePage"].ToString().Split(';');
                if (int.Parse(tmp[0]) > 0)
                {
                    pnlSinhNhatNhanVien.Title += " <span style='color:red;'>(" + tmp[0] + " " + GlobalResourceManager.GetInstance().GetDesktopValue("staff") + ")</span>";
                }
                if (int.Parse(tmp[1]) > 0)
                {
                    pnlNhanVienSapHetHopDong.Title += " <span style='color:red;'>(" + tmp[1] + " " + GlobalResourceManager.GetInstance().GetDesktopValue("staff") + ")</span>";
                }
            }
            catch (Exception ex)
            {
                X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetDesktopValue("warning"), ex.Message).Show();
            }
            SetVisibleByRole();
            LoadDonVi();
        }
    }

    private void LoadDonVi()
    {
        try
        {
            List<StoreComboObject> dvList = new DM_DONVIController().GetStoreByParentID(Session["MaDonVi"].ToString());
            Ext.Net.TreeNode root = new Ext.Net.TreeNode();

            DAL.DM_DONVI dv = new DM_DONVIController().GetById(Session["MaDonVi"].ToString());
            Ext.Net.TreeNode parent = new Ext.Net.TreeNode(dv.TEN_DONVI);
            parent.Icon = Ext.Net.Icon.House;
            root.Nodes.Add(parent);
            parent.Expanded = true;
            parent.NodeID = dv.MA_DONVI;
            parent.Checked = ThreeStateBool.False;
            hdfAllNodeID.Text += dv.MA_DONVI + ",";

            foreach (var item in dvList)
            {
                string actionNode = string.Empty;
                Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.TEN);
                node.Icon = Ext.Net.Icon.House;
                parent.Nodes.Add(node);
                node.Expanded = true;
                node.NodeID = item.MA;
                node.Checked = ThreeStateBool.False;
                hdfAllNodeID.Text += item.MA + ",";
                actionNode += LoadChildDepartment(item.MA, node);
                //if (actionNode != "")
                //{
                //    node.Listeners.CheckChange.Handler = "ucDanhGia1_trp_bophan.getNodeById('" + actionNode.Remove(actionNode.LastIndexOf(',')).Trim().Replace(",", "').getUI().checkbox.checked = (ucDanhGia1_trp_bophan.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);ucDanhGia1_trp_bophan.getNodeById('") + "').getUI().checkbox.checked = (ucDanhGia1_trp_bophan.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);";
                //}
            }
            trp_bophan.Listeners.CheckChange.Handler = "this.dropDownField.setValue(getTasks(this), false);";
            //X.Msg.Alert("Thông báo", hdfAllNodeID.Text.Length).Show();
            trp_bophan.Root.Clear();
            trp_bophan.Root.Add(root);
        }
        catch
        { }
    }

    private string LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    {
        List<StoreComboObject> childList = new DM_DONVIController().GetStoreByParentID(maDonVi);
        string dsChild = "";
        foreach (var dv in childList)
        {
            string tmp = "";
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN);
            node.Icon = Ext.Net.Icon.Folder;
            DvNode.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA;
            node.Checked = ThreeStateBool.False;
            hdfAllNodeID.Text += dv.MA + ",";
            tmp += LoadChildDepartment(dv.MA, node);
            tmp += dv.MA + ",";
            dsChild += tmp;
        }
        return dsChild;
    }

    [DirectMethod]
    public void showWindowMoRong()
    {
        string str_get = hdfChartUrl.Text + "&height=460&size=260";
        wdMoRong.AutoLoad.Url = str_get;
        wdMoRong.AutoLoad.Mode = LoadMode.IFrame;
        wdMoRong.Render(this.Form);
        wdMoRong.Show();
    }

    /// <summary>
    /// Thiết lập hiển thị dựa trên quyền
    /// </summary>
    private void SetVisibleByRole()
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("role_roleOfDesktop", "@StartmenuID", "@EndmenuID", "@UserID", 5000, 5999, CurrentUser.ID);
        foreach (DataRow item in table.Rows)
        {
            switch (item[0].ToString())
            {
                case "5001":
                    Toolbar1.Visible = true;
                    pnlChart.Visible = true;
                    lblIframe.Visible = true;
                    break;
                case "5002":
                    btnChonLoaiBieuDo.Visible = true;
                    break;
                case "5003": //bieu do gioi tinh
                    MenuItem1.Visible = true;
                    break;
                case "5004": //Biểu đồ trình độ 
                    mnuTrinhDoChart.Visible = true;
                    break;
                case "5005"://Biểu đồ biến động nhân sự
                    MenuItem3.Visible = true;
                    break;
                case "5006"://Biểu đồ độ tuổi
                    MenuItem4.Visible = true;
                    break;
                case "5007"://Thống kê nhân sự theo đơn vị 
                    MenuItem5.Visible = true;
                    break;
                case "5008"://Biểu đồ quốc tịch 
                    MenuItem6.Visible = true;
                    break;
                case "5009"://Thống kê theo tình trạng hôn nhân 
                    MenuItem8.Visible = true;
                    break;
                case "5010"://Biểu đồ tôn giáo 
                    MenuItem9.Visible = true;
                    break;
                case "5011"://Biểu đồ dân tộc 
                    MenuItem10.Visible = true;
                    break;
                case "5012"://Biểu đồ loại hợp đồng 
                    MenuItem11.Visible = true;
                    break;
                case "5026": //Thống kê nhân sự theo phòng ban
                    mnuThongKeNhanSuTheoPhongBan.Visible = true;
                    break;
                case "5027": //Thống kê theo thâm niên công tác
                    menuThongKeNhanSuTheoThamNienCongTac.Visible = true;
                    break;
                case "5028": //Biểu đồ tỉnh thành
                    mnuBieuDoTinhThanh.Visible = true;
                    break;
                case "5029"://Biểu đồ chức vụ đoàn
                    mnuBieuDoChucVuDoan.Visible = true;
                    break;
                case "5030": //Biểu đồ chức vụ đảng
                    mnuBieuDoChucVuDang.Visible = true;
                    break;
                case "5031"://Biểu đồ chức vụ quân đội
                    mnuBieuDoChucVuQuanDoi.Visible = true;
                    break;
                case "5013":
                    btnSetChartDefault.Visible = true;
                    break;
                case "5015": //Tra cứu nhanh thông tin nhân viên
                    tbar.Visible = true;
                    GridPanel1.Visible = true;
                    Panel2.Visible = true;
                    break;
                case "5016":
                    btnBaoCaoChiTiet1NV.Visible = true;
                    MenuItem2.Visible = true;
                    break;
                case "5017":
                    btnSendEmail.Visible = true;
                    mnuGuiMail.Visible = true;
                    break;
                case "5018": //Sinh nhật nhân viên
                    pnlSinhNhatNhanVien.Visible = true;
                    Panel6.Visible = true;
                    break;
                case "5019": //In danh sách
                    tbReportDanhSach.Visible = true;
                    break;
                case "5021": //Nhân viên sắp hết hợp đồng
                    pnlNhanVienSapHetHopDong.Visible = true;
                    Panel6.Visible = true;
                    break;
                case "5022":
                    Toolbar2.Visible = true;
                    break;
                case "5040"://Thống kê lý do nghỉ việc
                    mnuLyDoNghiViec.Visible = true;
                    break;
            }
        }
    }

    protected void cbxChonNamStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            List<object> obj = getYear(maDV);
            cbxChonNamStore.DataSource = obj;
            cbxChonNamStore.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("thong_bao"), ex.Message.ToString()).Show();
        }
    }

    private List<object> getYear(string maDV)
    {
        List<Int32> lists = new ChartController().GetDanhSachNam(maDV);
        lists.Sort(new MyComparation());
        List<object> obj = new List<object>();
        if (!lists.Contains(DateTime.Now.Year))
        {
            obj.Add(new { ID = DateTime.Now.Year, Title = DateTime.Now.Year });
        }
        for (int i = 0; i < lists.Count; i++)
        {
            obj.Add(new { ID = lists[i], Title = lists[i] });
        }
        if (obj.Count == 0)
        {
            obj.Add(new { ID = -1, Title = GlobalResourceManager.GetInstance().GetLanguageValue("not_have_data") });
        }
        return obj;
    }

    protected void RM_DocumentReady(object sender, DirectEventArgs e)
    {
        try
        {
            int count = new TuCapNhatController().GetCount("ChuaDuyet", Session["MaDonVi"].ToString());
            if (count > 0)
            {
                pnlHoSoNhanSuCanDuyet.Title += string.Format("<span style='color:red'> ({0} " + GlobalResourceManager.GetInstance().GetDesktopValue("staff") + ")</span>", count);
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("error"), ex.Message).Show();
        }
    }

    /// <summary>
    /// Load biểu đồ mặc định của chương trình hoặc do người dùng thiết lập
    /// </summary>
    private void SetChartDefault()
    {
        if (new FileInfo(Server.MapPath("XMLConfig.xml")).Exists)
        {
            XDocument xDoc = XDocument.Load(Server.MapPath("XMLConfig.xml"));
            try
            {
                var UserSetDefault = (from t in xDoc.Descendants("Chart")
                                      where t.Attribute("userid").Value == CurrentUser.ID.ToString()
                                      select t.Element("UserSetDefault"));
                if (UserSetDefault.Count() != 0)
                {
                    hdfChartUrl.Text = UserSetDefault.FirstOrDefault().Value;
                    if (UserSetDefault.FirstOrDefault().Value.IndexOf("BDNhanSu") >= 0)
                    {
                        cbxChonNam.Hidden = false;
                        tbsChonNam.Hidden = false;
                    }
                    lblIframe.Html = string.Format("<iframe height='400' frameborder='0' id='iframeChart' width='100%' src='{0}' />", UserSetDefault.FirstOrDefault().Value);
                }
                else
                {
                    lblIframe.Html = "<iframe height='400' frameborder='0' id='iframeChart' width='100%' src='chart/ColumnChart.aspx?type=NSDonVi' />";
                }
            }
            catch (Exception ex)
            {
                X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("thong_bao"), ex.Message).Show();
            }
        }
    }

    protected void btnSetChartDefault_Click(object sender, DirectEventArgs e)
    {
        if (!string.IsNullOrEmpty(hdfChartUrl.Text))
        {
            XDocument xDoc = XDocument.Load(Server.MapPath("XMLConfig.xml"));
            var linkChart = (from t in xDoc.Descendants("Chart")
                             where t.Attribute("userid").Value == CurrentUser.ID.ToString()
                             select t.Element("UserSetDefault"));
            if (linkChart.Count() != 0)
            {
                linkChart.FirstOrDefault().Value = hdfChartUrl.Text;
                xDoc.Save(Server.MapPath("XMLConfig.xml"));
            }
            else //Tạo mới
            {
                XElement column = new XElement("Chart",
                                      new XElement("UserSetDefault", hdfChartUrl.Text));
                column.SetAttributeValue("userid", CurrentUser.ID);
                xDoc.Root.Add(column);
                xDoc.Save(Server.MapPath("XMLConfig.xml"));
            }

            //Ghi log cho việc thay đổi chart mặc định
            string chartName = string.Empty;
            if (hdfChartUrl.Text.Contains("Country"))
            {
                chartName = "Biểu đồ quốc tịch";
            }
            else
                chartName = hdfChartUrl.Text;
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = "Thay đổi chart mặc định",
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
                MOTA = "Biểu đồ : " + chartName,
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
    }

    protected void btnSendEmail_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string mailto = e.ExtraParams["Email"];
            if (string.IsNullOrEmpty(mailto))
            {
                X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), GlobalResourceManager.GetInstance().GetDesktopValue("email_not_found")).Show();
                return;
            }
            HeThongController htController = new HeThongController();
            SendMail1.SetEmailTo(htController.GetValueByName(SystemConfigParameter.EMAIL, Session["MaDonVi"].ToString()), htController.GetValueByName(SystemConfigParameter.PASSWORD_EMAIL, Session["MaDonVi"].ToString()), mailto);
            SendMail1.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Cảnh báo", ex.Message).Show();
        }
    }

    protected void btn_SentEmail_HappyBirthDay_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SelectedRowCollection selecteds = RowSelectionModel3.SelectedRows;
            string mailto = string.Empty;
            string error = "";
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetAllEmailHappyBirthDayMonth");
            if (e.ExtraParams["All"] == "True")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Email"].ToString()))
                    {
                        mailto += dt.Rows[i]["Email"].ToString() + ", ";
                    }
                    else if (!string.IsNullOrEmpty(dt.Rows[i]["EMAIL_RIENG"].ToString()))
                    {
                        mailto += dt.Rows[i]["EMAIL_RIENG"].ToString() + ", ";
                    }
                    else
                    {
                        error += dt.Rows[i]["HO_TEN2"].ToString() + " ";
                    }
                }
            }
            else
            {
                foreach (var item in selecteds)
                {
                    string ma_CB = item.RecordID;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Ma_CB"].ToString() == ma_CB)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[i]["Email"].ToString()))
                            {
                                mailto += dt.Rows[i]["Email"].ToString() + ", ";
                            }
                            else if (!string.IsNullOrEmpty(dt.Rows[i]["EMAIL_RIENG"].ToString()))
                            {
                                mailto += dt.Rows[i]["EMAIL_RIENG"].ToString() + ", ";
                            }
                            else
                            {
                                Dialog.ShowError(GlobalResourceManager.GetInstance().GetDesktopValue("email_not_found"));
                                return;
                            }
                        }
                    }
                }
            }
            string mail = "";
            for (int i = 0; i < mailto.Length - 2; i++)
            {
                mail += mailto[i];
            }
            HeThongController htController = new HeThongController();
            SendMail1.SetEmailTo(htController.GetValueByName(SystemConfigParameter.EMAIL, Session["MaDonVi"].ToString()), htController.GetValueByName(SystemConfigParameter.PASSWORD_EMAIL, Session["MaDonVi"].ToString()), mail);

            SendMail1.Show();
            if (!string.IsNullOrEmpty(error.Trim()))
            {
                Dialog.ShowError("Một số nhân viên không có email: " + error);
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    private class MyComparation : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return -1;
            if (x < y)
                return 1;
            return 0;
        }
    }
    protected void bt_click_nhanviensinhnhat(object sender, DirectEventArgs e)
    {
        try
        {
            RM.RegisterClientScriptBlock("fd", "addHomePage(#{TabPanel1},'Homepage','../Report/BaoCao_Main.aspx?type=sntrongthang', 'Báo cáo danh sách nhân viên sinh nhật trong tháng');");
            ReportFilter RP = new ReportFilter(); 
            RP.StartMonth = DateTime.Now.Month; 
            RP.SessionDepartment = Session["MaDonVi"].ToString();
            RP.WhereClause = "1=1";
            RP.MaxSeniority = 1000;
            RP.MinSeniority = 0;
            RP.WorkingStatus = 0;
            RP.SelectedDepartment = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, DepartmentRoleController.MENUID_BIRTHDAY); //String.Join(",", new DM_DONVIController().getChildID(Session["MaDonVi"].ToString(), true).ToArray());
            RP.Reporter = CurrentUser.DisplayName;
            Session.Add("rp", RP);
            Window1.Title = "Báo cáo sinh nhật nhân viên";
            Window1.Show();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void bt_click_nhanviensaphethopdong(object sender, DirectEventArgs e)
    {
        try
        {
            RM.RegisterClientScriptBlock("fd", "addHomePage(#{TabPanel1},'Homepage1','../Report/BaoCao_Main.aspx?type=BaoCaoDanhSachCanBoHetHanHopDongTrongThang', 'Báo cáo danh sách nhân viên sắp hết hợp đồng');");
            ReportFilter RP = new ReportFilter();
            RP.StartDate = DateTime.Now;
            RP.Reporter = CurrentUser.DisplayName;
            RP.EndDate = DateTime.Now.AddDays(30);
            RP.SessionDepartment = Session["MaDonVi"].ToString();
            RP.ReportedDate = DateTime.Now;
            RP.SelectedDepartment = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, DepartmentRoleController.MENUID_CONTRACT);
            //RP.WhereClause = " (datediff(DD,GETDATE(),NGAYKT_HDONG)>= 0 and datediff(DD,GETDATE(),NGAYKT_HDONG)<= 30) and (DA_NGHI <> 1 or ISNULL(DA_NGHI,0) = 0) and isnull(NGAYKT_HDONG,'0001-01-01')<>'0001-01-01' AND dbo.fn_CheckKyKetHopDong(PR_KEY, 30) = 0";
            RP.WhereClause = "1=1";
            RP.MaxSeniority = 1000;
            RP.MinSeniority = 0;
            RP.StartMonth = 0;
            RP.Year = 0;
            RP.WorkingStatus = 0;
            RP.ReportTitle = "DANH SÁCH NHÂN VIÊN SẮP HẾT HẠN HỢP ĐỒNG";
            Session.Add("rp", RP);
            Window1.Title = "Danh sách cán bộ nhân viên sắp hết hạn hợp đồng";
            Window1.Show(); 
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        } 
    }

}