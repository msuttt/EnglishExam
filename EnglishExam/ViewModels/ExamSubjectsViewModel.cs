using EnglishExam.CustomModels;
using EnglishExam.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.ViewModels
{
    public class ExamSubjectsViewModel : BaseViewModel
    {
        public List<NewsModel> News { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
