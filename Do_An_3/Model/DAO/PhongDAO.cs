using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class PhongDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public PhongDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        public List<Phong> LayPhong()
        {
            return db.Phong.ToList();
        }
        public List<LoaiSP> LayLSPTheoMaPhong(int? Maphong)
        {
            IQueryable<LoaiSP> lstlsp = db.LoaiSP.Where(n => n.MaLoaiPhong == Maphong);
            return lstlsp.ToList();
        }
    }
}
