using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_LOAI_CS : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        grp_dm_loai_cs.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin loại chăm sóc",
            ModuleDescription = "Quản lý danh mục loại chăm sóc",
            Update_AccessHistoryDescription = "Cập nhật thông tin loại chăm sóc",
            Insert_AccessHistoryDescription = "Thêm mới thông tin loại chăm sóc"
        };
    }
}