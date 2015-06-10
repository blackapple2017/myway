using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BangPhanCaThangController
/// </summary>
public class BangPhanCaThangController : LinqProvider
{
    public BangPhanCaThangController()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void TaoBangPhanCaThang(int idBangPhanCa, int createdBy, int month, int year, string maDonVi, int idBangPhanCaCopy)
    {
        DateTime thangtruoc = new DateTime(year, month - 1, 1);
        foreach (var item in maDonVi.Split(','))
        {
            if (!string.IsNullOrEmpty(item))
            {
                List<string> maCBList = new HoSoController().GetMaCBByMaDonVi(item, false);
                foreach (var maCB in maCBList)
                {
                    DAL.BangPhanCaThang phanCaThang = new DAL.BangPhanCaThang()
                    {
                        MaCB = maCB,
                        MaDanhSachBangPhanCa = idBangPhanCa,
                        CreatedDate = DateTime.Now,
                        CreatedBy = createdBy,
                    };
                    if (idBangPhanCaCopy > 0)
                    {
                        //lấy thông tin phân ca của thằng đó của tháng trước
                        DAL.BangPhanCaThang phanCaThangTruoc = (from t in dataContext.BangPhanCaThangs
                                                                join q in dataContext.DanhSachBangPhanCas on t.MaDanhSachBangPhanCa equals q.ID
                                                                where q.Thang == thangtruoc.Month && q.Nam == thangtruoc.Year && t.MaCB == maCB
                                                                select t).SingleOrDefault();
                        if (phanCaThangTruoc != null)
                        {
                            phanCaThang.Ngay01 = phanCaThangTruoc.Ngay01;
                            phanCaThang.Ngay02 = phanCaThangTruoc.Ngay02;
                            phanCaThang.Ngay03 = phanCaThangTruoc.Ngay03;
                            phanCaThang.Ngay04 = phanCaThangTruoc.Ngay04;
                            phanCaThang.Ngay05 = phanCaThangTruoc.Ngay05;
                            phanCaThang.Ngay06 = phanCaThangTruoc.Ngay06;
                            phanCaThang.Ngay07 = phanCaThangTruoc.Ngay07;
                            phanCaThang.Ngay08 = phanCaThangTruoc.Ngay08;
                            phanCaThang.Ngay09 = phanCaThangTruoc.Ngay09;
                            phanCaThang.Ngay10 = phanCaThangTruoc.Ngay10;
                            phanCaThang.Ngay11 = phanCaThangTruoc.Ngay11;
                            phanCaThang.Ngay12 = phanCaThangTruoc.Ngay12;
                            phanCaThang.ngay13 = phanCaThangTruoc.ngay13;
                            phanCaThang.ngay14 = phanCaThangTruoc.ngay14;
                            phanCaThang.Ngay15 = phanCaThangTruoc.Ngay15;
                            phanCaThang.Ngay16 = phanCaThangTruoc.Ngay16;
                            phanCaThang.Ngay17 = phanCaThangTruoc.Ngay17;
                            phanCaThang.Ngay18 = phanCaThangTruoc.Ngay18;
                            phanCaThang.Ngay19 = phanCaThangTruoc.Ngay19;
                            phanCaThang.Ngay20 = phanCaThangTruoc.Ngay20;
                            phanCaThang.Ngay21 = phanCaThangTruoc.Ngay21;
                            phanCaThang.Ngay22 = phanCaThangTruoc.Ngay22;
                            phanCaThang.Ngay23 = phanCaThangTruoc.Ngay23;
                            phanCaThang.Ngay24 = phanCaThangTruoc.Ngay24;
                            phanCaThang.Ngay25 = phanCaThangTruoc.Ngay25;
                            phanCaThang.Ngay26 = phanCaThangTruoc.Ngay26;
                            phanCaThang.Ngay27 = phanCaThangTruoc.Ngay27;
                            phanCaThang.Ngay28 = phanCaThangTruoc.Ngay28;
                            phanCaThang.Ngay29 = phanCaThangTruoc.Ngay29;
                            phanCaThang.Ngay30 = phanCaThangTruoc.Ngay30;
                            phanCaThang.Ngay31 = phanCaThangTruoc.Ngay31;
                        }
                    }
                    dataContext.BangPhanCaThangs.InsertOnSubmit(phanCaThang);
                    Save();
                }
            }
        }
    }
    public string AddEmployee(int idBangPhanCa, string maDonVi, string maCa, int thang, int nam)
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
    /// Thêm mới 1 bảng phân ca tháng
    /// </summary>
    /// <param name="item"></param>
    public void Add(DAL.BangPhanCaThang item)
    {
        dataContext.BangPhanCaThangs.InsertOnSubmit(item);
        Save();
    }

    public void DeleteEmployee(int ID)
    {
        DAL.BangPhanCaThang phanCaThang = dataContext.BangPhanCaThangs.Where(t => t.ID == ID).FirstOrDefault();
        if (phanCaThang!=null)
        {
            dataContext.BangPhanCaThangs.DeleteOnSubmit(phanCaThang);
            Save();
        }
    }
    public DataTable GetBangPhanCaThang(string madonvi, int IDBangPhanCa, int start, int limit, string searchkey, out int count, int userID, int menuID)
    {
        count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountBangPhanCaThang", "@MaDonVi", "@IDBangPhanCa", "@SearchKey", "@userID", "@menuID", madonvi, IDBangPhanCa, searchkey,userID,menuID).ToString());
        return DataController.DataHandler.GetInstance().ExecuteDataTable("GetBangPhanCaThang", "@MaDonVi", "@IDBangPhanCa", "@Start", "@Limit", "@SearchKey", "@userID", "@menuID", madonvi, IDBangPhanCa, start, limit, searchkey,userID, menuID);
    }

    public DAL.BangPhanCaThang GetByMaCB(string maCb, int thang, int nam)
    {
        return dataContext.BangPhanCaThangs.Where(p => p.MaCB == maCb && p.DanhSachBangPhanCa.Thang == thang && p.DanhSachBangPhanCa.Nam == nam).FirstOrDefault();
    }
    public void Update(int ID, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_UpdateBangPhanCaThang", "@ID", "@Field", "@Value",
                                                                  ID, field, value);
    }
    public void UpdateByPhongBan(string maDV,int idBangPhanCa, string field, string value)
    {
        DataController.DataHandler.GetInstance().ExecuteNonQuery("ChamCong_UpdateBangPhanCaThangTheoMaDV", "@Field", "@Value", "@Ma_DV", "@IdBangPhanCa",
                                                                  field, value, maDV, idBangPhanCa);
    }
}