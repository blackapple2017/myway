using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_TRUONG_DAOTAO : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_truong_daotao.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin trường đào tạo",
            ModuleDescription = "Quản lý danh mục trường đào tạo",
            Update_AccessHistoryDescription = "Cập nhật thông tin trường đào tạo",
            Insert_AccessHistoryDescription = "Thêm mới thông tin trường đào tạo"
        };
    }
}