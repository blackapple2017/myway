using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExtMessage;

public partial class Modules_BaoHiem_TangGiamTrongThang_PlusMinusInMonth : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            cbMonth.SetValue(DateTime.Now.Month);
            spinYear.SetValue(DateTime.Now.Year);

            hdfMenuID.SetValue(MenuID);
            hdfUserID.SetValue(CurrentUser.ID);
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "#{hdfMaDonVi}.setValue('" + DTH.BorderLayout.nodeID + "');#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);
        }
    }
    int _countRole = -1;
    string[] departmentList;
    protected void stDepartmentList_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(DepartmentRoleController.DONVI_GOC);
        if (departmentList == null || departmentList.Count() == 0)
        {
            departmentList = new DepartmentRoleController().GetMaBoPhanByRole(CurrentUser.ID, MenuID).Split(',');
        }
        List<object> obj = new List<object>();
        foreach (var info in lists)
        {
            // if (departmentList.Contains(info.MA))
            obj.Add(new { MA = info.MA, TEN = info.TEN });
            //else
            //{
            //    obj.Add(new { MA = _countRole.ToString(), TEN = info.TEN });
            //  //  _countRole--;
            //}
            obj = LoadChildMenu(obj, info.MA, 1);
        }
        stDepartmentList.DataSource = obj;
        stDepartmentList.DataBind();
    }

    private List<object> LoadChildMenu(List<object> obj, string parentID, int k)
    {
        List<StoreComboObject> lists = new DM_DONVIController().GetStoreByParentID(parentID);
        foreach (var item in lists)
        {
            string tmp = "";
            for (int i = 0; i < k; i++)
                tmp += "----";
            // if (departmentList.Contains(item.MA))
            obj.Add(new { MA = item.MA, TEN = tmp + item.TEN });
            //else
            //{
            //    obj.Add(new { MA = _countRole.ToString(), TEN = tmp + item.TEN });
            // //   _countRole--;
            //}
            obj = LoadChildMenu(obj, item.MA, k + 1);
        }
        return obj;
    }

    [DirectMethod]
    public void AfterEdit(int id, string field, string oldValue, string newValue, object customer)
    {
        try
        {
            int month = int.Parse(cbMonth.SelectedItem.Value);
            int year = int.Parse("0" + spinYear.Text);
            new BHTangGiamBHTrongThangController().UpdateTangGiam(id, field, newValue, month, year);
            grpTangGiamBH.GetStore().CommitChanges();
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification("Có lỗi xảy ra: " + ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BHTangGiamBHTrongThangController controller = new BHTangGiamBHTrongThangController();
            foreach (var item in checkBoxSelection.SelectedRows)
            {
                try
                {
                    int id = int.Parse("0" + item.RecordID);
                    controller.Delete(id);
                }
                catch (Exception ex)
                {
                    
                }
            }
            grpTangGiamBH.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnThemNhanVien_Click(object sender, DirectEventArgs e)
    {
        try
        {
            BHTangGiamBHTrongThangController controller = new BHTangGiamBHTrongThangController();
            int month = int.Parse(cbMonth.SelectedItem.Value);
            int year = int.Parse("0" + spinYear.Text);
            DateTime date = new DateTime(year, month, 1);

            foreach (var item in chkEmployeeRowSelection.SelectedRows)
            {
                DAL.BHTangGiamBHTrongThang tg = new DAL.BHTangGiamBHTrongThang();
                try
                {
                    int idNVBH = int.Parse("0" + item.RecordID);
                    if (controller.GetByIDNVBHAndMonthYear(idNVBH, month, year) == null)
                    {
                        tg.IDNhanVien_BaoHiem = idNVBH;
                        tg.MonthYear = date;

                        controller.Insert(tg);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
            wdAddNhanVienBaoHiem.Hide();
            grpTangGiamBH.Reload();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }
}