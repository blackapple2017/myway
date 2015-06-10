using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DonViController
/// </summary>
public class DM_DONVIController : LinqProvider
{
    public DM_DONVIController()
    {

    }
    /// <summary>
    /// Lấy 1 chuỗi các mã đơn vị con của một đơn vị
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public List<string> getChildID(string maDonVi, bool includeItSelf)
    {
        List<string> rs = (from t in dataContext.DM_DONVIs
                           where t.PARENT_ID == maDonVi
                           select t.MA_DONVI).ToList();
        List<string> result = new List<string>();
        getChildID(rs, ref result);
        result.AddRange(rs);
        if (includeItSelf)
        {
            result.Add(maDonVi);
        }
        return result;
    }

    private void getChildID(List<string> idList, ref List<string> result)
    {
        foreach (string item in idList)
        {
            List<string> rs = dataContext.DM_DONVIs.Where(t => t.PARENT_ID == item).Select(t => t.MA_DONVI).ToList();
            if (rs.Count > 0)
            {
                result.AddRange(rs);
                getChildID(rs, ref result);
            }
        }
    }

    /// <summary>
    /// Đức anh lấy ra 1 cây tổng quát
    /// </summary>
    /// <param name="idList"></param>
    /// <param name="result"></param> 
    public void LayCon(List<string> idList, ref List<DonViInfo> result, int a)
    {
        foreach (string item in idList)
        {
            List<DonViInfo> rs = (from t in dataContext.DM_DONVIs
                                  where t.MA_DONVI == item
                                  orderby t.ORDER
                                  select new DonViInfo
                                  {
                                      MaDonVi = t.MA_DONVI,
                                      TenDonVi = t.TEN_DONVI,
                                      ParentID = t.PARENT_ID,
                                      Level = a
                                  }).ToList();
            if (rs.Count > 0)
            {
                DeQuy(rs, ref result, a + 1);
            }
        }
    }

    public void DeQuy(List<DonViInfo> list, ref List<DonViInfo> result, int a)
    {
        foreach (var item in list)
        {
            result.Add(item);
            List<DonViInfo> rs = (from t in dataContext.DM_DONVIs
                                  where t.PARENT_ID == item.MaDonVi
                                  select new DonViInfo
                                  {
                                      MaDonVi = t.MA_DONVI,
                                      TenDonVi = new string('→', a - 1) + t.TEN_DONVI,
                                      ParentID = t.PARENT_ID,
                                      Level = a
                                  }).ToList();
            if (rs.Count > 0)
            {
                DeQuy(rs, ref result, a + 1);
            }
        }
    }
    // het phan lay cay cua duc anh


    public void UpdateOrder(string maDV, int order)
    {
        DAL.DM_DONVI dv = dataContext.DM_DONVIs.SingleOrDefault(t => t.MA_DONVI == maDV);
        if (dv != null)
        {
            dv.ORDER = order;
            Save();
        }
    }

