using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IDanhGiaSanPham
    {
        bool AddDanhGiaSanPham(int idsanpham, string danhgia);
        string XemDanhGiaSanPham(int idsanpham);
    }
    public class DanhGiaSanPhamSvc : IDanhGiaSanPham
    {
        public bool AddDanhGiaSanPham(int idsanpham, string danhgia)
        {
            throw new NotImplementedException();
        }

        public string XemDanhGiaSanPham(int idsanpham)
        {
            throw new NotImplementedException();
        }
    }
}
