using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class api_ChamCong_InOutTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PushDataoHost();
    }

    private void PushDataoHost()
    {
        try
        {
            string apikey = ConfigurationManager.AppSettings["keyapi"];
            if (Request.QueryString["key"] != apikey)
            {
                Response.Write("duplicate");
                return;
            }
            string connectString = ConfigurationManager.ConnectionStrings["StandardConfig"].ConnectionString;
            string maChamCong = string.Empty;
            bool inOutMode = false;  // 0 nếu là giờ vào, 1 nếu là giờ ra
            DateTime ngayThang = new DateTime();

            if (!string.IsNullOrEmpty(Request.QueryString["enrollnumber"]))
                maChamCong = Request.QueryString["enrollnumber"];
            if (!string.IsNullOrEmpty(Request.QueryString["inoutmode"]))
                inOutMode = int.Parse(Request.QueryString["inoutmode"]) == 0 ? true : false;
            if (!string.IsNullOrEmpty(Request.QueryString["time"]))
                ngayThang = DateTime.Parse(Request.QueryString["time"]);

            //SqlConnection sqlConnection = new SqlConnection(connectString);
            //SqlCommand command = new SqlCommand("api_PushMarkPointData", sqlConnection);
            //command.CommandType = CommandType.StoredProcedure;
            //// add params
            //command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = maChamCong + ngayThang.Day + ngayThang.Month + ngayThang.Year + ngayThang.Hour + ngayThang.Minute + ngayThang.Second;
            //command.Parameters.Add("@MaChamCong", SqlDbType.NVarChar).Value = maChamCong;
            //command.Parameters.Add("@MaCa", SqlDbType.NVarChar).Value = "";
            //command.Parameters.Add("@DiVao", SqlDbType.Bit).Value = inOutMode;
            //command.Parameters.Add("@Time", SqlDbType.NVarChar).Value = ngayThang.Hour + ":" + ngayThang.Minute + ":" + ngayThang.Second;
            //command.Parameters.Add("@NgayChamCong", SqlDbType.DateTime).Value = ngayThang;
            //command.Parameters.Add("@Order", SqlDbType.Int).Value = 1;
            //// execute sql
            //sqlConnection.Open();
            //command.ExecuteNonQuery();
            //sqlConnection.Close();
            string id = maChamCong + ngayThang.Day + ngayThang.Month + ngayThang.Year + ngayThang.Hour + ngayThang.Minute + ngayThang.Second;
            //string time = ngayThang.ToLongTimeString().Remove(8);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("api_PushMarkPointData", "@Id", "@MaChamCong", "@MaCa", "@DiVao", "@Time", "@NgayChamCong", "@Order",
                id, maChamCong, "", inOutMode, ngayThang.ToString("HH:mm:ss"), ngayThang, 1);
            Response.Write("true");
        }
        catch (Exception ex)
        {
            Response.Write("false");
        }
    }
}