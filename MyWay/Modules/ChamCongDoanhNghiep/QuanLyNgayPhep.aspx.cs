using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;
using ExtMessage;
using DataController;

public partial class Modules_ChamCongDoanhNghiep_QuanLyNgayPhep : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfDateNow.SetValue( DateTime.Now);
            triggerXemTheoNam.Text = DateTime.Now.Year.ToString();
            hdfMaDonVi2.Text = Session["MaDonVi"].ToString();
            //grpDanhSachNgayPhep.WhereClause = "Nam = " + triggerXemTheoNam.Text;
            grpDanhSachNgayPhep.Title = "Danh sách ngày phép cán bộ công nhân viên năm " + DateTime.Now.Year;
            hdfMenuID.SetValue(MenuID);
            hdfUserID.SetValue(CurrentUser.ID);

            // phân quyền
            SetVisibleByControlID(btnUserManager, mnuThemNhanVien, mnuLoaiBoNhanVien, btnDieuChinhNgayPhep);
            MenuItem1.Visible = mnuThemNhanVien.Visible;
            MenuItemXoaNV.Visible = mnuLoaiBoNhanVien.Visible;
            mnuDieuChinhNgayPhep.Visible = btnDieuChinhNgayPhep.Visible;

            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "'); PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }

        if (btnDieuChinhNgayPhep.Visible)
        {
            grpDanhSachNgayPhep.Listeners.RowDblClick.Handler = "setValuewdDieuChinhNgayPhep(); wdDieuChinhNgayPhep.show();";

        }
        ucChooseEmployee1.AfterClickAcceptButton += ucChooseEmployee1_AfterClickAcceptButton;
        //grpDanhSachNgayPhep.DirectEvents.DocumentReady.Event += new ComponentDirectEvent.DirectEventHandler(DocumentReady_Event);
    }


    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        string row = ",";
        foreach (var item in ucChooseEmployee1.SelectedRow)
        {
            row += item.RecordID + ",";
        }
        hdfSelectedEmployees.Text += row;
        grpDanhSachNhanVienStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("NgayPhep_DanhSachNhanVien", "@maCBList", hdfSelectedEmployees.Text);
        grpDanhSachNhanVienStore.DataBind();
    }
    [DirectMethod]
    public void DocumentReady_Event()
    {
        DanhSachNgayPhepController controller = new DanhSachNgayPhepController();
        int count = 0;
        controller.GetNhanVienDaNghi(0, 1, Session["MaDonVi"].ToString(), 1, out count);
        if (count > 0)
        {
            wdNhanVienCanLoaiBo.Show();
        }
    }


    protected void btnTinhSoNgayPhep_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HeThongController system = new HeThongController();
            DanhSachNgayPhepController controller = new DanhSachNgayPhepController();
            DAL.DanhSachNgayPhep ngayPhep = new DanhSachNgayPhep()
            {
                Nam = DateTime.Now.Year,
                CreatedBy = CurrentUser.ID,
                SoNgayPhepNamNay = string.IsNullOrEmpty(nbfSoNgayPhep.Text) ? 0 : int.Parse(nbfSoNgayPhep.Text),
                SoNgayPhepNamTruoc = 0,
                SoNgayPhepDuocThem = string.IsNullOrEmpty(nbfSoNgayPhepThuongThem.Text) ? 0 : int.Parse(nbfSoNgayPhepThuongThem.Text),
                SoNgayPhepCongDonToiDaTrongThang = int.Parse(nbfSoNgayPhepCongDonToiDaTrong1Thang.Text),
                CreatedDate = DateTime.Now,
            };
            if (ngayPhep.SoNgayPhepDuocThem != 0)
            {
                ngayPhep.ThoiHanSuDungNgayPhepDuocThem = dfHanDungNgayPhepThuongThem.SelectedDate;
            }
            if (ngayPhep.SoNgayPhepNamTruoc != 0)
            {
                ngayPhep.ThoiHanSuDungNgayPhepNamTruoc = dfHanDungNgayPhepNamTruoc.SelectedDate;
            }
            if (rdApDungChoTatCaNhanVien.Checked)
            {
                controller.TinhSoNgayPhep(ngayPhep, Session["MaDonVi"].ToString());
            }
            //else if (rdChiNhungNhanVienDuocChon.Checked)
            //{
            //    foreach (var item in RowSelectionModel1.SelectedRows)
            //    {
            //        controller.TinhSoNgayPhep(ngayPhep, int.Parse(item.RecordID));
            //    }
            //}
            wdTinhSoNgayPhep.Hide();
            //   GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        try
        {

            DanhSachNgayPhepController controller = new DanhSachNgayPhepController();
            DAL.DanhSachNgayPhep ngayPhep = controller.GetByID(int.Parse(e.ExtraParams["RecordID"]));
            if (ngayPhep != null)
            {
                nbfSoNgayPhep.Value = ngayPhep.SoNgayPhepNamNay;
                nbfSoNgayPhepThuongThem.Value = ngayPhep.SoNgayPhepDuocThem;
                chkNgayNghiPhepNamTruoc.Value = ngayPhep.SoNgayPhepNamTruoc;
                if (ngayPhep.ThoiHanSuDungNgayPhepNamTruoc.HasValue && ngayPhep.ThoiHanSuDungNgayPhepNamTruoc.Value.ToString().Contains("0001") == false)
                {
                    dfHanDungNgayPhepNamTruoc.SelectedDate = ngayPhep.ThoiHanSuDungNgayPhepNamTruoc.Value;
                }
                if (ngayPhep.ThoiHanSuDungNgayPhepDuocThem.HasValue && ngayPhep.ThoiHanSuDungNgayPhepDuocThem.Value.ToString().Contains("0001") == false)
                {
                    dfHanDungNgayPhepThuongThem.SelectedDate = ngayPhep.ThoiHanSuDungNgayPhepDuocThem.Value;
                }
                nbfSoNgayPhepCongDonToiDaTrong1Thang.Value = ngayPhep.SoNgayPhepCongDonToiDaTrongThang;
                wdTinhSoNgayPhep.Show();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    #region Quản lý nhân viên

    public void btnAccept_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DanhSachNgayPhepController controller = new DanhSachNgayPhepController();
            int thamNien = 0;
            string loaiHopDong = "";
            if (!string.IsNullOrEmpty(nbfThamNien.Text))
            {
                if (cbThoiGianThamNien.SelectedItem.Value == "UsingMonthUnit")
                {
                    thamNien = int.Parse(nbfThamNien.Text);
                }
                else
                {
                    thamNien = int.Parse(nbfThamNien.Text) * 12;
                }
            }
            foreach (var item in cbHopDongLoaiHopDong.SelectedItems)
            {
                loaiHopDong += item.Value + ",";
            }
            if (!string.IsNullOrEmpty(loaiHopDong))
            {
                loaiHopDong = "," + loaiHopDong;
            }
            DateTime? HanSuDungPhep = null;
            if (!SoftCore.Util.GetInstance().IsDateNull(dfHanSuDungNPNamTruoc.SelectedDate))
                HanSuDungPhep = dfHanSuDungNPNamTruoc.SelectedDate;
            controller.AddAllEmployee(hdfSelectedEmployees.Text, Session["MaDonVi"].ToString(), thamNien, int.Parse("0" + cbxHinhThucLamViec.SelectedItem.Value),
                                      loaiHopDong, float.Parse("0" + nbfSoNgayPhepDuocThem.Text), float.Parse("0" + nbfSoNgayPhepNamNay.Text), int.Parse("0"+nbfNamAPDungNgayPhep.Text), CurrentUser.ID,
                                      chkTuDongTinhNgayPhep.Checked, nbfSoNgayPhepNamTruoc.Checked, rdGhiDeThongTinMoi.Checked, HanSuDungPhep);
            wdThemNhanVien.Hide();
            grpDanhSachNgayPhep.Reload();
            //Dialog.ShowNotification("Cập nhật thành công");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra ", ex.Message).Show();
        }
    }

    protected void mnuLoaiBoNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModelNgayPhep.SelectedRows)
            {
                new DanhSachNgayPhepController().DeleteEmployee(int.Parse(item.RecordID));
            }
            RowSelectionModelNgayPhep.ClearSelections();
            grpDanhSachNgayPhep.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnLoaiBoNhanVienDaNghi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            new DanhSachNgayPhepController().RemoveNhanVienDaNghi(Session["MaDonVi"].ToString(), !chkNotifyToDeleteAgain.Checked, bool.Parse(e.ExtraParams["LoaiBo"]));
            grpDanhSachNgayPhep.Reload();
            wdNhanVienCanLoaiBo.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion

    protected void btnOKDieuChinhNgayPhep_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DanhSachNgayPhepController controller = new DanhSachNgayPhepController();
            foreach (var item in RowSelectionModelNgayPhep.SelectedRows)
            {
                DAL.DanhSachNgayPhep obj = new DanhSachNgayPhep()
                {
                    ID = int.Parse(item.RecordID),
                    SoNgayPhepNamTruoc = double.Parse("0" + nbfDieuChinhSoNPNamTruoc.Text.Replace('.', ',')),
                    Thang1 = double.Parse("0" + nbfThang1.Text.Replace('.', ',')),
                    Thang2 = double.Parse("0" + nbfThang2.Text.Replace('.', ',')),
                    Thang3 = double.Parse("0" + nbfThang3.Text.Replace('.', ',')),
                    Thang4 = double.Parse("0" + nbfThang4.Text.Replace('.', ',')),
                    Thang5 = double.Parse("0" + nbfThang5.Text.Replace('.', ',')),
                    Thang6 = double.Parse("0" + nbfThang6.Text.Replace('.', ',')),
                    Thang7 = double.Parse("0" + nbfThang7.Text.Replace('.', ',')),
                    Thang8 = double.Parse("0" + nbfThang8.Text.Replace('.', ',')),
                    Thang9 = double.Parse("0" + nbfThang9.Text.Replace('.', ',')),
                    Thang10 = double.Parse("0" + nbfThang10.Text.Replace('.', ',')),
                    Thang11 = double.Parse("0" + nbfThang11.Text.Replace('.', ',')),
                    Thang12 = double.Parse("0" + nbfThang12.Text.Replace('.', ',')),
                    SoNgayPhepNamNay = double.Parse("0" + nbfDieuChinhNgayPhepNamNay.Text.Replace('.', ',')),
                    SoNgayPhepDuocThem = double.Parse("0" + nbfDieuChinhNgayPhepDuocThem.Text.Replace('.', ','))
                };
                controller.UpdateNgayPhep(obj);
            }
            grpDanhSachNgayPhep.Reload();
            wdDieuChinhNgayPhep.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbHopDongLoaiHopDongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbHopDongLoaiHopDongStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_LOAI_HDONG,TEN_LOAI_HDONG from DM_LOAI_HDONG");
            cbHopDongLoaiHopDongStore.DataBind();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void cbxHinhThucLamViec_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbxHinhThucLamViec_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("HinhThucLamViec", true);
        cbxHinhThucLamViec_Store.DataBind();
    }
}