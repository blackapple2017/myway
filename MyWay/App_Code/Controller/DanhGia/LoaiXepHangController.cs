using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Bùi Xuân Đại
/// </summary>
namespace Controller.DanhGia
{
    public class LoaiXepHangController : LinqProvider
    {
        public DataTable GetByPrkey(int pr_key)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("GetDM_LOAIXEPHANGByPrkey", "@MaXepHang", pr_key);
        }

        public void DeleteByPrkey(int pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteDM_LOAIXEPHANGByPrkey", "@MaXepHang", pr_key);
        }

        public void DeleteByParentID(int parentID)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("delete estimate.DM_LOAIXEPHANG where ParentID = " + parentID);
        }

        public DataTable GetAllRecord(int start, int limit, string searchKey, string maDV, int maLoaiXH, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountDM_LOAIXEPHANG", "@searchKey", "@MaDonVi", "@MaLoaiXH", searchKey, maDV, maLoaiXH).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectDM_LOAIXEPHANG", "@start", "@limit", "@searchKey", "@MaDonVi", "@MaLoaiXH", start, limit, searchKey, maDV, maLoaiXH);
        }

        public int Insert(DM_LOAIXEPHANGInfo record)
        {
            return int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("InsertDM_LOAIXEPHANG", "@KiHieuXepHang", "@TenXepHang", "@ParentID", "@GhiChu", "@MaDonVi", "@TuDiem", "@DenDiem", record.KiHieuXepHang, record.TenXepHang, record.ParentID, record.GhiChu, record.MaDonVi, record.TuDiem, record.DenDiem).ToString());
        }

        public void Update(DM_LOAIXEPHANGInfo record)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateDM_LOAIXEPHANG", "@MaXepHang", "@KiHieuXepHang", "@TenXepHang", "@ParentID", "@GhiChu", "@MaDonVi", "@TuDiem", "@DenDiem", record.MaXepHang, record.KiHieuXepHang, record.TenXepHang, record.ParentID, record.GhiChu, record.MaDonVi, record.TuDiem, record.DenDiem);
        }

        public DataTable GetByParentID(int parentID, string maDonVi)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("select * from estimate.DM_LOAIXEPHANG where ParentID = " + parentID + " and (LEN('" + maDonVi + "') = 0 or MaDonVi = '" + maDonVi + "')");
        }

        public DataTable GetByParentIDWithoutMe(int parentID, string maDonVi, int id)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("select * from estimate.DM_LOAIXEPHANG where ParentID = " + parentID + " and (LEN('" + maDonVi + "') = 0 or MaDonVi = '" + maDonVi + "') and (MaXepHang <> " + id + " or MaXepHang = -1)");
        }

        public DataTable GetAllParent(string maDonVi)
        {
            string sql = "select * from estimate.DM_LOAIXEPHANG where ParentID = -1 and (LEN('" + maDonVi + "') = 0 or MaDonVi = '" + maDonVi + "')";
            return DataController.DataHandler.GetInstance().ExecuteDataTable(sql);
        }

        public DataTable GetByMaDotDanhGia(string maDotDanhGia)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetXepHangByMaDotDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public DAL.DM_LOAIXEPHANG GetByKyHieuXepHang(string kyHieu)
        {
            return dataContext.DM_LOAIXEPHANGs.SingleOrDefault(t => t.KiHieuXepHang == kyHieu);
        }
    }
}
