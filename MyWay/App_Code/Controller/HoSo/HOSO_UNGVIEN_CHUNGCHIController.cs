using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_UNGVIEN_CHUNGCHIController
/// </summary>
public class HOSO_UNGVIEN_CHUNGCHIController : LinqProvider
{
    public HOSO_UNGVIEN_CHUNGCHIController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Lấy chứng chỉ của ứng viên
    /// </summary>
    /// <param name="Fr_key"></param>
    /// <returns></returns>
    public List<HOSO_UNGVIEN_CHUNGCHIInfo> GetByFr_key(decimal Fr_key)
    {

        var rs = from t in dataContext.HOSO_UNGVIEN_CHUNGCHIs
                 where t.FR_KEY_HOSO == Fr_key
                 select new HOSO_UNGVIEN_CHUNGCHIInfo
                 {
                     MA_XEPLOAI = t.DM_XEPLOAI != null ? t.DM_XEPLOAI.TEN_XEPLOAI : "",
                    // MA_TRINHDO = t.MaChungChi != null ? t.DM_CHUNGCHI.TEN_CHUNGCHI : "",
                     
                     NgayCap = t.NgayCap.Value,
                     NgayHetHan = t.NgayHetHan.Value,
                     NoiDaoTao = t.NoiDaoTao,
                     TenChungChi = t.MaChungChi,
                     ID = t.ID,
                 };
        return rs.ToList();

    }
    /// <summary>
    /// Lấy bằng cấp của hồ sơ
    /// </summary>
    /// <param name="fr_key"></param>
    /// <returns></returns>
    public List<HOSO_UNGVIEN_CHUNGCHIInfo1> GetByFr_keyHOSO(decimal fr_key)
    {
        var rs = from t in dataContext.HOSO_UNGVIEN_CHUNGCHIs
                 join dm_xl in dataContext.DM_XEPLOAIs on t.MA_XEPLOAI equals dm_xl.MA_XEPLOAI into tmp1
                 join dm_cc in dataContext.DM_CHUNGCHIs on t.MaChungChi equals dm_cc.MA_CHUNGCHI into tmp3
                 where t.FR_KEY_HOSO == fr_key

                 from t1 in tmp1.DefaultIfEmpty()
                 from t3 in tmp3.DefaultIfEmpty()
                 select new HOSO_UNGVIEN_CHUNGCHIInfo1
                 {
                     TEN_XEPLOAI = t1.TEN_XEPLOAI,
                     NgayCap = t.NgayCap.Value,
                     NgayHetHan = t.NgayHetHan.Value,
                     NoiDaoTao = t.NoiDaoTao,
                     TenChungChi = t3.TEN_CHUNGCHI,
                     ID = t.ID,
                     GhiChu = t.GhiChu,
                 };
        return rs.ToList();
    }

