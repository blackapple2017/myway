using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhSachNgayPhepController
/// </summary>
public class DanhSachNgayPhepController : LinqProvider
{
    public DanhSachNgayPhepController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DAL.DanhSachNgayPhep GetByID(int idDanhSachNgayPhep)
    {
        return dataContext.DanhSachNgayPheps.Where(t => t.ID == idDanhSachNgayPhep).FirstOrDefault();
    }

    public DAL.DanhSachNgayPhep GetByPrKeyHoSo(decimal prKeyHoSo, int nam)
    {
        return dataContext.DanhSachNgayPheps.Where(t => t.PrKeyHoSo == prKeyHoSo && t.Nam == nam).FirstOrDefault();
    }

    public void UpdateNgayPhep(DAL.DanhSachNgayPhep item)
    {
        DAL.DanhSachNgayPhep oldObj = GetByID(item.ID);
        oldObj.SoNgayPhepDuocThem = item.SoNgayPhepDuocThem;
        oldObj.SoNgayPhepNamNay = item.SoNgayPhepNamNay;
        oldObj.SoNgayPhepNamTruoc = item.SoNgayPhepNamTruoc;
        //cập nhật lại số ngày đã sử dụng theo tháng
        oldObj.Thang1 = item.Thang1;
        oldObj.Thang2 = item.Thang2;
        oldObj.Thang3 = item.Thang3;
        oldObj.Thang4 = item.Thang4;
        oldObj.Thang5 = item.Thang5;
        oldObj.Thang6 = item.Thang6;
        oldObj.Thang7 = item.Thang7;
        oldObj.Thang8 = item.Thang8;
        oldObj.Thang9 = item.Thang9;
        oldObj.Thang10 = item.Thang10;
        oldObj.Thang11 = item.Thang11;
        oldObj.Thang12 = item.Thang12;
        Save();
    }

    /// <summary>
    /// Cập nhật lại thông tin ngày phép cho một nhân viên
    /// </summary>
    /// <param name="ngayPhep"></param>
    /// <param name="idDanhSachNgayPhep">Khóa chính của bảng DanhSachNgayPhep</param>
    public void TinhSoNgayPhep(DAL.DanhSachNgayPhep ngayPhep, int idDanhSachNgayPhep)
    {
        DAL.DanhSachNgayPhep obj = GetByID(idDanhSachNgayPhep);
        if (obj != null)
        {
            obj.ThoiHanSuDungNgayPhepNamTruoc = ngayPhep.ThoiHanSuDungNgayPhepNamTruoc;
            obj.ThoiHanSuDungNgayPhepDuocThem = ngayPhep.ThoiHanSuDungNgayPhepDuocThem;
            obj.SoNgayPhepNamTruoc = ngayPhep.SoNgayPhepNamTruoc;
            obj.SoNgayPhepNamNay = ngayPhep.SoNgayPhepNamNay;
            obj.SoNgayPhepDuocThem = ngayPhep.SoNgayPhepDuocThem;
            obj.SoNgayPhepCongDonToiDaTrongThang = ngayPhep.SoNgayPhepCongDonToiDaTrongThang;
            obj.Nam = ngayPhep.Nam;
            Save();
        }
    }

