using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExtMessage;

/// <summary>
/// Summary description for DAOTAOController
/// </summary>
public class DaoTaoController : LinqProvider
{
    public DaoTaoController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void ThemGiaoVienVaoKhoaHoc(DAL.GiaoVien_KhoaDaoTao gvdt)
    {
        dataContext.GiaoVien_KhoaDaoTaos.InsertOnSubmit(gvdt);
        Save();
    }

    public IEnumerable<CacKhoanChiPhiInfo> GetCacKhoanChiPhi(string maKhoaHoc)
    {
        var rs = from t in dataContext.DM_CacKhoanChiChoDaoTaos
                 where t.FR_KEY == maKhoaHoc
                 select new CacKhoanChiPhiInfo
                 {
                     MaKeHoach = t.FR_KEY,
                     ID = t.ID,
                     NguonChi = t.NguonChi,
                     SoTien = t.SoTien,
                     TenChiPhi = t.TenChiPhi
                 };
        return rs;
    }
    public DAL.KHOA_DAOTAO GetByMaKhoaDaoTao(string maKhoaDaoTao)
    {
        return dataContext.KHOA_DAOTAOs.FirstOrDefault(t => t.MA_KHOA == maKhoaDaoTao);
    }
    public IEnumerable<KhoaDaoTaoInfo> GetAllKhoaDaoTao()
    {
        var rs = from t in dataContext.KHOA_DAOTAOs
                 select new KhoaDaoTaoInfo
                 {
                     PR_KEY = t.MA_KHOA,
                     TenKhoaDaoTao = t.TEN_KHOAHOC
                 };
        return rs;
    }

    public DAL.DM_CacKhoanChiChoDaoTao GetChiPhiDaoTaoByID(int ID)
    {
        return dataContext.DM_CacKhoanChiChoDaoTaos.FirstOrDefault(t => t.ID == ID);
    }

    /// <summary>
    /// Kiểm tra đã tồn tại điểm hoặc kết quả của một cán bộ trong một khóa đào tạo hay không
    /// </summary>
    /// <param name="maCB">Mã cán bộ cần kiểm tra</param>
    /// <param name="maKhoaDT">Mã khóa đào tạo cần kiểm tra</param>
    /// <returns><b>true</b> nếu đã tồn tại kết quả. <b>false</b> nếu chưa tồn tại kết quả</returns>
    public bool CheckExistResult(int id)
    {
        var rs = from t in dataContext.DM_NhanVienThamGiaDaoTaos
                 where t.ID == id
                    && (t.SoDiem != null || t.KetQua != null)
                 select t;
        return rs.ToList().Count == 0;
    }

    public IEnumerable<GiaoVienThamGiaDaoTaoInfo> GetGiaoVienDaoTaoByMaKhoaDaoTao(string maKhoaDaoTao)
    {
        var rs = from t in dataContext.DM_GiaoVienDaoTaos
                 join p in dataContext.GiaoVien_KhoaDaoTaos
                 on t.MaGV equals p.MaGiaoVien
                 where p.MaKhoaHoc == maKhoaDaoTao
                 select new GiaoVienThamGiaDaoTaoInfo
                 {
                     HoTenGV = t.HoTenGV,
                     MaGV = t.MaGV,
                     NgaySinh = t.NgaySinh,
                     DiDong = t.DiDong,
                     DonViCongTac = t.DonViCongTac,
                     CreatedBy = t.CreatedBy,
                     CreatedDate = t.CreatedDate,
                     DiaChiLienHe = t.DiaChiLienHe,
                     NhanXet = t.NhanXet,
                     ChucVu = t.ChucVu,
                     DTCoQuan = t.DTCoQuan,
                     Email = t.Email,
                     GioiTinh = t.GioiTinh,
                     HocVan = t.HocVan,
                     KinhNghiemGiangDay = t.KinhNghiemGiangDay,
                     LaNhanvienCty = t.LaNhanvienCty,
                     laQuanLyPhuTrach = t.LaQuanLyPhuTrach,
                 };
        return rs;
    }
    /// <summary>
    /// Kiểm tra xem mã giáo viên có bị trùng không
    /// </summary>
    /// <param name="maGiaoVien"></param>
    /// <returns>true = đã tồn tại</returns>
    public bool IsDuplicateMaGiaoVien(string maGiaoVien)
    {
        int c = dataContext.DM_GiaoVienDaoTaos.Count(t => t.MaGV == maGiaoVien);
        return c > 0;
    }

