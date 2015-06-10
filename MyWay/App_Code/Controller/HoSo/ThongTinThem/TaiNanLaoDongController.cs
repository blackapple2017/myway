using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TaiNanLaoDongController
/// </summary>
public class TaiNanLaoDongController : LinqProvider
{
    public TaiNanLaoDongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DAL.HOSO_TAINANLAODONG GetByID(int Id)
    {
        return dataContext.HOSO_TAINANLAODONGs.Where(t => t.ID == Id).FirstOrDefault();
    }

    /// <summary>
    /// Hàm xóa dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="ID"></param>
    public void Delete(int ID)
    {
        DAL.HOSO_TAINANLAODONG oldObject = GetByID(ID);
        if (oldObject.FR_KEY <= 0)
        {
            dataContext.HOSO_TAINANLAODONGs.DeleteOnSubmit(oldObject);
            Save();
        }
        else
        {
            oldObject.PrKeyHoSoTuCapNhat = -1;
            Save();
        }
    }
    /// <summary>
    /// Hàm update dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="item"></param>
    public void Update(DAL.HOSO_TAINANLAODONG item)
    {
        DAL.HOSO_TAINANLAODONG oldObject = dataContext.HOSO_TAINANLAODONGs.Where(t => t.ID == item.ID).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            //hủy việc dùng chung bản ghi
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            item.PrKeyHoSoTuCapNhat = -1;
            Save();
            //tạo ra 1 bản ghi mới
            DAL.HOSO_TAINANLAODONG newObject = new DAL.HOSO_TAINANLAODONG()
            {
                PrKeyHoSoTuCapNhat = item.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                BOI_THUONG = item.BOI_THUONG,
                LY_DO = item.LY_DO,
                NGAY_XAY_RA = item.NGAY_XAY_RA,
                NgayBoiThuong = item.NgayBoiThuong,
                THIET_HAI = item.THIET_HAI,
                THUONG_TAT = item.THUONG_TAT,
                GHI_CHU = item.GHI_CHU,
                DIA_DIEM = item.DIA_DIEM,
                CreatedDate = item.CreatedDate,
                CreatedBy = item.CreatedBy,
            };
            dataContext.HOSO_TAINANLAODONGs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            oldObject.PrKeyHoSoTuCapNhat = item.PrKeyHoSoTuCapNhat;
            oldObject.FR_KEY = -1;
            oldObject.BOI_THUONG = item.BOI_THUONG;
            oldObject.LY_DO = item.LY_DO;
            oldObject.NGAY_XAY_RA = item.NGAY_XAY_RA;
            oldObject.NgayBoiThuong = item.NgayBoiThuong;
            oldObject.THIET_HAI = item.THIET_HAI;
            oldObject.THUONG_TAT = item.THUONG_TAT;
            oldObject.GHI_CHU = item.GHI_CHU;
            oldObject.DIA_DIEM = item.DIA_DIEM;
            oldObject.CreatedDate = item.CreatedDate;
            oldObject.CreatedBy = item.CreatedBy;
            Save();
        }
    }
}