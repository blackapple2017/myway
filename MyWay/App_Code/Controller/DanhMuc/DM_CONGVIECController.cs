using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;

/// <summary>
/// Trần Đức Anh
/// </summary>

public class DM_CONGVIECController : LinqProvider
{
    public DataTable GetByPrkey(string pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetDM_CONGVIECByPrkey", "@MA_CONGVIEC", pr_key);
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CONGVIECs
                 select new StoreComboObject
                 {
                     MA = t.MA_CONGVIEC,
                     TEN = t.TEN_CONGVIEC
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }


    public List<string> GetAllTenCongViec()
    {
      return dataContext.DM_CONGVIECs.Select(t=>t.MA_CONGVIEC).ToList();               
       
    }


    public List<StoreComboObject> GetBySearchKeys(int start, int limit, string searchKey, out int count)
    {
        var rs =
            dataContext.DM_CONGVIECs.Where(t => System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_CONGVIEC, searchKey)).
                Select(t => new StoreComboObject {MA = t.MA_CONGVIEC, TEN = t.TEN_CONGVIEC});
        count = rs.Count();
        return rs.OrderBy(t => t.TEN).Skip(start).Take(limit).ToList();
    }

    public DAL.DM_CONGVIEC GetByMaCV(string maCV)
    {
        return dataContext.DM_CONGVIECs.FirstOrDefault(t => t.MA_CONGVIEC == maCV);
    }

    public void DeleteByPrkey(string pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteDM_CONGVIECByPrkey", "@MA_CONGVIEC", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey,string madonvi, out int count)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountDM_CONGVIEC", "@searchKey" , searchKey).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectDM_CONGVIEC", "@start", "@limit", "@searchKey", start, limit, searchKey);
    }

    public List<StoreComboObject> GetAllRecord(List<string> maDonViList)
    {
        var re = dataContext.DM_CONGVIECs.Where(t => maDonViList.Contains(t.MA_DONVI)).Select(t => new StoreComboObject
        {
            MA = t.MA_CONGVIEC,
            TEN = t.TEN_CONGVIEC
        }).ToList();
        return re;
    }

    public List<StoreComboObject> GetAllRecord()
    {
        var re = dataContext.DM_CONGVIECs.Select(t => new StoreComboObject
        {
            MA = t.MA_CONGVIEC,
            TEN = t.TEN_CONGVIEC
        }).ToList();
        return re;
    }
    public string GetNameById(string maCongViec)
    {
        var rs = (from t in dataContext.DM_CONGVIECs
                  where t.MA_CONGVIEC == maCongViec
                  select t.TEN_CONGVIEC).FirstOrDefault();
        return rs;
    }
    

    public string Insert(DM_CONGVIECInfo record)
    {
		return DataController.DataHandler.GetInstance().ExecuteScalar("InsertDM_CONGVIEC" , "@MA_CONGVIEC", "@TEN_CONGVIEC", "@USERNAME", "@DATE_CREATE", "@MA_DONVI" , record.MA_CONGVIEC, record.TEN_CONGVIEC, record.USERNAME, record.DATE_CREATE, record.MA_DONVI).ToString();
    }


    public bool Add(DAL.DM_CONGVIEC dmcv)
    {
        if (dataContext.DM_CONGVIECs.Any(dm => dm.MA_CONGVIEC.ToLower() == dmcv.MA_CONGVIEC.ToLower()))
            return false;
        else
        {
            try { dataContext.DM_CONGVIECs.InsertOnSubmit(dmcv);Save(); return true; }
            catch (Exception) { return false; }
        }

    }

    public void Update(DM_CONGVIECInfo record)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateDM_CONGVIEC" , "@MA_CONGVIEC", "@TEN_CONGVIEC", "@USERNAME", "@DATE_CREATE", "@MA_DONVI" , record.MA_CONGVIEC, record.TEN_CONGVIEC, record.USERNAME, record.DATE_CREATE, record.MA_DONVI);
    }

    public void DuplucateByPrkey(string pr_key)
    {
		DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateDM_CONGVIECByPrkey", "@MA_CONGVIEC", pr_key);
    }

    public List<DAL.DM_CONGVIEC> GetByAll()
    {
        var rs = from t in dataContext.DM_CONGVIECs
                 select t;
        return rs.ToList();
    }
    public void GetCombobox(ref Ext.Net.ComboBox combobox)
    {
        combobox.DisplayField = "TEN_CONGVIEC";
        combobox.ValueField = "MA_CONGVIEC";
        combobox.EnableViewState = false;
        string storeName = "store" + combobox.ID;
        Ext.Net.Store store = new CommonUtil().GetStore(storeName, "~/Modules/Base/ComboHandler.ashx", "DM_CONGVIEC", "MA_CONGVIEC", "TEN_CONGVIEC");
        combobox.Store.Add(store);
        combobox.Listeners.Expand.Handler += "if(" + storeName + ".getCount()==0){" + storeName + ".reload();}";
    }
}
