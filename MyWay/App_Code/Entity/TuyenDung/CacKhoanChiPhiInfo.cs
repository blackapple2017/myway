using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CacKhoanChiPhiInfo
/// </summary>
public class CacKhoanChiPhiInfo
{
    public CacKhoanChiPhiInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ID { get; set; }
    public string MaKeHoach { get; set; }
    public string TenChiPhi { get; set; }
    public decimal SoTien { get; set; }
    public string NguonChi { get; set; }
    public DateTime? NgayChi { get; set; }
}