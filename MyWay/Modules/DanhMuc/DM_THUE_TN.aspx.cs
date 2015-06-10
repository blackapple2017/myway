using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_THUE_TN : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_thue_tn.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin thuế",
            ModuleDescription = "Quản lý danh mục thuế",
            Update_AccessHistoryDescription = "Cập nhật thông tin thuế",
            Insert_AccessHistoryDescription = "Thêm mới thông tin thuế"
        };
    }
}