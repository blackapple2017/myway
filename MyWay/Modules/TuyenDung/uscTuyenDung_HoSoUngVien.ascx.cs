using DataController;
using Ext.Net;
using ExtMessage;
using SoftCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_TuyenDung_uscTuyenDung_HoSoUngVien : System.Web.UI.UserControl
{
    string type = "";

    //sự kiện sau khi update thì reload lại gridpanel
    public event EventHandler AfterUpdate;
    protected void Page_Load(object sender, EventArgs e)
    { 
        hdfType.Reset();
        if (Request.QueryString["type"] == "blacklist")
        {
            type = "black";
        }
        else
        {
            if (Request.QueryString["type"] == "store")
            {
                type = "store";
            }
            else
            {
                type = "";
                cbx_LyDo.Visible = false;
            }
        }
        hdfType.SetValue(type);
        df_ngaysinh.MinDate = Convert.ToDateTime("1900-01-01");
        df_ngaycapcmnd.MinDate = Convert.ToDateTime("1900-01-01");
        df_ngaynophs.MinDate = Convert.ToDateTime("1900-01-01");
        df_ngaycapcmnd.MaxDate = DateTime.Now;
        df_ngaynophs.MaxDate = DateTime.Now;
        df_ngaysinh.MaxDate = DateTime.Now;
        DataTable dsKhaNang = DataHandler.GetInstance().ExecuteDataTable("TuyenDung_getDanhSachKhaNang","@MaDonVi",Session["MaDonVi"].ToString());       
        if (dsKhaNang.Rows.Count > 0)
        {
            for (int i = 0; i < dsKhaNang.Rows.Count; i++)
            {
                mcb_KhaNang.Items.Add(new Ext.Net.ListItem(dsKhaNang.Rows[i]["Text"].ToString(), dsKhaNang.Rows[i]["ID"].ToString())); 
            }
        }
    }
    protected void btnUpdateImage_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //upload file
            HttpPostedFile file = fufUploadControl.PostedFile;
            string path = string.Empty;
            hdfImageFolder.SetValue("~/Modules/TuyenDung/AttachFile");
            if (fufUploadControl.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Modules/TuyenDung/AttachFile")); ;
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath(hdfImageFolder.Text + "/" + fufUploadControl.FileName);
                    file.SaveAs(path);
                    //update ảnh vào csdl
                    //  hdfUploadedImage.Text = hdfImageFolder.Text + "/" + fufUploadControl.FileName;                   
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
            wdUploadImageWindow.Hide();

            //Hiển thị lại ảnh sau khi đã cập nhật xong
            anhdaidien.ImageUrl = hdfImageFolder.Text + "/" + fufUploadControl.FileName;
            if (Equals(hdfAnhDaiDien.Text, "hsuv"))
            {
                DataHandler.GetInstance().ExecuteNonQuery("UPDATE TuyenDung.HoSoUngVien SET Anh = '" + hdfImageFolder.Text + "/" + fufUploadControl.FileName + "' WHERE MaUngVien = " + decimal.Parse("0" + hdfRecordID.Text));
                if (AfterUpdate != null)
                {
                    AfterUpdate(sender, e);
                }
                fufUploadControl.Reset();
                hdfImageFolder.Reset();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }
    protected void mcb_KhaNangStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            //mcb_KhaNangStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_KHANANG,TEN_KHANANG from DM_KHANANG");
            //mcb_KhaNangStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Cảnh báo", ex.Message);
        }
    }
    protected void cbx_trinhdo_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        cbx_trinhdo_Store.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TRINHDO,TEN_TRINHDO from DM_TRINHDO");
        cbx_trinhdo_Store.DataBind();
    }
    protected void cbx_tt_honnhanstore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_tt_honnhanstore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TT_HN,TEN_TT_HN from DM_TT_HN");
            cbx_tt_honnhanstore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    protected void cbx_tt_suckhoestore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_tt_suckhoestore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TT_SUCKHOE,TEN_TT_SUCKHOE from DM_TT_SUCKHOE");
            cbx_tt_suckhoestore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void cbx_trinhdovanhoastore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_trinhdovanhoastore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TD_VANHOA,TEN_TD_VANHOA from DM_TD_VANHOA");
            cbx_trinhdovanhoastore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void cbx_trinhdongoaingustore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_trinhdongoaingustore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_NGOAINGU,TEN_NGOAINGU from DM_NGOAINGU");
            cbx_trinhdongoaingustore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    protected void cbx_trinhdotinhocstore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            cbx_trinhdotinhocstore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select MA_TINHOC,TEN_TINHOC from DM_TINHOC");
            cbx_trinhdotinhocstore.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }
    protected void cbx_LyDoStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            string s = "";
            if (Equals(type, "black"))
            {
                s += "LyDoDuaVaoDanhSachHanChe";
            }
            else
            {
                s += "LyDoDuaVaoKho";
            }
            cbx_LyDoStore.DataSource = DataHandler.GetInstance().ExecuteDataTable("select ID, Value from dbo.ThamSoTrangThai where ParamName = '" + s + "' AND IsInUsed = 1");
            cbx_LyDoStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }


    protected void btn_UpdateUngVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            SoftCore.Util util = new Util();
            LinqProvider linq = new LinqProvider();
            HoSoUngVienController hosoungvien = new HoSoUngVienController();
            DAL.HoSoUngVien hsuv = new DAL.HoSoUngVien();
            if (string.IsNullOrEmpty(fufUploadControl.FileName) == false)
                hsuv.Anh = hdfImageFolder.Text + "/" + fufUploadControl.FileName;
            hsuv.Ten = txt_tenungvien.Text;
            // lấy họ và đệm từ họ tên
            int position = hsuv.Ten.LastIndexOf(' ');
            if (position == -1)
            {
                hsuv.Ten = hsuv.Ten;
            }
            else
            {
                hsuv.Ten = txt_tenungvien.Text.Substring(position + 1).Trim();
                hsuv.HoDem = txt_tenungvien.Text.Remove(position).Trim();
            }
            hsuv.MaUngVien = decimal.Parse("0" + hdfRecordID.Text.ToString());
            hsuv.SoCMT = txt_socmnd.Text.Replace("-", "");
            hsuv.SoCMT = hsuv.SoCMT.Trim();
            hsuv.HoTen = txt_tenungvien.Text.Trim();
            if (!util.IsDateNull(df_ngaysinh.SelectedDate))
                hsuv.NgaySinh = df_ngaysinh.SelectedDate;
            hsuv.GioiTinh = cbx_gioitinh.SelectedItem.Value;
            hsuv.HoKhauThuongTru = txt_hokhau.Text.Trim();
            hsuv.NoiSinh = txt_noisinh.Text.Trim();
            hsuv.MaTinhTrangHonNhan = hdfTinhTrangHN.Text;
            hsuv.MaTinhTrangSucKhoe = hdfTinhTrangSK.Text;
            hsuv.MaQuocTich = hdfQuocTich.Text;
            hsuv.DiDong = txt_didong.Text;
            if (!df_ngaycapcmnd.SelectedDate.ToString().Contains("0001"))
                hsuv.NgayCapCMT = df_ngaycapcmnd.SelectedDate;
            hsuv.MaTinhThanh = hdfTinhThanh.Text;
            hsuv.MaDanToc = hdfDanToc.Text;
            hsuv.Email = txt_email.Text.Trim();
            hsuv.MaTonGiao = hdfTonGiao.Text;
            hsuv.NoiCapCMT = hdfNoiCapCMND.Text;
            hsuv.DiaChiLienHe = txt_diachilhe.Text.Trim();
            hsuv.KinhNghiem = txt_kinhnghiem.Text.Trim();
            hsuv.MucLuongMongMuon = decimal.Parse("0" + txt_mucluongmongmuon.Text.Trim());
            hsuv.MucLuongToiThieu = decimal.Parse("0" + txt_mucluongtoithieu.Text.Trim());
            hsuv.MaTrinhDoVH = hdfTrinhDoVanHoa.Text;
            hsuv.MaTrinhDoTinHoc = hdfTrinhDoTinHoc.Text;
            hsuv.MaTrinhDoNgoaiNgu = hdfTrinhDoNgoaiNgu.Text;
            hsuv.MaChuyenNganh = hdfChuyenNganh.Text;
            hsuv.MaTruongDaoTao = hdfTruongDaoTao.Text;
            hsuv.MaTrinhDoHocVan = hdfTrinhDo.Text;
            hsuv.MaViTriCongViec = hdfCongViec.Text;
            hsuv.SoThich = txt_sothich.Text.Trim();
            hsuv.UuDiem = txt_uudiem.Text.Trim();
            hsuv.NhuocDiem = txt_nhuocdiem.Text.Trim();
            hsuv.BlackListOrStore = "";
            hsuv.MaLyDo = int.Parse("0" + hdfLyDo.Text);
            hsuv.MaDotTuyenDung = int.Parse("0" + hdfDotTuyenDung.Text);
            hsuv.DTCoDinh = txt_dienthoaicodinh.Text.Trim();
            hsuv.NhomMau = hdfNhomMau.Text;
            hsuv.ChieuCao = txt_chieucao.Text.Trim();
            hsuv.CanNang = txt_cannang.Text.Trim();
            hsuv.GhiChu = txt_ghichu.Text.Trim();
            hsuv.NguoiLienHeTrongTruongHopKhanCap = txt_nguoilienhe.Text.Trim();
            hsuv.DienThoaiNguoiLienHe = txt_sdtnguoilh.Text.Trim();
            hsuv.DiaChiNguoiLienHe = txt_diachinguoilienhe.Text.Trim();
            hsuv.EmailNguoiLienHe = txt_emailnguoilh.Text.Trim();
            hsuv.QuanHeVoiUngVien = txt_MoiQH.Text.Trim();
            //["67","KN"]            
            string _khanang = mcb_KhaNang.SelectedItems.ValuesToJsonArray();
            string[] split = _khanang.Split(new Char[] { '[', ']', ' ', '"' });
            _khanang = "";
            foreach (string s in split)
            {

                if (s.Trim() != "")
                    _khanang += s;
            }
            hsuv.MaKhaNang = _khanang;
            if (!util.IsDateNull(df_ngaycothedilam.SelectedDate))
                hsuv.NgayCoTheDiLam = df_ngaycothedilam.SelectedDate;
            if (Equals(type, "black"))
            {
                hsuv.BlackListOrStore = "black";
            }
            else
            {
                if (Equals(type, "store"))
                {
                    hsuv.BlackListOrStore = "store";
                }
            }
            if (!df_ngaynophs.SelectedDate.ToString().Contains("0001"))
                hsuv.NgayNopHS = df_ngaynophs.SelectedDate;
            if (int.Parse("0" + DataHandler.GetInstance().ExecuteScalar("KiemTraTonTaiCMND", "@maungvien", "@cmnd", hsuv.MaUngVien, hsuv.SoCMT).ToString()) == 1)
            {
                X.Msg.Alert("Có lỗi dữ liệu xảy ra", "Đã tồn tại số Chứng minh nhân dân trong Danh sách Hồ sơ nhân sự").Show();
                txt_socmnd.Focus();
            }
            else
            {
                if (int.Parse("0" + DataHandler.GetInstance().ExecuteScalar("KiemTraTonTaiCMND", "@maungvien", "@cmnd", hsuv.MaUngVien, hsuv.SoCMT).ToString()) == 2)
                {
                    X.Msg.Alert("Có lỗi dữ liệu xảy ra", "Đã tồn tại số Chứng minh nhân dân trong Danh sách ứng viên").Show();
                    txt_socmnd.Focus();
                }
                else
                {
                    if (e.ExtraParams["Command"] == "Edit")
                    {
                        hosoungvien.Update(hsuv);
                        wdAddUngVien.Hide();
                        Dialog.ShowNotification("Cập nhật dữ liệu thành công!");
                    }
                    else
                    {
                        hosoungvien.Insert(hsuv);
                        X.Js.Call("ResetWdAddUngVien");
                        Dialog.ShowNotification("Thêm mới thành công!");
                    }

                    if (e.ExtraParams["Close"] == "True")
                    {
                        wdAddUngVien.Hide();
                    }
                    // reload
                    if (AfterUpdate != null)
                    {
                        AfterUpdate(sender, e);
                    }
                }
            }
        }
        catch (SqlException sql)
        {
            X.Msg.Alert("Có lỗi dữ liệu xảy ra", sql.Message).Show();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

}