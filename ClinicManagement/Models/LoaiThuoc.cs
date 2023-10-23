using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class LoaiThuoc
    {
        public LoaiThuoc()
        {
            Thuocs = new HashSet<Thuoc>();
        }

        public int MaLoaiThuoc { get; set; }
        public string? TenLoaiThuoc { get; set; }
        public string? MoTa { get; set; }

        public virtual ICollection<Thuoc> Thuocs { get; set; }
    }
}
