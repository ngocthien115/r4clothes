using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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
        /// Danh sách sản phẩm trên trang chủ
        /// </summary>
        /// <returns></returns>
        [HttpGet("dssanpham")]
        public List<SanPham> GetSanPhamAll()
        {
            return _sanPhamSvc.DanhSachSanPham();
        }

        /// <summary>
        /// Chia sẻ sản phẩm
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "maKhachHang": 1,
        ///       "emailNguoiNhan": "nthien390@gmail.com",
        ///       "maSanPham": 1,
        ///       "hoTen": "ngocthien",
        ///       "linkSP": "http://google.com/image1",
        ///       "thoiGian": "2021-11-14T12:35:21.066Z"
        ///     }
        /// </remarks>
        /// <param name="chiase"></param>
        /// <returns></returns>
        [Authorize(Roles ="User")]
        [HttpPost("chiase")]
        public bool ChiaSeSanPham(ChiaSe chiase)
        {
            return _chiaSeSvc.AddChiaSe(chiase);
        }

        /// <summary>
        /// Thông tin chi tiết 1 sản phẩm theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public SanPham GetSanPham(int id)
        {
            return _sanPhamSvc.GetSanPham(id);
        }

        /// <summary>
        /// Danh sách sản phẩm liên quan
        /// </summary>
        /// <param name="loaisp"></param>
        /// <returns></returns>
        [HttpGet("splienquan")]
        public List<SanPham> SanPhamLienQuan(int loaisp)
        {
            return _sanPhamSvc.SanPhamLienQuan(loaisp);
        }

        /// <summary>
        /// Danh sách sản phẩm đặc biệt
        /// </summary>
        /// <returns></returns>
        [HttpGet("spdacbiet")]
        public List<SanPham> SanPhamDacBiet()
        {
            return _sanPhamSvc.SanPhamDacBiet();
        }

        /// <summary>
        /// Danh sách sản phẩm giảm giá
        /// </summary>
        /// <param name="giamgia"></param>
        /// <returns></returns>
        [HttpGet("spgiamgia")]
        public List<SanPham> SanPhamGiamGIa(int giamgia)
        {
            return _sanPhamSvc.SanPhamGiamGia(giamgia);
        }
    }
}