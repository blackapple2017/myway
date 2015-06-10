using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChamCong" in code, svc and config file together.
public class ChamCong : IChamCong
{
    public bool UpdateDate(string Id, string MaChamCong, string MaCa, bool InOutMode, DateTime ngayThang)
    {
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("api_PushMarkPointData", "@Id", "@MaChamCong", "@MaCa", "@DiVao", "@Time", "@NgayChamCong", "@Order",
                Id, MaChamCong, MaCa, InOutMode, ngayThang.ToString("HH:mm:ss"), ngayThang, 1);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
