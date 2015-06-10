using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_DANTOC : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_dantoc.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin dân tộc",
            ModuleDescription = "Quản lý danh mục dân tộc",
            Update_AccessHistoryDescription = "Cập nhật thông tin dân tộc",
            Insert_AccessHistoryDescription = "Thêm mới thông tin dân tộc"
        };

    }
}