using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DAL;
using SoftCore.Security;
using Controller.ChamCongDoanhNghiep;
using DataController;
using ExtMessage;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class Modules_ChamCongDoanhNghiep_ThietLapCaChoNhanVien : WebBase
{
    private static Dictionary<string, int> dictionaryDay = new Dictionary<string, int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfUserID.SetValue(CurrentUser.ID);
            hdfMenuID.SetValue(MenuID);
            SetEditor();
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            hdfIDBangPhanCa.Text = Request.QueryString["bpcID"];
            spnYear.SetValue(DateTime.Now.Year);
            cbxMonth.SetValue(0);
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
            //LoadDonVi();
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(hdfIDBangPhanCa.Text))
                {
                    FindDayOfWeek(); 
                }
            }
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }
    #region xuất dữ liệu ra Excel
    /// <summary>
    /// Xuất bảng lương
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportExcel_Click(object sender, DirectEventArgs e)
    {
        string s = "";
        try
        {
            DAL.DanhSachBangPhanCa d = new DanhSachBangPhanCaController().GetByID(int.Parse(hdfIDBangPhanCa.Text));
            string sql = "SELECT ROW_NUMBER() OVER(ORDER BY h.TEN_CB, h.HO_TEN ASC) STT, '''' + bpct.MaCB as N'Mã cán bộ', h.HO_TEN AS N'Họ tên',dd.TEN_DONVI AS N'Bộ phận', ";
            int totalDay = DateTime.DaysInMonth(d.Nam, d.Thang);//tổng số ngày trong tháng 
            for (int i = 1; i < totalDay; i++)
            {
                sql += "ISNULL(bpct.Ngay" + (i < 10 ? "0" + i.ToString() : i.ToString()) + ",'') AS N'Ngày " + i.ToString() + " (" + GetDayOfWeek(i, d.Thang, d.Nam) + ")', ";
            }
            sql += "bpct.Ngay" + (totalDay < 10 ? "0" + totalDay.ToString() : totalDay.ToString()) + " AS N'Ngày " + totalDay.ToString() + " (" + GetDayOfWeek(totalDay, d.Thang, d.Nam) + ")'";
            sql += " FROM   ChamCong.BangPhanCaThang AS bpct JOIN HOSO  AS h ON  bpct.MaCB = h.MA_CB JOIN DM_DONVI AS dd ON dd.MA_DONVI = h.MA_DONVI "
                + " WHERE  bpct.MaDanhSachBangPhanCa = " + hdfIDBangPhanCa.Text + " AND (h.HO_TEN LIKE  N'" + SoftCore.Util.GetInstance().GetKeyword(txtSearchKey.Text) + "' "
                + " OR h.MA_CB LIKE N'" + SoftCore.Util.GetInstance().GetKeyword(txtSearchKey.Text) + "' OR LEN('" + SoftCore.Util.GetInstance().GetKeyword(txtSearchKey.Text) + "') = 0) "
                + " AND(LEN('" + hdfMaDonVi.Text + "') = 0 OR dd.MA_DONVI IN (SELECT * FROM   dbo.f_GetDanhSachMaDonVi('" + hdfMaDonVi.Text + "') fgdsmdv) OR dd.MA_DONVI IN (SELECT fd.MA_DONVI FROM f_GetDanhSachBoPhan(" + hdfUserID.Text + "," + hdfMenuID.Text + ") fd))";
            //Create Tempory Table
            s = sql;
            DataTable dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable(sql);


            ExportToExcel("BangPhanCaThang" + d.Thang + "Nam" + d.Nam + "_BoPhan" + d.DonViSuDung.Replace(",", "+") + ".xls", dtTemp, d.TenBangPhanCa);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public string GetDayOfWeek(int day, int month, int year)
    {
        string dayOfWeek = "";
        DateTime date = new DateTime(year, month, day);
        switch (date.DayOfWeek.ToString())
        {
            case "Monday":
                dayOfWeek = "T2";
                day = 0;
                break;
            case "Tuesday":
                dayOfWeek = "T3";
                day = 1;
                break;
            case "Wednesday":
                dayOfWeek = "T4";
                day = 2;
                break;
            case "Thursday":
                dayOfWeek = "T5";
                day = 3;
                break;
            case "Friday":
                dayOfWeek = "T6";
                day = 4;
                break;
            case "Saturday":
                dayOfWeek = "T7";
                day = 5;
                break;
            case "Sunday":
                dayOfWeek = "CN";
                day = 6;
                break;
        }
        return dayOfWeek;
    }
    public void ExportToExcel(string fileName, DataTable table, string title)
    {
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        Response.AddHeader("Content-Disposition", "Attachment; Filename=" + fileName);
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        try
        {
            StringBuilder sb = new StringBuilder();
            //Tạo dòng tiêu để cho bảng tính
            sb.Append(title);
            Response.Write(sb.ToString() + "\n\n");
            Response.Flush();
            sb = new StringBuilder();
            for (int count = 0; count < table.Columns.Count; count++)
            {
                if (table.Columns[count].ColumnName != null)
                    sb.Append(table.Columns[count].ColumnName);
                if (count < table.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi 
            int soDem = 0;
            while (table.Rows.Count >= soDem + 1)
            {
                sb = new StringBuilder();


                for (int col = 0; col < table.Columns.Count - 1; col++)
                {
                    if (table.Rows[soDem][col] != null)
                        sb.Append(table.Rows[soDem][col].ToString().Replace(",", " "));
                    sb.Append("\t");
                }
                if (table.Rows[soDem][table.Columns.Count - 1] != null)
                    sb.Append(table.Rows[soDem][table.Columns.Count - 1].ToString().Replace(",", " "));


                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                soDem = soDem + 1;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        table.Dispose();
        Response.End();
    }
    #endregion
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {

        try
        {
            BangPhanCaThangController controller = new BangPhanCaThangController();
            int count = 0;
            if (hdfIDBangPhanCa.Text != "")
            {
                foreach (var item in ucChooseEmployee1.SelectedRow)
                {

                    try
                    {
                        DAL.BangPhanCaThang obj = new BangPhanCaThang()
                                {
                                    CreatedBy = CurrentUser.ID,
                                    CreatedDate = DateTime.Now,
                                    MaCB = item.RecordID,
                                    MaDanhSachBangPhanCa = int.Parse(hdfIDBangPhanCa.Text),
                                };
                        controller.Add(obj);
                    }
                    catch (SqlException sql)
                    {
                        if (sql.ToString().Contains("UNIQUE"))
                        {
                            count++;
                            continue;
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
                grpDanhSachBangPhanCaThang.Reload();
                if (count > 0)
                {
                    Dialog.ShowError("Nhân viên đã có trong danh sách bảng phân ca sẽ không được thêm. Các nhân viên khác thêm thành công.");
                }
            }
            else Dialog.ShowError("Bạn chưa chọn bảng phân ca tháng");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<BangChamCongThangInfo> bangchamcongthang = e.DataHandler.ObjectData<BangChamCongThangInfo>();
        foreach (BangChamCongThangInfo update in bangchamcongthang.Updated)
        {

        }
    }
    #region Load đơn vị
    string[] dsDv;
    int countRole = -1;
    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        dsDv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            if (dsDv.Contains(info.MA))
                obj.Add(new { MA = info.MA, TEN = info.TEN });
            else
            {
                obj.Add(new { MA = countRole.ToString(), TEN = info.TEN });
                countRole--;
            }
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        cbx_bophan_Store.DataSource = obj;
        cbx_bophan_Store.DataBind();
    }

    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "--";
            if (dsDv.Contains(item.MA))
                obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            else
            {
                obj.Add(new { MA = countRole.ToString(), TEN = tmp + item.TEN });
                countRole--;
            }
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }
    #endregion
    #region Các thao tác liên quan tới Grid
    private void SetEditor()
    {
        foreach (var col in grpDanhSachBangPhanCaThang.ColumnModel.Columns)
        {
            //     Ext.Net.MultiCombo cbWorkingStatus = new MultiCombo();
            Ext.Net.ComboBox cbWorkingStatus = new ComboBox();
            cbWorkingStatus.StoreID = "Store2";
            cbWorkingStatus.AnchorHorizontal = "100%";
            cbWorkingStatus.ListWidth = 250;
            cbWorkingStatus.ID = "cb" + col.ColumnID;
            //cbWorkingStatus.TypeAhead = true;
            //cbWorkingStatus.ForceSelection = true;
            //    cbWorkingStatus.SelectionMode = MultiSelectMode.Selection;
            cbWorkingStatus.DisplayField = "TenCa";
            cbWorkingStatus.ValueField = "MaCa";
            cbWorkingStatus.Editable = true;
            //cbWorkingStatus.Mode = DataLoadMode.Local;
            Ext.Net.FieldTrigger tg = new FieldTrigger();
            tg.Icon = TriggerIcon.Clear;
            tg.HideTrigger = true;
            cbWorkingStatus.Triggers.Add(tg);
            cbWorkingStatus.Listeners.Select.Handler = "this.triggers[0].show();";
            cbWorkingStatus.Listeners.TriggerClick.Handler = "if (index == 0) { this.clearValue(); this.triggers[0].hide(); }";
            cbWorkingStatus.MinChars = 1;
            cbWorkingStatus.PageSize = 15;
            cbWorkingStatus.ItemSelector = "tr.list-item";
            cbWorkingStatus.Template.Html = @"
                                            <tpl for=""."">
						                        <tpl if=""[xindex] == 1"">
							                        <table class=""cbStates-list"">
								                        <tr>
									                        <th>Mã ca</th>
									                        <th>Tên ca</th>
								                        </tr>
						                        </tpl>
						                        <tr class=""list-item"">
							                        <td style=""padding:3px 0px;"">{MaCa}</td>
							                        <td>{TenCa} ({GioVao} đến {GioRa})</td>
						                        </tr>
						                        <tpl if=""[xcount-xindex]==0"">
							                        </table>
						                        </tpl>
					                        </tpl>
                                            ";

            if (col.ColumnID.StartsWith("Ngay"))
            {
                col.Editor.Add(cbWorkingStatus);
                // col.DataIndex = "MaCa";
            }
        }
    }
    #endregion
    protected void btnChonBangPhanCa_Click(object sender, DirectEventArgs e)
    {
        if (hdfIDBangPhanCa.Text == hdfChosseBangPhanCa.Text)
        {
            wdChonBangPhanCa.Hide();
            return;
        }
        hdfIDBangPhanCa.Text = hdfChosseBangPhanCa.Text;
        Response.Redirect("DangKyCaTrongThang.aspx?mid=" + MenuID + "&bpcID=" + hdfIDBangPhanCa.Text);
        //FindDayOfWeek();
        //wdChonBangChamCong.Hide();  
    }
    /// <summary>
    /// Thiết lập giá trị cho các control trên form wdChamCongTheoKhoangThoiGian
    /// </summary>
    /// <param name="bangChamCong"></param>
    private void setDateForwdChamCongTheoKhoangThoiGian(DAL.DanhSachBangPhanCa bangChamCong)
    {
        int totalDayDayInMonth = DateTime.DaysInMonth(bangChamCong.Nam, bangChamCong.Thang);
        DateTime startDate = new DateTime(bangChamCong.Nam, bangChamCong.Thang, 1);
        DateTime endDate = new DateTime(bangChamCong.Nam, bangChamCong.Thang, totalDayDayInMonth);
        FromDate.SelectedDate = startDate;
        FromDate.MinDate = startDate;
        FromDate.MaxDate = endDate;
        ToDate.MaxDate = endDate;
        ToDate.SelectedDate = endDate;
    }
    /// <summary>
    /// Tìm thứ trong tuần và tô màu ngày cuối tuần
    /// </summary> 
    private void FindDayOfWeek()
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangPhanCa.Text))
            {
                return;
            }
            DAL.DanhSachBangPhanCa bangPhanCa = new DanhSachBangPhanCaController().GetByID(int.Parse(hdfIDBangPhanCa.Text));
            setDateForwdChamCongTheoKhoangThoiGian(bangPhanCa);
            DateTime date = new DateTime(bangPhanCa.Nam, bangPhanCa.Thang, 1);
            grpDanhSachBangPhanCaThang.Title = bangPhanCa.TenBangPhanCa + " (Bảng phân ca tháng " + bangPhanCa.Thang + "/" + bangPhanCa.Nam + ")";
            int totalDay = DateTime.DaysInMonth(bangPhanCa.Nam, bangPhanCa.Thang);//tổng số ngày trong tháng 

            dictionaryDay = new Dictionary<string, int>();
            int day = 0;
            foreach (var col in grpDanhSachBangPhanCaThang.ColumnModel.Columns)
            {
                if (col.ColumnID.StartsWith("Ngay"))
                {
                    string DayOfWeek = "";
                    switch (date.DayOfWeek.ToString())
                    {
                        case "Monday":
                            DayOfWeek = " T2";
                            day = 0;
                            break;
                        case "Tuesday":
                            DayOfWeek = " T3";
                            day = 1;
                            break;
                        case "Wednesday":
                            DayOfWeek = " T4";
                            day = 2;
                            break;
                        case "Thursday":
                            DayOfWeek = " T5";
                            day = 3;
                            break;
                        case "Friday":
                            DayOfWeek = " T6";
                            day = 4;
                            break;
                        case "Saturday":
                            DayOfWeek = " T7";
                            day = 5;
                            break;
                        case "Sunday":
                            DayOfWeek = " CN";
                            day = 6;
                            break;
                    }
                    dictionaryDay.Add(col.DataIndex, day);
                    if (int.Parse(col.ColumnID.Replace("Ngay", "")) > totalDay)
                    {
                        col.Hidden = true;
                        continue;
                    }
                    if (DayOfWeek.Contains("CN"))
                    {
                        col.Css = "background:#D3D3D3;";
                    }
                    if (bangPhanCa.Nam == DateTime.Now.Year && bangPhanCa.Thang == DateTime.Now.Month && int.Parse(col.ColumnID.Replace("Ngay", "").ToString()) == DateTime.Now.Day)
                    {
                        col.Css = "background:#87ceeb;";
                    }
                    date = date.AddDays(1);
                    col.Header += " (" + DayOfWeek + ")";
                }
            }
            ////set weekend style + today style
            //if (bangChamCong.Thang != DateTime.Now.Month)
            //    styleWeekend += "{background-color:#e3e6eb;}.x-grid3-td-Ngay";
            //else
            //    styleWeekend += "{background-color:#e3e6eb;}.x-grid3-td-Ngay" + DateTime.Today.Day + "{background-color:#ff6600}";
            //ltrweekendStyle.Text = "<style type='text/css'>" + styleWeekend + "</style>";
            //   ltrweekendStyle.Text = "*{font-size:15px !important;}";
            //GridPanel1.Reload();
            //GridPanel1.Reconfigure();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("SetColorWeekend = " + ex.Message);
        }
    }
    #region Quản lý, tạo bảng phân ca
    protected void btnTaoBangPhanCaThang_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfMaDonVi.Text) || string.IsNullOrEmpty(spfYear.Text))
            {
                X.Msg.Alert("Thông báo", "Tạo bảng phân ca thất bại. Dữ liệu nhập vào không hợp lệ").Show();
                return;
            }
            string str = hdfStringMaDonVi.Text;
            string a = hdfStringAllMaDonVi.Text;
            hdfStringMaDonVi.Text = "";

            DAL.DanhSachBangPhanCa dsbc = new DanhSachBangPhanCa()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                MaDonVi = Session["MaDonVi"].ToString(),
                Nam = int.Parse(spfYear.Text),
                Thang = int.Parse(cbThang.SelectedItem.Value),
                DonViSuDung = str,
                Lock = false,
                TenBangPhanCa = txtTenBangPhanCa.Text,
            };
            int id = new DanhSachBangPhanCaController().Insert(dsbc);
            if (id > 0)
            {
                DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TaoBangPhanCaThang", "@IDBangPhanCa", "@donViSuDung", "@createdBy",
                                                        id, str, CurrentUser.ID);
                //int isLayTuThangTruoc = -1;
                //if (chkLayTuThangTruoc.Checked == true)
                //    isLayTuThangTruoc = 1;
                //new BangPhanCaThangController().TaoBangPhanCaThang(id, CurrentUser.ID, int.Parse(cbThang.SelectedItem.Value), int.Parse(spfYear.Text), str, isLayTuThangTruoc);
                //hdfIDBangPhanCa.Text = id.ToString();
                //grpDanhSachBangPhanCaThang.Title = DataController.DataHandler.GetInstance().ExecuteScalar("store_LayTenBangPhanCa", "@ID", id).ToString();
                //RM.RegisterClientScriptBlock("reloadgrid", "PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();");
                wdTaoBangPhanCa.Hide();
            }
            else
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Không tạo được bảng chấm công tháng").Show();
            }
            RM.RegisterClientScriptBlock("reloadgrid", "PagingToolbar2.pageIndex = 0;  PagingToolbar2.doLoad();");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo ", ex.Message).Show();
        }
    }
    protected void btnXoaBangPhanCa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SelectedRowCollection selectedRows = RowSelectionModelBangPhanCa.SelectedRows;
            foreach (var item in selectedRows)
            {
                new DanhSachBangPhanCaController().Delete(int.Parse("0" + item.RecordID));
            }
            grpDanhSachBangPhanCa.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    //    #region loadtree ddfDonVi
    //    private void LoadDonVi()
    //    {
    //        List<StoreComboObject> dvList = new DM_DONVIController().GetStoreByParentID(Session["MaDonVi"].ToString());
    //        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
    //        foreach (var item in dvList)
    //        {
    //            string actionNode = string.Empty;
    //            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.TEN);
    //            node.Icon = Ext.Net.Icon.House;
    //            root.Nodes.Add(node);
    //            node.Expanded = true;
    //            node.NodeID = item.MA;
    //            node.Checked = ThreeStateBool.False;
    //            hdfStringAllMaDonVi.Text += item.MA + ",";
    //            actionNode += LoadChildDepartment(item.MA, node);
    //            if (actionNode != "")
    //            {
    //                node.Listeners.CheckChange.Handler = "TreePanelDonVi.getNodeById('" + actionNode.Remove(actionNode.LastIndexOf(',')).Trim().Replace(",", "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);TreePanelDonVi.getNodeById('") + "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);";
    //            }
    //        }
    //        TreePanelDonVi.Listeners.CheckChange.Handler = @"#{ddfDonVi}.setValue(getTasks(this), false);
    //                                                         txtTenBangPhanCa.setValue('Bảng phân ca tháng ' + cbThang.getValue() +' năm '+ spfYear.getValue()+' tại ' + ddfDonVi.getText().replace('[', '').replace(']', ''));";
    //        TreePanelDonVi.Root.Clear();
    //        TreePanelDonVi.Root.Add(root);
    //    }

    //    private string LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    //    {
    //        List<StoreComboObject> childList = new DM_DONVIController().GetStoreByParentID(maDonVi);
    //        string dsChild = "";
    //        foreach (var dv in childList)
    //        {
    //            string tmp = "";
    //            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN);
    //            node.Icon = Ext.Net.Icon.Folder;
    //            DvNode.Nodes.Add(node);
    //            node.Expanded = true;
    //            node.NodeID = dv.MA;
    //            node.Checked = ThreeStateBool.False;
    //            hdfStringAllMaDonVi.Text += dv.MA + ",";
    //            tmp += LoadChildDepartment(dv.MA, node);
    //            if (tmp != "")
    //            {
    //                node.Listeners.CheckChange.Handler = "TreePanelDonVi.getNodeById('" + tmp.Remove(tmp.LastIndexOf(',')).Trim().Replace(",", "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + dv.MA + "').getUI().checkbox.checked == true ? true : false);TreePanelDonVi.getNodeById('") + "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + dv.MA + "').getUI().checkbox.checked == true ? true : false);";
    //            }
    //            tmp += dv.MA + ",";
    //            dsChild += tmp;
    //        }
    //        return dsChild;
    //    }
    //    #endregion

    [DirectMethod]
    public void SaveData(string sql)
    {
        try
        {
            DataHandler.GetInstance().ExecuteNonQuery(sql);
            RM.RegisterClientScriptBlock("clearSQL", "clearSQL();");
            Dialog.ShowNotification("Dữ liệu đã được tự động lưu thành công");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(e.ExtraParams["sqlQuery"]))
            {
                DataHandler.GetInstance().ExecuteNonQuery(e.ExtraParams["sqlQuery"]);
                RM.RegisterClientScriptBlock("clearSQL", "clearSQL();");
            }
            Dialog.ShowNotification("Cập nhật thành công");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void mnuLoaiBoNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BangPhanCaThangController controller = new BangPhanCaThangController();
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                controller.DeleteEmployee(int.Parse(item.RecordID));
            }
            mnuLoaiBoNhanVien.Disabled = true;
            grpDanhSachBangPhanCaThang.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnThietLapCaNhanh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (rdApplyforSelectedEmployee.Checked == true)
            {
                foreach (var item in RowSelectionModel1.SelectedRows)
                {
                    int fromDay = FromDate.SelectedDate.Day;
                    int toDay = ToDate.SelectedDate.Day;
                    for (int i = fromDay; i < toDay + 1; i++)
                    {
                        string field = "";
                        string value = "";
                        if (i < 10)
                            field = "NGAY0" + i;
                        else field = "NGAY" + i;

                        DateTime date = new DateTime(FromDate.SelectedDate.Year, FromDate.SelectedDate.Month, i);
                        if (chkSaturday.Checked && date.DayOfWeek.ToString() == "Saturday") //Nếu chọn thứ 7
                        {
                            value = MultiComboSaturday.SelectedItem.Value;
                        }
                        else if (chkSunday.Checked && date.DayOfWeek.ToString() == "Sunday") //Nếu chọn CN
                        {
                            value = MultiComboSunday.SelectedItem.Value;
                        }
                        else if (chkSaturday.Checked == false && date.DayOfWeek.ToString() == "Saturday") //Nếu ko chọn thứ 7
                        {
                            value = "";
                        }
                        else if (chkSunday.Checked == false && date.DayOfWeek.ToString() == "Sunday")//Nếu ko chọn CN
                        {
                            value = "";
                        }
                        else
                        {
                            value = cbTinhTrangLamViec.SelectedItem.Value;
                        }

                        new BangPhanCaThangController().Update(int.Parse(item.RecordID), field, value);

                    }
                }
                wdThietLapCaNhanh.Hide();
                grpDanhSachBangPhanCaThang.Reload();
            }
            else
                if (rdApplyforSelectedDepartment.Checked == true)
                {
                    int fromDay = FromDate.SelectedDate.Day;
                    int toDay = ToDate.SelectedDate.Day;
                    for (int i = fromDay; i < toDay + 1; i++)
                    {
                        string field = "";
                        string value = "";
                        if (i < 10)
                            field = "NGAY0" + i;
                        else field = "NGAY" + i;

                        DateTime date = new DateTime(FromDate.SelectedDate.Year, FromDate.SelectedDate.Month, i);
                        if (chkSaturday.Checked && date.DayOfWeek.ToString() == "Saturday") //Nếu chọn thứ 7
                        {
                            value = MultiComboSaturday.SelectedItem.Value;
                        }
                        else if (chkSunday.Checked && date.DayOfWeek.ToString() == "Sunday") //Nếu chọn CN
                        {
                            value = MultiComboSunday.SelectedItem.Value;
                        }
                        else if (chkSaturday.Checked == false && date.DayOfWeek.ToString() == "Saturday") //Nếu ko chọn thứ 7
                        {
                            value = "";
                        }
                        else if (chkSunday.Checked == false && date.DayOfWeek.ToString() == "Sunday")//Nếu ko chọn CN
                        {
                            value = "";
                        }
                        else
                        {
                            value = cbTinhTrangLamViec.SelectedItem.Value;
                        }
                        new BangPhanCaThangController().UpdateByPhongBan(hdfMaDonVi.Text, int.Parse("0" + hdfIDBangPhanCa.Text), field, value);
                    }
                    grpDanhSachBangPhanCaThang.Reload();
                    wdThietLapCaNhanh.Hide();
                }
                else Dialog.ShowError("Bạn chưa chọn đối tượng phân ca.");

        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    [DirectMethod(Namespace = "PhanCaTrongThang")]
    public void AfterEdit(string field, string oldValue, string newValue, int ID)
    {
        try
        {
            new BangPhanCaThangController().Update(ID, field, newValue);
            grpDanhSachBangPhanCaThangStore.CommitChanges();

        }
        catch (Exception ex) { Dialog.ShowError(ex.Message); }
    }
}