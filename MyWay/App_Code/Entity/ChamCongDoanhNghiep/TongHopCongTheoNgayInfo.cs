using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TongHopCongTheoNgayInfo
/// </summary>
public class TongHopCongTheoNgayInfo
{
    /// <summary>
    /// Lê Thế Tư
    /// </summary>
	public TongHopCongTheoNgayInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public decimal ID { get; set; }
    public DateTime NgayThang { get; set; }
    public string MaChamCong { get; set; }
    public string MaCa { get; set; }
    public float? ComCa { get; set; }
    public float? SoPhutDiMuon { get; set; }
    public float? SoPhutVeSom { get; set; }
    public float? SoGio { get; set; }
    public float? GioHanhChinh { get; set; }
    public float? GioThua { get; set; }
    public float? Gio130 { get; set; }
    public float? Gio150 { get; set; }
    public float? Gio195 { get; set; }
    public float? Gio200 { get; set; }
    public float? Gio260 { get; set; }
    public float? Gio300 { get; set; }

    public string KyHieuChamCong { get; set; }

}