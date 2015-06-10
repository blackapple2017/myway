using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CAPBAC_QDOI : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_capbac_qdoi.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa cấp bậc quân đội",
            ModuleDescription = "Quản lý danh mục cấp bậc quân đội",
            Update_AccessHistoryDescription = "Cập nhật thông tin cấp bậc quân đội",
            Insert_AccessHistoryDescription = "Thêm mới cấp bậc quân đội"
        };
    }
}