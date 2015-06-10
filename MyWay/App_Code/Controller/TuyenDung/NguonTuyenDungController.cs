using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NGUON_TUYENDUNGController
/// </summary>
public class NguonTuyenDungController : LinqProvider
{
    public NguonTuyenDungController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<DAL.KenhTuyenDung> GetByAll()
    {
        var rs = from t in dataContext.KenhTuyenDungs
                 select t;
        return rs.ToList();
    }
    public void Insert(DAL.KenhTuyenDung a)
    {
        dataContext.KenhTuyenDungs.InsertOnSubmit(a);
        Save();

    }

    public DAL.KenhTuyenDung GetByID(int id)
    {
        return dataContext.KenhTuyenDungs.Where(t => t.ID == id).FirstOrDefault();
    }

    public void Update(DAL.KenhTuyenDung nguuonTuyenDung)
    {
        DAL.KenhTuyenDung n = GetByID(nguuonTuyenDung.ID);
        n.ID = nguuonTuyenDung.ID;
        n.Name = nguuonTuyenDung.Name;
        n.LinkUrl = nguuonTuyenDung.LinkUrl;
        n.Description = nguuonTuyenDung.Description;
        Save();
    }
}