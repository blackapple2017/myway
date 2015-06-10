using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TD_CHINHTRI : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_td_chinhtri.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin trình độ chính trị",
            ModuleDescription = "Quản lý danh mục trình độ chính trị",
            Update_AccessHistoryDescription = "Cập nhật thông tin trình độ chính trị",
            Insert_AccessHistoryDescription = "Thêm mới thông tin trình độ chính trị"
        };
    }
}