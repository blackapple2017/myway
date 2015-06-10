using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;
using System.Data;
using DataController;
using Controller.ThoiViec;
// huynhndse
public partial class Modules_TuyenDung_LichHenPhongVan : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //df_NgayPhongVan.MinDate = DateTime.Now;
        //dfNgayThiTuyen.MaxDate = DateTime.Now;
        //df_NgayPhongVan.SetValue(DateTime.Now);
        //dfNgayThiTuyen.SetValue(DateTime.Now);
    }
   
    //protected void mnDoiLichHenPV_Click(object sender, DirectEventArgs e)
    //{
    //   LichPhongVanController lichhenController=new LichPhongVanController();
    //    DataTable lichTAble = new DataTable();
    //    lichTAble = lichhenController.GetById(hdfIDLichHen.Text);
    //    txtRoiLich_ThuTuPhongVan.Text = lichTAble.Rows[0]["ThuTuPhongVan"].ToString();
    //    txtRoiLich_VongThi.Text = lichTAble.Rows[0]["VongPhongVan"].ToString();
    //    DateTime lichhen = Convert.ToDateTime(lichTAble.Rows[0]["LichHen"]);
    //    dfRoiLich_NgayThi.Value = lichhen;
    //    numfGio.Text = lichhen.Hour.ToString();
    //    numfPhut.Text = lichhen.Minute.ToString();
    //    txtRoiLich_VongThi.ReadOnly = true;

  
    //}
    protected void mnXoaLichHenPV_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //foreach (var item in RowSelectionModel1.SelectedRows)
            //{
            //    new LichPhongVanController().Delete(int.Parse("0" + item.RecordID));
            //}
            //btnDelete.Disabled = true;
            //btnThoiGian.Disabled = true;
            //btnChamDiemNX.Disabled = true;
            //btnPrint.Disabled = true;
            //GridPanel1.Reload();
            //GridPanel2.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void btn_ChuyenLichHenPV_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //LichPhongVanController lichphongvan = new LichPhongVanController();
            //DAL.LichHenPhongVan lpv = new DAL.LichHenPhongVan();            
            //foreach (var item in RowSelectionModel1.SelectedRows)
            //{
            //    lpv.ID = decimal.Parse("0" + item.RecordID);
            //    lpv.FR_KEY = decimal.Parse("0"+hdfMaUngVien.Text);
            //    lpv.CreatedBy = CurrentUser.ID;
            //    lpv.CreatedDate = DateTime.Now;
            //    lpv.LichHen = df_NgayPhongVan.SelectedDate;
            //    lpv.ThoiGian = tf_GioPhongVan.Text;
            //    lpv.ThuTuPhongVan = int.Parse("0" + txt_ThuTuPhongVan.Text);
            //    lpv.GhiChu = txt_ghichu.Text;
            //    lichphongvan.RoiLichPV(lpv);                
            //}
            //btnDelete.Disabled = true;
            //btnThoiGian.Disabled = true;
            //btnPrint.Disabled = true;
            //btnChamDiem.Disabled = true;
            //wdChuyenLichHenPV.Hide();
            //GridPanel1.Reload();
            //GridPanel2.Reload();
            //Dialog.ShowNotification("Cập nhật thành công!");
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Thông báo", "Có lỗi xảy ra: " + ex.Message);
        }
    }
    protected void btnRoiLichThi_Click(object sender, DirectEventArgs e)
    {
            //// oke click
            //int idLichHen = Convert.ToInt32(hdfIDLichHen.Text);
            //int vongthi = Convert.ToInt32(txtRoiLich_VongThi.Value.ToString());
            //int thutuphongvan = Convert.ToInt32(txtRoiLich_ThuTuPhongVan.Text);
            //DateTime ngaythi = Convert.ToDateTime(dfRoiLich_NgayThi.Value);
            //DateTime lichhen = new DateTime(ngaythi.Year, ngaythi.Month, ngaythi.Day, Convert.ToInt32(numfGio.Text), Convert.ToInt32(numfPhut.Text), 0);
            //LichPhongVanController lhController = new LichPhongVanController();
            //lhController.DoiLichHenPhongVan(idLichHen, vongthi, thutuphongvan, lichhen);
            //GridPanel1.Reload();
            //wdRoiLich.Hide();//
     }
    protected void btnXoaKetQua_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //new KetQuaThiTuyenController().Delete(int.Parse("0" + hdfIDKetQuaThi.Text));
            //btnXoaKetQua.Disabled = true;
            //btnSuaKetQua.Disabled = true;
            //GridPanel2.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
    public void CheckDaThoiViec(object sender, DirectEventArgs e)
    {
        try
        {
            //if (cbb_NguoiChamThi.SelectedItem == null)
            //{
            //    X.MessageBox.Alert("Thông báo", "Không tìm thấy cán bộ");
            //    return;
            //}
            //decimal prkeyHoSo = decimal.Parse(cbb_NguoiChamThi.SelectedItem.Value);
            //DAL.DanhSachCanBoThoiViec tv = new DanhSachCanBoThoiViecController().GetByPrkeyHoSo(prkeyHoSo);
            //if (tv != null) // exist in DanhSachCanBoThoiViec
            //{
            //    // alert to user
            //    X.Msg.Confirm("Xác nhận", "Cán bộ được chọn nằm trong danh sách cán bộ đã thôi việc. Bạn có muốn tiếp tục?", new MessageBoxButtonsConfig
            //    {
            //        Yes = new MessageBoxButtonConfig
            //        {
            //            Handler = "Ext.net.DirectMethods.DoYes()",
            //            Text = "Đồng ý"
            //        },
            //        No = new MessageBoxButtonConfig
            //        {
            //            Handler = "Ext.net.DirectMethods.DoNo()",
            //            Text = "Đóng lại"
            //        }
            //    }).Show();
            //}
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message);
        }
    }
    protected void btnChamDiem_Click(object sender, DirectEventArgs e)
    {
     
        try
        {
            //KetQuaThiTuyenController kqttControl = new KetQuaThiTuyenController();
            //DAL.KetQuaThiTuyen kqthi = new DAL.KetQuaThiTuyen();           
            //kqthi.FR_KEY = decimal.Parse("0"+hdfMaUngVien.Text);
            //kqthi.MaMonThi = Convert.ToInt32(cboMonThi.Value);
            //kqthi.VongThi = int.Parse("0" + txt_VongPhongVan.Text);
            //kqthi.MaVongPhongVan = decimal.Parse("0"+hdfVongPV.Text);
            //kqthi.Diem = float.Parse(txtDiemSo.Value.ToString());
            //kqthi.NhanXet = txtNhanXet.Text;
            //kqthi.NguoiChamThi = decimal.Parse("0" + hdfNguoiChamThi.Text);
            //kqthi.CreatedDate = DateTime.Now;
            //kqthi.NgayThiTuyen = Convert.ToDateTime(dfNgayThiTuyen.Value);
            //kqthi.CreatedBy = CurrentUser.ID;
            //bool ketqua = true;
            //if (kqthi.Diem >= float.Parse(hdfDiemDat.Text))
            //{
            //    ketqua = true;
            //}
            //else
            //{
            //    ketqua = false;
            //}

            ////string kiemtra = hdfTrangThaiLuaChon.Text;// trạng thái lựa chọn để biết là update or insert 
            //if (Equals(hdfTrangThaiLuaChon.Text, "edit"))
            //{
            //    kqthi.ID = Convert.ToInt32(hdfIDKetQuaThi.Text);
            //    kqthi.KetQua = ketqua;
            //    // đã tồn tại, update                           
            //    kqttControl.Update(kqthi);
            //}
            //else
            //{
            //    if (Equals(hdfTrangThaiLuaChon.Text, "add"))
            //    {
            //        kqthi.KetQua = ketqua;
            //        //chưa tồn tại Insert
            //        kqttControl.Insert(kqthi);
            //    }
            //}
            //GridPanel2.Reload();
            //wdChamDiemNhanXet.Hide(); 
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        } 
    } 
}