using DataController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class TuCapNhatController : LinqProvider
{
    public TuCapNhatController()
    {
    }
    /// <summary>
    /// Lấy tổng số bản ghi theo trạng thái
    /// </summary>
    /// <param name="filterStatus"></param>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public int GetCount(string filterStatus, string maDonVi)
    {
        System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
        string str = "%,";
        foreach (var item in idList)
        {
            str += item + ",";
        }
        str += "%";
        return (from t in dataContext.HOSO_TUCAPNHATs
                where (t.TrangThaiDuyet == filterStatus || string.IsNullOrEmpty(filterStatus)) &&
                System.Data.Linq.SqlClient.SqlMethods.Like("%" + str + "%", "%," + t.MA_DONVI + ",%")
                select t.PR_KEY).Count();

    }
    /// <summary>
    /// Update vào thông tin hồ sơ với những trường được chọn
    /// </summary>
    /// <param name="filterStatus"></param>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public void UpdateDuyetThongTinHoSo(decimal prkeyhoso, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateDuyetThongTinHoSo", "@PrkeyHoso", "@field", "@newValue", prkeyhoso, field, value);
    }
    public DataTable GetAll(int start, int limit, string searchKey, string filterStatus, out int count, string maDonVi)
    {
        DataTable table = DataHandler.GetInstance().ExecuteDataTable("hoso_DanhSachNhanSuCanDuyet", "@MaDonVi", "@SearchKey", "@filterStatus", "@start", "@limit",
                                                                                                    maDonVi, searchKey, filterStatus, start, limit);
        count = int.Parse("0" + DataHandler.GetInstance().ExecuteScalar("hoso_CountDanhSachNhanSuCanDuyet", "@MaDonVi", "@SearchKey", "@filterStatus",
                                                       maDonVi, searchKey, filterStatus).ToString());
        return table; 
    }

    /// <summary>
    /// Lấy thông tin dựa vào user login vào
    /// </summary>
    /// <param name="userID"></param>
    /// <returns></returns>
    public DAL.HOSO_TUCAPNHAT GetByUserId(int userID)
    {
        return dataContext.HOSO_TUCAPNHATs.Where(t => t.UserID == userID).FirstOrDefault();
    }

    public DAL.HOSO_TUCAPNHAT GetByPrKey(decimal prKey)
    {
        return dataContext.HOSO_TUCAPNHATs.Where(t => t.PR_KEY == prKey).FirstOrDefault();
    }

    public void Add(DAL.HOSO_TUCAPNHAT obj)
    {
        dataContext.HOSO_TUCAPNHATs.InsertOnSubmit(obj);
        Save();
    }

    /// <summary>
    /// Duyệt và chuyển thông tin sang form hồ sơ
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="prKeyNguoiDuyet"></param>
    /// <returns>trả về khóa chính của bản ghi mới</returns>
    public decimal CopyToHoSo(int userID, decimal prKeyNguoiDuyet, string thongTinThem, string maDV)
    {
        bool isInsert = false;
        DAL.HOSO hs = dataContext.HOSOs.Where(t => t.UserID == userID).FirstOrDefault();
        DAL.HOSO_TUCAPNHAT tuCapNhat = GetByUserId(userID);
        if (hs == null)
        {
            hs = new DAL.HOSO();
            isInsert = true;
            hs.MA_CB = new HoSoController().GenerateMaCB(maDV);
        }
        hs.BI_DANH = tuCapNhat.BI_DANH;
        hs.CAN_NANG = tuCapNhat.CAN_NANG;
        hs.CHIEU_CAO = tuCapNhat.CHIEU_CAO;
        hs.ChucVuCongDoan = tuCapNhat.ChucVuCongDoan;
        hs.DaThamGiaQuanDoi = tuCapNhat.DaThamGiaQuanDoi;
        hs.DI_DONG = tuCapNhat.DI_DONG;
        hs.DIA_CHI_LH = tuCapNhat.DIA_CHI_LH;
        hs.DiaChiNguoiLienHe = tuCapNhat.DiaChiNguoiLienHe;
        hs.EMAIL = tuCapNhat.EMAIL;
        hs.EMAIL_RIENG = tuCapNhat.EMAIL_RIENG;
        hs.DT_CQUAN = tuCapNhat.DT_CQUAN;
        hs.DT_NHA = tuCapNhat.DT_NHA;
        hs.EmailNguoiLienHe = tuCapNhat.EmailNguoiLienHe;
        hs.HangThuongTat = tuCapNhat.HangThuongTat;
        hs.HinhThucThuongTat = tuCapNhat.HinhThucThuongTat;
        hs.HO_CB = tuCapNhat.HO_CB;
        hs.HO_KHAU = tuCapNhat.HO_KHAU;
        hs.HO_TEN = tuCapNhat.HO_TEN;
        hs.LaDangVien = tuCapNhat.LaDangVien;
        hs.LaThuongBinh = tuCapNhat.LaThuongBinh;
        hs.MA_CAPBAC_QDOI = tuCapNhat.MA_CAPBAC_QDOI;

        hs.MA_CHUCVU = tuCapNhat.MA_CHUCVU;
        hs.MA_CHUCVU_DANG = tuCapNhat.MA_CHUCVU_DANG;
        hs.MA_CHUCVU_DOAN = tuCapNhat.MA_CHUCVU_DOAN;
        hs.MA_CHUCVU_QDOI = tuCapNhat.MA_CHUCVU_QDOI;
        hs.MA_CHUYENNGANH = tuCapNhat.MA_CHUYENNGANH;
        hs.MA_CONGTRINH = tuCapNhat.MA_CONGTRINH;
        hs.MA_CONGVIEC = tuCapNhat.MA_CONGVIEC;
        hs.MA_DANTOC = tuCapNhat.MA_DANTOC;
        hs.MA_DONVI = tuCapNhat.MA_DONVI;
        hs.MA_GIOITINH = tuCapNhat.MA_GIOITINH;
        hs.MA_HT_TUYENDUNG = tuCapNhat.MA_HT_TUYENDUNG;
        hs.MA_LOAI_CS = tuCapNhat.MA_LOAI_CS;
        hs.MA_LOAI_HDONG = tuCapNhat.MA_LOAI_HDONG;
        hs.MA_NGACH = tuCapNhat.MA_NGACH;
        hs.MA_NGOAINGU = tuCapNhat.MA_NGOAINGU;
        hs.MA_NOI_KCB = tuCapNhat.MA_NOI_KCB;
        hs.MA_NOICAP_BHXH = tuCapNhat.MA_NOICAP_BHXH;
        hs.MA_NOICAP_CMND = tuCapNhat.MA_NOICAP_CMND;
        hs.MA_NOICAP_HOCHIEU = tuCapNhat.MA_NOICAP_HOCHIEU;
        hs.MA_NUOC = tuCapNhat.MA_NUOC;
        hs.MA_TD_CHINHTRI = tuCapNhat.MA_TD_CHINHTRI;
        hs.MA_TD_QLKT = tuCapNhat.MA_TD_QLKT;
        hs.MA_TD_QUANLY = tuCapNhat.MA_TD_QUANLY;
        hs.MA_TD_VANHOA = tuCapNhat.MA_TD_VANHOA;
        hs.MA_TINHOC = tuCapNhat.MA_TINHOC;
        hs.MA_TINHTHANH = tuCapNhat.MA_TINHTHANH;
        hs.MA_TONGIAO = tuCapNhat.MA_TONGIAO;
        hs.MA_TP_BANTHAN = tuCapNhat.MA_TP_BANTHAN;
        hs.MA_TP_GIADINH = tuCapNhat.MA_TP_GIADINH;
        hs.MA_TRINHDO = tuCapNhat.MA_TRINHDO;
        hs.MA_XEPLOAI = tuCapNhat.MA_XEPLOAI;
        hs.MA_TRUONG_DAOTAO = tuCapNhat.MA_TRUONG_DAOTAO;
        hs.MA_TT_HN = tuCapNhat.MA_TT_HN;
        hs.MA_TT_SUCKHOE = tuCapNhat.MA_TT_SUCKHOE;
        hs.NHOM_MAU = tuCapNhat.NHOM_MAU;
        hs.MST_CANHAN = tuCapNhat.MST_CANHAN;
        hs.UU_DIEM = tuCapNhat.UU_DIEM;
        hs.TYLE_DONG_BH = tuCapNhat.TYLE_DONG_BH;
        hs.TEN_CB = tuCapNhat.TEN_CB;
        hs.TAI_NH = tuCapNhat.TAI_NH;
        hs.SoThuongTat = tuCapNhat.SoThuongTat;
        hs.SOTHE_DANG = tuCapNhat.SOTHE_DANG;
        hs.SOTHE_BHYT = tuCapNhat.SOTHE_BHYT;
        hs.SOTHE_BHXH = tuCapNhat.SOTHE_BHXH;
        hs.SOHIEU_CCVC = tuCapNhat.SOHIEU_CCVC;
        hs.SO_THICH = tuCapNhat.SO_THICH;
        hs.SO_TAI_KHOAN = tuCapNhat.SO_TAI_KHOAN;
        hs.SO_HOCHIEU = tuCapNhat.SO_HOCHIEU;
        hs.SO_CMND = tuCapNhat.SO_CMND;
        hs.SDTNguoiLienHe = tuCapNhat.SDTNguoiLienHe;
        hs.QueQuan = tuCapNhat.QueQuan;
        hs.QuanHeVoiCanBo = tuCapNhat.QuanHeVoiCanBo;
        hs.PHOTO = tuCapNhat.PHOTO;
        hs.NoiSinhHoatDang = tuCapNhat.NoiSinhHoatDang;
        hs.NOI_SINH = tuCapNhat.NOI_SINH;
        hs.NOI_KETNAP_DOAN = tuCapNhat.NOI_KETNAP_DOAN;
        hs.NOI_KETNAP_DANG = tuCapNhat.NOI_KETNAP_DANG;
        hs.NHUOC_DIEM = tuCapNhat.NHUOC_DIEM;
        hs.NguoiLienHe = tuCapNhat.NguoiLienHe;
        hs.NgayVaoCongDoan = tuCapNhat.NgayVaoCongDoan;
        hs.NAM_TN = tuCapNhat.NAM_TN;
        hs.NGAYVAO_QDOI = tuCapNhat.NGAYVAO_QDOI;
        hs.NGAY_BN_CHUCVU = tuCapNhat.NGAY_BN_CHUCVU;
        hs.NGAY_BN_NGACH = tuCapNhat.NGAY_BN_NGACH;
        hs.NGAY_CTHUC_DANG = tuCapNhat.NGAY_CTHUC_DANG;
        hs.NGAY_DONGBH = tuCapNhat.NGAY_DONGBH;
        hs.NGAY_HETHAN_BHYT = tuCapNhat.NGAY_HETHAN_BHYT;
        hs.NGAY_HETHAN_HOCHIEU = tuCapNhat.NGAY_HETHAN_HOCHIEU;
        hs.NGAY_KTBH = tuCapNhat.NGAY_KTBH;
        hs.NGAY_SINH = tuCapNhat.NGAY_SINH;
        hs.NGAY_TGCM = tuCapNhat.NGAY_TGCM;
        hs.NGAY_TUYEN_CHINHTHUC = tuCapNhat.NGAY_TUYEN_CHINHTHUC;
        hs.NGAY_TUYEN_DTIEN = tuCapNhat.NGAY_TUYEN_DTIEN;
        hs.NGAYCAP_BHXH = tuCapNhat.NGAYCAP_BHXH;
        hs.NGAYCAP_CMND = tuCapNhat.NGAYCAP_CMND;
        hs.NGAYCAP_HOCHIEU = tuCapNhat.NGAYCAP_HOCHIEU;
        hs.NGAYVAO_DOAN = tuCapNhat.NGAYVAO_DOAN;
        hs.NGAYRA_QDOI = tuCapNhat.NGAYRA_QDOI;
        hs.NGAYVAO_DANG = tuCapNhat.NGAYVAO_DANG;
        hs.DATE_CREATE = DateTime.Now;
        hs.NgayDuyet = DateTime.Now;
        hs.UserID = userID;
        hs.PrkeyNguoiDuyet = prKeyNguoiDuyet;
        hs.HinhThucLamViec = tuCapNhat.HinhThucLamViec;
        if (isInsert)
        {
            dataContext.HOSOs.InsertOnSubmit(hs);
        }
        tuCapNhat.TrangThaiDuyet = "DaDuyet";
        Save();

        string[] storeList = thongTinThem.Split(',');
        if (string.IsNullOrEmpty(thongTinThem))
        {
            thongTinThem = "";
        }
        storeList = new string[] { 
          "DuyetHoSoQuanHeGiaDinh",  
          "DuyetHoSoDeTai",
          "DuyetHoSoKhaNang",
          "DuyetHoSoKhenThuong",
          "DuyetHoSoKyLuat",
          "DuyetHoSoQuaTrinhCongTac",
          "DuyetHoSoQuaTrinhDieuChuyen",
          "DuyetHoSoTaiSan",
          "DuyetHoSoTepTinDinhKem",
          "DuyetHoSoQuaTrinhHocTap",
          "DuyetHoSoKinhNghiemLamViec",
          "DuyetHoSoBangCapChungChi",
          "DuyetHoSoTaiNanLaoDong"
        };
        foreach (var item in storeList)
        {
            if (!string.IsNullOrEmpty(item))
            {
                DataHandler.GetInstance().ExecuteNonQuery(item.Trim(), "@userid", userID);
            }
        }
        return hs.PR_KEY;
    }

    public void KhongDuyet(int userID, string lyDoKhongDuyet, decimal prKeyNguoiDuyet)
    {
        DAL.HOSO_TUCAPNHAT tmp = GetByPrKey(userID);
        if (tmp!=null)
        {
            tmp.LyDoKhongDuyet = lyDoKhongDuyet;
            tmp.NgayDuyet = DateTime.Now;
            tmp.TrangThaiDuyet = "KhongDuyet";
            tmp.PrkeyNguoiDuyet = prKeyNguoiDuyet;
            Save();
        } 
    }
    /// <summary>
    /// Xóa bản ghi
    /// </summary>
    /// <param name="userID"></param>
    public void Delete(string selectedID)
    { 
        DataHandler.GetInstance().ExecuteNonQuery("hoso_DeleteHoSoTuCapNhat", "@SelectedID", selectedID);
    }

    public string GenerateMaCB(string maDV)
    {
        string prefix = new HeThongController().GetValueByName(SystemConfigParameter.PREFIX, maDV);
        string sl = new HeThongController().GetValueByName(SystemConfigParameter.NUMBER_OF_CHARACTER, maDV);
        if (string.IsNullOrEmpty(prefix))
            prefix = "NV";
        int number = string.IsNullOrEmpty(sl) ? 5 : int.Parse(sl);
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("GenerateSelfEmployeeCode", "@Prefix", "@Number", prefix, number);
        string oldMaCB = table.Rows.Count == 0 ? "00000000000000000000" : table.Rows[0]["MA_CB"].ToString();
        long oldNumber = long.Parse("" + oldMaCB.Substring(prefix.Length));
        oldNumber++;
        string newMaCB = "00000000000000000000" + oldNumber;
        newMaCB = prefix + newMaCB.Substring(newMaCB.Length - number);
        return newMaCB;
    }
}
