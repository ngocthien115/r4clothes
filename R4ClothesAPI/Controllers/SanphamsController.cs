using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamsController : ControllerBase
    {
        protected ISanPham _sanPhamSvc;
        protected IChiaSe _chiaSeSvc;

        public SanphamsController(ISanPham sanPhamSvc, IChiaSe chiaSeSvc)
        {
            _sanPhamSvc = sanPhamSvc;
            _chiaSeSvc = chiaSeSvc;
        }


        /// <summary>
        /// Danh sách sản phẩm trong client
        /// </summary>
        /// <returns></returns>
        [HttpGet("dssanpham")]
        public List<SanPham> GetSanPhamAll()
        {
            return _sanPhamSvc.DanhSachSanPham();
        }

        [Authorize(Roles ="User")]
        [HttpPost("chiase")]
        public bool ChiaSeSanPham(ChiaSe chiase)
        {
            return _chiaSeSvc.AddChiaSe(chiase);
        }

        [HttpGet("{id}")]
        public SanPham GetSanPham(int id)
        {
            return _sanPhamSvc.GetSanPham(id);
        }

        [HttpGet("splienquan")]
        public List<SanPham> SanPhamLienQuan(int loaisp)
        {
            return _sanPhamSvc.SanPhamLienQuan(loaisp);
        }

        [HttpGet("spdacbiet")]
        public List<SanPham> SanPhamDacBiet()
        {
            return _sanPhamSvc.SanPhamDacBiet();
        }

        [HttpGet("spgiamgia")]
        public List<SanPham> SanPhamGiamGIa(int giamgia)
        {
            return _sanPhamSvc.SanPhamGiamGia(giamgia);
        }
    }
}
