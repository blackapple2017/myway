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
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

public partial class Modules_ChamCongDoanhNghiep_DangKyMaChamCong : WebBase
{
    private string loaiFileExcel = "vertical";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Ext.Net.X.IsAjaxRequest)
        {
            SingleGridPanel1.GetAddButton().Hidden = true;
            SingleGridPanel1.GetDeleteButton().Hidden = true;
            SingleGridPanel1.GetToolBar().Insert(1, btnImportFromExcel);
            SingleGridPanel1.GetToolBar().Insert(2, btnThietLapNhanh);
            SingleGridPanel1.GetToolBar().Insert(2, btnExportToExcel);
            SingleGridPanel1.GetEditButton().Listeners.Click.Handler = "return CheckSua();";
            SingleGridPanel1.GetGridPanel().Listeners.RowDblClick.Handler = "wdSua.show();";
            SingleGridPanel1.GetGridPanel().Listeners.RowContextMenu.Handler = "e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());SingleGridPanel1_GridPanel1.getSelectionModel().selectRow(rowIndex);";
            LoadDonVi();
        }
    }
    #region loadtree ddfDonVi
    private void LoadDonVi()
    {
        string[] dsdv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        List<StoreComboObject> dvList = new DM_DONVIController().GetStoreByParentID(Session["MaDonVi"].ToString());
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        foreach (var item in dvList)
        {
            string actionNode = string.Empty;
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.TEN);
            node.Icon = Ext.Net.Icon.House;
            root.Nodes.Add(node);
            node.Expanded = true;
            if (dsdv.Contains(item.MA))
                node.Disabled = false;
            node.NodeID = item.MA;
            node.Checked = ThreeStateBool.False;
            hdfStringAllMaDonVi.Text += item.MA + ",";
            actionNode += LoadChildDepartment(item.MA, node);
            if (actionNode != "")
            {
                node.Listeners.CheckChange.Handler = "TreePanelDonVi.getNodeById('" + actionNode.Remove(actionNode.LastIndexOf(',')).Trim().Replace(",", "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);TreePanelDonVi.getNodeById('") + "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);";
            }
        }
        TreePanelDonVi.Listeners.CheckChange.Handler = @"#{ddfDonVi}.setValue(getTasks(this), false);";
        TreePanelDonVi.Root.Clear();
        TreePanelDonVi.Root.Add(root);
    }

    private string LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    {
        string[] dsdv = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        List<StoreComboObject> childList = new DM_DONVIController().GetStoreByParentID(maDonVi);
        string dsChild = "";
        foreach (var dv in childList)
        {
            string tmp = "";
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN);
            node.Icon = Ext.Net.Icon.Folder;
            DvNode.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA;
            if (dsdv.Contains(dv.MA))
                node.Disabled = false;
            node.Checked = ThreeStateBool.False;
            hdfStringAllMaDonVi.Text += dv.MA + ",";
            tmp += LoadChildDepartment(dv.MA, node);
            if (tmp != "")
            {
                node.Listeners.CheckChange.Handler = "TreePanelDonVi.getNodeById('" + tmp.Remove(tmp.LastIndexOf(',')).Trim().Replace(",", "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + dv.MA + "').getUI().checkbox.checked == true ? true : false);TreePanelDonVi.getNodeById('") + "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + dv.MA + "').getUI().checkbox.checked == true ? true : false);";
            }
            tmp += dv.MA + ",";
            dsChild += tmp;
        }
        return dsChild;
    }
    #endregion
    private void UploadFile()
    {
        try
        {
            HttpPostedFile file = fUpload.PostedFile;
            if (fUpload.HasFile == false && file.ContentLength > 10000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 1Mb");
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
            if (new FileInfo(Server.MapPath("File" + "/") + fUpload.FileName).Exists)
            {
                List<object> sheetData = new List<object>();
                IEnumerable<string> sheetname = ExcelEngine.GetInstance().GetAllSheetName(Server.MapPath("File" + "/") + fUpload.FileName);
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
    private void ImportFromExcelFile()
    {
        // create math rule
        int dongTieuDe = 1;

        string excelFileName = Server.MapPath("File/" + fUpload.FileName);
        List<Row> excelData = null;
        int start = dongTieuDe - 1;
        int limit = start + 50;
        int demloi = 0;
        int dem = 0;
        string err = "";
        do
        {
            excelData = ExcelEngine.GetInstance().GetDataFromExcel(excelFileName, cbSheetName.SelectedItem.Value, start, limit);
            if (excelData.Count == 0) break;
            foreach (var item in excelData)
            {
                demloi++;
                DAL.HOSO hoso = new HoSoController().GetByMaCB(item[0]);
                if (hoso == null)
                {
                    err += "Dòng thứ " + (demloi + dongTieuDe).ToString() + " có mã cán bộ là " + item[0] + " không tồn tại trong bảng hồ sơ<br/>";
                }
                else
                {
                    try
                    {

                        new HoSoController().UpdateMaChamCong(item[0], item[4]);
                        dem++;
                    }
                    catch (Exception ex)
                    {
                        err = err + ex.Message + "<br/>";
                    }
                }
            }
            start = limit;
            limit = start + 50;
        } while (true);
        if (err != "")
            X.Msg.Alert("Thông báo từ hệ thống", err).Show();
        Dialog.ShowNotification("Thông báo", "Đã import thành công mã chấm công của " + dem.ToString() + " cán bộ");
    }

    protected void btnImport_Click(object sender, DirectEventArgs e)
    {
        try
        {
            ImportFromExcelFile();
            wdImportExcelFile.Hide();
            SingleGridPanel1.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", ex.Message).Show();
        }
    }
    protected void ExportExcelClick(object sender, DirectEventArgs e)
    {
        string sourceFile = Server.MapPath("") + "\\FileMau\\Ma cham cong mau.xls";
        string destination = Server.MapPath("") + "\\File\\Ma cham cong export.xls";
        File.Copy(sourceFile, destination, true);
        System.Data.OleDb.OleDbConnection MyConnection;
        System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
        string sql = null;
        MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + destination + "';Extended Properties=Excel 8.0;");
        MyConnection.Open();
        myCommand.Connection = MyConnection;
        int dem = 0;
        if (radExpTatCa.Checked == true)
        {
            List<HoSoInfo> listhoso = new HoSoController().GetHoSoMaChamCong(Session["MaDonVi"].ToString(), new List<string>(), false);
            foreach (var item in listhoso)
            {
                dem++;
                sql = @"Insert into [Sheet1$] values('" + item.MACB + "','" + item.HOTEN + "','" + item.PHONGBAN + "','" + item.BIDANH + "','" + item.MaChamCong + "')";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
            }
        }
        if (radExpBoPhan.Checked == true)
        {
            List<HoSoInfo> listhoso = new HoSoController().GetHoSoMaChamCong(SingleGridPanel1.GetMaDonVi(), new List<string>(), false);
            foreach (var item in listhoso)
            {
                dem++;
                sql = @"Insert into [Sheet1$] values('" + item.MACB + "','" + item.HOTEN + "','" + item.PHONGBAN + "','" + item.BIDANH + "','" + item.MaChamCong + "')";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
            }
        }

        HoSoController hsc = new HoSoController();
        if (radExpChon.Checked == true)
        {

            foreach (var item in new HoSoController().GetHoSoMaChamCong(Session["MaDonVi"].ToString(), SingleGridPanel1.GetSelectedRecordIDs() ?? new List<string>(), true))
            {
                dem++;
                sql = @"Insert into [Sheet1$] values('" + item.MACB + "','" + item.HOTEN + "','" + item.PHONGBAN + "','" + item.BIDANH + "','" + item.MaChamCong + "')";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
            }
        }
        MyConnection.Close();

        Dialog.ShowNotification("Thông báo", "Đã xuất thông tin của " + dem.ToString() + " cán bộ thành công");
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + "MaChamCongExport.xls");
        Response.WriteFile(destination);
        Response.End();
        wdExport.Hide();
    }
    protected void btnSuaDongYClick(object sender, DirectEventArgs e)
    {
        try
        {
            //if (SingleGridPanel1.GetSelectedRecordIDs().Count() > 1)
            //{
            //    X.MessageBox.Alert("Cảnh báo", "Bạn chỉ có thể chọn một nhân viên !").Show();
            //    return;
            //}
            //  Regex myRegex = new Regex("/[0-9A-Za-z\;]/");
            //myRegex.IsMatch(preg_match("/^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$/", "fsdfsd"); 
            if (txtSua.Text.LastIndexOf(';') == txtSua.Text.Length - 1) txtSua.Text = txtSua.Text.Remove(txtSua.Text.LastIndexOf(';'));
            foreach (var item in SingleGridPanel1.GetSelectedRecordIDs())
            {
                new HoSoController().UpdateMaChamCong(item, txtSua.Text);
            }
            Dialog.ShowNotification("Thông báo", "Cập nhật thành công !");
            SingleGridPanel1.GetGridPanel().Reload();
            wdSua.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnSuDungMaNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string str = "";
            if (e.ExtraParams["SelectedEmployees"] != "")
            {
                foreach (var item in SingleGridPanel1.GetSelectedRecordIDs())
                {
                    str += item + ",";
                }
                if (!string.IsNullOrEmpty(str))
                {
                    str = "," + str;
                }
                DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_SuDungMaCanBoLamMaChamCong", "@maCbStr", "@maDonVi", str, "");
            }
            else
            {
                DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_SuDungMaCanBoLamMaChamCong", "@maCbStr", "@maDonVi", str, "," + hdfStringMaDonVi.Text + ",");
            }
            SingleGridPanel1.GetGridPanel().Reload();
            wdSuDungMaNhanVien.Hide();

        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
}