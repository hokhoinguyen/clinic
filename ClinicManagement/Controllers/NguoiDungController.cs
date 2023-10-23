using ClinicManagement.Models;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicManagement.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly NguoiDungService _service;
        private readonly ClinicContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public NguoiDungController(NguoiDungService service, ClinicContext context, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(NguoiDung nd, IFormFile avaFile)
        {
                try
                {
                    await _service.DangKyAsync(nd, nd.TenDangNhap, nd.MatKhau, avaFile);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            return View(nd);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(NguoiDung nd)
        {
            bool result = await _service.DangNhapAsync(nd);
            if (result)
            {
                string tenDangNhap = _contextAccessor.HttpContext.Session.GetString("TenDangNhap");
                int? maQuyen = _contextAccessor.HttpContext.Session.GetInt32("MaQuyen");

                if (!string.IsNullOrEmpty(tenDangNhap) && maQuyen.HasValue)
                {
                    if (maQuyen == 1)
                        return RedirectToAction("AdminView", "Admin");
                    else if (maQuyen == 2)
                        return RedirectToAction("BacSiView", "BacSi");
                    else if (maQuyen == 3)
                        return RedirectToAction("YTaView", "YTa");
                    else if (maQuyen == 4)
                        return RedirectToAction("BenhNhanView", "NguoiDung");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
                
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ConfirmLogout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _service.DangXuatAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult BenhNhanView()
        {
            return View();
        }
    }
}
