using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for InOutTime
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class InOutTime : System.Web.Services.WebService {

    public InOutTime () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool UpdateData(string Id, string MaChamCong, string MaCa, bool InOutMode, DateTime ngayThang) 
    {
        DataController.DataHandler hdl = DataController.DataHandler.GetInstance(); ;
        try
        {
            
            hdl.ExecuteNonQuery("api_PushMarkPointData", "@Id", "@MaChamCong", "@MaCa", "@DiVao", "@Time", "@NgayChamCong", "@Order",
                Id, MaChamCong, MaCa, InOutMode, ngayThang.ToString("HH:mm:ss"), ngayThang, 1);
            return true;
        }
        catch (Exception ex)
        {
            ex.Data.Add(hdl, hdl);
            return false;
        }
        
    }
    
}
