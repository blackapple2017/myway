<%@ WebHandler Language="C#" Class="ThamSoHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using Ext.Net;
using System.Data;
public class ThamSoHandler : IHttpHandler {

    class tempt
    {
        public string MA { get; set; }
        public string Description { get; set; }
    }
    public void ProcessRequest (HttpContext context) {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("MA"), new DataColumn("Description") });
        dt.Rows.Add("**{HO_TEN}**", "Họ và tên");
        dt.Rows.Add("**{NGAY_SINH}**", "Ngày sinh");
        dt.Rows.Add("**{NOI_SINH}**", "Nơi sinh");
        dt.Rows.Add("**{MA_CB}**", "Mã cán bộ");
        dt.Rows.Add("**{CMTND}**", "Số CMTND");
        dt.Rows.Add("**{NGAY_CAP}**", "Ngày cấp CMTND");
        dt.Rows.Add("**{NOI_CAP}**", "Nơi cấp CMTND");
        dt.Rows.Add("**{DIA_CHI}**", "Địa chỉ thường trú");
        dt.Rows.Add("**{NGHE_NGHIEP}**", "Nghề nghiệp");
        dt.Rows.Add("**{ChucVu}**", "Chức vụ hiện tại");
        dt.Rows.Add("**{TU_NGAY}**", "Từ ngày");
        dt.Rows.Add("**{DEN_NGAY}**", "đến ngày");
        dt.Rows.Add("**{LUONG_CO_BAN}**", "Lương cơ bản");
        dt.Rows.Add("**{THOI_GIAN_THU_VIEC}**", "Thời gian thử việc");
        dt.Rows.Add("**{NGAY_HT}**", "Ngày hiện tại");
        dt.Rows.Add("**{NGAY_BN}**", "Ngày bổ nhiệm");
        dt.Rows.Add("**{S}**", "Thời hạn hợp đồng");
        dt.Rows.Add("**{LoaiHopDong}**", "Loại hợp đồng");
        dt.Rows.Add("**{MASO_THUE}**", "MÃ số thuế");
        dt.Rows.Add("**{CHUC_VU_MOI}**", "Chức vụ mới");
        dt.Rows.Add("**{PHONG_BAN}**", "Phòng ban");
        dt.Rows.Add("**{NGAY_THOI_VIEC}**", "Ngày thôi việc");
        dt.Rows.Add("**{QT}**", "Quốc tịch");
        dt.Rows.Add("**{SOQD}**", "Số Quyết định");
        dt.Rows.Add("**{BD_HDONG}**", "Thời gian bắt đầu hợp đồng");
        dt.Rows.Add("**{KT_HDONG}**", "Thời gian kết thúc hợp đồng");
        dt.Rows.Add("**{BD_TV_HD}**", "Thời gian bắt đầu hợp đồng thử việc");
        dt.Rows.Add("**{KT_TV_HD}**", "Thời gian kết thúc thử việc");
        dt.Rows.Add("**{VT_MOI}**", "Vị trí mới");
        dt.Rows.Add("{D}", "Ngày");
        dt.Rows.Add("{M}", "Tháng");
        dt.Rows.Add("{Y}", "Năm");
        dt.Rows.Add("**{GIAM_DOC}**", "Giám đốc");
        dt.Rows.Add("**{NOILAMVIEC}**", "Nơi làm việc");
        context.Response.Write(string.Format("{{TotalRecord:{1}, 'Data':{0}}}", JSON.Serialize(dt), dt.Rows.Count));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}