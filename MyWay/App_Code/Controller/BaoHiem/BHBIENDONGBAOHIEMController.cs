using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Nguyễn Văn Khởi
/// </summary>

public class BHBIENDONGBAOHIEMController
{
    public DataTable GetByPrkey(int pr_key)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetBHBIENDONGBAOHIEMByPrkey", "@IDBienDongBaoHiem", pr_key);
    }

    public void DeleteByPrkey(int pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteBHBIENDONGBAOHIEMByPrkey", "@IDBienDongBaoHiem", pr_key);
    }

    public DataTable GetAllRecord(int start, int limit, string searchKey, out int count)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountBHBIENDONGBAOHIEM", "@searchKey", searchKey).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectBHBIENDONGBAOHIEM", "@start", "@limit", "@searchKey", start, limit, searchKey);
    }

    public void Insert(BHBIENDONGBAOHIEMInfo record)
    {
        DataController.DataHandler.GetInstance().ExecuteScalar("InsertBHBIENDONGBAOHIEM", "@IDQuyDinhBienDong", "@IDNhanVien_BaoHiem", "@TuNgay", "@DenNgay", "@Loai", "@MaNhanVien", "@HoTen", "@MaSo", "@NgaySinh", "@GioiTinh", "@ChucVu", "@TienLuongCu", "@PhuCapCVCu", "@PhuCapTNVKCu", "@PhuCapNgheCu", "@TienLuongMoi", "@PhuCapCVMoi", "@PhuCapTNNgheMoi", "@ThangDangKy", "@DenThang", "@KhongTraThe", "@DaCoSo", "@UserID", "@DateCreate", "@MaDonVi",record.IDQuyDinhBienDong, record.IDNhanVien_BaoHiem, record.TuNgay, record.DenNgay, record.Loai, record.MaNhanVien, record.HoTen, record.MaSo, record.NgaySinh, record.GioiTinh, record.ChucVu, record.TienLuongCu, record.PhuCapCVCu, record.PhuCapTNVKCu, record.PhuCapNgheCu, record.TienLuongMoi, record.PhuCapCVMoi, record.PhuCapTNNgheMoi, record.TuThang, record.DenThang, record.KhongTraThe, record.DaCoSo, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void Update(BHBIENDONGBAOHIEMInfo record)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateBHBIENDONGBAOHIEM", "@IDBienDongBaoHiem", "@IDQuyDinhBienDong", "@IDNhanVien_BaoHiem", "@TuNgay", "@DenNgay", "@Loai", "@MaNhanVien", "@HoTen", "@MaSo", "@NgaySinh", "@GioiTinh", "@ChucVu", "@TienLuongCu", "@PhuCapCVCu", "@PhuCapTNVKCu", "@PhuCapNgheCu", "@TienLuongMoi", "@PhuCapCVMoi", "@PhuCapTNNgheMoi", "@ThangDangKy", "@DenThang", "@KhongTraThe", "@DaCoSo", "@UserID", "@DateCreate", "@MaDonVi", record.IDBienDongBaoHiem, record.IDQuyDinhBienDong, record.IDNhanVien_BaoHiem, record.TuNgay, record.DenNgay, record.Loai, record.MaNhanVien, record.HoTen, record.MaSo, record.NgaySinh, record.GioiTinh, record.ChucVu, record.TienLuongCu, record.PhuCapCVCu, record.PhuCapTNVKCu, record.PhuCapNgheCu, record.TienLuongMoi, record.PhuCapCVMoi, record.PhuCapTNNgheMoi, record.TuThang, record.DenThang, record.KhongTraThe, record.DaCoSo, record.UserID, record.DateCreate, record.MaDonVi);
    }

    public void DuplucateByPrkey(int pr_key)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("DuplucateBHBIENDONGBAOHIEMByPrkey", "@IDBienDongBaoHiem", pr_key);
    }
    public void CapNhatSoThangDongBangHiemTuTienBHBangLuongDong(int idBangLuong, string type)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("sp_UpdateSoThangDongBaoHiemKhiKhoaBangLuong", "@IdbangLuong", "@Type", idBangLuong, type); ;
    }
}
