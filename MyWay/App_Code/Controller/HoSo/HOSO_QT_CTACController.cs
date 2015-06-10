using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for HOSO_QT_CTACController
/// </summary>
public class HOSO_QT_CTACController : LinqProvider
{
    public HOSO_QT_CTACController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<HOSO_QT_CTAC> GetElementByFr_key(decimal Fr_key)
    {
        var ct = (from t in dataContext.HOSO_QT_CTACs
                  where t.FR_KEY == Fr_key
                  select t);
        return ct.ToList();

    }

    public HOSO_QT_CTAC GetById(decimal Pr_key)
    {
        return dataContext.HOSO_QT_CTACs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }

    public List<HOSO_QT_CTACInfo> GetByFrkey(decimal frkey)
    {
        var rs = from t in dataContext.HOSO_QT_CTACs
                 join n in dataContext.DM_NUOCs on t.MaQuocGia equals n.MA_NUOC into tmp1
                 join hs in dataContext.HOSOs on t.PrkeyNguoiQuyetDinh equals hs.PR_KEY into tmp2
                 from p1 in tmp1.DefaultIfEmpty()
                 from p2 in tmp2.DefaultIfEmpty()
                 where t.FR_KEY == frkey
                 select new HOSO_QT_CTACInfo()
                 {
                     PR_KEY = t.PR_KEY,
                     FR_KEY = t.FR_KEY,
                     GhiChu = t.GHI_CHU,
                     NgayBatDau = t.ThoiGianBatDau,
                     NgayKetThuc = t.ThoiGianKetThuc,
                     NgayQuyetDinh = t.NgayQuyetDinh,
                     SoQuyetDinh = t.SoQuyetDinh,
                     TenNuoc = p1.TEN_NUOC,
                     DiaDiemCongTac = t.DiaDiemCongTac,
                     TepTinDinhKem = t.TepTinDinhKem,
                     TEN_NGUOI_QD = p2.HO_TEN,
                     NoiDungCongViec = t.NoiDungCongViec,
                 };
        return rs.ToList();
    }

    public List<HOSO_QT_CTACInfo> GetByprKeyTuCapNhat(decimal prKeyTuCapNhat)
    {
        var rs = from t in dataContext.HOSO_QT_CTACs
                 join n in dataContext.DM_NUOCs on t.MaQuocGia equals n.MA_NUOC into tmp1
                 join hs in dataContext.HOSOs on t.PrkeyNguoiQuyetDinh equals hs.PR_KEY into tmp2
                 from p1 in tmp1.DefaultIfEmpty()
                 from p2 in tmp2.DefaultIfEmpty()
                 where t.PrKeyHoSoTuCapNhat == prKeyTuCapNhat
                 select new HOSO_QT_CTACInfo()
                 {
                     PR_KEY = t.PR_KEY,
                     FR_KEY = t.FR_KEY,
                     GhiChu = t.GHI_CHU,
                     NgayBatDau = t.ThoiGianBatDau,
                     NgayKetThuc = t.ThoiGianKetThuc,
                     NgayQuyetDinh = t.NgayQuyetDinh,
                     SoQuyetDinh = t.SoQuyetDinh,
                     TenNuoc = p1.TEN_NUOC,
                     DiaDiemCongTac = t.DiaDiemCongTac,
                     TepTinDinhKem = t.TepTinDinhKem,
                     TEN_NGUOI_QD = p2.HO_TEN,
                     NoiDungCongViec = t.NoiDungCongViec
                 };
        return rs.ToList();
    }

    public void InsertQuaTrinhCongTac(HOSO_QT_CTAC qtcongTac)
    {
        dataContext.HOSO_QT_CTACs.InsertOnSubmit(qtcongTac);
        Save();
    }

    public DAL.HOSO_QT_CTAC GetQuaTrinhCongTac(decimal Pr_key)
    {
        return dataContext.HOSO_QT_CTACs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }

