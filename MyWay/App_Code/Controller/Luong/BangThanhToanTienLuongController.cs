using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using Spire.Xls;
using System.Threading;
using System.Globalization;

//using Spire.Xls;
//using Excel = Microsoft.Office.Interop.Excel;

/// <summary>
/// Summary description for BangThanhToanTienLuongController
/// </summary>
public class BangThanhToanTienLuongController : LinqProvider
{
    public BangThanhToanTienLuongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<BangThanhToanTienLuongInfo> GetAll(int idDanhSachBangTinhLuong, int start, int limit, out int count)
    {
        List<BangThanhToanTienLuongInfo> bangthanhtoan =
            (
                from t in dataContext.BangThanhToanLuongs
                where t.IdBangLuong == idDanhSachBangTinhLuong
                select new BangThanhToanTienLuongInfo
                {
                    ID = t.ID,
                    MaCB = t.MaCB,
                    LuongCoBan = t.LuongCoBan,
                    LuongTrachNhiem = t.LuongTrachNhiem,
                }
            ).ToList();
        count = bangthanhtoan.Count;
        return bangthanhtoan.Skip(start).Take(limit).ToList();
    }
    public BangThanhToanTienLuongInfo GetChiTietLuongByID(int id)
    {
        return (from t in dataContext.BangThanhToanLuongs
                where t.ID == id
                select new BangThanhToanTienLuongInfo
                {
                    ID = t.ID,
                    LuongCoBan = t.LuongCoBan,
                    LuongTrachNhiem = t.LuongTrachNhiem,
                    PhuCapTienAn = t.PhuCapTienAn,
                    PhuCapChucVu = t.PhuCapChucVu,
                    PhuCapKiemNhiem = t.PhuCapKiemNhiem,
                    PhuCapKhac = t.PhuCapKhac,
                    LuongThoiGianNgayThuong = t.LuongThoiGianNgayThuong,
                    LuongThemGio = t.LuongThemGio,
                    LuongThuong = t.LuongThuong,
                    LuongThang13 = t.LuongThang13,
                    ATM = t.ATM,
                    TienMat = t.TienMat
                }).SingleOrDefault();
    }
    public void UpdateChiTietTienLuong(BangThanhToanTienLuongInfo item)
    {
        var change = dataContext.BangThanhToanLuongs.Where(p => p.ID == item.ID).FirstOrDefault();
        change.LuongCoBan = item.LuongCoBan;
        change.LuongBaoHiem = item.LuongBaoHiem;
        change.PhuCapChucVu = item.PhuCapChucVu;
        change.PhuCapKiemNhiem = item.PhuCapKiemNhiem;
        change.LuongSanPham = item.LuongSanPham;
        change.LuongThuong = item.LuongThuong;
        change.ChuyenCan = item.ChuyenCan;
        change.LamThem = item.LamThem;
        change.TongLuong = item.TongLuong;
        change.GiamTruBHXH = item.GiamTruBHXH;
        change.GiamTruBHYT = item.GiamTruBHYT;
        change.GiamTruBHTN = item.GiamTruBHTN;
        change.GiamTruTienPhat = item.GiamTruTienPhat;
        change.ThueTNCNPhaiNop = item.ThueTNCNPhaiNop;
        change.TamUng = item.TamUng;
        change.GiamTruKhac = item.GiamTruKhac;
        change.TongGiamTru = item.TongGiamTru;
        change.ThucLinh = item.ThucLinh;
        Save();
    }

    /// <summary>
    /// Lấy chi tiết phiếu lương của một người
    /// </summary>
    /// <param name="maCB"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public DAL.BangThanhToanLuong GetSalarySheet(string maCB, int idBangLuong)
    {
        return dataContext.BangThanhToanLuongs.Where(t => t.IdBangLuong == idBangLuong && t.MaCB == maCB).FirstOrDefault();
    }

