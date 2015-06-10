using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CHUNGCHI : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_chungchi.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin chứng chỉ",
            ModuleDescription = "Quản lý danh mục chứng chỉ",
            Update_AccessHistoryDescription = "Cập nhật thông tin chứng chỉ",
            Insert_AccessHistoryDescription = "Thêm mới thông tin chứng chỉ"
        };

    }
}