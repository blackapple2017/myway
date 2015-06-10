using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuanHeGiaDinhController
/// </summary>
public class QuanHeGiaDinhController : LinqProvider
{
    /*
     Note : Vì cơ sở dữ liệu sử dụng chung bảng cho nên sinh ra nhiều bất cập ==> phải viết các hàm xử lý riêng cho việc update
     */
    public void Update(DAL.HOSO_QH_GIADINH obj)
    {
        DAL.HOSO_QH_GIADINH item = dataContext.HOSO_QH_GIADINHs.Where(t => t.PR_KEY == obj.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            item.PrKeyHoSoTuCapNhat = -1; //Hủy việc dùng chung bản ghi
            Save();
            DAL.HOSO_QH_GIADINH newObject = new DAL.HOSO_QH_GIADINH()
            {
                //  Duyet = false,
                PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat,
                TUOI = obj.TUOI,
                GHI_CHU = obj.GHI_CHU,
                FR_KEY = -1,
                GIOI_TINH = obj.GIOI_TINH,
                NOI_LAMVIEC = obj.NOI_LAMVIEC,
                NGHE_NGHIEP = obj.NGHE_NGHIEP,
                NgayKetThucGiamTru = obj.NgayKetThucGiamTru,
                NgayBatDauGiamTru = obj.NgayBatDauGiamTru,
                MA_QUANHE = obj.MA_QUANHE,
                LaNguoiPhuThuoc = obj.LaNguoiPhuThuoc,
                HO_TEN = obj.HO_TEN,
            };
            dataContext.HOSO_QH_GIADINHs.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            //  item.Duyet = false;
            item.PrKeyHoSoTuCapNhat = obj.PrKeyHoSoTuCapNhat;
            item.TUOI = obj.TUOI;
            item.GHI_CHU = obj.GHI_CHU;
            item.FR_KEY = -1;
            item.GIOI_TINH = obj.GIOI_TINH;
            item.NOI_LAMVIEC = obj.NOI_LAMVIEC;
            item.NGHE_NGHIEP = obj.NGHE_NGHIEP;
            item.NgayKetThucGiamTru = obj.NgayKetThucGiamTru;
            item.NgayBatDauGiamTru = obj.NgayBatDauGiamTru;
            item.MA_QUANHE = obj.MA_QUANHE;
            item.LaNguoiPhuThuoc = obj.LaNguoiPhuThuoc;
            item.HO_TEN = obj.HO_TEN;
            Save();
        }
    }

    /// <summary>
    /// Hàm xóa quan hệ gia đình dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="prkey"></param>
    public void Delete(decimal prkey)
    {
        DAL.HOSO_QH_GIADINH obj = dataContext.HOSO_QH_GIADINHs.Where(t => t.PR_KEY == prkey).FirstOrDefault();
        if (obj.FR_KEY <= 0)
        {
            dataContext.HOSO_QH_GIADINHs.DeleteOnSubmit(obj);
            Save();
        }
        else
        {
            obj.PrKeyHoSoTuCapNhat = -1; //đánh dấu bản ghi này ko còn thuộc về HOSO_TUCAPNHAT
            Save();
        }
    }
}