    public bool CheckDuLieuBangLuong(int IDDanhSachBangLuong)
    {
        if (dataContext.BangThanhToanLuongs.Where(p => p.IdBangLuong == IDDanhSachBangLuong).ToList().Count > 0)
            return false;
        else return true;

    }
    public bool CheckDaKhoa(int IDDanhSachBangTongHopCong)
    {
        return dataContext.DanhSachBangTongHopCongs.Where(p => p.ID == IDDanhSachBangTongHopCong).FirstOrDefault().Lock;
    }
    public string InsertToBangThanhToanLuong(string MaDonVi, int IDDanhSachBangLuong, int IDDanhSachBangTongHopCong)
    {

        var data = (from t in dataContext.TongHopCongs
                    where t.IdDanhSachBangTongHopCong == IDDanhSachBangTongHopCong
                    select new
                    {
                        t.MA_CB
                    }).ToList();
        foreach (var item in data)
        {
            var x = new DAL.BangThanhToanLuong()
            {
                MaCB = item.MA_CB,
                IdBangLuong = IDDanhSachBangLuong
            };
            dataContext.BangThanhToanLuongs.InsertOnSubmit(x);
        }
        dataContext.SubmitChanges();
        DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_UpdateThongTinLuong", "@idBangLuong", IDDanhSachBangLuong);
        string loi = XuLiCongThuc(IDDanhSachBangLuong, MaDonVi, "");
        return loi;
        // DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_TinhToanThongTinLuong", "@idBangLuong", IDDanhSachBangLuong); 
    }

