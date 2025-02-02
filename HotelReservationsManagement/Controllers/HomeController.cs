using HotelReservationsManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManager.ActionFilters;
using HotelReservationsManager.Repositories;
using HotelReservationsManager.ViewModels.Home;
using HotelReservationsManager.ExtentionMethods;

namespace HotelReservationsManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!this.ModelState.IsValid)
                return View(model);

            HotelReservationsManagerDbContext context = new HotelReservationsManagerDbContext();
            User loggedUser = context.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Невалидни входни данни!");
                return View(model);
            }
            else if (loggedUser.ReleaseDate != null)
            {
                this.ModelState.AddModelError("releasedError", "Вашият акаунт няма достъп до системата!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");
        }

        [AuthenticationFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }
    }
}
