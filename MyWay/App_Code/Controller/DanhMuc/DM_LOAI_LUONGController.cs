using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DM_LOAI_LUONGController
/// </summary>
public class DM_LOAI_LUONGController : LinqProvider
{
    public DM_LOAI_LUONGController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<DM_LOAILUONGInfo> GetAll()
    {
        var rs = from t in dataContext.DM_LOAI_LUONGs
                 select new DM_LOAILUONGInfo
                 {
                     MA_LOAI_LUONG = t.MA_LOAI_LUONG,
                     TEN_LOAI_LUONG = t.TEN_LOAI_LUONG
                 };
        return rs.ToList();
    }
}