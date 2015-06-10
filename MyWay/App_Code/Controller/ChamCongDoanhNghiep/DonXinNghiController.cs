using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DonXinNghiController
/// </summary>
public class DonXinNghiController : LinqProvider
{
    public DonXinNghiController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public const string CHUA_DUYET = "ChuaDuyet";
    public const string DA_DUYET = "DaDuyet";
    public const string KHONG_DUYET = "KhongDuyet";
    public const string HOANTATTHUTUC = "HoanTatThuTuc";
    public const string MaCBHCNS = "MaCBHCNS";

    public void InsertNewOne(DAL.DonXinNghi donxinnghi)
    {
        dataContext.DonXinNghis.InsertOnSubmit(donxinnghi);
        Save();
    }
    public DAL.DonXinNghi GetDonXinNghiByID(int id)
    {
        return dataContext.DonXinNghis.Where(p => p.ID == id).SingleOrDefault();
    }
    public void UpdateDonXinNghi(DAL.DonXinNghi donxinnghi)
    {
        var item = dataContext.DonXinNghis.Where(p => p.ID == donxinnghi.ID).SingleOrDefault();
        item.KyHieuChamCong = donxinnghi.KyHieuChamCong;
        item.LyDoNghi = donxinnghi.LyDoNghi;
        item.MaCBDangDuyet = donxinnghi.MaCBDangDuyet;
        item.MaLyDoNghi = donxinnghi.MaLyDoNghi;
        item.NghiDenNgay = donxinnghi.NghiDenNgay;
        item.NghiTuNgay = donxinnghi.NghiTuNgay;
        item.PhanTramHuongLuong = donxinnghi.PhanTramHuongLuong;
        item.SoNgayNghi = donxinnghi.SoNgayNghi;
        item.SoNgayNghiCheDo = donxinnghi.SoNgayNghiCheDo;
        item.SoNgayNghiTruLuong = donxinnghi.SoNgayNghiTruLuong;
        item.SoNgayNghiTruPhep = donxinnghi.SoNgayNghiTruPhep;
        item.TrangThaiDuyet = donxinnghi.TrangThaiDuyet;
        Save();
    }
    public List<DonXinNghiInfo> GetAll(string macb, int start, int limit, string searchkey, out int count)
    {
        var result = (from t in dataContext.DonXinNghis
                      join q in dataContext.HOSOs on t.MaCBDangDuyet equals q.MA_CB
                      join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI
                      where t.MaCB == macb
                      orderby t.CreatedDate descending
                      select new DonXinNghiInfo
                      {
                          ID = t.ID,
                          LyDoNghi = t.LyDoNghi,
                          MaCB = t.MaCB,
                          MaCBDangDuyet = t.MaCBDangDuyet,
                          TenCBDangDuyet = q.HO_TEN,
                          TenPhongCBDangDuyet = x.TEN_DONVI,
                          MaLyDoNghi = t.MaLyDoNghi,
                          NghiTuNgay = t.NghiTuNgay,
                          NghiDenNgay = t.NghiDenNgay,
                          PhanTramHuongLuong = t.PhanTramHuongLuong,
                          SoNgayNghi = t.SoNgayNghi,
                          SoNgayNghiCheDo = t.SoNgayNghiCheDo,
                          SoNgayNghiTruLuong = t.SoNgayNghiTruLuong,
                          SoNgayNghiTruPhep = t.SoNgayNghiTruPhep,
                          KyHieuChamCong = t.KyHieuChamCong,
                          TrangThaiDuyet = t.TrangThaiDuyet,
                          NgayNopDon = t.CreatedDate
                      }).ToList();
        var result2 = (from t in dataContext.DonXinNghis
                       where t.MaCBDangDuyet == "" && t.MaCB == macb
                       orderby t.CreatedDate descending
                       select new DonXinNghiInfo
                       {
                           ID = t.ID,
                           LyDoNghi = t.LyDoNghi,
                           MaCB = t.MaCB,
                           MaCBDangDuyet = t.MaCBDangDuyet,
                           TenCBDangDuyet = "Phòng hành chính nhân sự",
                           TenPhongCBDangDuyet = "Phòng hành chính nhân sự",
                           MaLyDoNghi = t.MaLyDoNghi,
                           NghiTuNgay = t.NghiTuNgay,
                           NghiDenNgay = t.NghiDenNgay,
                           PhanTramHuongLuong = t.PhanTramHuongLuong,
                           SoNgayNghi = t.SoNgayNghi,
                           SoNgayNghiCheDo = t.SoNgayNghiCheDo,
                           SoNgayNghiTruLuong = t.SoNgayNghiTruLuong,
                           SoNgayNghiTruPhep = t.SoNgayNghiTruPhep,
                           KyHieuChamCong = t.KyHieuChamCong,
                           TrangThaiDuyet = t.TrangThaiDuyet,
                           NgayNopDon = t.CreatedDate
                       }).ToList();



        result = (result.Concat(result2)).ToList();
        //result = result.Union(result2).ToList();
        foreach (var item in result)
        {
            if (item.TrangThaiDuyet == DonXinNghiController.CHUA_DUYET) item.TrangThaiDuyet = "Chưa duyệt";
            if (item.TrangThaiDuyet == DonXinNghiController.DA_DUYET) item.TrangThaiDuyet = "Đã duyệt";
            if (item.TrangThaiDuyet == DonXinNghiController.HOANTATTHUTUC) item.TrangThaiDuyet = "Hoàn tất thủ tục";
            if (item.TrangThaiDuyet == DonXinNghiController.KHONG_DUYET) item.TrangThaiDuyet = "Không duyệt";
        }
        count = result.Count;
        return result.Skip(start).Take(limit).ToList();
    }
    public List<DonXinNghiInfo> GetAllDuyetDonXinNghi(string madonvi, string macbduyet, int start, int limit, string searchkey, bool hcsnduyet, string loctheotrangthai, out int count)
    {
        //Dictionary<string, string> dr = new HoSoController().TraVeTuDienHoSo();
        ////nếu macbduyet=="" thì lấy hết.
        ////lấy tất cả những người được gán
        //var result = (from t in dataContext.DonXinNghis
        //              join q in dataContext.HOSOs on t.MaCB equals q.MA_CB
        //              join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI
        //              where (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(q.HO_TEN, searchkey)
        //                                                      || System.Data.Linq.SqlClient.SqlMethods.Like(q.MA_CB, searchkey)))
        //                    && (t.MaCBDangDuyet==macbduyet)
        //              select new DonXinNghiInfo
        //              {
        //                  ID = t.ID,
        //                  MaCB = t.MaCB,
        //                  HoTen = q.HO_TEN,
        //                  BoPhan = x.TEN_DONVI,
        //                  MaCBDangDuyet=t.MaCBDangDuyet,
        //                  TenCBDangDuyet="",
        //                  NgayNopDon = t.CreatedDate,
        //                  NghiTuNgay = t.NghiTuNgay,
        //                  NghiDenNgay = t.NghiDenNgay,
        //                  LyDoNghi = t.LyDoNghi,
        //                  SoNgayNghi=t.SoNgayNghi,
        //                  TrangThaiDuyet = t.TrangThaiDuyet
        //              }).ToList();
        ////lấy tất cả những người có lịch sử được gán
        //var result2=(from t in dataContext.DonXinNghis
        //              join a in dataContext.DonXinNghiLichSus on t.ID equals a.IDDonXinNghi
        //              join q in dataContext.HOSOs on t.MaCB equals q.MA_CB
        //              join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI
        //              where (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(q.HO_TEN, searchkey)
        //                                                      || System.Data.Linq.SqlClient.SqlMethods.Like(q.MA_CB, searchkey)))
        //                    && (a.MaCBDuyet==macbduyet)
        //              select new DonXinNghiInfo
        //              {
        //                  ID = t.ID,
        //                  MaCB = t.MaCB,
        //                  HoTen = q.HO_TEN,
        //                  MaCBDangDuyet=t.MaCBDangDuyet,
        //                  TenCBDangDuyet="",
        //                  BoPhan = x.TEN_DONVI,
        //                  NgayNopDon = t.CreatedDate,
        //                  NghiTuNgay = t.NghiTuNgay,
        //                  NghiDenNgay = t.NghiDenNgay,
        //                  LyDoNghi = t.LyDoNghi,
        //                  SoNgayNghi=t.SoNgayNghi,
        //                  TrangThaiDuyet = t.TrangThaiDuyet
        //              }).ToList();
        //result = result.Union(result2).OrderBy(p => p.NgayNopDon).ToList();
        //foreach (var item in result)
        //{
        //    if (dr.ContainsKey(item.MaCBDangDuyet)) item.TenCBDangDuyet = dr[item.MaCBDangDuyet];
        //    else item.TenCBDangDuyet = "Phòng HCNS";
        //}

        var result = (from t in dataContext.DonXinNghis
                      join q in dataContext.HOSOs on t.MaCB equals q.MA_CB
                      join x in dataContext.DM_DONVIs on q.MA_DONVI equals x.MA_DONVI
                      join a in dataContext.DonXinNghiLichSus on t.ID equals a.IDDonXinNghi into tam
                      from bang in tam.DefaultIfEmpty()
                      where (string.IsNullOrEmpty(searchkey) ? 1 == 1 : (System.Data.Linq.SqlClient.SqlMethods.Like(q.HO_TEN, searchkey)
                                                              || System.Data.Linq.SqlClient.SqlMethods.Like(q.MA_CB, searchkey)))
                            && (((t.MaCBDangDuyet == macbduyet || bang.MaCBDuyet == macbduyet) && hcsnduyet == false)
                            || (hcsnduyet == true && (t.MaCBDangDuyet == "" || bang.HCNSDuyet == true)))
                      select new DonXinNghiInfo
                      {
                          ID = t.ID,
                          MaCB = t.MaCB,
                          HoTen = q.HO_TEN,
                          BoPhan = x.TEN_DONVI,
                          MaCBDangDuyet = t.MaCBDangDuyet,
                          TenCBDangDuyet = "",
                          NgayNopDon = t.CreatedDate,
                          NghiTuNgay = t.NghiTuNgay,
                          NghiDenNgay = t.NghiDenNgay,
                          LyDoNghi = t.LyDoNghi,
                          SoNgayNghi = t.SoNgayNghi,
                          TrangThaiDuyet = t.TrangThaiDuyet,
                          KyHieuChamCong = t.KyHieuChamCong,
                          MaLyDoNghi = t.MaLyDoNghi,
                          PhanTramHuongLuong = t.PhanTramHuongLuong,
                          SoNgayNghiCheDo = t.SoNgayNghiCheDo,
                          SoNgayNghiTruLuong = t.SoNgayNghiTruLuong,
                          SoNgayNghiTruPhep = t.SoNgayNghiTruPhep
                      }).ToList();

        Dictionary<string, string> dr = new HoSoController().TraVeTuDienHoSo();
        result = result.GroupBy(p => p.ID).Select(t => t.First()).ToList();
        foreach (var item in result)
        {
            if (dr.ContainsKey(item.MaCBDangDuyet)) item.TenCBDangDuyet = dr[item.MaCBDangDuyet];
            else item.TenCBDangDuyet = "Phòng HCNS";
            if (item.TrangThaiDuyet == DonXinNghiController.CHUA_DUYET)
            {
                //là cán bộ bình thường
                if (macbduyet != item.MaCBDangDuyet && hcsnduyet == false) item.TrangThaiDuyet = DonXinNghiController.DA_DUYET;
                //là cbhcsn
                if (item.MaCBDangDuyet != "" && hcsnduyet == true) item.TrangThaiDuyet = DonXinNghiController.DA_DUYET;
            }

        }
        result = (from t in result
                  where (loctheotrangthai == "" ? 1 == 1 : t.TrangThaiDuyet == loctheotrangthai)
                  select t).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).OrderBy(p => p.TrangThaiDuyet).ThenBy(p => p.NgayNopDon).ToList();
    }
    public void InsertDonXinNghiLichSu(DAL.DonXinNghiLichSu donlichsu)
    {
        dataContext.DonXinNghiLichSus.InsertOnSubmit(donlichsu);
        Save();
    }
    public List<DonXinNghiLichSuInfo> GetAllDonXinNghiLichSu(int iddonxinnghi, out int count)
    {
        var result = (from t in dataContext.DonXinNghiLichSus
                      join q in dataContext.HOSOs on t.MaCBDuyet equals q.MA_CB
                      orderby t.NgayDuyet descending
                      where t.IDDonXinNghi == iddonxinnghi
                      select new DonXinNghiLichSuInfo
                      {
                          GhiChu = t.GhiChu,
                          MaCBDuyet = t.MaCBDuyet,
                          NgayDuyet = t.NgayDuyet,
                          TenCBDuyet = q.HO_TEN,
                          TrangThai = t.TrangThai,
                      }).ToList();
        var result2 = (from t in dataContext.DonXinNghiLichSus
                       orderby t.NgayDuyet descending
                       where t.IDDonXinNghi == iddonxinnghi
                             && t.MaCBDuyet == ""
                       select new DonXinNghiLichSuInfo
                       {
                           GhiChu = t.GhiChu,
                           MaCBDuyet = t.MaCBDuyet,
                           NgayDuyet = t.NgayDuyet,
                           TenCBDuyet = "Phòng HCNS",
                           TrangThai = t.TrangThai,
                       }).ToList();
        result = result.Union(result2).OrderByDescending(p => p.NgayDuyet).ToList();
        count = result.Count;
        return result;
    }
    public bool CheckCBHCSN(int currentid)
    {
        bool kq = false;
        string macb = new HoSoController().GetByUserID(currentid).MA_CB;
        var thamso = new ThamSoTrangThaiController().GetByParamName(MaCBHCNS, true);
        foreach (var item in thamso)
        {
            foreach (var x in item.Value.Split(','))
            {
                if (macb == x) kq = true;
            }
        }
        return kq;
    }

    public DAL.DonXinNghi GetByHoanTatThuTuc(string maCB, DateTime ngay)
    {
        var rs = from t in dataContext.DonXinNghis
                 where t.MaCB == maCB && t.NghiTuNgay < ngay && t.NghiDenNgay > ngay
                    && t.TrangThaiDuyet == HOANTATTHUTUC
                 select t;
        return rs.FirstOrDefault();
    }
}