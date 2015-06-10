using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhMucPhuCapPhucLoiInfo
/// </summary>
public class DanhMucPhuCapPhucLoiInfo
{
    public int ID { get; set; }
    public string Ten { get; set; }
    public bool IsPhuCap { get; set; }
    public double? SoTien { get; set; }
    public double? HeSo { get; set; }
    public string NhomLoaiPhuCap { get; set; }
    public double? PhanTram { get; set; }
    public bool? TinhVaoBH { get; set; }
}