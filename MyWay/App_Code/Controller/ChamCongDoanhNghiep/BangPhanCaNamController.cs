using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BangPhanCaNamController
/// </summary>
public class BangPhanCaNamController : LinqProvider
{
    public BangPhanCaNamController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Đưa danh sách cán bộ vào bảng phân ca năm
    /// @Lê Văn Anh
    /// </summary>
    /// <param name="phanCa"></param>
    /// <param name="maCa">Mã ca cần thiết lập cho nhân viên, nếu maCa không có giá trị gì thì mặc định là chưa thiết lập ca cho nhân viên</param>
    public string AddEmployee(int idBangPhanCa, string maDonVi, string maCa, int nam)
    {
        Dictionary<string, string> dr = new DM_DONVIController().TraVeTuDienDonVi();
        string loi = "";//Trả về lỗi: có bao nhiêu người thuộc những phòng ban nào bị trùng
        foreach (var item in maDonVi.Split(','))
        {
            if (!string.IsNullOrEmpty(item))
            {
                List<string> maCBList = new HoSoController().GetMaCBByMaDonVi(item, false);
                int dem = 0;
                foreach (var maCB in maCBList)
                {
                    //kiểm tra trong năm nay cán bộ này đã có trong bảng phân ca khác
                    //của cùng năm hay chưa
                    bool datontai = false;
                    var checkcanbo = (from t in dataContext.BangPhanCaNams
                                      join q in dataContext.DanhSachBangPhanCas on t.IdDanhSachBangPhanCa equals q.ID
                                      where (q.Nam == nam) && q.Thang == -1 && t.MaCB == maCB
                                      select t.MaCB).ToList();
                    //tăng số người đã bị trùng lên 1
                    if (checkcanbo.Count > 0)
                    {
                        datontai = true;
                        dem++;
                    }
                    if (datontai == false)
                    {
                        DAL.BangPhanCaNam phanCaNam = new DAL.BangPhanCaNam()
                            {
                                MaCB = maCB,
                                IdDanhSachBangPhanCa = idBangPhanCa,
                            };
                        if (!string.IsNullOrEmpty(maCa))
                        {
                            phanCaNam.Thang1 = maCa;
                            phanCaNam.Thang2 = maCa;
                            phanCaNam.Thang3 = maCa;
                            phanCaNam.Thang4 = maCa;
                            phanCaNam.Thang5 = maCa;
                            phanCaNam.Thang6 = maCa;
                            phanCaNam.Thang7 = maCa;
                            phanCaNam.Thang8 = maCa;
                            phanCaNam.Thang9 = maCa;
                            phanCaNam.Thang10 = maCa;
                            phanCaNam.Thang11 = maCa;
                            phanCaNam.Thang12 = maCa;
                        }
                        dataContext.BangPhanCaNams.InsertOnSubmit(phanCaNam);
                        Save();
                    }
                }
                if (dem > 0)
                {
                    loi = loi + @"Phòng " + dr[item] + @" đã có " + dem.ToString() + @" cán bộ phân ca ở bảng phân ca khác.<br/>
                                  ";
                }
            }
        }
        return loi;
    }

    /// <summary>
    /// Lấy tổng số bản ghi của bảng phân ca năm. Phục vụ cho phân ca tự động
    /// </summary>
    /// <param name="idBangPhanCa"></param>
    /// <returns></returns>
    public int GetCount(int idBangPhanCa)
    {
        return dataContext.BangPhanCaNams.Where(t => t.IdDanhSachBangPhanCa == idBangPhanCa).Select(t => t.ID).Count();
    }

    public void Add(DAL.BangPhanCaNam item)
    {
        int nam = dataContext.DanhSachBangPhanCas.Where(t => t.ID == item.IdDanhSachBangPhanCa).SingleOrDefault().Nam;

        var check = (from t in dataContext.BangPhanCaNams
                     join q in dataContext.DanhSachBangPhanCas on t.IdDanhSachBangPhanCa equals q.ID
                     where t.MaCB == item.MaCB && q.Nam == nam
                     select t).ToList();
        if (check.Count > 0) { throw new System.Exception("Đã có cán bộ trong bảng"); }
        else
        {
            dataContext.BangPhanCaNams.InsertOnSubmit(item);
            Save();
        }
    }

    /// <summary>
    /// Lấy bảng phân ca năm theo ID danh sách bảng phân ca
    /// </summary>
    /// <param name="start"></param>
    /// <param name="limit"></param>
    /// <param name="count"></param>
    /// <param name="searchKey"></param>
    /// <param name="maBangPhanCa"></param>
    /// <param name="maDonVi">phục vụ cho mục đích filter</param>
    /// <returns></returns>
    public IEnumerable<BangPhanCaNamInfo> GetAll(int start, int limit, out int count, string searchKey, int maBangPhanCa, string maDonVi)
    {
        string str = string.Empty;
        if (!string.IsNullOrEmpty(maDonVi))
        {
            System.Collections.Generic.List<string> idList = new DM_DONVIController().getChildID(maDonVi, true);
            str = "%,";
            foreach (var item in idList)
            {
                str += item + ",";
            }
            str += "%";
        }

        var rs = from t in dataContext.BangPhanCaNams
                 join hs in dataContext.HOSOs
                 on t.MaCB equals hs.MA_CB
                 join dv in dataContext.DM_DONVIs
                 on hs.MA_DONVI equals dv.MA_DONVI
                 where t.IdDanhSachBangPhanCa == maBangPhanCa &&
                 (string.IsNullOrEmpty(maDonVi) || System.Data.Linq.SqlClient.SqlMethods.Like("%" + str + "%", "%," + hs.MA_DONVI + ",%")) &&
                 (string.IsNullOrEmpty(searchKey) || System.Data.Linq.SqlClient.SqlMethods.Like(hs.HO_TEN, searchKey) ||
                 System.Data.Linq.SqlClient.SqlMethods.Like(t.MaCB, searchKey))
                 select new BangPhanCaNamInfo
                 {
                     HoTen = hs.HO_TEN,
                     MaCB = t.MaCB,
                     BoPhan = dv.TEN_DONVI,
                     Thang1 = t.Thang1,
                     Thang2 = t.Thang2,
                     Thang3 = t.Thang3,
                     Thang4 = t.Thang4,
                     Thang5 = t.Thang5,
                     Thang6 = t.Thang6,
                     Thang7 = t.Thang7,
                     Thang8 = t.Thang8,
                     Thang9 = t.Thang9,
                     Thang10 = t.Thang10,
                     Thang11 = t.Thang11,
                     Thang12 = t.Thang12,
                     ID = t.ID
                 };
        count = rs.Count();
        return rs.Skip(start).Take(limit);
    }

    public DAL.BangPhanCaNam GetByID(int id)
    {
        return dataContext.BangPhanCaNams.Where(t => t.ID == id).FirstOrDefault();
    }

    public void Delete(int id)
    {
        DAL.BangPhanCaNam record = GetByID(id);
        if (record != null)
        {
            dataContext.BangPhanCaNams.DeleteOnSubmit(record);
            Save();
        }
    }
}