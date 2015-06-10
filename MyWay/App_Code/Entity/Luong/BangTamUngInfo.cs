using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangTamUngInfo
/// </summary>
public class BangTamUngInfo
{
	public BangTamUngInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public decimal SoTienDaTra { get; set; }
    public decimal SoTien { get; set; }
    public decimal SoTienConLai { get; set; }
    public bool DaThanhToanHet { get; set; }
    public string LyDoTamUng { get; set; }
    public string GhiChu { get; set; }
    public string AttachFile { get; set; }
    public DateTime? NgayThanhToan { get; set; }
    public DateTime? NgayTamUng { set; get; }
    public decimal PrkeyHoSo { set; get; }
}