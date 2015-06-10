using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CHUVUController
/// </summary>
public class DanhMucChucVuController : LinqProvider
{
	public DanhMucChucVuController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Lấy mã chức vụ dựa vào tên chức vụ
    /// </summary>
    /// <param name="TenChucVu"></param>
    /// <returns></returns>
    public string GetPrimaryKeyByName(string TenChucVu)
    {
        var rs = from t in dataContext.DM_CHUCVUs
                 where t.TEN_CHUCVU.Equals(TenChucVu)
                 select t.MA_CHUCVU;
        return rs.FirstOrDefault();
    }
    public string GetNameByPrimaryKey(string MaChucVu)
    {
        var rs = from t in dataContext.DM_CHUCVUs
                 where t.MA_CHUCVU.Equals(MaChucVu)
                 select t.TEN_CHUCVU;
        return rs.FirstOrDefault();
    }


    public List<DAL.DM_CHUCVU> GetByAll()
    {
        var rs = from t in dataContext.DM_CHUCVUs
                 select t;
        return rs.ToList();
    }

    public List<StoreComboObject> GetAll()
    {
        var rs = from t in dataContext.DM_CHUCVUs
                 select new StoreComboObject
                 {
                     MA = t.MA_CHUCVU,
                     TEN = t.TEN_CHUCVU
                 };
        return rs.OrderBy(t => t.TEN).ToList();
    }

    // Khởi get chức vụ theo mã đơn vị
    public List<DM_ChucVuInfo> GetAllByMaDonVi(string madonvi)
    {
        var rs = from t in dataContext.DM_CHUCVUs
                 where t.MA_DONVI.Equals(madonvi)
                 select new DM_ChucVuInfo
                 {
                     MA_CHUCVU = t.MA_CHUCVU,
                     TEN_CHUCVU = t.TEN_CHUCVU
                 };
        return rs.ToList();

    }
}