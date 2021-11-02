using EnglishExam.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.CustomModels
{
    public class NewsModel
    {
        public string Title { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public int OrderNo { get; set; }
        public Exam Exam { get; set; }
    }
}