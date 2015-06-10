using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TT_HN : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_tt_hn.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin tình trạng hôn nhân",
            ModuleDescription = "Quản lý danh mục tình trạng hôn nhân",
            Update_AccessHistoryDescription = "Cập nhật thông tin tình trạng hôn nhân",
            Insert_AccessHistoryDescription = "Thêm mới thông tin tình trạng hôn nhân"
        };
    }
}