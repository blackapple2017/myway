using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;

public partial class Modules_DanhMuc_DM_LOAI_HDONG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        DAL.DM_LOAI_HDONG loaihd = new DAL.DM_LOAI_HDONG();
        loaihd.MA_LOAI_HDONG = txtmaloaihd.Text;
        loaihd.TEN_LOAI_HDONG = txtTenLoaiHopDong.Text;
        loaihd.THOI_HAN_HOPDONG_MONTH_ = int.Parse(txtThoiGian.Text);
        loaihd.GHI_CHU = txtGhiChu.Text;
        loaihd.BHTN = false;
        loaihd.BHYT = false;
        loaihd.BHXH = false;
        if (!string.IsNullOrEmpty(nbfHeSo.Text))
        {
            loaihd.HeSo = double.Parse(nbfHeSo.Text.Replace('.', ','));
        }
        DM_LOAI_HDONGController ctr = new DM_LOAI_HDONGController();
        if (e.ExtraParams["Command"] == "Edit")
        {
            loaihd.MA_LOAI_HDONG = txtmaloaihd.Text;
            ctr.Update(loaihd);
            wdAddWindow.Hide();
        }
        else
        {
            ctr.Insert(loaihd);
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
        }
        GridPanel1.Reload();
        //    RM.RegisterClientScriptBlock("fd", string.Format("addHopDong({0},'{1}','{2}',{3},'{4}')", 0, txtmaloaihd.Text, txtTenLoaiHopDong.Text, txtThoiGian.Text, txtGhiChu.Text));
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DM_LOAI_HDONG loaihd = new DM_LOAI_HDONGController().GetByID(hdfRecordID.Text);
            DAL.DM_LOAI_HDONG copy = new DAL.DM_LOAI_HDONG();
            copy.MA_LOAI_HDONG = txtmaloaihdcoppy.Text;
            copy.TEN_LOAI_HDONG = loaihd.TEN_LOAI_HDONG;
            copy.THOI_HAN_HOPDONG_MONTH_ = loaihd.THOI_HAN_HOPDONG_MONTH_;
            copy.GHI_CHU = loaihd.GHI_CHU;
            wdInputNewPrimaryKey.Hidden = true;
            new DM_LOAI_HDONGController().Insert(copy);
            RM.RegisterClientScriptBlock("fd", string.Format("addHopDong({0},'{1}','{2}',{3},'{4}')", 0, txtmaloaihdcoppy.Text, copy.TEN_LOAI_HDONG, copy.THOI_HAN_HOPDONG_MONTH_, copy.GHI_CHU));

        }
        catch (Exception ex)
        {

            Dialog.ShowNotification("Đã có lỗi xảy ra trong quá trình nhân đôi dữ liệu !");
        }

    }

    [DirectMethod]
    public void DeleteHopDong(string pr_key)
    {
        try
        {
            new DM_LOAI_HDONGController().DeleteLoaiHD(pr_key);
            hdfRecordID.Text = "";
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Loại hợp đồng này đang được sử dụng. Bạn không được phép xóa!");
        }
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới loại hợp đồng";
        hdfCommand.SetValue("");
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DAL.DM_LOAI_HDONG loaihd = new DM_LOAI_HDONGController().GetByID(hdfRecordID.Text);
        //Dialog.ShowNotification(hdfRecordID.Text);
        txtmaloaihd.Text = loaihd.MA_LOAI_HDONG;
        txtTenLoaiHopDong.Text = loaihd.TEN_LOAI_HDONG;
        txtThoiGian.Text = loaihd.THOI_HAN_HOPDONG_MONTH_.ToString();
        txtGhiChu.Text = loaihd.GHI_CHU;
        if (loaihd.HeSo.HasValue)
        {
            nbfHeSo.Text = loaihd.HeSo.Value.ToString();
        }
        hdfCommand.Text = "Update";
        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa thông tin loại hợp đồng";
        wdAddWindow.Show();
    }
}