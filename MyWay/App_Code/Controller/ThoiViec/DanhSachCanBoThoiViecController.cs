using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataController;
using Entity.ThoiViec;

namespace Controller.ThoiViec
{
    /// <summary>
    /// Created by Lê Văn Anh
    /// </summary>
    public class DanhSachCanBoThoiViecController : LinqProvider
    {
        public DAL.DanhSachCanBoThoiViec GetByID(int id)
        {
            var rs = from t in dataContext.DanhSachCanBoThoiViecs
                     where t.ID == id
                     select t;
            return rs.FirstOrDefault();
        }
        /// <summary>
        /// ThienDL
        /// </summary>
        /// <param name="MaLyDo">Mã lý do</param>
        /// <returns>Tên lý do</returns>
        public string LayTenLyDoNghi(string maLyDo)
        {
            object objTenLyDo = DataHandler.GetInstance().ExecuteScalar("ThoiViec_LayLyDoThoiViec", "@MaLyDo", maLyDo);
            if (objTenLyDo != null)
            {
                return objTenLyDo.ToString();
            }
            else
            {
                return "";
            }
        }
        public IEnumerable<DanhSachCanBoThoiViecInfo> GetAll(int start, int limit, string maDonVi, string searchKey, int tinhTrang, string daTraThe, int daTraSo, int hoanTatCongNo, int banGiaoTaiSan, int userID, int menuID, out int count)
        {
            // get role
            string[] departmentList = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(',');
            string[] dsDonVi = new DM_DONVIController().GetAllMaDonVi(maDonVi).Split(',');
            var rs = from t in dataContext.DanhSachCanBoThoiViecs
                     let isHoanTatCongNo = (from ts in dataContext.BangTamUngs where ts.PrKeyHoSo == t.PrKeyHoSo && ts.SoTienDaTra < ts.SoTien select ts).ToList().Count > 0 ? 0 : 1
                     let isBanGiaoTaiSan = (from ts in dataContext.HOSO_TAISANs where ts.FR_KEY == t.PrKeyHoSo && (ts.NgayBanGiao == null || ts.NgayBanGiao.ToString().Contains("1900") || ts.NgayBanGiao.ToString().Contains("0001")) select ts).ToList().Count > 0 ? 0 : 1
                     join lydoNghi in dataContext.DM_LYDO_NGHIs on t.MaLyDoNghi equals lydoNghi.MA_LYDO_NGHI into j1
                     from j2 in j1.DefaultIfEmpty()
                     where (dsDonVi.Contains(t.HOSO.MA_DONVI) || maDonVi == "")
                      && (System.Data.Linq.SqlClient.SqlMethods.Like(t.HOSO.HO_TEN, searchKey) || string.IsNullOrEmpty(searchKey) ||
                      System.Data.Linq.SqlClient.SqlMethods.Like(t.HOSO.MA_CB, searchKey))
                      && (t.DaHoanThanhThuTuc == (tinhTrang == 1 ? true : false) || tinhTrang == -1)
                      && ((string.IsNullOrEmpty(daTraThe) || System.Data.Linq.SqlClient.SqlMethods.Like(t.DaTraTheBHYT, daTraThe)))
                      && (t.DaTraSoBHXH == (daTraSo == 1 ? true : false) || daTraSo == -1)
                         // && (hoanTatCongNo == -1 || hoanTatCongNo == isHoanTatCongNo)
                      && (banGiaoTaiSan == -1 || banGiaoTaiSan == isBanGiaoTaiSan)
                      && (departmentList.Count() == 0 || departmentList.Contains(t.HOSO.MA_DONVI))
                     select new DanhSachCanBoThoiViecInfo
                     {
                         DaHoanThanhThuTuc = t.DaHoanThanhThuTuc,
                         ID = t.ID,
                         FrKeyHoSo = t.PrKeyHoSo,
                         DaTraSoBHXH = t.DaTraSoBHXH,
                         DaTraTheBHYT = t.DaTraTheBHYT,
                         HoTen = t.HOSO.HO_TEN,
                         LyDoNghi = j2.TEN_LYDO_NGHI,
                         MaCB = t.HOSO.MA_CB,
                         NgayHoanThanhThuTuc = t.NgayHoanThanhThuTuc,
                         NgayTraSoBHXH = t.NgayTraSo,
                         NgayTraTheBHYT = t.NgayTraThe,
                         HoanTatCongNo = isHoanTatCongNo == 1 ? true : false,
                         BanGiaoTaiSan = isBanGiaoTaiSan == 1 ? true : false,
                         PhongBan = (from tp in dataContext.HOSOs join p in dataContext.DM_DONVIs on tp.MA_DONVI equals p.MA_DONVI where tp.PR_KEY == t.PrKeyHoSo select p.TEN_DONVI).FirstOrDefault(),
                         NgayNghi = t.NgayNghi,
                         IsBelongToBlackList = t.IsBelongToBlackList,
                         DiaChiLienHe = t.HOSO.DIA_CHI_LH,
                         Email = t.HOSO.EMAIL,
                         DiDong = t.HOSO.DI_DONG,
                         ChucVu = t.HOSO.DM_CHUCVU.TEN_CHUCVU,
                         ViTriCongViec = t.HOSO.DM_CONGVIEC.TEN_CONGVIEC,
                         NgaySinh = t.HOSO.NGAY_SINH,
                         GioiTinh = t.HOSO.MA_GIOITINH,
                         NgayLamChinhThuc = t.HOSO.NGAY_TUYEN_CHINHTHUC,
                         NgayThuViec = t.HOSO.NGAY_TUYEN_DTIEN,
                         CanBoDuyetNghi = t.HOSO1.HO_TEN,
                         Photo = t.HOSO.PHOTO,
                         SoQuyetDinh = t.SoQuyetDinh,
                         AttachFile = string.IsNullOrEmpty(t.AttachFile) ? "" : t.AttachFile,
                         GhiChu = t.GhiChu,
                     };
            count = rs.Count();
            return rs.Skip(start).Take(limit);
        }

