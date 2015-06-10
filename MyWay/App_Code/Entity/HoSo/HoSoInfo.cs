using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoSoInfo
/// </summary>
public class HoSoInfo
{


    #region "Private Members"
    private decimal mPRKEY;
    private string mMACB = string.Empty;
    private string mHOCB = string.Empty;
    private string mTENCB = string.Empty;
    private string mHOTEN = string.Empty;
    private string mSOHIEUCCVC = string.Empty;
    private DateTime? mNGAYSINH;
    private string mGIOITINH = string.Empty;
    private string mMATTHN = string.Empty;
    private string mBIDANH = string.Empty;
    private string mTENKHAC = string.Empty;
    private string mNOISINH = string.Empty;
    private string mMATINHTHANH = string.Empty;
    private string mDIACHILH = string.Empty;
    private string mHOKHAU = string.Empty;
    private string mDIDONG = string.Empty;
    private string mDTNHA = string.Empty;
    private string mDTCQUAN = string.Empty;
    private string mMANUOC = string.Empty;
    private string mMADANTOC = string.Empty;
    private string mMATONGIAO = string.Empty;
    private string mMATDVANHOA = string.Empty;
    private string mMATTSUCKHOE = string.Empty;
    private string mNHOMMAU = string.Empty;
    private decimal? mCHIEUCAO;
    private decimal? mCANNANG;
    private string mMANGOAINGU = string.Empty;
    private string mMATINHOC = string.Empty;
    private string mMATRINHDO = string.Empty;
    private string mMACHUYENNGANH = string.Empty;
    private decimal? mNAMTN;
    private string mMAXEPLOAI = string.Empty;
    private string mMATRUONGDAOTAO = string.Empty;
    private DateTime? mNGAYTUYENDTIEN;
    private DateTime? mNGAYTUYENCHINHTHUC;
    private DateTime? mNGAYVAOCHINHTHUC;
    private string mMAHTTUYENDUNG = string.Empty;
    private string mNGHETRUOCTUYEN = string.Empty;
    private string mEMAIL = string.Empty;
    private string mCONGVIEC = string.Empty;
    private string mLOAIHDONG = string.Empty;
    private string mCHUCVU = string.Empty;
    private DateTime? mNGAYBNCHUCVU;
    private string mMANGACH = string.Empty;
    private DateTime? mNGAYBNNGACH;
    private string mMACONGTRINH = string.Empty;
    private string mPHONG = string.Empty;
    private string mMATO = string.Empty;
    private string mTPGIADINH = string.Empty;
    private string mMATPBANTHAN = string.Empty;
    private string mMATDCHINHTRI = string.Empty;
    private string mMATDQUANLY = string.Empty;
    private string mMATDQLKT = string.Empty;
    private string mSOTHEBHYT = string.Empty;
    private DateTime? mNGAYHETHANBHYT;
    private string mMANOIKCB = string.Empty;
    private string mSOTHEBHXH = string.Empty;
    private DateTime? mNGAYCAPBHXH;
    private string mMANOICAPBHXH = string.Empty;
    private string mTYLEDONGBH = string.Empty;
    private string mSOCMND = string.Empty;
    private string mMANOICAPCMND = string.Empty;
    private DateTime? mNGAYCAPCMND;
    private string mSOHOCHIEU = string.Empty;
    private DateTime? mNGAYCAPHOCHIEU;
    private DateTime? mNGAYHETHANHOCHIEU;
    private string mMANOICAPHOCHIEU = string.Empty;
    private string mMALOAICS = string.Empty;
    private DateTime? mNGAYTGCM;
    private DateTime? mNGAYVAOQDOI;
    private DateTime? mNGAYRAQDOI;
    private string mMACHUCVUQDOI = string.Empty;
    private string mMACAPBACQDOI = string.Empty;
    private DateTime? mNGAYVAODOAN;
    private string mNOIKETNAPDOAN = string.Empty;
    private string mMACHUCVUDOAN = string.Empty;
    private DateTime? mNGAYVAODANG;
    private DateTime? mNGAYCTHUCDANG;
    private string mNOIKETNAPDANG = string.Empty;
    private string mSOTHEDANG = string.Empty;
    private string mMACHUCVUDANG = string.Empty;
    private decimal? mHSLUONG;
    private decimal? mMUCLUONG;
    private decimal? mLUONGDONGBHXH;
    private decimal? mPHUCAPCHUCVU;
    private decimal? mPHUCAPKHAC;
    private decimal? mPHUCAPTNVK;
    private DateTime? mNGAYHUONGTNVK;
    private string mBACLUONG = string.Empty;
    private DateTime? mNGAYHLUONG;
    private string mBACLUONGNB = string.Empty;
    private DateTime? mNGAYHLUONGNB;
    private bool? mDANGHI;
    private DateTime? mNGAYNGHI;
    private string mMALYDONGHI = string.Empty;
    private string mPHOTO = string.Empty;
    private DateTime? mNGAYDONGBH;
    private DateTime? mNGAYKTBH;
    private string mMSTCANHAN = string.Empty;
    private string mSOTAIKHOAN = string.Empty;
    private string mTAINH = string.Empty;
    private decimal? mSONGAYNGHIPHEP;
    private string mNANGLUC = string.Empty;
    private string mDANHGIA = string.Empty;
    private string mUSERNAME = string.Empty;
    private DateTime? mDATECREATE;
    private string mMADONVI = string.Empty;
    #endregion

