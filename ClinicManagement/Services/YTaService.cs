using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Services
{
    public class YTaService
    {
        private readonly ClinicContext _context;

        public YTaService(ClinicContext context)
        {
            _context = context;
        }

        public List<YTa> YTaList()
        {
            var listYTa = _context.Yta.Select(yta => new YTa
            {
                MaYta = yta.MaYta,
                Ho = yta.Ho,
                Ten = yta.Ten,
                NgaySinh = yta.NgaySinh,
                GioiTinh = yta.GioiTinh,
                DiaChi = yta.DiaChi,
                SoDienThoai = yta.SoDienThoai,
                BangCap = yta.BangCap,
                ChuyenMon = yta.ChuyenMon
            }).ToList();
            return listYTa;
        }

        public List<YTa> TimKiemYTaTheoTen(string tenYTa)
        {
            var dsYTa = _context.Yta
                .Where(yta => yta.Ten.Contains(tenYTa))
                .ToList();
            return dsYTa;
        }

        public async Task ThemYTa(YTa yTa)
        {
            _context.Yta.Add(yTa);
            await _context.SaveChangesAsync();
        }

        public async Task<YTa> GetYTaById(int id)
        {
            return await _context.Yta.FirstOrDefaultAsync(yt => yt.MaYta == id);
        }

        public async Task SuaThongTinYTa(YTa yt)
        {
            _context.Entry(yt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task XoaYTa(int id)
        {
            var yt = await _context.Yta.FindAsync(id);
            if (yt != null)
            {
                _context.Yta.Remove(yt);
                await _context.SaveChangesAsync();
            }
        }

        public void XacNhanLichHen(int maLichHen)
        {
            var lichHen = _context.LichHens.FirstOrDefault(lh => lh.MaLichHen == maLichHen);
            if (lichHen != null)
            {
                lichHen.TrangThai = "Đã xác nhận";
                _context.SaveChanges();
            }
        }

        public List<LichHen> GetLichHenChoXacNhan()
        {
            return _context.LichHens.Where(lh => lh.TrangThai == "Chờ xác nhận").ToList();
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
