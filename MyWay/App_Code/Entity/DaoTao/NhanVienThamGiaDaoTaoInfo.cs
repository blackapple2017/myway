using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NhanVienThamGiaDaoTaoInfo
/// </summary>
public class NhanVienThamGiaDaoTaoInfo
{
	public NhanVienThamGiaDaoTaoInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string MaCB { get; set; }
    public string TenCB { get; set; }
    public string PhongBan { get; set; }
    public string ViTriCongViec { get; set; }
    public string DonViCongTac { get; set; }
    public bool? DaThamGia { get; set; }
    public double? Diem { get; set; }
    public string KetQua { get; set; }
    public string NhanXetCuaGiaoVien { get; set; }
    public decimal? SoTienNhanVienDong { get; set; }
    public decimal? SoTienCongTyDong { get; set; }
    //Thông tin phụ về khóa đào tạo
    public string MaKhoaDaoTao { get; set; }
    public string TenKhoaDaoTao { get; set; }
    public DateTime? DaoTaoTuNgay { get; set; }
    public DateTime? KetThucDaoTao { get; set; }
    public string DiaDiemDaoTao { get; set; }
    public string DiaDiemLamViec { get; set; }
    public string GhiChu { get; set; }
    public int? DiemDanh { get; set; }
}