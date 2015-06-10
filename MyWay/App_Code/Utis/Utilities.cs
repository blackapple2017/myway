using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utilities
/// </summary>
public class Utilities
{
    public Utilities()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DateTime ConvertDate_VN2EN(string date)
    {
        DateTimeFormatInfo fInfo = new DateTimeFormatInfo();
        if (date.Contains('/'))
            date = date.Replace('/', '-');
        fInfo.DateSeparator = "-";
        fInfo.ShortDatePattern = "yyyy-MM-dd";
        return Convert.ToDateTime(date, fInfo);
    }
    public static int ToInt32(object o, int defaultValue)
    {

        string value = Convert.ToString(o);
        if (int.TryParse(value, out defaultValue))
            return defaultValue;
        return defaultValue;
    }
    public static int ToInt32(string s, int defaultValue)
    {
        
        if (int.TryParse(s, out defaultValue))
            return defaultValue;
        return defaultValue;
    }

    public static string ToString(object s, string defaultValue)
    {
        string value = Convert.ToString(s);

        if (value == string.Empty)
            return defaultValue;
        else return value;
    }

}