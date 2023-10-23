using ClinicManagement.Models;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    public class BenhNhanController : Controller
    {
        private readonly BenhNhanService _service;

        public BenhNhanController(BenhNhanService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult CreateProfile() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProfile(BenhNhan bn)
        {
            if (ModelState.IsValid)
            {
                _service.ThemBenhNhan(bn);
                return RedirectToAction("BenhNhanView", "NguoiDung");
            }
            return View(bn);
        }

        public IActionResult XemLichHen()
        {
            var lichHenList = _service.LichHenList();
            return View(lichHenList);
        }

        public IActionResult Successful()
        {
            return View();
        }

        public IActionResult DangKyLichHen(int maLichHen)
        {
            _service.DangKyLichHen(maLichHen);
            return RedirectToAction("Successful");
        }

        public IActionResult ThongTinLichHen()
        {
            var lichHen = _service.GetLichHenChoXacNhan();
            return View(lichHen);
        }

        public IActionResult LichHenXacNhan()
        {
            var lichHen = _service.GetLichHenXacNhan();
            return View(lichHen);
        }

        public IActionResult HuyLichHen(int maLichHen)
        {
            _service.HuyLichHen(maLichHen);
            return RedirectToAction("ThongTinLichHen");
        }
    }
}