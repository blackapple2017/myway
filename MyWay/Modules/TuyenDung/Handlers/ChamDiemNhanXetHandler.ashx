<%@ WebHandler Language="C#" Class="ChamDiemNhanXetHandler" %>

using System;
using System.Web;

public class ChamDiemNhanXetHandler : IHttpHandler {
    // sử lý nếu load truyền mã vào thì trả về dòng dữ liệu chọn,
    // không thì hiển thị tất
    public void ProcessRequest (HttpContext context) {
        int planid = 0;
        if (!string.IsNullOrEmpty(context.Request["planid"]))
        {
            planid = int.Parse(context.Request["planid"]);
        }
        var data = new KetQuaThiTuyenController().LayCacMonThiTuyen(planid);
        context.Response.Write(string.Format("{{TotalRecords:{1},'Data':{0}}}", Ext.Net.JSON.Serialize(data), data.Rows.Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}