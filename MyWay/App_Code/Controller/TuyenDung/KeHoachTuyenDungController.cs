using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for DM_DOTTUYENDUNGController
/// </summary>
public class KeHoachTuyenDungController : LinqProvider
{
    public KeHoachTuyenDungController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insert(DAL.KeHoachTuyenDung keHoachTuyenDung)
    {
        if (keHoachTuyenDung != null)
        {
            dataContext.KeHoachTuyenDungs.InsertOnSubmit(keHoachTuyenDung);
            Save();
        }
    }

    public void Update(DAL.KeHoachTuyenDung keHoachTuyenDung)
    {
        DAL.KeHoachTuyenDung temp = dataContext.KeHoachTuyenDungs.SingleOrDefault(t => t.ID == keHoachTuyenDung.ID);
        if (temp != null)
        {
            temp.CreatedBy = keHoachTuyenDung.CreatedBy;
            temp.CreatedDate = keHoachTuyenDung.CreatedDate;
            temp.GhiChu = keHoachTuyenDung.GhiChu;
            temp.HanNopHoSo = keHoachTuyenDung.HanNopHoSo;
            temp.HinhThucLamViec = keHoachTuyenDung.HinhThucLamViec;
            temp.HoSoBaoGom = keHoachTuyenDung.HoSoBaoGom;
            temp.KinhPhiDuTru = keHoachTuyenDung.KinhPhiDuTru;
            temp.LyDoTuyen = keHoachTuyenDung.LyDoTuyen;
            temp.MA_DONVI = keHoachTuyenDung.MA_DONVI;
            temp.MaCongViec = keHoachTuyenDung.MaCongViec;
            temp.MaChucVu = keHoachTuyenDung.MaChucVu;
            temp.MaKeHoach = keHoachTuyenDung.MaKeHoach;
            temp.MoTaCongViec = keHoachTuyenDung.MoTaCongViec;
            temp.MucLuongDuKienToiDa = keHoachTuyenDung.MucLuongDuKienToiDa;
            temp.MucLuongDuKienToiThieu = keHoachTuyenDung.MucLuongDuKienToiThieu;
            temp.NoiLamViec = keHoachTuyenDung.NoiLamViec;
            temp.NgayBatDau = keHoachTuyenDung.NgayBatDau;
            temp.NgayBatDauDiLam = keHoachTuyenDung.NgayBatDauDiLam;
            temp.NgayKetThuc = keHoachTuyenDung.NgayKetThuc;
            temp.SoLuongCanTuyen = keHoachTuyenDung.SoLuongCanTuyen;
            temp.SoVongPhongVan = keHoachTuyenDung.SoVongPhongVan;
            temp.TenKeHoach = keHoachTuyenDung.TenKeHoach;
            temp.ThoiGianThuViec = keHoachTuyenDung.ThoiGianThuViec;
            temp.TrangThaiXuLy = keHoachTuyenDung.TrangThaiXuLy;            
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.KeHoachTuyenDung temp = dataContext.KeHoachTuyenDungs.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.KeHoachTuyenDungs.DeleteOnSubmit(temp);
            Save();
        }
    }
    public int CountSlotKeHoachTuyenDung(int iDKeHoachTuyenDung)
    {
        int slots = dataContext.KeHoachTuyenDungs.SingleOrDefault(t => t.ID == iDKeHoachTuyenDung).SoLuongCanTuyen;
        var count = (from t in dataContext.HoSoUngViens
                  join khtd in dataContext.KeHoachTuyenDungs on t.MaDotTuyenDung equals khtd.ID
                  where t.MaDotTuyenDung == iDKeHoachTuyenDung
                  select t.MaUngVien).ToList().Count;
        return slots - count;
    }
    public DAL.KeHoachTuyenDung GetById(decimal id)
    {
        return dataContext.KeHoachTuyenDungs.SingleOrDefault(t => t.ID == id);
    }
    public IEnumerable<KeHoachTuyenDungInfo> GetInfoByID(decimal id)
    {
        var rs = from t in dataContext.KeHoachTuyenDungs
                 join cv in dataContext.DM_CONGVIECs on t.MaCongViec equals cv.MA_CONGVIEC into c
                 from cvs in c.DefaultIfEmpty()
                 join dmcv in dataContext.DM_CHUCVUs on t.MaChucVu equals dmcv.MA_CHUCVU into cv
                 from dmcvs in cv.DefaultIfEmpty()
                 join dv in dataContext.DM_DONVIs on t.MA_DONVI equals dv.MA_DONVI into dmdv
                 from dvs in dmdv.DefaultIfEmpty()
                 join tstt in dataContext.ThamSoTrangThais on t.LyDoTuyen equals tstt.ID into tstt1
                 from tstt2 in tstt1.DefaultIfEmpty()
                 where t.ID == id
                 select new KeHoachTuyenDungInfo
                 {
                     ID = t.ID,
                     MaKeHoach = t.MaKeHoach,
                     TenKeHoach = t.TenKeHoach,
                     NgayBatDau = t.NgayBatDau,
                     NgayKetThuc = t.NgayKetThuc,
                     TrangThaiXuLy = t.TrangThaiXuLy,
                     SoLuongCanTuyen = t.SoLuongCanTuyen,
                     SoVongPhongVan = t.SoVongPhongVan,
                     LyDoTuyen = tstt2.Value,
                     KinhPhiDuTru = t.KinhPhiDuTru,
                     MaCongViec = t.MaCongViec,
                     MaChucVu = t.MaChucVu,
                     MA_DONVI = t.MA_DONVI,
                     HanNopHoSo = t.HanNopHoSo,
                     MucLuongDuKienToiThieu = t.MucLuongDuKienToiThieu,
                     MucLuongDuKienToiDa = t.MucLuongDuKienToiDa,
                     NoiLamViec = t.NoiLamViec,
                     NgayBatDauDiLam = t.NgayBatDauDiLam,
                     HoSoBaoGom = t.HoSoBaoGom,
                     ThoiGianThuViec = t.ThoiGianThuViec,
                     HinhThucLamViec = t.HinhThucLamViec,
                     MoTaCongViec = t.MoTaCongViec,
                     CreatedBy = t.CreatedBy,
                     CreatedDate = t.CreatedDate,
                     TEN_CONGVIEC = cvs.TEN_CONGVIEC,
                     TEN_CHUCVU = dmcvs.TEN_CHUCVU,
                     TEN_DONVI = dvs.TEN_DONVI,
                     MaLyDoTuyen = t.LyDoTuyen,
                     GhiChu = t.GhiChu
                 };
        return rs;
    }
    //public IEnumerable<KeHoachTuyenDungInfo> GetAll(int start, int limit, string searchKey, string works, string chucVu, DateTime fromDate, DateTime toDate, out int count)
    //{
    //    var re = dataContext.KeHoachTuyenDungs.Where(t => (searchKey == "" || System.Data.Linq.SqlClient.SqlMethods.Like(t.TenKeHoach, searchKey)) && (chucVu == "" || t.MaChucVu == chucVu) && (works == "" || t.MaCongViec == works) && (fromDate == DateTime.MinValue || fromDate == t.NgayBatDau) && (toDate == DateTime.MinValue || toDate == t.NgayKetThuc)).Skip(start).Take(limit).ToList().Select(t => GetKHTDInfo(t));
    //    count = re.Count();
    //    return re;
    //}
    //public string GeneratorMaKeHoachTuyenDung()
    //{
    //    return "KHTD-" + DateTime.Now.ToString("dd-MM-yyyy");
    //}
    //public void Insert(DAL.KeHoachTuyenDung khtd)
    //{
    //    dataContext.KeHoachTuyenDungs.InsertOnSubmit(khtd);
    //    Save();
    //}

