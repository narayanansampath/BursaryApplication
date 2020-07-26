using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BursaryApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampathNarayananAssignment1.Models;

namespace BursaryApplication.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;

        public HomeController(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour;
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
            EFRepository repository = new EFRepository(context);
            if (ModelState.IsValid)
            {
                repository.AddResponse(formResponse);
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
            EFRepository repo = new EFRepository(context);
            return View(repo.Responses.Where(r => r.IsInternationalStudent == false));
        }

        public ViewResult Privacy()
        {
            return View();
        }
    }
}