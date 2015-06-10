using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NhanXetController
/// </summary>
public class NhanXetController : LinqProvider
{
	public NhanXetController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DAL.NhanXet GetByMaDotVaMaCB(string maDotDG, string maCanBo)
    {
        return dataContext.NhanXets.SingleOrDefault(t => t.MaDotDG == maDotDG && t.MaCB == maCanBo);
    }

    public void Update(DAL.NhanXet nxet)
    {
        DAL.NhanXet temp = dataContext.NhanXets.SingleOrDefault(t => t.MaCB == nxet.MaCB && t.MaDotDG == nxet.MaDotDG);
        if (temp != null)
        {
            // cập nhật nhận xét
            temp.MaCB = nxet.MaCB;
            temp.MaDotDG = nxet.MaDotDG;
            temp.TuNhanXet = nxet.TuNhanXet;
            temp.BanLQNhanXet = nxet.BanLQNhanXet;
            temp.QuanLyNhanXet = nxet.QuanLyNhanXet;
            temp.DeXuat = nxet.DeXuat;
            temp.NhanXet1 = nxet.NhanXet1;
            temp.NhanXet2 = nxet.NhanXet2;
            Save();
        }
        else
        {
            // thêm mới nhận xét
            if (nxet != null)
            {
                dataContext.NhanXets.InsertOnSubmit(nxet);
                Save();
            }
        }
    }

    public void DeleteByMaDotDG(string maDotDG)
    {
        List<DAL.NhanXet> lists = dataContext.NhanXets.Where(t => t.MaDotDG == maDotDG).ToList();
        if (lists.Count() > 0)
        {
            dataContext.NhanXets.DeleteAllOnSubmit(lists);
            Save();
        }
    }
}