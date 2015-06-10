using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThietLapCaTheoBoPhanController
/// </summary>
public class ThietLapCaTheoBoPhanController : LinqProvider
{
    public ThietLapCaTheoBoPhanController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DAL.ThietLapCaTheoBoPhan GetThietLap(string maCanBo)
    {
        var rs = from t in dataContext.ThietLapCaTheoBoPhans
                 join hs in dataContext.HOSOs on t.MaDonVi equals hs.MA_DONVI into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where t1.MA_CB == maCanBo
                 select t;
        return rs.FirstOrDefault();
    }

    public double GetCongChuan(string maDonVi)
    {
        var rs = dataContext.ThietLapCaTheoBoPhans.FirstOrDefault(t => t.MaDonVi == maDonVi);
        if (rs != null)
            return rs.SoNgayCongChuan;
        return 1;
    }

    public DAL.ThietLapCaTheoBoPhan GetThietLapByMaChamCong(string maChamCong)
    {
        var rs = from t in dataContext.ThietLapCaTheoBoPhans
                 join hs in dataContext.HOSOs on t.MaDonVi equals hs.MA_DONVI into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where t1.ID_MAY_CHAMCONG == maChamCong
                 select t;
        return rs.FirstOrDefault();
    }

    public void LayCon(List<string> idList, ref List<DonViInfo> result, int a)
    {
        foreach (string item in idList)
        {
            List<DonViInfo> rs = (from t in dataContext.DM_DONVIs
                                  join c in dataContext.ThietLapCaTheoBoPhans on t.MA_DONVI equals c.MaDonVi into j1
                                  from j2 in j1.DefaultIfEmpty()
                                  where t.MA_DONVI == item
                                  select new DonViInfo
                                  {
                                      MaDonVi = t.MA_DONVI,
                                      TenDonVi = t.TEN_DONVI,
                                      ParentID = t.PARENT_ID,
                                      Level = a,
                                      MaCa = j2.MaCa,
                                      MaCaChuNhat = j2.MaCaChuNhat,
                                      MaCaThu7 = j2.MaCaThu7
                                      //SoNgayCongChuan = j2.SoNgayCongChuan
                                  }).ToList();
            if (rs.Count > 0)
            {
                DeQuy(rs, ref result, a + 1);
            }
        }
    }

    public void UpdateCa(DAL.ThietLapCaTheoBoPhan item)
    {
        try
        {
            DAL.ThietLapCaTheoBoPhan caBoPhan = dataContext.ThietLapCaTheoBoPhans.FirstOrDefault(t => t.MaDonVi == item.MaDonVi);
            if (caBoPhan != null)
            {
                caBoPhan.MaCa = item.MaCa;
                caBoPhan.MaCaThu7 = item.MaCaThu7;
                caBoPhan.MaCaChuNhat = item.MaCaChuNhat;
                caBoPhan.SoNgayCongChuan = item.SoNgayCongChuan;
                Save();
            }
            else
            {
                dataContext.ThietLapCaTheoBoPhans.InsertOnSubmit(item);
                Save();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void DeQuy(List<DonViInfo> list, ref List<DonViInfo> result, int a)
    {
        foreach (var item in list)
        {
            result.Add(item);
            List<DonViInfo> rs = (from t in dataContext.DM_DONVIs
                                  join c in dataContext.ThietLapCaTheoBoPhans on t.MA_DONVI equals c.MaDonVi into j1
                                  from j2 in j1.DefaultIfEmpty()
                                  where t.PARENT_ID == item.MaDonVi
                                  select new DonViInfo
                                  {
                                      MaDonVi = t.MA_DONVI,
                                      TenDonVi = new string('→', a - 1) + t.TEN_DONVI,
                                      ParentID = t.PARENT_ID,
                                      Level = a,
                                      MaCa = j2.MaCa,
                                      MaCaChuNhat = j2.MaCaChuNhat,
                                      MaCaThu7 = j2.MaCaThu7,
                                      SoNgayCongChuan = j2.SoNgayCongChuan
                                  }).ToList();
            if (rs.Count > 0)
            {
                DeQuy(rs, ref result, a + 1);
            }
        }
    }
}