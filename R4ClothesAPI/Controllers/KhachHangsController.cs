using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangsController : ControllerBase
    {
        private IKhachHang _khachhangSvc;
        public KhachHangsController(IKhachHang khachHang)
        {
            _khachhangSvc = khachHang;
        }

        // GET: api/khachhangs
        [HttpGet]
        public async Task<List<KhachHang>> DSKH()
        {
            return await _khachhangSvc.DanhSachKhachHang();
            
        }

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

        // PUT: api/Khachhangs/5
        [HttpPut("{id}")]
        public async Task<KhachHang> ChinhSuaKH(int id, [FromBody] KhachHang kh)
        {
            return await _khachhangSvc.SuaKhachhang(id, kh);
        }

        // DELETE: api/Khachhangs/5
        [HttpDelete("{id}")]
        public bool ChinhSuaKH(int id)
        {
            return _khachhangSvc.XoaKhachHang(id);
        }
    }
}
