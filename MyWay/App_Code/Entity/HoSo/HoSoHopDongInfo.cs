using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoSoHopDongInfo
/// </summary>
public class HoSoHopDongInfo
{
    public HoSoHopDongInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string MaLoaiHopDong { get; set; }
    public string TenLoaiHopDong { get; set; }
    public string SoHopDong { get; set; }
    public decimal ID { get; set; }
    public string TenCongViec { get; set; }
    public DateTime NgayKyHopDong { get; set; }
    public DateTime? NgayKetThucHopDong { get; set; }
    public string MaTrangThai { get; set; }
}