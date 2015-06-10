using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NGOAINGU : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_ngoaingu.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin ngoại ngữ",
            ModuleDescription = "Quản lý danh mục ngoại ngữ",
            Update_AccessHistoryDescription = "Cập nhật thông tin ngoại ngữ",
            Insert_AccessHistoryDescription = "Thêm mới thông tin ngoại ngữ"
        };
    }
}