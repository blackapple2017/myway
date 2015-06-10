using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TongHopCongCuoiThangController
/// </summary>
public class TongHopCongCuoiThangController
{
	public TongHopCongCuoiThangController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void UpdateWhenAfterEdit(int ID, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_UpdateFieldTongHopCongCuoiThang", "@id", "@field", "@newValue", ID, field, value);
    }
}