    private string GetCongThuc(ref List<bangtam.bangcongthuc> congthuc, int chisocot, string mabophan, string machucvu, string mavitricongviec, int thamnien)
    {
        int prmax = -1, somax = -1;
        foreach (var item in congthuc.Where(p => p.TenCot == chisocot && p.ThamNien <= thamnien))
        {
            int dem = 0;
            if (item.MaBoPhan.IndexOf(mabophan) >= 0 && mabophan != "") dem++;
            if (item.ChucVu.IndexOf(machucvu) >= 0 && machucvu != "") dem++;
            if (item.ViTriCongViec.IndexOf(mavitricongviec) >= 0 && mavitricongviec != "") dem++;
            if (dem > somax) { prmax = item.PRKEY; somax = dem; }
        }

        bangtam.bangcongthuc obj = congthuc.FirstOrDefault(p => p.PRKEY == prmax);
        if (obj == null) return "";
        else if (obj.EditAble == false) return "";
        else return obj.CongThuc;
    }
    private List<string> GetColumnNames(DataTable table)
    {
        if (table != null)
        {
            List<string> lstColNames =
            (from DataColumn col in table.Columns
             select col.ColumnName).ToList();

            return lstColNames;
        }
        return null;
    }
    public int GetIDBangThanhToanLuongByIDBangTongHopCong(int idbangtonghopcong)
    {
        var bangtonghopcong = dataContext.DanhSachBangTongHopCongs.FirstOrDefault(p => p.ID == idbangtonghopcong);
        if (bangtonghopcong == null) return 0;

        var bangtinhluong = dataContext.DanhSachBangLuongs.FirstOrDefault(p => p.Month == bangtonghopcong.FromDate.Month && p.Year == bangtonghopcong.FromDate.Year && p.DaKhoa == false);
        if (bangtinhluong == null) return 0;
        return bangtinhluong.ID;
    }
    public string XuLiCongThuc(int idBangLuong, string MaDonVi, string MaNhanVien)
    {

        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("DTHSoft_GetAllBangThanhToanLuong", "@idBangLuong", "@MaDonVi", "@MaNhanVien", idBangLuong, MaDonVi, MaNhanVien);
        var congthuc = (from t in dataContext.BangCongThucLuongs
                        orderby t.TenCot ascending, t.MaBoPhan ascending, t.ChucVu ascending, t.ViTriCongViec ascending, t.ThamNien ascending
                        select new bangtam.bangcongthuc
                        {
                            PRKEY = t.PRKEY,
                            TenCot = t.TenCot,
                            CongThuc = t.CongThuc,
                            TieuDeCot = t.TieuDeCot,
                            ChucVu = t.ChucVu,
                            ViTriCongViec = t.ViTriCongViec,
                            MaBoPhan = t.MaBoPhan,
                            ThamNien = t.ThamNien,
                            EditAble = t.EditAble
                        }).ToList();

        List<string> colTableName = GetColumnNames(data);//lay ten cot trong bang
        List<string> tencot = (from t in typeof(DAL.BangThanhToanLuong).GetProperties() select t.Name).ToList();//lay ten cot trong csdl
        //chuyển công thức về dạng định dạng giống y hệt excel
        foreach (var item in congthuc)
        {
            foreach (var abc in congthuc)
                item.CongThuc = item.CongThuc.Replace("[" + abc.TenCot.ToString() + "]", ChuyenChiSoSangTenCotExcel(abc.TenCot - 1) + "1");
        }
        string strsql = "UPDATE TienLuong.BangThanhToanLuong SET ";
        string strmain = "";
        Workbook workbook = new Workbook();
        Worksheet sheet = workbook.Worksheets[0];
        sheet.Name = "Data Source";
        int socot = data.Columns.Count;
        string hihi;
        List<string> cotTinhBiLoi = new List<string>();
        foreach (DataRow item in data.Rows)
        {
            for (int i = 4; i <= socot - 6; i++)
            {
                try
                {

                    hihi = GetCongThuc(ref congthuc, i, item["MaBoPhan"] == System.DBNull.Value ? "" : item["MaBoPhan"].ToString(), item["MaChucVu"] == System.DBNull.Value ? "" : item["MaChucVu"].ToString(), item["MaCongViec"] == System.DBNull.Value ? "" : item["MaCongViec"].ToString(), item["ThamNien"] == System.DBNull.Value ? 0 : int.Parse(item["ThamNien"].ToString()));
                    if (hihi != "")
                    {
                        // hihi = congthuc.Where(p => p.TenCot == i).SingleOrDefault().CongThuc;// congthuc.Where(p => p.TenCot == "[" + i.ToString() + "]").SingleOrDefault().CongThuc;
                        sheet.Range[1, i].NumberValue = Math.Round((double)workbook.CaculateFormulaValue(hihi));
                        sheet.Range[1, i].NumberFormat = "0";
                        item[i - 1] = Math.Round(double.Parse(sheet.Range[1, i].NumberValue.ToString()));
                    }
                    else
                        if (i != 4)
                            sheet.Range[1, i].Value2 = Math.Round(double.Parse(item[i - 1].ToString()));
                        else sheet.Range[1, i].Value2 = double.Parse(item[i - 1].ToString());
                }
                catch (Exception e)
                {
                    if (!cotTinhBiLoi.Contains(congthuc.FirstOrDefault(p => p.TenCot == i).TieuDeCot))
                        cotTinhBiLoi.Add(congthuc.FirstOrDefault(p => p.TenCot == i).TieuDeCot);
                }
            }


            strmain = "";
            foreach (var bien in tencot)
            {
                if (colTableName.Contains(bien))
                    if (bien != "ID")
                        strmain = strmain + " " + bien + " = " + item[bien].ToString().Replace(',', '.') + " ,";
            }
            if (strmain.Length > 0)
            {
                strmain = strmain.Remove(strmain.LastIndexOf(','));
                DataController.DataHandler.GetInstance().ExecuteNonQuery(strsql + strmain + " WHERE ID = " + item["ID"].ToString());
            }
            if (item["SO_TAI_KHOAN"].ToString().Length > 0)
                DataController.DataHandler.GetInstance().ExecuteNonQuery(strsql + " ATM = " + item["ThucLinh"].ToString().Replace(',', '.') + " , " +
                                                                                  " TienMat = 0" + " WHERE ID = " + item["ID"].ToString());
            else
                DataController.DataHandler.GetInstance().ExecuteNonQuery(strsql + " TienMat = " + item["ThucLinh"].ToString().Replace(',', '.') + " , " +
                                                                              " ATM = 0" + " WHERE ID = " + item["ID"].ToString());
        }
        return cotTinhBiLoi.Count > 0 ? "Tính toán công thức bị lỗi tại các cột: " + string.Join(",", cotTinhBiLoi.ToArray()) : "";
        #region code cu bỏ
        //foreach (var item in data)
        //{
        //    sheet.Range["E1"].NumberValue = item.LuongCoBan;
        //    sheet.Range["F1"].NumberValue = item.LuongTrachNhiem;
        //    sheet.Range["G1"].NumberValue = item.PhuCapTienAn;
        //    sheet.Range["H1"].NumberValue = item.PhuCapChucVu;

        //    // sheet.Range["I1"].Formula = congthuc.Where(p => p.TenCot == "[9]").SingleOrDefault().CongThuc;
        //    // sheet.Range["I1"].NumberValue = sheet.Range["I1"].FormulaNumberValue;
        //    DAL.BangThanhToanLuong uuu = dataContext.BangThanhToanLuongs.Where(p => p.ID == item.ID).FirstOrDefault();
        //    uuu.PhuCapKiemNhiem = double.Parse(workbook.CaculateFormulaValue(congthuc.Where(p => p.TenCot == "[9]").SingleOrDefault().CongThuc).ToString());

        //    //  double x = sheet.Range["I1"].FormulaNumberValue;
        //}

        //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        //xlApp.Visible = true;
        //Excel.Workbook wb = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
        //Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
        //Excel.Range a1zz1 = ws.get_Range("A1:ZZ1");
        //foreach (DataRow item in data.Rows)
        //{
        //    for (int i = 4; i < 44; i++)
        //    {
        //        try
        //        {
        //            Excel.Range cell = (Excel.Range)a1zz1[1, i];

        //            if (congthuc.Where(p => p.TenCot == "[" + i.ToString() + "]").SingleOrDefault().CongThuc != "")
        //            {
        //                cell.Formula = congthuc.Where(p => p.TenCot == "[" + i.ToString() + "]").SingleOrDefault().CongThuc;
        //                item[i] = cell.Value2;
        //            }
        //            else
        //                cell.Value2 = item[i].ToString();
        //            //sheet.Range[1, i + 1].Value = item[i].ToString();
        //            //sheet.Range[1, i + 1].Value2 = item[i];
        //            //sheet.Range[1, i + 1].NumberValue = double.Parse(item[i].ToString());
        //            //if (congthuc.Where(p => p.TenCot == "[" + (i + 1).ToString() + "]").SingleOrDefault().CongThuc != "")
        //            //{
        //            //   // hihi = congthuc.Where(p => p.TenCot == "[" + (i + 1).ToString() + "]").SingleOrDefault().CongThuc;
        //            //   // sheet.Range[1, i + 1].Formula = hihi;// workbook.CaculateFormulaValue(hihi).ToString();
        //            //    item[i] = workbook.CaculateFormulaValue(sheet.Range[1, i + 1].Formula);
        //            //    sheet.Range[1, i + 1].Value = item[i].ToString();
        //            //    sheet.Range[1, i + 1].Value2 = item[i];
        //            //    sheet.Range[1, i + 1].NumberValue = double.Parse(item[i].ToString());
        //            //}
        //        }
        //        catch (Exception e)
        //        {
        //            // throw new Exception(e.Message);
        //        }
        //    }
        //  }

        //Workbook workbook = new Workbook();
        //Worksheet sheet = workbook.Worksheets[0];
        //sheet.Name = "Data Source";
        //string hihi;
        //foreach (DataRow item in data.Rows)
        //{
        //    for (int i = 4; i < 44; i++)
        //    {
        //        try
        //        {
        //            sheet.Range[1, i + 1].Value = item[i].ToString();
        //            sheet.Range[1, i + 1].Value2 = item[i];
        //            sheet.Range[1, i + 1].NumberValue = double.Parse(item[i].ToString());
        //            if (congthuc.Where(p => p.TenCot == "[" + (i + 1).ToString() + "]").SingleOrDefault().CongThuc != "")
        //            {
        //                 hihi = congthuc.Where(p => p.TenCot == "[" + (i + 1).ToString() + "]").SingleOrDefault().CongThuc;
        //                sheet.Range[1, i + 1].Formula = hihi;// workbook.CaculateFormulaValue(hihi).ToString();
        //                item[i] = workbook.CaculateFormulaValue(sheet.Range[1, i + 1].Formula);
        //                sheet.Range[1, i + 1].Value = item[i].ToString();
        //                sheet.Range[1, i + 1].Value2 = item[i];
        //                sheet.Range[1, i + 1].NumberValue = double.Parse(item[i].ToString());
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //           // throw new Exception(e.Message);
        //        }
        //    }
        //}

        //foreach (var item in data)
        //{
        //    sheet.Range["E1"].NumberValue = item.LuongCoBan;
        //    sheet.Range["F1"].NumberValue = item.LuongTrachNhiem;
        //    sheet.Range["G1"].NumberValue = item.PhuCapTienAn;
        //    sheet.Range["H1"].NumberValue = item.PhuCapChucVu;

        //    // sheet.Range["I1"].Formula = congthuc.Where(p => p.TenCot == "[9]").SingleOrDefault().CongThuc;
        //    // sheet.Range["I1"].NumberValue = sheet.Range["I1"].FormulaNumberValue;
        //    DAL.BangThanhToanLuong uuu = dataContext.BangThanhToanLuongs.Where(p => p.ID == item.ID).FirstOrDefault();
        //    uuu.PhuCapKiemNhiem = double.Parse(workbook.CaculateFormulaValue(congthuc.Where(p => p.TenCot == "[9]").SingleOrDefault().CongThuc).ToString());

        //    //  double x = sheet.Range["I1"].FormulaNumberValue;
        //}

        #endregion
    }
    public string ChuyenChiSoSangTenCotExcel(int intCol)
    {

        int intFirstLetter = ((intCol) / 676) + 64;
        int intSecondLetter = ((intCol % 676) / 26) + 64;
        int intThirdLetter = (intCol % 26) + 65;

        char FirstLetter = (intFirstLetter > 64) ? (char)intFirstLetter : ' ';
        char SecondLetter = (intSecondLetter > 64) ? (char)intSecondLetter : ' ';
        char ThirdLetter = (char)intThirdLetter;

        return string.Concat(FirstLetter, SecondLetter, ThirdLetter).Trim();
    }