    #region "Constructors"

    public HoSoInfo()
    {
    }

    public HoSoInfo(decimal pRKEY, string mACB, string hOCB, string tENCB, string hOTEN, string sOHIEUCCVC, DateTime? nGAYSINH, string mAGIOITINH, string mATTHN, string bIDANH, string tENKHAC, string nOISINH, string mATINHTHANH, string dIACHILH, string hOKHAU, string dIDONG, string dTNHA, string dTCQUAN, string mANUOC, string mADANTOC, string mATONGIAO, string mATDVANHOA, string mATTSUCKHOE, string nHOMMAU, decimal? cHIEUCAO, decimal? cANNANG, string mANGOAINGU, string mATINHOC, string mATRINHDO, string mACHUYENNGANH, decimal? nAMTN, string mAXEPLOAI, string mATRUONGDAOTAO, DateTime? nGAYTUYENDTIEN, DateTime? nGAYTUYENCHINHTHUC, DateTime? nGAYVAOCHINHTHUC, string mAHTTUYENDUNG, string nGHETRUOCTUYEN, string eMAIL, string mACONGVIEC, string mALOAIHDONG, string mACHUCVU, DateTime? nGAYBNCHUCVU, string mANGACH, DateTime? nGAYBNNGACH, string mACONGTRINH, string mAPHONG, string mATO, string mATPGIADINH, string mATPBANTHAN, string mATDCHINHTRI, string mATDQUANLY, string mATDQLKT, string sOTHEBHYT, DateTime? nGAYHETHANBHYT, string mANOIKCB, string sOTHEBHXH, DateTime? nGAYCAPBHXH, string mANOICAPBHXH, string tYLEDONGBH, string sOCMND, string mANOICAPCMND, DateTime? nGAYCAPCMND, string sOHOCHIEU, DateTime? nGAYCAPHOCHIEU, DateTime? nGAYHETHANHOCHIEU, string mANOICAPHOCHIEU, string mALOAICS, DateTime? nGAYTGCM, DateTime? nGAYVAOQDOI, DateTime? nGAYRAQDOI, string mACHUCVUQDOI, string mACAPBACQDOI, DateTime? nGAYVAODOAN, string nOIKETNAPDOAN, string mACHUCVUDOAN, DateTime? nGAYVAODANG, DateTime? nGAYCTHUCDANG, string nOIKETNAPDANG, string sOTHEDANG, string mACHUCVUDANG, decimal? hSLUONG, decimal? mUCLUONG, decimal? lUONGDONGBHXH, decimal? pHUCAPCHUCVU, decimal? pHUCAPKHAC, decimal? pHUCAPTNVK, DateTime? nGAYHUONGTNVK, string bACLUONG, DateTime? nGAYHLUONG, string bACLUONGNB, DateTime? nGAYHLUONGNB, bool? dANGHI, DateTime? nGAYNGHI, string mALYDONGHI, string pHOTO, DateTime? nGAYDONGBH, DateTime? nGAYKTBH, string mSTCANHAN, string sOTAIKHOAN, string tAINH, decimal? sONGAYNGHIPHEP, string nANGLUC, string dANHGIA, string uSERNAME, DateTime? dATECREATE, string mADONVI)
    {
        mPRKEY = pRKEY;
        mMACB = mACB;
        mHOCB = hOCB;
        mTENCB = tENCB;
        mHOTEN = hOTEN;
        mSOHIEUCCVC = sOHIEUCCVC;
        mNGAYSINH = nGAYSINH;
        mGIOITINH = mAGIOITINH;
        mMATTHN = mATTHN;
        mBIDANH = bIDANH;
        mTENKHAC = tENKHAC;
        mNOISINH = nOISINH;
        mMATINHTHANH = mATINHTHANH;
        mDIACHILH = dIACHILH;
        mHOKHAU = hOKHAU;
        mDIDONG = dIDONG;
        mDTNHA = dTNHA;
        mDTCQUAN = dTCQUAN;
        mMANUOC = mANUOC;
        mMADANTOC = mADANTOC;
        mMATONGIAO = mATONGIAO;
        mMATDVANHOA = mATDVANHOA;
        mMATTSUCKHOE = mATTSUCKHOE;
        mNHOMMAU = nHOMMAU;
        mCHIEUCAO = cHIEUCAO;
        mCANNANG = cANNANG;
        mMANGOAINGU = mANGOAINGU;
        mMATINHOC = mATINHOC;
        mMATRINHDO = mATRINHDO;
        mMACHUYENNGANH = mACHUYENNGANH;
        mNAMTN = nAMTN;
        mMAXEPLOAI = mAXEPLOAI;
        mMATRUONGDAOTAO = mATRUONGDAOTAO;
        mNGAYTUYENDTIEN = nGAYTUYENDTIEN;
        mNGAYTUYENCHINHTHUC = nGAYTUYENCHINHTHUC;
        mNGAYVAOCHINHTHUC = nGAYVAOCHINHTHUC;
        mMAHTTUYENDUNG = mAHTTUYENDUNG;
        mNGHETRUOCTUYEN = nGHETRUOCTUYEN;
        mEMAIL = eMAIL;
        mCONGVIEC = mACONGVIEC;
        mLOAIHDONG = mALOAIHDONG;
        mCHUCVU = mACHUCVU;
        mNGAYBNCHUCVU = nGAYBNCHUCVU;
        mMANGACH = mANGACH;
        mNGAYBNNGACH = nGAYBNNGACH;
        mMACONGTRINH = mACONGTRINH;
        mPHONG = mAPHONG;
        mMATO = mATO;
        mTPGIADINH = mATPGIADINH;
        mMATPBANTHAN = mATPBANTHAN;
        mMATDCHINHTRI = mATDCHINHTRI;
        mMATDQUANLY = mATDQUANLY;
        mMATDQLKT = mATDQLKT;
        mSOTHEBHYT = sOTHEBHYT;
        mNGAYHETHANBHYT = nGAYHETHANBHYT;
        mMANOIKCB = mANOIKCB;
        mSOTHEBHXH = sOTHEBHXH;
        mNGAYCAPBHXH = nGAYCAPBHXH;
        mMANOICAPBHXH = mANOICAPBHXH;
        mTYLEDONGBH = tYLEDONGBH;
        mSOCMND = sOCMND;
        mMANOICAPCMND = mANOICAPCMND;
        mNGAYCAPCMND = nGAYCAPCMND;
        mSOHOCHIEU = sOHOCHIEU;
        mNGAYCAPHOCHIEU = nGAYCAPHOCHIEU;
        mNGAYHETHANHOCHIEU = nGAYHETHANHOCHIEU;
        mMANOICAPHOCHIEU = mANOICAPHOCHIEU;
        mMALOAICS = mALOAICS;
        mNGAYTGCM = nGAYTGCM;
        mNGAYVAOQDOI = nGAYVAOQDOI;
        mNGAYRAQDOI = nGAYRAQDOI;
        mMACHUCVUQDOI = mACHUCVUQDOI;
        mMACAPBACQDOI = mACAPBACQDOI;
        mNGAYVAODOAN = nGAYVAODOAN;
        mNOIKETNAPDOAN = nOIKETNAPDOAN;
        mMACHUCVUDOAN = mACHUCVUDOAN;
        mNGAYVAODANG = nGAYVAODANG;
        mNGAYCTHUCDANG = nGAYCTHUCDANG;
        mNOIKETNAPDANG = nOIKETNAPDANG;
        mSOTHEDANG = sOTHEDANG;
        mMACHUCVUDANG = mACHUCVUDANG;
        mHSLUONG = hSLUONG;
        mMUCLUONG = mUCLUONG;
        mLUONGDONGBHXH = lUONGDONGBHXH;
        mPHUCAPCHUCVU = pHUCAPCHUCVU;
        mPHUCAPKHAC = pHUCAPKHAC;
        mPHUCAPTNVK = pHUCAPTNVK;
        mNGAYHUONGTNVK = nGAYHUONGTNVK;
        mBACLUONG = bACLUONG;
        mNGAYHLUONG = nGAYHLUONG;
        mBACLUONGNB = bACLUONGNB;
        mNGAYHLUONGNB = nGAYHLUONGNB;
        mDANGHI = dANGHI;
        mNGAYNGHI = nGAYNGHI;
        mMALYDONGHI = mALYDONGHI;
        mPHOTO = pHOTO;
        mNGAYDONGBH = nGAYDONGBH;
        mNGAYKTBH = nGAYKTBH;
        mMSTCANHAN = mSTCANHAN;
        mSOTAIKHOAN = sOTAIKHOAN;
        mTAINH = tAINH;
        mSONGAYNGHIPHEP = sONGAYNGHIPHEP;
        mNANGLUC = nANGLUC;
        mDANHGIA = dANHGIA;
        mUSERNAME = uSERNAME;
        mDATECREATE = dATECREATE;
        mMADONVI = mADONVI;
    }

