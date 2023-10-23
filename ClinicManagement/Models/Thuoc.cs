using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class Thuoc
    {
        public Thuoc()
        {
            DonThuocKhamBenhs = new HashSet<DonThuocKhamBenh>();
            DonThuocs = new HashSet<DonThuoc>();
        }

        public int MaThuoc { get; set; }
        public string? TenThuoc { get; set; }
        public string? MoTa { get; set; }
        public string? HangSanXuat { get; set; }
        public decimal? GiaNiemYet { get; set; }
        public int? MaLoaiThuoc { get; set; }

        public virtual LoaiThuoc? MaLoaiThuocNavigation { get; set; }
        public virtual ICollection<DonThuocKhamBenh> DonThuocKhamBenhs { get; set; }
        public virtual ICollection<DonThuoc> DonThuocs { get; set; }
    }
}
