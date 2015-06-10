using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Bùi Xuân Đại
/// </summary>

public class DoiTacDaoTaoController
{
    public DataTable GetByPrkey(string pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetDM_DOITACDAOTAOByPrkey", "@Ma", pr_key);
    }

    public void DeleteByPrkey(string pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteDM_DOITACDAOTAOByPrkey", "@Ma", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey, string maDonVi, out int count)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountDM_DOITACDAOTAO", "@searchKey", "@MaDonVi", searchKey, maDonVi).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectDM_DOITACDAOTAO", "@start", "@limit", "@searchKey", "@MaDonVi", start, limit, searchKey, maDonVi);
    }

    public string Insert(DM_DOITACDAOTAOInfo record)
    {
		return DataController.DataHandler.GetInstance().ExecuteScalar("InsertDM_DOITACDAOTAO" , "@Ma", "@Ten", "@DiaChiLienHe", "@TruSoChinh", "@Fax", "@Phone", "@Email", "@Website", "@MA_DONVI", "@CreatedUser" , record.Ma, record.Ten, record.DiaChiLienHe, record.TruSoChinh, record.Fax, record.Phone, record.Email, record.Website, record.MA_DONVI, record.CreatedUser).ToString();
    }

    public void Update(DM_DOITACDAOTAOInfo record)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateDM_DOITACDAOTAO" , "@Ma", "@Ten", "@DiaChiLienHe", "@TruSoChinh", "@Fax", "@Phone", "@Email", "@Website", "@MA_DONVI", "@CreatedUser" , record.Ma, record.Ten, record.DiaChiLienHe, record.TruSoChinh, record.Fax, record.Phone, record.Email, record.Website, record.MA_DONVI, record.CreatedUser);
    }

    public void DuplucateByPrkey(string pr_key)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateDM_DOITACDAOTAOByPrkey", "@Ma", pr_key);
    }

}
