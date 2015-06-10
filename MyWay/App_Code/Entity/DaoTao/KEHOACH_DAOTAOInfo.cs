using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KeHoachDaoTao
/// </summary>
public class KEHOACH_DAOTAOInfo
{
    public KEHOACH_DAOTAOInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string MaKeHoach { get; set; }
    public string TenkeHoach { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
    public string TenChungChi { get; set; }
    public decimal? KinhPhiDuKien { get; set; }
    public decimal? KinhPhiThucTe { get; set; }
    public decimal? KinhPhiCongTyHoTro { get; set; }
    public decimal? KinhPhiNhanVienDong { get; set; }
    public DateTime? NgayBatDauDangKy { get; set; }
    public DateTime? NgayKetThucDangKy { get; set; }
    public string MucDichKhoaHoc { get; set; }
    public string NoiDungDaoTao { get; set; }
    public string DiaDiemDaoTao { get; set; }
    public string ThoiGianDaoTao { get; set; }
    public string TrangThai { get; set; }
    public string DoiTuongDaoTao { get; set; }
    public int? SoLuongHocVien { get; set; }
    public string LyDoDaoTao { get; set; }
    public string GhiChu { get; set; }
    public string DonViPhuTrachDaoTao { get; set; } 
}