using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_CacKhoanChiChoTuyenDungController
/// </summary>
public class CacKhoanChiChoTuyenDungController:LinqProvider
{
	public CacKhoanChiChoTuyenDungController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    //public IEnumerable<CacKhoanChiPhiInfo> GetCacKhoanChiPhi(string maKeHoach)
    //{
    //    var rs = from t in dataContext.ChiPhiTuyenDungs
    //             where t.MaKeHoachTuyenDung == maKeHoach
    //             select new CacKhoanChiPhiInfo
    //             {
    //                 ID = t.ID,
    //                 MaKeHoach = t.MaKeHoachTuyenDung,
    //                 NguonChi = t.NguonChi,
    //                 SoTien = t.SoTien,
    //                 TenChiPhi = t.TenChiPhi,
    //                 NgayChi = t.NgayChi
    //             };
    //    return rs;
    //}

    //public List<CacKhoanChiPhiInfo> GetByFrkey(string fr_key)
    //{
    //    var rs = from t in dataContext.ChiPhiTuyenDungs
    //             where t.MaKeHoachTuyenDung == fr_key
    //             select new CacKhoanChiPhiInfo
    //             {
    //                 ID = t.ID,
    //                 MaKeHoach = t.MaKeHoachTuyenDung,
    //                 NguonChi = t.NguonChi,
    //                 SoTien = t.SoTien,
    //                 TenChiPhi = t.TenChiPhi,
    //                 NgayChi = t.NgayChi
    //             };
    //    return rs.ToList();
    //}

    //public decimal GetTongChiPhiKeHoachTuyenDung(string FR_KEY)
    //{
    //    var rs = (from t in dataContext.ChiPhiTuyenDungs
    //              where t.MaKeHoachTuyenDung == FR_KEY
    //              select new { t.SoTien}).ToList();
    //    var sum = rs.Select(c => c.SoTien).Sum();
    //    return sum;
    //}

    public DAL.ChiPhiTuyenDung GetChiPhiTuyenDungByID(int ID)
    {
        return dataContext.ChiPhiTuyenDungs.FirstOrDefault(t => t.ID == ID);
    }
    public void InsertChiphiTuyenDung(DAL.ChiPhiTuyenDung chiPhi)
    {
        dataContext.ChiPhiTuyenDungs.InsertOnSubmit(chiPhi);
        Save();
    }
    public void UpdateChiPhi(DAL.ChiPhiTuyenDung chiPhi)
    {
        DAL.ChiPhiTuyenDung d = GetChiPhiTuyenDungByID(chiPhi.ID);
        d.NguonChi = chiPhi.NguonChi;
        d.SoTien = chiPhi.SoTien;
        d.TenChiPhi = chiPhi.TenChiPhi;
        d.CreatedBy = chiPhi.CreatedBy;
        d.CreatedDate = chiPhi.CreatedDate;
        Save();
    }
    public void DeleteChiPhi(int ID)
    {
        DAL.ChiPhiTuyenDung chiPhi = dataContext.ChiPhiTuyenDungs.FirstOrDefault(t => t.ID == ID);
        dataContext.ChiPhiTuyenDungs.DeleteOnSubmit(chiPhi);
        Save();
    }
}