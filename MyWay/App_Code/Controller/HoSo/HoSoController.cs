using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using SoftCore;
using Ext.Net;
using System.Data;
using System.Data.Linq.SqlClient;
using DataController;

/// <summary>
/// Summary description for HO_SOController
/// </summary>
public class HoSoController : LinqProvider
{
    public HoSoController()
    {
    }

    public IEnumerable<DAL.HOSO> GetAllOrderDonVi()
    {
        return dataContext.HOSOs.OrderBy(hs => hs.MA_DONVI);
    }


    /// <summary>
    /// Lấy hồ sơ dựa vào khóa chính của bảng hồ sơ
    /// </summary>
    /// <param name="prKey"></param>
    /// <returns></returns>
    public HOSO GetByPrKey(decimal prKey)
    {
        return (from t in dataContext.HOSOs
                where t.PR_KEY == prKey
                select t).FirstOrDefault();
    }
    public string GetTenVietTatCongTy(string maDonVi)
    {
        return (from x in dataContext.DM_DONVIs
                where x.MA_DONVI == maDonVi
                select x.TEN_TAT).FirstOrDefault();
    }
    public int CountByDVAndDayAndTypeStaff(string dv, string work, string maChucVu, DateTime day, bool typeStaff)
    {
        dv = dv.ToLower();
        work = work.ToLower();
        maChucVu = maChucVu.ToLower();
        if (typeStaff)
            return
                dataContext.HOSOs.Count(hs => hs.MA_CONGVIEC.ToLower() == work && hs.MA_DONVI.ToLower() == dv && hs.NGAY_TUYEN_DTIEN <= day && hs.MA_CHUCVU.ToLower() == maChucVu && hs.DA_NGHI == false);
        else
            return
              dataContext.HOSOs.Count(hs => hs.MA_CONGVIEC.ToLower() == work && hs.MA_DONVI.ToLower() == dv && hs.NGAY_TUYEN_CHINHTHUC <= day && hs.MA_CHUCVU.ToLower() == maChucVu && hs.DA_NGHI == false);

    }

