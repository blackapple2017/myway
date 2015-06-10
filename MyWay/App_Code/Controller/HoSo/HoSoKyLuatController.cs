using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for HoSoKyLuatController
/// </summary>
public class HoSoKyLuatController : LinqProvider
{
    public HoSoKyLuatController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void InsertKyluat(HOSO_KYLUAT kyluat)
    {
        dataContext.HOSO_KYLUATs.InsertOnSubmit(kyluat);
        Save();
    }

    public DAL.HOSO_KYLUAT GetKyLuat(decimal Pr_key)
    {
        return dataContext.HOSO_KYLUATs.Where(t => t.PR_KEY == Pr_key).FirstOrDefault();
    }

    public void UpdateKyLuat(DAL.HOSO_KYLUAT hskl)
    {
        DAL.HOSO_KYLUAT kyluat = GetKyLuat(hskl.PR_KEY);
        if (kyluat != null)
        {
            kyluat.GHI_CHU = hskl.GHI_CHU;
            kyluat.MA_HT_KYLUAT = hskl.MA_HT_KYLUAT;
            kyluat.LYDO_KYLUAT = hskl.LYDO_KYLUAT;
            kyluat.NGAY_QD = hskl.NGAY_QD;
            kyluat.SO_QD = hskl.SO_QD;
            kyluat.SO_TIEN = hskl.SO_TIEN;
            kyluat.PrkeyNguoiQuyetDinh = hskl.PrkeyNguoiQuyetDinh;
            kyluat.TepTinDinhKem = hskl.TepTinDinhKem;
            kyluat.SoDiem = hskl.SoDiem;
            Save();
        }
    }

    /// <summary>
    /// Hàm update dành cho form tự cập nhật
    /// </summary>
    /// <param name="prKey"></param>
    public void Update(DAL.HOSO_KYLUAT obj)
    {
        DAL.HOSO_KYLUAT item = dataContext.HOSO_KYLUATs.Where(t => t.PR_KEY == obj.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_KYLUAT newObject = new DAL.HOSO_KYLUAT()
            {
                PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                Duyet = obj.Duyet,
                NGAY_QD = obj.NGAY_QD,
                LYDO_KYLUAT = obj.LYDO_KYLUAT,
                MA_HT_KYLUAT = obj.MA_HT_KYLUAT,
                GHI_CHU = obj.GHI_CHU,
                SO_TIEN = obj.SO_TIEN,
                PrkeyNguoiQuyetDinh = obj.PrkeyNguoiQuyetDinh,
                TepTinDinhKem = obj.TepTinDinhKem,
                SO_QD = obj.SO_QD,
            };
            dataContext.HOSO_KYLUATs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {  
            item.PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat;
            item.FR_KEY = -1;
            item.Duyet = obj.Duyet;
            item.NGAY_QD = obj.NGAY_QD;
            item.LYDO_KYLUAT = obj.LYDO_KYLUAT;
            item.MA_HT_KYLUAT = obj.MA_HT_KYLUAT;
            item.GHI_CHU = obj.GHI_CHU;
            item.SO_TIEN = obj.SO_TIEN;
            item.PrkeyNguoiQuyetDinh = obj.PrkeyNguoiQuyetDinh;
            item.TepTinDinhKem = obj.TepTinDinhKem;
            item.SO_QD = obj.SO_QD;
            Save();
        }
    }
}