    //public void Double(int originalMa, int ma)
    //{
    //    var khtd = dataContext.KeHoachTuyenDungs.FirstOrDefault(k => k.ID == originalMa);
    //    var newKHTD = new DAL.KeHoachTuyenDung();
    //    newKHTD.MaCongViec = khtd.MaCongViec;
    //    newKHTD.TenKeHoach = khtd.TenKeHoach;
    //    newKHTD.CreatedBy = khtd.CreatedBy;
    //    newKHTD.HanNopHoSo = khtd.HanNopHoSo;
    //    newKHTD.HinhThucLamViec = khtd.HinhThucLamViec;
    //    newKHTD.HoSoBaoGom = khtd.HoSoBaoGom;
    //    newKHTD.KinhPhiDuTru = khtd.KinhPhiDuTru;
    //    newKHTD.LyDoTuyen = khtd.LyDoTuyen;
    //    newKHTD.MaCongViec = khtd.MaCongViec;
    //    newKHTD.MaChucVu = khtd.MaChucVu;
    //    newKHTD.MoTaCongViec = khtd.MoTaCongViec;
    //    newKHTD.MucLuongDuKienToiDa = khtd.MucLuongDuKienToiDa;
    //    newKHTD.MucLuongDuKienToiThieu = khtd.MucLuongDuKienToiThieu;
    //    newKHTD.NoiLamViec = khtd.NoiLamViec;
    //    newKHTD.NgayBatDau = khtd.NgayBatDau;
    //    newKHTD.NgayKetThuc = khtd.NgayKetThuc;
    //    newKHTD.SoLuongCanTuyen = khtd.SoLuongCanTuyen;
    //    newKHTD.SoVongPhongVan = khtd.SoVongPhongVan;
    //    newKHTD.TenKeHoach = khtd.TenKeHoach;
    //    newKHTD.ThoiGianThuViec = khtd.ThoiGianThuViec;
    //    newKHTD.TrangThaiXuLy = khtd.TrangThaiXuLy;
    //    newKHTD.ID = ma;
    //    dataContext.KeHoachTuyenDungs.InsertOnSubmit(newKHTD);
    //    Save();
    //}

