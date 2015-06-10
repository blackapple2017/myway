using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachBangTongHopCongController
/// </summary>
namespace Controller.ChamCongDoanhNghiep
{
    public class DanhSachBangTongHopCongController : LinqProvider
    {
        public DanhSachBangTongHopCongController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Insert(DAL.DanhSachBangTongHopCong bang)
        {
            if (bang != null)
            {
                dataContext.DanhSachBangTongHopCongs.InsertOnSubmit(bang);
                Save();
            }
            return bang.ID;
        }


        public DAL.DanhSachBangTongHopCong GetById(int id)
        {
            var rs = from t in dataContext.DanhSachBangTongHopCongs
                     where t.ID == id
                     select t;
            return rs.FirstOrDefault();
        }

        public void Update(DAL.DanhSachBangTongHopCong bang)
        {
            var tmp = dataContext.DanhSachBangTongHopCongs.SingleOrDefault(t => t.ID == bang.ID);
            if (tmp != null)
            {
                tmp.CreatedBy = bang.CreatedBy;
                tmp.CreatedDate = bang.CreatedDate;
                tmp.Lock = bang.Lock;
                tmp.MaDonVi = bang.MaDonVi;
                tmp.Title = bang.Title;
                tmp.Thang = bang.Thang;
                tmp.Nam = bang.Nam;
                tmp.KindOfTimeSheetBoard = bang.KindOfTimeSheetBoard;
                Save();
            }
        }

        public void Delete(int id)
        {
            var tmp = dataContext.DanhSachBangTongHopCongs.SingleOrDefault(t => t.ID == id);
            if (tmp != null)
            {
                dataContext.DanhSachBangTongHopCongs.DeleteOnSubmit(tmp);
                Save();
            }
        }

        public DAL.DanhSachBangTongHopCong GetByInfo(string maBoPhan, int thang, int nam)
        {
            var rs = from t in dataContext.DanhSachBangTongHopCongs
                     where t.MaDonVi == maBoPhan && t.Thang == thang && t.Nam == nam
                     select t;
            return rs.SingleOrDefault();
        }
        /// <summary>
        /// Danh sách các bảng tổng hợp đông
        /// @Lê Anh
        /// </summary>
        /// <param name="madonvi"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<DanhSachBangTongHopCongInfo> GetTimeSheetBoardList(int start, int limit, string searchkey, string sessionDepartment, out int count)
        {
            var rs = (from t in dataContext.DanhSachBangTongHopCongs
                      where (searchkey == "" || System.Data.Linq.SqlClient.SqlMethods.Like(t.Title, searchkey)) &&
                      (string.IsNullOrEmpty(sessionDepartment) || t.MaDonVi == sessionDepartment)
                      orderby t.Nam descending, t.Thang descending
                      select new DanhSachBangTongHopCongInfo
                      {
                          ID = t.ID,
                          Lock = t.Lock,
                          DaKhoa = t.Lock == true ? "Đã khóa" : "Chưa khóa",
                          MaDonVi = t.MaDonVi,
                          Nam = t.Nam,
                          Thang = t.Thang,
                          Title = t.Title,
                          CreatedDate = t.CreatedDate
                      }).ToList();
            count = rs.Count;
            return rs.Skip(start).Take(limit).ToList();
        }
        public List<DanhSachBangTongHopCongInfo> GetTimeSheetBoardListByMonthYear(int start, int limit, string searchkey, string sessionDepartment, int month, int year, out int count)
        {
            var rs = (from t in dataContext.DanhSachBangTongHopCongs
                      let date = new DateTime(t.Nam, t.Thang, 1)
                      where (searchkey == "" || System.Data.Linq.SqlClient.SqlMethods.Like(t.Title, searchkey)) &&
                      (string.IsNullOrEmpty(sessionDepartment) || t.MaDonVi == sessionDepartment)
                      && (t.Thang == month || month == 0) && (t.Nam == year || year ==0)
                      orderby date descending
                      select new DanhSachBangTongHopCongInfo
                      {
                          ID = t.ID,
                          Lock = t.Lock,
                          DaKhoa = t.Lock == true ? "Đã khóa" : "Chưa khóa",
                          MaDonVi = t.MaDonVi,
                          Nam = t.Nam,
                          Thang = t.Thang,
                          Title = t.Title,
                          CreatedDate = t.CreatedDate
                      }).ToList();
            count = rs.Count;
            return rs.Skip(start).Take(limit).ToList();
        }
    }
}