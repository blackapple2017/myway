using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class DM_LOAI_HDONGBHController
{
    public DataTable GetByPrkey(string pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetDM_LOAI_HDONGByPrkey", "@MA_LOAI_HDONG", pr_key);
    }

    public void DeleteByPrkey(string pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteDM_LOAI_HDONGByPrkey", "@MA_LOAI_HDONG", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey, out int count,string MaDonVi)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountDM_LOAI_HDONG", "@searchKey", "@MaDonVi", searchKey,MaDonVi).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectDM_LOAI_HDONG", "@start", "@limit", "@searchKey", "@MaDonVi", start, limit, searchKey, @MaDonVi);
    }

    public string Insert(DM_LOAI_HDONGInfo record)
    {
		return DataController.DataHandler.GetInstance().ExecuteScalar("InsertDM_LOAI_HDONG" , "@MA_LOAI_HDONG", "@TEN_LOAI_HDONG", "@GHI_CHU", "@DATE_CREATE", "@USERNAME", "@MA_DONVI", "@THOI_HAN_HOPDONG(MONTH)", "@BHXH", "@BHYT", "@BHTN" , record.MA_LOAI_HDONG, record.TEN_LOAI_HDONG, record.GHI_CHU, record.DATE_CREATE, record.USERNAME, record.MA_DONVI, record.THOI_HAN_HOPDONG, record.BHXH, record.BHYT, record.BHTN).ToString();
    }

    public void Update(DM_LOAI_HDONGInfo record)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateDM_LOAI_HDONG" , "@MA_LOAI_HDONG", "@BHXH", "@BHYT", "@BHTN" , record.MA_LOAI_HDONG, record.BHXH, record.BHYT, record.BHTN);
    }

    public void DuplucateByPrkey(string pr_key)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateDM_LOAI_HDONGByPrkey", "@MA_LOAI_HDONG", pr_key);
    }

}
