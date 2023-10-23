using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Services
{
    public class BenhNhanService
    {
        private readonly ClinicContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public BenhNhanService(ClinicContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public int GetLoggedUserId()
        {
            var maND = _contextAccessor.HttpContext.Session.GetInt32("MaNd");
            return maND ?? 0;
        }

        public BenhNhan GetBenhNhanById(int id)
        {
            return _context.BenhNhans.FirstOrDefault(bn => bn.MaBenhNhan == id);
        }

        public void ThemBenhNhan(BenhNhan bn)
        {
            _context.BenhNhans.Add(bn);
            _context.SaveChanges();
        }

        public BacSi GetBacSiById(int id)
        {
            return _context.BacSis.FirstOrDefault(bs => bs.MaBacSi == id);
        }

        public List<LichHen> LichHenList()
        {
            var list = _context.LichHens.Select(lh => new LichHen
            {
                MaLichHen = lh.MaLichHen,
                NgayGioHen = lh.NgayGioHen,
                TrangThai = lh.TrangThai
            }).ToList();
            return list;
        }

        public void DangKyLichHen(int maLichHen)
        {
            var lichHen = _context.LichHens.FirstOrDefault(lh => lh.MaLichHen == maLichHen);
            if (lichHen != null)
            {
                lichHen.TrangThai = "Chờ xác nhận";
                _context.SaveChanges();
            }
        }

        public List<LichHen> GetLichHenChoXacNhan()
        {
            return _context.LichHens.Where(lh => lh.TrangThai == "Chờ xác nhận").ToList();
        }

        public List<LichHen> GetLichHenXacNhan()
        {
            return _context.LichHens.Where(lh => lh.TrangThai == "Đã xác nhận").ToList();
        }

        public void HuyLichHen(int maLichHen)
        {
            var lichHen = _context.LichHens.FirstOrDefault(lh => lh.MaLichHen == maLichHen);
            if (lichHen != null)
            {
                lichHen.TrangThai = "Chưa xác nhận";
                _context.SaveChanges();
            }
        }
    }
}
