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
public partial class Modules_BaoHiem_QuyDinhChung_QuyDinhBienDong : UserControlBase
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
        BHQUYDINHBIENDONGInfo obj = new BHQUYDINHBIENDONGInfo();
        BHQUYDINHBIENDONGController ctr = new BHQUYDINHBIENDONGController();

        obj.MaBienDong = txtMaBienDong.Text;
        obj.TenBienDong = txtTenBienDong.Text;
        obj.LoaiAnhHuong = cboloaianhhuong.Value.ToString();
        if (!string.IsNullOrEmpty(cboCheDoBH.Text))
        {
            if (cboCheDoBH.Text == "NULL")
            {
                obj.IDCheDoBaoHiem = null;
            }
            else
            {
                obj.IDCheDoBaoHiem = Convert.ToInt32(cboCheDoBH.Value);
            }
        }

        obj.IsBHXH = chkIsIsBHXH.Checked;
        obj.IsBHYT = chkIsIsBHYT.Checked;
        obj.IsBHTN = chkIsIsBHTN.Checked;
        obj.DangSuDung = chkIsDangSuDung.Checked;
        obj.UserID = CurrentUser.ID;
        obj.DateCreate = DateTime.Now;
        obj.MaDonVi = Session["MaDonVi"].ToString();
        if (e.ExtraParams["Command"] == "Edit")
        {
            if (!string.IsNullOrEmpty(hdfRecordID.Text))
            {
                obj.IDQuyDinhBienDong = Convert.ToInt32(hdfRecordID.Text);
            }
            ctr.Update(obj);
            wdAddWindow.Hide();
        }
        else
        {
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("GetBienDongBaoHiem_ByMaBienDong", "@MaBienDong", txtMaBienDong.Text);
            if (dt.Rows.Count > 0)
            {
                X.MessageBox.Alert("Thông báo", "Mã quy định biến động đã tồn tại").Show();
                txtMaBienDong.Focus();
                return;
            }
            else
            {
                ctr.Insert(obj);
            }
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
            // RM.RegisterClientScriptBlock("fd", string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", txtIDQuyDinhBienDong.Text, txtMaBienDong.Text, txtTenBienDong.Text, txtLoaiAnhHuong.Text, txtIDCheDoBaoHiem.Text, chkIsIsBHXH.Checked, chkIsIsBHYT.Checked, chkIsIsBHTN.Checked, chkIsDangSuDung.Checked, txtUserID.Text, txtDateCreate.Text, txtMaDonVi.Text));
        }
        GridPanel1.Reload();
    }
    protected void btnOK_Click(object sender, DirectEventArgs e)
    {

        DataTable record = new BHQUYDINHBIENDONGController().GetByPrkey(Convert.ToInt32(txtmaloaihdcoppy.Text));
        if (record.Rows.Count > 0)
        {
            Dialog.ShowNotification("Mã đã tồn tại");
        }
        else
        {
            record = new BHQUYDINHBIENDONGController().GetByPrkey(Convert.ToInt32(hdfRecordID.Text));
            record.Rows[0]["IDQuyDinhBienDong"] = int.Parse(txtmaloaihdcoppy.Text);
            if (record != null)
            {
                BHQUYDINHBIENDONGInfo item = new BHQUYDINHBIENDONGInfo()
                {
                    IDQuyDinhBienDong = int.Parse(record.Rows[0]["IDQuyDinhBienDong"].ToString()),
                    MaBienDong = record.Rows[0]["MaBienDong"].ToString(),
                    TenBienDong = record.Rows[0]["TenBienDong"].ToString(),
                    LoaiAnhHuong = record.Rows[0]["LoaiAnhHuong"].ToString(),
                    IDCheDoBaoHiem = int.Parse(record.Rows[0]["IDCheDoBaoHiem"].ToString()),
                    IsBHXH = (bool)record.Rows[0]["IsBHXH"],
                    IsBHYT = (bool)record.Rows[0]["IsBHYT"],
                    IsBHTN = (bool)record.Rows[0]["IsBHTN"],
                    DangSuDung = (bool)record.Rows[0]["DangSuDung"],
                    UserID = int.Parse(record.Rows[0]["UserID"].ToString()),
                    DateCreate = DateTime.Parse(record.Rows[0]["DateCreate"].ToString()),
                    MaDonVi = record.Rows[0]["MaDonVi"].ToString(),
                };
                new BHQUYDINHBIENDONGController().Insert(item);

                GridPanel1.Reload();
                wdInputNewPrimaryKey.Hide();
            }

        }
    }

    [DirectMethod]
    public void DeleteRecord(string pr_key)
    {
        try
        {
            new BHQUYDINHBIENDONGController().DeleteByPrkey(Convert.ToInt32(pr_key));
            hdfRecordID.Text = "";
        }
        catch (SqlException sqlex)
        {
            if (sqlex.Number == ErrorNumber.CONFLICT_FOREIGN_KEY)
            {
                Dialog.ShowError("Dữ liệu đang được sử dụng");
                GridPanel1.Reload();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("" + ex.Message);
        }
    }
    [DirectMethod]
    public void NhanDoiDuLieuTuTang()
    {
        string pr_key = hdfRecordID.Text;
        new BHQUYDINHBIENDONGController().DuplucateByPrkey(Convert.ToInt32(pr_key));
    }
    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới quy định biến động bảo hiểm";
        hdfCommand.SetValue("");
    }
    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new BHQUYDINHBIENDONGController().GetByPrkey(Convert.ToInt32(hdfRecordID.Text));
            txtMaBienDong.Text = record.Rows[0]["MaBienDong"].ToString();
            txtTenBienDong.Text = record.Rows[0]["TenBienDong"].ToString();
            string id = record.Rows[0]["IDCheDoBaoHiem"].ToString();
            if (record.Rows[0]["IDCheDoBaoHiem"].ToString() != "")
            {
                LoadCha(Convert.ToInt32(record.Rows[0]["IDCheDoBaoHiem"]));
            }
            string loaianhhuong = record.Rows[0]["LoaiAnhHuong"].ToString();
            string tenanhhuong = "";
            switch (loaianhhuong)
            {
                case "TLD":
                    tenanhhuong = "Tăng lao động";
                    break;
                case "GLD":
                    tenanhhuong = "Giảm lao động";
                    break;
                case "TMD": tenanhhuong = "Tăng mức đóng";
                    break;

                case "GMD": tenanhhuong = "Giảm mức đóng";
                    break;
                case "TruyThu": tenanhhuong = "Truy thu";
                    break;
                case "ThoaiThu": tenanhhuong = "Thoái thu";
                    break;
            }

            cboloaianhhuong.Text = tenanhhuong;
            cboloaianhhuong.Value = loaianhhuong;
            //txtLoaiAnhHuong.Text = record.Rows[0]["LoaiAnhHuong"].ToString();
            //txtIDCheDoBaoHiem.Text = record.Rows[0]["IDCheDoBaoHiem"].ToString();
            chkIsIsBHXH.Checked = (bool)record.Rows[0]["IsBHXH"];
            chkIsIsBHYT.Checked = (bool)record.Rows[0]["IsBHYT"];
            chkIsIsBHTN.Checked = (bool)record.Rows[0]["IsBHTN"];
            chkIsDangSuDung.Checked = (bool)record.Rows[0]["DangSuDung"];
            hdfCommand.Text = "Update";
            wdAddWindow.Icon = Icon.Pencil;
            wdAddWindow.Title = "Sửa quy định biến động bảo hiểm";
            wdAddWindow.Show();
        }
        catch
        {
        }
    }
    protected void Store_cboCheDoBH_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        LoadCha(-2);
    }
    public void LoadCha(int idchedobh)
    {
        List<CheDoBaoHiemInfo> lists = new CheDoBaoHiemController().GetbyParentID(0, -1);
        List<object> obj = new List<object>();
        obj.Add(new { IDCheDoBaoHiem = "NULL", TenCheDoBaoHiem = "Không có chế độ bảo hiểm" });

        foreach (CheDoBaoHiemInfo info in lists)
        {
            if (info.ParentID == 0)
            {
                obj.Add(new { IDCheDoBaoHiem = info.IDCheDoBaoHiem, TenCheDoBaoHiem = info.TenCheDoBaoHiem });
                obj = LoadMenuCon(obj, info.IDCheDoBaoHiem, 1, idchedobh);
            }
            if (idchedobh == info.IDCheDoBaoHiem)
            {
                if (idchedobh == null)
                {
                    cboCheDoBH.SelectedItem.Value = null;
                    cboCheDoBH.SelectedItem.Text = "Không có chế độ bảo hiểm";
                }
                else
                {
                    cboCheDoBH.SelectedItem.Text = info.TenCheDoBaoHiem;
                    cboCheDoBH.SelectedItem.Value = info.IDCheDoBaoHiem.ToString();
                }

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
                tmp += "- ";
            obj.Add(new { IDCheDoBaoHiem = item.IDCheDoBaoHiem, TenCheDoBaoHiem = tmp + item.TenCheDoBaoHiem });
            if (idchedobh == item.IDCheDoBaoHiem)
            {
                if (idchedobh == null)
                {
                    cboCheDoBH.SelectedItem.Text = "Không có chế độ bảo hiểm";
                    cboCheDoBH.SelectedItem.Value = null;
                }
                else
                {
                    cboCheDoBH.SelectedItem.Text = item.TenCheDoBaoHiem;
                    cboCheDoBH.SelectedItem.Value = item.IDCheDoBaoHiem.ToString();
                }

                break;
            }
            obj = LoadMenuCon(obj, item.IDCheDoBaoHiem, k + 1, idchedobh);

        }
        return obj;
    }
}
