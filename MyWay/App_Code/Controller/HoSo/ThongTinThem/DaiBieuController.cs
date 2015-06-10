using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DaiBieuController
/// </summary>
public class DaiBieuController : LinqProvider
{
    public DaiBieuController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Delete(decimal prKey)
    {
        DAL.HOSO_DAIBIEU oldObj = dataContext.HOSO_DAIBIEUs.Where(t => t.PR_KEY == prKey).FirstOrDefault();
        if (oldObj.FR_KEY <= 0)
        {
            dataContext.HOSO_DAIBIEUs.DeleteOnSubmit(oldObj);
            Save();
        }
        else
        {
            oldObj.PrKeyHoSoTuCapNhat = -1;
            Save();
        }
    }
    /// <summary>
    /// Hàm update dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="update"></param>
    public void Update(DAL.HOSO_DAIBIEU update)
    {
        DAL.HOSO_DAIBIEU item = dataContext.HOSO_DAIBIEUs.Where(t => t.PR_KEY == update.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_DAIBIEU newObject = new DAL.HOSO_DAIBIEU()
            {
                PrKeyHoSoTuCapNhat = update.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                DEN_NGAY = update.DEN_NGAY,
                GHI_CHU = update.GHI_CHU,
                LOAI_HINH = update.LOAI_HINH,
                NHIEM_KY = update.NHIEM_KY,
                TU_NGAY = update.TU_NGAY
            };
            dataContext.HOSO_DAIBIEUs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHoSoTuCapNhat = update.PrKeyHoSoTuCapNhat;
            item.FR_KEY = -1;
            item.DEN_NGAY = update.DEN_NGAY;
            item.GHI_CHU = update.GHI_CHU;
            item.LOAI_HINH = update.LOAI_HINH;
            item.NHIEM_KY = update.NHIEM_KY;
            item.TU_NGAY = update.TU_NGAY;
            Save();
        }
    }
}