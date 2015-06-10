using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Highcharts.Core;
using Highcharts.Core.Data.Chart;
using System.Collections.ObjectModel;
using Highcharts.Core.PlotOptions;

public partial class Modules_Home_chart_LineChart : System.Web.UI.Page
{
    private int userID = -1, menuID = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
            {
                userID = int.Parse(Request.QueryString["userID"]);
            }
            string h = Request.QueryString["height"];
            int height = (h == null) ? 270 : Int32.Parse(h);
            switch (Request.QueryString["type"])
            {
                case "BDNhanSu":
                    int year;
                    string tmp = Request.QueryString["year"];
                    if (tmp != null && tmp != "undefined")
                    {
                        year = Int32.Parse(tmp);
                    }
                    else
                    {
                        year = DateTime.Now.Year;
                    }
                    BieuDoBienDongNhanSu(year, height);
                    break;
                default:
                    break;
            }
        }
    }

    private void BieuDoBienDongNhanSu(int year, int height)
    {
        try
        {
            hcFrutas.Title = new Title(GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_fluctuation") + " " + year);

            string maDV = Session["MaDonVi"].ToString();
            List<BienDongNhanSu> biendongns = new ChartController().GetBienDongNhanSu(maDV, year, userID, menuID);
            object[] _data;     // Tổng số nhân viên
            object[] _moiVao;   // Số nhân viên mới vào
            object[] _nghi;     // Số nhân viên nghỉ
            int maxMonth = 12;
            if (year == DateTime.Now.Year)
            {
                _data = new object[DateTime.Now.Month];
                _moiVao = new object[DateTime.Now.Month];
                _nghi = new object[DateTime.Now.Month];
                maxMonth = DateTime.Now.Month;
            }
            else
            {
                _data = new object[12];
                _moiVao = new object[12];
                _nghi = new object[12];
            }
            for (int i = 0; i < _data.Count(); i++)
            {
                _data[i] = 0;
                _moiVao[i] = 0;
                _nghi[i] = 0;
            }
            for (int i = 0; i < biendongns.Count(); i++)
            {
                if (biendongns[i].daNghi)
                {
                    if (biendongns[i].ngayNghi.Year == year)
                    {
                        if (biendongns[i].ngayTuyenDTien.Year == year)
                        {
                            for (int j = biendongns[i].ngayTuyenDTien.Month - 1; j < biendongns[i].ngayNghi.Month; j++)
                            {
                                _data[j] = (object)((int) _data[j] + 1);
                                if (j == biendongns[i].ngayTuyenDTien.Month - 1)
                                    _moiVao[j] = (object)((int) _moiVao[j] + 1);
                                if (j == biendongns[i].ngayNghi.Month - 1)
                                    _nghi[j] = (object)((int) _nghi[j] + 1);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < biendongns[i].ngayNghi.Month; j++)
                            {
                                _data[j] = (object)((int)_data[j] + 1);
                                if (j == biendongns[i].ngayNghi.Month - 1)
                                    _nghi[j] = (object)((int)_nghi[j] + 1);
                            }
                        }
                    }
                }
                else
                {
                    if (biendongns[i].ngayTuyenDTien.Year == year)
                    {
                        for (int t = biendongns[i].ngayTuyenDTien.Month - 1; t < maxMonth; t++)
                        {
                            _data[t] = (object)((int)_data[t] + 1);
                            if (t == biendongns[i].ngayTuyenDTien.Month - 1)
                                _moiVao[t] = (object)((int) _moiVao[t] + 1);
                        }
                    }
                    else
                    {
                        for (int t = 0; t < maxMonth; t++)
                        {
                            _data[t] = (object)((int)_data[t] + 1);
                        }
                    }
                }
            }

            // ve bieu do
            hcFrutas.YAxis.Add(new YAxisItem { title = new Title(GlobalResourceManager.GetInstance().GetDesktopValue("quantity")) });
            hcFrutas.XAxis.Add(new XAxisItem
            {
                categories = new object[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", 
            "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" }
            });

            //dados
            var series = new Collection<Serie>();

            series.Add(new Serie { name = "Tổng số nhân viên", data = _data });
            series.Add(new Serie { name = "Số nhân viên mới", data = _moiVao});
            series.Add(new Serie { name = "Số nhân viên nghỉ", data = _nghi });

            hcFrutas.PlotOptions = new PlotOptionsLine()
            {
                dataLabels = new DataLabels()
                {
                    enabled = true,
                },
            };
            hcFrutas.Height = height;
            hcFrutas.Legend = new Legend()
            {
                layout = Highcharts.Core.Layout.vertical,
                align = Align.left,
                verticalAlign = Highcharts.Core.VerticalAlign.top,
                x = 0,
                y = -5,
                floating = true,
                shadow = true,
                backgroundColor = "#FFF",
                enabled = true,
            };
            hcFrutas.Exporting.enabled = true;
            hcFrutas.DataSource = series;
            hcFrutas.DataBind();
        }
        catch (Exception ex)
        {
            
            
            throw;
        }
    }
}