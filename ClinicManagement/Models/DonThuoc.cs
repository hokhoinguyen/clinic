using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class DonThuoc
    {
        public DonThuoc() 
        {
            DonThuocKhamBenhs = new HashSet<DonThuocKhamBenh>();
        }

        public int MaDonThuoc { get; set; }
        public int? MaLichHen { get; set; }
        public DateTime? NgayKeDon { get; set; }
        public string? TrieuChung { get; set; }
        public string? KetLuan { get; set; }
        public int? MaThuoc { get; set; }

        public virtual LichHen? MaLichHenNavigation { get; set; }
        public virtual Thuoc? MaThuocNavigation { get; set; }
        public virtual ICollection<DonThuocKhamBenh> DonThuocKhamBenhs { get; set; }
    }
}
