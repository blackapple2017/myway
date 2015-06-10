using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DinhBienNhanSuInfo
/// </summary>
public class CacMonThiTuyenInfo
{

    public int ID { get; set; }
    public int PlanID { get; set; }
    public int maMon { get; set; }
    public string tenMon { get; set; }
    public decimal TrongSo { get; set; }
    public double DiemDat { get; set; }
    public string NguoiCham { get; set; }
    public int maNguoiCham { get; set; }
    public decimal PrKeyHOSO { get; set; }
    public IEnumerable<DAL.HOSO> DSNguoiCham { get; set; }
    public DAL.HOSO TTNGuoiCham { get; set; }
    public int VongThi { get; set; }
    public string GhiChu { get; set; }  
}