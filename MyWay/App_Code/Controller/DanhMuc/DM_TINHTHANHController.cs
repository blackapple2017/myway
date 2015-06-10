using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_TINTHANHController
/// </summary>
public class DM_TINHTHANHController:LinqProvider
{
	public DM_TINHTHANHController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_TINHTHANH> GetByAll()
    {
        var rs = from t in dataContext.DM_TINHTHANHs
                 select t;
        return rs.ToList(); 
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_TINHTHANHs
                 select new StoreComboObject { 
                    MA = t.MA_TINHTHANH,
                    TEN = t.TEN_TINHTHANH
                 };
        return rs.ToList();
    }

    public List<DAL.DM_TINHTHANH> GetByMaNuoc(string maNuoc)
    {
        var rs = (from t in dataContext.DM_TINHTHANHs
                 where t.MA_NUOC == maNuoc
                 select t).OrderBy(t => t.TEN_TINHTHANH);
        return rs.ToList();
    }

    public void GetCombobox(ref Ext.Net.ComboBox combobox)
    {
        combobox.DisplayField = "TEN_TINHTHANH";
        combobox.ValueField = "MA_TINHTHANH";
        combobox.EnableViewState = false;
        string storeName = "store" + combobox.ID;
        Ext.Net.Store store = new CommonUtil().GetStore(storeName, "~/Modules/Base/ComboHandler.ashx", "DM_TINHTHANH", "MA_TINHTHANH", "TEN_TINHTHANH");
        combobox.Store.Add(store);
        combobox.Listeners.Expand.Handler += "if(" + storeName + ".getCount()==0){" + storeName + ".reload();}";
    }
}