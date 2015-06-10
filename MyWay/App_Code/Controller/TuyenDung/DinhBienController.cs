using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using DataController;
using Ext.Net;
using SoftCore.Security;
using DAL;
using ExtMessage;
using System.Xml.Xsl;
using System.Xml;


/// <summary>
/// Summary description for DinhBienController
/// </summary>
public class DinhBienNhanSuController : LinqProvider
{

    public List<DAL.DinhBienNhanSu> GetAll()
    {

        return dataContext.DinhBienNhanSus.OrderBy(t => t.MaDonVi).ToList();

    }

    public void UpdateColumnValue(int id, string column, int value)
    {

        DataController.DataHandler.GetInstance().ExecuteNonQuery("[dbo].[UpdateColumnDinhBienNhanSu]", new string[] { "@Id", "@Column", "@Value" }, id, column, value);
    }

    public List<DAL.DinhBienNhanSu> GetByYearAndSearchKey(int year, string searchKey, ref int count)
    { 
        //IEnumerable<DAL.DinhBienNhanSu> dbns = dataContext.DinhBienNhanSus.Where(t => (t.Nam == year || year == 0) && (t.TenChucVu.Contains(searchKey) || t.TenCongViec.Contains(searchKey) || searchKey == "")).OrderBy(t => t.DM_DONVI.ORDER);
        //foreach (var nhanSu in dbns)
        //{
        //    if (!string.IsNullOrEmpty(nhanSu.MaCongViec))
        //        nhanSu.TenCongViec = nhanSu.DM_CONGVIEC.TEN_CONGVIEC;
        //    else
        //    {
        //        nhanSu.TenCongViec = string.Empty;
        //    }
        //    if (!string.IsNullOrEmpty(nhanSu.MaChucVu))
        //        nhanSu.TenChucVu = nhanSu.DM_CHUCVU.TEN_CHUCVU;
        //    else
        //    {
        //        nhanSu.TenChucVu = string.Empty;
        //    }
        //    if (!string.IsNullOrEmpty(nhanSu.MaDonVi))
        //        nhanSu.TenDonVi = nhanSu.DM_DONVI.TEN_DONVI;
        //    else
        //    {
        //        nhanSu.TenDonVi = string.Empty;
        //    }
        //}
        //return dbns.OrderBy(t => t.DM_DONVI.ORDER).ToList();
        return new List<DAL.DinhBienNhanSu>();
    }

    private DinhBienNhanSuInfo DinhBienNhanSuToDinhBienNhanSuInfo(DAL.DinhBienNhanSu dbns)
    {
        var re = new DinhBienNhanSuInfo();
        re.ID = dbns.ID;
        re.Nam = dbns.Nam;
        re.Thang1 = dbns.Thang1;
        re.Thang2 = dbns.Thang2;
        re.Thang3 = dbns.Thang3;
        re.Thang4 = dbns.Thang4;
        re.Thang5 = dbns.Thang5;
        re.Thang6 = dbns.Thang6;
        re.Thang7 = dbns.Thang7;
        re.Thang8 = dbns.Thang8;
        re.Thang9 = dbns.Thang9;
        re.Thang10 = dbns.Thang10;
        re.Thang11 = dbns.Thang11;
        re.Thang12 = dbns.Thang12;
        re.MaDonVi = dbns.MaDonVi;
        re.MaChucVu = dbns.MaChucVu ?? string.Empty;
        re.MaCongViec = dbns.MaCongViec ?? string.Empty;
        re.MaHopDong = dbns.MaHopDong ?? string.Empty;
        re.TenDonVi = dbns.DM_DONVI.TEN_DONVI ?? string.Empty;
        if (!string.IsNullOrEmpty(re.MaChucVu))
            re.TenChucVu = dbns.DM_CHUCVU.TEN_CHUCVU ?? string.Empty;
        if (!string.IsNullOrEmpty(re.MaCongViec))
            re.TenCongViec = dbns.DM_CONGVIEC.TEN_CONGVIEC ?? string.Empty;
        re.SoLuongNhanSu = dbns.SoLuongNhanSu ?? 0;
        re.SoLuongDinhBien = dbns.SoLuongDinhBien ?? 0;
        re.SoLuongTuyenMoi = dbns.SoLuongTuyenMoi ?? 0;
        re.CreatedDate = dbns.CreatedDate;
        re.CreatedBy = dbns.CreatedBy;
        re.GhiChu = dbns.GhiChu;
        re.MaChucVu = dbns.MaChucVu;
        re.Order = dbns.DM_DONVI.ORDER;
        re.TinhDenNgay = dbns.TinhDenNgay;
        return re;
    }

