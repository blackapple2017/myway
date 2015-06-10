using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TinhLuongKhoanController
/// </summary>
public class TinhLuongKhoanController : LinqProvider
{
    public TinhLuongKhoanController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //private string GetCongThuc(ref List<bangtam.bangcongthuc> congthuc, string maca, decimal sanluonggio, int chisocot, int thamnien, string mabophan, string machucvu, string mavitricongviec)
    //{
    //    int prmax = -1, somax = -1;
    //    foreach (var item in congthuc.Where(p => p.TenCot == chisocot && p.ThamNien <= thamnien))
    //    {
    //        int dem = 0;
    //        if (item.MaBoPhan.IndexOf(mabophan) >= 0 && mabophan != "") dem++;
    //        if (item.ChucVu.IndexOf(machucvu) >= 0 && machucvu != "") dem++;
    //        if (item.ViTriCongViec.IndexOf(mavitricongviec) >= 0 && mavitricongviec != "") dem++;
    //        if (dem > somax) { prmax = item.PRKEY; somax = dem; }
    //    }

    //    bangtam.bangcongthuc obj = congthuc.OrderBy(p=>p.).FirstOrDefault(p => p.PRKEY == prmax);
    //    if (obj == null) return "";
    //    else if (obj.EditAble == false) return "";
    //    else return obj.CongThuc;
    //}

    private double GetLuong(string ma_cb)
    {
        //lấy tất cả những quyết định lương của ông có id= idnhanvienbaohiem
        List<DAL.HOSO_LUONG> tmp = dataContext.HOSO_LUONGs.Where(p => p.NgayHieuLuc <= DateTime.Now && p.TrangThai == "DaDuyet" && p.HOSO.MA_CB == ma_cb).ToList();
        //lấy quyết định lương gần đây nhất. bỏ qua việc xác nhận lỗi có 2 bản ghi cùng ngày hiệu lực
        DAL.HOSO_LUONG quyetdinhluong = tmp.SingleOrDefault(p => p.NgayHieuLuc == tmp.Max(v => v.NgayHieuLuc));
        return quyetdinhluong == null ? 0 : (quyetdinhluong.LuongCung ?? 0);
    }

    public double GetLuongDongBH(decimal prkey, DateTime dtime)
    {
        string sql = "select dbo.f_GetLuongDongBHTrongThang(" + prkey + ", '" + dtime.Year + "-" + dtime.Month + "-" + dtime.Day + "')";
        return double.Parse(DataController.DataHandler.GetInstance().ExecuteScalar(sql).ToString());
    }

