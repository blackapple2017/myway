using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DonViInfo
/// </summary>
public class DonViInfo
{
	public DonViInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string MaDonVi { get; set; }
    public string TenDonVi { get; set; }
    //Đức Anh thêm 2 trường để xử lý
    public string ParentID { get; set; }
    public int Level { get; set; }
    public string MaCa { get; set; }
    public string MaCaThu7 { get; set; }
    public string MaCaChuNhat { get; set; }
    public double? SoNgayCongChuan { get; set; }
    public bool isUsed { get; set; }
    public decimal Order { get; set; }
}