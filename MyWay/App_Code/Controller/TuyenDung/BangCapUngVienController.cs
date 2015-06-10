using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangCapUngVienController
/// </summary>
public class BangCapUngVienController : LinqProvider
{
	public BangCapUngVienController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(DAL.BangCapUngVien bangcap)
    {
        dataContext.BangCapUngViens.InsertOnSubmit(bangcap);
        Save();
    }
    public void Update(DAL.BangCapUngVien bangcap)
    {
        DAL.BangCapUngVien temp = dataContext.BangCapUngViens.SingleOrDefault(t => t.ID == bangcap.ID);
        if (temp != null)
        {
            temp.DA_TN = bangcap.DA_TN;
            temp.DATE_CREATE = bangcap.DATE_CREATE;
            temp.DEN_NGAY = bangcap.DEN_NGAY;
            temp.FR_KEY = bangcap.FR_KEY;
            temp.ID = bangcap.ID;
            temp.KHOA = bangcap.KHOA;
            temp.MA_CHUYENNGANH = bangcap.MA_CHUYENNGANH;
            temp.MA_HT_DAOTAO = bangcap.MA_HT_DAOTAO;
            temp.MA_TRINHDO = bangcap.MA_TRINHDO;
            temp.MA_TRUONG_DAOTAO = bangcap.MA_TRUONG_DAOTAO;
            temp.MA_XEPLOAI = bangcap.MA_XEPLOAI;
            temp.NGAY_NHANBANG = bangcap.NGAY_NHANBANG; 
            temp.TU_NGAY = bangcap.TU_NGAY;
            temp.USERNAME = bangcap.USERNAME;
            Save();
        }
    }
    public void Delete(int id)
    {
        DAL.BangCapUngVien temp = dataContext.BangCapUngViens.SingleOrDefault(t => t.ID == id);
        if (temp != null)
        {
            dataContext.BangCapUngViens.DeleteOnSubmit(temp);
            Save();
        }
    }
         
}