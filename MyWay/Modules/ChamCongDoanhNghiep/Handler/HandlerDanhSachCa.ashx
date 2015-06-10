<%@ WebHandler Language="C#" Class="HandlerDanhSachCa" %>

using System;
using System.Web;
using Ext.Net;
using System.Data;
using System.Collections.Generic;
using Controller.ChamCongDoanhNghiep;

public class HandlerDanhSachCa : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Start = 0;
        var Limit = 15;
        var SearchKey = string.Empty;
        var MaDonVi = context.Request["MaDonVi"];
        var Count = 0;

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
        var data = new DanhSachCaController().GetAll(Start, Limit, MaDonVi, SearchKey, out Count);

        DataTable table = CreateDataTable();
        for (int i = 0; i < data.Count; i++)
        {
            DataRow dr = table.NewRow();
            dr["ID"] = data[i].ID;
            dr["MaCa"] = data[i].MaCa;
            dr["TenCa"] = data[i].TenCa;

            string maCa = data[i].MaCa;
            int number = 0;
            while (data[i].MaCa == maCa)
            {
                dr["GioVao"] += data[i].GioVao + "##";
                dr["GioRa"] += data[i].GioRa + "##";
                dr["NghiGiuaCa"] += data[i].NghiGiuaCa + "##";
                dr["VaoGiuaCa"] += data[i].VaoGiuaCa + "##";
                dr["NgayApDung"] += GetNgayApDung(data[i].NgayApDung) + "##";

                dr["QuetTheDauCa"] += "<span class='style_time'>" + data[i].BatDauQuetTheLan1 + "</span>";
                if (data[i].KetThucQuetTheLan1 != "")
                    dr["QuetTheDauCa"] += " đến <span class='style_time'>" + data[i].KetThucQuetTheLan1 + "</span>##";
                else
                    dr["QuetTheDauCa"] += "##";

                dr["QuetTheNghiDauCa"] += "<span class='style_time'>" + data[i].BatDauQuetTheLan2 + "</span>";
                if (data[i].KetThucQuetTheLan2 != "")
                    dr["QuetTheNghiDauCa"] += " đến <span class='style_time'>" + data[i].KetThucQuetTheLan2 + "</span>##";
                else
                    dr["QuetTheNghiDauCa"] += "##";

                dr["QuetTheVaoCaSau"] += "<span class='style_time'>" + data[i].BatDauQuetTheLan3 + "</span>";
                if (data[i].KetThucQuetTheLan3 != "")
                    dr["QuetTheVaoCaSau"] += " đến <span class='style_time'>" + data[i].KetThucQuetTheLan3 + "</span>##";
                else
                    dr["QuetTheVaoCaSau"] += "##";

                dr["QuetTheCuoiCa"] += "<span class='style_time'>" + data[i].BatDauQuetTheLan4 + "</span>";
                if (data[i].KetThucQuetTheLan4 != "")
                    dr["QuetTheCuoiCa"] += " đến <span class='style_time'>" + data[i].KetThucQuetTheLan4 + "</span>##";
                else
                    dr["QuetTheCuoiCa"] += "##";

                dr["SoPhutChoPhepDiMuon"] += (data[i].SoPhutChoPhepDiMuon != null ? data[i].SoPhutChoPhepDiMuon + " phút" : " ") + "##";
                dr["SoPhutChoPhepVeSom"] += (data[i].SoPhutChoPhepVeSom != null ? data[i].SoPhutChoPhepVeSom + " phút" : " ") + "##";
                dr["BatDauTinhLamThemDauGio"] += data[i].BatDauTinhLamThemDauGio + "##";
                dr["BatDauTinhLamThemCuoiGio"] += data[i].BatDauTinhLamThemCuoiGio + "##";
                dr["PhuCapCa"] += RenderMoney(data[i].PhuCapCa + "") + "##";
                dr["TienLuongCa"] += RenderMoney(data[i].TienLuongCa + "") + "##";
                dr["ThoiGianApDungTu"] += (data[i].ThoiGianApDungTu != null ? data[i].ThoiGianApDungTu.Value.ToString("dd/MM/yyyy") : " ") + "##";
                dr["ThoiGianApDungDen"] += (data[i].ThoiGianApDungDen != null ? data[i].ThoiGianApDungDen.Value.ToString("dd/MM/yyyy") : " ") + "##";
                dr["CreatedDate"] += (data[i].CreatedDate != null ? data[i].CreatedDate.ToString("dd/MM/yyyy") : " ") + "##";
                dr["TongGio"] += data[i].TongGio + "##";
                dr["LoaiCa"] += data[i].LoaiCa + "##";
                i++;
                number++;
                if (i >= data.Count)
                    break;
            }
            table.Rows.Add(dr);
            i--;
        }
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(table), Count));
    }

    private string GetNgayApDung(string value)
    {
        if (value == "NgayThuong")
            return "Ngày thường";
        if (value == "NgayNghi")
            return "Ngày nghỉ";
        if (value == "NgayLe")
            return "Ngày lễ";
        return "";
    }

    private string RenderMoney(string money)
    {
        string result = "";
        int count = 1;
        for (int i = money.Length - 1; i >= 0; i--)
        {
            result = money[i] + result;
            if (count % 3 == 0 && count != money.Length)
                result = '.' + result;
            count++;
        }
        return result;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private DataTable CreateDataTable()
    {
        try
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("MaCa");
            dt.Columns.Add("TenCa");
            dt.Columns.Add("GioVao");
            dt.Columns.Add("GioRa");
            dt.Columns.Add("NghiGiuaCa");
            dt.Columns.Add("VaoGiuaCa");
            dt.Columns.Add("SoPhutChoPhepDiMuon");
            dt.Columns.Add("SoPhutChoPhepVeSom");
            dt.Columns.Add("BatDauTinhLamThemDauGio");
            dt.Columns.Add("BatDauTinhLamThemCuoiGio");
            dt.Columns.Add("PhuCapCa");
            dt.Columns.Add("TienLuongCa");
            dt.Columns.Add("RaNgoaiKhongBiTruGio");
            dt.Columns.Add("QuetTheDauCa");
            dt.Columns.Add("QuetTheNghiDauCa");
            dt.Columns.Add("QuetTheVaoCaSau");
            dt.Columns.Add("QuetTheCuoiCa");
            dt.Columns.Add("ThoiGianApDungTu");
            dt.Columns.Add("ThoiGianApDungDen");
            dt.Columns.Add("NgayApDung");
            dt.Columns.Add("CreatedDate");
            dt.Columns.Add("TongGio");
            dt.Columns.Add("LoaiCa");

            return dt;
        }
        catch
        {
            return null;
        }
    }
}