using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_KHANANG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_khanang.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin khả năng",
            ModuleDescription = "Quản lý danh mục khả năng",
            Update_AccessHistoryDescription = "Cập nhật thông tin khả năng",
            Insert_AccessHistoryDescription = "Thêm mới thông tin khả năng"
        };

    }
}