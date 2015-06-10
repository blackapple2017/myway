using System;
using System.Collections.Generic;
using System.Linq;
using Ext.Net;
using DAL;
using ExtMessage;
using System.Data;
using DataController;
using System.Data.SqlClient;
using Controller.ChamCongDoanhNghiep;

public partial class Modules_ChamCong_ChamCongTheoThang : SoftCore.Security.WebBase
{
    private static Dictionary<string, int> dictionaryDay = new Dictionary<string, int>();
    private static string idBangChamCong = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        hdfIdBangChamCong.Text = idBangChamCong;// Request.QueryString["blID"];
        if (!X.IsAjaxRequest)
        {
            string scriptContextMenu = "e.preventDefault(); " + RowContextMenu.ClientID + ".dataRecord = this.store.getAt(rowIndex);" + RowContextMenu.ClientID + ".showAt(e.getXY());" + RowSelectEvent.ClientID + ".selectRow(rowIndex);";
            GridPanel1.Listeners.RowContextMenu.Handler = scriptContextMenu;
            SetEditor();
            //Đối với người có quyền tạo bảng chấm công
            txtYear.Text = DateTime.Today.Year.ToString();
            txtTenBangChamCong.Text = GlobalResourceManager.GetInstance().GetLanguageValue("bangchamcong") + DateTime.Today.Month + "/" + txtYear.Text;
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;
            //GetTimeSheetSign();
            SetVisibleByControlID(btnBangChamCong, btnChooseTable, btnTaoBangCC, btnQuanLyBangChamCong, btnQuanLyNhanVien, btnDeleteUser, mnuThemNhanVien, mnuChuyenNhanVienSangBangChamCongKhac, btnTienIch, mnuChamCongHomNay, mnuChamCongTheoKhoangThoiGian, mnuDocExcel, btnBaoCao);
        }
        if (!Page.IsPostBack)
        {
            FindDayOfWeek();
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
        ImportFromExcel1.AfterClickImport += new EventHandler(AfterClickImport_AfterClickImport);
        ImportFromExcel1.AfterClickTestData += new EventHandler(AfterClickTestData_AfterClickTestData);

    }
    void AfterClickImport_AfterClickImport(object sender, EventArgs e)
    {
        try
        {
            List<BangChamCongThangInfo> list = (List<BangChamCongThangInfo>)sender;
            int idBangChamCong = Int32.Parse(hdfIdBangChamCong.Text);

            int count = 0;
            foreach (var item in list)
            {
                item.IdBangChamCong = idBangChamCong;
                bool tmp = new ChamCongThangController().UpdateFromExcel(item);
                if (tmp == true)
                    count++;
            }
            if (list.Count == 0)
            {
                X.Msg.Alert("Thông báo", "Không tìm thấy dữ liệu. Vui lòng kiểm tra lại").Show();
            }
            else
            {
                X.Msg.Alert("Thông báo", string.Format("Có {0} nhân viên được cập nhật dữ liệu", count)).Show();
                GridPanel1.Reload();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }

    void AfterClickTestData_AfterClickTestData(object sender, EventArgs e)
    {
        try
        {
            string invalidSymbol = (string)sender;
            if (invalidSymbol != "")
            {
                invalidSymbol = invalidSymbol.Substring(0, invalidSymbol.Length - 2);
                X.Msg.Alert("Thông báo", string.Format("Các kí hiệu sau chưa được định nghĩa trong phần mềm: {0}. Bạn có thể thêm các định nghĩa trong mục Danh mục ký hiệu chấm công", invalidSymbol)).Show();
            }
            else
            {
                X.Msg.Alert("Thông báo", "Kiểm tra dữ liệu thành công. Bạn có thể bắt đầu nhập dữ liệu").Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Nhập dữ liệu từ Excel: " + ex.Message.ToString());
        }
    }

    /// <summary>
    /// Thêm nhân viên vào bảng chấm công
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIdBangChamCong.Text))
            {
                X.Msg.Alert("Thông báo", "Bạn chưa chọn bảng chấm công nào").Show();
                return;
            }
            SelectedRowCollection SelectedRow = ucChooseEmployee1.SelectedRow;
            ChamCongThangController chamCongController = new ChamCongThangController();
            string str = "";
            foreach (var item in SelectedRow)
            {
                str += item.RecordID + ",";
            }
            DataHandler.GetInstance().ExecuteNonQuery("ChamCong_ThemNhanVienVaoBangChamCong", "@bangChamCongID", "@MaCBList", "@createdBy",
                                                                                               hdfIdBangChamCong.Text, str, CurrentUser.ID);
            RM.RegisterClientScriptBlock("reloadst", "#{Store1}.reload();");
            Dialog.ShowNotification("Cập nhật thành công");
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification("Có lỗi xảy ra" + ex.Message);
        }
    }

    /// <summary>
    /// sự kiện click của menu tình trạng làm việc, dành cho chấm công ngày hôm nay
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Click_Event(object sender, DirectEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(hdfIdBangChamCong.Text))
            {
                Ext.Net.MenuItem mnuItem = sender as Ext.Net.MenuItem;
                DM_TT_LAMVIEC ws = new KyHieuChamCongController().GetByName(mnuItem.Text);
                string sql = "update ChamCong.BangChamCongExcelTheoThang set NGAY";
                if (DateTime.Now.Day > 9)
                    sql += DateTime.Now.Day + " = N'" + ws.KYHIEU_TT_LAMVIEC + "' where PR_KEY = ";
                else
                    sql += "0" + DateTime.Now.Day + " = N'" + ws.KYHIEU_TT_LAMVIEC + "' where PR_KEY = ";
                int start = 0;
                int limit = 50;
                List<BangChamCongExcelTheoThang> bangLuong;
                do
                {
                    bangLuong = new ChamCongThangController().GetByIdBangChamCong(int.Parse(hdfIdBangChamCong.Text), start, limit);
                    foreach (var item in bangLuong)
                    {
                        DataController.DataHandler.GetInstance().ExecuteNonQuery(sql + item.PR_KEY);
                    }
                    start += limit;
                } while (bangLuong.Count() != 0);
                RM.RegisterClientScriptBlock("a", "#{Store1}.reload();");
            }
            else
            {
                X.MessageBox.Alert("Cảnh báo", "Bạn chưa chọn bảng lương").Show();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Cảnh báo", ex.Message).Show();
        }
    }

    /// <summary>
    /// Lưu thông tin chấm công vào CSDL
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<BangChamCongThangInfo> bangluong = e.DataHandler.ObjectData<BangChamCongThangInfo>();
        ChamCongThangController chamcong = new ChamCongThangController();
        //khai báo các tham số
        string[] param = new string[34];
        param[0] = "@PR_KEY";
        for (int i = 1; i <= 31; i++)
        {
            if (i <= 9)
                param[i] = "@NGAY0" + i;
            else
                param[i] = "@NGAY" + i;
        }
        param[32] = "@DIEM_THUONG";
        param[33] = "@DIEM_PHAT";
        string MaDonVi = Session["MaDonVi"].ToString();
        foreach (BangChamCongThangInfo update in bangluong.Updated)
        {
            update.NGAY01 = GetEmptyStringFromNullObject(update.NGAY01);
            update.NGAY02 = GetEmptyStringFromNullObject(update.NGAY02);
            update.NGAY03 = GetEmptyStringFromNullObject(update.NGAY03);
            update.NGAY04 = GetEmptyStringFromNullObject(update.NGAY04);
            update.NGAY05 = GetEmptyStringFromNullObject(update.NGAY05);
            update.NGAY06 = GetEmptyStringFromNullObject(update.NGAY06);
            update.NGAY07 = GetEmptyStringFromNullObject(update.NGAY07);
            update.NGAY08 = GetEmptyStringFromNullObject(update.NGAY08);
            update.NGAY09 = GetEmptyStringFromNullObject(update.NGAY09);
            update.NGAY10 = GetEmptyStringFromNullObject(update.NGAY10);

            update.NGAY11 = GetEmptyStringFromNullObject(update.NGAY11);
            update.NGAY12 = GetEmptyStringFromNullObject(update.NGAY12);
            update.NGAY13 = GetEmptyStringFromNullObject(update.NGAY13);
            update.NGAY14 = GetEmptyStringFromNullObject(update.NGAY14);
            update.NGAY15 = GetEmptyStringFromNullObject(update.NGAY15);
            update.NGAY16 = GetEmptyStringFromNullObject(update.NGAY16);
            update.NGAY17 = GetEmptyStringFromNullObject(update.NGAY17);
            update.NGAY18 = GetEmptyStringFromNullObject(update.NGAY18);
            update.NGAY19 = GetEmptyStringFromNullObject(update.NGAY19);
            update.NGAY20 = GetEmptyStringFromNullObject(update.NGAY20);

            update.NGAY21 = GetEmptyStringFromNullObject(update.NGAY21);
            update.NGAY22 = GetEmptyStringFromNullObject(update.NGAY22);
            update.NGAY23 = GetEmptyStringFromNullObject(update.NGAY23);
            update.NGAY24 = GetEmptyStringFromNullObject(update.NGAY24);
            update.NGAY25 = GetEmptyStringFromNullObject(update.NGAY25);
            update.NGAY26 = GetEmptyStringFromNullObject(update.NGAY26);
            update.NGAY27 = GetEmptyStringFromNullObject(update.NGAY27);
            update.NGAY28 = GetEmptyStringFromNullObject(update.NGAY28);
            update.NGAY29 = GetEmptyStringFromNullObject(update.NGAY29);
            update.NGAY30 = GetEmptyStringFromNullObject(update.NGAY30);
            update.NGAY31 = GetEmptyStringFromNullObject(update.NGAY31);

            DataHandler.GetInstance().ExecuteNonQuery("UpdateBangChamCongExcelThang", param, update.PRKEY, update.NGAY01, update.NGAY02, update.NGAY03, update.NGAY04, update.NGAY05, update.NGAY06, update.NGAY07, update.NGAY08, update.NGAY09,
                                                                                          update.NGAY10, update.NGAY11, update.NGAY12, update.NGAY13, update.NGAY14, update.NGAY15, update.NGAY16, update.NGAY17, update.NGAY18, update.NGAY19, update.NGAY20,
                                                                                          update.NGAY21, update.NGAY22, update.NGAY23, update.NGAY24, update.NGAY25, update.NGAY26, update.NGAY27, update.NGAY28, update.NGAY29, update.NGAY30, update.NGAY31, update.DIEMTHUONG, update.DIEMPHAT);

        }

        foreach (BangChamCongThangInfo deleted in bangluong.Deleted)
        {
            DataHandler.GetInstance().ExecuteNonQuery("ChamCong_DeleteEmployee", "@Prkey", deleted.PRKEY);
            if (Store1.UseIdConfirmation)
            {
                e.ConfirmationList.ConfirmRecord(deleted.PRKEY.ToString());
            }
        }
    }
    [DirectMethod]
    public void AfterEdit(decimal prkey, string field, string newValue, string oldValue)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_UpdateBangChamCongThang", "@PRKEY", "@Field", "@Value", prkey, field, newValue);
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    [DirectMethod]
    public void ResetValueTimeSheet()
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_ResetValueBangChamCongThang", "@IDBangChamCong", hdfIdBangChamCong.Text);
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    private string GetEmptyStringFromNullObject(string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            return "";
        }
        return p;
    }

    protected void btnTaoBangChamCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(txtTenBangChamCong.Text) || string.IsNullOrEmpty(ddfDonvi.Text))
            {
                wdTaoBangChamCong.Hide();
                X.MessageBox.Alert("Thông báo", "Tạo bảng chấm công thất bại. Dữ liệu nhập vào không hợp lệ").Show();
                return;
            }
            //Tạo bảng tong hop cong
            DAL.DanhSachBangTongHopCong bangCong = new DanhSachBangTongHopCong()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Title = txtTenBangChamCong.Text,
                KindOfTimeSheetBoard = "VP",
                Lock = false,
                //MaDonVi = Session["MaDonVi"].ToString(),
                MaDonVi = hdfMaDonVi.Text,
                Nam = int.Parse(txtYear.Text),
                Thang = int.Parse(cbMonth.SelectedItem.Value),
                FromDate = DateTime.Now,
                ToDate = DateTime.Now
            };
            int timeSheetID = new DanhSachBangTongHopCongController().Insert(bangCong);
            string selectedDepartment = "";
            //  foreach (var item in ddfDonvi.SelectedItems)
            //   {
            selectedDepartment += hdfMaDonVi.Text + ",";
            // }
            DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TaoBangChamCongThangExcel", "@bangChamCongID", "@donViSuDung", "@createdBy",
                                                        timeSheetID, selectedDepartment, CurrentUser.ID);
            // thêm nhân viên vào trong danh sách bảng tổng hợp công cuối tháng.
            DataHandler.GetInstance().ExecuteNonQuery("ChamCong_TaoBangTongHopCongCuoiThang", "@bangChamCongID", "@donViSuDung",
                                                        timeSheetID, selectedDepartment);
            wdTaoBangChamCong.Hide();
            // ResourceManager1.RegisterClientScriptBlock("reloadpage", "location.reload();grp_danhSachBangChamCongStore.reload();");
        }
        catch (SqlException ex)
        {
            switch (ex.Number)
            {
                case ErrorNumber.DUPLICATE_PRIMARY_KEY:
                    X.MessageBox.Alert("Có lỗi xảy ra", "Bảng chấm công của <b style='color:red;'>" + hdfMaDonVi.Text + "</b> trong <b style='color:red;'>tháng " + cbMonth.SelectedItem.Value + "</b> đã được tạo rồi !").Show();
                    break;
                default:
                    X.MessageBox.Alert("Có lỗi xảy ra", ex.Message + " number = " + ex.Number).Show();
                    break;
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnChamCongTheoKhoangThoiGian_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string congNgayThuong = ""; //Kí hiệu chấm công cho ngày thường
            string congT7 = ""; //kí hiệu công cho thứ 7
            string congCN = ""; //kí hiệu công cho ngày chủ nhật
            //Lấy công ngày thường
            congNgayThuong += cbTinhTrangLamViec.SelectedItems.ValuesToJsonArray().Replace("[","").Replace("]","").Replace("\"","");
            //lấy công ngày thứ 7
            if (chkSaturday.Checked)
            {
                congT7 += MultiComboSaturday.SelectedItems.ValuesToJsonArray().Replace("[", "").Replace("]", "").Replace("\"", "");
            }
            //lấy công ngày chủ nhật
            if (chkSunday.Checked)
            {
                congCN += MultiComboSunday.SelectedItems.ValuesToJsonArray().Replace("[", "").Replace("]", "").Replace("\"", "");
            }
            string sql = "update ChamCong.BangChamCongExcelTheoThang set ";
            int startDay = FromDate.SelectedDate.Day;
            int endDay = ToDate.SelectedDate.Day;
            string cong = string.Empty;
            for (int i = startDay; i <= endDay; i++)
            {
                DateTime date = new DateTime(FromDate.SelectedDate.Year, FromDate.SelectedDate.Month, i);
                if (chkSaturday.Checked && date.DayOfWeek.ToString() == "Saturday") //Nếu chọn thứ 7
                {
                    cong = congT7;
                }
                else if (chkSunday.Checked && date.DayOfWeek.ToString() == "Sunday") //Nếu chọn CN
                {
                    cong = congCN;
                }
                else if (chkSaturday.Checked == false && date.DayOfWeek.ToString() == "Saturday") //Nếu ko chọn thứ 7
                {
                    continue;
                }
                else if (chkSunday.Checked == false && date.DayOfWeek.ToString() == "Sunday")//Nếu ko chọn CN
                {
                    continue;
                }
                else
                {
                    cong = congNgayThuong;
                }
                if (i > 9)
                    sql += " NGAY" + i + " = N'" + cong + "',";
                else
                    sql += " NGAY0" + i + " = N'" + cong + "',";
            }

            sql = sql.Remove(sql.LastIndexOf(",")) + " where PR_KEY = ";

            if (chkApplyforSelectedEmployee.Checked == false)
            {
                List<BangChamCongExcelTheoThang> bangLuong;
                int start = 0;
                int limit = 50;
                do
                {
                    bangLuong = new ChamCongThangController().GetByIdBangChamCong(int.Parse(hdfIdBangChamCong.Text), start, limit);
                    foreach (var item in bangLuong)
                    {
                        DataController.DataHandler.GetInstance().ExecuteNonQuery(sql + item.PR_KEY);
                    }
                    start += limit;
                } while (bangLuong.Count() != 0);
            }
            else
            {
                foreach (var item in RowSelectEvent.SelectedRows)
                {
                    DataController.DataHandler.GetInstance().ExecuteNonQuery(sql + item.RecordID);
                }
            }
            wdChamCongTheoKhoangThoiGian.Hide();
            RM.RegisterClientScriptBlock("a", "#{Store1}.reload();");
        }
        catch (Exception ex)
        {
            ExtNet.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnDongYChamCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string sql = string.Empty;
            if (DateTime.Now.Day < 10)
            {
                sql = "update ChamCong.BangChamCongExcelTheoThang set NGAY0" + DateTime.Now.Day + " = N'" + hdfTinhTrangLamViecHomNay.Text + "' where IdBangChamCong = " + hdfIdBangChamCong.Text;
            }
            else
            {
                sql = "update ChamCong.BangChamCongExcelTheoThang set NGAY" + DateTime.Now.Day + " = N'" + hdfTinhTrangLamViecHomNay.Text + "' where IdBangChamCong = " + hdfIdBangChamCong.Text;
            }
            DataHandler.GetInstance().ExecuteNonQuery(sql);
            RM.RegisterClientScriptBlock("ff", "Store1.reload();");
            wdChamCongHomNay.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    /// <summary>
    /// Gán Editor để chọn tình trạng làm việc
    /// </summary>
    private void SetEditor()
    {
        List<DAL.DM_TT_LAMVIEC> data = new KyHieuChamCongController().GetAll();

        this.Store2.DataSource = data;
        this.Store2.DataBind();

        foreach (var col in GridPanel1.ColumnModel.Columns)
        {
            //   Ext.Net.MultiCombo cbWorkingStatus = new MultiCombo();
            Ext.Net.MultiCombo cbWorkingStatus = new MultiCombo();
            cbWorkingStatus.StoreID = "Store2";
            cbWorkingStatus.Width = 200;
            cbWorkingStatus.ListWidth = 300;
            cbWorkingStatus.ID = "cb" + col.ColumnID;
            cbWorkingStatus.TypeAhead = true;
            cbWorkingStatus.ForceSelection = true;
            cbWorkingStatus.WrapBySquareBrackets = true;
            //   cbWorkingStatus.SelectionMode = MultiSelectMode.Selection;
            cbWorkingStatus.DisplayField = "TEN_TT_LAMVIEC";
            cbWorkingStatus.ValueField = "KYHIEU_TT_LAMVIEC";
            cbWorkingStatus.Editable = false;
            //cbWorkingStatus.Mode = DataLoadMode.Local;
            //cbWorkingStatus.ItemSelector = "tr.list-item";
            Ext.Net.FieldTrigger tg = new FieldTrigger();
            tg.Icon = TriggerIcon.Clear;
            tg.HideTrigger = true;
            cbWorkingStatus.Triggers.Add(tg);
            cbWorkingStatus.Listeners.Select.Handler = "this.triggers[0].show();";
            cbWorkingStatus.Listeners.TriggerClick.Handler = "if (index == 0) { this.clearValue(); this.triggers[0].hide(); }";
//            cbWorkingStatus.Template.Html = @"
//                                            <tpl for=""."">
//						                        <tpl if=""[xindex] == 1"">
//							                        <table class=""cbStates-list"">
//								                        <tr>
//									                        <th>Kí hiệu</th>
//									                        <th>Tình trạng làm việc</th>
//								                        </tr>
//						                        </tpl>
//						                        <tr class=""list-item"">
//							                        <td style=""padding:3px 0px;"">{KYHIEU_TT_LAMVIEC}</td>
//							                        <td>{TEN_TT_LAMVIEC}</td>
//						                        </tr>
//						                        <tpl if=""[xcount-xindex]==0"">
//							                        </table>
//						                        </tpl>
//					                        </tpl>
//                                            ";

            if (col.ColumnID.StartsWith("Ngay"))
            {
                col.Editor.Add(cbWorkingStatus);
                if (col.ColumnID.Equals("NgayHomNay"))
                {
                    if (DateTime.Today.Day < 10)
                        col.DataIndex = "NGAY0" + DateTime.Today.Day;
                    else
                        col.DataIndex = "NGAY" + DateTime.Today.Day;
                }
            }
        }
    }

    protected void btnLoadTimeSheetBoard_Click(object sender, DirectEventArgs e)
    {
        idBangChamCong = rslChooseTimeSheet.SelectedRecordID;
        Response.Redirect("ChamCongTheoThang.aspx?mid=" + MenuID + "&blID=" + idBangChamCong);
        //FindDayOfWeek();
        //wdChonBangChamCong.Hide();  
    }

    protected void btnDongYChuyenNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string recordID = ",";
            foreach (var item in RowSelectEvent.SelectedRows)
            {
                recordID += item.RecordID + ",";
            }
            DataHandler.GetInstance().ExecuteNonQuery("ChamCong_ChuyenNhanVienSangBangKhac", "@PrKey", "@IdBangChamCong", recordID, rslChooseTimeSheet.SelectedRecordID);
            GridPanel1.Reload();
            wdChonBangChamCong.Hide();
            Dialog.ShowNotification("Đã chuyển nhân viên thành công !");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    string[] dsDv;
    int countRole = -1;
    protected void cbx_bophan_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        dsDv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
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

    /// <summary>
    /// Thiết lập giá trị cho các control trên form wdChamCongTheoKhoangThoiGian
    /// </summary>
    /// <param name="bangChamCong"></param>
    private void setDateForwdChamCongTheoKhoangThoiGian(DAL.DanhSachBangTongHopCong bangChamCong)
    {
        int totalDayDayInMonth = DateTime.DaysInMonth(bangChamCong.Nam, bangChamCong.Thang);
        DateTime startDate = new DateTime(bangChamCong.Nam, bangChamCong.Thang, 1);
        DateTime endDate = new DateTime(bangChamCong.Nam, bangChamCong.Thang, totalDayDayInMonth);
        FromDate.SelectedDate = startDate;
        FromDate.MinDate = startDate;
        FromDate.MaxDate = endDate;
        ToDate.MaxDate = endDate;
        ToDate.SelectedDate = endDate;
    }

    /// <summary>
    /// Tìm thứ trong tuần và tô màu ngày cuối tuần
    /// </summary> 
    private void FindDayOfWeek()
    {
        try
        {
            if (string.IsNullOrEmpty(hdfIdBangChamCong.Text))
            {
                return;
            }
            DAL.DanhSachBangTongHopCong bangChamCong = new DanhSachBangTongHopCongController().GetById(int.Parse(hdfIdBangChamCong.Text));
            setDateForwdChamCongTheoKhoangThoiGian(bangChamCong);
            DateTime date = new DateTime(bangChamCong.Nam, bangChamCong.Thang, 1);
            GridPanel1.Title = bangChamCong.Title + " (Bảng công tháng " + bangChamCong.Thang + "/" + bangChamCong.Nam + ")";
            int totalDay = DateTime.DaysInMonth(bangChamCong.Nam, bangChamCong.Thang);//tổng số ngày trong tháng 

            dictionaryDay = new Dictionary<string, int>();
            int day = 0;
            foreach (var col in GridPanel1.ColumnModel.Columns)
            {
                if (col.ColumnID.StartsWith("Ngay"))
                {
                    string DayOfWeek = "";
                    switch (date.DayOfWeek.ToString())
                    {
                        case "Monday":
                            DayOfWeek = " Thứ 2";
                            day = 0;
                            break;
                        case "Tuesday":
                            DayOfWeek = " Thứ 3";
                            day = 1;
                            break;
                        case "Wednesday":
                            DayOfWeek = " Thứ 4";
                            day = 2;
                            break;
                        case "Thursday":
                            DayOfWeek = " Thứ 5";
                            day = 3;
                            break;
                        case "Friday":
                            DayOfWeek = " Thứ 6";
                            day = 4;
                            break;
                        case "Saturday":
                            DayOfWeek = " Thứ 7";
                            day = 5;
                            break;
                        case "Sunday":
                            DayOfWeek = " Chủ nhật";
                            day = 6;
                            break;
                    }
                    if (col.ColumnID != "NgayHomNay")
                    {
                        dictionaryDay.Add(col.DataIndex, day);
                        if (int.Parse(col.ColumnID.Replace("Ngay", "")) > totalDay)
                        {
                            col.Hidden = true;
                            continue;
                        }
                        if (DayOfWeek.Contains("Chủ nhật"))
                        {
                            col.Css = "background:#D3D3D3;";
                        }
                        if (bangChamCong.Nam == DateTime.Now.Year && bangChamCong.Thang == DateTime.Now.Month && int.Parse(col.ColumnID.Replace("Ngay", "").ToString()) == DateTime.Now.Day)
                        {
                            col.Css = "background:#87ceeb;";
                        }
                        date = date.AddDays(1);
                        col.Header += DayOfWeek;
                    }
                    else
                    {
                        if (bangChamCong.Thang != DateTime.Today.Month)
                        {
                            col.Hidden = true;
                            mnuToday.Visible = false;
                            mnuChamCongHomNay.Visible = false;
                        }
                        else
                        {
                            mnuChamCongHomNay.Visible = true;
                        }
                        col.Header += " " + SoftCore.Util.GetInstance().GetTodayName();
                    }
                    //col.Header += DayOfWeek;
                }
            }
            ////set weekend style + today style
            //if (bangChamCong.Thang != DateTime.Now.Month)
            //    styleWeekend += "{background-color:#e3e6eb;}.x-grid3-td-Ngay";
            //else
            //    styleWeekend += "{background-color:#e3e6eb;}.x-grid3-td-Ngay" + DateTime.Today.Day + "{background-color:#ff6600}";
            //ltrweekendStyle.Text = "<style type='text/css'>" + styleWeekend + "</style>";
            //   ltrweekendStyle.Text = "*{font-size:15px !important;}";
            //GridPanel1.Reload();
            //GridPanel1.Reconfigure();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("SetColorWeekend = " + ex.Message);
        }
    }
    /// <summary>
    /// Xóa bảng chấm công
    /// @Lê Anh
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBangChamCongDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DanhSachBangTongHopCongController controller = new DanhSachBangTongHopCongController();
            foreach (var item in RowSelectionModelBangLuongChamCong.SelectedRows)
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_DeleteChamCongExcelUpdateNghiPhep_TongHopCongCuoiThang", "@bangCongID", item.RecordID);
                controller.Delete(int.Parse("0" + item.RecordID));
            }
            hdfRecordID.Text = "";
            grpDanhSachBangChamCong.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Cập nhật tiêu đề bảng chấm công
    /// </summary>
    /// <param name="titleOfTimeSheetBoard"></param>
    [DirectMethod]
    public void UpdateTimeSheetBoard(string titleOfTimeSheetBoard)
    {
        try
        {
            string sql = "update ChamCong.DanhSachBangTongHopCong set Title = N'{0}' where ID = " + hdfRecordID.Text;
            DataHandler.GetInstance().ExecuteNonQuery(string.Format(sql, titleOfTimeSheetBoard));
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}