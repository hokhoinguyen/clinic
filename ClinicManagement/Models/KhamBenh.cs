using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class KhamBenh
    {
        public KhamBenh()
        {
            DonThuocKhamBenhs = new HashSet<DonThuocKhamBenh>();
        }

        public int MaKhamBenh { get; set; }
        public int? MaBenhNhan { get; set; }
        public int? MaBacSi { get; set; }
        public int? MaLichHen { get; set; }
        public DateTime? NgayGioKham { get; set; }
        public string? TienSuBenh { get; set; }
        public string? QuaTrinhDieuTri { get; set; }
        public string? CacXetNghiem { get; set; }
        public string? KetLuan { get; set; }
        public DateTime? HenTaiKham { get; set; }

        public virtual BacSi? MaBacSiNavigation { get; set; }
        public virtual BenhNhan? MaBenhNhanNavigation { get; set; }
        public virtual LichHen? MaLichHenNavigation { get; set; }
        public virtual ICollection<DonThuocKhamBenh> DonThuocKhamBenhs { get; set; }
    }
}
