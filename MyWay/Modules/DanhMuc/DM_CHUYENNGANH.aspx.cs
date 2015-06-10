using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CHUYENNGANH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_chuyennganh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin chuyên ngành",
            ModuleDescription = "Quản lý danh mục chuyên ngành",
            Update_AccessHistoryDescription = "Cập nhật thông tin chuyên ngành",
            Insert_AccessHistoryDescription = "Thêm mới thông tin chuyên ngành"
        };
    }
}