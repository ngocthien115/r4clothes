using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using R4Clothes.Shared.Services;
using Microsoft.Extensions.Configuration;
using R4Clothes.Shared.Models.ViewModels;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using R4Clothes.Shared.Models;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        public IKhachHang _khachhangSvc;
        public IConfiguration _configuration;
        public TokensController(IConfiguration configuration, IKhachHang khachHang)
        {
            _khachhangSvc = khachHang;
            _configuration = configuration;
        }
        //[HttpPost]
        //public IActionResult Login(LoginKH loginKH)
        //{
        //    if (loginKH != null && !string.IsNullOrEmpty(loginKH.Email)
        //        && !string.IsNullOrEmpty(loginKH.Password))
        //    {
        //        var khachhang = _khachhangSvc.Login(loginKH);
        //        if (khachhang != null)
        //        {
        //            if (khachhang != null)
        //            {
        //                //create claims details based on the user information
        //                var claims = new[] {
        //                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

        //                    new Claim("Id", khachhang.Makhachhang.ToString()),
        //                    new Claim("FullName", khachhang.Tenkhachhang),
        //                    new Claim("Email", khachhang.Email)
        //                };

        //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
        //                    claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

        //                ViewToken viewToken = new ViewToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), KhachhangId = khachhang.Makhachhang };
        //                return Ok(viewToken);
        //            }
        //            else
        //            {
        //                return BadRequest("Invalid credentials");
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    return BadRequest();
        //}
        [HttpPost]
        public KhachHang Login(LoginKH loginKH)
        {
            return _khachhangSvc.Login(loginKH);
        }
        [HttpGet]
        public Task<bool> QuenMatKhau(string email)
        {
            return _khachhangSvc.QuenMatKhau(email);
        }
        [HttpPut]
        public Task<bool> DoiMatKhau(int idkhachhang, string oldpwd, string newpwd)
        {
            return _khachhangSvc.DoiMatKhau(idkhachhang,oldpwd,newpwd);
        }
    }
}
