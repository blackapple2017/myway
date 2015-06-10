using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SoftCore.Security;
using ExtMessage;
public partial class Modules_ChamCongDoanhNghiep_BangVaoRaCa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            dfNgayChamCong.SetValue(DateTime.Now);
            int max = int.Parse("0" + DataController.DataHandler.GetInstance().ExecuteScalar("LaySoLuotChamCongLonNhat").ToString());
            hdfMax.Text = max.ToString();
            var grid = grpVaoRaCa;
            var store = grid.GetStore();
            var cm = grid.ColumnModel;
            for (int i = 0; i < max; i++)
            {
                int k = i + 1;
                // add to store
                store.Reader[0].Fields.Add("Lan" + k);

                Column column = new Column()
                {
                    ColumnID = "Lan" + k,

                    Header = "Lần " + k,
                    Width = 60,
                    DataIndex = "Lan" + k,
                    Align = Alignment.Right,
                };
                var cb4 = new Ext.Net.TextField()
                {
                    MaskRe = "/[0-9:]/",
                    ID = "txtEditor" + k,
                    Selectable = true,
                    ReadOnly = false
                };
                column.Editor.Add(cb4);
                cm.Columns.Add(column);
            }
        }
    }
    [DirectMethod(Namespace = "ChamCongVaoRaCa")]
    public void AfterEdit(string field, string oldValue, string newValue, VaoRaCaInfo oj)
    {
        try
        {
            if (oldValue != "")
            {
                bool check = true;
                string[] item = newValue.Split(':');
                if (item.Length > 0)
                    if (int.Parse("0" + item[0]) > 24)
                    {
                        Dialog.ShowError("Giờ không hợp lệ");
                        check = false;
                    }
                    else
                        if (int.Parse("0" + item[1]) > 59)
                        {
                            Dialog.ShowError("Phút không hợp lệ");
                            check = false;
                        }
                        else
                            if (int.Parse("0" + item[2]) > 59)
                            {
                                Dialog.ShowError("Giây không hợp lệ");
                                check = false;
                            }
                if (check == true)
                {
                    DAL.VaoRaCa data = new DAL.VaoRaCa();
                    data.MaChamCong = oj.MaChamCong;
                    if (!SoftCore.Util.GetInstance().IsDateNull(dfNgayChamCong.SelectedDate))
                        data.NgayChamCong = DateTime.Parse(dfNgayChamCong.SelectedDate.ToString("yyyy-MM-dd") + " " + oldValue);
                    data.Time = newValue;
                    DateTime ngayChamCong = DateTime.Parse(dfNgayChamCong.SelectedDate.ToString("yyyy-MM-dd") + " " + newValue);
                    new VaoRaCaController().UpdateTime(data, oldValue, ngayChamCong);
                    Store1.CommitChanges();
                }
                else
                {
                    Store1.CommitChanges();
                    this.grpVaoRaCa.Reload();
                }
            }
        }
        catch (Exception ex) { Dialog.ShowError(ex.Message); }
    }
}