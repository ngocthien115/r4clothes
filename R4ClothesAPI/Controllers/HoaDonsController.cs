using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Models.ViewModels;
using R4Clothes.Shared.Services;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
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
        /// Lấy thông tin của hóa đơn theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public HoaDon GetHoaDon(int id)
        {
            return _hoadonSvc.GetHoaDon(id);
        }

        /// <summary>
        /// Lấy danh sách hóa đơn theo khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/hoadons/khachhang/{id}")]
        public List<HoaDon> DSDHByKH(int id)
        {
            return _hoadonSvc.DanhSachHoaDonTheoKhachHang(id);
        }

        /// <summary>
        /// Đặt hàng(Thêm 1 đơn hàng)
        /// </summary>
        /// <remarks>
        ///     Dữ liệu mẫu
        ///
        ///         {
        ///           "makhachhang": 1,
        ///           "listViewCart": [
        ///             {
        ///         	    "sanPham": {
        ///         	        "masanpham": 2,
        ///         	        "maquantri": 1,
        ///         	        "tensanpham": "Áo test 1",
        ///         	        "maloai": 1,
        ///         	        "soluong": 10,
        ///         	        "gia": 15000,
        ///         	        "hinh": "string",
        ///         	        "soluotxem": 0,
        ///         	        "ngaynhap": "2021-11-14T11:24:42.714",
        ///         	        "giamgia": 0,
        ///         	        "mota": "string",
        ///         	        "trangthai": true,
        ///         	        "dacbiet": true,
        ///         	        "quanTris": null,
        ///         	        "loaiSanPhams": null,
        ///         	        "chiTietHoaDons": null
        ///                 },
        ///                 "soluong": 3
        ///             },
        ///             {
        ///             "sanPham": {
        ///                 "masanpham": 1,
        ///             	"maquantri": 1,
        ///             	"tensanpham": "Áo test",
        ///             	"maloai": 1,
        ///             	"soluong": 10,
        ///             	"gia": 15000,
        ///             	"hinh": "string",
        ///             	"soluotxem": 0,
        ///             	"ngaynhap": "2021-11-14T11:24:42.714",
        ///             	"giamgia": 0,
        ///             	"mota": "string",
        ///             	"trangthai": true,
        ///             	"dacbiet": true,
        ///             	"quanTris": null,
        ///             	"loaiSanPhams": null,
        ///             	"chiTietHoaDons": null
        ///               },
        ///               "soluong": 2
        ///             }
        ///           ],
        ///           "tongtien": 225000
        ///         }
        /// </remarks>
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
                    Nguoiquantri = 1,
                    Tongtien = GioHang.Tongtien,
                    Ngaydat = DateTime.Now,
                };
                int Mahoadon = _hoadonSvc.AddHoaDon(hoadon);

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
                    //_sanPhamSvc.GiamSL(chitiet.Masanpham, chitiet.Soluong);
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