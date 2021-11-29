using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRecordViewerApp.Models;
using SutdentRecordViewer.BL;
using System;
using System.Diagnostics;

namespace StudentRecordViewerApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentDetail _studentdetails;

        public HomeController(ILogger<HomeController> logger, IStudentDetail studentDetail)
        {
            _logger = logger;
            _studentdetails = studentDetail;
        }

        public IActionResult Index()
        {
            return View(new StudentInputData());
        }

        [HttpPost]
        public IActionResult Index(StudentInputData student)
        {
            try
            {
                var studentRetrieved = _studentdetails.GetStudent(student.StudentData.StudentId.ToString());
                if (studentRetrieved == null)
                {
                    return View(new StudentInputData { IsSuccessful = false });
                }

                return View(new StudentInputData
                {
                    IsSuccessful = true,
                    StudentData = studentRetrieved,
                });
            }
            catch (Exception ex)
            {
                return View(new StudentInputData
                {
                    IsSuccessful = false,
                    FeedbackMessage = ex.Message
                });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
