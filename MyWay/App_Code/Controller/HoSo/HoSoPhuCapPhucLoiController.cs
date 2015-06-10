using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoSoPhucLoiController
/// </summary>
public class HoSoPhuCapPhucLoiController : LinqProvider
{
    public HoSoPhuCapPhucLoiController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Add(DAL.HOSO_PHUCAP phuCap)
    { 
        dataContext.HOSO_PHUCAPs.InsertOnSubmit(phuCap);
        Save();
        var hsl = new HoSoLuongController().GetByID(phuCap.FrKeyHOSO_LUONG);
        var hoso = new HoSoController().GetByPrKey(hsl.PrKeyHoSo);
        new HoSoLuongController().UpDateLuongTheoQuyetDinhLuong(hoso.MA_CB);
    }

    public DAL.HOSO_PHUCAP GetByID(int id)
    {
        return dataContext.HOSO_PHUCAPs.Where(t => t.ID == id).FirstOrDefault();
    }

    /// <summary>
    /// Lấy phụ cấp đi kèm lương
    /// @Bùi Xuân Đại
    /// </summary>
    /// <param name="frkey_hosoluong">Khóa chính của bảng HOSO_LUONG</param>
    /// <returns></returns>
    public IEnumerable<HoSoPhuCapInfo> GetListPhuCap(decimal frkey_hosoluong)
    {
        var rs = from t in dataContext.HOSO_PHUCAPs
                 join temp in dataContext.DanhMucPhuCapPhucLois on t.MaPhuCap equals temp.ID into tmp
                 from pc in tmp.DefaultIfEmpty()
                 where t.FrKeyHOSO_LUONG == frkey_hosoluong
                 select new HoSoPhuCapInfo
                 {
                     HeSo = t.HeSo,
                     ID = t.ID,
                     MaPhuCap = t.MaPhuCap,
                     TenPhuCap = pc.Ten,
                     NgayHetHieuLuc = t.NgayHetHieuLuc,
                     NgayHieuLuc = t.NgayHieuLuc,
                     NgayQuyetDinh = t.NgayQuyetDinh,
                     NguoiQuyetDinh = t.HOSO.HO_TEN,
                     SoTien = t.SoTien,
                     PhanTram = t.PhanTram,
                     TrangThai = t.TrangThai,
                     PrkeyNguoiQuyetDinh = t.prKeyHoSoNguoiQuyetDinh,
                 };
        return rs.ToList();
    }

    public void Update(DAL.HOSO_PHUCAP phuCap)
    {
        DAL.HOSO_PHUCAP tmp = GetByID(phuCap.ID);
        tmp.HeSo = phuCap.HeSo;
        tmp.MaPhuCap = phuCap.MaPhuCap;
        tmp.NgayHetHieuLuc = phuCap.NgayHetHieuLuc;
        tmp.NgayHieuLuc = phuCap.NgayHieuLuc;
        tmp.NgayQuyetDinh = phuCap.NgayQuyetDinh;
        tmp.prKeyHoSoNguoiQuyetDinh = phuCap.prKeyHoSoNguoiQuyetDinh;
        tmp.SoTien = phuCap.SoTien;
        tmp.PhanTram = phuCap.PhanTram;
        tmp.TrangThai = phuCap.TrangThai;

        var hsl = new HoSoLuongController().GetByID(phuCap.FrKeyHOSO_LUONG);
        var hoso = new HoSoController().GetByPrKey(hsl.PrKeyHoSo);
        new HoSoLuongController().UpDateLuongTheoQuyetDinhLuong(hoso.MA_CB);

        Save();
    }

    public List<DAL.HOSO_PHUCAP> GetByMaPhuCap(int id, int maPhuCap, int maHoSoLuong)
    {
        var rs = from t in dataContext.HOSO_PHUCAPs
                 where t.MaPhuCap == maPhuCap && t.FrKeyHOSO_LUONG == maHoSoLuong
                    && t.ID != id
                 select t;
        return rs.ToList();
    }

    /// <summary>
    /// kết thúc hiệu lực các phụ cấp trùng lặp trước khi thêm mới phụ cấp
    /// </summary>
    /// <param name="hspc">phụ cấp mới được thêm</param>
    /// <returns></returns>
    public bool UpdateNgayHetHieuLucPhuCap(DAL.HOSO_PHUCAP hspc)
    {
        List<DAL.HOSO_PHUCAP> lists = GetByMaPhuCap(hspc.ID, hspc.MaPhuCap, hspc.FrKeyHOSO_LUONG);
        foreach (DAL.HOSO_PHUCAP item in lists)
        {
            if (SoftCore.Util.GetInstance().IsDateNull(item.NgayHetHieuLuc))
            {
                if (hspc.NgayHieuLuc <= item.NgayHieuLuc)
                    return false;
                DateTime hetHL = hspc.NgayHieuLuc.Value;
                hetHL = hetHL.AddDays(-1);
                if (hetHL < item.NgayHieuLuc)
                    hetHL = hspc.NgayHieuLuc.Value;
                item.NgayHetHieuLuc = hetHL;
                Update(item);
                var hsl = new HoSoLuongController().GetByID(hspc.FrKeyHOSO_LUONG);
                var hoso = new HoSoController().GetByPrKey(hsl.PrKeyHoSo);
                new HoSoLuongController().UpDateLuongTheoQuyetDinhLuong(hoso.MA_CB); 
            }
        }
        return true;
    }

    public void DeleteByID(int id)
    {
        var phucap = dataContext.HOSO_PHUCAPs.SingleOrDefault(t => t.ID == id);
        if (phucap != null)
        {
          
            dataContext.HOSO_PHUCAPs.DeleteOnSubmit(phucap);
            Save();
            var hsl = new HoSoLuongController().GetByID(phucap.FrKeyHOSO_LUONG);
            var hoso = new HoSoController().GetByPrKey(hsl.PrKeyHoSo);
            new HoSoLuongController().UpDateLuongTheoQuyetDinhLuong(hoso.MA_CB); 
        }
    }

    public void DeleteByPrkeyHoSoLuong(int prkeyHoSoLuong)
    {
        List<DAL.HOSO_PHUCAP> list = dataContext.HOSO_PHUCAPs.Where(t => t.FrKeyHOSO_LUONG == prkeyHoSoLuong).ToList();
        if (list.Count > 0)
        { 
            dataContext.HOSO_PHUCAPs.DeleteAllOnSubmit(list);
            Save();
            var ctl = new HoSoLuongController();
            foreach (var item in list)
            {

                var hsl = new HoSoLuongController().GetByID(item.FrKeyHOSO_LUONG);
                var hoso = new HoSoController().GetByPrKey(hsl.PrKeyHoSo);
                ctl.UpDateLuongTheoQuyetDinhLuong(hoso.MA_CB);
            }
        }
    }
}