using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for ChamCongThangController
/// </summary>
public class ChamCongThangController : LinqProvider
{
    public ChamCongThangController()
    {
    }
    public void DeleteItemFromBangChamCongExcelTheoThang(int pr_key)
    {
        DAL.BangChamCongExcelTheoThang blcc = dataContext.BangChamCongExcelTheoThangs.Where(t => t.PR_KEY == pr_key).FirstOrDefault();
        dataContext.BangChamCongExcelTheoThangs.DeleteOnSubmit(blcc);
        Save();
    }
    public List<BangChamCongExcelTheoThang> GetByIdBangChamCong(int idBangChamCong, int start, int limit)
    {
        var rs = (from t in dataContext.BangChamCongExcelTheoThangs
                  where t.IdBangChamCong == idBangChamCong
                  select t).Skip(start).Take(limit);
        return rs.ToList();
    }

    /// <summary>
    /// Lấy dữ liệu để hiển thị lên trên Grid
    /// </summary>
    /// <param name="idBangChamCong">Khóa chính của bảng DM_BANGCHAMCONGTHANG</param>
    /// <param name="Keyword"></param>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public IEnumerable<BangChamCongThangInfo> GetDataForGrid(int idBangChamCong, string Keyword, int start, int limit, out int count)
    {
        string ma = Keyword.Replace("%", "");
        var rs = (from t in dataContext.BangChamCongExcelTheoThangs
                  join hs2 in dataContext.HOSOs on t.PRKEYHOSO equals hs2.PR_KEY into hs1
                  from hs in hs1.DefaultIfEmpty()
                  join dv2 in dataContext.DM_DONVIs on hs.MA_DONVI equals dv2.MA_DONVI into dv1
                  from dv in dv1.DefaultIfEmpty()
                  join np in dataContext.DanhSachNgayPheps on t.PRKEYHOSO equals np.PrKeyHoSo into np1
                  from np2 in np1.DefaultIfEmpty()
                  join nb in dataContext.QuanLyNghiBus on t.PRKEYHOSO equals nb.PrKeyHOSO into nb1
                  from nb2 in nb1.DefaultIfEmpty()
                  where t.IdBangChamCong == idBangChamCong &&
                 (System.Data.Linq.SqlClient.SqlMethods.Like(hs.HO_TEN, Keyword) || string.IsNullOrEmpty(Keyword) ||
                 System.Data.Linq.SqlClient.SqlMethods.Like(hs.MA_CB, ma))
                  orderby hs.TEN_CB ascending, hs.HO_CB ascending
                  select new BangChamCongThangInfo
                  {
                      Birthday = hs.NGAY_SINH,
                      DIEMPHAT = t.DIEM_PHAT,
                      DIEMTHUONG = t.DIEM_THUONG,
                      FullName = hs.HO_TEN,
                      BoPhan = dv.TEN_DONVI,
                      GHICHU = t.GHI_CHU,
                      NGAY01 = t.NGAY01,
                      NGAY02 = t.NGAY02,
                      NGAY03 = t.NGAY03,
                      NGAY04 = t.NGAY04,
                      NGAY05 = t.NGAY05,
                      NGAY06 = t.NGAY06,
                      NGAY07 = t.NGAY07,
                      NGAY08 = t.NGAY08,
                      NGAY09 = t.NGAY09,
                      NGAY10 = t.NGAY10,

                      NGAY11 = t.NGAY11,
                      NGAY12 = t.NGAY12,
                      NGAY13 = t.NGAY13,
                      NGAY14 = t.NGAY14,
                      NGAY15 = t.NGAY15,
                      NGAY16 = t.NGAY16,
                      NGAY17 = t.NGAY17,
                      NGAY18 = t.NGAY18,
                      NGAY19 = t.NGAY19,
                      NGAY20 = t.NGAY20,

                      NGAY21 = t.NGAY21,
                      NGAY22 = t.NGAY22,
                      NGAY23 = t.NGAY23,
                      NGAY24 = t.NGAY24,
                      NGAY25 = t.NGAY25,
                      NGAY26 = t.NGAY26,
                      NGAY27 = t.NGAY27,
                      NGAY28 = t.NGAY28,
                      NGAY29 = t.NGAY29,
                      NGAY30 = t.NGAY30,
                      NGAY31 = t.NGAY31,
                      IdBangChamCong = t.IdBangChamCong,
                      PRKEY = t.PR_KEY,
                      MACB = hs.MA_CB,
                      TONG_CONG = t.TONG_CONG,
                      HL = t.HL,
                      KL = t.KL,
                      Phep = t.Phep,
                      BHXH = t.BHXH,
                      HLTV = t.HLTV,
                      NB = t.NB,
                      NBConLai = (nb2.TangT1+nb2.TangT3+nb2.TangT4+nb2.TangT5+nb2.TangT6+nb2.TangT7+nb2.TangT8+nb2.TangT9+nb2.TangT10+nb2.TangT11+nb2.TangT12) -(nb2.GiamT1+nb2.GiamT3+nb2.GiamT4+nb2.GiamT5+nb2.GiamT6+nb2.GiamT7+nb2.GiamT8+nb2.GiamT9+nb2.GiamT10+nb2.GiamT11+nb2.GiamT12),
                      SoPhepCon = ((np2.ThoiHanSuDungNgayPhepNamTruoc.HasValue && np2.ThoiHanSuDungNgayPhepNamTruoc < DateTime.Now) ? 0 : np2.SoNgayPhepNamTruoc) + np2.SoNgayPhepNamNay + np2.SoNgayPhepDuocThem - (np2.Thang1 + np2.Thang2 + np2.Thang3 + np2.Thang4 + np2.Thang5 + np2.Thang6 + np2.Thang7 + np2.Thang8 + np2.Thang9 + np2.Thang10 + np2.Thang11 + np2.Thang12)
                  });
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }
    public BangChamCongExcelTheoThang GetByID(int PrKey)
    {
        return dataContext.BangChamCongExcelTheoThangs.Where(t => t.PR_KEY == PrKey).FirstOrDefault();
    }

