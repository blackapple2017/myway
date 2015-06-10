using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using Controller.DanhGia;
using System.Globalization;
using System.IO;
using LinqToExcel;
using System.Xml;
using System.Xml.Xsl;
using SoftCore;

/// <summary>
/// daibx
/// Created Date: 01/07/2013
/// Updated Date: 21/05/2014
/// </summary>
public partial class Modules_DanhGia_TieuChiDanhGia : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();

            //grp_NhomTC_Store.DataSource = new TieuChiDanhGiaController().GetByParentID("-1", Session["MaDonVi"].ToString());
            //grp_NhomTC_Store.DataBind();
            //LoadNhomTieuChi();
            grp_NhomTC.Reload();
        }
    }

    #region Đọc từ Excel
    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = FileUploadField1.PostedFile;

            if (file.ContentType != "application/vnd.ms-excel") //ko phải Excel 2003
            {
                Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("NotExcel2003"));
                return;
            }
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
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("../FilesUpload"));
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath("../FilesUpload/") + FileUploadField1.FileName;
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
            if (new FileInfo(Server.MapPath("../FilesUpload/") + FileUploadField1.FileName).Exists)
            {
                List<object> sheetData = new List<object>();
                IEnumerable<string> sheetname = ExcelEngine.GetInstance().GetAllSheetName(Server.MapPath("../FilesUpload/") + FileUploadField1.FileName);
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

    protected void grp_NhomTC_Store_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString();
        grp_NhomTC_Store.DataSource = new TieuChiDanhGiaController().GetByParentID("-1", maDv);
        grp_NhomTC_Store.DataBind();
    }

    protected void cbxChuyenTiepNhomTC_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        cbxChuyenTiepNhomTC_Store.DataSource = new TieuChiDanhGiaController().GetByParentID("-1", maDv);
        cbxChuyenTiepNhomTC_Store.DataBind();
    }

    protected void DownloadBangChamCongMau(object sender, DirectEventArgs e)
    {
        try
        {
            string fileName = Server.MapPath("../FileMau/Mau_Bo_Tieu_Chi_Danh_Gia.xls");
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

    private bool checkNumber(char c)
    {
        if (c >= '0' && c <= '9')
            return true;
        return false;
    }

    private void getConfig(out string startCell, out string endCell)
    {
        // get Config
        string file = Server.MapPath("config_dg.txt");
        string[] lines = System.IO.File.ReadAllLines(file);
        int pos = lines[0].IndexOf(' ');
        startCell = lines[0].Substring(0, pos).Trim();
        endCell = lines[0].Substring(pos + 1).Trim();
        int maxLines = int.Parse(lines[1] == "" ? "1000" : lines[1]);

        // get end cell
        pos = 0;
        for (int i = 0; i < endCell.Length; i++)
        {
            if (checkNumber(endCell[i]))
            {
                pos = i;
                break;
            }
        }
        string text = endCell.Substring(0, pos);
        int number = int.Parse(endCell.Substring(pos)) + maxLines;
        endCell = text + number;
    }

    protected void ImportDataFromExcel(object sender, DirectEventArgs e)
    {
        try
        {
            string extension = System.IO.Path.GetExtension(FileUploadField1.PostedFile.FileName).ToLower();

            if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
            {
                X.Msg.Alert("Thông báo", "Hãy chọn file excel").Show();
                return;
            }
            string fn = System.IO.Path.GetFileName(FileUploadField1.PostedFile.FileName);
            string saveLocation = Server.MapPath("../FilesUpload") + "\\" + fn;

            var excel = new ExcelQueryFactory();
            excel.FileName = saveLocation;

            // get config
            string startCell = "";
            string endCell = "";
            getConfig(out startCell, out endCell);

            var datas = from x in excel.WorksheetRangeNoHeader(startCell, endCell, cbSheetName.Value.ToString())
                        select x;
            int thanhCong = 0, daTonTai = 0;
            foreach (var item in datas)
            {
                if (item[0] == "")
                    break;

                TieuChiDanhGiaInfo tc = new TieuChiDanhGiaInfo();
                tc.MaNhom = item[0].ToString();
                tc.TenNhom = item[1].ToString();
                if (item[2] != null && item[2] != "")
                    tc.HeSo = decimal.Parse(item[2].ToString());
                else
                    tc.HeSo = 1;
                tc.GhiChu = item[3].ToString();
                tc.CreatedDate = DateTime.Now;
                tc.CreatedBy = CurrentUser.ID;
                if (cbxChonNhomTC.SelectedItem.Value != null)
                    tc.ParentID = cbxChonNhomTC.SelectedItem.Value.ToString();
                else
                    tc.ParentID = "";
                tc.MaDonVi = Session["MaDonVi"].ToString();

                DataTable tmp = new TieuChiDanhGiaController().GetByPrkey(item[0].ToString());
                if (tmp.Rows.Count > 0)
                {
                    new TieuChiDanhGiaController().Update(tc);
                    daTonTai++;
                }
                else
                {
                    if (tc.ParentID != "")
                    {
                        new TieuChiDanhGiaController().Insert(tc);
                        thanhCong++;
                    }
                }
            }
            Dialog.ShowNotification(string.Format("Đã thêm mới thành công {0} tiêu chí.\n Cập nhật thành công {1} tiêu chí!", thanhCong, daTonTai));
            wdNhapTuExcel.Hide();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }
    #endregion

    #region Load tree

    //private void LoadNhomTieuChi()
    //{
    //    Ext.Net.TreeNode root = new Ext.Net.TreeNode();

    //    // tao node goc
    //    Ext.Net.TreeNode node = new Ext.Net.TreeNode("Các nhóm tiêu chí đánh giá");
    //    node.Icon = Ext.Net.Icon.House;
    //    root.Nodes.Add(node);
    //    node.Expanded = true;
    //    node.NodeID = "-1";
    //    node.Listeners.Click.Handler = @"#{hdfMaNhom}.setValue('-1');PagingToolbar1.pageIndex=0;PagingToolbar1.doLoad();#{Store1}.reload();";
    //    LoadNhomTieuChiCon(node);

    //    TreeDMTieuChiDanhGia.Root.Clear();
    //    TreeDMTieuChiDanhGia.Root.Add(root);
    //}

    //private void LoadNhomTieuChiCon(Ext.Net.TreeNode parentNode)
    //{
    //    var data = new TieuChiDanhGiaController().GetByParentID(parentNode.NodeID, Session["MaDonVi"].ToString());
    //    foreach (DataRow item in data.Rows)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(item["TenNhom"].ToString());
    //        node.Icon = Ext.Net.Icon.Folder;
    //        node.Expanded = true;
    //        node.NodeID = item["MaNhom"].ToString();
    //        node.Listeners.Click.Handler = "#{hdfMaNhom}.setValue('" + node.NodeID + "'); PagingToolbar1.pageIndex=0; PagingToolbar1.doLoad(); #{Store1}.reload();";
    //        parentNode.Nodes.Add(node);

    //        //LoadNhomTieuChiCon(node);
    //    }
    //}

    #endregion

    protected void btnChuyenTiep_Click(object sender, DirectEventArgs e)
    {
        RowSelectionModel sm = GridPanel1.SelectionModel.Primary as RowSelectionModel;

        foreach (var item in sm.SelectedRows)
        {
            DataTable table = new TieuChiDanhGiaController().GetByPrkey(item.RecordID);

            if (table.Rows.Count > 0)
            {
                TieuChiDanhGiaInfo tc = new TieuChiDanhGiaInfo();
                tc.MaNhom = table.Rows[0]["MaNhom"].ToString();
                tc.TenNhom = table.Rows[0]["TenNhom"].ToString();
                tc.HeSo = decimal.Parse(table.Rows[0]["HeSo"].ToString());
                tc.MaDonVi = table.Rows[0]["MaDonVi"].ToString();
                tc.ParentID = cbxChuyenTiepNhomTC.SelectedItem.Value;
                tc.GhiChu = table.Rows[0]["GhiChu"].ToString();
                tc.CreatedDate = DateTime.Parse(table.Rows[0]["CreatedDate"].ToString());
                tc.CreatedBy = int.Parse(table.Rows[0]["CreatedBy"].ToString());

                new TieuChiDanhGiaController().Update(tc);
            }
        }
        GridPanel1.Reload();
        wdChuyenTiep.Hide();
    }

    protected void Store1_Submit(object sender, StoreSubmitDataEventArgs e)
    {
        try
        {
            var json = FormatType.Value.ToString();
            var eSubmit = new StoreSubmitDataEventArgs(json, null);
            var xml = eSubmit.Xml;

            if (xml.InnerText == "")
            {
                X.Msg.Alert("Thông báo", "Không có dữ liệu để xuất ra file Excel").Show();
                return;
            }
            Response.Clear();

            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=Export_Tieu_Chi_Danh_Gia.xls");
            var xtExcel = new System.Xml.Xsl.XslCompiledTransform();
            xtExcel.Load(Server.MapPath("../Export/Excel.xsl"));

            xtExcel.Transform(xml, null, Response.OutputStream);
            Response.End();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString()).Show();
        }
    }

    protected void cbxTieuChiCha_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        DataTable table = new TieuChiDanhGiaController().GetByParentID("-1", maDv);
        List<object> obj = new List<object>();
        //obj.Add(new { MaNhom = "-1", TenNhom = "Là nhóm tiêu chí"});

        foreach (DataRow item in table.Rows)
        {
            obj.Add(new { MaNhom = item["MaNhom"].ToString(), TenNhom = item["TenNhom"].ToString() });
        }
        cbxTieuChiCha_Store.DataSource = obj;
        cbxTieuChiCha_Store.DataBind();
    }

    protected void cbxCriterionGroupStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        cbxCriterionGroupStore.DataSource = new TieuChiDanhGiaController().GetByParentID("-1", maDv);
        cbxCriterionGroupStore.DataBind();
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {
        TieuChiDanhGiaInfo obj = new TieuChiDanhGiaInfo();
        TieuChiDanhGiaController ctr = new TieuChiDanhGiaController();
        obj.MaNhom = txtMaNhom.Text;
        obj.TenNhom = txtTenNhom.Text;
        if (!string.IsNullOrEmpty(txtHeSo.Text))
        {
            obj.HeSo = decimal.Parse("0" + txtHeSo.Text.Replace('.', ','));
        }
        obj.GhiChu = txtGhiChu.Text;
        obj.CreatedDate = DateTime.Now;
        obj.CreatedBy = CurrentUser.ID;
        obj.MaDonVi = Session["MaDonVi"].ToString();

        if (cbxTieuChiCha.Value != null)
            obj.ParentID = cbxTieuChiCha.Value.ToString();
        else
            obj.ParentID = "-1";

        if (e.ExtraParams["Command"] == "Edit")
        {
            obj.MaNhom = hdfRecordID.Text;
            ctr.Update(obj);
            wdAddWindow.Hide();
            GridPanel1.Reload();
        }
        else
        {
            DataTable tmp = new TieuChiDanhGiaController().GetByPrkey(obj.MaNhom);
            if (tmp.Rows.Count == 0)
            {
                ctr.Insert(obj);
                GridPanel1.Reload();
            }
            else
                X.Msg.Alert("Thông báo", "Mã tiêu chí đã tồn tại").Show();
            if (e.ExtraParams["Close"] == "True")
            {
                wdAddWindow.Hide();
                cbxTieuChiCha.Reset();
            }
        }
        grp_NhomTC.Reload();
    }

    protected void btnUpdateCriterion_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.TieuChiDanhGia tieuChi = new DAL.TieuChiDanhGia();
            TieuChiDanhGiaController controller = new TieuChiDanhGiaController();
            if (e.ExtraParams["Edit"] == "True")
            {
                tieuChi = controller.GetById(hdfRecordID.Text);
            }
            if (!string.IsNullOrEmpty(txtCriterionWeight.Text))
                tieuChi.HeSo = decimal.Parse(txtCriterionWeight.Text.Replace('.', ','));
            else
                tieuChi.HeSo = 1;
            tieuChi.TenNhom = txtCriterionName.Text;
            tieuChi.ParentID = cbxCriterionGroup.SelectedItem.Value;
            tieuChi.GhiChu = txtNote.Text;
            tieuChi.MaDonVi = Session["MaDonVi"].ToString();

            if (e.ExtraParams["Edit"] == "True")
            {
                tieuChi.MaNhom = hdfRecordID.Text;
                hdfTypeCommand.Text = "Edit";
                hdfClose.Text = "True";
                // update criterion
                controller.Update(tieuChi);
                hdfInsertedID.Text = tieuChi.MaNhom;
                if (hdfIsEdit.Text != "True")
                {
                    Dialog.ShowNotification("Cập nhật thông tin tiêu chí đánh giá thành công");
                    wdAddNewEstimateCriterion.Hide();
                }
            }
            else
            {
                tieuChi.MaNhom = txtCriterionCode.Text;
                hdfTypeCommand.Text = "Insert";
                // insert criterion
                tieuChi.CreatedBy = CurrentUser.ID;
                tieuChi.CreatedDate = DateTime.Now;
                controller.Insert(tieuChi);
                hdfInsertedID.Text = tieuChi.MaNhom;
                if (hdfIsEdit.Text != "True")
                {
                    Dialog.ShowNotification("Thêm mới thành công tiêu chí đánh giá");
                }
                if (e.ExtraParams["Close"] == "True")
                {
                    hdfClose.Text = "True";
                    if (hdfIsEdit.Text != "True")
                        wdAddNewEstimateCriterion.Hide();
                }
                else
                {
                    hdfClose.Text = "False";
                }
            }
            RM.RegisterClientScriptBlock("save", "grpTestList.save();");
            if (hdfIsEdit.Text != "True")
            {
                if (hdfClose.Text != "True")
                    RM.RegisterClientScriptBlock("rsform1", "ResetCriterionWindow();");
                GridPanel1.Reload();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.ToLower().Contains("duplicate"))
                Dialog.ShowError("Mã tiêu chí đánh giá đã bị trùng. Vui lòng nhập mã khác.");
            else
                Dialog.ShowError(ex.Message);
        }
    }

    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        try
        {
            TracNghiemController tracNghiemController = new TracNghiemController();
            ChangeRecords<TracNghiemInfo> tracNghiems = e.DataHandler.ObjectData<TracNghiemInfo>();

            // insert
            foreach (TracNghiemInfo created in tracNghiems.Created)
            {
                try
                {
                    DAL.TracNghiem info = new DAL.TracNghiem();
                    info.CriterionID = hdfInsertedID.Text;
                    info.ExplainName = created.ExplainName;
                    info.MaxPoint = created.MaxPoint;
                    info.MinPoint = created.MinPoint;
                    info.Order = created.Order;
                    tracNghiemController.Insert(info);
                }
                catch (Exception ex)
                {

                }
            }

            // update
            foreach (TracNghiemInfo updated in tracNghiems.Updated)
            {
                try
                {
                    DAL.TracNghiem info = new DAL.TracNghiem();
                    info.CriterionID = hdfInsertedID.Text;
                    info.ExplainName = updated.ExplainName;
                    info.MaxPoint = updated.MaxPoint;
                    info.MinPoint = updated.MinPoint;
                    info.Order = updated.Order;
                    tracNghiemController.Update(info);
                }
                catch (Exception ex)
                {

                }
            }

            // delete
            foreach (TracNghiemInfo deleted in tracNghiems.Deleted)
            {
                try
                {
                    tracNghiemController.Delete(deleted.ID);
                }
                catch (Exception ex)
                {

                }
            }
            if (hdfTypeCommand.Text == "Insert")
            {
                Dialog.ShowNotification("Thêm mới thành công tiêu chí đánh giá");
                if (hdfClose.Text == "True")
                {
                    wdAddNewEstimateCriterion.Hide();
                }
                else
                {
                    RM.RegisterClientScriptBlock("rsform", "ResetCriterionWindow();");
                }
            }
            else if (hdfTypeCommand.Text == "Edit")
            {
                Dialog.ShowNotification("Cập nhật thông tin tiêu chí đánh giá thành công");
                wdAddNewEstimateCriterion.Hide();
            }
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra: " + ex.Message);
        }
    }

    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DataTable record = new TieuChiDanhGiaController().GetByPrkey(txtmaloaihdcoppy.Text);
            if (record.Rows.Count > 0)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
            }
            else
            {
                record = new TieuChiDanhGiaController().GetByPrkey(hdfRecordID.Text);
                record.Rows[0]["MaNhom"] = txtmaloaihdcoppy.Text;
                TieuChiDanhGiaInfo item = new TieuChiDanhGiaInfo()
                {
                    MaNhom = record.Rows[0]["MaNhom"].ToString(),
                    TenNhom = record.Rows[0]["TenNhom"].ToString(),
                    HeSo = decimal.Parse(record.Rows[0]["HeSo"].ToString()),
                    GhiChu = record.Rows[0]["GhiChu"].ToString(),
                    CreatedDate = DateTime.Parse(record.Rows[0]["CreatedDate"].ToString()),
                    CreatedBy = int.Parse(record.Rows[0]["CreatedBy"].ToString()),
                    MaDonVi = record.Rows[0]["MaDonVi"].ToString(),
                    ParentID = record.Rows[0]["ParentID"].ToString(),
                };
                new TieuChiDanhGiaController().Insert(item);
                GridPanel1.Reload();
            }
            wdInputNewPrimaryKey.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }

    }

    [DirectMethod]
    public void DeleteRecord(string pr_key)
    {
        try
        {
            new TieuChiDanhGiaController().DeleteByPrkey(pr_key);
            hdfRecordID.Text = "";
        }
        catch (Exception ex)
        {
            if (ex.Message.ToString().Contains("FK_TieuChi_DotDanhGia_TieuChiDanhGia"))
            {
                X.Msg.Alert("Thông báo", "Bạn không thể xóa tiêu chí này. Tiêu chí đánh giá bạn muốn xóa đang được sử dụng trong một đợt đánh giá!").Show();
                GridPanel1.Reload();
            }
        }
    }

    [DirectMethod]
    public void DeleteNhomTieuChi(string pr_key)
    {
        try
        {
            // xóa các tiêu chí con
            new TieuChiDanhGiaController().DeleteByParentID(pr_key);
            // xóa nhóm tiêu chí
            new TieuChiDanhGiaController().DeleteByPrkey(pr_key);
            hdfMaNhom.Text = "";
        }
        catch (Exception ex)
        {
            if (ex.Message.ToString().Contains("FK_TieuChi_DotDanhGia_TieuChiDanhGia"))
            {
                X.Msg.Alert("Thông báo", "Bạn không thể xóa tiêu chí này. Tiêu chí đánh giá bạn muốn xóa đang được sử dụng trong một đợt đánh giá!").Show();
            }
        }
    }

    [DirectMethod]
    public void GeneratePrimaryKey()
    {
        txtMaNhom.Text = Util.GetInstance().GetRandomString(6);
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới tiêu chí đánh giá";
        hdfCommand.SetValue("");
        txtMaNhom.Disabled = false;
    }

    protected void btnEditCriterion_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.TieuChiDanhGia tieuChi = new TieuChiDanhGiaController().GetById(hdfRecordID.Text);
            if (tieuChi != null)
            {
                // get criterion information
                txtCriterionCode.Text = tieuChi.MaNhom;
                txtCriterionWeight.SetValue(tieuChi.HeSo);
                txtCriterionName.Text = tieuChi.TenNhom;
                cbxCriterionGroup.SetValue(tieuChi.ParentID);
                txtNote.Text = tieuChi.GhiChu;
                // get test information
                List<TracNghiemInfo> tests = new TracNghiemController().GetByCriterionID(tieuChi.MaNhom);
                grpTestListStore.DataSource = tests;
                grpTestListStore.DataBind();

                wdAddNewEstimateCriterion.Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra: " + ex.Message);
        }
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        string maNhom = string.Empty;
        if (e.ExtraParams["EditNhomTC"] == "True")
        {
            maNhom = hdfMaNhom.Text;
            if (maNhom.LastIndexOf(',') != -1)
            {
                maNhom = maNhom.Substring(0, maNhom.LastIndexOf(','));
            }
        }
        else
            maNhom = hdfRecordID.Text;
        DataTable record = new TieuChiDanhGiaController().GetByPrkey(maNhom);
        txtMaNhom.Text = record.Rows[0]["MaNhom"].ToString();
        txtTenNhom.Text = record.Rows[0]["TenNhom"].ToString();
        txtHeSo.Text = record.Rows[0]["HeSo"].ToString();
        txtGhiChu.Text = record.Rows[0]["GhiChu"].ToString();
        cbxTieuChiCha.SetValue(record.Rows[0]["ParentID"].ToString());
        txtMaNhom.Disabled = true;

        hdfCommand.Text = "Update";
        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa thông tin tiêu chí đánh giá";
        wdAddWindow.Show();
    }
}
