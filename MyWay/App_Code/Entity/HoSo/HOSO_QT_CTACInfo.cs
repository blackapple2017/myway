using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_QT_CTACInfo
/// </summary>
public class HOSO_QT_CTACInfo
{
	public HOSO_QT_CTACInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public decimal PR_KEY { get; set; }
    public decimal FR_KEY { get; set; }
    public string SoQuyetDinh { get; set; }
    public DateTime? NgayQuyetDinh { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public string DiaDiemCongTac { get; set; }
    public string TenNuoc { get; set; }
    public string TepTinDinhKem { get; set; }
    public string GhiChu { get; set; }
    public string TEN_NGUOI_QD { get; set; }
    public string NoiDungCongViec { get; set; }
}