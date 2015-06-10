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
using DAL;
using SoftCore.Security;
using System.Data;
using Ext.Net;

public partial class Modules_Home_chart_ColumnChart : WebBase
{
    private bool displayPercentage = true;
    private int userID = -1, menuID = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["userID"]))
                {
                    userID = int.Parse(Request.QueryString["userID"]);
                }
                string h = Request.QueryString["height"];
                int height = (h == null) ? 250 : Int32.Parse(h);
                string macb = Request.QueryString["id"];
                int thang = int.Parse(Request.QueryString["thang"] == null ? "0" : Request.QueryString["thang"]);
                int nam = int.Parse(Request.QueryString["nam"] == null ? "0" : Request.QueryString["nam"]);

                switch (Request.QueryString["type"])
                {
                    case "NSDonVi":
                        string dsDonVi = Request.QueryString["dv"];
                        if (string.IsNullOrEmpty(dsDonVi))
                            dsDonVi = Session["MaDonVi"].ToString();
                        GenerateNhanSuTheoDonVi(height, dsDonVi);
                        break;

                    case "Age":
                        BieuDoTheoDoTuoi(height);
                        break;

                    case "DiMuonVeSom":
                        BieuDoThongKeTinhTrangDiMuonVeSom(macb, thang, nam, height);
                        break;

                    //case "BDNhanSu":
                    //    BieuDoBienDongNhanSu();
                    //    break;

                    default:
                        //GenerateNhanSuTheoDonVi(height);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert(GlobalResourceManager.GetInstance().GetLanguageValue("warning"), "Có lỗi xảy ra: " + ex.Message).Show();
        }
    }

    private void GenerateNhanSuTheoDonVi(int height, string dsDonVi)
    {
        try
        {
            hcFrutas.Title = new Title(GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_unit"));
            hcFrutas.Height = height;
            //Danh sách giới tinh theo đơn vị
            List<NhanSu> nhansu = new ChartController().GetBaoCaoGioiTinhTheoDonVi(dsDonVi, userID, menuID);

            List<DM_DONVI> dvList = new DM_DONVIController().GetByDS(dsDonVi);
            int total = dvList.Count();
            object[] dvdata = new object[total];
            object[] MaleData = new object[total];
            object[] FemaleData = new object[total];

            for (int i = 0; i < dvList.Count(); i++)
            {
                dvdata[i] = dvList[i].TEN_DONVI;
                string[] dv = new DM_DONVIController().GetAllMaDonVi(dvList[i].MA_DONVI).Split(',');
                MaleData[i] = (from t in nhansu where dv.Contains(t.MaDonVi) && t.MaGioiTinh == "M" select t).ToList().Count();//lấy số lượng nhân viên nam
                FemaleData[i] = (from p in nhansu where dv.Contains(p.MaDonVi) && p.MaGioiTinh == "F" select p).ToList().Count();//lấy số lượng nhân viên nữ
            }


            //definições de eixos
            hcFrutas.YAxis.Add(new YAxisItem { title = new Title("Số lượng") });
            hcFrutas.XAxis.Add(new XAxisItem { categories = dvdata });

            //dados
            var series = new Collection<Serie>();

            series.Add(new Serie { name = "Nam", data = MaleData });
            series.Add(new Serie { name = "Nữ", data = FemaleData });

            hcFrutas.PlotOptions = new PlotOptionsColumn()
            {
                borderColor = "#dedede",
                borderRadius = 4,
                dataLabels = new DataLabels()
                {
                    enabled = true,
                },
            };
            hcFrutas.Legend = new Legend()
            {
                layout = Highcharts.Core.Layout.horizontal,
                align = Align.left,
                verticalAlign = Highcharts.Core.VerticalAlign.top,
                x = 70,
                y = -5,
                floating = true,
                shadow = true,
                backgroundColor = "#FFF",
            };
            hcFrutas.Exporting.enabled = true;
            hcFrutas.DataSource = series;
            hcFrutas.DataBind();
        }
        catch
        {
            throw;
        }
    }

    /******** Do Tuoi ******/
    private void BieuDoTheoDoTuoi(int height)
    {
        try
        {
            hcFrutas.Title = new Title(GlobalResourceManager.GetInstance().GetDesktopValue("chart_by_age"));

            // lay ma don vi
            string maDV = Session["MaDonVi"].ToString();

            // danh sach do tuoi
            List<ThongKeDoTuoi> ageList = new ChartController().GetDanhSachDoTuoi(maDV, userID, menuID);

            int[] MocTuoi = { 0, 18, 30, 40, 50 };
            int count = MocTuoi.Length;
            object[] tenMoc = new object[count];
            object[] ageData = new object[count];

            // create MocTuoi[]
            tenMoc[0] = "0 - 18";
            ageData[0] = 0;
            for (int i = 1; i < count - 1; i++)
            {
                tenMoc[i] = (MocTuoi[i] + 1) + " - " + MocTuoi[i + 1];
                ageData[i] = 0;
            }
            tenMoc[count - 1] = "Trên " + MocTuoi[count - 1];
            ageData[count - 1] = 0;

            foreach (ThongKeDoTuoi tmp in ageList)
            {
                int index = 0;
                for (int i = 0; i < count; i++)
                {
                    if (tmp.Tuoi >= MocTuoi[count - 1])
                    {
                        index = count - 1;
                        break;
                    }
                    if (tmp.Tuoi <= MocTuoi[i] && tmp.Tuoi >= 0)
                    {
                        if (i > 0)
                            index = i - 1;
                        break;
                    }
                }

                ageData[index] = (object)((int)ageData[index] + 1);
            }

            // ve bieu do
            hcFrutas.YAxis.Add(new YAxisItem { title = new Title(GlobalResourceManager.GetInstance().GetDesktopValue("quantity")) });
            hcFrutas.XAxis.Add(new XAxisItem { categories = tenMoc });

            //dados
            var series = new Collection<Serie>();

            series.Add(new Serie { name = "Nhân viên", data = ageData });

            hcFrutas.PlotOptions = new PlotOptionsColumn()
            {
                borderColor = "#dedede",
                borderRadius = 4,
                dataLabels = new DataLabels()
                {
                    enabled = true,
                },
            };
            hcFrutas.Height = height;
            hcFrutas.Legend = new Legend()
            {
                layout = Highcharts.Core.Layout.horizontal,
                align = Align.left,
                verticalAlign = Highcharts.Core.VerticalAlign.top,
                x = 70,
                y = -5,
                floating = true,
                shadow = true,
                backgroundColor = "#FFF",
                enabled = false,
            };
            hcFrutas.Exporting.enabled = true;
            hcFrutas.DataSource = series;
            hcFrutas.DataBind();
        }
        catch
        {
            throw;
        }
    }

    /*
     * Biểu đồ thống kê tình trạng đi muộn về sớm
     * daibx    22/06/2013
     */
    private void BieuDoThongKeTinhTrangDiMuonVeSom(string macb, int thang, int nam, int height)
    {
        try
        {
            string MaDonVi = Session["MaDonVi"].ToString();

            var data = DataController.DataHandler.GetInstance().ExecuteDataTable("ChamCong_GetDiMuonVeSomByMaCB", "@MA_CB", "@Thang", "@Nam", macb, thang, nam);

            string batDauLamSa = new HeThongController().GetValueByName(SystemConfigParameter.BAT_DAU_LAM_SANG, MaDonVi);
            string ketThucLamSa = new HeThongController().GetValueByName(SystemConfigParameter.KET_THUC_LAM_SANG, MaDonVi);
            string batDauLamCh = new HeThongController().GetValueByName(SystemConfigParameter.BAT_DAU_LAM_CHIEU, MaDonVi);
            string ketThucLamCh = new HeThongController().GetValueByName(SystemConfigParameter.KET_THUC_LAM_CHIEU, MaDonVi);
            string HThucLamT7 = new HeThongController().GetValueByName(SystemConfigParameter.HINH_THUC_LAM_T7, MaDonVi);
            string HThucLamCN = new HeThongController().GetValueByName(SystemConfigParameter.HINH_THUC_LAM_CN, MaDonVi);
            int soPhutChoPhepVeSom = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_CHO_PHEP_VE_SOM, MaDonVi));
            int soPhutChoPhepDiMuon = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_CHO_PHEP_DI_MUON, MaDonVi));
            int soPhutMinCoiLaLamThem = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_TOI_THIEU_DUOC_TINH_LAM_THEM, MaDonVi));
            bool choPhepLamThemDauGio = bool.Parse(new HeThongController().GetValueByName(SystemConfigParameter.CHO_PHEP_LAM_THEM_DAU_GIO, MaDonVi));
            int soPhutDiMuonCoiLaNghi = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_DI_MUON_COI_LA_NGHI, MaDonVi));

            int gioVaoSang = int.Parse(batDauLamSa.Split(':')[0]);
            int phutVaoSang = int.Parse(batDauLamSa.Split(':')[1]);
            int gioRaSang = int.Parse(ketThucLamSa.Split(':')[0]);
            int phutRaSang = int.Parse(ketThucLamSa.Split(':')[1]);
            int gioVaoChieu = int.Parse(batDauLamCh.Split(':')[0]);
            int phutVaoChieu = int.Parse(batDauLamCh.Split(':')[1]);
            int gioRaChieu = int.Parse(ketThucLamCh.Split(':')[0]);
            int phutRaChieu = int.Parse(ketThucLamCh.Split(':')[1]);

            int maxDay = DateTime.DaysInMonth(nam, thang);
            object[] tenMoc = new object[maxDay];

            object[] diMuonList = new object[maxDay];
            object[] veSomList = new object[maxDay];
            for (int i = 0; i < maxDay; i++)
            {
                diMuonList[i] = 0;
                veSomList[i] = 0;
            }

            for (int i = 0; i < data.Rows.Count; i++)
            {
                var item = data.Rows[i];
                if (item != null)
                {
                    DateTime curDay = new DateTime(nam, thang, int.Parse(item["DAY"].ToString()));
                    int thu = (int)curDay.DayOfWeek;
                    if (item["DAY"] != null && item["DAY"].ToString() != "")
                    {
                        // Tính đi muộn, làm thêm đầu giờ
                        if (item["VAO"].ToString() != "")
                        {
                            int diMuon = 0;
                            if (thu == 6)   // thứ 7
                            {
                                switch (HThucLamT7)
                                {
                                    case "FULLTIME":
                                        diMuon = CalculateDiMuon(gioVaoSang, phutVaoSang, item["VAO"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioRaChieu, phutRaChieu);
                                        break;
                                    case "LAM_SANG_NGHI_CHIEU":
                                        diMuon = CalculateDiMuon(gioVaoSang, phutVaoSang, item["VAO"].ToString(), gioRaSang, phutRaSang, int.Parse(item["VAO"].ToString().Split(':')[0]), int.Parse(item["VAO"].ToString().Split(':')[1]), int.Parse(item["VAO"].ToString().Split(':')[0]), int.Parse(item["VAO"].ToString().Split(':')[1]));
                                        break;
                                    case "LAM_CHIEU_NGHI_SANG":
                                        diMuon = CalculateDiMuonChieu(gioVaoChieu, phutVaoChieu, item["VAO"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioRaChieu, phutRaChieu);
                                        break;
                                }
                                if (diMuon > soPhutChoPhepDiMuon)
                                    diMuonList[int.Parse(item["DAY"].ToString()) - 1] = diMuon;
                            }
                            else if (thu == 0)  // chủ nhật
                            {
                                switch (HThucLamCN)
                                {
                                    case "FULLTIME":
                                        diMuon = CalculateDiMuon(gioVaoSang, phutVaoSang, item["VAO"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioRaChieu, phutRaChieu);
                                        break;
                                    case "LAM_SANG_NGHI_CHIEU":
                                        diMuon = CalculateDiMuon(gioVaoSang, phutVaoSang, item["VAO"].ToString(), gioRaSang, phutRaSang, int.Parse(item["VAO"].ToString().Split(':')[0]), int.Parse(item["VAO"].ToString().Split(':')[1]), int.Parse(item["VAO"].ToString().Split(':')[0]), int.Parse(item["VAO"].ToString().Split(':')[1]));
                                        break;
                                    case "LAM_CHIEU_NGHI_SANG":
                                        diMuon = CalculateDiMuonChieu(gioVaoChieu, phutVaoChieu, item["VAO"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioRaChieu, phutRaChieu);
                                        break;
                                }
                                if (diMuon > soPhutChoPhepDiMuon)
                                    diMuonList[int.Parse(item["DAY"].ToString()) - 1] = diMuon;
                            }
                            else // ngày thường
                            {
                                diMuon = CalculateDiMuon(gioVaoSang, phutVaoSang, item["VAO"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioRaChieu, phutRaChieu);
                                if (diMuon > soPhutChoPhepDiMuon)
                                    diMuonList[int.Parse(item["DAY"].ToString()) - 1] = diMuon;
                            }
                        }

                        // Tính về sớm, làm thêm cuối giờ
                        if (item["RA"].ToString() != "")
                        {
                            int veSom = 0;
                            if (thu == 6)   // thứ 7
                            {
                                switch (HThucLamT7)
                                {
                                    case "FULLTIME":
                                        veSom = CalculateVeSom(gioRaChieu, phutRaChieu, item["RA"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioVaoSang, phutVaoSang);
                                        break;
                                    case "LAM_SANG_NGHI_CHIEU":
                                        veSom = CalculateVeSomSang(gioRaSang, phutRaSang, item["RA"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioVaoSang, phutVaoSang);
                                        break;
                                    case "LAM_CHIEU_NGHI_SANG":
                                        veSom = CalculateVeSom(gioRaChieu, phutRaChieu, item["RA"].ToString(), int.Parse(item["RA"].ToString().Split(':')[0]), int.Parse(item["RA"].ToString().Split(':')[1]), gioVaoChieu, phutVaoChieu, int.Parse(item["RA"].ToString().Split(':')[0]), int.Parse(item["RA"].ToString().Split(':')[1]));
                                        break;
                                }
                                if (veSom > soPhutChoPhepVeSom)
                                    veSomList[int.Parse(item["DAY"].ToString()) - 1] = veSom;
                            }
                            else if (thu == 0)  // chủ nhật
                            {
                                switch (HThucLamCN)
                                {
                                    case "FULLTIME":
                                        veSom = CalculateVeSom(gioRaChieu, phutRaChieu, item["RA"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioVaoSang, phutVaoSang);
                                        break;
                                    case "LAM_SANG_NGHI_CHIEU":
                                        veSom = CalculateVeSomSang(gioRaSang, phutRaSang, item["RA"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioVaoSang, phutVaoSang);
                                        break;
                                    case "LAM_CHIEU_NGHI_SANG":
                                        veSom = CalculateVeSom(gioRaChieu, phutRaChieu, item["RA"].ToString(), int.Parse(item["RA"].ToString().Split(':')[0]), int.Parse(item["RA"].ToString().Split(':')[1]), gioVaoChieu, phutVaoChieu, int.Parse(item["RA"].ToString().Split(':')[0]), int.Parse(item["RA"].ToString().Split(':')[1]));
                                        break;
                                }
                                if (veSom > soPhutChoPhepVeSom)
                                    veSomList[int.Parse(item["DAY"].ToString()) - 1] = veSom;
                            }
                            else// ngày thường
                            {
                                veSom = CalculateVeSom(gioRaChieu, phutRaChieu, item["RA"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioVaoSang, phutRaSang);
                                if (veSom > soPhutChoPhepVeSom)
                                    veSomList[int.Parse(item["DAY"].ToString()) - 1] = veSom;
                            }
                        }
                    }
                }
            }
            string tencb = data.Rows[0]["HO_TEN"].ToString();
            hcFrutas.Title = new Title("Thời gian đi muộn về sớm trong tháng " + thang + "/" + nam + " của nhân viên " + tencb);

            for (int i = 1; i <= maxDay; i++)
            {
                tenMoc[i - 1] = i;
            }

            // ve bieu do
            hcFrutas.YAxis.Add(new YAxisItem { title = new Title("Số phút") });
            hcFrutas.XAxis.Add(new XAxisItem { categories = tenMoc, title = new Title("Ngày trong tháng") });

            //dados
            var series = new Collection<Serie>();

            series.Add(new Serie { name = "Đi muộn", data = diMuonList });
            series.Add(new Serie { name = "Về sớm", data = veSomList });

            hcFrutas.PlotOptions = new PlotOptionsColumn()
            {
                borderColor = "#dedede",
                borderRadius = 4,
                dataLabels = new DataLabels()
                {
                    enabled = true,
                },
            };
            hcFrutas.Height = height;
            hcFrutas.Legend = new Legend()
            {
                layout = Highcharts.Core.Layout.horizontal,
                align = Align.left,
                verticalAlign = Highcharts.Core.VerticalAlign.top,
                x = 70,
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
        catch
        {
            throw;
        }
    }

    /****** Bien dong nhan su ******/
    //private void BieuDoBienDongNhanSu()
    //{
    //    hcFrutas.Title = new Title("Biểu đồ biến động nhân sự");

    //    int year = DateTime.Now.Year;
    //    string maDV = Session["MaDonVi"].ToString();
    //    List<BienDongNhanSu> biendongns = new ChartController().GetBienDongNhanSu(maDV, year);

    //    object[] _data = new object[12];
    //    for (int i = 0; i < 12; i++)
    //        _data[i] = 0;
    //    for (int i = 0; i < biendongns.Count(); i++)
    //    {
    //        if (biendongns[i].daNghi)
    //        {
    //            if (biendongns[i].ngayNghi.Year == year)
    //            {
    //                for (int j = 0; j < biendongns[i].ngayNghi.Month; j++)
    //                {
    //                    _data[j] = (object)((int)_data[j] + 1);
    //                }
    //            }
    //        }
    //        else {
    //            for (int t = 0; t < 12; t++)
    //            {
    //                _data[t] = (object)((int)_data[t] + 1);
    //            }
    //        }
    //    }

    //    // ve bieu do
    //    hcFrutas.YAxis.Add(new YAxisItem { title = new Title("Số lượng") });
    //    hcFrutas.XAxis.Add(new XAxisItem { categories = new object[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"} });

    //    //dados
    //    var series = new Collection<Serie>();

    //    series.Add(new Serie { name = "Nhân viên", data = _data });

    //    hcFrutas.PlotOptions = new PlotOptionsColumn()
    //    {
    //        borderColor = "#dedede",
    //        borderRadius = 4,
    //        dataLabels = new DataLabels()
    //        {
    //            enabled = true,
    //        },
    //    };
    //    hcFrutas.Height = 270;
    //    hcFrutas.Legend = new Legend()
    //    {
    //        layout = Highcharts.Core.Layout.horizontal,
    //        align = Align.left,
    //        verticalAlign = Highcharts.Core.VerticalAlign.top,
    //        x = 70,
    //        y = -5,
    //        floating = true,
    //        shadow = true,
    //        backgroundColor = "#FFF",
    //        enabled = false,
    //    };
    //    hcFrutas.Exporting.enabled = true;
    //    hcFrutas.DataSource = series;
    //    hcFrutas.DataBind();
    //}

    private int CalculateDiMuon(int gioChuan, int phutChuan, string input, int gioRaSang, int phutRaSang, int gioVaoChieu, int phutVaoChieu, int gioRaChieu, int phutRaChieu)
    {
        if (input == null || input == "")
            return 0;
        // giờ vào
        int gioVao = int.Parse(input.Split(':')[0]);
        int phutVao = int.Parse(input.Split(':')[1]);
        // số phút muộn
        int phutMuon = gioVao * 60 + phutVao - gioChuan * 60 - phutChuan;

        if (gioVao > gioVaoChieu || (gioVao == gioVaoChieu && phutVao > phutVaoChieu))
        {
            phutMuon = phutMuon - (gioVaoChieu * 60 + phutVaoChieu - gioRaSang * 60 - phutRaSang);
        }
        else if ((gioVao > gioRaSang || (gioVao == gioRaSang && phutVao > phutRaSang)) && (gioVao < gioVaoChieu || (gioVao == gioVaoChieu && phutVao < phutVaoChieu)))
        {
            phutMuon = phutMuon - (gioVao * 60 + phutVao - gioRaSang * 60 - phutRaSang);
        }
        if (gioVao > gioRaChieu || (gioVao == gioRaChieu && phutVao > phutRaChieu))
        {
            phutMuon = phutMuon - (gioVao * 60 + phutVao - gioRaChieu * 60 - phutRaChieu);
        }
        return phutMuon;
    }

    private int CalculateDiMuonChieu(int gioChuan, int phutChuan, string input, int gioRaSang, int phutRaSang, int gioVaoChieu, int phutVaoChieu, int gioRaChieu, int phutRaChieu)
    {
        if (input == null || input == "")
            return 0;
        // giờ vào
        int gioVao = int.Parse(input.Split(':')[0]);
        int phutVao = int.Parse(input.Split(':')[1]);
        // số phút muộn
        int phutMuon = gioVao * 60 + phutVao - gioChuan * 60 - phutChuan;
        if (gioVao > gioRaChieu || (gioVao == gioRaChieu && phutVao > phutRaChieu))
            phutMuon = phutMuon - (gioVao * 60 + phutVao - gioRaChieu * 60 - phutRaChieu);

        return phutMuon;
    }

    private int CalculateVeSom(int gioChuan, int phutChuan, string input, int gioRaSang, int phutRaSang, int gioVaoChieu, int phutVaoChieu, int gioVaoSang, int phutVaoSang)
    {
        if (input == null || input == "")
            return 0;
        // giờ vào
        int gioRa = int.Parse(input.Split(':')[0]);
        int phutRa = int.Parse(input.Split(':')[1]);
        // số phút sớm
        int phutSom = gioChuan * 60 + phutChuan - gioRa * 60 - phutRa;

        if (gioRa < gioRaSang || (gioRa == gioRaSang && phutRa < phutRaSang))
        {
            phutSom = phutSom - (gioVaoChieu * 60 + phutVaoChieu - gioRaSang * 60 - phutRaSang);
        }
        else if ((gioRa > gioRaSang || (gioRa == gioRaSang && phutRa > phutRaSang)) && (gioRa < gioVaoChieu || (gioRa == gioVaoChieu && phutRa < phutVaoChieu)))
        {
            phutSom = phutSom - (gioVaoChieu * 60 + phutVaoChieu - gioRa * 60 - phutRa);
        }
        if (gioRa < gioVaoSang || (gioRa == gioVaoSang && phutRa < phutRaSang))
        {
            phutSom = phutSom - (gioVaoSang * 60 + phutVaoSang - gioRa * 60 - phutRa);
        }
        return phutSom;
    }

    private int CalculateVeSomSang(int gioChuan, int phutChuan, string input, int gioRaSang, int phutRaSang, int gioVaoChieu, int phutVaoChieu, int gioVaoSang, int phutVaoSang)
    {
        if (input == null || input == "")
            return 0;
        // giờ vào
        int gioRa = int.Parse(input.Split(':')[0]);
        int phutRa = int.Parse(input.Split(':')[1]);
        // số phút sớm
        int phutSom = gioChuan * 60 + phutChuan - gioRa * 60 - phutRa;

        if (gioRa < gioVaoSang || (gioRa == gioRaSang && phutRa < phutRaSang))
            phutSom = phutSom - (gioVaoSang * 60 + phutVaoSang - gioRa * 60 - phutRa);

        return phutSom;
    }
}