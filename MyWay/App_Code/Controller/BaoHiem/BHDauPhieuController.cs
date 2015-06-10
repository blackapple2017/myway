using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Summary description for BHDauPhieuController
/// </summary>
public class BHDauPhieuController : LinqProvider
{
    public List<BHDAUPHIEUInfo> GetDauPhieuByParent(string LoaiChungTu)
    {
        var t = from p in dataContext.BHDAUPHIEUs
                where p.LoaiChungTu == LoaiChungTu
                select new BHDAUPHIEUInfo
                {
                    IdDauPhieu = p.IDDauPhieu,
                    LoaiChungTu = p.LoaiChungTu,
                    TenChungTu = p.TenChungTu
                };
        return t.ToList();
    }
    public List<BHDAUPHIEUInfo> GetDauPhieuByParentByNam(string LoaiChungTu, string Nam)
    {
        var t = from p in dataContext.BHDAUPHIEUs
                where p.LoaiChungTu == LoaiChungTu && p.TuNgay.Year.ToString() == Nam
                select new BHDAUPHIEUInfo
                {
                    IdDauPhieu = p.IDDauPhieu,
                    LoaiChungTu = p.LoaiChungTu,
                    TenChungTu = p.TenChungTu
                };
        return t.ToList();
    }
    public string TinhThoiGian(DateTime d1, DateTime d2)
    {
        d1 = d1.Date;
        d2 = d2.Date;
        string _bc = "";
        if (d1.Day == d2.Day && d1.Month == d2.Month && d1.Year == d2.Year)
        {
            _bc = "Ngày " + d1.ToString("dd") + " tháng " + d1.ToString("MM") + " năm " + d1.ToString("yyyy");
        }
        else
            if (d1.Day != 1)
            {
                _bc = "Từ ngày " + d1.ToString("dd/MM/yyyy") + " đến ngày " + d2.ToString("dd/MM/yyyy");
            }
            else if (d1 == d2.AddDays(1).AddMonths(-1))
            {
                _bc = "Tháng " + d1.ToString("MM") + " năm " + d1.ToString("yyyy");
            }
            else if (d1.Year == d2.Year && d1.Month == 1 && d2.Month == 12 && d2.Day == 31)
            {
                _bc = "Năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 1 && d2.Day == 31 && d2.Month == 3)
            {
                _bc = "Quý I năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 4 && d2.Day == 30 && d2.Month == 6)
            {
                _bc = "Quý II năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 7 && d2.Day == 30 && d2.Month == 9)
            {
                _bc = "Quý III năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 10 && d2.Day == 31 && d2.Month == 12)
            {
                _bc = "Quý IV năm " + d2.ToString("yyyy");
            }

            else
            {
                _bc = "Từ ngày " + d1.ToString("dd/MM/yyyy") + " đến ngày " + d2.ToString("dd/MM/yyyy");
            }
        return _bc;
    }
    public string GetQuy(DateTime TuNgay, DateTime DenNgay)
    {
        string Ngay = "";
        if (TuNgay.Month == 1 && DenNgay.Month == 3)
        {
            Ngay = "Quý 1";
        }
        if (TuNgay.Month == 4 && DenNgay.Month == 6)
        {
            Ngay = "Quý 2";
        }
        if (TuNgay.Month == 7 && DenNgay.Month == 9)
        {
            Ngay = "Quý 3";

        }
        if (TuNgay.Month == 10 & DenNgay.Month == 12)
        {
            Ngay = "Quý 4";
        }
        if (TuNgay.Month == DenNgay.Month)
        {
            Ngay = TuNgay.Month.ToString();
        }
        return Ngay;
    }
    public void Quy(string thoigian, int NamBaoCao, out DateTime? TuNgay, out DateTime? DenNgay)
    {

        DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
        dtfi.ShortDatePattern = "dd-MM-yyyy";
        dtfi.DateSeparator = "-";
        switch (thoigian)
        {
            case "Quý 1":
                //if (Convert.ToInt32(NamBaoCao) == DateTime.Now.Year)
                //{
                //    string ngay1 = DateTime.DaysInMonth(DateTime.Now.Year, 3).ToString();
                //    TuNgay = Convert.ToDateTime("01-01-" + DateTime.Now.Year + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay1 + "-03-" + DateTime.Now.Year + "", dtfi);
                //    break;
                //}
                //else
                //{
                //    string ngay1 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao), 3).ToString();
                //    TuNgay = Convert.ToDateTime("01-01-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay1 + "-03-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    break;
                //}
                string ngay1 = DateTime.DaysInMonth(NamBaoCao, 3).ToString();
                TuNgay = Convert.ToDateTime("01-01-" + NamBaoCao + "", dtfi);
                DenNgay = Convert.ToDateTime("" + ngay1 + "-03-" + NamBaoCao + "", dtfi);
                break;
            case "Quý 2":
                //if (Convert.ToInt32(NamBaoCao) == DateTime.Now.Year)
                //{
                //    string ngay2 = DateTime.DaysInMonth(DateTime.Now.Year, 6).ToString();
                //    TuNgay = Convert.ToDateTime("01-04-" + DateTime.Now.Year + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay2 + "-06-" + DateTime.Now.Year + "", dtfi);
                //    break;
                //}
                //else
                //{
                //    string ngay2 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao), 6).ToString();
                //    TuNgay = Convert.ToDateTime("01-04-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay2 + "-06-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    break;
                //}
                string ngay2 = DateTime.DaysInMonth(NamBaoCao, 6).ToString();
                    TuNgay = Convert.ToDateTime("01-04-" + NamBaoCao + "", dtfi);
                    DenNgay = Convert.ToDateTime("" + ngay2 + "-06-" + NamBaoCao + "", dtfi);
                    break;
            case "Quý 3":
                //if (Convert.ToInt32(NamBaoCao) == DateTime.Now.Year)
                //{
                //    string ngay3 = DateTime.DaysInMonth(DateTime.Now.Year, 9).ToString();
                //    TuNgay = Convert.ToDateTime("01-07-" + DateTime.Now.Year + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay3 + "-09-" + DateTime.Now.Year + "", dtfi);
                //    break;
                //}
                //else
                //{
                //    string ngay3 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao), 9).ToString();
                //    TuNgay = Convert.ToDateTime("01-07-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay3 + "-09-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    break;
                //}
                string ngay3 = DateTime.DaysInMonth(NamBaoCao, 9).ToString();
                    TuNgay = Convert.ToDateTime("01-07-" + NamBaoCao + "", dtfi);
                    DenNgay = Convert.ToDateTime("" + ngay3 + "-09-" + NamBaoCao + "", dtfi);
                    break;
            case "Quý 4":
                //if (Convert.ToInt32(NamBaoCao) == DateTime.Now.Year)
                //{
                //    string ngay4 = DateTime.DaysInMonth(DateTime.Now.Year, 12).ToString();
                //    TuNgay = Convert.ToDateTime("01-10-" + DateTime.Now.Year + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay4 + "-12-" + DateTime.Now.Year + "", dtfi);
                //    break;
                //}
                //else
                //{
                //    string ngay4 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao), 12).ToString();
                //    TuNgay = Convert.ToDateTime("01-10-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay4 + "-12-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    break;
                //}
                 string ngay4 = DateTime.DaysInMonth(NamBaoCao, 12).ToString();
                    TuNgay = Convert.ToDateTime("01-10-" + NamBaoCao + "", dtfi);
                    DenNgay = Convert.ToDateTime("" + ngay4 + "-12-" + NamBaoCao + "", dtfi);
                    break;
            case "Cả năm":
                //if (Convert.ToInt32(NamBaoCao) == DateTime.Now.Year)
                //{
                //    string ngay6 = DateTime.DaysInMonth(DateTime.Now.Year, 12).ToString();
                //    TuNgay = Convert.ToDateTime("01-01-" + DateTime.Now.Year + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay6 + "-12-" + DateTime.Now.Year + "", dtfi);
                //    break;
                //}
                //else
                //{
                //    string ngay6 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao), 12).ToString();
                //    TuNgay = Convert.ToDateTime("01-01-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    DenNgay = Convert.ToDateTime("" + ngay6 + "-12-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
                //    break;
                //}
                string ngay6 = DateTime.DaysInMonth(NamBaoCao, 12).ToString();
                    TuNgay = Convert.ToDateTime("01-01-" + NamBaoCao + "", dtfi);
                    DenNgay = Convert.ToDateTime("" + ngay6 + "-12-" + NamBaoCao + "", dtfi);
                    break;
            case "Chọn khoảng thời gian":
                string ngay10 = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString();
                TuNgay = Convert.ToDateTime("01" + "-" + DateTime.Now.Month.ToString() + "-" + Convert.ToInt32(NamBaoCao), dtfi);
                DenNgay = Convert.ToDateTime(ngay10 + "-" + DateTime.Now.Month.ToString() + "-" + Convert.ToInt32(NamBaoCao), dtfi);
                break;
            default:
                //if (Convert.ToInt32(NamBaoCao) == DateTime.Now.Year)
                //{
                //    string ngay5 = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(thoigian)).ToString();
                if (thoigian == "1")
                {
                    TuNgay = Convert.ToDateTime("15-12-" + (NamBaoCao - 1) + "", dtfi);
                }
                else
                    TuNgay = Convert.ToDateTime("15-" + (Convert.ToInt32(thoigian) - 1) + "-" + NamBaoCao + "", dtfi);

                DenNgay = Convert.ToDateTime("14-" + Convert.ToInt32(thoigian) + "-" + NamBaoCao + "", dtfi);
                break;
            //}
            //else
            //{
            //    string ngay5 = DateTime.DaysInMonth(Convert.ToInt32(NamBaoCao), Convert.ToInt32(thoigian)).ToString();
            //    TuNgay = Convert.ToDateTime("01-" + Convert.ToInt32(thoigian) + "-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
            //    DenNgay = Convert.ToDateTime("" + ngay5 + "-" + Convert.ToInt32(thoigian) + "-" + Convert.ToInt32(NamBaoCao) + "", dtfi);
            //    break;
            //}
        }
    }
    public DAL.BHDAUPHIEU GetByPrKey(int prkey)
    {
        var rs = from t in dataContext.BHDAUPHIEUs
                 where t.IDDauPhieu == prkey
                 select t;
        return rs.FirstOrDefault();
    }
    public void Delete(int prekey)
    {
        DAL.BHDAUPHIEU tmp = dataContext.BHDAUPHIEUs.SingleOrDefault(t => t.IDDauPhieu == prekey);
        if (tmp != null)
        {
            dataContext.BHDAUPHIEUs.DeleteOnSubmit(tmp);
            Save();
        }
    }
    public void Insert(DAL.BHDAUPHIEU item)
    {
        dataContext.BHDAUPHIEUs.InsertOnSubmit(item);
        Save();
    }
    public void Update(DAL.BHDAUPHIEU item)
    {
        DAL.BHDAUPHIEU tmp = dataContext.BHDAUPHIEUs.SingleOrDefault(p => p.IDDauPhieu == item.IDDauPhieu);
        tmp.TenChungTu = item.TenChungTu;
        tmp.So = item.So;
        tmp.MoTaiNganHang = item.MoTaiNganHang;
        tmp.SoLaoDongNu = item.SoLaoDongNu;
        tmp.TongSoLaoDong = item.TongSoLaoDong;
        tmp.TongQuyLuongTrongQuy = item.TongQuyLuongTrongQuy;
        tmp.TuNgay = item.TuNgay;
        tmp.DenNgay = item.DenNgay;
        dataContext.SubmitChanges();
        Save();
    }
    public DAL.BHDAUPHIEU GetByIdDauPhieu(int id)
    {
        var rs = (from t in dataContext.BHDAUPHIEUs
                  where t.IDDauPhieu == id
                  select t).FirstOrDefault();
        return rs;
    }
    public List<BHDAUPHIEUInfo> GetCheDo(string madonvi, int start, int limit, out int count)
    {
        List<BHDAUPHIEUInfo> rs = (from t in dataContext.BHDAUPHIEUs
                                   where t.MaDonVi == madonvi
                                   && t.LoaiChungTu != "D02-TS"
                                   select new BHDAUPHIEUInfo
                                   {
                                       IdDauPhieu = t.IDDauPhieu,
                                       LoaiChungTu = t.LoaiChungTu,
                                       TenChungTu = t.TenChungTu,
                                       TuNgay = t.TuNgay,
                                       DenNgay = t.DenNgay,
                                       MaDonVi = t.MaDonVi
                                   }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
    public List<BHDAUPHIEUInfo> GetBienDong(string madonvi, int start, int limit, out int count)
    {
        List<BHDAUPHIEUInfo> rs = (from t in dataContext.BHDAUPHIEUs
                                   where t.MaDonVi == madonvi
                                   && t.LoaiChungTu == "D02-TS"
                                   select new BHDAUPHIEUInfo
                                   {
                                       IdDauPhieu = t.IDDauPhieu,
                                       LoaiChungTu = t.LoaiChungTu,
                                       TenChungTu = t.TenChungTu,
                                       TuNgay = t.TuNgay,
                                       DenNgay = t.DenNgay,
                                       MaDonVi = t.MaDonVi
                                   }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }
}