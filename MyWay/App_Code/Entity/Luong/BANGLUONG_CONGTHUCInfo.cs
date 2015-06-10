using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BANGLUONG_CONGTHUCInfo
/// </summary>
public class BANGLUONG_CONGTHUCInfo
{

    public string NguoiTao { get; set; }
    public bool? DIEUKIEN_DONGBAOHIEM { get; set; }
    #region "Private Members"
	private int mPRKEY;
	private DateTime? mTUNGAY;
	private DateTime? mDENNGAY;
	private string mTENTRUONG = string.Empty;
	private string mTENTRUONGVN = string.Empty;
	private string mCONGTHUC = string.Empty;
	private bool mISINUSED;
	private int mCREATEDUSER;
	private DateTime mDATECREATE;
	private string mMADONVI = string.Empty;
	private bool? mDIEUKIENGIOITINH;
	private int? mDIEUKIENTHAMNIEN;
	private DateTime? mDIEUKIENNGAYTHANG;
	private bool? mDIEUKIENNGAYTHANG_AM;
	private int? mDIEUKIENDOTUOI;
	private string mDIEUKIENCHUCVU = string.Empty;
	private string mDIEUKIENMACONGTRINH = string.Empty;
	private string mDIEUKIENLOAIHOPDONG = string.Empty;
	private string mDIEUKIENNGACH = string.Empty;
	private string mDIEUKIENCAPBACQDOI = string.Empty;
	private string mDIEUKIENCHUCVUDOAN = string.Empty;
	private string mDIEUKIENCHUCVUDANG = string.Empty;
    #endregion

    #region "Constructors"
    
    public BANGLUONG_CONGTHUCInfo()
    {
    }
		 
    
    #endregion

    #region "Public Properties"
    
	public int PRKEY
    {
		get
    	{
			return mPRKEY;
		}
		set
		{
			mPRKEY = value;
		}
	}
		
	public DateTime? TUNGAY
    {
		get
    	{
			return mTUNGAY;
		}
		set
      	{
			mTUNGAY = value;
		}
	}

	public DateTime? DENNGAY
    {
		get
    	{
			return mDENNGAY;
		}
		set
      	{
			mDENNGAY = value;
		}
	}

	public string TENTRUONG
    {
		get
    	{
			return mTENTRUONG;
		}
		set
      	{
			mTENTRUONG = value;
		}
	}

	public string TENTRUONGVN
    {
		get
    	{
			return mTENTRUONGVN;
		}
		set
      	{
			mTENTRUONGVN = value;
		}
	}

	public string CONGTHUC
    {
		get
    	{
			return mCONGTHUC;
		}
		set
      	{
			mCONGTHUC = value;
		}
	}

	public bool ISINUSED
    {
		get
    	{
			return mISINUSED;
		}
		set
      	{
			mISINUSED = value;
		}
	}

	public int CREATEDUSER
    {
		get
    	{
			return mCREATEDUSER;
		}
		set
      	{
			mCREATEDUSER = value;
		}
	}

	public DateTime DATECREATE
    {
		get
    	{
			return mDATECREATE;
		}
		set
      	{
			mDATECREATE = value;
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

	public bool? DIEUKIENGIOITINH
    {
		get
    	{
			return mDIEUKIENGIOITINH;
		}
		set
      	{
			mDIEUKIENGIOITINH = value;
		}
	}

	public int? DIEUKIENTHAMNIEN
    {
		get
    	{
			return mDIEUKIENTHAMNIEN;
		}
		set
      	{
			mDIEUKIENTHAMNIEN = value;
		}
	}

	public DateTime? DIEUKIENNGAYTHANG
    {
		get
    	{
			return mDIEUKIENNGAYTHANG;
		}
		set
      	{
			mDIEUKIENNGAYTHANG = value;
		}
	}

	public bool? DIEUKIENNGAYTHANG_AMDUONG
    {
		get
    	{
			return mDIEUKIENNGAYTHANG_AM;
		}
		set
      	{
            mDIEUKIENNGAYTHANG_AM = value;
		}
	}

	public int? DIEUKIENDOTUOI
    {
		get
    	{
			return mDIEUKIENDOTUOI;
		}
		set
      	{
			mDIEUKIENDOTUOI = value;
		}
	}

	public string DIEUKIENCHUCVU
    {
		get
    	{
			return mDIEUKIENCHUCVU;
		}
		set
      	{
			mDIEUKIENCHUCVU = value;
		}
	}

	public string DIEUKIENMACONGTRINH
    {
		get
    	{
			return mDIEUKIENMACONGTRINH;
		}
		set
      	{
			mDIEUKIENMACONGTRINH = value;
		}
	}

	public string DIEUKIENLOAIHOPDONG
    {
		get
    	{
			return mDIEUKIENLOAIHOPDONG;
		}
		set
      	{
			mDIEUKIENLOAIHOPDONG = value;
		}
	}

	public string DIEUKIENNGACH
    {
		get
    	{
			return mDIEUKIENNGACH;
		}
		set
      	{
			mDIEUKIENNGACH = value;
		}
	}

	public string DIEUKIENCAPBACQDOI
    {
		get
    	{
			return mDIEUKIENCAPBACQDOI;
		}
		set
      	{
			mDIEUKIENCAPBACQDOI = value;
		}
	}

	public string DIEUKIENCHUCVUDOAN
    {
		get
    	{
			return mDIEUKIENCHUCVUDOAN;
		}
		set
      	{
			mDIEUKIENCHUCVUDOAN = value;
		}
	}

	public string DIEUKIENCHUCVUDANG
    {
		get
    	{
			return mDIEUKIENCHUCVUDANG;
		}
		set
      	{
			mDIEUKIENCHUCVUDANG = value;
		}
	}
    #endregion
  
}