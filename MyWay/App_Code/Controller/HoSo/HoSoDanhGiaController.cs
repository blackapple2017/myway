using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Controller.HoSo
{
    /// <summary>
    /// Summary description for HOSO_DANHGIAController
    /// </summary>
    public class HoSoDanhGiaController
    {
        public HoSoDanhGiaController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetDanhGiaByPrkeyCB(int start, int limit, string maCB, out int count)
        {
            count = int.Parse(DataController.DataHandler.GetInstance().ExecuteScalar("HOSO_CountDanhGiaNhanVien", "@MaCB", maCB).ToString());
            return DataController.DataHandler.GetInstance().ExecuteDataTable("HOSO_GetDanhGiaNhanVien", "@Start", "@Limit", "@MaCB", start, limit, maCB);
        }
    }
}