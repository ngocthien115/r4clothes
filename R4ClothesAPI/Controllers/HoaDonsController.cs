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

        public HoaDonsController(IHoaDon hoaDonSvc, IChiTietHoaDon chiTietHoaDonSvc)
        {
            _hoadonSvc = hoaDonSvc;
            _chitiethoadonSvc = chiTietHoaDonSvc;
        }

        // GET: api/hoadons
        [HttpGet("{id}")]
        public List<HoaDon> DSDH(int id)
        {
            return  _hoadonSvc.DanhSachHoaDonTheoKhachHang(id);

        }
        // PUT: api/hoadons/5
        [HttpPut("{id}")]
        public bool ChinhSuaHD(int id, [FromBody] HoaDon hd)
        {
            return  _hoadonSvc.SuaHoaDon(id, hd);
        }
        [HttpGet]
        public List<HoaDon> DSDHST(TrangthaiHD tt)
        {
            return _hoadonSvc.DanhSachHoaDonStatus(tt);
        }
        [HttpPost]
        public IActionResult PostCart(Cart GioHang)
        {
            try
            {
                var hoadon = new HoaDon()
                {
                    Trangthai = TrangthaiHD.Dangchoxuli,
                    Makhachhang = GioHang.Makhachhang,
                    Tongtien = GioHang.Tongtien,
                    Ngaydat = DateTime.Now,
                };
                int Mahoadon =  _hoadonSvc.AddHoaDon(hoadon);
                hoadon.Mahoadon = Mahoadon;

                List<CartItem> dataCart = GioHang.ListViewCart;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    ChiTietHoaDon chitiet = new ChiTietHoaDon()
                    {
                        Mahoadon = Mahoadon,
                        Masanpham = dataCart[i].SanPham.Masanpham,
                        Soluong = dataCart[i].Trangthai,
                        Gia = dataCart[i].SanPham.Gia * dataCart[i].Trangthai,
                    };
                    _chitiethoadonSvc.AddChiTietHoaDon(chitiet);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }

    }
}
