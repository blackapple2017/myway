
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Bùi Xuân Đại
/// </summary>
namespace Controller.DanhGia
{
    public class TieuChiDanhGiaController : LinqProvider
    {
        public DataTable GetByPrkey(string pr_key)
        {
            return DataController.DataHandler.GetInstance().ExecuteDataTable("GetTieuChiDanhGiaByPrkey", "@MaNhom", pr_key);
        }

        public void DeleteByPrkey(string pr_key)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("DeleteTieuChiDanhGiaByPrkey", "@MaNhom", pr_key);
        }

        public void DeleteByParentID(string parentID)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("delete estimate.TieuChiDanhGia where ParentID = '" + parentID + "'");
        }

        public DataTable GetByAll(string MaDonVi, string ParentTCID, string bienDoi)
        {
            string sqlSelect = @"select 
                                tc.MaNhom,
                                tc.TenNhom,
                                tc.HeSo,
                                tc.GhiChu,
                                tc.CreatedDate,
                                tc.CreatedBy,
                                tc.MaDonVi,
                                tc.ParentID,
                                (select TenNhom from estimate.TieuChiDanhGia where MaNhom = tc.ParentID) as TenNhomCha
                            from estimate.TieuChiDanhGia as tc
                            where (LEN('" + MaDonVi + "') = 0 or tc.MaDonVi = '" + MaDonVi + "') and (tc.ParentID in (" + bienDoi + ") or LEN('" + ParentTCID + @"') = 0) and ParentID != '-1'";
            return DataController.DataHandler.GetInstance().ExecuteDataTable("SELECTTieuChiDanhGia", "@SQLSTR", sqlSelect);
        }

        public DataTable GetAllRecord(int start, int limit, string searchKey, string MaDonVi, string ParentTCID, string bienDoi, out int count)
        {
            string sqlCount = string.Format("select count(MaNhom) from estimate.TieuChiDanhGia where (TenNhom like N'%{0}%' or LEN('{1}') = 0) and (LEN('{5}') = 0 or MaDonVi = '{2}') and (ParentID in ({3}) or LEN('{4}') = 0) and ParentID != '-1'", searchKey, searchKey, MaDonVi, bienDoi, ParentTCID, MaDonVi);
            //string sqlCount = "select count(MaNhom) from TieuChiDanhGia where (TenNhom like N'%'+" + searchKey + "+'%' or LEN(" + searchKey + ") = 0) and MaDonVi = " + MaDonVi;
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("CountTieuChiDanhGia", "@SQLSTR", sqlCount).ToString());

            string sqlSelect = "select * from( select tc.MaNhom, tc.TenNhom, tc.HeSo, tc.GhiChu, tc.CreatedDate, tc.CreatedBy, tc.MaDonVi, tc.ParentID, (select TenNhom from estimate.TieuChiDanhGia where MaNhom = tc.ParentID) as TenNhomCha, ROW_NUMBER() OVER( ORDER BY tc.ParentID ASC) SK from estimate.TieuChiDanhGia as tc where (tc.TenNhom like N'%" + searchKey + "%' or LEN('" + searchKey + "') = 0) and (LEN ('" + MaDonVi + "') = 0 or tc.MaDonVi = '" + MaDonVi + "') and (tc.ParentID in (" + bienDoi + ") or LEN('" + ParentTCID + "') = 0) and ParentID != '-1')a where (SK > " + start + " and SK <= " + (start + limit) + " )";
            return DataController.DataHandler.GetInstance().ExecuteDataTable("SelectTieuChiDanhGia", "@SQLSTR", sqlSelect);
        }
        //public List<DAL.TieuChiDanhGia> GetAllRecord(int start, int limit, string searchKey, string MaDonVi, string ParentTCID, out int count)
        //{
        //    string[] ds = null;
        //    if (ParentTCID != "")
        //        ds = ParentTCID.Split(',');
        //    count = int.Parse((from t in dataContext.TieuChiDanhGias
        //            where t.MaDonVi == MaDonVi && (ds == null || ds.Contains(t.ParentID)) && System.Data.Linq.SqlClient.SqlMethods.Like(t.TenNhom, searchKey)
        //            select t).FirstOrDefault().ToString());
        //    var rs = (from t in dataContext.TieuChiDanhGias
        //              where t.MaDonVi == MaDonVi && (ds == null || ds.Contains(t.ParentID)) && System.Data.Linq.SqlClient.SqlMethods.Like(t.TenNhom, searchKey)
        //              select t).Take(start).Skip(limit);
        //    return rs.ToList();
        //}

        public DataTable GetByParentID(string parentID, string maDV)
        {
            string sql = string.Format("select * from estimate.TieuChiDanhGia where (LEN('{2}') = 0 or MaDonVi = '{0}') and ParentID = '{1}'", maDV, parentID, maDV);
            return DataController.DataHandler.GetInstance().ExecuteDataTable(sql);
        }

        public string Insert(TieuChiDanhGiaInfo record)
        {
            return DataController.DataHandler.GetInstance().ExecuteScalar("InsertTieuChiDanhGia", "@MaNhom", "@TenNhom", "@HeSo", "@GhiChu", "@CreatedDate", "@CreatedBy", "@MaDonVi", "@ParentID", record.MaNhom, record.TenNhom, record.HeSo, record.GhiChu, record.CreatedDate, record.CreatedBy, record.MaDonVi, record.ParentID).ToString();
        }

        public void Insert(DAL.TieuChiDanhGia danhGia)
        {
            if (danhGia != null)
            {
                dataContext.TieuChiDanhGias.InsertOnSubmit(danhGia);
                Save();
            }
        }

        public void Update(DAL.TieuChiDanhGia danhGia)
        {
            DAL.TieuChiDanhGia temp = dataContext.TieuChiDanhGias.SingleOrDefault(t => t.MaNhom == danhGia.MaNhom);
            if (temp != null)
            {
                temp.GhiChu = danhGia.GhiChu;
                temp.HeSo = danhGia.HeSo;
                temp.MaNhom = danhGia.MaNhom;
                temp.ParentID = danhGia.ParentID;
                temp.TenNhom = danhGia.TenNhom;
                Save();
            }
        }

        public DAL.TieuChiDanhGia GetById(string maTieuChi)
        {
            return dataContext.TieuChiDanhGias.SingleOrDefault(t => t.MaNhom == maTieuChi);
        }

        public void Update(TieuChiDanhGiaInfo record)
        {
            DataController.DataHandler.GetInstance().ExecuteNonQuery("UpdateTieuChiDanhGia", "@MaNhom", "@TenNhom", "@HeSo", "@GhiChu", "@CreatedDate", "@CreatedBy", "@MaDonVi", "@ParentID", record.MaNhom, record.TenNhom, record.HeSo, record.GhiChu, record.CreatedDate, record.CreatedBy, record.MaDonVi, record.ParentID);
        }
    }
}