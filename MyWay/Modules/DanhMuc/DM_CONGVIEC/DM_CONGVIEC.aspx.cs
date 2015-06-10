using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using System.Data.SqlClient;

public partial class Modules_DanhMuc_DM_CONGVIEC : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        DM_CONGVIECInfo obj = new DM_CONGVIECInfo();
        DM_CONGVIECController ctr = new DM_CONGVIECController();
        obj.MA_CONGVIEC = txtMA_CONGVIEC.Text;
        obj.TEN_CONGVIEC = txtTEN_CONGVIEC.Text;
        obj.USERNAME = CurrentUser.ID.ToString();
        obj.DATE_CREATE = DateTime.Now;
        obj.MA_DONVI = Session["MaDonVi"].ToString();
        if (e.ExtraParams["Command"] == "Edit")
        {
            obj.MA_CONGVIEC = hdfRecordID.Text;
            ctr.Update(obj);
            wdAddWindow.Hide();
            //RM.RegisterClientScriptBlock("fd", string.Format("addUpdatedRecord('{0}', '{1}', '{2}', '{3}', '{4}')", txtMA_CONGVIEC.Text, txtTEN_CONGVIEC.Text, txtUSERNAME.Text, txtDATE_CREATE.Text, txtMA_DONVI.Text));
            GridPanel1.Reload();
        }
        else
        {
            DataTable record = new DM_CONGVIECController().GetByPrkey(obj.MA_CONGVIEC);
            if (record.Rows.Count > 0)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
                return;
            }
            ctr.Insert(obj);
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
            //RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}')", txtMA_CONGVIEC.Text, txtTEN_CONGVIEC.Text, txtUSERNAME.Text, txtDATE_CREATE.Text, txtMA_DONVI.Text));
            GridPanel1.Reload();
        }
        txtMA_CONGVIEC.Reset();
        txtTEN_CONGVIEC.Reset();
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new DM_CONGVIECController().GetByPrkey(txtmaloaihdcoppy.Text);
            if (record.Rows.Count > 0)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
            }
            else
            {
                record = new DM_CONGVIECController().GetByPrkey(hdfRecordID.Text);
                record.Rows[0]["MA_CONGVIEC"] = txtmaloaihdcoppy.Text;
                DM_CONGVIECInfo item = new DM_CONGVIECInfo()
                {
                    MA_CONGVIEC = record.Rows[0]["MA_CONGVIEC"].ToString(),
                    TEN_CONGVIEC = record.Rows[0]["TEN_CONGVIEC"].ToString(),
                    USERNAME = record.Rows[0]["USERNAME"].ToString(),
                    DATE_CREATE = DateTime.Parse(record.Rows[0]["DATE_CREATE"].ToString()),
                    MA_DONVI = record.Rows[0]["MA_DONVI"].ToString(),
                };
                new DM_CONGVIECController().Insert(item);
                //RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}')", item.MA_CONGVIEC, item.TEN_CONGVIEC, item.USERNAME, item.DATE_CREATE, item.MA_DONVI));
                GridPanel1.Reload();
            }
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
            new DM_CONGVIECController().DeleteByPrkey(pr_key);
            hdfRecordID.Text = "";
        }
        catch (SqlException sqlEx)
        {
            if (sqlEx.Number == 547)
            {
                X.MessageBox.Alert("Có lỗi xảy ra", "Dữ liệu đang được sử dụng nên không thể xóa !").Show();
            }
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
            //  GridPanel1.Reload();
        }
    }

    /*[DirectMethod]
    public void NhanDoiDuLieuTuTang()
    {
        {NhanDoiDuLieuTuTangCode}
    }*/

    public void mnuNhanDoiDuLieu_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new DM_CONGVIECController().GetByPrkey(hdfRecordID.Text);
            DM_CONGVIECInfo item = new DM_CONGVIECInfo()
            {
                TEN_CONGVIEC = record.Rows[0]["TEN_CONGVIEC"].ToString(),
                USERNAME = record.Rows[0]["USERNAME"].ToString(),
                DATE_CREATE = DateTime.Parse(record.Rows[0]["DATE_CREATE"].ToString()),
                MA_DONVI = record.Rows[0]["MA_DONVI"].ToString(),
            };
            item.MA_CONGVIEC = new DM_CONGVIECController().Insert(item);
            //RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}')", item.MA_CONGVIEC, item.TEN_CONGVIEC, item.USERNAME, item.DATE_CREATE, item.MA_DONVI));
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới công việc";
        hdfCommand.SetValue("");
        txtMA_CONGVIEC.Disabled = false;
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DataTable record = new DM_CONGVIECController().GetByPrkey(hdfRecordID.Text);
        txtMA_CONGVIEC.Text = record.Rows[0]["MA_CONGVIEC"].ToString();
        txtTEN_CONGVIEC.Text = record.Rows[0]["TEN_CONGVIEC"].ToString();
        txtMA_CONGVIEC.Disabled = true;
        hdfCommand.Text = "Update";
        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa thông tin công việc";
        wdAddWindow.Show();
    }
}
