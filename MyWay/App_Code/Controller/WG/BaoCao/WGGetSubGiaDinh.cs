using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for WGGetSubGiaDinh
/// </summary>
public class WGGetSubGiaDinh : LinqProvider
{
    public WGGetSubGiaDinh()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<GetSubGiaDinhInfo> GetAll(decimal prkey)
    {
        var rs = (from t in dataContext.HOSOs.Where(p => p.PR_KEY == prkey)
                  join q in dataContext.HOSO_QH_GIADINHs on t.PR_KEY equals q.FR_KEY
                  join x in dataContext.DM_QUANHEs on q.MA_QUANHE equals x.MA_QUANHE
                  select new GetSubGiaDinhInfo
                  {
                      FR_KEY = q.FR_KEY,
                      GHI_CHU = q.GHI_CHU,
                      TenQuanHe = x.TEN_QUANHE,
                      GIOI_TINH = q.GIOI_TINH,
                      HO_TEN = q.HO_TEN,
                      MA_QUANHE = q.MA_QUANHE,
                      NOI_LAMVIEC = q.NOI_LAMVIEC,
                      NGHE_NGHIEP = q.NGHE_NGHIEP,
                      PR_KEY = q.PR_KEY,
                      TUOI = q.TUOI
                  }).ToList();
        return rs;
    }
    //truyền vào 2 biến datetime? và string return
    //trả về chuỗi string có định dạng. ưu tiên value1 hơn value2
    private string GetStringFrom2Value(DateTime? value1, DateTime? value2, string strreturn)
    {
        if (value1 != null) return value1.Value.ToString("dd/MM/yyyy");
        return value2 == null ? strreturn : value2.Value.ToString("dd/MM/yyyy");
    }

    private string GetLuongFromLuongList(ref List<DAL.HOSO_LUONG> listLuong, DateTime? datelookup)
    {
        if (datelookup == null) return "";
        var date = datelookup.Value;
        var luong = listLuong.OrderByDescending(p => p.NgayHieuLuc).FirstOrDefault(p => p.NgayHieuLuc <= date);
        if (luong == null) return "";
        if (luong.LuongCung == null) return "";
        return luong.LuongCung.Value.ToString("N0");
    }

