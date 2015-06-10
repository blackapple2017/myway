using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoSoPhuCapInfo
/// </summary>
public class HoSoPhuCapInfo
{
    public HoSoPhuCapInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ID { get; set; }
    public int MaPhuCap { get; set; }
    public string TenPhuCap { get; set; }
    public double HeSo { get; set; }
    public double SoTien { get; set; }
    public DateTime? NgayQuyetDinh { get; set; }
    public DateTime? NgayHieuLuc { get; set; }
    public DateTime? NgayHetHieuLuc { get; set; }
    public string NguoiQuyetDinh { get; set; }
    public string TrangThai { get; set; }
    public decimal? PrkeyNguoiQuyetDinh { get; set; }
    public int FrKeyHoSoLuong { get; set; }
    public double? PhanTram { get; set; }
}