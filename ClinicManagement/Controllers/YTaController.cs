using ClinicManagement.Models;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicManagement.Controllers
{
    public class YTaController : Controller
    {
        private readonly YTaService _yTaService;
        private readonly ClinicContext _clinicContext;

        public YTaController(YTaService yTaService, ClinicContext clinicContext)
        {
            _yTaService = yTaService;
            _clinicContext = clinicContext;
        }

        public IActionResult ListYTa(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var dsYTa = _yTaService.TimKiemYTaTheoTen(searchTerm);
                return View(dsYTa);
            }

            var allYTa = _yTaService.YTaList();
            return View(allYTa);
        }

        public IActionResult YTaView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateYTa()
        {
            var dsBangCap = _clinicContext.Yta.Select(yt => new SelectListItem
            {
                Text = yt.BangCap
            }).ToList();
            ViewBag.DSBangCap = dsBangCap;

            var dsChuyenMon = _clinicContext.Yta.Select(yt => new SelectListItem
            {
                Text = yt.ChuyenMon
            }).ToList();
            ViewBag.DSChuyenMon = dsChuyenMon;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateYTa([Bind("MaYta, Ho, Ten, NgaySinh, GioiTinh, DiaChi, SoDienThoai, BangCap, ChuyenMon, MaNd")] YTa yt)
        {
            if (ModelState.IsValid)
            {
                await _yTaService.ThemYTa(yt);
                return RedirectToAction("ListYTa");
            }
            return View(yt);
        }

        [HttpGet]
        public async Task<IActionResult> EditYTa(int id)
        {
            var yt = await _yTaService.GetYTaById(id);
            if (yt == null)
                return NotFound();
            var dsNguoiDung = _clinicContext.NguoiDungs
                .Select(nd => new SelectListItem
                {
                    Value = nd.MaNd.ToString(),
                    Text = nd.Ten
                }).ToList();
            ViewBag.DSNguoiDung = new SelectList(dsNguoiDung, "Value", "Text");
            return View(yt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditYTa(int id, YTa yt)
        {
            if (id != yt.MaYta)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _yTaService.SuaThongTinYTa(yt);
                return RedirectToAction("ListYTa");
            }

            return View(yt);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteYTa(int id)
        {
            var yt = await _yTaService.GetYTaById(id);
            if (yt == null)
                return NotFound();
            return View(yt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDeleteYTa(int id)
        {
            await _yTaService.XoaYTa(id);
            return RedirectToAction("ListYTa");
        }

        public IActionResult LichHenChoXacNhan()
        {
            var lichHenChoXacNhan = _yTaService.GetLichHenChoXacNhan();
            return View(lichHenChoXacNhan);
        }

        public IActionResult XacNhanLichHen(int maLichHen)
        {
            _yTaService.XacNhanLichHen(maLichHen);
            return RedirectToAction("LichHenChoXacNhan");
        }

        public IActionResult HuyLichHen(int maLichHen)
        {
            _yTaService.HuyLichHen(maLichHen);
            return RedirectToAction("LichHenChoXacNhan");
        }
    }
}
