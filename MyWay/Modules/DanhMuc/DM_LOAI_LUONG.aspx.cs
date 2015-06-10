using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_LOAI_LUONG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_loai_luong.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin loại lương",
            ModuleDescription = "Quản lý danh mục loại lương",
            Update_AccessHistoryDescription = "Cập nhật thông tin loại lương",
            Insert_AccessHistoryDescription = "Thêm mới thông tin loại lương"
        };

    }
}