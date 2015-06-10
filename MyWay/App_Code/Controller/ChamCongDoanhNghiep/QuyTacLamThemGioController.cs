using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// daibx   17/08/2013
/// Summary description for QuyTacLamThemGioController
/// </summary>
namespace Controller.ChamCongDoanhNghiep
{
    public class QuyTacLamThemGioController : LinqProvider
    {
        public QuyTacLamThemGioController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DAL.QuyTacLamThemGio GetByID(int ID)
        {
            var rs = from t in dataContext.QuyTacLamThemGios
                     where t.ID == ID
                     select t;
            return rs.FirstOrDefault();
        }

        public List<DAL.QuyTacLamThemGio> GetByFrMaCa(int prkeyDanhSachCa)
        {
            string maCa = dataContext.DanhSachCas.Where(c => c.ID == prkeyDanhSachCa).FirstOrDefault().MaCa;
            var rs = from t in dataContext.QuyTacLamThemGios
                     where t.MaCa == maCa
                     select t;
            return rs.ToList();
        }

        public List<QuyTacLamThemGioInfo> GetByFrkeyMaCa(int frMaMa)
        {
            string maCa = dataContext.DanhSachCas.Where(c => c.ID == frMaMa).FirstOrDefault().MaCa;
            var rs = from t in dataContext.QuyTacLamThemGios
                     //   join p in dataContext.DanhSachCas on t.FrMaCa equals p.ID into tmp1
                  //      from t1 in tmp1.DefaultIfEmpty()
                     where t.MaCa == maCa
                     orderby t.Order ascending
                     select new QuyTacLamThemGioInfo
                     {
                         DenGio = t.DenGio,
                         ID = t.ID,
                         LoaiNgay = t.LoaiNgay, 
                         NhanHeSo = t.NhanHeSo,
                         TuGio = t.TuGio, 
                         Order = t.Order
                     };
            return rs.ToList();
        }

        public int Insert(DAL.QuyTacLamThemGio qt)
        {
            if (qt != null)
            {
                dataContext.QuyTacLamThemGios.InsertOnSubmit(qt);
                Save();
                return qt.ID;
            }
            return -1;
        }

        public void Update(DAL.QuyTacLamThemGio qt)
        {
            DAL.QuyTacLamThemGio tmp = dataContext.QuyTacLamThemGios.Single(t => t.ID == qt.ID);
            if (tmp != null)
            {
                tmp.ID = qt.ID;
                tmp.MaCa = qt.MaCa;
                tmp.TuGio = qt.TuGio;
                tmp.DenGio = qt.DenGio;
                tmp.LoaiNgay = qt.LoaiNgay;
                tmp.CreatedDate = qt.CreatedDate;
                tmp.CreatedBy = qt.CreatedBy;
                tmp.NhanHeSo = qt.NhanHeSo;
                tmp.Order = qt.Order;
                Save();
            }
        }

        public void Delete(int id)
        {
            DAL.QuyTacLamThemGio qt = dataContext.QuyTacLamThemGios.Where(t => t.ID == id).FirstOrDefault();
            if (qt != null)
            {
                dataContext.QuyTacLamThemGios.DeleteOnSubmit(qt);
                Save();
            }
        }

        public void DeleteByFrkeyCa(int prkeyCa)
        {
            List<DAL.QuyTacLamThemGio> list = GetByFrMaCa(prkeyCa);
            if (list.Count > 0)
            {
                dataContext.QuyTacLamThemGios.DeleteAllOnSubmit(list);
                Save();
            }
        }
    }
}