    /// <summary>
    /// Lấy danh sách các mã bộ phận con của một bộ phận
    /// </summary>
    /// <param name="node">Mã của bộ phận cần lấy</param>
    /// <returns>Danh sách mã các bộ phận cách nhau bởi dấu phẩy</returns>
    public string GetAllMaDonVi(string node)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(node);
        string strMa = string.Empty;
        foreach (var info in lists)
        {
            strMa += info.MA + ",";
            strMa = GetChildMaBoPhan(strMa, info.MA);
        }
        strMa += node + ",";
        if (strMa.LastIndexOf(',') != -1)
            strMa = strMa.Remove(strMa.LastIndexOf(',')).Trim();
        return strMa;
    }
    public string GetDanhSachBoPhan(int userID, int menuID)
    {
        string strMa = string.Empty;
        var data = DataController.DataHandler.GetInstance().ExecuteScalar("Select MA_DONVI FROM f_GetDanhSachBoPhan(" + userID + ", " + menuID + ")");
        if (data!= null)
        {
            strMa = data.ToString();
        }
        return strMa;
    }
    private string GetChildMaBoPhan(string oldStr, string parentID)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            oldStr += item.MA + ",";
            oldStr = GetChildMaBoPhan(oldStr, item.MA);
        }
        return oldStr;
    }

    public List<DM_DONVI> GetAll()
    {
        return dataContext.DM_DONVIs.ToList();
    }

    public List<DM_DONVI> GetByDS(string dsDonVi)
    {
        string[] lists = dsDonVi.Split(',');
        var rs = from t in dataContext.DM_DONVIs
                 where lists.Contains(t.MA_DONVI)
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_DONVIs
                 select new StoreComboObject
                 {
                     MA = t.MA_DONVI,
                     TEN = t.TEN_DONVI
                 };
        return rs.ToList();
    }

    public List<DM_DONVI> GetByAll(string searchKey, string parentID)
    {
        var rs = (from t in dataContext.DM_DONVIs
                  where (t.PARENT_ID == parentID || parentID == "")
                     && (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_DONVI, searchKey) ||
                         System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_DONVI_EN, searchKey) ||
                         System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_TAT, searchKey))
                  select t).OrderBy(p => p.ORDER);
        return rs.ToList();
    }

    public DM_DONVI GetById(string MaDonVi)
    {
        var rs = (from t in dataContext.DM_DONVIs
                  where t.MA_DONVI == MaDonVi
                  select t).FirstOrDefault();
        return rs;
    }

    public string GetNameById(string maDonVi)
    {
        var rs = (from t in dataContext.DM_DONVIs
                  where t.MA_DONVI == maDonVi
                  select t.TEN_DONVI).FirstOrDefault();
        return rs;
    }

    public List<DAL.DM_DONVI> GetByParentID(string parentID)
    {
        var rs = from t in dataContext.DM_DONVIs
                 where t.PARENT_ID == parentID
                 select t;
        return rs.OrderBy(t => t.ORDER).ToList();
    }

    public List<StoreComboObject> GetStoreByParentID(string parentID)
    {
        var rs = (from t in dataContext.DM_DONVIs
                  where t.PARENT_ID == parentID
                  orderby t.ORDER ascending
                  select new StoreComboObject
                  {
                      MA = t.MA_DONVI,
                      TEN = t.TEN_DONVI
                  });
        return rs.ToList();
    }

    public List<DonViInfo> GetEntityByParentID(string parentID)
    {
        var rs = from t in dataContext.DM_DONVIs
                 where t.PARENT_ID == parentID
                 orderby t.ORDER ascending
                 select new DonViInfo
                 {
                     MaDonVi = t.MA_DONVI,
                     TenDonVi = t.TEN_DONVI
                 };
        return rs.ToList();
    }

    /// <summary>
    /// Kiểm tra xem user này đã có trong bảng DONVI_user chưa
    /// @Lê Anh
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public bool UserIsInAnyDepartments(int userID)
    {
        return dataContext.DONVI_Users.Where(t => t.UserID == userID).Count() > 0;
    }

    public void AddUserIntoDonVi(string MaDonVi, int userID)
    {
        dataContext.DONVI_Users.InsertOnSubmit(new DAL.DONVI_User()
        {
            DonViID = MaDonVi,
            UserID = userID
        });
        Save();
    }
    /// <summary>
    /// Sửa lại mã đơn vị cho user
    /// @Lê Anh
    /// </summary>
    /// <param name="MaDonVi"></param>
    /// <param name="userID"></param>
    public void UpdateUserIntoDonVi(string MaDonVi, int userID)
    {
        bool hasItem = false;
        foreach (var item in dataContext.DONVI_Users.Where(t => t.UserID == userID))
        {
            hasItem = true;
            if (item != null)
            {
                item.DonViID = MaDonVi;
                Save();
            }
        }
        if (!hasItem)
        {
            AddUserIntoDonVi(MaDonVi, userID);
        }
    }

    public void Insert(DAL.DM_DONVI dv)
    {
        if (dv != null)
        {
            dataContext.DM_DONVIs.InsertOnSubmit(dv);
            Save();
        }
    }

    public void Update(DAL.DM_DONVI dv)
    {
        DAL.DM_DONVI tmp = dataContext.DM_DONVIs.SingleOrDefault(t => t.MA_DONVI == dv.MA_DONVI);
        if (tmp != null)
        {
            tmp.DATE_CREATE = dv.DATE_CREATE;
            tmp.DIA_CHI = dv.DIA_CHI;
            tmp.DIEN_THOAI = dv.DIEN_THOAI;
            tmp.FAX = dv.FAX;
            tmp.GIAM_DOC = dv.GIAM_DOC;
            tmp.KE_TOAN_TRUONG = dv.KE_TOAN_TRUONG;
            tmp.MA_SO_THUE = dv.MA_SO_THUE;
            tmp.NGAN_HANG = dv.NGAN_HANG;
            tmp.ORDER = dv.ORDER;
            tmp.PARENT_ID = dv.PARENT_ID;
            tmp.SO_TAI_KHOAN = dv.SO_TAI_KHOAN;
            tmp.TEN_DONVI = dv.TEN_DONVI;
            tmp.TEN_DONVI_EN = dv.TEN_DONVI_EN;
            tmp.TEN_TAT = dv.TEN_TAT;
            tmp.USERNAME = dv.USERNAME;

            Save();
        }
    }

    public void Delete(string maDV)
    {
        DAL.DM_DONVI dv = dataContext.DM_DONVIs.SingleOrDefault(t => t.MA_DONVI == maDV);
        if (dv != null)
        {
            dataContext.DM_DONVIs.DeleteOnSubmit(dv);
            Save();
        }
    }

    /// <summary>
    /// chuyển 1 chuỗi dạng "01,001,002.." về "đơn vị 1,phòng A,phòng B.."
    /// </summary>
    /// <param name="stringma"></param>
    /// <returns></returns>
    public string ChuyenTuChuoiMaDonViVeTenDonVi(string stringma)
    {
        var listma = (from t in dataContext.DM_DONVIs
                      select new
                      {
                          t.MA_DONVI,
                          t.TEN_DONVI
                      }).ToList();
        var dr = listma.ToDictionary(item => item.MA_DONVI, item => item.TEN_DONVI);
        string result = stringma.Split(',').Aggregate("", (current, item) => current + dr[item] + ",");
        return result.Remove(result.LastIndexOf(','));
    }
    /// <summary>
    /// trả về directionary đơn vị (mã đơn vị, tên đơn vị)
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> TraVeTuDienDonVi()
    {
        var listma = (from t in dataContext.DM_DONVIs
                      select new
                      {
                          t.MA_DONVI,
                          t.TEN_DONVI
                      }).ToList();
        return listma.ToDictionary(item => item.MA_DONVI, item => item.TEN_DONVI);
    }

    /// <summary>
    /// Lấy tất cả các mã đơn vị
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllMaDonVi()
    {
        return (from t in dataContext.DM_DONVIs
                select t.MA_DONVI).ToList();
    }
    public void GetCombobox(ref Ext.Net.ComboBox combobox)
    {
        combobox.DisplayField = "TEN_DONVI";
        combobox.ValueField = "MA_DONVI";
        combobox.EnableViewState = false;
        string storeName = "store" + combobox.ID;
        Ext.Net.Store store = new CommonUtil().GetStore(storeName, "~/Modules/Base/ComboHandler.ashx", "DM_DONVI", "MA_DONVI", "TEN_DONVI");
        combobox.Store.Add(store);
        combobox.Listeners.Expand.Handler += "if(" + storeName + ".getCount()==0){" + storeName + ".reload();}";
    }
}