    #endregion

    #region "Public Properties"
    public string THOIGIANTHUVIEC { get; set; }
    public string TENCHUCVU { get; set; }
    public string TENTRINHDO { get; set; }
    public string THANHPHO_PHONGBAN { get; set; }
    public decimal PRKEY
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

    public string MACB
    {
        get
        {
            return mMACB;
        }
        set
        {
            mMACB = value;
        }
    }

    public string HOCB
    {
        get
        {
            return mHOCB;
        }
        set
        {
            mHOCB = value;
        }
    }

    public string TENCB
    {
        get
        {
            return mTENCB;
        }
        set
        {
            mTENCB = value;
        }
    }

    public string HOTEN
    {
        get
        {
            return mHOTEN;
        }
        set
        {
            mHOTEN = value;
        }
    }

    public string SOHIEUCCVC
    {
        get
        {
            return mSOHIEUCCVC;
        }
        set
        {
            mSOHIEUCCVC = value;
        }
    }

    public DateTime? NGAYSINH
    {
        get
        {
            return mNGAYSINH;
        }
        set
        {
            mNGAYSINH = value;
        }
    }

    public string GIOITINH
    {
        get
        {
            return mGIOITINH;
        }
        set
        {
            mGIOITINH = value;
        }
    }

    public string MATTHN
    {
        get
        {
            return mMATTHN;
        }
        set
        {
            mMATTHN = value;
        }
    }