    public IEnumerable<GiaoVienThamGiaDaoTaoInfo> LayDanhSachGiaoVien()
    {
        var rs = from t in dataContext.DM_GiaoVienDaoTaos
                 select new GiaoVienThamGiaDaoTaoInfo
                 {
                     MaGV = t.MaGV,
                     ChucVu = t.ChucVu,
                     DiaChiLienHe = t.DiaChiLienHe,
                     HoTenGV = t.HoTenGV,
                     DonViCongTac = t.DonViCongTac,
                     DiDong = t.DiDong,
                     NgaySinh = t.NgaySinh
                 };
        return rs;
    }
    /// <summary>
    /// Nhân đôi khóa đào tạo
    /// </summary>
    /// <param name="OldID">Khóa đào tạo cũ</param>
    /// <param name="NewID">Khóa đào tạo mới</param>
    /// <param name="createdUserID">Người tạo</param>
    /// <param name="copyGiaoVien"></param>
    /// <param name="copyChiPhi"></param>
    /// <param name="copyNhanVienThamGiaDaoTao"></param>
    public void DuplicateRecord(string OldID, string NewID, int createdUserID, bool copyGiaoVien, bool copyChiPhi, bool copyNhanVienThamGiaDaoTao)
    {
        DAL.KEHOACH_DAOTAO old = GetByID(OldID);
        DAL.KEHOACH_DAOTAO _new = new DAL.KEHOACH_DAOTAO()
        {
            TEN_KHOA_HOC = old.TEN_KHOA_HOC,
            TRANG_THAI = old.TRANG_THAI,
            TEN_DONVIPHUTRACHDAOTAO = old.TEN_DONVIPHUTRACHDAOTAO,
            MA_DONVIPHUTRACHDAOTAO = old.MA_DONVIPHUTRACHDAOTAO,
            GHI_CHU = old.GHI_CHU,
            NOIDUNG_DAOTAO = old.NOIDUNG_DAOTAO,
            LYDO_DAOTAO = old.LYDO_DAOTAO,
            DOITUONG_DAOTAO = old.DOITUONG_DAOTAO,
            THOI_GIAN_DAOTAO = old.THOI_GIAN_DAOTAO,
            SOLUONG_HOCVIEN = old.SOLUONG_HOCVIEN,
            DIA_DIEM_DAOTAO = old.DIA_DIEM_DAOTAO,
            BATDAU_DANGKY = old.BATDAU_DANGKY,
            CreatedDate = DateTime.Now,
            DEN_NGAY = old.DEN_NGAY,
            HETHAN_DANGKY = old.HETHAN_DANGKY,
            KINHPHI_CTY_HOTRO = old.KINHPHI_CTY_HOTRO,
            KINHPHI_DUKIEN = old.KINHPHI_DUKIEN,
            KINHPHI_NHANVIEN_DONG = old.KINHPHI_NHANVIEN_DONG,
            KINHPHI_THUCTE = old.KINHPHI_THUCTE,
            MA = NewID,
            MA_DONVI = old.MA_DONVI,
            MA_CHUNGCHI = old.MA_CHUNGCHI,
            MA_LYDODAOTAO = old.MA_LYDODAOTAO,
            MUCDICH_KHOAHOC = old.MUCDICH_KHOAHOC,
            TU_NGAY = old.TU_NGAY,
            CreatedBy = createdUserID
        };
        dataContext.KEHOACH_DAOTAOs.InsertOnSubmit(_new);
        Save();

        if (copyGiaoVien)
        {
            var gvdt = dataContext.GiaoVien_KhoaDaoTaos.Where(t => t.MaKhoaHoc == OldID);
            foreach (var item in gvdt)
            {
                DAL.GiaoVien_KhoaDaoTao gv = new DAL.GiaoVien_KhoaDaoTao()
                {
                    CreatedBy = createdUserID,
                    CreatedDate = DateTime.Now,
                    MaGiaoVien = item.MaGiaoVien,
                    MaKhoaHoc = NewID
                };
                dataContext.GiaoVien_KhoaDaoTaos.InsertOnSubmit(gv);
                Save();
            }
        }
        if (copyChiPhi)
        {
            var chiPhi = dataContext.DM_CacKhoanChiChoDaoTaos.Where(t => t.FR_KEY == OldID);
            foreach (var item in chiPhi)
            {
                DAL.DM_CacKhoanChiChoDaoTao cp = new DAL.DM_CacKhoanChiChoDaoTao()
                {
                    FR_KEY = NewID,
                    CreatedBy = createdUserID,
                    CreatedDate = DateTime.Now,
                    NguonChi = item.NguonChi,
                    SoTien = item.SoTien,
                    TenChiPhi = item.TenChiPhi
                };
                dataContext.DM_CacKhoanChiChoDaoTaos.InsertOnSubmit(cp);
                Save();
            }
        }
        if (copyNhanVienThamGiaDaoTao)
        {
            var nv = dataContext.DM_NhanVienThamGiaDaoTaos.Where(t => t.MaKhoaDaoTao == OldID);
            foreach (var item in nv)
            {
                DAL.DM_NhanVienThamGiaDaoTao nhanVien = new DAL.DM_NhanVienThamGiaDaoTao()
                {
                    CreatedBy = createdUserID,
                    CreatedDate = DateTime.Now,
                    MaKhoaDaoTao = NewID,
                    DaThamGia = item.DaThamGia,
                    MaCanBo = item.MaCanBo,
                    SoTienCongTyHoTro = item.SoTienCongTyHoTro,
                    SoTienNVDong = item.SoTienNVDong
                };
                dataContext.DM_NhanVienThamGiaDaoTaos.InsertOnSubmit(nhanVien);
                Save();
            }
        }
    }
    public DAL.KEHOACH_DAOTAO GetByID(string MA)
    {
        return dataContext.KEHOACH_DAOTAOs.FirstOrDefault(t => t.MA == MA);
    }

