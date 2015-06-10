using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TT_SUCKHOE : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_tt_suckhoe.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin tình trạng sức khỏe",
            ModuleDescription = "Quản lý danh mục tình trạng sức khỏe",
            Update_AccessHistoryDescription = "Cập nhật thông tin tình trạng sức khỏe",
            Insert_AccessHistoryDescription = "Thêm mới thông tin tình trạng sức khỏe"
        };
    }
}