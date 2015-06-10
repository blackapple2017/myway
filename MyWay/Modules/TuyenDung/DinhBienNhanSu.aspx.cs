using System;
using System.Collections.Generic;
using System.Linq;
using Ext.Net;
using SoftCore.Security;
using DAL;
using ExtMessage;
using System.Xml.Xsl;
using System.Xml;

public partial class Modules_TuyenDung_DinhBienNhanSu : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            dfDatetime.SelectedDate = dateTinhDenNgay.SelectedDate = DateTime.Now;

            new DTH.BorderLayout()
            {
                script = "#{hdfMaPhong}.setValue('" + DTH.BorderLayout.nodeID + "');hdfMaDonVi.setValue('');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
            LoadYear();
            LoadDonViForComboBox();
            LoadDMCongViec();
            LoadDMChucVu();
        }
    }

    private void LoadDinhBienNhanSu()
    {
        int count = 0;
        var source = new DinhBienNhanSuController().GetByYearAndSearchKey(0, string.Empty, ref count);
        var store = GridPanel1.GetStore();
        store.DataSource = source;
        store.DataBind();
    }

    private void LoadDMCongViec()
    {

        var source = new DM_CONGVIECController().GetAll();
        cbStoreCongViecList.DataSource = source;
        cbStoreCongViecList.DataBind();
    }

    private void LoadDMChucVu()
    {

        var source = new DM_CHUCVUController().GetALL();
        var store = cbChucVuList.GetStore();
        store.DataSource = source;
        store.DataBind();
       
    }


    protected void btnSaveData_Click(object sender, DirectEventArgs e)
    {

        //DataController.DataHandler.GetInstance().ExecuteNonQuery(e.ExtraParams["html"]);
        //Dialog.ShowNotification("Cập nhật dữ liệu thành công");
    }

    protected void btnSearch_Click(object sender, DirectEventArgs e)
    {
        int year = Convert.ToInt32(cbChonNam.Value);


        //DataController.DataHandler.GetInstance().ExecuteNonQuery(e.ExtraParams["html"]);
        //Dialog.ShowNotification("Cập nhật dữ liệu thành công");
    }

    protected void cbStoreDonVi_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            var dvList = new DonViController().GetDonViByUserIdParentChildren();
            cbStoreDonVi.DataSource = dvList;
            cbStoreDonVi.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbDonViList_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            var dvList = new DonViController().GetDonViByUserIdParentChildren();
            cbStoreDonViList.DataSource = dvList;
            cbStoreDonViList.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbCongViecList_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            var donViList = new List<string>();
            foreach (var dv in cbDonViList.SelectedItems) { donViList.Add(dv.Value); }
            var dvList = new DM_CONGVIECController().GetAllRecord(donViList);
            cbStoreCongViecList.DataSource = dvList;
            cbStoreCongViecList.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void cbChonNamStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbChonNamStore.DataSource = new DinhBienNhanSuController().GetYearList();
            cbChonNamStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }


    protected void cbStoreChucVuList_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            //cbChonNamStore.DataSource = new DinhBienController().GetYearList();
            //cbChonNamStore.DataBind();
        }
        catch (Exception ex)
        {
           // X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }


    

    private void LoadDonViForComboBox()
    {
        var dvList = new DonViController().GetDonViByUserIdParentChildren();
        var store = cbDonViList.GetStore();
        store.DataSource = dvList;
        store.DataBind();

        var store2 = cbDonVi.GetStore();
        store2.DataSource = dvList;
        store2.DataBind();
    }

    protected void cbxChuyenTiepNhomTC_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        //cbxChuyenTiepNhomTC_Store.DataSource = new TieuChiDanhGiaController().GetByParentID("-1", Session["MaDonVi"].ToString());
        //cbxChuyenTiepNhomTC_Store.DataBind();
    }

    protected void LoadYear()
    {
        var store = cbChonNam.GetStore();
        var yearList = new DinhBienNhanSuController().GetYearList();
        store.DataSource = yearList;
        store.DataBind();
    }

    protected void btnThemViTriCongViec_Click(object sender, DirectEventArgs e)
    {
        try
        {
            var maCongViec = MaCongViec.Text;
            var tenCongViec = TenCongViec.Text;
            var maDonVi =  Convert.ToString(cbDonVi.Value);
            var maChucVu = Convert.ToString(cbChucVuList.Value);
            var tinhDenNgay =dateTinhDenNgay.SelectedDate;
            var dinhBien = Convert.ToInt32(txtDinhBien.Text);

            var t1 = Utilities.ToInt32(thang1.Value,0);
            var t2 = Utilities.ToInt32(thang2.Value,0);
            var t3 = Utilities.ToInt32(thang3.Value,0);
            var t4 = Utilities.ToInt32(thang4.Value,0);
            var t5 = Utilities.ToInt32(thang5.Value,0);
            var t6 = Utilities.ToInt32(thang6.Value,0);
            var t7 = Utilities.ToInt32(thang7.Value,0);
            var t8 = Utilities.ToInt32(thang8.Value,0);
            var t9 = Utilities.ToInt32(thang9.Value,0);
            var t10 = Utilities.ToInt32(thang10.Value,0);
            var t11 = Utilities.ToInt32(thang11.Value,0);
            var t12 = Utilities.ToInt32(thang12.Value,0);
            

            var dmcv = new DM_CONGVIEC
            {
                MA_CONGVIEC = maCongViec,
                TEN_CONGVIEC = tenCongViec,
                MA_DONVI = maDonVi,
                DATE_CREATE = DateTime.Now.Date,
                USERNAME = CurrentUser.UserName
            };

            if (new DM_CONGVIECController().Add(dmcv))
            {
                
                new DinhBienNhanSuController().Add(new DinhBienNhanSu{
                                                           MaCongViec = maCongViec,
                                                           MaDonVi = maDonVi,
                                                           MaChucVu = maChucVu,
                                                           TinhDenNgay = tinhDenNgay,
                                                           SoLuongNhanSu = 0,
                                                           SoLuongDinhBien = dinhBien,
                                                           SoLuongTuyenMoi = dinhBien,
                                                           CreatedDate = DateTime.Now,
                                                           CreatedBy = CurrentUser.ID,
                                                           Nam = tinhDenNgay.Year,
                                                           Thang1 = t1,
                                                           Thang2 = t2,
                                                           Thang3 = t3,
                                                           Thang4 = t4,
                                                           Thang5 = t5,
                                                           Thang6 = t6,
                                                           Thang7 = t7,
                                                           Thang8 = t8,
                                                           Thang9 = t9,
                                                           Thang10 = t10,
                                                           Thang11 = t11,
                                                           Thang12 = t12
                                                       });
                wdThemViTriCongViec.Hide();
                GridPanel1.Reload();
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    /// <summary>
    /// Tính số lượng nhân sự hiện tại
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSum_Click(object sender, DirectEventArgs e)
    {
        try
        {
            bool allDonVi = chkAllDepartments.Checked;
            var departmentCodeList = new List<string>();
            if (!allDonVi)
            {
                foreach (var item in cbDonViList.SelectedItems)
                {
                    departmentCodeList.Add(item.Value);
                }
            }
            //else
            //{
            //    foreach (var item in cbDonViList.Items)
            //    {
            //        departmentCodeList.Add(item.Value);
            //    } 
            //}


            bool allWorks = chkAllWorks.Checked;
            var wordCodeList = new List<string>();
            if (!allWorks)
            {
                foreach (var item in cbCongViecList.SelectedItems)
                {
                    wordCodeList.Add(item.Value);
                }
            }
            //else
            //{
            //    foreach (var item in cbCongViecList.Items)
            //    {
            //        wordCodeList.Add(item.Value);
            //    }
            //}

            var day =  dfDatetime.SelectedDate;
            bool includeThuViec = chAllStaffType.Checked;
            new DinhBienNhanSuController().AddDinhBien(allDonVi, departmentCodeList,wordCodeList, day, includeThuViec, CurrentUser.ID, DateTime.Now);
            wdChonPhong.Hide();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }


    

    protected void Store1_Submit(object sender, StoreSubmitDataEventArgs e)
    {

        XmlNode xml = e.Xml;

        this.Response.Clear();

        this.Response.ContentType = "application/vnd.ms-excel";
        this.Response.AddHeader("Content-Disposition", "attachment; filename=submittedData.xls");
        XslCompiledTransform xtExcel = new XslCompiledTransform();
        xtExcel.Load(Server.MapPath("~/Modules/TuyenDung/Resource/Excel.xsl"));
        xtExcel.Transform(xml, null, Response.OutputStream);

        this.Response.End();
    }

    #region Load tree
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
            LoadChildDepartment(dv.MA_DONVI, node);
            node.Listeners.Click.Handler = "#{hdfMaDonVi}.setValue('" + node.NodeID + "');hdfMaPhong.setValue('');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();";
        }
        //   TreeCoCauToChuc.Root.Clear();
        //      TreeCoCauToChuc.Root.Add(root);
    }

    private void LoadChildDepartment(string maDonVi, Ext.Net.TreeNode DvNode)
    {
        List<DM_DONVI> childList = new DM_DONVIController().GetByParentID(maDonVi);
        foreach (DM_DONVI dv in childList)
        {
            var node = new Ext.Net.TreeNode(dv.TEN_DONVI);
            node.Icon = Ext.Net.Icon.Folder;
            DvNode.Nodes.Add(node);
            node.Expanded = true;
            node.NodeID = dv.MA_DONVI;
            node.Listeners.Click.Handler = "#{hdfMaPhong}.setValue('" + node.NodeID + "');hdfMaDonVi.setValue('');txtSearchKey.reset();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();";
            LoadChildDepartment(dv.MA_DONVI, node);
        }
    }
    #endregion
}