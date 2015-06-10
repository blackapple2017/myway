using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HOSO_HOPDONGController
/// </summary>
public class HOSO_HOPDONGController : LinqProvider
{
    public HOSO_HOPDONGController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insert(DAL.HOSO_HOPDONG hd)
    {
        dataContext.HOSO_HOPDONGs.InsertOnSubmit(hd);
        Save();
    }

    public List<DAL.HOSO_HOPDONG> GetByFrkey(decimal frkey)
    {
        var rs = from t in dataContext.HOSO_HOPDONGs
                 where t.FR_KEY == frkey
                 select t;
        return rs.ToList();
    }

    public List<HoSoHopDongInfo> GetAllByFrkey(decimal frkey)
    {
        var rs = from t in dataContext.HOSO_HOPDONGs
                 join p in dataContext.DM_LOAI_HDONGs on t.MA_LOAI_HDONG equals p.MA_LOAI_HDONG into tmp1
                 join cv in dataContext.DM_CONGVIECs on t.MA_CONGVIEC equals cv.MA_CONGVIEC into tmp2
                 from tp1 in tmp1.DefaultIfEmpty()
                 from tp2 in tmp2.DefaultIfEmpty()
                 where t.FR_KEY == frkey && (t.NGAYKT_HDONG >= DateTime.Now || t.NGAYKT_HDONG == null)
                 select new HoSoHopDongInfo
                 {
                     MaLoaiHopDong = t.MA_LOAI_HDONG,
                     TenLoaiHopDong = tp1.TEN_LOAI_HDONG,
                     SoHopDong = t.SO_HDONG,
                     ID = t.PR_KEY,
                     TenCongViec = tp2.TEN_CONGVIEC,
                     NgayKyHopDong = t.NGAY_HDONG,
                     NgayKetThucHopDong = t.NGAYKT_HDONG,
                     MaTrangThai = t.MA_TT_HDONG
                     
                 };
        return rs.ToList();
    }

    //Đức anh thêm hàm lấy ra hợp đồng của ông có id=id và hợp đồng đó vẫn còn hiệu lực
    public DAL.HOSO_HOPDONG GetHoSoHopDongById(decimal id)
    {
       return  dataContext.HOSO_HOPDONGs.Where(p => p.FR_KEY == id && (((p.NGAYKT_HDONG==null ||p.NGAYKT_HDONG.ToString().Contains("0001"))&&p.NGAY_HDONG<DateTime.Now) || (p.NGAY_HDONG < DateTime.Now && p.NGAYKT_HDONG >= DateTime.Now))).OrderByDescending(p=>p.NGAY_HDONG).SingleOrDefault();
    }

    public void Update(DAL.HOSO_HOPDONG hd)
    {
        DAL.HOSO_HOPDONG tmp = dataContext.HOSO_HOPDONGs.SingleOrDefault(t => t.PR_KEY == hd.PR_KEY);
        if (tmp != null)
        {
            tmp.SO_HDONG = hd.SO_HDONG;
            tmp.MA_LOAI_HDONG = hd.MA_LOAI_HDONG;
            tmp.MA_CONGVIEC = hd.MA_CONGVIEC;
            tmp.NGAY_HDONG = hd.NGAY_HDONG;
            tmp.NGAYKT_HDONG = hd.NGAYKT_HDONG;
            tmp.MA_TT_HDONG = hd.MA_TT_HDONG;
            tmp.NgayCoHieuLuc = hd.NgayCoHieuLuc;
            tmp.PrkeyNguoiDaiDienKyHD = hd.PrkeyNguoiDaiDienKyHD;
            tmp.MaChucVuNguoiKyHD = hd.MaChucVuNguoiKyHD;
            tmp.TepTinDinhKem = hd.TepTinDinhKem;
            tmp.GhiChu = hd.GhiChu;
            tmp.PrkeyHoSoLuong = hd.PrkeyHoSoLuong;
            tmp.TrangThaiHopDong = hd.TrangThaiHopDong;
            Save();
        }
    }

    /// <summary>
    /// Kiểm tra danh sách hợp đồng đã hết hạn hoàn toàn hay chưa để thêm mới 1 hợp đồng
    /// Nếu còn một hợp đồng chưa hết hạn thì không được phép thêm mới
    /// </summary>
    /// <returns><b>true</b> nếu không còn hợp đồng nào có giá trị (được phép thêm). <b>false</b> nếu còn ít nhất 1 hợp đồng còn thời hạn</returns>
    public bool CheckBeforeInsert(decimal frkey, DateTime? ngayCoHieuLucMoi)
    {
        //var dtNow = DateTime.Now;
        var rs = from t in dataContext.HOSO_HOPDONGs
                 where t.FR_KEY == frkey && (ngayCoHieuLucMoi < t.NGAYKT_HDONG || t.NGAYKT_HDONG == null)
                 select t;
        return rs.ToList().Count == 0;
    }

    public string GenerateSoHopDong(decimal prkeyCanBo, string suffix)
    {
        // get max number of constract
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("GetSoHopDongByConfig", "@Prkey", "@Suffix", prkeyCanBo, suffix);
        if (table.Rows.Count > 0)   // có số hợp đồng lớn nhất
        {
            string sohd = table.Rows[0]["SO_HDONG"].ToString();
            int pos = sohd.IndexOf('/');
            if (pos != -1)
            {
                string stt = sohd.Trim().Substring(0, pos);
                int number = int.Parse(stt);
                stt = "0000" + (number + 1);
                stt = stt.Substring(0, 3);
                stt = stt + DateTime.Now.Month + "/" + DateTime.Now.Year + "/" + suffix;
                return stt;
            }
        }
        // chưa có số hợp đồng nào theo định dạng
        return "001" + DateTime.Now.Month + "/" + DateTime.Now.Year + "/" + suffix;
    }

    public void UpdateInputForm(DAL.HOSO_HOPDONG hd)
    {
        DAL.HOSO_HOPDONG tmp = dataContext.HOSO_HOPDONGs.SingleOrDefault(t => t.PR_KEY == hd.PR_KEY);
        if (tmp != null)
        {
            tmp.FR_KEY = hd.FR_KEY;
            tmp.SO_HDONG = hd.SO_HDONG;
            tmp.MA_LOAI_HDONG = hd.MA_LOAI_HDONG;
            tmp.NGAY_HDONG = hd.NGAY_HDONG;
            tmp.NGAYKT_HDONG = hd.NGAYKT_HDONG;
            tmp.MA_TT_HDONG = hd.MA_TT_HDONG;
            Save();
        }
    }

    public void Delete(decimal p)
    {
        DAL.HOSO_HOPDONG tmp = dataContext.HOSO_HOPDONGs.SingleOrDefault(t => t.PR_KEY == p);
        if (tmp != null)
        {
            dataContext.HOSO_HOPDONGs.DeleteOnSubmit(tmp);
            Save();
        }
    }
}