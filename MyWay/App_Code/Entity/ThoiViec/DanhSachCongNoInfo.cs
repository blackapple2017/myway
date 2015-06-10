using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.ThoiViec
{
    public class DanhSachCongNoInfo
    {
        public int ID { get; set; }
        public string TenLoaiCongNo { get; set; }
        public string GhiChu { get; set; }

        public float? SoTien { get; set; }
         
        public bool DaHoanThanh { get; set; }

        public DateTime? NgayHoanThanh { get; set; }
        public DateTime NgayTao { get; set; }
    }
}