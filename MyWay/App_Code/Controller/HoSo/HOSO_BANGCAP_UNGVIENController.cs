using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_BANGCAP_UNGVIENController
/// </summary>
public class HOSO_BANGCAP_UNGVIENController : LinqProvider
{
    public HOSO_BANGCAP_UNGVIENController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<HOSO_BANGCAP_UNGVIENInfo1> GetByFr_Key(decimal Fr_Key)
    {
        var rs = from t in dataContext.HOSO_BANGCAP_UNGVIENs
                 join dm_truong in dataContext.DM_TRUONG_DAOTAOs on t.MA_TRUONG_DAOTAO equals dm_truong.MA_TRUONG_DAOTAO into tmp1
                 join dm_cn in dataContext.DM_CHUYENNGANHs on t.MA_CHUYENNGANH equals dm_cn.MA_CHUYENNGANH into tmp2
                 join dm_td in dataContext.DM_TRINHDOs on t.MA_TRINHDO equals dm_td.MA_TRINHDO into tmp3
                 join dm_htdt in dataContext.DM_HT_DAOTAOs on t.MA_HT_DAOTAO equals dm_htdt.MA_HT_DAOTAO into tmp4
                 join dm_xl in dataContext.DM_XEPLOAIs on t.MA_XEPLOAI equals dm_xl.MA_XEPLOAI into tmp5
                 where t.FR_KEY == Fr_Key

                 from t1 in tmp1.DefaultIfEmpty()
                 from t2 in tmp2.DefaultIfEmpty()
                 from t3 in tmp3.DefaultIfEmpty()
                 from t4 in tmp4.DefaultIfEmpty()
                 from t5 in tmp5.DefaultIfEmpty()
                 select new HOSO_BANGCAP_UNGVIENInfo1()
                 {
                     DA_TN = t.DA_TN,
                     ID = t.ID,
                     FR_KEY = t.FR_KEY,
                     KHOA = t.KHOA,
                     TEN_CHUYENNGANH = t2.TEN_CHUYENNGANH,
                     TEN_HT_DAOTAO = t4.TEN_HT_DAOTAO,
                     TEN_TRINHDO = t3.TEN_TRINHDO,
                     TEN_TRUONG_DAOTAO = t1.TEN_TRUONG_DAOTAO,
                     TEN_XEPLOAI = t5.TEN_XEPLOAI,
                     NGAY_NHANBANG = t.NGAY_NHANBANG,
                     TU_NGAY = t.TU_NGAY,
                     DEN_NGAY = t.DEN_NGAY
                 };
        return rs.ToList();
    }

    public List<HOSO_BANGCAP_UNGVIENInfo> GetByFr_Key1(decimal Fr_Key)
    {
        var rs = from t in dataContext.HOSO_BANGCAP_UNGVIENs
                 join dm_truong in dataContext.DM_TRUONG_DAOTAOs on t.MA_TRUONG_DAOTAO equals dm_truong.MA_TRUONG_DAOTAO into tmp1
                 join dm_cn in dataContext.DM_CHUYENNGANHs on t.MA_CHUYENNGANH equals dm_cn.MA_CHUYENNGANH into tmp2
                 join dm_td in dataContext.DM_TRINHDOs on t.MA_TRINHDO equals dm_td.MA_TRINHDO into tmp3
                 join dm_htdt in dataContext.DM_HT_DAOTAOs on t.MA_HT_DAOTAO equals dm_htdt.MA_HT_DAOTAO into tmp4
                 join dm_xl in dataContext.DM_XEPLOAIs on t.MA_XEPLOAI equals dm_xl.MA_XEPLOAI into tmp5
                 where t.FR_KEY == Fr_Key

                 from t1 in tmp1.DefaultIfEmpty()
                 from t2 in tmp2.DefaultIfEmpty()
                 from t3 in tmp3.DefaultIfEmpty()
                 from t4 in tmp4.DefaultIfEmpty()
                 from t5 in tmp5.DefaultIfEmpty()
                 select new HOSO_BANGCAP_UNGVIENInfo()
                 {
                     DA_TN = t.DA_TN,
                     ID = t.ID,
                     FR_KEY = t.FR_KEY,
                     KHOA = t.KHOA,
                     MA_CHUYENNGANH = t2.MA_CHUYENNGANH,
                     MA_HT_DAOTAO = t4.MA_HT_DAOTAO,
                     MA_TRINHDO = t3.MA_TRINHDO,
                     MA_TRUONG_DAOTAO = t1.MA_TRUONG_DAOTAO,
                     MA_XEPLOAI = t5.MA_XEPLOAI,
                     NGAY_NHANBANG = t.NGAY_NHANBANG,
                     TU_NGAY = t.TU_NGAY,
                     DEN_NGAY = t.DEN_NGAY
                 };
        return rs.ToList();
    }

