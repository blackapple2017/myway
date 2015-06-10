
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BHTangGiamBHTrongThangController
/// </summary>
public class BHTangGiamBHTrongThangController : LinqProvider
{
    public BHTangGiamBHTrongThangController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DAL.BHTangGiamBHTrongThang GetByIDNVBHAndMonthYear(int idNVBH, int month, int year)
    {
        return dataContext.BHTangGiamBHTrongThangs.FirstOrDefault(t => t.IDNhanVien_BaoHiem == idNVBH && t.MonthYear.Value.Month == month
                && t.MonthYear.Value.Year == year);
    }

    public void Insert(DAL.BHTangGiamBHTrongThang tg)
    {
        if (tg != null)
        {
            dataContext.BHTangGiamBHTrongThangs.InsertOnSubmit(tg);
            Save();
        }
    }

    public void Delete(decimal id)
    {
        DAL.BHTangGiamBHTrongThang tg = dataContext.BHTangGiamBHTrongThangs.FirstOrDefault(t => t.ID == id);
        if (tg != null)
        {
            dataContext.BHTangGiamBHTrongThangs.DeleteOnSubmit(tg);
            Save();
        }
    }

    public List<TangGiamBHTrongThangInfo> getAllInMonth(int start, int limit, int month, int year, string searchKey, string maDonVi, int userID, int menuID, out int count)
    {
        // lấy các bộ phận được quyền thao tác dữ liệu
        string[] dsdv = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(',');
        string[] dsselected = new DM_DONVIController().GetAllMaDonVi(maDonVi).Split(',');

        var rs = (from t in dataContext.BHTangGiamBHTrongThangs
                  join hs in dataContext.BHNHANVIEN_BAOHIEMs on t.IDNhanVien_BaoHiem equals hs.IDNhanVien_BaoHiem into hs1
                  from hs2 in hs1.DefaultIfEmpty()
                  join hstmp in dataContext.HOSOs on hs2.IDNhanVien_BaoHiem equals hstmp.PR_KEY into hstemp
                  from h in hstemp.DefaultIfEmpty()
                  join bp in dataContext.DM_DONVIs on h.MA_DONVI equals bp.MA_DONVI into dv1
                  from dv in dv1.DefaultIfEmpty()
                  join cv1 in dataContext.DM_CHUCVUs on hs2.MaChucVu equals cv1.MA_CHUCVU into cv2
                  from cv in cv2.DefaultIfEmpty()
                  where (System.Data.Linq.SqlClient.SqlMethods.Like(hs2.HoTen, searchKey) ||
                        System.Data.Linq.SqlClient.SqlMethods.Like(hs2.MaNhanVien, searchKey) || searchKey.Length == 0)
                        && (t.MonthYear.Value.Month == month) && (t.MonthYear.Value.Year == year)
                        && dsdv.Contains(h.MA_DONVI)
                        && (string.IsNullOrEmpty(maDonVi) || dsselected.Contains(h.MA_DONVI))
                  select new TangGiamBHTrongThangInfo
                  {
                      ID = t.ID,
                      IDNhanVien_BaoHiem = t.IDNhanVien_BaoHiem,
                      MaNhanVien = hs2.MaNhanVien,
                      TenBoPhan = dv.TEN_DONVI,
                      TenChucVu = cv.TEN_CHUCVU,
                      HoTen = hs2.HoTen,
                      LuongBaoHiem = hs2.LuongBaoHiem,
                      Plus = t.Plus,
                      Minus = t.Minus,
                      Notes = t.Notes
                  }).ToList();
        count = rs.Count;
        return rs.Skip(start).Take(limit).ToList();
    }

    public void UpdateTangGiam(int id, string field, string newValue, int month, int year)
    {
        if (field == "Notes")
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("BaoHiem_UpdateTangGiamText", "@ID", "@Field", "@Value", "@Month", "@Year",
                    id, field, newValue, month, year);
        }
        else
        {
            decimal value = decimal.Parse("0" + newValue);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("BaoHiem_UpdateTangGiam", "@ID", "@Field", "@Value", "@Month", "@Year",
                    id, field, value, month, year);
        }
    }
}