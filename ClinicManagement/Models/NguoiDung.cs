using System;
using System.Collections.Generic;

namespace ClinicManagement.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            BacSis = new HashSet<BacSi>();
            BenhNhans = new HashSet<BenhNhan>();
            Yta = new HashSet<YTa>();
        }

        public int MaNd { get; set; }
        public string? Ho { get; set; }
        public string? Ten { get; set; }
        public string? TenDangNhap { get; set; }
        public string? MatKhau { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public int? MaQuyen { get; set; }

        public virtual Quyen? MaQuyenNavigation { get; set; }
        public virtual ICollection<BacSi> BacSis { get; set; }
        public virtual ICollection<BenhNhan> BenhNhans { get; set; }
        public virtual ICollection<YTa> Yta { get; set; }
    }
}
