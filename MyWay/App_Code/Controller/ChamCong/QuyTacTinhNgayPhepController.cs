using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuyTacTinhNgayPhepController
/// </summary>
public class QuyTacTinhNgayPhepController : LinqProvider
{
    public QuyTacTinhNgayPhepController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public IEnumerable<QuyTacTinhNgayPhepInfo> GetAll(string maDonVi)
    {
        var rs = from t in dataContext.QuyTacTinhNgayPheps
                 select new QuyTacTinhNgayPhepInfo
                 {
                     HinhThucLamViec = t.ThamSoTrangThai.Value,
                     ID = t.ID,
                     IsInUsed = t.IsInUsed,
                     ThamNienDen = t.ThamNienDen,
                     ThamNienTu = t.ThamNienTu,
                     SoNgayPhepDuocHuong = t.SoNgayPhepDuocHuong,
                     TinhTheoNam = t.TinhTheoNam
                 };
        return rs;
    }

    public void Add(DAL.QuyTacTinhNgayPhep obj)
    {
        dataContext.QuyTacTinhNgayPheps.InsertOnSubmit(obj);
        Save();
    }

    public DAL.QuyTacTinhNgayPhep GetByID(int ID)
    {
        return dataContext.QuyTacTinhNgayPheps.Where(t => t.ID == ID).FirstOrDefault();
    }

    public void Delete(int ID)
    {
        DAL.QuyTacTinhNgayPhep item = GetByID(ID);
        if (item!=null)
        {
            dataContext.QuyTacTinhNgayPheps.DeleteOnSubmit(item);
            Save();
        }
    }

    public void Update(DAL.QuyTacTinhNgayPhep obj)
    {
        DAL.QuyTacTinhNgayPhep existing = GetByID(obj.ID);
        existing.CreatedBy = obj.CreatedBy;
        existing.CreatedDate = obj.CreatedDate;
        existing.IsInUsed = obj.IsInUsed;
        existing.MaHinhThucLamViec = obj.MaHinhThucLamViec;
        existing.SoNgayPhepDuocHuong = obj.SoNgayPhepDuocHuong;
        existing.ThamNienDen = obj.ThamNienDen;
        existing.ThamNienTu = obj.ThamNienTu;
        existing.TinhTheoNam = obj.TinhTheoNam;
        Save();
    }
}