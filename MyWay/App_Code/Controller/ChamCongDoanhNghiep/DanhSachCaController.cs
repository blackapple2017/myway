using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// daibx   17/08/2013
/// Summary description for DanhSachCaController
/// </summary>
namespace Controller.ChamCongDoanhNghiep
{
    public class DanhSachCaController : LinqProvider
    {
        public DanhSachCaController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DAL.DanhSachCa GetByPrkey(int prkey)
        {
            var rs = from t in dataContext.DanhSachCas
                     where t.ID == prkey
                     select t;
            return rs.FirstOrDefault();
        }

        public List<DAL.DanhSachCa> GetByMaCa(string maCa)
        {
            var rs = from t in dataContext.DanhSachCas
                     where t.MaCa == maCa
                     select t;
            return rs.ToList();
        }
        /// <summary>
        /// Đức anh, lấy 1 ca từ mã ca
        /// </summary>
        /// <param name="maCa"></param>
        /// <returns></returns>
        public DAL.DanhSachCa GetOneByMaCa(string maCa)
        {
            return (from t in dataContext.DanhSachCas
                    where t.MaCa == maCa
                    select t).FirstOrDefault();
        }
        /// <summary>
        /// Thống kê mỗi mã ca có bao nhiêu dòng
        /// </summary>
        /// <returns></returns>
        public List<ThongKeObject> GetNumberRowInMaCa(out int max)
        {
            var rs = from t in dataContext.DanhSachCas
                     group t by new
                     {
                         t.MaCa
                     }
                         into grouped
                         select new ThongKeObject
                         {
                             TenDoiTuong = grouped.Key.MaCa,
                             SoLuong = grouped.Count()
                         };
            max = rs.Max(t => t.SoLuong);
            return rs.ToList();
        }

        /// <summary>
        /// Sửa dụng cho combobox search ca làm việc
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="query"></param>
        /// <param name="count">Tổng số lượng bản ghi</param>
        /// <returns></returns>
        public List<DanhSachCaInfo> MiniGetAll(int start, int limit, string query, string maDonVi, out int count)
        {
            string[] dsDonVi = new DM_DONVIController().GetAllMaDonVi(maDonVi).Split(',');
            var rs = (from t in dataContext.DanhSachCas
                      where (string.IsNullOrEmpty(query) || System.Data.Linq.SqlClient.SqlMethods.Like(t.TenCa, query) || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaCa, query))
                        //&& dsDonVi.Contains(t.MaDonVi)
                      select new DanhSachCaInfo
                      {
                          ID = t.ID,
                          MaCa = t.MaCa,
                          TenCa = t.TenCa,
                          GioVao = t.GioVao,
                          GioRa = t.GioRa
                      }).ToList();
            count = rs.Count;
            return rs.OrderBy(t => t.TenCa).Skip(start).Take(limit).ToList();
        }


        public List<DanhSachCaInfo> MiniGetAll(string maDonVi)
        {
            string[] dsDonVi = new DM_DONVIController().GetAllMaDonVi(maDonVi).Split(',');
            var rs = (from t in dataContext.DanhSachCas
                      where dsDonVi.Contains(t.MaDonVi)
                      select new DanhSachCaInfo
                      {
                          ID = t.ID,
                          MaCa = t.MaCa,
                          TenCa = t.TenCa,
                          GioVao = t.GioVao,
                          GioRa = t.GioRa
                      }).ToList();
            return rs.OrderBy(t => t.TenCa).ToList();
        }

        public IEnumerable<DanhSachCaInfo> GetByMaDonVi(string maDonVi)
        {
            var rs = (from t in dataContext.DanhSachCas
                      where t.MaDonVi == maDonVi
                      select new DanhSachCaInfo
                      {
                          ID = t.ID,
                          MaCa = t.MaCa,
                          TenCa = t.TenCa,
                          GioVao = t.GioVao,
                          GioRa = t.GioRa
                      }).ToList();
            return rs.OrderBy(t => t.TenCa);
        }

