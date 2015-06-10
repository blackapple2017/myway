using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;

public partial class Modules_DaoTao_GiangVien : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!X.IsAjaxRequest)
        //{
        //    grp_DanhSachGiangVien.FilterAtRuntime = " MA_DONVI = " + Session["MaDonVi"];// new UserController().GetDonViByUserID(CurrentUser.ID).FirstOrDefault().MA_DONVI;
        //}
        //grp_DanhSachGiangVien.AddComponent(btnAddGiangVien, 0);
        //grp_DanhSachGiangVien.AddComponent(btnEditGiangVien, 1);
        //if (!X.IsAjaxRequest)
        //{
        //    grp_DanhSachGiangVien.HiddenAddButton(true);
        //    grp_DanhSachGiangVien.HiddenEditButton(true);
        //    grp_DanhSachGiangVien.RowSelection = "grp_DanhSachGiangVien_btnEditGiangVien.enable();";
        //}
        //grp_DanhSachGiangVien.GetGridPanel().DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(DblClick_Event);

        if (!X.IsAjaxRequest)
        {
            grpTeacherList.GetAddButton().Listeners.Click.Handler = "wdGiaoVien.show();";
        }
        grpTeacherList.GetEditButton().DirectEvents.Click.Event += new ComponentDirectEvent.DirectEventHandler(btnEditGiangVien_Click);
        grpTeacherList.GetGridPanel().DirectEvents.DblClick.Event += new ComponentDirectEvent.DirectEventHandler(btnEditGiangVien_Click);
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }
      
    //protected void cbx_trinhdo_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    List<DAL.DM_TRINHDO> lists = new DM_TRINHDOController().GetByAll();
    //    List<object> obj = new List<object>();
    //    foreach (var item in lists)
    //    {
    //        obj.Add(new { MA_TRINHDO = item.MA_TRINHDO, TEN_TRINHDO = item.TEN_TRINHDO });
    //    }
    //    cbx_trinhdo_Store.DataSource = obj;
    //    cbx_trinhdo_Store.DataBind();
    //}

    protected void btnEditGiangVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DM_GiaoVienDaoTao giaoVien = new DaoTaoController().GetGiaoVienByMaGiaoVien(grpTeacherList.GetSelectedRecordIDs().FirstOrDefault());
            gv_txtHoten.Text = giaoVien.HoTenGV;
            gv_txtMaGiaoVien.Text = giaoVien.MaGV;
            gv_txtMaGiaoVien.Disabled = true;
            if (giaoVien.NgaySinh.HasValue && giaoVien.NgaySinh.Value.ToString().Contains("01/01/0001") == false && giaoVien.NgaySinh.Value.ToString().Contains("1900") == false)
            {
                df_ngaysinh.SelectedDate = giaoVien.NgaySinh.Value;
            }
            txt_chucvu.Text = giaoVien.ChucVu;
            txt_didong.Text = giaoVien.DiDong;
            txt_diachi.Text = giaoVien.DiaChiLienHe;
            txt_donvicongtac.Text = giaoVien.DonViCongTac;
            txt_dtcq.Text = giaoVien.DTCoQuan;
            txt_email.Text = giaoVien.Email;
            cbx_gioitinh.SetValue(giaoVien.GioiTinh);
            cbx_trinhdo.SetValue(giaoVien.HocVan);
            txt_kinhnghiem.Text = giaoVien.KinhNghiemGiangDay;
            chk_nvcongty.Checked = giaoVien.LaNhanvienCty;
            chk_QuanLyPhuTrach.Checked = giaoVien.LaQuanLyPhuTrach;
            hdfCommand.Text = "Edit";
            wdGiaoVien.Show();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnSave_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DaoTaoController daotao = new DaoTaoController();
            DAL.DM_GiaoVienDaoTao giaovien = new DAL.DM_GiaoVienDaoTao();
 
            giaovien.ChucVu = txt_chucvu.Text;
            giaovien.CreatedBy = CurrentUser.ID;
            giaovien.CreatedDate = DateTime.Now;
            giaovien.DiaChiLienHe = txt_diachi.Text;
            giaovien.DiDong = txt_didong.Text;
            giaovien.DonViCongTac = txt_donvicongtac.Text;
            giaovien.DTCoQuan = txt_dtcq.Text;
            giaovien.Email = txt_email.Text;
            giaovien.GioiTinh = bool.Parse(cbx_gioitinh.SelectedItem.Value);
            //giaovien.HocVan = txt_hocvan.Text;
            //if (cbx_trinhdo.Value != null)
            //    giaovien.HocVan = cbx_trinhdo.Value.ToString();
            giaovien.HocVan = hdftrinhdo.Text;
            giaovien.HoTenGV = gv_txtHoten.Text;
            giaovien.KinhNghiemGiangDay = txt_kinhnghiem.Text;
            giaovien.LaNhanvienCty = chk_nvcongty.Checked;
            giaovien.LaQuanLyPhuTrach = chk_QuanLyPhuTrach.Checked;
            giaovien.MaGV = gv_txtMaGiaoVien.Text;
            if (!df_ngaysinh.SelectedDate.ToString().Contains("0001"))
            {
                giaovien.NgaySinh = df_ngaysinh.SelectedDate;
            }
            giaovien.MA_DONVI = Session["MaDonVi"].ToString();

            if (e.ExtraParams["Command"] == "Edit")
            {
                daotao.UpdateGiaoVien(giaovien);
                grpTeacherList.GetGridPanel().Reload();
                wdGiaoVien.Hide();
                Dialog.ShowNotification("Cập nhật thành công");
            }
            else
            {
                daotao.InsertGiaoVien(giaovien);
                grpTeacherList.GetGridPanel().Reload();
                if (e.ExtraParams["Close"] == "True")
                {
                    wdGiaoVien.Hide();
                }
                else
                {
                    grpTeacherList.GetResourceManager().RegisterClientScriptBlock("rsf", "ResetValue()");
                }
                Dialog.ShowNotification("Cập nhật thành công");
            }
            grpTeacherList.GetGridPanel().Reload();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
            {
                Dialog.ShowError("Mã giáo viên không được trùng !");
            }
            else
                Dialog.ShowError(ex.Message);
        }
    }

    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            SelectedRowCollection SelectedRow = ucChooseEmployee1.SelectedRow;
            List<DAL.DM_GiaoVienDaoTao> lists = new List<DAL.DM_GiaoVienDaoTao>();
            DaoTaoController daoTaoController = new DaoTaoController();
            HoSoController dmcbController = new HoSoController();

            string str = string.Empty;
            foreach (var item in SelectedRow)
            {
                DAL.HOSO employee = dmcbController.GetByMaCB(item.RecordID);
                if (daoTaoController.IsDuplicateMaGiaoVien(employee.MA_CB) == false)
                {
                    DAL.DM_GiaoVienDaoTao gv = new DAL.DM_GiaoVienDaoTao()
                    { // new DanhMucChucVuController().GetNameByPrimaryKey(employee.MA_CHUCVU),
                        CreatedBy = CurrentUser.ID,
                        CreatedDate = DateTime.Now,
                        DiaChiLienHe = employee.DIA_CHI_LH,
                        DiDong = employee.DI_DONG,
                        DonViCongTac = new DM_DONVIController().GetNameById(employee.MA_DONVI),
                        DTCoQuan = employee.DT_CQUAN, 
                        GioiTinh = employee.MA_GIOITINH == "M" ? true : false,
                        HocVan = new DM_TRINHDOController().GetNameByPrimaryKey(employee.MA_TRINHDO),
                        HoTenGV = employee.HO_TEN,
                        KinhNghiemGiangDay = string.Empty,
                        LaNhanvienCty = true,
                        MA_DONVI = employee.MA_DONVI,
                        MaGV = employee.MA_CB,
                        NgaySinh = employee.NGAY_SINH,
                        NhanXet = string.Empty,
                    };
                    if (employee.DM_CHUCVU!=null)
                    {
                        gv.ChucVu = employee.DM_CHUCVU.TEN_CHUCVU;
                    }
                    if (!string.IsNullOrEmpty(employee.EMAIL) && !string.IsNullOrEmpty(employee.EMAIL_RIENG))
                    {
                        gv.Email = employee.EMAIL + " ; " + employee.EMAIL_RIENG;
                    }
                    else if (!string.IsNullOrEmpty(employee.EMAIL))
                    {
                        gv.Email = employee.EMAIL;
                    }
                    else if (!string.IsNullOrEmpty(employee.EMAIL_RIENG))
                    {
                        gv.Email = employee.EMAIL_RIENG;
                    }
                    lists.Add(gv);
                }
                else
                {
                    str += employee.HO_TEN + "(" + item.RecordID + "), ";
                }
            }

            daoTaoController.CopyCanBoToGiaoVienDaoTao(lists);
       //     grp_DanhSachGiangVien.ReloadStore();
            if (!string.IsNullOrEmpty(str))
                Dialog.ShowNotification(string.Format("Đã thêm thành công! Một số nhân viên đã tồn tại bao gồm: {0}", str.Substring(0, str.Length - 2)));
            else
                Dialog.ShowNotification("Thông báo","Đã thêm thành công");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
}