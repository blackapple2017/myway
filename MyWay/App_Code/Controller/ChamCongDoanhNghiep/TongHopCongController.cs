using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Controller.ChamCongDoanhNghiep;
using System.Data;
using Ext.Net;

/// <summary>
/// Summary description for TongHopCongController
/// </summary>
public class TongHopCongController : LinqProvider 
{
    TimeController timeController = new TimeController();
    public TongHopCongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<DAL.TongHopCong> GetByIdDanhSachBangTongHopCong(int idDanhSachBangTongHopCong)
    {
        var rs = from t in dataContext.TongHopCongs
                 where t.IdDanhSachBangTongHopCong == idDanhSachBangTongHopCong
                 select t;
        return rs.ToList();
    }

    public void Insert(DAL.TongHopCong cong)
    {
        if (cong != null)
        {
            dataContext.TongHopCongs.InsertOnSubmit(cong);
            Save();
        }
    }

    public void Update(DAL.TongHopCong cong)
    {
        var tmp = dataContext.TongHopCongs.SingleOrDefault(t => t.ID == cong.ID);
        if (tmp != null)
        {
            tmp.GioCongDinhMuc = cong.GioCongDinhMuc;
            tmp.GioCongThucTe = cong.GioCongThucTe;
            tmp.SoPhutDiTre = cong.SoPhutDiTre;
            tmp.SoPhutLamThemNgayLe = cong.SoPhutLamThemNgayLe;
            tmp.SoPhutLamThemNgayNghi = cong.SoPhutLamThemNgayNghi;
            tmp.SoPhutLamThemNgayThuong = cong.SoPhutLamThemNgayThuong;
            tmp.SoPhutVeSom = cong.SoPhutVeSom;
            tmp.NghiPhep = cong.NghiPhep;
            tmp.NghiLe = cong.NghiLe;
            tmp.NghiBu = cong.NghiBu;
            tmp.NghiCheDo = cong.NghiCheDo;
            tmp.NghiKhongLuong = cong.NghiKhongLuong;
            tmp.SoLanQuenQuetThe = cong.SoLanQuenQuetThe;
            tmp.SoLanDiTre = cong.SoLanDiTre;
            tmp.SoLanVeSom = cong.SoLanVeSom;
            tmp.TongThoiGianLamThuaGio = cong.TongThoiGianLamThuaGio;
            tmp.ThongKeCaLamViec = cong.ThongKeCaLamViec;

            tmp.TongCaLamViecNgayThuong = cong.TongCaLamViecNgayThuong;
            tmp.TongCaLamViecNgayNghi = cong.TongCaLamViecNgayNghi;
            tmp.TongCaLamViecNgayLe = cong.TongCaLamViecNgayLe;
            tmp.ThoiGianRaNgoaiBiTru = cong.ThoiGianRaNgoaiBiTru;
            tmp.TongCaNghi = cong.TongCaNghi;

            Save();
        }
    }

    public void Delete(int id)
    {
        var rs = dataContext.TongHopCongs.SingleOrDefault(t => t.ID == id);
        if (rs != null)
        {
            dataContext.TongHopCongs.DeleteOnSubmit(rs);
            Save();
        }
    }

    public void DeleteByIdDanhDachBangTongHopCong(int idDanhSachBangTongHopCong)
    {
        var lists = GetByIdDanhSachBangTongHopCong(idDanhSachBangTongHopCong);
        if (lists.Count > 0)
        {
            dataContext.TongHopCongs.DeleteAllOnSubmit(lists);
            Save();
        }
    }

    public DAL.TongHopCong GetByMaCB(string maCB)
    {
        var rs = from t in dataContext.TongHopCongs
                 where t.MA_CB == maCB
                 select t;
        return rs.FirstOrDefault();
    }

    public DAL.TongHopCong GetByMaCBAndIdDanhSachBangTHC(string maCanBo, int idDanhSachBangTongHopCong)
    {
        var rs = from t in dataContext.TongHopCongs
                 where t.MA_CB == maCanBo && t.IdDanhSachBangTongHopCong == idDanhSachBangTongHopCong
                 select t;
        return rs.FirstOrDefault();
    }
     

    public List<TongHopCongTheoThangInfo> GetMaChamCongByIdDanhSachBangTHC(int idDanhSachBangTongHopCong)
    {
        var tmp = dataContext.DanhSachBangTongHopCongs.SingleOrDefault(t => t.ID == idDanhSachBangTongHopCong);
        string[] listDV = new DM_DONVIController().GetAllMaDonVi(tmp.MaDonVi).Split(',');
        var rs = from t in dataContext.HOSOs
                 join cong in dataContext.TongHopCongs on t.MA_CB equals cong.MA_CB into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where listDV.Contains(t.MA_DONVI) && (t.DA_NGHI == null || t.DA_NGHI == false)
                 select new TongHopCongTheoThangInfo
                 {
                     ID = t1.ID == null ? -1 : t1.ID,
                     MA_CB = t.MA_CB,
                     MaChamCong = t.ID_MAY_CHAMCONG,
                     GioCongDinhMuc = t1.GioCongDinhMuc == null ? 0 : t1.GioCongDinhMuc,
                     IdDanhSachTongHopCong = t1.IdDanhSachBangTongHopCong == null ? -1 : t1.IdDanhSachBangTongHopCong
                 };
        return rs.ToList();
    }

    /// <summary>
    /// Lấy thông tin tổng hợp công của một số cán bộ được chọn
    /// </summary>
    /// <param name="idDanhSachBangTongHopCong">Khóa ngoại bảng tổng hợp công</param>
    /// <param name="listIDTongHopCong">Danh sách các bản ghi được chọn</param>
    /// <returns></returns>
    public List<TongHopCongTheoThangInfo> GetMaChamCongByIdDanhSachBangTHC(int idDanhSachBangTongHopCong, List<int> listIDTongHopCong)
    {
        var rs = from t in dataContext.TongHopCongs
                 join hs in dataContext.HOSOs on t.MA_CB equals hs.MA_CB into tmp1
                 from t1 in tmp1.DefaultIfEmpty()
                 where t.IdDanhSachBangTongHopCong == idDanhSachBangTongHopCong
                    && listIDTongHopCong.Contains(t.ID)
                 select new TongHopCongTheoThangInfo
                 {
                     ID = t.ID,
                     MA_CB = t.MA_CB,
                     MaChamCong = t1.ID_MAY_CHAMCONG,
                     GioCongDinhMuc = t.GioCongDinhMuc
                 };
        return rs.ToList();
    }

