using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sqlapp.Models;
using sqlapp.Services;

namespace sqlapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _course_service;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, CourseService _svc, IConfiguration _config)
        {
            _logger = logger;
            _course_service = _svc;
            _configuration = _config;
        }

        public IActionResult Index()
        {
            //IEnumerable<Course> _course_list = _course_service.GetCourses(_configuration.GetConnectionString("SqlConnection"));
            return View();
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
