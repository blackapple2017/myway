using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using ExtMessage;
using System.Data;
using DataController;

public partial class Modules_ChamCongDoanhNghiep_DieuKienChamCong : WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!X.IsAjaxRequest)
        //{
        //    grpDieuKienChamCong.GetAddButton().Hide();
        //    grpDieuKienChamCong.GetDeleteButton().Hide();
        //    grpDieuKienChamCong.GetEditButton().Hide();
        //}
        //grpDieuKienChamCong.GetToolBar().Insert(0,btnEditValue);
        //grpDieuKienChamCong.GetToolBar().Insert(1,btnResetValue);
        //grpDieuKienChamCong.GetGridPanel().DirectEvents.RowDblClick.Event += new ComponentDirectEvent.DirectEventHandler(Modules_DieuKienChamCong_DirectClick);
    }


    /// <summary>
    /// Sự kiện khi click vào nút edit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Modules_DieuKienChamCong_DirectClick(object sender, DirectEventArgs e)
    {

        try
        {
            //DAL.DieuKienChamCong dieukien = new DieuKienChamCongController().GetByID(int.Parse(grpDieuKienChamCong.GetSelectedRecordIDs().FirstOrDefault().ToString()));
            //txtMaDieuKien.Text = dieukien.ParamName;
            //txtTenDieuKien.Text = dieukien.ParamDescription;
            //chkCheckBox.Checked=(dieukien.Value=="True"?true:false);
            //wdAddWindow.Show();
        }
        catch
        {
            //   grpDieuKienChamCong.GetResourceManager().RegisterClientScriptBlock("rml", "Bạn chưa chọn điều kiện chấm công");
        }
    }
    protected void btnResetValue_Click(object sender, DirectEventArgs e)
    {
        new DieuKienChamCongController().ResetToDefaultValue(Session["MaDonVi"].ToString());
        Dialog.ShowNotification("Thông báo", "Khôi phục giá trị mặc định thành công !");
        //    grpDieuKienChamCong.GetGridPanel().Reload();
    }


    protected void grpNhomDieuKienStore_grpNhomDieuKienStore(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            grpNhomDieuKienStore.DataSource = new DieuKienChamCongController().GetConditionGroup(Session["MaDonVi"].ToString());
            grpNhomDieuKienStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    [DirectMethod]
    public void UpdateValue(int id, string field, string value)
    {
        try
        {
            if (field == "IsInUsed")
            {
                DataHandler.GetInstance().ExecuteNonQuery("chamCong_UpdateConfig", "@ID", "@Field", "@Value", id, field, bool.Parse(value));
            }
            else
            {
                DataHandler.GetInstance().ExecuteNonQuery("chamCong_UpdateConfig", "@ID", "@Field", "@Value", id, field, value);
            }
        }
        catch (Exception)
        {
            
        }
    }

    #region cấu hình cuối tuần

    protected void btnCapNhatCuoiTuan_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DieuKienChamCongController controller = new DieuKienChamCongController();
            controller.Update(DieuKienChamCongController.SANG_THU6, chkSangThu6.Checked.ToString(), Session["MaDonVi"].ToString());
            controller.Update(DieuKienChamCongController.CHIEU_THU6, chkChieuThu6.Checked.ToString(), Session["MaDonVi"].ToString());
            controller.Update(DieuKienChamCongController.SANG_THU7, chkSangThu7.Checked.ToString(), Session["MaDonVi"].ToString());
            controller.Update(DieuKienChamCongController.CHIEU_THU7, chkChieuThu7.Checked.ToString(), Session["MaDonVi"].ToString());
            controller.Update(DieuKienChamCongController.CHU_NHAT, chkChuNhat.Checked.ToString(), Session["MaDonVi"].ToString());
            wdCuoiTuanBaoGom.Hide();
            grpGiaTri.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void wdCuoiTuanBaoGom_BeforeShow(object sender, DirectEventArgs e)
    {
        try
        {
            string param = "'" + DieuKienChamCongController.CHIEU_THU6 + "','" + DieuKienChamCongController.SANG_THU6 + "','" + DieuKienChamCongController.SANG_THU7 + "','" +
                           DieuKienChamCongController.CHIEU_THU7 + "','" + DieuKienChamCongController.CHU_NHAT + "'";
            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("chamCong_GetDieuKienChamCong", "@ParamName", "@MaDonVi", param, Session["MaDonVi"].ToString());
            foreach (DataRow item in table.Rows)
            {
                bool flag = bool.Parse(item["Value"].ToString());
                switch (item[0].ToString())
                {
                    case DieuKienChamCongController.SANG_THU6:
                        chkSangThu6.Checked = flag;
                        break;
                    case DieuKienChamCongController.CHIEU_THU6:
                        chkChieuThu6.Checked = flag;
                        break;
                    case DieuKienChamCongController.SANG_THU7:
                        chkSangThu7.Checked = flag;
                        break;
                    case DieuKienChamCongController.CHIEU_THU7:
                        chkChieuThu7.Checked = flag;
                        break;
                    case DieuKienChamCongController.CHU_NHAT:
                        chkChuNhat.Checked = flag;
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion

    #region cấu hình ngày công chuẩn
    protected void wdSoNgayCongChuan_BeforeShow(object sender, DirectEventArgs e)
    {
        try
        {
            //DAL.DieuKienChamCong dkChamCong = new DieuKienChamCongController().GetByParamName(DieuKienChamCongController.SO_NGAY_CONG_CHUAN,Session["MaDonVi"].ToString());
            //if (dkChamCong != null)
            //{
            //    nbfSoNgayCongChuan.Text = dkChamCong.Value;
            //}
            string paramNameList = "'" + DieuKienChamCongController.SO_NGAY_CONG_CHUAN + "','" + DieuKienChamCongController.CHAMCONG_EXCEL_FORMAT + "','" +
                DieuKienChamCongController.CHAMCONG_PHANCA_TYPE + "'";
            DataTable table = new DieuKienChamCongController().GetByParamNameList(paramNameList, Session["MaDonVi"].ToString());
            foreach (DataRow row in table.Rows)
            {
                switch (row["ParamName"].ToString())
                {
                    case DieuKienChamCongController.SO_NGAY_CONG_CHUAN:
                        if (row["Value"] != null)
                        {
                            if (row["Value"].ToString() == "CalculateEveryMonth")
                            {
                                cbHinhThucNgayCong.SetValue("CalculateEveryMonth");
                                nbfSoNgayCongChuan.Disabled = true;
                            }
                            else
                            {
                                nbfSoNgayCongChuan.Text = row["Value"].ToString();
                            }
                        }
                        break;
                    case DieuKienChamCongController.CHAMCONG_EXCEL_FORMAT:
                        if (row["Value"] != null)
                        {
                            if (row["Value"].ToString() == DieuKienChamCongController.EXCEL_FORMAT_NGANG)
                                chkExcelNgang.Checked = true;
                            else
                                chkExcelDoc.Checked = true;
                        }
                        break;
                    case DieuKienChamCongController.CHAMCONG_PHANCA_TYPE:
                        if (row["Value"] != null)
                        {
                            if (row["Value"].ToString() == DieuKienChamCongController.PHANCA_TYPE_THANG)
                                chkPhanCaThang.Checked = true;
                            else
                                chkPhanCaTheoBoPhan.Checked = true;
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnCapNhatTongHopCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            if (cbHinhThucNgayCong.SelectedItem.Value == "Fix")
            {
                new DieuKienChamCongController().Update(DieuKienChamCongController.SO_NGAY_CONG_CHUAN, nbfSoNgayCongChuan.Text, Session["MaDonVi"].ToString());
            }
            else
            {
                new DieuKienChamCongController().Update(DieuKienChamCongController.SO_NGAY_CONG_CHUAN, cbHinhThucNgayCong.SelectedItem.Value, Session["MaDonVi"].ToString());
            }

            // định dạng excel
            string excelFormat = chkExcelNgang.Checked == true ? DieuKienChamCongController.EXCEL_FORMAT_NGANG : DieuKienChamCongController.EXCEL_FORMAT_DOC;
            new DieuKienChamCongController().Update(DieuKienChamCongController.CHAMCONG_EXCEL_FORMAT, excelFormat, Session["MaDonVi"].ToString());
            // cách phân ca
            string phanCa = chkPhanCaThang.Checked == true ? DieuKienChamCongController.PHANCA_TYPE_THANG : DieuKienChamCongController.PHANCA_TYPE_BOPHAN;
            new DieuKienChamCongController().Update(DieuKienChamCongController.CHAMCONG_PHANCA_TYPE, phanCa, Session["MaDonVi"].ToString());

            wdSoNgayCongChuan.Hide();
            grpGiaTri.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion

    #region Quên chấm công
    protected void wdQuenChamCong_BeforeShow(object sender, DirectEventArgs e)
    {

    }

    protected void btnCapNhatQuenChamCong_Click(object sender, DirectEventArgs e)
    { }
    #endregion

    #region cấu hình máy chấm công ngang
    protected void btnTepTinChamCong_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DieuKienChamCongController controller = new DieuKienChamCongController();
            if (e.ExtraParams["ChamCongNgang"] == "True")
            {
                controller.Update(DieuKienChamCongController.COT_THOI_GIAN_NGANG, nbfCotThoiGian.Text, Session["MaDonVi"].ToString());
                controller.Update(DieuKienChamCongController.MA_CHAM_CONG_NGANG, nbfMaCotChamCong.Text, Session["MaDonVi"].ToString());
                controller.Update(DieuKienChamCongController.NGAY_CHAM_CONG_NGANG, nbfCotNgayChamCong.Text, Session["MaDonVi"].ToString());
            }
            else
            {
                controller.Update(DieuKienChamCongController.VAO, nbfCotVao.Text, Session["MaDonVi"].ToString());
                controller.Update(DieuKienChamCongController.RA, nbfCotRa.Text, Session["MaDonVi"].ToString());
                controller.Update(DieuKienChamCongController.NGAY_CHAM_CONG_DOC, nbfMaCotChamCong.Text, Session["MaDonVi"].ToString());
                controller.Update(DieuKienChamCongController.NGAY_CHAM_CONG_DOC, nbfCotNgayChamCong.Text, Session["MaDonVi"].ToString());
            }
            wdTepTinChamCong.Hide();
            grpGiaTri.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void wdTepTinChamCong_BeforeShow(object sender, DirectEventArgs e)
    {
        try
        {
            string param = string.Empty;
            if (e.ExtraParams["LoaiExcel"] == "Doc")
            {
                param = "'" + DieuKienChamCongController.VAO + "','" + DieuKienChamCongController.MA_CHAM_CONG_DOC + "','" + DieuKienChamCongController.RA + "','" + DieuKienChamCongController.NGAY_CHAM_CONG_DOC + "'";
            }
            else
            {
                param = "'" + DieuKienChamCongController.COT_THOI_GIAN_NGANG + "','" + DieuKienChamCongController.MA_CHAM_CONG_NGANG + "','" + DieuKienChamCongController.NGAY_CHAM_CONG_NGANG + "'";
            }

            DataTable table = DataController.DataHandler.GetInstance().ExecuteDataTable("chamCong_GetDieuKienChamCong", "@ParamName", "@MaDonVi", param, Session["MaDonVi"].ToString());
            foreach (DataRow item in table.Rows)
            {
                switch (item[0].ToString())
                {
                    case DieuKienChamCongController.COT_THOI_GIAN_NGANG:
                        nbfCotThoiGian.Text = item["Value"].ToString();
                        break;
                    case DieuKienChamCongController.MA_CHAM_CONG_NGANG:
                        nbfMaCotChamCong.Text = item["Value"].ToString();
                        break;
                    case DieuKienChamCongController.NGAY_CHAM_CONG_NGANG:
                        nbfCotNgayChamCong.Text = item["Value"].ToString();
                        break;
                    case DieuKienChamCongController.VAO:
                        nbfCotVao.Text = item["Value"].ToString();
                        break;
                    case DieuKienChamCongController.RA:
                        nbfCotRa.Text = item["Value"].ToString();
                        break;
                    case DieuKienChamCongController.MA_CHAM_CONG_DOC:
                        nbfMaCotChamCong.Text = item["Value"].ToString();
                        break;
                    case DieuKienChamCongController.NGAY_CHAM_CONG_DOC:
                        nbfCotNgayChamCong.Text = item["Value"].ToString();
                        break;
                    default:
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    #endregion
}