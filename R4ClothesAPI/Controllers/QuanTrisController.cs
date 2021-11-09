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
        [HttpGet]
        public List<QuanTri> GetQuanTris()
        {
            return _quanTriSvc.DanhSachQuanTri();
        }

        // GET: api/QuanTris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuanTri>> GetQuanTri(int id)
        {
            var quanTri = await _quanTriSvc.GetQuanTri(id);

            if (quanTri == null)
            {
                return NotFound();
            }

            return quanTri;
        }

        [HttpPost("/api/quantris/edit")]
        public async Task<IActionResult> SuaQuanTri(int id, [FromBody] QuanTri quanTri)
        {
            if (id != quanTri.Maquantri)
            {
                return NotFound();
            }
            else
            {
                var qt = await _quanTriSvc.GetQuanTri(id);
                if (qt == null)
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
        }

        [HttpPost("/api/quantris/add")]
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
    }
}
