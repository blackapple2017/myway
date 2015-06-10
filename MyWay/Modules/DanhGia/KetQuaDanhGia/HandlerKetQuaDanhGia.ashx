<%@ WebHandler Language="C#" Class="HandlerKetQuaDanhGia" %>

using System;
using System.Web;
using System.Data;
using Controller.DanhGia;

public class HandlerKetQuaDanhGia : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 20;
        var SearchKey = string.Empty;
        var Count = 0;
        string maDV = context.Request["MaDonVi"].ToString();
        string maDotDanhGia = string.Empty;
        decimal tuDanhGia = decimal.Parse("0" + context.Request["TuDanhGia"]);
        decimal quanLyDanhGia = decimal.Parse("0" + context.Request["QuanLyDanhGia"]);
        decimal nguoiKhacDanhGia = decimal.Parse("0" + context.Request["NguoiKhacDanhGia"]);

        if (!string.IsNullOrEmpty(context.Request["start"]))
        {
            Start = int.Parse(context.Request["start"]);
        }
        if (!string.IsNullOrEmpty(context.Request["limit"]))
        {
            Limit = int.Parse(context.Request["limit"]);
        }
        if (!string.IsNullOrEmpty(context.Request["SearchKey"]))
        {
            SearchKey = context.Request["SearchKey"];
            SearchKey = "%" + SoftCore.Util.GetInstance().GetKeyword(SearchKey) + "%";
        }
        if (!string.IsNullOrEmpty(context.Request["MaDotDanhGia"]))
        {
            maDotDanhGia = context.Request["MaDotDanhGia"];
        }

        var data = new KetQuaDanhGiaController().GetAllRecord(maDotDanhGia, Start, Limit, SearchKey, maDV, out Count);
        DataTable obj = RankKetQuaDanhGia(data, tuDanhGia, quanLyDanhGia, nguoiKhacDanhGia, maDotDanhGia);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(obj), Count));
    }

    private DataTable RankKetQuaDanhGia(System.Data.DataTable data, decimal tuDanhGia, decimal qlDanhGia, decimal nguoiKhacDanhGia, string maDotDanhGia)
    {
        DataTable obj = CreateDataTable();
        foreach (System.Data.DataRow item in data.Rows)
        {
            DataRow dr = obj.NewRow();
            dr["MaCB"] = item["MaCB"];
            dr["HO_TEN"] = item["HO_TEN"];
            dr["TEN_DONVI"] = item["TEN_DONVI"];
            dr["TEN_CHUCVU"] = item["TEN_CHUCVU"];
            //dr["DiemTuDanhGia"] = item["DiemTuDanhGia"];
            //dr["NguoiKhacDanhGia"] = item["NguoiKhacDanhGia"];
            //dr["DiemNguoiQLDanhGia"] = item["DiemNguoiQLDanhGia"];

            decimal tongDiem = 0;
            decimal diemTuDanhGia = decimal.Parse("0" + item["DiemTuDanhGia"].ToString());
            decimal diemNguoiKhacDanhGia = decimal.Parse("0" + item["NguoiKhacDanhGia"].ToString());
            decimal diemQLDanhGia = decimal.Parse("0" + item["DiemNguoiQLDanhGia"].ToString());

            dr["DiemTuDanhGia"] = Math.Round(diemTuDanhGia, 2);
            dr["NguoiKhacDanhGia"] = Math.Round(diemNguoiKhacDanhGia, 2);
            dr["DiemNguoiQLDanhGia"] = Math.Round(diemQLDanhGia, 2);

            decimal count = 0;
            if (diemTuDanhGia >= 0)
            {
                tongDiem += diemTuDanhGia * tuDanhGia;
                count += tuDanhGia;
            }
            if (diemQLDanhGia >= 0)
            {
                tongDiem += diemQLDanhGia * qlDanhGia;
                count += qlDanhGia;
            }
            if (diemNguoiKhacDanhGia >= 0)
            {
                tongDiem += diemNguoiKhacDanhGia * nguoiKhacDanhGia;
                count += nguoiKhacDanhGia;
            }
            if (tongDiem >= 0)
                tongDiem = Math.Round(tongDiem / count, 2);
            else
                continue;

            dr["TongDiem"] = tongDiem;
            DataTable loaiXH = new LoaiXepHangController().GetByMaDotDanhGia(maDotDanhGia);
            dr["TenXepLoai"] = GetTenXepLoai(loaiXH, tongDiem);

            obj.Rows.Add(dr);
        }
        return obj;
    }

    private string GetTenXepLoai(DataTable loaiXH, decimal trungBinh)
    {
        foreach (DataRow item in loaiXH.Rows)
        {
            decimal tuDiem = decimal.Parse(item["TuDiem"].ToString());
            decimal denDiem = decimal.Parse(item["DenDiem"].ToString());

            if (trungBinh >= tuDiem && trungBinh <= denDiem)
                return "Xếp loại: " + item["TenXepHang"].ToString();
        }
        return "";
    }

    private DataTable CreateDataTable()
    {
        try
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MaCB");
            dt.Columns.Add("HO_TEN");
            dt.Columns.Add("TEN_DONVI");
            dt.Columns.Add("TEN_CHUCVU");
            dt.Columns.Add("DiemTuDanhGia");
            dt.Columns.Add("NguoiKhacDanhGia");
            dt.Columns.Add("DiemNguoiQLDanhGia");
            dt.Columns.Add("TongDiem");
            dt.Columns.Add("TrangThaiDanhGia");
            dt.Columns.Add("TenXepLoai");

            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
