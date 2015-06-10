using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TONGIAO : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_tongiao.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin tôn giáo",
            ModuleDescription = "Quản lý danh mục tôn giáo",
            Update_AccessHistoryDescription = "Cập nhật thông tin tôn giáo",
            Insert_AccessHistoryDescription = "Thêm mới thông tin tôn giáo"
        };
    }
}