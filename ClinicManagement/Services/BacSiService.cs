using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Services
{
    public class BacSiService
    {
        private readonly ClinicContext _context;

        public BacSiService(ClinicContext context)
        {
            _context = context;
        }

        public List<BacSi> BacSiList()
        {
            var listBacSi = _context.BacSis.Select(bs => new BacSi
            {
                MaBacSi = bs.MaBacSi,
                Ho = bs.Ho,
                Ten = bs.Ten,
                NgaySinh = bs.NgaySinh,
                ChucVu = bs.ChucVu,
                GioiTinh = bs.GioiTinh,
                DiaChi = bs.DiaChi,
                SoDienThoai = bs.SoDienThoai,
                BangCap = bs.BangCap,
                ChuyenMon = bs.ChuyenMon
            }).ToList();
            return listBacSi;
        }

        public List<BacSi> TimKiemBacSiTheoTen(string tenBacSi)
        {
            var dsBacSi = _context.BacSis
                .Where(bs => bs.Ten.Contains(tenBacSi))
                .ToList();
            return dsBacSi;
        }

        public async Task ThemBacSi(BacSi bacSi)
        {
            _context.BacSis.Add(bacSi);
            await _context.SaveChangesAsync();
        }

        public async Task<BacSi> GetBacSiById(int id)
        {
            return await _context.BacSis.FirstOrDefaultAsync(bs => bs.MaBacSi == id);
        }

        public async Task SuaThongTinBacSi(BacSi bs)
        {
            _context.Entry(bs).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task XoaBacSi(int id)
        {
            var bs = await _context.BacSis.FindAsync(id);
            if (bs != null)
            {
                _context.BacSis.Remove(bs);
                await _context.SaveChangesAsync();
            }
        }

        public void TaoDonThuoc(DonThuoc donThuoc)
        {
            _context.Add(donThuoc);
            _context.SaveChanges();
        }
    }
}
