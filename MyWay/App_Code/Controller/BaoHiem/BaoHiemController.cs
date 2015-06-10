using DAL;
using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore;
using SoftCore.AccessHistory;
using SoftCore.Security;
using System.Data;
using System.Messaging;
using ExtMessage;
using DataController;
/// <summary>
/// Summary description for BaoHiemController
/// </summary>
public class BaoHiemController : LinqProvider
{
    public BaoHiemController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ClearControl(Control control, bool setcolor)
    {
        TextField tf = control as TextField;
        NumberField nf = control as NumberField;
        TextArea ta = control as TextArea;
        SpinnerField sf = control as SpinnerField;
        Checkbox cb = control as Checkbox;
        DropDownField ddf = control as DropDownField;
        ComboBox cbb = control as ComboBox;
        DateField df = control as DateField;
        TriggerField tgf = control as TriggerField;
        MultiCombo mc = control as MultiCombo;
        if (setcolor)
        {
            if (tgf != null) { tgf.Reset(); tgf.StyleSpec = "color:black"; }
            if (df != null)
            {
                df.Reset();
                df.Call("setMaxValue", null);
                df.Call("setMinValue", null);
                df.StyleSpec = "color:black";
            }
            if (mc != null) { mc.Reset(); mc.StyleSpec = "color:black"; }
            if (cbb != null) { cbb.Reset(); cbb.StyleSpec = "color:black"; }
            if (ddf != null) { ddf.Reset(); ddf.StyleSpec = "color:black"; }
            if (cb != null) { cb.Reset(); cb.StyleSpec = "color:black"; }
            if (sf != null) { sf.Reset(); sf.StyleSpec = "color:black"; }
            if (ta != null) { ta.Reset(); ta.StyleSpec = "color:black"; }
            if (nf != null) { nf.Reset(); nf.StyleSpec = "color:black"; }
            if (tf != null) { tf.Reset(); tf.StyleSpec = "color:black"; }
            if (control.HasControls())
            {
                foreach (Control child in control.Controls)
                {
                    ClearControl(child, setcolor);
                }
            }
        }
        else
        {
            if (tgf != null) { tgf.Reset(); }
            if (df != null)
            {
                df.Reset();
                df.Call("setMaxValue", null);
                df.Call("setMinValue", null);

            }
            if (mc != null) { mc.Reset(); }
            if (cbb != null) { cbb.Reset(); }
            if (ddf != null) { ddf.Reset(); }
            if (cb != null) { cb.Reset(); }
            if (sf != null) { sf.Reset(); }
            if (ta != null) { ta.Reset(); }
            if (nf != null) { nf.Reset(); }
            if (tf != null) { tf.Reset(); }
            if (control.HasControls())
            {
                foreach (Control child in control.Controls)
                {
                    ClearControl(child, setcolor);
                }
            }
        }
    }
    public string ChuyenSoThangDongBH(int sothangdong)
    {
        int sothang = sothangdong;
        int nam = 0;
        nam = sothang / 12;
        int sothang_u = sothang % 12;
        if (nam == 0)
        {
            return sothang + " tháng";
        }
        else
        {
            return nam + " năm " + sothang_u + " tháng";
        }
    }

    //hàm set giá trị của 1 số kiểu datetime khi nhận vào là 1 combobox và 1 spin
    public DateTime? SetValueDatetime(SpinnerField sp, ComboBox cbb, int ngay)
    {
        if (sp.Text == "1900" || sp.Text == "" || sp.Value == null) return null;
        if (cbb.SelectedItem.Value != null)
            return new DateTime(int.Parse(sp.Text), int.Parse(cbb.Value.ToString()), 1);
        return null;
    }


