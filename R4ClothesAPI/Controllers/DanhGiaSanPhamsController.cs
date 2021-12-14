using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using R4Clothes.Shared.Models.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
    public class DanhGiaSanPhamsController : ControllerBase
    {
        private IDanhGiaSanPham _danhgiasanpham;

        public DanhGiaSanPhamsController(IDanhGiaSanPham danhgiasanpham)
        {
            _danhgiasanpham = danhgiasanpham;
        }

        /// <summary>
        /// Danh sách đánh giá một sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<List<DanhGiaSanPhamReturn>> DanhGiaSanPhamTheoIDSP(int id)
        {
            return await _danhgiasanpham.DanhGiaSanPhamTheoIDSP(id);
        }

        /// <summary>
        /// Đánh giá 1 sản phẩm
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "maDanhGiaSanPham": 0,
        ///       "makhachhang": 0,
        ///       "masanpham": 0,
        ///       "thoigian": "2021-11-14T14:13:26.692Z",
        ///       "noidung": "string"
        ///     }
        /// </remarks>
        /// <param name="danhgiasanpham"></param>
        /// <returns></returns>
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