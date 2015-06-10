using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHQUYDINHBIENDONGInfo
{
    public int IDQuyDinhBienDong { set; get; }
    public string MaBienDong { set; get; }
    public string TenBienDong { set; get; }
    public string LoaiAnhHuong { set; get; }
    public int? IDCheDoBaoHiem { set; get; }
    public bool? IsBHXH { set; get; }
    public bool? IsBHYT { set; get; }
    public bool? IsBHTN { set; get; }
    public bool? DangSuDung { set; get; }
    public int UserID { set; get; }
    public DateTime DateCreate { set; get; }
    public string MaDonVi { set; get; }
}
