using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
public partial class Modules_BaoHiem_UC_BHNHANVIEN_BAOHIEM_BHNHANVIEN_BAOHIEM : UserControlBase
{
    public SelectedRowCollection SelectedRow;
    public event EventHandler AfterClickAcceptButton;
    public enum WorkingStatus
    {
        DangLamViec,
        DaNghiViec,
        TatCa
    }
    public bool GetDataFromHoSo { get; set; }
    public WorkingStatus DisplayWorkingStatus { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfLoadDatafromHoso.Text = GetDataFromHoSo.ToString();
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }

    protected void btnAddEmployee_Click(object sender, DirectEventArgs e)
    {
        if (chkEmployeeRowSelection.SelectedRows.Count() == 0)
        {
            wdChooseUser.Hide();
            Dialog.ShowNotification("Thông báo","Bạn phải chọn ít nhất một nhân viên");
            return;
        }
        SelectedRow = chkEmployeeRowSelection.SelectedRows;
        wdChooseUser.Hide();
        if (AfterClickAcceptButton != null)
        {
            //string idList = "";
            //foreach (var item in chkEmployeeRowSelection.SelectedRows)
            //{
            //    idList += item.RecordID + ",";
            //}
            AfterClickAcceptButton(SelectedRow, null);
        }
    }


   
    //private void LoadPhong2(string MaDonVi, Ext.Net.TreeNode DvNode)
    //{
    //    List<DM_PHONG> roomList = new DM_PHONGController().GetByDonViID(MaDonVi);
    //    foreach (DM_PHONG room in roomList)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(room.TEN_PHONG);
    //        node.Icon = Ext.Net.Icon.Folder;
    //        DvNode.Nodes.Add(node);
    //        node.Expanded = true;
    //        node.NodeID = room.MA_PHONG;
    //        node.Listeners.Click.Handler = "#{hdfMaPhong}.setValue('" + node.NodeID + "');#{DropDownField1}.setValue('" + room.TEN_PHONG + "');#{hdfMaDonVi}.setValue('');#{hdfMaTo}.setValue('');#{Store3}.reload();";
    //        LoadTo2(room.MA_PHONG, node);
    //    }
    //}

    //private void LoadTo2(string Maphong, Ext.Net.TreeNode PhongNode)
    //{
    //    List<DM_TO> roomList = new DM_TOController().GetByRoomID(Maphong);
    //    foreach (DM_TO group in roomList)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(group.TEN_TO);
    //        node.NodeID = group.MA_TO;
    //        PhongNode.Nodes.Add(node);
    //        node.Expanded = true;
    //        node.Listeners.Click.Handler = "#{hdfMaTo}.setValue('" + node.NodeID + "');#{DropDownField1}.setValue('" + group.TEN_TO + "');#{hdfMaDonVi}.setValue('');#{hdfMaPhong}.setValue('');#{Store3}.reload();";
    //    }
    //}
}