using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KhaNangController
/// </summary>
public class KhaNangController : LinqProvider
{
    public KhaNangController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Update(DAL.HOSO_KHANANG obj)
    {
        DAL.HOSO_KHANANG item = dataContext.HOSO_KHANANGs.Where(t => t.PR_KEY == obj.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            item.PrKeyHoSoTuCapNhat = -1; //Hủy việc dùng chung bản ghi
            Save();
            DAL.HOSO_KHANANG newObject = new DAL.HOSO_KHANANG()
            {
                FR_KEY = -1,
                GHI_CHU = obj.GHI_CHU,
                MA_KHANANG = obj.MA_KHANANG,
                MA_XEPLOAI = obj.MA_XEPLOAI,
                PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat, 
            };
            dataContext.HOSO_KHANANGs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            //  item.Duyet = false;
            item.FR_KEY = -1;
            item.GHI_CHU = obj.GHI_CHU;
            item.MA_KHANANG = obj.MA_KHANANG;
            item.MA_XEPLOAI = obj.MA_XEPLOAI;
            item.PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat;
            Save();
        }
    }

    /// <summary>
    /// Hàm xóa quan hệ gia đình dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="prkey"></param>
    public void Delete(decimal prkey)
    {
        DAL.HOSO_KHANANG obj = dataContext.HOSO_KHANANGs.Where(t => t.PR_KEY == prkey).FirstOrDefault();
        if (obj.FR_KEY <= 0)
        {
            dataContext.HOSO_KHANANGs.DeleteOnSubmit(obj);
            Save();
        }
        else
        {
            obj.PrKeyHoSoTuCapNhat = -1; //đánh dấu bản ghi này ko còn thuộc về HOSO_TUCAPNHAT
            Save();
        }
    }
}