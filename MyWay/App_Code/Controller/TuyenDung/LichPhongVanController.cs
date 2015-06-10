using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
///huynhndse
/// </summary>
public class LichPhongVanController : LinqProvider
{
    public LichPhongVanController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    // xoa lịch hẹn phỏng vấn theo mã lịch hẹn
    public void Delete(int id)
    {
        DAL.LichHenPhongVan temp = dataContext.LichHenPhongVans.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.LichHenPhongVans.DeleteOnSubmit(temp);
            Save();
        }
    }
    // dời lịch hẹn phỏng vấn, cập nhật vòng thi, lịch hẹn và thứ tự phỏng vấn
    public DataTable GetById(string id)
    {
       return  DataController.DataHandler.GetInstance().ExecuteDataTable("Tuyendung_LichHenPV_GetByID", "@ID", id);
    
    
    }
    public void DoiLichHenPhongVan(int id, int vong, int thutu, DateTime lichhen)
    {

        DataController.DataHandler.GetInstance().ExecuteNonQuery("Tuyendung_DoiLichHenPhongVan", "@ID", "@Vong",
            "@ThuTu", "@LichHen", id, vong, thutu, lichhen);
    }
    public void InsertByHoSoUngVien(DAL.LichHenPhongVan lichhenphongvan)
    {
        if (lichhenphongvan != null)
        {
            dataContext.LichHenPhongVans.InsertOnSubmit(lichhenphongvan);
            Save();
        }
    }
    public void RoiLichPV(DAL.LichHenPhongVan lichhenphongvan)
    {
        DAL.LichHenPhongVan temp = dataContext.LichHenPhongVans.SingleOrDefault(t => t.ID == lichhenphongvan.ID);
        if (temp != null)
        {
            temp.CreatedBy = lichhenphongvan.CreatedBy;
            temp.CreatedDate = lichhenphongvan.CreatedDate;
            //temp.DaLienHe = lichhenphongvan.DaLienHe;
            //temp.DaThamGia = lichhenphongvan.DaThamGia;
            //temp.Diem = lichhenphongvan.Diem;
            temp.GhiChu = lichhenphongvan.GhiChu;
            temp.ID = lichhenphongvan.ID;
            temp.LichHen = lichhenphongvan.LichHen;
            temp.FR_KEY = lichhenphongvan.FR_KEY;
            //temp.NguoiCham = lichhenphongvan.NguoiCham;
            //temp.NhanXet = lichhenphongvan.NhanXet;
            //temp.Pass = lichhenphongvan.Pass;
            temp.ThoiGian = lichhenphongvan.ThoiGian;
            temp.ThuTuPhongVan = lichhenphongvan.ThuTuPhongVan;
            //temp.VongPhongVan = lichhenphongvan.VongPhongVan;
            //temp.XacNhanThamGia = lichhenphongvan.XacNhanThamGia;
            Save();
        }
    }

}