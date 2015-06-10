using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TINHOC : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_tinhoc.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin tin học",
            ModuleDescription = "Quản lý danh mục tin học",
            Update_AccessHistoryDescription = "Cập nhật thông tin tin học",
            Insert_AccessHistoryDescription = "Thêm mới thông tin tin học"
        };
    }
}