using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for BangTinhCheDoBaoHiemController
/// </summary>
public class BangTinhCheDoBaoHiemController : LinqProvider
{
    public BangTinhCheDoBaoHiemController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DAL.BHBANGTINHCHEDOBAOHIEM GetByPrKey(int prkey)
    {
        var rs = from t in dataContext.BHBANGTINHCHEDOBAOHIEMs
                 where t.IDBangTinhCheDoBaoHiem == prkey
                 select t;
        return rs.FirstOrDefault();
    }
    public void Delete(int prekey)
    {
        dataContext.BHBANGTINHCHEDOBAOHIEMs.DeleteOnSubmit(dataContext.BHBANGTINHCHEDOBAOHIEMs.Where(p => p.IDBangTinhCheDoBaoHiem == prekey).SingleOrDefault());
        Save();
    }
    public void Insert(DAL.BHBANGTINHCHEDOBAOHIEM item)
    {
        dataContext.BHBANGTINHCHEDOBAOHIEMs.InsertOnSubmit(item);
        Save();
    }
    public void Update(DAL.BHBANGTINHCHEDOBAOHIEM item)
    {
        DAL.BHBANGTINHCHEDOBAOHIEM tmp = dataContext.BHBANGTINHCHEDOBAOHIEMs.SingleOrDefault(p => p.IDBangTinhCheDoBaoHiem == item.IDBangTinhCheDoBaoHiem);
        tmp.IDCheDoBaoHiem = item.IDCheDoBaoHiem;
        tmp.MaDieuKienHuong = item.MaDieuKienHuong;
        tmp.TenDieuKienHuong = item.TenDieuKienHuong;
        tmp.DKThoiGianToiDaHuongCheDo = item.DKThoiGianToiDaHuongCheDo;
        tmp.DKThoiGianDongBH = item.DKThoiGianDongBH;
        tmp.CongThuc = item.CongThuc;
        tmp.YeuCauThuTuc = item.YeuCauThuTuc;
        tmp.DienGiai = item.DienGiai;
        dataContext.SubmitChanges();
        Save();
    }
    public void UpdatCDBH(DAL.BHBANGTINHCHEDOBAOHIEM item)
    {
        DAL.BHBANGTINHCHEDOBAOHIEM bh = dataContext.BHBANGTINHCHEDOBAOHIEMs.Where(t => t.IDBangTinhCheDoBaoHiem == item.IDBangTinhCheDoBaoHiem).FirstOrDefault();
        bh.IDCheDoBaoHiem = item.IDCheDoBaoHiem;
        bh.MaDieuKienHuong = item.MaDieuKienHuong;
        bh.TenDieuKienHuong = item.TenDieuKienHuong;
        bh.DKThoiGianToiDaHuongCheDo = item.DKThoiGianToiDaHuongCheDo;
        bh.DKThoiGianDongBH = item.DKThoiGianDongBH;
        bh.CongThuc = item.CongThuc;
        bh.YeuCauThuTuc = item.YeuCauThuTuc;
        bh.DienGiai = item.DienGiai;
        Save();
    }
    public List<DAL.BHBANGTINHCHEDOBAOHIEM> GetAll(string MaDonVi, out int count)
    {
        DM_DONVI dv = new DM_DONVIController().GetById(MaDonVi);
        List<BHBANGTINHCHEDOBAOHIEM> rs = (from t in dataContext.BHBANGTINHCHEDOBAOHIEMs
                                           where t.MaDonVi.Equals(MaDonVi)
                                           select t).ToList();
        count = rs.Count();
        return rs;
    }
    public DataTable GetAllRecord(int start, int limit, string searchKey, string maDonVi, out int count)
    {
        count = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("CountBangTinhCheDoBaoHiem", "@searchKey", "@MaDonVi", searchKey, maDonVi).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GETALL_BANGTINHCHEDOBAOHIEM", "@start", "@limit", "@searchKey", "@MaDonVi", start, limit, searchKey, maDonVi);
    }
    public List<DAL.BHBANGTINHCHEDOBAOHIEM> GetByIDCheDoNghi(string MaDonVi, out int count, int IDCheDoNghi)
    {
        var rs = (from t in dataContext.BHBANGTINHCHEDOBAOHIEMs
                  where t.IDCheDoBaoHiem == IDCheDoNghi
                  orderby t.TenDieuKienHuong
                  select t).ToList();
        count = rs.Count;
        return rs;
    }

}
