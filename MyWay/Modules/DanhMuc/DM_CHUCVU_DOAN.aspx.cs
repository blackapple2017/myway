using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_CHUCVU_DOAN : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_chucvu_doan.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin chức vụ đoàn",
            ModuleDescription = "Quản lý danh mục chức vụ đoàn",
            Update_AccessHistoryDescription = "Cập nhật thông tin chức vụ đoàn",
            Insert_AccessHistoryDescription = "Thêm mới chức vụ đoàn"
        };

    }
}