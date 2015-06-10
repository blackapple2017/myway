using DataController;
using Ext.Net;
using ExtMessage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_VTHH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Ext.Net.X.IsAjaxRequest)
        {
            hdf_MA_DONVI.Text = Session["MaDonVi"].ToString();
            txtx_MA_DONVI.Text = Session["MaDonVi"].ToString();
            LoadFortuneGroup(treeFortuneGroup.Root);
        }
    }

    private Ext.Net.TreeNodeCollection LoadFortuneGroup(Ext.Net.TreeNodeCollection rootNode)
    {
        if (rootNode == null)
        {
            rootNode = new Ext.Net.TreeNodeCollection();
        }

        DM_VTHHController controller = new DM_VTHHController();
        List<DAL.DM_NHOM_VTHH> dvList = controller.GetFortuneGroupByParentID("-");
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        root.Expanded = true;
        Ext.Net.TreeNode all = new Ext.Net.TreeNode()
        {
            Text = "Danh sách nhóm",
            NodeID = "-1",
            Icon = Ext.Net.Icon.Group,
            Expanded = true
        };
        all.Listeners.Click.Handler = "hdfNodeID.setValue('-1');btnEditGroup.enable();btnDeleteGroup.enable();#{PagingToolbar1}.pageIndex=0;#{PagingToolbar1}.doLoad();";
        root.Nodes.Add(all);
        foreach (DAL.DM_NHOM_VTHH dv in dvList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_NHOM_VTHH);// + "(" + dv.MA_NHOM_VTHH + ")");
            //  node.Icon = Ext.Net.Icon.Folder;
            all.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA_NHOM_VTHH;
            LoadChildFortunes(dv.MA_NHOM_VTHH, node);
            node.Listeners.Click.Handler = "hdfParentNodeID.setValue('" + dv.PARENTID + "');hdfNodeID.setValue('" + dv.MA_NHOM_VTHH + "');btnEditGroup.enable();btnDeleteGroup.enable();#{PagingToolbar1}.pageIndex=0;#{PagingToolbar1}.doLoad();";
        }
        //   treeFortuneGroup.Root.Clear();
        //  treeFortuneGroup.Root.Add(root);
        rootNode.Add(root);
        return rootNode;
    }

    private void LoadChildFortunes(string maNhom, Ext.Net.TreeNode node)
    {
        List<DAL.DM_NHOM_VTHH> childList = new DM_VTHHController().GetFortuneGroupByParentID(maNhom);

        foreach (DAL.DM_NHOM_VTHH dv in childList)
        {
            Ext.Net.TreeNode child = new Ext.Net.TreeNode(dv.TEN_NHOM_VTHH);// + "(" + dv.MA_NHOM_VTHH + ")");
            //    child.Icon = Ext.Net.Icon.Folder;
            node.Nodes.Add(child);
            child.Expanded = true;
            child.NodeID = dv.MA_NHOM_VTHH;
            LoadChildFortunes(dv.MA_NHOM_VTHH, child);
            child.Listeners.Click.Handler = "hdfParentNodeID.setValue('" + dv.PARENTID + "');hdfNodeID.setValue('" + dv.MA_NHOM_VTHH + "');btnEditGroup.enable();btnDeleteGroup.enable();#{PagingToolbar1}.pageIndex=0;#{PagingToolbar1}.doLoad();";
        }
    }

    [DirectMethod]
    public string RefreshMenu()
    {
        Ext.Net.TreeNodeCollection nodes = this.LoadFortuneGroup(null);

        return nodes.ToJson();
    }

    protected void btnUpdateGroup_Click(object sender, DirectEventArgs e)
    {
        try
        {
            bool isSuccess = false;
            if (e.ExtraParams["Command"] == "Update")
            {
                isSuccess = new DALController().Update(wdThemNhomTaiSan, "DM_NHOM_VTHH", hdfNodeID.Text);
            }
            else
                isSuccess = new DALController().Add(wdThemNhomTaiSan, "DM_NHOM_VTHH");
            if (isSuccess)
            {
                Dialog.ShowNotification("Cập nhật thành công");
                wdThemNhomTaiSan.Hide();
                RM.RegisterClientScriptBlock("RefreshTree", "refreshTree(#{treeFortuneGroup});Storecb_MA_NHOM_VTHH.reload();btnEditGroup.disable();btnDeleteGroup.disable();");
            }
        }
        catch (SqlException sqlEx)
        {
            if (sqlEx.Number == ErrorNumber.DUPLICATE_PRIMARY_KEY)
            {
                X.Msg.Alert("Có lỗi xảy ra", "Mã nhóm tài sản bị trùng, hãy nhập mã khác").Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }

    protected void btnDeleteGroup_Click(object sender, DirectEventArgs e)
    {
        string idList = CommonUtil.GetInstance().GetChildIDListFromParentID("DM_NHOM_VTHH", hdfNodeID.Text, "MA_NHOM_VTHH", "PARENTID") + hdfNodeID.Text;

        try
        {
            idList = "'" + idList.Replace(",", "','") + "'";
            DataHandler.GetInstance().ExecuteNonQuery("DeleteNhomVTHH", "@idList", idList);
            RM.RegisterClientScriptBlock("RefreshTree", "refreshTree(#{treeFortuneGroup});Storecb_MA_NHOM_VTHH.reload();btnEditGroup.disable();btnDeleteGroup.disable();");

        }
        catch (SqlException sqlEx)
        {
            if (sqlEx.Number == ErrorNumber.DATA_IS_INUSED_IN_OTHER_TABLE)
            X.Msg.Alert("Có lỗi xảy ra", "Không thể xóa được do có tài sản đang nằm trong nhóm này !").Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }

    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (e.ExtraParams["Command"] == "Update")
            {
                if (new DALController().Update(wdCapNhatTaiSan, "DM_VTHH", txt_MA_VTHH.Text))
                {
                    Dialog.ShowNotification("Cập nhật thành công");
                    wdCapNhatTaiSan.Hide();
                    GridPanel1.Reload();
                }
            }
            else
            {
                if (new DALController().Add(wdCapNhatTaiSan, "DM_VTHH"))
                {
                    GridPanel1.Reload();
                    Dialog.ShowNotification("Thêm mới thành công");
                    if (e.ExtraParams["Close"] == "True")
                    {
                        wdCapNhatTaiSan.Hide();
                    }
                    else
                    {
                        RM.RegisterClientScriptBlock("validateForm", "validateForm()");
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            if (ex.Number == ErrorNumber.DUPLICATE_PRIMARY_KEY)
            {
                X.Msg.Alert("Có lỗi xảy ra", "Bị trùng mã tài sản").Show();
                txt_MA_VTHH.Focus();
            }
            else
                X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }

    protected void Storecb_MA_DONVITINH_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            Storecb_MA_DONVITINH.DataSource = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT MA_DVT,TEN_DVT FROM DM_DVT");
            Storecb_MA_DONVITINH.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }



    protected void Storecb_MA_NHOM_VTHH_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            DM_VTHHController controller = new DM_VTHHController();
            List<DM_NHOM_VTHHInfo> data = new List<DM_NHOM_VTHHInfo>();
            foreach (var item in controller.GetFortuneGroupByParentID("-"))
            {
                data.Add(new DM_NHOM_VTHHInfo()
                {
                    TEN_NHOM_VTHH = item.TEN_NHOM_VTHH,
                    MA_NHOM_VTHH = item.MA_NHOM_VTHH
                });
                GetChildCategories(ref data, item.MA_NHOM_VTHH, "----");
            }
            Storecb_MA_NHOM_VTHH.DataSource = data;
            Storecb_MA_NHOM_VTHH.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }

    protected void GridPanel1_RowDblClick(object sender, DirectEventArgs e)
    {
        try
        {
            string id = "";
            foreach (var a in RowSelectionModel1.SelectedRows)
            {
                id = a.RecordID;
            }
            DAL.DM_VTHH item = new DM_VTHHController().GetByID(id);
            txt_GHI_CHU.Text = item.GHI_CHU;
            txt_MA_VTHH.Text = item.MA_VTHH;
            if (item.NGUYEN_GIA.Value > 0)
                txt_NGUYEN_GIA.Text = item.NGUYEN_GIA.Value.ToString();
            txt_TEN_VTHH.Text = item.TEN_VTHH;
            cb_MA_DONVITINH.SetValue(item.MA_DONVITINH);
            cb_MA_NHOM_VTHH.SetValue(item.MA_NHOM_VTHH);
            if (item.SOTHANG_KHAUHAO.HasValue)
                txt_SOTHANG_KHAUHAO.Value = item.SOTHANG_KHAUHAO.Value;
            wdCapNhatTaiSan.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
        }
    }

    private void GetChildCategories(ref List<DM_NHOM_VTHHInfo> data, string p, string separator)
    {
        DM_VTHHController controller = new DM_VTHHController();
        foreach (var item in controller.GetFortuneGroupByParentID(p))
        {
            data.Add(new DM_NHOM_VTHHInfo()
            {
                TEN_NHOM_VTHH = separator + item.TEN_NHOM_VTHH,
                MA_NHOM_VTHH = item.MA_NHOM_VTHH
            });
            GetChildCategories(ref data, item.MA_NHOM_VTHH, separator + "----");
        }
    }

    protected void btnDeleteFortune_Click(object sender, DirectEventArgs e)
    {
        foreach (var item in RowSelectionModel1.SelectedRows)
        {
            try
            {
                new DALController().Delete("DM_VTHH", item.RecordID);
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number==ErrorNumber.DATA_IS_INUSED_IN_OTHER_TABLE)
                {
                    X.Msg.Alert("Có lỗi xảy ra","Dữ liệu đang được sử dụng nên không xóa được !").Show();
                }
                else
                    X.Msg.Alert("Có lỗi xảy ra", sqlex.Message.ToString()).Show();
            }
            catch (Exception ex)
            {
                X.Msg.Alert("Có lỗi xảy ra", ex.Message.ToString()).Show();
            }
        }
        GridPanel1.Reload();
        btnDeleteFortune.Disabled = true;
        btnEditFortune.Disabled = true;
    }
}