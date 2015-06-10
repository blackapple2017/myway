using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.ThoiViec
{
    /// <summary>
    /// Created by Le Van Anh
    /// </summary>
    public class DanhSachCanBoThoiViecInfo
    {
        public DanhSachCanBoThoiViecInfo()
        { 
        }

        public int ID { get; set; }

        public string MaCB { get; set; }
        public string HoTen { get; set; }
        public string PhongBan { get; set; }
        public string LyDoNghi { get; set; }
        public string DiaChiLienHe { get; set; }
        public string Email { get; set; }
        public string DiDong { get; set; }
        public string ChucVu { get; set; }
        public string ViTriCongViec { get; set; }
        public string GioiTinh { get; set; }
        public string CanBoDuyetNghi { get; set; }
        public string Photo { get; set; }
        public string SoQuyetDinh { get; set; }
        public string AttachFile { get; set; }
        public string GhiChu { get; set; }

        /// <summary>
        /// Lưu khóa chính của bảng hồ sơ
        /// </summary>
        public decimal FrKeyHoSo { get; set; }

        public string DaTraTheBHYT { get; set; }
        public bool DaTraSoBHXH { get; set; }
        public bool DaHoanThanhThuTuc { get; set; }
        public bool HoanTatCongNo { get; set; }
        public bool BanGiaoTaiSan { get; set; }
        /// <summary>
        /// Đánh dấu là nhân viên này thuộc danh sách blacklist
        /// lần sau ứng tuyển sẽ không được nữa
        /// </summary>
        public bool IsBelongToBlackList { get; set; }

        public DateTime? NgayXinNghi { get; set; }
        public DateTime? NgayLamViecCuoiCung { get; set; }
        public DateTime? NgayTraTheBHYT { get; set; }
        public DateTime? NgayTraSoBHXH { get; set; }
        public DateTime? NgayHoanThanhThuTuc { get; set; }
        public DateTime? NgayNghi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayThuViec { get; set; }
        public DateTime? NgayLamChinhThuc { get; set; }
    }
}