using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using WebUI.Controller;
using WebUI.Entity;
using System.Data;
using ExtMessage;
using SoftCore;
using DataController;
using WebUI.BaseControl;
using WebUI.Interface;
using System.Xml;
using System.Xml.Xsl;
using SoftCore.AccessHistory;

public partial class Modules_Base_GridPanel : GridTable
{
    public event EventHandler RowSelect;
    public event EventHandler RowDoubleClick;
    public event EventHandler AfterEditOnGrid;
    public string RowClickListener { get; set; }
    public string RowSelection { get; set; }
    /// <summary>
    /// Đường dẫn trỏ tới file hướng dẫn
    /// </summary>
    public string HelpLink { get; set; }
    public bool IsPrimaryKeyAutoIncrement { get; set; }
    /// <summary>
    /// Điều kiện để lọc lấy ra dữ liệu, ví dụ như chỉ lấy dữ liệu thuộc một đơn vị của user đăng nhập vào thôi
    /// </summary>
    public string FilterAtRuntime { get; set; }
    /// <summary>
    /// Được sử dụng để biết được ngày tạo khi thực hiện nhân đôi bản ghi
    /// </summary>
    public string DateCreatedField { get; set; }
    /// <summary>
    /// Được sử dụng để biết được người tạo khi thực hiện nhân đôi bản ghi
    /// </summary>
    public string UserCreatedField { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest && string.IsNullOrEmpty(hdfFilterAtRuntime.Text))
        {
            hdfFilterAtRuntime.Text = FilterAtRuntime;
        }
        gridPanel = GridController.GetInstance().GetGridPanel(this.ID);
        if (gridPanel != null)
        {
            if (string.IsNullOrEmpty(TableName) && gridPanel != null)
            {
                if (string.IsNullOrEmpty(gridPanel.ViewName) == false)
                {
                    this.TableName = gridPanel.ViewName;
                }
                else
                {
                    this.TableName = gridPanel.TableName;
                }
            }
            else
            {
                this.TableName = defaultTable;
            }
            if (RowSelect != null)
            {
                RowSelectionModel1.DirectEvents.RowSelect.Event += new ComponentDirectEvent.DirectEventHandler(RowSelect_Event);
            }
            if (!X.IsAjaxRequest)
            {
                SetControlVisible();
            }
            //Nếu ko có ComboBox trên Grid thì cho sự kiện chuột trên GridPanel
            //chỗ này tối ưu lại
            if (GridController.GetInstance().GetColumnInfo(this.ID, TableName, 1).Where(p => p.AllowComboBoxOnGrid == true && string.IsNullOrEmpty(p.ComboBoxTable) == false).Count() == 0 && gridPanel.AllowEditOnGrid == false)
            {
                if (!String.IsNullOrEmpty(gridPanel.InformationPanel))
                {
                    RowSelectionModel1.DirectEvents.RowSelect.Event += new ComponentDirectEvent.DirectEventHandler(RowSelect_Event);
                    RowSelectionModel1.DirectEvents.RowSelect.EventMask.Msg = "Đang tải dữ liệu";
                    RowSelectionModel1.DirectEvents.RowSelect.EventMask.ShowMask = true;
                }
                else //Nếu ko hiện form chi tiết thì sẽ cho click chuột để sửa
                {
                    if (DisableEditWindow == false && btnEdit.Visible == true)
                    {
                        GridPanel1.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEdit_Click);
                        GridPanel1.Listeners.RowDblClick.Handler = hdfWhatForm.ClientID + ".setValue('Update');";
                        GridPanel1.DirectEvents.RowDblClick.EventMask.Msg = "Chờ trong giây lát";
                        GridPanel1.DirectEvents.RowDblClick.EventMask.ShowMask = true;
                    }
                }
            }
            else
            {
                //Nếu có Panel phụ thì sẽ có sự kiện click chuột để xem thông tin chi tiết(ko phải double click)
                if (!String.IsNullOrEmpty(gridPanel.InformationPanel))
                {
                    RowSelectionModel1.DirectEvents.RowSelect.Event += new ComponentDirectEvent.DirectEventHandler(RowSelect_Event);
                    RowSelectionModel1.DirectEvents.RowSelect.EventMask.Msg = "Đang tải dữ liệu";
                    RowSelectionModel1.DirectEvents.RowSelect.EventMask.ShowMask = true;
                }
            }
        }
        else
        {
            TableName = defaultTable;
        }
        AddDetailForm();
        SetupForm();

        if (!X.IsAjaxRequest)
        {
            ShowData();
            if (!string.IsNullOrEmpty(RowClickListener))
                GridPanel1.Listeners.RowClick.Handler = RowClickListener;
            if (!string.IsNullOrEmpty(RowSelection))
                RowSelectionModel1.Listeners.RowSelect.Handler += RowSelection;
            //if (CurrentUser.IsSuperUser == false)
            //{
            //    //       AddColumn();
            //}
            if (!string.IsNullOrEmpty(HelpLink))
            {
                btnHelp.Listeners.Click.Handler = string.Format("window.open('{0}','_blank')", HelpLink);
            }
        }
        //Nếu developr thì để addColumn ở ngoài, còn người bình thường sẽ cho vào X.IsAjax...
        // if (CurrentUser.IsSuperUser)
        // {
        AddColumn();
        // }

        if (CurrentUser.IsSuperUser)
        {
            if (plcConfig.Controls.Count == 0)
            {
                Modules_Base_GridPanel_Config_GridConfig ct = this.Page.LoadControl("../Base/GridPanel/Config/GridConfig.ascx") as Modules_Base_GridPanel_Config_GridConfig;
                ct.ID = this.ID + "ConfigControl";
                ct.TableName = this.TableName;
                ct.GridPanelName = this.ID;
                ct.ViewName = gridPanel.ViewName;
                ct.AfterClickUpdateInformation += new EventHandler(ct_AfterClickUpdateInformation);
                ct.AfterCreateNewColumn += new EventHandler(ct_AfterCreateNewColumn);
                plcConfig.Controls.Add(ct);
            }
            btnConfig.Hidden = false;

            GridPanel1.Listeners.ColumnResize.Handler = "#{DirectMethods}.SaveColumnWidth(ChangeColumnWidth(#{GridPanel1}));";
            GridPanel1.Listeners.ColumnMove.Handler = "#{DirectMethods}.SaveColumnOrder(ChangeColumnOrder(#{GridPanel1}));";
        }
    }
    /// <summary>
    /// sự kiện refresh lại trang sau khi cấu hình thông tin GridPanel xong
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ct_AfterClickUpdateInformation(object sender, EventArgs e)
    {
        RM.RegisterClientScriptBlock("ReloadPageAgain", "location.reload();");
    }
    /// <summary>
    /// Reload lại store sau khi thêm mới cột
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ct_AfterCreateNewColumn(object sender, EventArgs e)
    {
        RM.RegisterClientScriptBlock("reloadStoreColumnInfo", "#{StoreColumnInfo}.reload();");
    }
    /// <summary>
    /// add form thông tin phụ phía dưới GridPanel
    /// </summary>
    private void AddDetailForm()
    {
        if (gridPanel != null)
            if (!string.IsNullOrEmpty(gridPanel.InformationPanel))
            {
                Control ct = this.Page.LoadControl("../Base/Form/Form.ascx");
                ct.ID = "formDetail";
                Form frmDetail = ct as Form;
                frmDetail.FormType = Form.FormKind.Form;
                frmDetail.GridPanelName = this.ID;
                // frmDetail.CommandButton = Form.Command.update;
                //   frmDetail.AfterClickUpdateConfig += new EventHandler(formDetail_AfterClickUpdateConfig);
                ((Modules_Base_Form_Form)ct).AfterClickUpdateConfig += new EventHandler(formDetail_AfterClickUpdateConfig);
                ((Modules_Base_Form_Form)ct).AfterClickUpdateButton += new EventHandler(ucWindowAddNew_AfterClickUpdateButton);
                switch (gridPanel.InformationPanel)
                {
                    case "Top":
                        plNorth.Controls.Add(ct);
                        break;
                    case "Bottom":
                        plcSouth.Controls.Add(ct);
                        break;
                    case "Right":
                        plEast.Controls.Add(ct);
                        break;
                    case "Left":
                        plEast.Controls.Add(ct);
                        break;
                }
            }
    }

    /// <summary>
    /// Thiết lập các thông số của form Edit và Insert
    /// </summary>
    private void SetupForm()
    {
        if (DisableEditWindow == true)
            return;
        if (gridPanel == null)
        {
            gridPanel = GridController.GetInstance().GetGridPanel(this.ID);
            if (gridPanel == null) //xảy ra trong trường hợp chưa config Form
                return;
        }
        if (gridPanel.OneManyForm == false)
        {
            Control ct = this.Page.LoadControl("../Base/Form/Form.ascx");
            Form frm = ct as Form;
            frm.accessHistory = this.accessHistory;
            plcWindow.Controls.Add(ct);
            frm.WindowHidden = true;
            frm.FormType = Form.FormKind.Window;
            ((Modules_Base_Form_Form)ct).AfterClickUpdateButton += new EventHandler(Form1_AfterClickUpdateButton);
            if (string.IsNullOrEmpty(hdfWhatForm.Text))
            {
                frm.GridPanelName = this.ID;
                frm.FormName = this.ID + "ucWindowAddNew";
                frm.CommandButton = Form.Command.insert;
            }
            else //Update
            {
                frm.GridPanelName = this.ID;
                frm.CommandButton = Form.Command.update;
                frm.FormName = this.ID + "ucWindowUpdate";
                frm.FormReference = this.ID + "ucWindowAddNew";
                frm.PrimaryColumnValue = hdfRecordID.Text;
            }
        }
        else
        {
            //Chưa lưu lịch sử truy cập
            Control ct = this.Page.LoadControl("../Base/OneManyForm/OneManyForm.ascx");
            OneManyFormControl frm = ct as OneManyFormControl;
            frm.XmlConfigUrl = this.XmlConfigUrl;
            frm.accessHistory = this.accessHistory;
            frm.GridPanelName = this.ID;
            frm.FormName = this.ID + "OneManyForm";
            plcWindow.Controls.Add(ct);
            frm.WindowHidden = true;
            frm.FormType = Form.FormKind.Window;
            if (string.IsNullOrEmpty(hdfWhatForm.Text))
            {
                frm.CommandButton = Form.Command.insert;
            }
            else
            {
                frm.CommandButton = Form.Command.update;
            }
            ((Modules_Base_OneManyForm_OneManyForm)ct).AfterClickUpdateButton += new EventHandler(Form1_AfterClickUpdateButton);
        }
    }

    void Form1_AfterClickUpdateButton(object sender, EventArgs e)
    {
        RM.RegisterClientScriptBlock("storereload", "#{Store1}.reload();");
        //Form1.GridPanelName = this.ID;
        //Form1.FormName = this.ID + "ucWindowAddNew";
        //Form1.CommandButton = Form.Command.insert;
    }

    void ucWindowAddNew_AfterClickUpdateButton(object sender, EventArgs e)
    {
        RM.RegisterClientScriptBlock("storereload", "#{Store1}.reload();");
    }

    void formDetail_AfterClickUpdateConfig(object sender, EventArgs e)
    {
        RM.RegisterClientScriptBlock("pageLoadAgain", "location.reload();");
    }
    /// <summary>
    /// Gọi hàm javascript sử dụng Resource Manager
    /// </summary>
    /// <param name="script"></param>
    public void CallScriptUsingResourceManager(string script)
    {
        RM.RegisterClientScriptBlock("CallScript", script);
    }

    public RowSelectionModel GetRowSelectionModel()
    {
        return RowSelectionModel1;
    }

    public Ext.Net.GridPanel GetGridPanel()
    {
        return GridPanel1;
    }

    public void ShowData()
    {
        if (gridPanel == null)
        {
            gridPanel = new GridPanelInfo(1, this.ID, "", "", 0, 0, "", 30, defaultTable, true, false, false, false, "", "", "", false, "", false);
            GridController.GetInstance().AddGridPanel(gridPanel);
        }
        if (columnList == null)
            columnList = GridController.GetInstance().GetColumnInfo(this.ID, TableName, 1);

        InitComponent(gridPanel, columnList);
        LoadField();
    }
    /// <summary>
    /// Load field vào store
    /// </summary>
    private void LoadField()
    {
        Store1.AutoLoad = !DisableAutoLoad;
        if (columnList == null)
            columnList = GridController.GetInstance().GetColumnInfo(this.ID, TableName, 1);
        JsonReader jsonReader = new JsonReader();
        jsonReader.Root = "Data";
        if (string.IsNullOrEmpty(this.PrimaryKey))
        {
            this.PrimaryKey = Util.GetInstance().GetPrimaryKeyOfTable(gridPanel.TableName);
        }
        jsonReader.IDProperty = this.PrimaryKey;
        jsonReader.TotalProperty = "TotalRecords";

        if (columnList.FirstOrDefault() != null)
        {
            foreach (GridPanelColumnInfo columnInfo in columnList)
            {
                RecordField field = new RecordField();
                field.Name = columnInfo.ColumnName;
                jsonReader.Fields.Add(field);
            }
        }
        else
        {
            DataTable datatable = DataController.DataHandler.GetInstance().ExecuteDataTable("select top 1 * from " + TableName);
            foreach (DataColumn item in datatable.Columns)
            {
                RecordField field = new RecordField();
                field.Name = item.ColumnName;
                jsonReader.Fields.Add(field);
            }
        }
        Store1.Reader.Add(jsonReader);
    }
    /// <summary>
    /// Load column vào GridPanel
    /// </summary>
    private void AddColumn()
    {
        string HtmlExpandRowTemplate = "";
        if (!string.IsNullOrEmpty(this.RowExpanderTemplateUrl))
            HtmlExpandRowTemplate = Util.GetInstance().ReadFile(Server.MapPath(this.RowExpanderTemplateUrl));
        if (columnList == null)
            columnList = GridController.GetInstance().GetColumnInfo(this.ID, TableName, 1);
        if (columnList.FirstOrDefault() == null)
        {
            datatable = DataController.DataHandler.GetInstance().ExecuteDataTable("select top 1 * from " + TableName);
            foreach (DataColumn item in datatable.Columns)
            {
                Column column = new Column();
                column.DataIndex = item.ColumnName;
                column.Header = item.ColumnName;
                GridPanel1.ColumnModel.Columns.Add(column);
                if (item.DataType.ToString().Equals("System.DateTime"))
                {
                    column.Renderer.Fn = "GetDateFormat";
                }
            }
        }
        else
        {
            string listener = "";
            bool hasComboBox = false;
            //Khóa cột
            if (columnList.Where(t => t.Locked == true).Count() > 0)
            {
                LockingGridView lockview = new LockingGridView();
                lockview.ID = "LockingGridView" + this.ID;
                lockview.EnableViewState = false;
                GridPanel1.View.Clear();
                GridPanel1.View.Add(lockview);
            }
            foreach (GridPanelColumnInfo columnInfo in columnList)
            {
                if (HtmlExpandRowTemplate.Contains("{" + columnInfo.ColumnName + "}"))
                    continue;
                Column column = new Column();
                column.DataIndex = columnInfo.ColumnName;
                column.Header = columnInfo.ColumnHeader;
                column.Locked = columnInfo.Locked;
                switch (columnInfo.Align)
                {
                    case "right":
                        column.Align = Alignment.Right;
                        break;
                    case "center":
                        column.Align = Alignment.Right;
                        break;
                }
                if (columnInfo.Width.HasValue && columnInfo.Width != 0)
                    column.Width = columnInfo.Width.Value;
                GridPanel1.ColumnModel.Columns.Add(column);
                if (string.IsNullOrEmpty(columnInfo.RenderJS) == false)
                {
                    column.Renderer.Fn = columnInfo.RenderJS;
                }
                if (columnInfo.AllowSearch)
                {
                    column.Renderer.Fn = "RenderHightLight";
                }
                if (columnInfo.AllowComboBoxOnGrid && string.IsNullOrEmpty(columnInfo.TableName) == false)
                {
                    hasComboBox = true;
                    Ext.Net.ComboBox cbBox = new ComboBox();
                    cbBox.LoadingText = "Đang tải...";
                    cbBox.ID = "combo" + columnInfo.ColumnName;
                    cbBox.DisplayField = "displayField";
                    cbBox.ValueField = "valueField";
                    cbBox.EnableViewState = false;
                    cbBox.Editable = false;
                    //add trigger X 
                    FieldTrigger fieldTrigger = new FieldTrigger();
                    fieldTrigger.Icon = TriggerIcon.Clear;
                    fieldTrigger.HideTrigger = true;
                    fieldTrigger.Qtip = "Hủy";
                    cbBox.Triggers.Add(fieldTrigger);
                    cbBox.Listeners.Select.Handler = "this.triggers[0].show();";
                    cbBox.Listeners.BeforeQuery.Handler = "this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();";
                    cbBox.Listeners.TriggerClick.Handler = "if (index == 0) { this.clearValue(); this.triggers[0].hide(); }";
                    // cbBox.PageSize = 10;
                    //end add trigger X

                    column.Editor.Add(cbBox);
                    Store store = CreateStore(cbBox.ID);
                    cbBox.Store.Add(store);
                    storeList.Add(new StoreDaTa(store,
                                                columnInfo.ComboBoxTable,
                                                columnInfo.DisplayFieldComboBox,
                                                columnInfo.ValueFieldComboBox,
                                                columnInfo.WhereFilterComboBox,
                                                columnInfo.ColumnName,
                                                columnInfo.MasterColumnComboID.Value,
                                                columnInfo.ID));

                    if (columnInfo.MasterColumnComboID.HasValue && columnInfo.MasterColumnComboID.Value != 0)
                    {
                        GridPanelColumnInfo col = columnList.Where(p => p.ID == columnInfo.MasterColumnComboID.Value).FirstOrDefault();
                        if (col != null)
                        {
                            listener += string.Format("case \"{0}\": this.getColumnModel().getCellEditor(e.column, e.row).field.allQuery = e.record.get('{1}');break;", columnInfo.ColumnName, col.ColumnName);
                        }
                    }
                }
                if (gridPanel == null)
                    gridPanel = GridController.GetInstance().GetGridPanel(this.ID);
                if (gridPanel.AllowEditOnGrid)
                {
                    //Nếu cột cho phép sửa thì sẽ add control trên Grid để sửa
                    if (columnInfo.AllowEditOnGrid)
                    {
                        if (column.Editor.Count() == 0)
                            AddEditor(column, columnInfo);
                    }
                }
            }
            if (!string.IsNullOrEmpty(listener))
            {
                GridPanel1.Listeners.BeforeEdit.Handler = "switch (e.field) {" + listener + "}";
            }
            if (hasComboBox)
            {
                GridPanel1.DirectEvents.AfterEdit.Event += new ComponentDirectEvent.DirectEventHandler(AfterEdit_Event);
                GridPanel1.DirectEvents.AfterEdit.ExtraParams.Add(new Ext.Net.Parameter("id", "e.record.id", ParameterMode.Raw));
                GridPanel1.DirectEvents.AfterEdit.ExtraParams.Add(new Ext.Net.Parameter("field", "e.field", ParameterMode.Raw));
                GridPanel1.DirectEvents.AfterEdit.ExtraParams.Add(new Ext.Net.Parameter("record", "e.record.data", ParameterMode.Raw, true));
                GridPanel1.DirectEvents.AfterEdit.ExtraParams.Add(new Ext.Net.Parameter("value", "e.value", ParameterMode.Raw));
            }
        }
    }
    /// <summary>
    /// Add các control vào Grid để có thể sửa trực tiếp trên Grid
    /// </summary>
    /// <param name="column"></param>
    /// <param name="columnInfo"></param>
    private void AddEditor(Column column, GridPanelColumnInfo columnInfo)
    {
        switch (columnInfo.DataType)
        {
            case "System.DateTime":
                Ext.Net.DateField datefield = new DateField();
                datefield.ID = "datefield" + column.DataIndex;
                column.Editor.Add(datefield);
                break;
            case "System.String":
                Ext.Net.TextField textfield = new TextField();
                textfield.ID = "textfield" + column.DataIndex;
                textfield.MaxLength = 500;
                column.Editor.Add(textfield);
                break;
            case "System.Boolean":
                Ext.Net.Checkbox chkCheckBox = new Checkbox();
                chkCheckBox.ID = "chkCheckBox" + column.DataIndex;
                column.Editor.Add(chkCheckBox);
                break;
            case "System.Int32":
                Ext.Net.NumberField intNumber = new NumberField();
                intNumber.AllowDecimals = false;
                intNumber.ID = "intNumber" + column.DataIndex;
                intNumber.MaxLength = 9;
                column.Editor.Add(intNumber);
                break;
            case "System.Decimal":
                Ext.Net.NumberField decNumber = new NumberField();
                decNumber.AllowDecimals = true;
                decNumber.ID = "decNumber" + column.DataIndex;
                decNumber.MaxLength = 18;
                column.Editor.Add(decNumber);
                break;
        }
    }
    /// <summary>
    /// Lưu các thông tin sau khi edit trực tiếp trên Grid vào CSDL
    /// </summary>
    /// <param name="id"></param>
    /// <param name="field"></param>
    /// <param name="value"></param>
    [DirectMethod]
    public void AfterEdit(string recordID, string field, string value)
    {
        if (AfterEditOnGrid != null)
        {
            AfterEditOnGrid(recordID + ";" + field + ";" + value, null);
            return;
        }
        string sql = string.Empty;
        try
        {
            if (gridPanel == null)
                gridPanel = GridController.GetInstance().GetGridPanel(this.ID);
            this.PrimaryKey = Util.GetInstance().GetPrimaryKeyOfTable(gridPanel.TableName);
            if (value.Replace("\"", "") == "false")
                value = "0";
            else if (value.Replace("\"", "") == "true")
                value = "1";
            sql = "update " + gridPanel.TableName + " set " + field + " = N'" + value.Replace("\"", "") + "' where " + this.PrimaryKey + " = N'" + recordID + "'"; //hdfRecordID.Text.Trim()
            DataHandler.GetInstance().ExecuteNonQuery(sql);
            //Ghi log cho hành động thêm mới
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("EditOnGrid"),
                MOTA = GlobalResourceManager.GetInstance().GetHistoryAccessValue("EditOnGrid"),
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = gridPanel.TableName,
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = field + " : Giá trị mới = " + value + ", câu truy vấn sql = " + sql,
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(GlobalResourceManager.GetInstance().GetErrorMessageValue("AfterEditInGrid"));
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("EditOnGrid"),
                MOTA = ex.Message,
                IsError = true,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = this.TableName,
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = field + " : Giá trị mới = " + value + ", câu truy vấn sql = " + sql,
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
    }
    /// <summary>
    /// Sự kiện AfterEdit của GridPanel1, xảy ra khi người dùng thay đổi giá trị combobox trên Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void AfterEdit_Event(object sender, DirectEventArgs e)
    {
        JsonObject data = JSON.Deserialize<JsonObject>(e.ExtraParams["record"]);
        foreach (StoreDaTa store in storeList)
        {
            StoreDaTa _s = storeList.Where(p => p.ColumnID == store.MasterColumnID).FirstOrDefault();
            if (_s == null)
                continue;
            if (!string.IsNullOrEmpty(store.WhereFilter))
                store.WhereFilter = string.Format(store.WhereFilter, "N'" + data[_s.ColumnName] + "'");
            else
                store.WhereFilter = "1=1";
            string sql = string.Format("select top 1 {0} from {1} where {2}", store.DisplayField, store.TableName, store.WhereFilter);
            DataTable Data = DataHandler.GetInstance().ExecuteDataTable(sql);
            if (Data.Rows.Count != 0)
                this.Store1.UpdateRecordField(e.ExtraParams["id"], store.ColumnName, Data.Rows[0][store.DisplayField].ToString());
        }
    }
    /// <summary>
    /// Tạo Store cho các ComboBox trên GridPanel
    /// </summary>
    /// <returns></returns>
    private Ext.Net.Store CreateStore(string StoreName)
    {
        Ext.Net.Store st = new Store();
        st.ID = "store" + StoreName;
        st.AutoLoad = false;
        st.RefreshData += new Store.AjaxRefreshDataEventHandler(cbBoxStoreRefresh);
        st.Proxy.Add(new PageProxy());
        JsonReader reader = new JsonReader();
        reader.IDProperty = "valueField";
        reader.Fields.Add(new RecordField("valueField"));
        reader.Fields.Add(new RecordField("displayField"));
        st.Reader.Add(reader);
        return st;
    }
    /// <summary>
    /// Store được sử dụng để fill data vào combobox trên grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cbBoxStoreRefresh(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            StoreDaTa storeData = storeList.Where(p => p.store.ID == ((Store)sender).ID).FirstOrDefault();
            string query = e.Parameters["query"];
            List<object> dataList = new List<object>();
            if (string.IsNullOrEmpty(storeData.WhereFilter))
                storeData.WhereFilter = "1=1";
            else if (string.IsNullOrEmpty(query) == false) //Note: Nếu muốn sử dụng query thì trong trường filter phải có đoạn text như FieldName like {0}
            {
                storeData.WhereFilter = string.Format(storeData.WhereFilter, "N'" + query + "'");
            }
            string sql = string.Format("select {0},{1} from {2} where {3}", storeData.DisplayField, storeData.ValueField, storeData.TableName, storeData.WhereFilter);
            DataTable Data = DataHandler.GetInstance().ExecuteDataTable(sql);

            foreach (DataRow row in Data.Rows)
            {
                string _displayField = row[storeData.DisplayField].ToString();
                string _valueField = row[storeData.ValueField].ToString();

                dataList.Add(new { valueField = _valueField, displayField = _displayField });
            }

            if (storeData.store != null)
            {
                storeData.store.DataSource = dataList;
                storeData.store.DataBind();
            }
        }
        catch
        {
        }
    }

    private void InitComponent(GridPanelInfo panel, List<GridPanelColumnInfo> columnList)
    {
        //if (panel.RowCheckBox)
        //{
        //    CheckboxSelectionModel r = new CheckboxSelectionModel();
        //    r.ID = "RowSelectionModel1";
        //    r.Listeners.SelectionChange.Handler = "GetColumnID(#{RowSelectionModel1});";
        //    GridPanel1.SelectionModel.Add(r);
        //}
        //else
        //{
        //    RowSelectionModel r = new RowSelectionModel();
        //    r.ID = "RowSelectionModel1";
        //    r.Listeners.RowSelect.Handler = "document.getElementById('hdfRecordID').value = #{RowSelectionModel1}.getSelected().id;";
        //    GridPanel1.SelectionModel.Add(r);
        //}  

        //Add Row Expander cho Grid
        if (!string.IsNullOrEmpty(this.RowExpanderTemplateUrl))
        {
            RowExpander rowExpander = new RowExpander()
            {
                ID = "rx",
            };
            rowExpander.Template.Html = Util.GetInstance().ReadFile(Server.MapPath(this.RowExpanderTemplateUrl));
            GridPanel1.Plugins.Add(rowExpander);
        }
        if (columnList == null)
            columnList = GridController.GetInstance().GetColumnInfo(this.ID, TableName, 1);
        if (panel.DisplayRowNumber)
        {
            RowNumbererColumn stt = new RowNumbererColumn();
            if (columnList.Where(t => t.Locked == true).Count() > 0)
            {
                stt.Locked = true;
            }
            stt.Width = 32;
            stt.Header = "STT";
            GridPanel1.ColumnModel.Columns.Add(stt);
        }
        if (panel.Header == false)
            GridPanel1.Title = "";
        else
            GridPanel1.Title = panel.Title;
        if (!string.IsNullOrEmpty(panel.AutoExpandColumn))
        {
            if (columnList.Count() != 0)
            {
                if (columnList.Where(p => p.ColumnName == panel.AutoExpandColumn).FirstOrDefault() != null)
                {
                    GridPanel1.AutoExpandColumn = panel.AutoExpandColumn;
                }
            }
            else
            {
                datatable = DataController.DataHandler.GetInstance().ExecuteDataTable("select top 1 * from " + TableName);
                foreach (DataColumn item in datatable.Columns)
                {
                    if (item.ColumnName == panel.AutoExpandColumn)
                    {
                        GridPanel1.AutoExpandColumn = panel.AutoExpandColumn;
                        break;
                    }
                }
            }
        }
        this.PrimaryKey = Util.GetInstance().GetPrimaryKeyOfTable(panel.TableName);
        Store1.AutoLoadParams.Add(new Ext.Net.Parameter("limit", panel.PageSize.ToString()));

        if (string.IsNullOrEmpty(this.PrimaryKey))
        {
            this.PrimaryKey = Util.GetInstance().GetPrimaryKeyOfTable(panel.TableName);
        }
        sHdfgridName.Value = this.ID.ToString();
        sHdftable.Value = this.TableName;
        sHdfwhere.Value = panel.WhereClause.Replace("where", "");
        sHdfOrderBy.Value = panel.OrderBy;
        sHdfPrimaryKeyName.Value = this.PrimaryKey;
        //Lấy các column truyền vào file handler để phục vụ cho việc lấy dữ liệu 
        string column = "";
        if (columnList.Count() != 0)
        {
            column = "[" + PrimaryKey + "]";
            foreach (var item in columnList)
            {
                if (!item.ColumnName.Equals(PrimaryKey))
                {
                    column += ",[" + item.ColumnName + "]";
                }
            }
        }
        hdfColumnList.Value = column;
        if (panel.PageSize.HasValue)
        {
            ComboBoxPaging.SelectedIndex = panel.PageSize.Value / 5 - 1;
            StaticPagingToolbar.PageSize = panel.PageSize.Value;
        }
        if (!string.IsNullOrEmpty(panel.Icon))
        {
            GridPanel1.IconCls = panel.Icon;
        }
        else
        {
            GridPanel1.Icon = Icon.Table;
        }
        //Sinh hàm Java AfterEdit
        ltrAfterEditJs.Text = "<script type='text/javascript'>" +
                                  "var afterEdit = function (e) {  " +
                                    "Ext.Msg.confirm('Xác Nhận', 'Bạn có muốn lưu lại không ?', function (btn) {" +
                                    "if (btn == 'yes') {" +
                                     " directMethod.AfterEdit(e.record.data." + this.PrimaryKey + "+'',e.field, e.value);" +
                                     " }});store.commitChanges();" +
                                 "};" +
                               "</script>";

        //    Ext.Msg.confirm('Xác Nhận', 'Bạn có muốn thay đổi thông tin không ?', function (btn) {
        //    if (btn == "yes") {

        //    }
        //});
        //load bảng thông tin chi tiết
        if (!string.IsNullOrEmpty(gridPanel.InformationPanel))
        {
            FormInfo frmInfo = FormController.GetInstance().GetForm(this.ID + "formDetail");
            if (frmInfo != null)
                switch (gridPanel.InformationPanel)
                {
                    case "Top":
                        if (frmInfo.Height.HasValue)
                            plNorth.Height = frmInfo.Height.Value;
                        else
                            plNorth.Height = 200;
                        plNorth.Visible = true;
                        plNorth.Title = frmInfo.Title;
                        break;
                    case "Bottom":
                        if (frmInfo.Height.HasValue)
                            plSouth.Height = frmInfo.Height.Value;
                        else
                            plSouth.Height = 200;
                        plSouth.Visible = true;
                        plSouth.Title = frmInfo.Title;
                        break;
                    case "Right":
                        if (frmInfo.Width > 1)
                            plEast.Width = (int)frmInfo.Width;
                        else if (frmInfo.Width > 0 && frmInfo.Width <= 1)
                            plEast.AnchorHorizontal = frmInfo.Width * 100 + "%";
                        else if (frmInfo.Width == 0)
                            plEast.AnchorHorizontal = "40%";
                        plEast.Visible = true;
                        plEast.Title = frmInfo.Title;
                        break;
                    case "Left":
                        if (frmInfo.Width > 1)
                            plWest.Width = (int)frmInfo.Width;
                        else if (frmInfo.Width > 0 && frmInfo.Width <= 1)
                            plWest.AnchorHorizontal = frmInfo.Width * 100 + "%";
                        else if (frmInfo.Width == 0)
                            plWest.AnchorHorizontal = "40%";
                        plWest.Visible = true;
                        plWest.Title = frmInfo.Title;
                        break;
                }
        }


        //set local filter
        if (panel.AllowFilter)
        {
            GridFilters filter = new GridFilters();
            filter.Local = true;
            filter.FiltersText = "Lọc";
            GridPanel1.Plugins.Add(filter);
            datatable = DataController.DataHandler.GetInstance().ExecuteDataTable("select top 1 * from " + TableName);
            foreach (DataColumn item in datatable.Columns)
            {
                switch (item.DataType.ToString())
                {
                    case "System.Int32":
                        NumericFilter numberic = new NumericFilter();
                        numberic.DataIndex = item.ColumnName;
                        filter.Filters.Add(numberic);
                        break;
                    case "System.Boolean":
                        BooleanFilter boolean = new BooleanFilter();
                        boolean.DataIndex = item.ColumnName;
                        filter.Filters.Add(boolean);
                        break;
                    case "System.String":
                        StringFilter str = new StringFilter();
                        str.DataIndex = item.ColumnName;
                        filter.Filters.Add(str);
                        break;
                    case "System.DateTime":
                        DateFilter datefilter = new DateFilter();
                        datefilter.BeforeText = "Trước ngày";
                        datefilter.AfterText = "Sau ngày";
                        datefilter.OnText = "Vào ngày";
                        datefilter.DataIndex = item.ColumnName;
                        filter.Filters.Add(datefilter);
                        break;
                }
            }
        }
    }

    void RowSelect_Event(object sender, DirectEventArgs e)
    {
        if (RowSelect != null)
        {
            RowSelect(sender, null);
        }
        else
            switch (gridPanel.InformationPanel)
            {
                case "Top":
                    Dialog.ShowNotification(plcNorth.Controls.Count.ToString() + plcWest.Controls.Count.ToString() + plcEast.Controls.Count.ToString() + plcNorth.Controls.Count.ToString());
                    //      (plcNorth.Controls[0] as Form).PrimaryColumnValue = hdfRecordID.Text;
                    //   ((IControl)plcNorth.Controls[0]).SetValue(hdfRecordID.Text);
                    break;
                case "Bottom":
                    (plcSouth.Controls[0] as Form).PrimaryColumnValue = hdfRecordID.Text;
                    ((IControl)plcSouth.Controls[0]).SetValue(hdfRecordID.Text);
                    break;
                case "Left":
                    (plcWest.Controls[0] as Form).PrimaryColumnValue = hdfRecordID.Text;
                    ((IControl)plcWest.Controls[0]).SetValue(hdfRecordID.Text);
                    break;
                case "Right":
                    (plcEast.Controls[0] as Form).PrimaryColumnValue = hdfRecordID.Text;
                    ((IControl)plcEast.Controls[0]).SetValue(hdfRecordID.Text);
                    break;
                default:
                    break;
            }
    }
    protected void btnDelete_Click(object sender, DirectEventArgs e)
    //[DirectMethod]
    //public void DirectDelete()
    {
        NhatkyTruycapInfo accessDiary = null;
        if (this.accessHistory != null)
            accessDiary = new NhatkyTruycapInfo()
             {
                 CHUCNANG = accessHistory.ModuleDescription,
                 IsError = false,
                 USERNAME = CurrentUser.UserName,
                 THOIGIAN = DateTime.Now,
                 MANGHIEPVU = gridPanel.TableName,
                 TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                 IPMAY = Request.UserHostAddress,
                 THAMCHIEU = "",
             };
        try
        {
            if (string.IsNullOrEmpty(this.PrimaryKey))
            {
                if (gridPanel == null)
                    gridPanel = GridController.GetInstance().GetGridPanel(this.ID);
                this.PrimaryKey = Util.GetInstance().GetPrimaryKeyOfTable(gridPanel.TableName);
            }

            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                string query = "delete from " + gridPanel.TableName + " where " + this.PrimaryKey + " = N'" + item.RecordID + "'";
                DataController.DataHandler.GetInstance().ExecuteNonQuery(query);

                if (this.accessHistory != null)
                {
                    accessDiary.MOTA = this.accessHistory.Delete_AccessHistoryDescription + ", khóa chính bản ghi: " + item.RecordID;
                    new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
                }
            }
            hdfRecordID.Text = "";
            RM.RegisterClientScriptBlock("rlStore", "RemoveItemOnBaseGrid(#{GridPanel1},#{Store1},#{DirectMethods});");
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("conflicted with the REFERENCE constraint"))
            {
                Dialog.ShowError("Không thể xóa được vì dữ liệu này đang được sử dụng ở chỗ khác !");
            }
            else
                Dialog.ShowError("Base/Module/GridPanel " + ex.Message);
            if (this.accessHistory != null)
            {
                accessDiary.MOTA = ex.Message;
                accessDiary.IsError = true;
                new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
            }
        }
    }


    [DirectMethod]
    public void DirectEdit()
    {
        btnEdit_Click(null, null);
    }
    [DirectMethod]
    public void DirectAdd()
    {
        btnAddRecord_Click(null, null);
    }

    [DirectMethod]
    public void SaveColumnOrder(string column)
    {
        try
        {
            string[] columnname = column.Split(',');
            int order = 0;
            foreach (var item in columnname)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    GridController.GetInstance().UpdateColumnOrder(this.ID, TableName, item, order);
                    order++;
                }
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Thông báo lỗi", ex.Message);
        }
        // Dialog.ShowNotification("Cập nhật thứ tự cột thành công !", false);
    }

    [DirectMethod]
    public void SaveColumnWidth(string column)
    {
        try
        {
            string[] col = column.Split(',');
            foreach (var item in col)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string[] tmp = item.Split('=');
                    GridController.GetInstance().UpdateColumnWidth(this.ID, TableName, tmp[0], int.Parse(tmp[1]));
                }
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Thông báo lỗi", ex.Message);
        }
        //  Dialog.ShowNotification("Cập nhật độ rộng của cột thành công !", false);
    }
    private void SetControlVisible()
    {
        if (CurrentUser.IsSuperUser)
        {
            return;
        }
        foreach (var item in Toolbar1.Items)
        {
            switch (item.InstanceOf)
            {
                case "Ext.Button":
                    var btn = (Ext.Net.Button)item;
                    if (btn.ID != "btnSearch")
                    {
                        btn.Visible = SetVisible(btn.Text);
                    }
                    break;
            }
        }
        foreach (var item in RowContextMenu.Items)
        {
            switch (item.ToString())
            {
                case "Ext.Net.MenuItem":
                    var mnuItem = (Ext.Net.MenuItem)item;
                    mnuItem.Visible = SetVisible(mnuItem.Text);
                    break;
            }
        }
        btnButtonTienIch.Visible = SetVisible(menuCopyData.Text);
        //   txtSearchKey.Visible = SetVisible(btnSearch.Text);
    }

    #region Ẩn các control trên ToolBar
    public void HiddenAddButton(bool hidden)
    {
        btnAddRecord.Hidden = hidden;
        mnuAddNew.Hidden = hidden;
    }

    public void HiddenEditButton(bool hidden)
    {
        btnEdit.Hidden = hidden;
        mnuEditUser.Hidden = hidden;
    }

    public void HiddenDeleteButton(bool hidden)
    {
        btnDelete.Hidden = hidden;
        MenuItem4.Hidden = hidden;
    }

    public void HiddenHelpButton(bool hidden)
    {
        btnHelp.Hidden = hidden;
    }

    public void HiddenSearchBox(bool hidden)
    {
        btnSearch.Hidden = hidden;
        txtSearchKey.Hidden = hidden;
    }

    public void HiddenTienIch(bool hidden)
    {
        btnButtonTienIch.Hidden = hidden;
    }

    public void HiddenDuplicateButton(bool hidden)
    {
        menuCopyData.Hidden = true;
        if (menuTienIch.Items.Count() == 0)
            btnButtonTienIch.Hidden = hidden;
    }

    public void ClearAllButtonOnToolbar()
    {
        foreach (var item in Toolbar1.Items)
        {
            if (item.ID != "btnConfig")
                item.Hidden = true;
        }
    }

    public void HiddenPagingToolbar(bool hidden)
    {
        StaticPagingToolbar.Hidden = hidden;
    }
    #endregion


    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {

        try
        {
            if (gridPanel.OneManyForm == false)
            {
                Form frm = plcWindow.Controls[0] as Form;
                frm.GridPanelName = this.ID;
                frm.CommandButton = Form.Command.update;
                frm.FormName = this.ID + "ucWindowUpdate";
                frm.FormReference = this.ID + "ucWindowAddNew";
                frm.PrimaryColumnValue = hdfRecordID.Text;
                ((Modules_Base_Form_Form)frm).Show();
            }
            else
            {
                OneManyFormControl frm = plcWindow.Controls[0] as OneManyFormControl;
                ((Modules_Base_OneManyForm_OneManyForm)frm).Show(hdfRecordID.Text);
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnAddRecord_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (gridPanel.OneManyForm == false)
            {
                Form frm = plcWindow.Controls[0] as Form;
                frm.GridPanelName = this.ID;
                frm.FormName = this.ID + "ucWindowAddNew";
                frm.CommandButton = Form.Command.insert;
                ((Modules_Base_Form_Form)frm).Show();
            }
            else
            {
                OneManyFormControl frm = plcWindow.Controls[0] as OneManyFormControl;
                frm.CommandButton = Form.Command.insert;
                ((Modules_Base_OneManyForm_OneManyForm)frm).Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Hiện window cấu hình GridPanel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuShowConfigWindow_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (plcConfig.Controls.Count != 0)
            {
                Control ct = plcConfig.Controls[0];
                ((Modules_Base_GridPanel_Config_GridConfig)ct).ShowGridPanelInformationConfig();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("GridPanel/mnuShowConfigWindow_Click = " + ex.Message);
        }
    }

    /// <summary>
    /// Hiện form thông tin cấu hình cột
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuColumnInformation_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (plcConfig.Controls.Count != 0)
            {
                Control ct = plcConfig.Controls[0];
                ((Modules_Base_GridPanel_Config_GridConfig)ct).ShowColumnInformationConfig();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("GridPanel/mnuColumnInformation_Click = " + ex.Message);
        }
    }

    /// <summary>
    /// Thêm control vào Toolbar, được sử dụng để developer thêm các control bên ngoài vào
    /// </summary>
    /// <param name="btn"></param>
    public void AddComponent(Component component)
    {
        if (Toolbar1.Items.Count() >= 5)
            Toolbar1.Items.Insert(Toolbar1.Items.Count() - 5, component);
        else
            Toolbar1.Items.Insert(0, component);
    }

    public void AddComponent(Component component, int position)
    {
        try
        {
            Toolbar1.Items.Insert(position, component);
        }
        catch (Exception ex)
        {
            Dialog.ShowError("GridPanel/AddComponent = " + ex.Message);
        }
    }

    public void AddMenuItemToTienIch(Ext.Net.MenuItem menuItem, int position)
    {
        menuTienIch.Items.Insert(position, menuItem);
    }

    public void SetHeaderTitle(string Title)
    {
        GridPanel1.Title = Title;
    }

    /// <summary>
    /// Lấy khóa chính của bản ghi được chọn, được sử dụng để cho các nút bên ngoài thao tác với bản ghi bên trong Grid
    /// </summary>
    /// <returns></returns>
    public string GetPrimaryKey()
    {
        return hdfRecordID.Text;
    }

    /// <summary>
    /// Lấy ID của các bản ghi được chọn
    /// </summary>
    /// <returns></returns>
    public List<string> GetSelectedRowsRecordId()
    {
        var rs = from r in RowSelectionModel1.SelectedRows select r.RecordID;
        return rs.ToList();
    }

    /// <summary>
    /// Phương thức tạm thời để test
    /// </summary>
    public void ReloadStore()
    {
        hdfQueryPhu.Text = OutSideQuery;
        RM.RegisterClientScriptBlock("zz", "#{Store1}.reload();");
    }

    /// <summary>
    /// Thêm nút vào MenuContext
    /// </summary>
    public void AddToMenuContext(Component menuItem)
    {
        RowContextMenu.Items.Add(menuItem);
    }
    public void AddToMenuContext(int position, Ext.Net.MenuItem menuItem)
    {
        RowContextMenu.Items.Insert(position, menuItem);
    }

    /// <summary>
    /// cho phép developer add các control tự viết thêm vào bên trái như TreePanel, GridPanel...
    /// </summary>
    /// <param name="component"></param>
    /// <param name="PanelTitle"></param>
    /// <param name="collapsed">true = thu nhỏ thanh panel, false = mở rộng</param>
    public void AddComponentToLeftPanel(Component component, string PanelTitle, bool collapsed)
    {
        plWest.Items.Add(component);
        plWest.Collapsed = collapsed;
        plWest.Visible = true;
        plWest.Width = component.Width;
        plWest.Title = PanelTitle;
    }

    /// <summary>
    /// cho phép developer add các control tự viết thêm vào bên phải như TreePanel, GridPanel...
    /// </summary>
    /// <param name="component"></param>
    /// <param name="PanelTitle"></param>
    public void AddComponentToRightPanel(Component component, string PanelTitle)
    {
        plEast.Items.Add(component);
        plEast.Visible = true;
        plEast.Width = component.Width;
        plEast.Title = PanelTitle;
    }


    /// <summary>
    /// cho phép developer add các control tự viết thêm vào bên dưới như TreePanel, GridPanel...
    /// </summary>
    /// <param name="component"></param>
    /// <param name="PanelTitle"></param>
    public void AddComponentToBottomPanel(Component component, string PanelTitle)
    {
        Ext.Net.Panel p = new Ext.Net.Panel();
        p.Border = false;
        p.Items.Add(GridPanel1);
        GridPanel1.Height = 400;
        borderLayout.Center.Items.Clear();
        borderLayout.Center.Items.Add(p);
        p.Items.Insert(1, component);
        component.Height = 250;
    }
    public void AddComponentToBottomPanel(Control component, string PanelTitle, int height)
    {
        //Ext.Net.Panel p = new Ext.Net.Panel();
        //p.Border = false;
        //p.Items.Add(GridPanel1);
        //borderLayout.Center.Items.Clear();
        //borderLayout.Center.Items.Add(p);
        //p.ContentContainer.Controls.Add(component);

        Ext.Net.BorderLayout br = new BorderLayout();
        br.Center.Items.Add(GridPanel1);
        borderLayout.Center.Items.Clear();
        Ext.Net.Panel pl = new Ext.Net.Panel();
        pl.Layout = "Fit";
        pl.Items.Add(br);
        pl.Border = false;
        borderLayout.Center.Items.Add(pl);
        Ext.Net.Panel p = new Ext.Net.Panel();
        //  p.Height = ((Form)component).Height;
        p.Height = height;
        p.Border = false;
        //    br.South.Collapsible = true;
        p.ContentContainer.Controls.Add(component);
        br.South.Items.Add(p);
    }

    protected void btnCopyData_Click(object sender, DirectEventArgs e)
    {
        int d = 0;
        foreach (var item in RowSelectionModel1.SelectedRows)
        {
            d++;
        }
        if (d <= 1)
        {
            if (IsPrimaryKeyAutoIncrement == false)
            {
                wdInputNewPrimaryKey.Show();
                return;
            }
            if (CopyData())
                ReloadStore();
        }
        else
        {
            Dialog.ShowError("Bạn chỉ được chọn một bản ghi");
        }

    }

    protected void btnOkPrimaryKey_Click(object sender, DirectEventArgs e)
    {
        if (string.IsNullOrEmpty(txtNewPrimaryKey.Text.Trim()))
        {
            Dialog.ShowNotification("Bạn chưa nhập khóa chính mới");
            return;
        }
        bool rs = CopyData();
        wdInputNewPrimaryKey.Hide();
        ReloadStore();
    }

    private bool CopyData()
    {
        if (gridPanel == null)
            gridPanel = GridController.GetInstance().GetGridPanel(this.ID);
        List<string> columnList = Util.GetInstance().GetColumnOfTable(gridPanel.TableName);
        if (string.IsNullOrEmpty(this.PrimaryKey))
        {
            this.PrimaryKey = Util.GetInstance().GetPrimaryKeyOfTable(gridPanel.TableName);
        }
        string sql = string.Empty;
        string column = "";
        foreach (var item in columnList)
        {
            if (item != this.PrimaryKey)
                column += "[" + item + "],";
        }
        column = column.Remove(column.LastIndexOf(","));
        List<string> recordIdList = new List<string>();
        if (IsPrimaryKeyAutoIncrement)
        {
            sql = string.Format("insert into " + gridPanel.TableName + "({0}) select {1} from " + gridPanel.TableName + " where " + this.PrimaryKey + " = ", column, column);
            recordIdList = (from t in RowSelectionModel1.SelectedRows select t.RecordID).ToList();
        }
        else
        {
            DataTable t = DataHandler.GetInstance().ExecuteDataTable("select " + column + " from " + gridPanel.TableName + " where " + this.PrimaryKey + " = N'" + hdfRecordID.Text + "'");
            column += ",[" + this.PrimaryKey + "]";
            string v = "";
            foreach (DataRow r in t.Rows)
            {
                foreach (DataColumn c in t.Columns)
                {
                    string dddd = c.DataType.ToString();
                    if (c.DataType.ToString() == "System.DateTime")
                        v += "N'" + Util.GetInstance().GetDateTimeEnfromVi(r[c.ColumnName].ToString()) + "',";
                    else
                        v += "N'" + r[c.ColumnName] + "',";
                }
            }
            v += "N'" + txtNewPrimaryKey.Text + "'";
            recordIdList.Add(hdfRecordID.Text);
            sql = "insert into " + gridPanel.TableName + "(" + column + ") values(" + v + ")";
        }

        foreach (var recordID in recordIdList)
        {
            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("CopyData"),
                IsError = false,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = gridPanel.TableName,
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
            };
            try
            {
                if (IsPrimaryKeyAutoIncrement)
                    DataHandler.GetInstance().ExecuteNonQuery(sql + "N'" + recordID + "'");
                //  Dialog.ShowError(sql + "N'" + recordID + "'");
                else
                    // Dialog.ShowError(sql);
                    DataHandler.GetInstance().ExecuteNonQuery(sql);
                accessDiary.MOTA = ", Khóa chính bản ghi gốc " + recordID;
            }
            catch (Exception ex)
            {
                accessDiary.MOTA = ex.Message.Replace("'", "") + ", Khóa chính bản ghi gốc " + recordID;
                accessDiary.IsError = true;
                if (ex.Message.Contains("Cannot insert duplicate key in object"))
                {
                    Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("DuplicateKey"));
                }
                else
                {
                    Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("DefaultErrorMessage"));
                }
                return false;
            }
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
        return true;
    }
}