using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_GIOITINH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_gioitinh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin giới tính",
            ModuleDescription = "Quản lý danh mục giới tính",
            Update_AccessHistoryDescription = "Cập nhật thông tin giới tính",
            Insert_AccessHistoryDescription = "Thêm mới thông tin giới tính"
        };

    }
}