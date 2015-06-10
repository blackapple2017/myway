using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CONGTRINH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_congtrinh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin công trình",
            ModuleDescription = "Quản lý danh mục công trình",
            Update_AccessHistoryDescription = "Cập nhật thông tin công trình",
            Insert_AccessHistoryDescription = "Thêm mới thông tin công trình"
        };
    }
}