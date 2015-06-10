using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_LYDO_KTHUONG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_lydo_kthuong.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin lý do khen thưởng",
            ModuleDescription = "Quản lý danh mục lý do khen thưởng",
            Update_AccessHistoryDescription = "Cập nhật thông tin lý do khen thưởng",
            Insert_AccessHistoryDescription = "Thêm mới thông tin lý do khen thưởng"
        };
    }
}