    public void ChuyenTrangThai(string Ma, string TrangThai)
    {
        DAL.KEHOACH_DAOTAO daotao = GetByID(Ma);
        daotao.TRANG_THAI = TrangThai;
        Save();
    }
    /// <summary>
    /// Lấy các khóa đào tạo mà một nhân viên tham gia
    /// </summary>
    /// <param name="MaNhanVien"></param>
    /// <returns></returns>
    public IEnumerable<NhanVienThamGiaDaoTaoInfo> GetThongTinDaoTaoCuaNhanVien(string MaNhanVien)
    {
        var rs = from t in dataContext.DM_NhanVienThamGiaDaoTaos
                 join dt in dataContext.KEHOACH_DAOTAOs
                 on t.MaKhoaDaoTao equals dt.MA
                 where t.MaCanBo == MaNhanVien
                 select new NhanVienThamGiaDaoTaoInfo
                 {
                     DaThamGia = t.DaThamGia,
                     Diem = t.SoDiem,
                     KetQua = t.KetQua,
                     ID = t.ID,
                     NhanXetCuaGiaoVien = t.NhanXetCuaGiaoVien,
                     SoTienCongTyDong = t.SoTienCongTyHoTro,
                     SoTienNhanVienDong = t.SoTienNVDong,

                     DaoTaoTuNgay = dt.TU_NGAY,
                     KetThucDaoTao = dt.DEN_NGAY,
                     MaKhoaDaoTao = dt.MA,
                     TenKhoaDaoTao = dt.TEN_KHOA_HOC,
                     DiaDiemDaoTao = dt.DIA_DIEM_DAOTAO
                 };
        return rs;
    }

