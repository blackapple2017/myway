using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;
using DataController;
using Ext.Net;
using Highcharts.Core.Data.Chart;
using Highcharts.Core.PlotOptions;
using Highcharts.Core;
using SoftCore.Security;
using System.Data;
using ToolTip = Highcharts.Core.ToolTip;


public partial class Modules_Home_chart_QualificationsChart : WebBase
{
    private bool displayPercentage = false;
    private int userID = -1, menuID = DepartmentRoleController.MENUID_CHART;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                userID = int.Parse(Request.QueryString["userID"]);
            }
            string h = Request.QueryString["height"];
            int height = (h == null) ? 300 : Int32.Parse(h);
            string s = Request.QueryString["size"];
            int size = (s == null) ? 160 : Int32.Parse(s);
            string maDotTD = Request.QueryString["MaDotTuyenDung"];
            int maDotTuyenDung = (maDotTD == null) ? 0 : int.Parse(maDotTD);
            switch (Request.QueryString["type"])
            {
                case "Level":
                    BieuDoTrinhDo(height, size);
                    break;
                case "Gender":
                    Gender(height, size);
                    break;
                case "Country":
                    Country(height, size);
                    break;
                case "TTHonNhan":
                    MarriageStatus(height, size);
                    break;
                case "TonGiao":
                    Religion(height, size);
                    break;
                case "DanToc":
                    Ethnicity(height, size);
                    break;
                case "LoaiHD":
                    ContractType(height, size);
                    break;
                case "NhanSuTheoPhongBan":
                    Department(height, size);
                    break;
                case "NhanSuTheoTinhThanh":
                    Province(height, size);
                    break;
                case "NhanSuTheoChucVuDoan":
                    NhanSuTheoChucVuDoan(height, size);
                    break;
                case "CapBacQuanDoi":
                    CapBacQuanDoi(height, size);
                    break;
                case "ThongKeChucVuDang":
                    ThongKeChucVuDang(height, size);
                    break;
                case "ThongKeTheoThamNienCT":
                    ThongKeTheoThamNienCongTac(height, size);
                    break;
                case "LyDoNghiViec":
                    ThongKeLyDoNghiViec(height, size);
                    break;
                // Báo cáo cho phân hệ tuyển dụng: daibx 19/07/2013
                case "NguonUngVien":
                    TuyenDung_ThongKeUngVienTheoNguon(height, size, maDotTuyenDung);
                    break;
                case "TyLeTruot":
                    TuyenDung_ThongKeUngVienTruot(height, size, maDotTuyenDung);
                    break;
            }
        }
    }

    private void ThongKeLyDoNghiViec(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeTheoLyDoNghiViec", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                if (displayPercentage)
                {
                    data[k++] = new object[] { table.Rows[i]["TEN_LYDO_NGHI"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                }
                else
                {
                    data[k++] = new object[] { table.Rows[i]["TEN_LYDO_NGHI"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_reason_for_leaving"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }

    private void ThongKeChucVuDang(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoChucVuDang", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                if (displayPercentage)
                {
                    data[k++] = new object[] { table.Rows[i]["TEN_CHUCVU_DANG"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                }
                else
                {
                    data[k++] = new object[] { table.Rows[i]["TEN_CHUCVU_DANG"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_party_office"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }

    private void CapBacQuanDoi(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoCapBacQuanDoi", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                if (displayPercentage)
                {
                    data[k++] = new object[] { table.Rows[i]["TEN_CAPBAC_QDOI"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                }
                else
                {
                    data[k++] = new object[] { table.Rows[i]["TEN_CAPBAC_QDOI"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_military_grade"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }

    private void NhanSuTheoChucVuDoan(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoChucVuDoan", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_CHUCVU_DOAN"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_CHUCVU_DOAN"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_union_office"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Tỉnh thành
    /// </summary>
    /// <param name="height"></param>
    /// <param name="size"></param>
    private void Province(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoTinhThanh", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TINHTHANH"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TINHTHANH"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_city"), height, size, false);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }

    private void Department(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoPhong", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_DONVI"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_DONVI"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_section"), height, size, false);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Tình trạng hôn nhân
    /// </summary>
    /// <param name="height"></param>
    /// <param name="size"></param>
    private void MarriageStatus(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();

            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoTinhTrangHonNhan", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TT_HN"] + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TT_HN"] + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_marriage_status"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Tôn giáo
    /// </summary>
    /// <param name="height"></param>
    /// <param name="size"></param>
    private void Religion(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoTonGiao", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TONGIAO"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TONGIAO"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_religion"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Dân tộc
    /// </summary>
    /// <param name="height"></param>
    /// <param name="size"></param>
    private void Ethnicity(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeTheoDanToc", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_DANTOC"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_DANTOC"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_ethnicity"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Loại hợp đồng
    /// </summary>
    /// <param name="height"></param>
    /// <param name="size"></param>
    private void ContractType(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();

            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoLoaiHopDong", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, tong = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    tong++;
                }
            }
            object[] data = new object[tong];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_LOAI_HDONG"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_LOAI_HDONG"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_contract_type"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Quốc tịch
    /// </summary>
    /// <param name="height"></param>
    /// <param name="size"></param>
    private void Country(int height, int size)
    {
        try
        {
            // lay ma don vi
            string maDV = Session["MaDonVi"].ToString();

            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoQuocTich", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);
            int total = 0, max = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    max++;
                }
            }
            object[] _data = new object[max];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        _data[k++] = new object[] { table.Rows[i]["TEN_NUOC"] + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        _data[k++] = new object[] { table.Rows[i]["TEN_NUOC"] + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(_data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_natinonality"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Bind biểu đồ trình độ
    /// </summary>
    private void BieuDoTrinhDo(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoTrinhDo", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int total = 0, max = 0, k = 0;
            foreach (DataRow item in table.Rows)
            {
                if (int.Parse(item["Count"].ToString()) > 0)
                {
                    total += int.Parse(item["Count"].ToString());
                    max++;
                }
            }
            object[] data = new object[max];
            float percentage = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (int.Parse(table.Rows[i]["Count"].ToString()) > 0)
                {
                    percentage = (float.Parse(table.Rows[i]["Count"].ToString()) / (float)total) * 100;
                    if (displayPercentage)
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TRINHDO"].ToString() + " (" + table.Rows[i]["Count"] + " người, chiếm " + percentage + " %)", percentage };
                    }
                    else
                    {
                        data[k++] = new object[] { table.Rows[i]["TEN_TRINHDO"].ToString() + " (" + table.Rows[i]["Count"] + ")", percentage };
                    }
                }
            }
            BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_level"), height, size, true);
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
    /// <summary>
    /// Bind Biểu đồ giới tính
    /// </summary>
    private void Gender(int height, int size)
    {
        try
        {
            // lay ma don vi
            string maDV = Session["MaDonVi"].ToString();

            int male = 0;
            int female = 0;
            float percentageMale = 0;
            float percentageFemale = 0;
            new ChartController().GetGenderNumber(out male, out female, maDV, userID, menuID);
            float nam = ((float)male / (float)(male + female)) * 100;
            percentageMale = ((float)male / ((float)male + (float)female)) * 100;
            percentageFemale = (100 - percentageMale);
            if (displayPercentage)
            {
                object[] data = new object[]
                { 
                    new object[]{"Nam" + " (" + male + " người, chiếm "+percentageMale+" % )",nam},
                    new object[]{"Nữ" + " (" + female + " người, chiếm "+percentageFemale+" % )",100-nam},
                };
                BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_gender"), height, size, true);
            }
            else
            {
                object[] data = new object[]
                { 
                    new object[]{"Nam" + " (" + male + ")",nam},
                    new object[]{"Nữ" + " (" + female + ")",100-nam},
                };
                BindData(data, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_gender"), height, size, true);
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }

    private void ThongKeTheoThamNienCongTac(int height, int size)
    {
        try
        {
            string maDV = Session["MaDonVi"].ToString();
            DataTable table = DataHandler.GetInstance().ExecuteDataTable("BieuDo_ThongKeNhanSuTheoThamNienCongTac", "@MaDonVi", "@UserID", "@MenuID", maDV, userID, menuID);

            int[] MocTN = { 0, 5, 10 };
            int count = MocTN.Length;
            object[] tenMoc = new object[count + 1];
            int[] data = new int[count + 1];

            // create MocTN[]
            tenMoc[0] = "Dưới " + MocTN[1] + " năm";
            data[0] = 0;
            for (int i = 1; i < count - 1; i++)
            {
                tenMoc[i] = MocTN[i] + "-" + MocTN[i + 1] + " năm";
                data[i] = 0;
            }
            tenMoc[count - 1] = "Trên " + MocTN[count - 1] + " năm";
            data[count - 1] = 0;
            tenMoc[count] = "Không xác định";
            data[count] = 0;
            int total = 0;

            foreach (DataRow item in table.Rows)
            {
                int index = 0;
                for (int i = 0; i < count; i++)
                {
                    if (int.Parse(item["years"].ToString()) == -1)
                    {
                        index = count;
                        break;
                    }
                    if (int.Parse(item["years"].ToString()) >= MocTN[count - 1])
                    {
                        index = count - 1;
                        break;
                    }
                    if (int.Parse(item["years"].ToString()) < MocTN[i] && int.Parse(item["years"].ToString()) >= 0)
                    {
                        if (i > 0)
                            index = i - 1;
                        break;
                    }
                }
                total++;
                data[index] = data[index] + 1;
            }

            int sz = 0;
            for (int j = 0; j < data.Count(); j++)
                if (data[j] > 0)
                    sz++;

            object[] obj = new object[sz];
            int k = 0;
            for (int i = 0; i <= count; i++)
            {
                if (data[i] > 0)
                    obj[k++] = new object[] { tenMoc[i] + " (" + data[i] + ")", ((float)data[i]) / ((float)total) * 100 };
            }

            BindData(obj, GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_length_of_service"), height, size, true);
        }
        catch (Exception ex)
        {
            X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), "Thâm niên công tác: " + ex.Message.ToString()).Show();
        }
    }

    // Biểu đồ: Báo cáo kết quả tuyển dụng
    private void TuyenDung_ThongKeUngVienTheoNguon(int height, int size, int maDotTuyenDung)
    {
        object[] data = GetData(maDotTuyenDung);
        BindData(data, "Thống kê ứng viên theo nguồn", height, size, true);
    }

    private void TuyenDung_ThongKeUngVienTruot(int height, int size, int maDotTuyenDung)
    {
        object[] data = GetDataTyLeDoTruot(maDotTuyenDung);
        BindData(data, "Thống kê tỷ lệ ứng viên trượt", height, size, true);
    }

    private object[] GetDataTyLeDoTruot(int maDotTuyenDung)
    {
        try
        {
            switch (maDotTuyenDung)
            {
                case 70:
                    object[] data1 = new object[3];
                    data1[0] = new object[] { "Trượt (50)", (float)50 * 100 / 100 };
                    data1[1] = new object[] { "Qua vòng sơ loại (50)", (float)50 * 100 / 100 };
                    return data1;
                case 69:
                    object[] data2 = new object[2];
                    data2[0] = new object[] { "Trượt (22)", (float)22 * 100 / 37 };
                    data2[1] = new object[] { "Qua vòng sơ loại (15)", (float)15 * 100 / 37 };
                    return data2;
                case 71:
                    object[] data3 = new object[2];
                    data3[0] = new object[] { "Trượt (6)", (float)6 * 100 / 20 };
                    data3[1] = new object[] { "Qua vòng sơ loại (14)", (float)14 * 100 / 20 };
                    return data3;
                case 72:
                    object[] data4 = new object[2];
                    data4[0] = new object[] { "Trượt (9)", (float)9 * 100 / 36 };
                    data4[1] = new object[] { "Qua vòng sơ loại (27)", (float)27 * 100 / 36 };
                    return data4;
                default:
                    return new object[0];
            }
        }
        catch
        {
            throw;
        }
    }

    private object[] GetData(int maDotTuyenDung)
    {
        try
        {
            switch (maDotTuyenDung)
            {
                case 70:
                    object[] data1 = new object[3];
                    data1[0] = new object[] { "Website của công ty (6)", (float)6 * 100 / 15 };
                    data1[1] = new object[] { "Các mối quan hệ (3)", (float)3 * 100 / 15 };
                    data1[2] = new object[] { "Vieclam24h.vn (6)", (float)6 * 100 / 15 };
                    return data1;
                case 69:
                    object[] data2 = new object[2];
                    data2[0] = new object[] { "Vietnamworks.com (3)", (float)3 * 100 / 4 };
                    data2[1] = new object[] { "Vieclam24h.vn (1)", (float)1 * 100 / 4 };
                    return data2;
                case 71:
                    object[] data3 = new object[1];
                    data3[0] = new object[] { "Vietnamworks.com (2)", (float)2 * 100 / 2 };
                    return data3;
                case 72:
                    object[] data4 = new object[4];
                    data4[0] = new object[] { "Vietnamworks.com (5)", (float)6 * 100 / 10 };
                    data4[1] = new object[] { "Website của công ty (1)", (float)1 * 100 / 10 };
                    data4[2] = new object[] { "Các mối quan hệ (1)", (float)1 * 100 / 10 };
                    data4[3] = new object[] { "Vieclam24h.vn (3)", (float)3 * 100 / 10 };
                    return data4;
                default:
                    return new object[0];
            }
        }
        catch
        {
            throw;
        }
    }

    private void BindData(object[] _data, string Title, int nHeight, int nSize, bool showInLegend)
    {
        try
        {
            hcVendas.Title = new Title(Title);
            //   hcVendas.SubTitle = new SubTitle("(Chỉ thống kê theo những nhân viên đang làm việc)");
            hcVendas.Height = nHeight;
            var series = new Collection<Serie>();
            series.Add(new Serie
            {
                size = nSize,
                data = _data
            });

            hcVendas.PlotOptions = new PlotOptionsPie
            {
                allowPointSelect = true,
                cursor = "pointer",
                dataLabels = new DataLabels
                {
                    enabled = true,
                    align = Align.right,
                    y = 10,
                    verticalAlign = Highcharts.Core.VerticalAlign.top

                },
                animation = true,
                enableMouseTracking = true,
                showInLegend = showInLegend,
            };
            hcVendas.Legend = new Legend()
            {
                enabled = true,
                layout = Highcharts.Core.Layout.vertical,
                align = Align.left,
                verticalAlign = Highcharts.Core.VerticalAlign.top,
                x = 5,
                y = 10,
                floating = true,
                shadow = true,
                backgroundColor = "#FFF",
            };
            if (displayPercentage)
            {
                //hide percentage when mouse hover
                hcVendas.Tooltip = new ToolTip("'<b>'+ this.point.name +'</b>'");
            }
            else
            {
                //display percentage when mouse hover
                hcVendas.Tooltip = new ToolTip("'<b>'+ this.point.name +'</b>: '+ this.y +' %'");
            }
            hcVendas.Exporting.enabled = true;
            hcVendas.DataSource = series;
            hcVendas.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), ex.Message).Show();
        }
    }
}