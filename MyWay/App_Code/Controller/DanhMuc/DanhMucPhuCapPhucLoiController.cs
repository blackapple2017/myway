using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DanhMucPhuCapPhucLoiController
/// </summary>
public class DanhMucPhuCapPhucLoiController : LinqProvider
{
    public DanhMucPhuCapPhucLoiController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public enum KieuLoai
    {
        Phucap, Phucloi
    }
    /// <summary>
    /// Lấy danh sách phụ cấp hoặc phúc lợi
    /// </summary>
    /// <param name="kieuLoai"></param>
    /// <returns></returns>
    public IEnumerable<DAL.DanhMucPhuCapPhucLoi> GetAll(KieuLoai kieuLoai)
    {
        if (kieuLoai == KieuLoai.Phucap)
        {
            return dataContext.DanhMucPhuCapPhucLois.Where(t => t.IsPhuCap == true);
        }
        return dataContext.DanhMucPhuCapPhucLois.Where(t => t.IsPhuCap == false);
    }
    public List<DanhMucPhuCapPhucLoiInfo> GetAllDonVi(string madonvi, out int count)
    {
        var rs = (from t in dataContext.DanhMucPhuCapPhucLois
                  join x in dataContext.ThamSoTrangThais on t.NhomLoaiPhuCapPhucLoi equals x.Value into tx
                  from tq in tx.DefaultIfEmpty()
                  where t.MaDonVi == madonvi
                  orderby t.IsPhuCap descending, t.NhomLoaiPhuCapPhucLoi, t.Ten
                  select new DanhMucPhuCapPhucLoiInfo
                  {
                      ID = t.ID,
                      HeSo = t.HeSo,
                      NhomLoaiPhuCap = tq == null ? (t.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapChucVu" ? "(BH) Phụ cấp chức vụ" : 
                                                    t.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapThamNienVuotKhung" ? "(BH) Phụ cấp thâm niêm vượt khung" : 
                                                    t.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapThamNienNghe" ? "(BH) Phụ cấp thâm niêm nghề" : 
                                                    t.NhomLoaiPhuCapPhucLoi == "(BH)PhuCapKhac" ? "(BH) Phụ cấp khác" : "") : tq.Description,
                      IsPhuCap = t.IsPhuCap,
                      SoTien = t.SoTien,
                      Ten = t.Ten,
                      TinhVaoBH = t.TinhVaoBH,
                      PhanTram = t.PhanTram
                  }).ToList();

        dataContext.DanhMucPhuCapPhucLois.Where(t => t.MaDonVi == madonvi).ToList();
        count = rs.Count;
        return rs;
    }
    public DAL.HOSO_PHUCAP GetByID(int id)
    {
        return dataContext.HOSO_PHUCAPs.Where(t => t.ID == id).FirstOrDefault();
    }

    public void Delete(int p)
    {
        var tmp = dataContext.DanhMucPhuCapPhucLois.SingleOrDefault(t => t.ID == p);
        if (tmp != null)
        {
            dataContext.DanhMucPhuCapPhucLois.DeleteOnSubmit(tmp);
            Save();
        }
    }
    public void Insert(DAL.DanhMucPhuCapPhucLoi pcpl)
    {
        dataContext.DanhMucPhuCapPhucLois.InsertOnSubmit(pcpl);
        Save();
    }
    public DAL.DanhMucPhuCapPhucLoi Lay1BanGhi(int id)
    {
        return dataContext.DanhMucPhuCapPhucLois.Where(p => p.ID == id).SingleOrDefault();
    }
    public void Update(DAL.DanhMucPhuCapPhucLoi item)
    {
        var pcpl = dataContext.DanhMucPhuCapPhucLois.Where(p => p.ID == item.ID).SingleOrDefault();
        pcpl.Ten = item.Ten;
        pcpl.SoTien = item.SoTien;
        pcpl.HeSo = item.HeSo;
        pcpl.NhomLoaiPhuCapPhucLoi = item.NhomLoaiPhuCapPhucLoi;
        pcpl.IsPhuCap = item.IsPhuCap;
        pcpl.PhanTram = item.PhanTram;
        pcpl.TinhVaoBH = item.TinhVaoBH;
        Save();
    }
    public List<StoreComboObject> GetStoreNhomLoai()
    {
        var result = (from t in dataContext.ThamSoTrangThais
                      where t.ParamName == "PhuCapPhucLoi"
                      select new StoreComboObject
                      {
                          MA = t.Value,
                          TEN = t.Description
                      }).ToList();
        return result;
    }
}