    public string BIDANH
    {
        get
        {
            return mBIDANH;
        }
        set
        {
            mBIDANH = value;
        }
    }

    public string TENKHAC
    {
        get
        {
            return mTENKHAC;
        }
        set
        {
            mTENKHAC = value;
        }
    }

    public string NOISINH
    {
        get
        {
            return mNOISINH;
        }
        set
        {
            mNOISINH = value;
        }
    }

    public string MATINHTHANH
    {
        get
        {
            return mMATINHTHANH;
        }
        set
        {
            mMATINHTHANH = value;
        }
    }

    public string DIACHILH
    {
        get
        {
            return mDIACHILH;
        }
        set
        {
            mDIACHILH = value;
        }
    }

    public string HOKHAU
    {
        get
        {
            return mHOKHAU;
        }
        set
        {
            mHOKHAU = value;
        }
    }

    public string DIDONG
    {
        get
        {
            return mDIDONG;
        }
        set
        {
            mDIDONG = value;
        }
    }

    public string DTNHA
    {
        get
        {
            return mDTNHA;
        }
        set
        {
            mDTNHA = value;
        }
    }

    public string DTCQUAN
    {
        get
        {
            return mDTCQUAN;
        }
        set
        {
            mDTCQUAN = value;
        }
    }

    public string MANUOC
    {
        get
        {
            return mMANUOC;
        }
        set
        {
            mMANUOC = value;
        }
    }

