using ClinicManagement.Models;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicManagement.Controllers
{
    public class ThuocController : Controller
    {
        private readonly ThuocService _thuocService;
        private readonly ClinicContext _context;

        public ThuocController(ClinicContext context, ThuocService thuocService)
        {
            _context = context;
            _thuocService = thuocService;
        }

        public IActionResult ListThuoc(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var dsThuoc = _thuocService.TimKiemThuocTheoTen(searchTerm);
                return View(dsThuoc);
            }

            var allThuoc = _thuocService.ThuocList();
            return View(allThuoc);
        }

        [HttpGet]
        public IActionResult CreateThuoc()
        {
            var dsLoaiThuoc = _context.LoaiThuocs.Select(lt => new SelectListItem
            {
                Value = lt.MaLoaiThuoc.ToString(),
                Text = lt.TenLoaiThuoc
            }).ToList();

            ViewBag.DSLoaiThuoc = dsLoaiThuoc;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateThuoc([Bind("MaThuoc, TenThuoc, MoTa, HangSanXuat, GiaNiemYet, MaLoaiThuoc")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                await _thuocService.ThemThuoc(thuoc);
                return RedirectToAction("ListThuoc");
            }
            return View(thuoc);
        }

        [HttpGet]
        public async Task<IActionResult> EditThuoc(int id)
        {
            var thuoc = await _thuocService.GetThuocById(id);
            if (thuoc == null)
                return NotFound();
            var dsLoaiThuoc = _context.LoaiThuocs
                .Select(lt => new SelectListItem
                {
                    Value = lt.MaLoaiThuoc.ToString(),
                    Text = lt.TenLoaiThuoc
                }).ToList();
            ViewBag.DSLoaiThuoc = new SelectList(dsLoaiThuoc, "Value", "Text");
            return View(thuoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditThuoc(int id, Thuoc thuoc)
        {
            if (id != thuoc.MaThuoc)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _thuocService.CapNhatThuoc(thuoc);
                return RedirectToAction("ListThuoc");
            }

            return View(thuoc);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteThuoc(int id)
        {
            var thuoc = await _thuocService.GetThuocById(id);
            if (thuoc == null)
                return NotFound();
            return View(thuoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDeleteThuoc(int id)
        {
            await _thuocService.XoaThuoc(id);
            return RedirectToAction("ListThuoc");
        }
    }
}
