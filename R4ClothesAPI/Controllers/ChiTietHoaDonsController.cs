using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models.ViewModels;
using R4Clothes.Shared.Services;
using System.Collections.Generic;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonsController : ControllerBase
    {
        protected IChiTietHoaDon _chiTietHoaDonSvc;

        public ChiTietHoaDonsController(IChiTietHoaDon chiTietHoaDonSvc)
        {
            _chiTietHoaDonSvc = chiTietHoaDonSvc;
        }

        /// <summary>
        /// Danh sách sản phẩm trong hóa đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/chitiethoadons/hoadon/{id}")]
        public List<SanPhamCT> GetChiTiet(int id)
        {
            return _chiTietHoaDonSvc.GetChiTiet(id);
        }
    }
}