using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationsManager.ActionFilters;
using HotelReservationsManager.Models;
using HotelReservationsManager.Repositories;
using HotelReservationsManager.ViewModels.Users;

namespace HotelReservationsManager.Controllers
{
    [AuthenticationFilter]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            HotelReservationsManagerDbContext context = new HotelReservationsManagerDbContext();

            IndexVM model = new IndexVM();
            model.Items = context.Users.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.Surname = model.Surname;
            item.LastName = model.LastName;
            item.EGN = model.EGN;
            item.PhoneNumber = model.PhoneNumber;
            item.Email = model.Email;
            item.DateOfAppointment = model.DateOfAppointment;
            item.IsActive = model.IsActive;
            item.ReleaseDate = null;

            HotelReservationsManagerDbContext context = new HotelReservationsManagerDbContext();
            context.Users.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HotelReservationsManagerDbContext context = new HotelReservationsManagerDbContext();
            User item = context.Users.Where(u => u.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Users");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Username = item.Username;
            model.Password = item.Password;
            model.FirstName = item.FirstName;
            model.Surname = item.Surname;
            model.LastName = item.LastName;
            model.EGN = item.EGN;
            model.PhoneNumber = item.PhoneNumber;
            model.Email = item.Email;
            model.DateOfAppointment = item.DateOfAppointment;
            model.IsActive = item.IsActive;
            model.ReleaseDate = item.ReleaseDate;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.Id = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.Surname = model.Surname;
            item.LastName = model.LastName;
            item.EGN = model.EGN;
            item.PhoneNumber = model.PhoneNumber;
            item.Email = model.Email;
            item.DateOfAppointment = model.DateOfAppointment;
            item.IsActive = model.IsActive;
            item.ReleaseDate = model.ReleaseDate;

            HotelReservationsManagerDbContext context = new HotelReservationsManagerDbContext();
            context.Users.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public IActionResult Delete(int id)
        {
            HotelReservationsManagerDbContext context = new HotelReservationsManagerDbContext();
            User item = new User();
            item.Id = id;

            context.Users.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Users");
        }
    }
}
