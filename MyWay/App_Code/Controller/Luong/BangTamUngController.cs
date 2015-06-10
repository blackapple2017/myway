using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangTamUngController
/// </summary>
public class BangTamUngController : LinqProvider
{
    public BangTamUngController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DAL.BangTamUng GetByPrKey(int prkey)
    {
        return dataContext.BangTamUngs.Where(p => p.PR_KEY == prkey).FirstOrDefault();
    }
    public void Insert(DAL.BangTamUng tamung)
    {
        dataContext.BangTamUngs.InsertOnSubmit(tamung);
        Save();
    }
    public void Update(DAL.BangTamUng tamung)
    {
        var item = dataContext.BangTamUngs.Where(p => p.PR_KEY == tamung.PR_KEY).FirstOrDefault();
        //item.SoTienDaTra = tamung.SoTienDaTra;
        item.LyDoTamUng = tamung.LyDoTamUng;
        item.NgayTamUng = tamung.NgayTamUng;
        item.SoTien = tamung.SoTien;
        item.SoTienVietBangChu = tamung.SoTienVietBangChu;
        //item.ThoiHanThanhToan = tamung.ThoiHanThanhToan;
        item.TepTinDinhKem = tamung.TepTinDinhKem;
        Save();
    }
    /// <summary>
    /// Lấy danh sách công nợ dựa vào prkeyHoso
    /// </summary>
    /// <param name="prKeyHoSo"></param>
    /// <returns></returns>
    public IEnumerable<BangTamUngInfo> GetByPrKeyHoSo(decimal prKeyHoSo)
    {
        var rs = from t in dataContext.BangTamUngs
                 where t.PrKeyHoSo == prKeyHoSo
                 select new BangTamUngInfo
                 {
                     GhiChu = t.GhiChu,
                     ID = t.PR_KEY,
                     LyDoTamUng = t.LyDoTamUng,
                     SoTien = t.SoTien,
                     SoTienDaTra = t.SoTienDaTra,
                     //NgayThanhToan = t.NgayThanhToan,
                     SoTienConLai = t.SoTien - t.SoTienDaTra,
                     DaThanhToanHet = t.SoTienDaTra == t.SoTien,
                     AttachFile = t.TepTinDinhKem
                 };
        return rs;
    }

    public void Delete(int ID)
    {
        DAL.BangTamUng existing = GetByPrKey(ID);
        if (existing != null)
        {
            dataContext.BangTamUngs.DeleteOnSubmit(existing);
            Save();
        }
    }

    public void UpdateThanhToanCongNo(BangTamUngInfo tmp)
    {
        DAL.BangTamUng existing = GetByPrKey(tmp.ID);
        if (existing != null)
        {
            existing.NgayThanhToan = tmp.NgayThanhToan;
            existing.GhiChu = tmp.GhiChu;
            existing.TepTinDinhKem = tmp.AttachFile;
            if (tmp.DaThanhToanHet)
                existing.SoTienDaTra = existing.SoTien;
            else
            {
                if (tmp.SoTienConLai != 0)
                {
                    existing.SoTienDaTra = existing.SoTien - tmp.SoTienConLai;
                }
                else
                    existing.SoTienDaTra = existing.SoTienDaTra + tmp.SoTienDaTra;
            }
            Save();
        }
    }
}