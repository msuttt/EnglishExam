using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using EnglishExam.Services;
using EnglishExam.Models.Entities;
using EnglishExam.Helpers;
using EnglishExam.ViewModels;

namespace EnglishExam.Controllers
{
    public class ExamController : Controller
    {
        private readonly AuthorityService _authorityService = new AuthorityService();
        private readonly UserService _userService = new UserService();
        private readonly ExamService _examService = new ExamService();
        private readonly WiredCrawler _wiredCrawler = new WiredCrawler();

        public IActionResult Login()
        {
            Authority defaultAuthority = new Authority();
            defaultAuthority.AuthorityName = "Yönetici";
            _authorityService.Insert(defaultAuthority);

            User defaultUser = new User();
            defaultUser.UserName = "Mesut";
            defaultUser.Password = "123";
            defaultUser.AuthorityId = 1;
            _userService.Insert(defaultUser);

            return View();

        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            TempData["NoUser"] = string.Empty;
            username = Request.Form["kullaniciadi"];
            password = Request.Form["sifre"];

            var user = _userService.GetUserByUserNameAndPassword(username, password);
            if (user == null)
            {

                TempData["NoUser"] = "Böyle bir kullanıcı bulunmamaktadır";
            }

            else
            {
                
                return RedirectToAction("Index");
            }
            return View();
            

        }
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Exams = _examService.GetExams();
            return View(model);
           
        }

        //[HttpPost]
        //public IActionResult Index(int id)
        //{
        //    //var exam=_examService.GetExamById(id);
        //    //var question = _examService.GetQuestionByExamId(id);

        //    //_examService.QuestionDelete(question);
        //    //_examService.ExamDelete(exam);

        //    return View();

        //}

        //public IActionResult Delete()
        //{
          
        //    return View();

        //}

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var exam = _examService.GetExamById(id);
            var question = _examService.GetQuestionByExamId(id);

            _examService.QuestionDelete(question);
            _examService.ExamDelete(exam);

            return RedirectToAction("Index");

        }

        public IActionResult CreateExam(string title, int id)
        {
            var model = new CreateExamViewModel();
            var selectedNews = _wiredCrawler.GetLast5News().FirstOrDefault(x => x.Title == title);
            selectedNews.Content = _wiredCrawler.GetContent(selectedNews.To);
            model.Exam = id > 0 ? _examService.GetExamById(id) : new Exam() { Content = selectedNews.Content, Title = selectedNews.Title };

            return View(model);
        }
        [HttpPost]

        public IActionResult CreateExam(CreateExamPostViewModel postModel)
        {
            var exam = _examService.Insert(postModel.Exam);
            foreach (var question in postModel.Questions)
            {
                question.ExamId = exam.Id;
                _examService.QuestionInsert(question);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Subjects()
        {
            var model = new ExamSubjectsViewModel();
            model.News = _wiredCrawler.GetLast5News();
            return View(model);
        }

       
        public IActionResult SolveExam(string title)
        {
            var exam = _examService.GetExamByTitle(title);
            var question = _examService.GetQuestionByExamId(exam.Id);

            List<Exam> exams = new List<Exam>();
            exams.Add(exam);

            SolveandCheckViewModel solveViewModel = new SolveandCheckViewModel();
            solveViewModel.Exams = exams;
            solveViewModel.Questions = question;

            return View(solveViewModel);
        }

        //[HttpPost]
        //public IActionResult SolveExam()
        //{


        //    //var exam = _examService.GetExamByTitle(title);
        //    //var question = _examService.GetQuestionByExamId(exam.Id);

        //    //List<Exam> exams = new List<Exam>();
        //    //exams.Add(exam);

        //    //SolveandCheckViewModel checkViewModel = new SolveandCheckViewModel();
        //    //checkViewModel.Exams = exams;
        //    //checkViewModel.Questions = question;
        //    //checkViewModel.UserAnswers = answers;

        //    return RedirectToAction("SolveExam");
        //}


    }
}
