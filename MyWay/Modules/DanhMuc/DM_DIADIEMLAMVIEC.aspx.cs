using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_DIADIEMLAMVIEC : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_diadiemlamviec.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa địa điểm làm việc",
            ModuleDescription = "Quản lý danh mục địa điểm làm việc",
            Update_AccessHistoryDescription = "Cập nhật thông tin địa điểm làm việc",
            Insert_AccessHistoryDescription = "Thêm mới địa điểm làm việc"
        };
    }
}