using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_HT_KTHUONG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_ht_kthuong.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin hình thức khen thưởng",
            ModuleDescription = "Quản lý danh mục hình thức khen thưởng",
            Update_AccessHistoryDescription = "Cập nhật thông tin hình thức khen thưởng",
            Insert_AccessHistoryDescription = "Thêm mới thông tin hình thức khen thưởng"
        };
    }
}