    /// <summary>
    /// Cập nhật thông tin chấm công từ file excel
    /// </summary>
    /// <param name="update"></param>
    public bool UpdateFromExcel(BangChamCongThangInfo info)
    {
        DAL.BangChamCongExcelTheoThang obj = null;// getBangChamCongByMACB(info.MACB, info.IdBangChamCong);
        if (obj != null)
        {
            obj.NGAY01 = info.NGAY01;
            obj.NGAY02 = info.NGAY02;
            obj.NGAY03 = info.NGAY03;
            obj.NGAY04 = info.NGAY04;
            obj.NGAY05 = info.NGAY05;
            obj.NGAY06 = info.NGAY06;
            obj.NGAY07 = info.NGAY07;
            obj.NGAY08 = info.NGAY08;
            obj.NGAY09 = info.NGAY09;
            obj.NGAY10 = info.NGAY10;

            obj.NGAY11 = info.NGAY11;
            obj.NGAY12 = info.NGAY12;
            obj.NGAY13 = info.NGAY13;
            obj.NGAY14 = info.NGAY14;
            obj.NGAY15 = info.NGAY15;
            obj.NGAY16 = info.NGAY16;
            obj.NGAY17 = info.NGAY17;
            obj.NGAY18 = info.NGAY18;
            obj.NGAY19 = info.NGAY19;
            obj.NGAY20 = info.NGAY20;

            obj.NGAY21 = info.NGAY21;
            obj.NGAY22 = info.NGAY22;
            obj.NGAY23 = info.NGAY23;
            obj.NGAY24 = info.NGAY24;
            obj.NGAY25 = info.NGAY25;
            obj.NGAY26 = info.NGAY26;
            obj.NGAY27 = info.NGAY27;
            obj.NGAY28 = info.NGAY28;
            obj.NGAY29 = info.NGAY29;
            obj.NGAY30 = info.NGAY30;
            obj.NGAY31 = info.NGAY31;

            Save();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Cập nhật thông tin chấm công
    /// </summary>
    /// <param name="update"></param>
    public void Update(BangChamCongThangInfo update)
    {
        DAL.BangChamCongExcelTheoThang obj = GetByID(update.PRKEY);
        obj.NGAY01 = update.NGAY01;
        obj.NGAY02 = update.NGAY02;
        obj.NGAY03 = update.NGAY03;
        obj.NGAY04 = update.NGAY04;
        obj.NGAY05 = update.NGAY05;
        obj.NGAY06 = update.NGAY06;
        obj.NGAY07 = update.NGAY07;
        obj.NGAY08 = update.NGAY08;
        obj.NGAY09 = update.NGAY09;
        obj.NGAY10 = update.NGAY10;
        obj.NGAY11 = update.NGAY11;
        obj.NGAY12 = update.NGAY12;
        obj.NGAY13 = update.NGAY13;
        obj.NGAY14 = update.NGAY14;
        obj.NGAY15 = update.NGAY15;
        obj.NGAY16 = update.NGAY16;
        obj.NGAY17 = update.NGAY17;
        obj.NGAY18 = update.NGAY18;
        obj.NGAY19 = update.NGAY19;
        obj.NGAY20 = update.NGAY20;
        obj.NGAY21 = update.NGAY21;

        obj.NGAY22 = update.NGAY22;
        obj.NGAY23 = update.NGAY23;
        obj.NGAY24 = update.NGAY24;

        obj.NGAY25 = update.NGAY25;
        obj.NGAY26 = update.NGAY26;
        obj.NGAY27 = update.NGAY27;
        obj.NGAY28 = update.NGAY28;
        obj.NGAY29 = update.NGAY29;
        obj.NGAY30 = update.NGAY30;
        obj.NGAY31 = update.NGAY31;
        // Save();
        dataContext.SubmitChanges();
    }

}


