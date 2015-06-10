using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CongThucKhoanSanXuatControler
/// </summary>
public class CongThucKhoanSanXuatControler : LinqProvider
{
    public CongThucKhoanSanXuatControler()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DAL.CongThucKhoanSanXuat GetCongThucByPrKey(int prkey)
    {
        return dataContext.CongThucKhoanSanXuats.SingleOrDefault(p => p.PRKEY == prkey);
    }

    public DAL.CongThucKhoanSanXuat GetByMaBoPhanVaSanLuong(string maBoPhan, decimal sanLuong)
    {
        var rs = from t in dataContext.CongThucKhoanSanXuats
                 where t.MaDonVi == maBoPhan && t.DKSanLuongTu <= sanLuong && sanLuong <= t.DKSanLuongDen
                 select t;
        return rs.FirstOrDefault();
    }

    public List<DAL.CongThucKhoanSanXuat> GetAll()
    {
        //var rs = from t in dataContext.CongThucKhoanSanXuats
        //         select t;
        //return rs.ToList();
        return null;
    }
    public void Insert(DAL.CongThucKhoanSanXuat item)
    {
        dataContext.CongThucKhoanSanXuats.InsertOnSubmit(item);
        Save();
    }

    public void Update(DAL.CongThucKhoanSanXuat congthuc)
    {
        var item = dataContext.CongThucKhoanSanXuats.SingleOrDefault(p => p.PRKEY == congthuc.PRKEY);
        item.CongThuc = congthuc.CongThuc;
        item.DKSanLuongDen = congthuc.DKSanLuongDen;
        item.DKSanLuongTu = congthuc.DKSanLuongTu;
        item.GhiChu = congthuc.GhiChu; 
        item.TenCongThuc = congthuc.TenCongThuc;
        item.TrongSo = congthuc.TrongSo;
        item.MaDonVi = congthuc.MaDonVi;
        Save();
    }
}