    public string MADANTOC
    {
        get
        {
            return mMADANTOC;
        }
        set
        {
            mMADANTOC = value;
        }
    }

    public string MATONGIAO
    {
        get
        {
            return mMATONGIAO;
        }
        set
        {
            mMATONGIAO = value;
        }
    }

    public string MATDVANHOA
    {
        get
        {
            return mMATDVANHOA;
        }
        set
        {
            mMATDVANHOA = value;
        }
    }

    public string MATTSUCKHOE
    {
        get
        {
            return mMATTSUCKHOE;
        }
        set
        {
            mMATTSUCKHOE = value;
        }
    }

    public string NHOMMAU
    {
        get
        {
            return mNHOMMAU;
        }
        set
        {
            mNHOMMAU = value;
        }
    }

    public decimal? CHIEUCAO
    {
        get
        {
            return mCHIEUCAO;
        }
        set
        {
            mCHIEUCAO = value;
        }
    }

    public decimal? CANNANG
    {
        get
        {
            return mCANNANG;
        }
        set
        {
            mCANNANG = value;
        }
    }

    public string MANGOAINGU
    {
        get
        {
            return mMANGOAINGU;
        }
        set
        {
            mMANGOAINGU = value;
        }
    }

    public string MATINHOC
    {
        get
        {
            return mMATINHOC;
        }
        set
        {
            mMATINHOC = value;
        }
    }

    public string TRINHDO
    {
        get
        {
            return mMATRINHDO;
        }
        set
        {
            mMATRINHDO = value;
        }
    }

    public string MACHUYENNGANH
    {
        get
        {
            return mMACHUYENNGANH;
        }
        set
        {
            mMACHUYENNGANH = value;
        }
    }

    public decimal? NAMTN
    {
        get
        {
            return mNAMTN;
        }
        set
        {
            mNAMTN = value;
        }
    }

    public string MAXEPLOAI
    {
        get
        {
            return mMAXEPLOAI;
        }
        set
        {
            mMAXEPLOAI = value;
        }
    }

    public string TRUONGDAOTAO
    {
        get
        {
            return mMATRUONGDAOTAO;
        }
        set
        {
            mMATRUONGDAOTAO = value;
        }
    }

    public DateTime? NGAYTUYENDTIEN
    {
        get
        {
            return mNGAYTUYENDTIEN;
        }
        set
        {
            mNGAYTUYENDTIEN = value;
        }
    }

    public DateTime? NGAYTHUVIEC
    {
        get
        {
            return mNGAYTUYENCHINHTHUC;
        }
        set
        {
            mNGAYTUYENCHINHTHUC = value;
        }
    }

    public DateTime? NGAYNHANCHINHTHUC
    {
        get
        {
            return mNGAYVAOCHINHTHUC;
        }
        set
        {
            mNGAYVAOCHINHTHUC = value;
        }
    }

    public string MAHTTUYENDUNG
    {
        get
        {
            return mMAHTTUYENDUNG;
        }
        set
        {
            mMAHTTUYENDUNG = value;
        }
    }

