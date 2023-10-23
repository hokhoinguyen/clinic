using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class LichHen
    {
        public LichHen()
        {
            DonThuocs = new HashSet<DonThuoc>();
            KhamBenhs = new HashSet<KhamBenh>();
        }

        public int MaLichHen { get; set; }
        public int? MaBenhNhan { get; set; }
        public int? MaBacSi { get; set; }
        public DateTime? NgayGioHen { get; set; }
        public string? TrangThai { get; set; }

        public virtual BacSi? MaBacSiNavigation { get; set; }
        public virtual BenhNhan? MaBenhNhanNavigation { get; set; }
        public virtual ICollection<DonThuoc> DonThuocs { get; set; }
        public virtual ICollection<KhamBenh> KhamBenhs { get; set; }
    }
}
