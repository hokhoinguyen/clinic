using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Services
{
    public class ThuocService
    {
        private readonly ClinicContext _context;

        public ThuocService(ClinicContext context)
        {
            _context = context;
        }

        public List<Thuoc> ThuocList()
        {
            var listThuoc = _context.Thuocs
                .Select(thuoc => new Thuoc
            {
                MaThuoc = thuoc.MaThuoc,
                TenThuoc = thuoc.TenThuoc,
                MoTa = thuoc.MoTa,
                HangSanXuat = thuoc.HangSanXuat,
                GiaNiemYet = thuoc.GiaNiemYet
            }).ToList();
            return listThuoc;
        }

        public List<Thuoc> TimKiemThuocTheoTen(string tenThuoc)
        {
            var dsThuoc = _context.Thuocs
                .Where(t => t.TenThuoc.Contains(tenThuoc))
                .ToList();
            return dsThuoc;
        }

        public async Task ThemThuoc(Thuoc thuoc)
        {
            _context.Thuocs.Add(thuoc);
            await _context.SaveChangesAsync();
        }

        public async Task<Thuoc> GetThuocById(int id)
        {
            return await _context.Thuocs.FirstOrDefaultAsync(thuoc => thuoc.MaThuoc == id);
        }

        public async Task CapNhatThuoc(Thuoc thuoc)
        {
            _context.Entry(thuoc).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task XoaThuoc(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc != null)
            {
                _context.Thuocs.Remove(thuoc);
                await _context.SaveChangesAsync();
            }    
        }
    }
}
