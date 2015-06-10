<%@ WebHandler Language="C#" Class="HandlerTyLeUngVien" %>

using System;
using System.Web;

public class HandlerTyLeUngVien : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        object[] data = GetData();
        int count = data.Length;
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }

    private object[] GetData()
    {
        return new object[]
        {
            new {MaKHTD = "70", TenKHTD = "Tuyển nhân viên triển khai", TenPhong = "Phòng chuyển giao", TenCongViec = "Nhân viên triển khai", TyLeDatSoLoai = "50/100", TyLeTiepNhanThuViec = "25/100", TyLeTiepNhanChinhThuc = "15/100", TyLeNghiSauTuyenDung = "5/100"},
            new {MaKHTD = "69", TenKHTD = "Tuyển nhân viên chăm sóc khách hàng", TenPhong = "Phòng chuyển giao", TenCongViec = "Nhân viên chăm sóc khách hàng", TyLeDatSoLoai = "15/37", TyLeTiepNhanThuViec = "7/37", TyLeTiepNhanChinhThuc = "4/37", TyLeNghiSauTuyenDung = "0/37"},
            new {MaKHTD = "71", TenKHTD = "Tuyển lập trình viên ASP.NET", TenPhong = "Phòng phát triển", TenCongViec = "Nhân viên lập trình", TyLeDatSoLoai = "14/20", TyLeTiepNhanThuViec = "7/20", TyLeTiepNhanChinhThuc = "2/20", TyLeNghiSauTuyenDung = "0/20"},
            new {MaKHTD = "72", TenKHTD = "Tuyển Tester gấp", TenPhong = "Phòng phát triển", TenCongViec = "Nhân viên Tester", TyLeDatSoLoai = "27/36", TyLeTiepNhanThuViec = "20/36", TyLeTiepNhanChinhThuc = "10/36", TyLeNghiSauTuyenDung = "1/36"}
        };
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}