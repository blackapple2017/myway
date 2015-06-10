using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangTinhCheDoBaoHiemInfo
/// </summary>
public class BangTinhCheDoBaoHiemInfo
{
    public int IDBangTinhCheDoBaoHiem { get; set; }
    public int IDCheDoBaoHiem{get;set;}
    public string MaDieuKienHuong { get; set; }
    public string TenDieuKienHuong { get; set; }
    public decimal DKThoiGianDongBH { get; set; }
    public int DKThoiGianToiDaHuongCheDo { get; set; }
    public string CongThuc { get; set; }
    public string YeuCauThuTuc { get; set; }
    public string DienGiai { get; set; }
    public int UserID { get; set; }
    public DateTime? DateCreate { get; set; }
    public string MaDonVi { get; set; }
}