using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
using Model.DAO;


namespace Do_An_3.Businiess
{
    public class XemSanPhamBus
    {
        SanPhamDAO dao = new SanPhamDAO();
        public List<Sanpham> XemSPTheoLoai(int? maphong, int? maloai)
        {
            return dao.LaySPTheoMaLoai(maphong, maloai);
        }
        public Sanpham Lay1SP(int? maSP)
        {
            return dao.Lay1SP(maSP);
        }
    }
}