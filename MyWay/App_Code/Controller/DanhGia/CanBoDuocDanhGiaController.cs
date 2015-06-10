
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
    public class CanBoDuocDanhGiaController : LinqProvider
    {
        //public DataTable GetByPrkey(int pr_key)
        //{
        //    return DataController.DataHandler.GetInstance().ExecuteDataTable("GetCanBoDuocDanhGiaByPrkey", "@ID", pr_key);
        //}
        public DAL.CanBoDuocDanhGia GetByPrkey(int pr_key)
        {
            var rs = from t in dataContext.CanBoDuocDanhGias
                     where t.ID == pr_key
                     select t;
            return rs.FirstOrDefault();
        }

        public void DeleteByPrkey(int pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteCanBoDuocDanhGiaByPrkey", "@ID", pr_key);
        }

        public void DeleteByMaDotDanhGia(string maDotDanhGia)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DanhGia_DeleteCanBoBiDanhGiaByMaDotDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public int Insert(CanBoDuocDanhGiaInfo record)
        {
            return int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("InsertCanBoDuocDanhGia", "@MaCB", "@MaDotDanhGia", "@CreatedDate", "@CreatedBy", record.MaCB, record.MaDotDanhGia, record.CreatedDate, record.CreatedBy).ToString());
        }

        public void Update(CanBoDuocDanhGiaInfo record)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateCanBoDuocDanhGia", "@ID", "@MaCB", "@MaDotDanhGia", "@CreatedDate", "@CreatedBy", record.ID, record.MaCB, record.MaDotDanhGia, record.CreatedDate, record.CreatedBy);
        }

        public DataTable GetByMaDotDanhGia(string maDotDanhGia)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoDuocDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public DataTable GetAllRecord(int start, int limit, string maDotDanhGia, int createdBy, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountCanBoBiDanhGiaByAll", "@MaDotDanhGia", "@CreatedBy", maDotDanhGia, createdBy).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoBiDanhGiaByAll", "@Start", "@Limit", "@MaDotDanhGia", "@CreatedBy", start, limit, maDotDanhGia, createdBy);
        }

        public DataTable GetAllCanBoTuDanhGia(int start, int limit, string maCB, string maDotDanhGia, int createdBy, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountCanBoBiDanhGia_TuDanhGia", "@MaCB", "@MaDotDanhGia", "@CreatedBy", maCB, maDotDanhGia, createdBy).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoBiDanhGia_TuDanhGia", "@Start", "@Limit", "@MaCB", "@MaDotDanhGia", "@CreatedBy", start, limit, maCB, maDotDanhGia, createdBy);
        }

        public DataTable GetAllCanBoNormal(int start, int limit, string maDotDanhGia, string maBoPhan, string maCB, int createdBy, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountCanBoBiDanhGia_Normal", "@MaDotDanhGia", "@MaBoPhan", "@MaCB", "@CreatedBy", maDotDanhGia, maBoPhan, maCB, createdBy).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoBiDanhGia_Normal", "@Start", "@Limit", "@MaDotDanhGia", "@MaBoPhan", "@MaCB", "@CreatedBy", start, limit, maDotDanhGia, maBoPhan, maCB, createdBy);
        }

        /// <summary>
        /// Kiểm tra một cán bộ đã tồn tại trong danh sách hay chưa
        /// </summary>
        /// <param name="macb">Mã cán bộ</param>
        /// <returns><b>true</b> nếu cán bộ tồn tại, <b>false</b> nếu chưa tồn tại</returns>
        public bool CheckExistMaCBDuocDanhGia(string macb, string maDotDanhGia)
        {
            var tmp = DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoDuocDanhGiaByMaCB", "@MA_CB", "@MaDotDanhGia", macb, maDotDanhGia);
            if (tmp.Rows.Count == 0)
                return false;
            if (tmp.Rows[0]["ID"].ToString() == "")
                return false;
            else
                return true;
        }
    }
}
