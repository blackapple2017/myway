using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangThanhToanTienLuongInfo
/// </summary>
public class BangThanhToanTienLuongInfo
{
    public BangThanhToanTienLuongInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ID { get; set; }
    public int IdBangLuong { get; set; }
    public string MaCB { get; set; }
    public string HoTen { get; set; }
    public string LoaiHDLD { get; set; }
    public string TenBoPhan { get; set; }
    public double GiamTruTienPhat { get; set; }
    public double GiamTruBHYT { get; set; }
    public double GiamTruBHXH { get; set; }
    public double GiamTruBHTN { get; set; }
    public double GiamTruNgayNghi { get; set; }
    public double GiamTruThuNhapCaNhan { get; set; }
    public double GiamTruDiMuonVeSom { get; set; }
    public double GiamTruPhiCongDoan { get; set; }
    public double GiamTruTamUng { get; set; }
    public double GiamTruHocPhi { get; set; }
    public double GiamTruDangPhi { get; set; }
    public double GiamTruAnCa { get; set; }
    public double GiamTruTienNha { get; set; }
    public double GiamTruKhac { get; set; }
    public double TongGiamTru { get; set; }
    public double PhuCapChucVu { get; set; }
    public double PhuCapBacTho { get; set; }
    public double PhuCapThamNien { get; set; }
    public double PhuCapThamNienVuotKhung { get; set; }
    public double PhuCapThamNienNghe { get; set; }
    public double PhuCapDienThoai { get; set; }
    public double PhuCapDocHai { get; set; }
    public double PhuCapTienTro { get; set; }
    public double PhuCapCa3 { get; set; }
    public double PhuCapKiemNhiem { get; set; }
    public double PhuCapXangXe { get; set; }
    public double PhuCapKhac { get; set; }
    public double PhuCapTienAn { get; set; }
    public double LuongSanPham { get; set; }
    public double LuongThuong { get; set; }
    public double LuongNghiLe { get; set; }
    public double LuongBaoHiem { get; set; }
    public double LuongCoBan { get; set; }
    public double LuongThemGio { get; set; }
    public double LuongCheDo { get; set; }
    public double LuongKhac { get; set; }
    public double Luong100PhanTram { get; set; }
    public double Luong200PhanTram { get; set; }
    public double Luong300PhanTram { get; set; }
    public double Luong150PhanTram { get; set; }
    public double ChuyenCan { get; set; }
    public double LamThem { get; set; }
    public double TongLuong { get; set; }
    public int SoNguoiPhuThuoc { get; set; }
    public double LuongDoanhThu { get; set; }
    public double LuongTrachNhiem { get; set; }
    public double LuongThang13 { get; set; }
    public double LuongThoiGianNgayThuong { get; set; }
    public double TienAnKhauTruThueTNCN { get; set; }
    public double ThuNhapTinhThue { get; set; }
    public double ThueTNCNPhaiNop { get; set; }
    public double ThueCuoiNamHoanTraHoacNopThem { get; set; }
    public double TongThuNhap { get; set; }
    public double TongThuNhapNet { get; set; }
    public double TamUng { get; set; }
    public double ThucLinh { get; set; }
    public double ATM { get; set; }
    public double TienMat { get; set; }
}
public class BangCongThucLuongInfo
{
    public int PRKEY { get; set; }
    public int TenCot { get; set; } 
    public string TieuDeCot { get; set; }
    public string ChucVu { get; set; }
    public string TenChucVu { get; set; }
    public string ViTriCongViec { get; set; }
    public string TenViTriCongViec { get; set; }
    public string MaBoPhan { get; set; }
    public string TenBoPhan { get; set; }
    public int ThamNien { get; set; }
    public string CongThuc { get; set; }
    public bool EditAble { get; set; }
}