using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for KetQuaThiTuyenController
/// </summary>
/// 
// HUYNHNDSE
public class KetQuaThiTuyenController : LinqProvider
{
    public KetQuaThiTuyenController()
    {
        //
        // TODO: Add constructor logic here
        //
    } 
    // lay cac mon thi tyuen
    public DataTable LayCacMonThiTuyen(int planid)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_Lay_CacMonThiTuyen", "@PlanID", planid);   
    }
    public DataTable GetAll(decimal maUngVien, decimal maVongPV)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("TuyenDung_LayKetQuaThiTuyen", "@MaUngVien", "@MaVongPV", maUngVien, maVongPV);
    }

    public void Delete(int id)
    {

        DAL.KetQuaThiTuyen temp = dataContext.KetQuaThiTuyens.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.KetQuaThiTuyens.DeleteOnSubmit(temp);
            Save();
        }
    
    }
    public void Insert(DAL.KetQuaThiTuyen kqtt)
    {
        if (kqtt != null)
        {
            dataContext.KetQuaThiTuyens.InsertOnSubmit(kqtt);
            Save();
        }
    }
    public void Update(DAL.KetQuaThiTuyen kqtt)
    {
        DAL.KetQuaThiTuyen temp = dataContext.KetQuaThiTuyens.SingleOrDefault(t => t.ID == kqtt.ID);
        if (temp != null)
        {
            temp.CreatedBy = kqtt.CreatedBy;
            temp.CreatedDate = kqtt.CreatedDate;
            temp.Diem = kqtt.Diem;
            temp.NguoiChamThi = kqtt.NguoiChamThi;
            temp.ID = kqtt.ID;            
            temp.MaMonThi = kqtt.MaMonThi;
            temp.FR_KEY = kqtt.FR_KEY;
            //temp.MaVongPhongVan = kqtt.MaVongPhongVan;
            temp.NgayThiTuyen = kqtt.NgayThiTuyen;
            temp.NhanXet = kqtt.NhanXet;
            temp.VongThi = kqtt.VongThi;
            Save();
        }
    }

    public void XoaKetQuaTheoMaUngVien(string maUV)
    {

        DataController.DataHandler.GetInstance().ExecuteNonQuery("TuyenDung_Delete_KetQuaTdByMaUV", "@MaUV", maUV);
    }
    /// <summary>
}