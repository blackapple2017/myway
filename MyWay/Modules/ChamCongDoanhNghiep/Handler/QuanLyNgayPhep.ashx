<%@ WebHandler Language="C#" Class="QuanLyNgayPhep" %>

using System;
using System.Web;

public class QuanLyNgayPhep : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int start = 0;
        int limit = 10;
        int count = 0;
        int soNgayDaSuDung = string.IsNullOrEmpty(context.Request["SoNgayDaSuDung"]) ? -1 : int.Parse(context.Request["SoNgayDaSuDung"]);
        int tongSoNgayPhep = string.IsNullOrEmpty(context.Request["TongSoNgayPhep"]) ? -1 : int.Parse(context.Request["TongSoNgayPhep"]);
        int soNgayConLai = string.IsNullOrEmpty(context.Request["SoNgayConLai"]) ? -1 : int.Parse(context.Request["SoNgayConLai"]);
        int congDonNgayPhep = string.IsNullOrEmpty(context.Request["CongDonNgayPhep"]) ? -1 : int.Parse(context.Request["CongDonNgayPhep"]);
      //  int thamNien = string.IsNullOrEmpty(context.Request["ThamNien"]) ? -1 : int.Parse(context.Request["ThamNien"]);

        string maDonVi = context.Request["MaDonVi"]; 
        string maCB = context.Request["MaCB"];
        string hoTen = context.Request["HoTen"];

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(hoTen))
        {
            hoTen = "%" + SoftCore.Util.GetInstance().GetKeyword(hoTen) + "%";
        }
      //  var data = new DanhSachNgayPhepController().GetAll(start, limit, out count, maCB, hoTen,soNgayDaSuDung,tongSoNgayPhep,soNgayConLai,congDonNgayPhep, maDonVi);
      //  context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), count));
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}