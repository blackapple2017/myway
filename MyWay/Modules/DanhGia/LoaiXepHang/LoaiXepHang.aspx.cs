using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using Controller.DanhGia;

public partial class Modules_DanhGia_LoaiXepHang_LoaiXepHang : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            grp_HinhThucXepLoai.Reload();
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DM_LOAIXEPHANGInfo obj = new DM_LOAIXEPHANGInfo();
            LoaiXepHangController ctr = new LoaiXepHangController();
            if (e.ExtraParams["Command"] != "Edit")
            {
                DAL.DM_LOAIXEPHANG xh = ctr.GetByKyHieuXepHang(txtKiHieuXapHang.Text);
                if (xh != null)
                {
                    Dialog.ShowError("Mã xếp hạng đã tồn tại. Vui lòng nhập mã khác");
                    return;
                }
            }
            obj.KiHieuXepHang = txtKiHieuXapHang.Text;
            obj.TenXepHang = txtTenXepHang.Text;
            if (cbLoaiXepHang.SelectedItem != null)
                obj.ParentID = int.Parse(cbLoaiXepHang.SelectedItem.Value);
            obj.GhiChu = txtGhiChu.Text;
            obj.MaDonVi = Session["MaDonVi"].ToString();
            obj.TuDiem = decimal.Parse(txtTuDiem.Text.Replace('.', ','));
            obj.DenDiem = decimal.Parse(txtDenDiem.Text.Replace('.', ','));

            if (e.ExtraParams["Command"] == "Edit")
            {
                obj.MaXepHang = int.Parse(hdfMaXepHang.Text);
            }

            // Kiểm tra sự phù hợp của thang điểm mới
            string errStr = string.Empty;
            if (CheckValidRank(obj, out errStr) == false)
            {   // Không phù hợp
                X.Msg.Alert("Thông báo", errStr).Show();
            }
            else
            {   // Phù hợp
                if (e.ExtraParams["Command"] == "Edit")
                {
                    //obj.MaXepHang = int.Parse(hdfRecordID.Text);
                    ctr.Update(obj);
                    wdAddWindow.Hide();
                    GridPanel1.Reload();
                    grp_HinhThucXepLoai.Reload();
                }
                else
                {
                    ctr.Insert(obj);
                    if (e.ExtraParams["Close"] == "True")
                    {
                        wdAddWindow.Hide();
                    }
                    else
                    {
                        RM.RegisterClientScriptBlock("rl", "resetWindowHide();");
                    }
                    GridPanel1.Reload();
                    grp_HinhThucXepLoai.Reload();
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    private bool CheckValidRank(DM_LOAIXEPHANGInfo info, out string errorString)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        errorString = string.Empty;
        // lấy danh sách thang điểm có cùng ParentID
        DataTable table = new LoaiXepHangController().GetByParentIDWithoutMe(info.ParentID, maDv, info.MaXepHang != 0 ? info.MaXepHang : -1);
        foreach (DataRow item in table.Rows)
        {
            decimal tuDiem = decimal.Parse(item["TuDiem"].ToString());
            decimal denDiem = decimal.Parse(item["DenDiem"].ToString());
            if (tuDiem == -1 && denDiem == -1)  // thêm mới hình thức xếp hạng
                return true;
            if (info.TuDiem >= tuDiem && info.TuDiem <= denDiem || info.DenDiem >= tuDiem && info.DenDiem <= denDiem)
            {
                errorString = "Thang điểm bạn nhập phải tách biệt hoàn toàn với thang điểm: " + item["TenXepHang"].ToString();
                return false;
            }
        }
        return true;
    }

    [DirectMethod]
    public void DeleteRecord(int pr_key)
    {
        // xóa các thang điểm con nếu có
        new LoaiXepHangController().DeleteByParentID(pr_key);

        // xóa hình thức xếp hạng
        new LoaiXepHangController().DeleteByPrkey(pr_key);
        hdfRecordID.Text = "";
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới loại xếp hạng";
        hdfCommand.SetValue("");
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new LoaiXepHangController().GetByPrkey(int.Parse(hdfRecordID.Text));
            hdfMaXepHang.Text = record.Rows[0]["MaXepHang"].ToString();
            txtKiHieuXapHang.Text = record.Rows[0]["KiHieuXepHang"].ToString();
            txtTenXepHang.Text = record.Rows[0]["TenXepHang"].ToString();
            cbLoaiXepHang.SetValue(int.Parse(record.Rows[0]["ParentID"].ToString()));
            txtGhiChu.Text = record.Rows[0]["GhiChu"].ToString();
            txtTuDiem.SetValue(record.Rows[0]["TuDiem"]);
            txtDenDiem.SetValue(record.Rows[0]["DenDiem"]);
            txtKiHieuXapHang.Disabled = true;

            hdfCommand.Text = "Update";
            wdAddWindow.Icon = Icon.Pencil;
            wdAddWindow.Title = "Sửa thông tin loại xếp hạng";
            wdAddWindow.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    protected void cbLoaiXepHang_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        DataTable table = new LoaiXepHangController().GetByParentID(-1, maDv);
        object[] obj = new object[table.Rows.Count + 1];
        obj[0] = new { MaXepHang = -1, TenXepHang = "Là gốc" };
        for (int i = 0; i < table.Rows.Count; i++)
        {
            obj[i + 1] = new { MaXepHang = table.Rows[i]["MaXepHang"], TenXepHang = table.Rows[i]["TenXepHang"] };
        }
        cbLoaiXepHang_Store.DataSource = obj;
        cbLoaiXepHang_Store.DataBind();
    }

    protected void grp_HinhThucXepLoai_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        grp_HinhThucXepLoai_Store.DataSource = new LoaiXepHangController().GetAllParent(maDv);
        grp_HinhThucXepLoai_Store.DataBind();
    }
}
