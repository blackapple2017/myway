using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CHUCVU_DANG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_chucvu_dang.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin chức vụ đảng",
            ModuleDescription = "Quản lý danh mục chức vụ đảng",
            Update_AccessHistoryDescription = "Cập nhật thông tin chức vụ đảng",
            Insert_AccessHistoryDescription = "Thêm mới chức vụ đảng"
        };

    }
}