    public List<DinhBienNhanSuInfo> GetByYearAndSearchKey(int year, string maDonVi, string searchKey, int start, int end, ref int count)
    {
        var maDonViList = new List<string>();
        if(!string.IsNullOrEmpty(maDonVi))
            maDonViList = new DM_DONVIController().getChildID(maDonVi, true);
        var dbns =
            dataContext.DinhBienNhanSus.Where(
                t =>
                (maDonVi == "" || maDonViList.Contains(t.MaDonVi)) && ( year == 0 || t.Nam == year) &&
                ((searchKey == "" || System.Data.Linq.SqlClient.SqlMethods.Like(t.DM_CHUCVU.TEN_CHUCVU, searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.DM_CONGVIEC.TEN_CONGVIEC, searchKey))
                )).OrderBy(t => t.DM_DONVI.ORDER);
        count = dbns.Count();
        var reTmp = dbns.Skip(start).Take(end);
        return reTmp.Select(nhanSu => DinhBienNhanSuToDinhBienNhanSuInfo(nhanSu)).ToList();
    }

    public void AddDinhBien(bool allDepartments, List<string> departmentCodeList, List<string> workCodeList, DateTime day, bool includeTV, int userId, DateTime createDate)
    {
        var hosoController = new HoSoController();
        if (departmentCodeList.Count() < 1)
            departmentCodeList = new DonViController().GetAllDepartments();

        if (workCodeList.Count() < 1)
            workCodeList = new DM_CONGVIECController().GetAllTenCongViec();
        foreach (var department in departmentCodeList)
        {
            foreach (var work in workCodeList)
            {
                //if (dataContext.DM_CONGVIECs.Any(t => t.MA_CONGVIEC.ToLower() == work.ToLower() && t.MA_DONVI.ToLower() == department.ToLower()))
                //{

                    IEnumerable<string> tmpList = dataContext.HOSOs.Where(t =>
                           t.MA_DONVI.ToLower() == department.ToLower() &&
                           t.MA_CONGVIEC.ToLower() == work.ToLower()).Select(t => t.MA_CHUCVU).Distinct();
                    foreach (var maChucVu in tmpList)
                    {
                        if (dataContext.DinhBienNhanSus.Any(t => t.MaDonVi.ToLower() == department.ToLower() && t.MaCongViec.ToLower() == work.ToLower() && t.MaChucVu.ToLower() == maChucVu.ToLower() && t.TinhDenNgay == day))
                            break;
                        var dbns = new DinhBienNhanSu();
                        dbns.MaDonVi = department;
                        dbns.MaCongViec = work;
                        dbns.MaChucVu = maChucVu;
                        dbns.Nam = day.Year;
                        dbns.TinhDenNgay = day;
                        dbns.CreatedBy = userId;
                        dbns.CreatedDate = createDate;
                        dbns.SoLuongNhanSu = hosoController.CountByDVAndDayAndTypeStaff(department, work, maChucVu, day, includeTV);
                        dataContext.DinhBienNhanSus.InsertOnSubmit(dbns);
                    }
                //}
            }
        }
        Save();
    }

    public int Add(DAL.DinhBienNhanSu dbns)
    {
        dataContext.DinhBienNhanSus.InsertOnSubmit(dbns);
        Save();
        return dbns.ID;
    }

    public int Edit(DAL.DinhBienNhanSu dbns)
    {
        dataContext.DinhBienNhanSus.Attach(dbns, true);
        Save();
        return dbns.ID;
    }

    public List<DAL.DM_DONVI> GetDonViList()
    {
        var rs = dataContext.DM_DONVIs;
        return rs.ToList();
    }

    public List<YearInfo> GetYearList()
    {

        var rs = dataContext.DinhBienNhanSus.OrderBy(t => t.Nam).Select(t => new YearInfo { Year = t.Nam }).Distinct();
        return rs.OrderByDescending(t => t.Year).ToList();
    }

}