using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for XuLyTreeDonViController
/// </summary>
public class XuLyTreeDonViController : LinqProvider
{
    public XuLyTreeDonViController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string ChuanHoaChuoiTree(string mabophan, string strCanChuan)
    {
        List<string> a = new List<string>();
        a.Add(mabophan);
        List<DonViInfo> listFullDonVi = new List<DonViInfo>();
        new DM_DONVIController().LayCon(a, ref listFullDonVi, 1);

        List<string> listcanchuan = new List<string>(strCanChuan.Split(','));

        string result = "";

        // có sử dụng nhưng ít dùng
        //foreach(var item in listcanchuan)
        //{
        //    //lấy mã của tất cả những thằng cấp con có mã đơn vị là thằng cha
        //    List<string> tatcacon = listFullDonVi.Where(p => p.ParentID == item).Select(p=>p.MaDonVi).ToList();
        //    //biến check xem liệu các con của strCanChuan có chứa hết những thằng của full
        //    bool check=false;
        //    foreach (var x in tatcacon)
        //    {
        //        if (!strCanChuan.Contains(x)) check = true;
        //    }
        //    if (check == true||tatcacon.Count==0) result += item + ","; 
        //}
        foreach (var item in listcanchuan)
        {
            //nếu trong listcanchuan có thằng cha, thì ko lấy thằng con
            var parentitem = listFullDonVi.Where(p => p.MaDonVi == item).Select(p => p.ParentID).SingleOrDefault();
            if (parentitem != null)
            {
                if (!strCanChuan.Contains(parentitem)) result += item + ",";
            }
            else result += item + ",";
        }
        return result;
    }
    public string ChuyenTuMaDonViVeTenDonVi(string chuoicanchuyen)
    {
        string result = chuoicanchuyen;
        var donvi = (from t in dataContext.DM_DONVIs
                     orderby t.MA_DONVI.Length descending
                     select new
                     {
                         t.MA_DONVI,
                         t.TEN_DONVI
                     }).ToList();
        List<string> listcanchuyen = new List<string>(chuoicanchuyen.Split(','));
        foreach (var ds in donvi)
        {
            result = result.Replace(ds.MA_DONVI, ds.TEN_DONVI);
        }
        return result;
    }
}