    public void UpdateQuaTrinhCongTac(DAL.HOSO_QT_CTAC hsqtct)
    {
        DAL.HOSO_QT_CTAC quatrinhcongtac = GetQuaTrinhCongTac(hsqtct.PR_KEY);
        if (quatrinhcongtac != null)
        {
            quatrinhcongtac.NgayQuyetDinh = hsqtct.NgayQuyetDinh;
            quatrinhcongtac.SoQuyetDinh = hsqtct.SoQuyetDinh;
            quatrinhcongtac.TepTinDinhKem = hsqtct.TepTinDinhKem;
            quatrinhcongtac.PrkeyNguoiQuyetDinh = hsqtct.PrkeyNguoiQuyetDinh;
            quatrinhcongtac.NgayQuyetDinh = hsqtct.NgayQuyetDinh;
            quatrinhcongtac.ThoiGianBatDau = hsqtct.ThoiGianBatDau;
            quatrinhcongtac.ThoiGianKetThuc = hsqtct.ThoiGianKetThuc;
            quatrinhcongtac.NoiDungCongViec = hsqtct.NoiDungCongViec;
            quatrinhcongtac.NguoiLienQuan = hsqtct.NguoiLienQuan;
            quatrinhcongtac.MaQuocGia = hsqtct.MaQuocGia;
            quatrinhcongtac.GHI_CHU = hsqtct.GHI_CHU;
            quatrinhcongtac.PrKeyHoSoTuCapNhat = hsqtct.PrKeyHoSoTuCapNhat;
            quatrinhcongtac.DiaDiemCongTac = hsqtct.DiaDiemCongTac;
            Save();
        }
    }
    /// <summary>
    /// Hàm xóa dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="pkKey"></param>
    public void Delete(decimal prKey)
    {
        DAL.HOSO_QT_CTAC existing = dataContext.HOSO_QT_CTACs.Where(t => t.PR_KEY == prKey).FirstOrDefault();
        if (existing.FR_KEY <= 0)
        {
            dataContext.HOSO_QT_CTACs.DeleteOnSubmit(existing);
            Save();
        }
        else
        {
            existing.PrKeyHoSoTuCapNhat = -1;
            Save();
        }
    }

    /// <summary>
    /// Hàm update dành cho form tự cập nhật
    /// </summary>
    /// <param name="obj"></param>
    public void Update(DAL.HOSO_QT_CTAC obj)
    {
        DAL.HOSO_QT_CTAC item = dataContext.HOSO_QT_CTACs.Where(t => t.PR_KEY == obj.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_QT_CTAC newObject = new DAL.HOSO_QT_CTAC()
            {
                PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                DiaDiemCongTac = obj.DiaDiemCongTac,
                MaQuocGia = obj.MaQuocGia,
                PrkeyNguoiQuyetDinh = obj.PrkeyNguoiQuyetDinh,
                SoQuyetDinh = obj.SoQuyetDinh,
                ThoiGianKetThuc = obj.ThoiGianKetThuc,
                ThoiGianBatDau = obj.ThoiGianBatDau,
                NoiDungCongViec = obj.NoiDungCongViec,
                NguoiLienQuan = obj.NguoiLienQuan,
                NgayQuyetDinh = obj.NgayQuyetDinh,
                GHI_CHU = obj.GHI_CHU,
            };
            if (!string.IsNullOrEmpty(obj.TepTinDinhKem))
            {
                newObject.TepTinDinhKem = obj.TepTinDinhKem;
            }
            dataContext.HOSO_QT_CTACs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat;
            item.FR_KEY = -1;
            item.DiaDiemCongTac = obj.DiaDiemCongTac;
            item.MaQuocGia = obj.MaQuocGia;
            item.PrkeyNguoiQuyetDinh = obj.PrkeyNguoiQuyetDinh;
            item.SoQuyetDinh = obj.SoQuyetDinh;
            item.ThoiGianKetThuc = obj.ThoiGianKetThuc;
            item.ThoiGianBatDau = obj.ThoiGianBatDau;
            item.TepTinDinhKem = obj.TepTinDinhKem;
            item.NoiDungCongViec = obj.NoiDungCongViec;
            item.NguoiLienQuan = obj.NguoiLienQuan;
            item.NgayQuyetDinh = obj.NgayQuyetDinh;
            item.GHI_CHU = obj.GHI_CHU;
            Save();
        }
    }
}