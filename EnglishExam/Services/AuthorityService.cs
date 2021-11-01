using EnglishExam.Models;
using EnglishExam.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.Services
{
    public class AuthorityService : BaseService
    {
        public List<Authority> GetAuthorities()
        {

            return _db.Authority.ToList();
        }
        public Authority Insert(Authority authority)
        {
            _db.Authority.Add(authority);
            _db.SaveChanges();
            return authority;
        }
    }
}
