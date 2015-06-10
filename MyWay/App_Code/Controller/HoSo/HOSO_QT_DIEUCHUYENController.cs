using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for HOSO_QT_DIEUCHUYENController
/// </summary>
public class HOSO_QT_DIEUCHUYENController : LinqProvider
{
    public HOSO_QT_DIEUCHUYENController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<HOSO_QT_DIEUCHUYENInfo1> GetByFr_Key(decimal FR_KEY)
    {
        var rs = from t in dataContext.HOSO_QT_DIEUCHUYENs
                 join dm_dv in dataContext.DM_DONVIs on t.MaBoPhanCu equals dm_dv.MA_DONVI into tmp1
                 join dm_p in dataContext.DM_DONVIs on t.MaBoPhanMoi equals dm_p.MA_DONVI into tmp2
                 join dm_cv in dataContext.DM_CHUCVUs on t.MaChucVuCu equals dm_cv.MA_CHUCVU into tmp3
                 join dm_n in dataContext.DM_CHUCVUs on t.MaChucVuMoi equals dm_n.MA_CHUCVU into tmp4
                 join dm_cvieccu in dataContext.DM_CONGVIECs on t.MaCongViecCu equals dm_cvieccu.MA_CONGVIEC into tmp6
                 join dm_cviecmoi in dataContext.DM_CONGVIECs on t.MaCongViecMoi equals dm_cviecmoi.MA_CONGVIEC into tmp7
                 join hs in dataContext.HOSOs on t.PrkeyNguoiQuyetDinh equals hs.PR_KEY into tmp5
                 where t.FR_KEY == FR_KEY

                 from t1 in tmp1.DefaultIfEmpty()
                 from t2 in tmp2.DefaultIfEmpty()
                 from t3 in tmp3.DefaultIfEmpty()
                 from t4 in tmp4.DefaultIfEmpty()
                 from t5 in tmp5.DefaultIfEmpty()
                 from t6 in tmp6.DefaultIfEmpty()
                 from t7 in tmp7.DefaultIfEmpty()
                 select new HOSO_QT_DIEUCHUYENInfo1()
                 {
                     PR_KEY = t.PR_KEY,
                     FR_KEY = t.FR_KEY,
                     SoQuyetDinh = t.SoQuyetDinh,
                     TenNguoiQuyetDinh = t5.HO_TEN,
                     NgayQuyetDinh = t.NgayQuyetDinh,
                     NgayCoHieuLuc = t.NgayCoHieuLuc,
                     NgayHetHieuLuc = t.NgayHetHieuLuc,
                     TenBoPhanCu = t1.TEN_DONVI,
                     TenBoPhanMoi = t2.TEN_DONVI,
                     TenChucVuCu = t3.TEN_CHUCVU,
                     TenChucVuMoi = t4.TEN_CHUCVU,
                     TenCongViecCu = t6.TEN_CONGVIEC,
                     TenCongViecMoi = t7.TEN_CONGVIEC,
                     TepTinDinhKem = t.TepTinDinhKem,
                     GhiChu = t.GhiChu,
                 };
        return rs.ToList();
    }
    /// <summary>
    /// Lấy thông tin cho form tự cập nhật
    /// </summary>
    /// <param name="prKeyTuCapNhat"></param>
    /// <returns></returns>
    public List<HOSO_QT_DIEUCHUYENInfo1> GetByPrKeyTuCapNhat(decimal prKeyTuCapNhat)
    {
        var rs = from t in dataContext.HOSO_QT_DIEUCHUYENs
                 join dm_dv in dataContext.DM_DONVIs on t.MaBoPhanCu equals dm_dv.MA_DONVI into tmp1
                 join dm_p in dataContext.DM_DONVIs on t.MaBoPhanMoi equals dm_p.MA_DONVI into tmp2
                 join dm_cv in dataContext.DM_CHUCVUs on t.MaChucVuCu equals dm_cv.MA_CHUCVU into tmp3
                 join dm_n in dataContext.DM_CHUCVUs on t.MaChucVuMoi equals dm_n.MA_CHUCVU into tmp4
                 join hs in dataContext.HOSOs on t.PrkeyNguoiQuyetDinh equals hs.PR_KEY into tmp5
                 where t.PrKeyHosoTuCapNhat == prKeyTuCapNhat

                 from t1 in tmp1.DefaultIfEmpty()
                 from t2 in tmp2.DefaultIfEmpty()
                 from t3 in tmp3.DefaultIfEmpty()
                 from t4 in tmp4.DefaultIfEmpty()
                 from t5 in tmp5.DefaultIfEmpty()
                 select new HOSO_QT_DIEUCHUYENInfo1()
                 {
                     PR_KEY = t.PR_KEY,
                     FR_KEY = t.FR_KEY,
                     SoQuyetDinh = t.SoQuyetDinh,
                     TenNguoiQuyetDinh = t5.HO_TEN,
                     NgayQuyetDinh = t.NgayQuyetDinh,
                     NgayCoHieuLuc = t.NgayCoHieuLuc,
                     NgayHetHieuLuc = t.NgayHetHieuLuc,
                     TenBoPhanCu = t1.TEN_DONVI,
                     TenBoPhanMoi = t2.TEN_DONVI,
                     TenChucVuCu = t3.TEN_CHUCVU,
                     TenChucVuMoi = t4.TEN_CHUCVU,
                     TepTinDinhKem = t.TepTinDinhKem,
                     GhiChu = t.GhiChu,
                     TenCongViecCu = t.MaCongViecCu,
                     TenCongViecMoi = t.MaCongViecMoi,
                 };
        return rs.ToList();
    }

