using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
using DAL;
using System.Data;
using DataController;
using SoftCore.Security;
using ExtMessage;
using System.IO;
using SoftCore;
using SoftCore.AccessHistory;
using System.Data.SqlClient;
using System.Text;

public partial class Modules_TienLuong_BangLuongDong : WebBase
{
    //private int idBangLuong = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Ext.Net.X.IsAjaxRequest)
        {
            // phân quyền chức năng
            SetVisibleByControlID(mnuAddEmployee, mnuDeleteEmployee, btnAdjustment, mnuLayTatCa, mnuLayDuocChon, mnuTinhChoTatCa, mnuCalculateSelected,
                btnKhoaBangLuong, btnMoKhoaBangLuong, btnThemBangTinhLuong, btnSuaBangTinhLuong, btnXoaBangTinhLuong);

            LoadRecordField();
            LoadColumnIntoGrid();
            //LoadDonVi();
            LoadDepartment();

            //new DTH.BorderLayout()
            //{
            //    menuID = MenuID,
            //    script = "#{hdfSelectedDepartment}.setValue('" + DTH.BorderLayout.nodeID + "');#{StaticPagingToolbar}.pageIndex = 0; #{StaticPagingToolbar}.doLoad();"
            //}.AddDepartmentList(br, CurrentUser.ID, true);

            cbChonThang.SetValue(DateTime.Now.Month);
            spinChonNam.SetValue(DateTime.Now.Year);
            hdfSessionDepartment.Text = Session["MaDonVi"].ToString();
            hdfMenuID.SetValue(MenuID);
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
        SetVisibleByControlID(btnEditOnGrid);
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
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_GetSalaryConfig", "@menuID", hdfMenuID.Text);
            string sql = "SELECT '''' + h.MA_CB as N'Mã CB',h.HO_TEN as N'Họ tên', dc.TEN_CHUCVU as N'Chức vụ', ha.ATMNumber AS 'Tài khoản Techcombank', ha1.ATMNumber AS 'Tài khoản khác',";
            for (int i = 0; i < table.Rows.Count - 1; i++)
            {
                sql += table.Rows[i]["ColumnName"].ToString() + " AS N'" + table.Rows[i]["ColumnDescription"].ToString() + "', ";
            }
            sql += table.Rows[table.Rows.Count - 1]["ColumnName"].ToString() + " AS N'" + table.Rows[table.Rows.Count - 1]["ColumnDescription"].ToString() + "' ";
            sql += " FROM TienLuong.BangLuongDong AS bld LEFT JOIN HOSO AS h ON bld.PrKeyHoSo = h.PR_KEY LEFT JOIN DM_CHUCVU dc ON h.MA_CHUCVU = dc.MA_CHUCVU "
                +"LEFT JOIN HOSO_ATM ha ON ha.PrKeyHoSo = h.PR_KEY AND ha.BankID = 'TECH' LEFT JOIN HOSO_ATM ha1 ON ha1.PrKeyHoSo = h.PR_KEY AND ha.BankID != 'TECH' "
                +" WHERE bld.IdBangLuong = " + hdfIDBangLuong.Text 
                + " AND (LEN(N'" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) 
                + "') = 0 OR h.HO_TEN LIKE N'%" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) 
                + "%' OR h.MA_CB LIKE N'%" + SoftCore.Util.GetInstance().GetKeyword(txtSearch.Text) + "%')";
            DAL.DanhSachBangLuong d = new DanhSachBangLuongController().GetByID(int.Parse(hdfIDBangLuong.Text));
            //Create Tempory Table
            DataTable dtTemp = DataController.DataHandler.GetInstance().ExecuteDataTable(sql);


            ExportToExcel("Payroll_Month"+d.Month+"Year"+d.Year+"_Department"+d.MA_DONVI.Replace(",","+")+".xls", dtTemp, d.Title);
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
    #region Load đơn vị
    /// <summary>
    /// get department list to display on html tree
    /// </summary>
    private void LoadDepartment()
    {
        List<DonViInfo> childList = new DM_DONVIController().GetEntityByParentID("0");
        string s = "";
        foreach (var item in childList)
        {
            s += string.Format("<li id='{0}' item-expanded='true'>{1}{2}</li>", item.MaDonVi, item.TenDonVi, BindChildDepartment(item.MaDonVi));
        }
        ldlMenuTree.Text = s;
    }
    private string BindChildDepartment(string parentID)
    {
        List<DonViInfo> childList = new DM_DONVIController().GetEntityByParentID(parentID);
        if (childList.Count() == 0)
        {
            return "";
        }
        string str = "";
        string function = "";
        foreach (var item in childList)
        {
            str += string.Format("<li id='{0}' item-expanded='true'>{1}{2}{3}</li>", item.MaDonVi, item.TenDonVi, BindChildDepartment(item.MaDonVi), function);
        }
        return string.Format("<ul>{0}</ul>", str);
    }
    private void LoadDonVi()
    {
        List<DM_DONVI> dvList = new UserController().GetDonViByUserID(CurrentUser.ID);
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        foreach (DM_DONVI dv in dvList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
            node.Icon = Ext.Net.Icon.House;
            root.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA_DONVI;
            node.Checked = ThreeStateBool.False;
            LoadChildDepartment(dv.MA_DONVI, node);
            //node.Listeners.Click.Handler = "txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue() + ' tại bộ phận ' + Field3.getValue());";
        }

        //TreePanel1.Root.Clear();
        //TreePanel1.Root.Add(root);
    }

    private void LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    {
        List<DM_DONVI> childList = new DM_DONVIController().GetByParentID(maDonVi);
        foreach (DM_DONVI dv in childList)
        {
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
            node.Icon = Ext.Net.Icon.Folder;
            DvNode.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA_DONVI;
            node.Checked = ThreeStateBool.False;
            //node.Listeners.Click.Handler = "txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue() + ' tại bộ phận ' + Field3.getValue());";
            LoadChildDepartment(dv.MA_DONVI, node);
        }
    }
    #endregion

    #region Cấu hình bảng lương động
    private void LoadColumnIntoGrid()
    {
        // create HeaderRow
        Ext.Net.HeaderRow row = new HeaderRow();
        int i = 0;
        foreach (var item in new SalaryBoardConfigController().GetSalaryColumnList(MenuID))
        {
            // set editor
            Ext.Net.TextField txtEditor = new TextField();
            txtEditor.MaskRe = "/[0-9.-]/";
            txtEditor.ID = "txtEditor" + i;
            item.Editor.Add(txtEditor);

            grpSalaryBoard.ColumnModel.Columns.Add(item);

            #region Tạo GroupHeader
            // create HeaderColumn
            Ext.Net.HeaderColumn column = new HeaderColumn();
            column.AutoWidthElement = false;
            // tạo DisplayField để hiển thị
            Ext.Net.DisplayField dpf = new DisplayField();
            dpf.ID = "dpf" + item.ColumnID;
            dpf.Text = "";
            // add DisplayField to ColumnHeader
            column.Component.Add(dpf);
            row.Columns.Add(column);
            #endregion

            i++;
        }
        lkv.HeaderRows.Add(row);
    }

    private void LoadRecordField()
    {
        //RecordField r = new RecordField() { Name = "C1" };
        //stSalaryBoard.AddField(r);
        foreach (var item in new SalaryBoardConfigController().GetSalaryColumnList(MenuID))
        {
            RecordField r = new RecordField() { Name = item.ColumnID };
            stSalaryBoard.AddField(r);
        }
    }

    private void SetEditor()
    {
        if (hdfIsLocked.Text == "true")
            SetEditable(false);
        else
            SetEditable(true);
    }

    private void SetEditable(bool value)
    {
        //int number = new SalaryBoardConfigController().GetSalaryColumnList(MenuID).Count;
        //for (int i = 2; i < number; i++)
        //{
        //    grpSalaryBoard.ColumnModel.Columns[i].Editable = value;
        //}
        int j = 0;
        foreach (var item in new SalaryBoardConfigController().GetSalaryColumnList(MenuID))
        {
            if (btnEditOnGrid.Visible)
            {
                if (value == true)
                {
                    if (item.Editable == true)
                        grpSalaryBoard.ColumnModel.SetEditable(3 + j, value);
                }
                else
                {
                    grpSalaryBoard.ColumnModel.SetEditable(3 + j, value);
                }
            }
            else
            {
                grpSalaryBoard.ColumnModel.SetEditable(3 + j, false);
            }
            j++;
        }
    }
    #endregion

    #region Quản lý bảng lương
    /// <summary>
    /// Thêm mới một bảng lương
    /// @daibx
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDongYThemBangTinhClick(object sender, DirectEventArgs e)
    {
        try
        {
            DanhSachBangLuongController controller = new DanhSachBangLuongController();
            int thang = int.Parse(cbChonThang.SelectedItem.Value);
            int nam = int.Parse(spinChonNam.Text);
            if (e.ExtraParams["Edit"] != "True")//thêm bảng tính
            {
                if (controller.CheckTrungThangNam(hdfMaDonVi.Text, thang, nam, MenuID))
                {
                    X.Msg.Alert("Thông báo", "Đã tồn tại bảng tính lương cho bộ phận " + cbChonPhongBan.Text + " trong tháng " + thang.ToString() + " năm " + nam.ToString() + "").Show();
                    return;
                }
                DAL.DanhSachBangLuong bang = new DAL.DanhSachBangLuong()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MA_DONVI = hdfMaDonVi.Text,
                    SessionDepartment = Session["MaDonVi"].ToString(),
                    Month = thang,
                    Year = nam,
                    Title = txtTenBangTinhLuong.Text,
                    Description = txtDescription.Text,
                    MenuID = MenuID
                };
                controller.Insert(bang);
                hdfIDBangLuong.SetValue(bang.ID);
                if (!string.IsNullOrEmpty(hdfMaDonVi.Text))
                    DataController.DataHandler.GetInstance().ExecuteNonQuery("CreateBangLuong", "@IdBangLuong", "@MaDonVi", bang.ID, hdfMaDonVi.Text);
                Dialog.ShowNotification("Thông báo", "Thêm mới bảng lương thành công");
            }
            else //sửa bảng tính
            {
                DAL.DanhSachBangLuong bang = controller.GetByID(int.Parse("0" + hdfIDBangLuong.Text));
                bang.Title = txtTenBangTinhLuong.Text;
                bang.Month = thang;
                bang.Year = nam;
                bang.Description = txtDescription.Text;
                controller.Update(bang);
                Dialog.ShowNotification("Thông báo", "Câp nhật thông tin bảng lương thành công");
            }
            wdThemBangTinhLuong.Hide();
            grpDanhSachBangTinhLuong.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Sửa thông tin bảng lương
    /// @daibx
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSuaBangTinhLuong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DanhSachBangLuong dsach = new DanhSachBangLuongController().GetByID(int.Parse("0" + hdfChosseBangLuong.Text));
            if (dsach != null)
            {
                cbChonThang.SetValue(dsach.Month);
                spinChonNam.SetValue(dsach.Year);
                txtTenBangTinhLuong.Text = dsach.Title;
                txtDescription.Text = dsach.Description;

                wdThemBangTinhLuong.Show();
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Xóa bảng lương khỏi danh sách (chỉ xóa các bảng lương chưa khóa)
    /// @daibx
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnXoaBangTinhLuongClick(object sender, DirectEventArgs e)
    {
        try
        {
            bool isLock = new DanhSachBangLuongController().Delete(int.Parse("0" + hdfChosseBangLuong.Text));
            if (isLock == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không có quyền xóa");
            }
            hdfIDBangLuong.Text = "0";
            grpDanhSachBangTinhLuong.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Chọn bảng lương
    /// @daibx
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnChonBangTinhLuongClick(object sender, DirectEventArgs e)
    {
        try
        {
            //if (hdfChosseBangLuong.Text == hdfIDBangLuong.Text)
            //{
            //    wdQuanLyBangTinhLuong.Hide();
            //    return;
            //}
            //else
            {
                hdfIDBangLuong.Text = hdfChosseBangLuong.Text;
                DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(int.Parse("0" + hdfIDBangLuong.Text));
                int idBangLuong = bangLuong.ID;
                grpSalaryBoard.Title = bangLuong.Title;
                //Response.Redirect(Request.RawUrl);
                LoadTongLuong();
                ReloadGrid();
            }

        }
        catch (Exception)
        {
            Dialog.ShowError("Không tìm thấy bảng lương");
        }
    }
    #endregion

    #region Thêm, xóa cán bộ khỏi bảng lương
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse(hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text) || hdfIDBangLuong.Text == "0")
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương nào");
                return;
            }
            int count = 0;
            string ma = "", errStr = string.Empty;
            // lấy danh sách các mã cán bộ được chọn
            SelectedRowCollection selectedRows = ucChooseEmployee1.SelectedRow;
            foreach (var item in selectedRows)
            {
                try
                {
                    bool isSuccess = bool.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("InsertEmployeeToSalaryBoard", "@IDBangLuong", "@MaCanBo",
                        idBangLuong, item.RecordID).ToString());
                    if (isSuccess == false)
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
            grpSalaryBoard.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void mnuXoaNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse(hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            SelectedRowCollection selectedRows = RowSelectionModelSalaryBoard.SelectedRows;
            string error = string.Empty;
            foreach (var item in selectedRows)
            {
                try
                {
                    DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_DeleteEmployee", "@ID", item.RecordID);
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
            grpSalaryBoard.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Điều chỉnh bảng lương
    protected void btnAcceptAdjustment_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            // áp dụng cho các cán bộ được chọn
            if (chkApplySelectedEmployee.Checked)
            {
                SelectedRowCollection selecteds = RowSelectionModelSalaryBoard.SelectedRows;
                foreach (var item in selecteds)
                {
                    DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_AdjustmentValueSelected", "@ID", "@ColumnName", "@Value",
                            int.Parse(item.RecordID), cbxSelectColumn.SelectedItem.Value, float.Parse(txtValueAdjustment.Text.Replace('.', ',')));
                }
            }
            // áp dụng cho toàn bộ cán bộ
            else if (chkApplyForAll.Checked)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_AdjustmentValueForAll", "@IDBangLuong", "@ColumnName", "@Value",
                        idBangLuong, cbxSelectColumn.SelectedItem.Value, float.Parse(txtValueAdjustment.Text.Replace('.', ',')));
            }
            grpSalaryBoard.Reload();
            wdDieuChinh.Hide();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void AfterEdit(int id, string field, string oldValue, string newValue, object customer)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                stSalaryBoard.CommitChanges();
                grpSalaryBoard.Reload();
                return;
            }
            float value = 0;
            try
            {
                value = float.Parse(newValue.Replace('.', ','));
            }
            catch (Exception) { value = 0; }
            new BangLuongDongController().UpdateBangThanhToanLuong(id, field, value, int.Parse("0" + hdfIDBangLuong.Text));
            stSalaryBoard.CommitChanges();
            try
            {
                new BangLuongDongController().CalculateSalaryForAnEmployee(idBangLuong, id + "");
            }
            catch (Exception)
            {

            }
            LoadTongLuong();
           // grpSalaryBoard.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification("Có lỗi xảy ra: " + ex.Message);
        }
    }
    #endregion

    #region Lấy dữ liệu
    /// <summary>
    /// Lấy dữ liệu cho tất cả cán bộ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuGetDataForAll_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_CapNhatThamSoCong", "@SalaryBoardID", "@selectedID", idBangLuong, "");
            LoadTongLuong();
            grpSalaryBoard.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Lấy dữ liệu cho các nhân viên được chọn
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuGetDataForSelectedEmployee_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            SelectedRowCollection selecteds = RowSelectionModelSalaryBoard.SelectedRows;
            string selectedID = string.Empty;
            foreach (var item in selecteds)
            {
                selectedID += item.RecordID + ",";
            }
            DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_CapNhatThamSoCong", "@SalaryBoardID", "@selectedID", idBangLuong, selectedID);
            grpSalaryBoard.Reload();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Tính lương
    protected void btnCalculateSalary_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            new BangLuongDongController().CalculateSalaryBoard(idBangLuong);
            LoadTongLuong();
            grpSalaryBoard.Reload();
            Dialog.ShowNotification("Hoàn thành tính lương");
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void mnuCalculateSelected_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            SelectedRowCollection selecteds = RowSelectionModelSalaryBoard.SelectedRows;
            string dsIdBangLuongDong = string.Empty;
            foreach (var item in selecteds)
            {
                dsIdBangLuongDong += item.RecordID + ",";
            }
            int pos = dsIdBangLuongDong.LastIndexOf(',');
            if (pos != -1)
                dsIdBangLuongDong = dsIdBangLuongDong.Remove(pos);
            new BangLuongDongController().CalculateSalaryForAnEmployee(idBangLuong, dsIdBangLuongDong);
            LoadTongLuong();
            grpSalaryBoard.Reload();
            Dialog.ShowNotification("Tính lương xong cho nhân viên được chọn");
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    [DirectMethod]
    public void LoadTongLuong()
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                //Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            //DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("TienLuong_TinhTongLuongGroupHeader", "@MaDonVi", "@IDBangLuong", "@seachKey",
            //    "", idBangLuong, txtSearch.Text);
            List<SalaryBoardConfigInfo> lists = new SalaryBoardConfigController().GetSalaryBoardConfig(MenuID);
            string sqlString = string.Empty;
            foreach (var it in lists)
            {
                if (it.AllowSum == true)
                {
                    sqlString += "SUM(ISNULL(bld." + it.ColumnName + ", 0)) AS '" + it.ColumnName + "',";
                }
            }
            int pos = sqlString.LastIndexOf(',');
            if (pos != -1)
                sqlString = sqlString.Remove(pos);
            if (string.IsNullOrEmpty(sqlString) || sqlString == "")
            {
                return;
            }
            sqlString = "SELECT " + sqlString + string.Format(@"FROM   (
                                      SELECT hs.PR_KEY,
                                             hs.MA_CB,
                                             hs.TEN_CB,
                                             hs.HO_TEN,
                                             hs.MA_DONVI
                                      FROM   HOSO hs
                                  ) AS hs
                                  LEFT JOIN TienLuong.BangLuongDong bld
                                       ON  hs.PR_KEY = bld.PrKeyHoSo
                           WHERE  (
                                      LEN('" + txtSearch.Text + @"') = 0
                                      OR hs.MA_CB LIKE N'%' + '" + txtSearch.Text + @"' + '%'
                                      OR hs.HO_TEN LIKE N'%' + '" + txtSearch.Text + @"' + '%'
                           )
                           AND (LEN('') = 0 OR  hs.MA_DONVI in (select MA_DONVI from f_GetDanhSachMaDonVi('')))
                           AND " + idBangLuong + @"=bld.IDBangLuong
                           GROUP BY bld.IDBangLuong");
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable(sqlString);

            if (table.Rows.Count > 0)
            {
                DataRow record = table.Rows[0];
                string javascript = string.Empty;
                foreach (var item in lists)
                {
                    if (item.AllowSum == true)
                    {
                        javascript += "dpf" + item.ColumnName + ".setValue(RenderVNDGroupHeader(" + record[item.ColumnName] + "));";
                    }
                }
                RM.RegisterClientScriptBlock("SetSum", javascript);
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Khóa/Mở khóa bảng lương
    protected void btnKhoaBangLuongClick(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);

            if (bangLuong.DaKhoa == true)
            {
                Dialog.ShowError("Bảng lương đã khóa. Bạn không được phép thao tác");
                return;
            }
            if (idBangLuong == 0)
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy bảng tổng hợp lương").Show();
                return;
            }
            new DanhSachBangLuongController().LockBangLuong(idBangLuong, true);
            //Response.Redirect(Request.RawUrl);
            ReloadGrid();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    protected void btnMoBangLuongClick(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIDBangLuong.Text))
            {
                Dialog.ShowError("Bạn chưa chọn bảng lương");
                return;
            }
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            if (idBangLuong == 0)
            {
                X.Msg.Alert("Thông báo từ hệ thống", "Không tìm thấy bảng tổng hợp lương").Show();
                return;
            }
            new DanhSachBangLuongController().LockBangLuong(idBangLuong, false);
            //Response.Redirect(Request.RawUrl);
            ReloadGrid();
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
    #endregion

    #region Load ComboBox
    protected void cbxSelectColumnStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<object> objs = new List<object>();
        foreach (var item in new SalaryBoardConfigController().GetSalaryColumnList(MenuID))
        {
            objs.Add(new { ColumnName = item.ColumnID, ColumnDescription = item.Header });
        }
        cbxSelectColumnStore.DataSource = objs;
        cbxSelectColumnStore.DataBind();
    }
    #endregion

    private void ReloadGrid()
    {
        try
        {
            // xử lý chọn bảng lương
            int idBangLuong = int.Parse("0" + hdfIDBangLuong.Text);
            if (idBangLuong != 0)
            {
                try
                {
                    DAL.DanhSachBangLuong bangLuong = new DanhSachBangLuongController().GetByID(idBangLuong);
                    idBangLuong = bangLuong.ID;
                    hdfIDBangLuong.SetValue(idBangLuong);
                    grpSalaryBoard.Title = bangLuong.Title;
                    wdQuanLyBangTinhLuong.Hide();
                    if (bangLuong.DaKhoa == true)
                    {
                        if (btnEmployee.Visible)
                            btnEmployee.Disabled = true;
                        if (btnAdjustment.Visible)
                            btnAdjustment.Disabled = true;
                        if (btnCalculateSalary.Visible)
                            btnCalculateSalary.Disabled = true;
                        if (btnMoKhoaBangLuong.Visible)
                            btnMoKhoaBangLuong.Show();
                        if (btnKhoaBangLuong.Visible)
                            btnKhoaBangLuong.Hide();
                        hdfIsLocked.Text = "true";
                    }
                    else
                    {
                        if (btnEmployee.Visible)
                            btnEmployee.Disabled = false;
                        if (btnAdjustment.Visible)
                            btnAdjustment.Disabled = false;
                        if (btnCalculateSalary.Visible)
                            btnCalculateSalary.Disabled = false;
                        if (btnMoKhoaBangLuong.Visible)
                            btnMoKhoaBangLuong.Hide();
                        if (btnKhoaBangLuong.Visible)
                            btnKhoaBangLuong.Show();
                        hdfIsLocked.Text = "false";
                    }
                    SetEditor();
                    grpSalaryBoard.Reload();
                }
                catch (Exception ex)
                {
                    ExtMessage.Dialog.ShowError(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }
}