    /// <summary>
    /// Tìm kiếm hồ sơ cán bộ theo họ tên
    /// </summary>
    /// <param name="name">tên cán bộ</param>
    /// <returns></returns>
    public IEnumerable<HoSoInfo> SearchByName(int start, int limit, string name, out int count)
    {
        var rs = from t in dataContext.HOSOs
                 join dv in dataContext.DM_DONVIs
                 on t.MA_DONVI equals dv.MA_DONVI
                 where (System.Data.Linq.SqlClient.SqlMethods.Like(t.HO_TEN, name) || name == "")
                 //&& (t.DA_NGHI == null || t.DA_NGHI == false)
                 orderby t.TEN_CB, t.MA_CB ascending
                 select new HoSoInfo
                 {
                     MACB = t.MA_CB,
                     HOTEN = t.HO_TEN,
                     PRKEY = t.PR_KEY,
                     PHONGBAN = dv.TEN_DONVI + " (" + dv.MA_DONVI + ")",
                     NGAYSINH = t.NGAY_SINH,
                     DANGHI = t.DA_NGHI
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }

    /// <summary>
    /// Lấy thông tin hồ sơ dựa vào ID của UserLog vào
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public HOSO GetByUserID(int id)
    {
        return (from t in dataContext.HOSOs
                where t.UserID == id
                select t).FirstOrDefault();
    }

    public string GetStaffCodeByPrKey(string prKey)
    {
        return DataHandler.GetInstance().ExecuteScalar("HoSo_GetStaffCodeByPrKey", "@PrkeyHOSO", decimal.Parse("0" + prKey)).ToString();
    }
    public DataTable FindHoso(string searchKey, out int count)
    {

        var re = new DataController.DataHandler().ExecuteDataTable("FindHoso", new string[] { "@SearchKey" }, searchKey);
        count = re.Rows.Count;
        return re;
    }

    public HOSO GetByMaCB(string macb)
    {
        return (from t in dataContext.HOSOs
                where t.MA_CB == macb
                select t).FirstOrDefault();
    }

    public decimal GetPrKeyByMaCB(string macb)
    {
        return (from t in dataContext.HOSOs
                where t.MA_CB == macb
                select t.PR_KEY).FirstOrDefault();
    }
    /// <summary>
    /// Kiểm tra số CMT đã bị trùng chưa
    /// </summary>
    /// <param name="cmdn"></param>
    /// <param name="macb"></param>
    /// <param name="isExisting"></param>
    /// <returns></returns>
    public DataTable GetByCMDN(string cmdn, string macb, ref bool isExisting)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("hoso_KiemTraTrungCMT", "@CMT", "@MaCB", cmdn, macb);
        isExisting = (table.Rows.Count > 0);
        return table;
    }
    public HOSO GetByMaChamCong(string maChamCong)
    {
        var rs = from t in dataContext.HOSOs
                 where t.ID_MAY_CHAMCONG == maChamCong
                 select t;
        return rs.FirstOrDefault();
    }
    /// <summary>
    /// Lấy danh sách cán bộ công nhân viên dựa vào một chuỗi mã cán bộ cách nhau bởi dấu phẩy
    /// ví dụ ,DTH001,DTH002,
    /// </summary>
    /// <param name="IdList"></param>
    /// <returns></returns>
    public List<DM_CBInfo> GetList(string IdList)
    {
        return (from t in dataContext.HOSOs
                where System.Data.Linq.SqlClient.SqlMethods.Like("," + IdList, "%," + t.MA_CB + ",%")
                select new DM_CBInfo
                {
                    MA_CB = t.MA_CB,
                    HO_TEN = t.HO_TEN,
                    NGAY_SINH = t.NGAY_SINH,
                    GIOI_TINH = t.MA_GIOITINH == "F" ? "Nữ" : "Nam",
                    DIA_CHI = t.DIA_CHI_LH,
                    MA_CONGTRINH = t.MA_CONGTRINH,
                    TEN_LOAI_HDONG = t.DM_LOAI_HDONG.TEN_LOAI_HDONG,
                    TEN_TRINHDO = t.DM_TRINHDO.TEN_TRINHDO,
                    EMAIL = t.EMAIL
                }).ToList();
    }
    /// <summary>
    /// Lấy PR_KEY theo MA_CB
    /// </summary>
    /// <param name="IdList"></param>
    /// <returns></returns>
    public HOSO GetByMACB(string maCB)
    {
        var rs = from t in dataContext.HOSOs
                 where t.MA_CB == maCB
                 select t;
        return rs.FirstOrDefault();
    }
    /// <summary>
    /// Lay PR_KEY theo ID_MAY_CHAMCONG
    /// </summary>
    /// <param name="maCB"></param>
    /// <returns></returns>
    public HOSO GetByIDMayChamCong(string idMayChamCong)
    {
        var rs = from t in dataContext.HOSOs
                 where t.ID_MAY_CHAMCONG == idMayChamCong
                 select t;
        return rs.FirstOrDefault();
    }
    public bool UpdateImageByMaPhongAndName(string maphong, string hoten, string ImageUrl)
    {
        string ht = SoftCore.Util.GetInstance().GetKeyword(hoten);
        var rs = (from t in dataContext.HOSOs
                  where t.MA_DONVI.ToLower() == maphong.ToLower() && SqlMethods.Like(t.HO_TEN.ToLower().Replace(" ", ""), '%' + ht.ToLower() + '%')
                  select t).FirstOrDefault();
        if (rs != null)
        {
            rs.PHOTO = ImageUrl;
            Save();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Cập nhật ảnh theo mã cán bộ
    /// </summary>
    /// <param name="MaCB">Mã cán bộ</param>
    /// <param name="ImageUrl">Đường dẫn ảnh</param>
    /// <returns><b>true</b> nếu cập nhật ảnh thành công. <b>false</b> nếu cập nhật ảnh thất bại</returns>
    public bool UpdateImage(string MaCB, string ImageUrl)
    {
        HOSO hs = dataContext.HOSOs.Where(t => t.MA_CB == MaCB).FirstOrDefault();//GetByMaCB(MaCB);
        if (hs != null)
        {
            hs.PHOTO = ImageUrl;
            Save();
            return true;
        }
        return false;
    }

    public bool UpdateImageBySoCMND(string SoCMND, string ImageUrl)
    {
        HOSO hs = dataContext.HOSOs.Where(t => t.SO_CMND == SoCMND).FirstOrDefault();
        if (hs != null)
        {
            hs.PHOTO = ImageUrl;
            Save();
            return true;
        }
        return false;
    }

    public void UpdateImage(decimal pr_key, string ImageUrl)
    {
        HOSO hs = dataContext.HOSOs.Where(t => t.PR_KEY == pr_key).FirstOrDefault();//GetByMaCB(MaCB);
        if (hs != null)
        {
            hs.PHOTO = ImageUrl;
            Save();
        }
        else
        {
            X.Msg.Alert("Thông báo", "Không tìm thấy cán bộ").Show();
        }
    }

    public void UpdateMaDonVi(decimal prkey, string maDonVi)
    {
        var hs = dataContext.HOSOs.SingleOrDefault(t => t.PR_KEY == prkey);
        if (hs != null)
        {
            hs.MA_DONVI = maDonVi;
            Save();
        }
    }

    public void UpdateMaChucVu(decimal prkey, string maChucVu)
    {
        var hs = dataContext.HOSOs.SingleOrDefault(t => t.PR_KEY == prkey);
        if (hs != null)
        {
            hs.MA_CHUCVU = maChucVu;
            Save();
        }
    }

    public void UpdateMaCongViec(decimal prkey, string maCongViec)
    {
        var hs = dataContext.HOSOs.SingleOrDefault(t => t.PR_KEY == prkey);
        if (hs != null)
        {
            hs.MA_CONGVIEC = maCongViec;
            Save();
        }
    }

    public decimal GetLastRecordPrimaryKey()
    {
        var rs = (from t in dataContext.HOSOs
                  orderby t.PR_KEY descending
                  select t.PR_KEY).Skip(0).Take(1).FirstOrDefault();
        return rs;
    }

    /// <summary>
    /// Sinh mã cán bộ dựa vào cấu hình hệ thống:
    /// -   Tiền tố của mã cán bộ
    /// -   Số lượng chữ số theo sau tiền tố
    /// </summary>
    /// <returns>Mã cán bộ mới được sinh ra</returns>
    public string GenerateMaCB(string maDV)
    {
        string prefix = new HeThongController().GetValueByName(SystemConfigParameter.PREFIX, maDV);
        string sl = new HeThongController().GetValueByName(SystemConfigParameter.NUMBER_OF_CHARACTER, maDV);
        if (string.IsNullOrEmpty(prefix))
            prefix = "";
        int number = string.IsNullOrEmpty(sl) ? 5 : int.Parse(sl);
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("GetMaCBByConfig", "@Prefix", "@Number", prefix, number);
        string oldMaCB = table.Rows.Count == 0 ? "00000000000000000000" : table.Rows[0]["MA_CB"].ToString();
        long oldNumber = long.Parse("" + oldMaCB.Substring(prefix.Length));
        oldNumber++;
        string newMaCB = "00000000000000000000" + oldNumber;
        newMaCB = prefix + newMaCB.Substring(newMaCB.Length - number);
        return newMaCB;
    }

    /// <summary>
    /// Hàm sinh số quyết định  daibx
    /// </summary>
    /// <param name="TableName">Tên bảng trong cơ sở dữ liệu cần sinh số quyết định</param>
    /// <param name="ColumnName">Tên cột của bảng lưu số quyết định</param>
    /// <param name="suffix">Hậu tố của số quyết định</param>
    /// <returns>Số quyết định được sinh theo định dạng đã cấu hình hệ thống</returns>
    public string GenerateSoHopDong(string TableName, string ColumnName, string suffix)
    {
        // get full suffix
        if (string.IsNullOrEmpty(suffix))
            return "";
        suffix = DateTime.Now.Year + "/" + suffix;
        // get max number of constract
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("GetSoHopDongByConfig", "@TableName", "@ColumnName", "@Suffix", TableName, ColumnName, suffix);
        if (table.Rows.Count > 0)   // có số hợp đồng lớn nhất
        {
            string sohd = table.Rows[0]["ColumnName"].ToString();
            int pos = sohd.IndexOf('/');
            if (pos != -1)
            {
                string stt = sohd.Trim().Substring(0, pos);
                int number = int.Parse(stt);
                stt = "0000" + (number + 1);
                stt = stt.Substring(stt.Length - 3);
                stt = stt + "/" + suffix;
                return stt;
            }
        }
        // chưa có số hợp đồng nào theo định dạng
        return "001/" + suffix;
    }

    public List<string> GetAllMaCB()
    {
        var rs = from t in dataContext.HOSOs
                 select t.MA_CB;
        return rs.ToList();
    }

    /// <summary>
    /// Lấy các mã cán bộ của 1 đơn vị(Không bao gồm các đơn vị con)
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public List<string> GetMaCBByMaDonVi(string maDonVi, bool daNghi)
    {
        var rs = from t in dataContext.HOSOs
                 where t.MA_DONVI == maDonVi &&
                 (t.DA_NGHI == daNghi || (t.DA_NGHI.HasValue == false && daNghi == false))
                 select t.MA_CB;
        return rs.ToList();
    }

    public List<HOSO> GetByMaDonVi(string maDV)
    {
        var rs = from t in dataContext.HOSOs
                 where t.MA_DONVI == maDV
                 select t;
        return rs.ToList();
    }
    public HoSoInfo getHoSo(decimal macb)
    {

        var rs = from t in dataContext.HOSOs
                 join temp1 in dataContext.DM_DONVIs on t.MA_DONVI equals temp1.MA_DONVI into tmp1
                 from dv in tmp1.DefaultIfEmpty()
                 join temp2 in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals temp2.MA_CHUCVU into tmp2
                 from cv in tmp2.DefaultIfEmpty()
                 join temp3 in dataContext.HOSO_LUONGs on t.PR_KEY equals temp3.PrKeyHoSo into tmp3
                 from hsluong in tmp3.DefaultIfEmpty()
                 where t.PR_KEY == macb
                 select new HoSoInfo
                 {
                     HOTEN = t.HO_TEN,
                     NGAYSINH = t.NGAY_SINH,
                     SOCMND = t.SO_CMND,
                     DIACHILH = t.DIA_CHI_LH,
                     TENCHUCVU = cv.TEN_CHUCVU,
                     NGAYTHUVIEC = t.NGAY_TUYEN_DTIEN, //Ngày thử việc
                     NGAYNHANCHINHTHUC = t.NGAY_TUYEN_CHINHTHUC,
                     LUONGDONGBHXH = (decimal)hsluong.LuongCung,
                     THOIGIANTHUVIEC = t.ThoiGianThuViec.ToString()
                 };
        return rs.FirstOrDefault();

    }
    public string GetNameTGD()
    {
        var rs = from t in dataContext.HOSOs
                 join dmcv in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals dmcv.MA_CHUCVU into em1
                 from emw in em1.DefaultIfEmpty()
                 where emw.MA_CHUCVU == "001"
                 select t.HO_TEN.ToString();
        return rs.FirstOrDefault();
    }
    public HoSoInfo getHoSoReportHopDong(string macb)
    {
        var rs = from t in dataContext.HOSOs
                 join hshop in dataContext.HOSO_HOPDONGs on t.PR_KEY equals hshop.FR_KEY into em7
                 from tb5 in em7.DefaultIfEmpty()
                 join temp1 in dataContext.DM_DONVIs on t.MA_DONVI equals temp1.MA_DONVI into tmp1
                 from dv in tmp1.DefaultIfEmpty()
                 join dmnuoc in dataContext.DM_NUOCs on t.MA_NUOC equals dmnuoc.MA_NUOC into em1
                 from tb in em1.DefaultIfEmpty()
                 join ngLuong in dataContext.DM_NGACHes on t.MA_NUOC equals ngLuong.MA_NGACH into nluong
                 from ngl in nluong.DefaultIfEmpty()
                 join cviec in dataContext.DM_CONGVIECs on t.MA_CONGVIEC equals cviec.MA_CONGVIEC into cv
                 from cviec in cv.DefaultIfEmpty()
                 join dmTrinhDo in dataContext.DM_TRINHDOs on t.MA_TRINHDO equals dmTrinhDo.MA_TRINHDO into matd
                 from td in matd.DefaultIfEmpty()
                 join dmchucvu in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals dmchucvu.MA_CHUCVU into em2
                 from tb1 in em2.DefaultIfEmpty()
                 join dmNoiCapCMND in dataContext.DM_NOICAP_CMNDs on t.MA_NOICAP_CMND equals dmNoiCapCMND.MA_NOICAP_CMND into em3
                 from tb2 in em3.DefaultIfEmpty()
                 join hsdieuchuyen in dataContext.HOSO_QT_DIEUCHUYENs on t.PR_KEY equals hsdieuchuyen.FR_KEY into em4
                 from tb3 in em4.DefaultIfEmpty()
                 join dmchucvumoi in dataContext.DM_CHUCVUs on tb3.MaChucVuMoi equals dmchucvumoi.MA_CHUCVU into em5
                 from tb4 in em5.DefaultIfEmpty()
                 join hsluong in dataContext.HOSO_LUONGs on t.PR_KEY equals hsluong.PrKeyHoSo into em9
                 from tb9 in em9.DefaultIfEmpty()
                 join tbx in dataContext.DM_LOAI_HDONGs on t.MA_LOAI_HDONG equals tbx.MA_LOAI_HDONG into emx
                 from ems in emx.DefaultIfEmpty()
                 join knlv in dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs on t.PR_KEY equals knlv.FR_KEY into em10
                 from tb10 in em10.DefaultIfEmpty()
                 where (t.MA_CB == macb)
                 orderby tb5.NGAY_HDONG ascending
                 select new HoSoInfo
                 {
                     Ngay_sinh = t.NGAY_SINH,
                     Noi_sinh = t.NOI_SINH,
                     MACB = t.MA_CB,
                     LOAIHDONG = ems.TEN_LOAI_HDONG,
                     HOTEN = t.HO_TEN,
                     TENNUOC = tb.TEN_NUOC,
                     GIOITINH = t.MA_GIOITINH == "M" ? "Ông" : "Bà",
                     GIOITINH_NAM_NU = t.MA_GIOITINH == "M" ? "Nam" : "Nữ",
                     NGAYSINH = t.NGAY_SINH,
                     TENCHUCVU = tb1.TEN_CHUCVU,
                     NOISINH = t.NOI_SINH,
                     DIACHILH = t.DIA_CHI_LH,
                     SOCMND = t.SO_CMND,
                     NGAYCAPCMND = t.NGAYCAP_CMND,
                     NOICAPCMNTT = tb2.TEN_NOICAP_CMND,
                     NGAYBATDAUHOPDONG = tb5.NGAY_HDONG,
                     NGAYKETTHUCHOPDONG = tb5.NGAYKT_HDONG,
                     TENCHUCVUMOI = tb4.TEN_CHUCVU,
                     NGAYTUYENDTIEN = t.NGAY_TUYEN_DTIEN,
                     NGAYNHANCHINHTHUC = t.NGAY_TUYEN_CHINHTHUC,
                     THOIHANHOPDONG = t.DM_LOAI_HDONG.THOI_HAN_HOPDONG_MONTH_,
                     MUCLUONG = (decimal?)tb9.LuongCung,
                     PHONGBAN = dv.TEN_DONVI,
                     THOIGIANTHUVIEC = t.ThoiGianThuViec.ToString(),
                     NGAYNGHI = t.NGAY_NGHI,
                     TENTRINHDO = td.TEN_TRINHDO,
                     HOKHAU = t.HO_KHAU,
                     sOHD = tb5.SO_HDONG,

                     BATDAUHOPDONG = tb5.NGAY_HDONG,
                     KETTHUCHOPDONG = tb5.NGAYKT_HDONG,
                     CHUCDANH = cviec.TEN_CONGVIEC,
                     CONGTYCU = tb10.NoiLamViec,

                     MADONVI = dv.MA_DONVI
                 };
        return rs.FirstOrDefault();
    }
    public HoSoInfo getHoSoDieuChuyen(string macb)
    {
        var rs = from t in dataContext.HOSOs
                 join hsqtdc in dataContext.HOSO_QT_DIEUCHUYENs on t.PR_KEY equals hsqtdc.FR_KEY into em1
                 from v1 in em1.DefaultIfEmpty()
                 join dmcv in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals dmcv.MA_CHUCVU into em6
                 from v6 in em6.DefaultIfEmpty()
                 join dmdv in dataContext.DM_DONVIs on t.MA_DONVI equals dmdv.MA_DONVI into em7
                 from v7 in em7.DefaultIfEmpty()
                 join dmdv1 in dataContext.DM_DONVIs on v7.PARENT_ID equals dmdv1.MA_DONVI into em8
                 from v8 in em8.DefaultIfEmpty()
                 where (t.MA_CB == macb)
                 select new HoSoInfo
                 {
                     HOTEN = t.HO_TEN,
                     TENCHUCVU = v6.TEN_CHUCVU,
                     MADONVI = v7.TEN_DONVI,
                     MACB = t.MA_CB,
                     TENKHAC = v8.TEN_DONVI,
                     NGAYBNCHUCVU = v1.NgayCoHieuLuc
                 };
        return rs.FirstOrDefault();
    }
    public HoSoInfo getHoSo(string macb)
    {
        var rs = from t in dataContext.HOSOs
                 join temp1 in dataContext.DM_DONVIs on t.MA_DONVI equals temp1.MA_DONVI into tmp1
                 from dv in tmp1.DefaultIfEmpty()
                 join temp2 in dataContext.DM_CHUCVUs on t.MA_CHUCVU equals temp2.MA_CHUCVU into tmp2
                 from cv in tmp2.DefaultIfEmpty()
                 join temp3 in dataContext.HOSO_LUONGs on t.PR_KEY equals temp3.PrKeyHoSo into tmp3
                 from hsluong in tmp3.DefaultIfEmpty()
                 where t.MA_CB == macb
                 select new HoSoInfo
                 {
                     HOTEN = t.HO_TEN,
                     NGAYSINH = t.NGAY_SINH,
                     SOCMND = t.SO_CMND,
                     DIACHILH = t.DIA_CHI_LH,
                     TENCHUCVU = cv.TEN_CHUCVU,
                     NGAYTHUVIEC = t.NGAY_TUYEN_DTIEN, //Ngày thử việc
                     NGAYNHANCHINHTHUC = t.NGAY_TUYEN_CHINHTHUC,
                     LUONGDONGBHXH = (decimal)hsluong.LuongCung,
                     THOIGIANTHUVIEC = t.ThoiGianThuViec.ToString(),
                     PHONGBAN = dv.TEN_DONVI,
                     NGAYNGHI = t.NGAY_NGHI
                 };
        return rs.FirstOrDefault();
    }
    public List<HoSoInfo> GetHoso(int start, int limit, string MaDonVi, out int count, string searchKey, int userID, int menuID, bool isAllEmployee)
    {
        string[] dsDonVi = new DepartmentRoleController().GetMaBoPhanByRole(userID, menuID).Split(',');
        //string[] dsDonVi = new DM_DONVIController().GetAllMaDonVi(MaDonVi).Split(',');
        var rs = (from t in dataContext.HOSOs
                  join dv in dataContext.DM_DONVIs
                  on t.MA_DONVI equals dv.MA_DONVI
                  where (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.HO_TEN, searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.MA_CB, searchKey)
                    || System.Data.Linq.SqlClient.SqlMethods.Like(t.DI_DONG, searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(t.SO_CMND, searchKey)
                    || System.Data.Linq.SqlClient.SqlMethods.Like(t.EMAIL, searchKey))
                  && dsDonVi.Contains(t.MA_DONVI) && (isAllEmployee == true || t.DA_NGHI == false || t.DA_NGHI.HasValue == false)
                  //   orderby t.TEN_CB
                  select new HoSoInfo
                  {
                      PRKEY = t.PR_KEY,
                      HOTEN = t.HO_TEN,
                      MACB = t.MA_CB,
                      NGAYSINH = t.NGAY_SINH,
                      GIOITINH = t.MA_GIOITINH == "F" ? "Nữ" : "Nam",
                      DIACHILH = t.DIA_CHI_LH,
                      DIDONG = t.DI_DONG,
                      PHOTO = t.PHOTO.Replace("~", "../.."),
                      TRUONGDAOTAO = t.DM_TRUONG_DAOTAO.TEN_TRUONG_DAOTAO == null ? "" : t.DM_TRUONG_DAOTAO.TEN_TRUONG_DAOTAO,
                      LOAIHDONG = t.DM_LOAI_HDONG.TEN_LOAI_HDONG,
                      TRINHDO = t.DM_TRINHDO.TEN_TRINHDO,
                      NGAYTHUVIEC = t.NGAY_TUYEN_DTIEN, //Ngày thử việc
                      NGAYNHANCHINHTHUC = t.NGAY_TUYEN_CHINHTHUC, //Ngày tiếp nhận chính thức
                      SOCMND = t.SO_CMND,
                      EMAIL = t.EMAIL,
                      PHONGBAN = dv.TEN_DONVI,//t.DM_PHONG != null ? t.DM_PHONG.TEN_PHONG : ""
                      DANGHI = t.DA_NGHI
                  });
        count = rs.Count();
        return rs.OrderBy(u => u.PHONGBAN).Skip(start).Take(limit).ToList();
    }

    /// <summary>
    /// Lấy danh sách cán bộ theo một chuỗi mã đơn vị, cách nhau bằng dấu ,
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <param name="count"></param>
    /// <param name="searchKey"></param>
    /// <param name="IsDaNghi"></param>
    /// <returns></returns>
    public List<DM_CBInfo> GetHOSOInfoByMaDonVi(string maDonVi, int start, int limit, out int count, string searchKey, bool IsDaNghi)
    {
        //lấy các chuỗi ID
        System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
        string str = "%,";
        foreach (var item in idList)
        {
            str += item + ",";
        }
        str += "%";

        List<DM_CBInfo> rs = (from t in dataContext.HOSOs
                              join dv in dataContext.DM_DONVIs
                               on t.MA_DONVI equals dv.MA_DONVI
                              where (System.Data.Linq.SqlClient.SqlMethods.Like("%" + str + "%", "%," + t.MA_DONVI + ",%")) && (string.IsNullOrEmpty(searchKey)
                              || System.Data.Linq.SqlClient.SqlMethods.Like(t.HO_TEN, searchKey))
                              && (t.DA_NGHI == IsDaNghi || (t.DA_NGHI.HasValue == false && IsDaNghi == false))
                              select new DM_CBInfo
                              {
                                  MA_CB = t.MA_CB,
                                  HO_TEN = t.HO_TEN,
                                  NGAY_SINH = t.NGAY_SINH,
                                  GIOI_TINH = t.MA_GIOITINH == "F" ? "Nữ" : "Nam",
                                  DIA_CHI = t.DIA_CHI_LH,
                                  TEN_LOAI_HDONG = t.DM_LOAI_HDONG.TEN_LOAI_HDONG,
                                  TEN_TRINHDO = t.DM_TRINHDO.TEN_TRINHDO,
                                  DIENTHOAI = t.DI_DONG,
                                  DonViCongTac = dv.TEN_DONVI
                              }).ToList();
        count = rs.Count();
        return rs.Skip(start).Take(limit).ToList();
    }

    /// <summary>
    /// Thêm mới tài sản
    /// </summary>
    /// <param name="ts"></param>
    /// <returns></returns>
    public bool InsertTaiSan(DAL.HOSO_TAISAN ts)
    {
        try
        {
            dataContext.HOSO_TAISANs.InsertOnSubmit(ts);
            Save();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public DAL.HOSO_TAISAN GetTaiSan(decimal Pr_key)
    {
        return dataContext.HOSO_TAISANs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();

    }
    public void UpdateTaiSan(DAL.HOSO_TAISAN hsts)
    {
        DAL.HOSO_TAISAN taisan = GetTaiSan(hsts.PR_KEY);
        if (taisan != null)
        {
            taisan.SoLuong = hsts.SoLuong;
            taisan.MaDonViTinh = hsts.MaDonViTinh;
            taisan.GHI_CHU = hsts.GHI_CHU;
            taisan.MA_VTHH = hsts.MA_VTHH;
            taisan.NGAY_NHAN = hsts.NGAY_NHAN;
            taisan.TINH_TRANG = hsts.TINH_TRANG;
            taisan.TepTinDinhKem = hsts.TepTinDinhKem;
            taisan.HanSuDung = hsts.HanSuDung;
            Save();
        }
    }
    public void InsertHoSo(DAL.HOSO hs)
    {
        dataContext.HOSOs.InsertOnSubmit(hs);
        Save();
    }
    public void UpdateHoSo(DAL.HOSO hs)
    {
        DAL.HOSO tmp = dataContext.HOSOs.Single(p => p.UserID == hs.UserID);
        tmp = hs;
        Save();
    }
    public void InsertQuaTrinhDaoTao(HOSO_QT_DAOTAO qtdt)
    {
        dataContext.HOSO_QT_DAOTAOs.InsertOnSubmit(qtdt);
        Save();
    }
    public DAL.HOSO_QT_DAOTAO GetQuaTrinhDaoTao(decimal Pr_key)
    {
        return dataContext.HOSO_QT_DAOTAOs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }
    public void UpdateQuaTrinhDaoTao(HOSO_QT_DAOTAO qtdt)
    {
        DAL.HOSO_QT_DAOTAO daotao = GetQuaTrinhDaoTao(qtdt.PR_KEY);
        daotao.MA_XEPLOAI = qtdt.MA_XEPLOAI;
        daotao.DEN_NGAY = qtdt.DEN_NGAY;
        daotao.GHI_CHU = qtdt.GHI_CHU;
        daotao.MA_CHUYENNGANH = qtdt.MA_CHUYENNGANH;
        daotao.MA_HT_DAOTAO = qtdt.MA_HT_DAOTAO;
        daotao.MA_NUOC = qtdt.MA_NUOC;
        daotao.MA_TRINHDO = qtdt.MA_TRINHDO;
        daotao.MA_TRUONG_DAOTAO = qtdt.MA_TRUONG_DAOTAO;
        daotao.MA_XEPLOAI = qtdt.MA_XEPLOAI;
        daotao.SO_TIEN = qtdt.SO_TIEN;
        daotao.TEN_KHOAHOC = qtdt.TEN_KHOAHOC;
        daotao.TEN_TRUONG = qtdt.TEN_TRUONG;
        daotao.TU_NGAY = qtdt.TU_NGAY;
        Save();
    }

    public void InsertBaoHiem(HOSO_BAOHIEM hosoBaoHiem)
    {
        dataContext.HOSO_BAOHIEMs.InsertOnSubmit(hosoBaoHiem);
        Save();
    }
    public DAL.HOSO_BAOHIEM GetBaoHiem(decimal Pr_key)
    {
        return dataContext.HOSO_BAOHIEMs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }
    public void UpdateBaoHiem(DAL.HOSO_BAOHIEM hsbh)
    {
        DAL.HOSO_BAOHIEM baohiem = GetBaoHiem(hsbh.PR_KEY);

        baohiem.DEN_NGAY = hsbh.DEN_NGAY;
        baohiem.DON_VI = hsbh.DON_VI;
        baohiem.GHI_CHU = hsbh.GHI_CHU;
        baohiem.HS_LUONG = hsbh.HS_LUONG;
        baohiem.MA_CONGVIEC = hsbh.MA_CONGVIEC;
        baohiem.MUC_LUONG = hsbh.MUC_LUONG;
        baohiem.PHUCAP = hsbh.PHUCAP;
        baohiem.TU_NGAY = hsbh.TU_NGAY;
        baohiem.TYLE = hsbh.TYLE;
        Save();

    }

    public void InsertDaiBieu(HOSO_DAIBIEU daibieu)
    {
        dataContext.HOSO_DAIBIEUs.InsertOnSubmit(daibieu);
        Save();
    }
    public DAL.HOSO_DAIBIEU GetDaiBieu(decimal Pr_key)
    {
        return dataContext.HOSO_DAIBIEUs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }
    public void UpdateDaiBieu(DAL.HOSO_DAIBIEU hsdb)
    {
        DAL.HOSO_DAIBIEU daibieu = GetDaiBieu(hsdb.PR_KEY);
        daibieu.DEN_NGAY = hsdb.DEN_NGAY;
        daibieu.GHI_CHU = hsdb.GHI_CHU;
        daibieu.LOAI_HINH = hsdb.LOAI_HINH;
        daibieu.NHIEM_KY = hsdb.NHIEM_KY;
        daibieu.TU_NGAY = hsdb.TU_NGAY;
        Save();
    }

    public void InsertDeTai(HOSO_DETAI detai)
    {
        dataContext.HOSO_DETAIs.InsertOnSubmit(detai);
        Save();
    }
    public DAL.HOSO_DETAI GetDeTai(decimal Pr_key)
    {
        return dataContext.HOSO_DETAIs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }
    public void UpdateDetai(DAL.HOSO_DETAI hsdt)
    {
        DAL.HOSO_DETAI detai = GetDeTai(hsdt.PR_KEY);
        if (detai != null)
        {
            detai.MaDeTai = hsdt.MaDeTai;
            detai.CAP_DETAI = hsdt.CAP_DETAI;
            detai.CHUNHIEM_DETAI = hsdt.CHUNHIEM_DETAI;
            detai.DEN_NGAY = hsdt.DEN_NGAY;
            detai.GHI_CHU = hsdt.GHI_CHU;
            detai.KET_QUA = hsdt.KET_QUA;
            detai.TEN_DETAI = hsdt.TEN_DETAI;
            detai.TU_NGAY = hsdt.TU_NGAY;
            detai.TUCACH_THAMGIA = hsdt.TUCACH_THAMGIA;
            detai.TepTinDinhKem = hsdt.TepTinDinhKem;
            Save();
        }
    }

    public DAL.HOSO_HOPDONG GetHopDong(decimal Pr_key)
    {
        //return dataContext.HOSO_HOPDONGs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
        var rs = from t in dataContext.HOSO_HOPDONGs
                 where t.PR_KEY == Pr_key
                 select t;
        return rs.FirstOrDefault();
    }
    public string GetTenByMa(string ma)
    {
        var rs = (from t in dataContext.DM_TT_HDONGs
                  where t.MA_TT_HDONG == ma
                  select t.TEN_TT_HDONG).FirstOrDefault();
        return rs.ToString();
    }
    public void UpdateLoaiHopDong(string maLoaiHopDong, decimal prkey)
    {
        HOSO hs = dataContext.HOSOs.Single(t => t.PR_KEY == prkey);
        if (hs != null)
        {
            hs.MA_LOAI_HDONG = maLoaiHopDong;
            Save();
        }
    }

    public void InsertKhaNang(HOSO_KHANANG khaNang)
    {
        dataContext.HOSO_KHANANGs.InsertOnSubmit(khaNang);
        Save();
    }
    public DAL.HOSO_KHANANG GetKhaNang(decimal Pr_key)
    {
        return dataContext.HOSO_KHANANGs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }
    public void UpdateKhaNang(DAL.HOSO_KHANANG hskn)
    {
        DAL.HOSO_KHANANG khanang = GetKhaNang(hskn.PR_KEY);
        khanang.GHI_CHU = hskn.GHI_CHU;
        khanang.MA_KHANANG = hskn.MA_KHANANG;
        khanang.MA_XEPLOAI = hskn.MA_XEPLOAI;
        Save();
    }

    public void InsertQuanHeGiaDinh(HOSO_QH_GIADINH qhgd)
    {
        dataContext.HOSO_QH_GIADINHs.InsertOnSubmit(qhgd);
        Save();
    }
    public DAL.HOSO_QH_GIADINH GetQuanHeGiaDinh(decimal Pr_key)
    {
        return dataContext.HOSO_QH_GIADINHs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }
    public void UpdateQuanHeGiaDinh(DAL.HOSO_QH_GIADINH hsqhgd)
    {
        DAL.HOSO_QH_GIADINH quanhegiadinh = GetQuanHeGiaDinh(hsqhgd.PR_KEY);
        if (quanhegiadinh != null)
        {
            quanhegiadinh.GHI_CHU = hsqhgd.GHI_CHU;
            quanhegiadinh.GIOI_TINH = hsqhgd.GIOI_TINH;
            quanhegiadinh.HO_TEN = hsqhgd.HO_TEN;
            quanhegiadinh.MA_QUANHE = hsqhgd.MA_QUANHE;
            quanhegiadinh.NGHE_NGHIEP = hsqhgd.NGHE_NGHIEP;
            quanhegiadinh.NOI_LAMVIEC = hsqhgd.NGHE_NGHIEP;
            quanhegiadinh.NOI_LAMVIEC = hsqhgd.NOI_LAMVIEC;
            quanhegiadinh.TUOI = hsqhgd.TUOI;
            quanhegiadinh.LaNguoiPhuThuoc = hsqhgd.LaNguoiPhuThuoc;
            quanhegiadinh.NgayBatDauGiamTru = hsqhgd.NgayBatDauGiamTru;
            quanhegiadinh.NgayKetThucGiamTru = hsqhgd.NgayKetThucGiamTru;
            quanhegiadinh.SoCMT = hsqhgd.SoCMT;
            //  quanhegiadinh.Duyet = false;
            quanhegiadinh.PrKeyHoSoTuCapNhat = hsqhgd.PrKeyHoSoTuCapNhat;
            Save();
        }
    }

    public IEnumerable<DAL.HOSO_TAINANLAODONG> GetTaiNanList(decimal fr_key)
    {
        return dataContext.HOSO_TAINANLAODONGs.Where(t => t.FR_KEY == fr_key);
    }

    public void updateLuong(HOSO hs)
    {
        DAL.HOSO tmp = GetByMaCB(hs.MA_CB);
        tmp.MA_CHUCVU = hs.MA_CHUCVU;
        //tmp.HS_LUONG = hs.HS_LUONG;
        tmp.MA_NGACH = hs.MA_NGACH;
        tmp.MA_CONGVIEC = hs.MA_CONGVIEC;
        Save();
    }
    /// <summary>
    /// Tạo tài khoản dựa vào họ tên
    /// </summary>
    /// <param name="FullName"></param>
    /// <returns></returns>
    public string CreateUserAcc(string FullName)
    {
        string[] tmp = Util.GetInstance().RemoveVietNamese(FullName.Trim().Replace("Đ", "D").Replace("đ", "d")).Split(' ');
        string rs = "";
        foreach (string item in tmp)
        {
            rs += item.Trim();
        }
        int c = 1;
        while (UsersController.GetInstance().GetUser(rs) != null)
        {
            rs += c;
            c++;
        }
        return rs;
    }

    public int GetCountHoSo()
    {
        var rs = from t in dataContext.HOSOs
                 where t.DA_NGHI == false
                 select t;
        return rs.ToList().Count;
    }

    public void DuplidateTaiNanLaoDong(int id, int createdby)
    {
        DAL.HOSO_TAINANLAODONG taiNan = dataContext.HOSO_TAINANLAODONGs.Where(t => t.ID == id).FirstOrDefault();
        DAL.HOSO_TAINANLAODONG clone = new HOSO_TAINANLAODONG()
        {
            CreatedDate = DateTime.Now,
            CreatedBy = createdby,
            BOI_THUONG = taiNan.BOI_THUONG,
            DIA_DIEM = taiNan.DIA_DIEM,
            GHI_CHU = taiNan.GHI_CHU,
            FR_KEY = taiNan.FR_KEY,
            LY_DO = taiNan.LY_DO,
            NGAY_XAY_RA = taiNan.NGAY_XAY_RA,
            THIET_HAI = taiNan.THIET_HAI,
            THUONG_TAT = taiNan.THUONG_TAT
        };

        dataContext.HOSO_TAINANLAODONGs.InsertOnSubmit(clone);
        Save();
    }

    public void InsertTaiNanLaoDong(HOSO_TAINANLAODONG taiNan)
    {
        dataContext.HOSO_TAINANLAODONGs.InsertOnSubmit(taiNan);
        Save();
    }

    public decimal GetMultilId(int n)
    {
        var idhoso = (from r in dataContext.HOSOs orderby r.PR_KEY descending select r.PR_KEY).Take(n);
        return idhoso.FirstOrDefault();
    }
    public HOSO_TAINANLAODONG getTaiNan(int p)
    {
        return dataContext.HOSO_TAINANLAODONGs.Where(t => t.ID == p).FirstOrDefault();
    }

    public ThuTucDauVao getThuTuc(int p)
    {
        return dataContext.ThuTucDauVaos.Where(t => t.ID == p).FirstOrDefault();
    }

    public void UpdateThuTucDauVao(DAL.ThuTucDauVao thutuc)
    {
        DAL.ThuTucDauVao item = dataContext.ThuTucDauVaos.Where(t => t.ID == thutuc.ID).FirstOrDefault();
        if (item == null)
        {
            return;
        }

            item.ID = thutuc.ID;
            item.PrKeyHoSo = thutuc.PrKeyHoSo;
            item.TenThuTuc = thutuc.TenThuTuc;
            item.HoanThanh = thutuc.HoanThanh;
            item.CreatedBy = thutuc.CreatedBy;
            item.CreatedDate = thutuc.CreatedDate;
            Save();
        
    }
    public void UpdateTaiNanLaoDong(HOSO_TAINANLAODONG taiNan, int currentID)
    {
        DAL.HOSO_TAINANLAODONG tmp = getTaiNan(taiNan.ID);
        tmp.LY_DO = taiNan.LY_DO;
        tmp.GHI_CHU = taiNan.GHI_CHU;
        tmp.BOI_THUONG = taiNan.BOI_THUONG;
        tmp.CreatedBy = currentID;
        tmp.CreatedDate = DateTime.Now;
        tmp.DIA_DIEM = taiNan.DIA_DIEM;
        tmp.NGAY_XAY_RA = taiNan.NGAY_XAY_RA;
        tmp.THIET_HAI = taiNan.THIET_HAI;
        tmp.THUONG_TAT = taiNan.THUONG_TAT;
        tmp.NgayBoiThuong = taiNan.NgayBoiThuong;
        Save();
    }

    public void DuplidateBangCapChungChi(int p)
    {
        DAL.HOSO_UNGVIEN_CHUNGCHI chungChi = dataContext.HOSO_UNGVIEN_CHUNGCHIs.Where(t => t.ID == p).FirstOrDefault();
        DAL.HOSO_UNGVIEN_CHUNGCHI hsChungChi = new HOSO_UNGVIEN_CHUNGCHI()
        {
            FR_KEY_HOSO = chungChi.FR_KEY_HOSO,
            GhiChu = chungChi.GhiChu,
            MA_XEPLOAI = chungChi.MA_XEPLOAI,
            NgayCap = chungChi.NgayCap,
            NgayHetHan = chungChi.NgayHetHan,
            NoiDaoTao = chungChi.NoiDaoTao,
            MaChungChi = chungChi.MaChungChi,
            Duyet = chungChi.Duyet
        };
        dataContext.HOSO_UNGVIEN_CHUNGCHIs.InsertOnSubmit(hsChungChi);
        Save();
    }

    public void InsertTepTin(HOSO_TepTinDinhKem attachFile)
    {
        dataContext.HOSO_TepTinDinhKems.InsertOnSubmit(attachFile);
        Save();
    }
    public void InsertThuTuc(ThuTucDauVao thutuc)
    {
        dataContext.ThuTucDauVaos.InsertOnSubmit(thutuc);
        Save();
    }

    public DAL.HOSO_TepTinDinhKem GetTepTin(int ID)
    {
        return dataContext.HOSO_TepTinDinhKems.Where(t => t.PR_KEY == ID).FirstOrDefault();
    }

    public DAL.HOSO_TepTinDinhKem GetByIdTuCapNhat(int ID)
    {
        return dataContext.HOSO_TepTinDinhKems.Where(t => t.PrKeyHoSoTuCapNhat == ID).FirstOrDefault();
    }

    public void DeleteTepTin(int p, out string linkFile)
    {
        DAL.HOSO_TepTinDinhKem teptin = dataContext.HOSO_TepTinDinhKems.Where(t => t.PR_KEY == p).FirstOrDefault();
        linkFile = teptin.Link;
        dataContext.HOSO_TepTinDinhKems.DeleteOnSubmit(teptin);
        Save();
    }

    public void DeleteByMaCB(decimal pr_key)
    {
        DAL.HOSO tmp = dataContext.HOSOs.Where(t => t.PR_KEY == pr_key).FirstOrDefault();
        if (tmp != null)
        {
            dataContext.HOSOs.DeleteOnSubmit(tmp);
            Save();
        }
    }

    public void UpdateTepTin(HOSO_TepTinDinhKem attachFile, out string oldFilePath)
    {
        DAL.HOSO_TepTinDinhKem tmp = GetTepTin(attachFile.PR_KEY);
        oldFilePath = tmp.Link;
        tmp.TenTepTin = attachFile.TenTepTin;
        tmp.GhiChu = attachFile.GhiChu;
        tmp.Link = attachFile.Link;
        Save();
    }

    public void DuplicateKinhNghiemLamViec(int p, int createdUser)
    {
        DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC knlv = dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.ID == p).FirstOrDefault();
        DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC tmp = new HOSO_UNGVIEN_KINHNGHIEMLAMVIEC()
        {
            LyDoThoiViec = knlv.LyDoThoiViec,
            MucLuong = knlv.MucLuong,
            GhiChu = knlv.GhiChu,
            DiaChiCongTy = knlv.DiaChiCongTy,
            CreatedUser = createdUser,
            DenThangNam = knlv.DenThangNam,
            FR_KEY = knlv.FR_KEY,
            KinhNghiemDatDuoc = knlv.KinhNghiemDatDuoc,
            NoiLamViec = knlv.NoiLamViec,
            TuThangNam = knlv.TuThangNam,
            ViTriCongViec = knlv.ViTriCongViec,
        };
        dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.InsertOnSubmit(tmp);
        Save();
    }

    public HOSO_UNGVIEN_KINHNGHIEMLAMVIEC GetKinhNghiemLamViec(int p)
    {
        return dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.ID == p).FirstOrDefault();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pr_key"></param>
    /// <param name="createdUserID"></param>
    public void DuplicateQuaTrinhHocTap(int pr_key, int createdUserID)
    {
        DAL.HOSO_BANGCAP_UNGVIEN bangCap = dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.ID == pr_key).FirstOrDefault();
        DAL.HOSO_BANGCAP_UNGVIEN tmp = new HOSO_BANGCAP_UNGVIEN()
        {
            DATE_CREATE = DateTime.Now,
            KHOA = bangCap.KHOA,
            MA_CHUYENNGANH = bangCap.MA_CHUYENNGANH,
            MA_HT_DAOTAO = bangCap.MA_HT_DAOTAO,
            MA_TRINHDO = bangCap.MA_TRINHDO,
            FR_KEY = bangCap.FR_KEY,
            MA_TRUONG_DAOTAO = bangCap.MA_TRUONG_DAOTAO,
            MA_XEPLOAI = bangCap.MA_XEPLOAI,
            NGAY_NHANBANG = bangCap.NGAY_NHANBANG,
            USERNAME = createdUserID.ToString(),
            DA_TN = bangCap.DA_TN,
            DEN_NGAY = bangCap.DEN_NGAY,
            TU_NGAY = bangCap.TU_NGAY,
        };
        dataContext.HOSO_BANGCAP_UNGVIENs.InsertOnSubmit(tmp);
        Save();
    }

    public HOSO_BANGCAP_UNGVIEN getQuaTrinhHocTap(int p)
    {
        return dataContext.HOSO_BANGCAP_UNGVIENs.Where(t => t.ID == p).FirstOrDefault();
    }

    public void UpDateHoSoBaoHiem(HOSO hs)
    {
        HOSO item = dataContext.HOSOs.Where(p => p.PR_KEY == hs.PR_KEY).SingleOrDefault();
        if (item != null)
        {
            if (!string.IsNullOrEmpty(hs.HO_TEN))
            {
                item.HO_TEN = hs.HO_TEN;
                item.TEN_CB = hs.TEN_CB;
            }

            if (hs.NGAY_SINH != null)
            {
                item.NGAY_SINH = hs.NGAY_SINH;
            }
            if (!string.IsNullOrEmpty(hs.MA_GIOITINH))
            {
                item.MA_GIOITINH = hs.MA_GIOITINH;
            }
            if (!string.IsNullOrEmpty(hs.SO_CMND))
            {
                item.SO_CMND = hs.SO_CMND;
            }
            if (!string.IsNullOrEmpty(hs.MA_NOICAP_CMND))
            {
                item.MA_NOICAP_CMND = hs.MA_NOICAP_CMND;
            }
            if (hs.NGAYCAP_CMND != null)
            {
                item.NGAYCAP_CMND = hs.NGAYCAP_CMND;
            }
            if (!string.IsNullOrEmpty(hs.SOTHE_BHXH))
            {
                item.SOTHE_BHXH = hs.SOTHE_BHXH;
            }
            if (!string.IsNullOrEmpty(hs.SOTHE_BHYT))
            {
                item.SOTHE_BHYT = hs.SOTHE_BHYT;
            }
            if (hs.NGAY_DONGBH != null)
            {
                item.NGAY_DONGBH = hs.NGAY_DONGBH;
            }
            if (hs.NGAY_HETHAN_BHYT != null)
            {
                item.NGAY_HETHAN_BHYT = hs.NGAY_HETHAN_BHYT;
            }
            Save();
        }
    }

    public void UpdateDaNghiStatus(decimal prkeyHoSo, bool value)
    {
        DAL.HOSO hs = dataContext.HOSOs.Where(t => t.PR_KEY == prkeyHoSo).FirstOrDefault();
        if (hs != null)
        {
            hs.DA_NGHI = value;
            Save();
        }
    }
    /// <summary>
    /// Đức anh viết hàm trả về direction hồ sơ: mã nhân viên, tên nhân viên
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, string> TraVeTuDienHoSo()
    {
        Dictionary<string, string> dr = new Dictionary<string, string>();
        var listma = (from t in dataContext.HOSOs
                      select new
                      {
                          t.MA_CB,
                          t.HO_TEN
                      }).ToList();
        foreach (var item in listma)
        {
            dr.Add(item.MA_CB, item.HO_TEN);
        }
        return dr;
    }

    public string TraVeTenByPRKEY(decimal prkeyhoso)
    {
        return dataContext.HOSOs.SingleOrDefault(p => p.PR_KEY == prkeyhoso).HO_TEN;
    }
    public string TraVeTenByMaCB(string macb)
    {
        return dataContext.HOSOs.SingleOrDefault(p => p.MA_CB == macb).HO_TEN;
    }
    public string TraVeMaCbByPRKEY(decimal prkeyhoso)
    {
        return dataContext.HOSOs.SingleOrDefault(p => p.PR_KEY == prkeyhoso).MA_CB;
    }
    public decimal TraVePRKEYbyMaCB(string macb)
    {
        return dataContext.HOSOs.SingleOrDefault(p => p.MA_CB == macb).PR_KEY;
    }
    public void UpdateMaChamCong(string macb, string machamcong)
    {
        DAL.HOSO hs = dataContext.HOSOs.SingleOrDefault(t => t.ID_MAY_CHAMCONG == machamcong);
        if (hs != null)
        {
            throw new Exception("Mã chấm công này đã được dùng cho nhân viên " + hs.HO_TEN + " (" + hs.MA_CB + ")");
        }
        DAL.HOSO hoso = GetByMaCB(macb);
        hoso.ID_MAY_CHAMCONG = machamcong;
        Save();
    }
    public void UpdateMaCa(string macb, string maca)
    {
        DAL.BangPhanCaNhanVien tmp = dataContext.BangPhanCaNhanViens.SingleOrDefault(t => t.MA_CB == macb);
        if (tmp != null)
        {
            tmp.MA_CB = macb;
            tmp.MaCa = string.IsNullOrEmpty(maca) ? null : maca;
            Save();
        }
        else
        {
            DAL.BangPhanCaNhanVien bpc = new BangPhanCaNhanVien();
            bpc.MA_CB = macb;
            bpc.MaCa = string.IsNullOrEmpty(maca) ? null : maca;
            dataContext.BangPhanCaNhanViens.InsertOnSubmit(bpc);
            Save();
        }
    }
    public List<HoSoInfo> GetHoSoMaChamCong(string madonvi, List<string> macanbo, bool choncanbo)//=true: chỉ lấy những cán bộ trong danh sách được chọn, false: cán bộ trong bộ phận được chọn
    {
        string[] dsDonVi = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        var rs = (from t in dataContext.HOSOs
                  join dv in dataContext.DM_DONVIs on t.MA_DONVI equals dv.MA_DONVI into dv1
                  from dv2 in dv1.DefaultIfEmpty()
                  join dd in dataContext.DM_DIADIEMLAMVIECs on t.BI_DANH equals dd.MA_DIADIEM into dd1
                  from dd2 in dd1.DefaultIfEmpty()
                  where (choncanbo == false ? dsDonVi.Contains(t.MA_DONVI) && (t.DA_NGHI == false || t.DA_NGHI.HasValue == false) : macanbo.Contains(t.MA_CB))
                  orderby dv2.MA_DONVI ascending, dd2.MA_DIADIEM ascending
                  select new HoSoInfo
                  {
                      PRKEY = t.PR_KEY,
                      HOTEN = t.HO_TEN,
                      MACB = t.MA_CB,
                      PHONGBAN = dv2.TEN_DONVI,
                      MaChamCong = t.ID_MAY_CHAMCONG,
                      BIDANH = dd2.TEN_DIADIEM
                  });
        //count = rs.Count();
        return rs.ToList();
    }
    public List<HoSoInfo> GetHoSoMaCa(string madonvi, List<string> macanbo, bool choncanbo)//=true: chỉ lấy những cán bộ trong danh sách được chọn, false: cán bộ trong bộ phận được chọn
    {
        string[] dsDonVi = new DM_DONVIController().GetAllMaDonVi(madonvi).Split(',');
        var rs = (from t in dataContext.HOSOs
                  join dv in dataContext.DM_DONVIs on t.MA_DONVI equals dv.MA_DONVI into dv1
                  from dv2 in dv1.DefaultIfEmpty()
                  join dd in dataContext.DM_DIADIEMLAMVIECs on t.BI_DANH equals dd.MA_DIADIEM into dd1
                  from dd2 in dd1.DefaultIfEmpty()
                  join bpc in dataContext.BangPhanCaNhanViens on t.MA_CB equals bpc.MA_CB into bpc1
                  from bpc2 in bpc1.DefaultIfEmpty()
                  where (choncanbo == false ? dsDonVi.Contains(t.MA_DONVI) && (t.DA_NGHI == false || t.DA_NGHI.HasValue == false) : macanbo.Contains(t.MA_CB))
                  orderby dv2.MA_DONVI ascending, dd2.MA_DIADIEM ascending
                  select new HoSoInfo
                  {
                      PRKEY = t.PR_KEY,
                      HOTEN = t.HO_TEN,
                      MACB = t.MA_CB,
                      PHONGBAN = dv2.TEN_DONVI,
                      MaChamCong = t.ID_MAY_CHAMCONG,
                      BIDANH = dd2.TEN_DIADIEM,
                      MaCa = bpc2.MaCa
                  });
        //count = rs.Count();
        return rs.ToList();
    }
}