    public string NGHETRUOCTUYEN
    {
        get
        {
            return mNGHETRUOCTUYEN;
        }
        set
        {
            mNGHETRUOCTUYEN = value;
        }
    }

    public string EMAIL
    {
        get
        {
            return mEMAIL;
        }
        set
        {
            mEMAIL = value;
        }
    }

    public string MACONGVIEC
    {
        get
        {
            return mCONGVIEC;
        }
        set
        {
            mCONGVIEC = value;
        }
    }

    public string LOAIHDONG
    {
        get
        {
            return mLOAIHDONG;
        }
        set
        {
            mLOAIHDONG = value;
        }
    }

    public string MACHUCVU
    {
        get
        {
            return mCHUCVU;
        }
        set
        {
            mCHUCVU = value;
        }
    }

    public DateTime? NGAYBNCHUCVU
    {
        get
        {
            return mNGAYBNCHUCVU;
        }
        set
        {
            mNGAYBNCHUCVU = value;
        }
    }

    public string MANGACH
    {
        get
        {
            return mMANGACH;
        }
        set
        {
            mMANGACH = value;
        }
    }

    public DateTime? NGAYBNNGACH
    {
        get
        {
            return mNGAYBNNGACH;
        }
        set
        {
            mNGAYBNNGACH = value;
        }
    }

    public string MACONGTRINH
    {
        get
        {
            return mMACONGTRINH;
        }
        set
        {
            mMACONGTRINH = value;
        }
    }

    public string MAPHONG
    {
        get
        {
            return mPHONG;
        }
        set
        {
            mPHONG = value;
        }
    }

    public string MATO
    {
        get
        {
            return mMATO;
        }
        set
        {
            mMATO = value;
        }
    }

    public string MATPGIADINH
    {
        get
        {
            return mTPGIADINH;
        }
        set
        {
            mTPGIADINH = value;
        }
    }

    public string MATPBANTHAN
    {
        get
        {
            return mMATPBANTHAN;
        }
        set
        {
            mMATPBANTHAN = value;
        }
    }

    public string MATDCHINHTRI
    {
        get
        {
            return mMATDCHINHTRI;
        }
        set
        {
            mMATDCHINHTRI = value;
        }
    }

    public string MATDQUANLY
    {
        get
        {
            return mMATDQUANLY;
        }
        set
        {
            mMATDQUANLY = value;
        }
    }

    public string MATDQLKT
    {
        get
        {
            return mMATDQLKT;
        }
        set
        {
            mMATDQLKT = value;
        }
    }

    public string SOTHEBHYT
    {
        get
        {
            return mSOTHEBHYT;
        }
        set
        {
            mSOTHEBHYT = value;
        }
    }

    public DateTime? NGAYHETHANBHYT
    {
        get
        {
            return mNGAYHETHANBHYT;
        }
        set
        {
            mNGAYHETHANBHYT = value;
        }
    }

    public string MANOIKCB
    {
        get
        {
            return mMANOIKCB;
        }
        set
        {
            mMANOIKCB = value;
        }
    }

    public string SOTHEBHXH
    {
        get
        {
            return mSOTHEBHXH;
        }
        set
        {
            mSOTHEBHXH = value;
        }
    }

    public DateTime? NGAYCAPBHXH
    {
        get
        {
            return mNGAYCAPBHXH;
        }
        set
        {
            mNGAYCAPBHXH = value;
        }
    }

    public string MANOICAPBHXH
    {
        get
        {
            return mMANOICAPBHXH;
        }
        set
        {
            mMANOICAPBHXH = value;
        }
    }

    public string TYLEDONGBH
    {
        get
        {
            return mTYLEDONGBH;
        }
        set
        {
            mTYLEDONGBH = value;
        }
    }

    public string SOCMND
    {
        get
        {
            return mSOCMND;
        }
        set
        {
            mSOCMND = value;
        }
    }

    public string MANOICAPCMND
    {
        get
        {
            return mMANOICAPCMND;
        }
        set
        {
            mMANOICAPCMND = value;
        }
    }

    public DateTime? NGAYCAPCMND
    {
        get
        {
            return mNGAYCAPCMND;
        }
        set
        {
            mNGAYCAPCMND = value;
        }
    }

