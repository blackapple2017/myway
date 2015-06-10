using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NOICAP_BHXH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_noicap_bhxh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin nơi cấp bảo hiểm xã hội",
            ModuleDescription = "Quản lý danh mục nơi cấp bảo hiểm xã hội",
            Update_AccessHistoryDescription = "Cập nhật thông tin nơi cấp bảo hiểm xã hội",
            Insert_AccessHistoryDescription = "Thêm mới thông tin nơi cấp bảo hiểm xã hội"
        };
    }
}