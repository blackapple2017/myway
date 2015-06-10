using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DiMuonVeSomController
/// </summary>
public class DiMuonVeSomController
{
    public DiMuonVeSomController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Lấy danh sách cán bộ đi muộn về sớm
    /// </summary>
    /// <param name="data">Dữ liệu thời gian vào và ra của cán bộ</param>
    /// <returns>DataTable chứa danh sách cán bộ với thời gian đi muộn và về sớm</returns>
    public DataTable GetDanhSachDiMuonVeSom(DataTable data)
    {
        DataTable table = new DataTable();
        return table;
    }

    public DataTable GetDiMuonVeSom(DataTable data, string MaDonVi, string Nam, string Thang)
    {
        string batDauLamSa = new HeThongController().GetValueByName(SystemConfigParameter.BAT_DAU_LAM_SANG, MaDonVi);
        string ketThucLamSa = new HeThongController().GetValueByName(SystemConfigParameter.KET_THUC_LAM_SANG, MaDonVi);
        string batDauLamCh = new HeThongController().GetValueByName(SystemConfigParameter.BAT_DAU_LAM_CHIEU, MaDonVi);
        string ketThucLamCh = new HeThongController().GetValueByName(SystemConfigParameter.KET_THUC_LAM_CHIEU, MaDonVi);
        string HThucLamT7 = new HeThongController().GetValueByName(SystemConfigParameter.HINH_THUC_LAM_T7, MaDonVi);
        string HThucLamCN = new HeThongController().GetValueByName(SystemConfigParameter.HINH_THUC_LAM_CN, MaDonVi);
        int soPhutChoPhepVeSom = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_CHO_PHEP_VE_SOM, MaDonVi));
        int soPhutChoPhepDiMuon = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_CHO_PHEP_DI_MUON, MaDonVi));
        int soPhutMinCoiLaLamThem = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_TOI_THIEU_DUOC_TINH_LAM_THEM, MaDonVi));
        int soPhutMuonCoiLaNghi = int.Parse(new HeThongController().GetValueByName(SystemConfigParameter.SO_PHUT_DI_MUON_COI_LA_NGHI, MaDonVi));

        int gioVaoSang = int.Parse(batDauLamSa.Split(':')[0]);
        int phutVaoSang = int.Parse(batDauLamSa.Split(':')[1]);
        int gioRaSang = int.Parse(ketThucLamSa.Split(':')[0]);
        int phutRaSang = int.Parse(ketThucLamSa.Split(':')[1]);
        int gioVaoChieu = int.Parse(batDauLamCh.Split(':')[0]);
        int phutVaoChieu = int.Parse(batDauLamCh.Split(':')[1]);
        int gioRaChieu = int.Parse(ketThucLamCh.Split(':')[0]);
        int phutRaChieu = int.Parse(ketThucLamCh.Split(':')[1]);

        DataTable table = CreateDataTable();
        int maxLength = data.Rows.Count;
        int ngay = DateTime.DaysInMonth(Convert.ToInt32(Nam), Convert.ToInt32(Thang));
        for (int i = 0; i < maxLength; i++)
        {
            int thu = 0;
            DateTime curDay;
            var item = data.Rows[i];
            if (item != null)
            {
                DataRow dr = table.NewRow();
                dr["MA_CB"] = item["MA_CB"];    // MA_CB
                dr["HO_TEN"] = item["HO_TEN"];    // HO_TEN
                dr["TEN_PHONG"] = item["TEN_PHONG"];
                string tenphong = item["TEN_PHONG"].ToString();
                string macb = item["MA_CB"].ToString();
                int tongDiMuon = 0, tongVeSom = 0, solan_dimuon = 0, solan_vesom = 0;
                while (item["MA_CB"].ToString() == macb)
                {
                    if (item["DAY"] != null && item["DAY"].ToString() != "")
                    {

                        if (Convert.ToInt32(item["DAY"]) <= ngay)
                        {
                            curDay = new DateTime(int.Parse(Nam), int.Parse(Thang), int.Parse(item["DAY"].ToString()));
                            thu = (int)curDay.DayOfWeek;
                        }
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
                                {
                                    tongDiMuon += diMuon;
                                    solan_dimuon++;
                                    dr["DI_MUON" + item["DAY"].ToString()] = diMuon > 60 ? ((diMuon / 60) + "").Split('.')[0] + "h" + (diMuon % 60) + "'" : diMuon + "'";
                                }
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
                                {
                                    tongDiMuon += diMuon;
                                    solan_dimuon++;
                                    dr["DI_MUON" + item["DAY"].ToString()] = diMuon > 60 ? ((diMuon / 60) + "").Split('.')[0] + "h" + (diMuon % 60) + "'" : diMuon + "'";
                                }
                            }
                            else // ngày thường
                            {
                                diMuon = CalculateDiMuon(gioVaoSang, phutVaoSang, item["VAO"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioRaChieu, phutRaChieu);
                                if (diMuon > soPhutChoPhepDiMuon)
                                {
                                    tongDiMuon += diMuon;
                                    solan_dimuon++;
                                    dr["DI_MUON" + item["DAY"].ToString()] = diMuon > 60 ? ((diMuon / 60) + "").Split('.')[0] + "h" + (diMuon % 60) + "'" : diMuon + "'";
                                }
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
                                {
                                    tongVeSom += veSom;
                                    solan_vesom++;
                                    dr["VE_SOM" + item["DAY"].ToString()] = veSom > 60 ? ((veSom / 60) + "").Split('.')[0] + "h" + (veSom % 60) + "'" : veSom + "'";
                                }
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
                                {
                                    tongVeSom += veSom;
                                    solan_vesom++;
                                    dr["VE_SOM" + item["DAY"].ToString()] = veSom > 60 ? ((veSom / 60) + "").Split('.')[0] + "h" + (veSom % 60) + "'" : veSom + "'";
                                }
                            }
                            else// ngày thường
                            {
                                veSom = CalculateVeSom(gioRaChieu, phutRaChieu, item["RA"].ToString(), gioRaSang, phutRaSang, gioVaoChieu, phutVaoChieu, gioVaoSang, phutVaoSang);
                                if (veSom > soPhutChoPhepVeSom)
                                {
                                    tongVeSom += veSom;
                                    solan_vesom++;
                                    dr["VE_SOM" + item["DAY"].ToString()] = veSom > 60 ? ((veSom / 60) + "").Split('.')[0] + "h" + (veSom % 60) + "'" : veSom + "'";
                                }
                            }
                        }
                    }
                    i++;
                    if (i < maxLength)
                        item = data.Rows[i];
                    else
                        break;
                }
                if (tongDiMuon == 0 && tongVeSom == 0)
                    continue;
                dr["TONG_DIMUON"] = tongDiMuon > 60 ? ((tongDiMuon / 60) + "").Split('.')[0] + "h" + (tongDiMuon % 60) + "'" : tongDiMuon + "'";
                dr["TONG_VESOM"] = tongVeSom > 60 ? ((tongVeSom / 60) + "").Split('.')[0] + "h" + (tongVeSom % 60) + "'" : tongVeSom + "'";
                dr["SOLAN_DIMUON"] = solan_dimuon > 0 ? solan_dimuon + " lần" : "";
                dr["SOLAN_VESOM"] = solan_vesom > 0 ? solan_vesom + " lần" : "";
                table.Rows.Add(dr);
                i--;
            }
        }
        return table;
    }

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

        if (phutMuon < 0)
            return 0;
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
        if (phutMuon < 0)
            return 0;
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

        if (phutSom < 0)
            return 0;
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
        if (phutSom < 0)
            return 0;
        return phutSom;
    }

    private DataTable CreateDataTable()
    {
        try
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MA_CB");        // 0
            dt.Columns.Add("TEN_PHONG");
            dt.Columns.Add("HO_TEN");
            dt.Columns.Add("TONG_DIMUON");
            dt.Columns.Add("TONG_VESOM");
            dt.Columns.Add("DI_MUON1");
            dt.Columns.Add("VE_SOM1");      // 5
            dt.Columns.Add("DI_MUON2");
            dt.Columns.Add("VE_SOM2");
            dt.Columns.Add("DI_MUON3");
            dt.Columns.Add("VE_SOM3");
            dt.Columns.Add("DI_MUON4");     // 10
            dt.Columns.Add("VE_SOM4");
            dt.Columns.Add("DI_MUON5");
            dt.Columns.Add("VE_SOM5");
            dt.Columns.Add("DI_MUON6");
            dt.Columns.Add("VE_SOM6");      // 15
            dt.Columns.Add("DI_MUON7");
            dt.Columns.Add("VE_SOM7");
            dt.Columns.Add("DI_MUON8");
            dt.Columns.Add("VE_SOM8");
            dt.Columns.Add("DI_MUON9");     // 20
            dt.Columns.Add("VE_SOM9");
            dt.Columns.Add("DI_MUON10");
            dt.Columns.Add("VE_SOM10");

            dt.Columns.Add("DI_MUON11");
            dt.Columns.Add("VE_SOM11");     // 25
            dt.Columns.Add("DI_MUON12");
            dt.Columns.Add("VE_SOM12");
            dt.Columns.Add("DI_MUON13");
            dt.Columns.Add("VE_SOM13");
            dt.Columns.Add("DI_MUON14");    // 30
            dt.Columns.Add("VE_SOM14");
            dt.Columns.Add("DI_MUON15");
            dt.Columns.Add("VE_SOM15");
            dt.Columns.Add("DI_MUON16");
            dt.Columns.Add("VE_SOM16");     // 35
            dt.Columns.Add("DI_MUON17");
            dt.Columns.Add("VE_SOM17");
            dt.Columns.Add("DI_MUON18");
            dt.Columns.Add("VE_SOM18");
            dt.Columns.Add("DI_MUON19");    // 40
            dt.Columns.Add("VE_SOM19");
            dt.Columns.Add("DI_MUON20");
            dt.Columns.Add("VE_SOM20");

            dt.Columns.Add("DI_MUON21");
            dt.Columns.Add("VE_SOM21");      // 45
            dt.Columns.Add("DI_MUON22");
            dt.Columns.Add("VE_SOM22");
            dt.Columns.Add("DI_MUON23");
            dt.Columns.Add("VE_SOM23");
            dt.Columns.Add("DI_MUON24");     // 50
            dt.Columns.Add("VE_SOM24");
            dt.Columns.Add("DI_MUON25");
            dt.Columns.Add("VE_SOM25");
            dt.Columns.Add("DI_MUON26");
            dt.Columns.Add("VE_SOM26");      // 55
            dt.Columns.Add("DI_MUON27");
            dt.Columns.Add("VE_SOM27");
            dt.Columns.Add("DI_MUON28");
            dt.Columns.Add("VE_SOM28");
            dt.Columns.Add("DI_MUON29");     // 60
            dt.Columns.Add("VE_SOM29");
            dt.Columns.Add("DI_MUON30");
            dt.Columns.Add("VE_SOM30");

            dt.Columns.Add("DI_MUON31");
            dt.Columns.Add("VE_SOM31");     // 65

            dt.Columns.Add("SOLAN_DIMUON");
            dt.Columns.Add("SOLAN_VESOM");

            return dt;
        }
        catch
        {
            return null;
        }
    }
}