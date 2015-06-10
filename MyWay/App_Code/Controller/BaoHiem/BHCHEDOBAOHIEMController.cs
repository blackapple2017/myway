using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using System.Collections;
using System.Globalization;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHCHEDOBAOHIEMController : LinqProvider
{
    private bool bParsed = false; DataSet m_dataSet = new DataSet("DataSet");
    DataTable m_table = new DataTable("Variable");
    public DataTable GetByPrkey(int pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetBHCHEDOBAOHIEMByPrkey", "@IDCheDoBaoHiem", pr_key);
    }
    public DataTable GetByParentId(int pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetByParentId", "@IdParent", pr_key);
    }

    public void DeleteByPrkey(int pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteBHCHEDOBAOHIEMByPrkey", "@IDCheDoBaoHiem", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey, out int count, string MaDonVi, string IdCheDoBH)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountBHCHEDOBAOHIEM", "@searchKey", "@MaDonVi", "@IdCheDoBH", searchKey, MaDonVi, IdCheDoBH).ToString());
        DataTable dt = DataController.DataHandler.GetInstance().ExecuteDataTable("SelectBHCHEDOBAOHIEM", "@start", "@limit", "@searchKey", "@MaDonVi", "@IdCheDoBH", start, limit, searchKey, MaDonVi, IdCheDoBH);
        dt.Columns.Add("sapxep", typeof(string));

        DataTable dtcha = GetByParentId(0);
        for (int i = 0; i < dtcha.Rows.Count; i++)
        {
            string idcha = dtcha.Rows[i][0].ToString();
            string namecha = dtcha.Rows[i][3].ToString();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j][1].ToString() == idcha)
                {
                    dt.Rows[j]["sapxep"] = namecha;
                }
                //DataTable dt2 = GetByPrkey(Convert.ToInt32(idcha));
                //if (dt2.Rows.Count>0)
                //{
                //     dt.Rows[j]["sapxep"] = namecha;
                //}
            }
        }
        return dt;
    }


    public void Insert(BHCHEDOBAOHIEMInfo record)
    {
        DataController.DataHandler.GetInstance().ExecuteScalar("InsertBHCHEDOBAOHIEM", "@ParentID", "@MaCheDoBaohiem", "@TenCheDoBaoHiem", "@UserID", "@DateCreate", "@MaDonVi", record.ParentID, record.MaCheDoBaohiem, record.TenCheDoBaoHiem, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void Update(BHCHEDOBAOHIEMInfo record)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateBHCHEDOBAOHIEM", "@IDCheDoBaoHiem", "@ParentID", "@MaCheDoBaohiem", "@TenCheDoBaoHiem", "@UserID", "@DateCreate", "@MaDonVi", record.IDCheDoBaoHiem, record.ParentID, record.MaCheDoBaohiem, record.TenCheDoBaoHiem, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void DuplucateByPrkey(int pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateBHCHEDOBAOHIEMByPrkey", "@IDCheDoBaoHiem", pr_key);
    }
    #region Xử lý công thức
    public decimal XuLyCongThuc(string CongThuc, decimal LuongToiThieuChung, decimal LuongDongBHThangLienKe, decimal LuongBHBQ6Thang, int SoNgayNghi, int CongChuan, out string congthucdathay)
    {
        decimal thanhtien = 0;
        string CongThuc1 = CongThuc.Replace("LuongToiThieuChung", LuongToiThieuChung.ToString("0")).Replace("LuongDongBHThangLienKe", LuongDongBHThangLienKe.ToString("0")).Replace("LuongBHBQ6Thang", LuongBHBQ6Thang.ToString("0")).Replace("SoNgayNghi", SoNgayNghi.ToString()).Replace("CongChuan", CongChuan.ToString());
        congthucdathay = CongThuc1;
        #region xử lý công thức code cũ
        // xử lý tính toán
        //khởi tạo
        //TinhCongThucDong.Function fn = new TinhCongThucDong.Function();
        //bParsed = true;
        //if (!string.IsNullOrEmpty(CongThuc1))
        //{
        //    fn.Parse(CongThuc1.ToString().Trim());
        //    fn.Infix2Postfix();
        //}
        //ArrayList var = fn.Variables;
        //// tính
        //ArrayList var1 = new ArrayList();
        //TinhCongThucDong.Symbol sym1;
        //foreach (DataRow row1 in m_table.Rows)
        //{
        //    sym1.m_name = (string)row1["Name"];
        //    sym1.m_value = (decimal)row1["Value"];
        //    sym1.m_type = TinhCongThucDong.Type.Variable;
        //    var.Add(sym1);
        //}
        //decimal c;
        //fn.Variables = var1;
        //string a = "0.75";
        //decimal b = decimal.Parse(a, new NumberFormatInfo() { NumberDecimalSeparator = "." });
        //fn.EvaluatePostfix();
        //thanhtien = Convert.ToDecimal(fn.Result);
        //string bien = fn.Result.ToString(); 
        #endregion
        var sql = "SELECT " + congthucdathay;
        var result = DataController.DataHandler.GetInstance().ExecuteScalar(sql);
        if (result.ToString().Contains('-'))
        {
            result = 0;
        }
        thanhtien = decimal.Parse("" + result.ToString());

        return thanhtien;
    }
    #endregion
    public void TinhChiTieu(DateTime NgayBatDau, int IdNhanVien_BH, out decimal LuongDongBHThangLienKe, out decimal LuongToiThieuChung, out decimal LuongBHBQ6Thang)
    {
        LuongBHBQ6Thang = 0;
        LuongDongBHThangLienKe = 0;
        LuongToiThieuChung = 0;
        var nhanvien = dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.IDNhanVien_BaoHiem == IdNhanVien_BH).FirstOrDefault();
        string manv = "";
        decimal luongbh = 0;
        int sothangdongbh = 0;
        if (nhanvien != null)
        {
            manv = nhanvien.MaNhanVien;
            luongbh = nhanvien.LuongBaoHiem;
            sothangdongbh = nhanvien.ThoiGianDongBaoHiem;
        }
        //xử lý lương tối thiểu chung
        var mucdongbh = (from t in dataContext.BHMUCDONGBAOHIEMs
                         where t.NgayHieuLuc <= NgayBatDau
                         orderby t.NgayHieuLuc descending
                         select t).FirstOrDefault();
        if (mucdongbh != null)
            LuongToiThieuChung = mucdongbh.SanBHXH;
        ////xử lý lương đóng bảo hiểm tháng liền kề
        //var dongbhthanggannhat = (from t in dataContext.BangThanhToanLuongs.Where(p => p.MaCB == manv)
        //                          join q in dataContext.DanhSachBangLuongs.Where(p => p.Month + p.Year * 12 <= NgayBatDau.Month + NgayBatDau.Year * 12) on t.IdBangLuong equals q.ID
        //                          orderby (q.Month + q.Year * 12) descending
        //                          select new { t.LuongBaoHiem }).FirstOrDefault();
        //if (dongbhthanggannhat != null)
        //    LuongDongBHThangLienKe = (decimal)dongbhthanggannhat.LuongBaoHiem;

        // lấy trong bảng lương động Cột C29 lương đóng BH
        var luong = DataController.DataHandler.GetInstance().ExecuteScalar("sp_BH_LayTienLuongThangLienKe", "@MaNV", "@Month", "@Year", manv, NgayBatDau.Month, NgayBatDau.Year);
        LuongDongBHThangLienKe = decimal.Parse("0" + luong);


        if (LuongDongBHThangLienKe == 0 && sothangdongbh > 0 && luongbh > 0) LuongDongBHThangLienKe = luongbh;


        // xử lý 6 tháng liền kề
        //var dongbh6thang = (from t in dataContext.BangThanhToanLuongs.Where(p => p.MaCB == manv)
        //                    join q in dataContext.DanhSachBangLuongs.Where(p => p.Month + p.Year * 12 <= NgayBatDau.Month + NgayBatDau.Year * 12) on t.IdBangLuong equals q.ID
        //                    orderby (q.Month + q.Year * 12) descending
        //                    select new { t.LuongBaoHiem }).Skip(0).Take(6).ToList();
        //if (dongbh6thang.Count == 6)
        //{
        //    LuongBHBQ6Thang = (decimal)dongbh6thang.Average(p => p.LuongBaoHiem);
        //}
        //else
        //{
        //    if (sothangdongbh >= 6 && luongbh > 0)
        //    {
        //        int count = dongbh6thang.Count;
        //        LuongBHBQ6Thang = ((decimal)dongbh6thang.Sum(p => p.LuongBaoHiem) + luongbh * (6 - count)) / 6;
        //    }
        //}
        // bảng lương động cột thực nhân
        DataTable data = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_BH_LayTienLuong6ThangLienKe", "@MaNV", "@Month", "@Year", manv, NgayBatDau.Month, NgayBatDau.Year);
        decimal tong6thang = 0;
        if (data.Rows.Count == 6)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                tong6thang += decimal.Parse("0" + data.Rows[i]["BaoHiem"].ToString());
            }
            LuongBHBQ6Thang = tong6thang / 6;
        }
        else if (data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                tong6thang += decimal.Parse("0" + data.Rows[i]["BaoHiem"].ToString());
            }
            LuongBHBQ6Thang = tong6thang / (data.Rows.Count);
        }

    }
    #region  Xử lý kiểm tra ngày hiệu lực gần nhất + tồn tại bảng chấm công chưa
    protected decimal GetNgayHieuLucMin()
    {
        var dt = new MucDongBaoHiemController().GetAll();
        int i = 0;
        decimal mucsanBHXH = 0;
        TimeSpan ngayhieuluc = new TimeSpan();
        string[] split;
        ArrayList array = new ArrayList();
        int min = 0;
        int Id = 0;
        foreach (var item in dt)
        {
            if (DateTime.Now.Date != item.NgayHieuLuc.Date)
            {
                ngayhieuluc = DateTime.Now.Date - item.NgayHieuLuc.Date;
                split = ngayhieuluc.ToString().Split('.');
                if (Convert.ToInt32(split[0]) > 0)
                {
                    array.Add(Convert.ToInt32(split[0]));
                }
            }
            else
            {
                array.Add(0);
            }
        }
        //
        min = Convert.ToInt32(array[0]);
        for (i = 0; i < array.Count; i++)
        {
            if (min > Convert.ToInt32(array[i]))
            {
                min = Convert.ToInt32(array[i]);
            }
        }
        foreach (var item in dt)
        {
            if (DateTime.Now.Date != item.NgayHieuLuc.Date)
            {
                ngayhieuluc = DateTime.Now.Date - item.NgayHieuLuc.Date;
                split = ngayhieuluc.ToString().Split('.');
                if (Convert.ToInt32(split[0]) == min)
                {
                    Id = item.ID;
                }
            }
            else
            {
                Id = item.ID;
            }
        }
        // lấy ra thông tin mức đóng bảo hiểm có ngày hiệu lực gần nhất theo Id
        DataTable dtNgayHieuLucMin = new BHMUCDONGBAOHIEMController().GetByPrkey(Id);
        // lấy ra cán bộ ở tháng chấm công trước +tổng số công>14
        DataTable dtChamCong_NVBH = DataController.DataHandler.GetInstance().ExecuteDataTable("CheckNhanVien_SoCong");
        mucsanBHXH = Convert.ToDecimal(dtNgayHieuLucMin.Rows[0]["SanBHXH"]);

        return mucsanBHXH;
    }
    #endregion

}