    public void Insert(DAL.HOSO_QT_DIEUCHUYEN qtdc)
    {
        dataContext.HOSO_QT_DIEUCHUYENs.InsertOnSubmit(qtdc);
        Save();
    }

    public DAL.HOSO_QT_DIEUCHUYEN GetQuaTrinhDieuChuyen(decimal Pr_key)
    {
        return dataContext.HOSO_QT_DIEUCHUYENs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }

    public void Update(DAL.HOSO_QT_DIEUCHUYEN hsqtdc)
    {
        DAL.HOSO_QT_DIEUCHUYEN quatrinhdieuchuyen = GetQuaTrinhDieuChuyen(hsqtdc.PR_KEY);
        if (quatrinhdieuchuyen != null)
        {
            quatrinhdieuchuyen.FR_KEY = hsqtdc.FR_KEY;
            quatrinhdieuchuyen.SoQuyetDinh = hsqtdc.SoQuyetDinh;
            quatrinhdieuchuyen.PrkeyNguoiQuyetDinh = hsqtdc.PrkeyNguoiQuyetDinh;
            quatrinhdieuchuyen.NgayQuyetDinh = hsqtdc.NgayQuyetDinh;
            quatrinhdieuchuyen.NgayCoHieuLuc = hsqtdc.NgayCoHieuLuc;
            quatrinhdieuchuyen.NgayHetHieuLuc = hsqtdc.NgayHetHieuLuc;
            //quatrinhdieuchuyen.MaBoPhanCu = hsqtdc.MaBoPhanCu;
            quatrinhdieuchuyen.MaBoPhanMoi = hsqtdc.MaBoPhanMoi;
            //quatrinhdieuchuyen.MaChucVuCu = hsqtdc.MaChucVuCu;
            quatrinhdieuchuyen.MaChucVuMoi = hsqtdc.MaChucVuMoi;
            quatrinhdieuchuyen.TepTinDinhKem = hsqtdc.TepTinDinhKem;
            quatrinhdieuchuyen.PrKeyHosoTuCapNhat = hsqtdc.PrKeyHosoTuCapNhat;
            quatrinhdieuchuyen.GhiChu = hsqtdc.GhiChu;
            quatrinhdieuchuyen.TepTinDinhKem = hsqtdc.TepTinDinhKem;
            Save();
        }
    }
    /// <summary>
    /// Hàm update dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="hsqtdc"></param>
    public void UpdateForTuCapNhat(DAL.HOSO_QT_DIEUCHUYEN updated)
    {
        DAL.HOSO_QT_DIEUCHUYEN item = dataContext.HOSO_QT_DIEUCHUYENs.Where(t => t.PR_KEY == updated.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHosoTuCapNhat > 0)
        {
            item.PrKeyHosoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_QT_DIEUCHUYEN newObject = new DAL.HOSO_QT_DIEUCHUYEN()
            {
                PrKeyHosoTuCapNhat = updated.PrKeyHosoTuCapNhat,
                FR_KEY = -1,
                GhiChu = updated.GhiChu,
                MaBoPhanCu = updated.MaBoPhanCu,
                MaChucVuCu = updated.MaChucVuCu,
                PrkeyNguoiQuyetDinh = updated.PrkeyNguoiQuyetDinh,
                NgayQuyetDinh = updated.NgayQuyetDinh,
                SoQuyetDinh = updated.SoQuyetDinh,
                TepTinDinhKem = updated.TepTinDinhKem,
                NgayHetHieuLuc = updated.NgayHetHieuLuc,
                NgayCoHieuLuc = updated.NgayCoHieuLuc,
                MaChucVuMoi = updated.MaChucVuMoi,
                MaBoPhanMoi = updated.MaBoPhanMoi,
            };
            dataContext.HOSO_QT_DIEUCHUYENs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHosoTuCapNhat = updated.PrKeyHosoTuCapNhat;
            item.FR_KEY = -1;
            item.GhiChu = updated.GhiChu;
            item.MaBoPhanCu = updated.MaBoPhanCu;
            item.MaChucVuCu = updated.MaChucVuCu;
            item.PrkeyNguoiQuyetDinh = updated.PrkeyNguoiQuyetDinh;
            item.NgayQuyetDinh = updated.NgayQuyetDinh;
            item.SoQuyetDinh = updated.SoQuyetDinh;
            item.TepTinDinhKem = updated.TepTinDinhKem;
            item.NgayHetHieuLuc = updated.NgayHetHieuLuc;
            item.NgayCoHieuLuc = updated.NgayCoHieuLuc;
            item.MaChucVuMoi = updated.MaChucVuMoi;
            item.MaBoPhanMoi = updated.MaBoPhanMoi;
            Save();
        }
    }

    /// <summary>
    /// Hàm xóa dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="prKey"></param>
    public void Delete(decimal prKey)
    {
        DAL.HOSO_QT_DIEUCHUYEN oldObject = dataContext.HOSO_QT_DIEUCHUYENs.Where(t => t.PR_KEY == prKey).FirstOrDefault();
        if (oldObject.FR_KEY <= 0)
        {
            dataContext.HOSO_QT_DIEUCHUYENs.DeleteOnSubmit(oldObject);
            Save();
        }
        else
        {
            oldObject.PrKeyHosoTuCapNhat = -1;
            Save();
        }
    }
}