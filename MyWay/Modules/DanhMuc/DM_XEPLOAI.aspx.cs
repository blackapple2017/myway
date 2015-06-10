using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_XEPLOAI : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_xeploai.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin xếp loại",
            ModuleDescription = "Quản lý danh mục xếp loại",
            Update_AccessHistoryDescription = "Cập nhật thông tin xếp loại",
            Insert_AccessHistoryDescription = "Thêm mới thông tin vật xếp loại"
        };
    }
}