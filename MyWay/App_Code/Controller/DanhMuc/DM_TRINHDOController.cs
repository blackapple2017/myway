using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DM_TRINHDOController
/// </summary>
public class DM_TRINHDOController : LinqProvider
{
    public DM_TRINHDOController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Lấy khóa chính dựa vào tên trình độ
    /// </summary>
    /// <param name="TenTrinhDo"></param>
    /// <returns></returns>
    public string GetPrimaryKeyByName(string TenTrinhDo)
    {
        var rs = from t in dataContext.DM_TRINHDOs
                 where t.TEN_TRINHDO.Equals(TenTrinhDo)
                 select t.MA_TRINHDO;
        return rs.FirstOrDefault();
    }
    public string GetNameByPrimaryKey(string MaTrinhDo)
    {
        var rs = from t in dataContext.DM_TRINHDOs
                 where t.MA_TRINHDO.Equals(MaTrinhDo)
                 select t.TEN_TRINHDO;
        return rs.FirstOrDefault();
    }
    public List<DAL.DM_TRINHDO> GetByAll()
    {
        var rs = from t in dataContext.DM_TRINHDOs
                 select t;
        return rs.ToList();

    }

    public List<DM_TRINHDOInfo> GetAll()
    {
        var rs = from t in dataContext.DM_TRINHDOs
                 select new DM_TRINHDOInfo
                 {
                     MA_TRINHDO = t.MA_TRINHDO,
                     TEN_TRINHDO = t.TEN_TRINHDO
                 };
        return rs.ToList();
    }
//chỉ lấy tên với mã
    public List<StoreComboObject> GetAll1()
    {
        var rs = from t in dataContext.DM_TRINHDOs
                 select new StoreComboObject
                 {
                     MA = t.MA_TRINHDO,
                     TEN = t.TEN_TRINHDO
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }
    // Khởi get trình độ theo mã đơn vị
    public List<DM_TRINHDO> GetAllByMaDonVi(string madonvi)
    {
        return dataContext.DM_TRINHDOs.Where(p => p.MA_DONVI == madonvi).OrderBy(p => p.MA_TRINHDO).ToList();

    }

    public DAL.DM_TRINHDO GetByMaTrinhDo(string matrinhdo)
    {
        return dataContext.DM_TRINHDOs.Where(p => p.MA_TRINHDO == matrinhdo).SingleOrDefault();
    }
    
    public void Insert(DAL.DM_TRINHDO trinhdo)
    {
        dataContext.DM_TRINHDOs.InsertOnSubmit(trinhdo);
        Save();
    }
    public void Update(DAL.DM_TRINHDO trinhdo)
    {
        var item = dataContext.DM_TRINHDOs.Where(p => p.MA_TRINHDO == trinhdo.MA_TRINHDO).SingleOrDefault();
        item.MA_TRINHDO = trinhdo.MA_TRINHDO;
        item.TEN_TRINHDO = trinhdo.TEN_TRINHDO;
        item.NhomTrinhDo = trinhdo.NhomTrinhDo;
        item.GHI_CHU = trinhdo.GHI_CHU;
        Save();
    }
}
