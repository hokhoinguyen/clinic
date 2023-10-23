
using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ClinicManagement.Services
{
    public class NguoiDungService
    {
        private readonly ClinicContext _context;
        private readonly Cloudinary _cloudinary;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<NguoiDungService> _logger;

        public NguoiDungService(ClinicContext context, Cloudinary cloudinary, IHttpContextAccessor httpContextAccessor, ILogger<NguoiDungService> logger)
        {
            _context = context;
            _cloudinary = cloudinary;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public string CalculateSHA256(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2")); // Chuyển byte sang dạng hex
                }

                return sb.ToString();
            }
        }

        public async Task DangKyAsync(NguoiDung nd, string tenDangNhap, string matKhau, IFormFile avaFile)
        {
            try
            {
                var existingUser = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.TenDangNhap == tenDangNhap);
                if (existingUser != null)
                {
                    throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");
                }

                string hashedPassword = CalculateSHA256(matKhau);

                string imgUrl = null;

                if (avaFile != null && avaFile.Length > 0 && avaFile.ContentType.StartsWith("image/"))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(avaFile.FileName, avaFile.OpenReadStream()),
                    };

                    var resultUpload = await _cloudinary.UploadAsync(uploadParams);

                    if (resultUpload.Error != null)
                    {
                        throw new Exception($"Lỗi tải lên Cloudinary: {resultUpload.Error.Message}");
                    }
                    else
                    {
                        imgUrl = resultUpload.SecureUrl.ToString();
                    }
                }

                var nguoiDung = new NguoiDung()
                {
                    Ho = nd.Ho,
                    Ten = nd.Ten,
                    TenDangNhap = nd.TenDangNhap,
                    MatKhau = hashedPassword,
                    Email = nd.Email,
                    Avatar = imgUrl,
                    MaQuyen = 4
                };

                _context.NguoiDungs.Add(nguoiDung);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi xảy ra trong quá trình đăng ký: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DangNhapAsync(NguoiDung nd)
        {
            if (string.IsNullOrEmpty(nd.TenDangNhap) || string.IsNullOrEmpty(nd.MatKhau))
            {
                return false;
            }
            string hashedPass = CalculateSHA256(nd.MatKhau);
            var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.TenDangNhap.Equals(nd.TenDangNhap) && u.MatKhau.Equals(hashedPass));
            if (user != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);
                _httpContextAccessor.HttpContext.Session.SetInt32("MaQuyen", (int)user.MaQuyen);
                return true;
            }
            return false;
        }

        public async Task<NguoiDung> GetNguoiDungByNameAsync(string userName)
        {
            var user = await _context.NguoiDungs.FirstOrDefaultAsync(u => u.TenDangNhap == userName);
            return user;
        }

        public async Task DangXuatAsync()
        {
            _httpContextAccessor.HttpContext.Session.Remove("TenDangNhap");
            _httpContextAccessor.HttpContext.Session.Remove("MaQuyen");
        }
    }
}