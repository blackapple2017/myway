using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using System.Resources;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Data;
using DataController;
using DevExpress.XtraReports.UI.PivotGrid;
using DevExpress.XtraPivotGrid;
// huynhnd
public partial class Modules_Report_BaoCao_Main : WebBase
{
    int idBangTHC = 0;
    string maDonVi = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.ReportViewer.Report = CreateReport();
    }
    public DevExpress.XtraReports.UI.XtraReport CreateReport()
    {
        ReportFilter rpFilter = Session["ReportFilter"] as ReportFilter;
        #region Xử lý phần in báo cáo trong chế độ, biến động bảo hiểm
        if (!string.IsNullOrEmpty(Request.QueryString.Get("IdBcBaoHiem")))
        {
            string v = Request.QueryString.Get("IdBcBaoHiem");

            ReportFilter RP = new ReportFilter();
            RP.SessionDepartment = Session["MaDonVi"].ToString();
            RP.WhereClause = Request.QueryString.Get("IdBcBaoHiem");
            var cd = new BHDauPhieuController().GetByIdDauPhieu(Convert.ToInt32(Request.QueryString.Get("IdBcBaoHiem")));
            Session.Add("rp", RP);

            if (cd.LoaiChungTu == "D02-TS")
            {
                return DanhSachLaoDongDieuChinhDongBhxhBhytBhtn();
            }
            if (cd.LoaiChungTu == "C66a-HD")
            {
                return DanhSachNguoiLaoDongDeNghiHuongCheDoOmDau();
            }
            if (cd.LoaiChungTu == "C67a-HD")
            {
                return DanhSachNguoiLaoDongDeNghiHuongCheDoThaiSan();
            }
            if (cd.LoaiChungTu == "C68a-HD")
            {
                return NguoiLaoDongHuongTroCapNghiDsphskSauOmDau();
            }
            if (cd.LoaiChungTu == "C69a-HD")
            {
                return NguoiLaoDongHuongTroCapNghiDsphskSauThaiSan();
            }
            if (cd.LoaiChungTu == "C70a-HD")
            {
                return NguoiLaoDongHuongTroCapNghiDsphskSauThuongTat();
            }
        }
        // chế độ phát sinh mẫu in 
        if (!string.IsNullOrEmpty(Request.QueryString.Get("IdChiTietBH")))
        {
            ReportFilter RP = new ReportFilter { WhereClause = Request.QueryString.Get("IdChiTietBH"), SessionDepartment = Session["MaDonVi"].ToString() };
            Session.Add("rp", RP);
            return NghiViecHuongBHXH();
        }
        if (!string.IsNullOrEmpty(Request.QueryString.Get("IdChiTietBH1")))
        {
            ReportFilter RP = new ReportFilter { WhereClause = Request.QueryString.Get("IdChiTietBH1"), SessionDepartment = Session["MaDonVi"].ToString() };
            Session.Add("rp", RP);
            return ChamSocConOmDau();
        }
        if (!string.IsNullOrEmpty(Request.QueryString.Get("IdChiTietBH2")))
        {
            ReportFilter RP = new ReportFilter { WhereClause = Request.QueryString.Get("IdChiTietBH2"), SessionDepartment = Session["MaDonVi"].ToString() };
            Session.Add("rp", RP);
            return DeNghiHuongTroCapThaiSan();
        }
        #endregion

        string type = Request.QueryString["type"];
        if (!string.IsNullOrEmpty(Request.QueryString["IdBangTHC"]))
            idBangTHC = int.Parse(Request.QueryString["IdBangTHC"]);
        maDonVi = Request.QueryString["MaDonVi"];
        switch (Request.QueryString["type"])
        {
            case "":
                return DanhMucCBCNV();
            #region case tài sản
            case "DanhSachTaiSanCapPhatChoNhanVien":
                return DanhSachTaiSanCapPhatChoNhanVien();
            case "BaoCaoDanhSachTaiSanTheoPhongBan":
                return BaoCaoDanhSachTaiSanTheoPhongBan();
            #endregion
            case "sntrongthang":
                return BirthdayOfEmployees();
            case "BaoCaoLuyKeTongHopTienLuongTheoPhongBan":
                return LuyKeLuongTheoPhongBan();
            case "BangQuyetToanChiTietSoThueThuNhapCuaCaNhanNguoiLaoDong":
                return BaoCaoChiTietThueThuNhapCaNhan();
            case "DanhSachCanBoVaQuyTienLuongTrichNopBhxh":
                return TrichNopBHXH();
            case "TongHopTinhHinhLaoDongQuyLuongSoPhaiNopBhxh":
                return TongHopTinhHinhLaoDongQuyLuongSoPhaiNopBhxh();
            case "BaoCaoSoLaoDongTheoHinhThucTiepNhan":
                return BaoCaoSoLaoDongTheoHinhThucTiepNhan();
            #region case tuyển dụng
            case "BaoCaoKetQuaPhongVanCuaUngVien":
                return BaoCaoKetQuaPhongVanCuaUngVien();
            case "BaoCaoDanhSachUngVienTrungTuyen":
                return BaoCaoUngVienTrungTuyen();
            case "BaoCaoThongKeTyLeUngVien":
                return BaoCaoThongKeTyLeUngVien();
            case "ReportHoSoUngVienFromLichHenPV":
                return CVChiTietUngVienFromLichPhongVan();
            case "BaoCaoDotTuyenDung":
                return DMKeHoachTuyenDung();
            case "BaoCaoChiTiet1DotTuyenDung":
                return BaoCaoChiTietMotDotTuyenDung();
            case "KeHoachTuyenDung":
                return DMKeHoachTuyenDung();
            case "DanhSachTiepNhan":
                return DanhSachTiepNhanThuViec();
            case "BaoCaoDanhSachDenTrongTuyenDung":
                return BaoCaoDanhSachDenTuyenDung();
            case "BaoCaoKhoDuTruHoSoTuyenDung":
                return BaoCaoKhoDuTruTuyenDung();
            case "BaoCaoHoSoUngVienChiTiet":
                return BaoCaoHoSoUngVienChiTiet();
            // Austfeed
            case "BaoCaoTuyenDungTrongNamCuaCacDonViThanhVien":
                return BaoCaoTuyenDungTrongNamCuaCacDonViThanhVien();
            case "BaoCaoNhanVienTuyenDungNam":
                return BaoCaoNhanVienTuyenDungNam();


            #endregion
            #region case Đào tạo
            case "BaoCaoThongTinChiTiet1KhoaDaoTao":
                return BaoCaoThongTinChiTiet1KhoaDaoTao();
            case "BaoCaoDanhSachNhanVienThamGiaDaoTao":
                return BaoCaoDanhSachNhanVienThamGiaDaoTao();
            case "BaoCaoDanhSachKeHoachDaoTao":
                return BaoCaoDanhSachKhoaDaoTao();
            case "BaoCaoDanhSachCacKhoaDaoTao":
                return BaoCaoDanhSachCacKhoaDaoTao();
            #endregion
            #region case nhân sự
            case "BaoCaoTangMoiToanCongTy":
                return BaoCaoTangMoiToanCongTy();
            case "BaoCaoBienDongNhanSu":
                return BaoCaoBienDongNhanSu();
            case "TongHopNhanSuToanCongTy":
                return TongHopNhanSuToanCongTy(); //worldgame
            case "DanhSachNhanVien": //Báo cáo nhanh danh sách nhân viên ở form Hồ Sơ
                return DanhSachNhanVien();
            case "QuyetDinhThoiViec":
                return QuyetDinhThoiViec();
            case "DanhSachCanBoHetHanBoNhiem":
                return DanhSachCanBoHetHanBoNhiem();
            case "DanhSachCanBoDaBoNhiem":
                return DanhSachCanBoDaBoNhiem();
            case "DanhSachNhanVienTheoLoaiHopDong":
                return DanhSachNhanVienTheoLoaiHopDong();
            case "BaoCaoLaoDongBinhQuanNam":
                return BaoCaoLaoDongBinhQuanNam();
            case "BaoCaoNgayPhepCbnv":
                return DanhSachNgayPhepConLaiTrongNam();
            case "BaoCaoThamNienCongTac":
                return BaoCaoCanThamNienCongTac();
            case "BaoCaoDanhSachCanBoHetHanHopDong":
                return BaoCaoDanhSachNhanVienHetHanHopDong();
            case "BaoCaoDanhSachCanBoHetHanHopDongTrongThang":
                return BaoCaoDanhSachNhanVienHetHanHopDongTrongThang();
            case "BaoCaoDanhSachCanBoDieuChuyenTrongThang":
                return BaoCaoDanhSachNhanVienDieuChuyenTrongThang();
            case "BaoCaoDanhSachQuanNhanTrongCty":
                return BaoCaoCanBoQuanNhan();
            case "DanhSachCanBoCoConEmNhanQuaTrungThu":
                return BaoCaoDanhSachNhanVienDuocTangQuaTrungThu();
            case "BaoCaoDanhSachNhanVienDuocTangQuaMong8Thang3":
                return BaoCaoDanhSachNhanVienDuocTangQuaMong8Thang3();
            case "BaoCaoDanhSachNguoiPhuThuoc":
                return BaoCaoDanhSachNguoiPhuThuoc();
            case "BaoCaoDanhSachHopDongCuaNhanVien":
                return BaoCaoDanhSachHopDongCuaNhanVien();
            case "BaoCaoDanhSachCanBoHuongChinhSach":
                return BaoCaoCanBoHuongChinhSach();
            case "BaoCaoDanhSachCanBoDuocNangLuong":
                return BaoCaoCanBoDuocNangLuong();
            case "HopDongThuViec":
                return HopDongThuViec();
            case "HopDongLaoDong":
                return HopDongLaoDong();
            case "ThoaThuanHocViec":
                return ThoaThuanHocViec();
            case "BaoCaoDanhSachCanBoChuaCoSoBhxh":
                return BaoCaoNhanVienChuaCoSoBHXH();
            case "BaoCaoDanhSachCanBoThamGiaBhxh":
                return BaoCaoDanhSachCanBoThamGiaBhxh();
            case "BaoCaoDanhSachCanBoChuaCoTheBhyt":
                return BaoCaoNhanVienChuaCoSoBHYT();
            case "BaoCaoCanBoNhanVienTheoPhongBan":
                return BaoCaoNhanVienTheoPhongBan();
            case "BangKeDanhSachCanBoCongChuc":
                return BangKeDanhSachCanBoCongChuc();
            case "BaoCaoCanBoDoanVienTrongCongTy":
                return BaoCaoDanhSachCanBoDoanTrongCongTy();
            case "BaoCaoCanBoDangVienTrongCongTy":
                return BaoCaoDanhSachCanBoDangVienTrongCongTy();
            case "BaoCaoDanhSachCanBoSinhNhatTrongThang":
                return BirthdayOfEmployees();
            case "BaoCaoDanhSachCanBoNhanVienThuViec":
                return BaoCaoNhanVienThuViec();
            case "BaoCaoDanhSachCanBoKhenThuongTrongThang":
                return BaoCaoKhenThuong();
            case "BaoCaoDanhSachNhanVienThamGiaCongDoan":
                return BaoCaoDanhSachNhanVienThamGiaCongDoan();
            case "BaoCaoDienBienLuongCuaNhanVien":
                return BaoCaoDienBienLuongCuaNhanVien();
            case "BaoCaoDanhSachTaiKhoanNganHangCuaNhanVien":
                return BaoCaoDanhSachTaiKhoanNhanVien();
            case "DanhSachCanBoNhanVienTiepNhanChinhThuc":
                return DanhSachCanBoNhanVienTiepNhanChinhThuc();
            case "BaoCaoSoLaoDong":
                return BaoCaoSoLaoDong();
            case "BaoCaoDanhSachNhanVienThayDoiChucVu":
                return BaoCaoNhanVienThayDoiChucVu();
            case "BaoCaoNhanVienCoNguoiGiamTruGiaCanh":
                return BaoCaoNhanVienCoNguoiGiamTruGiaCanh();
            case "BaoCaoDanhSachNhanVienTheoGioiTinh":
                return BaoCaoDanhSachNhanVienTheoGioiTinh();
            case "BaoCaoNhanVienKyHopDongThoiVu":
                return BaoCaoNhanVienKyHopDongThoiVu();
            case "DanhSachCanBoCongNhanVienCongTy":
                return DanhSachCanBoCongNhanVienCongTy();
            case "BaoCaoDanhSachNhanVienCuaCacDonViThanhVien":
                return BaoCaoDanhSachNhanVienCuaCacDonViThanhVien();
            case "GiayDeNghiThuyenChuyenNhanSu":
                return PhieuDeNghiThuyenChuyenNhanSu();
            case "BaoCaoDanhSachCanBoCoMaSoThueCaNhan":
                return BaoCaoMaSoThueCaNhan();
            case "BaoCaoThongTinNguoiThanNhanQuaTrungThu":
                return BaoCaoThongTinNguoiThanNhanQuaTrungThu();
            case "BaoCaoDienBienLuongGanNhatCuaNhanVien":
                return BaoCaoDienBienLuongGanNhatCuaNhanVien();
            #endregion
            #region case luong
            case "BaoCaoThanhToanTienLuong":
                return BangThanhToanLuongThang();
            case "BaoCaoChiPhiTheoNhanVien":
                return BaoCaoChiPhiTheoNhanVien();
            case "BangTongHopThuNhapChiuThueVaThueDaNopCbnvTrongNam":
                return BangTongHopThuNhapChiuThueVaThueDaNopCBNTrongNam();
            case "DanhSachNhanLuongBangTienMat":
                return DanhSachNhanLuongTienMat();
            case "DanhSachChuyenKhoanNganHang":
                return DanhSachChuyenKhoanNganHangTienLuong();
            case "DanhSachTraLuongTheoKy":
                return DanhSachTraLuongTheoKy();
            case "BaoCaoThanhToanTamUng":
                return BaoCaoThanhToanTamUng();
            case "QuyetDinhLuong":
                return BaoCaoQuyetDinhLuong();
            case "DanhSachPhatHaThuong":
                return DanhSachPhatHaThuong();
            case "DanhSachKhenThuong":
                return DanhSachKhenThuongTienLuong();
            case "BangChamCongThang":
                return BangChamCongThang();
            //Ausstfeed
            case "BaoCaoTongHopThuTienBaoLanhCuaNhanVienTrongNam":
                return BaoCaoTongHopThuTienBaoLanhCuaNhanVienTrongNam();
            case "DanhSachLuongChuyenKhoanTheoThangLan1":
                return DanhSachLuongChuyenKhoanTheoThangLan1();
            case "DanhSachLuongChuyenKhoanTheoThangLan2":
                return DanhSachLuongChuyenKhoanTheoThangLan2();
            case "DanhSachLuongNghiViecChuyenKhoanThang":
                return DanhSachLuongNghiViecChuyenKhoanThang();
            case "DanhSachLuongKinhDoanhChuyenKhoanTheoThangLan1":
                return DanhSachLuongKinhDoanhChuyenKhoanTheoThangLan1();
            case "DanhSachLuongKinhDoanhChuyenKhoanTheoThangLan2":
                return DanhSachLuongKinhDoanhChuyenKhoanTheoThangLan2();
            case "DanhSachLuongKinhDoanhNghiViecChuyenKhoanThang":
                return DanhSachLuongKinhDoanhNghiViecChuyenKhoanThang();
            case "BaoCaoChiPhiCacBoPhanTrongThang":
                return BaoCaoChiPhiCacBoPhanTrongThang();
            case "BangThanhToanTienLuongTheoThang":
                return BangThanhToanTienLuongTheoThang();
            case "DanhSachLuongLinhTienMatTheoThangLan1":
                return DanhSachLuongLinhTienMatTheoThangLan1();
            case "DanhSachLuongLinhTienMatTheoThangLan2":
                return DanhSachLuongLinhTienMatTheoThangLan2();
            case "DanhSachLuongKinhDoanhLinhTienMatTheoThangLan1":
                return DanhSachLuongKinhDoanhLinhTienMatTheoThangLan1();
            case "DanhSachLuongKinhDoanhLinhTienMatTheoThangLan2":
                return DanhSachLuongKinhDoanhLinhTienMatTheoThangLan2();
            case "PhieuLuongKinhDoanh":
                return PhieuLuongKinhDoanh();
            case "BangTongHopLuongVanPhong":
                return BangTongHopLuongVanPhong();
            case "BangTongHopLuongKinhDoanh":
                return BangTongHopLuongKinhDoanh();
            case "BaoCaoKhoanSanXuat":
                return BaoCaoKhoanSanXuat();

            #endregion
            #region case chấm công
            case "TongHopTienCom":
                return TienChamCongCom();
            case "LichPhanCaThang":
                return LichPhanCaThang();
            case "BaoCaoNhanVienQuenQuetThe":
                return BaoCaoNhanVienQuenQuetThe();
            case "BaoCaoTheoDoiNhanVienNghiChamCong":
                return BaoCaoTheoDoiNhanVienNghiChamCong();
            case "DanhSachNhanVienCoMatTrongNgay":
                return DanhSachNhanVienCoMatTrongNgay();
            case "BaoCaoTongHopLamThemGio":
                return BaoCaoTongHopLamThemGio();
            case "BaoCaoBangChamCongThang":
                return BaoCaoBangChamCongThang();// chưa được
            case "BaoCaoNgayCong":
                return BaoCaoNgayCong();
            case "BanDangKyNghi":
                return BanDangKyNghi();
            case "BangDangKyLamBu":
                return BangDangKyLamBu();
            case "BangTheoDoiDiMuonVeSomTheoNgay":
                return BangTheoDoiDiMuonVeSomTheoNgay();
            case "BangTheoDoiDiMuonVeSom":
                return BangTheoDoiDiMuonVeSom();
            case "BaoCaoDanhSachNhanVienDangKyLamThemGio":
                return BaoCaoDanhSachNhanVienDangKyLamThemGio();
            case "BaoCaoTinhHinhNghiPhep":
                return BaoCaoTinhHinhNghiPhep();
            case "BaoCaoNhanVienNghiDaiNgay":
                return BaoCaoNhanVienNghiDaiNgay();
            case "BaoCaoTongHopCongCuoiThang":
                return BaoCaoTongHopCongCuoiThang();
            case "BaoCaoNhanVienDiCongTacTrongThang":
                return BaoCaoNhanVienDiCongTacTrongThang();//bat dau Austfeed
            case "BaoCaoNhanVienNghiOmTrongThang":
                return BaoCaoNhanVienNghiOmTrongThang();
            case "BaoCaoNhanVienNghiKhongLyDoTrongThang":
                return BaoCaoNhanVienNghiKhongLyDoTrongThang();
            case "BaoCaoTongHopSoNgayNghiPhepCuaNhanVienTrongNam":
                return BaoCaoTongHopSoNgayNghiPhepCuaNhanVienTrongNam();
            case "BaoCaoTongHopSoNgayNghiKhongLyDoCuaNhanVienTrongNam":
                return BaoCaoTongHopSoNgayNghiKhongLyDoCuaNhanVienTrongNam();
            case "BaoCaoTongHopSoNgayNghiViecRiengNghiOmCuaNhanVienTrongNam":
                return BaoCaoTongHopSoNgayNghiViecRiengNghiOmCuaNhanVienTrongNam();
            case "BaoCaoNhanVienNghiCheDoTrongThang":
                return BaoCaoNhanVienNghiCheDoTrongThang();
            case "BaoCaoNhanVienLamNgayLeTetTrongThang":
                return BaoCaoNhanVienLamNgayLeTetTrongThang();
            case "BaoCaoNhanVienNghiViecRiengTrongThang":
                return BaoCaoNhanVienNghiViecRiengTrongThang();
            case "BaoCaoLamThemGio":
                return BaoCaoLamThemGio();
            case "BaoCaoCBNVLamTheoCa":
                return BaoCaoCBNVLamCa();
            case "BaoCaoThuTucDauVao":
                return BaoCaoThuTucDauVao();
            #endregion
            #region Case đánh giá
            case "BaoCaoDanhSachXepLoaiCanBoNhanVien":
                return BaoCaoDanhSachXepLoaiCBNV();
            case "TheoDoiTongHopTienDoDanhGiaTheoDonVi":
                return TheoDoiTongHopTienDoDanhGiaTheoDonVi();
            case "DanhGiaChamTienDoSoVoiQuyDinh":
                return DanhGiaChamTienDoSoVoiQuyDinh();
            case "BangTongDiemKetQuaDanhGia":
                return BangTongDiemKetQuaDanhGia();
            case "BangTheoDoiKetQuaThucHienCongViecCaNhan":
                return BangTheoDoiKetQuaThucHienCongViecCaNhan();
            case "BangTongHopDiemKetQuaDanhGiaCaNam":
                return BangTongHopDiemKetQuaDanhGiaCaNam();

            #region austfeed
            case "BangDanhGiaCongViecTheoNam":
                return BangDanhGiaCongViecTheoNam();
            case "BangTuDanhGiaCuaNhanVienTheoNam":
                return BangTuDanhGiaCuaNhanVienTheoNam();
            #endregion
            #endregion
            #region case bảo hiểm
            case "D02TsDanhSachLaoDongDieuChinhDongBhxhBhytBhtn":
                return DanhSachLaoDongDieuChinhDongBhxhBhytBhtn();
            case "HuongTroCapNghiDsphskSauOmDau":
                return NguoiLaoDongHuongTroCapNghiDsphskSauOmDau();
            case "HuongTroCapNghiDsphskSauThaiSan":
                return NguoiLaoDongHuongTroCapNghiDsphskSauThaiSan();
            case "DsphskSauThuongTatBenhTat":
                return NguoiLaoDongHuongTroCapNghiDsphskSauThuongTat();
            case "HuongCheDoOmDau":
                return DanhSachNguoiLaoDongDeNghiHuongCheDoOmDau();
            case "HuongCheDoThaiSan":
                return DanhSachNguoiLaoDongDeNghiHuongCheDoThaiSan();
            case "ToKhaiThamGiaBaoHiemXaHoiBaoHiemYTe":
                return ToKhaiThamGiaBaoHiemXaHoiBaoHiemYTe();
            case "BaoCaoNgayCongNghiPhep":
                return BaoCaoNgayCongNghiPhep();
            case "BaoCaoNhanVienThamGiaBaoHiemXaHoi":
                return BaoCaoNhanVienThamGiaBaoHiemXaHoi();
            case "DsLaoDongThamGiaBhxhTheoThang":
                return DSLaoDongThamGiaBHXHTheoThang();
            case "BaoCaoNhanVienHuongCheDoThaiSanTrongNam":
                return BaoCaoNhanVienHuongCheDoThaiSanTrongNam();
            case "BaoCaoNhanVienNghiOmThaiSan":
                return BaoCaoNhanVienNghiOmThaiSan();
            case "MauC70a-Hd":
                return MauC70aHD();
            #endregion
            #region Case khenthuong,kỷ luật
            case "BaoCaoTongHopKhenThuongTheoPhongBan":
                return BaoCaoTongHopKhenThuongTheoPhongBan();
            case "DanhSachKhenThuongTheoNhanVien":
                return DanhSachKhenThuongTheoNhanVien();
            case "DanhSachNhanVienKhenThuongTheoPhongBan":
                return NhanVienKhenThuongTheoPhongBan();
            case "DanhSachNhanVienBiKyLuat":
                return NhanVienKyLuat();
            case "ThongBaoPhatNhanVienDiLamMuon":
                return ThongBaoPhatNhanVienDiLamMuon();

            #endregion
            #region case thôi việc
            case "DanhSachNhanVienThoiViec":
                return DanhSachNhanVienThoiViec();
            case "DanhSachNhanVienThoiViecTheoPhongBan":
                return NhanVienNghiViecTheoPhongBan();
            case "ThongKeLyDoThoiViec":
                return ThongKeLyDoThoiViec();
            #endregion
            #region case thuế
            case "ToKhaiThueDoiVoiThueKhauTru10%":
                return BaoCaoToKhaiThue();
            case "ToKhaiKhauTruThueThuNhapCaNhan":
                return ToKhaiKhauTruThueThuNhapCaNhan();
            case "ToKhaiQuyetToanThuNhapCaNhan":
                return ToKhaiQuyetToanThuNhapCaNhan();
            case "DanhSachDangKyGiamTruGiaCanh":
                return DanhSachDangKyGiamTruGiaCanh();
            case "BangKeThuNhapChiuThue05a/kk":
                return BangKeThuNhapChiuThue05A();
            case "BangKeChiuThueCaNhanKhongKyHopDong05b":
                return BangKeChiuThueCaNhanKhongKyHopDong05B();
            case "DanhSachCapMaSoThueCaNhan":
                return DanhSachCapMaSoThueCaNhan();
            #endregion

            #region Báo cáo An Phát
            #region case Đánh giá
            case "BaoCaoKetQuaDanhGiaTheoPhongBan":
                return BaoCaoKetQuaDanhGiaTheoPhongBan();
            //case "BaoCaoKetQuaDanhGiaTheoNhanVien":
            //    return BaoCaoKetQuaDanhGiaCuaNhanVien();
            //case "BaoCaoTongHopDiemKetQuaDanhGiaCaNam":
            //    return BaoCaoTongHopKetQuaDanhGiaCaNam();
            case "DanhGiaHoanThanhCongViec":
                return BaoCaoHoanThanhCongViecTheoNhanVien();
            case "BangTongHopDiemVaKetQuaDanhGiaHangThang":
                return BangTongHopDiemVaKetQuaDanhGiaHangThang();
            #endregion
            #endregion
        }
        return new DevExpress.XtraReports.UI.XtraReport();
    }

    private XtraReport BaoCaoDienBienLuongGanNhatCuaNhanVien()
    {
        rp_DienBienLuongGanNhatCuaNhanVien rp = new rp_DienBienLuongGanNhatCuaNhanVien();
        if (Session["rp"] != null)
        {
            ReportFilter filter = Session["rp"] as ReportFilter;
            rp.BindData(filter);
        }
        return rp;
    }

    private XtraReport BaoCaoThongTinNguoiThanNhanQuaTrungThu()
    {
        rp_ThongTinNguoiNhatQuaTrungThu rp = new rp_ThongTinNguoiNhatQuaTrungThu();
        if (Session["rp"] != null)
        {
            ReportFilter filter = Session["rp"] as ReportFilter;
            rp.BindData(filter);
        }
        return rp;
    }

    private XtraReport DSLaoDongThamGiaBHXHTheoThang()
    {
        rp_austfeed_DS_LaoDongThamGiaBHXH1 rp = new rp_austfeed_DS_LaoDongThamGiaBHXH1();
        if (Session["rp"] != null)
        {
            ReportFilter filter = Session["rp"] as ReportFilter;
            rp.BindData(filter);
        }
        return rp;
    }

    private XtraReport PhieuDeNghiThuyenChuyenNhanSu()
    {
        rp_austfeed_GiayDeNghiThuyenChuyenNhanSu rp = new rp_austfeed_GiayDeNghiThuyenChuyenNhanSu();
        if (Session["rp"] != null)
        {
            ReportFilter filter = Session["rp"] as ReportFilter;
            rp.BindData(filter);
        }
        return rp;
    }

    private XtraReport TienChamCongCom()
    {
        rp_apTongHopAnCa rp = new rp_apTongHopAnCa();
        if (Session["rp"] != null)
        {
            ReportFilter filter = Session["rp"] as ReportFilter;
            rp.BindData(filter);
        }
        return rp;
    }

    #region báo cáo đánh giá
    private DevExpress.XtraReports.UI.XtraReport BaoCaoHoanThanhCongViecTheoNhanVien()
    {
        ReportFilter filter = new ReportFilter();
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        filter.MaDotDanhGia = Request.QueryString["ddg"];
        filter.MaCanBo = Request.QueryString["macb"];
        if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
            filter.CanBoQuanLy = int.Parse(Request.QueryString["uid"]);
        else
            filter.CanBoQuanLy = -1;
        DanhGiaHoanThanhCongViecTheoNhanVien danhGia = new DanhGiaHoanThanhCongViecTheoNhanVien();
        danhGia.BindData(filter);
        return danhGia;
    }

    private DevExpress.XtraReports.UI.XtraReport BangTongHopDiemVaKetQuaDanhGiaHangThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        BangTongHopDiemDanhGiaHangThang theoThang = new BangTongHopDiemDanhGiaHangThang();
        theoThang.BindData(filter);
        return theoThang;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoKetQuaDanhGiaTheoPhongBan()
    {
        string maDonVi = Session["MaDonVi"].ToString();
        string maDotDanhGia = Request.QueryString["ddg"];
        rp_ap_KetQuaDanhGiaTheoPhongBan phongBan = new rp_ap_KetQuaDanhGiaTheoPhongBan();
        phongBan.BindData(maDotDanhGia, maDonVi);
        return phongBan;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoKetQuaDanhGiaCuaNhanVien()
    {
        string maDonVi = Session["MaDonVi"].ToString();
        string maDotDanhGia = Request.QueryString["ddg"];
        string maCanBo = Request.QueryString["mcb"];
        rp_apKetQuaDanhGiaCuaNhanVien dgNhanVien = new rp_apKetQuaDanhGiaCuaNhanVien();
        dgNhanVien.BindData(maDotDanhGia, maCanBo, maDonVi);
        return dgNhanVien;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopKetQuaDanhGiaCaNam()
    {
        BangTongHopDiemKetQuaDanhGiaCaNam caNam = new BangTongHopDiemKetQuaDanhGiaCaNam();
        ReportFilter filter = (ReportFilter)Session["rp"];
        caNam.BindData(filter);
        return caNam;
    }
    #endregion

    #region Báo cáo thuế


    private DevExpress.XtraReports.UI.XtraReport BaoCaoChiTietThueThuNhapCaNhan()
    {

        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;
        }
        //filter.MaDonVi = Session["MaDonVi"].ToString();
        rp_BangQuyetToanThueThuNhapCaNhan thuetncn = new rp_BangQuyetToanThueThuNhapCaNhan();
        thuetncn.BindData(filter);
        return thuetncn;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoToKhaiThue()
    {
        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;
        }
        //filter.MaDonVi = Session["MaDonVi"].ToString();
        rp_ToKhaiThue tokhaithue = new rp_ToKhaiThue();
        tokhaithue.BindData(filter);
        return tokhaithue;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoSoLaoDong()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoSoLuongLaoDong baocaosoluonglaodong = new rp_BaoCaoSoLuongLaoDong();
        baocaosoluonglaodong.BinData(filter);
        return baocaosoluonglaodong;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienThayDoiChucVu()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCanBoThayDoiChucVu thaydoichucvu = new rp_DanhSachCanBoThayDoiChucVu();
        thaydoichucvu.bindata(filter);
        return thaydoichucvu;
    }

    private DevExpress.XtraReports.UI.XtraReport BangKeChiuThueCaNhanKhongKyHopDong05B()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        
        //ReportFilterTax filter = (ReportFilterTax)Session["rpThue"];
        rp_BangKeChiuThueCaNhanKhongKyHopDong05B BangKeKhongKyHopDong = new rp_BangKeChiuThueCaNhanKhongKyHopDong05B();
        BangKeKhongKyHopDong.BindData(filter);
        return BangKeKhongKyHopDong;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachCapMaSoThueCaNhan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCapMaSoThueCaNhan MaSoThueCN = new rp_DanhSachCapMaSoThueCaNhan();
        MaSoThueCN.BindData(filter);
        return MaSoThueCN;
    }
    private DevExpress.XtraReports.UI.XtraReport BangKeThuNhapChiuThue05A()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BangKeThuNhapChiuThue bangkethunhapchiuthue = new rp_BangKeThuNhapChiuThue();
        bangkethunhapchiuthue.BindData(filter);
        return bangkethunhapchiuthue;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachDangKyGiamTruGiaCanh()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachGiamTruGiaCanh giamtrugiacanh = new rp_DanhSachGiamTruGiaCanh();
        giamtrugiacanh.BinData(filter);
        return giamtrugiacanh;
    }

    private DevExpress.XtraReports.UI.XtraReport ToKhaiKhauTruThueThuNhapCaNhan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_ToKhaiKhauTruThueThuNhapCaNhan tokhaithue = new rp_ToKhaiKhauTruThueThuNhapCaNhan();
        tokhaithue.BinData(filter);
        return tokhaithue;
    }
    private DevExpress.XtraReports.UI.XtraReport ToKhaiQuyetToanThuNhapCaNhan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_ToKhaiQuyetToanThueThuNhapCaNhan tokhaiquyettoan = new rp_ToKhaiQuyetToanThueThuNhapCaNhan();
        tokhaiquyettoan.BinData(filter);
        return tokhaiquyettoan;
    }
    #endregion
    #region Báo cáo khen thưởng, kỷ luật
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopKhenThuongTheoPhongBan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoTongHopKhenThuongPhongBan ktpb = new rp_BaoCaoTongHopKhenThuongPhongBan();
        ktpb.BindData(filter);
        return ktpb;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachKhenThuongTheoNhanVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachKhenThuongTheoNhanVien khenthuongnv = new rp_DanhSachKhenThuongTheoNhanVien();
        khenthuongnv.BindData(filter);
        return khenthuongnv;
    }
    private DevExpress.XtraReports.UI.XtraReport NhanVienKyLuat()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        //rp_DanhSachCanBoNhanVienKyLuat nvkyluat = new rp_DanhSachCanBoNhanVienKyLuat();
        //nvkyluat.BinData(filter);
        rp_wgBangTongHopHaThuong nvkyluat = new rp_wgBangTongHopHaThuong();
        nvkyluat.BinData(filter);
        return nvkyluat;
    }
    private DevExpress.XtraReports.UI.XtraReport NhanVienKhenThuongTheoPhongBan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachKhenThuongNhanVienTheoPhongBan nvtheophong = new rp_DanhSachKhenThuongNhanVienTheoPhongBan();
        nvtheophong.BinData(filter);
        return nvtheophong;
    }

    //Ky luat Austfeed
    ///@Nghia
    ///
    private DevExpress.XtraReports.UI.XtraReport ThongBaoPhatNhanVienDiLamMuon()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_ThongBaoPhatNVDiLamMuon tbvvpnvdlm = new rp_austfeed_ThongBaoPhatNVDiLamMuon();
        tbvvpnvdlm.BinData(filter);
        return tbvvpnvdlm;
    }


    #endregion
    #region Hàm báo cáo bảo hiểm
    //Hàm báo cáo bảo hiểm
    private DevExpress.XtraReports.UI.XtraReport NghiViecHuongBHXH()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_GiayChungNhanNghiViecHuongBHXH NVBHXH = new rp_GiayChungNhanNghiViecHuongBHXH();
        NVBHXH.BinData(filter);
        return NVBHXH;
    }
    private DevExpress.XtraReports.UI.XtraReport ChamSocConOmDau()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_GiayXacNhanViecNghiChamSocConOm CSCOD = new rp_GiayXacNhanViecNghiChamSocConOm();
        CSCOD.BinData(filter);
        return CSCOD;
    }
    private DevExpress.XtraReports.UI.XtraReport DeNghiHuongTroCapThaiSan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DonDeNghiHuongTroCapThaiSan TroCapThaiSan = new rp_DonDeNghiHuongTroCapThaiSan();
        TroCapThaiSan.BinData(filter);
        return TroCapThaiSan;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDienBienLuongCuaNhanVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DienBienLuongMotNhanVien dbluong = new rp_DienBienLuongMotNhanVien();
        dbluong.BindData(filter);
        return dbluong;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienThamGiaCongDoan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCanBoThamGiaCongDoan cbthamgiacongdoan = new rp_DanhSachCanBoThamGiaCongDoan();
        cbthamgiacongdoan.BindData(filter);
        return cbthamgiacongdoan;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLaoDongDieuChinhDongBhxhBhytBhtn()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH DSCBDCMUCLUONG_PHUCAPXH = new DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH();
        DSCBDCMUCLUONG_PHUCAPXH.BindData(filter);
        return DSCBDCMUCLUONG_PHUCAPXH;
    }
    private DevExpress.XtraReports.UI.XtraReport NguoiLaoDongHuongTroCapNghiDsphskSauOmDau()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        rp_TroCapSauOmDau sauomdau = new rp_TroCapSauOmDau();
        sauomdau.BindData(filter);
        return sauomdau;
    }
    private DevExpress.XtraReports.UI.XtraReport NguoiLaoDongHuongTroCapNghiDsphskSauThaiSan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        rp_TroCapSauThaiSan sauthaisan = new rp_TroCapSauThaiSan();
        sauthaisan.BindData(filter);
        return sauthaisan;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachCanBoNhanVienTiepNhanChinhThuc()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCBNVTiepNhanChinhThuc cbnvtiepnhan = new rp_DanhSachCBNVTiepNhanChinhThuc();
        cbnvtiepnhan.BinData(filter);
        return cbnvtiepnhan;
    }
    private DevExpress.XtraReports.UI.XtraReport NguoiLaoDongHuongTroCapNghiDsphskSauThuongTat()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        //rp_DanhSachNguoiSauDieuTriBenhTat thuongtat = new rp_DanhSachNguoiSauDieuTriBenhTat();
        rp_BaoHiem_C70aHD thuongtat = new rp_BaoHiem_C70aHD();
        thuongtat.BindData(filter);
        return thuongtat;
    }
    private DevExpress.XtraReports.UI.XtraReport MauC70aHD()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        //rp_DanhSachNguoiSauDieuTriBenhTat thuongtat = new rp_DanhSachNguoiSauDieuTriBenhTat();
        rp_BaoHiem_C70aHD thuongtat = new rp_BaoHiem_C70aHD();
        thuongtat.BindData(filter);
        return thuongtat;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachNguoiLaoDongDeNghiHuongCheDoOmDau()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        rp_HuongOmDau huongomdau = new rp_HuongOmDau();
        huongomdau.BindData(filter);
        return huongomdau;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachNguoiLaoDongDeNghiHuongCheDoThaiSan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        rp_HuongCheDoThaiSan trocapthaisan = new rp_HuongCheDoThaiSan();
        trocapthaisan.BindData(filter);
        return trocapthaisan;
    }
    private DevExpress.XtraReports.UI.XtraReport ToKhaiThamGiaBaoHiemXaHoiBaoHiemYTe()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        rp_ToKhaiThamGiaBHXH_BHYT tokhai = new rp_ToKhaiThamGiaBHXH_BHYT();
        tokhai.BindData(filter);
        return tokhai;
    }
    private DevExpress.XtraReports.UI.XtraReport TrichNopBHXH()
    {
        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;
        }
        rp_TrichNopBHYT trichnopbhxh = new rp_TrichNopBHYT();
        trichnopbhxh.BindData(filter);
        return trichnopbhxh;
    }

    ///Bao hiem Austfeed
    ///Nghia
    ///
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienThamGiaBaoHiemXaHoi()
    {
        ReportFilter filter = new ReportFilter();
        if (Session["rp"] != null)
        {
            filter = Session["rp"] as ReportFilter;
        }
        filter.SessionDepartment = Session["MaDonVi"].ToString();
        rp_austfeed_BCNhanVienThamGiaBHXH bcnvtgbhxh = new rp_austfeed_BCNhanVienThamGiaBHXH();
        bcnvtgbhxh.BindData(filter);
        return bcnvtgbhxh;
    }

    ///
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienHuongCheDoThaiSanTrongNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BCNhanVienHuongCheDoThaiSanTrongNam thaisan = new rp_austfeed_BCNhanVienHuongCheDoThaiSanTrongNam();
        thaisan.Bindata(filter);
        return thaisan;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienNghiOmThaiSan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_usstfeed_BaoCaoNhanVienNghiOmThaiSan nghiomthaisan = new rp_usstfeed_BaoCaoNhanVienNghiOmThaiSan();
        nghiomthaisan.Bindata(filter);
        return nghiomthaisan;
    }


    #endregion
    #region Báo cáo phần nhân sự
    /// <summary>
    /// Mẫu báo cáo worldgame
    /// @Lê Anh
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTangMoiToanCongTy()
    {
        rpwg_BaoCaoTangMoiNhanSu report = new rpwg_BaoCaoTangMoiNhanSu();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            report.BindData(filter);
        }
        return report;
    }

    private ReportFilter GetReportFilter()
    {
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            return filter;
        }
        return new ReportFilter();
    }

    /// <summary>
    /// Mẫu báo cáo worldgame
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport BaoCaoBienDongNhanSu()
    {
        rpwg_BaoCaoBienDongNhanSu report = new rpwg_BaoCaoBienDongNhanSu();
        report.BindData(GetReportFilter());
        return report;
    }
    /// <summary>
    /// Mẫu báo cáo worldgame
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport TongHopNhanSuToanCongTy()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rpwg_BaoCaoTongHopNhanSuToanCongTy nsToanCty = new rpwg_BaoCaoTongHopNhanSuToanCongTy();
        nsToanCty.BindData(filter);
        return nsToanCty;
    }
    /// <summary>
    /// Báo cáo danh sách nhân viên nhanh tại form Hồ sơ
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport DanhSachNhanVien()
    {
        rpwg_BangTongHopCBNVChiNhanh nvnv = new rpwg_BangTongHopCBNVChiNhanh();
        //ReportFilterDanhSach filter = new ReportFilterDanhSach();
        //string checkedMaDonVi = Request.QueryString["checked"];
        //if (checkedMaDonVi == null)
        //    filter.CheckedMaDonVi = "";
        //else
        //    filter.CheckedMaDonVi = "," + new CommonUtil().GetChildIDListFromParentID("DM_DONVI", checkedMaDonVi, "MA_DONVI", "PARENT_ID") + checkedMaDonVi + ",";
        //filter.MaDonVi = Session["MaDonVi"].ToString();
        //filter.ReportTitle = string.IsNullOrEmpty(Request.QueryString["rpTitle"]) ? "" : Request.QueryString["rpTitle"];
        //filter.GioiTinh = string.IsNullOrEmpty(Request.QueryString["gtinh"]) ? "" : "," + Request.QueryString["gtinh"] + ",";
        //filter.Nam = string.IsNullOrEmpty(Request.QueryString["nsinh"]) ? -1 : int.Parse(Request.QueryString["nsinh"]);
        //filter.ChucVu = string.IsNullOrEmpty(Request.QueryString["cvu"]) ? "" : "," + Request.QueryString["cvu"] + ",";
        //filter.ViTriCongViec = string.IsNullOrEmpty(Request.QueryString["cviec"]) ? "" : "," + Request.QueryString["cviec"] + ",";
        //filter.TrinhDo = string.IsNullOrEmpty(Request.QueryString["tdo"]) ? "" : "," + Request.QueryString["tdo"] + ",";
        //filter.ChuyenNganh = string.IsNullOrEmpty(Request.QueryString["cnganh"]) ? "" : Request.QueryString["cnganh"];
        //filter.TinhThanh = string.IsNullOrEmpty(Request.QueryString["tthanh"]) ? "" : Request.QueryString["tthanh"];
        //filter.HopDong = string.IsNullOrEmpty(Request.QueryString["hdong"]) ? "" : "," + Request.QueryString["hdong"] + ",";
        //filter.ThamNien = string.IsNullOrEmpty(Request.QueryString["tnien"]) ? "" : Request.QueryString["tnien"];
        //if (!string.IsNullOrEmpty(Request.QueryString["tnien"]))
        //{
        //    if (filter.ThamNien.IndexOf('-') == -1) // dang >6
        //    {
        //        filter.ThamNien = "AND ISNULL(tn_month, 0)" + filter.ThamNien;
        //    }
        //    else // dang 6-8
        //    {
        //        filter.ThamNien = "AND ISNULL(tn_month, 0) > " + filter.ThamNien.Replace("-", "AND ISNULL(tn_month, 0) <= ");
        //    }
        //}

        //filter.DiaChi = string.IsNullOrEmpty(Request.QueryString["dchi"]) ? "" : SoftCore.Util.GetInstance().GetKeyword(Request.QueryString["dchi"]);
        //filter.DiDong = string.IsNullOrEmpty(Request.QueryString["ddong"]) ? "" : Request.QueryString["ddong"];
        //filter.Email = string.IsNullOrEmpty(Request.QueryString["email"]) ? "" : Request.QueryString["email"];
        //filter.DaNghi = string.IsNullOrEmpty(Request.QueryString["dnghi"]) ? 0 : int.Parse(Request.QueryString["dnghi"]);
        //filter.SearchKey = string.IsNullOrEmpty(Request.QueryString["search"]) ? "" : Request.QueryString["search"];

        //filter.Ten1 = Request.QueryString["nguoiLap"];
        //filter.Ten2 = Request.QueryString["trPhong"];
        //filter.Ten3 = Request.QueryString["giamDoc"];
        ReportFilter filter = (ReportFilter)Session["rp"];
        nvnv.BindData(filter);
        return nvnv;
    }

    /// <summary>
    /// Nghia
    /// </summary>Báo cáo Nhân sự Austfeed 
    /// <returns></returns>
    /// 
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienTheoGioiTinh()
    {

        rp_austfeed_BaoCaoDSCanBoNVTheoGioiTinh cbnvtheogioitinh = new rp_austfeed_BaoCaoDSCanBoNVTheoGioiTinh();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            cbnvtheogioitinh.BindData(filter);
        }
        return cbnvtheogioitinh;
    }
    /// <summary>
    /// Nghia
    /// </summary>
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienDiCongTacTrongThang()
    {

        rp_austfeed_BCNhanVienDiCongTacTrongThang cbnvdicongtac = new rp_austfeed_BCNhanVienDiCongTacTrongThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            cbnvdicongtac.BindData(filter);
        }
        return cbnvdicongtac;
    }

    /// <summary>
    /// @Nghia
    /// </summary>
    /// <returns></returns>
    /// 
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienNghiOmTrongThang()
    {

        rp_austfeed_BaoCaoNhanVienNghiOmTrongThang bcnvnghiom = new rp_austfeed_BaoCaoNhanVienNghiOmTrongThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            bcnvnghiom.BindData(filter);
        }
        return bcnvnghiom;
    }


    /// <summary>
    /// @Nghia
    /// </summary>
    /// <returns>report Bao cao nv ky hop dong thoi vu</returns>
    /// 
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienKyHopDongThoiVu()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BaoCaoNVKyHDThoiVu bcnvhdtv = new rp_austfeed_BaoCaoNVKyHDThoiVu();
        bcnvhdtv.BindData(filter);
        return bcnvhdtv;
    }


    /// <summary>
    /// @Nghia
    /// </summary>
    /// <returns></returns>
    /// 
    private DevExpress.XtraReports.UI.XtraReport DanhSachCanBoCongNhanVienCongTy()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_DanhSachCBNVCongTy dscbcnv = new rp_austfeed_DanhSachCBNVCongTy();
        dscbcnv.BinData(filter);
        return dscbcnv;
    }


    /// <summary>
    /// @Nghia
    /// </summary>Bao cao danh sach nhan  vien cua cac don vi thanh vien
    /// <returns></returns>
    /// 
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienCuaCacDonViThanhVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BaoCaoDSNhanVienCuaCacDVThanhVien dsnvcdvtv = new rp_austfeed_BaoCaoDSNhanVienCuaCacDVThanhVien();
        dsnvcdvtv.BinData(filter);
        return dsnvcdvtv;
    }

    private DevExpress.XtraReports.UI.XtraReport DanhSachCanBoHetHanBoNhiem()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCanBoHetHanBoNhiem cbhethanbonhiem = new rp_DanhSachCanBoHetHanBoNhiem();
        cbhethanbonhiem.BindData(filter);
        return cbhethanbonhiem;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachCanBoDaBoNhiem()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCanBoDuocBoNhiem cbdbn = new rp_DanhSachCanBoDuocBoNhiem();
        cbdbn.BindData(filter);
        return cbdbn;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachNhanVienTheoLoaiHopDong()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachNhanVienTheoLoaiHopDong nvtheoLHĐ = new rp_DanhSachNhanVienTheoLoaiHopDong();
        nvtheoLHĐ.BindData(filter, rp_DanhSachNhanVienTheoLoaiHopDong.ReportType.DanhSachNhanVienTheoLoaiHD);
        return nvtheoLHĐ;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoLaoDongBinhQuanNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoLaoDongBinhQuanNam ldbq = new rp_BaoCaoLaoDongBinhQuanNam();
        ldbq.BindData(filter);
        return ldbq;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachNgayPhepConLaiTrongNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachNgayPhepConLaiTrongNam ngayphepcon = new rp_DanhSachNgayPhepConLaiTrongNam();
        ngayphepcon.BindData(filter);
        return ngayphepcon;
    }
    /// <summary>
    /// sinh nhật nhân viên
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport BirthdayOfEmployees()
    {
        rp_SinhNhatNhanVien sn = new rp_SinhNhatNhanVien();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            sn.BindData(filter);
        }
        return sn;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoSoLaoDongTheoHinhThucTiepNhan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan SoLaoDongTheoHTTiepNhan = new rp_BaoCaoSoLuongLaoDongTheoHinhThucTiepNhan();
        SoLaoDongTheoHTTiepNhan.BinData(filter);
        return SoLaoDongTheoHTTiepNhan;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachTaiKhoanNhanVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachTaiKhoanNhanVien tknv = new rp_DanhSachTaiKhoanNhanVien();
        tknv.BindData(filter);
        return tknv;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienDuocTangQuaTrungThu()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachNhanVienDuocTangQuaTrungThu QuaTrungThu = new rp_DanhSachNhanVienDuocTangQuaTrungThu();
        QuaTrungThu.BinData(filter);
        return QuaTrungThu;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienDuocTangQuaMong8Thang3()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_NhanVienDuocTangQuaMong8Thang3 NgayPhuNu = new rp_NhanVienDuocTangQuaMong8Thang3();
        NgayPhuNu.BinData(filter);
        return NgayPhuNu;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNguoiPhuThuoc()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rpwg_BaoCaoDanhSachNguoiPhuThuoc nguoiPhuThuoc = new rpwg_BaoCaoDanhSachNguoiPhuThuoc();
        nguoiPhuThuoc.BindData(filter);
        return nguoiPhuThuoc;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachHopDongCuaNhanVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rpwg_BaoCaoDanhSachHopDongNhanVien dsHopDong = new rpwg_BaoCaoDanhSachHopDongNhanVien();
        dsHopDong.BindData(filter);
        return dsHopDong;
    }
    private DevExpress.XtraReports.UI.XtraReport ThongKeLyDoThoiViec()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_ThongKeLyDoNghiViec report = new rp_ThongKeLyDoNghiViec();
        report.BindData(filter);
        return report;
    }

    private DevExpress.XtraReports.UI.XtraReport NhanVienNghiViecTheoPhongBan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachNhanVienNghiViecTheoPhongBan nvnv = new rp_DanhSachNhanVienNghiViecTheoPhongBan();
        nvnv.BinData(filter);
        return nvnv;
    }
    private DevExpress.XtraReports.UI.XtraReport HopDongThuViec()
    {
        rpwg_HopDongThuViec thuViec = new rpwg_HopDongThuViec();
        ReportFilterEmployeeProfile filter = new ReportFilterEmployeeProfile();
        filter.PrKeyHoSo = decimal.Parse(Request.QueryString["prkey"]);
        filter.SoQuyetDinh = Request.QueryString["soqd"];
        filter.Thang = int.Parse("0" + Request.QueryString["soThang"]);
        filter.TuNgay = Convert.ToDateTime(Request.QueryString["tuNgay"]);
        filter.SoTien = long.Parse(Request.QueryString["soTien"]);
        filter.SessionDepartmentID = Session["MaDonVi"].ToString();
        thuViec.BindData(filter);
        return thuViec;
    }
    private DevExpress.XtraReports.UI.XtraReport HopDongLaoDong()
    {

        //   rp_HopDongLaoDong ns = new rp_HopDongLaoDong();
        rpwg_HopDongChinhThuc hd = new rpwg_HopDongChinhThuc();
        hd.BindData(decimal.Parse("0" + Request.QueryString["id"]));
        return hd;
    }
    private DevExpress.XtraReports.UI.XtraReport ThoaThuanHocViec()
    {
        rpwgThoaThuanHocViec hocViec = new rpwgThoaThuanHocViec();
        ReportFilterEmployeeProfile filter = new ReportFilterEmployeeProfile();
        filter.PrKeyHoSo = decimal.Parse(Request.QueryString["prkey"]);
        filter.TuNgay = Convert.ToDateTime(Request.QueryString["tuNgay"]);
        filter.DenNgay = Convert.ToDateTime(Request.QueryString["denNgay"]);
        filter.SoTien = long.Parse(Request.QueryString["soTien"]);
        filter.SessionDepartmentID = Session["MaDonVi"].ToString();
        hocViec.BindData(filter);
        return hocViec;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienChuaCoSoBHXH()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoNhanVienChuaCoSoBHXH nvchuacobhxh = new rp_BaoCaoNhanVienChuaCoSoBHXH();
        nvchuacobhxh.BindData(filter);
        return nvchuacobhxh;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachCanBoThamGiaBhxh()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoNhanVienThamGiaBHXH nvchuacobhxh = new rp_BaoCaoNhanVienThamGiaBHXH();
        nvchuacobhxh.BindData(filter);
        return nvchuacobhxh;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienChuaCoSoBHYT()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoDanhSachCanBoChuaCoSoBHYT nvchuacobhyt = new rp_BaoCaoDanhSachCanBoChuaCoSoBHYT();
        nvchuacobhyt.BindData(filter);
        return nvchuacobhyt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoCanBoHuongChinhSach()
    {
        ReportFilter filter = (ReportFilter)Session["rp"]; ;
        rp_BaoCaoDanhSachCanBoHuongChinhSach cbhuongchinhsach = new rp_BaoCaoDanhSachCanBoHuongChinhSach();
        cbhuongchinhsach.BindData(filter);
        return cbhuongchinhsach;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoCanBoDuocNangLuong()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoDanhSachCanBoDuocNangLuong cbduocnangluong = new rp_BaoCaoDanhSachCanBoDuocNangLuong();
        cbduocnangluong.BindData(filter);
        return cbduocnangluong;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoCanThamNienCongTac()
    {
        ReportFilter filter = (ReportFilter)(Session["rp"]);
        rp_BaoCaoThamNienCongTac cbthamniencongtac = new rp_BaoCaoThamNienCongTac();
        cbthamniencongtac.BindData(filter);
        return cbthamniencongtac;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienTheoPhongBan()
    {
        ReportFilter filter = (ReportFilter)(Session["rp"]);
        //mẫu báo cáo cũ
        rp_BaoCaoCanBoNhanVienTheoPhongBan cbtheophong = new rp_BaoCaoCanBoNhanVienTheoPhongBan();
        cbtheophong.BindData(filter);
        //mẫu báo cáo của worldgame
        //ReportFilter filter = (ReportFilter)Session["rp"];
        //rpwg_BangTongHopCBNVChiNhanh cbtheophong = new rpwg_BangTongHopCBNVChiNhanh();
        return cbtheophong;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienHetHanHopDong()
    {
        rp_DanhSachNhanVienTheoLoaiHopDong nhanvienhethanhopdong = new rp_DanhSachNhanVienTheoLoaiHopDong();
        ReportFilter filter;
        if (Session["rp"] != null)
        {
            filter = (ReportFilter)(Session["rp"]);
            nhanvienhethanhopdong.BindData(filter, rp_DanhSachNhanVienTheoLoaiHopDong.ReportType.DanhSachNhanVienHetHanHD);
        }
        return nhanvienhethanhopdong;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienHetHanHopDongTrongThang()
    {
        rp_DanhSachNhanVienTheoLoaiHopDong nhanvienhethanhopdong = new rp_DanhSachNhanVienTheoLoaiHopDong();
        ReportFilter filter;
        if (Session["rp"] != null)
        {
            filter = (ReportFilter)(Session["rp"]);
            nhanvienhethanhopdong.BindData(filter, rp_DanhSachNhanVienTheoLoaiHopDong.ReportType.DanhSachNhanVienHetHanHDTrongThang);
        }
        return nhanvienhethanhopdong;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienDieuChuyenTrongThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachCanBoDieuChuyenTrongThang nhanviendieuchuyen = new rp_DanhSachCanBoDieuChuyenTrongThang();
        nhanviendieuchuyen.BindData(filter);
        return nhanviendieuchuyen;
    }
    private DevExpress.XtraReports.UI.XtraReport BangKeDanhSachCanBoCongChuc()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BangKeDanhSachCanBoCongChuc ccvc = new rp_BangKeDanhSachCanBoCongChuc();
        ccvc.BindData(filter);
        return ccvc;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachCanBoDoanTrongCongTy()
    {

        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoCanBoDoan cbdoan = new rp_BaoCaoCanBoDoan();
        cbdoan.BindData(filter);
        return cbdoan;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachCanBoDangVienTrongCongTy()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_CanBoDangVien cbdangvien = new rp_CanBoDangVien();
        cbdangvien.BindData(filter);
        return cbdangvien;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoCanBoQuanNhan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        DanhSachQuanNhan1 cbquannhan = new DanhSachQuanNhan1();
        cbquannhan.BindData(filter);
        return cbquannhan;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienThuViec()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_NhanVienThuViec nvthuviec = new rp_NhanVienThuViec();
        nvthuviec.BindData(filter);
        return nvthuviec;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienCoNguoiGiamTruGiaCanh()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoNhanVienCoNguoiPhuThuoc giamtrugiacanh = new rp_BaoCaoNhanVienCoNguoiPhuThuoc();
        giamtrugiacanh.BindData(filter);
        return giamtrugiacanh;
    }
    private XtraReport BaoCaoMaSoThueCaNhan()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachMaSoThueCaNhan report = new rp_DanhSachMaSoThueCaNhan();
        report.BindData(filter);
        return report;
    }
    #endregion
    #region Lương


    /// <summary>
    /// Nghia
    /// </summary>Ausstfeed
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopThuTienBaoLanhCuaNhanVienTrongNam()
    {

        rp_austfeed_BC_ThuTienBaoLanhCuaNhanVienTrongNam bcttblcnvtn = new rp_austfeed_BC_ThuTienBaoLanhCuaNhanVienTrongNam();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            bcttblcnvtn.bindata(filter);
        }
        return bcttblcnvtn;
    }

    //nghia

    private DevExpress.XtraReports.UI.XtraReport BaoCaoChiPhiCacBoPhanTrongThang()
    {

        rp_austfeed_ChiPhiLuongCacBoPhanTrongThang bccpcbptt = new rp_austfeed_ChiPhiLuongCacBoPhanTrongThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            bccpcbptt.Bindata(filter);
        }
        return bccpcbptt;
    }
    //Nghia - Luong van phong
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongChuyenKhoanTheoThangLan1()
    {

        rp_austfeed_DanhSachLuongChuyenKhoanTheoThang dslcktt = new rp_austfeed_DanhSachLuongChuyenKhoanTheoThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongChuyenKhoanTheoThang.ReportType.DanhSachLuongChuyenKhoanThangLan1);
        }
        return dslcktt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongChuyenKhoanTheoThangLan2()
    {

        rp_austfeed_DanhSachLuongChuyenKhoanTheoThang dslcktt = new rp_austfeed_DanhSachLuongChuyenKhoanTheoThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongChuyenKhoanTheoThang.ReportType.DanhSachLuongChuyenKhoanThangLan2);
        }
        return dslcktt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongNghiViecChuyenKhoanThang()
    {

        rp_austfeed_DanhSachLuongChuyenKhoanTheoThang dslcktt = new rp_austfeed_DanhSachLuongChuyenKhoanTheoThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongChuyenKhoanTheoThang.ReportType.DanhSachLuongNghiViecChuyenKhoanThang);
        }
        return dslcktt;
    }

    // Tien mat - Luong van phong
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongLinhTienMatTheoThangLan1()
    {

        rp_austfeed_DanhSachLuongLinhtienMatThang32014 dslcktt = new rp_austfeed_DanhSachLuongLinhtienMatThang32014();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongLinhtienMatThang32014.ReportType.DanhSachLuongLinhTienMatThangLan1);
        }
        return dslcktt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongLinhTienMatTheoThangLan2()
    {

        rp_austfeed_DanhSachLuongLinhtienMatThang32014 dslcktt = new rp_austfeed_DanhSachLuongLinhtienMatThang32014();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongLinhtienMatThang32014.ReportType.DanhSachLuongLinhTienMatThangLan2);
        }
        return dslcktt;
    }
    
    // Tien mat - Luong kinh doanh
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongKinhDoanhLinhTienMatTheoThangLan1()
    {

        rp_austfeed_DanhSachLuongKinhDoanhLinhtienMatThang32014 dslcktt = new rp_austfeed_DanhSachLuongKinhDoanhLinhtienMatThang32014();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongKinhDoanhLinhtienMatThang32014.ReportType.DanhSachLuongLinhTienMatThangLan1);
        }
        return dslcktt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongKinhDoanhLinhTienMatTheoThangLan2()
    {

        rp_austfeed_DanhSachLuongKinhDoanhLinhtienMatThang32014 dslcktt = new rp_austfeed_DanhSachLuongKinhDoanhLinhtienMatThang32014();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongKinhDoanhLinhtienMatThang32014.ReportType.DanhSachLuongLinhTienMatThangLan2);
        }
        return dslcktt;
    }

    private DevExpress.XtraReports.UI.XtraReport BangTongHopLuongVanPhong()
    {

        rp_austfeed_BangTongHopLuongVanPhong lvp = new rp_austfeed_BangTongHopLuongVanPhong();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            lvp.BinData(filter);
        }
        return lvp;
    }

    // Luong kinh doanh
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongKinhDoanhChuyenKhoanTheoThangLan1()
    {
        rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang dslcktt = new rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang.ReportType.DanhSachLuongChuyenKhoanThangLan1);
        }
        return dslcktt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongKinhDoanhChuyenKhoanTheoThangLan2()
    {
        rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang dslcktt = new rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang.ReportType.DanhSachLuongChuyenKhoanThangLan2);
        }
        return dslcktt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachLuongKinhDoanhNghiViecChuyenKhoanThang()
    {
        rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang dslcktt = new rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            dslcktt.Bindata(filter, rp_austfeed_DanhSachLuongKinhDoanhChuyenKhoanTheoThang.ReportType.DanhSachLuongNghiViecChuyenKhoanThang);
        }
        return dslcktt;
    }

    private DevExpress.XtraReports.UI.XtraReport BangTongHopLuongKinhDoanh()
    {

        rp_austfeed_BangTongHopLuongKinhDoanh lkd = new rp_austfeed_BangTongHopLuongKinhDoanh();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            lkd.BinData(filter);
        }
        return lkd;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoKhoanSanXuat()
    {
        rp_austfeed_KhoanSanXuat lkd = new rp_austfeed_KhoanSanXuat();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            lkd.BinData(filter);
        }
        return lkd;
    }
    //
    private DevExpress.XtraReports.UI.XtraReport BangThanhToanTienLuongTheoThang()
    {

        rp_austfeed_BangThanhToanTienLuongThang72013 btttltt = new rp_austfeed_BangThanhToanTienLuongThang72013();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            btttltt.Bindata(filter);
        }
        return btttltt;
    }
    // luong kinh doanh
    private DevExpress.XtraReports.UI.XtraReport PhieuLuongKinhDoanh()
    {

        rp_austfeed_BangThanhToanTienLuongKinhDoanhThang72013 btttltt = new rp_austfeed_BangThanhToanTienLuongKinhDoanhThang72013();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            btttltt.Bindata(filter);
        }
        return btttltt;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoThanhToanTamUng()
    {

        //ReportFilter filter = new ReportFilter();
        ReportFilter filter = (ReportFilter)Session["rp"];
        //filter.MaDonVi = Session["MaDonVi"].ToString();
        //filter.NguoiLapBaoCao = CurrentUser.DisplayName.ToString();
        BaoCaoThanhToanTamUng BCTTTU = new BaoCaoThanhToanTamUng();
        // trichnopbhxh.BindData(filter);
        return BCTTTU;
    }

    private DevExpress.XtraReports.UI.XtraReport DanhSachPhatHaThuong()
    {

        ReportFilterSalary rp = (ReportFilterSalary)Session["rpLuong"];
        rp_DanhSachHaThuong thuongPhat = new rp_DanhSachHaThuong();
        thuongPhat.BindData(rp, true);
        return thuongPhat;
    }

    private DevExpress.XtraReports.UI.XtraReport DanhSachKhenThuongTienLuong()
    {
        ReportFilterSalary rp = (ReportFilterSalary)Session["rpLuong"];
        rp_DanhSachHaThuong thuongPhat = new rp_DanhSachHaThuong();
        thuongPhat.BindData(rp, false);
        return thuongPhat;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoQuyetDinhLuong()
    {
        ReportFilterQuyetDinhLuong filter = new ReportFilterQuyetDinhLuong();
        filter.MaDonVi = Session["MaDonVi"].ToString();
        string id = Request.QueryString["id"];
        if (!string.IsNullOrEmpty(id))
        {
            filter.ID = int.Parse("0" + id);
            rpwg_QuyetDinhLuong BCQDL = new rpwg_QuyetDinhLuong();
            BCQDL.BindData(filter);
            return BCQDL;
        }
        return null;
    }
    #endregion
    #region Đánh giá
    private DevExpress.XtraReports.UI.XtraReport BangTongHopDiemKetQuaDanhGiaCaNam()
    {
        BangTongHopDiemKetQuaDanhGiaCaNam rpt = new BangTongHopDiemKetQuaDanhGiaCaNam();
        ReportFilter rp = (ReportFilter)Session["rp"];
        rpt.BindData(rp);
        return rpt;
    }
    private DevExpress.XtraReports.UI.XtraReport BangTheoDoiKetQuaThucHienCongViecCaNhan()
    {
        rp_BangTheoDoiKetQuaThucHienCongViecCaNhan rpt = new rp_BangTheoDoiKetQuaThucHienCongViecCaNhan();
        return rpt;

    }
    private DevExpress.XtraReports.UI.XtraReport BangTongDiemKetQuaDanhGia()
    {
        rp_BangTongDiemKetQuaDanhGia rpt = new rp_BangTongDiemKetQuaDanhGia();
        ReportFilter rp = (ReportFilter)Session["rp"];
        rpt.BindData(rp);
        return rpt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhGiaChamTienDoSoVoiQuyDinh()
    {
        rp_DanhGiaChamTienDoSoVoiQuyDinh rpt = new rp_DanhGiaChamTienDoSoVoiQuyDinh();
        return rpt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachXepLoaiCBNV()
    {
        rp_DanhSachCanBoCoDotDanhGia rpt = new rp_DanhSachCanBoCoDotDanhGia();
        ReportFilter rp = (ReportFilter)Session["rp"];
        rpt.BindData(rp);
        return rpt;
    }
    private DevExpress.XtraReports.UI.XtraReport TheoDoiTongHopTienDoDanhGiaTheoDonVi()
    {
        rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi rpt = new rp_TheoDoiTongHopTienDoDanhGiaTheoDonVi();
        ReportFilter rp = (ReportFilter)Session["rp"];
        rpt.BindData(rp);
        return rpt;
    }

    #region báo cáo của austfeed
    /// <summary>
    /// daibx - Dùng cho người quản lý đánh giá nhân viên
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport BangDanhGiaCongViecTheoNam()
    {
        rp_austfeed_BangDanhGiaCongViecNam danhGia = new rp_austfeed_BangDanhGiaCongViecNam();
        ReportFilter filter = (ReportFilter)Session["rp"];
        danhGia.BindData(filter);
        return danhGia;
    }

    /// <summary>
    /// daibx - Dùng cho nhân viên tự đánh giá
    /// </summary>
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport BangTuDanhGiaCuaNhanVienTheoNam()
    {
        rp_austfeed_BangTuDanhGiaCuaNVNam danhGia = new rp_austfeed_BangTuDanhGiaCuaNVNam();
        ReportFilter filter = (ReportFilter)Session["rp"];
        danhGia.BindData(filter);
        return danhGia;
    }
    #endregion

    #endregion
    #region Tuyển dụng


    /// <summary>
    /// @Nghia
    /// </summary>Austfeed
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoTuyenDungTrongNamCuaCacDonViThanhVien()
    {
        rs_austfeed_BaoCaoTuyenDungTrongNamCuaCacDVThanhVien tdtn = new rs_austfeed_BaoCaoTuyenDungTrongNamCuaCacDVThanhVien();
        ReportFilter filter = (ReportFilter)Session["rp"];
        tdtn.BindData(filter);
        return tdtn;
    }

    /// <summary>
    /// @Nghia
    /// </summary>Austfeed
    /// <returns></returns>
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienTuyenDungNam()
    {
        rp_austfeed_BCNhanVienTuyenDungNam bcnvtdn = new rp_austfeed_BCNhanVienTuyenDungNam();
        ReportFilter filter = (ReportFilter)Session["rp"];
        bcnvtdn.BindData(filter);
        return bcnvtdn;
    }


    private DevExpress.XtraReports.UI.XtraReport BaoCaoHoSoUngVienChiTiet()
    {
        rp_UngvienChiTiet sn = new rp_UngvienChiTiet();
        if (Session["rp"] != null)
        {
            string MaUngVien = Request.QueryString.Get("MaUngVien");
            ReportFilter filter = (ReportFilter)Session["rp"];
            sn.BindData(MaUngVien, filter);
        }
        return sn;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachTiepNhanThuViec()
    {
        rpwg_TiepNhanNhanSu sn = new rpwg_TiepNhanNhanSu();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            sn.BindData(filter);
        }
        return sn;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoKetQuaPhongVanCuaUngVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_KetQuaPhongVanCuaUngVien kqpvungvien = new rp_KetQuaPhongVanCuaUngVien();
        kqpvungvien.BindData(filter);
        return kqpvungvien;
    }
    private DevExpress.XtraReports.UI.XtraReport DMKeHoachTuyenDung()
    {
        rp_BaoCaoKeHoachTuyenDung sn = new rp_BaoCaoKeHoachTuyenDung();
        if (Session["rp"] != null)
        {
            ReportFilter filter = (ReportFilter)Session["rp"];
            //filter.MaDonVi = Session["MaDonVi"].ToString();
            //filter.NguoiLapBaoCao = CurrentUser.DisplayName.ToString();
            sn.BindData(filter);
        }
        return sn;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoChiTietMotDotTuyenDung()
    {
        ReportFilter filter = Session["rp"] as ReportFilter;
        rp_BaoChiTiet1DotTuyenDung sn = new rp_BaoChiTiet1DotTuyenDung();
        sn.BindData(filter);
        return sn;
    }
    //tận dụng lại method này
    private DevExpress.XtraReports.UI.XtraReport CVChiTietUngVienFromLichPhongVan()
    {
        rp_UngvienChiTiet cv = new rp_UngvienChiTiet();
        int idLichPhongVan = int.Parse(Request.QueryString["id"]);
        //DAL.DM_LICHPHONGVAN lichPV = new LichPhongVanController().GetLichPhongVanById(idLichPhongVan);
        //cv.BindData(lichPV.MaUngVien);
        return cv;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoUngVienTrungTuyen()
    {
        string id = Request.QueryString.Get("id");

        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_UngVienTrungTuyen ungvientrungtuyen = new rp_UngVienTrungTuyen();
        ungvientrungtuyen.BindData(filter);
        return ungvientrungtuyen;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoThongKeTyLeUngVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoThongKeTyLeUngVien tkuv = new rp_BaoCaoThongKeTyLeUngVien();
        tkuv.BindData(filter);
        return tkuv;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachDenTuyenDung()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachDenTuyenDung tkuv = new rp_DanhSachDenTuyenDung();
        tkuv.BindData(filter, "black");
        return tkuv;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoKhoDuTruTuyenDung()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachDenTuyenDung tkuv = new rp_DanhSachDenTuyenDung();
        tkuv.BindData(filter, "store");
        return tkuv;
    }
    #endregion
    #region Đào tạo
    private DevExpress.XtraReports.UI.XtraReport BaoCaoThongTinChiTiet1KhoaDaoTao()
    {
        rp_ThongTinChiTiet1KhoaDaoTao nvthamgiadt = new rp_ThongTinChiTiet1KhoaDaoTao();
        return nvthamgiadt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienThamGiaDaoTao()
    {
        rp_DanhSachNhanVienThamGiaDaoTao rp = new rp_DanhSachNhanVienThamGiaDaoTao();
        if (Session["rp"] != null)
        {
            ReportFilter filter = Session["rp"] as ReportFilter;
            rp.BindData(filter);
        }
        return rp;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachKhoaDaoTao()
    {
        ReportFilter filter = new ReportFilter();
        if (Session["rp"] != null)
        {
            filter = Session["rp"] as ReportFilter;
        }
        rp_BaoCaoDanhSachKhoaDaoTao khoadaotao = new rp_BaoCaoDanhSachKhoaDaoTao();
        khoadaotao.BindData(filter);
        return khoadaotao;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachCacKhoaDaoTao()
    {
        ReportFilter filter = new ReportFilter();
        if (Session["rp"] != null)
        {
            filter = Session["rp"] as ReportFilter;
        }
        rp_BaoCaoDanhSachCacKhoaDaoTao khoadaotao = new rp_BaoCaoDanhSachCacKhoaDaoTao();
        khoadaotao.BindData(filter);
        return khoadaotao;
    }
    #endregion
    #region Chấm công

    /// <summary>
    /// @Nghia
    /// </summary>Austfeed
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienNghiKhongLyDoTrongThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BCNhanVienNghiKhogLyDoTrongThang bcnvnghiklydo = new rp_austfeed_BCNhanVienNghiKhogLyDoTrongThang();
        bcnvnghiklydo.Bindata(filter);
        return bcnvnghiklydo;
    }

    /// <summary>
    /// Nghia
    /// </summary>Austfeed
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopSoNgayNghiPhepCuaNhanVienTrongNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BCTHSoNgayNghiPhepCuaNVTrongNam bcthsnnpcnvtn = new rp_austfeed_BCTHSoNgayNghiPhepCuaNVTrongNam();
        bcthsnnpcnvtn.BinData(filter);
        return bcthsnnpcnvtn;
    }

    /// <summary>
    /// @Nghia
    /// </summary>Austfeed
    /// <returns></returns>

    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopSoNgayNghiKhongLyDoCuaNhanVienTrongNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BCTHSoNgayNghiKhogLyDoCuaNV bcthsnnkldcnvtn = new rp_austfeed_BCTHSoNgayNghiKhogLyDoCuaNV();
        bcthsnnkldcnvtn.BinData(filter);
        return bcthsnnkldcnvtn;
    }


    /// <summary>
    /// @Nghia
    /// </summary>AustFeed 
    /// <returns></returns>
    /// 
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopSoNgayNghiViecRiengNghiOmCuaNhanVienTrongNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BCTHSoNgayNghiViecRiengNghiOmCuaNV bcthsnnvrnocnvtn = new rp_austfeed_BCTHSoNgayNghiViecRiengNghiOmCuaNV();
        bcthsnnvrnocnvtn.BinData(filter);
        return bcthsnnvrnocnvtn;
    }
    /// <summary>
    /// @Nghia
    /// </summary>AUstfeed
    /// <returns></returns>
    /// 


    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienNghiCheDoTrongThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BaoCaoNVNghiCheDoTrongThang bcnvncdtt = new rp_austfeed_BaoCaoNVNghiCheDoTrongThang();
        bcnvncdtt.BinData(filter);
        return bcnvncdtt;
    }


    /// <summary>
    /// @Nghia
    /// </summary>Austfeed -Bao cao nhan vien lam ngay le tet
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienLamNgayLeTetTrongThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BCNhanVienLamNgayLeTetTrongThang bcnvlnlttt = new rp_BCNhanVienLamNgayLeTetTrongThang();
        bcnvlnlttt.BindData(filter);
        return bcnvlnlttt;
    }


    /// <summary>
    /// Nghia
    /// </summary>Austfeed- Báo cáo nhân viên nghỉ  riêng trong tháng
    /// <returns></returns>
    /// 

    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienNghiViecRiengTrongThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BaoCaoNhanVienNghiViecRiengTrongThang bcnvnvrtt = new rp_austfeed_BaoCaoNhanVienNghiViecRiengTrongThang();
        bcnvnvrtt.BinData(filter);
        return bcnvnvrtt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoLamThemGio()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_austfeed_BaoCaoLamThemGio bcltg = new rp_austfeed_BaoCaoLamThemGio();
        bcltg.BinData(filter);
        return bcltg;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoCBNVLamCa()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoSoLuongCBNVLamTheoCa lamca = new rp_BaoCaoSoLuongCBNVLamTheoCa();
        lamca.BindData(filter);
        return lamca;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoThuTucDauVao()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoThuTucDauVao dauvao = new rp_BaoCaoThuTucDauVao();
        dauvao.BindData(filter);
        return dauvao;
    }
    
    private DevExpress.XtraReports.UI.XtraReport LichPhanCaThang()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_LichPhanCaThang lpcthang = new rp_LichPhanCaThang();
        lpcthang.BindData(filter);
        return lpcthang;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienQuenQuetThe()
    {
        ReportFilterTimeKeeper filter = (ReportFilterTimeKeeper)Session["rpChamCong"];
        rp_BaoCaoNhanVienQuetTheLoi nvqtl = new rp_BaoCaoNhanVienQuetTheLoi();
        nvqtl.BindData(filter);
        return nvqtl;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTheoDoiNhanVienNghiChamCong()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoTheoDoiNghi bctheodoinghi = new rp_BaoCaoTheoDoiNghi();
        bctheodoinghi.BindData(filter);
        return bctheodoinghi;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachNhanVienCoMatTrongNgay()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachNhanVienCoMatTrongNgay nhanviencomattrongngay = new rp_DanhSachNhanVienCoMatTrongNgay();
        nhanviencomattrongngay.BindData(filter);
        return nhanviencomattrongngay;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopLamThemGio()
    {
        ReportFilterTimeKeeper filter = (ReportFilterTimeKeeper)Session["rpChamCong"];
        rp_BaoCaoTongHopLamThemGio lamthemgio = new rp_BaoCaoTongHopLamThemGio();
        lamthemgio.BindData(filter);
        return lamthemgio;
    }
    private DevExpress.XtraReports.UI.XtraReport BanDangKyNghi()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BanDangKyNghi bandangkynghi = new rp_BanDangKyNghi();
        bandangkynghi.BindData(filter);
        return bandangkynghi;
    }
    private DevExpress.XtraReports.UI.XtraReport BangDangKyLamBu()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_bangdanhkylambu bangdangkylambu = new rp_bangdanhkylambu();
        bangdangkylambu.BindData(filter);
        return bangdangkylambu;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNgayCongNghiPhep()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoSoNgayNghiPhep SoLaoDongTheoHTTiepNhan = new rp_BaoCaoSoNgayNghiPhep();
        SoLaoDongTheoHTTiepNhan.BindData(filter);
        return SoLaoDongTheoHTTiepNhan;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNgayCong()
    {
        rp_BaoCaoNgayCongTuNgayDenNgay ngaycong = new rp_BaoCaoNgayCongTuNgayDenNgay();
        ReportFilter rp = (ReportFilter)Session["rp"];
        ngaycong.BindData(rp);
        return ngaycong;
    }
    private DevExpress.XtraReports.UI.XtraReport BangTheoDoiDiMuonVeSom()
    {
        rp_BangTheoDoiDiMuonVeSom dmvs = new rp_BangTheoDoiDiMuonVeSom();
        ReportFilter rp = (ReportFilter)Session["rp"];
        dmvs.Bindata(rp);
        return dmvs;
    }
    private DevExpress.XtraReports.UI.XtraReport BangTheoDoiDiMuonVeSomTheoNgay()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BangTheoDoiDiMuonVeSomTheoNgay thtt = new rp_BangTheoDoiDiMuonVeSomTheoNgay();
        thtt.Bindata(filter);
        return thtt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoBangChamCongThang()
    {
        ReportFilterTimeKeeper filter = (ReportFilterTimeKeeper)Session["rpChamCong"];
        rp_BangChamCongTheoThang bcctt = new rp_BangChamCongTheoThang();
        //bcctt.BindData(filter);
        return bcctt;
    }
    private DevExpress.XtraReports.UI.XtraReport BangChamCongThang()
    {
        ReportFilterTimeKeeper filter = (ReportFilterTimeKeeper)Session["rpChamCong"];
        rp_BangChamCongTheoThang_May bcct = new rp_BangChamCongTheoThang_May();
        bcct.BindData(filter);
        return bcct;
    }

    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachNhanVienDangKyLamThemGio()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_DanhSachNhanVienDangKyLamThemGio bcnvncdtt = new rp_DanhSachNhanVienDangKyLamThemGio();
        bcnvncdtt.BindData(filter);
        return bcnvncdtt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTinhHinhNghiPhep()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoTinhHinhNghiPhep nghiphep = new rp_BaoCaoTinhHinhNghiPhep();
        nghiphep.BindData(filter);
        return nghiphep;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoNhanVienNghiDaiNgay()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoNhanVienNghiDaiNgay bcnvncdtt = new rp_BaoCaoNhanVienNghiDaiNgay();
        bcnvncdtt.BindData(filter);
        return bcnvncdtt;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoTongHopCongCuoiThang()
    {

        ReportFilterTimeKeeper ftChamCong = (ReportFilterTimeKeeper)Session["rpChamCong"];
        if (ftChamCong == null)
        {
            ftChamCong = new ReportFilterTimeKeeper();
            ftChamCong.SessionDepartmentID = maDonVi;
            ftChamCong.IDDanhSachBangTongHopCong = idBangTHC;
            ftChamCong.ReportTitle = "";
            ftChamCong.Ten1 = "";
            ftChamCong.Ten3 = "";
            ftChamCong.Footer1 = "";
            ftChamCong.Footer3 = "";
            ftChamCong.CityName = new HeThongController().GetValueByName(SystemConfigParameter.CITY, Session["MaDonVi"].ToString()).ToUpper();
            ftChamCong.CompanyName = new DM_DONVIController().GetNameById(Session["MaDonVi"].ToString());
        }
        rp_BaoCaoTongHopCongCuoiThang tonghop = null;
        if (idBangTHC != 0 && maDonVi != "")
        {
            tonghop = new rp_BaoCaoTongHopCongCuoiThang(idBangTHC, maDonVi);
        }
        else
        {
            tonghop = new rp_BaoCaoTongHopCongCuoiThang();
        }
        tonghop.BindData(ftChamCong);
        return tonghop;
    }
    #endregion
    #region Thôi việc
    private DevExpress.XtraReports.UI.XtraReport QuyetDinhThoiViec()
    {
        rpwg_QuyetDinhThoiViec nvnv = new rpwg_QuyetDinhThoiViec();
        nvnv.BinData(Request.QueryString["MaCB"]);
        return nvnv;
    }

    /// <summary>
    /// Nghia
    /// </summary>
    /// <returns></returns>
    /// 


    private DevExpress.XtraReports.UI.XtraReport DanhSachNhanVienThoiViec()
    {
        //ReportFilter filter = (ReportFilter)Session["rp"];
        //rp_DanhSachNhanVienNghiViec nvnv = new rp_DanhSachNhanVienNghiViec();
        //nvnv.BinData(filter);
        rpwg_BaoCaoDanhSachNhanVienNghiViec nvnv = new rpwg_BaoCaoDanhSachNhanVienNghiViec();
        nvnv.BindData((ReportFilter)Session["rp"]);
        return nvnv;
    }
    #endregion
    #region TaiSan
    private DevExpress.XtraReports.UI.XtraReport BaoCaoDanhSachTaiSanTheoPhongBan()
    {
        rp_DanhSachTaiSanTheoPhongBan rpt = new rp_DanhSachTaiSanTheoPhongBan();
        ReportFilter rp = (ReportFilter)Session["rp"];
        rpt.BinData(rp);
        return rpt;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachTaiSanCapPhatChoNhanVien()
    {
        ReportFilter rp = (ReportFilter)Session["rp"];
        if (rp == null)
        {
            rp = new ReportFilter()
            {
                SessionDepartment = Session["MaDonVi"].ToString(),
                Reporter = CurrentUser.DisplayName,
            };
        }
        rp_DanhSachTaiSanCapPhatChoNhanVien dmvs = new rp_DanhSachTaiSanCapPhatChoNhanVien();
        if (!string.IsNullOrEmpty(Request.QueryString["prkey"]))
        {
            rp.EmployeeCode = decimal.Parse("0" + Request.QueryString["prkey"]);
        }
        dmvs.BindData(rp);
        return dmvs;
    }
    #endregion
    #region Lương

    private DevExpress.XtraReports.UI.XtraReport DanhSachNhanLuongTienMat()
    {
        ReportFilter rp = (ReportFilter)Session["rp"];
        rp_DanhSachNhanLuongTienMat tvhoacchotv = new rp_DanhSachNhanLuongTienMat();
        tvhoacchotv.BindData(rp);
        return tvhoacchotv;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachChuyenKhoanNganHangTienLuong()
    {
        ReportFilter rp = (ReportFilter)Session["rp"];
        rp_NhanVienTraLuongQuaTaiKhoanNganHang NhanVienTraLuongQuaTaiKhoan = new rp_NhanVienTraLuongQuaTaiKhoanNganHang();
        NhanVienTraLuongQuaTaiKhoan.BindData(rp);
        return NhanVienTraLuongQuaTaiKhoan;
    }
    private DevExpress.XtraReports.UI.XtraReport DanhSachTraLuongTheoKy()
    {
        if (string.IsNullOrEmpty(Request.QueryString["idBangLuong"]))
        {
            return new DevExpress.XtraReports.UI.XtraReport();
        }
        ReportFilter filter = new ReportFilter();
        if (Session["rp"] != null)
        {
            filter = (ReportFilter)Session["rp"];
        }
        string sotaikhoan = "";// new DM_DONVIController().GetById(filter.MaDonVi).SO_TAI_KHOAN;
        rp_DanhSachTraLuongTheoKy dstraluongtheoky = new rp_DanhSachTraLuongTheoKy();
        dstraluongtheoky.BindData(filter, sotaikhoan, int.Parse(Request.QueryString["idBangLuong"]));
        return dstraluongtheoky;
    }
    private DevExpress.XtraReports.UI.XtraReport PhieuTraLuong()
    {
        PhieuTraLuong1 phieuluong = new PhieuTraLuong1();
        ReportFilterSalary rp = (ReportFilterSalary)Session["rp"];
        phieuluong.BindData(rp);
        return phieuluong;
    }
    private DevExpress.XtraReports.UI.XtraReport BangThanhToanLuongThang()
    {
        ReportFilter RP = (ReportFilter)(Session["rp"]);
        rp_BangThanhToanLuongThang luongthang = new rp_BangThanhToanLuongThang();
        luongthang.BindData(RP);
        return luongthang;
    }
    private DevExpress.XtraReports.UI.XtraReport BangTongHopThuNhapChiuThueVaThueDaNopCBNTrongNam()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BangTongHopThuNhapVaChiuThueVaThueDaNop thuethunhap = new rp_BangTongHopThuNhapVaChiuThueVaThueDaNop();
        thuethunhap.BinData(filter);
        return thuethunhap;
    }
    private DevExpress.XtraReports.UI.XtraReport BaoCaoChiPhiTheoNhanVien()
    {
        ReportFilter filter = (ReportFilter)Session["rp"];
        rp_BaoCaoChiPhiTheoNhanVien baocaotheochiphi = new rp_BaoCaoChiPhiTheoNhanVien();
        baocaotheochiphi.BinData(filter);
        return baocaotheochiphi;
    }
    private DevExpress.XtraReports.UI.XtraReport TongHopTinhHinhLaoDongQuyLuongSoPhaiNopBhxh()
    {

        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;
        }
        DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH DSCBDCMUCLUONG_PHUCAPXH = new DanhSachCanBoDieuChinhMucLuongPhuCapNopBHXH();
        //trichnopbhxh.BindData(filter);
        return DSCBDCMUCLUONG_PHUCAPXH;
    }
    private DevExpress.XtraReports.UI.XtraReport ToKhaiNopThueThuNhapThuongXuyenCuaCaNhan()
    {

        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;
        }
        ToKhaiNopThueThuNhapThuongXuyenCuaCaNhan TKNTTHNTXCN = new ToKhaiNopThueThuNhapThuongXuyenCuaCaNhan();
        //trichnopbhxh.BindData(filter);
        return TKNTTHNTXCN;
    }
    #endregion
    #region Khen thưởng,kỷ luật
    private DevExpress.XtraReports.UI.XtraReport BaoCaoKhenThuong()
    {

        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;

        }
        rp_BaoCaoKhenThuongKyLuatTrongThang khenthuong = new rp_BaoCaoKhenThuongKyLuatTrongThang();
        khenthuong.BindData(filter);
        return khenthuong;
    }
    #endregion
    private DevExpress.XtraReports.UI.XtraReport DanhMucCBCNV()
    {

        rp_BangChamCongTheoThang ns = new rp_BangChamCongTheoThang();
        ReportFilterTimeKeeper rp = (ReportFilterTimeKeeper)Session["rpChamCong"];
        //ns.BindData(rp);
        return ns;
    }
    private DevExpress.XtraReports.UI.XtraReport LuyKeLuongTheoPhongBan()
    {
        ReportFilter filter = new ReportFilter();
        if (Session["ReportFilter"] != null)
        {
            filter = Session["ReportFilter"] as ReportFilter;
        }
        rp_TongHopThanhToanLuong luykeluong = new rp_TongHopThanhToanLuong();
        luykeluong.BindData(filter);
        return luykeluong;
    }


}