using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationsManagement.ActionFilters;
using HotelReservationsManagement.Models;
using HotelReservationsManagement.Repositories;
using HotelReservationsManagement.ViewModels.Reservations;
using HotelReservationsManagement.ExtentionMethods;

namespace HotelReservationsManagement.Controllers
{
    public class ReservationsController : Controller
    {
        public IActionResult Index()
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            IndexVM model = new IndexVM();
            model.Items = context.Reservations.ToList();

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
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");

            if (!ModelState.IsValid)
                return View(model);

            Reservation item = new Reservation();
            item.UserId = loggedUser.Id;
            item.DateArrive = model.DateArrive;
            item.DateDepart = model.DateDepart;
            item.HasBreakfast = model.HasBreakfast;
            item.IsAllInclusive = model.IsAllInclusive;
            item.FinalPrice = model.FinalPrice;
            item.ClientId = model.ClientId;
            item.RoomId = model.RoomId;

            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            int dateArrive = item.DateArrive.Year + item.DateArrive.Month + item.DateArrive.Day;
            int dateDepart = item.DateDepart.Year + item.DateDepart.Month + item.DateDepart.Day;
            Room room = context.Rooms.Where(u => u.Id == item.RoomId).FirstOrDefault();
            int daysOfStay = dateDepart - dateArrive;
            var dayPrice = room.PriceForAdult * item.AdultsCount + room.PriceForChild * item.ChildsCount;
            item.FinalPrice = daysOfStay * dayPrice;

            context.Reservations.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Reservations");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Reservation item = context.Reservations.Where(u => u.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Reservations");

            Reservation model = new Reservation();
            model.UserId = loggedUser.Id;
            model.DateArrive = item.DateArrive;
            model.DateDepart = item.DateDepart;
            model.HasBreakfast = item.HasBreakfast;
            model.IsAllInclusive = item.IsAllInclusive;
            model.FinalPrice = item.FinalPrice;
            model.ClientId = item.ClientId;
            model.RoomId = item.RoomId;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");

            if (!ModelState.IsValid)
                return View(model);

            Reservation item = new Reservation();

            if (item.UserId != loggedUser.Id)
            {
                ModelState.AddModelError("summaryError", "Нямате разрешение за това действие!");

                return View(model);
            }

            if (model.UserId != loggedUser.Id)
            {
                ModelState.AddModelError("summaryError", "Нямате разрешение за това действие!");
                return View(model);
            }

            item.UserId = loggedUser.Id;
            item.DateArrive = model.DateArrive;
            item.DateDepart = model.DateDepart;
            item.HasBreakfast = model.HasBreakfast;
            item.IsAllInclusive = model.IsAllInclusive;
            item.FinalPrice = model.FinalPrice;
            item.ClientId = model.ClientId;
            item.RoomId = model.RoomId;

            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            context.Reservations.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Reservations");
        }

        public IActionResult Delete(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Reservation item = new Reservation();
            item.Id = id;

            context.Reservations.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Reservations");
        }
    }
}
