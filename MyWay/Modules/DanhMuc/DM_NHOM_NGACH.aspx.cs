using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NHOM_NGACH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_nhom_ngach.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin nhóm ngạch",
            ModuleDescription = "Quản lý danh mục nhóm ngạch",
            Update_AccessHistoryDescription = "Cập nhật thông tin nhóm ngạch",
            Insert_AccessHistoryDescription = "Thêm mới thông tin nhóm ngạch"
        };
    }
}