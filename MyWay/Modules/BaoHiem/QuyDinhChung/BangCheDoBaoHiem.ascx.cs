using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;

public partial class Modules_BaoHiem_QuyDinhChung_BangCheDoBaoHiem : UserControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            grp_nhombhdcd.Reload();
        }
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        BHCHEDOBAOHIEMInfo obj = new BHCHEDOBAOHIEMInfo();
        BHCHEDOBAOHIEMController ctr = new BHCHEDOBAOHIEMController();

        if (!string.IsNullOrEmpty(cboCheDoBH.Text))
            obj.ParentID = Convert.ToInt32(cboCheDoBH.Value);
        obj.MaCheDoBaohiem = txtMaCheDoBaohiem.Text;
        obj.TenCheDoBaoHiem = txtTenCheDoBaoHiem.Text;
        obj.UserID = CurrentUser.ID;
        obj.DateCreate = DateTime.Now;
        obj.MaDonVi = Session["MaDonVi"].ToString();
        if (e.ExtraParams["Command"] == "Edit")
        {
            obj.IDCheDoBaoHiem = Convert.ToInt32(hdfRecordID.Text);
            //obj.IDCheDoBaoHiem = Convert.ToInt32(hdfIdcha_edit.Text);
            ctr.Update(obj);
            wdAddWindow.Hide();
            hdfIdcha_edit.Text = "";
        }
        else
        {
            if (cboCheDoBH.Value.ToString() == "0")
            {
                obj.ParentID = 0;
            }
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("GetCheDoBaoHiem_MaCheDoBaoHiem", "@MaCheDoBaoHiem", txtMaCheDoBaohiem.Text);
            if (dt.Rows.Count > 0)
            {
                X.MessageBox.Alert("Thông báo", "Mã chế độ bảo hiểm đã tồn tại").Show();
                txtMaCheDoBaohiem.Focus();
                return;
            }
            else
            {
                ctr.Insert(obj);
                cboCheDoBH.Reset();
                txtMaCheDoBaohiem.Reset();
                txtTenCheDoBaoHiem.Reset();
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
        }
        GridPanel1.Reload();
    }
    protected void Store_cboCheDoBH_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        //int a;
        //Store_ddfCheDoNghi.DataSource = new CheDoBaoHiemController().GetAll(Session["MaDonVi"].ToString(),out a);
        //Store_ddfCheDoNghi.DataBind();
        LoadCha(-2);
    }
    public void LoadCha(int idchedobh)
    {
        List<CheDoBaoHiemInfo> lists = new CheDoBaoHiemController().GetbyParentID(0, -1);
        List<object> obj = new List<object>();
        // obj.Add(new { IDCheDoBaoHiem = "0", TenCheDoBaoHiem = "Là gốc" });

        foreach (CheDoBaoHiemInfo info in lists)
        {
            if (info.ParentID == 0)
            {
                obj.Add(new { IDCheDoBaoHiem = info.IDCheDoBaoHiem, TenCheDoBaoHiem = info.TenCheDoBaoHiem });
                obj = LoadMenuCon(obj, info.IDCheDoBaoHiem, 1, idchedobh);
            }
            if (idchedobh == info.IDCheDoBaoHiem)
            {
                cboCheDoBH.SelectedItem.Value = info.IDCheDoBaoHiem.ToString();
                cboCheDoBH.SelectedItem.Text = info.TenCheDoBaoHiem;
                break;
            }
        }
        Store_cboCheDoBH.DataSource = obj;
        Store_cboCheDoBH.DataBind();
    }
    private List<object> LoadMenuCon(List<object> obj, int menuID, int k, int idchedobh)
    {
        List<CheDoBaoHiemInfo> lists = new CheDoBaoHiemController().GetbyParentID(menuID, -1);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                //tmp += "- ";
                // obj.Add(new { IDCheDoBaoHiem = item.IDCheDoBaoHiem, TenCheDoBaoHiem = tmp + item.TenCheDoBaoHiem });
                if (idchedobh == item.IDCheDoBaoHiem)
                {
                    
                   DataTable list1 = new BHCHEDOBAOHIEMController().GetByPrkey( item.ParentID);
                   for (int h = 0; h < list1.Rows.Count; h++)
                   {
                       
                       cboCheDoBH.SelectedItem.Text = list1.Rows[h]["TenCheDoBaoHiem"].ToString();
                       cboCheDoBH.SelectedItem.Value = item.IDCheDoBaoHiem.ToString();
                       
                   }
                    break;
                }
            obj = LoadMenuCon(obj, item.IDCheDoBaoHiem, k + 1, idchedobh);

        }
        return obj;
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new BHCHEDOBAOHIEMController().GetByPrkey(Convert.ToInt32(txtmaloaihdcoppy.Text));
            if (record.Rows.Count > 0)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
            }
            else
            {
                record = new BHCHEDOBAOHIEMController().GetByPrkey(Convert.ToInt32(hdfRecordID.Text));
                record.Rows[0]["IDCheDoBaoHiem"] = int.Parse(txtmaloaihdcoppy.Text);
                BHCHEDOBAOHIEMInfo item = new BHCHEDOBAOHIEMInfo()
                {
                    IDCheDoBaoHiem = int.Parse(record.Rows[0]["IDCheDoBaoHiem"].ToString()),
                    ParentID = int.Parse(record.Rows[0]["ParentID"].ToString()),
                    MaCheDoBaohiem = record.Rows[0]["MaCheDoBaohiem"].ToString(),
                    TenCheDoBaoHiem = record.Rows[0]["TenCheDoBaoHiem"].ToString(),
                    UserID = int.Parse(record.Rows[0]["UserID"].ToString()),
                    DateCreate = DateTime.Parse(record.Rows[0]["DateCreate"].ToString()),
                    MaDonVi = record.Rows[0]["MaDonVi"].ToString(),
                };
                new BHCHEDOBAOHIEMController().Insert(item);
            }
            GridPanel1.Reload();
            wdInputNewPrimaryKey.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }

    }

    [DirectMethod]
    public void DeleteRecord(string pr_key)
    {
        try
        {
            DataTable dt = new BHCHEDOBAOHIEMController().GetByParentId(Convert.ToInt32(pr_key));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ParentID"].ToString() == pr_key)
                    {
                        new BHCHEDOBAOHIEMController().DeleteByPrkey(Convert.ToInt32(dt.Rows[i]["IDCheDoBaoHiem"]));
                    }
                }
            }
            else
            {
                new BHCHEDOBAOHIEMController().DeleteByPrkey(Convert.ToInt32(pr_key));
                hdfRecordID.Text = "";
            }
        }
        catch
        {
            X.MessageBox.Alert("Thông báo", "Mã chế độ bảo hiểm đang được sử dụng").Show();
        }
        GridPanel1.Reload();
    }

    [DirectMethod]
    public void NhanDoiDuLieuTuTang()
    {
        string pr_key = hdfRecordID.Text;
        new BHCHEDOBAOHIEMController().DuplucateByPrkey(Convert.ToInt32(pr_key));
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        try
        {
            wdAddWindow.Icon = Icon.Add;
            wdAddWindow.Title = "Thêm mới chế độ bảo hiểm";
            hdfCommand.SetValue("");
            txtMaCheDoBaohiem.Reset();
            txtTenCheDoBaoHiem.Reset(); cboCheDoBH.Reset();
        }
        catch
        {
        }

    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            wdAddWindow.Show();
            wdAddWindow.Title = "Sửa chế độ bảo hiểm";
            wdAddWindow.Icon = Icon.Pencil;
            if (!string.IsNullOrEmpty("hdfRecordID"))
            {
                DataTable dt = new BHCHEDOBAOHIEMController().GetByPrkey(Convert.ToInt32(hdfRecordID.Text));
                //hdfIdcha_edit.Text = dt.Rows[0]["IDCheDoBaohiem"].ToString();
                txtTenCheDoBaoHiem.Text = dt.Rows[0]["TenCheDoBaoHiem"].ToString();
                txtMaCheDoBaohiem.Text = dt.Rows[0]["MaCheDoBaohiem"].ToString();
                //cboCheDoBH.Text = dt.Rows[0]["TenCheDoBaoHiem"].ToString();
                //cboCheDoBH.Value = dt.Rows[0]["IDCheDoBaohiem"].ToString();
                cboCheDoBH.SetValue(dt.Rows[0]["ParentId"].ToString()); 
               // LoadCha(Convert.ToInt32(dt.Rows[0]["IDCheDoBaoHiem"]));
            }
        }
        catch
        {

        }

    }
    // xử lý danh mục cha bên trái west
    protected void Store_CheDoBaoHiem_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        Store_CheDoBaoHiem.DataSource = new BHCHEDOBAOHIEMController().GetByParentId(0);
        Store_CheDoBaoHiem.DataBind();
    }
    protected void btnEditCha_Click(object sender, DirectEventArgs e)
    {
        try
        {
            wdNhomCheDoBH.Show();
            wdNhomCheDoBH.Title = "Sửa nhóm chế độ bảo hiểm";
            wdNhomCheDoBH.Icon = Icon.Pencil;
            if (!string.IsNullOrEmpty(hdfNhomCha.Text))
            {
                DataTable dt = new BHCHEDOBAOHIEMController().GetByPrkey(Convert.ToInt32(hdfNhomCha.Text));
                txtcha_machedobh.Text = dt.Rows[0]["MaCheDoBaohiem"].ToString();
                txtcha_tenchedobh.Text = dt.Rows[0]["TenCheDoBaoHiem"].ToString();
            }
        }
        catch
        {

        }

    }
    protected void btnCapNhat_Click_Cha(object sender, DirectEventArgs e)
    {
        BHCHEDOBAOHIEMInfo obj = new BHCHEDOBAOHIEMInfo();
        BHCHEDOBAOHIEMController ctr = new BHCHEDOBAOHIEMController();
        obj.ParentID = 0;
        obj.MaCheDoBaohiem = txtcha_machedobh.Text;
        obj.TenCheDoBaoHiem = txtcha_tenchedobh.Text;
        obj.UserID = CurrentUser.ID;
        obj.DateCreate = DateTime.Now;
        obj.MaDonVi = Session["MaDonVi"].ToString();
        if (e.ExtraParams["Command"] == "Edit")
        {
            obj.IDCheDoBaoHiem = Convert.ToInt32(hdfNhomCha.Text);
            ctr.Update(obj);
            wdNhomCheDoBH.Hide();
        }
        else
        {
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("GetCheDoBaoHiem_MaCheDoBaoHiem", "@MaCheDoBaoHiem", txtcha_machedobh.Text);
            if (dt.Rows.Count > 0)
            {
                X.MessageBox.Alert("Thông báo", "Mã chế độ bảo hiểm đã tồn tại").Show();
                txtcha_machedobh.Focus();
                return;
            }
            else
            {
                ctr.Insert(obj);
                txtcha_machedobh.Reset();
                txtcha_tenchedobh.Reset();

            }
        }
        if (e.ExtraParams["Close"] == "True")
        {
            wdNhomCheDoBH.Hide();
        }
        grp_nhombhdcd.Reload();
    }
}