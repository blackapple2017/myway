using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_HT_KYLUAT : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_ht_kyluat.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin hình thức kỷ luật",
            ModuleDescription = "Quản lý danh mục hình thức kỷ luật",
            Update_AccessHistoryDescription = "Cập nhật thông tin hình thức kỷ luật",
            Insert_AccessHistoryDescription = "Thêm mới thông tin hình thức kỷ luật"
        };
    }
}