using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using DAL;
using Controller.ChamCongDoanhNghiep;
using System.Data.SqlClient;
using DataController;
using ExtMessage;

public partial class Modules_ChamCongDoanhNghiep_ThietLapCaTheoThang : WebBase
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();

            new DTH.BorderLayout()
            {
                script = "hdfMaDonVi.setValue('" + DTH.BorderLayout.nodeID + "');txtSearchKey.reset();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();Store1.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
        LoadDonVi();
    }

    protected void cbChonBangPhanCaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            int count = 0;
            cbChonBangPhanCaStore.DataSource = new DanhSachBangPhanCaController().GetByMaDonVi(Session["MaDonVi"].ToString(), -1, int.Parse(SpinnerField1.Text), 0, 100, out count,"Nam");
            cbChonBangPhanCaStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            string duplicateMaCB = "";
            BangPhanCaNamController controller = new BangPhanCaNamController();
            int i = 0;
            string[] g = ucChooseEmployee1.DanhSachHoTen.Split(',');
            foreach (var item in ucChooseEmployee1.SelectedRow)
            {
                try
                {
                    DAL.BangPhanCaNam bangPhanCaNam = new BangPhanCaNam()
                    {
                        IdDanhSachBangPhanCa = int.Parse(hdfIdBangPhanCa.Text),
                        MaCB = item.RecordID,
                    };
                    controller.Add(bangPhanCaNam);
                }
                catch (SqlException ex)
                {
                    //if (ex.Number == 2601)//mã lỗi trùng bản ghi
                    //{
                    duplicateMaCB += "<br/> " + item.RecordID + " : " + g[i];
                    //}
                }
                i++;
            }
            GridPanel1.Reload();

            if (!string.IsNullOrEmpty(duplicateMaCB))
            {
                X.MessageBox.Alert("Thông báo", "Các nhân viên có mã sau đây đã được thêm vào rồi : " + duplicateMaCB).Show();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void mnuXoaNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BangPhanCaNamController controller = new BangPhanCaNamController();
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                controller.Delete(int.Parse(item.RecordID));
            }
            GridPanel1.Reload();
            mnuXoaNhanVien.Disabled = true;
            mnuHuyPhanCa.Disabled = true;
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void btnChuyenNhanVien_Click(int id, string macb, string tencb)
    {

        string sql = "Update ChamCong.BangPhanCaNam set IdDanhSachBangPhanCa = {0} where ID in ({1})";
        try
        {

            DataHandler.GetInstance().ExecuteNonQuery(string.Format(sql, cbChonBangPhanCa.SelectedItem.Value, id));
            Dialog.ShowNotification("Thông báo", "Đã chuyển thành công nhân viên " + tencb);
            RM.RegisterClientScriptBlock("reloadgrid", "Store1.reload()");

        }
        catch (Exception ex)
        {
            Dialog.ShowNotification("Thông báo", "Không chuyển được nhân viên có mã" + macb + ": " + tencb + " vì bảng đích đã có người này.");

        }

        //try
        //{
        //    string idLoi = "";
        //    string sql = "Update ChamCong.BangPhanCaNam set IdDanhSachBangPhanCa = {0} where ID in ({1}-1)";
        //    foreach (var item in RowSelectionModel1.SelectedRows)
        //    {
        //        try
        //        {
        //            DataHandler.GetInstance().ExecuteNonQuery(string.Format(sql, cbChonBangPhanCa.SelectedItem.Value, item.RecordID));
        //        }
        //        catch(Exception ex)
        //        {
        //            idLoi += item.RecordID + ",";
        //        }
        //    }

        //    GridPanel1.Reload();
        //    wdChuyenNhanVien.Hide();
        //}
        //catch (Exception ex)
        //{
        //    X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        //}
    }

    //private void LoadDonVi()
    //{
    //    List<DM_DONVI> dvList = new UserController().GetDonViByUserID(CurrentUser.ID);
    //    Ext.Net.TreeNode root = new Ext.Net.TreeNode();
    //    foreach (DM_DONVI dv in dvList)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
    //        node.Icon = Ext.Net.Icon.House;
    //        root.Nodes.Add(node);
    //        node.Expanded = true;
    //        node.NodeID = dv.MA_DONVI;
    //        node.Checked = ThreeStateBool.False;
    //        LoadChildDepartment(dv.MA_DONVI, node);
    //    }
    //    TreePanelDonVi.Root.Clear();
    //    TreePanelDonVi.Root.Add(root);
    //}

    //private void LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    //{
    //    List<DM_DONVI> childList = new DM_DONVIController().GetByParentID(maDonVi);
    //    foreach (DM_DONVI dv in childList)
    //    {
    //        Ext.Net.TreeNode node = new Ext.Net.TreeNode(dv.TEN_DONVI);
    //        node.Icon = Ext.Net.Icon.Folder;
    //        DvNode.Nodes.Add(node);
    //        node.Expanded = true;
    //        node.NodeID = dv.MA_DONVI;
    //        node.Checked = ThreeStateBool.False;
    //        LoadChildDepartment(dv.MA_DONVI, node);
    //    }
    //}

    protected void cbChonCaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            int count = 0;
            cbChonCaStore.DataSource = new DanhSachCaController().GetAll(0, 100, Session["MaDonVi"].ToString(), "", out count);
            cbChonCaStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnTaoBangPhanCa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtTenBangPhanCa.Text) || string.IsNullOrEmpty(txtYear.Text) || string.IsNullOrEmpty(ddfDonVi.Text))
            {
                X.Msg.Alert("Thông báo", "Tạo bảng phân ca thất bại. Dữ liệu nhập vào không hợp lệ").Show();
                return;
            }
            string str = hdfStringMaDonVi.Text;
            //hdfStringMaDonVi.Reset();
            hdfStringMaDonVi.Text = "";
            // thêm một bảng phân ca mới
            DAL.DanhSachBangPhanCa ds = new DanhSachBangPhanCa()
            {
                TenBangPhanCa = txtTenBangPhanCa.Text,
                Thang = -1,
                Nam = int.Parse("0" + txtYear.Text),
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                //MaBangPhanCa = str,
                MaDonVi = Session["MaDonVi"].ToString()
            };
            int id = new DanhSachBangPhanCaController().Insert(ds);
            // thêm nhân viên cho bảng phân ca vừa tạo
            if (id == -1)
                throw new Exception("Thêm mới bảng phân ca không thành công");
            string loitrungnguoi = new BangPhanCaNamController().AddEmployee(id, str, cbChonCa.SelectedItem.Value, int.Parse("0" + txtYear.Text));
            //  hdfIdBangPhanCa.Text = id.ToString();
            //  GridPanel1.Reload();
            hdfIdBangPhanCa.Text = id.ToString();
            GridPanel1.Title = txtTenBangPhanCa.Text;
            if (loitrungnguoi != "")
                X.Msg.Alert("Thông báo", loitrungnguoi).Show();
            wdTaoBangPhanCa.Hide();
            RM.RegisterClientScriptBlock("rl", "txtSearchKey.reset();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();Store1.reload();");
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    protected void btnTienHanhPhanCaNhanh_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //phân ca cho tất cả nhân viên trong bảng phân ca

            string sql = "update ChamCong.BangPhanCaNam set ";

            if (cbTuThang1.SelectedIndex >= 0 && cbDenThang1.SelectedIndex >= 0 && cbChonCa1.SelectedIndex >= 0)
            {
                for (int i = int.Parse(cbTuThang1.SelectedItem.Value); i <= int.Parse(cbDenThang1.SelectedItem.Value); i++)
                {
                    sql += "Thang" + i + " = '" + cbChonCa1.SelectedItem.Value + "', ";
                }
            }

            if (cbTuThang2.SelectedIndex >= 0 && cbDenThang2.SelectedIndex >= 0 && cbDenThang2.SelectedIndex >= 0)
            {
                for (int i = int.Parse(cbTuThang2.SelectedItem.Value); i <= int.Parse(cbDenThang2.SelectedItem.Value); i++)
                {
                    sql += "Thang" + i + " = '" + cbChonCa2.SelectedItem.Value + "', ";
                }
            }

            if (cbTuThang3.SelectedIndex >= 0 && cbDenThang3.SelectedIndex >= 0 && cbDenThang3.SelectedIndex >= 0)
            {
                for (int i = int.Parse(cbTuThang3.SelectedItem.Value); i <= int.Parse(cbDenThang3.SelectedItem.Value); i++)
                {
                    sql += "Thang" + i + " = '" + cbChonCa3.SelectedItem.Value + "', ";
                }
            }

            if (cbTuThang4.SelectedIndex >= 0 && cbDenThang4.SelectedIndex >= 0 && cbDenThang4.SelectedIndex >= 0)
            {
                for (int i = int.Parse(cbTuThang4.SelectedItem.Value); i <= int.Parse(cbDenThang4.SelectedItem.Value); i++)
                {
                    sql += "Thang" + i + " = '" + cbChonCa4.SelectedItem.Value + "', ";
                }
            }

            if (cbTuThang5.SelectedIndex >= 0 && cbDenThang5.SelectedIndex >= 0 && cbDenThang5.SelectedIndex >= 0)
            {
                for (int i = int.Parse(cbTuThang5.SelectedItem.Value); i <= int.Parse(cbDenThang5.SelectedItem.Value); i++)
                {
                    sql += "Thang" + i + " = '" + cbChonCa5.SelectedItem.Value + "', ";
                }
            }

            if (cbTuThang6.SelectedIndex >= 0 && cbDenThang6.SelectedIndex >= 0 && cbDenThang6.SelectedIndex >= 0)
            {
                for (int i = int.Parse(cbTuThang6.SelectedItem.Value); i <= int.Parse(cbDenThang6.SelectedItem.Value); i++)
                {
                    sql += "Thang" + i + " = '" + cbChonCa6.SelectedItem.Value + "', ";
                }
            }
            if (sql.Contains(","))
            {
                if (chkAll.Checked)
                {
                    sql = sql.Remove(sql.LastIndexOf(",")) + " where IdDanhSachBangPhanCa = " + hdfIdBangPhanCa.Text;
                }
                else //chỉ áp dụng cho đối tượng được  chọn
                {
                    string id = "";
                    foreach (var item in RowSelectionModel1.SelectedRows)
                    {
                        id += item.RecordID + ",";
                    }
                    sql = sql.Remove(sql.LastIndexOf(",")) + " where ID in (" + id + "-1)";
                }
            }
            else
            {
                X.MessageBox.Alert("Thông báo", "Bạn chưa chọn thông tin phân ca").Show();
                return;
            }

            DataHandler.GetInstance().ExecuteNonQuery(sql);
            GridPanel1.Reload();
            wdPhanCaNhanh.Hide();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnPhanCaTuDong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BangPhanCaNamController controller = new BangPhanCaNamController();
            int tongSoCa = cbChonCaTuDong.SelectedItems.Count(); //tổng số ca được chọn để phân ca
            int tongSoNguoi = controller.GetCount(int.Parse(hdfIdBangPhanCa.Text));
            int start;
            int limit;
            int remain = tongSoNguoi % tongSoCa;
            int nguyen = tongSoNguoi / tongSoCa;
            int du = tongSoNguoi % tongSoCa;
            string bath = "";
            //Phân ca nhưng ko luân chuyển ca
            if (rdKhongLuanChuyen.Checked)
            {
                string sql = string.Empty;
                string command = @"update ChamCong.BangPhancaNam set {0} where ID in 
                                (
	                                select ID from
	                                (
	                                   select ID, ROW_NUMBER() OVER(ORDER BY ID) RN from ChamCong.BangPhancaNam 
	                                   where IdDanhSachBangPhanCa = " + hdfIdBangPhanCa.Text + @"
                                    )a
	                                where RN between {1} and {2}
                                ) ";

                if (cbFromMonth.SelectedIndex >= 0 && cbToMonth.SelectedIndex >= 0)
                {
                    start = 1; limit = nguyen;// dàn đều số người thuộc từng ca
                    //đặt 1 biến đếm để khi hết số tháng quy định thì nẩy lên 1
                    int dem, nhom = 0;
                    foreach (var item in cbChonCaTuDong.SelectedItems)
                    {
                        sql = ""; dem = 0;
                        limit = limit + (du > 0 ? 1 : 0);
                        for (int i = int.Parse(cbFromMonth.SelectedItem.Value); i <= int.Parse(cbToMonth.SelectedItem.Value); i++)
                        {

                            sql += "Thang" + i + "='" + item.Value + "', ";
                            dem++;
                        }
                        bath += string.Format(command, sql.Remove(sql.LastIndexOf(",")), start, limit) + "  ";
                        du--;
                        start = limit + 1;
                        limit = start + nguyen - 1;
                        nhom++;
                    }
                }
                DataHandler.GetInstance().ExecuteNonQuery(bath);
            }
            else if (rdCoLuanChuyenCa.Checked) //có luân chuyển ca
            {
                string sql = string.Empty;
                string command = @"update ChamCong.BangPhancaNam set {0} where ID in 
                                (
	                                select ID from
	                                (
	                                   select ID, ROW_NUMBER() OVER(ORDER BY ID) RN from ChamCong.BangPhancaNam 
	                                   where IdDanhSachBangPhanCa = " + hdfIdBangPhanCa.Text + @"
                                    )a
	                                where RN between {1} and {2}
                                ) ";

                if (cbFromMonth.SelectedIndex >= 0 && cbToMonth.SelectedIndex >= 0)
                {
                    start = 1; limit = nguyen;// dàn đều số người thuộc từng ca
                    //đặt 1 biến đếm để khi hết số tháng quy định thì nẩy lên 1
                    int dem, nhom = 0;
                    foreach (var item in cbChonCaTuDong.SelectedItems)
                    {
                        sql = ""; dem = 0;
                        limit = limit + (du > 0 ? 1 : 0);
                        for (int i = int.Parse(cbFromMonth.SelectedItem.Value); i <= int.Parse(cbToMonth.SelectedItem.Value); i++)
                        {

                            sql += "Thang" + i + "='" + cbChonCaTuDong.SelectedItems[(dem / int.Parse(spnSoThangLuanChuyenCa.Value.ToString()) + nhom) % (tongSoCa)].Value + "', ";
                            dem++;
                        }
                        bath += string.Format(command, sql.Remove(sql.LastIndexOf(",")), start, limit) + "  ";
                        du--;
                        start = limit + 1;
                        limit = start + nguyen - 1;
                        nhom++;
                    }
                }
                DataHandler.GetInstance().ExecuteNonQuery(bath);
            }
            wdPhanCaTuDong.Hide();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbChonLaiBangPhanCaStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            int count = 0;
            cbChonLaiBangPhanCaStore.DataSource = new DanhSachBangPhanCaController().GetByMaDonVi(Session["MaDonVi"].ToString(), -1, int.Parse(spfYear.Text), 0, 100, out count,"Nam");
            cbChonLaiBangPhanCaStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnHuyBangPhanCa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string id = "";
            string sql = "update ChamCong.BangPhanCaNam set ";
            if (chkThang1.Checked)
                sql += "Thang1='',";
            if (chkThang2.Checked)
                sql += "Thang2='',";
            if (chkThang3.Checked)
                sql += "Thang3='',";
            if (chkThang4.Checked)
                sql += "Thang4='',";
            if (chkThang5.Checked)
                sql += "Thang5='',";
            if (chkThang6.Checked)
                sql += "Thang6='',";
            if (chkThang7.Checked)
                sql += "Thang7='',";
            if (chkThang8.Checked)
                sql += "Thang8='',";
            if (chkThang9.Checked)
                sql += "Thang9='',";
            if (chkThang10.Checked)
                sql += "Thang10='',";
            if (chkThang11.Checked)
                sql += "Thang11='',";
            if (chkThang12.Checked)
                sql += "Thang12='',";
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                id += item.RecordID + ",";
            }
            DataHandler.GetInstance().ExecuteNonQuery(sql.Remove(sql.LastIndexOf(",")) + " where ID in (" + id + "-1)");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    #region loadtree ddfDonVi
    private void LoadDonVi()
    {
        List<StoreComboObject> dvList = new DM_DONVIController().GetStoreByParentID(Session["MaDonVi"].ToString());
        Ext.Net.TreeNode root = new Ext.Net.TreeNode();
        foreach (var item in dvList)
        {
            string actionNode = string.Empty;
            Ext.Net.TreeNode node = new Ext.Net.TreeNode(item.TEN);
            node.Icon = Ext.Net.Icon.House;
            root.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = item.MA;
            node.Checked = ThreeStateBool.False;
            hdfStringAllMaDonVi.Text += item.MA + ",";
            actionNode += LoadChildDepartment(item.MA, node);
            if (actionNode != "")
            {
                node.Listeners.CheckChange.Handler = "TreePanelDonVi.getNodeById('" + actionNode.Remove(actionNode.LastIndexOf(',')).Trim().Replace(",", "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);TreePanelDonVi.getNodeById('") + "').getUI().checkbox.checked = (TreePanelDonVi.getNodeById('" + item.MA + "').getUI().checkbox.checked == true ? true : false);";
            }
        }
        TreePanelDonVi.Listeners.CheckChange.Handler = @"#{ddfDonVi}.setValue(getTasks(this), false);
                                                         txtTenBangPhanCa.setValue('Bảng phân ca trong năm ' + txtYear.getValue() + ' tại ' + ddfDonVi.getText().replace('[', '').replace(']', ''));
                                                         GetSelectedNodeDonVi(TreePanelDonVi,hdfStringAllMaDonVi,hdfStringMaDonVi)";
        TreePanelDonVi.Root.Clear();
        TreePanelDonVi.Root.Add(root);
    }

    private string LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    {
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
}