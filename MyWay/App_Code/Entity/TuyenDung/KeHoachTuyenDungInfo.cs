using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NguonTuyenDung
/// </summary>
public class KeHoachTuyenDungInfo
{
    public KeHoachTuyenDungInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int ID { get; set; }
    public int? CreatedBy { get; set; }
    public int? TrangThaiXuLy { get; set; }
    public int SoLuongCanTuyen { get; set; }
    public int? SoVongPhongVan { get; set; }
    public decimal? MucLuongDuKienToiThieu { get; set; }
    public decimal? MucLuongDuKienToiDa { get; set; }
    public decimal? KinhPhiDuTru { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public DateTime? HanNopHoSo { get; set; }
    public DateTime? NgayBatDauDiLam { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string MaKeHoach { get; set; }
    public string TenKeHoach { get; set; }    
    public string LyDoTuyen { get; set; }
    public string MaCongViec { get; set; }
    public string MaChucVu { get; set; }
    public string MA_DONVI { get; set; }
    public string NoiLamViec { get; set; }
    public string HoSoBaoGom { get; set; }
    public string ThoiGianThuViec { get; set; }
    public string HinhThucLamViec { get; set; }
    public string MoTaCongViec { get; set; }
    public string TEN_CONGVIEC { get; set; }
    public string TEN_CHUCVU { get; set; }
    public string TEN_DONVI { get; set; }
    public int? MaLyDoTuyen { get; set; }
    public string GhiChu { get; set; }
}