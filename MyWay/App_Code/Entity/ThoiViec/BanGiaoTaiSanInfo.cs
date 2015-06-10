using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Trần Đức Anh
/// </summary>
public class BanGiaoTaiSanInfo
{
    public decimal ID { get; set; }
    public string MaTaiSan { get; set; }
    public string TenTaiSan { get; set; }
    public string TinhTrang { get; set; }
    public string DonViTinh { get; set; }
    public bool DaBanGiao { get; set; }
    public string GhiChu { get; set; }
    public DateTime? NgayBanGiao { get; set; }
    public DateTime NgayTao { get; set; }
    public int NguoiTao { get; set; }
    public int SoLuong { get; set; }
    public string AttachFile { get; set; }
}