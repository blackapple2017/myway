using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NOI_KCB : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_noi_kcb.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin nơi khám chữa bệnh",
            ModuleDescription = "Quản lý danh mục nơi khám chữa bệnh",
            Update_AccessHistoryDescription = "Cập nhật thông tin nơi khám chữa bệnh",
            Insert_AccessHistoryDescription = "Thêm mới thông tin nơi khám chữa bệnh"
        };
    }
}