using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class BenhNhan
    {
        public BenhNhan()
        {
            KhamBenhs = new HashSet<KhamBenh>();
            LichHens = new HashSet<LichHen>();
        }

        public int MaBenhNhan { get; set; }
        public string? Ho { get; set; }
        public string? Ten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? SoCccd { get; set; }
        public string? GioiTinh { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public int? MaNd { get; set; }

        public virtual NguoiDung? MaNdNavigation { get; set; }
        public virtual ICollection<KhamBenh> KhamBenhs { get; set; }
        public virtual ICollection<LichHen> LichHens { get; set; }
    }
}
