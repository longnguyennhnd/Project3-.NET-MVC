using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class LoaiSPDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public LoaiSPDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        public List<LoaiSP> LayLoaiSP()
        {
            return db.LoaiSP.ToList();
        }
    }
}
