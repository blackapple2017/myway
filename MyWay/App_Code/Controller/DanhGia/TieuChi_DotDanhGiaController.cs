
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
    public class TieuChi_DotDanhGiaController : LinqProvider
    {
        public DataTable GetByPrkey(int pr_key)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("GetTieuChi_DotDanhGiaByPrkey", "@ID", pr_key);
        }

        public void DeleteByPrkey(int pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteTieuChi_DotDanhGiaByPrkey", "@ID", pr_key);
        }

        public void DeleteByMaTCandMaDotDG(string maTieuChi, string maDotDanhGia)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DanhGia_DeleteTieuChi_DotDanhGiaByMaTCandMaDDG", "@MaTieuChi", "@MaDotDanhGia", maTieuChi, maDotDanhGia);
        }

        public void DeleteByMaDotDanhGia(string maDotDanhGia)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DanhGia_DeleteTieuChiDanhGiaByMaDotDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public int Insert(TieuChi_DotDanhGiaInfo record)
        {
            return int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("InsertTieuChi_DotDanhGia", "@MaTieuChi", "@MaDotDanhGia", "@CreatedDate", "@CreatedBy", record.MaTieuChi, record.MaDotDanhGia, record.CreatedDate, record.CreatedBy).ToString());
        }

        public DataTable GetByMaDotDanhGia(int start, int limit, string maDotDanhGia, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountDanhSachDotDanhGia_TieuChi", "@MaDotDanhGia", maDotDanhGia).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetDanhSachDotDanhGia_TieuChi", "@Start", "@Limit", "@MaDotDanhGia", start, limit, maDotDanhGia);
        }

        public DataTable GetByMaDotDanhGia(string maDotDanhGia)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetTieuChiByMaDotDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public DataTable GetTieuChiDanhGiaByMaCB(int start, int limit, string maCB, string maDotDanhGia, int createdBy, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountTieuChiDanhGiaByMaCB", "@MaCB", "@MaDotDanhGia", "@CreatedBy", maCB, maDotDanhGia, createdBy).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetTieuChiDanhGiaByMaCB", "@Start", "@Limit", "@MaCB", "@MaDotDanhGia", "@CreatedBy", start, limit, maCB, maDotDanhGia, createdBy);
        }

        public bool CheckExistTieuChi_DotDanhGia(string maTieuChi, string maDotDanhGia)
        {
            var tmp = DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetTieuChi_DotDanhGiaByMaTCandMaDDG", "@MaTieuChi", "@MaDotDanhGia", maTieuChi, maDotDanhGia);
            if (tmp.Rows.Count == 0)
                return false;
            if (tmp.Rows[0]["ID"].ToString() == "")
                return false;
            else
                return true;
        }

        public List<DAL.TieuChi_DotDanhGia> GetByMaCanBo(string maCB)
        {
            string maDotDanhGia = (from t in dataContext.CanBoDuocDanhGias
                                   where t.MaCB == maCB
                                   select t).FirstOrDefault().MaDotDanhGia;
            var rs = from t in dataContext.TieuChi_DotDanhGias
                     where t.MaDotDanhGia == maDotDanhGia
                     select t;
            return rs.ToList();
        }

        public DAL.TieuChi_DotDanhGia GetByMaDotDanhGiavaMaTieuChi(string maDotDanhGia, string maTieuChi)
        {
            var rs = from t in dataContext.TieuChi_DotDanhGias
                     where t.MaDotDanhGia == maDotDanhGia && t.MaTieuChi == maTieuChi
                     select t;
            return rs.FirstOrDefault();
        }

        public List<DAL.TieuChiDanhGia> GetTieuChiDanhGiaByMaDotDanhGia(string maDotDanhGia)
        {
            var rs = from t in dataContext.TieuChi_DotDanhGias
                     join p in dataContext.TieuChiDanhGias on t.MaTieuChi equals p.MaNhom
                     where t.MaDotDanhGia == maDotDanhGia
                     select p;
            return rs.ToList();
        }
    }
}