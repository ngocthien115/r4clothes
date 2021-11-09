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
    public class DanhGiaSanPhamsController : ControllerBase
    {
        private IDanhGiaSanPham _danhgiasanpham;
        public DanhGiaSanPhamsController(IDanhGiaSanPham danhgiasanpham)
        {
            _danhgiasanpham = danhgiasanpham;
        }
        // GET: api/<DanhGiaSanPhamsController>/id?
        [HttpGet("{id}")]
        public async Task<List<DanhGiaSanPham>> DanhGiaSanPhamTheoIDSP(int id)
        {
            return await _danhgiasanpham.DanhGiaSanPhamTheoIDSP(id);
        }

        // POST api/<DanhGiaSanPhamsController>
        [HttpPost]
        public async Task<DanhGiaSanPham> Post([FromBody] DanhGiaSanPham danhgiasanpham)
        {
            if (danhgiasanpham != null)
            {
                return await _danhgiasanpham.AddDanhGiaSanPham(danhgiasanpham);
            }
            else
            {
                return danhgiasanpham = null;
            }
        }
    }
}
