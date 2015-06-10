using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Bùi Xuân Đại
/// </summary>

public class DotDanhGiaInfo
{
    public string ID { set; get; }
    public string TenDotDanhGia { set; get; }
    public DateTime? TuNgay { set; get; }
    public DateTime? DenNgay { set; get; }
    public string TrangThaiDanhGia { set; get; }
    public string GhiChu { set; get; }
    public int CreatedBy { set; get; }
    public DateTime CreatedDate { set; get; }
    public string MaDonVi { set; get; }
    public bool TrongPhongDanhGiaLanNhau { set; get; }
}
