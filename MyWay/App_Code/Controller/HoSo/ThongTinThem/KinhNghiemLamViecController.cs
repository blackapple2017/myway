using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for KinhNghiemLamViecController
/// </summary>
public class KinhNghiemLamViecController : LinqProvider
{
    public KinhNghiemLamViecController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// Hàm delete dành riêng cho form tự cập nhật
    /// </summary>
    /// <param name="prKey"></param>
    public void Delete(int ID)
    {
        DAL.HOSO_UNGVIEN_KINHNGHIEMLAMVIEC exitsting = dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.Where(t => t.ID == ID).FirstOrDefault();
        if (exitsting.FR_KEY <= 0)
        {
            dataContext.HOSO_UNGVIEN_KINHNGHIEMLAMVIECs.DeleteOnSubmit(exitsting);
            Save();
        }
        else
        {
            exitsting.PrKeyHoSoTuCapNhat = -1;
            Save();
        }
    }
}