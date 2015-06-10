using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_UNGVIEN_KINHNGHIEMLAMVIECController
/// </summary>
public class HOSO_UNGVIEN_KINHNGHIEMLAMVIECController : LinqProvider
{
    public HOSO_UNGVIEN_KINHNGHIEMLAMVIECController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC> GetByUngVienId(decimal Fr_key)
    {
        return dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.FR_KEY == Fr_key).ToList();
    }
    /// <summary>
    /// Lấy bản ghi cho form tự cập nhật
    /// </summary>
    /// <param name="prKeyTuCapNhat"></param>
    /// <returns></returns>
    public List<DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC> GetByPrKeyTuCapNhat(decimal prKeyTuCapNhat)
    {
        return dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.PrKeyHoSoTuCapNhat == prKeyTuCapNhat).ToList();
    }

    public void Insert(DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC a)
    {
        dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.InsertOnSubmit(a);
        Save();

    }
    public DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC GetKinhNghiemByID(int id)
    {
        return dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.ID == id).FirstOrDefault();
    }
    public void Update(DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC knlv)
    {
        DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC kn = GetKinhNghiemByID(knlv.ID);
        kn.KinhNghiemDatDuoc = knlv.KinhNghiemDatDuoc;
        kn.NoiLamViec = knlv.NoiLamViec;
        kn.TuThangNam = knlv.TuThangNam;
        kn.ViTriCongViec = knlv.ViTriCongViec;
        kn.DenThangNam = knlv.DenThangNam;
        kn.LyDoThoiViec = knlv.LyDoThoiViec;
        kn.MucLuong = knlv.MucLuong;
        kn.DiaChiCongTy = knlv.DiaChiCongTy;
        kn.GhiChu = knlv.GhiChu;
        Save();
    }

    public void UpdateForTuCapNhat(DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC knlv)
    {
        DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC item = dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.ID == knlv.ID).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC newObject = new DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC()
            {
                PrKeyHoSoTuCapNhat = knlv.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                KinhNghiemDatDuoc = knlv.KinhNghiemDatDuoc,
                NoiLamViec = knlv.NoiLamViec,
                TuThangNam = knlv.TuThangNam,
                ViTriCongViec = knlv.ViTriCongViec,
                DenThangNam = knlv.DenThangNam,
                CreatedUser = knlv.CreatedUser,
                GhiChu = knlv.GhiChu,
                DiaChiCongTy = knlv.DiaChiCongTy,
                MucLuong = knlv.MucLuong,
                LyDoThoiViec = knlv.LyDoThoiViec,
            };
            dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHoSoTuCapNhat = knlv.PrKeyHoSoTuCapNhat;
            item.FR_KEY = -1;
            item.KinhNghiemDatDuoc = knlv.KinhNghiemDatDuoc;
            item.NoiLamViec = knlv.NoiLamViec;
            item.TuThangNam = knlv.TuThangNam;
            item.ViTriCongViec = knlv.ViTriCongViec;
            item.DenThangNam = knlv.DenThangNam;
            item.CreatedUser = knlv.CreatedUser;
            item.GhiChu = knlv.GhiChu;
            item.DiaChiCongTy = knlv.DiaChiCongTy;
            item.MucLuong = knlv.MucLuong;
            item.LyDoThoiViec = knlv.LyDoThoiViec;
            Save();
        }
    }

    public void DeleteKinhNghiemLamViec(int id)
    {
        DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC kn = dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.ID == id).FirstOrDefault();
        dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.DeleteOnSubmit(kn);
        Save();
    }
}