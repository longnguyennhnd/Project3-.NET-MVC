using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    class CartDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public CartDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        //public int LuuDDH(DonDatHang t)
        //{
        //    db.DonDatHang.Add(t);
        //}
    }
}
