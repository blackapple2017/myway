using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GiaoVienThamGiaDaoTaoInfo
/// </summary>
public class GiaoVienThamGiaDaoTaoInfo
{  
     
    public string MakhoaDaoTao { get; set; }

     
   
    #region "Private Members"
	private string mMaGV = string.Empty;
	private string mHoTenGV = string.Empty;
	private string mChucVu = string.Empty;
	private string mDonViCongTac = string.Empty;
	private string mHocVan = string.Empty;
	private string mDiaChiLienHe = string.Empty;
	private string mEmail = string.Empty;
	private string mDiDong = string.Empty;
	private string mDTCoQuan = string.Empty;
	private string mKinhNghiemGiangDay = string.Empty;
	private string mNhanXet = string.Empty;
	private bool mLaNhanvienCty;
	private bool mlaQuanLyPhuTrach;
	private int mCreatedBy;
	private DateTime mCreatedDate;
	private bool mGioiTinh;
	private DateTime? mNgaySinh;
	private string mMADONVI = string.Empty;
    #endregion

    #region "Constructors"
    
    public GiaoVienThamGiaDaoTaoInfo()
    {
    }

    public GiaoVienThamGiaDaoTaoInfo(string maGV, string hoTenGV, string chucVu, string donViCongTac, string hocVan, string diaChiLienHe, string email, string diDong, string dTCoQuan, string kinhNghiemGiangDay, string nhanXet, bool laNhanvienCty, bool laQuanLyPhuTrach, int createdBy, DateTime createdDate, bool gioiTinh, DateTime? ngaySinh, string mADONVI)
    {
      mMaGV = maGV;
      mHoTenGV = hoTenGV;
      mChucVu = chucVu;
      mDonViCongTac = donViCongTac;
      mHocVan = hocVan;
      mDiaChiLienHe = diaChiLienHe;
      mEmail = email;
      mDiDong = diDong;
      mDTCoQuan = dTCoQuan;
      mKinhNghiemGiangDay = kinhNghiemGiangDay;
      mNhanXet = nhanXet;
      mLaNhanvienCty = laNhanvienCty;
      mlaQuanLyPhuTrach = laQuanLyPhuTrach;
      mCreatedBy = createdBy;
      mCreatedDate = createdDate;
      mGioiTinh = gioiTinh;
      mNgaySinh = ngaySinh;
      mMADONVI = mADONVI;
    }
    
    #endregion

    #region "Public Properties"
    
	public string MaGV
    {
		get
    	{
			return mMaGV;
		}
		set
		{
			mMaGV = value;
		}
	}
		
	public string HoTenGV
    {
		get
    	{
			return mHoTenGV;
		}
		set
      	{
			mHoTenGV = value;
		}
	}

	public string ChucVu
    {
		get
    	{
			return mChucVu;
		}
		set
      	{
			mChucVu = value;
		}
	}

	public string DonViCongTac
    {
		get
    	{
			return mDonViCongTac;
		}
		set
      	{
			mDonViCongTac = value;
		}
	}

	public string HocVan
    {
		get
    	{
			return mHocVan;
		}
		set
      	{
			mHocVan = value;
		}
	}

	public string DiaChiLienHe
    {
		get
    	{
			return mDiaChiLienHe;
		}
		set
      	{
			mDiaChiLienHe = value;
		}
	}

	public string Email
    {
		get
    	{
			return mEmail;
		}
		set
      	{
			mEmail = value;
		}
	}

	public string DiDong
    {
		get
    	{
			return mDiDong;
		}
		set
      	{
			mDiDong = value;
		}
	}

	public string DTCoQuan
    {
		get
    	{
			return mDTCoQuan;
		}
		set
      	{
			mDTCoQuan = value;
		}
	}

	public string KinhNghiemGiangDay
    {
		get
    	{
			return mKinhNghiemGiangDay;
		}
		set
      	{
			mKinhNghiemGiangDay = value;
		}
	}

	public string NhanXet
    {
		get
    	{
			return mNhanXet;
		}
		set
      	{
			mNhanXet = value;
		}
	}

	public bool LaNhanvienCty
    {
		get
    	{
			return mLaNhanvienCty;
		}
		set
      	{
			mLaNhanvienCty = value;
		}
	}
    public bool laQuanLyPhuTrach
    {
		get
    	{
            return mlaQuanLyPhuTrach;
		}
		set
      	{
            mlaQuanLyPhuTrach = value;
		}
	}
    

	public int CreatedBy
    {
		get
    	{
			return mCreatedBy;
		}
		set
      	{
			mCreatedBy = value;
		}
	}

	public DateTime CreatedDate
    {
		get
    	{
			return mCreatedDate;
		}
		set
      	{
			mCreatedDate = value;
		}
	}

	public bool GioiTinh
    {
		get
    	{
			return mGioiTinh;
		}
		set
      	{
			mGioiTinh = value;
		}
	}

	public DateTime? NgaySinh
    {
		get
    	{
			return mNgaySinh;
		}
		set
      	{
			mNgaySinh = value;
		}
	}

	public string MADONVI
    {
		get
    	{
			return mMADONVI;
		}
		set
      	{
			mMADONVI = value;
		}
	}
    #endregion
 

}