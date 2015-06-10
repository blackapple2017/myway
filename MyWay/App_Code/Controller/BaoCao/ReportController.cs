using System.Reflection;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using SoftCore.Security;

/// <summary>
/// Summary description for ReportController
/// </summary>
public class ReportController
{
    public ReportController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static ReportController Instance;

    public static ReportController GetInstance()
    {
        if (Instance == null)
        {
            Instance = new ReportController();
        }
        return Instance;
    }
    /// <summary>
    /// Lấy tên người tạo báo cáo
    /// @Lê Anh
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string GetCreatedReporterName(string maDonVi, string reporter)
    {
        HeThongController htController = new HeThongController();
        string usingCurrentUser = htController.GetValueByName(SystemConfigParameter.SuDungTenDangNhap, maDonVi);
        if (usingCurrentUser == "True")
        {
            return reporter;
        }
        else
        {
            return new HeThongController().GetValueByName(SystemConfigParameter.chuky1, maDonVi);
        }
    }
    /// <summary>
    /// Lấy logo công ty
    /// @Lương Thiện
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public string GetLogoCompany(string maDonVi)
    {
        HeThongController htController = new HeThongController();
        return htController.GetValueByName(SystemConfigParameter.LOGO_COMPANY, maDonVi);
    }

    public enum DataType
    {
        DateTime, String, Number
    }

    /// <summary>
    /// Lấy giá trị của một biến để hiển thị, nếu giá trị của biến không tồn tại thì lấy giá trị mặc định ...
    /// @daibx
    /// </summary>
    /// <param name="value">giá trị của biến</param>
    /// <returns></returns>
    public string GetValueDefault(string value, DataType type)
    {
        string defaultValue = "...";
        try
        {
            switch (type)
            {
                case DataType.String:
                    if (!string.IsNullOrEmpty(value))
                        return value;
                    break;
                case DataType.DateTime:
                    DateTime date = DateTime.Parse(value);
                    if (!SoftCore.Util.GetInstance().IsDateNull(date))
                        return date.ToString("dd/MM/yyyy");
                    break;
                case DataType.Number:
                    long number = long.Parse(value);
                    return number.ToString("n0");
            }
            return defaultValue;
        }
        catch (Exception)
        {
            return defaultValue;
        }
    }

    /// <summary>
    /// Lấy theo định dạng: Từ ngày 1/5/1014 đến ngày 15/5/2014
    /// @daibx
    /// </summary>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <returns></returns>
    public string GetFromDateToDate(DateTime? fromDate, DateTime? toDate)
    {
        string rs = string.Empty;
        if (fromDate != null)
        {
            rs += "Từ ngày " + string.Format("{0:dd/MM/yyyy}", fromDate);
            if (toDate != null)
                rs += " đến ngày " + string.Format("{0:dd/MM/yyyy}", toDate);
        }
        else
        {
            if (toDate != null)
                rs += "Đến ngày " + string.Format("{0:dd/MM/yyyy}", toDate);
        }
        return rs;
    }

    /// <summary>
    /// Get date format: ngày 16 tháng 5 năm 2014
    /// @daibx
    /// </summary>
    /// <param name="day">date to format</param>
    /// <returns></returns>
    public string GetFormatDate(string dayStr)
    {
        string format = "...";
        try
        {
            DateTime day = DateTime.Parse(dayStr);
            if (day == null || SoftCore.Util.GetInstance().IsDateNull(day))
            {
                return format;
            }
            return "Ngày " + day.Day + " tháng " + day.Month + " năm " + day.Year;
        }
        catch (Exception)
        {
            return format;
        }
    }

    /// <summary>
    /// Get date format: ngày 16 tháng 5 năm 2014
    /// @daibx
    /// </summary>
    /// <param name="day">date to format</param>
    /// <returns></returns>
    public string GetFormatDate(DateTime day)
    {
        string format = "...";
        try
        {
            if (day == null || SoftCore.Util.GetInstance().IsDateNull(day))
            {
                return format;
            }
            return "Ngày " + day.Day + " tháng " + day.Month + " năm " + day.Year;
        }
        catch (Exception)
        {
            return format;
        }
    }

    /// <summary>
    /// Lấy tên giám đốc
    /// @Lê Anh
    /// </summary>
    /// <param name="maDonVI"></param>
    /// <returns></returns>
    public string GetDirectorName(string maDonVi, string displayName)
    {
        string name = new HeThongController().GetValueByName(SystemConfigParameter.chuky2, maDonVi);
        if (string.IsNullOrEmpty(name))
        {
            name = displayName;
        }
        return name;
    }

