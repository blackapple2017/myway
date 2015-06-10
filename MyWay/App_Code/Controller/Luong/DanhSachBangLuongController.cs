using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachBangLuongController
/// </summary>
public class DanhSachBangLuongController : LinqProvider
{
    public DanhSachBangLuongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Lấy danh sách bảng lương theo MenuID
    /// @daibx
    /// </summary>
    /// <param name="sessionDepartment">Mã đơn vị đang đăng nhập</param>
    /// <param name="menuID">MenuID đang click</param>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public List<DanhSachBangLuongInfo> GetByMenuID(string sessionDepartment, int menuID, int start, int limit, out int count)
    {
        List<string> dsDonVi = new DM_DONVIController().getChildID(sessionDepartment, true);
        var rs = from t in dataContext.DanhSachBangLuongs
                 join temp1 in dataContext.Users on t.CreatedBy equals temp1.ID into tmp1
                 from tp1 in tmp1.DefaultIfEmpty()
                 where dsDonVi.Contains(t.SessionDepartment) && t.MenuID == menuID
                 orderby t.CreatedDate descending
                 select new DanhSachBangLuongInfo
                 {
                     CreatedBy = tp1 != null ? tp1.DisplayName : "",
                     CreatedDate = t.CreatedDate,
                     ID = t.ID,
                     Month = t.Month,
                     Year = t.Year,
                     Title = t.Title,
                     DaKhoa = t.DaKhoa,
                     Description = t.Description
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit).ToList();
    }

    public List<DanhSachBangLuongInfo> GetAll(string madonvi, int start, int limit, out int count)
    {
        List<string> limadonvi = new DM_DONVIController().getChildID(madonvi,true);
        var result = (from t in dataContext.DanhSachBangLuongs
                      join q in dataContext.Users on t.CreatedBy equals q.ID into tq
                      from x in tq.DefaultIfEmpty()
                      where limadonvi.Contains(t.MA_DONVI)
                      orderby t.Year descending, t.Month descending
                      select new DanhSachBangLuongInfo
                      {
                          CreatedBy = x != null ? x.DisplayName : "",
                          CreatedDate = t.CreatedDate,
                          ID = t.ID,
                          Month = t.Month,
                          Title = t.Title,
                          Year = t.Year
                      }).ToList();
        count = result.Count;
        return result.Skip(start).Take(limit).ToList();
    }
    public DAL.DanhSachBangLuong GetByID(int id)
    {
        return dataContext.DanhSachBangLuongs.Where(p => p.ID == id).FirstOrDefault();
    }
    public int Insert(DAL.DanhSachBangLuong danhsach)
    {
        dataContext.DanhSachBangLuongs.InsertOnSubmit(danhsach);
        Save();
        int id = danhsach.ID;
        return id;
    }
    public void Update(DAL.DanhSachBangLuong danhsach)
    {
        var item = dataContext.DanhSachBangLuongs.Where(p => p.ID == danhsach.ID).FirstOrDefault();
        item.Title = danhsach.Title;
        item.Description = danhsach.Description;
        Save();
    } 
    /// <summary>
    /// Lấy bảng lương mới nhất
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public DAL.DanhSachBangLuong GetLastest(string maDonVi)
    {
        return dataContext.DanhSachBangLuongs.OrderByDescending(t => t.Year).OrderByDescending(t => t.Month).FirstOrDefault(t => t.MA_DONVI == maDonVi);
    }

    /// <summary>
    /// Lấy danh sách tất cả bảng lương của 1 cán bộ
    /// </summary>
    /// <param name="maCB"></param>
    /// <returns></returns>
    public IEnumerable<DanhSachBangLuongInfo> GetSalaryListOfEmployee(string maCB, int start, int limit, out int count)
    {
        var rs = from t in dataContext.DanhSachBangLuongs
                 orderby t.Year
                 orderby t.Month
                 where t.BangThanhToanLuongs.Where(s => s.MaCB == maCB).Count() > 0
                 select new DanhSachBangLuongInfo
                 {
                     Title = t.Title,
                     Month = t.Month,
                     Year = t.Year,
                     ID = t.ID
                 };
        count = rs.Count();
        return rs;
    }
    public bool Delete(int id)
    {
        bool isLock = false;
        DAL.DanhSachBangLuong bangLuong = dataContext.DanhSachBangLuongs.SingleOrDefault(t => t.ID == id);
        if (bangLuong != null && bangLuong.DaKhoa == false)
        {
            dataContext.DanhSachBangLuongs.DeleteOnSubmit(bangLuong);
            Save();
        }
        else
            isLock = true;
        return isLock;
    }
    public bool CheckTrungThangNam(string madonvi, int thang, int nam, int menuID)
    {
        var item = dataContext.DanhSachBangLuongs.Where(p =>p.MA_DONVI==madonvi&& p.Month == thang && p.Year == nam && p.MenuID==menuID).FirstOrDefault();
        if (item != null)
            return true;
        else return false;
    }

    public void LockBangLuong(int idBangLuong, bool locked)
    {
        DAL.DanhSachBangLuong bangLuong = dataContext.DanhSachBangLuongs.SingleOrDefault(t => t.ID == idBangLuong);
        if (bangLuong != null)
        {
            bangLuong.DaKhoa = locked;
            Save();
        }
    }
}