using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using ExtMessage;
using System.Data;
using Controller.DanhGia;

public partial class Modules_DanhGia_TienHanhDanhGia_TienHanhDanhGia : SoftCore.Security.WebBase
{
    private static bool isNguoiQL = false;
    private static bool isTuDanhGia = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.QueryString["type"];
        switch (type)
        {
            case "NguoiQLDG":
                isNguoiQL = true;
                isTuDanhGia = false;
                // ẩn cột tự đánh giá
                txtTomTat.Hide();
                //grp_TieuChiDanhGia.ColumnModel.SetHidden(3, false);
                break;
            case "TuDG":
                isTuDanhGia = true;
                isNguoiQL = false;
                grp_TieuChiDanhGia.ColumnModel.SetHidden(4, true);
                // ẩn nhận xét
                txtLyDo.Hide();
                txtTomTat.Show();
                txtLienQuanNhanXet.Hide();
                txtQuanLyNhanXet.Hide();
                txtDeXuat.Hide();
                txt_tunhanxet.Hide();
                // rieng cho austfeed
                break;
            default:
                isTuDanhGia = false;
                isNguoiQL = false;
                // ẩn nhận xét
                txtLyDo.Hide();
                txtQuanLyNhanXet.Hide();
                txtTomTat.Hide();
                // rieng cho austfeed
                btnNhanXet.Hide();
                break;
        }
        hdfIsNguoiQL.Text = isNguoiQL.ToString();
        hdfIsTuDanhGia.Text = isTuDanhGia.ToString();

