using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class LoaiSanPhamsController : ControllerBase
    {

        private ILoaiSanPham _loaisanphamSvc;
        public LoaiSanPhamsController(ILoaiSanPham loaisanphamSvc)
        {
            _loaisanphamSvc = loaisanphamSvc;
        }
        // GET: api/<LoaiSanPhamsController>
        [HttpGet]
        public async Task<List<LoaiSanPham>> GetDSloaiSP()
        {
            return await _loaisanphamSvc.DanhSachLoaiSanPham();
        }

        // POST api/<LoaiSanPhamsController>
        [HttpPost]
        public async Task<LoaiSanPham> PostloaiSP([FromBody] LoaiSanPham loaisanpham)
        {
            if (loaisanpham != null)
            {
                return await _loaisanphamSvc.AddLoaiSanPham(loaisanpham);
            }
            else
            {
                return loaisanpham = null;
            }
        }
    }
}