    public void Insert(DAL.HOSO_BANGCAP_UNGVIEN a)
    {
        dataContext.HOSO_BANGCAP_UNGVIENs.InsertOnSubmit(a);
        Save();
    }
    public DAL.HOSO_BANGCAP_UNGVIEN GetByID(int Id)
    {
        return dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.ID == Id).FirstOrDefault();

    }
    public void Update(DAL.HOSO_BANGCAP_UNGVIEN a)
    {
        DAL.HOSO_BANGCAP_UNGVIEN bangcapuv = GetByID(a.ID);
        bangcapuv.KHOA = a.KHOA;
        bangcapuv.MA_CHUYENNGANH = a.MA_CHUYENNGANH;
        bangcapuv.MA_HT_DAOTAO = a.MA_HT_DAOTAO;
        bangcapuv.MA_TRINHDO = a.MA_TRINHDO;
        bangcapuv.MA_TRUONG_DAOTAO = a.MA_TRUONG_DAOTAO;
        bangcapuv.MA_XEPLOAI = a.MA_XEPLOAI;
        bangcapuv.NGAY_NHANBANG = a.NGAY_NHANBANG;
        bangcapuv.DA_TN = a.DA_TN;
        bangcapuv.TU_NGAY = a.TU_NGAY;
        bangcapuv.DEN_NGAY = a.DEN_NGAY;
        Save();
    }
    /// <summary>
    /// Lấy ra Mã Chuyên ngành của ứng viên
    /// </summary>
    /// <param name="Pr_Key">Khóa chính PR_KEY của bảng KEHOACH_TUYENDUNG</param>
    /// <returns></returns>
    public string GetMaChuyenNganhByFr_Key(int Pr_Key)
    {
        var rs = from t in dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.FR_KEY == Pr_Key)
                 select t.MA_CHUYENNGANH.FirstOrDefault();
        return rs.ToString();


    }

    public void DeleteBangCap(int id)
    {
        DAL.HOSO_BANGCAP_UNGVIEN bangCap = dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.ID == id).FirstOrDefault();
        dataContext.HOSO_BANGCAP_UNGVIENs.DeleteOnSubmit(bangCap);
        Save();
    }

    /// <summary>
    /// Hàm xóa dành cho form tự cập nhật
    /// </summary>
    /// <param name="ID"></param>
    public void Delete(int ID)
    {
        DAL.HOSO_BANGCAP_UNGVIEN obj = dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.ID == ID).FirstOrDefault();
        if (obj.FR_KEY <= 0)
        {
            dataContext.HOSO_BANGCAP_UNGVIENs.DeleteOnSubmit(obj);
            Save();
        }
        else
        {
            obj.PrkeyHoSoTuCapNhat = -1;
            Save();
        }
    }
    /// <summary>
    /// Hàm update dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="deTai"></param>
    public void UpdateForTuCapNhat(DAL.HOSO_BANGCAP_UNGVIEN newObj)
    {
        DAL.HOSO_BANGCAP_UNGVIEN oldObj = dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.ID == newObj.ID).FirstOrDefault();
        if (oldObj == null)
        {
            return;
        }
        if (oldObj.FR_KEY > 0 && oldObj.PrkeyHoSoTuCapNhat > 0)
        {
            oldObj.PrkeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_BANGCAP_UNGVIEN item = new DAL.HOSO_BANGCAP_UNGVIEN()
            {
                PrkeyHoSoTuCapNhat = newObj.PrkeyHoSoTuCapNhat,
                KHOA = newObj.KHOA,
                FR_KEY = -1,
                DA_TN = newObj.DA_TN,
                MA_CHUYENNGANH = newObj.MA_CHUYENNGANH,
                MA_HT_DAOTAO = newObj.MA_HT_DAOTAO,
                MA_TRINHDO = newObj.MA_TRINHDO,
                MA_TRUONG_DAOTAO = newObj.MA_TRUONG_DAOTAO,
                MA_XEPLOAI = newObj.MA_XEPLOAI,
                NGAY_NHANBANG = newObj.NGAY_NHANBANG,
                TU_NGAY = newObj.TU_NGAY,
                DATE_CREATE = newObj.DATE_CREATE,
                DEN_NGAY = newObj.DEN_NGAY,
                USERNAME = newObj.USERNAME,
            };
            dataContext.HOSO_BANGCAP_UNGVIENs.InsertOnSubmit(item);
            Save();
        }
        else
        {
            oldObj.PrkeyHoSoTuCapNhat = newObj.PrkeyHoSoTuCapNhat;
            oldObj.KHOA = newObj.KHOA;
            oldObj.FR_KEY = -1;
            oldObj.DA_TN = newObj.DA_TN;
            oldObj.MA_CHUYENNGANH = newObj.MA_CHUYENNGANH;
            oldObj.MA_HT_DAOTAO = newObj.MA_HT_DAOTAO;
            oldObj.MA_TRINHDO = newObj.MA_TRINHDO;
            oldObj.MA_TRUONG_DAOTAO = newObj.MA_TRUONG_DAOTAO;
            oldObj.MA_XEPLOAI = newObj.MA_XEPLOAI;
            oldObj.NGAY_NHANBANG = newObj.NGAY_NHANBANG;
            oldObj.TU_NGAY = newObj.TU_NGAY;
            oldObj.DATE_CREATE = newObj.DATE_CREATE;
            oldObj.DEN_NGAY = newObj.DEN_NGAY;
            oldObj.USERNAME = newObj.USERNAME;
            Save();
        }
    }
}