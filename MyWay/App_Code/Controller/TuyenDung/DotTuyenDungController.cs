using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_DOTTUYENDUNGController
/// </summary>
public class DotTuyenDungController : LinqProvider
{
    public DotTuyenDungController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    // ĐẠI TT commment
     
    //public void Insert(DAL.DM_DOTTUYENDUNG k)
    //{
    //    dataContext.DM_DOTTUYENDUNGs.InsertOnSubmit(k);
    //    Save();
    //}

    //public void UpdateTrangThaiXuLy(DAL.DM_DOTTUYENDUNG a)
    //{
    //    DAL.DM_DOTTUYENDUNG dotTuyenDung = GetByID(a.ID);
    //    dotTuyenDung.TrangThaiXuLy = a.TrangThaiXuLy;
    //    Save();
    //}
    /// <summary>
    /// Hàm này được sử dụng cho báo cáo
    /// </summary>
    /// <param name="trangthaisuly">Nếu trạng thái xử lý bằng rỗng thì lấy tất cả</param>
    /// <returns></returns>
    public IEnumerable<DM_DOTTUYENDUNGInfo> GetDotTuyenDungByTrangThaiXuLy(string trangthaiXuly)
    {
        //return (from t in dataContext.DM_DOTTUYENDUNGs.Where(t => t.TrangThaiXuLy == trangthaiXuly || string.IsNullOrEmpty(trangthaiXuly))
        //        join p in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals p.MA_CHUCVU
        //        into pp
        //        from p in pp.DefaultIfEmpty()
        //        select new DM_DOTTUYENDUNGInfo
        //        {
        //            KinhPhiDuTru = t.KinhPhiDuTru,
        //            LyDoTuyen = t.LyDoTuyen,
        //            MA_CHUCVU = p.TEN_CHUCVU,
        //            NgayBatDau = t.NgayBatDau,
        //            NgayKetThuc = t.NgayKetThuc,
        //            SoLuongCanTuyen = t.SoLuongCanTuyen,
        //            TenKeHoach = t.TenKeHoach,
        //            ID = t.ID
        //        });
        return null;
    }

    //public List<DAL.DM_DOTTUYENDUNG> GetAll(int start, int limit)
    //{
    //    return dataContext.DM_DOTTUYENDUNGs.Skip(start).Take(limit).OrderByDescending(t => t.CreatedDate).ToList();
    //}

    public void DeleteKeHoachTuyenDung(int ID)
    {
        //DAL.DM_DOTTUYENDUNG tuyendung = dataContext.DM_DOTTUYENDUNGs.Where(t => t.ID == ID).FirstOrDefault();
        //dataContext.DM_DOTTUYENDUNGs.DeleteOnSubmit(tuyendung);
        //Save();
    }
}