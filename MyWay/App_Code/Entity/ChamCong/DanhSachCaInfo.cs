using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachCaInfo
/// </summary>
public class DanhSachCaInfo
{
    public DanhSachCaInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int ID { get; set; }
    public string MaCa { get; set; }
    public string TenCa { get; set; }
    public string GioVao { get; set; }
    public string GioRa { get; set; }
    public string NghiGiuaCa { get; set; }
    public string VaoGiuaCa { get; set; }
    public double? SoPhutChoPhepDiMuon { get; set; }
    public double? SoPhutChoPhepVeSom { get; set; }
    public string BatDauTinhLamThemDauGio { get; set; }
    public string BatDauTinhLamThemCuoiGio { get; set; }
    public double? PhuCapCa { get; set; }
    public double? TienLuongCa { get; set; }
    public bool? RaNgoaiKhongBiTruGio { get; set; }
    public string MaDonVi { get; set; }
    public string BatDauQuetTheLan1 { get; set; }
    public string KetThucQuetTheLan1 { get; set; }
    public string BatDauQuetTheLan2 { get; set; }
    public string KetThucQuetTheLan2 { get; set; }
    public string BatDauQuetTheLan3 { get; set; }
    public string KetThucQuetTheLan3 { get; set; }
    public string BatDauQuetTheLan4 { get; set; }
    public string KetThucQuetTheLan4 { get; set; }
    public bool DangSuDung { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ThoiGianApDungTu { get; set; }
    public DateTime? ThoiGianApDungDen { get; set; }
    public string NgayApDung { get; set; }
    public double? TongGio { get; set; }
    public string LoaiCa { get; set; }
}
