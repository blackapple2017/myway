using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using DAL;
using Controller.DanhGia;
using System.IO;

/// <summary>
/// daibx   
/// Date add    : 03/07/2013
/// Date update : 19/12/2013
/// </summary>
public partial class Modules_DanhGia_DotDanhGia : SoftCore.Security.WebBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            hdfIsChangeHinhThucDanhGia.Text = "";
        }
        ucChooseEmployee1.AfterClickAcceptButton += new EventHandler(ucChooseEmployee1_AfterClickAcceptButton);
    }

    /// <summary>
    /// Thêm nhân viên vào bảng cán bộ được đánh giá
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void ucChooseEmployee1_AfterClickAcceptButton(object sender, EventArgs e)
    {
        try
        {
            string chonCB = hdfChonCanBo.Text;
            switch (chonCB)
            {
                case "1":
                    SelectedRowCollection SelectedRow = ucChooseEmployee1.SelectedRow;
                    HoSoController dmcbController = new HoSoController();
                    string str = "";
                    foreach (var item in SelectedRow)
                    {
                        HOSO emp = dmcbController.GetByMaCB(item.RecordID);
                        if (emp != null)
                        {
                            if (new CanBoDuocDanhGiaController().CheckExistMaCBDuocDanhGia(emp.MA_CB, hdfRecordID.Text) == false)
                            {
                                CanBoDuocDanhGiaInfo cbo = new CanBoDuocDanhGiaInfo()
                                {
                                    MaCB = emp.MA_CB,
                                    MaDotDanhGia = hdfRecordID.Text,
                                    CreatedBy = CurrentUser.ID,
                                    CreatedDate = DateTime.Now
                                };
                                int id = new CanBoDuocDanhGiaController().Insert(cbo);
                                cbo.ID = id;

                                // tạo bản đánh giá trống
                                //CreateKetQuaDanhGiaByMaCB(cbo.MaCB);
                            }
                            else
                            {
                                str += emp.HO_TEN + "(" + item.RecordID + "), ";
                            }
                        }
                    }
                    RM.RegisterClientScriptBlock("reloadst", "#{grp_CanBoDuocDanhGia_Store}.reload();");
                    if (!string.IsNullOrEmpty(str))
                        X.MessageBox.Alert("Thông báo", "Các nhân viên sau đã tồn tại: " + str).Show();
                    else
                        X.MessageBox.Alert("Thông báo", "Đã thêm cán bộ thành công");
                    break;
                case "0":
                    SelectedRowCollection SelectedRow1 = ucChooseEmployee1.SelectedRow;
                    HoSoController dmcbController1 = new HoSoController();
                    string str1 = "";
                    foreach (var item in SelectedRow1)
                    {
                        HOSO emp = dmcbController1.GetByMaCB(item.RecordID);
                        if (emp != null)
                        {
                            if (new CanBoThamGiaDanhGiaController().CheckExistMaCBThamGiaDanhGia(hdfCanBoDuocDanhGiaID.Text, emp.MA_CB, hdfRecordID.Text) == false)
                            {
                                CanBoThamGiaDanhGiaInfo cbo = new CanBoThamGiaDanhGiaInfo()
                                {
                                    MaCBDanhGia = emp.MA_CB,
                                    MaDotDanhGia = hdfRecordID.Text,
                                    MaCBBiDanhGia = "",
                                    CreatedBy = CurrentUser.ID,
                                    CreatedDate = DateTime.Now
                                };

                                new CanBoThamGiaDanhGiaController().Insert(cbo);
                            }
                            else
                            {
                                str1 += emp.HO_TEN + "(" + item.RecordID + "), ";
                            }
                        }
                    }
                    RM.RegisterClientScriptBlock("reloadst1", "#{grp_CanBoThamGiaDanhGia_Store}.reload();");
                    if (!string.IsNullOrEmpty(str1))
                        X.MessageBox.Alert("Thông báo", "Các nhân viên sau đã tồn tại: " + str1).Show();
                    else
                        X.MessageBox.Alert("Thông báo", "Đã thêm cán bộ thành công");
                    break;
            }

        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnDongYThemTieuChi_Click(object sender, DirectEventArgs e)
    {
        SelectedRowCollection SelectedRow = checkboxSelectionTieuChiDG.SelectedRows;
        TieuChiDanhGiaController tieuChiDGController = new TieuChiDanhGiaController();
        string str = "";
        foreach (var item in SelectedRow)
        {
            DataTable emp = tieuChiDGController.GetByPrkey(item.RecordID.ToString());
            if (emp.Rows.Count > 0)
            {
                string maTieuChi = emp.Rows[0]["MaNhom"].ToString();
                if (new TieuChi_DotDanhGiaController().CheckExistTieuChi_DotDanhGia(emp.Rows[0]["MaNhom"].ToString(), hdfRecordID.Text) == false)
                {
                    TieuChi_DotDanhGiaInfo info = new TieuChi_DotDanhGiaInfo()
                    {
                        MaDotDanhGia = hdfRecordID.Text,
                        MaTieuChi = emp.Rows[0]["MaNhom"].ToString(),
                        CreatedDate = DateTime.Now,
                        CreatedBy = CurrentUser.ID
                    };
                    int id = new TieuChi_DotDanhGiaController().Insert(info);
                    info.ID = id;

                    // tạo bản đánh giá trống
                    //CreateKetQuaDanhGiaByIdTieuChiDotDanhGia(info);
                }
                else
                {
                    str += emp.Rows[0]["TenNhom"].ToString() + ", ";
                }
            }
        }
        RM.RegisterClientScriptBlock("reloadst2", "#{grp_DanhSachTieuChi_Store}.reload();");
        if (!string.IsNullOrEmpty(str))
            X.MessageBox.Alert("Thông báo", "Các tiêu chí sau đã tồn tại: " + str).Show();
        else
            X.MessageBox.Alert("Thông báo", "Đã thêm cán bộ thành công");
        wdThemTieuChiDanhGia.Hide();
    }

    private void CreateKetQuaDanhGiaByIdTieuChiDotDanhGia(TieuChi_DotDanhGiaInfo tcd)
    {
        DataTable canbos = new CanBoDuocDanhGiaController().GetByMaDotDanhGia(tcd.MaDotDanhGia);
        foreach (DataRow item in canbos.Rows)
        {
            DAL.KetQuaDanhGia tmp = new KetQuaDanhGiaController().GetByMaCBvaIdTieuChiDotDanhGia(item["MaCB"].ToString(), tcd.ID);
            if (tmp == null)
            {
                DAL.KetQuaDanhGia info = new DAL.KetQuaDanhGia()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    Diem = 0,
                    IdTieuChi_DotDanhGia = tcd.ID,
                    IsQuanLyDanhGia = false,
                    MaCB = item["MaCB"].ToString(),
                    NhanXet = ""
                };
                new KetQuaDanhGiaController().Insert(info);
            }
        }
    }

    private void CreateKetQuaDanhGiaByMaCB(string maCB)
    {
        List<DAL.TieuChi_DotDanhGia> tieuchis = new TieuChi_DotDanhGiaController().GetByMaCanBo(maCB);
        foreach (var item in tieuchis)
        {
            DAL.KetQuaDanhGia info = new DAL.KetQuaDanhGia()
            {
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Diem = 0,
                IdTieuChi_DotDanhGia = item.ID,
                IsQuanLyDanhGia = false,
                MaCB = maCB,
                NhanXet = ""
            };
            new KetQuaDanhGiaController().Insert(info);
        }
    }

    /// <summary>
    /// Lấy dữ liệu cho ComboBox Trạng thái trong Windows thêm mới đợt đánh giá
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void cbxTrangThai_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        //cbxTrangThai_Store.DataSource = DataController.DataHandler.GetInstance().ExecuteDataTable("select Value from ThamSoTrangThai where ParamName = 'TrangThaiDanhGia' and IsInUsed = 1");
        cbxTrangThai_Store.DataSource = new ThamSoTrangThaiController().GetByParamName("TrangThaiDanhGia", true);
        cbxTrangThai_Store.DataBind();
    }

    /// <summary>
    /// Lấy danh sách cán bộ bị đánh giá đưa vào Grid phía dưới
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grp_CanBoDuocDanhGia_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (hdfRecordID.Text != "")
        {
            grp_CanBoDuocDanhGia_Store.DataSource = new CanBoDuocDanhGiaController().GetByMaDotDanhGia(hdfRecordID.Text);
            grp_CanBoDuocDanhGia_Store.DataBind();
        }
    }

    protected void cbLoaiXepHang_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        cbLoaiXepHang_Store.DataSource = new LoaiXepHangController().GetAllParent(maDv);
        cbLoaiXepHang_Store.DataBind();
    }

    //protected void grp_DanhSachCBDuocDanhGia_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    grp_DanhSachCBDuocDanhGia_Store.DataSource = new DotDanhGiaController().GetAllCanBoDuocDanhGia();
    //    grp_DanhSachCBDuocDanhGia_Store.DataBind();
    //}

    /// <summary>
    /// Lấy danh sách cán bộ tham gia vào đợt đánh giá
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grp_CanBoThamGiaDanhGia_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        if (hdfRecordID.Text != "")
        {
            grp_CanBoThamGiaDanhGia_Store.DataSource = new CanBoThamGiaDanhGiaController().GetByMaDotDanhGia(hdfRecordID.Text);
            grp_CanBoThamGiaDanhGia_Store.DataBind();
        }
    }

    //protected void grp_DanhSachCBThamGiaDanhGia_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    //{
    //    grp_DanhSachCBThamGiaDanhGia_Store.DataSource = new DotDanhGiaController().GetDSCanBoThamGiaDanhGia(hdfDanhSachCBDuocDanhGiaID.Text);
    //    grp_DanhSachCBThamGiaDanhGia_Store.DataBind();
    //}

    protected void grp_NhomTC_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        grp_NhomTC_Store.DataSource = new TieuChiDanhGiaController().GetByParentID("-1", maDv);
        grp_NhomTC_Store.DataBind();
    }

    protected void grp_ChonTieuChi_Store_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        string maDv = string.Empty;//Session["MaDonVi"].ToString()
        string bienDoi = string.Empty;
        string ParentTCID = string.Empty;
        if (!string.IsNullOrEmpty(hdfMaNhom.Text))
        {
            ParentTCID = hdfMaNhom.Text;

            string[] tmp = ParentTCID.Split(',');
            foreach (var item in tmp)
            {
                if (item != "")
                    bienDoi += "'" + item + "',";
            }
            int pos = bienDoi.LastIndexOf(',');
            if (pos != -1)
                bienDoi = bienDoi.Substring(0, pos);
        }
        if (bienDoi == "-1" || bienDoi == "")
            bienDoi = "'" + "'";
        if (ParentTCID == "-1")
            ParentTCID = "";

        grp_ChonTieuChi_Store.DataSource = new TieuChiDanhGiaController().GetByAll(maDv, ParentTCID, bienDoi);
        grp_ChonTieuChi_Store.DataBind();
    }

    protected void btnCapNhat_Click(object sender, DirectEventArgs e)
    {

        DAL.DotDanhGia obj = new DAL.DotDanhGia();
        DotDanhGiaController ctr = new DotDanhGiaController();
        string isChangeHTDG = hdfIsChangeHinhThucDanhGia.Text;

        obj.ID = txtID.Text;
        obj.PrkeyCanBoQuanLy = decimal.Parse("0" + hdfMaNguoiQL.Text);
        obj.TenDotDanhGia = txtTenDotDanhGia.Text;
        if (txtTuNgay.SelectedDate.ToString().Contains("0001") == false)
            obj.TuNgay = txtTuNgay.SelectedDate;
        if (txtDenNgay.SelectedDate.ToString().Contains("0001") == false)
            obj.DenNgay = txtDenNgay.SelectedDate;
        if (cbxTrangThai.Value != null)
            obj.TrangThaiDanhGia = cbxTrangThai.Value.ToString();
        obj.GhiChu = txtGhiChu.Text;
        obj.CreatedBy = CurrentUser.ID;
        obj.CreatedDate = DateTime.Now;
        obj.MaDonVi = Session["MaDonVi"].ToString();
        if (cbxLoaiDanhGia.SelectedItem != null)
            obj.HinhThucDanhGia = int.Parse(cbxLoaiDanhGia.Value.ToString());
        obj.TL_TuDanhGia = decimal.Parse(txtTuDanhGia.Text.Replace('.', ','));
        obj.TL_QuanLyDanhGia = decimal.Parse(txtQuanlyDanhGia.Text.Replace('.', ','));
        obj.TL_NguoiKhacDanhGia = decimal.Parse(txtNguoiKhacDanhGia.Text.Replace('.', ','));
        if (cbLoaiXepHang.SelectedItem != null)
            obj.MaLoaiXepHang = int.Parse(cbLoaiXepHang.SelectedItem.Value);

        if (isChangeHTDG == "Yes")
        {
            hdfIsChangeHinhThucDanhGia.Text = "";
            DataTable table = new TieuChi_DotDanhGiaController().GetByMaDotDanhGia(hdfRecordID.Text);
            foreach (DataRow item in table.Rows)
            {
                int idTieuChiDotDanhGia = int.Parse(item["ID"].ToString());
                // Xóa kết quả đánh giá
                new KetQuaDanhGiaController().DeleteByIdTieuChi_DotDanhGia(idTieuChiDotDanhGia);
            }
            // Xóa danh sách cán bộ bị đánh giá
            new CanBoDuocDanhGiaController().DeleteByMaDotDanhGia(hdfRecordID.Text);
            // Xóa danh sách cán bộ tham gia đánh giá
            new CanBoThamGiaDanhGiaController().DeleteByMaDotDanhGia(hdfRecordID.Text);
            // Xóa danh sách các tiêu chí
            new TieuChi_DotDanhGiaController().DeleteByMaDotDanhGia(hdfRecordID.Text);

            // Thêm cán bộ
            InsertCanBo(obj);
        }

        if (e.ExtraParams["Command"] == "Edit")
        {
            obj.ID = hdfRecordID.Text;
            ctr.Update(obj);
            wdAddWindow.Hide();
            GridPanel1.Reload();
        }
        else
        {
            DAL.DotDanhGia tmp = new DotDanhGiaController().GetByPrkey(txtID.Text);
            if (tmp == null)
            {
                ctr.Insert(obj);
                InsertCanBo(obj);
                if (e.ExtraParams["Close"] == "True")
                {
                    wdAddWindow.Hide();
                }
                GridPanel1.Reload();
            }
            else
            {
                Dialog.ShowNotification("Mã đợt đánh giá đã tồn tại");
            }
        }
    }

    /// <summary>
    /// Mở cửa sổ cấu hình tỷ lệ điểm, xếp loại cho đợt đánh giá
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnConfig_Click(object sender, DirectEventArgs e)
    //{
    //    try
    //    {
    //        if (new FileInfo(Server.MapPath("../ConfigDotDanhGia.xml")).Exists)
    //        {
    //            XDocument xDoc = XDocument.Load(Server.MapPath("../ConfigDotDanhGia.xml"));
    //            var result = (from t in xDoc.Descendants("Estimate")
    //                          where t.Attribute("id").Value == hdfRecordID.Text
    //                          select t)
    //                          .Descendants("Result")
    //                          .Select(t => new { TuDanhGia = t.Descendants("TuDanhGia").FirstOrDefault().Value, QuanLyDanhGia = t.Descendants("QuanLyDanhGia").FirstOrDefault().Value, NguoiKhacDanhGia = t.Descendants("NguoiKhacDanhGia").FirstOrDefault().Value });
    //            if (result.Count() > 0)
    //            {
    //                foreach (var item in result)
    //                {
    //                    txtTuDanhGia.Text = item.TuDanhGia;
    //                    txtQuanLyDanhGia.Text = item.QuanLyDanhGia;
    //                    txtNguoiKhacDanhGia.Text = item.NguoiKhacDanhGia;
    //                }
    //            }
    //            else
    //            {
    //                // Tạo mới
    //                XElement estimate = new XElement("Estimate",
    //                    new XElement("Result",
    //                        new XElement("TuDanhGia", 20),
    //                        new XElement("QuanLyDanhGia", 50),
    //                        new XElement("NguoiKhacDanhGia", 30)),
    //                    new XElement("Rank"));
    //                estimate.SetAttributeValue("id", hdfRecordID.Text);
    //                xDoc.Root.Add(estimate);
    //                xDoc.Save(Server.MapPath("../ConfigDotDanhGia.xml"));

    //                txtTuDanhGia.Text = "20";
    //                txtQuanLyDanhGia.Text = "50";
    //                txtNguoiKhacDanhGia.Text = "30";
    //            }
    //            wdConfig.Show();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString());
    //    }
    //}

    /// <summary>
    /// Lưu cấu hình cho đợt đánh giá khi sửa thông tin
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnLuuLai_Click(object sender, DirectEventArgs e)
    //{
    //    try
    //    {
    //        if (new FileInfo(Server.MapPath("../ConfigDotDanhGia.xml")).Exists)
    //        {
    //            XDocument xDoc = XDocument.Load(Server.MapPath("../ConfigDotDanhGia.xml"));
    //            var result = from t in xDoc.Descendants("Estimate")
    //                         where t.Attribute("id").Value == hdfRecordID.Text
    //                         select t;

    //            if (result.Count() > 0)
    //            {
    //                foreach (XElement item in result)
    //                {
    //                    item.Element("Result").Element("TuDanhGia").Value = txtTuDanhGia.Text;
    //                    item.Element("Result").Element("QuanLyDanhGia").Value = txtQuanLyDanhGia.Text;
    //                    item.Element("Result").Element("NguoiKhacDanhGia").Value = txtNguoiKhacDanhGia.Text;
    //                }
    //            }
    //            xDoc.Save(Server.MapPath("../ConfigDotDanhGia.xml"));
    //            wdConfig.Hide();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        X.Msg.Alert("Thông báo", "Có lỗi xảy ra: " + ex.Message.ToString());
    //    }
    //}

    private void InsertCanBo(DotDanhGia obj)
    {
        if (obj.HinhThucDanhGia == 0 || obj.HinhThucDanhGia == 1)   // Đánh giá cả đơn vị, trong phòng
        {
            // lấy danh sách các cán bộ của cả đơn vị
            List<string> macbs = new HoSoController().GetAllMaCB();
            // Thêm vào bảng CanBoDuocDanhGia, CanBoThamGiaDanhGia
            foreach (var item in macbs)
            {
                CanBoDuocDanhGiaInfo info = new CanBoDuocDanhGiaInfo()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaCB = item,
                    MaDotDanhGia = obj.ID
                };
                new CanBoDuocDanhGiaController().Insert(info);

                CanBoThamGiaDanhGiaInfo info1 = new CanBoThamGiaDanhGiaInfo()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaCBBiDanhGia = "",
                    MaCBDanhGia = item,
                    MaDotDanhGia = obj.ID
                };
                new CanBoThamGiaDanhGiaController().Insert(info1);
            }
            //// Thêm vào kết quả đánh giá
            //foreach (var item in macbs)
            //{
            //    CreateKetQuaDanhGiaByMaCB(item);
            //}
        }
    }

    protected void btnOK_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.DotDanhGia record = new DotDanhGiaController().GetByPrkey(txtmaloaihdcoppy.Text);
            if (record != null)
            {
                Dialog.ShowNotification("Mã đã tồn tại");
            }
            else
            {
                record = new DotDanhGiaController().GetByPrkey(hdfRecordID.Text);
                DAL.DotDanhGia item = new DAL.DotDanhGia()
                {
                    ID = txtmaloaihdcoppy.Text,
                    TenDotDanhGia = txtTenDotMoi.Text,
                    TuNgay = record.TuNgay,
                    DenNgay = record.DenNgay,
                    TrangThaiDanhGia = record.TrangThaiDanhGia,
                    GhiChu = record.GhiChu,
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    MaDonVi = record.MaDonVi,
                    HinhThucDanhGia = record.HinhThucDanhGia,
                    TL_TuDanhGia = record.TL_TuDanhGia,
                    TL_QuanLyDanhGia = record.TL_QuanLyDanhGia,
                    TL_NguoiKhacDanhGia = record.TL_NguoiKhacDanhGia,
                    MaLoaiXepHang = record.MaLoaiXepHang,
                    PrkeyCanBoQuanLy = record.PrkeyCanBoQuanLy
                };
                new DotDanhGiaController().Insert(item);

                #region nhân đôi dữ liệu cán bộ bị đánh giá
                if (chkBiDanhGia.Checked || record.HinhThucDanhGia == 0 || record.HinhThucDanhGia == 1)
                {
                    var table = new CanBoDuocDanhGiaController().GetByMaDotDanhGia(hdfRecordID.Text);
                    foreach (DataRow it in table.Rows)
                    {
                        CanBoDuocDanhGiaInfo info = new CanBoDuocDanhGiaInfo()
                        {
                            MaCB = it["MaCB"].ToString(),
                            MaDotDanhGia = txtmaloaihdcoppy.Text,
                            CreatedBy = CurrentUser.ID,
                            CreatedDate = DateTime.Now
                        };
                        new CanBoDuocDanhGiaController().Insert(info);
                    }
                }
                #endregion

                #region nhân đôi dữ liệu cán bộ tham gia đánh giá
                if (chkThamGiaDanhGia.Checked || record.HinhThucDanhGia == 0 || record.HinhThucDanhGia == 1)
                {
                    var table = new CanBoThamGiaDanhGiaController().GetByMaDotDanhGia(hdfRecordID.Text);
                    foreach (DataRow it in table.Rows)
                    {
                        CanBoThamGiaDanhGiaInfo info = new CanBoThamGiaDanhGiaInfo()
                        {
                            MaCBBiDanhGia = it["MaCBBiDanhGia"].ToString(),
                            MaCBDanhGia = it["MaCBDanhGia"].ToString(),
                            MaDotDanhGia = txtmaloaihdcoppy.Text,
                            CreatedBy = CurrentUser.ID,
                            CreatedDate = DateTime.Now
                        };
                        new CanBoThamGiaDanhGiaController().Insert(info);
                    }
                }
                #endregion

                #region nhân đôi dữ liệu tiêu chí đánh giá
                if (chkTieuChiDanhGia.Checked)
                {
                    var table = new TieuChi_DotDanhGiaController().GetByMaDotDanhGia(hdfRecordID.Text);
                    foreach (DataRow it in table.Rows)
                    {
                        TieuChi_DotDanhGiaInfo info = new TieuChi_DotDanhGiaInfo()
                        {
                            MaDotDanhGia = txtmaloaihdcoppy.Text,
                            MaTieuChi = it["MaTieuChi"].ToString(),
                            CreatedDate = DateTime.Now,
                            CreatedBy = CurrentUser.ID
                        };
                        new TieuChi_DotDanhGiaController().Insert(info);
                    }
                }
                #endregion

                GridPanel1.Reload();
            }
            wdInputNewPrimaryKey.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }

    }

    /// <summary>
    /// Xóa thông tin một đợt tuyển dụng làm theo các bước như sau:
    /// -   Xóa danh sách cán bộ bị đánh giá
    /// -   Xóa danh sách cán bộ tham gia đánh giá
    /// -   Xóa danh sách tiêu chí đánh giá của đợt
    /// 
    /// -   Xóa đợt tuyển dụng
    /// </summary>
    /// <param name="pr_key"></param>

    protected void DeleteRecord(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item1 in checkboxSelection.SelectedRows)
            {


                #region Xóa kết quả đánh giá
                DAL.DotDanhGia table4 = new DotDanhGiaController().GetByPrkey(item1.RecordID);
                DataTable list = new TieuChi_DotDanhGiaController().GetByMaDotDanhGia(table4.ID);
                foreach (DataRow item in list.Rows)
                {
                    new KetQuaDanhGiaController().DeleteByIdTieuChi_DotDanhGia(int.Parse(item["ID"].ToString()));
                }
                #endregion

                #region Xóa danh sách cán bộ bị đánh giá
                var table1 = new CanBoDuocDanhGiaController().GetByMaDotDanhGia(item1.RecordID);
                foreach (DataRow it1 in table1.Rows)
                {
                    int id = int.Parse("0" + it1["ID"].ToString());
                    if (id != 0)
                        DeleteRecordCanBoDuocDanhGia(id);
                }
                #endregion

                #region Xóa danh sách cán bộ tham gia đánh giá
                table1 = new CanBoThamGiaDanhGiaController().GetByMaDotDanhGia(item1.RecordID);
                foreach (DataRow it1 in table1.Rows)
                {
                    int id = int.Parse("0" + it1["ID"].ToString());
                    DeleteRecordCanBoThamDanhGia(id);
                }
                #endregion

                #region Xóa danh sách tiêu chí đánh giá của đợt
                table1 = new TieuChi_DotDanhGiaController().GetByMaDotDanhGia(item1.RecordID);
                foreach (DataRow it1 in table1.Rows)
                {
                    int id = int.Parse("0" + it1["ID"].ToString());
                    DeleteRecordTieuChi(id);
                }
                #endregion

                #region xóa nhận xét
                new NhanXetController().DeleteByMaDotDG(item1.RecordID);
                #endregion
                // Xóa thông tin của đợt tuyển dụng
                new DotDanhGiaController().DeleteByPrkey(item1.RecordID);
                // 
            }

            checkboxSelection.ClearSelections();
            hdfRecordID.Text = "";
            GridPanel1.Reload();
            Dialog.ShowNotification("Xóa dữ liệu thành công");
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Thông báo", "Xóa đợt đánh giá xảy ra lỗi: " + ex.Message.ToString()).Show();
        }
    }

    [DirectMethod]
    public void DeleteRecordCanBoDuocDanhGia(int id)
    {
        // xóa kết quả đánh giá
        DAL.DotDanhGia table4 = new DotDanhGiaController().GetByPrkey(hdfRecordID.Text);
        DataTable list = new TieuChi_DotDanhGiaController().GetByMaDotDanhGia(table4.ID);
        DAL.CanBoDuocDanhGia cb = new CanBoDuocDanhGiaController().GetByPrkey(id);
        if (cb != null)
        {
            foreach (DataRow item in list.Rows)
            {
                new KetQuaDanhGiaController().DeleteByMaCBvaIdTieuChiDotDanhGia(cb.MaCB, int.Parse(item["ID"].ToString()));
            }
        }

        new CanBoDuocDanhGiaController().DeleteByPrkey(id);
        hdfCanBoDuocDanhGiaID.Text = "";
    }

    [DirectMethod]
    public void DeleteRecordTieuChi(int id)
    {
        // xóa kết quả đánh giá
        new KetQuaDanhGiaController().DeleteByIdTieuChi_DotDanhGia(id);

        // xóa kết quả trong bảng TieuChi_DotDanhGia
        new TieuChi_DotDanhGiaController().DeleteByPrkey(id);
    }

    [DirectMethod]
    public void DisableButton()
    {
        foreach (var item1 in checkboxSelection.SelectedRows)
        {
            DAL.DotDanhGia info = new DotDanhGiaController().GetByPrkey(item1.RecordID);
            switch (info.HinhThucDanhGia)
            {
                case 0:     // Đánh giá cả đơn vị
                    break;
                case 1:     // Đánh giá trong phòng
                    btnThemCanBoDuocDanhGia.Disabled = true;
                    btnThemCanBoThamGiaDanhGia.Disabled = true;
                    btnXoaCanBoThamGiaDanhGia.Disabled = true;
                    btnXoaCanBoDuocDanhGia.Disabled = true;
                    fd.Collapsed = true;
                    fd.Collapsible = false;
                    ltrColapsibleStyle.Text = "<style type='text/css'> div.x-tool-expand-south {display: none !important;}</style>";
                    RM.RegisterClientScriptBlock("rlst", "Delete(#{grp_CanBoDuocDanhGia}, #{grp_CanBoDuocDanhGia_Store}); Delete(#{grp_CanBoThamGiaDanhGia}, #{grp_CanBoThamGiaDanhGia_Store});");
                    break;
                case 2:     // Chỉ định cán bộ tham gia đánh giá
                    fd.Collapsible = true;
                    fd.Collapsed = false;
                    RM.RegisterClientScriptBlock("rlst", "grp_CanBoThamGiaDanhGia_Store.reload();grp_CanBoDuocDanhGia_Store.reload();btnThemCanBoDuocDanhGia.enable();btnThemCanBoThamGiaDanhGia.enable();btnXoaCanBoThamGiaDanhGia.enable();btnXoaCanBoDuocDanhGia.enable();");
                    break;
            }
        }

    }

    [DirectMethod]
    public void DeleteRecordCanBoThamDanhGia(int id)
    {
        new CanBoThamGiaDanhGiaController().DeleteByPrkey(id);
        hdfCanBoThamGiaDanhGiaID.Text = "";
    }

    [DirectMethod]
    public void ResetWindowTitle()
    {
        wdAddWindow.Icon = Icon.Add;
        wdAddWindow.Title = "Thêm mới đợt đánh giá";
        txtID.Disabled = false;
    }

    protected void btnEdit_Click(object sender, DirectEventArgs e)
    {
        DAL.DotDanhGia record = new DotDanhGiaController().GetByPrkey(hdfRecordID.Text);
        txtID.Text = record.ID;
        hdfMaNguoiQL.SetValue(record.PrkeyCanBoQuanLy);
        try
        {
            DAL.HOSO hs = new HoSoController().GetByPrKey(record.PrkeyCanBoQuanLy.Value);
            cbxChonCanBo.Text = hs.HO_TEN;
        }
        catch (Exception)
        {

        }
        txtTenDotDanhGia.Text = record.TenDotDanhGia;
        if (record.TuNgay != null)
            txtTuNgay.SetValue(record.TuNgay);
        if (record.DenNgay != null)
            txtDenNgay.SetValue(record.DenNgay);
        cbxTrangThai.SetValue(record.TrangThaiDanhGia);
        txtGhiChu.Text = record.GhiChu;
        //chkIsTrongPhongDanhGiaLanNhau.Checked = bool.Parse(record.Rows[0]["TrongPhongDanhGiaLanNhau"].ToString());
        cbxLoaiDanhGia.SetValue(record.HinhThucDanhGia);
        txtTuDanhGia.SetValue(record.TL_TuDanhGia);
        txtNguoiKhacDanhGia.SetValue(record.TL_NguoiKhacDanhGia);
        txtQuanlyDanhGia.SetValue(record.TL_QuanLyDanhGia);
        cbLoaiXepHang.SetValue(record.MaLoaiXepHang);
        txtID.Disabled = true;

        wdAddWindow.Icon = Icon.Pencil;
        wdAddWindow.Title = "Sửa thông tin đợt đánh giá";
        wdAddWindow.Show();
        hdfOldHinhThucDanhGia.Text = record.HinhThucDanhGia.ToString();
    }
}
