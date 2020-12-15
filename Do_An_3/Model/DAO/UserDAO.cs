using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.DAO
{
    public class UserDAO
    {
        QuanLyBanNoiThatEntities db = null;
        public UserDAO()
        {
            db = new QuanLyBanNoiThatEntities();
        }
        public int Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.MaUser;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.MaUser);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }    
        }
        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.User.OrderByDescending(x=>x.Name).ToPagedList(page, pageSize);
        }
        public User GetByID(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
    }
}
