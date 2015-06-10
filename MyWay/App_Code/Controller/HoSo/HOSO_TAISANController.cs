using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_TAISANController
/// </summary>
public class HOSO_TAISANController : LinqProvider
{
    public HOSO_TAISANController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<DAL.HOSO_TAISAN> GetByPrkeyCanBo(decimal prkey)
    {
        var rs = from t in dataContext.HOSO_TAISANs
                 where t.FR_KEY == prkey
                 select t;
        return rs.ToList();
    }

    public void Delete(decimal prKey)
    {
        DAL.HOSO_TAISAN obj = dataContext.HOSO_TAISANs.Where(t => t.PR_KEY == prKey).FirstOrDefault();
        if (obj.FR_KEY <= 0)
        {
            dataContext.HOSO_TAISANs.DeleteOnSubmit(obj);
            Save();
        }
        else
        {
            obj.PrKeyHoSoTuCapNhat = -1;
            Save();
        }
    }

    public void UpdateBanGiaoTaiSan(DAL.HOSO_TAISAN ts)
    {
        DAL.HOSO_TAISAN existing = dataContext.HOSO_TAISANs.Where(t => t.PR_KEY == ts.PR_KEY).FirstOrDefault();
        if (existing != null)
        {
            existing.NgayBanGiao = ts.NgayBanGiao;
            existing.GhiChuSauBanGiao = ts.GhiChuSauBanGiao;
            existing.TepTinDinhKem = ts.TepTinDinhKem;
            Save();
        }
    }

    public List<BanGiaoTaiSanInfo> GetTaiSanBanGiao(decimal prkeyHoSo)
    {
        var rs = from t in dataContext.HOSO_TAISANs
                 join vt in dataContext.DM_VTHHs on t.MA_VTHH equals vt.MA_VTHH into vt1
                 from vt2 in vt1.DefaultIfEmpty()
                 where t.FR_KEY == prkeyHoSo
                 select new BanGiaoTaiSanInfo
                 {
                     ID = t.PR_KEY,
                     GhiChu = t.GhiChuSauBanGiao,
                     MaTaiSan = t.MA_VTHH,
                     DonViTinh = t.DM_DVT.TEN_DVT,
                     NgayBanGiao = t.NgayBanGiao,
                     SoLuong = t.SoLuong,
                     TenTaiSan = vt2.TEN_VTHH,
                     TinhTrang = t.TINH_TRANG,
                     AttachFile = t.TepTinDinhKem,
                     DaBanGiao = !(t.NgayBanGiao == null || (t.NgayBanGiao.ToString().Contains("0001") || t.NgayBanGiao.ToString().Contains("1900"))),
                     
                 };
        return rs.ToList();
    }

    public void Update(DAL.HOSO_TAISAN obj)
    {
        DAL.HOSO_TAISAN item = dataContext.HOSO_TAISANs.Where(t => t.PR_KEY == obj.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_TAISAN newObject = new DAL.HOSO_TAISAN()
            {
                PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                SoLuong = obj.SoLuong,
                GHI_CHU = obj.GHI_CHU,
                MA_VTHH = obj.MA_VTHH,
                MaDonViTinh = obj.MaDonViTinh,
                NGAY_NHAN = obj.NGAY_NHAN,
                TINH_TRANG = obj.TINH_TRANG,
            };
            dataContext.HOSO_TAISANs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat;
            item.FR_KEY = -1;
            item.SoLuong = obj.SoLuong;
            item.GHI_CHU = obj.GHI_CHU;
            item.MA_VTHH = obj.MA_VTHH;
            item.MaDonViTinh = obj.MaDonViTinh;
            item.NGAY_NHAN = obj.NGAY_NHAN;
            item.TINH_TRANG = obj.TINH_TRANG;
            Save();
        }
    }

}