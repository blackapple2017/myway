using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_nh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin ngân hàng",
            ModuleDescription = "Quản lý danh mục ngân hàng",
            Update_AccessHistoryDescription = "Cập nhật thông tin ngân hàng",
            Insert_AccessHistoryDescription = "Thêm mới thông tin ngân hàng"
        };
    }
}