    //public void Update(DAL.KeHoachTuyenDung khtd)
    //{
    //    //DAL.KeHoachTuyenDung khtdOriginal = dataContext.KeHoachTuyenDungs.FirstOrDefault(k => k.ID == khtd.ID);
    //    DAL.KeHoachTuyenDung khtdOriginal = dataContext.KeHoachTuyenDungs.SingleOrDefault(k => k.ID == khtd.ID);
    //    if (khtdOriginal != null)
    //    {
    //        khtdOriginal.MaCongViec = khtd.MaCongViec;
    //        khtdOriginal.TenKeHoach = khtd.TenKeHoach;
    //        khtdOriginal.CreatedBy = khtd.CreatedBy;
    //        khtdOriginal.HanNopHoSo = khtd.HanNopHoSo;
    //        khtdOriginal.HinhThucLamViec = khtd.HinhThucLamViec;
    //        khtdOriginal.HoSoBaoGom = khtd.HoSoBaoGom;
    //        khtdOriginal.KinhPhiDuTru = khtd.KinhPhiDuTru;
    //        khtdOriginal.LyDoTuyen = khtd.LyDoTuyen;
    //        khtdOriginal.MaCongViec = khtd.MaCongViec;
    //        khtdOriginal.MaChucVu = khtd.MaChucVu;
    //        khtdOriginal.MoTaCongViec = khtd.MoTaCongViec;
    //        khtdOriginal.MucLuongDuKienToiDa = khtd.MucLuongDuKienToiDa;
    //        khtdOriginal.MucLuongDuKienToiThieu = khtd.MucLuongDuKienToiThieu;
    //        khtdOriginal.NoiLamViec = khtd.NoiLamViec;
    //        khtdOriginal.NgayBatDau = khtd.NgayBatDau;
    //        khtdOriginal.NgayKetThuc = khtd.NgayKetThuc;
    //        khtdOriginal.SoLuongCanTuyen = khtd.SoLuongCanTuyen;
    //        khtdOriginal.SoVongPhongVan = khtd.SoVongPhongVan;
    //        khtdOriginal.TenKeHoach = khtd.TenKeHoach;
    //        khtdOriginal.ThoiGianThuViec = khtd.ThoiGianThuViec;
    //        khtdOriginal.TrangThaiXuLy = khtd.TrangThaiXuLy;
    //        Save();
    //    }
    //}

