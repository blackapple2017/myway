using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_DVT : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

        grp_dm_dvt.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin đơn vị tính",
            ModuleDescription = "Quản lý danh mục đơn vị tính",
            Update_AccessHistoryDescription = "Cập nhật thông tin đơn vị tính",
            Insert_AccessHistoryDescription = "Thêm mới thông tin đơn vị tính"
        };

    }
}