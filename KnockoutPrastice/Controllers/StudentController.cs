﻿using Microsoft.AspNetCore.Mvc;

namespace KnockoutPrastice.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
