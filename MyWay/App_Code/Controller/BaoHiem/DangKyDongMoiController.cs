using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DangKyDongMoiController
/// </summary>
public class DangKyDongMoiController : LinqProvider
{
    public DangKyDongMoiController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDangKyDongMoi(int start, int limit, string searchKey, string MaDonVi, int Thang, int Nam)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("BHLoadDanhSachDongMoi", "@MaDonVi", "@Thang", "@Nam", "@SearchKey", "@Start", "@Limit", MaDonVi, Thang, Nam, searchKey, start, limit);
    }

    public List<BHNHANVIEN_BAOHIEMInfo> GetDangKyDongMoi(int start, int limit, string searchKey, string MaDonVi, int thang, int Nam, out int count, bool cotheohopdong, bool loaihd, bool ngaydilam)
    {   //cotheohopdong là biến nếu true thì lấy lương ghi trên hợp đồng và các tham số đi kèm, nếu false thì lấy lương mới nhất
        var cm = new CommonUtil();
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(MaDonVi).Split(',');
        DateTime ThangTruoc = new DateTime(Nam, thang, 1).AddMonths(-1);
        //Bảng hoso chỉ có 2 trường là id và manhanvien
        var hoso2cot = (from t in dataContext.HOSOs
                        where (MaDonVi == "" || s1.Contains(t.MA_DONVI))
                        select new tmpCB
                        {
                            MaCB = t.MA_CB,
                            PrKey = t.PR_KEY
                        }).ToList();
        #region Lấy ra danh mục loại hợp đồng ko keos ddc linq nen kho the nay day :(

        List<DanhMucLoaiHopDongInfo> dmLoaiHDong = new List<DanhMucLoaiHopDongInfo>();
        DataTable a = DataController.DataHandler.GetInstance().ExecuteDataTable(String.Format("SELECT MA_LOAI_HDONG,TEN_LOAI_HDONG,BHXH,BHYT,BHTN FROM DM_LOAI_HDONG "));

        foreach (DataRow dr in a.Rows)
        {
            var dm = new DanhMucLoaiHopDongInfo();
            dm.MaLoaiHopDong = dr["MA_LOAI_HDONG"].ToString();
            dm.TenLoaiHopDong = dr["TEN_LOAI_HDONG"].ToString();
            dm.BHXH = bool.Parse(dr["BHXH"].ToString());
            dm.BHYT = bool.Parse(dr["BHYT"].ToString());
            dm.BHTN = bool.Parse(dr["BHTN"].ToString());
            dmLoaiHDong.Add(dm);
        }
        #endregion

        #region lấy những nhân viên trong bảng hồ sơ có chưa kết thúc hợp đồng
        // và loại hợp đồng đc đóng bhxh hoặc bhyt
        var hoso_hoso_hopdong = (from t in dataContext.HOSOs
                                 join q in dataContext.HOSO_HOPDONGs on t.PR_KEY equals q.FR_KEY
                                 // join x in dmLoaiHDong on q.MA_LOAI_HDONG equals x.MaLoaiHopDong
                                 where (MaDonVi == "" || s1.Contains(t.MA_DONVI)) &&
                                        (q.NGAYKT_HDONG == null || (DateTime.Now - q.NGAYKT_HDONG.Value).Days < 0)
                                 select new
                                 {
                                     t.MA_CB,
                                     PR_KEY = q.FR_KEY,
                                     q.MA_LOAI_HDONG
                                 }
                  ).Distinct().ToList();

        if (loaihd)
            hoso2cot = (from t in hoso_hoso_hopdong
                        join x in dmLoaiHDong on t.MA_LOAI_HDONG equals x.MaLoaiHopDong
                        where (x.BHXH == true || x.BHYT == true)
                        select new tmpCB
                            {
                                MaCB = t.MA_CB,
                                PrKey = t.PR_KEY
                            }).ToList();
        else hoso2cot = (from t in hoso_hoso_hopdong select new tmpCB { MaCB = t.MA_CB, PrKey = t.PR_KEY }).ToList();

        #endregion

        #region loại bỏ những nhân viên đã có trong bảng nhân viên bảo hiểm lấy prkey
        int[] NhanvienBaohiemID = dataContext.BHNHANVIEN_BAOHIEMs.Select(x => x.IDNhanVien_BaoHiem).ToArray();
        hoso2cot = (from t in hoso2cot
                    where (!NhanvienBaohiemID.Contains((int)t.PrKey))
                    select new tmpCB { MaCB = t.MaCB, PrKey = t.PrKey }).ToList();
        #endregion
        #region kiểm tra điều kiện chấm công tháng
        //chuyển từ pr(trong temp2) thành Ma)
        string[] ma = (from t in hoso2cot
                       select t.MaCB).ToArray();
        string[] listMaCanBo = new string[10000];
        if (ngaydilam)
        {
            string tmp = String.Join(",", ma);
            DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_BaoHiem_GetHoSoDiLam", "@MaCB", "@Month", "@Year", tmp, ThangTruoc.Month, ThangTruoc.Year);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listMaCanBo[i] = dt.Rows[i][0].ToString();
            }

        }
        else listMaCanBo = ma;

        //hoso2cot = hoso2cot.Where(p => listMaCanBo.Contains(p.MaCB)).ToList();
        #endregion
        // bảng hồ sơ chỉ chứa mã cán bộ trong list
        var hoso = (from t in dataContext.HOSOs
                    join q in dataContext.DM_DONVIs on t.MA_DONVI equals q.MA_DONVI into tq
                    from abc in tq.DefaultIfEmpty()
                    join x in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals x.MA_CHUCVU into tqx
                    from xyz in tqx.DefaultIfEmpty()
                    where (listMaCanBo.Contains(t.MA_CB)
                    && (string.IsNullOrEmpty(searchKey)
                     || System.Data.Linq.SqlClient.SqlMethods.Like(t.MA_CB, searchKey)
                     || System.Data.Linq.SqlClient.SqlMethods.Like(t.HO_TEN, searchKey)))
                     //|| System.Data.Linq.SqlClient.SqlMethods.Like(t.TenLoaiHopDong, searchKey))
                    orderby t.TEN_CB, t.HO_CB
                    select new
                    {
                        t.PR_KEY,
                        t.MA_CB,
                        t.HO_TEN,
                        t.MA_DONVI,
                        abc.TEN_DONVI,
                        t.MA_CHUCVU,
                        xyz.TEN_CHUCVU
                    }
                    ).ToList();
        decimal[] listIDCanBo = hoso.Select(p => p.PR_KEY).ToArray();
        //bây giờ mình đã có listMaCanBo và listIDCanBo lưu những nhân viên đc show ra gid
        //xử lý nốt lương và phụ cấp

        //lấy hợp đồng có ngày hiệu lực lớn nhất
        var hoso_hopdong = (from t in dataContext.HOSO_HOPDONGs
                            group t by t.FR_KEY into grp
                            let maxDate = grp.Max(p => p.NgayCoHieuLuc)
                            from t in grp
                            where (maxDate == null || t.NgayCoHieuLuc == maxDate)
                            && listIDCanBo.Contains(t.FR_KEY)
                            select t).ToList();
        //trả về kết quả
        //lấy ngày hiệu lực gần nhất của nhân viên
        var result = (from t1 in hoso
                      join t3 in hoso_hopdong on t1.PR_KEY equals t3.FR_KEY
                      join t4 in dmLoaiHDong on t3.MA_LOAI_HDONG equals t4.MaLoaiHopDong
                      select new BHNHANVIEN_BAOHIEMInfo
                      {
                          IDNhanVien_BaoHiem = (int)t1.PR_KEY,
                          MaNhanVien = t1.MA_CB,
                          HoTen = t1.HO_TEN,
                          Ho = cm.GetLastNameFromFullName(t1.HO_TEN),
                          Ten = cm.GetFirstNamFromFullName(t1.HO_TEN),
                          MaBoPhan = t1.MA_DONVI,
                          TenBoPhan = t1.TEN_DONVI,
                          MaChucVu = t1.MA_CHUCVU,
                          TenChucVu = t1.TEN_CHUCVU,
                          LuongBaoHiem = 0,
                          NgayBatDauHopDong = t3.NGAY_HDONG,
                          TenLoaiHopDong = t4.TenLoaiHopDong,
                          DangDongBHXH = t4.BHXH,
                          DangDongBHYT = t4.BHYT,
                          DangDongBHTN = t4.BHTN,
                          PhuCapCV = 0,
                          PhuCapTNN = 0,
                          PhuCapKhac = 0,
                          PhuCapTNVK = 0
                      }).ToList();
        #region bỏ
        //var result = (from t1 in dataContext.HOSOs
        //              join t3 in dataContext.HOSO_HOPDONGs on t1.PR_KEY equals t3.FR_KEY
        //              join t4 in dmLoaiHDong on t3.MA_LOAI_HDONG equals t4.MaLoaiHopDong
        //              join t6 in LayNgayHieuLuc on t1.PR_KEY equals t6.PR_KEY
        //              where listMaCanBo.Contains(t1.MA_CB)
        //              select new BHNHANVIEN_BAOHIEMInfo
        //              {
        //                  IDNhanVien_BaoHiem = (int)t1.PR_KEY,
        //                  MaNhanVien = t1.MA_CB,
        //                  HoTen = t1.HO_TEN,
        //                  MaChucVu = t5.MA_CHUCVU,
        //                  TenChucVu = t5.TEN_CHUCVU,
        //                  LuongBaoHiem = t6.LuongDongBHXH == null ? 0 : (decimal)t6.LuongDongBHXH,
        //                  NgayBatDauHopDong = t3.NGAY_HDONG,
        //                  TenLoaiHopDong = t4.TenLoaiHopDong,
        //                  DangDongBHXH = t4.BHXH,
        //                  DangDongBHYT = t4.BHYT,
        //                  DangDongBHTN = t4.BHTN,
        //                  PhuCapCV = 0,
        //                  PhuCapTNN = 0,
        //                  PhuCapKhac = 0,
        //                  PhuCapTNVK = 0
        //              }).ToList();
        #endregion
        int IDNhanVienBaoHiem;
        string soquyetdinh;
        string tenquyetdinh;
        DateTime? ngayky;
        DateTime? Ngayhieuluc;
        DateTime? Hethieuluc;
        decimal? luongbaohiem;
        decimal? phucapcv;
        decimal? phucaptnn;
        decimal? phucaptnvk;
        decimal? phucapkhac;
        foreach (var item in result)
        {
            IDNhanVienBaoHiem = item.IDNhanVien_BaoHiem;
            new BaoHiemController().TTQuyetDinhLuongMoiNhat(IDNhanVienBaoHiem, out soquyetdinh, out tenquyetdinh, out ngayky, out Ngayhieuluc, out Hethieuluc, out luongbaohiem, out phucapcv, out phucaptnn, out phucaptnvk, out phucapkhac);
            item.PhuCapCV = phucapcv;
            item.PhuCapTNVK = phucaptnvk;
            item.PhuCapTNN = phucaptnn;
            item.PhuCapKhac = phucapkhac;
            item.LuongBaoHiem = luongbaohiem;
        }
        var kq = (from t in result

                  select t).ToList();

        count = kq.Count;
        return kq.Skip(start).Take(limit).ToList();
    }
    // vĩ sửa
    public List<BHNHANVIEN_BAOHIEMInfo> GetDangKyDongMoi(int start, int limit, string searchKey, string MaDonVi, out int count, bool cotheohopdong, bool loaihd)
    {   //cotheohopdong là biến nếu true thì lấy lương ghi trên hợp đồng và các tham số đi kèm, nếu false thì lấy lương mới nhất
        var cm = new CommonUtil();
        string[] s1 = new DM_DONVIController().GetAllMaDonVi(MaDonVi).Split(',');
        //Bảng hoso chỉ có 2 trường là id và manhanvien
        var hoso2cot = (from t in dataContext.HOSOs
                        where (MaDonVi == "" || s1.Contains(t.MA_DONVI))
                        select new tmpCB
                        {
                            MaCB = t.MA_CB,
                            PrKey = t.PR_KEY
                        }).ToList();
        #region Lấy ra danh mục loại hợp đồng ko keos ddc linq nen kho the nay day :(

        List<DanhMucLoaiHopDongInfo> dmLoaiHDong = new List<DanhMucLoaiHopDongInfo>();
        DataTable a = DataController.DataHandler.GetInstance().ExecuteDataTable(String.Format("SELECT MA_LOAI_HDONG,TEN_LOAI_HDONG,BHXH,BHYT,BHTN FROM DM_LOAI_HDONG "));

        foreach (DataRow dr in a.Rows)
        {
            var dm = new DanhMucLoaiHopDongInfo();
            dm.MaLoaiHopDong = dr["MA_LOAI_HDONG"].ToString();
            dm.TenLoaiHopDong = dr["TEN_LOAI_HDONG"].ToString();
            dm.BHXH = bool.Parse(dr["BHXH"].ToString());
            dm.BHYT = bool.Parse(dr["BHYT"].ToString());
            dm.BHTN = bool.Parse(dr["BHTN"].ToString());
            dmLoaiHDong.Add(dm);
        }
        #endregion

        #region lấy những nhân viên trong bảng hồ sơ có chưa kết thúc hợp đồng
        // và loại hợp đồng đc đóng bhxh hoặc bhyt
        var hoso_hoso_hopdong = (from t in dataContext.HOSOs
                                 join q in dataContext.HOSO_HOPDONGs on t.PR_KEY equals q.FR_KEY
                                 // join x in dmLoaiHDong on q.MA_LOAI_HDONG equals x.MaLoaiHopDong
                                 where (MaDonVi == "" || s1.Contains(t.MA_DONVI)) &&
                                        (q.NGAYKT_HDONG == null || (DateTime.Now - q.NGAYKT_HDONG.Value).Days < 0)
                                 select new
                                 {
                                     t.MA_CB,
                                     PR_KEY = q.FR_KEY,
                                     q.MA_LOAI_HDONG
                                 }
                  ).Distinct().ToList();

        if (loaihd)
            hoso2cot = (from t in hoso_hoso_hopdong
                        join x in dmLoaiHDong on t.MA_LOAI_HDONG equals x.MaLoaiHopDong
                        where (x.BHXH == true || x.BHYT == true)
                        select new tmpCB
                        {
                            MaCB = t.MA_CB,
                            PrKey = t.PR_KEY
                        }).ToList();
        else hoso2cot = (from t in hoso_hoso_hopdong select new tmpCB { MaCB = t.MA_CB, PrKey = t.PR_KEY }).ToList();

        #endregion

        #region loại bỏ những nhân viên đã có trong bảng nhân viên bảo hiểm lấy prkey
        int[] NhanvienBaohiemID = dataContext.BHNHANVIEN_BAOHIEMs.Select(x => x.IDNhanVien_BaoHiem).ToArray();
        hoso2cot = (from t in hoso2cot
                    where (!NhanvienBaohiemID.Contains((int)t.PrKey))
                    select new tmpCB { MaCB = t.MaCB, PrKey = t.PrKey }).ToList();
        #endregion
        #region kiểm tra điều kiện chấm công tháng
        //chuyển từ pr(trong temp2) thành Ma)
        string[] ma = (from t in hoso2cot
                       select t.MaCB).ToArray();

        //hoso2cot = hoso2cot.Where(p => listMaCanBo.Contains(p.MaCB)).ToList();
        #endregion
        // bảng hồ sơ chỉ chứa mã cán bộ trong list
        var hoso = (from t in dataContext.HOSOs
                    join q in dataContext.DM_DONVIs on t.MA_DONVI equals q.MA_DONVI into tq
                    from abc in tq.DefaultIfEmpty()
                    join x in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals x.MA_CHUCVU into tqx
                    from xyz in tqx.DefaultIfEmpty()
                    where (ma.Contains(t.MA_CB)
                    && (string.IsNullOrEmpty(searchKey)
                     || System.Data.Linq.SqlClient.SqlMethods.Like(t.MA_CB, searchKey)
                     || System.Data.Linq.SqlClient.SqlMethods.Like(t.HO_TEN, searchKey)))
                    //|| System.Data.Linq.SqlClient.SqlMethods.Like(t.TenLoaiHopDong, searchKey))
                    orderby t.TEN_CB, t.HO_CB
                    select new
                    {
                        t.PR_KEY,
                        t.MA_CB,
                        t.HO_TEN,
                        t.MA_DONVI,
                        abc.TEN_DONVI,
                        t.MA_CHUCVU,
                        xyz.TEN_CHUCVU
                    }
                    ).ToList();
        decimal[] listIDCanBo = hoso.Select(p => p.PR_KEY).ToArray();
        //bây giờ mình đã có listMaCanBo và listIDCanBo lưu những nhân viên đc show ra gid
        //xử lý nốt lương và phụ cấp

        //lấy hợp đồng có ngày hiệu lực lớn nhất
        var hoso_hopdong = (from t in dataContext.HOSO_HOPDONGs
                            group t by t.FR_KEY into grp
                            let maxDate = grp.Max(p => p.NgayCoHieuLuc)
                            from t in grp
                            where (maxDate == null || t.NgayCoHieuLuc == maxDate)
                            && listIDCanBo.Contains(t.FR_KEY)
                            select t).ToList();
        //trả về kết quả
        //lấy ngày hiệu lực gần nhất của nhân viên
        var result = (from t1 in hoso
                      join t3 in hoso_hopdong on t1.PR_KEY equals t3.FR_KEY
                      join t4 in dmLoaiHDong on t3.MA_LOAI_HDONG equals t4.MaLoaiHopDong
                      select new BHNHANVIEN_BAOHIEMInfo
                      {
                          IDNhanVien_BaoHiem = (int)t1.PR_KEY,
                          MaNhanVien = t1.MA_CB,
                          HoTen = t1.HO_TEN,
                          Ho = cm.GetLastNameFromFullName(t1.HO_TEN),
                          Ten = cm.GetFirstNamFromFullName(t1.HO_TEN),
                          MaBoPhan = t1.MA_DONVI,
                          TenBoPhan = t1.TEN_DONVI,
                          MaChucVu = t1.MA_CHUCVU,
                          TenChucVu = t1.TEN_CHUCVU,
                          LuongBaoHiem = 0,
                          NgayBatDauHopDong = t3.NGAY_HDONG,
                          TenLoaiHopDong = t4.TenLoaiHopDong,
                          DangDongBHXH = t4.BHXH,
                          DangDongBHYT = t4.BHYT,
                          DangDongBHTN = t4.BHTN,
                          PhuCapCV = 0,
                          PhuCapTNN = 0,
                          PhuCapKhac = 0,
                          PhuCapTNVK = 0
                      }).ToList();
        int IDNhanVienBaoHiem;
        string soquyetdinh;
        string tenquyetdinh;
        DateTime? ngayky;
        DateTime? Ngayhieuluc;
        DateTime? Hethieuluc;
        decimal? luongbaohiem;
        decimal? phucapcv;
        decimal? phucaptnn;
        decimal? phucaptnvk;
        decimal? phucapkhac;
        foreach (var item in result)
        {
            IDNhanVienBaoHiem = item.IDNhanVien_BaoHiem;
            new BaoHiemController().TTQuyetDinhLuongMoiNhat(IDNhanVienBaoHiem, out soquyetdinh, out tenquyetdinh, out ngayky, out Ngayhieuluc, out Hethieuluc, out luongbaohiem, out phucapcv, out phucaptnn, out phucaptnvk, out phucapkhac);
            item.PhuCapCV = phucapcv;
            item.PhuCapTNVK = phucaptnvk;
            item.PhuCapTNN = phucaptnn;
            item.PhuCapKhac = phucapkhac;
            item.LuongBaoHiem = luongbaohiem;
        }
        var kq = (from t in result

                  select t).ToList();

        count = kq.Count;
        return kq.Skip(start).Take(limit).ToList();
    }

    public void LuuNhanVienDongMoi(string manhanvien, string madonvi, string machucvu, int userid, DateTime ngaytao, bool bhxh, bool bhyt, bool bhtn,
                                    decimal LuongDongBaoHiem,
                                    decimal phucapcv,
                                    decimal phucaptnn,
                                    decimal phucaptnvk,
                                    decimal phucapkhac,
                                    DateTime? ngaydangky)
    {
        HoSoController hsc = new HoSoController();
        DAL.HOSO hoso = hsc.GetByMaCB(manhanvien);
        //Tinh luong dong bao hiem cua nhan vien a
        //Lưu vào bảng nhân viên bảo hiểm
        DAL.BHNHANVIEN_BAOHIEM nvbh = new DAL.BHNHANVIEN_BAOHIEM();
        nvbh.IDNhanVien_BaoHiem = int.Parse(hoso.PR_KEY.ToString());
        nvbh.MaNhanVien = hoso.MA_CB;
        nvbh.HoTen = hoso.HO_TEN;
        nvbh.Ten = hoso.HO_TEN.Split(' ').Last();
        nvbh.GioiTinh = hoso.MA_GIOITINH != "F";
        nvbh.NgaySinh = hoso.NGAY_SINH;
        nvbh.HoKhauThuongTruTamTru = hoso.HO_KHAU ?? "";
        nvbh.DiaChiLienHe = hoso.DIA_CHI_LH ?? "";
        nvbh.SoCMTND = hoso.SO_CMND ?? "";
        nvbh.NgayCapCMTND = hoso.NGAYCAP_CMND.ToString().Contains("0001") ? null : hoso.NGAYCAP_CMND;
        nvbh.NoiCapCMTND = hoso.MA_NOICAP_CMND ?? "";
        nvbh.MaChucVu = hoso.MA_CHUCVU ?? "";
        nvbh.LuongBaoHiem = LuongDongBaoHiem;
        nvbh.PhuCapCV = phucapcv;
        nvbh.PhuCapTNN = phucaptnn;
        nvbh.PhuCapTNVK = phucaptnvk;
        nvbh.PhuCapKhac = phucapkhac;
        nvbh.NoiDangKyKCB = hoso.MA_NOI_KCB ?? "";
        nvbh.LoaiBHYT = "";
        nvbh.SoTheBHYT = hoso.SOTHE_BHYT ?? "";
        nvbh.TrangThaiCapTheBHYT = string.IsNullOrEmpty(hoso.SOTHE_BHYT) ? "ChuaCapThe" : "DaCapThe";
        if (!hoso.NGAY_DONGBH.ToString().Contains("0001") && !hoso.NGAY_DONGBH.ToString().Contains("1900") && !string.IsNullOrEmpty(hoso.NGAY_DONGBH.ToString()))
            nvbh.TuThangBHYT = hoso.NGAY_DONGBH;
        if (!hoso.NGAY_HETHAN_BHYT.ToString().Contains("0001") && !hoso.NGAY_HETHAN_BHYT.ToString().Contains("1900") && !string.IsNullOrEmpty(hoso.NGAY_HETHAN_BHYT.ToString()))
            nvbh.DenThangBHYT = hoso.NGAY_HETHAN_BHYT;
        nvbh.DoiTuongHuongBHYTMuc = null;
        nvbh.BHXHTrangThaiDangKyCQBH = true;
        nvbh.NgayDangKyBHXH = ngaydangky;
        nvbh.TrangThaiCapSoBHXH = string.IsNullOrEmpty(hoso.SOTHE_BHXH) ? "ChuaCapSo" : "DaCapSo";
        nvbh.NoiCapSoBHXH = hoso.MA_NOICAP_BHXH ?? "";
        nvbh.NgayCapSoBHXH = hoso.NGAYCAP_BHXH;
        nvbh.SoSoBHXH = hoso.SOTHE_BHXH ?? "";
        nvbh.DangDongBHXH = bhxh;
        nvbh.DangDongBHYT = bhyt;
        nvbh.DangDongBHTN = bhtn;
        nvbh.ThoiGianDongBaoHiem = 0;
        nvbh.ThoiGianDongBHXHTruocKhiVaoCongTy = 0;
        nvbh.MaDonVi = madonvi;
        nvbh.UserID = userid;
        nvbh.DateCreate = ngaytao;
        dataContext.BHNHANVIEN_BAOHIEMs.InsertOnSubmit(nvbh);
        Save();
        //Lưu biến động đăng ký đóng mới bảo hiểm
        var bdbh = new DAL.BHBIENDONGBAOHIEM
        {
            IDQuyDinhBienDong =
                dataContext.BHQUYDINHBIENDONGs.SingleOrDefault(p => p.MaBienDong == "TDMBH").IDQuyDinhBienDong,
            IDNhanVien_BaoHiem = nvbh.IDNhanVien_BaoHiem,
            TuNgay = (DateTime)ngaydangky,
            DenNgay = null,
            Loai = dataContext.BHQUYDINHBIENDONGs.SingleOrDefault(p => p.MaBienDong == "TDMBH").LoaiAnhHuong,
            MaNhanVien = nvbh.MaNhanVien ?? "",
            HoTen = nvbh.HoTen ?? "",
            MaSo = nvbh.SoSoBHXH ?? "",
            NgaySinh = nvbh.NgaySinh,
            GioiTinh = nvbh.GioiTinh ?? true
        };
        if (dataContext.DM_CHUCVUs.SingleOrDefault(p => p.MA_CHUCVU == nvbh.MaChucVu) != null)
            bdbh.ChucVu = dataContext.DM_CHUCVUs.SingleOrDefault(p => p.MA_CHUCVU == nvbh.MaChucVu).TEN_CHUCVU;
        bdbh.TienLuongCu = 0;
        bdbh.PhuCapCVCu = 0;
        bdbh.PhuCapTNVKCu = 0;
        bdbh.PhuCapNgheCu = 0;
        //// lương bảo hiểm lấy từ hồ sơ
        //bdbh.TienLuongMoi = nvbh.LuongBaoHiem;
        // lấy ra lương đóng bảo hiểm mới nhất theo quyết định lương mới nhất nhỏ hơn ngày hiện tại
        //object a =  DataController.DataHandler.GetInstance().ExecuteScalar("sp_GetLuongDongBaoHiemHOSO_ByMaCB", "@MA_CB", nvbh.MaNhanVien);
        //bdbh.TienLuongMoi = decimal.Parse("0" + a);
        bdbh.TienLuongMoi = LuongDongBaoHiem;
        bdbh.PhuCapCVMoi = phucapcv;
        bdbh.PhuCapTNNgheMoi = phucaptnn;
        bdbh.PhuCapTNVKMoi = phucaptnvk;
        bdbh.DienGiai = "";
        bdbh.ThangDangKy = (DateTime)ngaydangky;
        bdbh.KhongTraThe = false;
        bdbh.DaCoSo = string.IsNullOrEmpty(nvbh.SoSoBHXH) ? bdbh.DaCoSo = false : bdbh.DaCoSo = true;
        bdbh.DaDuyet = true;
        bdbh.UserID = userid;
        bdbh.DateCreate = DateTime.Now;
        bdbh.MaDonVi = madonvi;
        dataContext.BHBIENDONGBAOHIEMs.InsertOnSubmit(bdbh);
        Save();
    }
}
public class tmpCB
{
    public decimal PrKey { get; set; }
    public string MaCB { get; set; }
}