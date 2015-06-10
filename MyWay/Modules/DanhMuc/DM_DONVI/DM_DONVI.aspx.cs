using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.Data;
using ExtMessage;
using SoftCore.Security;
using System.Data.SqlClient;

public partial class Modules_DanhMuc_DM_DONVI_DM_DONVI : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region load đơn vị theo cấp
    protected void cbxDonViCapCha_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<DAL.DM_DONVI> lists = new DM_DONVIController().GetByParentID("0");
        List<object> obj = new List<object>();
        obj.Add(new { MA_DONVI = "0", TEN_DONVI = "Đơn vị cấp cao nhất" });
        foreach (var info in lists)
        {
            obj.Add(new { MA_DONVI = info.MA_DONVI, TEN_DONVI = info.TEN_DONVI });
            obj = LoadMenuCon(obj, info.MA_DONVI, 1);
        }
        cbxDonViCapCha_Store.DataSource = obj;
        cbxDonViCapCha_Store.DataBind();
    }

    private List<object> LoadMenuCon(List<object> obj, string parentID, int k)
    {
        List<DAL.DM_DONVI> lists = new DM_DONVIController().GetByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "-- ";
            obj.Add(new { MA_DONVI = item.MA_DONVI, TEN_DONVI = tmp + item.TEN_DONVI });
            obj = LoadMenuCon(obj, item.MA_DONVI, k + 1);
        }
        return obj;
    }
    #endregion

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Title = "Thêm mới một đơn vị";
        wdAddWindow.Icon = Icon.Add;
        txtMaDonVi.Disabled = false;
    }

    [DirectMethod]
    public void DeleteNode(string maDV)
    {
        try
        {
            DM_DONVIController ctr = new DM_DONVIController();
            // xóa tất cả các con rồi xóa cha
            List<DAL.DM_DONVI> dv = ctr.GetByParentID(maDV);

            foreach (var item in dv)
            {
                if (item.PARENT_ID == "0")
                    break;
                if (!string.IsNullOrEmpty(item.MA_DONVI))
                    DeleteNode(item.MA_DONVI);
            }
            ctr.Delete(maDV);
            tgDonVi.ReloadAsyncNode("0", new JFunction());
        }
        catch (SqlException sqlEx)
        {
            if (sqlEx.Number==ErrorNumber.DATA_IS_INUSED_IN_OTHER_TABLE)
            {
                X.Msg.Alert("Có lỗi xảy ra","Không thể xóa được do có dữ liệu khác tham chiếu tới !").Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DM_DONVI dv = new DAL.DM_DONVI();
            if (e.ExtraParams["Command"] == "Edit")
            {
                dv = new DM_DONVIController().GetById(hdfRecordID.Text);
            }
            if (txtMaDonVi.Text == "")
                dv.MA_DONVI = hdfRecordID.Text;
            else
                dv.MA_DONVI = txtMaDonVi.Text.Trim();
            dv.TEN_TAT = txtTenVietTat.Text;
            dv.TEN_DONVI = txtTenDonVi.Text;
            dv.TEN_DONVI_EN = txtTenTienAnh.Text;
            dv.DIA_CHI = txtDiaChi.Text;
            if (cbxDonViCapCha.SelectedItem.Value != null)
            {
                dv.PARENT_ID = cbxDonViCapCha.SelectedItem.Value;
            }
            dv.DIEN_THOAI = txtSoDT.Text;
            dv.FAX = txtFax.Text;
            dv.GIAM_DOC = txtGiamDoc.Text;
            dv.KE_TOAN_TRUONG = txtKeToanTruong.Text;
            dv.MA_SO_THUE = txtMaSoThue.Text;
            dv.SO_TAI_KHOAN = txtSoTaiKhoan.Text;
            dv.NGAN_HANG = txtNganHang.Text;
            dv.DATE_CREATE = DateTime.Now;
            dv.USERNAME = CurrentUser.DisplayName;

            if (e.ExtraParams["Command"] == "Edit")
            {
                new DM_DONVIController().Update(dv);
                //Dialog.ShowNotification("Cập nhật thành công thông tin đơn vị");
                Notification.Show(new NotificationConfig
                {
                    Title = "Thông báo từ hệ thống",
                    AlignCfg = new NotificationAlignConfig()
                    {
                        ElementAnchor = AnchorPoint.BottomRight,
                        TargetAnchor = AnchorPoint.BottomRight,
                    },
                    Icon = Ext.Net.Icon.Information,
                    AutoHide = true,
                    HideDelay = 2000,
                    Closable = true,
                    Html = "Cập nhật thành công thông tin đơn vị",
                    Modal = false,
                });
                wdAddWindow.Hide();
                //RM.RegisterClientScriptBlock("rlst1", "tgDonVi.getRootNode().reload();");
                tgDonVi.ReloadAsyncNode("0", new JFunction());
            }
            else
            {
                // kiểm tra sự tồn tại của mã đơn vị
                DAL.DM_DONVI tmp = new DM_DONVIController().GetById(txtMaDonVi.Text);
                if (tmp != null)
                {
                    Dialog.ShowNotification("Mã đơn vị đã tồn tại. Bạn vui lòng chọn một mã khác");
                    return;
                }
                new DM_DONVIController().Insert(dv);
                //Dialog.ShowNotification("Thêm mới đơn vị thành công");
                Notification.Show(new NotificationConfig
                {
                    Title = "Thông báo từ hệ thống",
                    AlignCfg = new NotificationAlignConfig()
                    {
                        ElementAnchor = AnchorPoint.BottomRight,
                        TargetAnchor = AnchorPoint.BottomRight,
                    },
                    Icon = Ext.Net.Icon.Information,
                    AutoHide = true,
                    HideDelay = 2000,
                    Closable = true,
                    Html = "Thêm mới đơn vị thành công",
                    Modal = false,
                });
                if (e.ExtraParams["Closed"] == "True")
                {
                    wdAddWindow.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rlst2", "ResetWindow();");
                }
                tgDonVi.ReloadAsyncNode("0", new JFunction());
            }

        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfRecordID.Text == "")
            {
                Dialog.ShowNotification("Không tìm thấy đơn vị");
                return;
            }
            DAL.DM_DONVI dv = new DM_DONVIController().GetById(hdfRecordID.Text);
            if (dv == null)
            {
                Dialog.ShowNotification("Không tìm thấy đơn vị");
                return;
            }
            txtMaDonVi.Text = dv.MA_DONVI;
            txtMaDonVi.Disabled = true;
            txtTenVietTat.Text = dv.TEN_TAT;
            txtTenDonVi.Text = dv.TEN_DONVI;
            txtTenTienAnh.Text = dv.TEN_DONVI_EN;
            txtDiaChi.Text = dv.DIA_CHI;
            cbxDonViCapCha.SetValue(dv.PARENT_ID);
            txtSoDT.Text = dv.DIEN_THOAI;
            txtFax.Text = dv.FAX;
            txtGiamDoc.Text = dv.GIAM_DOC;
            txtKeToanTruong.Text = dv.KE_TOAN_TRUONG;
            txtMaSoThue.Text = dv.MA_SO_THUE;
            txtSoTaiKhoan.Text = dv.SO_TAI_KHOAN;
            txtNganHang.Text = dv.NGAN_HANG;

            wdAddWindow.Title = "Sửa thông tin đơn vị";
            wdAddWindow.Icon = Icon.Pencil;
            RM.RegisterClientScriptBlock("wds", "wdAddWindow.show();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // kiểm tra sự tồn tại của mã mới
            DAL.DM_DONVI dv = new DM_DONVIController().GetById(txtmacoppy.Text);
            if (dv != null)
            {
                Dialog.ShowNotification("Mã đơn vị đã tồn tại");
                return;
            }
            // lấy thông tin đơn vị hiện tại
            dv = new DM_DONVIController().GetById(hdfRecordID.Text);
            // tạo một đơn vị mới
            DAL.DM_DONVI tmp = new DAL.DM_DONVI()
            {
                MA_DONVI = txtmacoppy.Text,
                DATE_CREATE = DateTime.Now,
                DIA_CHI = dv.DIA_CHI,
                DIEN_THOAI = dv.DIEN_THOAI,
                FAX = dv.FAX,
                GIAM_DOC = dv.GIAM_DOC,
                KE_TOAN_TRUONG = dv.KE_TOAN_TRUONG,
                MA_SO_THUE = dv.MA_SO_THUE,
                NGAN_HANG = dv.NGAN_HANG,
                ORDER = dv.ORDER,
                PARENT_ID = dv.PARENT_ID,
                SO_TAI_KHOAN = dv.SO_TAI_KHOAN,
                TEN_DONVI = dv.TEN_DONVI,
                TEN_DONVI_EN = dv.TEN_DONVI_EN,
                TEN_TAT = dv.TEN_TAT,
                USERNAME = dv.USERNAME
            };
            // insert đơn vị vào csdl
            new DM_DONVIController().Insert(tmp);

            tgDonVi.ReloadAsyncNode("0", new JFunction());
            wdAddWindow.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    protected void btnSort_Click(object sender, DirectEventArgs e)
    {
        List<DAL.DM_DONVI> listChilds = new DM_DONVIController().GetByParentID(hdfRecordID.Text);
        string menuStr = "";
        foreach (var menu in listChilds)
        {
            menuStr = string.Concat(menuStr, string.Format("<li id='{0}'>{1}</li>", menu.MA_DONVI.ToString(), menu.TEN_DONVI));
        }
        string output = @" <div class='demo'>
                            <ul id='sortable'>
                             {0}
                            </ul>
                        </div>";

        string script = @" $(function () {
                                $('#sortable').sortable();
                                $('#sortable').disableSelection();
                            });";

        lblOutput.Html = string.Format(output, menuStr);
        wdSortAscending.Show();
        RM.RegisterClientScriptBlock("load", script);
    }

    /// <summary>
    /// cập nhật lại thứ tự của đơn vị
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveOrderedMenu_Click(object sender, DirectEventArgs e)
    {
        string[] childID = e.ExtraParams["order"].Split(',');
        short count = 0;
        foreach (string item in childID)
        {
            new DM_DONVIController().UpdateOrder(item, count);
            count++;
        }
        wdSortAscending.Hide();
        tgDonVi.ReloadAsyncNode("0", new JFunction());
    }

    [DirectMethod]
    public string NodeLoad(string nodeID)
    {
        try
        {
            Ext.Net.TreeNodeCollection nodes = new Ext.Net.TreeNodeCollection();

            List<DAL.DM_DONVI> list = new DM_DONVIController().GetByAll(txtSearch.Text, nodeID);

            foreach (var item in list)
            {
                AsyncTreeNode asyncNode = new AsyncTreeNode();
                asyncNode.Text = item.TEN_DONVI;
                asyncNode.NodeID = item.MA_DONVI;
                asyncNode.Icon = Icon.House;
                asyncNode.CustomAttributes.Add(new ConfigItem("MA_DONVI", item.MA_DONVI, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("TEN_DONVI", item.TEN_DONVI, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("TEN_TAT", item.TEN_TAT, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("TEN_DONVI_EN", item.TEN_DONVI_EN, ParameterMode.Value));
                asyncNode.CustomAttributes.Add(new ConfigItem("DIA_CHI", item.DIA_CHI, ParameterMode.Value));
                asyncNode.Expanded = true;
                nodes.Add(asyncNode);
            }

            return nodes.ToJson();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
            return null;
        }
    }
}