    /// <summary>
    /// Lấy thông tin tự cập nhật
    /// </summary>
    /// <param name="prKeyTuCapNhat"></param>
    /// <returns></returns>
    public List<HOSO_UNGVIEN_CHUNGCHIInfo1> GetByPrKeyTuCapNhat(decimal prKeyTuCapNhat)
    {
        var rs = from t in dataContext.HOSO_UNGVIEN_CHUNGCHIs
                 join dm_xl in dataContext.DM_XEPLOAIs on t.MA_XEPLOAI equals dm_xl.MA_XEPLOAI into tmp1
                 join dm_cc in dataContext.DM_CHUNGCHIs on t.MaChungChi equals dm_cc.MA_CHUNGCHI into tmp3
                 where t.PrKeyHoSoTuCapNhat == prKeyTuCapNhat

                 from t1 in tmp1.DefaultIfEmpty()
                 from t3 in tmp3.DefaultIfEmpty()
                 select new HOSO_UNGVIEN_CHUNGCHIInfo1
                 {
                     TEN_XEPLOAI = t1.TEN_XEPLOAI,
                     GhiChu = t.GhiChu,
                     NgayCap = t.NgayCap.Value,
                     NgayHetHan = t.NgayHetHan.Value,
                     NoiDaoTao = t.NoiDaoTao,
                     TenChungChi = t3.TEN_CHUNGCHI,
                     ID = t.ID, 
                 };
        return rs.ToList();
    }
    /// <summary>
    /// Lấy thông tin mã chứng chỉ và mã hồ sơ. nếu đã có trong csdl thì thực hiện update chứ không insert
    /// </summary>
    /// <param name="prKeyTuCapNhat"></param>
    /// <returns></returns>
    public DAL.HOSO_UNGVIEN_CHUNGCHI GetByMaCCandPrKeyHoSoTuCapNhat(string MaCC, decimal prkey)
    {
        return dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.MaChungChi == MaCC && t.PrKeyHoSoTuCapNhat == prkey).FirstOrDefault();
    }


    public void Insert(DAL.HOSO_UNGVIEN_CHUNGCHI chungchi)
    {
        dataContext.HOSO_UNGVIEN_CHUNGCHIs.InsertOnSubmit(chungchi);
        Save();
    }
    public DAL.HOSO_UNGVIEN_CHUNGCHI GetByID(int Id)
    {
        return dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.ID == Id).FirstOrDefault();
    }
    public void Update(DAL.HOSO_UNGVIEN_CHUNGCHI chungchi)
    {
        DAL.HOSO_UNGVIEN_CHUNGCHI hschungchi = GetByID(chungchi.ID);
        if (hschungchi!=null)
        {
            hschungchi.GhiChu = chungchi.GhiChu;
            hschungchi.MA_XEPLOAI = chungchi.MA_XEPLOAI;
            hschungchi.NgayCap = chungchi.NgayCap;
            hschungchi.NgayHetHan = chungchi.NgayHetHan;
            hschungchi.NoiDaoTao = chungchi.NoiDaoTao;
            hschungchi.MaChungChi = chungchi.MaChungChi;
            hschungchi.FR_KEY_HOSO = chungchi.FR_KEY_HOSO;
            Save();
        }
     
    }

    public void UpdateForTuCapNhat(DAL.HOSO_UNGVIEN_CHUNGCHI chungchi)
    {
        DAL.HOSO_UNGVIEN_CHUNGCHI item = dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.ID == chungchi.ID).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY_HOSO > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_UNGVIEN_CHUNGCHI newObject = new DAL.HOSO_UNGVIEN_CHUNGCHI()
            {
                PrKeyHoSoTuCapNhat = chungchi.PrKeyHoSoTuCapNhat,
                FR_KEY_HOSO = 0,
                GhiChu = chungchi.GhiChu,
                MA_XEPLOAI = chungchi.MA_XEPLOAI,
                NgayCap = chungchi.NgayCap,
                NgayHetHan = chungchi.NgayHetHan,
                NoiDaoTao = chungchi.NoiDaoTao,
                MaChungChi = chungchi.MaChungChi,
            };
            dataContext.HOSO_UNGVIEN_CHUNGCHIs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHoSoTuCapNhat = chungchi.PrKeyHoSoTuCapNhat;
            item.FR_KEY_HOSO = 0;
            item.GhiChu = chungchi.GhiChu;
            item.MA_XEPLOAI = chungchi.MA_XEPLOAI;
            item.NgayCap = chungchi.NgayCap;
            item.NgayHetHan = chungchi.NgayHetHan;
            item.NoiDaoTao = chungchi.NoiDaoTao;
            item.MaChungChi = chungchi.MaChungChi;
            Save();
        }
    }

    public void Delete(int id)
    {
        DAL.HOSO_UNGVIEN_CHUNGCHI chungchi = dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.ID == id).FirstOrDefault();
        dataContext.HOSO_UNGVIEN_CHUNGCHIs.DeleteOnSubmit(chungchi);
        Save();
    }
}