    public double SumTongTienLuong(int idbangluong)
    {

        try
        {
            return dataContext.BangThanhToanLuongs.Where(p => p.IdBangLuong == idbangluong).Sum(p => p.ThucLinh);
        }
        catch (Exception)
        {

            return 0;
        }

    }
    //   tongHopCong.GioCongThucTe + tongHopCong.TongCaLamViecNgayThuong
    //+ tongHopCong.TongCaLamViecNgayLe + tongHopCong.TongCaLamViecNgayNghi+tongHopCong.TongCaLamViecNgayNghi+LuongCoBan + LuongTrachNhiem + PhuCapTienAn +  PhuCapChucVu +  PhuCapKiemNhiem 
    public string GetThangNamByIDBangLuong(int idbangluong)
    {
        var item = dataContext.DanhSachBangLuongs.Where(p => p.ID == idbangluong).FirstOrDefault();
        return "Tháng " + item.Month.ToString() + " năm " + item.Year.ToString();
    }
    public void XoaCanBo(int id)
    {
        var item = dataContext.BangThanhToanLuongs.Where(p => p.ID == id).FirstOrDefault();
        dataContext.BangThanhToanLuongs.DeleteOnSubmit(item);
        Save();
    }

    public List<int> LayTop10IDBangLuongGanNhat()
    {
        return dataContext.DanhSachBangLuongs.Where(p => p.DaKhoa == false).OrderByDescending(p => p.CreatedDate).Select(p => p.ID).Take(10).ToList();
    }
    public void Lock(int id, bool locked)
    {
        var tmp = dataContext.DanhSachBangLuongs.SingleOrDefault(t => t.ID == id);
        if (tmp != null)
        {
            tmp.DaKhoa = locked;
            Save();
        }
    }
    /// <summary>
    /// xử lý trừ tạm ứng với bảng lương đã khóa hoặc mở khóa
    /// trangthai=true: chuyển từ chưa khóa sang đã khóa.
    /// trạng thái = false: chuyển từ đã khóa sang chưa khóa.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="trangthai"></param>
    public void XuLyTruTamUng(int id, bool trangthai)
    {
        var hsc = new HoSoController();
        foreach (var item in dataContext.BangThanhToanLuongs.Where(p => p.IdBangLuong == id && p.TamUng > 0).ToList())
        {
            decimal prkeyhoso = hsc.TraVePRKEYbyMaCB(item.MaCB);
            string tencanbo = hsc.TraVeTenByMaCB(item.MaCB);
            decimal sotien = (decimal)item.TamUng;
            if (trangthai)
            {
                foreach (var itemtamung in dataContext.BangTamUngs.Where(p => p.PrKeyHoSo == prkeyhoso && (p.SoTien - p.SoTienDaTra > 0)).OrderBy(p => p.NgayTamUng).ToList())
                {
                    if (sotien > 0)
                    {
                        if (sotien >= (itemtamung.SoTien - itemtamung.SoTienDaTra))
                        {
                            sotien -= (itemtamung.SoTien - itemtamung.SoTienDaTra);
                            itemtamung.SoTienDaTra = itemtamung.SoTien;
                        }
                        else
                        {
                            itemtamung.SoTienDaTra += sotien;
                            sotien = 0;
                        }
                    }
                }
            }
            else
            {
                foreach (var itemtamung in dataContext.BangTamUngs.Where(p => p.PrKeyHoSo == prkeyhoso && p.SoTienDaTra > 0).OrderBy(p => p.NgayTamUng).ToList())
                {
                    if (sotien > 0)
                    {
                        if (sotien >= itemtamung.SoTienDaTra)
                        {
                            sotien -= itemtamung.SoTienDaTra;
                            itemtamung.SoTienDaTra = 0;
                        }
                        else
                        {
                            itemtamung.SoTienDaTra -= sotien;
                            sotien = 0;
                        }
                    }
                }
            }
        }
        Save();
    }
    public string CheckKhoaSoDuTamUng(int id)
    {
        string loi = "";
        var hsc = new HoSoController();
        foreach (var item in dataContext.BangThanhToanLuongs.Where(p => p.IdBangLuong == id && p.TamUng > 0).ToList())
        {
            decimal prkeyhoso = hsc.TraVePRKEYbyMaCB(item.MaCB);
            string tencanbo = hsc.TraVeTenByMaCB(item.MaCB);
            decimal sotien = (decimal)item.TamUng;
            decimal sotiencanhoanung = dataContext.BangTamUngs.Where(p => p.PrKeyHoSo == prkeyhoso && (p.SoTien - p.SoTienDaTra > 0)).ToList().Count > 0 ? dataContext.BangTamUngs.Where(p => p.PrKeyHoSo == prkeyhoso && (p.SoTien - p.SoTienDaTra > 0)).Sum(p => p.SoTien - p.SoTienDaTra) : 0;
            if (sotien > sotiencanhoanung)
            {
                loi += "Cán bộ: " + tencanbo + " Số tiền trên cột tạm ứng: " + sotien.ToString() + " Tổng tiền cần hoàn ứng: " + sotiencanhoanung.ToString() + "<br/>";

            }
        }
        return loi;
    }
}
namespace bangtam
{
    public class bangcongthuc
    {
        public int PRKEY { get; set; }
        public int TenCot { get; set; }
        public string CongThuc { get; set; }
        public string ChucVu { get; set; }
        public string TieuDeCot { get; set; }
        public string ViTriCongViec { get; set; }
        public string MaBoPhan { get; set; }
        public int ThamNien { get; set; }
        public bool EditAble { get; set; }
    }
}