    public List<GetSubQuaTrinhLamViecInfo> GetAllSubQuaTrinhLamViec(decimal prkey)
    {
        var dieuchuyen = dataContext.HOSO_QT_DIEUCHUYENs.Where(p => p.FR_KEY == prkey).ToList();
        var dicdonvi = dataContext.DM_DONVIs.ToDictionary(p => p.MA_DONVI, p => p.TEN_DONVI);
        var listluong = dataContext.HOSO_LUONGs.Where(p => p.PrKeyHoSo == prkey && p.TrangThai == "DaDuyet").OrderByDescending(p => p.NgayHieuLuc).ToList();
        var hoso = dataContext.HOSOs.FirstOrDefault(p => p.PR_KEY == prkey);
        var rs = new List<GetSubQuaTrinhLamViecInfo>();
        if (dieuchuyen.Count == 0)
        {
            try
            {
                rs.Add(new GetSubQuaTrinhLamViecInfo
                {
                    ThoiGian = GetStringFrom2Value(hoso.NGAY_TUYEN_DTIEN, hoso.NGAY_TUYEN_CHINHTHUC, " ? ") + " => Nay",//  hoso.NGAY_TUYEN_DTIEN == null ? (hoso.NGAY_TUYEN_CHINHTHUC == null ? " ? " : hoso.NGAY_TUYEN_CHINHTHUC.Value.ToString("dd/MM/yyyy")) : hoso.NGAY_TUYEN_DTIEN.Value.ToString("dd/MM/yyyy") + " => Nay",
                    NoiDung = dicdonvi[hoso.MA_DONVI] ?? "",
                    SoVanBanQuyDinh = "",
                    ThuNhapHienTai = GetLuongFromLuongList(ref listluong, DateTime.Now),// luongmoinhat != null ? (luongmoinhat.LuongCung == null ? "" : luongmoinhat.LuongCung.Value.ToString("N0")) : ""
                });
            }
            catch (Exception)
            {
            }
        }
        if (dieuchuyen.Count == 1)
        {
            try
            {
                rs.Add(new GetSubQuaTrinhLamViecInfo
                 {
                     ThoiGian = GetStringFrom2Value(hoso.NGAY_TUYEN_DTIEN, hoso.NGAY_TUYEN_CHINHTHUC, " ? ")
                                 + " => " + GetStringFrom2Value(dieuchuyen[0].NgayCoHieuLuc, dieuchuyen[0].NgayQuyetDinh, " Nay "),
                     NoiDung = dicdonvi[dieuchuyen[0].MaBoPhanCu] ?? "",
                     SoVanBanQuyDinh = "",
                     ThuNhapHienTai = GetLuongFromLuongList(ref listluong, dieuchuyen[0].NgayCoHieuLuc ?? dieuchuyen[0].NgayQuyetDinh)
                 });
            }
            catch (Exception)
            {
            }
            try
            {
                rs.Add(new GetSubQuaTrinhLamViecInfo
                 {
                     ThoiGian = GetStringFrom2Value(dieuchuyen[0].NgayCoHieuLuc, dieuchuyen[0].NgayQuyetDinh, " ? ") + " => Nay",
                     NoiDung = dicdonvi[hoso.MA_DONVI] ?? "",
                     SoVanBanQuyDinh = dieuchuyen[0].SoQuyetDinh ?? "",
                     ThuNhapHienTai = GetLuongFromLuongList(ref listluong, DateTime.Now)// luongmoinhat == null ? "" : (luongmoinhat.LuongCung == null ? "" : luongmoinhat.LuongCung.Value.ToString("N0"))
                 });
            }
            catch (Exception)
            {
            }
        }
        if (dieuchuyen.Count > 1)
        {
            var so = dieuchuyen.Count;
            try
            {
                rs.Add(new GetSubQuaTrinhLamViecInfo
                 {
                     ThoiGian = GetStringFrom2Value(hoso.NGAY_TUYEN_DTIEN, hoso.NGAY_TUYEN_CHINHTHUC, " ? ")
                                + " => " + GetStringFrom2Value(dieuchuyen[0].NgayCoHieuLuc, dieuchuyen[0].NgayQuyetDinh, " ? "),
                     NoiDung = dicdonvi[dieuchuyen[0].MaBoPhanCu] ?? "",
                     SoVanBanQuyDinh = "",
                     ThuNhapHienTai = GetLuongFromLuongList(ref listluong, dieuchuyen[0].NgayCoHieuLuc ?? dieuchuyen[0].NgayQuyetDinh)
                 });
            }
            catch (Exception)
            {
            }

            for (var i = 1; i <= so - 1; i++)
            {
                try
                {
                    rs.Add(new GetSubQuaTrinhLamViecInfo
                         {
                             ThoiGian = GetStringFrom2Value(dieuchuyen[i - 1].NgayCoHieuLuc, dieuchuyen[i - 1].NgayQuyetDinh, " ? ")
                                          + " => " + GetStringFrom2Value(dieuchuyen[i].NgayCoHieuLuc, dieuchuyen[i].NgayQuyetDinh, " ? "),
                             NoiDung = dicdonvi[dieuchuyen[i].MaBoPhanCu] ?? "",
                             SoVanBanQuyDinh = dieuchuyen[i - 1].SoQuyetDinh ?? "",
                             ThuNhapHienTai = GetLuongFromLuongList(ref listluong, dieuchuyen[i].NgayCoHieuLuc ?? dieuchuyen[i].NgayQuyetDinh)
                         });
                }
                catch (Exception)
                {
                }
            }

            try
            {
                rs.Add(new GetSubQuaTrinhLamViecInfo
               {
                   ThoiGian = GetStringFrom2Value(dieuchuyen[so - 1].NgayCoHieuLuc, dieuchuyen[so - 1].NgayQuyetDinh, " ? ") + " => Nay",
                   NoiDung = dicdonvi[hoso.MA_DONVI] ?? "",
                   SoVanBanQuyDinh = dieuchuyen[so - 1].SoQuyetDinh ?? "",
                   ThuNhapHienTai = GetLuongFromLuongList(ref listluong, DateTime.Now)
               });
            }
            catch (Exception)
            {
            }
        }
        return rs;
    }
}

public class GetSubQuaTrinhLamViecInfo
{
    public string ThoiGian { get; set; }
    public string NoiDung { get; set; }
    public string SoVanBanQuyDinh { get; set; }
    public string ThuNhapHienTai { get; set; }
}
public class GetSubGiaDinhInfo
{
    public decimal PR_KEY { get; set; }
    public decimal FR_KEY { get; set; }
    public string HO_TEN { get; set; }
    public string TUOI { get; set; }
    public string MA_QUANHE { get; set; }
    public string TenQuanHe { get; set; }
    public string NGHE_NGHIEP { get; set; }
    public string NOI_LAMVIEC { get; set; }
    public string GIOI_TINH { get; set; }
    public string GHI_CHU { get; set; }
}