    public string SOHOCHIEU
    {
        get
        {
            return mSOHOCHIEU;
        }
        set
        {
            mSOHOCHIEU = value;
        }
    }

    public DateTime? NGAYCAPHOCHIEU
    {
        get
        {
            return mNGAYCAPHOCHIEU;
        }
        set
        {
            mNGAYCAPHOCHIEU = value;
        }
    }

    public DateTime? NGAYHETHANHOCHIEU
    {
        get
        {
            return mNGAYHETHANHOCHIEU;
        }
        set
        {
            mNGAYHETHANHOCHIEU = value;
        }
    }

    public string MANOICAPHOCHIEU
    {
        get
        {
            return mMANOICAPHOCHIEU;
        }
        set
        {
            mMANOICAPHOCHIEU = value;
        }
    }

    public string MALOAICS
    {
        get
        {
            return mMALOAICS;
        }
        set
        {
            mMALOAICS = value;
        }
    }

    public DateTime? NGAYTGCM
    {
        get
        {
            return mNGAYTGCM;
        }
        set
        {
            mNGAYTGCM = value;
        }
    }

    public DateTime? NGAYVAOQDOI
    {
        get
        {
            return mNGAYVAOQDOI;
        }
        set
        {
            mNGAYVAOQDOI = value;
        }
    }

    public DateTime? NGAYRAQDOI
    {
        get
        {
            return mNGAYRAQDOI;
        }
        set
        {
            mNGAYRAQDOI = value;
        }
    }

    public string MACHUCVUQDOI
    {
        get
        {
            return mMACHUCVUQDOI;
        }
        set
        {
            mMACHUCVUQDOI = value;
        }
    }

    public string MACAPBACQDOI
    {
        get
        {
            return mMACAPBACQDOI;
        }
        set
        {
            mMACAPBACQDOI = value;
        }
    }

    public DateTime? NGAYVAODOAN
    {
        get
        {
            return mNGAYVAODOAN;
        }
        set
        {
            mNGAYVAODOAN = value;
        }
    }

    public string NOIKETNAPDOAN
    {
        get
        {
            return mNOIKETNAPDOAN;
        }
        set
        {
            mNOIKETNAPDOAN = value;
        }
    }

    public string MACHUCVUDOAN
    {
        get
        {
            return mMACHUCVUDOAN;
        }
        set
        {
            mMACHUCVUDOAN = value;
        }
    }

    public DateTime? NGAYVAODANG
    {
        get
        {
            return mNGAYVAODANG;
        }
        set
        {
            mNGAYVAODANG = value;
        }
    }

    public DateTime? NGAYCTHUCDANG
    {
        get
        {
            return mNGAYCTHUCDANG;
        }
        set
        {
            mNGAYCTHUCDANG = value;
        }
    }

    public string NOIKETNAPDANG
    {
        get
        {
            return mNOIKETNAPDANG;
        }
        set
        {
            mNOIKETNAPDANG = value;
        }
    }

    public string SOTHEDANG
    {
        get
        {
            return mSOTHEDANG;
        }
        set
        {
            mSOTHEDANG = value;
        }
    }

    public string MACHUCVUDANG
    {
        get
        {
            return mMACHUCVUDANG;
        }
        set
        {
            mMACHUCVUDANG = value;
        }
    }

    public decimal? HSLUONG
    {
        get
        {
            return mHSLUONG;
        }
        set
        {
            mHSLUONG = value;
        }
    }

    public decimal? MUCLUONG
    {
        get
        {
            return mMUCLUONG;
        }
        set
        {
            mMUCLUONG = value;
        }
    }

    public decimal? LUONGDONGBHXH
    {
        get
        {
            return mLUONGDONGBHXH;
        }
        set
        {
            mLUONGDONGBHXH = value;
        }
    }

    public decimal? PHUCAPCHUCVU
    {
        get
        {
            return mPHUCAPCHUCVU;
        }
        set
        {
            mPHUCAPCHUCVU = value;
        }
    }

