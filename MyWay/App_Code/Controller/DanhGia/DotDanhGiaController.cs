
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
    public class DotDanhGiaController : LinqProvider
    {
        public DAL.DotDanhGia GetByPrkey(string pr_key)
        {
            return dataContext.DotDanhGias.Where(t => t.ID == pr_key).FirstOrDefault();
        }

        public void DeleteByPrkey(string pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteDotDanhGiaByPrkey", "@ID", pr_key);
        }

        public DataTable GetAllRecord(int start, int limit, string searchKey, string MaDonVi, string trangThai, bool isGetAll, decimal prkeyQL, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountDotDanhGia", "@searchKey", "@MaDonVi", "@TrangThaiDanhGia", "@IsGetAll", "@PrkeyQL", searchKey, MaDonVi, trangThai, isGetAll, prkeyQL).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectDotDanhGia", "@start", "@limit", "@searchKey", "@MaDonVi", "@TrangThaiDanhGia", "@IsGetAll", "@PrkeyQL", start, limit, searchKey, MaDonVi, trangThai, isGetAll, prkeyQL);
        }

        public void Insert(DAL.DotDanhGia record)
        {
            dataContext.DotDanhGias.InsertOnSubmit(record);
            Save();
        }

        public List<DotDanhGiaInfo> GetByYear(int year)
        {
            var rs = from t in dataContext.DotDanhGias
                     where t.TuNgay.HasValue && t.TuNgay.Value.Year == year
                     select new DotDanhGiaInfo
                     {
                         ID = t.ID,
                         TenDotDanhGia = t.TenDotDanhGia,
                         TuNgay = t.TuNgay,
                         DenNgay = t.DenNgay,
                         MaDonVi = t.MaDonVi
                     };
            return rs.ToList();
        }

        public DataTable GetDotDanhGiaTuDanhGia(int start, int limit, string maCB, string maDonVi, string trangThai, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountDotDanhGia_TuDanhGia", "@MaDonVi", "@MaCB", "@TrangThaiDanhGia", maDonVi, maCB, trangThai).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetDotDanhGia_TuDanhGia", "@start", "@limit", "@MaDonVi", "@MaCB", "@TrangThaiDanhGia", start, limit, maDonVi, maCB, trangThai);
        }

        public DataTable GetDotDanhGiaNormal(int start, int limit, string maCB, string maDonVi, string trangThai, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("DanhGia_CountDotDanhGia_Normal", "@MaDonVi", "@MaCB", "@TrangThaiDanhGia", maDonVi, maCB, trangThai).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("DanhGia_GetDotDanhGia_Normal", "@start", "@limit", "@MaDonVi", "@MaCB", "@TrangThaiDanhGia", start, limit, maDonVi, maCB, trangThai);
        }

        public void Update(DAL.DotDanhGia record)
        {
            DAL.DotDanhGia tmp = dataContext.DotDanhGias.Where(t => t.ID == record.ID).FirstOrDefault();
            if (tmp != null)
            {
                tmp.PrkeyCanBoQuanLy = record.PrkeyCanBoQuanLy;
                tmp.TenDotDanhGia = record.TenDotDanhGia;
                tmp.TrangThaiDanhGia = record.TrangThaiDanhGia;
                tmp.HinhThucDanhGia = record.HinhThucDanhGia;
                tmp.TuNgay = record.TuNgay;
                tmp.DenNgay = record.DenNgay;
                tmp.GhiChu = record.GhiChu;
                tmp.TL_TuDanhGia = record.TL_TuDanhGia;
                tmp.TL_QuanLyDanhGia = record.TL_QuanLyDanhGia;
                tmp.TL_NguoiKhacDanhGia = record.TL_NguoiKhacDanhGia;
                tmp.MaLoaiXepHang = record.MaLoaiXepHang;
            }
            Save();
        }

        public DAL.DotDanhGia GetNewestDotDanhGia()
        {
            var rs = from t in dataContext.DotDanhGias
                     orderby t.CreatedDate descending
                     select t;
            return rs.FirstOrDefault();
        }

        public DAL.DotDanhGia GetNewestDotDanhGiaTHDG(string maDonVi, string maCB)
        {
            var rs = from t in dataContext.DotDanhGias
                     join p in dataContext.CanBoDuocDanhGias on t.ID equals p.MaDotDanhGia into tmp1

                     from tp in tmp1
                     where (string.IsNullOrEmpty(maDonVi) || t.MaDonVi == maDonVi)
                        && (tp.MaCB == maCB && t.HinhThucDanhGia == 0)
                        || (tp.MaCB == maCB && (t.HinhThucDanhGia == 1 || t.HinhThucDanhGia == 2))
                     select t;
            return rs.FirstOrDefault();
        }

        public List<DAL.DotDanhGia> GetDotDanhGiaByYear(int year)
        {
            var rs = from t in dataContext.DotDanhGias
                     where t.TuNgay.Value.Year == year
                     select t;
            return rs.ToList();
        }

        public List<ThongKeObject> GetYearsHaveDotDanhGia()
        {
            var rs = from t in dataContext.DotDanhGias
                     let year = t.TuNgay.Value.Year
                     select new ThongKeObject()
                     {
                         TenDoiTuong = year.ToString(),
                         SoLuong = year
                     };
            return rs.Distinct().ToList();
        }
    }
}