    /// <summary>
    /// Lấy tên kế toán trưởng
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <param name="displayName">Tên người ký nhập ở trên form filter</param>
    /// <returns></returns>
    public string GetHeadAccountant(string maDonVi, string displayName)
    {
        string name = new HeThongController().GetValueByName(SystemConfigParameter.chuky3, maDonVi);
        if (string.IsNullOrEmpty(name))
        {
            name = displayName;
        }
        return name;
    }

    /// <summary>
    /// Lấy tên trưởng phòng hành chính nhân sự
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <param name="displayName">Tên người ký nhập ở trên form filter</param>
    /// <returns></returns>
    public string GetHeadOfHRroom(string maDonVi, string displayName)
    {
        string name = new HeThongController().GetValueByName(SystemConfigParameter.chuky4, maDonVi);
        if (string.IsNullOrEmpty(name))
        {
            name = displayName;
        }
        return name;
    }

    /// <summary>
    /// Lấy tên thành phố
    /// @Lê Anh
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCityName(string maDonVi)
    {
        return new HeThongController().GetValueByName(SystemConfigParameter.CITY, maDonVi);
    }

    /// <summary>
    /// Lấy tên công ty
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCompanyName(string maDonVi)
    {
        string companyName = new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_NAME, maDonVi);
        if (string.IsNullOrEmpty(companyName))
        {
            return "CHƯA CÓ THÔNG TIN CÔNG TY";
        }
        return companyName;
    }

    /// <summary>
    /// Lấy địa chỉ công ty
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCompanyAddress(string maDonVi)
    {
        return new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_ADDRESS, maDonVi);
    }

    /// <summary>
    /// Lấy mã số thuế của công ty
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCompanyTaxCode(string maDonVi)
    {
        return new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_MASOTHUE, maDonVi);
    }

    /// <summary>
    /// Lấy số điện thoại của công ty
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCompanyPhoneNumber(string maDonVi)
    {
        return new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_DIENTHOAI, maDonVi);
    }

    /// <summary>
    /// Lấy số fax của công ty
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCompanyFax(string maDonVi)
    {
        return new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_FAX, maDonVi);
    }

    /// <summary>
    /// Lấy email của công ty
    /// @daibx
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public string GetCompanyEmail(string maDonVi)
    {
        return new HeThongController().GetValueByName(SystemConfigParameter.COMPANY_EMAIL, maDonVi);
    }
    /// <summary>
    /// Lấy tiêu đề của chữ ký
    /// @Lê Anh
    /// </summary>
    /// <param name="defaultTitle">Tiêu đề mặc định</param>
    /// <param name="defaultTitle">Tiêu đề do người dùng nhập vào</param>
    /// <returns></returns>
    public string GetTitleOfSignature(string defaultTitle, string newTitle)
    {
        if (!string.IsNullOrEmpty(newTitle))
        {
            return newTitle;
        }
        return defaultTitle;
    }
    /// <summary>
    /// Lấy định dạng chuỗi như : Hà Nội, Ngày ? Tháng ? Năm ?
    /// @Lê Anh
    /// </summary>
    /// <returns></returns>
    public string GetFooterReport(string maDonVi, DateTime? reportDate)
    {
        if (SoftCore.Util.GetInstance().IsDateNull(reportDate))
            reportDate = DateTime.Now;
        string cityName = GetCityName(maDonVi);
        return (string.IsNullOrEmpty(cityName) ? "N" : cityName + ", n") + "gày " + reportDate.Value.Day +
            " tháng " + reportDate.Value.Month + " năm " + reportDate.Value.Year;
    }

    private string BuildRTF(string input)
    {
        StringBuilder backslashed = new StringBuilder(input);
        backslashed.Replace(@"\", @"\\");
        backslashed.Replace(@"{", @"\{");
        backslashed.Replace(@"}", @"\}");
        StringBuilder sb = new StringBuilder();
        foreach (char character in backslashed.ToString())
        {
            if (character <= 0x7f)
                sb.Append(character);
            else
                sb.Append("\\u" + Convert.ToUInt32(character) + "?");
        }
        return " " + sb.ToString();
    }

    public string GetRtfString(string input)
    {
        return BuildRTF(input);
    }
    /// <summary>
    /// Được sử dụng để replace giá trị trong RichTextBox (Báo cáo sử dụng Dev)
    /// @Đức Anh
    /// </summary>
    /// <param name="strnguon"></param>
    /// <param name="kytuthaythe"></param>
    /// <param name="chuoithaythe"></param>
    /// <returns></returns>
    public string Convertstringtortf(string strnguon, string kytuthaythe, string chuoithaythe)
    {
        kytuthaythe = @"\{" + kytuthaythe.Substring(1, kytuthaythe.Length - 2) + @"\}";
        return strnguon.Replace(kytuthaythe, BuildRTF(chuoithaythe));
    }

    /// <summary>
    /// Lấy danh sách tháng, quý
    /// @Lê Anh
    /// </summary>
    /// <returns></returns>
    public List<object> GetMonthList()
    {
        List<object> data = new List<object>();
        data.Add(new { Name = "Cả năm", Value = "FullYear" });
        for (int i = 1; i <= 12; i++)
        {
            data.Add(new { Name = "Tháng " + i, Value = i });
        }
        data.Add(new { Name = "Quý I", Value = "I" });
        data.Add(new { Name = "Quý II", Value = "II" });
        data.Add(new { Name = "Quý III", Value = "III" });
        data.Add(new { Name = "Quý IV", Value = "IV" });
        return data;
    }
    /// <summary>
    /// Lấy diễn giải khoảng thời gian
    /// @Lê Anh
    /// </summary>
    /// <param name="startMonth"></param>
    /// <param name="endMonth"></param>
    /// <returns></returns>
    public string GetDescriptionTime(int startMonth, int endMonth)
    {
        if (startMonth == endMonth)
        {
            return "Tháng " + startMonth;
        }
        if (startMonth == 1 && endMonth == 3)
        {
            return "Quý I";
        }
        if (startMonth == 4 && endMonth == 6)
        {
            return "Quý II";
        }
        if (startMonth == 7 && endMonth == 9)
        {
            return "Quý III";
        }
        if (startMonth == 10 && endMonth == 12)
        {
            return "Quý IV";
        }
        if (startMonth == 1 && endMonth == 12)
        {
            return "Cả năm";
        }
        if (startMonth < endMonth)
        {
            return string.Format("Từ tháng {0} đến tháng {1}", startMonth, endMonth);
        }
        return "";
    }
    /// <summary>
    /// Lấy giá trị tháng từ combobox nếu combobox đó sử dụng data ở phương thức GetMonthList()
    /// @Lê Anh
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int GetStartMonth(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return 1;
        }
        switch (value)
        {
            case "":
            case "FullYear":
                return 1;
            case "I":
                return 1;
            case "II":
                return 4;
            case "III":
                return 7;
            case "IV":
                return 10;
            default:
                return int.Parse(value);
        }
    }
    /// <summary>
    /// Lấy giá trị tháng từ combobox nếu combobox đó sử dụng data ở phương thức GetMonthList()
    /// @Lê Anh
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int GetEndMonth(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return 12;
        }
        switch (value)
        {
            case "":
            case "FullYear":
                return 12;
            case "I":
                return 3;
            case "II":
                return 6;
            case "III":
                return 9;
            case "IV":
                return 12;
            default:
                return int.Parse(value);
        }
    }
    /// <summary>
    /// Tính giá trị giữa 2 khoảng thời gian
    /// @Unknown
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public string CalculateTime(DateTime d1, DateTime d2)
    {
        d1 = d1.Date;
        d2 = d2.Date;
        string _bc = "";
        if (d1.Day == d2.Day && d1.Month == d2.Month && d1.Year == d2.Year)
        {
            _bc = "Ngày " + d1.ToString("dd") + " tháng " + d1.ToString("MM") + " năm " + d1.ToString("yyyy");
        }
        else
            if (d1.Day != 1)
            {
                _bc = "Từ ngày " + d1.ToString("dd/MM/yyyy") + " đến ngày " + d2.ToString("dd/MM/yyyy");
            }
            else if (d1 == d2.AddDays(1).AddMonths(-1))
            {
                _bc = "Tháng " + d1.ToString("MM") + " năm " + d1.ToString("yyyy");
            }
            else if (d1.Year == d2.Year && d1.Month == 1 && d2.Month == 12 && d2.Day == 31)
            {
                _bc = "Năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 1 && d2.Day == 31 && d2.Month == 3)
            {
                _bc = "Quý I năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 4 && d2.Day == 30 && d2.Month == 6)
            {
                _bc = "Quý II năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 7 && d2.Day == 30 && d2.Month == 9)
            {
                _bc = "Quý III năm " + d2.ToString("yyyy");
            }
            else if (d1.Month == 10 && d2.Day == 31 && d2.Month == 12)
            {
                _bc = "Quý IV năm " + d2.ToString("yyyy");
            }

            else
            {
                _bc = "Từ ngày " + d1.ToString("dd/MM/yyyy") + " đến ngày " + d2.ToString("dd/MM/yyyy");
            }
        return _bc;
    }
}