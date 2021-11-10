using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Models.ViewModels;
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
    public class ThongKesController : ControllerBase
    {
        private readonly IThongKe _thongKeSvc;

        public ThongKesController(IThongKe thongKeSvc)
        {
            _thongKeSvc = thongKeSvc;
        }

        // GET: api/<ThongKesController>
        [HttpGet("/api/thongke/specialcus")]
        public List<KhachHangTT> Get()
        {
            return _thongKeSvc.KhachHangThanThiet();
        }

        [HttpGet("/api/thongke/doanhthu")]
        public async Task<List<HoaDon>> GetDoanhthu(DateTime from, DateTime to)
        {
            return await _thongKeSvc.DoanhThu(from, to);
        }

        [HttpGet("/api/thongke/banduoc")]
        public List<SanPham> BanDuoc()
        {
            return _thongKeSvc.SoLuongSanPhamBanDuoc();
        }
    }
}
