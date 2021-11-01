using EnglishExam.Models;
using EnglishExam.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.Services
{
    public class BaseService
    {
        public readonly ContextDatabase _db = new ContextDatabase();
    }
}
