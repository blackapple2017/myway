using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TP_BANTHAN : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_tp_banthan.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin thành phần bản thân",
            ModuleDescription = "Quản lýdanh mục thành phần bản thân",
            Update_AccessHistoryDescription = "Cập nhật thông tin thành phần bản thân",
            Insert_AccessHistoryDescription = "Thêm mới thông tin thành phần bản thân"
        };
    }
}