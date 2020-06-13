using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampathNarayananAssignment1.Models;

namespace BursaryApplication.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Evening";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult BursaryForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult BursaryForm(FormResponse formResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(formResponse);
                return View("Thanks", formResponse);
            }
            else
            {
                //There is a validation error in the form
                return View();
            }
        }
        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.IsInternationalStudent == false));
        }
    }
}