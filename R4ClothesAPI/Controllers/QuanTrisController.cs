using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Helpers;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanTrisController : ControllerBase
    {
        private readonly IQuanTri _quanTriSvc;
        private readonly ISanPham _sanPhamSvc;
        private readonly IKhachHang _khachHangSvc;
        private readonly IHoaDon _hoaDonSvc;
        private readonly IMaHoaHelper _maHoa;
        public QuanTrisController(IQuanTri quanTriSvc, ISanPham sanPhamSvc, IKhachHang khachHangSvc, IHoaDon hoaDonSvc, IMaHoaHelper maHoa)
        {
            _quanTriSvc = quanTriSvc;
            _sanPhamSvc = sanPhamSvc;
            _khachHangSvc = khachHangSvc;
            _hoaDonSvc = hoaDonSvc;
            _maHoa = maHoa;
        }

        // GET: api/QuanTris
        [HttpGet("dsqt")]
        public List<QuanTri> GetQuanTris()
        {
            return _quanTriSvc.DanhSachQuanTri();
        }

        // GET: api/QuanTris/5
        [HttpGet("get/{id}")]
        public ActionResult<QuanTri> GetQuanTri(int id)
        {
            var quanTri = _quanTriSvc.GetQuanTri(id);

            if (quanTri == null)
            {
                return NotFound();
            }

            return quanTri;
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> SuaQuanTri(int id, [FromBody] QuanTri quanTri)
        {
            if (quanTri == null)
            {
                return NotFound();
            }
            else
            {
                bool flag = await _quanTriSvc.SuaNguoiQuanTri(id, quanTri);
                if (flag)
                {
                    return Ok("Đã sửa");
                }
                else
                {
                    return BadRequest("Lỗi");
                }
            }
        }

        [HttpPost("doimatkhau")]
        public IActionResult DoiMatKhau(int id, string mkcu, string newpwd)
        {
            var qt = new QuanTri();
            qt = _quanTriSvc.GetQuanTri(id);
            if (id != 0 || _maHoa.Mahoa(mkcu) == qt.Matkhau)
            {
                bool flag = _quanTriSvc.DoiMatKhau(id, newpwd);
                if (flag)
                {
                    return Ok("Đã sửa");
                }
                else
                {
                    return BadRequest("Lỗi");
                }
            }
            else
            {
                return BadRequest("Lỗi");
                
            }
        }

        [HttpPost("add")]
        public async Task<QuanTri> ThemQuanTri([FromBody] QuanTri quantri)
        {
            if (quantri != null)
            {
                await _quanTriSvc.ThemQuanTri(quantri);
                return quantri;
            }
            else
            {
                return quantri = null;
            }
        }


        // --- Chức năng của người quản trị
        // Sản phẩm
        [HttpGet("sanpham")]
        public List<SanPham> DSSP()
        {
            return _sanPhamSvc.DanhSachSanPhamAdmin();
        }

        [HttpPost("sanpham/edit")]
        public async Task<bool> SuaSanPham(int idsp, SanPham sp)
        {
            return await _sanPhamSvc.SuaSanPham(idsp, sp);
        }

        // Hóa đơn
        [HttpGet("hoadon/getall")]
        public List<HoaDon> GetAll()
        {
            return _hoaDonSvc.DanhSachHoaDon();
        }
        
        [HttpPost("hoadon/suahd")]
        public bool SuaHoaDon(int idhd, int nguoiql, TrangthaiHD tt)
        {
            return _hoaDonSvc.SuaHoaDon(idhd, nguoiql, tt);
        }

        // Khách hàng
        [HttpPost("khachhang/xoakh/{id}")]
        public bool DeleteKH(int id)
        {
            return _khachHangSvc.XoaKhachHang(id);
        }

        [HttpPost("khachhang/thaydoitt")]
        public async Task<IActionResult> ThayDoiTT(int idkh, KhachHang kh)
        {
            var khachhang = await _khachHangSvc.SuaKhachhang(idkh, kh);
            if (khachhang != null)
            {
                return Ok("Đã cập nhật thành công!");
            }
            else
            {
                return NotFound("Lỗi khi kết nối");
            }
        }
    }
}
