using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller.ChamCongDoanhNghiep;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
using Controller.ThoiViec;
using DAL;
using System.IO;
using SoftCore;

public partial class Modules_TienLuong_KhoanSanXuat_BangCongThucLuongKhoan : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {

            grpCongThucLuongKhoan.GetAddButton().Listeners.Click.Handler = "wdGiaoVien.show();";
        }
        grpCongThucLuongKhoan.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnEditCongThucLuong_Click);
        grpCongThucLuongKhoan.GetGridPanel().DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEditCongThucLuong_Click);
        grpCongThucLuongKhoan.GetAddButton().Listeners.Click.Handler = "wdCongThucKhoanSanXuatEdit.show();";
    }
    //protected void cbb_MaCa_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    int count = 0;
    //    List<DanhSachCaInfo> lists = new DanhSachCaController().MiniGetAll(0, 1000, "", "CN1", out count);
    //    List<object> obj = new List<object>();
    //    foreach (var item in lists)
    //    {
    //        obj.Add(new { Ma = item.MaCa, Ten = item.TenCa });
    //    }
    //    cbb_MaCa_Store.DataSource = obj;
    //    cbb_MaCa_Store.DataBind();
    //}

    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            obj.Add(new { MA = info.MA, TEN = info.TEN });
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        cbx_bophan_Store.DataSource = obj;
        cbx_bophan_Store.DataBind();
    }

    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "----";
            obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }

    protected void btnEditCongThucLuong_Click(object sender, DirectEventArgs e)
    {
        hdf_PRKEY.Text = grpCongThucLuongKhoan.GetSelectedRecordIDs().FirstOrDefault();
        var congthuc = new CongThucKhoanSanXuatControler().GetCongThucByPrKey(int.Parse("0" + hdf_PRKEY.Text));
        //cbb_MaCa.SetValue(congthuc.MaCa);
        hdfBoPhan.SetValue(congthuc.MaDonVi);
        DAL.DM_DONVI dv = new DM_DONVIController().GetById(congthuc.MaDonVi);
        if (dv != null)
            cbx_bophan.Text = dv.TEN_DONVI;
        txt_TenCongThuc.Text = congthuc.TenCongThuc;
        txt_DKSanLuongTu.Text = congthuc.DKSanLuongTu.ToString();
        txt_CongThuc.Text = congthuc.CongThuc;
        txt_DKSanLuongDen.Text = congthuc.DKSanLuongDen.ToString();
        txt_TrongSo.SetValue(congthuc.TrongSo);
        txt_GhiChu.Text = congthuc.GhiChu;
        wdCongThucKhoanSanXuatEdit.Title = "Sửa công thức";
        wdCongThucKhoanSanXuatEdit.Icon = Icon.Pencil;
        wdCongThucKhoanSanXuatEdit.Show();
    }

    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        bool isSuccess = false;
        int prkey = int.Parse("0" + hdf_PRKEY.Text);
        if (prkey != 0)
        {
            var item = new CongThucKhoanSanXuatControler().GetCongThucByPrKey(prkey);
            item.CongThuc = txt_CongThuc.Text;
            item.DKSanLuongDen = decimal.Parse("0" + txt_DKSanLuongDen.Text);
            item.DKSanLuongTu = decimal.Parse("0" + txt_DKSanLuongTu.Text);
            item.GhiChu = txt_GhiChu.Text;
            item.MaDonVi = hdfBoPhan.Text;
            item.TenCongThuc = txt_TenCongThuc.Text;
            item.TrongSo = decimal.Parse("0" + txt_TrongSo.Text.Replace(".", ","));
            new CongThucKhoanSanXuatControler().Update(item);
        }
        else
        {
            var item = new DAL.CongThucKhoanSanXuat()
            {
                CongThuc = txt_CongThuc.Text,
                DKSanLuongDen = decimal.Parse("0" + txt_DKSanLuongDen.Text),
                DKSanLuongTu = decimal.Parse("0" + txt_DKSanLuongTu.Text),
                GhiChu = txt_GhiChu.Text,
                MaDonVi = hdfBoPhan.Text,
                TenCongThuc = txt_TenCongThuc.Text,
                TrongSo = decimal.Parse("0" + txt_TrongSo.Text.Replace(".", ","))
            };
            new CongThucKhoanSanXuatControler().Insert(item);
        }
        Dialog.ShowNotification("Cập nhật thành công");
        //wdCongThucKhoanSanXuatEdit.Hide();
        grpCongThucLuongKhoan.GetGridPanel().Reload();


    }
}
