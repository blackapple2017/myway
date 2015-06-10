using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Trần Đức Anh
/// </summary>

public class KetQuaDanhGiaInfo
{
    public int ID { set; get; }
    public string MaCB { set; get; }
    public float Diem { set; get; }
    public int IdTieuChi_DotDanhGia { set; get; }
    public string NhanXet { set; get; }
    public DateTime CreatedDate { set; get; }
    public int CreatedBy { set; get; }
    public bool IsQuanLyDanhGia { set; get; }
}

//Đức Anh tạo class kết quả đánh giá tổng hợp
public class KetQuaDanhGiaTongHop
{
    public string MaCanBo { get; set; }
    public string HoTen { get; set; }
    public string TenPhong { get; set; }
    public float DiemTuDanhGia { get; set; }
    public float DiemQuanLyDanhgia { get; set; }
    public DateTime? NgayDanhGia { get; set; }
    public float TongDiem { get; set; }
    public string TrangThaiDanhGia { get; set; }

}
