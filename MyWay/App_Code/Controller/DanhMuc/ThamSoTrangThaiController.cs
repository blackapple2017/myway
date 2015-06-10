using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataController;

/// <summary>
/// Lê Văn Anh
/// </summary>
public class ThamSoTrangThaiController : LinqProvider
{

    public const string TRANG_THAI_TUYEN_DUNG = "TrangThaiTuyenDung";
    public const string TRANG_THAI_DANH_GIA = "TrangThaiDanhGia";
    public const string HINH_THUC_LAM_VIEC = "HinhThucLamViec";
    public const string CAC_MON_THI_TUYEN = "CacMonThiTuyen";
    public const string NGUON_UNG_VIEN = "NguonUngVien";


    /// <summary>
    /// Lấy giá trị của các trạng thái theo tham số
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="isInUsed"></param>
    /// <returns></returns>
    public IEnumerable<DAL.ThamSoTrangThai> GetByParamName(string paramName, bool isInUsed)
    {
        return dataContext.ThamSoTrangThais.Where(t => t.ParamName == paramName && t.IsInUsed == isInUsed).OrderBy(t => t.Order);
    }

    public IEnumerable<DAL.ThamSoTrangThai> GetByParamName(string paramName, bool isInUsed, string maDonVi)
    {
        return dataContext.ThamSoTrangThais.Where(t => t.ParamName == paramName && t.IsInUsed == isInUsed && t.MaDonVi == maDonVi).OrderBy(t => t.Order);
    }


    public IEnumerable<DAL.ThamSoTrangThai> GetByParamName(string paramName, string maDonVi, string searchKey)
    {
        return dataContext.ThamSoTrangThais.Where(t => t.ParamName == paramName && (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.Value, searchKey))).OrderBy(t => t.Order);
    } 

    public void Add(DAL.ThamSoTrangThai thamSoTrangThai)
    {
        dataContext.ThamSoTrangThais.InsertOnSubmit(thamSoTrangThai);
        Save();
    }

    public DAL.ThamSoTrangThai GetByID(int id)
    {
        return dataContext.ThamSoTrangThais.Where(t => t.ID == id).FirstOrDefault();
    }

    public void Delete(int id)
    {
        dataContext.ThamSoTrangThais.DeleteOnSubmit(GetByID(id));
        Save();
    }

    public void Update(DAL.ThamSoTrangThai thamso)
    {
        DAL.ThamSoTrangThai tmp = GetByID(thamso.ID);
        tmp.IsInUsed = thamso.IsInUsed;
        tmp.ParamName = thamso.ParamName;
        tmp.Value = thamso.Value;
        tmp.Order = thamso.Order;
        tmp.Description = thamso.Description;
        Save();
    }

    public void GetCombobox(ref Ext.Net.ComboBox combobox)
    {
        combobox.DisplayField = "Value";
        combobox.EnableViewState = false;
        combobox.ValueField = "ID";
        string storeName = "store" + combobox.ID;
        Ext.Net.Store store = new CommonUtil().GetStore(storeName, "~/Modules/Base/ComboHandler.ashx", "ThamSoTrangThai", "ID", "Value");
        combobox.Store.Add(store);
        combobox.Listeners.Expand.Handler += "if(" + storeName + ".getCount()==0){" + storeName + ".reload();}";
    }
}