    public IEnumerable<KEHOACH_DAOTAOInfo> GetKeHoachDaoTao(string MaDonVi, int start, int limit, out int count, string KeyWord, string TrangThai)
    {
        var rs = from t in dataContext.KEHOACH_DAOTAOs
                 where (System.Data.Linq.SqlClient.SqlMethods.Like(t.MA, KeyWord) || string.IsNullOrEmpty(KeyWord)) && (System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_KHOA_HOC, KeyWord) || string.IsNullOrEmpty(KeyWord))
                 && (t.TRANG_THAI == TrangThai || string.IsNullOrEmpty(TrangThai))
                 orderby t.TRANG_THAI
                 //   && t.MA_DONVI == MaDonVi
                 select new KEHOACH_DAOTAOInfo
                 {
                     DenNgay = t.DEN_NGAY,
                     DiaDiemDaoTao = t.DIA_DIEM_DAOTAO,
                     DoiTuongDaoTao = t.DOITUONG_DAOTAO,
                     DonViPhuTrachDaoTao = t.TEN_DONVIPHUTRACHDAOTAO,
                     GhiChu = t.GHI_CHU,
                     KinhPhiCongTyHoTro = t.KINHPHI_CTY_HOTRO,
                     KinhPhiDuKien = t.KINHPHI_DUKIEN,
                     KinhPhiNhanVienDong = t.KINHPHI_NHANVIEN_DONG,
                     KinhPhiThucTe = t.KINHPHI_THUCTE,
                     LyDoDaoTao = t.LYDO_DAOTAO,
                     MaKeHoach = t.MA,
                     MucDichKhoaHoc = t.MUCDICH_KHOAHOC,
                     NgayBatDauDangKy = t.BATDAU_DANGKY,
                     NgayKetThucDangKy = t.HETHAN_DANGKY,
                     NoiDungDaoTao = t.NOIDUNG_DAOTAO,
                     SoLuongHocVien = t.SOLUONG_HOCVIEN,
                     TenChungChi = t.DM_CHUNGCHI != null ? t.DM_CHUNGCHI.TEN_CHUNGCHI : "",
                     TenkeHoach = t.TEN_KHOA_HOC,
                     ThoiGianDaoTao = t.THOI_GIAN_DAOTAO,
                     TrangThai = t.TRANG_THAI,
                     TuNgay = t.TU_NGAY
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }

    public string Insert(DAL.KEHOACH_DAOTAO daotao)
    {
        dataContext.KEHOACH_DAOTAOs.InsertOnSubmit(daotao);
        Save();
        return daotao.MA;
    }

    public void Delete(string p)
    {
        DAL.KEHOACH_DAOTAO kehoach = GetByID(p);
        dataContext.KEHOACH_DAOTAOs.DeleteOnSubmit(kehoach);
        Save();
    }

    public void DeleteChiPhi(int ID)
    {
        DAL.DM_CacKhoanChiChoDaoTao chiPhi = dataContext.DM_CacKhoanChiChoDaoTaos.FirstOrDefault(t => t.ID == ID);
        if (chiPhi != null)
        {
            dataContext.DM_CacKhoanChiChoDaoTaos.DeleteOnSubmit(chiPhi);
            Save();
        }
    }

    public void DeleteChiPhiByFrkey(string fr_key)
    {
        List<DAL.DM_CacKhoanChiChoDaoTao> list = dataContext.DM_CacKhoanChiChoDaoTaos.Where(t => t.FR_KEY == fr_key).ToList();
        dataContext.DM_CacKhoanChiChoDaoTaos.DeleteAllOnSubmit(list);
        Save();
    }

