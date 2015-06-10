using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataController;

/// <summary>
/// Summary description for BangLuongDongController
/// </summary>
public class BangLuongDongController
{
	public BangLuongDongController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Tính toán lương
    /// @Lê Anh
    /// </summary> 
    /// <param name="SalaryBoardID">ID bảng lương, khóa chính của bảng TienLuong.DanhSachBangLuong</param>
    public void CalculateSalaryBoard(int SalaryBoardID)
    {
        DataHandler.GetInstance().ExecuteNonQuery("TienLuong_ExecuteFormula","@SalaryBoardID", SalaryBoardID);
    }
    /// <summary>
    /// Tính lương lại cho 1 nhân viên
    /// </summary>
    /// <param name="id">Khóa chính của TienLuong.BangLuongDong, cách nhau bằng dấu phẩy</param>
    public void CalculateSalaryForAnEmployee(int SalaryBoardID, string id)
    {
        DataHandler.GetInstance().ExecuteNonQuery("TienLuong_ExecuteFormulaForSelectedEmployees", "@SalaryBoardID", "@IdBangLuongDong", SalaryBoardID, id);
    }

    /// <summary>
    /// Sửa giá trị trong một ô bảng lương
    /// </summary>
    /// <param name="id">id của bản ghi</param>
    /// <param name="field">tên cột sửa giá trị</param>
    /// <param name="newValue">giá trị mới sửa</param>
    /// <param name="idBangLuong">id bảng lương</param>
    public void UpdateBangThanhToanLuong(decimal id, string field, float newValue, int idBangLuong)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("TienLuong_UpdateTongHopLuong", "@Prkey", "@Field", "@Value", "@IdBangLuong",
                id, field, newValue, idBangLuong);
    }
}