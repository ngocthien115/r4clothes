using R4Clothes.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4Clothes.Shared.Services
{
    public interface IQuanTri
    {
        bool Login();
        List<QuanTri> DanhSachQuanTri();
        bool XoaNguoiQuanTri(int idnguoiquantri);
    }
    public class QuanTriSvc : IQuanTri
    {
        public List<QuanTri> DanhSachQuanTri()
        {
            throw new NotImplementedException();
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public bool XoaNguoiQuanTri(int idnguoiquantri)
        {
            throw new NotImplementedException();
        }
    }
}
