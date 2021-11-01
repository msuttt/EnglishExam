using EnglishExam.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.ViewModels
{
    public class SolveViewModel
    {
        public List<Exam> Exams { get; set; }

        public List<Question> Questions { get; set; }
    }
}