        if (!X.IsAjaxRequest)
        {
            hdfMaDonVi.Text = Session["MaDonVi"].ToString();
            hdfMaDotDanhGia.Text = "-1";

            // get MA_CB by UserID
            DAL.HOSO hoso = new HoSoController().GetByUserID(CurrentUser.ID);
            if (hoso != null)
            {
                hdfUser.Text = hoso.MA_CB;
                hdfMaBoPhan.Text = hoso.MA_DONVI;
            }
            hdfCreatedBy.Text = CurrentUser.ID.ToString();

            // get newest DotDanhGia
            string maDV = Session["MaDonVi"].ToString();
            DAL.HOSO hs = new HoSoController().GetByUserID(CurrentUser.ID);
            if (hs == null)
                return;
            int count = 0;
            string maDotDG = string.Empty;
            string tenDotDG = string.Empty;
            if (isNguoiQL)
            {
                //dotDG = new DotDanhGiaController().GetNewestDotDanhGia();
                DataTable table = new DotDanhGiaController().GetAllRecord(0, 1, "", maDV, "Đang thực hiện", true, hs.PR_KEY, out count);
                if (table.Rows.Count > 0)
                {
                    maDotDG = table.Rows[0]["ID"].ToString();
                    tenDotDG = table.Rows[0]["TenDotDanhGia"].ToString();
                }
            }
            else if (isTuDanhGia)
            {
                //dotDG = new DotDanhGiaController().GetNewestDotDanhGiaTHDG(maDV, hs.MA_CB);
                DataTable table = new DotDanhGiaController().GetDotDanhGiaTuDanhGia(0, 1, hs.MA_CB, maDV, "Đang thực hiện", out count);
                if (table.Rows.Count > 0)
                {
                    maDotDG = table.Rows[0]["ID"].ToString();
                    tenDotDG = table.Rows[0]["TenDotDanhGia"].ToString();
                }
            }
            else
            {
                DataTable table = new DotDanhGiaController().GetDotDanhGiaNormal(0, 1, hs.MA_CB, maDV, "Đang thực hiện", out count);
                if (table.Rows.Count > 0)
                {
                    maDotDG = table.Rows[0]["ID"].ToString();
                    tenDotDG = table.Rows[0]["TenDotDanhGia"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(maDotDG))
            {
                tbNorth.Title = "Đợt đánh giá: " + tenDotDG;
                // get employee by MaDotDanhGia
                hdfMaDotDanhGia.Text = maDotDG;
                grp_CanBoBiDanhGia.Reload();
                // selected first record
            }
        }
    }

    [DirectMethod]
    public void SetTitle()
    {
        string maDotDanhGia = hdfMaDotDanhGia.Text;
        if (maDotDanhGia != "")
        {
            DAL.DotDanhGia dotDanhGia = new DotDanhGiaController().GetByPrkey(maDotDanhGia);
            tbNorth.Title = "Đợt đánh giá: " + dotDanhGia.TenDotDanhGia;
        }
    }

    protected void btnEditNhanXet_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.NhanXet nxet = new NhanXetController().GetByMaDotVaMaCB(hdfMaDotDanhGia.Text, hdfMaCanBo.Text);
            if (nxet != null)
            {
                txtLyDo.Text = nxet.NhanXet2;
                txt_tunhanxet.Text = nxet.TuNhanXet;
                txtLienQuanNhanXet.Text = nxet.BanLQNhanXet;
                txtQuanLyNhanXet.Text = nxet.QuanLyNhanXet;
                txtDeXuat.Text = nxet.DeXuat;
                txtTomTat.Text = nxet.NhanXet1;
            }
            wdNhanXet.Show();
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void btnDongYNhanXet_Click(object sender, DirectEventArgs e)
    {
        try
        {
            DAL.NhanXet nhanXet = new DAL.NhanXet();
            nhanXet.NhanXet2 = txtLyDo.Text;
            nhanXet.TuNhanXet = txt_tunhanxet.Text;
            nhanXet.BanLQNhanXet = txtLienQuanNhanXet.Text;
            nhanXet.QuanLyNhanXet = txtQuanLyNhanXet.Text;
            nhanXet.DeXuat = txtDeXuat.Text;
            nhanXet.NhanXet1 = txtTomTat.Text;
            nhanXet.MaCB = hdfMaCanBo.Text;
            nhanXet.MaDotDG = hdfMaDotDanhGia.Text;
            new NhanXetController().Update(nhanXet);
            wdNhanXet.Hide();
        }
        catch (Exception ex)
        {
            Dialog.ShowError("Có lỗi xảy ra: " + ex.Message);
        }
    }

    protected void DSCBRowSelected(object sender, DirectEventArgs e)
    {
        // save old data
        //List<string> listsNX = new List<string>();
        //string[] nhanxet = hdfNhanXet.Text.Split('#');
        //for (int i = nhanxet.Count() - 1; i >= 0; i--)
        //{
        //    if (nhanxet[i].Trim() != "")
        //    {
        //        string[] tmp = nhanxet[i].Split('$');
        //        if (!listsNX.Contains(tmp[0].Trim()))
        //        {
        //            new KetQuaDanhGiaController().UpdateNhanXetByID(int.Parse("0" + tmp[0]), tmp[1]);
        //            listsNX.Add(tmp[0].Trim());
        //        }
        //    }
        //}
        //hdfNhanXet.Text = "";

        // save new data to result table
        string maCB = hdfMaCanBo.Text;
        string maDotDanhGia = hdfMaDotDanhGia.Text;
        // Danh sách các mã tiêu chí đã có trong bảng kết quả
        List<DAL.TieuChiDanhGia> lists = new TieuChi_DotDanhGiaController().GetTieuChiDanhGiaByMaDotDanhGia(maDotDanhGia);
        foreach (var item in lists)
        {
            //string comp = item.MaNhom + "," + maDotDanhGia + "," + CurrentUser.ID;
            if (new KetQuaDanhGiaController().GetKetQuaByMaCBandMaDotDanhGia(maCB, maDotDanhGia, item.MaNhom, CurrentUser.ID) == null)
            {
                DAL.KetQuaDanhGia info = new DAL.KetQuaDanhGia()
                {
                    CreatedBy = CurrentUser.ID,
                    CreatedDate = DateTime.Now,
                    Diem = 0,
                    IdTieuChi_DotDanhGia = new TieuChi_DotDanhGiaController().GetByMaDotDanhGiavaMaTieuChi(maDotDanhGia, item.MaNhom).ID,
                    IsQuanLyDanhGia = isNguoiQL,
                    MaCB = maCB,
                    NhanXet = "",
                };
                new KetQuaDanhGiaController().Insert(info);
            }
        }
        grp_CanBoBiDanhGia.Reload();
        grp_TieuChiDanhGia.Reload();
    }

    //protected void btnSave_Click(object sender, DirectEventArgs e)
    //{
    //    List<string> lists = new List<string>();
    //    string[] nhanxet = hdfNhanXet.Text.Split('#');
    //    for (int i = nhanxet.Count() - 1; i >= 0; i--)
    //    {
    //        if (nhanxet[i].Trim() != "")
    //        {
    //            string[] tmp = nhanxet[i].Split('$');
    //            if (!lists.Contains(tmp[0].Trim()))
    //            {
    //                new KetQuaDanhGiaController().UpdateNhanXetByID(int.Parse("0" + tmp[0]), tmp[1]);
    //                lists.Add(tmp[0].Trim());
    //            }
    //        }
    //    }
    //    hdfNhanXet.Text = "";
    //    grp_TieuChiDanhGia.Reload();
    //    grp_CanBoBiDanhGia.Reload();
    //}

    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<TienHanhDanhGia> canbos = e.DataHandler.ObjectData<TienHanhDanhGia>();

        foreach (TienHanhDanhGia updated in canbos.Updated)
        {
            DAL.TieuChi_DotDanhGia tc = new TieuChi_DotDanhGiaController().GetByMaDotDanhGiavaMaTieuChi(hdfMaDotDanhGia.Text, updated.MaNhom);
            KetQuaDanhGiaInfo kqua = new KetQuaDanhGiaInfo()
            {
                ID = updated.ID,
                CreatedBy = CurrentUser.ID,
                CreatedDate = DateTime.Now,
                Diem = (float)Math.Round(updated.Diem, 2),
                IdTieuChi_DotDanhGia = tc.ID,
                MaCB = hdfMaCanBo.Text,
                NhanXet = updated.NhanXet
            };
            if (isNguoiQL == true)
                kqua.IsQuanLyDanhGia = true;
            // update kết quả
            new KetQuaDanhGiaController().Update(kqua);
        }
        e.Cancel = true;
        Dialog.ShowNotification("Đã lưu kết quả đánh giá");
        // cập nhật kết quả hàng tháng
        try
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DanhGia_UpdateDanhGiaTheoThang", "@MaCanBo", "@MaDotDanhGia", hdfMaCanBo.Text, hdfMaDotDanhGia.Text);
        }
        catch (Exception ex)
        {
            
        }
    }
}
