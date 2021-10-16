using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IChiTietHoaDon
    {
        bool AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon);
        string GetChiTiet(int maHoaDon); // list ViewDetails

    }
    public class ChiTietHoaDonSvc : IChiTietHoaDon
    {
        public bool AddChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            throw new NotImplementedException();
        }

        public string GetChiTiet(int maHoaDon)
        {
            throw new NotImplementedException();
        }
    }
}
