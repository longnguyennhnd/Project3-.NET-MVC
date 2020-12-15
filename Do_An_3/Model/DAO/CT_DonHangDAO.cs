using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CT_DonHangDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public CT_DonHangDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        public List<CT_DonDatHang> LayBanGhi(int? maDH)
        {
            return db.CT_DonDatHang.Where(x => x.MaDDH == maDH).ToList();
        }
    }
}