        /// <summary>
        /// Sử dụng lấy dữ liệu cho GridPanel
        /// </summary>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="maDV"></param>
        /// <param name="searchKey"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<DanhSachCaInfo> GetAll(int start, int limit, string maDV, string searchKey, out int count)
        {
            var rs = (from t in dataContext.DanhSachCas
                      join p in dataContext.ThamSoTrangThais on t.LoaiCa equals p.ID into tmp1
                      from t1 in tmp1.DefaultIfEmpty()
                      where t.MaDonVi == maDV
                         && (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.MaCa, searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.TenCa, searchKey))
                      select new DanhSachCaInfo
                      {
                          BatDauQuetTheLan1 = t.BatDauQuetTheLan1,
                          BatDauQuetTheLan2 = t.BatDauQuetTheLan2,
                          BatDauQuetTheLan3 = t.BatDauQuetTheLan3,
                          BatDauQuetTheLan4 = t.BatDauQuetTheLan4,
                          BatDauTinhLamThemCuoiGio = t.BatDauTinhLamThemCuoiGio,
                          BatDauTinhLamThemDauGio = t.BatDauTinhLamThemDauGio,
                          CreatedBy = t.CreatedBy,
                          CreatedDate = t.CreatedDate,
                          DangSuDung = t.DangSuDung,
                          GioRa = t.GioRa,
                          GioVao = t.GioVao,
                          ID = t.ID,
                          KetThucQuetTheLan1 = t.KetThucQuetTheLan1,
                          KetThucQuetTheLan2 = t.KetThucQuetTheLan2,
                          KetThucQuetTheLan3 = t.KetThucQuetTheLan3,
                          KetThucQuetTheLan4 = t.KetThucQuetTheLan4,
                          LoaiCa = t1.Value,
                          MaCa = t.MaCa,
                          MaDonVi = t.MaDonVi,
                          NgayApDung = t.NgayApDung,
                          NghiGiuaCa = t.NghiGiuaCa,
                          PhuCapCa = t.PhuCapCa,
                          RaNgoaiKhongBiTruGio = t.RaNgoaiKhongBiTruGio,
                          SoPhutChoPhepDiMuon = t.SoPhutChoPhepDiMuon,
                          SoPhutChoPhepVeSom = t.SoPhutChoPhepVeSom,
                          TenCa = t.TenCa,
                          ThoiGianApDungDen = t.ThoiGianApDungDen,
                          ThoiGianApDungTu = t.ThoiGianApDungTu,
                          TienLuongCa = t.TienLuongCa,
                          TongGio = t.TongGio,
                          VaoGiuaCa = t.VaoGiuaCa
                      }).OrderByDescending(t => t.CreatedDate).ToList();
            count = rs.Count;
            return rs.OrderBy(t => t.MaCa).Skip(start).Take(limit).ToList();

        }

        public void Insert(DAL.DanhSachCa dsc)
        {
            if (dsc != null)
            {
                dataContext.DanhSachCas.InsertOnSubmit(dsc);
                Save();
            }
        }

        public void Update(DAL.DanhSachCa dsc)
        {
            DAL.DanhSachCa tmp = dataContext.DanhSachCas.SingleOrDefault(t => t.ID == dsc.ID);
            if (tmp != null)
            {
                tmp.ID = dsc.ID;
                tmp.MaCa = dsc.MaCa;
                tmp.TenCa = dsc.TenCa;
                tmp.GioVao = dsc.GioVao;
                tmp.GioRa = dsc.GioRa;
                tmp.NgayApDung = dsc.NgayApDung;
                tmp.LoaiCa = dsc.LoaiCa;
                tmp.NghiGiuaCa = dsc.NghiGiuaCa;
                tmp.VaoGiuaCa = dsc.VaoGiuaCa;
                tmp.SoPhutChoPhepDiMuon = dsc.SoPhutChoPhepDiMuon;
                tmp.SoPhutChoPhepVeSom = dsc.SoPhutChoPhepVeSom;
                tmp.BatDauTinhLamThemDauGio = dsc.BatDauTinhLamThemDauGio;
                tmp.BatDauTinhLamThemCuoiGio = dsc.BatDauTinhLamThemCuoiGio;
                tmp.PhuCapCa = dsc.PhuCapCa;
                tmp.TienLuongCa = dsc.TienLuongCa;
                tmp.RaNgoaiKhongBiTruGio = dsc.RaNgoaiKhongBiTruGio;
                tmp.MaDonVi = dsc.MaDonVi;
                tmp.BatDauQuetTheLan1 = dsc.BatDauQuetTheLan1;
                tmp.BatDauQuetTheLan2 = dsc.BatDauQuetTheLan2;
                tmp.BatDauQuetTheLan3 = dsc.BatDauQuetTheLan3;
                tmp.BatDauQuetTheLan4 = dsc.BatDauQuetTheLan4;
                tmp.KetThucQuetTheLan1 = dsc.KetThucQuetTheLan1;
                tmp.KetThucQuetTheLan2 = dsc.KetThucQuetTheLan2;
                tmp.KetThucQuetTheLan3 = dsc.KetThucQuetTheLan3;
                tmp.KetThucQuetTheLan4 = dsc.KetThucQuetTheLan4;
                tmp.DangSuDung = dsc.DangSuDung;
                tmp.CreatedBy = dsc.CreatedBy;
                tmp.CreatedDate = dsc.CreatedDate;
                tmp.TongGio = dsc.TongGio;
                Save();
            }
        }

        public void DeleteByMaCa(string maCa)
        {
            //DAL.DanhSachCa tmp = dataContext.DanhSachCas.Where(t => t.MaCa == maCa).FirstOrDefault();
            DAL.DanhSachCa tmp = dataContext.DanhSachCas.SingleOrDefault(t => t.MaCa == maCa);
            if (tmp != null)
            {
                dataContext.DanhSachCas.DeleteOnSubmit(tmp);
                Save();
            }
        }

        public void DeleteByID(int prkey)
        {
            //DAL.DanhSachCa tmp = dataContext.DanhSachCas.Where(t => t.ID == prkey).FirstOrDefault();
            DAL.DanhSachCa tmp = dataContext.DanhSachCas.SingleOrDefault(t => t.ID == prkey);
            if (tmp != null)
            {
                dataContext.DanhSachCas.DeleteOnSubmit(tmp);
                Save();
            }
        }

        public DAL.DanhSachCa GetByMaChamCong(string maChamCong, DateTime day, string maDonVi)
        {
            string type = string.Empty;
            DAL.DieuKienChamCong dkcc = new DieuKienChamCongController().GetByParamName(DieuKienChamCongController.CHAMCONG_PHANCA_TYPE, maDonVi);
            if (dkcc != null)
                type = dkcc.Value;
            List<string> listMaCa = new List<string>();

            if (type == DieuKienChamCongController.PHANCA_TYPE_THANG)
            {
                // lấy dữ liệu bảng phân ca tháng theo mã chấm công và ngày chấm công
                DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_GetBangCaThangByMaChamCong", "@MaChamCong", "@Ngay", maChamCong, day);
                if (table.Rows.Count == 0)
                    return null;
                string columnName = "Ngay";
                if (day.Day < 10)
                    columnName += "0" + day.Day;
                else
                    columnName += "" + day.Day;
                // lấy các mã ca mà cán bộ đã đăng ký trong ngày
                foreach (DataRow item in table.Rows)
                {
                    if (!string.IsNullOrEmpty(item[columnName].ToString()))
                    {
                        listMaCa.Add(item[columnName].ToString());
                    }
                }
            }
            else if (type == DieuKienChamCongController.PHANCA_TYPE_BOPHAN)
            {
                DAL.ThietLapCaTheoBoPhan thietLap = new ThietLapCaTheoBoPhanController().GetThietLapByMaChamCong(maChamCong);
                DayOfWeek dayOfWeek = day.DayOfWeek;
                switch (dayOfWeek)
                {
                    // ngày thường
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        listMaCa.Add(thietLap.MaCa);
                        break;

                    // ngày thứ 7
                    case DayOfWeek.Saturday:
                        listMaCa.Add(thietLap.MaCaThu7);
                        break;

                    // ngày chủ nhật
                    case DayOfWeek.Sunday:
                        listMaCa.Add(thietLap.MaCaChuNhat);
                        break;
                }
            }

            var rs = from t in dataContext.DanhSachCas
                     where listMaCa.Contains(t.MaCa)
                     select t;
            return rs.FirstOrDefault();
        }
    }
}