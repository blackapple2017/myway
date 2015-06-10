using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_VTHHController
/// </summary>
public class DM_VTHHController : LinqProvider
{
    public DM_VTHHController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<DAL.DM_NHOM_VTHH> GetFortuneGroupByParentID(string parentID)
    {
        var rs = from t in dataContext.DM_NHOM_VTHHs
                 where t.PARENTID == parentID
                 orderby t.ORDER
                 select t;
        return rs.ToList();
    }

    /// <summary>
    /// Lấy danh sách vật tư hàng hóa
    /// </summary>
    /// <returns></returns>
    public List<DM_VTHHInfo> GetAll()
    {

        var rs = from t in dataContext.DM_VTHHs
                 select new DM_VTHHInfo
                 {
                     MA_VTHH = t.MA_VTHH,
                     TEN_VTHH = t.TEN_VTHH
                 };
        return rs.ToList();
    }

    public List<DM_VTHHInfo> GetAll(int start, int limit, out int count, string searchKey, string groupID)
    {
        string groupIDList = "";
        if (!string.IsNullOrEmpty(groupID) && groupID != "-1")
        {
            groupIDList = "," + groupID + "," +
                          CommonUtil.GetInstance().GetChildIDListFromParentID("DM_NHOM_VTHH", groupID, "MA_NHOM_VTHH", "PARENTID");
        }
        var rs = from t in dataContext.DM_VTHHs
                 join g in dataContext.DM_NHOM_VTHHs
                 on t.MA_NHOM_VTHH equals g.MA_NHOM_VTHH into j1
                 from j2 in j1.DefaultIfEmpty()
                 join dvt in dataContext.DM_DVTs
                 on t.MA_DONVITINH equals dvt.MA_DVT into dvt1
                 from dvt2 in dvt1.DefaultIfEmpty()
                 where (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_VTHH, searchKey)
                        || System.Data.Linq.SqlClient.SqlMethods.Like(t.MA_VTHH, searchKey)) &&
                        (string.IsNullOrEmpty(groupID) || groupID == "-1" || System.Data.Linq.SqlClient.SqlMethods.Like(groupIDList, "%," + t.MA_NHOM_VTHH + ",%"))
                 select new DM_VTHHInfo
                 {
                     MA_VTHH = t.MA_VTHH,
                     TEN_VTHH = t.TEN_VTHH,
                     GhiChu = t.GHI_CHU,
                     NhomVTHH = j2.TEN_NHOM_VTHH,
                     DVT = dvt2.TEN_DVT,
                     NguyenGia = t.NGUYEN_GIA,
                     SoThangKH = t.SOTHANG_KHAUHAO
                 };
        count = rs.Count();
        return rs.ToList();
    }

    public DAL.DM_VTHH GetByID(string Id)
    {
        return dataContext.DM_VTHHs.Where(t => t.MA_VTHH == Id).FirstOrDefault();
    }

    //Có truyền thêm mã đơn vị
    public List<DM_VTHHInfo> GetAll(string madonvi)
    {
        var rs = from t in dataContext.DM_VTHHs
                 where t.MA_DONVI == madonvi
                 select new DM_VTHHInfo
                 {
                     MA_VTHH = t.MA_VTHH,
                     TEN_VTHH = t.TEN_VTHH
                 };
        return rs.ToList();
    }

}