    public List<LuongKhoanSanPhamInfo> GetLuongKhoanSanPham(int start, int limit, int month, int year, string maDonVi, string searchKey, int userID, int menuID, out int count)
    {
        string[] dsdv = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(',');
        string[] listSelected = new DM_DONVIController().GetAllMaDonVi(maDonVi).Split(',');
        var rs = from hs in dataContext.HOSOs
                 join tmpVaoRa in dataContext.ChamCongKhoanAustfeeds on hs.MA_CB equals tmpVaoRa.MaCB into tmp1
                 from vr in tmp1.DefaultIfEmpty()
                 join tmpChucVu in dataContext.DM_CHUCVUs on hs.MA_CHUCVU equals tmpChucVu.MA_CHUCVU into tmp2
                 from cv in tmp2.DefaultIfEmpty()
                 join donvi in dataContext.DM_DONVIs on hs.MA_DONVI equals donvi.MA_DONVI into tmp3
                 from dv in tmp3.DefaultIfEmpty()
                 where (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(hs.MA_CB, searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(hs.HO_TEN, searchKey))
                    && vr.MonthYear.Month == month && vr.MonthYear.Year == year
                    && (string.IsNullOrEmpty(maDonVi) || listSelected.Contains(hs.MA_DONVI))
                    && dsdv.Contains(hs.MA_DONVI)
                 let SalaryInfo = (from hsl in dataContext.HOSO_LUONGs where hsl.PrKeyHoSo == hs.PR_KEY select hsl).OrderByDescending(p => p.NgayHieuLuc).FirstOrDefault()
                 select new LuongKhoanSanPhamInfo
                 {
                     MaCanBo = hs.MA_CB,
                     HoTen = hs.HO_TEN,
                     TenCanBo = hs.TEN_CB,
                     ChucVu = cv.TEN_CHUCVU,
                     LuongQuyetDinh = SalaryInfo == null ? 0 : SalaryInfo.LuongCung,
                     SoGioDangKy = vr.SoGioDangKy,
                     SoGioLamViec = vr.SoGioLamViec,
                     SanPhamChinh = vr.SanPhamChinh,
                     SanPhamPhu = vr.SanPhamPhu,
                     LuongSanPham = vr.LuongSanPham,
                     LuongCongNhat = vr.LuongCongNhat,
                     LuongKhac = vr.LuongKhac,
                     LuongHoTro = vr.LuongHoTro,
                     TongLuong = vr.LuongSanPham + vr.LuongCongNhat + 
                        (decimal)(vr.LuongHoTro * (SalaryInfo.LuongDongBHXH == null ? 0 : SalaryInfo.LuongDongBHXH) / 100) + 
                        vr.LuongKhac,
                     Ngay = vr.MonthYear.Day,
                     MaDonVi = dv.MA_DONVI,
                     TenDonVi = dv.TEN_DONVI
                 };
        count = rs.ToList().Count;
        return rs.OrderBy(t => t.TenCanBo).ToList();
    }

    public DAL.ChamCongKhoanAustfeed GetByMaCanBoAndDay(string maCanBo, int ngay, int thang, int nam)
    {
        var rs = from t in dataContext.ChamCongKhoanAustfeeds
                 join tmphs in dataContext.HOSOs on t.MaCB equals tmphs.MA_CB into tmp1
                 from hs in tmp1.DefaultIfEmpty()
                 where t.MaCB == maCanBo && t.MonthYear.Day == ngay
                    && t.MonthYear.Month == thang && t.MonthYear.Year == nam
                 select t;
        return rs.FirstOrDefault();
    }

    public void Insert(DAL.ChamCongKhoanAustfeed vaoRa)
    {
        if (vaoRa != null)
        {
            dataContext.ChamCongKhoanAustfeeds.InsertOnSubmit(vaoRa);
            Save();
        }
    }

    public void Update(DAL.ChamCongKhoanAustfeed vaoRa)
    {
        DAL.ChamCongKhoanAustfeed temp = dataContext.ChamCongKhoanAustfeeds.SingleOrDefault(t => t.MaCB == vaoRa.MaCB
                && t.MonthYear.Day == vaoRa.MonthYear.Day
                && t.MonthYear.Month == vaoRa.MonthYear.Month
                && t.MonthYear.Year == vaoRa.MonthYear.Year);
        if (temp != null)
        {
            temp.SoGioDangKy = vaoRa.SoGioDangKy;
            temp.SoGioLamViec = vaoRa.SoGioLamViec;
            temp.SoGioCaTo = vaoRa.SoGioCaTo;
            temp.SanPhamChinh = vaoRa.SanPhamChinh;
            temp.SanPhamPhu = vaoRa.SanPhamPhu;
            temp.LuongSanPham = vaoRa.LuongSanPham;
            Save();
        }
    }

    public void DeleteByDay(string maCanBo, int year, int month, int day)
    {
        DAL.ChamCongKhoanAustfeed temp = dataContext.ChamCongKhoanAustfeeds.SingleOrDefault(t => t.MaCB == maCanBo && t.MonthYear.Year == year
                && t.MonthYear.Month == month && t.MonthYear.Day == day);
        if (temp != null)
        {
            dataContext.ChamCongKhoanAustfeeds.DeleteOnSubmit(temp);
            Save();
        }
    }

    public void DeleteByEmployeeCode(string maCanBo)
    {
        List<DAL.ChamCongKhoanAustfeed> dsChamCong = dataContext.ChamCongKhoanAustfeeds.Where(t => t.MaCB == maCanBo).ToList();
        if (dsChamCong.Count() > 0)
        {
            dataContext.ChamCongKhoanAustfeeds.DeleteAllOnSubmit(dsChamCong);
            Save();
        }
    }
}