
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Controller.DanhGia
{
    /// <summary>
    /// Bùi Xuân Đại
    /// </summary>
    public class KetQuaDanhGiaController : LinqProvider
    {
        public DataTable GetByPrkey(int pr_key)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("GetKetQuaDanhGiaByPrkey", "@ID", pr_key);
        }

        public void DeleteByPrkey(int pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteKetQuaDanhGiaByPrkey", "@ID", pr_key);
        }

        public int Insert(DAL.KetQuaDanhGia record)
        {
            dataContext.KetQuaDanhGias.InsertOnSubmit(record);
            Save();
            return record.ID;
        }

        public void Update(KetQuaDanhGiaInfo record)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateKetQuaDanhGia", "@ID", "@MaCB", "@Diem", "@IdTieuChi_DotDanhGia", "@NhanXet", "@CreatedDate", "@CreatedBy", "@IsQuanLyDanhGia", record.ID, record.MaCB, record.Diem, record.IdTieuChi_DotDanhGia, record.NhanXet, record.CreatedDate, record.CreatedBy, record.IsQuanLyDanhGia);
        }

        public void UpdateNhanXetByID(int id, string nhanxet)
        {
            DAL.KetQuaDanhGia tmp = dataContext.KetQuaDanhGias.Where(t => t.ID == id).FirstOrDefault();
            if (tmp != null)
            {
                tmp.NhanXet = nhanxet;
                Save();
            }
        }

        public DataTable GetAllRecord(string maDotDanhGia, int start, int limit, string searchKey, string maDV, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountKetQuaDanhGiaTongHop", "@MaDotDanhGia", "@SearchKey", maDotDanhGia, searchKey).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectKetQuaDanhGiaTongHop", "@MaDotDanhGia", "@Start", "@Limit", "@SearchKey", maDotDanhGia, start, limit, searchKey);
        }

        public void DeleteByIdTieuChi_DotDanhGia(int idTieuChi_DotDanhGia)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DanhGia_DeleteKetQuaDGByIdTieuChi_DotDanhGia", "@IdTieuChi_DotDanhGia", idTieuChi_DotDanhGia);
        }

        public DAL.KetQuaDanhGia GetByMaCBvaIdTieuChiDotDanhGia(string maCB, int idTieuChiDotDanhGia)
        {
            var rs = from t in dataContext.KetQuaDanhGias
                     where t.MaCB == maCB && t.IdTieuChi_DotDanhGia == idTieuChiDotDanhGia
                     select t;
            return rs.FirstOrDefault();
        }

        public void DeleteByMaCBvaIdTieuChiDotDanhGia(string maCB, int idTieuChiDotDanhGia)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery(string.Format("Delete estimate.KetQuaDanhGia where MaCB = '{0}' and IdTieuChi_DotDanhGia = {1}", maCB, idTieuChiDotDanhGia));
        }

        public DAL.KetQuaDanhGia GetKetQuaByMaCBandMaDotDanhGia(string maCB, string maDotDanhGia, string maTieuChi, int currentUserID)
        {
            var rs = from t in dataContext.KetQuaDanhGias
                     join p in dataContext.TieuChi_DotDanhGias on t.IdTieuChi_DotDanhGia equals p.ID
                     where p.MaDotDanhGia == maDotDanhGia && t.MaCB == maCB && t.CreatedBy == currentUserID && p.MaTieuChi == maTieuChi
                     select t;
            return rs.FirstOrDefault();
        }

        public DataTable GetChiTietKetQuaDanhGia(int start, int limit, string maDotDanhGia, string maCB, string searchKey, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountChiTietKetQuaDanhGia", "@MaDotDanhGia", "@MaCB", "@SearchKey", maDotDanhGia, maCB, searchKey).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetChiTietKetQuaDanhGia", "@Start", "@Limit", "@MaDotDanhGia", "@MaCB", "@SearchKey", start, limit, maDotDanhGia, maCB, searchKey);
        }

        public DataTable GetDSCanBoDanhGiaMotCanBo(string maDotDanhGia, string maCB)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetDanhSachCanBoDanhGia", "@MaDotDanhGia", "@MaCB", maDotDanhGia, maCB);
        }

        public List<UserMiniInfo> GetManagerEmployee(string maDotDanhGia, string maCanBo)
        {
            var rs = from kq in dataContext.KetQuaDanhGias
                     join tp2 in dataContext.TieuChi_DotDanhGias on kq.IdTieuChi_DotDanhGia equals tp2.ID into tmp2
                     from tcd in tmp2.DefaultIfEmpty()
                     join tp1 in dataContext.Users on kq.CreatedBy equals tp1.ID into tmp1
                     from u in tmp1.DefaultIfEmpty()
                     where tcd.MaDotDanhGia == maDotDanhGia && kq.MaCB == maCanBo && kq.Diem > 0
                     select new UserMiniInfo
                     {
                         DisplayName = u.DisplayName,
                         ID = kq.CreatedBy
                     };
            return rs.ToList();
        }
    }
}
