using Ext.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using DataController;

public partial class Modules_Base_SingleGridPanel_SingleGridPanel : UserControlBase
{
    #region properties
    public string Title { get; set; }
    public string TableOrViewName { get; set; }
    public string ColumnName { get; set; } //truyền vào cách nhau = dấy ,
    public string ColumnHeader { get; set; } //truyền vào cách nhau = dấy ,
    public string ColumnWidth { get; set; }//ColumnName1=34,ColumnName2=70,
    public string LockedColumn { get; set; }//truyền vào cách nhau = dấy ,
    public string Render { get; set; }//truyền vào cách nhau = dấy , VD : ColumnName1=RenderFunc1,ColumnName1=RenderFunc2,
    public string GroupField { get; set; }
    public string IDProperty { get; set; }
    public string SearchField { get; set; }
    public string EmptyTextSearch { get; set; } //Thiết lập emptyText cho form search
    public string OrderBy { get; set; } //truyền vào cột để order
    public string AutoExpandColumn { get; set; }
    public string DonViColumn { get; set; }
    public string MenuContextID { get; set; } //thiết lập menuContext
    public string MoreStoreField { get; set; } //Bổ sung thêm các trường vào store nhưng không hiện lên grid, cách nhau dấu ,
    // public string WestPanelFilterScript { get; set; } //Đoạn javascript khi người dùng click vào tree filter
    public bool EnableWestPanelFilter { get; set; } //Cho phép hiện west panel lọc bên tay trái
    public bool ExpandWestPanelFilter { get; set; }
    public bool Header { get; set; }
    public bool EnableWhiteSpace { get; set; } //Nếu text dài quá thì cho xuống dòng
    public string MaDonViColumn { get; set; }
    public string WhereClause { get; set; } //Mệnh đề where để load dữ liệu
    public bool SingleSelect { get; set; }
    public bool HideGrouped { get; set; } //Có ẩn cột group ko
    public bool DisplayPrimaryColumn { get; set; }
    public int PageSize { get; set; }
    public string TableForDeleting { get; set; }
    #endregion

