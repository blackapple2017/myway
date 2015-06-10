using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToExcel;

/// <summary>
/// Summary description for ExcelEngine
/// </summary>
public class ExcelEngine
{
    public ExcelEngine()
    {
        Instance = null;
    }

    private static ExcelEngine Instance;

    public static ExcelEngine GetInstance()
    {
        if (Instance == null)
            Instance = new ExcelEngine();
        return Instance;
    }


    /// <summary>
    /// Lấy về danh sách các cột ở trong file Excel
    /// </summary>
    /// <param name="ExcelFileName">Đường dẫn trở tới file Excel</param>
    /// <param name="SheetName">Tên sheet cần lấy ra, mặc định là Sheet1, Sheet2, Sheet3...</param>
    /// <returns></returns>
    public IEnumerable<string> GetColumnName(string ExcelFileName, string SheetName)
    {
        var excel = new ExcelQueryFactory(ExcelFileName);
        var columnName = excel.GetColumnNames(SheetName);
        return columnName;
    }

    /// <summary>
    /// Lấy dữ liệu từ file Excel
    /// </summary>
    /// <param name="ExcelFileName">Đường dẫn trỏ tới file Excel</param>
    /// <param name="SheetName">Tên sheet cần lấy ra, mặc định là Sheet1, Sheet2, Sheet3...</param>
    /// <param name="start">Dòng bắt đầu lấy</param>
    /// <param name="limit">số lượng bản ghi bắt đầu lấy ra</param>
    /// <returns></returns>
    public List<Row> GetDataFromExcel(string ExcelFileName, string SheetName, int start, int limit)
    {
        var excel = new ExcelQueryFactory(ExcelFileName);
        var excelData = (from c in excel.Worksheet(SheetName)
                         select c).Skip(start).Take(limit); 
        return excelData.ToList();
    }
    /// <summary>
    /// Lấy tất cả dòng trong file excel bắt đầu từ 1 dòng nào đó
    /// </summary>
    /// <param name="ExcelFileName">Tên file excel</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="start">dòng bắt đầu đọc</param>
    /// <returns></returns>
    public List<Row> GetDataFromExcel(string ExcelFileName, string SheetName, int start)
    {
        var excel = new ExcelQueryFactory(ExcelFileName);
        var excelData = (from t in excel.Worksheet(SheetName)
                         select t).Skip(start);
        return excelData.ToList();
    }
    /// <summary>
    /// Lấy tất cả các sheet trong file Excel
    /// </summary>
    /// <param name="ExcelFileName">Đường dẫn trỏ tới file Excel</param>
    /// <returns></returns>
    public IEnumerable<String> GetAllSheetName(string ExcelFileName)
    {
        var excel = new ExcelQueryFactory(ExcelFileName);
        return excel.GetWorksheetNames();
    }
    /// <summary>
    /// Lấy một số dòng trong file Excel
    /// </summary>
    /// <param name="ExcelFileName"></param>
    /// <param name="SheetName"></param>
    /// <param name="RowNumber">Các dòng cách nhau bằng dấu chấm phẩy</param>
    /// <returns></returns>
    public List<Row> GetSomeRowFromExcel(string ExcelFileName, string SheetName, string RowNumber)
    {
        /*
            Lưu ý : Vì dòng đầu tiên trong Excel là dòng tiêu đề, cho nên chỉ số dòng phải trừ đi 2
         */
        string[] RowArr = RowNumber.Split(';');
        var excel = new ExcelQueryFactory(ExcelFileName);

        //test
        IQueryable<Row> cc = (from c in excel.Worksheet(SheetName)
                              select c).Skip(2).Take(1);
        int cs = cc.Count();
        foreach (var item in cc)
        {
            string s = item[0];
        }
        //end test
        List<Row> rs = new List<Row>();
        foreach (var item in RowArr)
        {
            if (!string.IsNullOrEmpty(item))
            {
                var i = (from c in excel.Worksheet(SheetName)
                         select c).Skip(2).Take(1);//.ToList();
                // rs.Add(cc[int.Parse(item) - 1]);
            }
        }
        return rs;
    }
}