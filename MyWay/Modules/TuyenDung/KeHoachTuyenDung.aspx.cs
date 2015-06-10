using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DAL;
using SoftCore.Security;
using ExtMessage;
using DataController;
using System.Data.SqlClient;
using SoftCore;
using System.Data;
using System.Text;

public partial class Modules_TuyenDung_KeHoachTuyenDungNEW : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            spnYear.SetValue(DateTime.Now.Year);
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
            int start = 0, limit = 10000000;
            try
            {
                limit = PagingToolbar1.PageIndex * int.Parse("0" + ComboBox1.Text);
                start = limit - int.Parse("0" + ComboBox1.Text);
            }
            catch (Exception ex) { }
            //Create Tempory Table
            var dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_KeHoachTuyenDung_ExportToExcel", "@start", "@limit", "@searchKey", "@month", "@year", start, limit, SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text).Replace(" ", "%"), cbxMonth.SelectedItem.Value, spnYear.Value);


            ExportToExcel("KeHoachTuyenDung.xls", dtTemp,"Danh sách kế hoạch tuyển dụng");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
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
                        sb.Append(table.Rows[soDem][col].ToString().Replace(",", " "));
                    sb.Append("\t");
                }
                if (table.Rows[soDem][table.Columns.Count - 1] != null)
                    sb.Append(table.Rows[soDem][table.Columns.Count - 1].ToString().Replace(",", " "));


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
    #region Cập nhật dữ liệu
    string[] dsDv;
    int countRole = -1;
    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "--";
            if (dsDv.Contains(item.MA))
                obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            else
            {
                obj.Add(new { MA = countRole.ToString(), TEN = tmp + item.TEN });
                countRole--;
            }
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }
    public void stDonVi_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
        if (dsDv == null || dsDv.Count() == 0)
        {
            dsDv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        }
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            if (dsDv.Contains(info.MA))
                obj.Add(new { MA = info.MA, TEN = info.TEN });
            else
            {
                obj.Add(new { MA = countRole.ToString(), TEN = info.TEN });
                countRole--;
            }
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        stDonVi.DataSource = obj;
        stDonVi.DataBind();
    }
    public void btnThemYeuCauTuyenDung_Click(object sender, DirectEventArgs e)
    {
        new DALController().Add(wdAddRequest, "TuyenDung.YeuCauTuyenDung");
        if (e.ExtraParams.Count > 0)
        {
            if (e.ExtraParams[0].Value == "True")
                wdAddRequest.Hide();
        }
    }

    public void btnThemChiPhiTuyenDung_Click(object sender, DirectEventArgs e)
    {
        new DALController().Add(wdChiPhi, "TuyenDung.ChiPhiTuyenDung", new string[] { "MaKeHoachTuyenDung", "CreatedDate", "CreatedBy" }, new string[] { hdfRecordID.Text, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), CurrentUser.ID.ToString() });
        if (e.ExtraParams.Count > 0)
        {
            if (e.ExtraParams[0].Value == "True")
                wdAddRequest.Hide();
        }
    }



    public void btnThemHoiDong_Click(object sender, DirectEventArgs e)
    {
        new DALController().Add(wdHoiDong, "TuyenDung.HoiDongTuyenDung", new string[] { "CreatedDate", "CreatedBy" }, new string[] { DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), CurrentUser.ID.ToString() });
        if (e.ExtraParams.Count > 0)
        {
            if (e.ExtraParams[0].Value == "True")
                wdHoiDong.Hide();
        }
    }
    public void btnCapNhatKeHoachTuyenDung_Click(object sender, DirectEventArgs e)
    {
        try
        {
            KeHoachTuyenDungController ctrol = new KeHoachTuyenDungController();
            DAL.KeHoachTuyenDung khtd = new KeHoachTuyenDung();
            khtd.CreatedBy = CurrentUser.ID;
            khtd.CreatedDate = DateTime.Now;
            if (df_HanNopHoSo.SelectedDate.ToString().Contains("0001") == false)
            {
                khtd.HanNopHoSo = df_HanNopHoSo.SelectedDate;
            }
            if (df_NgayBatDau.SelectedDate.ToString().Contains("0001") == false)
            {
                khtd.NgayBatDau = df_NgayBatDau.SelectedDate;
            }
            if (df_NgayKetThuc.SelectedDate.ToString().Contains("0001") == false)
            {
                khtd.NgayKetThuc = df_NgayKetThuc.SelectedDate;
            }
            khtd.TenKeHoach = txt_TenKeHoach.Text;
            khtd.SoLuongCanTuyen = int.Parse("0" + txt_SoLuongCanTuyen.Text);
            khtd.SoVongPhongVan = int.Parse("0" + txt_SoVongPhongVan.Text);
            khtd.MaChucVu = hdfMaChucVu.Text;
            khtd.MaCongViec = hdfMaCongViec.Text;
            khtd.MA_DONVI = hdfMaDonVi.Text;
            khtd.MucLuongDuKienToiDa = decimal.Parse("0" + txt_MucLuongDuKienToiDa.Text);
            khtd.MucLuongDuKienToiThieu = decimal.Parse("0" + txt_MucLuongDuKienToiThieu.Text);
            khtd.KinhPhiDuTru = decimal.Parse("0" + txt_KinhPhiDuTru.Text);
            khtd.ThoiGianThuViec = txt_ThoiGianThuViec.Text;
            khtd.LyDoTuyen = int.Parse("0" + hdfLyDoTuyenDung.Text);
            khtd.GhiChu = txt_GhiChu.Text;
            if (e.ExtraParams["Command"] == "Edit")
            {
                khtd.ID = int.Parse("0" + hdfRecordID.Text);
                ctrol.Update(khtd);
                wdInsertKeHoachTuyenDung.Hide();
                Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
            }
            else
            {
                ctrol.Insert(khtd);
                Dialog.ShowNotification("Thêm mới thành công!");
            }

            if (e.ExtraParams["Close"] == "True")
            {
                wdInsertKeHoachTuyenDung.Hide();
            }
            grp_KeHoachTuyenDung.Reload();

        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btnEditKHTD_Click(object sender, DirectEventArgs e)
    {
        try
        {

            DAL.KeHoachTuyenDung khtdInfo = new KeHoachTuyenDungController().GetById(int.Parse("0" + hdfRecordID.Text));
            if (khtdInfo == null)
            {
                Dialog.ShowError("Không tìm thấy kế hoạch tuyển dụng");
                return;
            }

            txt_TenKeHoach.Text = khtdInfo.TenKeHoach;
            if (khtdInfo.SoLuongCanTuyen != null)
            {
                txt_SoLuongCanTuyen.Text = khtdInfo.SoLuongCanTuyen.ToString();
            }
            if (khtdInfo.KinhPhiDuTru != null)
            {
                txt_KinhPhiDuTru.Text = khtdInfo.KinhPhiDuTru.ToString();
            }
            if (khtdInfo.ThoiGianThuViec != null)
            {
                txt_ThoiGianThuViec.Text = khtdInfo.ThoiGianThuViec.ToString();
            }
            if (khtdInfo.MucLuongDuKienToiThieu != null)
            {
                txt_MucLuongDuKienToiThieu.Text = khtdInfo.MucLuongDuKienToiThieu.ToString();
            }
            if (khtdInfo.MucLuongDuKienToiDa != null)
            {
                txt_MucLuongDuKienToiDa.Text = khtdInfo.MucLuongDuKienToiDa.ToString();
            }

            if (khtdInfo.SoVongPhongVan != null)
            {
                txt_SoVongPhongVan.Text = khtdInfo.SoVongPhongVan.ToString();
            }

            if (khtdInfo.HanNopHoSo != null)
                df_HanNopHoSo.SelectedDate = khtdInfo.HanNopHoSo.Value;
            if (khtdInfo.NgayBatDau != null)
                df_NgayBatDau.SelectedDate = khtdInfo.NgayBatDau.GetValueOrDefault(DateTime.Now.Date);
            if (khtdInfo.NgayKetThuc != null)
                df_NgayKetThuc.SelectedDate = khtdInfo.NgayKetThuc.GetValueOrDefault(DateTime.Now.Date);

            if (!string.IsNullOrEmpty(khtdInfo.MaChucVu))
                cbx_MaChucVu.SetValueAndFireSelect(khtdInfo.MaChucVu);
            if (!string.IsNullOrEmpty(khtdInfo.MaCongViec))
                cbx_MaCongViec.SetValueAndFireSelect(khtdInfo.MaCongViec);
            if (!string.IsNullOrEmpty(khtdInfo.MA_DONVI))
                cbx_Ma_DonVi.SetValueAndFireSelect(khtdInfo.MA_DONVI);


            btnCapNhatKeHoachTuyenDung.Hide();
            btnEditKeHoachTuyenDung.Show();
            btnCapNhat_DongLaiKHTD.Hide();
            btnClose.Show();

            wdInsertKeHoachTuyenDung.Title = "Cập nhật kế hoạch tuyển dụng";
            wdInsertKeHoachTuyenDung.Icon = Icon.Pencil;
            wdInsertKeHoachTuyenDung.Show();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    public void btnDeleteKHTD_Click(object sender, DirectEventArgs e)
    {

        try
        {
            string maKHTD = "";
            DataTable dt = new DataTable();
            foreach (var item in checkboxSelection.SelectedRows)
            {
                dt  = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_CheckKeHoachTDDelete", "@MaKH", decimal.Parse(item.RecordID));
                if (dt.Rows.Count > 0)
                {
                    maKHTD += item.RecordID + ", ";
                }
                else
                {
                    new KeHoachTuyenDungController().Delete(int.Parse("0" + item.RecordID));
                }
            }
            RM.RegisterClientScriptBlock("n", "resetButtonAfterDelete();");
            grp_KeHoachTuyenDung.Reload();
            if (maKHTD.Length>1)
            {
                Dialog.ShowError("Có lỗi xảy ra ", "Kế hoạch tuyển dụng có mã " + maKHTD.Substring(0,maKHTD.Length-2) + " đang được sử dụng");
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    public void btnNhanDoiDuLieu_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in checkboxSelection.SelectedRows)
            {
                int id = int.Parse(hdfRecordID.Text);
                int ma = int.Parse(txt_NewID.Text);
                //  new KeHoachTuyenDungController().Double(id, ma);
                wdNhanDoiDuLieu.Hide();

            }
            grp_KeHoachTuyenDung.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    public void mnuNhanDoiDuLieuKHTD_Click(object sender, DirectEventArgs e)
    {
        try
        {
            int id = int.Parse(hdfRecordID.Text);
            DAL.KeHoachTuyenDung khtdInfo = new KeHoachTuyenDungController().GetById(id);
            txt_NewID.Text = khtdInfo.ID.ToString();
            wdNhanDoiDuLieu.Show();
            grp_KeHoachTuyenDung.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message + hdfRecordID.Text);
        }
    }
    #endregion
    #region Panel Thông tin yêu cầu
    [DirectMethod]
    protected void pnlYeuCauTuyenDung_Load()
    {
        var data = new KeHoachTuyenDungController().GetInfoByID(decimal.Parse("0" + hdfRecordID.Text));
        foreach (var item in data)
        {

        }
    }

    protected void stLyDoTuyenDung_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            stLyDoTuyenDung.DataSource = DataHandler.GetInstance().ExecuteDataTable("select ID, Value from dbo.ThamSoTrangThai where ParamName = 'LyDoTuyenDung' AND IsInUsed = 1");
            stLyDoTuyenDung.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion
    #region Panel các khoản chi
    protected void btnCapNhatChiPhi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SoftCore.Util util = new Util();
            DAL.ChiPhiTuyenDung d = new ChiPhiTuyenDung();
            d.TenChiPhi = txtTenKhoanChiPhi.Text;
            if (!util.IsDateNull(dfNgayChi.SelectedDate))
                d.NgayChi = dfNgayChi.SelectedDate;
            d.NguonChi = txtNguonChi.Text;
            d.SoTien = decimal.Parse("0" + txtSoTienChiPhi.Text);
            d.PlanID = int.Parse("0" + hdfRecordID.Text);
            d.CreatedBy = CurrentUser.ID;
            d.CreatedDate = DateTime.Now;
            d.GhiChu = txtGhiChuCacKhoanChi.Text;
            ChiPhiTuyenDungController control = new ChiPhiTuyenDungController();
            if (e.ExtraParams["type"] == "edit")
            {
                d.ID = int.Parse("0" + hdfChiPhiID.Text);
                control.Update(d);
                wdCacKhoanChiPhi.Hide();
            }
            else
            {
                control.Insert(d);
                if (e.ExtraParams["Close"] == "true")
                {
                    wdCacKhoanChiPhi.Hide();
                }

            }
            RM.RegisterClientScriptBlock("resetWd", "resetWdCacKhoanChiPhi();");
            grdchiphituyendung.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    protected void btnDeleteChiPhi_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel_CPTD.SelectedRows)
            {
                new ChiPhiTuyenDungController().Delete(int.Parse("0" + item.RecordID));
            }
            RM.RegisterClientScriptBlock("resetAfterDeleteChiPhi", "resetButtonAfterDeleteChiPhi();");
            grdchiphituyendung.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    #endregion
    #region Panel Các môn thi tuyển
    protected void storeMaMonThi_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            storeMaMonThi.DataSource = new ThamSoTrangThaiController().GetByParamName("CacMonThiTuyen", Session["MaDonVi"].ToString(),"");
            storeMaMonThi.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    protected void stSubjectList_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            var monThi = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetCacMonThiTuyenByPlanID", "@PlanID", int.Parse("0" + hdfRecordID.Text));
            stSubjectList.DataSource = monThi;
            stSubjectList.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    protected void btnAddSubjectList_Click(object sender, DirectEventArgs e)
    {
        try
        {
            CacMonThiTuyenController control = new CacMonThiTuyenController();
            DAL.CacMonThiTuyen mt = new CacMonThiTuyen();
            mt.Vong = int.Parse("0" + txt_Vong.Text);
            mt.TrongSo = decimal.Parse("0" + txt_TrongSo.Text.Trim().Replace(".",","));
            mt.PlanID = int.Parse("0" + hdfRecordID.Text);
            mt.GhiChu = txt_GhiChuMonThi.Text;
            mt.MaMonThi = int.Parse("0" + hdfMaMonThi.Text);
            mt.DiemDat = double.Parse("0" + txt_DiemDat.Text.Trim().Replace(".", ","));
            mt.NguoiChamThi = int.Parse("0" + hdfNguoiChamThi.Text);
            var dt = DataController.DataHandler.GetInstance().ExecuteDataTable("SELECT * FROM TuyenDung.HoiDongTuyenDung hdtd WHERE hdtd.PrKeyHoSo = " + decimal.Parse("0" + hdfNguoiChamThi.Text) + "AND hdtd.PlanID = " + int.Parse("0" + hdfRecordID.Text));
            if (dt.Rows.Count == 0)
            {
                HoiDongTuyenDungController ctrol = new HoiDongTuyenDungController();
                DAL.HoiDongTuyenDung hd = new HoiDongTuyenDung();
                hd.CreatedBy = CurrentUser.ID;
                hd.CreatedDate = DateTime.Now;
                hd.PlanID = int.Parse("0" + hdfRecordID.Text);
                hd.PrKeyHoSo = decimal.Parse("0" + hdfNguoiChamThi.Text);
                hd.VongThi = int.Parse("0" + txt_Vong.Text);
                ctrol.Insert(hd);
                grpCouncilRecruitment.Reload();
                RowSelectionModel1.ClearSelections();
                btnDeleteCouncilRecruitment.Disabled = true;
                btnEditCouncilRecruitment.Disabled = true;
            }
            if (e.ExtraParams["type"] == "edit")
            {
                mt.ID = int.Parse("0" + hdfCacMonThiTuyen.Text);
                control.Update(mt);
                wdMonThi.Hide();
            }
            else
            {
                control.Insert(mt);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdMonThi.Hide();
                }

            }
            gpCacMonThiTuyen.Reload();
            RM.RegisterClientScriptBlock("resetWdMonThi", "resetWdMonThi();");

        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }

    }
    protected void btnDeleteSubject_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel2.SelectedRows)
            {
                var dt = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_CheckMonThiDelete", "@MaMonThi", "@PlanID", int.Parse(hdfMaMonThi.Text), int.Parse(hdfRecordID.Text));
                if (dt.Rows.Count > 0)
                {
                    Dialog.ShowError("Có lỗi xảy ra ", "Môn thi tuyển đang được sử dụng");
                }
                else
                {
                    new CacMonThiTuyenController().Delete(int.Parse("0" + item.RecordID));
                }
                //Dialog.ShowNotification("Xóa dữ liệu thành công!");
                RM.RegisterClientScriptBlock("resetAfterDeleteSubject", "resetButtonAfterDeleteSubject();");
                gpCacMonThiTuyen.Reload();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    #endregion
    #region Panel Hội đồng tuyển dụng
    protected void stCouncilRecruitment_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            var hoiDongTuyenDung = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_GetHoiDongTuyenDungByPlanID", "@PlanID", int.Parse("0" + hdfRecordID.Text));
            stCouncilRecruitment.DataSource = hoiDongTuyenDung;
            stCouncilRecruitment.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    protected void btnDeleteCouncilRecruitment_Click(object sender, DirectEventArgs e)
    {
        try
        {
            var dt = DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_CheckHoiDongChamThiDelete", "@MaCB", "@PlanID", decimal.Parse(hdfNguoiChamThi.Text), decimal.Parse(hdfRecordID.Text));
            if (dt.Rows.Count > 0)
            {
                Dialog.ShowError("Có lỗi xảy ra ", "Cán bộ chấm thi đã có tên trong danh sách chấm thi của các môn thi tuyển");
            }
            else
            {
                foreach (var item in RowSelectionModel1.SelectedRows)
                {
                    new HoiDongTuyenDungController().Delete(int.Parse("0" + item.RecordID));
                }
            }
            //new HoiDongTuyenDungController().Delete(int.Parse("0" + hdfCouncilRecruitment.Text));
            //Dialog.ShowNotification("Xóa dữ liệu thành công!");
            RM.RegisterClientScriptBlock("resetAfterDeleteCouncilRecruitment", "resetButtonAfterDeleteHoiDong();");
            grpCouncilRecruitment.Reload();
            //}
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra " + ex.Message);
        }
    }
    protected void btnAddGiamKhao_Click(object sender, DirectEventArgs e)
    {
        try
        {
            HoiDongTuyenDungController control = new HoiDongTuyenDungController();
            DAL.HoiDongTuyenDung hd = new HoiDongTuyenDung();
            hd.CreatedBy = CurrentUser.ID;
            hd.CreatedDate = DateTime.Now;
            hd.Note = txtNoteHoiDong.Text;
            hd.PlanID = int.Parse("0" + hdfRecordID.Text);
            hd.PrKeyHoSo = decimal.Parse("0" + hdfGiamKhao.Text);
            hd.VongThi = int.Parse("0" + txt_VongCham.Text);
            if (e.ExtraParams["type"] == "edit")
            {
                hd.ID = int.Parse("0" + hdfCouncilRecruitment.Text);
                control.Update(hd);
                //Dialog.ShowNotification(CommonMessage.INSERT_SUCCESSFULLY);
                wdHoiDong.Hide();
            }
            else
            {
                control.Insert(hd);
                //Dialog.ShowNotification(CommonMessage.INSERT_SUCCESSFULLY);
                if (e.ExtraParams["Close"] == "true")
                {
                    wdHoiDong.Hide();
                }
            }
            RM.RegisterClientScriptBlock("resetWdHoiDong", "resetWdHoiDong();");
            grpCouncilRecruitment.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Lỗi xảy ra " + ex.Message);
        }
    }
    #endregion
    public void CheckDaThoiViec(object sender, DirectEventArgs e)
    {
        try
        {
            if (cbx_GiamKhao.SelectedItem == null)
            {
                X.MessageBox.Alert("Thông báo", "Không tìm thấy cán bộ");
                return;
            }
            decimal prkeyHoSo = decimal.Parse(cbx_GiamKhao.SelectedItem.Value);
            DAL.DanhSachCanBoThoiViec tv = new Controller.ThoiViec.DanhSachCanBoThoiViecController().GetByPrkeyHoSo(prkeyHoSo);
            if (tv != null) // exist in DanhSachCanBoThoiViec
            {
                // alert to user
                X.Msg.Confirm("Xác nhận", "Cán bộ được chọn nằm trong danh sách cán bộ đã thôi việc. Bạn có muốn tiếp tục?", new MessageBoxButtonsConfig
                {
                    Yes = new MessageBoxButtonConfig
                    {
                        Handler = "Ext.net.DirectMethods.DoYes()",
                        Text = "Đồng ý"
                    },
                    No = new MessageBoxButtonConfig
                    {
                        Handler = "Ext.net.DirectMethods.DoNo()",
                        Text = "Đóng lại"
                    }
                }).Show();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo", "Có lỗi xảy ra " + ex.Message);
        }
    }
    [DirectMethod]
    public void DoYes()
    {
        // nothing to do
    }

    [DirectMethod]
    public void DoNo()
    {
        wdMonThi.Hide();
    }

}