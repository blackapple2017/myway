using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_HT_TUYENDUNG : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_ht_tuyendung.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin đơn vị ký hợp đồng",
            ModuleDescription = "Quản lý danh mục đơn vị ký hợp đồng",
            Update_AccessHistoryDescription = "Cập nhật thông tin đơn vị ký hợp đồng",
            Insert_AccessHistoryDescription = "Thêm mới thông tin đơn vị ký hợp đồng"
        };
    }
}