using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for BorderLayout
/// </summary>
/// 
namespace DTH
{
    public class BorderLayout
    {
        public BorderLayout()
        {
        }
        /// <summary>
        /// Đoạn javascript xử lý khi người dùng click vào tree node
        /// </summary>
        public string script { get; set; }
        public int menuID { get; set; }
        public const string nodeID = "#NodeID#";
        public const string noteText = "#NodeText#";
        private string departmentList = "";
        /// <summary>
        /// Add bộ lọc cơ cấu tổ chức vào westpanel 
        /// </summary>
        /// <param name="borderLayout"></param>
        /// <param name="currentUserID"></param>
        /// <param name="collapsed"></param>
        public void AddDepartmentList(Ext.Net.BorderLayout borderLayout, int currentUserID, bool collapsed)
        {
            Ext.Net.Panel panel = new Ext.Net.Panel()
            {
                Width = 220,
                Collapsed = collapsed,
                ID = "pnlCoCauToChuc",
                CtCls = "west-panel",
                Border = false,
                Layout = "BorderLayout",
                Title = "Cơ cấu tổ chức",
            };

            Ext.Net.TreePanel treePanel = new Ext.Net.TreePanel()
            {
                RootVisible = false,
                AutoScroll = true,
                ID = "TreeCoCauToChuc",
                Border = false,
                Region = Ext.Net.Region.Center,
                Header = false
            };
            Ext.Net.Toolbar tb = new Ext.Net.Toolbar();

            Ext.Net.Button btnExpand = new Ext.Net.Button()
            {
                Icon = Ext.Net.Icon.ArrowOut,
                Text = "Mở rộng"
            };
            btnExpand.Listeners.Click.Handler = "#{TreeCoCauToChuc}.expandAll();";

            Ext.Net.Button btnCollapse = new Ext.Net.Button()
            {
                Text = "Thu nhỏ",
                Icon = Ext.Net.Icon.ArrowIn
            };
            btnCollapse.Listeners.Click.Handler = "#{TreeCoCauToChuc}.collapseAll();";

            tb.Items.Add(btnExpand);
            tb.Items.Add(btnCollapse);
            treePanel.TopBar.Add(tb);

            borderLayout.West.Split = true;
            borderLayout.West.Collapsible = true;
            borderLayout.West.Items.Add(panel);
            panel.Items.Add(treePanel);
            AddData(treePanel, currentUserID);
        }
        /// <summary>
        /// Thêm dữ liệu vào tree
        /// </summary>
        /// <param name="treePanel"></param>
        /// <param name="currentUserID"></param>
        private void AddData(Ext.Net.TreePanel treePanel, int currentUserID)
        {
            departmentList = new DepartmentRoleController().GetMaBoPhanByRole(currentUserID, menuID);
            if (!string.IsNullOrEmpty(departmentList))
            {
                departmentList = "," + departmentList + ",";
            }
            LoadDonVi(treePanel, currentUserID);
        }


        private void LoadDonVi(Ext.Net.TreePanel TreeCoCauToChuc, int currentUserID)
        {
            //List<DM_DONVI> dvList = new UserController().GetDonViByUserID(currentUserID);
            List<DM_DONVI> dvList = new DM_DONVIController().GetByParentID("0");
            Ext.Net.TreeNode root = new Ext.Net.TreeNode();
            foreach (DM_DONVI dv in dvList)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
                node.Icon = Ext.Net.Icon.House;
                root.Nodes.Add(node);
                node.Expanded = true;
                node.NodeID = dv.MA_DONVI;
                if ((!departmentList.Contains("," + dv.MA_DONVI + ",") && !string.IsNullOrEmpty(departmentList)) || string.IsNullOrEmpty(departmentList))
                    node.Disabled = true;
                LoadChildDepartment(dv.MA_DONVI, node);
                if (!string.IsNullOrEmpty(script))
                {
                    node.Listeners.Click.Handler = script.Replace(nodeID, node.NodeID).Replace(noteText, node.Text);
                }
            }
            TreeCoCauToChuc.Root.Clear();
            TreeCoCauToChuc.Root.Add(root);
        }

        private void LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
        {
            List<DonViInfo> childList = new DM_DONVIController().GetEntityByParentID(maDonVi);
            foreach (DonViInfo dv in childList)
            {
                Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TenDonVi);
                node.Icon = Ext.Net.Icon.Folder;
                DvNode.Nodes.Add(node);
                node.Expanded = true;
                node.NodeID = dv.MaDonVi;
                if ((!departmentList.Contains("," + dv.MaDonVi + ",") && !string.IsNullOrEmpty(departmentList)) || string.IsNullOrEmpty(departmentList))
                    node.Disabled = true;
                if (!string.IsNullOrEmpty(script))
                {
                    node.Listeners.Click.Handler = script.Replace(nodeID, node.NodeID).Replace(noteText, node.Text);
                }
                LoadChildDepartment(dv.MaDonVi, node);
            }
        }
    }
}