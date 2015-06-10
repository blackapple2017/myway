using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CHUCVU_DOI : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_chucvu_qdoi.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin chức vụ quân đội",
            ModuleDescription = "Quản lý danh mục chức vụ quân đội",
            Update_AccessHistoryDescription = "Cập nhật thông tin chức vụ quân đội",
            Insert_AccessHistoryDescription = "Thêm mới chức vụ quân đội"
        };

    }
}