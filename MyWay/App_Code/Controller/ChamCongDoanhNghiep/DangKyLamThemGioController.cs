using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DangKyLamThemGioController
/// </summary>
namespace Controller.ChamCongDoanhNghiep
{
    public class DangKyLamThemGioController : LinqProvider
    {
        public DangKyLamThemGioController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DAL.DangKyLamThemGio GetById(int id)
        {
            var rs = from t in dataContext.DangKyLamThemGios
                     where t.ID == id
                     select t;
            return rs.FirstOrDefault();
        }

        public List<DAL.DangKyLamThemGio> GetByMaCanBoAndFrkeyCa(string maCB, int frkeyCa)
        {
            var rs = from t in dataContext.DangKyLamThemGios
                     where t.MaCB == maCB && t.FrkeyMaCa == frkeyCa
                     select t;
            return rs.OrderByDescending(t => t.CreatedDate).ToList();
        }

        public void Insert(DAL.DangKyLamThemGio dky)
        {
            if (dky != null)
            {
                dataContext.DangKyLamThemGios.InsertOnSubmit(dky);
                Save();
            }
        }

        public void Update(DAL.DangKyLamThemGio dky)
        {
            DAL.DangKyLamThemGio tmp = dataContext.DangKyLamThemGios.SingleOrDefault(t => t.ID == dky.ID);
            if (tmp != null)
            {
                tmp.MaCB = dky.MaCB;
                tmp.TuNgay = dky.TuNgay;
                tmp.DenNgay = dky.DenNgay;
                tmp.FrkeyMaCa = dky.FrkeyMaCa;
                tmp.GhiChu = dky.GhiChu;
                tmp.GioKetThucSauCa = dky.GioKetThucSauCa;
                tmp.GioBatDauSauCa = dky.GioBatDauSauCa;

                Save();
            }
        }

        public void Delete(int id)
        {
            DAL.DangKyLamThemGio tmp = dataContext.DangKyLamThemGios.SingleOrDefault(t => t.ID == id);
            if (tmp != null)
            {
                dataContext.DangKyLamThemGios.DeleteOnSubmit(tmp);
                Save();
            }
        }

        public void DeleteByPrkeyCa(int prkeyCa)
        {
            var tmp = dataContext.DangKyLamThemGios.Where(t => t.FrkeyMaCa == prkeyCa).ToList();
            if (tmp.Count > 0)
            {
                dataContext.DangKyLamThemGios.DeleteAllOnSubmit(tmp);
                Save();
            }
        }
    }
}