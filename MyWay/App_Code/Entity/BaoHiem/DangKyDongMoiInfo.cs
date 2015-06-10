using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DangKyDongMoiInfo
/// </summary>
public class DangKyDongMoiInfo
{
    public int ID { set; get; }
    public string MaCanBo { get; set; }
    public string TenCanBo { get; set; }
    public DateTime NgaySinh { get; set; }
    public string MaChucVu { get; set; }
    public string TenChucVu { get; set; }
    public decimal LuongBaoHiem { get; set; }
    public DateTime NgayHieuLuc { get; set; }
    public bool BHXH { get; set; }
    public bool BHYT { get; set; }
    public bool BHTN { get; set; }
    public string MaLoaiHopDong { get; set; }
    public string TenLoaiHopDong { get; set; }
    public DateTime NgayBatDauHopDong { get; set; }

}