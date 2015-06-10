using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DAL;
using SoftCore.Security;

public partial class Modules_ChamCongDoanhNghiep_ThietLapCaChoNhanVien : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.BindData();
            LoadDonVi();
            SetEditor();
        }
    }

    #region Load tree
    private void LoadDonVi()
    {
        List<DM_DONVI> dvList = new UserController().GetDonViByUserID(CurrentUser.ID);
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        foreach (DM_DONVI dv in dvList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
            node.Icon = Ext.Net.Icon.House;
            root.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA_DONVI;
            node.Listeners.Click.Handler = "#{hdfMaDonVi}.setValue('" + node.NodeID + "');#{hdfMaPhong}.setValue('');#{hdfMaTo}.setValue('');#{PagingToolbar1}.pageIndex = 0;#{filterPhongBan}.reset();#{DirectMethods}.SetValueQuery();";
            LoadPhong(dv.MA_DONVI, node);
        }
        TreeCapNhatHoSoNhanSu.Root.Clear();
        TreeCapNhatHoSoNhanSu.Root.Add(root);
    }

    private void LoadPhong(string MaDonVi, Ext.Net.TreeNode DvNode)
    {
        //List<DM_PHONG> roomList = new DM_PHONGController().GetByDonViID(MaDonVi);
        //foreach (DM_PHONG room in roomList)
        //{
        //    Ext.Net.TreeNode node = new Ext.Net.TreeNode(room.TEN_PHONG);
        //    node.Icon = Ext.Net.Icon.Folder;
        //    DvNode.Nodes.Add(node);
        //    node.Expanded = true;
        //    node.NodeID = room.MA_PHONG;
        //    node.Listeners.Click.Handler = "#{hdfMaPhong}.setValue('" + node.NodeID + "');#{hdfMaDonVi}.setValue('');#{hdfMaTo}.setValue('');#{PagingToolbar1}.pageIndex = 0;#{filterPhongBan}.reset();#{DirectMethods}.SetValueQuery();";
        //    LoadTo(room.MA_PHONG, node);
        //}
    }

    private void LoadTo(string Maphong, Ext.Net.TreeNode PhongNode)
    {
        //List<DM_TO> roomList = new DM_TOController().GetByRoomID(Maphong);
        //foreach (DM_TO group in roomList)
        //{
        //    Ext.Net.TreeNode node = new Ext.Net.TreeNode(group.TEN_TO);
        //    // node.Icon = Ext.Net.Icon.House;
        //    node.NodeID = group.MA_TO;
        //    PhongNode.Nodes.Add(node);
        //    node.Expanded = true;
        //    node.Listeners.Click.Handler = "#{hdfMaTo}.setValue('" + node.NodeID + "');#{hdfMaPhong}.setValue('');#{hdfMaDonVi}.setValue('');#{PagingToolbar1}.pageIndex = 0;#{filterPhongBan}.reset();#{DirectMethods}.SetValueQuery();";
        //}
    }
    #endregion

    private void SetEditor()
    {
         
        this.Store2.DataSource = new List<object> { new { name = "Ca 1" }, new { name = "Ca 2" }, new { name = "Ca 3" } };
        this.Store2.DataBind();

        foreach (var col in GridPanel1.ColumnModel.Columns)
        {
            //   Ext.Net.MultiCombo cbWorkingStatus = new MultiCombo();
            Ext.Net.MultiCombo cbWorkingStatus = new MultiCombo();
            cbWorkingStatus.StoreID = "Store2";
            cbWorkingStatus.Width = 60;
            cbWorkingStatus.ListWidth = 300;
            cbWorkingStatus.ID = "cb" + col.ColumnID;
            cbWorkingStatus.TypeAhead = true;
            cbWorkingStatus.ForceSelection = true;
              cbWorkingStatus.SelectionMode = MultiSelectMode.Selection;
            cbWorkingStatus.DisplayField = "name";
            cbWorkingStatus.ValueField = "name";
            cbWorkingStatus.Editable = false;
            cbWorkingStatus.Mode = DataLoadMode.Local;
            cbWorkingStatus.ItemSelector = "tr.list-item";

            cbWorkingStatus.Template.Html = @"
                                            <tpl for=""."">
						                        <tpl if=""[xindex] == 1"">
							                        <table class=""cbStates-list"">
								                        <tr>
									                        <th>Tên ca</th>
									                        <th>Giờ làm việc</th>
								                        </tr>
						                        </tpl>
						                        <tr class=""list-item"">
							                        <td style=""padding:3px 0px;"">{name}</td>
							                        <td>{name}</td>
						                        </tr>
						                        <tpl if=""[xcount-xindex]==0"">
							                        </table>
						                        </tpl>
					                        </tpl>
                                            ";

            if (col.ColumnID.StartsWith("Ngay"))
            {
                col.Editor.Add(cbWorkingStatus);
                col.DataIndex = "name";
            }
        }
    }

    protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        this.BindData();
    }

    private void BindData()
    {
        var store = this.GridPanel1.GetStore();

        store.DataSource = this.Data;
        store.DataBind();
    }

    private object[] Data
    {
        get
        {
            DateTime now = DateTime.Now;

            return new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, "Ca 1", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 2", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 3", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 4", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 5", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 6", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 7", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 8", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 9", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 10", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 11", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 12", now }, 
                new object[] { "3m Co", 71.72, 0.02, "Ca 13", now }, 
            };
        }
    }
}