using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IThongKe
    {
        Task<List<SanPham>> SoLuongSanPhamBanDuoc();
        Task<List<SanPham>> SanPhamConLai();
        Task<List<SanPham>> DoanhThu(DateTime from, DateTime to);
        Task<List<KhachHang>> KhachHangThanThiet();

    }
    public class ThongKeSvc
    {
    }
}
