using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
using Controller.ThoiViec;
using DAL;
using System.IO;
using SoftCore;
using System.Data;


public partial class Modules_TienLuong_BangTamUng : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {

            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            dfNgayTamUng.MaxDate = DateTime.Now;
            grpBangTamUng.GetGridPanel().Listeners.RowContextMenu.Handler = "e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());grpBangTamUng_GridPanel1.getSelectionModel().selectRow(rowIndex);";
        }
        grpBangTamUng.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaClick);
        //   grpBangTamUng.GetAddButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnThemClick);
        grpBangTamUng.GetAddButton().Hide();
        grpBangTamUng.GetToolBar().Items.Insert(0, btnUserAdd);
        grpBangTamUng.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnSuaClick);
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
        grpBangTamUng.AddControlToSouth(pnlPaymentHistory, false);

        grpBangTamUng.GetRowSelectionModel().Listeners.RowSelect.Handler += "grpBangTamUng_btnEdit.enable();grpBangTamUng_btnDelete.enable();grpBangTamUng_btnAddPayment.enable();hdfRecordID.setValue(grpBangTamUng_RowSelectionModel1.getSelected().id);grpBangTamUng_storePaymentHistory.reload();";//hdfCurrentRecordID.setValue(grpBangTamUng_RowSelectionModel1.getSelected().data.PR_KEY);
        btnAddPayment.Listeners.Click.Handler = "wdPaymentHistory.show();btnAddAndCloseHistory.show();btnUpdateHistory.hide();btnAddHistory.show();";
        btnEditPayment.Listeners.Click.Handler = "wdPaymentHistory.show();btnUpdateHistory.show();btnAddHistory.hide();btnAddAndCloseHistory.hide()";
        grpPaymentHistory.Listeners.RowDblClick.Handler = "wdPaymentHistory.show();btnUpdateHistory.show();btnAddHistory.hide();btnAddAndCloseHistory.hide()";
        grpPaymentHistory.DirectEvents.RowDblClick.EventMask.ShowMask = true;
        btnEditPayment.DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
        btnEditPayment.DirectEvents.Click.EventMask.ShowMask = true;
        grpPaymentHistory.DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(Click_Event);
        grpPaymentHistory.DirectEvents.RowDblClick.EventMask.ShowMask = true;
    }

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            hdfSelectedEmployee.Text = ucChooseEmployee1.SelectedRow.Count.ToString();
            foreach (var item in ucChooseEmployee1.SelectedRow)
            {
                // get employee information
                HOSO hs = new HoSoController().GetByMaCB(item.RecordID);
                string pr_keyhoso = hs.PR_KEY.ToString();
                string ma_cb = hs.MA_CB;
                string ho_ten = hs.HO_TEN;
                string ten_donvi = new DM_DONVIController().GetNameById(hs.MA_DONVI);
                // insert record to grid
                grpBangTamUng.GetResourceManager().RegisterClientScriptBlock("insert" + pr_keyhoso, string.Format("addRecord('{0}', '{1}', '{2}', '{3}', '', '', '', '', '');", pr_keyhoso, ma_cb, ho_ten, ten_donvi));
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }
    void Click_Event(object sender, Ext.Net.DirectEventArgs e)
    {

        try
        {
            DAL.BangTamUngHistory item = new BangTamUngHistoryController().GetByPrKey(int.Parse("0" + hdfBangTamUngHistoryID.Text));

            if (item != null)
            {
                txaDescription.Text = item.Description;
                dfPaidDate.Text = item.NgayTra.ToString();
                cbPaymentType.Text = item.LoaiThanhToan.ToString();
                nbfChietKhau.Text = item.FB.ToString();
                nbfPaid.Text = item.SoTienThanhToan.ToString();
            }
            wdPaymentHistory.Show();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }

    }
    public void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        try
        {
            string error = string.Empty;
            ChangeRecords<BangTamUngInfo> tamUngs = e.DataHandler.ObjectData<BangTamUngInfo>();

            foreach (BangTamUngInfo created in tamUngs.Created)
            {
                try
                {
                    // create BangTamUng object
                    BangTamUng tamUng = new BangTamUng();
                    tamUng.PrKeyHoSo = created.PrkeyHoSo;
                    tamUng.SoTien = created.SoTien;
                    tamUng.SoTienDaTra = created.SoTienDaTra;
                    tamUng.LyDoTamUng = created.LyDoTamUng;
                    if (created.NgayTamUng != null)
                        tamUng.NgayTamUng = created.NgayTamUng.Value;
                    if (created.NgayThanhToan != null)
                        tamUng.ThoiHanThanhToan = created.NgayThanhToan.Value;
                    tamUng.CreatedBy = CurrentUser.ID;
                    tamUng.CreatedDate = DateTime.Now;
                    tamUng.NgayThanhToan = null;

                    // insert data to database
                    new BangTamUngController().Insert(tamUng);
                }
                catch (Exception ex)
                {
                    error += ex.Message + "\n";
                }
            }
            // show error if valid
            if (!string.IsNullOrEmpty(error))
            {
                X.Msg.Alert("Có lỗi xảy ra", error).Show();
            }
            else
            {
                Dialog.ShowNotification("Thêm cán bộ tạm ứng thành công!");
                wdCapNhatTamUngHangLoat.Hide();
            }
            grpBangTamUng.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    public void CheckDaThoiViec(object sender, DirectEventArgs e)
    {
        try
        {
            if (cbonhanvien.SelectedItem == null)
            {
                X.MessageBox.Alert("Thông báo", "Không tìm thấy cán bộ");
                return;
            }
            decimal prkeyHoSo = decimal.Parse(cbonhanvien.SelectedItem.Value);
            DAL.DanhSachCanBoThoiViec tv = new DanhSachCanBoThoiViecController().GetByPrkeyHoSo(prkeyHoSo);
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
            X.MessageBox.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message);
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
        // close window
        wdAddWindow.Hide();
    }
    #region các hàm dùng chung
    /// <summary>
    /// upload file from computer to server
    /// </summary>
    /// <param name="sender">ID of FileUploadField</param>
    /// <param name="directory">directory of folder HoSoNhanSu</param>
    /// <param name="relativePath">the relative path to place you want to save file</param>
    /// <returns>The path of file after upload to server</returns>
    public string UploadFile(object sender, string relativePath)
    {
        FileUploadField obj = (FileUploadField)sender;
        HttpPostedFile file = obj.PostedFile;
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath(relativePath));  // save file to directory HoSoNhanSu/File
        // if directory not exist then create this
        if (dir.Exists == false)
            dir.Create();
        string rdstr = SoftCore.Util.GetInstance().GetRandomString(7);
        string path = Server.MapPath(relativePath) + "/" + rdstr + "_" + obj.FileName;
        if (File.Exists(path))
            return "";
        FileInfo info = new FileInfo(path);
        file.SaveAs(path);
        return relativePath + "/" + rdstr + "_" + obj.FileName;
    }

    /// <summary>
    /// Return attach file to client when user click download button
    /// </summary>
    /// <param name="TableName">Name of table</param>
    /// <param name="Prkey">Prkey of employee</param>
    public void DownloadAttachFile(string TableName, Hidden sender)
    {
        try
        {
            if (string.IsNullOrEmpty(sender.Text))
            {
                Dialog.ShowNotification("Không có tệp tin đính kèm");
                return;
            }
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            Response.Clear();
            //  Response.ContentType = "application/octet-stream";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + sender.Text.Replace(" ", "_"));
            Response.WriteFile(serverPath);
            Response.End();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }

    public void DeleteTepTinDinhKem(string tableName, int id, Hidden sender)
    {
        try
        {
            // xóa trong csdl
            DataController.DataHandler.GetInstance().ExecuteNonQuery(string.Format("update {0} set {1} = N'' where PR_KEY = {2}", tableName, "TepTinDinhKem", id));
            // xóa file trong thư mục
            string serverPath = Server.MapPath(sender.Text);
            if (Util.GetInstance().FileIsExists(serverPath) == false)
            {
                Dialog.ShowNotification("Tệp tin không tồn tại hoặc đã bị xóa !");
                return;
            }
            File.Delete(serverPath);
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.Alert("Có lỗi xảy ra: " + ex.Message);
        }
    }
    #endregion
    protected void btnSuaClick(object sender, DirectEventArgs e)
    {
        try
        {
            if (grpBangTamUng.GetSelectedRecordIDs().Count > 1)
            {
                X.Msg.Alert("Thông báo", "Bạn chỉ được chọn 1 dòng").Show();
                return;
            }
            wdAddWindow.Icon = Icon.Pencil;
            wdAddWindow.Title = "Sửa thông tin tạm ứng";
            hdfRecordID.Text = grpBangTamUng.GetSelectedRecordIDs().FirstOrDefault();
            DAL.BangTamUng tamung = new BangTamUngController().GetByPrKey(int.Parse(hdfRecordID.Text));
            cbonhanvien.Text = new HoSoController().TraVeTenByPRKEY(tamung.PrKeyHoSo);
            dfNgayTamUng.SelectedDate = tamung.NgayTamUng;
            //dfThoiHanTamUng.SelectedDate = tamung.ThoiHanThanhToan;
            txtLyDoTamUng.Text = tamung.LyDoTamUng;
            txtSoTien.Text = tamung.SoTien.ToString();
            //txtSoTienDaTra.Text = tamung.SoTienDaTra.ToString();

            cbonhanvien.Disabled = true;
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
            DAL.BangTamUng tamung = new DAL.BangTamUng()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                //SoTienDaTra = decimal.Parse("0" + txtSoTienDaTra.Text),
                LyDoTamUng = txtLyDoTamUng.Text,
                NgayTamUng = dfNgayTamUng.SelectedDate,
                PrKeyHoSo = decimal.Parse(cbonhanvien.SelectedItem.Value),
                SoTien = decimal.Parse("0" + txtSoTien.Text),
                SoTienVietBangChu = "",
                ThoiHanThanhToan = DateTime.Now
            };
            new BangTamUngController().Insert(tamung);
            Dialog.ShowNotification("Thông báo", "Đã lưu thành công thông tin tạm ứng: ");
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
            }
            else
            {
                grpBangTamUng.GetResourceManager().RegisterClientScriptBlock("r1", "resetForm();");
            }
            grpBangTamUng.GetGridPanel().Reload();
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
            DAL.BangTamUng tamung = new BangTamUngController().GetByPrKey(int.Parse(grpBangTamUng.GetSelectedRecordIDs().FirstOrDefault().ToString()));
            //tamung.SoTienDaTra = decimal.Parse("0" + txtSoTienDaTra.Text);
            tamung.LyDoTamUng = txtLyDoTamUng.Text;
            tamung.NgayTamUng = dfNgayTamUng.SelectedDate;
            tamung.SoTien = decimal.Parse("0" + txtSoTien.Text);
            tamung.SoTienVietBangChu = "";
            //tamung.ThoiHanThanhToan = dfThoiHanTamUng.SelectedDate;
            new BangTamUngController().Update(tamung);
            Dialog.ShowNotification("Thông báo", "Đã cập nhật thành công");
            grpBangTamUng.GetGridPanel().Reload();
            wdAddWindow.Hide();
            grpBangTamUng.GetResourceManager().RegisterClientScriptBlock("rabc", "resetForm();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnDeleteTamUng_Click(object sender, DirectEventArgs e)
    {
        try
        {
            new BangTamUngController().Delete(int.Parse(grpBangTamUng.GetSelectedRecordIDs().FirstOrDefault()));
            grpBangTamUng.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnUpdateHistory_Click(object sender, DirectEventArgs e)
    {
        int bangTamUngID = int.Parse("0" + hdfRecordID.Text);
        decimal checktongHistory = 0;
        decimal checktong = 0;
        DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("select sum(SoTienThanhToan)as 'tong'  from BangTamUngHistory where BangTamUngID=" + hdfRecordID.Text);
        for (int i = 0; i < data.Rows.Count; i++)
        {
            checktongHistory = int.Parse("0" + data.Rows[i]["tong"].ToString());
        }
        DataTable data1 = DataController.DataHandler.GetInstance().ExecuteDataTable("select sotien from TienLuong.BangTamUng where BangTamUng.PR_KEY=" + hdfRecordID.Text);
        for (int i = 0; i < data1.Rows.Count; i++)
        {
            checktong = int.Parse("0" + data1.Rows[i]["sotien"].ToString());
        }
        DAL.BangTamUngHistory item = new DAL.BangTamUngHistory()
        {
            NgayTra = dfPaidDate.SelectedDate,
            LoaiThanhToan = cbPaymentType.SelectedItem.Value,
            Description = txaDescription.Text,
            BangTamUngID = bangTamUngID,
            SoTienThanhToan = decimal.Parse(nbfPaid.Text),
            FB = decimal.Parse("0" + nbfChietKhau.Text),
            CreatedBy = CurrentUser.ID,
            CreatedDate = DateTime.Now
        };

        if (e.ExtraParams["Command"] == "UpdateHistory")
        {
            if (checktong >= (checktongHistory + item.SoTienThanhToan))
            {
                item.ID = int.Parse("0" + hdfBangTamUngHistoryID.Text);

                new BangTamUngHistoryController().Update(item);
                Dialog.ShowNotification("Cập nhật thành công");
                grpPaymentHistory.Reload();
                grpBangTamUng.GetGridPanel().Reload();
                wdPaymentHistory.Hide();
            }
            else
            {
                Dialog.ShowError("Số tiền trả lớn hơn tổng tiền");
            }

        }
        else
        {
            if (checktong >= (checktongHistory + item.SoTienThanhToan))
            {

                new BangTamUngHistoryController().Insert(item);
                grpPaymentHistory.Reload();
                grpBangTamUng.GetGridPanel().Reload();
                Dialog.ShowNotification("Thêm thành công");
                X.Js.Call("resetFormHistory", "resetFormHistory();");
            }
            else
            {
                Dialog.ShowError("Số tiền trả lớn hơn tổng tiền");
            }
        }
        grpPaymentHistory.Reload();
        if (e.ExtraParams["CloseHistory"] == "True")
        {
            wdPaymentHistory.Hide();
        }

    }
    protected void storePaymentHistory_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {

            storePaymentHistory.DataSource = DataController.DataHandler.GetInstance().ExecuteDataTable("GetBangTamUngHistory",
                                                                                                   "@BangTamUngID", int.Parse(hdfRecordID.Text));
            storePaymentHistory.DataBind();

        }

        catch (Exception ex)
        {

            Dialog.ShowError(ex.Message);
        }
    }
    protected void btnDeletePayment_Click(object sender, DirectEventArgs e)
    {
        int recordid = int.Parse("0" + grpBangTamUng.GetSelectedRecordIDs().FirstOrDefault());
        try
        {
            foreach (var item in rsm.SelectedRows)
            {

                new BangTamUngHistoryController().Delete(int.Parse("0" + item.RecordID));

            }
            //  DataController.DataHandler.GetInstance().ExecuteNonQuery("store_UpdateAmountPaymentAndFB", "@LiabilitiesOfCustomerID", liabilitiesOfCustomerID);
            grpBangTamUng.GetGridPanel().Reload();
            grpPaymentHistory.Reload();
            btnDeletePayment.Disabled = true;
            btnEditPayment.Disabled = true;
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}