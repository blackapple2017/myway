using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TP_GIADINH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_tp_giadinh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin thành phần gia đình",
            ModuleDescription = "Quản lý danh mục thành phần gia đình",
            Update_AccessHistoryDescription = "Cập nhật thông tin thành phần gia đình",
            Insert_AccessHistoryDescription = "Thêm mới thông tin thành phần gia đình"
        };
    }
}