using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HOSO_TEPTINDINHKEMControllor
/// </summary>
public class HOSO_TEPTINDINHKEMControllor : LinqProvider
{
    public HOSO_TEPTINDINHKEMControllor()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void insert(DAL.HOSO_TepTinDinhKem a)
    {
        dataContext.HOSO_TepTinDinhKems.InsertOnSubmit(a);
        Save();
    }
    /// <summary>
    /// Hàm update dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="attachFile"></param>
    public void Update(DAL.HOSO_TepTinDinhKem attachFile)
    {
        DAL.HOSO_TepTinDinhKem item = dataContext.HOSO_TepTinDinhKems.Where(t => t.PR_KEY == attachFile.PR_KEY).FirstOrDefault();
        if (item == null)
        {
            return;
        }
        if (item.FR_KEY > 0 && item.PrKeyHoSoTuCapNhat > 0)
        {
            //nếu đang dùng chung bản ghi thì khi cập nhật sẽ sinh ra 1 bản ghi mới
            item.PrKeyHoSoTuCapNhat = -1; //Hủy việc dùng chung bản ghi
            Save();
            DAL.HOSO_TepTinDinhKem newObject = new DAL.HOSO_TepTinDinhKem()
            {
                FR_KEY = attachFile.FR_KEY,
                PrKeyHoSoTuCapNhat = attachFile.PrKeyHoSoTuCapNhat,
                TenTepTin = attachFile.TenTepTin,
                Link = attachFile.Link,
                GhiChu = attachFile.GhiChu,
                CreatedBy = attachFile.CreatedBy,
                CreatedDate = attachFile.CreatedDate,
            };
            if (attachFile.SizeKB != null)
                newObject.SizeKB = attachFile.SizeKB;
            dataContext.HOSO_TepTinDinhKems.InsertOnSubmit(newObject);
            Save();
        }
        else
        {
            item.FR_KEY = attachFile.FR_KEY;
            item.PrKeyHoSoTuCapNhat = attachFile.PrKeyHoSoTuCapNhat;
            item.TenTepTin = attachFile.TenTepTin;
            if (attachFile.SizeKB != null)
                item.SizeKB = attachFile.SizeKB;
            item.Link = attachFile.Link;
            item.GhiChu = attachFile.GhiChu;
            item.CreatedBy = attachFile.CreatedBy;
            item.CreatedDate = attachFile.CreatedDate;
            Save();
        }
    }
    /// <summary>
    /// Hàm xóa dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="ID"></param>
    public void Delete(int ID, out string linkFile)
    {
        DAL.HOSO_TepTinDinhKem oldObj = dataContext.HOSO_TepTinDinhKems.Where(t => t.PR_KEY == ID).FirstOrDefault();
        if (oldObj.FR_KEY <= 0)
        {
            linkFile = oldObj.Link;
            dataContext.HOSO_TepTinDinhKems.DeleteOnSubmit(oldObj);
            Save();
        }
        else
        {
            oldObj.PrKeyHoSoTuCapNhat = -1;
            linkFile = "";
            Save();
        }
    }
}