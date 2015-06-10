using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KHOA_DAOTAOController
/// </summary>
public class KHOA_DAOTAOController : LinqProvider
{
	public KHOA_DAOTAOController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<DAL.DM_CHUNGCHI> GetByAll()
    {
        var rs = from t in dataContext.DM_CHUNGCHIs

                 select t;
        return rs.ToList();

    }

    public IEnumerable<DonViInfo> SearchByName(int start, int limit, string name, out int count)
    {
        var rs = from t in dataContext.DM_DONVIs
                 where System.Data.Linq.SqlClient.SqlMethods.Like(t.TEN_DONVI, name)
                 orderby t.TEN_DONVI, t.MA_DONVI ascending
                 select new DonViInfo
                 {
                     MaDonVi = t.MA_DONVI,
                     TenDonVi = t.TEN_DONVI,
                    
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }

    public IEnumerable<DM_DOITACDAOTAOInfo> SearchByNameDoiTac(int start, int limit, string name, out int count)
    {
        var rs = from t in dataContext.DM_DOITACDAOTAOs
                 where System.Data.Linq.SqlClient.SqlMethods.Like(t.Ten, name)
                 orderby t.Ten, t.Ma ascending
                 select new DM_DOITACDAOTAOInfo
                 {
                     Ma = t.Ma,
                     Ten = t.Ten,

                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }

    public bool IsDuplicateMaKhoaDaoTao(string maKhoaDaoTao)
    {
        int c = dataContext.KHOA_DAOTAOs.Count(t => t.MA_KHOA == maKhoaDaoTao);
        return c > 0;
    }
    public void InsertKhoaDaoTao(DAL.KHOA_DAOTAO dt)
    {
        dataContext.KHOA_DAOTAOs.InsertOnSubmit(dt);
        Save();
    }
    public DAL.KHOA_DAOTAO GetKhoaDaoTaoByMaDaoTao(string MaDaoTao)
    {
        return dataContext.KHOA_DAOTAOs.FirstOrDefault(t => t.MA_KHOA == MaDaoTao);
    }
    public void UpdateKhoaDaoTao(DAL.KHOA_DAOTAO dt)
    {
        DAL.KHOA_DAOTAO khoadaotao = GetKhoaDaoTaoByMaDaoTao(dt.MA_KHOA);
        khoadaotao.MA_KHOA = dt.MA_KHOA;
        khoadaotao.TEN_KHOAHOC = dt.TEN_KHOAHOC;
        khoadaotao.ThoiGianDuKien = dt.ThoiGianDuKien;
        khoadaotao.CHIPHIDUKIEN = dt.CHIPHIDUKIEN;
        khoadaotao.MA_CHUNGCHI = dt.MA_CHUNGCHI;
        khoadaotao.CHIPHITHUCTE = dt.CHIPHITHUCTE;
        khoadaotao.SOLUONGHOCVIEN = dt.SOLUONGHOCVIEN;
        khoadaotao.DIA_DIEM_DAO_TAO = dt.DIA_DIEM_DAO_TAO;
        khoadaotao.NhanVienDong = dt.NhanVienDong;
        khoadaotao.CongTyHoTro = dt.CongTyHoTro;
        khoadaotao.MA_DONVI = dt.MA_DONVI;
        khoadaotao.CreatedUser = dt.CreatedUser;
        khoadaotao.IsNganHan = dt.IsNganHan;
        khoadaotao.MA_DONVIPHUTRACH = dt.MA_DONVIPHUTRACH;
        Save();

    }
}