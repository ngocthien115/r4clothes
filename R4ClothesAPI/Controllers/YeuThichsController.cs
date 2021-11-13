using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R4Clothes.Shared.Models;
using R4Clothes.Shared.Services;

namespace R4ClothesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class YeuThichsController : ControllerBase
    {
        private readonly IYeuThich _yeuThichSvc;
        private readonly ISanPham _sanPhamSvc;
        public YeuThichsController(IYeuThich yeuThichSvc, ISanPham sanPhamSvc)
        {
            _yeuThichSvc = yeuThichSvc;
            _sanPhamSvc = sanPhamSvc;
        }

        // GET: api/YeuThichs/5
        [HttpGet("khachhang/{id}")]
        public List<SanPham> GetYeuThich(int idkhachhang)
        {
            return _sanPhamSvc.LoadYeuThich(idkhachhang);
        }

        [HttpPost("/api/yeuthichs/checkyeuthich")]
        public bool CheckYT(int makhachhang, int masanpham)
        {
            return _yeuThichSvc.CheckYT(makhachhang, masanpham);
        }

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
