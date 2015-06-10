using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;
using DataController;
using SoftCore;
using System.Text;
using System.Data;

public partial class Modules_TuyenDung_UngVienTrungTuyen : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            DateTime1.MinDate = DateTime.Now;
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            btn_BaoCao.Visible = SetVisible(btn_BaoCao.Text);
            spnYear.SetValue(DateTime.Now.Year);
            cbxMonth.SetValue(0);
        }
    }
    #region xuất dữ liệu ra Excel
    /// <summary>
    /// Xuất bảng lương
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExportExcel_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //Create Tempory Table
            DataTable dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_GetUngVienTrungTuyen_ExportToExcel",
                                                                                        "@searchKey", "@DotTuyenDung", "@month", "@year",
                                                                                        SoftCore.Util.GetInstance().GetKeyword(UngVienTrungTuyen_txtSearchKey.Text.ToString()),
                                                                                        cbx_dottuyendung.SelectedItem.Value == null ? "0" : cbx_dottuyendung.SelectedItem.Value,
                                                                                        cbxMonth.SelectedItem.Value,
                                                                                        spnYear.Value);
            ExportToExcel("TuyenDung_UngVienTrungTuyen.xls", dtTemp, "Danh sách ứng viên trúng tuyển");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public string GetDayOfWeek(int day, int month, int year)
    {
        string dayOfWeek = "";
        DateTime date = new DateTime(year, month, day);
        switch (date.DayOfWeek.ToString())
        {
            case "Monday":
                dayOfWeek = " T2";
                day = 0;
                break;
            case "Tuesday":
                dayOfWeek = " T3";
                day = 1;
                break;
            case "Wednesday":
                dayOfWeek = " T4";
                day = 2;
                break;
            case "Thursday":
                dayOfWeek = " T5";
                day = 3;
                break;
            case "Friday":
                dayOfWeek = " T6";
                day = 4;
                break;
            case "Saturday":
                dayOfWeek = " T7";
                day = 5;
                break;
            case "Sunday":
                dayOfWeek = " CN";
                day = 6;
                break;
        }
        return dayOfWeek;
    }
    public void ExportToExcel(string fileName, DataTable table, string title)
    {
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        Response.AddHeader("Content-Disposition", "Attachment; Filename=" + fileName);
        Response.ContentEncoding = Encoding.Unicode;
        Response.BinaryWrite(Encoding.Unicode.GetPreamble());
        try
        {
            StringBuilder sb = new StringBuilder();
            //Tạo dòng tiêu để cho bảng tính
            sb.Append(title);
            Response.Write(sb.ToString() + "\n\n");
            Response.Flush();
            sb = new StringBuilder();
            for (int count = 0; count < table.Columns.Count; count++)
            {
                if (table.Columns[count].ColumnName != null)
                    sb.Append(table.Columns[count].ColumnName);
                if (count < table.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            Response.Write(sb.ToString() + "\n");
            Response.Flush();
            //Duyệt từng bản ghi 
            int soDem = 0;
            while (table.Rows.Count >= soDem + 1)
            {
                sb = new StringBuilder();


                for (int col = 0; col < table.Columns.Count - 1; col++)
                {
                    if (table.Rows[soDem][col] != null)
                        sb.Append(table.Rows[soDem][col].ToString());
                    sb.Append("\t");
                }
                if (table.Rows[soDem][table.Columns.Count - 1] != null)
                    sb.Append(table.Rows[soDem][table.Columns.Count - 1].ToString());


                Response.Write(sb.ToString() + "\n");
                Response.Flush();
                soDem = soDem + 1;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        table.Dispose();
        Response.End();
    }
    #endregion
    protected void btnRoiNgayDiLam_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string chuoi = DateTime1.SelectedDate.Year + "/" + DateTime1.SelectedDate.Month + "/" + DateTime1.SelectedDate.Day;
            DataHandler.GetInstance().ExecuteDataTable("UpdateNgayDilam", "@ngaycothedilam", "@maungvien", chuoi, int.Parse("0" + hdfMaUngVien.Text));
            wdRoiNgayDiLam.Hide();
            RM.RegisterClientScriptBlock("d", "#{Store1}.reload();");
            Dialog.ShowNotification("Thiết lập thành công !");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void cbx_Chuyen_LyDo_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            string s = "";
            if (Equals(hdfType.Text, "black"))
            {
                s = "LyDoDuaVaoDanhSachHanChe";
            }
            else
            {
                s = "LyDoDuaVaoKho";
            }
            cbx_Chuyen_LyDo_Store.DataSource = new ThamSoTrangThaiController().GetByParamName(s, true);
            cbx_Chuyen_LyDo_Store.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnTiepNhan_Click(object sender, DirectEventArgs e) { }
    protected void btnChuyenTiep_Click(object sender, DirectEventArgs e)
    {
        string type = "";
        bool datrungtuyen = false;
        HoSoUngVienController hosoungvien = new HoSoUngVienController();
        DAL.HoSoUngVien hsuv = new DAL.HoSoUngVien();
        if (Equals(hdfType.Text, "toList"))
        {
            type = "";
            datrungtuyen = true;
        }
        else
        {
            if (Equals(hdfType.Text, "store"))
            {
                type = "store";
            }
            else
            {
                if (Equals(hdfType.Text, "black"))
                {
                    type = "black";
                }
            }
        }
        try
        {
            foreach (var item in checkboxSelection.SelectedRows)
            {
                hsuv.MaUngVien = decimal.Parse("0" + item.RecordID);
                hsuv.BlackListOrStore = type;
                if (datrungtuyen == false)
                {
                    hsuv.GhiChu = txt_Chuyen_GhiChu.Text;
                    hsuv.MaLyDo = int.Parse("0" + hdfChuyen_LyDo.Text);
                }
                hosoungvien.ChuyenDanhSach(hsuv, datrungtuyen);
            }
            checkboxSelection.ClearSelections();
            GridPanel1.Reload();
            btnChuyenTiep.Disabled = true;
            btnRoiNgayDiLam.Disabled = true;
            btnTinhTrangDiLam.Disabled = true;
            Dialog.ShowNotification("Chuyển thành công!");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    [DirectMethod]
    public void GenderMaCB()
    {
        HoSoController hsController = new HoSoController();
        txtMaCB.Text = hsController.GenerateMaCB(Session["MaDonVi"].ToString());
    }
    [DirectMethod]
    /// <summary>
    /// Insert dữ liệu vào bảng HOSO dữ liệu lấy từ HoSoUngVien
    /// </summary>
    /// <author>ViVi</author>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void btnForward_Click(object sender, DirectEventArgs e)
    {
        HoSoUngVienController ctrol = new HoSoUngVienController();
        //hdfMaUngVien.Text;
        //Session["MaDonVi"].ToString();
        //hdfMaKeHoachTuyenDung.text;
        //dfNgayThuViec
        try
        {
            // sinh mã cán bộ
            HoSoController hsController = new HoSoController();
            string newMaCb = string.Empty;
            newMaCb = txtMaCB.Text;
            string maDiaDiemLamViec = hdfDiaDiemLamViec.Text;
            string maDonViKyHopDong = hdfDonViKyHopDong.Text;
            if (!dfNgayThuViec.SelectedDate.ToString().Contains("0001"))
            {
                ctrol.CopyToHoSo(int.Parse("0" + hdfMaUngVien.Text), Session["MaDonVi"].ToString(), int.Parse("0" + hdfMaKeHoachTuyenDung.Text), dfNgayThuViec.SelectedDate, newMaCb,maDonViKyHopDong, maDiaDiemLamViec);
                wdForwardToHOSO.Hide();
                checkboxSelection.ClearSelections();
                GridPanel1.Reload();
                btnChuyenTiep.Disabled = true;
                btnRoiNgayDiLam.Disabled = true;
                btnTinhTrangDiLam.Disabled = true;
                Dialog.ShowNotification("Chuyển thành công!");
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    protected void cbx_httuyen_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_httuyen_Store.DataSource = new DM_HT_TUYENDUNGController().GetAll();
        cbx_httuyen_Store.DataBind();
    }
    public void mnuXacNhanDiLam_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in checkboxSelection.SelectedRows)
            {
                DAL.HoSoUngVien hsuv = new DAL.HoSoUngVien();
                hsuv.MaUngVien = int.Parse("0" + item.RecordID);
                if (e.ExtraParams["XacNhan"] == "TuChoi")
                { hsuv.XacNhanDiLam = false; }
                else
                { hsuv.XacNhanDiLam = true; }
                new HoSoUngVienController().XacNhanDiLam(hsuv);
            }
            checkboxSelection.ClearSelections();
            GridPanel1.Reload();
            btnChuyenTiep.Disabled = true;
            btnRoiNgayDiLam.Disabled = true;
            btnTinhTrangDiLam.Disabled = true;
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}