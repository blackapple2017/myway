using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KhenThuongController
/// </summary>
public class KhenThuongController : LinqProvider
{
    public KhenThuongController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void Update(DAL.HOSO_KHENTHUONG obj)
    {
        DAL.HOSO_KHENTHUONG item = dataContext.HOSO_KHENTHUONGs.Where(t => t.PR_KEY == obj.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            item.PrKeyHoSoTuCapNhat = -1; //Hủy việc dùng chung bản ghi
            Save();
            DAL.HOSO_KHENTHUONG newObject = new DAL.HOSO_KHENTHUONG()
            {
                FR_KEY = -1,
                GHI_CHU = obj.GHI_CHU,
                MA_HT_KTHUONG = obj.MA_HT_KTHUONG,
                LYDO_KTHUONG = obj.LYDO_KTHUONG,
                NGAY_QD = obj.NGAY_QD,
                PrkeyNguoiQuyetDinh = obj.PrkeyNguoiQuyetDinh,
                SO_QD = obj.SO_QD,
                SO_TIEN = obj.SO_TIEN,
                TepTinDinhKem = obj.TepTinDinhKem,
                PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat, 
            };
            dataContext.HOSO_KHENTHUONGs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.FR_KEY = -1;
            item.GHI_CHU = obj.GHI_CHU;
            item.MA_HT_KTHUONG = obj.MA_HT_KTHUONG;
            item.LYDO_KTHUONG = obj.LYDO_KTHUONG;
            item.NGAY_QD = obj.NGAY_QD;
            item.PrkeyNguoiQuyetDinh = obj.PrkeyNguoiQuyetDinh;
            item.SO_QD = obj.SO_QD;
            item.SO_TIEN = obj.SO_TIEN;
            item.TepTinDinhKem = obj.TepTinDinhKem;
            item.PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat; 
            Save();
        }
    }

    /// <summary>
    /// Hàm xóa dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="prKey"></param>
    public void Delete(decimal prKey)
    {
        DAL.HOSO_KHENTHUONG obj = dataContext.HOSO_KHENTHUONGs.Where(t => t.PR_KEY == prKey).FirstOrDefault();
        if (obj.FR_KEY <= 0)
        {
            dataContext.HOSO_KHENTHUONGs.DeleteOnSubmit(obj);
            Save();
        }
        else
        {
            obj.PrKeyHoSoTuCapNhat = -1; //đánh dấu bản ghi này ko còn thuộc về HOSO_TUCAPNHAT
            Save();
        }
    }
}