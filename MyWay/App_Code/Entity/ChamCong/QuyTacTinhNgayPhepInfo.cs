using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CongThucTinhNgayPhepInfo
/// </summary>
public class QuyTacTinhNgayPhepInfo
{
    public QuyTacTinhNgayPhepInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ID { get; set; }
    public int SoNgayPhepDuocHuong { get; set; }
    public int ThamNienTu { get; set; }
    public int? ThamNienDen { get; set; }
    public bool TinhTheoNam { get; set; }
    public bool IsInUsed { get; set; }
    public string HinhThucLamViec { get; set; }
}