using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;

public partial class Modules_RoleListDropDownField_ucRoleList : System.Web.UI.UserControl
{
    public event EventHandler AfterClickAcceptButton;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            LoadRole(TreePanel1);
        }
    }

    protected void btnAccept_Click(object sender, DirectEventArgs e)
    {
        wdRoleList.Hide();
        if (AfterClickAcceptButton != null)
        {
            AfterClickAcceptButton(txtRoleId.Text,null);
        }
    }

    private void LoadRole(TreePanel TreePanelRole)
    {
        List<RoleInfo> RoleList = RoleController.GetInstance().GetAllRoles(0, 0,Session["MaDonVi"].ToString());
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        TreePanelRole.Root.Clear();
        TreePanelRole.Root.Add(root);
        foreach (RoleInfo ParentRole in RoleList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(ParentRole.RoleName);
            root.Nodes.Add(node);
            node.Checked = ThreeStateBool.False;
            node.Expanded = true;
            node.NodeID = ParentRole.ID.ToString();
            List<RoleInfo> ChildRoles = RoleController.GetInstance().GetAllRoles(ParentRole.ID, 0, Session["MaDonVi"].ToString());
            LoadChildRoles(ref node, ChildRoles);
        }
    }

    private void LoadChildRoles(ref Ext.Net.TreeNode root, List<RoleInfo> RoleList)
    {
        foreach (RoleInfo item in RoleList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.RoleName);
            root.Nodes.Add(node);
            node.Checked = ThreeStateBool.False;
            node.Expanded = true;
            node.NodeID = item.ID.ToString();
            List<RoleInfo> ChildRoles = RoleController.GetInstance().GetAllRoles(item.ID, 0, Session["MaDonVi"].ToString());
            LoadChildRoles(ref node, ChildRoles);
        }
    }
}