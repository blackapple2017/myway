using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuyTacLamThemGioInfo
/// </summary>
public class QuyTacLamThemGioInfo
{
    public QuyTacLamThemGioInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ID { get; set; }
    public string TuGio { get; set; }
    public string DenGio { get; set; }
    public string LoaiNgay { get; set; }
    public decimal NhanHeSo { get; set; }

    public string MaCa { get; set; }
    public string TenCa { get; set; }
    public string NgayApDung { get; set; }
    public string GioVao { get; set; }
    public string GioRa { get; set; }
    public int Order { get; set; }
}