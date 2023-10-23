using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class DonThuocKhamBenh
    {
        public int MaDonThuoc { get; set; }
        public int MaKhamBenh { get; set; }
        public DateTime? NgayGioKham { get; set; }
        public string? TienSuBenh { get; set; }
        public string? QuaTrinhDieuTri { get; set; }
        public string? CacXetNghiem { get; set; }
        public string? KetLuan { get; set; }
        public DateTime? HenTaiKham { get; set; }

        public virtual KhamBenh MaKhamBenhNavigation { get; set; } = null!;
        public virtual DonThuoc MaDonThuocNavigation { get; set; } = null!;
    }
}
