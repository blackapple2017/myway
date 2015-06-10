using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rp_baocaodong
/// </summary>
public class rp_baocaodong : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
	private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    rp_baocaodong _report;
    DataSet _dataSet;
    public rp_baocaodong()
	{
        createDataTable("Table1");
        XRTable tableHeader, tableDetail;
        createReportTable(out tableHeader, out tableDetail, "Table1");
        addTable(tableHeader, tableDetail, "Table1");
        level++;

		InitializeComponent();
		//
		// TODO: Add constructor logic here
		//
	}
    static int level = 0;
    private void addTable(XRTable tableHeader, XRTable tableDetail, string tableName)
    {
        DetailReportBand DetailReportBand1 = new DevExpress.XtraReports.UI.DetailReportBand();
        DetailReportBand1.Level = level;
        GroupHeaderBand GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            tableHeader});
        GroupHeader1.Height = 20;
        GroupHeader1.Name = "GroupHeader" + level.ToString();
        GroupHeader1.RepeatEveryPage = true;
        DetailBand Detail1 = new DevExpress.XtraReports.UI.DetailBand();
        Detail1.Height = 20;
        Detail1.PageBreak = PageBreak.AfterBand;
        Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            tableDetail});
        DetailReportBand1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            GroupHeader1,
               Detail1});
        _report.Bands.Add(DetailReportBand1);
    }

    //---------------------------------------------------------------- createReportTable
    private void createReportTable(out XRTable tableHeader, out XRTable tableDetail, string tableName)
    {
        int colCount = _dataSet.Tables[tableName].Columns.Count;
        int colWidth = (_report.PageWidth - (_report.Margins.Left + _report.Margins.Right)) / colCount;

        // Create a table to represent headers
        tableHeader = new XRTable();
        tableHeader.Height = 20;
        tableHeader.Width = (_report.PageWidth - (_report.Margins.Left + _report.Margins.Right));

        XRTableRow headerRow = new XRTableRow();
        headerRow.Width = tableHeader.Width;
        headerRow.BackColor = Color.FromArgb(255, 222, 121);
        tableHeader.Rows.Add(headerRow);

        for (int i = 0; i < colCount; i++)
        {
            XRTableCell headerCell = new XRTableCell();
            headerCell.Borders = DevExpress.XtraPrinting.BorderSide.All;

            if (i == 0)
            {
                headerCell.Width = 105;
                headerCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            }
            else if (i == 1)
            {
                headerCell.Width = 36;
                headerCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            }
            else
            {
                headerCell.Width = colWidth;
                headerCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            }
            headerCell.Text = _dataSet.Tables[tableName].Columns[i].Caption;

            headerRow.Cells.Add(headerCell);
        }

        // Create a table to display data
        tableDetail = new XRTable();
        tableDetail.Width = (_report.PageWidth - (_report.Margins.Left + _report.Margins.Right));

        // Create table cells, fill the header cells with text, bind the cells to data
        foreach (DataRow row in _dataSet.Tables[tableName].Rows)
        {
            XRTableRow detailRow = new XRTableRow();
            detailRow.Width = tableDetail.Width;
            tableDetail.Rows.Add(detailRow);
            tableDetail.EvenStyleName = "EvenStyle";
            tableDetail.OddStyleName = "OddStyle";

            for (int i = 0; i < colCount; i++)
            {
                XRTableCell detailCell = new XRTableCell();
                if (i == 0)
                {
                    detailCell.Width = 105;
                    detailCell.BackColor = Color.FromArgb(255, 222, 121);
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                }
                else if (i == 1)
                {
                    detailCell.Width = 36;
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                }
                else
                {
                    detailCell.Width = colWidth;
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                }

                detailCell.Text = row[i].ToString();


                if (i == 0)
                {
                    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else
                {
                    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
                }

                // Place the cells into the corresponding tables
                detailRow.Cells.Add(detailCell);
            }
        }
    }
    //------------------------------------------------------------------ createDataTable
    private void createDataTable(string tableName)
    {
        if (_dataSet == null) _dataSet = new DataSet();
        DataTable table = addTable(_dataSet, tableName);
        DataColumn snpDataColumn = getOrAddColumn(_dataSet, table, "Sample", typeof(string));
        snpDataColumn.ColumnName = "Sample";
        DataColumn wellColumn =getOrAddColumn(_dataSet, table, "Well", typeof(string));
        wellColumn.ColumnName = "Well";
        DataColumn callColumn = getOrAddColumn(_dataSet, table, "Call", typeof(string));
        callColumn.ColumnName = "Call";
        int count = 40;
        for (int i = 0; i < count; i++)
        {
            DataRow row = table.NewRow();
            row["Sample"] = string.Format("Sample {0}", i);
            row["Well"] = string.Format("Well {0}", i);
            string dataString = string.Format("{0}, contains {1} rows", tableName, count);
            row["Call"] = dataString;
            table.Rows.Add(row);
        }
    }

    //----------------------------------------------------------------------- initStyles
    public void initStyles(XtraReport rep)
    {
        // Create different odd and even styles
        XRControlStyle oddStyle = new XRControlStyle();
        XRControlStyle evenStyle = new XRControlStyle();
        // Specify the odd style appearance
        oddStyle.BackColor = Color.FromArgb(250, 250, 210);
        oddStyle.StyleUsing.UseBackColor = true;
        oddStyle.StyleUsing.UseBorders = false;
        oddStyle.Name = "OddStyle";

        // Specify the even style appearance
        evenStyle.BackColor = Color.White;
        evenStyle.StyleUsing.UseBackColor = true;
        evenStyle.StyleUsing.UseBorders = false;
        evenStyle.Name = "EvenStyle";

        // Add styles to report's style sheet
        rep.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] { oddStyle, evenStyle });
    }

    #region =====================================================================  Table

    //------------------------------------------------------------------------- addTable
    public static DataTable addTable(DataSet dataSet, string tableName)
    {
        DataTable table = dataSet.Tables[tableName];
        if (table == null)
        {
            table = new DataTable(tableName);
            dataSet.Tables.Add(table);
        }
        return table;
    }

    //------------------------------------------------------------------------- getTable
    public static DataTable getTable(DataSet dataSet, string tableName)
    {
        return dataSet.Tables[tableName];
    }

    #endregion
    #region ====================================================================  Column

    //------------------------------------------------------------------------ addColumn
    public static DataColumn addColumn(DataTable data, string name, System.Type type)
    {
        return addColumn(data, name, type, false);
    }

    //------------------------------------------------------------------------ addColumn
    public static DataColumn addColumn(DataTable data, string name, System.Type type, bool ro)
    {
        DataColumn col;
        col = new DataColumn(name, type);
        col.Caption = name;
        col.ReadOnly = ro;
        data.Columns.Add(col);
        return col;
    }

    //------------------------------------------------------------------------ addColumn
    public static DataColumn addColumn(DataTable table, string columnName, System.Type type,
       params object[] extProps)
    {
        DataColumn col = addColumn(table, columnName, type);

        int propLimit = extProps.Length - 1;
        for (int i = 0; i < propLimit; i += 2)
        {
            object propName = extProps[i];
            object propVal = extProps[i + 1];
            col.ExtendedProperties[propName] = propVal;
        }

        return col;
    }

    //------------------------------------------------------------------- getOrAddColumn
    public static DataColumn getOrAddColumn(DataSet dataSet, string tableName, string columnName, System.Type type)
    {
        DataTable table = getTable(dataSet, tableName);
        return getOrAddColumn(table, columnName, type);
    }

    //------------------------------------------------------------------- getOrAddColumn
    public static DataColumn getOrAddColumn(DataTable table, string columnName, System.Type type)
    {
        DataColumn col = table.Columns[columnName];
        if (col == null)
        {
            col = addColumn(table, columnName, type);
        }
        return col;
    }

    //------------------------------------------------------------------- getOrAddColumn
    public static DataColumn getOrAddColumn(DataSet dataSet, string tableName, string columnName, System.Type type,
       params object[] extProps)
    {
        DataTable table = getTable(dataSet, tableName);
        return getOrAddColumn(dataSet, table, columnName, type, extProps);
    }

    //------------------------------------------------------------------- getOrAddColumn
    public static DataColumn getOrAddColumn(DataSet dataSet, DataTable table, string columnName, System.Type type,
       params object[] extProps)
    {
        bool isNew;
        DataColumn col = getOrAddColumnImpl(dataSet, table, columnName, type, out isNew);

        if (isNew)
        {
            int propLimit = extProps.Length - 1;
            for (int i = 0; i < propLimit; i += 2)
            {
                object propName = extProps[i];
                object propVal = extProps[i + 1];
                col.ExtendedProperties[propName] = propVal;
            }
        }

        return col;
    }


    //--------------------------------------------------------------- getOrAddColumnImpl
    public static DataColumn getOrAddColumnImpl(DataSet dataSet, DataTable table, string columnName, System.Type type, out bool isNew)
    {
        DataColumn col = table.Columns[columnName];
        if (col == null)
        {
            isNew = true;
            return addColumn(table, columnName, type);
        }
        else
        {
            isNew = false;
            return col;
        }
    }

    #endregion
    #region =======================================================================  Row

    //---------------------------------------------------------------------- getOrAddRow
    public static DataRow getOrAddRow(DataTable data, int index)
    {
        DataRow row = null;
        if (data.Rows.Count > index)
        {
            row = data.Rows[index];
        }

        if (row == null)
        {
            row = data.NewRow();
            data.Rows.Add(row);
        }
        return row;
    }

    //---------------------------------------------------------------------- getOrAddRow
    public static DataRow getOrAddRow(DataTable data, int index, DataColumn columnForIndex)
    {
        DataRow row = null;
        if (data.Rows.Count > index)
        {
            row = data.Rows[index];
        }

        if (row == null)
        {
            row = data.NewRow();
            row[columnForIndex] = index;
            data.Rows.Add(row);
        }
        return row;
    }

    //--------------------------------------------------------------------- findOrAddRow
    public static DataRow findOrAddRow(DataTable data, object primaryKey)
    {
        DataRow row = data.Rows.Find(primaryKey);
        if (row == null)
        {
            row = data.NewRow();
            DataColumn primary = data.PrimaryKey[0];
            row[primary] = primaryKey;
            data.Rows.Add(row);
        }
        return row;
    }
    #endregion

	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		components = new System.ComponentModel.Container();
		this.Detail = new DevExpress.XtraReports.UI.DetailBand();
		this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
		this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
		((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
		this.BottomMargin.Height = 100;
		this.TopMargin.Height = 100;
		this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
		this.Detail,
		this.TopMargin,
		this.BottomMargin});
		((System.ComponentModel.ISupportInitialize)(this)).EndInit();
	}

	#endregion
}
