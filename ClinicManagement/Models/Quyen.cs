using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class Quyen
    {
        public Quyen()
        {
            NguoiDungs = new HashSet<NguoiDung>();
        }

        public int MaQuyen { get; set; }
        public string? TenQuyen { get; set; }
        public string? MoTaQuyen { get; set; }

        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
