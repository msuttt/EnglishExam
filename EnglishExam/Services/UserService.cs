using EnglishExam.Models;
using EnglishExam.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.Services
{
    public class UserService:BaseService
    {
        public List<User> GetUsers()
        {

            return _db.User.ToList();
        }
        public User Insert(User user)
        {
            _db.User.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User GetUserByUserNameAndPassword(string kullanici, string sifre)
        {
            return _db.User.Where(x => x.UserName == kullanici && x.Password == sifre).FirstOrDefault();
        }
    }
}
