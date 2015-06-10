using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NOICAP_HOCHIEU : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_noicap_hochieu.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin nơi cấp hộ chiếu",
            ModuleDescription = "Quản lý danh mục nơi cấp hộ chiếu",
            Update_AccessHistoryDescription = "Cập nhật thông tin nơi cấp hộ chiếu",
            Insert_AccessHistoryDescription = "Thêm mới thông tin nơi cấp hộ chiếu"
        };
    }
}