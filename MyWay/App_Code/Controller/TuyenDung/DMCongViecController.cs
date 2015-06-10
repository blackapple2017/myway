using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DMCongViecController
/// </summary>
public class DMCongViecController : LinqProvider
{
    public bool Add(DAL.DM_CONGVIEC dmcv)
    {
        if (dataContext.DM_CONGVIECs.Any(dm => dm.MA_CONGVIEC.ToLower() == dmcv.MA_CONGVIEC.ToLower()))
            return false;
        else
        {
            try{dataContext.DM_CONGVIECs.InsertOnSubmit(dmcv);return true;}
            catch(Exception){return false;}
        }

    }
}