        public int Insert(DAL.DanhSachCanBoThoiViec thoiViec)
        {
            dataContext.DanhSachCanBoThoiViecs.InsertOnSubmit(thoiViec);
            Save();
            return thoiViec.ID;
        }

        public void UpdateThuTuc(DAL.DanhSachCanBoThoiViec thoiViec)
        {
            DAL.DanhSachCanBoThoiViec tv = dataContext.DanhSachCanBoThoiViecs.Where(t => t.ID == thoiViec.ID).SingleOrDefault();
            if (tv != null)
            {
                tv.NgayNghi = thoiViec.NgayNghi;
                tv.MaLyDoNghi = thoiViec.MaLyDoNghi;
                tv.DaTraTheBHYT = thoiViec.DaTraTheBHYT;
                tv.NgayTraThe = thoiViec.NgayTraThe;
                tv.DaTraSoBHXH = thoiViec.DaTraSoBHXH;
                tv.NgayTraSo = thoiViec.NgayTraSo;
                tv.FrCBDuyetNghi = thoiViec.FrCBDuyetNghi;
                tv.NgayHoanThanhThuTuc = thoiViec.NgayHoanThanhThuTuc;
                tv.IsBelongToBlackList = thoiViec.IsBelongToBlackList;
                tv.MaLyDoBiHanChe = thoiViec.MaLyDoBiHanChe;
                tv.DaHoanThanhThuTuc = thoiViec.DaHoanThanhThuTuc;
                tv.AttachFile = thoiViec.AttachFile;
                tv.GhiChu = thoiViec.GhiChu;
                tv.SoQuyetDinh = thoiViec.SoQuyetDinh;
                Save();
            }
        }

        public void Delete(int id)
        {
            DAL.DanhSachCanBoThoiViec tv = dataContext.DanhSachCanBoThoiViecs.Where(t => t.ID == id).SingleOrDefault();
            if (tv != null)
            {
                dataContext.DanhSachCanBoThoiViecs.DeleteOnSubmit(tv);
                Save();
            }
        }

        public List<DAL.ThamSoTrangThai> GetByParamName(string paramName, string maDV)
        {
            var rs = from t in dataContext.ThamSoTrangThais
                     where t.ParamName == paramName && t.MaDonVi == maDV
                     select t;
            return rs.ToList();
        }

        public void UpdateNghiViecHoSo(DAL.HOSO hs)
        {
            DAL.HOSO hoso = dataContext.HOSOs.Where(t => t.PR_KEY == hs.PR_KEY).FirstOrDefault();
            if (hoso != null)
            {
                hoso.DA_NGHI = hs.DA_NGHI;
                hoso.NGAY_NGHI = hs.NGAY_NGHI;
                hoso.MA_LYDO_NGHI = hs.MA_LYDO_NGHI;
                Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prKey">Khóa chính của bảng DanhSachCanBoTHoiViec</param>
        /// <returns></returns>
        public decimal GetHoSoPrimaryKey(int prKey)
        {
            DAL.DanhSachCanBoThoiViec item = dataContext.DanhSachCanBoThoiViecs.FirstOrDefault(p => p.ID == prKey);
            if (item != null)
            {
                return item.PrKeyHoSo;
            }
            return 0;
        }

        public DAL.DanhSachCanBoThoiViec GetByPrkeyHoSo(decimal prkeyHoSo)
        {
            var rs = from t in dataContext.DanhSachCanBoThoiViecs
                     where t.PrKeyHoSo == prkeyHoSo
                     select t;
            return rs.FirstOrDefault();
        }
    }
}