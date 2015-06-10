using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
using System.Data;
using DataController;
using System.Data.SqlClient;
using System.IO;
using LinqToExcel;
using System.Linq.Expressions;

public partial class Modules_TienLuong_KhoanSanXuat_LuongKhoanSanXuat : WebBase
{
    //private List<DAL.CongThucKhoanSanXuat> CongThucKhoanList;
    //private int congchuan = 26; //tạm thời fix cứng, sẽ lấy động từ cấu hình trong form cấu hình thông tin chấm công
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            cbxMonth.SetValue(DateTime.Now.Month);
            spnYear.SetValue(DateTime.Now.Year);

            hdfUserID.SetValue(CurrentUser.ID);
            hdfMenuID.SetValue(MenuID);

            SetVisibleByControlID(mnuAddOne, mnuAddDepartment, btnSua, mnuXoaTheoNgay, mnuXoaNhanVien, btnImportFromExcel);
        }

        if (btnSua.Visible)
        {
            GridPanel1.DirectEvents.CellDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSua_Click);
            GridPanel1.DirectEvents.CellDblClick.Before = "btnCapNhat.hide();btnCapNhatEdit.show();btnUpdateAndClose.hide();cbCanBo.disable();cbxNgay.disable();";
        }

        //hdfMaDonVi.Text = Session["MaDonVi"].ToString();
        new DTH.BorderLayout()
        {
            menuID = MenuID,
            script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "'); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();"
        }.AddDepartmentList(br, CurrentUser.ID, true);
        hdfLuongCoBan.Text = new HeThongController().GetValueByName(SystemConfigParameter.LUONG_CB, Session["MaDonVi"].ToString());
        //if (CongThucKhoanList == null) CongThucKhoanList = new CongThucKhoanSanXuatControler().GetAll();
        // if (congchuan < 0) congchuan = int.Parse("0" + new HeThongController().GetValueByName(SystemConfigParameter.CONG_CHUAN, Session["MaDonVi"].ToString()));
        var grid = GridPanel1;
        var store = grid.GetStore();
        var cm = grid.ColumnModel;

        Renderer f = new Renderer();
        f.Fn = "RenderNgay";

        for (int i = 0; i < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
        {
            int k = i + 1;
            // add to store
            store.Reader[0].Fields.Add("Ngay" + k);
            Column column = new Column()
            {
                ColumnID = "Ngay" + k,
                Header = "Ngày " + k,
                Width = 200,
                DataIndex = "Ngay" + k,
                Align = Alignment.Center,
                Renderer = f
            };
            cm.Columns.Add(column);
        }
        store.Reader[0].Fields.Add("TONG_LUONG");
        Renderer rd = new Renderer();
        rd.Fn = "RenderVND";
        Column colSum = new Column()
        {
            ColumnID = "TONG_LUONG",
            Header = "Tổng lương",
            Width = 100,
            DataIndex = "TONG_LUONG",
            Align = Alignment.Right,
            Renderer = rd
        };
        cm.Columns.Add(colSum);
    }

    #region Thêm nhân viên
    protected void mnuAddOne_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CellSelectionModel sm = this.GridPanel1.SelectionModel.Primary as CellSelectionModel;
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_LuongKhoan_GetInfoEmployeeByMaCB", "@MaCB", sm.SelectedCell.RecordID);
            if (table.Rows.Count > 0)
            {
                DataRow item = table.Rows[0];
                hdfCanBo.SetValue(item["MA_CB"]);
                cbCanBo.Text = item["HO_TEN"].ToString();
                hdfMaBoPhan.SetValue(item["MA_DONVI"].ToString());
                cbxNgay.SetValue(int.Parse(sm.SelectedCell.Name.Replace("Ngay", "")));
                hdfNgay.SetValue(int.Parse(sm.SelectedCell.Name.Replace("Ngay", "")));
                hdfQDLuong.SetValue(item["LuongCung"]);//LuongDongBH
                
                // lấy lương cơ bản (lương đóng BH)
                int thang = int.Parse(cbxMonth.SelectedItem.Value);
                int nam = int.Parse("0" + spnYear.Text);
                double luongcb = new TinhLuongKhoanController().GetLuongDongBH(decimal.Parse(item["PR_KEY"].ToString()), new DateTime(nam, thang, 1));
                if (luongcb == 0)
                {
                    Dialog.ShowNotification("Cán bộ " + item["HO_TEN"].ToString() + " chưa có lương cơ bản");
                }
                // lấy công chuẩn
                double congchuan = new ThietLapCaTheoBoPhanController().GetCongChuan(item["MA_DONVI"].ToString());
                txtLuongCongNhat.SetValue(Math.Round(luongcb / congchuan, 0, MidpointRounding.AwayFromZero));
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            wdLuongKhoanSanXuat.Show();
        }
    }

    protected void ThemNhanVienTheoBoPhan_CLick(object sender, DirectEventArgs e)
    {
        try
        {
            string SelectedDepartment = string.Empty;
            foreach (SelectedListItem item in mcbxBoPhan.SelectedItems)
            {
                SelectedDepartment += item.Value + ",";
            }
            int pos = SelectedDepartment.LastIndexOf(',');
            if (pos != -1)
                SelectedDepartment = SelectedDepartment.Remove(pos);
            int maxDay = DateTime.DaysInMonth(int.Parse(spnYear.Value.ToString()), int.Parse(cbxMonth.SelectedItem.Value));
            DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_LuongKhoan_InsertEmployeeByDepartment", "@MaxDay", "@Month", "@Year", "@SelectedDepartment",
                maxDay, cbxMonth.SelectedItem.Value, spnYear.Value.ToString(), SelectedDepartment);
            wdAddDepartment.Hide();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Đọc lương khoán từ file excel
    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = FileUploadField1.PostedFile;

            //if (file.ContentType != "application/vnd.ms-excel") //ko phải Excel 2003
            //{
            //    Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("NotExcel2003"));
            //    return;
            //}
            if (FileUploadField1.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                string path = string.Empty;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("File"));
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath("File/") + FileUploadField1.FileName;
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }

    /// <summary>
    /// Tải tệp tin excel mẫu lương khoán
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DownloadBangChamCongMau(object sender, DirectEventArgs e)
    {
        try
        {
            string fileName = Server.MapPath("SampleFile/Mau_Luong_Khoan.xls");
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);

            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + file.FullName);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/vnd.ms-excel";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                X.Msg.Alert("Thông báo", "File mẫu không tồn tại").Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }

    protected void cbSheetNameStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            UploadFile();
            string path = Server.MapPath("File/") + FileUploadField1.FileName;
            FileInfo info = new FileInfo(path);
            if (info.Exists)
            {
                List<object> sheetData = new List<object>();
                IEnumerable<string> sheetname = ExcelEngine.GetInstance().GetAllSheetName(path);
                foreach (var item in sheetname)
                {
                    sheetData.Add(new { SheetName = item });
                }
                cbSheetNameStore.DataSource = sheetData;
                cbSheetNameStore.DataBind();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void ImportDataFromExcel(object sender, DirectEventArgs e)
    {
        try
        {
            int manv = 0, ngayindex = 3, sogiodk = 4, sogiolv = 5, giocato = 6, sospc = 7, sospp = 8, luongcn = 9, luongk = 10, luonght = 11;
            string extension = System.IO.Path.GetExtension(FileUploadField1.PostedFile.FileName).ToLower();
            TinhLuongKhoanController controller = new TinhLuongKhoanController();
            if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
            {
                X.Msg.Alert("Thông báo", "File bạn chọn không phải excel").Show();
                return;
            }
            string fn = System.IO.Path.GetFileName(FileUploadField1.PostedFile.FileName);
            string saveLocation = Server.MapPath("File") + "\\" + fn;
            List<Row> dataExcel = ExcelEngine.GetInstance().GetDataFromExcel(saveLocation, cbSheetName.SelectedItem.Value, 0);
            int count = 0;
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse("0" + spnYear.Text);
            FileInfo file;
            foreach (Row item in dataExcel)
            {
                try
                {
                    if (count > 10)
                        break;
                    if (string.IsNullOrEmpty(item[manv]))
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        DAL.ChamCongKhoanAustfeed chamCong = new DAL.ChamCongKhoanAustfeed();
                        chamCong.MaCB = item[manv].ToString();
                        float luong = 0;
                        string maBoPhan = string.Empty;
                        // lấy lương
                        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_LuongKhoan_GetInfoEmployeeByMaCB", "@MaCB", chamCong.MaCB);
                        if (table.Rows.Count > 0)
                        {
                            try { maBoPhan = table.Rows[0]["MA_DONVI"].ToString(); }
                            catch (Exception) { }
                            try { luong = float.Parse(table.Rows[0]["LuongCung"].ToString()); }
                            catch (Exception) { }
                        }
                        int ngay = int.Parse("0" + item[ngayindex].ToString());
                        chamCong.MonthYear = new DateTime(nam, thang, ngay);
                        try
                        {
                            chamCong.SoGioDangKy = double.Parse(item[sogiodk].ToString().Replace(".", ","));
                        }
                        catch (Exception) { }
                        try
                        {
                            chamCong.SoGioLamViec = double.Parse(item[sogiolv].ToString().Replace(".", ","));
                        }
                        catch (Exception) { }
                        try
                        {
                            chamCong.SoGioCaTo = double.Parse(item[giocato].ToString().Replace(".", ","));
                        }
                        catch (Exception) { }
                        try
                        {
                            chamCong.SanPhamChinh = decimal.Parse("0" + item[sospc].ToString().Replace(".", ","));
                        }
                        catch (Exception) { }
                        try
                        {
                            chamCong.SanPhamPhu = decimal.Parse("0" + item[sospp].ToString().Replace(".", ","));
                        }
                        catch (Exception) { }
                        chamCong.LuongCongNhat = decimal.Parse("0" + item[luongcn].ToString());
                        chamCong.LuongKhac = decimal.Parse("0" + item[luongk].ToString());
                        chamCong.LuongHoTro = double.Parse("0" + item[luonght].ToString());

                        if (chamCong.SoGioDangKy == 0)
                            chamCong.SoGioDangKy = 1;
                        if (chamCong.SoGioLamViec <= 0)
                            continue;
                        decimal sanLuong = (decimal)((double)chamCong.SanPhamChinh / chamCong.SoGioDangKy);
                        string congthucstring = "";
                        DAL.CongThucKhoanSanXuat congthuc = new CongThucKhoanSanXuatControler().GetByMaBoPhanVaSanLuong(maBoPhan, sanLuong);
                        if (congthuc != null)
                        {
                            congthucstring = congthuc.CongThuc;
                        }
                        try
                        {
                            // lấy công chuẩn
                            double congchuan = new ThietLapCaTheoBoPhanController().GetCongChuan(maBoPhan);
                            congthucstring = congthucstring.Replace("Luong", luong.ToString())
                                                .Replace("CongChuan", congchuan.ToString())
                                                .Replace("SanPhamChinh", chamCong.SanPhamChinh.ToString())
                                                .Replace("SanPhamPhu", chamCong.SanPhamPhu.ToString())
                                                .Replace("TongGio", chamCong.SoGioCaTo.ToString())
                                                .Replace("SoGioDangKy", chamCong.SoGioDangKy.ToString())
                                                .Replace("SoGioLamViec", chamCong.SoGioLamViec.ToString())
                                                .Replace("TrongSo", congthuc.TrongSo.ToString())
                                                .Replace(",", ".")
                                                .Replace("/0", "/1");
                            string value = new DataTable().Compute(congthucstring, null).ToString();
                            chamCong.LuongSanPham = Math.Round(decimal.Parse(value), 0);
                        }
                        catch (Exception)
                        {
                            chamCong.LuongSanPham = 0;
                        }
                        DAL.ChamCongKhoanAustfeed temp = controller.GetByMaCanBoAndDay(chamCong.MaCB, ngay, thang, nam);
                        if (temp == null)
                        {
                            controller.Insert(chamCong);
                        }
                        else
                        {
                            controller.Update(chamCong);
                        }
                    }
                }
                catch (Exception ex)
                {
                    file = new FileInfo(saveLocation);
                    if (file.Exists)
                        file.Delete();
                }
            }
            file = new FileInfo(saveLocation);
            if (file.Exists)
                file.Delete();
            Dialog.ShowNotification("Nhập dữ liệu thành công");
            GridPanel1.Reload();
            wdNhapTuExcel.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Combobox
    // combobox bộ phận
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

    protected void cbxNgayStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        int month = int.Parse(cbxMonth.SelectedItem.Value);
        int year = int.Parse(spnYear.Value.ToString());
        int maxDays = DateTime.DaysInMonth(year, month);
        List<object> objs = new List<object>();
        for (int i = 1; i <= maxDays; i++)
        {
            object obj = new { MA = i, TEN = i };
            objs.Add(obj);
        }
        cbxNgayStore.DataSource = objs;
        cbxNgayStore.DataBind();
    }
    #endregion

    protected void cbCanBo_Selected(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_LuongKhoan_GetInfoEmployeeByMaCB", "@MaCB", cbCanBo.SelectedItem.Value);
            if (table.Rows.Count > 0)
            {
                hdfQDLuong.SetValue(table.Rows[0]["LuongCung"].ToString());
                hdfMaBoPhan.Text = table.Rows[0]["MA_DONVI"].ToString();

                // lấy lương cơ bản (lương đóng BH)
                int thang = int.Parse(cbxMonth.SelectedItem.Value);
                int nam = int.Parse("0" + spnYear.Text);
                double luongcb = new TinhLuongKhoanController().GetLuongDongBH(decimal.Parse(table.Rows[0]["PR_KEY"].ToString()), new DateTime(nam, thang, 1));
                // lấy công chuẩn
                double congchuan = new ThietLapCaTheoBoPhanController().GetCongChuan(table.Rows[0]["MA_DONVI"].ToString());
                txtLuongCongNhat.SetValue(Math.Round(luongcb / congchuan, 0, MidpointRounding.AwayFromZero));
            }
            else
            {
 
            }
        }
        catch (Exception)
        {
            
        }
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int ngay, thang, nam;
            ngay = int.Parse("0" + hdfNgay.Text);
            thang = int.Parse(cbxMonth.SelectedItem.Value);
            nam = int.Parse(spnYear.Text);
            TinhLuongKhoanController controller = new TinhLuongKhoanController();
            DAL.ChamCongKhoanAustfeed vaoRa = new DAL.ChamCongKhoanAustfeed();
            if (e.ExtraParams["Edit"] == "True")
            {
                vaoRa = controller.GetByMaCanBoAndDay(hdfCanBo.Text, ngay, thang, nam);
            }
            else
            {
                DAL.ChamCongKhoanAustfeed temp = controller.GetByMaCanBoAndDay(hdfCanBo.Text, ngay, thang, nam);
                if (temp != null)
                {
                    Dialog.ShowError("Thông tin lương khoán của cán bộ " + cbCanBo.Text + " ngày " + ngay + " đã tồn tại");
                    return;
                }
            }
            vaoRa.MaCB = hdfCanBo.Text;
            vaoRa.MonthYear = new DateTime(nam, thang, ngay);
            vaoRa.SoGioDangKy = double.Parse("0" + txtSoGioDangKy.Text.Replace(".", ","));
            vaoRa.SoGioLamViec = double.Parse("0" + txtSoGioLamViec.Text.Replace(".", ","));
            vaoRa.SoGioCaTo = double.Parse("0" + txtSoGioCaTo.Text.Replace(".", ","));
            vaoRa.SanPhamChinh = decimal.Parse("0" + txtSanPhamChinh.Text.Replace(".", ","));
            vaoRa.SanPhamPhu = decimal.Parse("0" + txtSanPhamPhu.Text.Replace(".", ","));
            vaoRa.LuongSanPham = decimal.Parse("0" + txtLuongSanPham.Text);
            vaoRa.LuongCongNhat = decimal.Parse("0" + txtLuongCongNhat.Text);
            vaoRa.LuongHoTro = double.Parse("0" + txtLuongHoTro.Text.Replace('.', ','));
            vaoRa.LuongKhac = decimal.Parse("0" + txtLuongKhac.Text);
            if (e.ExtraParams["Edit"] == "True")
            {
                controller.Update(vaoRa);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công");
                wdLuongKhoanSanXuat.Hide();
            }
            else
            {
                controller.Insert(vaoRa);
                Dialog.ShowNotification("Thêm mới thành công");
                if (e.ExtraParams["Close"] == "True")
                {
                    wdLuongKhoanSanXuat.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rlst", "ResetWindows();");
                }
            }
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnSua_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int oldRow, oldColumn;
            int month = int.Parse(cbxMonth.SelectedItem.Value);
            int year = int.Parse(spnYear.Text);
            CellSelectionModel sm = GridPanel1.SelectionModel.Primary as CellSelectionModel;
            oldRow = sm.SelectedCell.RowIndex;
            oldColumn = sm.SelectedCell.ColIndex;
            string maCanBo = sm.SelectedCell.RecordID;
            string tmpNgay = sm.SelectedCell.Name;
            int ngay = 0;
            if (tmpNgay.StartsWith("Ngay"))
            {
                ngay = int.Parse(tmpNgay.Replace("Ngay", "").Trim());
                DAL.ChamCongKhoanAustfeed vaoRa = new TinhLuongKhoanController().GetByMaCanBoAndDay(maCanBo, ngay, month, year);
                if (vaoRa == null)
                {
                    X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy dữ liệu").Show();
                    return;
                }

                hdfCanBo.SetValue(vaoRa.MaCB);
                cbCanBo.SetValue(vaoRa.MaCB);
                hdfNgay.SetValue(ngay);
                cbxNgay.SetValue(ngay);
                txtSoGioDangKy.SetValue(vaoRa.SoGioDangKy);
                txtSoGioLamViec.SetValue(vaoRa.SoGioLamViec);
                txtSoGioCaTo.SetValue(vaoRa.SoGioCaTo);
                txtSanPhamChinh.SetValue(vaoRa.SanPhamChinh);
                txtSanPhamPhu.SetValue(vaoRa.SanPhamPhu);
                txtLuongSanPham.SetValue(vaoRa.LuongSanPham);
                txtLuongCongNhat.SetValue(vaoRa.LuongCongNhat);
                txtLuongHoTro.SetValue(vaoRa.LuongHoTro);
                txtLuongKhac.SetValue(vaoRa.LuongKhac);
                // lấy thông tin lương, mã ca
                try
                {
                    string[] value = sm.SelectedCell.Value.Replace("##", "#").Split('#');
                    hdfQDLuong.Text = value[5];
                    hdfMaBoPhan.Text = value[6];
                }
                catch (Exception ex)
                {

                }


                cbCanBo.Disabled = true;
                cbxNgay.Disabled = true;
                wdLuongKhoanSanXuat.Show();
                txtSoGioDangKy.Focus();
            }
            else
            {
                Dialog.ShowNotification("Thông tin này không được phép thay đổi");
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void mnuXoaLuongKhoan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int year = int.Parse(spnYear.Value.ToString());
            int month = int.Parse(cbxMonth.SelectedItem.Value);
            TinhLuongKhoanController controller = new TinhLuongKhoanController();
            CellSelectionModel sm = this.GridPanel1.SelectionModel.Primary as CellSelectionModel;
            string maCB = sm.SelectedCell.RecordID;
            // xóa ngày
            if (e.ExtraParams["Delete"] == "day")
            {
                if (!sm.SelectedCell.Name.StartsWith("Ngay"))
                {
                    Dialog.ShowError("Không thể xóa ô này");
                    return;
                }
                int ngay = int.Parse(sm.SelectedCell.Name.Replace("Ngay", ""));
                controller.DeleteByDay(maCB, year, month, ngay);
            }
            // xóa nhân viên
            if (e.ExtraParams["Delete"] == "employee")
            {
                controller.DeleteByEmployeeCode(maCB);
            }
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void grpBangLuongKhoanSanXuatStoreRefresh(object sender, StoreRefreshDataEventArgs e)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Quy trình tính lương khoán
    /// Input:  Tổng khối lượng sản phẩm (sản phẩm chính) /
    ///         Số giờ đăng ký làm
    ///     => Khối lượng sản phẩm / 1 giờ      So sánh với sản lượng quy định
    ///     => Trọng số (số tiền cho 1 tấn sản lượng) * Tổng khối lượng sản phẩm
    ///     => Tổng số tiền cả tổ được nhận / Số giờ cả tổ làm trong ngày
    ///     => Số tiền trung bình / 1 giờ làm việc
    ///     Số tiền trung bình * số giờ làm việc của từng công nhân
    ///     => Số tiền lương khoán
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ThayDoi(object sender, DirectEventArgs e)
    {
        try
        {
            decimal luong = decimal.Parse("0" + hdfQDLuong.Text.Replace(".", ""));
            string maBoPhan = hdfMaBoPhan.Text;
            string congthucstring = "";
            // sản lượng của sản phẩm chính
            double spchinh = double.Parse("0" + txtSanPhamChinh.Text.Replace(".", ","));
            // sản lượng của sản phẩm phụ
            double spphu = double.Parse("0" + txtSanPhamPhu.Text.Replace(".", ","));
            // Số giờ tổ đăng ký làm việc
            double giodangky = double.Parse("0" + txtSoGioDangKy.Text.Replace(".", ","));
            if (giodangky == 0) giodangky = 1;
            // Số giờ thực tế công nhân làm việc
            double giothucte = double.Parse("0" + txtSoGioLamViec.Text.Replace(".", ","));
            // Số giờ cả tổ làm trong 1 ngày (tổng số giờ làm việc của công nhân trong tổ)
            double giocato = double.Parse("0" + txtSoGioCaTo.Text.Replace(".", ","));
            if (giothucte <= 0)
                return;
            decimal sanLuong = (decimal)(spchinh / giodangky);

            //var congthuc = CongThucKhoanList.FirstOrDefault(p => p.MaDonVi == maBoPhan && p.DKSanLuongTu <= (spchinh / giodangky) && p.DKSanLuongDen >= (spchinh / giodangky));
            DAL.CongThucKhoanSanXuat congthuc = new CongThucKhoanSanXuatControler().GetByMaBoPhanVaSanLuong(maBoPhan, sanLuong);
            if (congthuc == null)
            {
                Dialog.ShowError("Không tìm thấy công thức tính lương cho mã bộ phận: " + maBoPhan);
                return;
            }
            congthucstring = congthuc.CongThuc;
            // lấy công chuẩn
            double congchuan = new ThietLapCaTheoBoPhanController().GetCongChuan(maBoPhan);
            congthucstring = congthucstring.Replace("Luong", luong.ToString())
                .Replace("CongChuan", congchuan.ToString())
                .Replace("SanPhamChinh", txtSanPhamChinh.Text)
                .Replace("SanPhamPhu", txtSanPhamPhu.Text)
                .Replace("SoGioDangKy", txtSoGioDangKy.Text)
                .Replace("SoGioLamViec", txtSoGioLamViec.Text)
                .Replace("TongGio", txtSoGioCaTo.Text)
                .Replace("TrongSo", congthuc.TrongSo.ToString())
                .Replace(",", ".")
                .Replace("/0", "/1");
            //RM.RegisterClientScriptBlock("abdc", "  alert('"+congthucstring+"'); ");

            RM.RegisterClientScriptBlock("abc", " txtLuongSanPham.setValue(Math.round( eval('" + congthucstring + "')));if (!txtLuongSanPham.getValue()) {txtLuongSanPham.setValue(0);}");
            //Dialog.ShowNotification("Công thức: <b>" + congthuc.CongThuc + " </b> <br/>    Trọng số: <b>"
            //    + congthuc.TrongSo.ToString() + " </b> <br/> Giá trị : <b>" + congthucstring);
        }
        catch (Exception ex)
        {

        }
    }
}