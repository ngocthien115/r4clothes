using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class HoaDonsController : ControllerBase
    {
        private IHoaDon _hoadonSvc;
        private IChiTietHoaDon _chitiethoadonSvc;
        private ISanPham _sanPhamSvc;

        public HoaDonsController(IHoaDon hoadonSvc, IChiTietHoaDon chitiethoadonSvc, ISanPham sanPhamSvc)
        {
            _hoadonSvc = hoadonSvc;
            _chitiethoadonSvc = chitiethoadonSvc;
            _sanPhamSvc = sanPhamSvc;
        }


        /// <summary>
        /// Lấy thông tin 1 hóa đơn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/hoadon/{id}")]
        public HoaDon GetHoaDon(int id)
        {
            return _hoadonSvc.GetHoaDon(id);
        }

        // GET: api/hoadons
        /// <summary>
        /// Danh sách hóa đơn theo khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/hoadon/khachhang/{id}")]
        public List<HoaDon> DSDHByKH(int id)
        {
            return  _hoadonSvc.DanhSachHoaDonTheoKhachHang(id);

        }
        

        /// <summary>
        /// Thêm hóa đơn mới
        /// </summary>
        /// <param name="GioHang"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostCart(Cart GioHang)
        {
            try
            {
                var hoadon = new HoaDon()
                {
                    Trangthai = TrangthaiHD.Dangchoxuli,
                    Makhachhang = GioHang.Makhachhang,
                    Nguoiquantri = 2,
                    Tongtien = GioHang.Tongtien,
                    Ngaydat = DateTime.Now,
                };
                int Mahoadon =  _hoadonSvc.AddHoaDon(hoadon);

                List<CartItem> dataCart = GioHang.ListViewCart;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    ChiTietHoaDon chitiet = new ChiTietHoaDon()
                    {
                        Mahoadon = Mahoadon,
                        Masanpham = dataCart[i].SanPham.Masanpham,
                        Tensanpham = dataCart[i].SanPham.Tensanpham,
                        Soluong = dataCart[i].Soluong,
                        Gia = dataCart[i].SanPham.Gia,
                    };
                    _chitiethoadonSvc.AddChiTietHoaDon(chitiet);
                    _sanPhamSvc.GiamSL(chitiet.Masanpham, chitiet.Soluong);
                }
            }
            catch (Exception)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
