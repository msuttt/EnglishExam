using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishExam.CustomModels
{
    public class NewExam
    {
        public List<string> newQuestions { get; set; }
        public List<string> newAnswers { get; set; }
        public string newTitle { get; set; }
        public string newContent { get; set; }

    }
}