using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KetQuaThiTuyenInfo
/// </summary>
public class KetQuaThiTuyenInfo
{
	public KetQuaThiTuyenInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int ID { get; set; }
    public int MaUngVien { get; set; }
    public int MaMonThi { get; set; }
   public int? VongThi { get; set; }
  public float? Diem { get; set; }
  public DateTime NgayThiTuyen { get; set; }
  public string NhanXet { get; set; }
   public string Examiner{get;set;}
    public DateTime CreatedDate { get; set; }
    public int? CreatedBy { get; set; }    
    public bool? KetQua { get; set; }

}