using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUCVUController
/// </summary>
public class DM_CHUCVUController:LinqProvider
{

    public  List<StoreComboObject> GetALL()
    {
        return dataContext.DM_CHUCVUs.Select(t => new StoreComboObject {MA = t.MA_CHUCVU, TEN = t.TEN_CHUCVU}).ToList();
    }
    public void GetCombobox(ref Ext.Net.ComboBox combobox)
    {
        combobox.DisplayField = "TEN_CHUCVU";
        combobox.ValueField = "MA_CHUCVU";
        combobox.EnableViewState = false;
        string storeName = "store" + combobox.ID;
        Ext.Net.Store store = new CommonUtil().GetStore(storeName, "~/Modules/Base/ComboHandler.ashx", "DM_CHUCVU", "MA_CHUCVU", "TEN_CHUCVU");
        combobox.Store.Add(store);
        combobox.Listeners.Expand.Handler += "if(" + storeName + ".getCount()==0){" + storeName + ".reload();}";
    }
    public string GetNameById(string maChucVu)
    {
        var rs = (from t in dataContext.DM_CHUCVUs
                  where t.MA_CHUCVU == maChucVu
                  select t.TEN_CHUCVU).FirstOrDefault();
        return rs;
    }
}