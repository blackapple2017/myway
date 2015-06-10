using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuyetDinhLuongHangLoatInfo
/// </summary>
public class QuyetDinhLuongHangLoatInfo
{
    public QuyetDinhLuongHangLoatInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public decimal PR_KEY { get; set; }
    public string MA_CB { get; set; }
    public string HO_TEN { get; set; }
    public string TEN_DONVI { get; set; }
    public string TEN_CHUCVU { get; set; }
    public string MaNgach { get; set; }
    public string BacLuong { get; set; }
    public double HeSoLuong { get; set; }
    public double LuongCung { get; set; }
    public double LuongDongBHXH { get; set; }
    public DateTime NgayHuongLuong { get; set; }
    public string BacLuongNB { get; set; }
    public DateTime NgayHuongLuongNB { get; set; }
    public double PhanTramHuongLuong { get; set; }
    public string LuongTrachNhiem { get; set; }
    public string MaLoaiLuong { get; set; }
    public string TrangThai { get; set; }
}