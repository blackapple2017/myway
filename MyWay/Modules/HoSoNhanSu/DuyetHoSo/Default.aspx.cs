using DataController;
using Ext.Net;
using ExtMessage;
using SoftCore.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_HoSoNhanSu_DuyetHoSo_Default : WebBase
{
    #region param
    string[] hoSoStore = { 
                                     "LayHoSoDaiBieu",
                                     "LayQuanHeGiaDinhHoSo", 
                                     "LayHoSoDeTai", 
                                     "LayHoSoKhaNang", 
                                     "LayHoSoKhenThuong",
                                     "LayHoSoKyLuat",
                                     "LayHoSoQuaTrinhCongTac",
                                     "LayHoSoQuaTrinhDieuChuyen",
                                     "LayHoSoTaiSan",
                                     "LayHoSoQuaTrinhHocTap",
                                     "LayHoSoKinhNghiemLamViec",
                                     "LayHoSoChungChi",
                                     "LayHoSoTaiNanLaoDong",
                                     "LayHoSoTepTinDinhKem"
                                 };
    string[] tuCapNhat = { 
                                     "LayHoSoTuCapNhatDaiBieu", 
                                     "LayQuanHeGiaDinhHoSoTuCapNhat", 
                                     "LayHoSoTuCapNhatDeTai",
                                     "LayHoSoTuCapNhatKhaNang" ,
                                     "LayHoSoTuCapNhatKhenThuong",
                                     "LayHoSoTuCapNhatKyLuat",
                                     "LayTuCapNhatQuaTrinhCongTac",
                                     "LayTuCapNhatQuaTrinhDieuChuyen",
                                     "LayTuCapNhatTaiSan",
                                     "LayTuCapNhatQuaTrinhHocTap",
                                     "LayTuCapNhatKinhNghiemLamViec",
                                     "LayTuCapNhatChungChi",
                                     "LayTuCapNhatTaiNanLaoDong",
                                     "LayTuCapNhatTepTinDinhKem"
                                 };
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            new DTH.BorderLayout()
            {
                menuID = MenuID,
                script = "hdfMaDonVi.setValue('" + DTH.BorderLayout.nodeID + "');RowSelectionModel1.clearSelections();StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();"
            }.AddDepartmentList(br, CurrentUser.ID, true);

            SetVisibleByControlID(btnXemChiTiet, btnDelete, btnThongTinThem1,
                mnuKhaNang1, mnuKhenThuong1, mnuQuanHeGiaDinh1, mnuQuaTrinhCongTac1,
                mnuQuaTrinhDieuChuyen1, mnuTaiSan1, mnuTepTinDinhKem1, mnuQuaTrinhHocTap1, mnuKinhNghiemLamViec1,
                mnuChungChi1, mnuTaiNanLaoDong1);

            mnuXemChiTiet.Visible = btnXemChiTiet.Visible;
            mnuXoa.Visible = btnDelete.Visible;
        }
        if (btnXemChiTiet.Visible)
        {
            GridPanel1.Listeners.RowDblClick.Handler = "wdDuyet.show();setWindowTitle();";
        }
    }

    #region So sánh các thông tin chi tiết của Hồ Sơ
    /// <summary>
    /// So sánh ở các bảng chi tiết trước khi người dùng mở window
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void wdDuyet_BeforeShow(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (Ext.Net.MenuItem item in mnuThongTinThem.Items)
            {
                item.Text = item.Text;
            }
            foreach (Ext.Net.MenuItem item in mnuThongTinThem1.Items)
            {
                item.Text = item.Text;
            }
            string css = "<span style='color:red;'>{0}</span>";
            string khongDuyet = string.Empty;
            mnuInfomation.Icon = Icon.Information;
            mnuInfomation.Text = mnuInfomation.Text;
            btnThongTinThem1.Icon = Icon.Information;
            btnThongTinThem1.Text = mnuInfomation.Text;
            for (int i = 0; i < tuCapNhat.Length; i++)
            {
                DataTable hoSoTable = DataHandler.GetInstance().ExecuteDataTable(hoSoStore[i], "@userID", hdfSelectedUserID.Text);
                DataTable tuCapNhatTable = DataHandler.GetInstance().ExecuteDataTable(tuCapNhat[i], "@userID", hdfSelectedUserID.Text);
                KetQuaSoSanh ketQua = CompareTwoTable(hoSoTable, tuCapNhatTable);
                if (ketQua != KetQuaSoSanh.BangNhau)
                {
                    mnuInfomation.Icon = Icon.Exclamation;
                    mnuInfomation.Text = string.Format(css, mnuInfomation.Text);
                    btnThongTinThem1.Icon = Icon.Exclamation;
                    btnThongTinThem1.Text = string.Format(css, mnuInfomation.Text);
                    if (ketQua == KetQuaSoSanh.KhongDuyet)
                    {
                        khongDuyet = " [Không duyệt]";
                    }
                    else
                    {
                        khongDuyet = "";
                    }
                    switch (hoSoStore[i])
                    {
                        //case "LayHoSoDaiBieu":
                        //    mnuDaiBieu.Text = string.Format(css, mnuDaiBieu.Text + khongDuyet);
                        //    mnuDaiBieu1.Text = string.Format(css, mnuDaiBieu.Text + khongDuyet);
                        //    hdfThongTinSaiLech.Text += "Đại biểu, ";
                        //    hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoDaiBieu,";
                        //    break;
                        case "LayQuanHeGiaDinhHoSo":
                            mnuQuanHeGiaDinh.Text = string.Format(css, mnuQuanHeGiaDinh.Text + khongDuyet);
                            mnuQuanHeGiaDinh1.Text = string.Format(css, mnuQuanHeGiaDinh.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Quan hệ gia đình, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoQuanHeGiaDinh,";
                            break;
                        //case "LayHoSoDeTai":
                        //    mnuDeTai.Text = string.Format(css, mnuDeTai.Text + khongDuyet);
                        //    mnuDeTai1.Text = string.Format(css, mnuDeTai.Text + khongDuyet);
                        //    hdfThongTinSaiLech.Text += "Đề tài, ";
                        //    hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoDeTai,";
                        //    break;
                        case "LayHoSoKhaNang":
                            mnuKhaNang.Text = string.Format(css, mnuKhaNang.Text + khongDuyet);
                            mnuKhaNang1.Text = string.Format(css, mnuKhaNang.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Khả năng, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoKhaNang,";
                            break;
                        case "LayHoSoKhenThuong":
                            mnuKhenThuong.Text = string.Format(css, mnuKhenThuong.Text + khongDuyet);
                            mnuKhenThuong1.Text = string.Format(css, mnuKhenThuong.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Khen thưởng, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoKhenThuong,";
                            break;
                        //case "LayHoSoKyLuat":
                        //    mnuKyLuat.Text = string.Format(css, mnuKyLuat.Text + khongDuyet);
                        //    mnuKyLuat1.Text = string.Format(css, mnuKyLuat.Text + khongDuyet);
                        //    hdfThongTinSaiLech.Text += "Kỷ luật, ";
                        //    hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoKyLuat,";
                        //    break;
                        case "LayHoSoQuaTrinhCongTac":
                            mnuQuaTrinhCongTac.Text = string.Format(css, mnuQuaTrinhCongTac.Text + khongDuyet);
                            mnuQuaTrinhCongTac1.Text = string.Format(css, mnuQuaTrinhCongTac.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Quá trình công tác, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoQuaTrinhCongTac,";
                            break;
                        case "LayHoSoQuaTrinhDieuChuyen":
                            mnuQuaTrinhDieuChuyen.Text = string.Format(css, mnuQuaTrinhDieuChuyen.Text + khongDuyet);
                            mnuQuaTrinhDieuChuyen1.Text = string.Format(css, mnuQuaTrinhDieuChuyen.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Quá trình điều chuyển, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoQuaTrinhDieuChuyen,";
                            break;
                        case "LayHoSoTaiSan":
                            mnuTaiSan.Text = string.Format(css, mnuTaiSan.Text + khongDuyet);
                            mnuTaiSan1.Text = string.Format(css, mnuTaiSan.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Tài sản, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoTaiSan,";
                            break;
                        case "TepTinDinhKem":
                            mnuTepTinDinhKem.Text = string.Format(css, mnuTepTinDinhKem.Text + khongDuyet);
                            mnuTepTinDinhKem1.Text = string.Format(css, mnuTepTinDinhKem.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Tệp tin đính kèm, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoTepTinDinhKem,";
                            break;
                        case "LayHoSoQuaTrinhHocTap":
                            mnuQuaTrinhHocTap.Text = string.Format(css, mnuQuaTrinhHocTap.Text + khongDuyet);
                            mnuQuaTrinhHocTap1.Text = string.Format(css, mnuQuaTrinhHocTap.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Quá trình học tập, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoQuaTrinhHocTap,";
                            break;
                        case "LayHoSoKinhNghiemLamViec":
                            mnuKinhNghiemLamViec.Text = string.Format(css, mnuKinhNghiemLamViec.Text + khongDuyet);
                            mnuKinhNghiemLamViec1.Text = string.Format(css, mnuKinhNghiemLamViec.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Kinh nghiệm làm việc, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoKinhNghiemLamViec,";
                            break;
                        case "LayHoSoChungChi":
                            mnuChungChi.Text = string.Format(css, mnuChungChi.Text + khongDuyet);
                            mnuChungChi1.Text = string.Format(css, mnuChungChi.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Hồ sơ chứng chỉ, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoBangCapChungChi,";
                            break;
                        case "LayHoSoTaiNanLaoDong":
                            mnuTaiNanLaoDong.Text = string.Format(css, mnuTaiNanLaoDong.Text + khongDuyet);
                            mnuTaiNanLaoDong1.Text = string.Format(css, mnuTaiNanLaoDong.Text + khongDuyet);
                            hdfThongTinSaiLech.Text += "Tai nạn lao động, ";
                            hdfStoreDuyetThongTinSaiLech.Text += "DuyetHoSoTaiNanLaoDong,";
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    enum KetQuaSoSanh
    {
        BangNhau,
        KhacNhau,
        KhongDuyet
    }
    /// <summary>
    /// So sánh dữ liệu của 2 bảng, 2 bảng này phải có số cột giống nhau 
    /// </summary>
    /// <param name="hoSoTable"></param>
    /// <param name="tuCapNhatTable"></param>
    /// <returns></returns>
    private KetQuaSoSanh CompareTwoTable(DataTable hoSoTable, DataTable tuCapNhatTable)
    {
        foreach (DataRow row in tuCapNhatTable.Rows)
        {
            try
            {
                if (row["Duyet"].ToString() == "False")
                {
                    return KetQuaSoSanh.KhongDuyet;
                }
            }
            catch
            { }
        }
        int hoSoRowCount = hoSoTable.Rows.Count;
        int tuCapNhatRowCount = tuCapNhatTable.Rows.Count;
        if (tuCapNhatRowCount == 0 && hoSoRowCount == 0)
        {
            return KetQuaSoSanh.BangNhau;
        }
        if (hoSoRowCount != tuCapNhatRowCount)
        {
            return KetQuaSoSanh.KhacNhau;
        }

        for (int i = 0; i < tuCapNhatRowCount; i++)
        {
            DataRow r1 = hoSoTable.Rows[i];
            DataRow r2 = tuCapNhatTable.Rows[i];
            foreach (DataColumn col in hoSoTable.Columns)
            {
                if (r1[col.ColumnName].ToString() != r2[col.ColumnName].ToString())
                {
                    return KetQuaSoSanh.KhacNhau;
                }
            }
        }
        return KetQuaSoSanh.BangNhau;
    }
    /// <summary>
    /// Load dữ liệu vào 2 Grid để đối chiếu, một grid chứa thông tin cũ, một grid chứa thông tin mới
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void mnuThongTinThem_Click(object sender, DirectEventArgs e)
    {
        string hoSoStore = string.Empty;
        string tuCapNhatStore = string.Empty;
        switch (e.ExtraParams["LoaiThongTin"])
        {
            //case "DaiBieu":
            //    hoSoStore = "LayHoSoDaiBieu";
            //    tuCapNhatStore = "LayHoSoTuCapNhatDaiBieu";
            //    break;
            case "QuanHeGiaDinh":
                hoSoStore = "LayQuanHeGiaDinhHoSo";
                tuCapNhatStore = "LayQuanHeGiaDinhHoSoTuCapNhat";
                break;
            //case "DeTai":
            //    hoSoStore = "LayHoSoDeTai";
            //    tuCapNhatStore = "LayHoSoTuCapNhatDeTai";
            //    break;
            case "KhaNang":
                hoSoStore = "LayHoSoKhaNang";
                tuCapNhatStore = "LayHoSoTuCapNhatKhaNang";
                break;
            case "KhenThuong":
                hoSoStore = "LayHoSoKhenThuong";
                tuCapNhatStore = "LayHoSoTuCapNhatKhenThuong";
                break;
            //case "KyLuat":
            //    hoSoStore = "LayHoSoKyLuat";
            //    tuCapNhatStore = "LayHoSoTuCapNhatKyLuat";
            //    break;
            case "QuaTrinhCongTac":
                hoSoStore = "LayHoSoQuaTrinhCongTac";
                tuCapNhatStore = "LayTuCapNhatQuaTrinhCongTac";
                break;
            case "QuaTrinhDieuChuyen":
                hoSoStore = "LayHoSoQuaTrinhDieuChuyen";
                tuCapNhatStore = "LayTuCapNhatQuaTrinhDieuChuyen";
                break;
            case "TaiSan":
                hoSoStore = "LayHoSoTaiSan";
                tuCapNhatStore = "LayTuCapNhatTaiSan";
                break;
            case "TepTinDinhKem":
                hoSoStore = "LayHoSoTepTinDinhKem";
                tuCapNhatStore = "LayTuCapNhatTepTinDinhKem";
                break;
            case "QuaTrinhHocTap":
                hoSoStore = "LayHoSoQuaTrinhHocTap";
                tuCapNhatStore = "LayTuCapNhatQuaTrinhHocTap";
                break;
            case "KinhNghiemLamViec":
                hoSoStore = "LayHoSoKinhNghiemLamViec";
                tuCapNhatStore = "LayTuCapNhatKinhNghiemLamViec";
                break;
            case "BangCapChungChi":
                hoSoStore = "LayHoSoChungChi";
                tuCapNhatStore = "LayTuCapNhatChungChi";
                break;
            case "TaiNanLaoDong":
                hoSoStore = "LayHoSoTaiNanLaoDong";
                tuCapNhatStore = "LayTuCapNhatTaiNanLaoDong";
                break;
            default:
                break;
        }
        DataTable hoSo = DataHandler.GetInstance().ExecuteDataTable(hoSoStore, "@userID", hdfSelectedUserID.Text);
        DataTable tuCapNhat = DataHandler.GetInstance().ExecuteDataTable(tuCapNhatStore, "@userID", hdfSelectedUserID.Text);
        JsonReader jsonReader = new JsonReader();
        string colName = string.Empty; //Tên tiếng việt hoặc theo ngôn ngữ khác 
        foreach (DataColumn column in hoSo.Columns)
        {
            if (column.ColumnName == "Duyet")
            {
                continue;
            }
            colName = GlobalResourceManager.GetInstance().GetLanguageValue(column.ColumnName);
            switch (column.DataType.ToString())
            {
                case "System.Boolean":
                    this.grpThongTinCu.ColumnModel.Columns.Add(new Ext.Net.CheckColumn()
                    {
                        DataIndex = column.ColumnName,
                        Header = string.IsNullOrEmpty(colName) ? column.ColumnName : colName,
                    });
                    this.grpThongTinMoi.ColumnModel.Columns.Add(new Ext.Net.CheckColumn()
                    {
                        DataIndex = column.ColumnName,
                        Header = string.IsNullOrEmpty(colName) ? column.ColumnName : colName,
                    });
                    break;
                case "System.DateTime":
                    this.grpThongTinCu.ColumnModel.Columns.Add(new Ext.Net.DateColumn()
                    {
                        DataIndex = column.ColumnName,
                        Header = string.IsNullOrEmpty(colName) ? column.ColumnName : colName,
                        Format = "dd/MM/yyyy"
                    });

                    this.grpThongTinMoi.ColumnModel.Columns.Add(new Ext.Net.DateColumn()
                    {
                        DataIndex = column.ColumnName,
                        Header = string.IsNullOrEmpty(colName) ? column.ColumnName : colName,
                        Format = "dd/MM/yyyy"
                    });
                    break;
                default:
                    this.grpThongTinCu.ColumnModel.Columns.Add(new Ext.Net.Column()
                    {
                        DataIndex = column.ColumnName,
                        Header = string.IsNullOrEmpty(colName) ? column.ColumnName : colName,
                    });

                    this.grpThongTinMoi.ColumnModel.Columns.Add(new Ext.Net.Column()
                    {
                        DataIndex = column.ColumnName,
                        Header = string.IsNullOrEmpty(colName) ? column.ColumnName : colName,
                    });
                    break;
            }
            RecordField field = new RecordField(column.ColumnName);
            jsonReader.Fields.Add(field);
        }
        grpThongTinCuStore.Reader.Add(jsonReader);
        grpThongTinCuStore.DataSource = hoSo;
        grpThongTinCuStore.DataBind();

        grpThongTinMoiStore.Reader.Add(jsonReader);
        grpThongTinMoiStore.DataSource = tuCapNhat;
        grpThongTinMoiStore.DataBind();

        grpThongTinCu.Reconfigure();
        grpThongTinCu.Render();
        grpThongTinMoi.Reconfigure();
        grpThongTinMoi.Render();
    }
    #endregion

    #region Duyệt & Xóa
    protected void DuyetCacThongTinDuocChon(object sender, DirectEventArgs e)
    {
        try
        {
            SelectedRowCollection selecteds = RowSelectionModelDuyet.SelectedRows;
            string listField = string.Empty;
            string itemName = string.Empty;
            foreach (var item in selecteds)
            {
                if (item.RecordID == "TEN_NH")
                    itemName = "TAI_NH";
                else
                    itemName = item.RecordID.Replace("TEN_", "MA_");
                listField += itemName + ",";
            }
            int pos = listField.LastIndexOf(',');
            if (pos != -1)
                listField = listField.Remove(pos);
            DataController.DataHandler.GetInstance().ExecuteNonQuery("HoSo_ApprovedSelectedField", "@UserID", "@ListField", hdfSelectedUserID.Text, listField);
            grpCompare.Reload();
            RM.RegisterClientScriptBlock("clear", "RowSelectionModelDuyet.clearSelections();");
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    protected void btnDuyetVaChuyenSangHoSo_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //lấy ra các thông tin có khả năng sai lệch
            if (!string.IsNullOrEmpty(hdfThongTinSaiLech.Text))
            {
                dpfCanhBao.Text = string.Format("Các thông tin {0} có khả năng bị sai lệch, bạn có chắc chắn tiếp tục duyệt", hdfThongTinSaiLech.Text);
                wdCanhBao.Show();
                return;
            }
            else //truy vấn tới CSDL kiểm tra thông tin sai lệch
            {
                wdDuyet_BeforeShow(sender, e);
                if (!string.IsNullOrEmpty(hdfThongTinSaiLech.Text))
                {
                    dpfCanhBao.Text = string.Format(dpfCanhBao.Text, hdfThongTinSaiLech.Text);
                    wdCanhBao.Show();
                    return;
                }
            }
            new TuCapNhatController().CopyToHoSo(int.Parse(hdfSelectedUserID.Text), CurrentUser.ID, "", Session["MaDonVi"].ToString());
            wdDuyet.Hide();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Cảnh báo", ex.Message).Show();
        }
    }

    protected void btnTiepTucDuyet_Click(object sender, DirectEventArgs e)
    {
        try
        {
            //Duyệt tất cả các thông tin
            if (rdDongYDuyet.Checked)
            {
                new TuCapNhatController().CopyToHoSo(int.Parse(hdfSelectedUserID.Text), CurrentUser.ID, "", Session["MaDonVi"].ToString());
            }
            else if (rdChiDuyetThongTinChinhXac.Checked)
            {
                new TuCapNhatController().CopyToHoSo(int.Parse(hdfSelectedUserID.Text), CurrentUser.ID, hdfStoreDuyetThongTinSaiLech.Text, Session["MaDonVi"].ToString());
            }
            wdCanhBao.Hide();
            wdDuyet_BeforeShow(sender, e);
            GridPanel1.Reload();
            wdDuyet.Hide();
            wdSoSanhChiTiet.Hide();

        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    /// <summary>
    /// Không duyệt thông tin Hồ sơ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTiepTucKhongDuyet_Click(object sender, DirectEventArgs e)
    {
        try
        {
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                new TuCapNhatController().KhongDuyet(int.Parse(item.RecordID), txtLyDoKhongDuyet.Text, CurrentUser.ID);
            } 
            wdNhapLyDoKhongDuyet.Hide();
            wdDuyet.Hide();
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }
    /// <summary>
    /// Duyệt thông tin ở các bảng chi tiết
    /// Cách thức duyệt như sau
    /// Nếu ở bảng HOSO đã có thông tin rồi thì chuyển hết thông tin mới sang hồ sơ và xóa thông tin cũ đi
    /// Nếu bảng HOSO chưa có thì ta chỉ đánh dấu Duyet trong bảng chi tiết
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDuyetChiTiet_Click(object sender, DirectEventArgs e)
    {
        try
        {
            switch (hdfThongTinChiTiet.Text)
            {
                case "QuanHeGiaDinh":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoQuanHeGiaDinh", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "QuanHeGiaDinh";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Quan hệ gia đình,", "").Trim();
                    break;
                case "KhaNang":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoKhaNang", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "KhaNang";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Khả năng,", "").Trim();
                    break;
                case "KhenThuong":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoKhenThuong", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "KhenThuong";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Khen thưởng,", "").Trim();
                    break;
                case "QuaTrinhCongTac":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoQuaTrinhCongTac", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "QuaTrinhCongTac";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Quá trình công tác,", "").Trim();
                    break;
                case "QuaTrinhDieuChuyen":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoQuaTrinhDieuChuyen", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "QuaTrinhDieuChuyen";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Quá trình điều chuyển,", "").Trim();
                    break;
                case "TaiSan":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoTaiSan", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "TaiSan";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Tài sản,", "").Trim();
                    break;
                case "TepTinDinhKem":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoTepTinDinhKem", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "TepTinDinhKem";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Tệp tin đính kèm,", "").Trim();
                    break;
                case "QuaTrinhHocTap":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoQuaTrinhHocTap", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "QuaTrinhHocTap";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Quá trình học tập,", "").Trim();
                    break;
                case "KinhNghiemLamViec":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoKinhNghiemLamViec", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "KinhNghiemLamViec";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Kinh nghiệm làm việc,", "").Trim();
                    break;
                case "BangCapChungChi":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoBangCapChungChi", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "BangCapChungChi";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Hồ sơ chứng chỉ,", "").Trim();
                    break;
                case "TaiNanLaoDong":
                    DataHandler.GetInstance().ExecuteNonQuery("DuyetHoSoTaiNanLaoDong", "@userid", hdfSelectedUserID.Text);
                    e.ExtraParams["LoaiThongTin"] = "TaiNanLaoDong";
                    hdfThongTinSaiLech.Text = hdfThongTinSaiLech.Text.Replace("Tai nạn lao động,", "").Trim();
                    break;
            }

            mnuThongTinThem_Click(sender, e); //reload lại grid thông tin cũ
            wdDuyet_BeforeShow(sender, e); //reset lại các menu thông tin thêm
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    /// <summary>
    /// Không duyệt chi tiết
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnKhongDuyetChiTiet_Click(object sender, DirectEventArgs e)
    {
        try
        {
            switch (hdfThongTinChiTiet.Text)
            {
                case "QuanHeGiaDinh":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoQuanHeGiaDinh", "@userid", hdfSelectedUserID.Text);
                    break;
                case "KhaNang":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoKhaNang", "@userid", hdfSelectedUserID.Text);
                    break;
                case "KhenThuong":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoKhenThuong", "@userid", hdfSelectedUserID.Text);
                    break;
                case "KyLuat":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoKyLuat", "@userid", hdfSelectedUserID.Text);
                    break;
                case "QuaTrinhCongTac":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoQTCongTac", "@userid", hdfSelectedUserID.Text);
                    break;
                case "QuaTrinhDieuChuyen":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoQTDieuChuyen", "@userid", hdfSelectedUserID.Text);
                    break;
                case "TaiSan":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoTaiSan", "@userid", hdfSelectedUserID.Text);
                    break;
                case "TepTinDinhKem":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoTepTinDinhKem", "@userid", hdfSelectedUserID.Text);
                    break;
                case "QuaTrinhHocTap":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoQuaTrinhHocTap", "@userid", hdfSelectedUserID.Text);
                    break;
                case "KinhNghiemLamViec":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoKNLV", "@userid", hdfSelectedUserID.Text);
                    break;
                case "BangCapChungChi":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoChungChi", "@userid", hdfSelectedUserID.Text);
                    break;
                case "TaiNanLaoDong":
                    DataHandler.GetInstance().ExecuteNonQuery("HuyDuyetHoSoTaiNanLaoDong", "@userid", hdfSelectedUserID.Text);
                    break;
            }
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    protected void btnDelete_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string selectedID = "";
            foreach (var item in RowSelectionModel1.SelectedRows)
            {
                selectedID += item.RecordID + ",";
            }
            if (!string.IsNullOrEmpty(selectedID))
            {
                new TuCapNhatController().Delete(selectedID);
            }
            btnDelete.Disabled = true;
            mnuChuyenTrangThai.Disabled = true;
            btnXemChiTiet.Disabled = true;
            GridPanel1.Reload();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message).Show();
        }
    }

    #endregion

    #region So sánh các thông tin ở bảng HOSO
    struct HoSoInfo
    {
        public string ColumnName { get; set; }
        public string VietnameseName { get; set; }
        public string GroupName { get; set; }
    };
    /// <summary>
    /// Lấy thông tin cột dựa vào tên cột trong bảng HOSO
    /// </summary>
    /// <param name="columnNameInDB"></param>
    /// <returns></returns>
    private object[] getColumnInfomation(string columnNameInDB)
    {
        foreach (object[] item in HoSoTableInfo)
        {
            if (item[0].ToString() == columnNameInDB)
            {
                return item;
            }
        }
        return null;
    }
    /// <summary>
    /// Lấy dữ liệu chuẩn 
    /// </summary>
    /// <param name="columnName"></param>
    /// <param name="originalValue"></param>
    /// <returns></returns>
    private string getFormatedData(string columnName, string originalValue)
    {
        switch (columnName)
        {
            case "MA_GIOITINH":
                if (originalValue == "F")
                {
                    return "Nữ";
                }
                return "Nam";
            case "CHIEU_CAO":
                if (!string.IsNullOrEmpty(originalValue))
                {
                    return originalValue + " cm";
                }
                return originalValue;
            case "NGAY_TUYEN_DTIEN":
            case "CAN_NANG":
                if (!string.IsNullOrEmpty(originalValue))
                {
                    return originalValue + " Kg";
                }
                return originalValue;
            case "NGAY_TUYEN_CHINHTHUC":
            case "NGAY_SINH":
            case "NGAY_BN_CHUCVU":
            case "NGAY_BN_NGACH":
            case "NGAY_HETHAN_BHYT":
            case "NGAYCAP_BHXH":
            case "NGAYCAP_HOCHIEU":
            case "NGAY_HETHAN_HOCHIEU":
            case "NGAYVAO_QDOI":
            case "NGAYRA_QDOI":
            case "NGAYVAO_DANG":
            case "NGAY_CTHUC_DANG":
            case "NGAY_DONGBH":
            case "NGAY_KTBH":
            case "NgayVaoCongDoan":
            case "NGAYCAP_CMND":
            case "NGAYVAO_DOAN":
            case "NGAY_TGCM":
                if (originalValue.Contains("SA") || originalValue.Contains("CH"))
                {
                    return originalValue.Remove(originalValue.IndexOf(" "));
                }
                else if (originalValue.Contains("AM") || originalValue.Contains("PM"))
                {
                    SoftCore.Util.GetInstance().GetDateTimeEnfromVi(originalValue);
                }
                return originalValue;
            case "LaThuongBinh":
                if (string.IsNullOrEmpty(originalValue))
                {
                    return "";
                }
                if (originalValue == "False")
                {
                    return "Không phải thương binh";
                }
                return "Là thương binh";
            case "DaThamGiaQuanDoi":
                if (string.IsNullOrEmpty(originalValue))
                {
                    return "";
                }
                if (originalValue == "False")
                {
                    return "Chưa tham gia quân đội";
                }
                return "Đã tham gia quân đội";
            case "LaDangVien":
                if (string.IsNullOrEmpty(originalValue))
                {
                    return "";
                }
                if (originalValue == "False")
                {
                    return "Không phải đảng viên";
                }
                return "Là đảng viên";
            case "PHOTO":
                if (string.IsNullOrEmpty(originalValue))
                {
                    return "";
                }
                return string.Format("<img width='150px' src='../../{0}'/>", originalValue.Replace("~/Modules/", ""));
            default:
                return originalValue;
        }
    }

    /// <summary>
    /// Lưu trữ tên cột của bảng HOSO
    /// </summary>
    private object[] HoSoTableInfo
    {
        get
        {
            return new Object[] { 
                  new object[]{"HO_TEN","Họ tên","1.Thông tin cơ bản"},
                  new object[]{"SOHIEU_CCVC","Số hiệu CCVC","1.Thông tin cơ bản"}, 
                  new object[]{"NGAY_SINH","Ngày sinh","1.Thông tin cơ bản"},
                  new object[]{"MA_GIOITINH","Giới tính","1.Thông tin cơ bản"},
                  new object[]{"TEN_TT_HN","Tình trạng hôn nhân","1.Thông tin cơ bản"},
                  new object[]{"BI_DANH","Bí danh","1.Thông tin cơ bản"},
                  new object[]{"NOI_SINH","Nơi sinh","1.Thông tin cơ bản"},
                  new object[]{"TEN_TINHTHANH","Tỉnh thành","1.Thông tin cơ bản"},
                  new object[]{"DIA_CHI_LH","Hộ khẩu thường trú","1.Thông tin cơ bản"},
                  new object[]{"HO_KHAU","Hộ khẩu","1.Thông tin cơ bản"},
                  new object[]{"TEN_NUOC","Quốc tịch","1.Thông tin cơ bản"},
                  new object[]{"TEN_DANTOC","Dân tộc","1.Thông tin cơ bản"},
                  new object[]{"TEN_TONGIAO","Tôn giáo","1.Thông tin cơ bản"},
                  new object[]{"TEN_TP_GIADINH","Thành phần gia đình","1.Thông tin cơ bản"},
                  new object[]{"TEN_TP_BANTHAN","Thành phần bản thân","1.Thông tin cơ bản"},
                  new object[]{"SO_THICH","Sở thích","1.Thông tin cơ bản"},
                  new object[]{"UU_DIEM","Ưu điểm","1.Thông tin cơ bản"},
                  new object[]{"NHUOC_DIEM","Nhược điểm","1.Thông tin cơ bản"},
                  new object[]{"QueQuan","Quê quán","1.Thông tin cơ bản"}, 
                  new object[]{"PHOTO","Ảnh","1.Thông tin cơ bản"},                                    
                  //Thông tin liên hệ
                  new object[]{"DI_DONG","Di động","2.Thông tin liên hệ"},
                  new object[]{"DT_NHA","Điện thoại nhà","2.Thông tin liên hệ"},
                  new object[]{"DT_CQUAN","Điện thoại cơ quan","2.Thông tin liên hệ"}, 
                  new object[]{"EMAIL","Email","2.Thông tin liên hệ"},
                  new object[]{"EMAIL_RIENG","Email khác","2.Thông tin liên hệ"},
                  new object[]{"NguoiLienHe","Người liên hệ trong trường hợp khẩn cấp","2.Thông tin liên hệ"},
                  new object[]{"SDTNguoiLienHe","Số điện thoại người liên hệ","2.Thông tin liên hệ"},
                  new object[]{"QuanHeVoiCanBo","Quan hệ với nhân viên","2.Thông tin liên hệ"},
                  new object[]{"EmailNguoiLienHe","Email người liên hệ","2.Thông tin liên hệ"},
                  new object[]{"DiaChiNguoiLienHe","Địa chỉ người liên hệ ","2.Thông tin liên hệ"},

                  //Thông tin sức khỏe
                  new object[]{"TEN_TT_SUCKHOE","Tình trạng sức khỏe","7.Thông tin sức khỏe"},
                  new object[]{"NHOM_MAU","Nhóm máu","7.Thông tin sức khỏe"},
                  new object[]{"CHIEU_CAO","Chiều cao","7.Thông tin sức khỏe"},
                  new object[]{"CAN_NANG","Cân nặng","7.Thông tin sức khỏe"},
                  new object[]{"LaThuongBinh","Là thương binh","7.Thông tin sức khỏe"},
                  new object[]{"HangThuongTat","Hạng thương tật","7.Thông tin sức khỏe"},
                  new object[]{"SoThuongTat","Số thương tật","7.Thông tin sức khỏe"},
                  new object[]{"HinhThucThuongTat","Hình thức thương tật","7.Thông tin sức khỏe"},

                  //Thông tin chính trị
                  new object[]{"TEN_LOAI_CS","Tên loại chính sách","8.Thông tin chính trị"},
                  new object[]{"NGAY_TGCM","Ngày tham gia cách mạng","8.Thông tin chính trị"},
                  new object[]{"NGAYVAO_QDOI","Ngày vào quân đội" ,"8.Thông tin chính trị"},
                  new object[]{"NGAYRA_QDOI","Ngày ra quân đội","8.Thông tin chính trị"},
                  new object[]{"TEN_CAPBAC_QDOI","Cấp bậc quân đội","8.Thông tin chính trị"},
                  new object[]{"TEN_CHUCVU_QDOI","Chức vụ quân đội","8.Thông tin chính trị"},
                  new object[]{"NGAYVAO_DOAN","Ngày vào đoàn","8.Thông tin chính trị"},
                  new object[]{"NOI_KETNAP_DOAN","Nơi kết nạp Đoàn","8.Thông tin chính trị"},
                  new object[]{"TEN_CHUCVU_DOAN","Chức vụ Đoàn","8.Thông tin chính trị"},
                  new object[]{"NGAYVAO_DANG","Ngày vào Đảng","8.Thông tin chính trị"},
                  new object[]{"NGAY_CTHUC_DANG","Ngày chính thức vào Đảng","8.Thông tin chính trị"},
                  new object[]{"NOI_KETNAP_DANG","Nơi kết nạp Đảng","8.Thông tin chính trị"},
                  new object[]{"SOTHE_DANG","Số thẻ Đảng","8.Thông tin chính trị"},
                  new object[]{"TEN_CHUCVU_DANG","Tên chức vụ Đảng","8.Thông tin chính trị"},
                  new object[]{"TEN_TD_CHINHTRI","Trình độ chính trị","8.Thông tin chính trị"},
                  new object[]{"LaDangVien","Là Đảng viên","8.Thông tin chính trị"},
                  new object[]{"NoiSinhHoatDang","Nơi sinh hoạt Đảng","8.Thông tin chính trị"},
                  new object[]{"DaThamGiaQuanDoi","Đã tham gia quân đội","8.Thông tin chính trị"}, 
                  new object[]{"NgayVaoCongDoan","Ngày vào công đoàn","8.Thông tin chính trị"},
                  new object[]{"ChucVuCongDoan","Chức vụ công đoàn","8.Thông tin chính trị"},

                  //Trình độ học vấn
                  new object[]{"TEN_TD_VANHOA","Trình độ văn hóa","3.Trình độ" }, 
                  new object[]{"TEN_NGOAINGU","Ngoại ngữ","3.Trình độ" },
                  new object[]{"TEN_TINHOC","Trình độ tin học","3.Trình độ" },
                  new object[]{"TEN_TRINHDO", "Trình độ","3.Trình độ" },
                  new object[]{"TEN_CHUYENNGANH","Chuyên ngành","3.Trình độ" },
                  new object[]{"NAM_TN","Năm tốt nghiệp","3.Trình độ" },
                  new object[]{"TEN_XEPLOAI","Xếp loại tốt nghiệp","3.Trình độ" },
                  new object[]{"TEN_TRUONG_DAOTAO","Trường đào tạo","3.Trình độ" }, 
                  new object[]{"TEN_NGACH","Ngạch","3.Trình độ" },
                  new object[]{"NGAY_BN_NGACH","Ngày bổ nhiệm ngạch","3.Trình độ" },
                  new object[]{"TEN_TD_QUANLY","Trình độ quản lý","3.Trình độ" },
                  new object[]{"TEN_TD_QLKT","Trình độ quản lý kinh tế","3.Trình độ" },

                  //Thông tin công việc
                  new object[]{"TEN_CONGVIEC", "Vị trí công việc","4.Thông tin công việc"},
                  new object[]{"TEN_LOAI_HDONG","Loại hợp đồng","4.Thông tin công việc"},
                  new object[]{"TEN_CHUCVU","Chức vụ","4.Thông tin công việc"},
                  new object[]{"NGAY_BN_CHUCVU","Ngày bổ nhiệm chức vụ","4.Thông tin công việc"}, 
                  new object[]{"TEN_CONGTRINH", "Công trình","4.Thông tin công việc"},
                  new object[]{"NGAY_TUYEN_DTIEN","Ngày thử việc","4.Thông tin công việc"},
                  new object[]{"NGAY_TUYEN_CHINHTHUC","Ngày nhận chính thức","4.Thông tin công việc"},
                  new object[]{"TEN_HT_TUYENDUNG","Hình thức tuyển dụng","4.Thông tin công việc"},
                  new object[]{"HinhThucLamViec","Hình thức làm việc","4.Thông tin công việc"},
                  //Thông tin bảo hiểm
                  new object[]{"SOTHE_BHYT","Số thẻ BHYT","5.Thông tin bảo hiểm" },
                  new object[]{"NGAY_HETHAN_BHYT","Ngày hết hạn BHYT","5.Thông tin bảo hiểm" },
                  new object[]{"TEN_NOI_KCB","Nơi khám chữa bệnh","5.Thông tin bảo hiểm" },
                  new object[]{"SOTHE_BHXH","Số thẻ BHXH","5.Thông tin bảo hiểm" },
                  new object[]{"NGAYCAP_BHXH","Ngày cấp BHXH","5.Thông tin bảo hiểm" },
                  new object[]{"TEN_NOICAP_BHXH","Nơi cấp BHXH","5.Thông tin bảo hiểm" },
                  new object[]{"TYLE_DONG_BH","Tỷ lệ đóng BH","5.Thông tin bảo hiểm" },
                  new object[]{"NGAY_DONGBH","Ngày đóng bảo hiểm","5.Thông tin bảo hiểm" },
                  new object[]{"NGAY_KTBH","Ngày kết thúc bảo hiểm","5.Thông tin bảo hiểm" },

                  //Chứng minh thư nhân dân - hộ chiếu
                  new object[]{"SO_CMND","Số CMND","6.Chứng minh thư nhân dân - hộ chiếu"},
                  new object[]{"TEN_NOICAP_CMND","Nơi cấp CMND","6.Chứng minh thư nhân dân - hộ chiếu"},
                  new object[]{"NGAYCAP_CMND","Ngày cấp CMND","6.Chứng minh thư nhân dân - hộ chiếu"},
                  new object[]{"SO_HOCHIEU","Số hộ chiếu","6.Chứng minh thư nhân dân - hộ chiếu"},
                  new object[]{"NGAYCAP_HOCHIEU","Ngày cấp hộ chiếu","6.Chứng minh thư nhân dân - hộ chiếu"},
                  new object[]{"NGAY_HETHAN_HOCHIEU","Ngày hết hạn hộ chiếu","6.Chứng minh thư nhân dân - hộ chiếu"},
                  new object[]{"TEN_NOICAP_HOCHIEU","Nơi cấp hộ chiếu","6.Chứng minh thư nhân dân - hộ chiếu"},
                   
                  //Tài khoản ngân hàng
                  new object[]{"MST_CANHAN","Mã số thuế cá nhân","9.Tài khoản ngân hàng"},
                  new object[]{"SO_TAI_KHOAN","Số tài khoản","9.Tài khoản ngân hàng"},
                  new object[]{"TAI_NH","Ngân hàng","9.Tài khoản ngân hàng"},
                  
                  
            };
        }
    }
    struct CompareInfo
    {
        public string InformationField { get; set; }
        public string InformationName { get; set; }
        public string OldInformation { get; set; }
        public string NewInformation { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
    }
    protected void grpCompareStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            string filter = cbLocTheoTrangThai.SelectedItem.Value ?? "";
            List<CompareInfo> objData = new List<CompareInfo>();
            DataTable hoso = DataController.DataHandler.GetInstance().ExecuteDataTable("GetHoSoByUserID", "@userID", hdfSelectedUserID.Text);
            DataTable tuCapNhat = DataController.DataHandler.GetInstance().ExecuteDataTable("GetTuCapNhapByUserID", "@userID", hdfSelectedUserID.Text);
            //Nhập mới hoàn toàn, chưa được duyệt tí gì
            if (hoso.Rows.Count == 0)
            {
                foreach (DataRow row in tuCapNhat.Rows)
                {
                    foreach (DataColumn column in tuCapNhat.Columns)
                    {
                        object[] columnInfo = getColumnInfomation(column.ColumnName);
                        objData.Add(new CompareInfo
                        {
                            InformationField = columnInfo[0].ToString(),
                            InformationName = columnInfo[1].ToString(),
                            OldInformation = "",
                            NewInformation = getFormatedData(columnInfo[0].ToString(), row[column.ColumnName].ToString()),
                            Status = "new",
                            Group = columnInfo[2].ToString(),
                        });
                    }
                }
            }
            else //Có một vài thông tin mới người dùng cập nhật lại
            {
                string status = string.Empty;
                foreach (DataRow row in tuCapNhat.Rows)
                {
                    foreach (DataColumn column in tuCapNhat.Columns)
                    {
                        if (string.IsNullOrEmpty(hoso.Rows[0][column.ColumnName].ToString()) && string.IsNullOrEmpty(row[column.ColumnName].ToString()) == false)
                        {
                            status = "new";
                        }
                        else if (row[column.ColumnName].ToString() != hoso.Rows[0][column.ColumnName].ToString())
                        {
                            status = "edit";
                        }
                        else if (row[column.ColumnName].ToString() == hoso.Rows[0][column.ColumnName].ToString() && !string.IsNullOrEmpty(hoso.Rows[0][column.ColumnName].ToString()))
                        {
                            status = "equal";
                        }
                        else
                        {
                            status = "nothing";
                        }
                        if (filter.Contains(status) || string.IsNullOrEmpty(filter))
                        {
                            object[] columnInfo = getColumnInfomation(column.ColumnName);

                            objData.Add(new CompareInfo
                            {
                                InformationField = columnInfo[0].ToString(),
                                InformationName = columnInfo[1].ToString(),
                                OldInformation = getFormatedData(columnInfo[0].ToString(), hoso.Rows[0][column.ColumnName].ToString()),
                                NewInformation = getFormatedData(columnInfo[0].ToString(), row[column.ColumnName].ToString()),
                                Status = status,
                                Group = columnInfo[2].ToString(),
                            });

                        }
                    }
                }
            }
            grpCompareStore.DataSource = objData.OrderByDescending(t => t.Group);
            grpCompareStore.DataBind();
        }
        catch (Exception ex)
        {
            X.MessageBox.Alert("Có lỗi xảy ra", ex.Message);
        }
    }
    #endregion
}