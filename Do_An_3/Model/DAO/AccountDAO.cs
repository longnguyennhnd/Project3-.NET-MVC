using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AccountDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public AccountDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }

        public int Insert(ClientAccount entity)
        {
            db.ClientAccount.Add(entity);
            db.SaveChanges();
            return entity.IDAcount;
        }

        public int Login(string userName, string passWord)
        {
            var result = db.ClientAccount.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == passWord)
                    return 1;
                else
                    return -2;
            }   
        }

        public bool CheckUserName(string userName)
        {
            return db.ClientAccount.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckUserEmail(string email)
        {
            return db.ClientAccount.Count(x => x.Email == email) > 0;
        }
        public ClientAccount GetByID(string userName)
        {
            return db.ClientAccount.SingleOrDefault(x => x.UserName == userName);
        }
    }
}
