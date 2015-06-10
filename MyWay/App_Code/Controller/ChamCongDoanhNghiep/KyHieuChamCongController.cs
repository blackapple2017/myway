using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DM_TT_LAMVIECController
/// </summary>
public class KyHieuChamCongController : LinqProvider
{
    public KyHieuChamCongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<DM_TT_LAMVIEC> GetAll()
    {
        return dataContext.DM_TT_LAMVIECs.Where(t => t.IS_IN_USED).OrderBy(t => t.STT).ToList();
    }
    public List<TinhTrangLamViecInfo> GetTinhTrangLamViec(bool isInUsed)
    {
        var rs = from t in dataContext.DM_TT_LAMVIECs
                 where t.IS_IN_USED == isInUsed
                 select new TinhTrangLamViecInfo
                 {
                     Ma = t.KYHIEU_TT_LAMVIEC,
                     Ten = t.QUI_UOC_CHAM_CONG
                 };
        return rs.ToList();
    }
    public DM_TT_LAMVIEC GetByName(string Name)
    {
        return dataContext.DM_TT_LAMVIECs.Where(t => t.TEN_TT_LAMVIEC.Equals(Name)).FirstOrDefault();
    }

    public DM_TT_LAMVIEC GetByQuyUocChamCong(string quyUoc)
    {
        return dataContext.DM_TT_LAMVIECs.Where(t => t.QUI_UOC_CHAM_CONG.Equals(quyUoc)).FirstOrDefault();
    }

    public DAL.DM_TT_LAMVIEC GetbyPrKey(int id)
    {
        return dataContext.DM_TT_LAMVIECs.Where(t => t.PR_KEY == id).FirstOrDefault();
    }

    public void Update(DM_TT_LAMVIEC obj)
    {
        DAL.DM_TT_LAMVIEC update = GetbyPrKey(obj.PR_KEY);
        if (update != null)
        {
            update.IS_IN_USED = obj.IS_IN_USED;
            update.DIEN_GIAI = obj.DIEN_GIAI;
            update.CREATED_USER = obj.CREATED_USER;
            update.DATE_CREATE = obj.DATE_CREATE;
            update.KYHIEU_TT_LAMVIEC = obj.KYHIEU_TT_LAMVIEC;
            update.QUI_UOC_CHAM_CONG = obj.QUI_UOC_CHAM_CONG;
            update.STT = obj.STT;
            update.TEN_TT_LAMVIEC = obj.TEN_TT_LAMVIEC;
            update.SoCongHuongLuong = obj.SoCongHuongLuong;
            update.NhomKyHieu = obj.NhomKyHieu;
            Save();
        }
    }

    public int Insert(DM_TT_LAMVIEC obj)
    {
        dataContext.DM_TT_LAMVIECs.InsertOnSubmit(obj);
        Save();
        return obj.PR_KEY;
    }

    public void DeleteByPrkey(int pr_key)
    {
        DAL.DM_TT_LAMVIEC deleted = GetbyPrKey(pr_key);
        dataContext.DM_TT_LAMVIECs.DeleteOnSubmit(deleted);
        Save();
    }

    public IEnumerable<DAL.DM_TT_LAMVIEC> GetAllRecord(int Start, int Limit, string SearchKey, string MaDonVi, out int Count)
    {
        var rs = (from t in dataContext.DM_TT_LAMVIECs
                 where (string.IsNullOrEmpty(SearchKey) 
                 || System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_TT_LAMVIEC, SearchKey) ||
                 System.Data.Linq.SqlClient.SqlMethods.Like(t.DIEN_GIAI, SearchKey))// && t.MA_DONVI == MaDonVi
                 select t).OrderBy(t=>t.STT);
        Count = rs.Count();
        return rs.Skip(Start).Take(Limit);
    }
    /// <summary>
    /// Kiểm tra xem có trùng kí hiệu chấm công không
    /// </summary>
    /// <param name="kiHieu"></param>
    /// <param name="maDonVi"></param>
    /// <returns>true nếu trùng kí hiệu</returns>
    public bool CheckDuplicateSignal(string kiHieu, string maDonVi)
    {
        return dataContext.DM_TT_LAMVIECs.Where(t => t.KYHIEU_TT_LAMVIEC == kiHieu && t.MA_DONVI == maDonVi).Count() > 0;
    }

    #region Ký hiệu chấm công
    public string NghiPhep { get { return "P"; } }
    public string NghiKhongLuong { get { return "KL"; } }
    public string CheDo { get { return "CD"; } }
    public string NghiBu { get { return "NB"; } }
    public string NghiLe { get { return "L"; } }
    #endregion
}