    /// <summary>
    /// Xóa kế hoạch đào tạo
    /// 
    /// Trước khi xóa kế hoạch đào tạo cần phải xóa các thông tin ràng buộc
    /// bao gồm Giáo viên đào tạo, Các khoản chi phí, Nhân viên tham gia đào tạo
    /// </summary>
    /// <param name="id">Mã kế hoạch đào tạo</param>
    public void DeleteKeHoachDaoTaoByID(string id)
    {
        DAL.KEHOACH_DAOTAO kehoach = dataContext.KEHOACH_DAOTAOs.FirstOrDefault(t => t.MA == id);
        // Xóa bỏ ràng buộc giáo viên - khóa đào tạo (trong bảng GiaoVien_KhoaDaoTao)
        DeleteGiaoVien_KhoaDaoTaoByMaKhoaHoc(id);
        // Xóa các khoản chi phí
        DeleteChiPhiByFrkey(id);
        // Xóa nhân viên tham gia đào tạo
        DeleteNhanVienThamGiaDaoTaoByMaKhoaHoc(id);

        if (kehoach != null)
        {
            dataContext.KEHOACH_DAOTAOs.DeleteOnSubmit(kehoach);
            Save();
        }
    }

    /// <summary>
    /// Xóa nhân viên tham gia đào tạo
    /// </summary>
    /// <param name="recordID"></param>
    public void DeleteNhanVien(int recordID)
    {
        DAL.DM_NhanVienThamGiaDaoTao nv = dataContext.DM_NhanVienThamGiaDaoTaos.FirstOrDefault(t => t.ID == recordID);
        if (nv != null)
        {
            dataContext.DM_NhanVienThamGiaDaoTaos.DeleteOnSubmit(nv);
            Save();
        }
    }

    public void DeleteNhanVienThamGiaDaoTaoByMaKhoaHoc(string maKhoaDaoTao)
    {
        List<DAL.DM_NhanVienThamGiaDaoTao> list = dataContext.DM_NhanVienThamGiaDaoTaos.Where(t => t.MaKhoaDaoTao == maKhoaDaoTao).ToList();
        dataContext.DM_NhanVienThamGiaDaoTaos.DeleteAllOnSubmit(list);
        Save();
    }

    public void DeleteGiaoVienDaoTao(string maGV)
    {
        DAL.DM_GiaoVienDaoTao gvdt = dataContext.DM_GiaoVienDaoTaos.FirstOrDefault(t => t.MaGV == maGV);
        if (gvdt != null)
        {
            dataContext.DM_GiaoVienDaoTaos.DeleteOnSubmit(gvdt);
            Save();
        }
    }

    public void DeleteGiaoVien_KhoaDaoTaoByMaKhoaHoc(string maKhoaHoc)
    {
        List<DAL.GiaoVien_KhoaDaoTao> list = dataContext.GiaoVien_KhoaDaoTaos.Where(t => t.MaKhoaHoc == maKhoaHoc).ToList();
        dataContext.GiaoVien_KhoaDaoTaos.DeleteAllOnSubmit(list);
        Save();
    }

    /// <summary>
    /// Xóa giáo viên ở bảng GiaoVien_KhoaDaoTao
    /// </summary>
    /// <param name="MaGV"></param>
    /// <param name="MaKhoaDaoTao"></param>
    public void DeleteGiaoVien(string MaGV, string MaKhoaDaoTao)
    {
        DAL.GiaoVien_KhoaDaoTao gvdt =
            dataContext.GiaoVien_KhoaDaoTaos.FirstOrDefault(t => t.MaGiaoVien == MaGV && t.MaKhoaHoc == MaKhoaDaoTao);
        dataContext.GiaoVien_KhoaDaoTaos.DeleteOnSubmit(gvdt);
        Save();
    }

    public void InsertChiphiDaotao(DAL.DM_CacKhoanChiChoDaoTao chiPhi)
    {
        dataContext.DM_CacKhoanChiChoDaoTaos.InsertOnSubmit(chiPhi);
        Save();
    }

