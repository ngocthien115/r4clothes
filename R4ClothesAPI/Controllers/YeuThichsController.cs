using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class YeuThichsController : ControllerBase
    {
        private readonly IYeuThich _yeuThichSvc;
        private readonly ISanPham _sanPhamSvc;

        public YeuThichsController(IYeuThich yeuThichSvc, ISanPham sanPhamSvc)
        {
            _yeuThichSvc = yeuThichSvc;
            _sanPhamSvc = sanPhamSvc;
        }

        /// <summary>
        /// Lấy danh sách yêu thích của khách hàng
        /// </summary>
        /// <param name="idkhachhang"></param>
        /// <returns></returns>
        // GET: api/YeuThichs/5
        [HttpGet("khachhang")]
        public List<SanPham> GetYeuThich(int idkhachhang)
        {
            return _sanPhamSvc.LoadYeuThich(idkhachhang);
        }

        /// <summary>
        /// Check yêu thích theo id khách hàng và id sản phẩm
        /// </summary>
        /// <param name="makhachhang"></param>
        /// <param name="masanpham"></param>
        /// <returns></returns>
        [HttpPost("/api/yeuthichs/checkyeuthich")]
        public bool CheckYT(int makhachhang, int masanpham)
        {
            return _yeuThichSvc.CheckYT(makhachhang, masanpham);
        }

        /// <summary>
        /// Thêm yêu thích
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "mayeuthich": 0,
        ///       "makhachhang": 0,
        ///       "masanpham": 0,
        ///     }
    /// </remarks>
    /// <param name="yeuthich"></param>
    /// <returns></returns>
    [HttpPost("/api/yeuthichs/add")]
        public async Task<bool> ThemYT([FromBody] YeuThich yeuthich)
        {
            if (yeuthich != null)
            {
                var res = await _yeuThichSvc.ThemYeuThich(yeuthich);
                if (res != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa yêu thích
        /// </summary>
        /// <param name="masanpham"></param>
        /// <param name="makhachhang"></param>
        /// <returns></returns>
        [HttpPost("/api/yeuthichs/remove")]
        public async Task<bool> RemoveFav(int masanpham, int makhachhang)
        {
            try
            {
                await _yeuThichSvc.XoaYeuThich(masanpham, makhachhang);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}