using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WhereFilterInfo
/// </summary>
public class ReportFilter
{
    public ReportFilter()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime ReportedDate { get; set; }
    public int StartMonth { get; set; }
    public int EndMonth { get; set; }
    public int MinSeniority { get; set; } //Thâm niên tối thiểu
    public int MaxSeniority { get; set; }//Thâm niên tối đa
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public int Year { get; set; }
    public int UserID { get; set; }
    public int MenuID { get; set; }
    public int WorkingStatus { get; set; } // Tình trạng làm việc: Đã nghỉ hay đang làm việc
    
    public decimal EmployeeCode { get; set; } //Mã cán bộ
    public int CanBoQuanLy { get; set; }
    public string MaCanBo { get; set; }
    public string ReportTitle { get; set; }
    public string WhereClause { get; set; }
    public string Reporter { get; set; } //Người lập biểu
    public string Note { get; set; } // ghi chú thêm cho một số báo cáo
      
    public string Gender { get; set; }

    public string MaDotDanhGia { get; set; }

    public string MaSoThue { get; set; }
   
    public string SessionDepartment { get; set; }
    /// <summary>
    /// Đính dạng kiểu: 01,CN1,CN1-01,CN1-02,CN1-03,CN1-04,CN1-05,CN2,CN2-02,CN2-01,CN2-03,CN2-04,CN2-05,CN2-0501,CN2-0502,
    /// </summary>
    public string SelectedDepartment { get; set; }

    public string Title1 { get; set; }
    public string Name1 { get; set; }
    public string Title2 { get; set; }
    public string Name2 { get; set; }
    public string Title3 { get; set; }
    public string Name3 { get; set; }

    public string CompanyAddress { get; set; }
    public string CompanyName { get; set; }
    public string CompanyFax { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhone { get; set; }
}