    public void UpdateChiPhi(DAL.DM_CacKhoanChiChoDaoTao chiPhi)
    {
        DAL.DM_CacKhoanChiChoDaoTao d = GetChiPhiDaoTaoByID(chiPhi.ID);
        d.NguonChi = chiPhi.NguonChi;
        d.SoTien = chiPhi.SoTien;
        d.TenChiPhi = chiPhi.TenChiPhi;
        Save();
    }

    public List<NhanVienThamGiaDaoTaoInfo> GetNhanVienThamGiaDaoTaoByMaDaoTao(string MaDaoTao, int start, int limit)
    {
        var rs = from t in dataContext.DM_NhanVienThamGiaDaoTaos
                 join hs in dataContext.HOSOs on t.MaCanBo equals hs.MA_CB into hs1
                 from hs2 in hs1.DefaultIfEmpty()
                 join dv in dataContext.DM_DONVIs on hs2.MA_DONVI equals dv.MA_DONVI into dv1
                 from dv2 in dv1.DefaultIfEmpty()
                 join ddlv in dataContext.DM_DIADIEMLAMVIECs on hs2.BI_DANH equals ddlv.MA_DIADIEM into ddlv1
                 from ddlv2 in ddlv1.DefaultIfEmpty()
                 where t.MaKhoaDaoTao == MaDaoTao
                 orderby hs2.TEN_CB
                 select new NhanVienThamGiaDaoTaoInfo
                 {
                     ID = t.ID,
                     TenCB = hs2.HO_TEN,
                     DaThamGia = t.DaThamGia,
                     Diem = t.SoDiem,
                     PhongBan = dv2.TEN_DONVI,
                     KetQua = t.KetQua,
                     MaCB = t.MaCanBo,
                     NhanXetCuaGiaoVien = t.NhanXetCuaGiaoVien,
                     SoTienCongTyDong = t.SoTienCongTyHoTro,
                     SoTienNhanVienDong = t.SoTienNVDong,
                     ViTriCongViec = hs2.DM_CONGVIEC != null ? hs2.DM_CONGVIEC.TEN_CONGVIEC : "",
                     DiaDiemLamViec = ddlv2.TEN_DIADIEM,
                     GhiChu = t.GhiChu
                 };
        return rs.ToList();
    }
    public void InsertGiaoVien(DAL.DM_GiaoVienDaoTao gv)
    {
        dataContext.DM_GiaoVienDaoTaos.InsertOnSubmit(gv);
        Save();
    }
    public DAL.DM_GiaoVienDaoTao GetGiaoVienByMaGiaoVien(string MaGV)
    {
        return dataContext.DM_GiaoVienDaoTaos.FirstOrDefault(t => t.MaGV == MaGV);
    }
    public void UpdateGiaoVien(DAL.DM_GiaoVienDaoTao gv)
    {
        DAL.DM_GiaoVienDaoTao giaovien = GetGiaoVienByMaGiaoVien(gv.MaGV);
        giaovien.ChucVu = gv.ChucVu;
        giaovien.DiaChiLienHe = gv.DiaChiLienHe;
        giaovien.DiDong = gv.DiDong;
        giaovien.DonViCongTac = gv.DonViCongTac;
        giaovien.DTCoQuan = gv.DTCoQuan;
        giaovien.Email = gv.Email;
        giaovien.GioiTinh = gv.GioiTinh;
        giaovien.HocVan = gv.HocVan;
        giaovien.HoTenGV = gv.HoTenGV;
        giaovien.KinhNghiemGiangDay = gv.KinhNghiemGiangDay;
        giaovien.LaNhanvienCty = gv.LaNhanvienCty;
        giaovien.LaQuanLyPhuTrach = gv.LaQuanLyPhuTrach;
        giaovien.MaGV = gv.MaGV;
        giaovien.NgaySinh = gv.NgaySinh;
        giaovien.NhanXet = gv.NhanXet;
        Save();

    }

