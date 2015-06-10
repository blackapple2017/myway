using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using LinqToExcel;
using System.Globalization;
using Controller.ChamCongDoanhNghiep;
using DAL;
using DataController;
using System.Data;
using SoftCore;

public partial class Modules_ChamCongDoanhNghiep_TongHopCongTheoThang : WebBase
{
    //private string loaiFileExcel = DieuKienChamCongController.EXCEL_FORMAT_NGANG;
    //private string phanCa = SystemConfigParameter.PHANCA_TYPE_THANG;
    //private static int idBangTongHopCong = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            // dfFilterTuNgay.SetValue("1/"+DateTime.Now.Month+"/"+DateTime.Now.Year);
            // dfFilterDenNgay.SetValue(DateTime.Now);
            cbxMonth.SetValue(DateTime.Now.Month);
            spnYear.SetValue(DateTime.Now.Year);
            //hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            txtYear.Text = DateTime.Now.Year.ToString();

            hdfUserID.SetValue(CurrentUser.ID);
            hdfMenuID.SetValue(MenuID);
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "'); grpTongHopCongStore.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
            //if (idBangTongHopCong != 0)
            //{
            //    DAL.DanhSachBangTongHopCong thc = new DanhSachBangTongHopCongController().GetById(idBangTongHopCong);
            //    grpTongHopCong.Title = thc.Title;
            //    hdfIdBangTongHopCong.Text = idBangTongHopCong.ToString();
            //    grpTongHopCong.Reload();
            //    if (thc.Lock == true)
            //    {
            //        //  btnChuanBiDuLieuDauVao.Disabled = true;
            //        //btnTongHopCong.Disabled = true;
            //        btnEditHangLoat.Disabled = true;
            //        //btnSave.Disabled = true;
            //        btnMoKhoaBangTongHopCong.Show();
            //        btnKhoaBangChamCong.Hide();
            //        hdfIsLocked.Text = "true";
            //    }
            //    else
            //    {
            //        // btnChuanBiDuLieuDauVao.Disabled = false;
            //        //btnTongHopCong.Disabled = false;
            //        btnEditHangLoat.Disabled = false;
            //        //btnSave.Disabled = false;
            //        btnMoKhoaBangTongHopCong.Hide();
            //        btnKhoaBangChamCong.Show();
            //        hdfIsLocked.Text = "false";
            //    }
            //}
            SetVisibleByControlID(btnChuanBiDuLieuDauVao, mnuLayCongLamThemGio, mnuTongHopTatCa, mnuTongHopDuocChon, mnuThemNhanVien, mnuXoaNhanVien, btnEditOnGrid);
            cmenuThemCanBo.Visible = mnuThemNhanVien.Visible;
            cmenuLoaiBoCanBo.Visible = mnuXoaNhanVien.Visible;

