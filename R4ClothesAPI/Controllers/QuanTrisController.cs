using Microsoft.AspNetCore.Mvc;
using R4Clothes.Shared.Helpers;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Lấy danh sách người quản trị
        /// </summary>
        /// <returns></returns>
        // GET: api/QuanTris
        [HttpGet("dsqt")]
        public List<QuanTri> GetQuanTris()
        {
            return _quanTriSvc.DanhSachQuanTri();
        }

        /// <summary>
        /// Thông tin chi tiết của người quản trị theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sửa người quản trị
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "masanpham": 0,
        ///       "maquantri": 0,
        ///       "tensanpham": "string",
        ///       "maloai": 0,
        ///       "soluong": 0,
        ///       "gia": 0,
        ///       "hinh": "string",
        ///       "soluotxem": 0,
        ///       "ngaynhap": "2021-11-14T14:15:19.603Z",
        ///       "giamgia": 0,
        ///       "mota": "string",
        ///       "trangthai": true,
        ///       "dacbiet": true
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="quanTri"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mkcu"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Thêm người quản trị
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "masanpham": 0,
        ///       "maquantri": 0,
        ///       "tensanpham": "string",
        ///       "maloai": 0,
        ///       "soluong": 0,
        ///       "gia": 0,
        ///       "hinh": "string",
        ///       "soluotxem": 0,
        ///       "ngaynhap": "2021-11-14T14:15:19.603Z",
        ///       "giamgia": 0,
        ///       "mota": "string",
        ///       "trangthai": true,
        ///       "dacbiet": true
        ///     }
        /// </remarks>
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

        /// <summary>
        /// Danh sách sản phẩm đầy đủ
        /// </summary>
        /// <returns></returns>
        [HttpGet("sanpham")]
        public List<SanPham> DSSP()
        {
            return _sanPhamSvc.DanhSachSanPhamAdmin();
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "masanpham": 0,
        ///       "maquantri": 1,
        ///       "tensanpham": "Áo khoác XD",
        ///       "maloai": 3,
        ///       "soluong": 10,
        ///       "gia": 15000,
        ///       "hinh": "string",
        ///       "soluotxem": 0,
        ///       "ngaynhap": "2021-11-14T12:08:46.327Z",
        ///       "giamgia": 0,
        ///       "mota": "string",
        ///       "trangthai": true,
        ///       "dacbiet": true
        ///     }
        /// </remarks>
        /// <param name="sanpham"></param>
        /// <returns></returns>
        [HttpPost("sanpham/add")]
        public async Task<SanPham> ThemSanPham([FromBody] SanPham sanpham)
        {
            return await _sanPhamSvc.AddSanPham(sanpham);
        }

        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <remarks>
        /// Dữ liệu mẫu
        /// 
        ///     {
        ///       "masanpham": 0,
        ///       "maquantri": 1,
        ///       "tensanpham": "Áo khoác XD",
        ///       "maloai": 3,
        ///       "soluong": 10,
        ///       "gia": 15000,
        ///       "hinh": "string",
        ///       "soluotxem": 0,
        ///       "ngaynhap": "2021-11-14T12:08:46.327Z",
        ///       "giamgia": 0,
        ///       "mota": "string",
        ///       "trangthai": true,
        ///       "dacbiet": true
        ///     }
        /// </remarks>
        [HttpPost("sanpham/edit")]
        public async Task<bool> SuaSanPham(int idsp, SanPham sp)
        {
            return await _sanPhamSvc.SuaSanPham(idsp, sp);
        }
        /// <summary>
        /// Lấy danh sách hóa đơn
        /// </summary>
        /// <returns></returns>
        [HttpGet("hoadon/getall")]
        public List<HoaDon> GetAll()
        {
            return _hoaDonSvc.DanhSachHoaDon();
        }

        /// <summary>
        /// Sửa trạng thái hóa đơn
        /// </summary>
        /// <param name="idhd"></param>
        /// <param name="nguoiql"></param>
        /// <param name="tt"></param>
        /// <returns></returns>
        [HttpPost("hoadon/suahd")]
        public bool SuaHoaDon(int idhd, int nguoiql, TrangthaiHD tt)
        {
            return _hoaDonSvc.SuaHoaDon(idhd, nguoiql, tt);
        }

        /// <summary>
        /// Lấy danh sách hóa đơn theo trạng thái
        /// </summary>
        /// <param name="tt"></param>
        /// <returns></returns>
        [HttpGet("dshdtheott")]
        public List<HoaDon> DanhSachHoaDonTheoTT(TrangthaiHD tt)
        {
            return _hoaDonSvc.DanhSachHoaDonStatus(tt);
        }

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet("khachhang/ds")]
        public async Task<List<KhachHang>> DanhSachKH()
        {
            return await _khachHangSvc.DanhSachKhachHang();
        }

        /// <summary>
        /// Xóa khách hàng theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("khachhang/xoakh/{id}")]
        public bool DeleteKH(int id)
        {
            return _khachHangSvc.XoaKhachHang(id);
        }

        /// <summary>
        /// Thay đổi trạng thái tài khoản khách hàng
        /// </summary>
        /// <param name="idkh"></param>
        /// <param name="tt"></param>
        /// <returns></returns>
        [HttpPost("khachhang/thaydoitt")]
        public async Task<IActionResult> ThayDoiTT(int idkh, bool tt)
        {
            bool khachhang = await _khachHangSvc.ThayDoiTrangThai(idkh, tt);
            if (khachhang == true)
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