    public void InsertNhanVienThamgiaHoc(DAL.DM_NhanVienThamGiaDaoTao nv)
    {
        try
        {
            dataContext.DM_NhanVienThamGiaDaoTaos.InsertOnSubmit(nv);
            Save();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UpdateNhanVien(NhanVienThamGiaDaoTaoInfo item)
    {
        DAL.DM_NhanVienThamGiaDaoTao nv = dataContext.DM_NhanVienThamGiaDaoTaos.FirstOrDefault(t => t.ID == item.ID);
        nv.KetQua = item.KetQua;
        nv.NhanXetCuaGiaoVien = item.NhanXetCuaGiaoVien;
        nv.SoDiem = item.Diem;
        nv.SoTienCongTyHoTro = item.SoTienCongTyDong;
        nv.SoTienNVDong = item.SoTienNhanVienDong;
        nv.DaThamGia = item.DaThamGia;
        nv.GhiChu = item.GhiChu;
        Save();
    }

    public DAL.KEHOACH_DAOTAO GetKeHoachDaoTaoByID(string maKeHoachDaoTao)
    {
        return dataContext.KEHOACH_DAOTAOs.FirstOrDefault(t => t.MA == maKeHoachDaoTao);
    }

    public void CopyCanBoToGiaoVienDaoTao(List<DAL.DM_GiaoVienDaoTao> lists)
    {
        foreach (var item in lists)
        {
            dataContext.DM_GiaoVienDaoTaos.InsertOnSubmit(item);
            Save();
        }
    }

    public void Update(DAL.KEHOACH_DAOTAO kehoach)
    {
        DAL.KEHOACH_DAOTAO kh = GetKeHoachDaoTaoByID(kehoach.MA);
        kh.LYDO_DAOTAO = kehoach.LYDO_DAOTAO;
        kh.KINHPHI_THUCTE = kehoach.KINHPHI_THUCTE;
        kh.KINHPHI_NHANVIEN_DONG = kehoach.KINHPHI_NHANVIEN_DONG;
        kh.BATDAU_DANGKY = kehoach.BATDAU_DANGKY;
        kh.DEN_NGAY = kehoach.DEN_NGAY;
        kh.DIA_DIEM_DAOTAO = kehoach.DIA_DIEM_DAOTAO;
        kh.DOITUONG_DAOTAO = kehoach.DOITUONG_DAOTAO;
        kh.GHI_CHU = kehoach.GHI_CHU;
        kh.HETHAN_DANGKY = kehoach.HETHAN_DANGKY;
        kh.KINHPHI_CTY_HOTRO = kehoach.KINHPHI_CTY_HOTRO;
        kh.KINHPHI_DUKIEN = kehoach.KINHPHI_DUKIEN;
        kh.KINHPHI_NHANVIEN_DONG = kehoach.KINHPHI_NHANVIEN_DONG;
        kh.KINHPHI_THUCTE = kehoach.KINHPHI_THUCTE;
        kh.MA_CHUNGCHI = kehoach.MA_CHUNGCHI;
        kh.MA_DONVIPHUTRACHDAOTAO = kehoach.MA_DONVIPHUTRACHDAOTAO;
        kh.MA_LYDODAOTAO = kehoach.MA_LYDODAOTAO;
        kh.MUCDICH_KHOAHOC = kehoach.MUCDICH_KHOAHOC;
        kh.NOIDUNG_DAOTAO = kehoach.NOIDUNG_DAOTAO;
        kh.SOLUONG_HOCVIEN = kehoach.SOLUONG_HOCVIEN;
        kh.TEN_DONVIPHUTRACHDAOTAO = kehoach.TEN_DONVIPHUTRACHDAOTAO;
        kh.TEN_KHOA_HOC = kehoach.TEN_KHOA_HOC;
        kh.THOI_GIAN_DAOTAO = kehoach.THOI_GIAN_DAOTAO;
        kh.TRANG_THAI = kehoach.TRANG_THAI;
        kh.TU_NGAY = kehoach.TU_NGAY;
        Save();
    }
}
