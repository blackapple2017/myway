using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_QT_DIEUCHUYENInfo1
/// </summary>
public class HOSO_QT_DIEUCHUYENInfo1
{
	public HOSO_QT_DIEUCHUYENInfo1()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public decimal PR_KEY { get; set; }
    public decimal FR_KEY { get; set; }
    public string SoQuyetDinh { get; set; }
    public string TenNguoiQuyetDinh { get; set; }
    public DateTime? NgayQuyetDinh { get; set; }
    public DateTime? NgayCoHieuLuc { get; set; }
    public DateTime? NgayHetHieuLuc { get; set; }
    public string TenBoPhanCu { get; set; }
    public string TenBoPhanMoi { get; set; }
    public string TenChucVuCu { get; set; }
    public string TenChucVuMoi { get; set; }
    public string TenCongViecCu { get; set; }
    public string TenCongViecMoi { get; set; }
    public string TepTinDinhKem { get; set; }
    public string GhiChu { get; set; }
}