using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Models.ViewModels;
using R4Clothes.Shared.Services;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User,Admin")]
    public class ChiTietHoaDonsController : ControllerBase
    {
        protected IChiTietHoaDon _chiTietHoaDonSvc;
        public ChiTietHoaDonsController(IChiTietHoaDon chiTietHoaDonSvc)
        {
            _chiTietHoaDonSvc = chiTietHoaDonSvc;
        }

        // GET: api/ChiTietHoaDons/5
        [HttpGet("/api/chitiethoadons/hoadon/{id}")]
        public List<SanPhamCT> GetChiTiet(int id)
        {
           return _chiTietHoaDonSvc.GetChiTiet(id);
        }
    }
}
