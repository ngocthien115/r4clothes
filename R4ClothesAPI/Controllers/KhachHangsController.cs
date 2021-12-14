using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System.Threading.Tasks;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
    public class KhachHangsController : ControllerBase
    {
        private IKhachHang _khachhangSvc;

        public KhachHangsController(IKhachHang khachHang)
        {
            _khachhangSvc = khachHang;
        }

        /// <summary>
        /// Thêm một khách hàng(Đăng ký)
        /// </summary>
        /// <param name="khachhang"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostKhachHang([FromBody] KhachHang khachhang)
        {
            if (khachhang != null)
            {
                if (_khachhangSvc.isExist(khachhang.Email))
                {
                    return BadRequest(-1); // Email đã được sử dụng
                }
                else
                {
                    await _khachhangSvc.AddKhachhang(khachhang);
                    return Ok("Đã thêm thành công");
                }
            }
            else
            {
                return BadRequest(-2);
            }
        }

        /// <summary>
        /// Lấy thông tin 1 khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<KhachHang> GetKhachhang(int id)
        {
            return await _khachhangSvc.GetKhachhang(id);
        }

        /// <summary>
        /// Sửa khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kh"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ChinhSuaKH(int id, [FromBody] KhachHang kh)
        {
            if (await _khachhangSvc.SuaKhachhang(id, kh) != null)
            {
                return Ok("Đã sửa thành công");
            }
            else
            {
                return NotFound("Lỗi khi sửa");
            }
        }

        /// <summary>
        /// Quên mật khẩu
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("quenmatkhau")]
        public Task<bool> QuenMatKhau(string email)
        {
            return _khachhangSvc.QuenMatKhau(email);
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="idkhachhang"></param>
        /// <param name="oldpwd"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        [HttpPost("doimatkhau")]
        public Task<bool> DoiMatKhau(int idkhachhang, string oldpwd, string newpwd)
        {
            return _khachhangSvc.DoiMatKhau(idkhachhang, oldpwd, newpwd);
        }
    }
}