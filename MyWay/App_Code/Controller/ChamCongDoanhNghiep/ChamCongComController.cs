using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataController;
/// <summary>
/// TiếnBV
/// </summary>
public class ChamCongComController : LinqProvider
{
    public ChamCongComController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable GetAllByCombobox(string thang, string nam, int start, int limit, out int count, string searchKey, int menuID, int userID)
    {
        DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("sp_ChamCongComSelectByCombobox", "@Nam", "@Thang", "@start", "@limit", "@seachKey", "@MenuID", "@UserID", 
                nam, thang, start, limit, searchKey, menuID, userID);
        count = int.Parse("0" + DataHandler.GetInstance().ExecuteScalar("chamcong_CountChamCongCom", "@Nam", "@Thang", "@seachKey", "@MenuID", "@UserID", nam, thang, searchKey, menuID, userID).ToString());
        return table;
    }
    public void UpdateChamCongCom(int ID, decimal prkeyhoso, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateChamCongCom", "@id", "@field", "@PrkeyHoso", "@newValue", ID, field, prkeyhoso, value);

    }


    public void InsertChamCongCom(DateTime date, decimal prkeyhoso, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("InsertChamCongCom", "@PrkeyHoso", "@field", "@ngaythang", "@newValue", prkeyhoso, field, date, value);

    }
}