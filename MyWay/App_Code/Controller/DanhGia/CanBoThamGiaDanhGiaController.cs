
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
    public class CanBoThamGiaDanhGiaController
    {
        public DataTable GetByPrkey(int pr_key)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("GetCanBoThamGiaDanhGiaByPrkey", "@ID", pr_key);
        }

        public void DeleteByPrkey(int pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteCanBoThamGiaDanhGiaByPrkey", "@ID", pr_key);
        }

        public void DeleteByMaDotDanhGia(string maDotDanhGia)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DanhGia_DeleteCanBoThamGiaDanhGiaByMaDotDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public int Insert(CanBoThamGiaDanhGiaInfo record)
        {
            return int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("InsertCanBoThamGiaDanhGia", "@MaDotDanhGia", "@MaCBDanhGia", "@MaCBBiDanhGia", "@CreatedDate", "@CreatedBy", record.MaDotDanhGia, record.MaCBDanhGia, record.MaCBBiDanhGia, record.CreatedDate, record.CreatedBy).ToString());
        }

        public void Update(CanBoThamGiaDanhGiaInfo record)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateCanBoThamGiaDanhGia", "@ID", "@MaDotDanhGia", "@MaCBDanhGia", "@MaCBBiDanhGia", "@CreatedDate", "@CreatedBy", record.ID, record.MaDotDanhGia, record.MaCBDanhGia, record.MaCBBiDanhGia, record.CreatedDate, record.CreatedBy);
        }

        public DataTable GetByMaDotDanhGia(string maDotDanhGia)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoThamGiaDanhGia", "@MaDotDanhGia", maDotDanhGia);
        }

        public bool CheckExistMaCBThamGiaDanhGia(string macbBiDanhGia, string macbThamGiaDanhGia, string maDotDanhGia)
        {
            var tmp = DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetCanBoThamGiaDanhGiaByMaCB", "@MaCBBiDanhGia", "@MaCBThamGiaDanhGia", "@MaDotDanhGia", macbBiDanhGia, macbThamGiaDanhGia, maDotDanhGia);
            if (tmp.Rows.Count == 0)
                return false;
            if (tmp.Rows[0]["ID"].ToString() == "")
                return false;
            else
                return true;
        }
    }
}
