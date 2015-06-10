using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_QUANHE : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_quanhe.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin quan hệ gia đình",
            ModuleDescription = "Quản lý danh mục quan hệ gia đình",
            Update_AccessHistoryDescription = "Cập nhật thông tin quan hệ gia đình",
            Insert_AccessHistoryDescription = "Thêm mới thông tin quan hệ gia đình"
        };
    }
}