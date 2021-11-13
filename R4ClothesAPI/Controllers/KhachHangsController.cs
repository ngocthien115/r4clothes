using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class KhachHangsController : ControllerBase
    {
        private IKhachHang _khachhangSvc;
        public KhachHangsController(IKhachHang khachHang)
        {
            _khachhangSvc = khachHang;
        }

        [AllowAnonymous]
        // POST: api/KhachHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostKhachHang([FromBody] KhachHang khachhang)
        {
            if (khachhang != null)
            {
                await _khachhangSvc.AddKhachhang(khachhang);
                return Ok("Đã thêm thành công");
            }
            else
            {
                return BadRequest("Thêm thất bại");
            }
        }

        // GET: api/Khachhangs/5
        [HttpGet("{id}")]
        public async Task<KhachHang> GetKhachhang(int id)
        {
            return await _khachhangSvc.GetKhachhang(id);
        }

        // PUT: api/Khachhangs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChinhSuaKH(int id, [FromBody] KhachHang kh)
        {
            if (await _khachhangSvc.SuaKhachhang(id, kh) != null)
            {
                return Ok("Đã sửa thành công");
            }
            else
            {
                return NotFound("Lỗi khi sửa");
            }
        }

        [HttpPost("quenmatkhau")]
        public Task<bool> QuenMatKhau(string email)
        {
            return _khachhangSvc.QuenMatKhau(email);
        }

        [HttpPost("doimatkhau")]
        public Task<bool> DoiMatKhau(int idkhachhang, string oldpwd, string newpwd)
        {
            return _khachhangSvc.DoiMatKhau(idkhachhang, oldpwd, newpwd);
        }
    }
}