    public decimal? PHUCAPKHAC
    {
        get
        {
            return mPHUCAPKHAC;
        }
        set
        {
            mPHUCAPKHAC = value;
        }
    }

    public decimal? PHUCAPTNVK
    {
        get
        {
            return mPHUCAPTNVK;
        }
        set
        {
            mPHUCAPTNVK = value;
        }
    }

    public DateTime? NGAYHUONGTNVK
    {
        get
        {
            return mNGAYHUONGTNVK;
        }
        set
        {
            mNGAYHUONGTNVK = value;
        }
    }

    public string BACLUONG
    {
        get
        {
            return mBACLUONG;
        }
        set
        {
            mBACLUONG = value;
        }
    }

    public DateTime? NGAYHLUONG
    {
        get
        {
            return mNGAYHLUONG;
        }
        set
        {
            mNGAYHLUONG = value;
        }
    }

    public string BACLUONGNB
    {
        get
        {
            return mBACLUONGNB;
        }
        set
        {
            mBACLUONGNB = value;
        }
    }

    public DateTime? NGAYHLUONGNB
    {
        get
        {
            return mNGAYHLUONGNB;
        }
        set
        {
            mNGAYHLUONGNB = value;
        }
    }

    public bool? DANGHI
    {
        get
        {
            return mDANGHI;
        }
        set
        {
            mDANGHI = value;
        }
    }

    public DateTime? NGAYNGHI
    {
        get
        {
            return mNGAYNGHI;
        }
        set
        {
            mNGAYNGHI = value;
        }
    }

    public string MALYDONGHI
    {
        get
        {
            return mMALYDONGHI;
        }
        set
        {
            mMALYDONGHI = value;
        }
    }

    public string PHOTO
    {
        get
        {
            return mPHOTO;
        }
        set
        {
            mPHOTO = value;
        }
    }

    public DateTime? NGAYDONGBH
    {
        get
        {
            return mNGAYDONGBH;
        }
        set
        {
            mNGAYDONGBH = value;
        }
    }

    public DateTime? NGAYKTBH
    {
        get
        {
            return mNGAYKTBH;
        }
        set
        {
            mNGAYKTBH = value;
        }
    }

    public string MSTCANHAN
    {
        get
        {
            return mMSTCANHAN;
        }
        set
        {
            mMSTCANHAN = value;
        }
    }

    public string SOTAIKHOAN
    {
        get
        {
            return mSOTAIKHOAN;
        }
        set
        {
            mSOTAIKHOAN = value;
        }
    }

    public string TAINH
    {
        get
        {
            return mTAINH;
        }
        set
        {
            mTAINH = value;
        }
    }

    public decimal? SONGAYNGHIPHEP
    {
        get
        {
            return mSONGAYNGHIPHEP;
        }
        set
        {
            mSONGAYNGHIPHEP = value;
        }
    }

    public string NANGLUC
    {
        get
        {
            return mNANGLUC;
        }
        set
        {
            mNANGLUC = value;
        }
    }

    public string DANHGIA
    {
        get
        {
            return mDANHGIA;
        }
        set
        {
            mDANHGIA = value;
        }
    }

    public string USERNAME
    {
        get
        {
            return mUSERNAME;
        }
        set
        {
            mUSERNAME = value;
        }
    }

    public DateTime? DATECREATE
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
    #endregion

    public string PHONGBAN { get; set; }
    public string MaChamCong { get; set; }
    public string TENNUOC { get; set; }
    public string NOICAPCMNTT { get; set; }
    public DateTime? NGAYBATDAUHOPDONG { get; set; }
    public DateTime? NGAYKETTHUCHOPDONG { get; set; }
    public string TENCHUCVUMOI { get; set; }
    public int? THOIHANHOPDONG { get; set; }
    public string CHUCDANH { get; set; }
    public string sOHD { get; set; }
    public string CONGTYCU { get; set; }
    public string GIOITINH_NAM_NU { get; set; }
    public DateTime? BATDAUHOPDONG { get; set; }
    public DateTime? KETTHUCHOPDONG { get; set; }
    public string MaCa { get; set; }
   
}