    #region Javascript
    public string RowSelect { get; set; }
    public string RowDbClick { get; set; }
    public string ViewReady { get; set; }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Ext.Net.X.IsAjaxRequest)
        {
            //Kiểm tra các điều kiện thuộc tính truyền vào
            if (PropertiesAreNotCorrect())
            {
                return;
            }
            InitComponent();//Sinh ra các thành phần trên grid
            hdfDataSource.Text = TableOrViewName;
            hdfColumn.Text = ColumnName;
            hdfIDProperty.Text = IDProperty;
            hdfSearchField.Text = SearchField;
            hdfWhereClause.Text = WhereClause;
            hdfOrderBy.Text = OrderBy;
            if (!string.IsNullOrEmpty(MaDonViColumn))
            {
                hdfMaDonVi.Text = Session["MaDonVi"].ToString();
                hdfMaDonViColumn.Text = MaDonViColumn;
            }
            string whiteSpace = "";
            if (!EnableWhiteSpace)
            {
                whiteSpace = "div#" + this.ID + "_GridPanel1 .x-grid3-cell-inner {white-space: nowrap !important;";
            }
            ltrCss.Text = "<style type='text/css'>div#" + this.ID + "_pnlCoCauToChuc-xsplit{" +
                                                "border-right: 1px solid #98C0F4;" +
                                                "border-left: 1px solid #98C0F4; } " + whiteSpace + "</style>";
        }
    }

    #region Khởi tạo các thành phần của Grid
    private void InitComponent()
    {
        if (string.IsNullOrEmpty(ColumnName))
        {
            ColumnName = "*";
        }
        DataTable datatable = DataController.DataHandler.GetInstance().ExecuteDataTable("select top 1 " + ColumnName + " from " + TableOrViewName);
        LoadFieldForStore(datatable);
        LoadColumnForGrid(datatable);
        //set title
        if (!string.IsNullOrEmpty(Title))
        {
            GridPanel1.Title = Title;
            GridPanel1.Header = true;
        }
        else
        {
            GridPanel1.Header = false;
        }
        //set javascript
        RowSelectionModel1.Listeners.RowSelect.Handler += RowSelect;
        GridPanel1.Listeners.RowDblClick.Handler += RowDbClick;
        GridPanel1.Listeners.ViewReady.Handler += ViewReady;
        GridPanel1.AutoExpandColumn = AutoExpandColumn;
        GridPanel1.Header = Header;
        //search field
        if (string.IsNullOrEmpty(SearchField))
        {
            txtSearchKey.Hide();
            btnSearch.Hide();
        }
        if (!string.IsNullOrEmpty(EmptyTextSearch))
        {
            txtSearchKey.EmptyText = EmptyTextSearch;
        }
        if (EnableWestPanelFilter)
        {

            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');StaticPagingToolbar.pageIndex=0;StaticPagingToolbar.doLoad(),Store1.reload();#{RowSelectionModel1}.clearSelections();",
            }.AddDepartmentList(borderLayout, CurrentUser.ID, !ExpandWestPanelFilter);
        }
        if (!string.IsNullOrEmpty(MenuContextID))
        {
            GridPanel1.Listeners.RowContextMenu.Handler = "e.preventDefault();#{" + MenuContextID + "}.dataRecord = this.store.getAt(rowIndex);#{" + MenuContextID + "}.showAt(e.getXY()); #{GridPanel1}.getSelectionModel().selectRow(rowIndex);";
        }
    }
    private void LoadFieldForStore(DataTable datatable)
    {
        JsonReader jsonReader = new JsonReader();
        jsonReader.Root = "Data";
        if (PageSize <= 0)
        {
            PageSize = 30;
        }
        Store1.BaseParams.Add(new Ext.Net.Parameter("PageSize", PageSize.ToString()));
        StaticPagingToolbar.PageSize = PageSize;

        jsonReader.IDProperty = IDProperty;
        jsonReader.TotalProperty = "TotalRecords";

        jsonReader.Fields.Add(new RecordField()
        {
            Name = IDProperty
        });

        foreach (DataColumn item in datatable.Columns)
        {
            RecordField field = new RecordField();
            field.Name = item.ColumnName;
            jsonReader.Fields.Add(field);
        }
        if (!string.IsNullOrEmpty(MoreStoreField))
        {
            foreach (var item in MoreStoreField.Split(','))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    RecordField field = new RecordField();
                    field.Name = item;
                    jsonReader.Fields.Add(field);
                }
            }
        } 
        Store1.Reader.Add(jsonReader);
        if (!string.IsNullOrEmpty(GroupField))
        {
            Store1.GroupField = GroupField;
        }
    }

    private void LoadColumnForGrid(DataTable table)
    {
        string[] headerColumn = ("" + ColumnHeader).Split(',');
        string[] widthList = ("" + ColumnWidth).Split(',');
        string[] render = ("" + Render).Split(',');
        int columnCount = table.Columns.Count;
        bool usingHeaderColumn = (headerColumn.Count() == columnCount);
        if (!string.IsNullOrEmpty(LockedColumn))
        {
            Ext.Net.LockingGridView lkv = new LockingGridView()
            {
                ID = "lkv",
            };
            GridPanel1.View.Add(lkv);
        }
        else if (!string.IsNullOrEmpty(GroupField))
        {
            Ext.Net.GroupingView group = new GroupingView()
            {
                ID = "GroupingView1",
                ForceFit = false,
                MarkDirty = false,
                ShowGroupName = false,
                EnableNoGroups = true,
                HideGroupedColumn = HideGrouped
            };
            GridPanel1.View.Add(group);
        }
        for (int i = 0; i < columnCount; i++)
        {
            if (table.Columns[i].ColumnName == IDProperty && DisplayPrimaryColumn == false)
            {
                continue;
            }
            switch (table.Columns[i].DataType.ToString())
            {
                case "System.Boolean":
                    string _render = GetRender(render, table.Columns[i].ColumnName);
                    if (!string.IsNullOrEmpty(_render))
                    {
                        Column _column = new Column();
                        _column.ColumnID = table.Columns[i].ColumnName;
                        _column.DataIndex = table.Columns[i].ColumnName;
                        _column.Header = usingHeaderColumn ? headerColumn[i].Trim() : table.Columns[i].ColumnName;
                        _column.Locked = GetLockingStatus(table.Columns[i].ColumnName);
                        _column.Width = GetColumnWidth(widthList, table.Columns[i].ColumnName);
                        _column.Renderer.Fn = _render;
                        GridPanel1.ColumnModel.Columns.Add(_column);
                    }
                    else
                    {
                        CheckColumn chkColumn = new CheckColumn();
                        chkColumn.ColumnID = table.Columns[i].ColumnName;
                        chkColumn.DataIndex = table.Columns[i].ColumnName;
                        chkColumn.Header = usingHeaderColumn ? headerColumn[i].Trim() : table.Columns[i].ColumnName;
                        chkColumn.Locked = GetLockingStatus(table.Columns[i].ColumnName);
                        chkColumn.Width = GetColumnWidth(widthList, table.Columns[i].ColumnName);
                        GridPanel1.ColumnModel.Columns.Add(chkColumn);
                    }
                    break;
                case "System.DateTime":
                    DateColumn dcolumn = new DateColumn();
                    dcolumn.ColumnID = table.Columns[i].ColumnName;
                    dcolumn.DataIndex = table.Columns[i].ColumnName;
                    dcolumn.Header = usingHeaderColumn ? headerColumn[i].Trim() : table.Columns[i].ColumnName;
                    dcolumn.Format = "dd/MM/yyyy";
                    dcolumn.Locked = GetLockingStatus(table.Columns[i].ColumnName);
                    dcolumn.Width = GetColumnWidth(widthList, table.Columns[i].ColumnName);
                    GridPanel1.ColumnModel.Columns.Add(dcolumn);
                    break;
                default:
                    Column column = new Column();
                    column.ColumnID = table.Columns[i].ColumnName;
                    column.DataIndex = table.Columns[i].ColumnName;
                    column.Header = usingHeaderColumn ? headerColumn[i].Trim() : table.Columns[i].ColumnName;
                    column.Locked = GetLockingStatus(table.Columns[i].ColumnName);
                    column.Width = GetColumnWidth(widthList, table.Columns[i].ColumnName);
                    column.Renderer.Fn = GetRender(render, table.Columns[i].ColumnName); //"RenderHightLight";
                    GridPanel1.ColumnModel.Columns.Add(column);
                    break;
            }
        }
    }

    private string GetRender(string[] render, string colName)
    {
        if ((SearchField + ",").Contains(colName + ","))
        {
            return "RenderHightLight";
        }
        foreach (string item in render)
        {
            try
            {
                if (item.Contains(colName))
                {
                    return item.Substring(item.LastIndexOf("=") + 1).Trim();
                    // return item.Replace("=", "").Replace(colName, "").Trim();
                }
            }
            catch
            {
            }
        }
        return "";
    }

    public int GetColumnWidth(string[] widthList, string columnName)
    {
        foreach (string item in widthList)
        {
            try
            {
                if (item.Contains(columnName))
                {
                    return int.Parse(item.Replace("=", "").Replace(columnName, ""));
                }
            }
            catch
            {
            }
        }
        return 90;//default width
    }
    private bool GetLockingStatus(string columnName)
    {
        return (LockedColumn + ",").Contains(columnName + ",");
    }

    #endregion

    private bool PropertiesAreNotCorrect()
    {
        if (!string.IsNullOrEmpty(WhereClause) && WhereClause.Contains("where"))
        {
            X.MessageBox.Alert("Thuộc tính truyền vào không hợp lệ", "WhereClause không được chứa từ khóa where").Show();
            return true;
        }
        if (string.IsNullOrEmpty(TableOrViewName))
        {
            X.MessageBox.Alert("Thuộc tính truyền vào không hợp lệ", "TableOrViewName bắt buộc phải có giá trị").Show();
            return true;
        }
        if (string.IsNullOrEmpty(IDProperty))
        {
            X.MessageBox.Alert("Thuộc tính truyền vào không hợp lệ", "IDProperty bắt buộc phải có giá trị");
            return true;
        }
        if (("," + ColumnName + ",").Contains("," + IDProperty + ",") == false && string.IsNullOrEmpty(ColumnName) == false)
        {
            X.MessageBox.Alert("Thuộc tính truyền vào không hợp lệ", "ColumnName bắt buộc phải chứa IDProperty").Show();
            return true;
        }
        if (string.IsNullOrEmpty(MaDonViColumn) && EnableWestPanelFilter == true)
        {
            X.MessageBox.Alert("Thuộc tính truyền vào không hợp lệ", "Bạn phải chỉ định rõ giá trị của MaDonViColumn").Show();
        }
        if (!string.IsNullOrEmpty(LockedColumn) && !string.IsNullOrEmpty(GroupField))
        {
            X.MessageBox.Alert("Thuộc tính truyền vào không hợp lệ", "LockedColumn và GroupField không thể đồng thời có cùng giá trị").Show();
        }
        return false;
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string sql = "Delete from " + TableForDeleting + " where " + IDProperty + " in (";
            string id = "";
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                id += "N'" + item.RecordID + "',";
            }
            DataHandler.GetInstance().ExecuteNonQuery(sql + id + "'-1')");
            GridPanel1.Reload();
            btnDelete.Disabled = true;
            btnEdit.Disabled = true;
            RowSelectionModel1.ClearSelections();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("REFERENCE constraint"))
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Không thể xóa được vì dữ liệu này đang được sử dụng ở chỗ khác !").Show();
            }
            else
                X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    #region CommonMethod
    /// <summary>
    /// add control vào west layout
    /// </summary>
    /// <param name="control"></param>
    public void AddControlToWest(Ext.Net.Component control)
    {
        borderLayout.West.Split = true;
        borderLayout.West.Collapsible = true;
        borderLayout.West.Items.Add(control);
    }

    public void AddControlToSouth(Ext.Net.Component control, bool collapsiable)
    {
        borderLayout.South.Split = true;
        borderLayout.South.Collapsible = collapsiable;
        borderLayout.South.Items.Add(control);
    }
    public ResourceManager GetResourceManager()
    {
        return RM;
    }
    public string GetMaDonVi()
    {
        return hdfMaDonVi.Text;
    }
    public Ext.Net.GridPanel GetGridPanel()
    {
        return GridPanel1;
    }

    public Ext.Net.Button GetAddButton()
    {
        return btnAddRecord;
    }

    public Ext.Net.Button GetEditButton()
    {
        return btnEdit;
    }

    public Ext.Net.Button GetDeleteButton()
    {
        return btnDelete;
    }

    public Ext.Net.Toolbar GetToolBar()
    {
        return Toolbar1;
    }

    public RowSelectionModel GetRowSelectionModel()
    {
        return RowSelectionModel1;
    }

    public List<string> GetSelectedRecordIDs()
    {
        List<string> idList = new List<string>();
        foreach (var item in RowSelectionModel1.SelectedRows)
        {
            idList.Add(item.RecordID);
        }
        //  RowSelectionModel1.ClearSelections();
        return idList;
    }

    public Ext.Net.BorderLayout GetBorderLayout()
    {
        return borderLayout;
    }
    #endregion
}