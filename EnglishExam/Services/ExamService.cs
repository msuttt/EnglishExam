using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EnglishExam.Models.Entities;

namespace EnglishExam.Services
{
    public class ExamService : BaseService
    {
        public List<Exam> GetExams()
        {

            return _db.Exam.ToList();
        }
        public Exam Insert(Exam exam)
        {
            exam.Date = DateTime.Now;
            _db.Exam.Add(exam);
            _db.SaveChanges();
            return exam;
        }
        public bool CheckTitle(string title)
        {
            return _db.Exam.Any(x => x.Title == title);
        }

        public Exam GetExamById(int id)
        {
            return _db.Exam.Single(x => x.Id == id);
        }

        public Exam GetExamByTitle(string title)
        {
            return _db.Exam.Single(x => x.Title == title);
        }
 
        public Question GetQuestionById(int id)
        {
            return _db.Question.Single(x => x.Id == id);
        }
        public List<Question> GetQuestionByExamId(int id)
        {
            return _db.Question.Where(x => x.ExamId == id).ToList();
        }

        public Question QuestionInsert(Question question)
        {
         
            _db.Question.Add(question);
            _db.SaveChanges();
            return question;
        }

        public List<Question> QuestionDelete(List<Question> question)
        {
            var questionEntry = _db.Entry(question);
            questionEntry.State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Deleted;
            _db.SaveChanges();
            return question;
        }

        public Exam ExamDelete(Exam exam)
        {
            
            var examEntry=_db.Entry(exam);
            examEntry.State= (Microsoft.EntityFrameworkCore.EntityState)EntityState.Deleted;
            _db.SaveChanges();
            return exam;
        }
    }
}
