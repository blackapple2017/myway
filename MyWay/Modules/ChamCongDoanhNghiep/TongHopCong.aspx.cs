using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using Controller.ChamCongDoanhNghiep;
using DAL;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_TongHopCong : WebBase
{
    int idBangTongHopCong = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "'); grpTongHopCongStore.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
            if (idBangTongHopCong != 0)
            {
                DAL.DanhSachBangTongHopCong thc = new DanhSachBangTongHopCongController().GetById(idBangTongHopCong);
                grpTongHopCong.Title = thc.Title;
                hdfIdBangTongHopCong.Text = idBangTongHopCong.ToString();
                grpTongHopCong.Reload();
                if (thc.Lock == true)
                {
                    //btnTongHopCong.Disabled = true;
                    btnEditNhanVien.Disabled = true;
                    //btnSave.Disabled = true;
                    btnMoKhoaBangTongHopCong.Show();
                    btnKhoaBangChamCong.Hide();
                    hdfIsLocked.Text = "true";
                }
                else
                {
                    //btnTongHopCong.Disabled = false;
                    btnEditNhanVien.Disabled = false;
                    //btnSave.Disabled = false;
                    btnMoKhoaBangTongHopCong.Hide();
                    btnKhoaBangChamCong.Show();
                    hdfIsLocked.Text = "false";
                }
            }
            SetEditor();
        }
    }

    #region Cấu hình bảng công
    private void SetEditor()
    {
        for (int i = 4; i < grpTongHopCong.ColumnModel.Columns.Count; i++)
        {
            Ext.Net.TextField txtEditor = new TextField();
            txtEditor.MaskRe = "/[0-9.]/";
            txtEditor.ID = "txtEditor" + i;
            grpTongHopCong.ColumnModel.Columns[i].Editor.Add(txtEditor);
        }
        if (hdfIsLocked.Text == "true")
            SetEditable(false);
        else
            SetEditable(true);
    }

    private void SetEditable(bool value)
    {
        for (int i = 4; i < grpTongHopCong.ColumnModel.Columns.Count; i++)
        {
            grpTongHopCong.ColumnModel.Columns[i].Editable = value;
        }
    }
    #endregion

    #region Quản lý bảng công

    protected void grp_danhSachBangTongHopCongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        //grp_danhSachBangTongHopCongStore.DataSource = new DanhSachBangTongHopCongController().GetByAll(Session["MaDonVi"].ToString(),
        //    int.Parse(cbChonThang.SelectedItem.Value), int.Parse(txtCurrentYear.Text));
        //grp_danhSachBangTongHopCongStore.DataBind();
    }

    /// <summary>
    /// Chọn bảng chấm công
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDongYChon_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //if (hdfTmpID.Text == "")
            //{
            //    X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy mã bảng tổng hợp công").Show();
            //    return;
            //}
            //DAL.DanhSachBangTongHopCong bang = new DanhSachBangTongHopCongController().GetById(int.Parse(hdfTmpID.Text));
            //idBangTongHopCong = bang.ID;
            //hdfIdBangTongHopCong.Text = bang.ID.ToString();
            //grpTongHopCong.Title = bang.Title;
            //if (bang.Lock == true)
            //{
            //    btnKhoaBangChamCong.Hide();
            //    btnMoKhoaBangTongHopCong.Show();
            //}
            //else
            //{
            //    btnKhoaBangChamCong.Show();
            //    btnMoKhoaBangTongHopCong.Hide();
            //}
            //if (bang.Lock == true)
            //{
            //    btnChuanBiDuLieuDauVao.Disabled = true;
            //    btnTongHopCong.Disabled = true;
            //    btnEditHangLoat.Disabled = true;
            //    btnSave.Disabled = true;
            //    hdfIsLocked.Text = "true";
            //}
            //else
            //{
            //    btnChuanBiDuLieuDauVao.Disabled = false;
            //    btnTongHopCong.Disabled = false;
            //    btnEditHangLoat.Disabled = false;
            //    btnSave.Disabled = false;
            //    hdfIsLocked.Text = "false";
            //}

            //if (hdfIsLocked.Text == "true")
            //    SetEditable(false);
            //else
            //    SetEditable(true);

            //grpTongHopCong.Reload();
            wdChonBangTongHopCong.Hide();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }
    #endregion

    #region Khóa, mở khóa bảng công
    /// <summary>
    /// Khóa các bảng chấm công được chọn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnKhoaBangChamCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfIdBangTongHopCong.Text == "")
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy bảng tổng hợp công").Show();
                return;
            }
            new TongHopCongController().Lock(int.Parse(hdfIdBangTongHopCong.Text), true);

            //btnChuanBiDuLieuDauVao.Disabled = true;
            //btnTongHopCong.Disabled = true;
            //btnEditHangLoat.Disabled = true;
            //btnSave.Disabled = true;
            //hdfIsLocked.Text = "true";
            //SetEditable(false);

            //Dialog.ShowNotification("Đã khóa bảng tổng hợp công");
            //btnMoKhoaBangTongHopCong.Show();
            //btnKhoaBangChamCong.Hide();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnMoKhoaBangTongHopCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (hdfIdBangTongHopCong.Text == "")
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy bảng tổng hợp công").Show();
                return;
            }
            new TongHopCongController().Lock(int.Parse(hdfIdBangTongHopCong.Text), false);

            //btnChuanBiDuLieuDauVao.Disabled = false;
            //btnTongHopCong.Disabled = false;
            //btnEditHangLoat.Disabled = false;
            //btnSave.Disabled = false;
            //hdfIsLocked.Text = "true";
            //SetEditable(true);

            //Dialog.ShowNotification("Đã mở khóa bảng tổng hợp công");
            //btnKhoaBangChamCong.Show();
            //btnMoKhoaBangTongHopCong.Hide();
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    #region Chức năng khác
    /// <summary>
    /// Thêm cán bộ vào bảng tổng hợp công
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            string ma = "", errStr = string.Empty;
            // lấy danh sách các mã cán bộ được chọn
            SelectedRowCollection selectedRows = ucChooseEmployee1.SelectedRow;
            foreach (var item in selectedRows)
            {
                try
                {
                    DAL.TongHopCong thcong = new TongHopCong
                    {
                        MA_CB = item.RecordID,
                        IdDanhSachBangTongHopCong = int.Parse(hdfIdBangTongHopCong.Text)
                    };
                    DAL.TongHopCong tmp = new TongHopCongController().GetByMaCBAndIdDanhSachBangTHC(item.RecordID, int.Parse(hdfIdBangTongHopCong.Text));
                    if (tmp == null)
                    {
                        new TongHopCongController().Insert(thcong);
                    }
                    else
                    {
                        ma += item.RecordID + ", ";
                        count++;
                    }
                }
                catch (Exception)
                {
                    count++;
                }
            }
            if (count == 0)
                Dialog.ShowNotification("Thêm mới cán bộ thành công");
            else
            {
                errStr += "Không thêm được " + count + " cán bộ.";
                if (ma != "")
                {
                    ma = ma.Remove(ma.LastIndexOf(','));
                    errStr += " Các cán bộ có mã " + ma + " đã tồn tại";
                }
                X.Msg.Alert("Thông báo từ hệ thống", errStr).Show();
            }
            grpTongHopCong.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void mnuXoaNhanVien_Click(object sender, DirectEventArgs e)
    {
        SelectedRowCollection selectedRows = RowSelectionModelTongHopCong.SelectedRows;
        string error = string.Empty;
        foreach (var item in selectedRows)
        {
            try
            {
                new TongHopCongController().Delete(int.Parse(item.RecordID));
            }
            catch (Exception ex)
            {
                error += ex.Message + "<br />";
            }
        }
        if (!string.IsNullOrEmpty(error))
        {
            X.Msg.Alert("Thông báo từ hệ thống", error).Show();
        }
        grpTongHopCong.Reload();
    }
    #endregion

    #region Tổng hợp công
    protected void mnuTongHopTatCa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            // lấy danh sách mã chấm công của các toàn bộ cán bộ
            List<TongHopCongTheoThangInfo> lists = new TongHopCongController().GetMaChamCongByIdDanhSachBangTHC(int.Parse(hdfIdBangTongHopCong.Text));
            if (lists.Count > 0 && lists[0].IdDanhSachTongHopCong == int.Parse(hdfIdBangTongHopCong.Text))
            {
                wdConfirm.Show();
            }
            else
            {
                string result = TinhToanThongTinCong(lists, true);

                if (string.IsNullOrEmpty(result))
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Tổng hợp công thành công").Show();

                    grpTongHopCong.Reload();
                }
                else
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + result).Show();
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }

    protected void btnDongYCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (rdCapNhatLai.Checked == true)
            {
                List<TongHopCongTheoThangInfo> lists = new TongHopCongController().GetMaChamCongByIdDanhSachBangTHC(int.Parse(hdfIdBangTongHopCong.Text));

                string result = TinhToanThongTinCong(lists, false);

                if (string.IsNullOrEmpty(result))
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Tổng hợp công thành công").Show();

                    grpTongHopCong.Reload();

                    wdConfirm.Hide();
                }
                else
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + result).Show();
                }
            }
            else
            {
                wdConfirm.Hide();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    /// <summary>
    /// Tổng hợp công cho các cán bộ được chọn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuTongHopDuocChon_Click(object sender, DirectEventArgs e)
    {
        try
        {
            List<int> listID = new List<int>();
            SelectedRowCollection selectedRows = RowSelectionModelTongHopCong.SelectedRows; // ID bảng tổng hợp công
            foreach (var item in selectedRows)
                listID.Add(int.Parse(item.RecordID));

            List<TongHopCongTheoThangInfo> lists = new TongHopCongController().GetMaChamCongByIdDanhSachBangTHC(int.Parse(hdfIdBangTongHopCong.Text),
                                                                                    listID);
            string result = TinhToanThongTinCong(lists, false);

            if (string.IsNullOrEmpty(result))
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Tổng hợp công thành công").Show();

                grpTongHopCong.Reload();
            }
            else
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + result).Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }

    /// <summary>
    /// Hàm tính toán tổng hợp công
    /// </summary>
    /// <param name="lists">Danh sách thông tin chấm công cần tính</param>
    /// <param name="isNew"><b>true</b> nếu tổng hợp mới, <b>false</b> nếu cập nhật lại</param>
    private string TinhToanThongTinCong(List<TongHopCongTheoThangInfo> lists, bool isNew)
    {
        try
        {
            TimeController timeController = new TimeController();
            string error = "";
            #region lấy các cấu hình cho tổng hợp công
            // lấy các ngày cuối tuần trong tháng
            List<string> listWeekend = timeController.GetWeekKend(Session["MaDonVi"].ToString());

            // lấy danh sách chấm công đặc biệt
            Dictionary<string, int> dicSpecialEmployee = new Dictionary<string, int>();

            List<DAL.DanhSachNhanVienChamCongDacBiet> listEmployees = new DieuKienChamCongDacBietController().GetByAll();
            foreach (var item in listEmployees)
            {
                dicSpecialEmployee.Add(item.MaCB, item.SoLanChitTay);
            }
            // lấy ngày công chuẩn
            //double ngayCongChuan = timeController.GetNumberDayOfWork();
            #endregion

            // lấy tháng
            DAL.DanhSachBangTongHopCong thcong = new DanhSachBangTongHopCongController().GetById(int.Parse(hdfIdBangTongHopCong.Text));
            //int maxDays = 31;//DateTime.DaysInMonth(thcong.Nam, thcong.Thang);
            int tong = 0;

            foreach (var item in lists)
            {
                try
                {
                    tong++;
                    #region các tham biến
                    double tongGioCongDinhMuc = 0, tongGioCongThucTe = 0;
                    int tongPhutDiTre = 0, tongPhutVeSom = 0, tongSoPhutLamThuaGio = 0;
                    int tongSoPhutLamThemNgayThuong = 0, tongSoPhutLamThemNgayNghi = 0, tongSoPhutLamThemNgayLe = 0;
                    double nghiLe = 0, nghiPhep = 0, nghiCheDo = 0, nghiBu = 0, nghiKhongLuong = 0;
                    int tongSoLamQuenQuetThe = 0, tongSoLanDiMuon = 0, tongSoLanVeSom = 0;
                    string ngayLe = "", thongKeCaLamViec = "";
                    float tongCaLamViecNgayThuong = 0, tongCaLamViecNgayNghi = 0, tongCaLamViecNgayLe = 0, tongThoiGianRaNgoaiBiTruGio = 0, tongCaNghi = 0;
                    bool isFail = false;
                    int soLanChitTayBatBuoc = -1;

                    if (dicSpecialEmployee.ContainsKey(item.MA_CB))
                        soLanChitTayBatBuoc = dicSpecialEmployee[item.MA_CB];

                    // thống kê ca làm việc định dạng MaCa1=a,MaCa2=b
                    Dictionary<string, int> dicThongKeCaLamViec = new Dictionary<string, int>();
                    #endregion

                    // tính toán các ngày nghỉ
                    //if (soLanChitTayBatBuoc == -1)
                    new TongHopCongController().GetNgayNghi(item.MA_CB, thcong.FromDate, thcong.ToDate, ref ngayLe, ref nghiLe, ref nghiPhep,
                        ref nghiCheDo, ref nghiBu, ref nghiKhongLuong, Session["MaDonVi"].ToString());

                    DateTime day = thcong.FromDate;
                    while (day <= thcong.ToDate)
                    {
                        #region tổng hợp thông tin trong một ngày
                        try
                        {
                            #region các biến cục bộ
                            double gioCongDinhMuc = 0, gioCongThucTe = 0;
                            int soPhutDiTre = 0, soPhutVeSom = 0, soPhutDiSom = 0, soPhutVeMuon = 0;
                            int soPhutLamThemNgayThuong = 0, soPhutLamThemNgayNghi = 0, soPhutLamThemNgayLe = 0, soPhutLamThuaGio = 0;
                            int soLanQuenQuetThe = 0, soLanDiMuon = 0, soLanVeSom = 0;
                            float soCaLamViecNgayThuong = 0, soCaLamViecNgayNghi = 0, soCaLamViecNgayLe = 0, thoiGianRaNgoaiBiTruGio = 0, soCaNghi = 0;
                            string thoiGianDiFirst = "", thoiGianVeLast = "";

                            DAL.DanhSachCa ca = new DanhSachCa();
                            #endregion

                            try
                            {
                                // lấy ca làm việc của cán bộ
                                ca = new DanhSachCaController().GetByMaChamCong(item.MaChamCong, day, Session["MaDonVi"].ToString());

                                #region cập nhật thống kê ca làm việc
                                if (ca == null)
                                    continue;
                                #endregion

                                // tính các tham số liên quan
                                if (soLanChitTayBatBuoc == -1)
                                {
                                    new TongHopCongController().GetCaLamViecTrongNgay(ngayLe.Split(','), listWeekend, item.MaChamCong, day, ca, ref dicThongKeCaLamViec,
                                            ref gioCongDinhMuc, ref gioCongThucTe, ref soPhutDiTre, ref soPhutVeSom, ref soPhutDiSom, ref soPhutVeMuon,
                                            ref soPhutLamThemNgayThuong, ref soPhutLamThemNgayNghi, ref soPhutLamThemNgayLe,
                                            ref soLanQuenQuetThe, ref soLanDiMuon, ref soLanVeSom, ref soPhutLamThuaGio,
                                            ref soCaLamViecNgayThuong, ref soCaLamViecNgayNghi, ref soCaLamViecNgayLe, ref thoiGianRaNgoaiBiTruGio, ref soCaNghi,
                                            ref thoiGianDiFirst, ref thoiGianVeLast);

                                    //new TongHopCongController().GetCaLamViecTrongNgay1(ngayLe.Split(','), listWeekend, item.MaChamCong, day, ca, ref gioCongDinhMuc,
                                    //    ref gioCongThucTe, ref soPhutDiTre, ref soPhutVeSom, ref thoiGianDiFirst, ref thoiGianVeLast, ref thoiGianRaNgoaiBiTruGio,
                                    //    ref soLanDiMuon, ref soLanVeSom);
                                }
                                else
                                {
                                    List<DAL.VaoRaCa> dsVaoRaCa = new VaoRaCaController().GetByMaChamCongAndDay(item.MaChamCong, day);

                                    if (dsVaoRaCa.Count >= soLanChitTayBatBuoc)
                                    {
                                        //gioCongDinhMuc += ca.TongGio != null ? ca.TongGio.Value : 0;
                                        //gioCongThucTe += (ca.TongGio != null ? ca.TongGio.Value : 0) * 60;
                                        if (ca.NghiGiuaCa != "" && ca.VaoGiuaCa != "")
                                        {
                                            gioCongThucTe += 1;
                                            soCaLamViecNgayThuong += 1;
                                        }
                                        else
                                        {
                                            gioCongThucTe += 0.5;
                                            soCaLamViecNgayThuong += (float)0.5;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                isFail = true;
                                error += ex.Message + "<br />";
                            }

                            #region tính các thời gian liên quan
                            DAL.TongHopCongTheoNgay theoNgay = new TongHopCongTheoNgay();
                            theoNgay.MaCa = ca.MaCa;
                            theoNgay.MaChamCong = item.MaChamCong;
                            theoNgay.NgayThang = day;
                            //theoNgay.SoLanDiMuon = soLanDiMuon;
                            //theoNgay.SoLanVeSom = soLanVeSom;
                            //theoNgay.SoNgayCong = Math.Round((gioCongThucTe / ca.TongGio == 0 ? 1 : ca.TongGio), 1);
                            theoNgay.SoPhutDiMuon = soPhutDiTre;
                            //theoNgay.SoPhutDiSom = soPhutVeSom;
                            //theoNgay.SoPhutLamThemNgayLe = soPhutLamThemNgayLe;
                            //theoNgay.SoPhutLamThemNgayNghi = soPhutLamThemNgayNghi;
                            //theoNgay.SoPhutLamThemNgayThuong = soPhutLamThemNgayThuong;
                            //theoNgay.SoPhutLamThuaGio = soPhutLamThuaGio;
                            //theoNgay.SoPhutLamViec = gioCongThucTe;
                            //theoNgay.SoPhutRaNgoai = 
                            //tongGioCongDinhMuc += gioCongDinhMuc;
                            //tongGioCongThucTe += gioCongThucTe;
                            //tongPhutDiTre += soPhutDiTre;
                            //tongPhutVeSom += soPhutVeSom;
                            //tongSoPhutLamThemNgayThuong += soPhutLamThemNgayThuong;
                            //tongSoPhutLamThemNgayNghi += soPhutLamThemNgayNghi;
                            //tongSoPhutLamThemNgayLe += soPhutLamThemNgayLe;
                            //tongSoLamQuenQuetThe += soLanQuenQuetThe;
                            //tongSoLanDiMuon += soLanDiMuon;
                            //tongSoLanVeSom += soLanVeSom;
                            //tongSoPhutLamThuaGio += soPhutLamThuaGio;

                            //tongCaLamViecNgayThuong += soCaLamViecNgayThuong;
                            //tongCaLamViecNgayNghi += soCaLamViecNgayNghi;
                            //tongCaLamViecNgayLe += soCaLamViecNgayLe;
                            //tongThoiGianRaNgoaiBiTruGio += thoiGianRaNgoaiBiTruGio;
                            //tongCaNghi += soCaNghi;
                            #endregion

                            day.AddDays(1);
                        }
                        catch (Exception ex)
                        {
                            error += ex.Message + "<br />";
                        }
                        #endregion
                    }

                    // thống kê số ca làm việc của từng cán bộ
                    if (soLanChitTayBatBuoc == -1)
                        thongKeCaLamViec = new TongHopCongController().GetThongKeCaLamViec(dicThongKeCaLamViec);

                    #region Cập nhật vào bảng tổng hợp công
                    //DAL.TongHopCong cong = new TongHopCong()
                    //{
                    //    MA_CB = item.MA_CB,
                    //    IdDanhSachBangTongHopCong = int.Parse(hdfIdBangTongHopCong.Text),
                    //    SoPhutDiTre = tongPhutDiTre,
                    //    SoPhutLamThemNgayLe = tongSoPhutLamThemNgayLe,
                    //    SoPhutLamThemNgayNghi = tongSoPhutLamThemNgayNghi,
                    //    SoPhutLamThemNgayThuong = tongSoPhutLamThemNgayThuong,
                    //    GioCongThucTe = tongGioCongThucTe,  // tính theo phút
                    //    GioCongDinhMuc = tongGioCongDinhMuc,
                    //    SoPhutVeSom = tongPhutVeSom,
                    //    NghiBu = nghiBu,
                    //    NghiKhongLuong = nghiKhongLuong,
                    //    NghiCheDo = nghiCheDo,
                    //    NghiLe = nghiLe,
                    //    NghiPhep = nghiPhep,
                    //    TinhToanSai = isFail,
                    //    SoLanQuenQuetThe = tongSoLamQuenQuetThe,
                    //    SoLanDiTre = tongSoLanDiMuon,
                    //    SoLanVeSom = tongSoLanVeSom,
                    //    TongThoiGianLamThuaGio = tongSoPhutLamThuaGio,
                    //    ThongKeCaLamViec = thongKeCaLamViec,
                    //    TongCaLamViecNgayThuong = tongCaLamViecNgayThuong,
                    //    TongCaLamViecNgayNghi = tongCaLamViecNgayNghi,
                    //    TongCaLamViecNgayLe = tongCaLamViecNgayLe,
                    //    ThoiGianRaNgoaiBiTru = tongThoiGianRaNgoaiBiTruGio,
                    //    TongCaNghi = tongCaNghi,
                    //};
                    //if (isNew == true)
                    //{
                    //    new TongHopCongController().Insert(cong);
                    //}
                    //else
                    //{
                    //    cong.ID = item.ID;
                    //    new TongHopCongController().Update(cong);
                    //}
                    #endregion
                }
                catch (Exception ex)
                {
                    error += ex.Message + "<br />";
                }
            }
            X.Msg.Alert("", error).Show();
            return "";
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
            return ex.Message;
        }
    }

    private string GetNameDay(DateTime day, int sa)
    {
        string name = "";
        if (sa == 0)
            name = "Morning";
        else if (sa == 1)
            name = "Afternoon";
        switch (day.DayOfWeek)
        {
            case DayOfWeek.Friday:
                name = "Friday" + name;
                break;
            case DayOfWeek.Saturday:
                name = "Saturday" + name;
                break;
            case DayOfWeek.Sunday:
                name = "Sunday";
                break;
            default:
                name = "";
                break;
        }
        return name;
    }
    #endregion
}