using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NguonTuyenDung
/// </summary>
public class ChiPhiTuyenDungInfo
{
    public ChiPhiTuyenDungInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ID { get; set; }
    public int CreatedBy { get; set; }
    public decimal SoTien { get; set; }
    public string MaKeHoachTuyenDung { get; set; }
    public string TenKeHoach { get; set; }
    public string TenChiPhi { get; set; }    
    public string NguonChi { get; set; }
    public string NguoiTao { get; set; }
    public DateTime? NgayChi { get; set; }
    public DateTime CreatedDate { get; set; }
    public string GhiChu { get; set; }

}