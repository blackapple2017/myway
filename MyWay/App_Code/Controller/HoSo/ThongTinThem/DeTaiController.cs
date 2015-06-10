using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeTaiController
/// </summary>
public class DeTaiController : LinqProvider
{
    public DeTaiController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Hàm update này dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="deTai"></param>
    public void Update(DAL.HOSO_DETAI deTai)
    {
        DAL.HOSO_DETAI item = dataContext.HOSO_DETAIs.Where(t => t.PR_KEY == deTai.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            item.PrKeyHoSoTuCapNhat = -1; //hủy việc dùng chung bản ghi
            Save();
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            DAL.HOSO_DETAI newObject = new DAL.HOSO_DETAI()
            {
                PrKeyHoSoTuCapNhat = deTai.PrKeyHoSoTuCapNhat,
                FR_KEY = -1,
                CAP_DETAI = deTai.CAP_DETAI,
                CHUNHIEM_DETAI = deTai.CHUNHIEM_DETAI,
                DEN_NGAY = deTai.DEN_NGAY,
                Duyet = deTai.Duyet,
                GHI_CHU = deTai.GHI_CHU,
                KET_QUA = deTai.KET_QUA,
                MaDeTai = deTai.MaDeTai,
                TEN_DETAI = deTai.TEN_DETAI,
                TepTinDinhKem = deTai.TepTinDinhKem,
                TU_NGAY = deTai.TU_NGAY,
                TUCACH_THAMGIA = deTai.TUCACH_THAMGIA
            };
            dataContext.HOSO_DETAIs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.PrKeyHoSoTuCapNhat = deTai.PrKeyHoSoTuCapNhat;
            item.FR_KEY = -1;
            item.CAP_DETAI = deTai.CAP_DETAI;
            item.CHUNHIEM_DETAI = deTai.CHUNHIEM_DETAI;
            item.DEN_NGAY = deTai.DEN_NGAY;
            item.Duyet = deTai.Duyet;
            item.GHI_CHU = deTai.GHI_CHU;
            item.KET_QUA = deTai.KET_QUA;
            item.MaDeTai = deTai.MaDeTai;
            item.TEN_DETAI = deTai.TEN_DETAI;
            item.TepTinDinhKem = deTai.TepTinDinhKem;
            item.TU_NGAY = deTai.TU_NGAY;
            item.TUCACH_THAMGIA = deTai.TUCACH_THAMGIA;
            Save();
        }
    }

    /// <summary>
    /// Hàm xóa quan hệ gia đình dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="prkey"></param>
    public void Delete(decimal prkey)
    {
        DAL.HOSO_DETAI obj = dataContext.HOSO_DETAIs.Where(t => t.PR_KEY == prkey).FirstOrDefault();
        if (obj.FR_KEY <= 0)
        {
            dataContext.HOSO_DETAIs.DeleteOnSubmit(obj);
            Save();
        }
        else
        {
            obj.PrKeyHoSoTuCapNhat = -1; //đánh dấu bản ghi này ko còn thuộc về HOSO_TUCAPNHAT
            Save();
        }
    }
     
}