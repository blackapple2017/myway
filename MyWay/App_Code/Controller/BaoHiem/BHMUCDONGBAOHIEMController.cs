using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHMUCDONGBAOHIEMController
{
    public DataTable GetByPrkey(int pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetBHMUCDONGBAOHIEMByPrkey", "@ID", pr_key);
    }

    public void DeleteByPrkey(int pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteBHMUCDONGBAOHIEMByPrkey", "@ID", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey, out int count,string MaDonVi)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountBHMUCDONGBAOHIEM", "@searchKey","@MaDonVi", searchKey,MaDonVi).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectBHMUCDONGBAOHIEM", "@start", "@limit", "@searchKey","@MaDonVi", start, limit, searchKey,MaDonVi);
    }

    public void Insert(BHMUCDONGBAOHIEMInfo record)
    {
        DataController.DataHandler.GetInstance().ExecuteScalar("InsertBHMUCDONGBAOHIEM", "@NgayHieuLuc", "@SanBHXH", "@SanBHYT", "@SanBHTN", "@TranBHXH", "@TranBHYT", "@TranBHTN", "@NVBYXH", "@NVBHYT", "@NVBHTN", "@DVBHXH", "@DVBHYT", "@DVBHTN", "@UserID", "@DateCreate", "@MaDonVi",record.NgayHieuLuc, record.SanBHXH, record.SanBHYT, record.SanBHTN, record.TranBHXH, record.TranBHYT, record.TranBHTN, record.NVBYXH, record.NVBHYT, record.NVBHTN, record.DVBHXH, record.DVBHYT, record.DVBHTN, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void Update(BHMUCDONGBAOHIEMInfo record)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateBHMUCDONGBAOHIEM" , "@ID", "@NgayHieuLuc", "@SanBHXH", "@SanBHYT", "@SanBHTN", "@TranBHXH", "@TranBHYT", "@TranBHTN", "@NVBYXH", "@NVBHYT", "@NVBHTN", "@DVBHXH", "@DVBHYT", "@DVBHTN", "@UserID", "@DateCreate", "@MaDonVi" , record.ID, record.NgayHieuLuc, record.SanBHXH, record.SanBHYT, record.SanBHTN, record.TranBHXH, record.TranBHYT, record.TranBHTN, record.NVBYXH, record.NVBHYT, record.NVBHTN, record.DVBHXH, record.DVBHYT, record.DVBHTN, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void DuplucateByPrkey(int pr_key)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateBHMUCDONGBAOHIEMByPrkey", "@ID", pr_key);
    }

}
