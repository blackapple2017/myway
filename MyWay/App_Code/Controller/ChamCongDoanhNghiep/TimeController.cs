using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for TimeController
/// </summary>
public class TimeController
{
    public TimeController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private static TimeController Instance;

    public static TimeController GetInstance()
    {
        if (Instance == null)
        {
            Instance = new TimeController();
        }
        return Instance;
    }

    /// <summary>
    /// @Đức Anh
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns></returns>
    public float GetTotalTimeInHour(string startTime, string endTime)
    {
        return GetTotalTimeInMinutes(startTime, endTime) / (float)60;
    }
    /// <summary>
    /// Lấy tổng số phút giữa 2 khoảng thời gian
    /// @Đức Anh
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns></returns>
    public int GetTotalTimeInMinutes(string startTime, string endTime)
    {
        if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            return -1;
        int stHour = 0;
        int stMinus = 0;
        int enHour = 0;
        int enMinus = 0;
        stHour = int.Parse(startTime.Split(':')[0]);
        stMinus = int.Parse(startTime.Split(':')[1]);
        enHour = int.Parse(endTime.Split(':')[0]);
        enMinus = int.Parse(endTime.Split(':')[1]);

        int thoigian = (enHour * 60 + enMinus) - (stHour * 60 + stMinus);
        //xử lý nếu giờ vào biowf232h  giờ ra bằng 1h. xử lý nếu về sớm
        if (thoigian < -12 * 60) thoigian = thoigian + 24 * 60;
        if (thoigian > 12 * 60) thoigian = thoigian - 24 * 60;
        return thoigian;
    }
    /// <summary>
    /// Chuyển số phút thành giờ
    /// </summary>
    /// <param name="totalMintutes"></param>
    /// <returns></returns>
    public float ConvertMinutesToHours(int totalMintutes)
    {
        return (float)totalMintutes / 60;
    }
    /// <summary>
    /// Lấy các ngày cuối tuần
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public List<string> GetWeekKend(string maDonVi)
    {
        List<string> str = new List<string>();
        string paramList = "'" + DieuKienChamCongController.SANG_THU6 + "','" + DieuKienChamCongController.CHIEU_THU6 + "','" +
                           DieuKienChamCongController.SANG_THU7 + "','" + DieuKienChamCongController.CHIEU_THU7 + "','" + DieuKienChamCongController.CHU_NHAT + "'";
        DataTable table = new DieuKienChamCongController().GetByParamNameList(paramList, maDonVi);
        foreach (DataRow item in table.Rows)
        {
            if (item[1].ToString() == "True")
            {
                str.Add(item[0].ToString());
            }
        }
        return str;
    }

    /// <summary>
    /// Kiểm tra thời gian sampleTime có nằm trong khoảng thời gian (startTime, endTime) không
    /// @daibx
    /// </summary>
    /// <param name="sampleTime">thời gian cần kiểm tra</param>
    /// <param name="startTime">bắt đầu khoảng thời gian</param>
    /// <param name="endTime">kết thúc khoảng thời gian</param>
    /// <returns><b>true</b> nếu nằm trong khoảng, <b>false</b> nếu nằm ngoài khoảng</returns>
    public bool CheckRangeTime(string sampleTime, string startTime, string endTime)
    {
        if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            return false;
        if (string.IsNullOrEmpty(sampleTime))
            return false;
        if (GetTotalTimeInMinutes(startTime, sampleTime) > 0 && GetTotalTimeInMinutes(sampleTime, endTime) > 0)
            return true;
        return false;
    }

    /// <summary>
    /// Lấy số ngày làm việc trong tháng
    /// @daibx
    /// </summary>
    /// <param name="month">tháng</param>
    /// <param name="year">năm</param>
    /// <returns></returns>
    public double GetNumberDayOfWork(int month, int year, string maDonVi)
    {
        List<string> lists = GetWeekKend(maDonVi);
        int maxDays = DateTime.DaysInMonth(year, month);
        double totalDayOfWork = 0;
        for (int i = 1; i <= maxDays; i++)
        {
            DateTime day = new DateTime(year, month, i);

            switch (day.DayOfWeek.ToString())
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    totalDayOfWork++;
                    break;
                case "Saturday":
                    if (lists.Contains("SaturdayAfternoon"))
                        totalDayOfWork = totalDayOfWork + 0.5;
                    else
                        totalDayOfWork++;
                    break;
                case "Sunday":
                    break;
            }
        }
        return totalDayOfWork;
    }

    /// <summary>
    /// Lấy số ngày làm việc từ ngày A đến ngày B
    /// @daibx
    /// </summary>
    /// <param name="fromDate">Từ ngày</param>
    /// <param name="toDate">Đến ngày</param>
    /// <param name="maDonVi">Mã đơn vị</param>
    /// <returns></returns>
    public double GetNumberDayOfWork(DateTime fromDate, DateTime toDate, string maDonVi)
    {
        List<string> lists = GetWeekKend(maDonVi);
        double totalDayOfWork = 0;
        DateTime day = fromDate;
        while (day <= toDate)
        {
            switch (day.DayOfWeek.ToString())
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    totalDayOfWork++;
                    break;
                case "Saturday":
                    if (lists.Contains("SaturdayAfternoon"))
                        totalDayOfWork = totalDayOfWork + 0.5;
                    else
                        totalDayOfWork++;
                    break;
                case "Sunday":
                    break;
            }
            day.AddDays(1);
        }
        return totalDayOfWork;
    }
}
