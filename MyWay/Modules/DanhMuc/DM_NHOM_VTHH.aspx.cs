using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_DanhMuc_DM_NHOM_VTHH : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        grp_dm_nhom_vthh.accessHistory = new WebUI.Entity.AccessHistory()
        {
            Delete_AccessHistoryDescription = "Xóa thông tin nhóm vật tư hàng hóa",
            ModuleDescription = "Quản lý danh mục nhóm vật tư hàng hóa",
            Update_AccessHistoryDescription = "Cập nhật thông tin nhóm vật tư hàng hóa",
            Insert_AccessHistoryDescription = "Thêm mới thông tin nhóm vật tư hàng hóa"
        };

        grp_dm_nhom_vthh.AddComponent(btnImportFromExcel, 4);
    }
}