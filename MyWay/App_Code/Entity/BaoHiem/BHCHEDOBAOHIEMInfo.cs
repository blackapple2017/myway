using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHCHEDOBAOHIEMInfo
{
    public int IDCheDoBaoHiem { set; get; }
    public int ParentID { set; get; }
    public string MaCheDoBaohiem { set; get; }
    public string TenCheDoBaoHiem { set; get; }
    public int UserID { set; get; }
    public DateTime DateCreate { set; get; }
    public string MaDonVi { set; get; }
}
