using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class YTa
    {
        public int MaYta { get; set; }
        public string? Ho { get; set; }
        public string? Ten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? BangCap { get; set; }
        public string? ChuyenMon { get; set; }
        public int? MaNd { get; set; }

        public virtual NguoiDung? MaNdNavigation { get; set; }
    }
}
