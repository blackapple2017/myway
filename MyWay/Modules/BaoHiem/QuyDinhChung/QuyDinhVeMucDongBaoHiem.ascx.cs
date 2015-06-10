using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using System.Data;
using Ext.Net;
using ExtMessage;

public partial class Modules_BaoHiem_QuyDinhChung_QuyDinhVeMucDongBaoHiem : UserControlBase
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
        try
        {
            BHMUCDONGBAOHIEMInfo obj = new BHMUCDONGBAOHIEMInfo();
            BHMUCDONGBAOHIEMController ctr = new BHMUCDONGBAOHIEMController();

            if (dfNgayHieuLuc.SelectedDate.ToString().Contains("01/01/0001") == false)
            {
                obj.NgayHieuLuc = dfNgayHieuLuc.SelectedDate;
            }
            else
            {
                obj.NgayHieuLuc = DateTime.Now;
            }
            if (!string.IsNullOrEmpty(nfSanBHXH.Text))
                obj.SanBHXH = decimal.Parse(nfSanBHXH.Text.Replace(".", ","));
            //if (!string.IsNullOrEmpty(nfSanBHYT.Text))
            //    obj.SanBHYT = decimal.Parse(nfSanBHYT.Text.Replace(".", ","));
            //if (!string.IsNullOrEmpty(nfSanBHTN.Text))
            //    obj.SanBHTN = decimal.Parse(nfSanBHTN.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfTranBHXH.Text))
                obj.TranBHXH = decimal.Parse(nfTranBHXH.Text.Replace(".", ","));
            //if (!string.IsNullOrEmpty(nfTranBHYT.Text))
            //    obj.TranBHYT = decimal.Parse(nfTranBHYT.Text.Replace(".", ","));
            //if (!string.IsNullOrEmpty(nfTranBHTN.Text))
            //    obj.TranBHTN = decimal.Parse(nfTranBHTN.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfBHXHNhanVien.Text))
                obj.NVBYXH = decimal.Parse(nfBHXHNhanVien.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfBHYTNhanVien.Text))
                obj.NVBHYT = decimal.Parse(nfBHYTNhanVien.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfBHTNNhanVien.Text))
                obj.NVBHTN = decimal.Parse(nfBHTNNhanVien.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfBHXHDonVi.Text))
                obj.DVBHXH = decimal.Parse(nfBHXHDonVi.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfBHYTDonVi.Text))
                obj.DVBHYT = decimal.Parse(nfBHYTDonVi.Text.Replace(".", ","));
            if (!string.IsNullOrEmpty(nfBHTNDonVi.Text))
                obj.DVBHTN = decimal.Parse(nfBHTNDonVi.Text.Replace(".", ","));
            obj.UserID = CurrentUser.ID;
            obj.MaDonVi = Session["MaDonVi"].ToString();
            obj.DateCreate = DateTime.Now;
            if (e.ExtraParams["Command"] == "Edit")
            {
                if (!string.IsNullOrEmpty(hdfRecordID.Text))
                {
                    obj.ID = Convert.ToInt32(hdfRecordID.Text);
                }
                // tạm thời bỏ check ngày trùng
                //if (Check_NgayHieuLuc(dfNgayHieuLuc.SelectedDate) == true)
                //{
                //    X.MessageBox.Alert("Thông báo", " Ngày hiệu lực đã tồn tại").Show();
                //    dfNgayHieuLuc.Focus();
                //    return;
                //}
                //else
                //{
                    ctr.Update(obj);
                    wdAddWindow.Hide();
                //}
                //RM.RegisterClientScriptBlock("fd", string.Format("addUpdatedRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}')", nfID.Text, nfNgayHieuLuc.Text, nfSanBHXH.Text, nfSanBHYT.Text, nfSanBHTN.Text, nfTranBHXH.Text, nfTranBHYT.Text, nfTranBHTN.Text, nfNVBYXH.Text, nfNVBHYT.Text, nfNVBHTN.Text, nfDVBHXH.Text, nfDVBHYT.Text, nfDVBHTN.Text, nfUserID.Text, nfDateCreate.Text, nfMaDonVi.Text));
            }
            else
            {
                if (Check_NgayHieuLuc(dfNgayHieuLuc.SelectedDate) == true)
                {
                    X.MessageBox.Alert("Thông báo", " Ngày hiệu lực đã tồn tại").Show();
                    dfNgayHieuLuc.Focus();
                    return;
                }
                else
                {
                    ctr.Insert(obj);
                    if (e.ExtraParams["Close"] == "True")
                    {
                        wdAddWindow.Hide();
                    }
                }
                // RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}')", nfID.Text, nfNgayHieuLuc.Text, nfSanBHXH.Text, nfSanBHYT.Text, nfSanBHTN.Text, nfTranBHXH.Text, nfTranBHYT.Text, nfTranBHTN.Text, nfNVBYXH.Text, nfNVBHYT.Text, nfNVBHTN.Text, nfDVBHXH.Text, nfDVBHYT.Text, nfDVBHTN.Text, nfUserID.Text, nfDateCreate.Text, nfMaDonVi.Text));
            }
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {

            X.MessageBox.Alert("Thông báo ", "Số năm vượt quá khoảng cho phép(1753->9999)").Show();
        }
    }
    protected bool Check_NgayHieuLuc(DateTime NgayHieuLuc)
    {
        DataTable record = DataController.DataHandler.GetInstance().ExecuteDataTable("GetAll_BHMucDongBH");
        if (record.Rows.Count>0)
        {
            for (int i = 0; i < record.Rows.Count; i++)
            {
                if (record.Rows[i]["NgayHieuLuc"].ToString()==NgayHieuLuc.ToString())
                {
                    return true;
                    break;
                }
            }
        }
        return false;
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new BHMUCDONGBAOHIEMController().GetByPrkey(Convert.ToInt32(hdfCommand.Text));
            if (record.Rows.Count > 0)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
            }
            else
            {
                record = new BHMUCDONGBAOHIEMController().GetByPrkey(Convert.ToInt32(hdfRecordID.Text));
                // record.Rows[0]["ID"] = Convert.ToInt32(nfmaloaihdcoppy.Text);
                BHMUCDONGBAOHIEMInfo item = new BHMUCDONGBAOHIEMInfo()
                {
                    ID = int.Parse(record.Rows[0]["ID"].ToString()),
                    NgayHieuLuc = DateTime.Parse(record.Rows[0]["NgayHieuLuc"].ToString().Replace(".", ",")),
                    SanBHXH = decimal.Parse(record.Rows[0]["SanBHXH"].ToString()),
                    //SanBHYT = decimal.Parse(record.Rows[0]["SanBHYT"].ToString()),
                    //SanBHTN = decimal.Parse(record.Rows[0]["SanBHTN"].ToString()),
                    TranBHXH = decimal.Parse(record.Rows[0]["TranBHXH"].ToString()),
                    //TranBHYT = decimal.Parse(record.Rows[0]["TranBHYT"].ToString()),
                    //TranBHTN = decimal.Parse(record.Rows[0]["TranBHTN"].ToString()),
                    NVBYXH = decimal.Parse(record.Rows[0]["NVBYXH"].ToString()),
                    NVBHYT = decimal.Parse(record.Rows[0]["NVBHYT"].ToString()),
                    NVBHTN = decimal.Parse(record.Rows[0]["NVBHTN"].ToString()),
                    DVBHXH = decimal.Parse(record.Rows[0]["DVBHXH"].ToString()),
                    DVBHYT = decimal.Parse(record.Rows[0]["DVBHYT"].ToString()),
                    DVBHTN = decimal.Parse(record.Rows[0]["DVBHTN"].ToString()),
                    UserID = int.Parse(record.Rows[0]["UserID"].ToString()),
                    DateCreate = DateTime.Parse(record.Rows[0]["DateCreate"].ToString()),
                    MaDonVi = record.Rows[0]["MaDonVi"].ToString(),
                };
                new BHMUCDONGBAOHIEMController().Insert(item);
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
        if (!string.IsNullOrEmpty(pr_key))
        {
            new BHMUCDONGBAOHIEMController().DeleteByPrkey(Convert.ToInt32(pr_key));
        }
        hdfRecordID.Text = "";
    }
    [DirectMethod]
    public void NhanDoiDuLieuTuTang()
    {
        //string pr_key = hdfRecordID.Text;
        //new BHMUCDONGBAOHIEMController().DuplucateByPrkey(pr_key);
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới quy định về mức đóng bảo hiểm";
        hdfCommand.SetValue("");
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        int prkey = 0;
        if (!string.IsNullOrEmpty(hdfRecordID.Text))
        {
            prkey = Convert.ToInt32(hdfRecordID.Text);
        }
        DataTable record = new BHMUCDONGBAOHIEMController().GetByPrkey(prkey);
        if (record.Rows.Count > 0)
        {
            dfNgayHieuLuc.SelectedDate = DateTime.Parse(record.Rows[0]["NgayHieuLuc"].ToString());
            nfSanBHXH.Text = record.Rows[0]["SanBHXH"].ToString();
            //nfSanBHYT.Text = record.Rows[0]["SanBHYT"].ToString();
            //nfSanBHTN.Text = record.Rows[0]["SanBHTN"].ToString();
            nfTranBHXH.Text = record.Rows[0]["TranBHXH"].ToString();
            //nfTranBHYT.Text = record.Rows[0]["TranBHYT"].ToString();
            //nfTranBHTN.Text = record.Rows[0]["TranBHTN"].ToString();
            nfBHXHNhanVien.Text = record.Rows[0]["NVBYXH"].ToString();
            nfBHYTNhanVien.Text = record.Rows[0]["NVBHYT"].ToString();
            nfBHTNNhanVien.Text = record.Rows[0]["NVBHTN"].ToString();
            nfBHXHDonVi.Text = record.Rows[0]["DVBHXH"].ToString();
            nfBHYTDonVi.Text = record.Rows[0]["DVBHYT"].ToString();
            nfBHTNDonVi.Text = record.Rows[0]["DVBHTN"].ToString();
            hdfCommand.Text = "Update";
            wdAddWindow.Icon = Icon.Pencil;
            wdAddWindow.Title = "Sửa quy định về mức đóng bảo hiểm";
            wdAddWindow.Show();
        }
    }
}