    //phục vụ cho việc lấy thay đổi từ quyết định lương
    //đầu vào: idnhanvienBaoHiem
    //đầu ra: quyết định, lương bảo hiểm, các loại phụ cấp các kiểu còn hiệu lực
    public void TTQuyetDinhLuongMoiNhat(int IDNhanVienBaoHiem, out string soquyetdinh, out string tenquyetdinh, out DateTime? ngayky, out DateTime? ngayhieuluc, out DateTime? hethieuluc,
                                        out decimal? luongbaohiem, out decimal? phucapcv, out decimal? phucaptnn, out decimal? phucaptnvk, out decimal? phucapkhac)
    {
        var pcpl = dataContext.DanhMucPhuCapPhucLois.ToList();
        int[] pccv = pcpl.Where(p => p.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapChucVu" && p.TinhVaoBH == true).Select(p => p.ID).ToArray();
        int[] pctnvk = pcpl.Where(p => p.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapThamNienVuotKhung" && p.TinhVaoBH == true).Select(p => p.ID).ToArray();
        int[] pctnn = pcpl.Where(p => p.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapThamNienNghe" && p.TinhVaoBH == true).Select(p => p.ID).ToArray();
        int[] pck = pcpl.Where(p => p.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapKhac" && p.TinhVaoBH == true).Select(p => p.ID).ToArray();

        soquyetdinh = ""; tenquyetdinh = ""; ngayhieuluc = null; hethieuluc = null; luongbaohiem = 0; phucapcv = 0; phucaptnn = 0; phucaptnvk = 0; phucapkhac = 0; ngayky = null;
        //lấy tất cả những quyết định lương của ông có id= idnhanvienbaohiem
        List<DAL.HOSO_LUONG> tmp = dataContext.HOSO_LUONGs.Where(p => p.NgayHieuLuc <= DateTime.Now && p.TrangThai == "DaDuyet" && p.PrKeyHoSo == (decimal)IDNhanVienBaoHiem).ToList();
        //lấy quyết định lương gần đây nhất. bỏ qua việc xác nhận lỗi có 2 bản ghi cùng ngày hiệu lực
        DAL.HOSO_LUONG quyetdinhluong = tmp.OrderByDescending(t => t.NgayHieuLuc).FirstOrDefault(); //tmp.Where(p => p.NgayHieuLuc == tmp.Max(v => v.NgayHieuLuc)).SingleOrDefault();
        if (quyetdinhluong != null)
        {
            soquyetdinh = quyetdinhluong.SoQuyetDinh;
            tenquyetdinh = quyetdinhluong.TenQuyetDinh;
            ngayhieuluc = quyetdinhluong.NgayHieuLuc;
            hethieuluc = quyetdinhluong.NgayKetThucHieuLuc;
            ngayky = quyetdinhluong.NgayQuyetDinh;
            if (quyetdinhluong.LuongDongBHXH != null)
                luongbaohiem = (decimal)quyetdinhluong.LuongDongBHXH;


            //bảng phụ cấp chứa tất cả các phụ cấp (có thể các phụ cấp đã trùng)
            //
            var temptinhphucap1 = (from t in dataContext.HOSO_PHUCAPs
                                   where (t.TrangThai == "DaDuyet") && (t.FrKeyHOSO_LUONG == quyetdinhluong.ID)
                                   select t).ToList();
            //chỉ lấy những phụ cấp có ngày hiệu lực gần nhất
            var temptinhphucap = (from t in temptinhphucap1
                                  where t.NgayHieuLuc == (from x in temptinhphucap1
                                                          where x.MaPhuCap == t.MaPhuCap
                                                          select t.NgayHieuLuc).Max()
                                  select t).ToList();
            #region bỏ
            //var temptinhphucap = (from t in temptinhphucap1
            //                      group t by new
            //                      {
            //                          t.IDNhanVienBaoHiem,
            //                          t.MaPhuCap
            //                      } into g
            //                      let MaxNgayHieuLuc = g.Max(x => x.NgayHieuLuc)

            //                      from p in g
            //                      where p.NgayHieuLuc == MaxNgayHieuLuc
            //                      select new
            //                      {
            //                          g.Key.IDNhanVienBaoHiem,
            //                          g.Key.MaPhuCap,
            //                          SoTien = g.Sum(t => t.SoTien)
            //                      }).ToList();
            #endregion
            //phụ cấp chức vụ
            var cv = (from t in temptinhphucap
                      where pccv.Contains(t.MaPhuCap)
                      select new
                      {
                          t.SoTien
                      }).ToArray();

            if (cv != null)
            {
                phucapcv = (decimal)cv.Sum(p => p.SoTien);
            }
            //thâm niên vượt khung
            var tnvk = (from t in temptinhphucap
                        where pctnvk.Contains(t.MaPhuCap)
                        select new
                        {
                            t.SoTien
                        }).ToArray();

            if (tnvk != null)
            {
                phucaptnvk = (decimal)tnvk.Sum(p => p.SoTien);
            }
            //thâm niên nghề
            var tnn = (from t in temptinhphucap
                       where pctnn.Contains(t.MaPhuCap)
                       select new
                       {
                           t.SoTien
                       }).ToArray();

            if (tnn != null)
            {
                phucaptnn = (decimal)tnn.Sum(p => p.SoTien);
            }
            //phụ cấp khác
            var k = (from t in temptinhphucap
                     where pck.Contains(t.MaPhuCap)
                     select new
                     {
                         t.SoTien
                     }).ToArray();

            if (k != null)
            {
                phucapkhac = (decimal)k.Sum(p => p.SoTien);
            }
        }
    }
    public void DemSoLaoDong(out int TongSo, out int SoNu)
    {
        TongSo = 0; SoNu = 0;
        TongSo = dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.DaNghi == false || p.DaNghi == null).Count();
        SoNu = dataContext.BHNHANVIEN_BAOHIEMs.Where(p => p.GioiTinh == false && (p.DaNghi == false || p.DaNghi == null)).Count();
    }
}