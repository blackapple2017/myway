using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DieuKienChamCongController
/// </summary>
public class DieuKienChamCongController : LinqProvider
{
    public DieuKienChamCongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region các tham biến cho chấm công phân ca
    //Cuối tuần bao gồm
    public const string SANG_THU6 = "FridayMorning";
    public const string CHIEU_THU6 = "FridayAfternoon";
    public const string SANG_THU7 = "SaturdayMorning";
    public const string CHIEU_THU7 = "SaturdayAfternoon";
    public const string CHU_NHAT = "Sunday";
    //Quên chít tay đầu giờ
    public const string COI_NHU_NGHI = "COI_NHU_NGHI";
    public const string COI_NHU_DEN_DUNG_GIO = "COI_NHU_DEN_DUNG_GIO";
    public const string COI_NHU_DI_MUON_X_PHUT = "COI_NHU_DI_MUON_X_PHUT";
    //Tổng hợp công
    public const string SO_NGAY_CONG_CHUAN = "SO_NGAY_CONG_CHUAN";
    public const string CHAMCONG_EXCEL_FORMAT = "CHAMCONG_EXCEL_FORMAT";
    public const string CHAMCONG_PHANCA_TYPE = "CHAMCONG_PHANCA_TYPE";

    public const string PHANCA_TYPE_THANG = "THANG";
    public const string PHANCA_TYPE_BOPHAN = "BOPHAN";
    public const string EXCEL_FORMAT_DOC = "DOC";
    public const string EXCEL_FORMAT_NGANG = "NGANG";
    //Chấm công ngang

    public const string MA_CHAM_CONG_NGANG = "MA_CHAM_CONG_NGANG";
    public const string NGAY_CHAM_CONG_NGANG = "NGAY_CHAM_CONG_NGANG";
    public const string COT_THOI_GIAN_NGANG = "COT_THOI_GIAN";

    //Chấm công dọc
    public const string MA_CHAM_CONG_DOC = "MaChamCong";
    public const string NGAY_CHAM_CONG_DOC = "NgayChamCong";
    public const string VAO = "Vao";
    public const string RA = "Ra";

    #endregion

    #region Các tham biến cho chấm công hành chính

    #endregion
    public DAL.DieuKienChamCong GetByParamName(string paramName, string maDonVi)
    {
        return dataContext.DieuKienChamCongs.Where(p => p.ParamName == paramName && p.MaDonVi == maDonVi).SingleOrDefault();
    }
    /// <summary>
    /// Lấy các tham biến, kết quả trả về là một datatable gồm 2 column
    /// column đầu tiên chứa tên tham biến, column thứ 2 chứa giá trị
    /// </summary>
    /// <param name="paramList">paramList là các tham biến cách nhau bởi một dấu phẩy, ví dụ "'param1','param2'"</param>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public DataTable GetByParamNameList(string paramList, string maDonVi)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable("chamCong_GetDieuKienChamCong", "@ParamName", "@MaDonVi", paramList, maDonVi);
    }

    public DAL.DieuKienChamCong GetByID(int id)
    {
        return dataContext.DieuKienChamCongs.Where(p => p.ID == id).SingleOrDefault();
    }

    public void Update(DAL.DieuKienChamCong dieuKiem)
    {
        var item = dataContext.DieuKienChamCongs.SingleOrDefault(t => t.ID == dieuKiem.ID);
        if (item != null)
        {
            item.Value = dieuKiem.Value;
            Save();
        }
    }

    public void Update(string paramName, string newValue, string maDonVi)
    {
        var item = dataContext.DieuKienChamCongs.SingleOrDefault(t => t.ParamName == paramName && (string.IsNullOrEmpty(maDonVi) || t.MaDonVi == maDonVi));
        if (item != null)
        {
            item.Value = newValue;
            Save();
        }
    }
    /// <summary>
    /// Khôi phục các giá trị mặc định
    /// </summary>
    /// <param name="madonvi"></param>
    public void ResetToDefaultValue(string madonvi)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("UPDATE ChamCong.DieuKienChamCong SET Value=DefaultValue Where MaDonVi = '" + madonvi + "'");
    }

    /// <summary>
    /// Lấy điều kiện chấm công
    /// </summary>
    /// <param name="maDonVi"></param>
    /// <returns></returns>
    public DataTable GetConditionGroup(string maDonVi)
    {
        return DataController.DataHandler.GetInstance().ExecuteDataTable(string.Format("select Distinct GroupID,GroupDescription from ChamCong.DieuKienChamCong where (LEN('{0}') = 0 or maDonVi = '{0}') and Display = 1 order by GroupID", maDonVi, maDonVi));
    }

    public IEnumerable<DAL.DieuKienChamCong> GetConditionList(int groupID, int start, int limit, out int count, bool display)
    {
        var rs = from t in dataContext.DieuKienChamCongs
                 where (t.GroupID == groupID) && t.Display == display
                 orderby t.Order
                 select t;
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }

    public List<DAL.DieuKienChamCong> GetByGroupDescription(string groupName, bool onlyGrid)
    {
        var rs = from t in dataContext.DieuKienChamCongs
                 where t.GroupDescription == groupName
                    && (t.ParamName != "SO_COT_FILE_EXCEL" || onlyGrid == false)
                    && (t.ParamName != "DONG_HEADER_ROW" || onlyGrid == false)
                    && (t.ParamName != "HORIZONTAL_HEADER_ROW" || onlyGrid == false)
                 select t;
        return rs.ToList();
    }
}