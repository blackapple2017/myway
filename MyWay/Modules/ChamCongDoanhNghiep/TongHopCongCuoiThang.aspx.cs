using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using LinqToExcel;
using System.Globalization;
using Controller.ChamCongDoanhNghiep;
using DAL;
using DataController;
using System.Data;
using SoftCore;
using System.Text;

public partial class Modules_ChamCongDoanhNghiep_TongHopCongCuoiThang : WebBase
{
    //private string loaiFileExcel = DieuKienChamCongController.EXCEL_FORMAT_NGANG;
    //private string phanCa = SystemConfigParameter.PHANCA_TYPE_THANG;
    //private static int idBangTongHopCong = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            cbxMonth.SetValue(DateTime.Now.Month);
            spnYear.SetValue(DateTime.Now.Year);
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            //txtYear.Text = DateTime.Now.Year.ToString();
            hdfUserID.SetValue(CurrentUser.ID);
            hdfMenuID.SetValue(MenuID);
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "'); grpTongHopCongStore.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
            
            //SetEditor();

            LoadRecordField();
            LoadColumnIntoGrid();
            GenerateGridColumn();
        }
    }
    #region
    [DirectMethod]
    public void LoadConfigTimeToDay()
    {
        try
        {
            var d = DataController.DataHandler.GetInstance().ExecuteDataTable("select dbo.f_ChamCong_GetConfigTimesToDay('StartTime') as 'StartTime', dbo.f_ChamCong_GetConfigTimesToDay('EndTime') as 'EndTime', dbo.f_ChamCong_GetConfigTimesToDay('Day1') as 'Day1', dbo.f_ChamCong_GetConfigTimesToDay('Day2') as 'Day2',dbo.f_ChamCong_GetConfigTimesToDay('CaGay') as 'CaGay'");
            if (d.Rows.Count > 0)
            {
                nbfStartTime.Text = d.Rows[0]["StartTime"].ToString();
                nbfEndTime.Text = d.Rows[0]["EndTime"].ToString();
                nbfStartTime2.Text = d.Rows[0]["EndTime"].ToString()+" trở lên";
                nbfDay1.Text = d.Rows[0]["Day1"].ToString();
                nbfDay2.Text = d.Rows[0]["Day2"].ToString();
                nbfCaGay.Text = d.Rows[0]["CaGay"].ToString();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateThamSoTrangThai", "@ParamName", "@Description", "@Value", "ConfigTimeToDay", "StartTime", nbfStartTime.Value);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateThamSoTrangThai", "@ParamName", "@Description", "@Value", "ConfigTimeToDay", "EndTime", nbfEndTime.Value);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateThamSoTrangThai", "@ParamName", "@Description", "@Value", "ConfigTimeToDay", "Day1", nbfDay1.Value);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateThamSoTrangThai", "@ParamName", "@Description", "@Value", "ConfigTimeToDay", "Day2", nbfDay2.Value);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateThamSoTrangThai", "@ParamName", "@Description", "@Value", "ConfigTimeToDay", "CaGay", nbfCaGay.Value);
            wdConfigTimesToDay.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion
    #region xuất dữ liệu ra Excel
    /// <summary>
    /// Xuất bảng lương
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportExcel_Click(object sender, DirectEventArgs e)
    {
        try
        {
            List<TimeSheetConfigInfo> d = new TimeSheetConfigController().GetAllTimeSheetConfigInfo();
            string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY h.HO_TEN ASC ) AS N'STT',
                            '''' + h.MA_CB as N'Mã CB', 
                            h.HO_TEN as N'Họ tên',
                            dd.TEN_DONVI as 'Bộ phận',
                            dd2.TEN_DIADIEM as N'Địa điểm làm việc',";
            for (int i = 0; i < d.Count - 1; i++)
            {
                sql += "thcct." + d[i].ColumnName + " as N'" + d[i].ColumnDescription + "', ";
            }
            sql += "thcct." + d[d.Count - 1].ColumnName + " as N'" + d[d.Count - 1].ColumnDescription + "' ";
            sql += @"FROM ChamCong.TongHopCongCuoiThang thcct
                    LEFT JOIN HOSO h ON thcct.PRKEYHOSO = h.PR_KEY
                    LEFT JOIN DM_DONVI dd ON h.MA_DONVI = dd.MA_DONVI
                    LEFT JOIN DM_DIADIEMLAMVIEC dd2 ON h.BI_DANH = dd2.MA_DIADIEM
                    WHERE (LEN(N'" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) + @"') = 0 OR h.MA_CB LIKE N'%'+ N'" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) + @"' +'%' OR h.HO_TEN LIKE N'%'+N'" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) + @"'+'%')
                        AND (MONTH(thcct.MonthYear) = " + cbxMonth.SelectedItem.Value + @" OR " + cbxMonth.SelectedItem.Value + @" = 0) AND YEAR(thcct.MonthYear) = " + spnYear.Value + @"
                        AND h.MA_DONVI IN ( SELECT MA_DONVI FROM dbo.f_GetDanhSachMaDonVi('" + hdfMaDonVi.Text + @"'))";
            //Create Tempory Table
            DataTable dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable(sql);


            ExportToExcel("BangTongHopCong" + (cbxMonth.SelectedItem.Value != "0" ? "Thang" + cbxMonth.SelectedItem.Value.ToString() : "Ca") + "Nam" + spnYear.Value.ToString() + ".xls", dtTemp, "Bảng tổng hợp chấm công" + (cbxMonth.SelectedItem.Value != "0" ? " tháng " + cbxMonth.SelectedItem.Value.ToString() : " cả ") + " năm " + spnYear.Value.ToString());
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
                dayOfWeek = " T2";
                day = 0;
                break;
            case "Tuesday":
                dayOfWeek = " T3";
                day = 1;
                break;
            case "Wednesday":
                dayOfWeek = " T4";
                day = 2;
                break;
            case "Thursday":
                dayOfWeek = " T5";
                day = 3;
                break;
            case "Friday":
                dayOfWeek = " T6";
                day = 4;
                break;
            case "Saturday":
                dayOfWeek = " T7";
                day = 5;
                break;
            case "Sunday":
                dayOfWeek = " CN";
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
                        sb.Append(table.Rows[soDem][col].ToString());
                    sb.Append("\t");
                }
                if (table.Rows[soDem][table.Columns.Count - 1] != null)
                    sb.Append(table.Rows[soDem][table.Columns.Count - 1].ToString());


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
    private Ext.Net.Column GetColumn(string header, string dataIndex, int width)
    {
        Column column = new Column()
        {
            ColumnID = dataIndex,
            Header = header,
            Width = width,
            DataIndex = dataIndex,
            Align = Alignment.Right,
        };
        return column;
    }
    private void GenerateGridColumn()
    {
        int max = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("LaySoLuotChamCongLonNhat").ToString());
        hdfMax.Text = max.ToString();
        var grid = grpChiTietChamCongMay;
        var store = grid.GetStore();
        var cm = grid.ColumnModel;
        for (int i = 0; i < max; i++)
        {
            int k = i + 1;
            // add to store
            store.Reader[0].Fields.Add("Lan" + k);
            cm.Columns.Insert(i + 1, GetColumn("Lần " + k, "Lan" + k, 60));
        }
        //SetEditor(max);
    }
    protected void cbSheetNameStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            UploadFile();
            string path = Server.MapPath("File/") + fUpload.FileName;
            FileInfo info = new FileInfo(path);
            if (info.Exists)
            {
                List<object> sheetData = new List<object>();
                IEnumerable<string> sheetname = ExcelEngine.GetInstance().GetAllSheetName(path);
                foreach (var item in sheetname)
                {
                    sheetData.Add(new { SheetName = item });
                }
                cbSheetNameStore.DataSource = sheetData;
                cbSheetNameStore.DataBind();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #region Đọc dữ liệu từ Excel
    int maChamCong = 2;
    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = fUpload.PostedFile;

            //if (file.ContentType != "application/vnd.ms-excel") //ko phải Excel 2003
            //{
            //    Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("NotExcel2003"));
            //    return;
            //}
            if (fUpload.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                string path = string.Empty;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("File"));
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath("File/") + fUpload.FileName;
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }
    protected void btnImport_Click(object sender, DirectEventArgs e)
    {
        try
        {
            VaoRaCaController controller = new VaoRaCaController();
            TongHopCongTheoNgayController ngayCtr = new TongHopCongTheoNgayController();
            int ngayChamCong = 6;
            int gioVao = 7;
            int gioRa = 8;
            int count = 0;
            int rowIndex = 0;
            string oldMaChamCong = string.Empty;
            string extension = System.IO.Path.GetExtension(fUpload.PostedFile.FileName).ToLower();
            if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
            {
                X.Msg.Alert("Thông báo", "File bạn chọn không phải Excel").Show();
                return;
            }
            string fileName = System.IO.Path.GetFileName(fUpload.PostedFile.FileName);
            string fileLocation = Server.MapPath("File") + "\\" + fileName;
            string error = "";
            List<Row> dataExcel = ExcelEngine.GetInstance().GetDataFromExcel(fileLocation, cbSheetName.SelectedItem.Value, 0);
            foreach (Row item in dataExcel)
            {
                try
                {
                    rowIndex++;
                    if (count > 20)
                        break;
                    // xóa dữ liệu cũ
                    if (chkXoa.Checked)
                    {
                        if (!string.IsNullOrEmpty(item[maChamCong].ToString().Trim())
                            && item[maChamCong].ToString().Trim() != oldMaChamCong)
                        {
                            if (!string.IsNullOrEmpty(item[ngayChamCong].ToString().Trim()))
                            {
                                DateTime time = DateTime.ParseExact(item[ngayChamCong].ToString().Trim(), "dd/MM/yyyy", null);
                                controller.DeleteByMaChamCongAndMonthYear(item[maChamCong].ToString().Trim(), time);
                                ngayCtr.DeleteByDay(time, item[maChamCong].ToString().Trim());
                                oldMaChamCong = item[maChamCong].ToString().Trim();
                            }
                        }
                    }
                    // nếu có dữ liệu
                    if (!string.IsNullOrEmpty(item[maChamCong].ToString().Trim()) && !string.IsNullOrEmpty(item[ngayChamCong].ToString().Trim())
                        && (!string.IsNullOrEmpty(item[gioVao].ToString().Trim()) || !string.IsNullOrEmpty(item[gioRa].ToString().Trim())))
                    {
                        count = 0;
                        DateTime time = DateTime.ParseExact(item[ngayChamCong].ToString().Trim(), "dd/MM/yyyy", null);
                        //if (chkXoa.Checked)
                        //{
                        //    controller.DeleteByMaChamCongAndMonthYear(item[maChamCong].ToString().Trim(), time);
                        //}
                        if (!string.IsNullOrEmpty(item[gioVao].ToString().Trim()))
                        {
                            InserVaoRaCa(item, gioVao, time);
                        }
                        if (!string.IsNullOrEmpty(item[gioRa].ToString().Trim()))
                        {
                            InserVaoRaCa(item, gioRa, time);
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    // error += item[maChamCong].ToString().Trim() + "-" + item[ngayChamCong].ToString().Trim() + "-" +
                    //   item[gioVao].ToString().Trim() + "-" + item[gioRa].ToString().Trim() + "<br/>";
                    //error += "Number : " + count + item[maChamCong].ToString() + rowIndex + ex.Message + ",";// ex.Message + "(" + count + ")";   
                }
            }
            if (string.IsNullOrEmpty(error))
            {
                Dialog.ShowNotification("Nhập dữ liệu từ Excel thành công");
            }
            else
            {
                Dialog.ShowError("Không đọc được dòng " + error.Remove(error.LastIndexOf(",")));
            }
            wdImportExcelFile.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
        finally
        {
            string fn = System.IO.Path.GetFileName(fUpload.PostedFile.FileName);
            string saveLocation = Server.MapPath("File") + "\\" + fn;
            FileInfo file = new FileInfo(saveLocation);
            if (file.Exists)
                file.Delete();
        }
    }

    private void InserVaoRaCa(LinqToExcel.Row row, int timeIndex, DateTime time)
    {
        VaoRaCaController controller = new VaoRaCaController();
        DAL.VaoRaCa vao = new VaoRaCa();
        vao.MaCa = "";
        vao.Order = 1;
        vao.MaChamCong = row[maChamCong].ToString().Trim();
        vao.Time = row[timeIndex].ToString().Trim();
        if (vao.Time.Length <= 5)
            vao.Time += ":00";
        string _time = string.Empty;
        if (int.Parse(vao.Time.Split(':')[0]) > 23)
        {
            _time = "23:59:00";
        }
        else
            _time = vao.Time;
        vao.NgayChamCong = DateTime.Parse(time.ToString("yyyy-MM-dd " + _time));
        vao.ID = vao.MaChamCong + vao.NgayChamCong.Day + vao.NgayChamCong.Month + vao.NgayChamCong.Year + vao.NgayChamCong.Hour +
                 vao.NgayChamCong.Minute + vao.NgayChamCong.Second;
        vao.DiVao = true;
        controller.InsertAndUpdate(vao);
    }
    #endregion
    protected void mnuTongHopDuocChon_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            SelectedRowCollection selecteds = RowSelectionModelTongHopCong.SelectedRows;
            string selectedId = string.Empty;
            foreach (var item in selecteds)
            {
                selectedId += item.RecordID + ",";
            }
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCongThang_ByViVi", "@Thang", "@Nam", "@SelectedId", "@MenuID", "@UserID", "@MaDonVi", thang, nam, selectedId, hdfMenuID.Text, hdfUserID.Text, hdfMaDonVi.Text);
            grpTongHopCong.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }
    protected void mnuTongHopTatCa_Click(object sender, DirectEventArgs e)
    {
        int thang = int.Parse(cbxMonth.SelectedItem.Value);
        int nam = int.Parse(spnYear.Text);
        // tổng hợp công cuối tháng
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCongThang_ByViVi", "@Thang", "@Nam", "@SelectedId", "@MenuID", "@UserID", "@MaDonVi", thang, nam, null, hdfMenuID.Text, hdfUserID.Text, hdfMaDonVi.Text);
        grpTongHopCong.Reload();
        try
        {
           
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }
    protected void mnuLayCongLamThemGio_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            // tổng hợp giờ làm thêm
            DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_TongHopLamThemGio", "@Thang", "@Nam", "@BoPhan", thang, nam, hdfMaDonVi.Text);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    private string GetNameDay(DateTime day, int sa)
    {
        string name = "";
        if (sa == 0)
            name = "Morning";
        else if (sa == 1)
            name = "Afternoon";
        switch (day.DayOfWeek)
        {
            case DayOfWeek.Friday:
                name = "Friday" + name;
                break;
            case DayOfWeek.Saturday:
                name = "Saturday" + name;
                break;
            case DayOfWeek.Sunday:
                name = "Sunday";
                break;
            default:
                name = "";
                break;
        }
        return name;
    }
    [DirectMethod]
    public void AfterEdit(int id, string field, string oldvalue, string newValue)
    {
        try
        {
            TongHopCongCuoiThangController controller = new TongHopCongCuoiThangController();
            controller.UpdateWhenAfterEdit(id, field, newValue);
            RM.RegisterClientScriptBlock("commitchange", "grpTongHopCongStore.commitChanges();");
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    protected void stConfigTimeSheets_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        DataTable data = new TimeSheetConfigController().getAll();
        stConfigTimeSheets.DataSource = data;
        stConfigTimeSheets.DataBind();
    }
    [DirectMethod]
    public void AfterEdit2(int id, string field, string oldValue, string newValue, TimeSheetConfigInfo oj)
    {
        try
        {
            TimeSheetConfigController sdc = new TimeSheetConfigController();
            sdc.Update(id, field, newValue, oj.ColumnName);
            this.grpConfigTimeSheets.Store.Primary.CommitChanges();
        }
        catch (Exception ex) { ExtMessage.Dialog.ShowError(ex.Message); }
    }
    private void LoadRecordField()
    {
        //RecordField r = new RecordField() { Name = "C1" };
        //stSalaryBoard.AddField(r);
        foreach (var item in new TimeSheetConfigController().GetTimeSheetColumnList())
        {
            RecordField r = new RecordField() { Name = item.ColumnID };
            grpTongHopCongStore.AddField(r);
        }
    }
    private void LoadColumnIntoGrid()
    {
        // create HeaderRow
        Ext.Net.HeaderRow row = new HeaderRow();
        foreach (var item in new TimeSheetConfigController().GetTimeSheetColumnList())
        {
            // set editor
            Ext.Net.TextField txtEditor = new TextField();
            txtEditor.MaskRe = "/[0-9.-]/";
            txtEditor.ID = "txtEditor_GG_" + item.ColumnID;
            item.Editor.Add(txtEditor);

            grpTongHopCong.ColumnModel.Columns.Add(item);

            #region Tạo GroupHeader
            //// create HeaderColumn
            //Ext.Net.HeaderColumn column = new HeaderColumn();
            //column.AutoWidthElement = false;
            //// tạo DisplayField để hiển thị
            //Ext.Net.DisplayField dpf = new DisplayField();
            //dpf.ID = "dpf_GG_" + item.ColumnID;
            //dpf.Text = "";
            //// add DisplayField to ColumnHeader
            //column.Component.Add(dpf);
            //row.Columns.Add(column);
            #endregion
        }
        lkv.HeaderRows.Add(row);
    }
}