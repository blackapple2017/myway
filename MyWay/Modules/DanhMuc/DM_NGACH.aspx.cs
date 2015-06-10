using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NGACH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_ngach.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin ngạch",
            ModuleDescription = "Quản lý danh mục ngạch",
            Update_AccessHistoryDescription = "Cập nhật thông tin ngạch",
            Insert_AccessHistoryDescription = "Thêm mới thông tin mức ngạch"
        };
    }
}