using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using R4Clothes.Shared.Models.ViewModels;
using R4Clothes.Shared.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        public IKhachHang _khachhangSvc;
        public IConfiguration _configuration;
        protected IQuanTri _quanTriSvc;

        public TokensController(IKhachHang khachhangSvc, IConfiguration configuration, IQuanTri quanTriSvc)
        {
            _khachhangSvc = khachhangSvc;
            _configuration = configuration;
            _quanTriSvc = quanTriSvc;
        }

        /// <summary>
        /// Lấy token(Đăng nhập)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login != null && !string.IsNullOrEmpty(login.User)
                && !string.IsNullOrEmpty(login.Password))
            {
                var dangnhap = _khachhangSvc.Login(login);
                if (dangnhap != null)
                {
                    var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("Id", dangnhap.Makhachhang.ToString()),
                            new Claim("FullName", dangnhap.Tenkhachhang),
                            new Claim("Email", dangnhap.Email),
                            new Claim(ClaimTypes.Role, "User")
                        };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                        claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    ViewToken viewToken = new ViewToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), KhachhangId = dangnhap.Makhachhang };
                    return Ok(viewToken);
                }
                else
                {
                    var admin = _quanTriSvc.Login(login);
                    if (admin != null)
                    {
                        var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("Id", admin.Maquantri.ToString()),
                            new Claim("FullName", admin.Hoten),
                            new Claim("Taikhoan", admin.Taikhoan),
                            new Claim(ClaimTypes.Role, "Admin")
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                            claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                        ViewToken viewToken = new ViewToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), KhachhangId = admin.Maquantri };
                        return Ok(viewToken);
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
            }
            return BadRequest();
        }
    }
}