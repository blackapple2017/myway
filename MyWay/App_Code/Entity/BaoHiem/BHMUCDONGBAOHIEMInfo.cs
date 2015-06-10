using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHMUCDONGBAOHIEMInfo
{
    public int ID { set; get; }
    public DateTime NgayHieuLuc { set; get; }
    public decimal? SanBHXH { set; get; }
    public decimal? SanBHYT { set; get; }
    public decimal? SanBHTN { set; get; }
    public decimal? TranBHXH { set; get; }
    public decimal? TranBHYT { set; get; }
    public decimal? TranBHTN { set; get; }
    public decimal? NVBYXH { set; get; }
    public decimal? NVBHYT { set; get; }
    public decimal? NVBHTN { set; get; }
    public decimal? DVBHXH { set; get; }
    public decimal? DVBHYT { set; get; }
    public decimal? DVBHTN { set; get; }
    public int UserID { set; get; }
    public DateTime DateCreate { set; get; }
    public string MaDonVi { set; get; }
}
