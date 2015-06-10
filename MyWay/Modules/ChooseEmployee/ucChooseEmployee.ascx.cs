using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DAL;
using ExtMessage;
using SoftCore.Security;

public partial class Modules_ChooseEmployee_ucChooseEmployee : UserControlBase
{
    public SelectedRowCollection SelectedRow;
    public event EventHandler AfterClickAcceptButton;

    int _countRole = -1;
    string[] departmentList;
    public enum WorkingStatus
    {
        DangLamViec,
        DaNghiViec,
        TatCa
    }
    public bool ChiChonMotCanBo { get; set; }
    public WorkingStatus DisplayWorkingStatus { get; set; }
    public string DanhSachHoTen { get; private set; } //Chứa danh sách các họ tên được chọn, ngăn cách nhau bởi dấu phẩy
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            if (ChiChonMotCanBo != null && ChiChonMotCanBo != false)
            {
                EmployeeGrid.GetSelectionModel().Attributes.Add("SingleSelect", "true");
            }
            if (DisplayWorkingStatus == WorkingStatus.DangLamViec)
            {
                cbLoaiNhanVien.Items.Add(new Ext.Net.ListItem()
                {
                    Text = "Nhân viên đang làm việc",
                    Value = "False"
                });
            }
            else if (DisplayWorkingStatus == WorkingStatus.DaNghiViec)
            {
                cbLoaiNhanVien.Items.Add(new Ext.Net.ListItem()
                {
                    Text = "Nhân viên đã nghỉ việc",
                    Value = "True"
                });
            }
            else
            {
                cbLoaiNhanVien.Items.Add(new Ext.Net.ListItem()
                {
                    Text = "Nhân viên đang làm việc",
                    Value = "False"
                });
                cbLoaiNhanVien.Items.Add(new Ext.Net.ListItem()
                {
                    Text = "Nhân viên đã nghỉ việc",
                    Value = "True"
                });
            }
            //   LoadDonVi();
        }
    }

    protected void btnAddEmployee_Click(object sender, DirectEventArgs e)
    {
        if (chkEmployeeRowSelection.SelectedRows.Count() == 0)
        {
            wdChooseUser.Hide();
            X.MessageBox.Alert("Cảnh báo", "Bạn phải chọn ít nhất một nhân viên").Show();
            return;
        }
        SelectedRow = chkEmployeeRowSelection.SelectedRows;
        wdChooseUser.Hide();
        DanhSachHoTen = hdfHoTenCanBo.Text;
        if (AfterClickAcceptButton != null)
        {
            AfterClickAcceptButton(SelectedRow, null);
        }
    }


    //private void LoadDonVi()
    //{
    //    List<DM_DONVI> dvList;// = new UserController().GetDonViByUserID(CurrentUser.ID);
    //    dvList = new DM_DONVIController().GetByParentID("01");
    //    Ext.Net.TreeNode root = new Ext.Net.TreeNode();
    //    foreach (DM_DONVI dv in dvList)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
    //        node.Icon = Ext.Net.Icon.House;
    //        root.Nodes.Add(node);
    //        node.Expanded = true;
    //        node.NodeID = dv.MA_DONVI;
    //        LoadChildDepartment(dv.MA_DONVI, node);
    //        node.Listeners.Click.Handler = "#{hdfMaDonVi}.setValue('" + node.NodeID + "');#{DropDownField1}.setValue('" + dv.TEN_DONVI + "');#{Store3}.reload();";
    //    }

    // //   TreePanel2.Root.Clear();
    // //   TreePanel2.Root.Add(root);
    //}

    //private void LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    //{
    //    List<DM_DONVI> childList = new DM_DONVIController().GetByParentID(maDonVi);
    //    foreach (DM_DONVI dv in childList)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
    //        node.Icon = Ext.Net.Icon.Folder;
    //        DvNode.Nodes.Add(node);
    //        node.Expanded = true;
    //        node.NodeID = dv.MA_DONVI;
    //        node.Listeners.Click.Handler = "#{hdfMaDonVi}.setValue('" + node.NodeID + "');#{DropDownField1}.setValue('" + dv.TEN_DONVI + "');#{Store3}.reload();";
    //        LoadChildDepartment(dv.MA_DONVI, node);
    //    }
    //}

    protected void stDepartmentList_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
        if (departmentList == null || departmentList.Count() == 0)
        {
            departmentList = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, int.Parse("0" + hdfMenuID.Text)).Split(',');
        }
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            //if (departmentList.Contains(info.MA))
            obj.Add(new { MA = info.MA, TEN = info.TEN });
            //else
            //{
            //    obj.Add(new { MA = _countRole.ToString(), TEN = info.TEN });
            //    _countRole--;
            //}
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        stDepartmentList.DataSource = obj;
        stDepartmentList.DataBind();
    }

    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "----";
            //if (departmentList.Contains(item.MA))
            obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            //else
            //{
            //    obj.Add(new { MA = _countRole.ToString(), TEN = tmp + item.TEN });
            //    _countRole--;
            //}
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }
}