using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NUOC : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_nuoc.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin nước",
            ModuleDescription = "Quản lý danh mục nước",
            Update_AccessHistoryDescription = "Cập nhật thông tin nước",
            Insert_AccessHistoryDescription = "Thêm mới thông tin nước"
        };
    }
}