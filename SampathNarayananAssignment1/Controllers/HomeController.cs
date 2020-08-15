using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BursaryApplication.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public ViewResult ListResponses()
        {
            EFRepository repo = new EFRepository(context);
            return View(repo.Responses.Where(r => r.IsInternationalStudent == false));
        }

        // Edit Action
        public ViewResult Edit(int responseId)
        {
            EFRepository repo = new EFRepository(context);
            return View(repo.Responses.FirstOrDefault(p => p.Id == responseId));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(FormResponse response)
        {
            EFRepository repo = new EFRepository(context);
            if (ModelState.IsValid)
            {
                repo.AddResponse(response);
                TempData["message"] = $"{response.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                // There is something wrong with the data values
                return View(response);
            }
        }

        [HttpPost]
        public IActionResult Delete(int responseId)
        {
            EFRepository repo = new EFRepository(context);
            FormResponse deletedProduct = repo.DeleteResponse(responseId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("ListResponses");
        }

        public ViewResult Privacy()
        {
            return View();
        }
    }
}