    /// <summary>
    /// Tính số ngày phép cho tất cả nhân viên
    /// Những nhân viên nào chưa có danh sách ngày phép thì tạo mới
    /// những nhân viên có rồi thì cập nhật lại thông tin
    /// </summary>
    /// <param name="ngayPhep"></param>
    /// <param name="maDonVi"></param>
    public void TinhSoNgayPhep(DAL.DanhSachNgayPhep ngayPhep, string maDonVi)
    {

        List<decimal> prKeyHOSO = new List<decimal>();
        int start = 0;
        int limit = 30;
        do
        {
            prKeyHOSO = (from t in dataContext.HOSOs
                         where t.MA_DONVI == maDonVi
                         select t.PR_KEY).Skip(start).Take(limit).ToList();
            foreach (var item in prKeyHOSO)
            {
                DAL.DanhSachNgayPhep fromdb = dataContext.DanhSachNgayPheps.Where(t => t.PrKeyHoSo == item && t.Nam == ngayPhep.Nam).FirstOrDefault();
                if (fromdb != null)
                {
                    fromdb.SoNgayPhepCongDonToiDaTrongThang = ngayPhep.SoNgayPhepCongDonToiDaTrongThang;
                    fromdb.SoNgayPhepNamNay = ngayPhep.SoNgayPhepNamNay;
                    fromdb.ThoiHanSuDungNgayPhepNamTruoc = ngayPhep.ThoiHanSuDungNgayPhepNamTruoc;
                    fromdb.ThoiHanSuDungNgayPhepDuocThem = ngayPhep.ThoiHanSuDungNgayPhepDuocThem;
                    fromdb.SoNgayPhepDuocThem = ngayPhep.SoNgayPhepDuocThem;
                }
                else
                {
                    DAL.DanhSachNgayPhep tmp = new DAL.DanhSachNgayPhep()
                    {
                        CreatedBy = ngayPhep.CreatedBy,
                        CreatedDate = DateTime.Now,
                        PrKeyHoSo = item,
                        Nam = ngayPhep.Nam,
                        SoNgayPhepCongDonToiDaTrongThang = ngayPhep.SoNgayPhepCongDonToiDaTrongThang,
                        SoNgayPhepNamNay = ngayPhep.SoNgayPhepNamNay,
                        ThoiHanSuDungNgayPhepNamTruoc = ngayPhep.ThoiHanSuDungNgayPhepNamTruoc,
                        ThoiHanSuDungNgayPhepDuocThem = ngayPhep.ThoiHanSuDungNgayPhepDuocThem,
                        SoNgayPhepDuocThem = ngayPhep.SoNgayPhepDuocThem,
                    };
                    dataContext.DanhSachNgayPheps.InsertOnSubmit(tmp);
                }
                Save();
            }
            start += limit;
        } while (prKeyHOSO.Count() != 0);
    }
    /// <summary>
    /// Thêm nhân viên vào bảng quản lý ngày phép
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <param name="thamNien">thâm niên được tính theo tháng</param>
    /// <param name="hinhThucLamViec"></param>
    /// <param name="maLoaiHopDong"></param>
    /// <param name="soNgayPhepDuocThem"></param>
    /// <param name="soNgayPhepNamNay"></param>
    /// <param name="tuDongTinhNgayPhep"></param>
    /// <param name="timNgayPhepNamTruoc"></param>
    public void AddAllEmployee(string maCBlist, string maDonVi, int thamNien, int hinhThucLamViec, string maLoaiHopDong,
                               float soNgayPhepDuocThem, float soNgayPhepNamNay, int year, int createdBy, bool tuDongTinhNgayPhep, bool timNgayPhepNamTruoc, bool ghiDeThongTinMoi,DateTime? HanNPNamTruoc)
    {
        //lấy các chuỗi ID
        System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
        string str = ",";
        foreach (var item in idList)
        {
            str += item + ",";
        }
        string[] param = { "@maCBList","@maDonVi","@thamNien","@maLoaiHopDong","@hinhThucLamViec","@soNgayPhepNamNay",
                             "@soNgayPhepDuocThem","@Year","@createdBy","@TimNapNgayPhepNamTruoc","@TuDongTimNgayPhepNamNay","@GhiDeThongTinMoi","@HanNPNamTruoc" };
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_ThemNhanVienVaoBangQuanLyNgayPhep", param, maCBlist, str, thamNien, maLoaiHopDong, hinhThucLamViec,
            soNgayPhepNamNay, soNgayPhepDuocThem, year, createdBy, timNgayPhepNamTruoc, tuDongTinhNgayPhep, ghiDeThongTinMoi, HanNPNamTruoc); 
    } 

    /// <summary>
    /// Lấy những nhân viên đã nghỉ mà vẫn còn lưu trữ trong bảng quản lý ngày phép
    /// </summary>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <param name="maDonVi"></param>
    /// <param name="notifyToDeleteAgain">1 = true, 0 = false, -1 = all</param>
    /// <param name="count"></param>
    /// <returns></returns>
    public IEnumerable<HoSoInfo> GetNhanVienDaNghi(int start, int limit, string maDonVi, int notifyToDeleteAgain, out int count)
    {
        System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
        string str = "%,";
        foreach (var item in idList)
        {
            str += item + ",";
        }
        str += "%";

        var rs = from t in dataContext.DanhSachNgayPheps
                 join dv in dataContext.DM_DONVIs
                 on t.HOSO.MA_DONVI equals dv.MA_DONVI
                 where t.HOSO.DA_NGHI == true && System.Data.Linq.SqlClient.SqlMethods.Like("%" + str + "%", "%," + dv.MA_DONVI + ",%") &&
                 ((t.NotifyToDeleteAgain == true && notifyToDeleteAgain == 1) || (t.NotifyToDeleteAgain == false && notifyToDeleteAgain == 0) || notifyToDeleteAgain == -1)
                 select new HoSoInfo
                 {
                     HOTEN = t.HOSO.HO_TEN,
                     MACB = t.HOSO.MA_CB,
                     PRKEY = t.PrKeyHoSo,
                     NGAYSINH = t.HOSO.NGAY_SINH,
                     PHONGBAN = dv.TEN_DONVI,
                     NGAYNGHI = t.HOSO.NGAY_NGHI,
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }
    /// <summary>
    /// Loại bỏ nhân viên đã nghỉ khỏi danh sách quản lý ngày phép
    /// delete = true : Xóa
    /// delete = false : không xóa và đánh dấu thuộc tính NotifyToDeleteAgain = notifyToDeleteAgain
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <param name="notifyToDeleteAgain"></param>
    /// <param name="delete"></param>
    public void RemoveNhanVienDaNghi(string maDonVi, bool notifyToDeleteAgain, bool delete)
    {
        System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
        string str = "%,";
        foreach (var item in idList)
        {
            str += item + ",";
        }
        str += "%";
        int start = 0;
        int limit = 30;
        List<DAL.DanhSachNgayPhep> rs = new List<DAL.DanhSachNgayPhep>();
        do
        {
            rs = (from t in dataContext.DanhSachNgayPheps
                  where t.HOSO.DA_NGHI == true && System.Data.Linq.SqlClient.SqlMethods.Like("%" + str + "%", "%," + t.HOSO.MA_DONVI + ",%")// &&
                  //  t.NotifyToDeleteAgain == notifyToDeleteAgain
                  select t).Skip(start).Take(limit).ToList();
            if (delete)
            {
                for (int i = 0; i < rs.Count(); i++)
                {
                    dataContext.DanhSachNgayPheps.DeleteOnSubmit(rs[i]);
                    Save();
                }
            }
            else
            {
                foreach (var item in rs)
                {
                    item.NotifyToDeleteAgain = notifyToDeleteAgain; //false
                    Save();
                }
            }
            start += limit;
        } while (rs.Count() != 0);
    }
    /// <summary>
    /// Loại bỏ 1 nhân viên ra khỏi bảng quản lý ngày phép
    /// </summary>
    /// <param name="ID">Khóa chính của bảng DanhSachNgayPhep</param>
    public void DeleteEmployee(int ID)
    {
        DAL.DanhSachNgayPhep existing = dataContext.DanhSachNgayPheps.Where(t => t.ID == ID).FirstOrDefault();
        dataContext.DanhSachNgayPheps.DeleteOnSubmit(existing);
        Save();
    }
}