    //public void UpdateTrangThaiXuLy(int ma, string trangThaiXuLy)
    //{
    //    DAL.KeHoachTuyenDung dotTuyenDung = GetByID(ma);
    //    //dotTuyenDung.TrangThaiXuLy = trangThaiXuLy;
    //    Save();
    //}
    /// <summary>
    /// Hàm này được sử dụng cho báo cáo
    /// </summary>
    /// <param name="trangthaisuly">Nếu trạng thái xử lý bằng rỗng thì lấy tất cả</param>
    /// <returns></returns>
    //public IEnumerable<DM_DOTTUYENDUNGInfo> GetDotTuyenDungByTrangThaiXuLy(string trangthaiXuly)
    //{
    //    //return (from t in dataContext.DM_DOTTUYENDUNGs.Where(t => t.TrangThaiXuLy == trangthaiXuly || string.IsNullOrEmpty(trangthaiXuly))
    //    //        join p in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals p.MA_CHUCVU
    //    //        into pp
    //    //        from p in pp.DefaultIfEmpty()
    //    //        select new DM_DOTTUYENDUNGInfo
    //    //        {
    //    //            KinhPhiDuTru = t.KinhPhiDuTru,
    //    //            LyDoTuyen = t.LyDoTuyen,
    //    //            MA_CHUCVU = p.TEN_CHUCVU,
    //    //            NgayBatDau = t.NgayBatDau,
    //    //            NgayKetThuc = t.NgayKetThuc,
    //    //            SoLuongCanTuyen = t.SoLuongCanTuyen,
    //    //            TenKeHoach = t.TenKeHoach,
    //    //            ID = t.ID
    //    //        });
    //    return null;
    //}

    //public List<DAL.DM_DOTTUYENDUNG> GetAll(int start, int limit)
    //{
    //    return dataContext.DM_DOTTUYENDUNGs.Skip(start).Take(limit).OrderByDescending(t => t.CreatedDate).ToList();
    //}

    //public DAL.KeHoachTuyenDung GetByID(int ma)
    //{
    //    return dataContext.KeHoachTuyenDungs.SingleOrDefault(k => k.ID == ma);
    //}

    //public KeHoachTuyenDungInfo GetKHTDInfo(int ma)
    //{
    //    DAL.KeHoachTuyenDung khtd = dataContext.KeHoachTuyenDungs.FirstOrDefault(k => k.ID == ma);
    //    return GetKHTDInfo(khtd);
    //}
    //private KeHoachTuyenDungInfo GetKHTDInfo(DAL.KeHoachTuyenDung khtd)
    //{

    //    return new KeHoachTuyenDungInfo { ID = khtd.ID, TenKeHoach = khtd.TenKeHoach, SoLuongTuyen = khtd.SoLuongCanTuyen, SoVongPhongVan = khtd.SoVongPhongVan.GetValueOrDefault(1), MucLuongDuKien = khtd.MucLuongDuKienToiDa, NgayBatDau = khtd.NgayBatDau, NgayKetThuc = khtd.NgayKetThuc, MaCongViec = khtd.MaCongViec, CongViec = khtd.DM_CONGVIEC.TEN_CONGVIEC, ChucVu = khtd.DM_CHUCVU.TEN_CHUCVU };

    //}

    //public void DeleteKeHoachTuyenDung(int ID)
    //{
    //    var del = GetByID(ID);
    //    dataContext.KeHoachTuyenDungs.DeleteOnSubmit(del);
    //    Save();
    //}
    //public IEnumerable<CacmonthituyenInfo> GetCacMonThiTuyen()
    //{
    //    var cacMonThiTuyen = new ThamSoTrangThaiController().GetByParamName("CacMonThiTuyen", true);
    //    var source = new List<CacmonthituyenInfo>();
    //    foreach (var item in cacMonThiTuyen)
    //    {
    //        source.Add(new CacmonthituyenInfo
    //        {
    //            ID = item.ID,
    //            MonThi = item.Value,
    //        });
    //    }
    //    return source;
    //}
}