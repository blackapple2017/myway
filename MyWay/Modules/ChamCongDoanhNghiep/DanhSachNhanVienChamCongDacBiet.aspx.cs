using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
public partial class Modules_ChamCongDoanhNghiep_DanhSachNhanVienChamCongDacBiet : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        grpDanhSachNhanVienChamCongDacBiet.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaClick);
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
        // grpDanhSachNhanVienChamCongDacBiet.GetAddButton().Handler = "wdAddWindow.show()";
        grpDanhSachNhanVienChamCongDacBiet.GetAddButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnThemClick);
        //grpDanhSachNhanVienChamCongDacBiet.GetEditButton().Handler = "return CheckChonNhieuDong(grpNghiDaiNgay);";
        grpDanhSachNhanVienChamCongDacBiet.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaClick);
        grpDanhSachNhanVienChamCongDacBiet.GetGridPanel().Listeners.RowContextMenu.Handler = "e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());grpDanhSachNhanVienChamCongDacBiet_GridPanel1.getSelectionModel().selectRow(rowIndex);";

    }

    private void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        SelectedRowCollection selectedRows = ucChooseEmployee1.SelectedRow;
        string ma = "";
        string ten = "";
        foreach (var item in selectedRows)
        {
            ma += item.RecordID + ",";
            ten += new HoSoController().TraVeTenByMaCB(item.RecordID) + ", ";
        }
        ma = ma.Remove(ma.LastIndexOf(','));
        ten = ten.Remove(ten.LastIndexOf(','));
        tgfMaCanBo.Text = ma;
        txtHoTen.Text = ten;
    }
    protected void btnThemClick(object sender, DirectEventArgs e)
    {
        wdAddWindow.Title = "Thêm đối tượng chấm công đặc biệt";
        wdAddWindow.Icon = Icon.Add;
        tgfMaCanBo.Disabled = false;
        btnCapNhatSua.Hide();
        btnCapNhatThem.Show();
        btnCapNhatThemVaDongLai.Show();
        wdAddWindow.Show();
    }
    protected void btnSuaClick(object sender, DirectEventArgs e)
    {
        try
        {

        if (grpDanhSachNhanVienChamCongDacBiet.GetSelectedRecordIDs().Count > 1)
        {
            X.Msg.Alert("Thông báo", "Bạn chỉ được chọn 1 dòng").Show();
            return;
        }
        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa đối tượng chấm công đặc biệt";
        DAL.DanhSachNhanVienChamCongDacBiet dieukien = new DanhSachChamCongDacBietController().GetByID(int.Parse(grpDanhSachNhanVienChamCongDacBiet.GetSelectedRecordIDs().FirstOrDefault().ToString()));
        tgfMaCanBo.Text = dieukien.MaCB;
        txtHoTen.Text = new HoSoController().TraVeTenByMaCB(dieukien.MaCB);
        cbbSoLanChitTay.Value = dieukien.SoLanChitTay.ToString();
        tgfMaCanBo.Disabled = true;
        btnCapNhatSua.Show();
        btnCapNhatThem.Hide();
        btnCapNhatThemVaDongLai.Hide();
        wdAddWindow.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhatThem_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachNhanVienChamCongDacBiet chamcongdacbiet = new DAL.DanhSachNhanVienChamCongDacBiet();
            string strCanbotrung = "";
            foreach (var item in tgfMaCanBo.Text.Split(','))
            {
                chamcongdacbiet = new DanhSachChamCongDacBietController().GetByMaCB(item);
                if (chamcongdacbiet != null)
                {
                    strCanbotrung += "Cán bộ " + new HoSoController().TraVeTenByMaCB(item) + " đã có trong danh sách chấm công đặc biệt<br/>";
                }
                else
                {
                    chamcongdacbiet = new DAL.DanhSachNhanVienChamCongDacBiet();
                    chamcongdacbiet.MaCB = item;
                    chamcongdacbiet.SoLanChitTay = int.Parse(cbbSoLanChitTay.SelectedItem.Value);
                    chamcongdacbiet.CreatedDate = DateTime.Now;
                    chamcongdacbiet.CreatedBy = CurrentUser.ID;
                    new DanhSachChamCongDacBietController().Insert(chamcongdacbiet);
                    Dialog.ShowNotification("Thông báo", "Đã lưu thành công cán bộ " + item);
                }
            }
            if (strCanbotrung != "") X.Msg.Alert("Thông báo", strCanbotrung).Show();
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
            else
            {
                grpDanhSachNhanVienChamCongDacBiet.GetResourceManager().RegisterClientScriptBlock("r1", "resetForm();");
            }
            grpDanhSachNhanVienChamCongDacBiet.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void btnCapNhatSua_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachNhanVienChamCongDacBiet chamcongdacbiet = new DAL.DanhSachNhanVienChamCongDacBiet();
            chamcongdacbiet.MaCB = tgfMaCanBo.Text;
            chamcongdacbiet.SoLanChitTay = int.Parse(cbbSoLanChitTay.SelectedItem.Value);
            chamcongdacbiet.CreatedDate = DateTime.Now;
            chamcongdacbiet.CreatedBy = CurrentUser.ID;
            new DanhSachChamCongDacBietController().Update(chamcongdacbiet);
            Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
            grpDanhSachNhanVienChamCongDacBiet.GetGridPanel().Reload();
            wdAddWindow.Hide();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }


}