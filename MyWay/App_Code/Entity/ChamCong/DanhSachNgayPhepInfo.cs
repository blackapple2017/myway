using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachNgayPhepInfo
/// </summary>
public class DanhSachNgayPhepInfo
{
	public DanhSachNgayPhepInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string MaNhanVien { get; set; }
    public string HoTen { get; set; }
    public string PhongBan { get; set; }
    public string ToDoi { get; set; }


    public int ID { get; set; }
    public int? SoNgayPhepNamTruoc { get; set; }
    public int? SoNgayPhepNamNay { get; set; }
    public int? SoNgayPhepDuocThem { get; set; }
    public int? SoNgayPhepDaSuDung { get; set; }
    public DateTime? ThoiHanSuDungNgayPhepNamTruoc { get; set; }
    public DateTime? ThoiHanSuDungNgayPhepDuocThem { get; set; }
    public int? SoNgayPhepCongDonToiDaTrongThang { get; set; }
    public int ThamNien { get; set; }
}