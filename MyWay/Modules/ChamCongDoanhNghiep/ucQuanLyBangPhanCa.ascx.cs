using DataController;
using Ext.Net;
using ExtMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_ChamCongDoanhNghiep_ucQuanLyBangPhanCa : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Store1.BaseParams.Add(new Ext.Net.Parameter() { Name = "ThangHayNam", Mode = ParameterMode.Raw, Value = ThangHayNam });
       // if (ThangHayNam == "Nam") GridPanel1.ColumnModel.Columns[2].Hidden = true;
    }
    public string ThangHayNam { get; set; }
    protected void btnXoa_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                new DanhSachBangPhanCaController().Delete(int.Parse(item.RecordID));
            }
            btnSua.Disabled = true;
            btnXoa.Disabled = true;
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void Save(int id, string title)
    {
        DataHandler.GetInstance().ExecuteNonQuery(string.Format("update ChamCong.DanhSachBangPhanCa set TenBangPhanCa = N'{0}' where ID = {1}",title,id)); 
    }
}