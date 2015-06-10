using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HosoLuongInfo
/// </summary>
public class HosoLuongInfo
{
    public HosoLuongInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ID { get; set; }
    public double? PhanTramHuongLuong { get; set; }

    public string SoQuyetDinh { get; set; }
    public string MaCB { get; set; }
    public string HoTen { get; set; }
    public string GioiTinh { get; set; }
    public string TenBoPhan { get; set; }
    public string LoaiLuong { get; set; }
    public string NguoiQuyetDinh { get; set; }
    public string TrangThai { get; set; }
    public string BacLuongNB { get; set; }
    public string BacLuong { get; set; }
    public string GhiChu { get; set; }
    public string TepTinDinhKem { get; set; }

    public double? HeSoLuong { get; set; }
    public double? LuongCung { get; set; }
    public double? LuongDongBHXH { get; set; }
    public string LuongTrachNhiem { get; set; }
    
    public DateTime? NgayHuongLuong { get; set; }
    public DateTime? NgaySinh { get; set; }
    public DateTime? NgayHuongLuongNB { get; set; }
    public DateTime? NgayQuyetDinh { get; set; }
    public DateTime NgayHieuLuc { get; set; }
    public DateTime? NgayKetThucHieuLuc { get; set; } 
    public DateTime CreatedDate { get; set; }

    public bool HasPhuCap { get; set; }
    public decimal? IdNguoiQuyetDinhPhuCap { get; set; }
}