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
    public class ChiTietHoaDonsController : ControllerBase
    {
        private readonly ChiTietHoaDonSvc _chiTietHoaDonSvc;
        private readonly HoaDonSvc _hoaDonSvc;

        public ChiTietHoaDonsController(ChiTietHoaDonSvc chiTietHoaDonSvc ,HoaDonSvc hoaDonSvc )
        {
            _chiTietHoaDonSvc = chiTietHoaDonSvc;
            _hoaDonSvc = hoaDonSvc;
        }

        // GET: api/ChiTietHoaDons
        
        //public async Task<ActionResult<IEnumerable<ChiTietHoaDon>>> GetChiTietHoaDons()
        //{
        //    return await _context.ChiTietHoaDons.ToListAsync();
        //}

        // GET: api/ChiTietHoaDons/5
        [HttpGet("{id}")]
        public List<ViewDetails> GetChiTiet(int id)
        {
           return _chiTietHoaDonSvc.GetChiTiet(id);
        }
      
            // PUT: api/ChiTietHoaDons/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

            //private bool ChiTietHoaDonExists(int id)
            //{
            //    return _context.ChiTietHoaDons.Any(e => e.MaChiTietHoaDon == id);
            //}
        }
}