    public DataTable GetByAll(int start, int limit, int thang, int nam, string searchKey, string maBoPhan, int userID, int menuID, out int count)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("ChamCong_CountTongHopCongTheoThang", "@Thang", "@Nam",
                            "@SearchKey", "@MaBoPhan", "@UserID", "@MenuID", thang, nam, searchKey, maBoPhan, userID, menuID).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_GetTongHopCongTheoThang", 
                            "@Start", "@Limit", "@Thang", "@Nam", "@SearchKey", "@MaBoPhan", "@UserID", "@MenuID", 
                            start, limit, thang, nam, searchKey, maBoPhan, userID, menuID);
    }

    #region tính toán các tham biến công
    /// <summary>
    /// Lấy số ngày nghỉ lễ, nghỉ phép, nghỉ chế độ...
    /// @Lê Anh
    /// </summary>
    /// <param name="maCB"></param>
    /// <returns></returns>
    public void GetNgayNghi(string maCB, DateTime FromDate, DateTime ToDate, ref string ngayLe,
                              ref double nghiLe, ref double nghiPhep, ref double nghiCheDo, ref double nghiBu, ref double nghiKhongLuong, string maDonVi)
    {
        try
        {
            KyHieuChamCongController kyHieuChamCong = new KyHieuChamCongController();
            List<string> dayList = new List<string>();
            string type = new HeThongController().GetValueByName(SystemConfigParameter.CHAMCONG_PHANCA_TYPE, maDonVi);

            // sử dụng bảng phân ca tháng
            int thang = -1;
            if (type == SystemConfigParameter.PHANCA_TYPE_THANG)
            {
                DAL.BangPhanCaThang phanCaThang = new DAL.BangPhanCaThang();
                DateTime day = FromDate;
                while (day <= ToDate)
                {
                    if (thang != day.Month)
                        phanCaThang = new BangPhanCaThangController().GetByMaCB(maCB, day.Month, day.Year);
                    if (phanCaThang != null)
                    {
                        dayList.Add(GetNameCharacter(phanCaThang, day.Day));
                    }
                    thang = day.Month;
                    day.AddDays(1);
                } 
            }
            #region comment
            //else if (type == SystemConfigParameter.PHANCA_TYPE_BOPHAN)  // sử dụng bảng phân ca theo bộ phận
            //{
            //DAL.ThietLapCaTheoBoPhan thietLap = new ThietLapCaTheoBoPhanController().GetThietLap(maCB);
            //int totalDay = DateTime.DaysInMonth(year, month);
            //for (int i = 1; i <= totalDay; i++)
            //{
            //    DayOfWeek dayOfWeek = new DateTime(year, month, i).DayOfWeek;
            //    switch (dayOfWeek)
            //    {
            //        // ngày thường
            //        case DayOfWeek.Monday:
            //        case DayOfWeek.Tuesday:
            //        case DayOfWeek.Wednesday:
            //        case DayOfWeek.Thursday:
            //        case DayOfWeek.Friday:
            //            dayList.Add(thietLap.MaCa);
            //            break;

            //        // ngày thứ 7
            //        case DayOfWeek.Saturday:
            //            dayList.Add(thietLap.MaCaThu7);
            //            break;

            //        // ngày chủ nhật
            //        case DayOfWeek.Sunday:
            //            dayList.Add(thietLap.MaCaChuNhat);
            //            break;
            //    }
            //}
            //}
            #endregion
            if (dayList.Count > 0)
            {
                DateTime day = FromDate;
                DonXinNghiController ctr = new DonXinNghiController();
                foreach (var item in dayList)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(item))
                        {
                            continue;
                        }
                        if (item.Contains(kyHieuChamCong.NghiLe))
                        {
                            nghiLe += 1;
                            ngayLe += day.Day + ",";
                        }
                        else if (item.Contains(kyHieuChamCong.NghiPhep))
                        {
                            DAL.DonXinNghi xinNghi = ctr.GetByHoanTatThuTuc(maCB, day);
                            if (xinNghi != null)
                                nghiPhep += 1; //phải viết thêm điều kiện dựa vào bảng ĐƠN XIN NGHỈ
                        }
                        else if (item.Contains(kyHieuChamCong.CheDo))
                        {
                            DAL.DonXinNghi xinNghi = ctr.GetByHoanTatThuTuc(maCB, day);
                            if (xinNghi != null)
                                nghiCheDo += 1;//phải viết thêm điều kiện dựa vào bảng ĐƠN XIN NGHỈ
                        }
                        else if (item.Contains(kyHieuChamCong.NghiBu))
                        {
                            nghiBu += 1;
                        }
                        else if (item.Contains(kyHieuChamCong.NghiKhongLuong))
                        {
                            nghiKhongLuong += 1;
                        }
                        day.AddDays(1);
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }
            else
            {
                List<DAL.DanhSachNgayLe> holidayList = new DanhSachNgayLeController().GetHolidayInMonth(FromDate, ToDate);
                nghiLe = holidayList.Count();
                foreach (var item in holidayList)
                {
                    ngayLe += item.Ngay + ",";
                }
            }

            if (!string.IsNullOrEmpty(ngayLe))
            {
                int pos = ngayLe.LastIndexOf(',');
                if (pos != -1)
                {
                    ngayLe = ngayLe.Remove(pos);
                }
            }

            //LẤY NGHỈ PHÉP, CHẾ ĐỘ
            //Lấy số ngày nghỉ phép của nhân viên
            //Dựa vào bảng duyệt đơn xin nghỉ, dựa vào bảng phân ca tháng
            //Sau khi lấy được số ngày nghỉ phép thì trừ vào bảng quản lý ngày phép
        }
        catch { }
    }

    private string GetNameCharacter(DAL.BangPhanCaThang bangPhanCa, int day)
    {
        switch (day)
        {
            case 1:
                return bangPhanCa.Ngay01;
            case 2:
                return bangPhanCa.Ngay02;
            case 3:
                return bangPhanCa.Ngay03;
            case 4:
                return bangPhanCa.Ngay04;
            case 5:
                return bangPhanCa.Ngay05;
            case 6:
                return bangPhanCa.Ngay06;
            case 7:
                return bangPhanCa.Ngay07;
            case 8:
                return bangPhanCa.Ngay08;
            case 9:
                return bangPhanCa.Ngay09;
            case 10:
                return bangPhanCa.Ngay10;
            case 11:
                return bangPhanCa.Ngay11;
            case 12:
                return bangPhanCa.Ngay12;
            case 13:
                return bangPhanCa.ngay13;
            case 14:
                return bangPhanCa.ngay14;
            case 15:
                return bangPhanCa.Ngay15;
            case 16:
                return bangPhanCa.Ngay16;
            case 17:
                return bangPhanCa.Ngay17;
            case 18:
                return bangPhanCa.Ngay18;
            case 19:
                return bangPhanCa.Ngay19;
            case 20:
                return bangPhanCa.Ngay20;
            case 21:
                return bangPhanCa.Ngay21;
            case 22:
                return bangPhanCa.Ngay22;
            case 23:
                return bangPhanCa.Ngay23;
            case 24:
                return bangPhanCa.Ngay24;
            case 25:
                return bangPhanCa.Ngay25;
            case 26:
                return bangPhanCa.Ngay26;
            case 27:
                return bangPhanCa.Ngay27;
            case 28:
                return bangPhanCa.Ngay28;
            case 29:
                return bangPhanCa.Ngay29;
            case 30:
                return bangPhanCa.Ngay30;
            case 31:
                return bangPhanCa.Ngay31;
            default:
                return "";
        }
    }

    /// <summary>
    /// Lấy số ngày nghỉ vô tổ chức của nhân viên
    /// @Đức Anh
    /// </summary>
    /// <param name="thongKeCaLamViec"></param>
    /// <param name="maCb"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <returns></returns>
    public double NghiVoToChuc(string thongKeCaLamViec, string maCb, int month, int year)
    {
        //thongKeCaLamViec là chuỗi có dạng Ca1=12,Ca2=15 ==> Tổng ca làm việc là 27
        //Nếu trong bảng phân ca tháng mà tổng ca
        return 0;
    }

    //public void GetCaLamViecTrongNgay1(string[] ngayLe, List<string> weekends, string maChamCong, DateTime day, DAL.DanhSachCa ca, ref double ngayCongDinhMuc,
    //    ref double ngayCongThucTe, ref int soPhutDiMuon, ref int soPhutVeSom, ref string thoiGianDenFirst, ref string thoiGianVeLast,
    //    ref float soPhutRaNgoaiTruGio, ref int soLanDiMuon, ref int soLanVeSom)
    //{
    //    string veLast = "", diFirst = "";

    //    // lấy danh sách giờ vào ra của cán bộ theo mã chấm công và ngày
    //    List<DAL.VaoRaCa> dsVaoRaCa = new VaoRaCaController().GetByMaChamCongAndDay(maChamCong, day);

    //    ngayCongDinhMuc = TinhNgayCongChuan(ngayLe, ca, weekends, day);

    //    for (int i = 0; i < dsVaoRaCa.Count; i++)
    //    {
    //        try
    //        {
    //            #region tham số chung
    //            int diTreFirst = 0, veSomLast = 0;
    //            #endregion

    //            int count = 0;
    //            if (timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa) > 0)
    //            {
    //                if (!string.IsNullOrEmpty(ca.NghiGiuaCa) && !string.IsNullOrEmpty(ca.VaoGiuaCa))  // ca có nghỉ giữa ca
    //                {
    //                    #region có nghỉ giữa ca
    //                    // int currI = i;
    //                    #region tính toán nửa ca đầu
    //                    // tính toán nửa ca đầu
    //                    int sl = 0;
    //                    int tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.NghiGiuaCa);
    //                    if (tgian > 0)
    //                    {
    //                        while (tgian > 0)
    //                        {
    //                            try
    //                            {
    //                                sl++;
    //                                double gioCongTT = 0;
    //                                int diMuon = 0, veSom = 0, diSom = 0, veMuon = 0;
    //                                TinhThoiGian(ca.GioVao, ca.NghiGiuaCa, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra,
    //                                        ref gioCongTT, ref diMuon, ref veSom, ref diSom, ref veMuon);

    //                                if (count == 0)
    //                                {
    //                                    diFirst = dsVaoRaCa[i].Vao;
    //                                    veLast = dsVaoRaCa[i].Ra;

    //                                    diTreFirst = diMuon;
    //                                    veSomLast = veSom;
    //                                }
    //                                else
    //                                {
    //                                    veLast = dsVaoRaCa[i].Ra;

    //                                    if (ca.RaNgoaiKhongBiTruGio == true)
    //                                    {
    //                                        int time = timeController.GetTotalTimeInMinutes(veLast, dsVaoRaCa[i].Vao);
    //                                        if (time > 0)
    //                                            soPhutRaNgoaiTruGio += time;
    //                                    }

    //                                    veSomLast = veSom;
    //                                }
    //                                count++;
    //                                i++;
    //                                if (i >= dsVaoRaCa.Count)
    //                                    break;
    //                                tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.NghiGiuaCa);
    //                            }
    //                            catch { }
    //                        }
    //                        if (sl == 0)
    //                            i--;
    //                        soPhutDiMuon += diTreFirst;
    //                        if (diTreFirst > 0)
    //                            soLanDiMuon++;
    //                        soPhutVeSom += veSomLast;
    //                        if (veSomLast > 0)
    //                            soLanVeSom++;
    //                    }
    //                    #endregion
    //                    //i++;
    //                    #region tính toán nửa ca sau
    //                    diTreFirst = 0; veSomLast = 0;
    //                    // tính toán nửa ca sau
    //                    sl = 0;
    //                    tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.NghiGiuaCa);
    //                    int tgianSau = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
    //                    if (tgian < 0 && tgianSau > 0)
    //                    {
    //                        //int count = 0;
    //                        while (tgian < 0 && tgianSau > 0)
    //                        {
    //                            try
    //                            {
    //                                sl++;
    //                                double gioCongTT = 0;
    //                                int diMuon = 0, veSom = 0, diSom = 0, veMuon = 0;
    //                                TinhThoiGian(ca.VaoGiuaCa, ca.GioRa, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra,
    //                                        ref gioCongTT, ref diMuon, ref veSom, ref diSom, ref veMuon);

    //                                if (count == 0)
    //                                {
    //                                    diFirst = dsVaoRaCa[i].Vao;
    //                                    veLast = dsVaoRaCa[i].Ra;

    //                                    diTreFirst = diMuon;
    //                                    veSomLast = veSom;
    //                                }
    //                                else
    //                                {
    //                                    veLast = dsVaoRaCa[i].Ra;

    //                                    if (ca.RaNgoaiKhongBiTruGio == true)
    //                                    {
    //                                        int time = timeController.GetTotalTimeInMinutes(veLast, dsVaoRaCa[i].Vao);
    //                                        if (time > 0)
    //                                            soPhutRaNgoaiTruGio += time;
    //                                    }
    //                                    veSomLast = veSom;
    //                                }
    //                                count++;
    //                                i++;
    //                                if (i >= dsVaoRaCa.Count)
    //                                    break;
    //                                tgianSau = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
    //                            }
    //                            catch { }
    //                        }
    //                        i--;
    //                        soPhutDiMuon += diTreFirst;
    //                        if (diTreFirst > 0)
    //                            soLanDiMuon++;
    //                        soPhutVeSom += veSomLast;
    //                        if (veSomLast > 0)
    //                            soLanVeSom++;
    //                    }
    //                    #endregion
    //                    #endregion
    //                }
    //                else // ca không có nghỉ giữa ca
    //                {
    //                    #region không có nghỉ giữa ca
    //                    int sl = 0;
    //                    int tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
    //                    if (tgian > 0)
    //                    {
    //                        //int count = 0;
    //                        while (tgian > 0)
    //                        {
    //                            try
    //                            {
    //                                sl++;
    //                                double gioCongTT = 0;
    //                                int diMuon = 0, veSom = 0, diSom = 0, veMuon = 0;
    //                                TinhThoiGian(ca.GioVao, ca.GioRa, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra,
    //                                        ref gioCongTT, ref diMuon, ref veSom, ref diSom, ref veMuon);

    //                                if (count == 0)
    //                                {
    //                                    diFirst = dsVaoRaCa[i].Vao;
    //                                    veLast = dsVaoRaCa[i].Ra;

    //                                    diTreFirst = diMuon;
    //                                    veSomLast = veSom;
    //                                }
    //                                else
    //                                {
    //                                    veLast = dsVaoRaCa[i].Ra;

    //                                    if (ca.RaNgoaiKhongBiTruGio == true)
    //                                    {
    //                                        int time = timeController.GetTotalTimeInMinutes(veLast, dsVaoRaCa[i].Vao);
    //                                        if (time > 0)
    //                                            soPhutRaNgoaiTruGio += time;
    //                                    }
    //                                    veSomLast = veSom;
    //                                }
    //                                count++;
    //                                i++;
    //                                if (i >= dsVaoRaCa.Count)
    //                                    break;
    //                                tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
    //                            }
    //                            catch
    //                            {
    //                                //i++;
    //                            }
    //                        }
    //                        i--;
    //                        soPhutDiMuon += diTreFirst;
    //                        if (diTreFirst > 0)
    //                            soLanDiMuon++;
    //                        soPhutVeSom += veSomLast;
    //                        if (veSomLast > 0)
    //                            soLanVeSom++;
    //                    }
    //                    #endregion
    //                }
    //            }
    //        }
    //        catch { }
    //    }

    //    thoiGianDenFirst = diFirst;
    //    thoiGianVeLast = veLast;

    //    if (string.IsNullOrEmpty(thoiGianDenFirst) && string.IsNullOrEmpty(thoiGianVeLast))
    //        return;

    //    if (ca.NghiGiuaCa != "" && ca.VaoGiuaCa != "")  // ngày thường
    //    {
    //        if (timeController.GetTotalTimeInMinutes(thoiGianDenFirst, ca.NghiGiuaCa) >= 0)
    //        {
    //            if (thoiGianVeLast != "" && timeController.GetTotalTimeInMinutes(thoiGianVeLast, ca.VaoGiuaCa) >= 0)
    //            {
    //                ngayCongThucTe += 0.5;
    //            }
    //            else
    //            {
    //                ngayCongThucTe += 1.0;
    //            }
    //        }
    //        else
    //        {
    //            if (thoiGianVeLast == "" || timeController.GetTotalTimeInMinutes(thoiGianVeLast, ca.GioRa) >= 0)
    //                ngayCongThucTe += 0.5;
    //        }
    //    }
    //    else // ngày thứ 7
    //    {
    //        if (timeController.GetTotalTimeInMinutes(thoiGianDenFirst, ca.GioRa) > 0)
    //            ngayCongThucTe += 0.5;
    //    }
    //}

    private double TinhNgayCongChuan(string[] ngayLe, DAL.DanhSachCa ca, List<string> listWeekends, DateTime day)
    {
        try
        {
            double ngayCongChuan = 0;
            string dayName = "";
            if (timeController.GetTotalTimeInMinutes(ca.GioVao, "12:00") > 0)   // ca làm việc sáng
            {
                dayName = GetNameDay(day, 0);
            }
            else if (timeController.GetTotalTimeInMinutes("12:00", ca.GioVao) > 0)  // ca làm việc chiều
            {
                dayName = GetNameDay(day, 1);
            }
            if (ngayLe.Contains(day.Day.ToString()))
            {
                ngayCongChuan = 0;
            }
            else if (listWeekends.Contains(dayName))
            {
                if (dayName.ToLower().Contains("afternoon") || dayName.ToLower().Contains("morning"))
                    ngayCongChuan = 0.5;
                else
                    ngayCongChuan = 0;
            }

            return ngayCongChuan;
        }
        catch
        {
            return 0;
        }
    }

    /// <summary>
    /// Lấy ca làm việc của một ngày cụ thể và số phút làm việc của ngày đó
    /// @daibx
    /// </summary>
    /// <param name="kyHieuChamCong"></param>
    /// <param name="day"></param>
    /// <param name="soPhutLamViecThucTe"></param>
    /// <returns></returns>
    public string GetCaLamViecTrongNgay(string[] ngayLe, List<string> weekends, string maChamCong, DateTime day, DAL.DanhSachCa ca, ref Dictionary<string, int> dics,
            ref double gioCongDinhMuc, ref double gioCongThucTe, ref int soPhutDiTre, ref int soPhutVeSom, ref int soPhutDiSom, ref int soPhutVeMuon,
            ref int soPhutLamThemNgayThuong, ref int soPhutLamThemNgayNghi, ref int soPhutLamThemNgayLe,
            ref int soLanQuenQuetThe, ref int soLanDiTre, ref int soLanVeSom, ref int soPhutLamThuaGio,
            ref float soCaLamViecNgayThuong, ref float soCaLamViecNgayNghi, ref float soCaLamViecNgayLe,
            ref float thoiGianRaNgoaiBiTruGio, ref float tongCaNghi,
            ref string thoiGianDenFirst, ref string thoiGianVeLast)
    {
        string maCa = "", veLast = "", diFirst = "";
        #region tính số phút làm việc thực tế
        // tính giờ công định mức
        gioCongDinhMuc += ca.TongGio == null ? 0 : ca.TongGio.Value;

        //// lấy dữ liệu giờ vào ra ca của cán bộ theo mã chấm công và ngày
        List<DAL.VaoRaCa> dsVaoRaCa = new VaoRaCaController().GetByMaChamCongAndDay(maChamCong, day);

        #region thống kê ca làm việc (số lượng từng ca, số ca ngày thường, ngày nghỉ, ngày lễ)
        if (dsVaoRaCa.Count > 0)
        {
            //// thống kê ca làm việc
            //if (dsVaoRaCa.Count > 1 || (dsVaoRaCa.Count == 1 && dsVaoRaCa[1].Vao != "" && dsVaoRaCa[1].Ra != ""))
            //{
            //    CreateDanhSachThongKeCaLamViec(dics, ca);

            //    #region tham biến
            //    TinhSoCaLamViec(ngayLe, weekends, day, ca, ref soCaLamViecNgayThuong, ref soCaLamViecNgayNghi, ref soCaLamViecNgayLe);
            //    #endregion
            //}
        }
        #endregion

        for (int i = 0; i < dsVaoRaCa.Count; i++)
        {
            try
            {
                #region tham số chung
                int diTreFirst = 0, diSomFirst = 0, veSomLast = 0, veMuonLast = 0;
                #endregion

                int count = 0;
                //if (timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa) > 0)
                //{
                //    if (!string.IsNullOrEmpty(ca.NghiGiuaCa) && !string.IsNullOrEmpty(ca.VaoGiuaCa))  // ca có nghỉ giữa ca
                //    {
                //        #region có nghỉ giữa ca
                //        // int currI = i;
                //        #region tính toán nửa ca đầu
                //        // tính toán nửa ca đầu
                //        int sl = 0;
                //        int tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.NghiGiuaCa);
                //        if (tgian > 0)
                //        {
                //            while (tgian > 0)
                //            {
                //                try
                //                {
                //                    sl++;
                //                    double gioCongTT = 0;
                //                    int diMuon = 0, veSom = 0, diSom = 0, veMuon = 0;
                //                    TinhThoiGian(ca.GioVao, ca.NghiGiuaCa, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra,
                //                            ref gioCongTT, ref diMuon, ref veSom, ref diSom, ref veMuon);

                //                    if (count == 0)
                //                    {
                //                        if (ca.RaNgoaiKhongBiTruGio == false)
                //                        {
                //                            gioCongThucTe += gioCongTT;
                //                        }

                //                        diFirst = dsVaoRaCa[i].Vao;
                //                        veLast = dsVaoRaCa[i].Ra;

                //                        diTreFirst = diMuon;
                //                        diSomFirst = diSom;
                //                        veMuonLast = veMuon;
                //                        veSomLast = veSom;
                //                    }
                //                    else
                //                    {
                //                        veLast = dsVaoRaCa[i].Ra;

                //                        if (ca.RaNgoaiKhongBiTruGio == false)
                //                        {
                //                            gioCongThucTe += gioCongTT;
                //                        }
                //                        else
                //                        {
                //                            int time = timeController.GetTotalTimeInMinutes(veLast, dsVaoRaCa[i].Vao);
                //                            if (time > 0)
                //                                thoiGianRaNgoaiBiTruGio += time;
                //                        }

                //                        veMuonLast = veMuon;
                //                        veSomLast = veSom;
                //                    }
                //                    count++;
                //                    i++;
                //                    if (i >= dsVaoRaCa.Count)
                //                        break;
                //                    tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.NghiGiuaCa);
                //                }
                //                catch { }
                //            }
                //            if (sl == 0)
                //                i--;
                //            if (ca.RaNgoaiKhongBiTruGio == true)
                //            {
                //                gioCongThucTe += timeController.GetTotalTimeInMinutes(diFirst, veLast);
                //            }
                //            soPhutDiTre += diTreFirst;
                //            if (diTreFirst > 0)
                //                soLanDiTre++;
                //            soPhutDiSom += diSomFirst;
                //            soPhutVeSom += veSomLast;
                //            if (veSomLast > 0)
                //                soLanVeSom++;
                //            soPhutVeMuon += veMuonLast;
                //        }
                //        if (sl == 0)
                //            tongCaNghi += (float)0.5;
                //        #endregion
                //        //i++;
                //        #region tính toán nửa ca sau
                //        diTreFirst = 0; diSomFirst = 0; veMuonLast = 0; veSomLast = 0;
                //        // tính toán nửa ca sau
                //        sl = 0;
                //        tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.NghiGiuaCa);
                //        int tgianSau = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
                //        if (tgian < 0 && tgianSau > 0)
                //        {
                //            //int count = 0;
                //            while (tgian < 0 && tgianSau > 0)
                //            {
                //                try
                //                {
                //                    sl++;
                //                    double gioCongTT = 0;
                //                    int diMuon = 0, veSom = 0, diSom = 0, veMuon = 0;
                //                    TinhThoiGian(ca.VaoGiuaCa, ca.GioRa, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra,
                //                            ref gioCongTT, ref diMuon, ref veSom, ref diSom, ref veMuon);

                //                    if (count == 0)
                //                    {
                //                        if (ca.RaNgoaiKhongBiTruGio == false)
                //                        {
                //                            gioCongThucTe += gioCongTT;
                //                        }

                //                        diFirst = dsVaoRaCa[i].Vao;
                //                        veLast = dsVaoRaCa[i].Ra;

                //                        diTreFirst = diMuon;
                //                        diSomFirst = diSom;
                //                        veMuonLast = veMuon;
                //                        veSomLast = veSom;
                //                    }
                //                    else
                //                    {
                //                        veLast = dsVaoRaCa[i].Ra;

                //                        if (ca.RaNgoaiKhongBiTruGio == false)
                //                        {
                //                            gioCongThucTe += gioCongTT;
                //                        }
                //                        else
                //                        {
                //                            int time = timeController.GetTotalTimeInMinutes(veLast, dsVaoRaCa[i].Vao);
                //                            if (time > 0)
                //                                thoiGianRaNgoaiBiTruGio += time;
                //                        }

                //                        veMuonLast = veMuon;
                //                        veSomLast = veSom;
                //                    }
                //                    count++;
                //                    i++;
                //                    if (i >= dsVaoRaCa.Count)
                //                        break;
                //                    tgianSau = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
                //                }
                //                catch { }
                //            }
                //            i--;
                //            if (ca.RaNgoaiKhongBiTruGio == true)
                //            {
                //                gioCongThucTe += timeController.GetTotalTimeInMinutes(diFirst, veLast);
                //            }
                //            soPhutDiTre += diTreFirst;
                //            if (diTreFirst > 0)
                //                soLanDiTre++;
                //            soPhutDiSom += diSomFirst;
                //            soPhutVeSom += veSomLast;
                //            if (veSomLast > 0)
                //                soLanVeSom++;
                //            soPhutVeMuon += veMuonLast;
                //        }
                //        if (tgian < 0 && sl == 0)
                //            tongCaNghi += (float)0.5;
                //        #endregion
                //        #endregion
                //    }
                //    else // ca không có nghỉ giữa ca
                //    {
                //        #region không có nghỉ giữa ca
                //        int sl = 0;
                //        int tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
                //        if (tgian > 0)
                //        {
                //            //int count = 0;
                //            while (tgian > 0)
                //            {
                //                try
                //                {
                //                    sl++;
                //                    double gioCongTT = 0;
                //                    int diMuon = 0, veSom = 0, diSom = 0, veMuon = 0;
                //                    TinhThoiGian(ca.GioVao, ca.GioRa, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra,
                //                            ref gioCongTT, ref diMuon, ref veSom, ref diSom, ref veMuon);

                //                    if (count == 0)
                //                    {
                //                        if (ca.RaNgoaiKhongBiTruGio == false)
                //                        {
                //                            gioCongThucTe += gioCongTT;
                //                        }

                //                        diFirst = dsVaoRaCa[i].Vao;
                //                        veLast = dsVaoRaCa[i].Ra;

                //                        diTreFirst = diMuon;
                //                        diSomFirst = diSom;
                //                        veMuonLast = veMuon;
                //                        veSomLast = veSom;
                //                    }
                //                    else
                //                    {
                //                        veLast = dsVaoRaCa[i].Ra;

                //                        if (ca.RaNgoaiKhongBiTruGio == false)
                //                        {
                //                            gioCongThucTe += gioCongTT;
                //                        }
                //                        else
                //                        {
                //                            int time = timeController.GetTotalTimeInMinutes(veLast, dsVaoRaCa[i].Vao);
                //                            if (time > 0)
                //                                thoiGianRaNgoaiBiTruGio += time;
                //                        }

                //                        veMuonLast = veMuon;
                //                        veSomLast = veSom;
                //                    }
                //                    count++;
                //                    i++;
                //                    if (i >= dsVaoRaCa.Count)
                //                        break;
                //                    tgian = timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, ca.GioRa);
                //                }
                //                catch
                //                {
                //                    //i++;
                //                }
                //            }
                //            i--;
                //            if (ca.RaNgoaiKhongBiTruGio == true)
                //            {
                //                gioCongThucTe += timeController.GetTotalTimeInMinutes(diFirst, veLast);
                //            }
                //            soPhutDiTre += diTreFirst;
                //            if (diTreFirst > 0)
                //                soLanDiTre++;
                //            soPhutDiSom += diSomFirst;
                //            soPhutVeSom += veSomLast;
                //            if (veSomLast > 0)
                //                soLanVeSom++;
                //            soPhutVeMuon += veMuonLast;
                //        }
                //        if (sl == 0)
                //            tongCaNghi += (float)1.0;
                //        #endregion
                //    }
                //}
                //else
                //{
                //    gioCongThucTe += timeController.GetTotalTimeInMinutes(dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra);
                //}
                soPhutLamThuaGio += soPhutDiSom + soPhutVeMuon;

                #region tính số phút làm thêm giờ
                int lamThemNgayThuong = 0, lamThemNgayNghi = 0, lamThemNgayLe = 0, quenQuetThe = 0, lamThuaGio = 0;

                //if (ca != null && soPhutVeMuon > 0)
                //    GetSoPhutLamThemGio(ngayLe, weekends, maChamCong, day, ca, dsVaoRaCa[i].Vao, dsVaoRaCa[i].Ra, ref lamThemNgayThuong, ref lamThemNgayNghi,
                //        ref quenQuetThe, ref lamThemNgayLe, ref lamThuaGio);

                soPhutLamThemNgayThuong += lamThemNgayThuong;
                soPhutLamThemNgayNghi += lamThemNgayNghi;
                soPhutLamThemNgayLe += lamThemNgayLe;
                soLanQuenQuetThe += quenQuetThe;
                soPhutLamThuaGio += lamThuaGio;

                #endregion

                // số lần quên quẹt thẻ
          //      GetQuenQuetThe(ca, dsVaoRaCa[i], ref soLanQuenQuetThe);
            }
            catch { }
        }

        thoiGianDenFirst = diFirst;
        thoiGianVeLast = veLast;
        #endregion

        return maCa;
    }

    #region các hàm bổ trợ cho GetCaLamViecTrongNgay
      
    /// <summary>
    /// Tính toán các tham số cho một cặp giờ vào ra
    /// @daibx
    /// </summary>
    /// <param name="gioVaoCa">giờ quy định vào ca làm việc</param>
    /// <param name="gioRaCa">giờ quy định ra ca làm việc</param>
    /// <param name="vao">giờ vào của cán bộ</param>
    /// <param name="ra">giờ ra của cán bộ</param>
    private void TinhThoiGian(string gioVaoCa, string gioRaCa, string vao, string ra,
            ref double gioCongThucTe, ref int soPhutDiTre, ref int soPhutVeSom, ref int soPhutDiSom, ref int soPhutVeMuon)
    {
        try
        {
            // giờ công thực tế
            gioCongThucTe = timeController.GetTotalTimeInMinutes(vao, ra);

            #region tính số phút đi sớm, đi muộn
            // đi sớm / muộn
            int tgian = timeController.GetTotalTimeInMinutes(vao, gioVaoCa);
            if (tgian > 0)      // giờ vào < giờ vào ca (đi sớm)
            {
                soPhutDiSom = tgian;
            }
            else // giờ vào > giờ vào ca (đi muộn)
            {
                soPhutDiTre = 0 - tgian;
            }
            #endregion

            #region tính số phút về sớm, về muộn
            // về sớm / muộn
            tgian = timeController.GetTotalTimeInMinutes(ra, gioRaCa);
            if (tgian > 0)      // giờ ra ca > giờ ra (về sớm)
            {
                soPhutVeSom = tgian;
            }
            else // giờ ra ca < giờ ra (về muộn)
            {
                soPhutVeMuon = 0 - tgian;
            }
            #endregion
        }
        catch (Exception ex)
        {
            ExtMessage.Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// Tính số ca làm việc ngày thường, ngày nghỉ, ngày lễ
    /// @daibx
    /// </summary>
    /// <param name="listWeekends">Danh sách các ngày cuối tuần</param>
    /// <param name="day">Ngày cần tính</param>
    /// <param name="ca">Ca cần tính</param>
    private void TinhSoCaLamViec(string[] ngayLe, List<string> listWeekends, DateTime day, DAL.DanhSachCa ca,
            ref float soCaLamViecNgayThuong, ref float soCaLamViecNgayNghi, ref float soCaLamViecNgayLe)
    {
        try
        {
            string dayName = "";
            if (timeController.GetTotalTimeInMinutes(ca.GioVao, "12:00") > 0)   // ca làm việc sáng
            {
                dayName = GetNameDay(day, 0);
            }
            else if (timeController.GetTotalTimeInMinutes("12:00", ca.GioVao) > 0)  // ca làm việc chiều
            {
                dayName = GetNameDay(day, 1);
            }

            if (ngayLe.Contains(day.Day.ToString()))
            {
                soCaLamViecNgayLe++;
            }
            else if (listWeekends.Contains(dayName))
            {
                soCaLamViecNgayNghi++;
            }
            else
            {
                soCaLamViecNgayThuong++;
            }
        }
        catch { }
    }

    /// <summary>
    /// Kiểm tra thời gian vào thuộc ca nào và thời gian đó là vào đầu ca hay kết thúc nghỉ giữa ca
    /// </summary>
    /// <param name="dsCa">Danh sách ca làm việc</param>
    /// <param name="time">thời gian cần kiểm tra</param>
    /// <param name="ca">mã ca trả về</param>
    /// <returns><b>0</b> nếu là giờ vào đầu ca, <b>1</b> nếu là giờ kết thúc nghỉ giữa ca</returns>
    private int GetCaByTimeIn(List<DAL.DanhSachCa> dsCa, string time, out DAL.DanhSachCa ca)
    {
        foreach (var item in dsCa)
        {
            if (timeController.CheckRangeTime(time, item.BatDauQuetTheLan1, item.KetThucQuetTheLan1))
            {
                ca = item;
                return 0;
            }
            if (timeController.CheckRangeTime(time, item.BatDauQuetTheLan3, item.KetThucQuetTheLan3))
            {
                ca = item;
                return 1;
            }
        }
        ca = null;
        return -1;
    }

    /// <summary>
    /// Kiểm tra thời gian ra thuộc ca nào và thời gian đó là bắt đầu nghỉ giữa ca hay nghỉ kết thúc ca
    /// </summary>
    /// <param name="dsCa">Danh sách ca làm việc</param>
    /// <param name="time">thời gian cần kiểm tra</param>
    /// <param name="ca">mã ca trả về</param>
    /// <returns><b>0</b> nếu là giờ bắt đầu nghỉ giữa ca, <b>1</b> nếu là giờ nghỉ kết thúc ca</returns>
    private int GetCaByTimeOut(List<DAL.DanhSachCa> dsCa, string time, out DAL.DanhSachCa ca)
    {
        foreach (var item in dsCa)
        {
            if (timeController.CheckRangeTime(time, item.BatDauQuetTheLan2, item.KetThucQuetTheLan2))
            {
                ca = item;
                return 0;
            }
            if (timeController.CheckRangeTime(time, item.BatDauQuetTheLan4, item.KetThucQuetTheLan4))
            {
                ca = item;
                return 1;
            }
        }
        ca = null;
        return -1;
    }

    /// <summary>
    /// lấy tên của ngày hiện tại theo định dạng ngày nghỉ
    /// </summary>
    /// <param name="day">ngày cần lấy tên</param>
    /// <param name="sa"><b>0</b> nếu là buổi sáng, <b>1</b> nếu là buổi chiều</param>
    /// <returns></returns>
    private string GetNameDay(DateTime day, int sa)
    {
        string name = "";
        if (sa == 0)
            name = "Morning";
        else if (sa == 1)
            name = "Afternoon";
        switch (day.DayOfWeek)
        {
            case DayOfWeek.Friday:
                name = "Friday" + name;
                break;
            case DayOfWeek.Saturday:
                name = "Saturday" + name;
                break;
            case DayOfWeek.Sunday:
                name = "Sunday";
                break;
            default:
                name = "";
                break;
        }
        return name;
    }

    /// <summary>
    /// Kiểm tra 1 ngày có nằm trong danh sách ngày đăng ký làm thêm giờ không
    /// </summary>
    /// <param name="dkys">Danh sách các đăng ký làm thêm giờ</param>
    /// <param name="day">Ngày cần kiểm tra</param>
    /// <returns><b>true</b> nếu có trong danh sách, <b>false</b> nếu không có trong danh sách</returns>
    private bool CheckContainDay(List<DAL.DangKyLamThemGio> dkys, DateTime day)
    {
        foreach (var item in dkys)
        {
            if (item.TuNgay < day && day < item.DenNgay)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Tính số phút làm thêm giờ (làm thêm ngày thường, ngày nghỉ, ngày lễ)
    /// việc tính toán dựa vào bảng DangKyLamThemGio
    /// </summary>
    /// <param name="maChamCong">mã chấm công của cán bộ</param>
    /// <param name="day">ngày đang xét</param>
    /// <param name="maCa">mã ca làm việc cán bộ đăng ký</param>
    /// <param name="soPhutLamThemNgayThuong">số phút làm thêm ngày thường</param>
    /// <param name="soPhutLamThemNgayNghi">số phút làm thêm ngày nghỉ</param>
    /// <param name="soPhutLamThemNgayLe">số phút làm thêm ngày lễ</param>
    private void GetSoPhutLamThemGio(string[] ngayLe, List<string> weekends, string maChamCong, DateTime day, DAL.DanhSachCa dsCa, string vaoLast, string raLast, ref int soPhutLamThemNgayThuong,
        ref int soPhutLamThemNgayNghi, ref int soLanQuenQuetThe, ref int soPhutLamThemNgayLe, ref int soPhutLamThuaGio)
    {
        DAL.HOSO hs = new HoSoController().GetByMaChamCong(maChamCong);
        if (hs == null)
            return;

        string dayName = "", start = "", end = "";
        List<DAL.DangKyLamThemGio> dky = new DangKyLamThemGioController().GetByMaCanBoAndFrkeyCa(hs.MA_CB, dsCa.ID);
        if (dky == null || raLast == "" || vaoLast == "")
            return;
        if (CheckContainDay(dky, day) == false)
            return;
        foreach (var item in dky)
        {
            if (item.TuNgay < day && day < item.DenNgay)
            {
                if (timeController.GetTotalTimeInMinutes(item.GioBatDauSauCa, "12:00") > 0 &&
                    timeController.GetTotalTimeInMinutes("12:00", item.GioKetThucSauCa) < 0)     // giờ đăng ký làm thêm là buổi sáng
                {
                    dayName = GetNameDay(day, 0);
                }
                else if (timeController.GetTotalTimeInMinutes(item.GioBatDauSauCa, "12:00") < 0 &&
                    timeController.GetTotalTimeInMinutes("12:00", item.GioKetThucSauCa) > 0)     // giờ đăng ký làm thêm là buổi chiều
                {
                    dayName = GetNameDay(day, 1);
                }
            }
        }

        #region các tham số làm thêm giờ
        foreach (var item in dky)
        {
            if (item.TuNgay < day && day < item.DenNgay)
            {
                if (timeController.GetTotalTimeInMinutes(item.GioBatDauSauCa, vaoLast) > 0)
                    start = vaoLast;
                else
                    start = item.GioBatDauSauCa;
                if (timeController.GetTotalTimeInMinutes(raLast, item.GioKetThucSauCa) > 0)
                    end = raLast;
                else
                    end = item.GioKetThucSauCa;
            }
        }

        int time = timeController.GetTotalTimeInMinutes(start, end);
        #endregion

        if (start != "" && end != "")
        {
            if (ngayLe.Contains(day.Day.ToString()))
            {
                if (time > 0)
                {
                    soPhutLamThemNgayLe += time;
                }
            }
            else if (weekends.Contains(dayName))
            {
                //soPhutLamThemNgayNghi += timeController.GetTotalTimeInMinutes(dky.GioBatDauSauCa, dky.GioKetThucSauCa);
                if (time > 0)
                {
                    soPhutLamThemNgayNghi += time;
                    //soPhutLamThuaGio -= time;
                }
            }
            else
            {
                if (time > 0)
                {
                    soPhutLamThemNgayThuong += time;
                    //soPhutLamThuaGio -= time;
                }
            }
        }
        //soPhutLamThemNgayLe = 0;
    }

    /// <summary>
    /// Lấy danh sách các ngày nghỉ lễ được cấu hình trong tháng
    /// </summary>
    /// <param name="month">tháng cần lấy</param>
    /// <param name="year">năm cần lấy</param>
    /// <returns>danh sách các ngày trong tháng</returns>
    public List<int> GetVacationDayInMonth(int month, int year)
    {
        List<int> lists = new List<int>();
        var rs = from t in dataContext.DanhSachNgayLes
                 select t;
        foreach (var item in rs)
        {
            if (item.AmLich == false)
            {
                if (item.Thang == month)
                    lists.Add(item.Thang);
            }
            else
            {

            }
        }
        return lists;
    }

    private void GetInformationInRange(string firstTime, string lastTime, DAL.VaoRaCa vaoRa, ref int soPhutLamViecThucTe, ref int soPhutLamThemNgayThuong,
                                        ref int soPhutLamThemNgayNghi, ref int soPhutLamThemNgayLe, ref int soPhutDiTre, ref int soPhutVeSom)
    {
        TimeController timeController = new TimeController();
         
    }
    #endregion

    /// <summary>
    /// Thống kê tổng số ca làm việc
    /// @daibx
    /// </summary>
    /// <param name="dicThongKe">danh sách lưu thông tin các ca dưới dạng MaCa1 -> a lần    MaCa2 -> b lần</param>
    /// <returns>trả về chuỗi có dạng : MaCa1=12,MaCa2=18</returns>
    public string GetThongKeCaLamViec(Dictionary<string, int> dicThongKe)
    {
        //Dựa vào bảng ChamCong.VaoRaCa và một số bảng liên quan khác như bảng DanhSachCa để tính toán
        //Kết quả trả về sẽ có dạng : MaCa1=12,MaCa2=18
        //Có nghĩa là trong 1 tháng người này làm 12 ca 1 và 18 ca 2
        string thongKeCaLamViec = string.Empty;
        foreach (var item in dicThongKe)
        {
            thongKeCaLamViec += item.Key + "=" + item.Value + ",";
        }
        if (!string.IsNullOrEmpty(thongKeCaLamViec))
        {
            int position = thongKeCaLamViec.LastIndexOf(',');
            thongKeCaLamViec = thongKeCaLamViec.Remove(position);
        }
        return thongKeCaLamViec;
    }

    public void CreateDanhSachThongKeCaLamViec(Dictionary<string, int> dictionary, DAL.DanhSachCa ca)
    {
        if (dictionary.ContainsKey(ca.MaCa))
        {
            dictionary[ca.MaCa] += 1;
        }
        else
        {
            dictionary.Add(ca.MaCa, 1);
        }
    }

    /// <summary>
    /// Lấy tổng số giờ làm việc định mức
    /// @daibx
    /// </summary>
    /// <param name="thongKeCaLamViec"></param>
    /// <returns></returns>
    public float GetGioCongDinhMuc(string thongKeCaLamViec)
    {
        //Lấy tổng số giờ làm việc định mức
        //Ví dụ truyền vào Ca1=12,Ca2=18 thì ta sẽ phải tính xem tổng số giờ làm việc là bao nhiêu
        //ví dụ ca1 làm 8 tiếng, ca2 làm 6 tiếng thì giờ công định mức sẽ là 12 * 8 + 18 * 6
        return 0;
    }

    /// <summary>
    /// Lấy số ca làm việc thực tế trong tháng
    /// @daibx
    /// </summary>
    /// <param name="thongKeCaLamViec"></param>
    /// <returns></returns>
    public float GetSoCaThucTe(string thongKeCaLamViec)
    {
        //ví dụ truyền vào Ca1=12,Ca2=18 thì số ca thực tế = 12 + 18 = 30
        float tongSoCaLamViecThucTe = 0;
        if (string.IsNullOrEmpty(thongKeCaLamViec))
            return 0;
        string[] lists = thongKeCaLamViec.Split(',');
        foreach (var item in lists)
        {
            if (!string.IsNullOrEmpty(item) && item.IndexOf('=') != -1)
            {
                string[] arr = item.Split('=');
                float tmp = float.Parse("0" + arr[1]);
                tongSoCaLamViecThucTe += tmp;
            }
        }
        return tongSoCaLamViecThucTe;
    }
    #endregion
      
    /// <summary>
    /// Khóa bảng tổng hợp công
    /// @daibx
    /// </summary>
    /// <param name="id">Mã bảng tổng hợp công</param>
    /// <param name="locked"><b>true</b> nếu muốn khóa bảng tổng hợp công, <b>false</b> nếu muốn mở bảng tổng hợp công</param>
    public void Lock(int id, bool locked)
    {
        var tmp = dataContext.DanhSachBangTongHopCongs.SingleOrDefault(t => t.ID == id);
        if (tmp != null)
        {
            tmp.Lock = locked;
            Save();
        }
    }
}