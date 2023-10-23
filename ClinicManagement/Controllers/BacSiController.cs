using ClinicManagement.Models;
using ClinicManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Controllers
{
    public class BacSiController : Controller
    {
        public readonly BacSiService _bacSiService;
        public readonly ClinicContext _clinicContext;

        public BacSiController(BacSiService bacSiService, ClinicContext clinicContext)
        {
            _bacSiService = bacSiService;
            _clinicContext = clinicContext;
        }

        public IActionResult ListBacSi(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                var dsBacSi = _bacSiService.TimKiemBacSiTheoTen(searchTerm);
                return View(dsBacSi);
            }

            var allBacSi = _bacSiService.BacSiList();
            return View(allBacSi);
        }

        public IActionResult BacSiView() 
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult CreateBacSi()
        {
            var dsChucVu = _clinicContext.BacSis.Select(bs => new SelectListItem
            {
                Text = bs.ChucVu
            }).ToList();

            ViewBag.DSChucVu = dsChucVu;

            var dsBangCap = _clinicContext.BacSis.Select(bs => new SelectListItem
            {
                Text = bs.BangCap
            }).ToList();

            ViewBag.DSBangCap = dsBangCap;

            var dsChuyenMon = _clinicContext.BacSis.Select(bs => new SelectListItem
            {
                Text = bs.ChuyenMon
            }).ToList();

            ViewBag.DSChuyenMon = dsChuyenMon;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBacSi([Bind("MaBacSi, Ho, Ten, NgaySinh, ChucVu, GioiTinh, DiaChi, SoDienThoai, BangCap, ChuyenMon, MaNd")] BacSi bs)
        {
            if (ModelState.IsValid)
            {
                await _bacSiService.ThemBacSi(bs);
                return RedirectToAction("ListBacSi");
            }
            return View(bs);
        }

        [HttpGet]
        public async Task<IActionResult> EditBacSi(int id)
        {
            var bs = await _bacSiService.GetBacSiById(id);
            if (bs == null)
                return NotFound();
            var dsNguoiDung = _clinicContext.NguoiDungs
                .Select(nd => new SelectListItem
                {
                    Value = nd.MaNd.ToString(),
                    Text = nd.Ten
                }).ToList();
            ViewBag.DSNguoiDung = new SelectList(dsNguoiDung, "Value", "Text");
            return View(bs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBacSi(int id, BacSi bs)
        {
            if (id != bs.MaBacSi)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _bacSiService.SuaThongTinBacSi(bs);
                return RedirectToAction("ListBacSi");
            }

            return View(bs);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBacSi(int id)
        {
            var bs = await _bacSiService.GetBacSiById(id);
            if (bs == null)
                return NotFound();
            return View(bs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDeleteBacSi(int id)
        {
            await _bacSiService.XoaBacSi(id);
            return RedirectToAction("ListBacSi");
        }

        [HttpGet]
        public IActionResult TaoDonThuoc()
        {
            var dsNgayGioHen = _clinicContext.LichHens.Select(lh => new SelectListItem
            {
                Value = lh.NgayGioHen.HasValue ? string.Format("{0:yyyy-MM-dd HH:mm:ss}", lh.NgayGioHen) : string.Empty,
                Text = lh.NgayGioHen.HasValue ? string.Format("{0:dd/MM/yyyy HH:mm}", lh.NgayGioHen) : "Chọn ngày giờ hẹn"
            }).ToList();
            ViewBag.DSNgayGioHen = new SelectList(dsNgayGioHen, "Value", "Text");

            var dsThuoc = _clinicContext.Thuocs.Select(thuoc => new SelectListItem
            {
                Text = thuoc.TenThuoc
            }).ToList();
            ViewBag.DSThuoc = dsThuoc;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TaoDonThuoc(DonThuoc donThuoc, string tenThuoc, DateTime ngayGioHen)
        {
            if (ModelState.IsValid)
            {
                //var selectedLichHen = _clinicContext.LichHens.FirstOrDefault(lh => lh.NgayGioHen.Equals(ngayGioHen));
                //var selectedThuoc = _clinicContext.Thuocs.FirstOrDefault(thuoc => thuoc.TenThuoc == tenThuoc);

                //if (selectedLichHen != null && selectedThuoc != null)
                if (donThuoc.MaLichHen != null && donThuoc.MaThuoc != null)
                {
                    //donThuoc.MaLichHen = selectedLichHen.MaLichHen;
                    //donThuoc.MaThuoc = selectedThuoc.MaThuoc;
                    _bacSiService.TaoDonThuoc(donThuoc);
                    return RedirectToAction("TaoDonThuoc");
                }    
                else
                    ModelState.AddModelError(string.Empty, "Có lỗi trong việc tạo đơn thuốc.");
            }  
            return View(donThuoc);
        }
    }
}
