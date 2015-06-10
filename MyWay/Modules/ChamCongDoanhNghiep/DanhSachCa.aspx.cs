using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using Controller.ChamCongDoanhNghiep;
using ExtMessage;
using System.Data;
using DataController;

public partial class Modules_ChamCongDoanhNghiep_SapXepCaLamViec : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            HideColumn();

            // phân quyền
            SetVisibleByControlID(btnThemMoi, btnSua, btnXoa, btnTienIch, btnConfig,
                    btnAddQT, btnEditQT, btnXoaQT);
            mnuAdd.Visible = btnThemMoi.Visible;
            mnuEdit.Visible = btnSua.Visible;
            mnuDelete.Visible = btnXoa.Visible;
            MenuItem1.Visible = btnTienIch.Visible;
        }
        if (btnSua.Visible)
        {
            grp_DanhSachCa.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(EditCaLamViec);
            grp_DanhSachCa.DirectEvents.RowDblClick.Before = "#{btnCapNhat}.hide(); #{btnEdit}.show(); #{btnCapNhatVaDongLai}.hide();";
        }
    }

    #region DirectMethods
    [DirectMethod]
    public void ResetWindowsTitle()
    {
        wdThemCaLamViec.Title = "Thêm mới ca làm việc";
        wdThemCaLamViec.Icon = Icon.ClockAdd;
    }

    [DirectMethod]
    public void ResetWindowsQuyTac()
    {
        wdQuyTacLamThemGio.Title = "Thêm mới quy tắc làm thêm giờ";
        wdQuyTacLamThemGio.Icon = Icon.ClockAdd;
    }

    [DirectMethod]
    public void DeleteRecordQuyTac(int id)
    {
        try
        {
            new QuyTacLamThemGioController().Delete(id);
            hdfIDQuyTac.Text = "";
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    [DirectMethod]
    public void LoadConfigGridPanel()
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("SystemConfig_GetConfigByPrefix", "@Prefix", "@MaDonVi", "DSC_", Session["MaDonVi"].ToString());
            foreach (DataRow item in table.Rows)
            {
                switch (item["VAR_NAME"].ToString())
                {
                    case SystemConfigParameter.DSC_GIOVAO:
                        chkGioVao.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_GIORA:
                        chkGioRa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_SOGIOLAM:
                        chkSoGioLam.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_CHOPHEPDIMUON:
                        chkChoPhepDiMuon.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_CHOPHEPVESOM:
                        chkChoPhepVeSom.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    //case SystemConfigParameter.DSC_BATDAUTINHLAMTHEMDAUGIO:
                    //    chkBatDauTinhLamThemDauGio.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                    //    break;
                    //case SystemConfigParameter.DSC_BATDAULAMTHEMCUOIGIO:
                    //    chkBatDauTinhLamThemCuoiGio.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                    //    break;
                    case SystemConfigParameter.DSC_APDUNGTUNGAY:
                        chkApDungTuNgay.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_APDUNGDENNGAY:
                        chkApDungDenNgay.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;


                    case SystemConfigParameter.DSC_QUETTHEDAUCA:
                        chkQuetTheDauCa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_QUETTHENGHIDAUCA:
                        chkQuetTheNghiDauCa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_QUETTHEVAOCASAU:
                        chkQuetTheVaoCaSau.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_QUETTHECUOICA:
                        chkQuetTheCuoiCa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_PHUCAPCA:
                        chkPhuCapCa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_MUCLUONGCA:
                        chkMucLuongCa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_NGAYAPDUNG:
                        chkNgayApDung.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_NGAYTAO:
                        chkNgayTao.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                    case SystemConfigParameter.DSC_LOAICA:
                        chkLoaiCa.Checked = bool.Parse(item["VAR_VALUE"].ToString());
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    #region DirectEvent
    //protected void btnDongY_Click(object sender, DirectEventArgs e)
    //{
    //    try
    //    {
    //        if (hdfPrkeyCa.Text == "")
    //        {
    //            X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy ca làm việc").Show();
    //            return;
    //        }
    //        int prkeyCa = int.Parse(hdfPrkeyCa.Text);
    //        switch (hdfAction.Text)
    //        {
    //            case "Edit":
    //                EditCaLamViec(prkeyCa);
    //                break;
    //            case "Delete":
    //                DeleteCaLamViec(prkeyCa);
    //                break;
    //            case "Duplicate":
    //                DuplicateCaLamViec(prkeyCa);
    //                break;
    //            default:
    //                break;
    //        }
    //        wdChonCaLamViec.Hide();
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
    //    }
    //}

    /// <summary>
    /// Kiểm tra mã ca có bị trùng với các mã ngày nghỉ lễ, chế độ, nghỉ bù không
    /// </summary>
    /// <param name="maCa">Mã ca cần kiểm tra</param>
    /// <param name="lyDo">Lý do trùng nếu mã ca đã bị trùng</param>
    /// <returns><b>true</b> nếu mã ca đã bị trùng, <b>false</b> nếu mã ca chưa bị trùng</returns>
    private bool KiemTraTrungNgayNghiLe(string maCa, ref string lyDo)
    {
        KyHieuChamCongController kyHieu = new KyHieuChamCongController();
        if (maCa == kyHieu.NghiBu)
        {
            lyDo = "Mã ca trùng với mã nghỉ bù.";
            return true;
        }
        else if (maCa == kyHieu.NghiKhongLuong)
        {
            lyDo = "Mã ca trùng với mã nghỉ không lương.";
            return true;
        }
        else if (maCa == kyHieu.NghiLe)
        {
            lyDo = "Mã ca trùng với mã nghỉ lễ.";
            return true;
        }
        else if (maCa == kyHieu.NghiPhep)
        {
            lyDo = "Mã ca trùng với mã nghỉ phép.";
            return true;
        }
        else if (maCa == kyHieu.CheDo)
        {
            lyDo = "Mã ca trùng với mã nghỉ chế độ.";
            return true;
        }
        return false;
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            LinqProvider linq = new LinqProvider();
            DanhSachCaController dsController = new DanhSachCaController();
            DAL.DanhSachCa ca = new DAL.DanhSachCa();
            if (e.ExtraParams["Command"] == "Edit")
            {
                ca = linq.GetDataContext().DanhSachCas.Where(t => t.ID == int.Parse(hdfRecordID.Text)).FirstOrDefault();
            }
            else
            {
                string lyDo = "";
                if (KiemTraTrungNgayNghiLe(txtMaCa.Text, ref lyDo))
                {
                    X.Msg.Alert("Thông báo từ hệ thống", lyDo + " Vui lòng nhập mã ca khác!").Show();
                    return;
                }
            }
            ca.MaCa = txtMaCa.Text;
            ca.TenCa = txtTenCa.Text;
            if (txtPhuCapCa.Text != "")
                ca.PhuCapCa = double.Parse(txtPhuCapCa.Text.Replace('.', ','));
            if (txtLuongCuaCa.Text != "")
                ca.TienLuongCa = double.Parse(txtLuongCuaCa.Text.Replace('.', ','));
            if (txtTongSoGio.Text != "")
                ca.TongGio = double.Parse(txtTongSoGio.Text.Replace('.', ','));
            ca.LoaiCa = int.Parse("0" + hdfLoaiCa.Text);
            //   ca.NgayApDung = cbxNgayApDung.SelectedItem.Value;
            //
            ca.GioVao = GetTime(tfBatDauCa.Text);
            ca.GioRa = GetTime(tfKetThucCaSau.Text);
            ca.NghiGiuaCa = GetTime(tfNghiNuaCaDau.Text);
            ca.VaoGiuaCa = GetTime(tfBatDauCaSau.Text);
            //ca.BatDauTinhLamThemDauGio = GetTime(tfBatDauLamThemDauGio.Text);
            //ca.BatDauTinhLamThemCuoiGio = GetTime(tfBatDauLamThemCuoiGio.Text);
            //
            ca.RaNgoaiKhongBiTruGio = chkRaNgoaiKhongBiTruGio.Checked;
            //
            ca.BatDauQuetTheLan1 = GetTime(tfDauCaTu.Text);
            ca.KetThucQuetTheLan1 = GetTime(tfDauCaDen.Text);
            ca.BatDauQuetTheLan2 = GetTime(tfGiuaCaRaTu.Text);
            ca.KetThucQuetTheLan2 = GetTime(tfGiuaCaRaDen.Text);
            ca.BatDauQuetTheLan3 = GetTime(tfGiuaCaVaoTu.Text);
            ca.KetThucQuetTheLan3 = GetTime(tfGiuaCaVaoDen.Text);
            ca.BatDauQuetTheLan4 = GetTime(tfCuoiCaTu.Text);
            ca.KetThucQuetTheLan4 = GetTime(tfCuoiCaDen.Text);
            //
            //if (!SoftCore.Util.GetInstance().IsDateNull(dfApDungTu.SelectedDate))
            //    ca.ThoiGianApDungTu = dfApDungTu.SelectedDate;
            //if (!SoftCore.Util.GetInstance().IsDateNull(dfApDungDen.SelectedDate))
            //    ca.ThoiGianApDungDen = dfApDungDen.SelectedDate;
            //
            if (txtSoPhutChoPhepDiMuon.Text != "")
                ca.SoPhutChoPhepDiMuon = double.Parse(txtSoPhutChoPhepDiMuon.Text);
            if (txtSoPhutChoPhepVeSom.Text != "")
                ca.SoPhutChoPhepVeSom = double.Parse(txtSoPhutChoPhepVeSom.Text);
            ca.DangSuDung = chkDangSuDung.Checked;
            //
            ca.MaDonVi = Session["MaDonVi"].ToString();
            ca.CreatedBy = CurrentUser.ID;
            ca.CreatedDate = DateTime.Now;

            if (e.ExtraParams["Command"] == "Edit")
            {
                ca.ID = int.Parse(hdfRecordID.Text);
                dsController.Update(ca);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
                grp_DanhSachCa.Reload();
                wdThemCaLamViec.Hide();
            }
            else
            {
                DAL.DanhSachCa tmp = dsController.GetOneByMaCa(ca.MaCa);
                if (tmp != null)
                {
                    X.Msg.Alert("Thông báo", "Mã ca đã tồn tại. Vui lòng nhập mã ca khác!").Show();
                    return;
                }
                dsController.Insert(ca);
                Dialog.ShowNotification("Thêm mới thành công ca!");
                grp_DanhSachCa.Reload();
            }
            if (e.ExtraParams["Closed"] == "True")
            {
                wdThemCaLamViec.Hide();
            }
            else
            {
                ResourceManager1.RegisterClientScriptBlock("rl1f", "resetForm();");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnCapNhatQuyTac_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.QuyTacLamThemGio quyTac = new DAL.QuyTacLamThemGio();
            if (e.ExtraParams["Command"] == "Edit")
            {
                quyTac = new QuyTacLamThemGioController().GetByID(int.Parse("0" + hdfIDQuyTac.Text));
            }
            quyTac.TuGio = GetTime(tfTuGio.Text);
            quyTac.DenGio = GetTime(tfDenGio.Text);
            if (cbxLoaiNgay.SelectedItem.Value != null)
                quyTac.LoaiNgay = cbxLoaiNgay.SelectedItem.Value;
            if (txtHeSoLuong.Text != "")
            {
                quyTac.NhanHeSo = decimal.Parse("0" + txtHeSoLuong.Text.Replace('.', ','));
            }
            //if (hdfQuyTacFrMaCa.Text != "")
            //    quyTac.FrMaCa = int.Parse(hdfQuyTacFrMaCa.Text);
            //else
            //    quyTac.FrMaCa = int.Parse(cbxQuyTacChonCaLamViec.SelectedItem.Value);
            quyTac.MaCa = e.ExtraParams["MaCa"].ToString();
            quyTac.CreatedBy = CurrentUser.ID;
            quyTac.CreatedDate = DateTime.Now;
            quyTac.Order = int.Parse("0" + txtOrder.Text);
            if (e.ExtraParams["Command"] == "Edit")
            {
                new QuyTacLamThemGioController().Update(quyTac);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công");
                ResourceManager1.RegisterClientScriptBlock("rlst1", "#{wdQuyTacLamThemGio}.hide(); #{grp_QuyTacLamThemGio}.reload();");
            }
            else
            {
                new QuyTacLamThemGioController().Insert(quyTac);
                Dialog.ShowNotification("Thêm mới dữ liệu thành công");
                ResourceManager1.RegisterClientScriptBlock("rlst2", "#{grp_QuyTacLamThemGio}.reload();");
            }
            if (e.ExtraParams["Closed"] == "True")
            {
                wdQuyTacLamThemGio.Hide();
            }
            else
            {
                ResourceManager1.RegisterClientScriptBlock("rlst4", "ResetQuyTacLamThemGio();");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnEditQT_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfIDQuyTac.Text == "")
            {
                X.Msg.Alert("Thông báo", "Không tìm thấy quy tắc làm thêm giờ").Show();
                return;
            }
            DAL.QuyTacLamThemGio quyTac = new QuyTacLamThemGioController().GetByID(int.Parse("0" + hdfIDQuyTac.Text));
            if (quyTac == null)
            {
                X.Msg.Alert("Thông báo", "Không tìm thấy quy tắc làm thêm giờ").Show();
                return;
            }
            //cbxQuyTacChonCaLamViec.SetValue(quyTac.FrMaCa); 
            tfTuGio.SetValue(quyTac.TuGio);
            tfDenGio.SetValue(quyTac.DenGio);
            cbxLoaiNgay.SetValue(quyTac.LoaiNgay);
            txtHeSoLuong.SetValue(quyTac.NhanHeSo);
            txtOrder.SetValue(quyTac.Order);
            wdQuyTacLamThemGio.Title = "Sửa thông tin quy tắc làm thêm giờ";
            wdQuyTacLamThemGio.Icon = Icon.ClockEdit;
            wdQuyTacLamThemGio.Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnCapNhatCauHinh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            HeThongController controller = new HeThongController();

            controller.CreateOrSave(SystemConfigParameter.DSC_GIOVAO, chkGioVao.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_GIORA, chkGioRa.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_SOGIOLAM, chkSoGioLam.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_CHOPHEPDIMUON, chkChoPhepDiMuon.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_CHOPHEPVESOM, chkChoPhepVeSom.Checked.ToString(), CurrentUser.ID, maDV);
            //   controller.CreateOrSave(SystemConfigParameter.DSC_BATDAUTINHLAMTHEMDAUGIO, chkBatDauTinhLamThemDauGio.Checked.ToString(), CurrentUser.ID, maDV);
            //   controller.CreateOrSave(SystemConfigParameter.DSC_BATDAULAMTHEMCUOIGIO, chkBatDauTinhLamThemCuoiGio.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_APDUNGTUNGAY, chkApDungTuNgay.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_APDUNGDENNGAY, chkApDungDenNgay.Checked.ToString(), CurrentUser.ID, maDV);

            controller.CreateOrSave(SystemConfigParameter.DSC_QUETTHEDAUCA, chkQuetTheDauCa.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_QUETTHENGHIDAUCA, chkQuetTheNghiDauCa.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_QUETTHEVAOCASAU, chkQuetTheVaoCaSau.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_QUETTHECUOICA, chkQuetTheCuoiCa.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_PHUCAPCA, chkPhuCapCa.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_MUCLUONGCA, chkMucLuongCa.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_NGAYAPDUNG, chkNgayApDung.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_NGAYTAO, chkNgayTao.Checked.ToString(), CurrentUser.ID, maDV);
            controller.CreateOrSave(SystemConfigParameter.DSC_LOAICA, chkLoaiCa.Checked.ToString(), CurrentUser.ID, maDV);

            Dialog.ShowNotification("Đã lưu cấu hình");
            wdConfigGridPanel.Hide();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    #region Combobox OnRefreshData
    protected void grp_QuyTacLamThemGio_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (hdfRecordID.Text == "")
            {
                return;
            }
            List<QuyTacLamThemGioInfo> list = new QuyTacLamThemGioController().GetByFrkeyMaCa(int.Parse(hdfRecordID.Text));
            //foreach (var item in list)
            //{
            //    item.TenCa = GetNgayApDung(item.NgayApDung) + " (" + item.GioVao + " - " + item.GioRa + ")";
            //}
            grp_QuyTacLamThemGio_Store.DataSource = list;
            grp_QuyTacLamThemGio_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Lỗi xảy ra khi tải các quy tắc làm thêm giờ: " + ex.Message).Show();
        }
    }

    //protected void cbxCaLamViecStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    List<DAL.DanhSachCa> lists = new DanhSachCaController().GetByMaCa(hdfRecordID.Text);
    //    foreach (var item in lists)
    //    {
    //        item.NgayApDung = GetNgayApDung(item.NgayApDung);
    //    }
    //    cbxCaLamViecStore.DataSource = lists;
    //    cbxCaLamViecStore.DataBind();
    //}

    protected void cbxLoaiCaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbxLoaiCaStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select ID, Value from dbo.ThamSoTrangThai where ParamName = 'PhanLoaiCa' AND IsInUsed = 1");
            cbxLoaiCaStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion

    #region Other Function
    private string GetTime(string time)
    {
        if (time == "" || time.Contains("-"))
            return "";
        int pos = time.LastIndexOf(':');
        if (pos == -1)
            return "";
        return time.Substring(0, pos);
    }

    protected void EditCaLamViec(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachCa ca = new DanhSachCaController().GetByPrkey(int.Parse(hdfRecordID.Text));
            if (ca == null)
            {
                Dialog.ShowNotification("Không tìm thấy dữ liệu");
                return;
            }
            txtMaCa.Text = ca.MaCa;
            txtTenCa.Text = ca.TenCa;
            txtPhuCapCa.SetValue(ca.PhuCapCa);
            txtLuongCuaCa.SetValue(ca.TienLuongCa);
            txtTongSoGio.SetValue(ca.TongGio);
            cbxLoaiCa.SetValue(ca.LoaiCa);
            //cbxNgayApDung.SetValue(ca.NgayApDung);
            //
            if (ca.GioVao != "")
                tfBatDauCa.Text = ca.GioVao;
            if (ca.NghiGiuaCa != "")
                tfNghiNuaCaDau.Text = ca.NghiGiuaCa;
            //if (ca.BatDauTinhLamThemDauGio != "")
            //    tfBatDauLamThemDauGio.SetValue(ca.BatDauTinhLamThemDauGio);
            if (ca.VaoGiuaCa != "")
                tfBatDauCaSau.Text = ca.VaoGiuaCa;
            if (ca.GioRa != "")
                tfKetThucCaSau.Text = ca.GioRa;
            //if (ca.BatDauTinhLamThemCuoiGio != "")
            //    tfBatDauLamThemCuoiGio.SetValue(ca.BatDauTinhLamThemCuoiGio);
            //
            chkRaNgoaiKhongBiTruGio.Checked = bool.Parse(ca.RaNgoaiKhongBiTruGio.ToString());
            //
            if (ca.BatDauQuetTheLan1 != "")
                tfDauCaTu.Text = ca.BatDauQuetTheLan1;
            if (ca.KetThucQuetTheLan1 != "")
                tfDauCaDen.Text = ca.KetThucQuetTheLan1;
            if (ca.BatDauQuetTheLan2 != "")
                tfGiuaCaRaTu.Text = ca.BatDauQuetTheLan2;
            if (ca.KetThucQuetTheLan2 != "")
                tfGiuaCaRaDen.Text = ca.KetThucQuetTheLan2;
            if (ca.BatDauQuetTheLan3 != "")
                tfGiuaCaVaoTu.Text = ca.BatDauQuetTheLan3;
            if (ca.KetThucQuetTheLan3 != "")
                tfGiuaCaVaoDen.Text = ca.KetThucQuetTheLan3;
            if (ca.BatDauQuetTheLan4 != "")
                tfCuoiCaTu.Text = ca.BatDauQuetTheLan4;
            if (ca.KetThucQuetTheLan4 != "")
                tfCuoiCaDen.Text = ca.KetThucQuetTheLan4;
            //
            //if (!SoftCore.Util.GetInstance().IsDateNull(ca.ThoiGianApDungTu))
            //    dfApDungTu.SetValue(ca.ThoiGianApDungTu);
            //if (!SoftCore.Util.GetInstance().IsDateNull(ca.ThoiGianApDungDen))
            //    dfApDungDen.SetValue(ca.ThoiGianApDungDen);
            //
            txtSoPhutChoPhepDiMuon.SetValue(ca.SoPhutChoPhepDiMuon);
            txtSoPhutChoPhepVeSom.SetValue(ca.SoPhutChoPhepVeSom);
            chkDangSuDung.Checked = ca.DangSuDung;

            txtMaCa.Disabled = true;
            wdThemCaLamViec.Title = "Sửa thông tin phân ca";
            wdThemCaLamViec.Icon = Icon.ClockEdit;

            wdThemCaLamViec.Show();
        }
        catch
        {
            throw;
        }
    }

    protected void btnXoa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //SelectedRowCollection selectedRows = RowSelectionModel1.SelectedRows;
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                // xóa đăng ký làm thêm giờ
                //new DangKyLamThemGioController().DeleteByPrkeyCa(int.Parse(item.RecordID));
                // xóa quy tắc làm thêm giờ
                //new QuyTacLamThemGioController().DeleteByFrkeyCa(int.Parse(item.RecordID));
                // xóa ca
                new DanhSachCaController().DeleteByID(int.Parse(item.RecordID));
            }
            hdfRecordID.Text = "";
            grp_DanhSachCa.Reload();
            grp_QuyTacLamThemGio.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void mnuNhanDoi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachCa ca = new DanhSachCaController().GetOneByMaCa(txtmaloaihdcoppy.Text);
            if (ca != null)
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Mã ca đã tồn tại").Show();
                return;
            }

            DAL.DanhSachCa oldCa = new DanhSachCaController().GetByPrkey(int.Parse(hdfRecordID.Text));
            if (oldCa == null)
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy ca làm việc").Show();
            }
            DAL.DanhSachCa newCa = new DAL.DanhSachCa
            {
                BatDauQuetTheLan1 = oldCa.BatDauQuetTheLan1,
                BatDauQuetTheLan2 = oldCa.BatDauQuetTheLan2,
                BatDauQuetTheLan3 = oldCa.BatDauQuetTheLan3,
                BatDauQuetTheLan4 = oldCa.BatDauQuetTheLan4,
                BatDauTinhLamThemCuoiGio = oldCa.BatDauTinhLamThemCuoiGio,
                BatDauTinhLamThemDauGio = oldCa.BatDauTinhLamThemDauGio,
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                DangSuDung = oldCa.DangSuDung,
                GioRa = "",
                GioVao = "",
                KetThucQuetTheLan1 = oldCa.KetThucQuetTheLan1,
                KetThucQuetTheLan2 = oldCa.KetThucQuetTheLan2,
                KetThucQuetTheLan3 = oldCa.KetThucQuetTheLan3,
                KetThucQuetTheLan4 = oldCa.KetThucQuetTheLan4,
                MaDonVi = oldCa.MaDonVi,
                NghiGiuaCa = oldCa.NghiGiuaCa,
                PhuCapCa = oldCa.PhuCapCa,
                RaNgoaiKhongBiTruGio = oldCa.RaNgoaiKhongBiTruGio,
                SoPhutChoPhepDiMuon = oldCa.SoPhutChoPhepDiMuon,
                SoPhutChoPhepVeSom = oldCa.SoPhutChoPhepVeSom,
                TenCa = oldCa.TenCa,
                ThoiGianApDungDen = oldCa.ThoiGianApDungDen,
                ThoiGianApDungTu = oldCa.ThoiGianApDungTu,
                TienLuongCa = oldCa.TienLuongCa,
                VaoGiuaCa = oldCa.VaoGiuaCa,
                MaCa = txtmaloaihdcoppy.Text,
                LoaiCa = oldCa.LoaiCa
            };
            new DanhSachCaController().Insert(newCa);
            wdInputNewPrimaryKey.Hide();
            grp_DanhSachCa.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    private void HideColumn()
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("SystemConfig_GetConfigByPrefix", "@Prefix", "@MaDonVi", "DSC_", Session["MaDonVi"].ToString());
            List<string> columnList = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                if (bool.Parse(row["VAR_VALUE"].ToString()) == false)
                    columnList.Add(row["VAR_NAME"].ToString());
            }
            foreach (var item in grp_DanhSachCa.ColumnModel.Columns)
            {
                if (columnList.Contains(item.ColumnID))
                {
                    item.Hidden = true;
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    private string GetNgayApDung(string value)
    {
        if (value == "NgayThuong")
            return "Ngày thường";
        if (value == "NgayNghi")
            return "Ngày nghỉ";
        if (value == "NgayLe")
            return "Ngày lễ";
        return "";
    }
    #endregion

    [DirectMethod]
    public void AfterEdit_QuyTacLamThemGio(int prkey, string newValue)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_QuyTacLamThemGio_UpdateLoaiNgay", "@ID", "@Value", prkey, newValue);
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
}