            SetEditor();
        }

        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    private void SetEditor()
    {
        for (int i = 4; i < grpTongHopCong.ColumnModel.Columns.Count; i++)
        {
            Ext.Net.TextField txtEditor = new TextField();
            txtEditor.MaskRe = "/[0-9.]/";
            txtEditor.ID = "txtEditor" + i;
            grpTongHopCong.ColumnModel.Columns[i].Editor.Add(txtEditor);
            if (btnEditOnGrid.Visible)
            {
                if (hdfIsLocked.Text == "true")
                    SetEditable(false);
                else
                {
                    SetEditable(true);
                }
            }
            else
            {
                SetEditable(false);
            }
        }
    }

    private void SetEditable(bool value)
    {
        for (int i = 4; i < grpTongHopCong.ColumnModel.Columns.Count; i++)
        {
            grpTongHopCong.ColumnModel.Columns[i].Editable = value;
        }
    }

    [DirectMethod]
    public void SaveData(string sql)
    {
        try
        {
            DataHandler.GetInstance().ExecuteNonQuery(sql);
            //  Dialog.ShowNotification(sql);
            RM.RegisterClientScriptBlock("clearSQL", "clearSQL();");
            Dialog.ShowNotification("Dữ liệu đã được tự động lưu lại");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void AfterEdit(int id, string field, string oldValue, string newValue, TongHopCongInfo customer)
    {
        try
        {
            if (field == "NghiPhep")
            {
                int thang = int.Parse(cbxMonth.SelectedItem.Value);
                int nam = int.Parse(spnYear.Text);
                object data = DataController.DataHandler.GetInstance().ExecuteScalar("sp_LaySoNgayPhepConDuocSuDungTrongThangCuaNam",
                    "@Thang", "@Nam", "@MaCB", thang, nam, customer.MA_CB);
                if (data != null)
                {
                    float soNgayPhepConLai = float.Parse("0" + data.ToString());
                    float songaynghicu = float.Parse("0" + oldValue.Replace('.', ','));
                    float songaynghimoi = float.Parse("0" + newValue.Replace('.', ','));

                    if (soNgayPhepConLai < (float.Parse("0" + songaynghimoi) - float.Parse("0" + songaynghicu)))
                    {
                        Dialog.ShowError("Số ngày được nghỉ phép trong năm không đủ cho cập nhât của bạn");
                        grpTongHopCongStore.CommitChanges();

                        return;
                    }
                    else
                    {
                        float songaynghi = float.Parse("0" + newValue.Replace('.', ','));
                        DataController.DataHandler.GetInstance().ExecuteNonQuery("store_Update_ChamCong_DanhSachNgayPhep",
                               "@Thang", "@Nam", "@MaCB", "@Value", thang, nam, customer.MA_CB, float.Parse("0" + songaynghi));
                    }
                }
                else {
                    grpTongHopCongStore.CommitChanges();
                    grpTongHopCong.Reload();
                    Dialog.ShowError("Cán bộ bạn chọn không có số ngày phép trong năm "+nam);
                    return;
                }
            }

            float value = float.Parse("0" + newValue.Replace('.', ','));
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCong_UpdateAfterEdit",
                    "@ID", "@Field", "@Value", id, field, value);
            grpTongHopCongStore.CommitChanges();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification("Có lỗi xảy ra: " + ex.Message);
        }
    }

    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(e.ExtraParams["sqlQuery"]))
            {
                DataHandler.GetInstance().ExecuteNonQuery(e.ExtraParams["sqlQuery"]);
                RM.RegisterClientScriptBlock("clearSQL", "clearSQL();");

                int idbangluong = new BangThanhToanTienLuongController().GetIDBangThanhToanLuongByIDBangTongHopCong(int.Parse(hdfIdBangTongHopCong.Text));
                if (idbangluong > 0)
                    new BangThanhToanTienLuongController().XuLiCongThuc(idbangluong, Session["MaDonVi"].ToString(), e.ExtraParams["maCBChange"].ToString());
                Dialog.ShowNotification("Cập nhật thành công");
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnCapNhatNgayPhep_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("store_Update_ChamCong_DanhSachNgayPhep", "@Thang", "@Nam", thang, nam);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

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
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            // lấy danh sách các mã cán bộ được chọn
            SelectedRowCollection selectedRows = ucChooseEmployee1.SelectedRow;
            foreach (var item in selectedRows)
            {
                try
                {
                    DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_TongHopCong_GetByMaCanBoAndTime",
                            "@MaCanBo", "@Thang", "@Nam", item.RecordID, thang, nam);
                    if (table.Rows.Count == 0)
                    {
                        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCong_InsertCanBo", "@MaCanBo", "@Thang", "@Nam", item.RecordID, thang, nam);
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
        int thang = int.Parse(cbxMonth.SelectedItem.Value);
        int nam = int.Parse(spnYear.Text);
        SelectedRowCollection selectedRows = RowSelectionModelTongHopCong.SelectedRows;
        string error = string.Empty;
        foreach (var item in selectedRows)
        {
            try
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCong_DeleteCanBo", "@IDBangCong", item.RecordID);
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

    #region import from excel
    #region các hàm tính toán
    private int GetExcelColumnNumber(string name)
    {
        int number = 0;
        int pow = 1;
        for (int i = name.Length - 1; i >= 0; i--)
        {
            number += (name[i] - 'A' + 1) * pow;
            pow *= 26;
        }
        return number;
    }

    private string GetExcelColumnName(int columnNumber)
    {
        int dividend = columnNumber;
        string columnName = String.Empty;
        int modulo;

        while (dividend > 0)
        {
            modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
            dividend = (int)((dividend - modulo) / 26);
        }
        return columnName;
    }

    private string FindDayOfWeek(DateTime date)
    {
        string dayOfWeek = "";
        switch (date.DayOfWeek.ToString())
        {
            case "Monday":
                dayOfWeek = "Thứ Hai";
                break;
            case "Tuesday":
                dayOfWeek = "Thứ Ba";
                break;
            case "Wednesday":
                dayOfWeek = "Thứ Tư";
                break;
            case "Thursday":
                dayOfWeek = "Thứ Năm";
                break;
            case "Friday":
                dayOfWeek = "Thứ Sáu";
                break;
            case "Saturday":
                dayOfWeek = "Thứ Bảy";
                break;
            case "Sunday":
                dayOfWeek = "Chủ nhật";
                break;
        }
        return dayOfWeek;
    }

    /// <summary>
    /// Tính số phút đi sớm hay số phút về muộn
    /// </summary>
    /// <param name="chuan">giờ bắt đầu ca - giờ kết thúc ca</param>
    /// <param name="den">giờ đến đầu ca - giờ về cuối ca</param>
    /// <param name="isDiSom">tính toán cho đi sớm = true, tính toán cho về muộn = false</param>
    /// <returns>số phút</returns>
    private int CalculateDiSom(string chuan, string den, bool isDiSom)
    {
        int tgian = new TimeController().GetTotalTimeInMinutes(chuan, den);
        if (isDiSom == true)
        {
            return (0 - tgian);
        }
        else
            return tgian;
    }
    #endregion
    protected void btnSua_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachBangTongHopCong bangthcong = new DanhSachBangTongHopCongController().GetById(int.Parse(hdfTmpID.Text));
            if (bangthcong != null)
            {
                //txtYear.SetValue(bangthcong.Nam);
                //cbMonth.SetValue(bangthcong.Thang);
                txtTenBangChamCong.Text = bangthcong.Title;
                //txtYear.Disabled = true;
                //cbMonth.Disabled = true;

                wdTaoBangTongHopCong.Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    #endregion

    protected void mnuLayCongLamThemGio_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            // tổng hợp giờ làm thêm
            DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_TongHopLamThemGio", "@Thang", "@Nam","@BoPhan", thang, nam,hdfMaDonVi.Text);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Tổng hợp công cho tất cả cán bộ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuTongHopTatCa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            // tổng hợp công cuối tháng
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCongThang", "@Thang", "@Nam", "@SelectedId", thang, nam, null);
            grpTongHopCong.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
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
            int thang = int.Parse(cbxMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            SelectedRowCollection selecteds = RowSelectionModelTongHopCong.SelectedRows;
            string selectedId = string.Empty;
            foreach (var item in selecteds)
            {
                selectedId += item.RecordID + ",";
            }
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TongHopCongThang", "@Thang", "@Nam", "@SelectedId", thang, nam, selectedId);
            grpTongHopCong.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
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

    protected void btnTaoBangChamCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string maDonVi = Session["MaDonVi"].ToString();
            if (!(e.ExtraParams["Command"] == "Edit"))
            {
                DAL.DanhSachBangTongHopCong tmp = new DanhSachBangTongHopCongController().GetByInfo(maDonVi, int.Parse(cbMonth.SelectedItem.Value), int.Parse(txtYear.Text));
                if (tmp != null)
                {
                    X.Msg.Alert("Thông báo từ hệ thống", txtTenBangChamCong.Text + " cho tháng " + cbMonth.SelectedItem.Value + "/" + txtYear.Text + " <span style='color:red;'><b> đã tồn tại</b></span>").Show();
                    return;
                }
            }
            // tạo bảng tổng hợp công
            DAL.DanhSachBangTongHopCong cong = new DanhSachBangTongHopCong()
            {
                Nam = int.Parse(txtYear.Text),
                Thang = int.Parse(cbMonth.SelectedItem.Value),
                MaDonVi = maDonVi,
                Lock = false,
                FromDate = DateTime.Parse("2014/01/01"),
                ToDate = DateTime.Parse("2014/01/01"),
                Title = txtTenBangChamCong.Text,
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now
            };
            if (e.ExtraParams["Command"] == "Edit")
            {
                cong.ID = int.Parse(hdfTmpID.Text);
                new DanhSachBangTongHopCongController().Update(cong);
                Dialog.ShowNotification("Cập nhật dữ liệu thành công");
                grp_danhSachBangTongHopCong.Reload();
            }
            else
            {
                new DanhSachBangTongHopCongController().Insert(cong);
                Dialog.ShowNotification("Tạo " + txtTenBangChamCong.Text + " thành công!");
            }
            wdTaoBangTongHopCong.Hide();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }

    #region Đọc dữ liệu từ Excel
    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = fUpload.PostedFile;

            //if (file.ContentType != "application/vnd.ms-excel") //ko phải Excel 2003
            //{
            //    Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("NotExcel2003"));
            //    return;
            //}
            if (fUpload.HasFile == false && file.ContentLength > 2000000)
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
                    path = Server.MapPath("File/") + fUpload.FileName;
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

    protected void cbSheetNameStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            UploadFile();
            string path = Server.MapPath("File/") + fUpload.FileName;
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

    int maChamCong = 2;
    protected void btnImport_Click(object sender, DirectEventArgs e)
    {
        try
        {
            VaoRaCaController controller = new VaoRaCaController();
            TongHopCongTheoNgayController ngayCtr = new TongHopCongTheoNgayController();
            int ngayChamCong = 6;
            int gioVao = 7;
            int gioRa = 8;
            int count = 0;
            int rowIndex = 0;
            string oldMaChamCong = string.Empty;
            string extension = System.IO.Path.GetExtension(fUpload.PostedFile.FileName).ToLower();
            if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
            {
                X.Msg.Alert("Thông báo", "File bạn chọn không phải Excel").Show();
                return;
            }
            string fileName = System.IO.Path.GetFileName(fUpload.PostedFile.FileName);
            string fileLocation = Server.MapPath("File") + "\\" + fileName;
            string error = "";
            List<Row> dataExcel = ExcelEngine.GetInstance().GetDataFromExcel(fileLocation, cbSheetName.SelectedItem.Value, 0);
            foreach (Row item in dataExcel)
            {
                try
                {
                    rowIndex++;
                    if (count > 20)
                        break;
                    // xóa dữ liệu cũ
                    if (chkXoa.Checked)
                    {
                        if (!string.IsNullOrEmpty(item[maChamCong].ToString().Trim())
                            && item[maChamCong].ToString().Trim() != oldMaChamCong)
                        {
                            if (!string.IsNullOrEmpty(item[ngayChamCong].ToString().Trim()))
                            {
                                DateTime time = DateTime.ParseExact(item[ngayChamCong].ToString().Trim(), "dd/MM/yyyy", null);
                                controller.DeleteByMaChamCongAndMonthYear(item[maChamCong].ToString().Trim(), time);
                                ngayCtr.DeleteByDay(time, item[maChamCong].ToString().Trim());
                                oldMaChamCong = item[maChamCong].ToString().Trim();
                            }
                        }
                    }
                    // nếu có dữ liệu
                    if (!string.IsNullOrEmpty(item[maChamCong].ToString().Trim()) && !string.IsNullOrEmpty(item[ngayChamCong].ToString().Trim())
                        && (!string.IsNullOrEmpty(item[gioVao].ToString().Trim()) || !string.IsNullOrEmpty(item[gioRa].ToString().Trim())))
                    {
                        count = 0;
                        DateTime time = DateTime.ParseExact(item[ngayChamCong].ToString().Trim(), "dd/MM/yyyy", null);
                        //if (chkXoa.Checked)
                        //{
                        //    controller.DeleteByMaChamCongAndMonthYear(item[maChamCong].ToString().Trim(), time);
                        //}
                        if (!string.IsNullOrEmpty(item[gioVao].ToString().Trim()))
                        {
                            InserVaoRaCa(item, gioVao, time);
                        }
                        if (!string.IsNullOrEmpty(item[gioRa].ToString().Trim()))
                        {
                            InserVaoRaCa(item, gioRa, time);
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    // error += item[maChamCong].ToString().Trim() + "-" + item[ngayChamCong].ToString().Trim() + "-" +
                    //   item[gioVao].ToString().Trim() + "-" + item[gioRa].ToString().Trim() + "<br/>";
                    //error += "Number : " + count + item[maChamCong].ToString() + rowIndex + ex.Message + ",";// ex.Message + "(" + count + ")";   
                }
            }
            if (string.IsNullOrEmpty(error))
            {
                Dialog.ShowNotification("Nhập dữ liệu từ Excel thành công");
            }
            else
            {
                Dialog.ShowError("Không đọc được dòng " + error.Remove(error.LastIndexOf(",")));
            }
            wdImportExcelFile.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
        finally
        {
            string fn = System.IO.Path.GetFileName(fUpload.PostedFile.FileName);
            string saveLocation = Server.MapPath("File") + "\\" + fn;
            FileInfo file = new FileInfo(saveLocation);
            if (file.Exists)
                file.Delete();
        }
    }

    private void InserVaoRaCa(LinqToExcel.Row row, int timeIndex, DateTime time)
    {
        VaoRaCaController controller = new VaoRaCaController();
        DAL.VaoRaCa vao = new VaoRaCa();
        vao.MaCa = "";
        vao.Order = 1;
        vao.MaChamCong = row[maChamCong].ToString().Trim();
        vao.Time = row[timeIndex].ToString().Trim();
        if (vao.Time.Length <= 5)
            vao.Time += ":00";
        string _time = string.Empty;
        if (int.Parse(vao.Time.Split(':')[0]) > 23)
        {
            _time = "23:59:00";
        }
        else
            _time = vao.Time;
        vao.NgayChamCong = DateTime.Parse(time.ToString("yyyy-MM-dd " + _time));
        vao.ID = vao.MaChamCong + vao.NgayChamCong.Day + vao.NgayChamCong.Month + vao.NgayChamCong.Year + vao.NgayChamCong.Hour +
                 vao.NgayChamCong.Minute + vao.NgayChamCong.Second;
        vao.DiVao = true;
        controller.InsertAndUpdate(vao);
    }
    #endregion

    protected void btnXoa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string error = string.Empty, result = string.Empty;
            int count = 0;
            SelectedRowCollection selectedRows = RowSelectionModelDanhSachBangTongHopCong.SelectedRows;
            foreach (var item in selectedRows)
            {
                // lấy bảng tổng hợp công được chọn
                DAL.DanhSachBangTongHopCong thcong = new DanhSachBangTongHopCongController().GetById(int.Parse(item.RecordID));

                if (thcong != null)
                {
                    // xóa dữ liệu bảng tạm
                    //new TmpVaoRaController().DeleteByIdDanhSachBangTongHopCong(thcong.ID);

                    // xóa dữ liệu bảng tổng hợp công
                    new TongHopCongController().DeleteByIdDanhDachBangTongHopCong(thcong.ID);

                    // xóa dữ liệu bảng Danh sách bảng tổng hợp công
                    new DanhSachBangTongHopCongController().Delete(thcong.ID);

                    count++;
                }
                else
                {
                    error += "Không tìm thấy " + thcong.Title + "<br />";
                }
            }
            if (count > 0)
            {
                if (count > 1)
                {
                    result += "Xóa thành công " + count + " bảng tổng hợp công";
                }
                else
                {
                    result += "Xóa dữ liệu thành công";
                }
            }
            if (!string.IsNullOrEmpty(error))
            {
                result += error;
            }
            grp_danhSachBangTongHopCong.Reload();
            X.Msg.Alert("Thông báo từ hệ thống", result).Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void grp_danhSachBangTongHopCongStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        int count = 0;
        grp_danhSachBangTongHopCongStore.DataSource = new DanhSachBangTongHopCongController().GetTimeSheetBoardListByMonthYear(0, 15, "", Session["MaDonVi"].ToString(),
            int.Parse(cbChonThang.SelectedItem.Value), int.Parse(txtCurrentYear.Text), out count);
        grp_danhSachBangTongHopCongStore.DataBind();
    }

    /// <summary>
    /// Khóa các bảng chấm công được chọn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnKhoaBangChamCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int thang = int.Parse(cbMonth.SelectedItem.Value);
            int nam = int.Parse(spnYear.Text);
            if (hdfIdBangTongHopCong.Text == "")
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy bảng tổng hợp công").Show();
                return;
            }
            new TongHopCongController().Lock(int.Parse(hdfIdBangTongHopCong.Text), true);
            // cập nhật ngày phép
            DataController.DataHandler.GetInstance().ExecuteNonQuery("store_Update_ChamCong_DanhSachNgayPhep", "@Thang", "@Nam", thang, nam);

            btnChuanBiDuLieuDauVao.Disabled = true;
            btnTongHopCong.Disabled = true;
            btnEditHangLoat.Disabled = true;
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
            //    //btnKhoaBangChamCong.Hide();
            //    //btnMoKhoaBangTongHopCong.Show();
            //}
            //else
            //{
            //    //btnKhoaBangChamCong.Show();
            //    //btnMoKhoaBangTongHopCong.Hide();
            //}
            //if (bang.Lock == true)
            //{
            //    // btnChuanBiDuLieuDauVao.Disabled = true;
            //    //btnTongHopCong.Disabled = true;
            //    btnEditHangLoat.Disabled = true;
            //    //btnSave.Disabled = true;
            //    hdfIsLocked.Text = "true";
            //}
            //else
            //{
            //    //btnChuanBiDuLieuDauVao.Disabled = false;
            //    //btnTongHopCong.Disabled = false;
            //    btnEditHangLoat.Disabled = false;
            //    //btnSave.Disabled = false;
            //    hdfIsLocked.Text = "false";
            //}

            //if (hdfIsLocked.Text == "true")
            //    SetEditable(false);
            //else
            //    SetEditable(true);

            //grpTongHopCong.Reload();
            //wdChonBangTongHopCong.Hide();
            //Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }
    protected void btnLayDuLieu_Click(object sender, DirectEventArgs e)
    {
        //  cbxMonth
        //spnYear
    }
}