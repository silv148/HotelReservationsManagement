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
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            CreateVM model = new CreateVM();
            model.UserId = loggedUser.Id;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            if (!ModelState.IsValid)
                return View(model);

            Reservation item = new Reservation();

            Client client = context.Clients.FirstOrDefault(x => x.FirstName == model.ClientFirstName && x.LastName == model.ClientLastName && x.PhoneNumber == model.ClientPhone);
            Room room = context.Rooms.FirstOrDefault(x => x.RoomNumber == model.RoomNumber);
            item.Client = client;
            item.ClientId = item.Client.Id;
            item.Room = room;
            item.RoomId = item.Room.Id;
            item.RoomNumber = room.RoomNumber;
            item.UserId = loggedUser.Id;
            item.Username = loggedUser.Username;
            item.DateArrive = model.DateArrive;
            item.DateDepart = model.DateDepart;
            item.HasBreakfast = model.HasBreakfast;
            item.IsAllInclusive = model.IsAllInclusive;
            item.ChildsCount = model.NumberChildren < 0 ? 0 : model.NumberChildren;
            item.AdultsCount = room.Capacity - model.NumberChildren;

            int dateArrive = item.DateArrive.Year + item.DateArrive.Month + item.DateArrive.Day;
            int dateDepart = item.DateDepart.Year + item.DateDepart.Month + item.DateDepart.Day;
            int daysOfStay = dateDepart - dateArrive;
            var dayPrice = item.Room.PriceForAdult * item.AdultsCount + item.Room.PriceForChild * item.ChildsCount;
            var finalPrice = daysOfStay * dayPrice;

            if (item.IsAllInclusive)
            {
                var priceForChild = (dayPrice + 60)*item.Room.Capacity;
                finalPrice = daysOfStay * dayPrice;
            }
            else if (item.HasBreakfast)
            {
                var priceForChild = (dayPrice + 20) * item.Room.Capacity;
                finalPrice = daysOfStay * dayPrice;
            }

            item.FinalPrice = finalPrice;
            item.Room.IsAvailable = false;

            context.Reservations.Add(item);
            client.Reservations.Add(item);

            context.Clients.Update(client);
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

            EditVM model = new EditVM();

            Client client = context.Clients.FirstOrDefault(x => x.Id == item.ClientId);
            model.Id = item.Id;
            model.Client = client;
            model.ClientFirstName = client.FirstName;
            model.ClientLastName = client.LastName;
            model.ClientPhone = client.PhoneNumber;
            model.RoomNumber = model.RoomNumber;
            model.UserId = item.UserId;
            model.IsAllInclusive = item.IsAllInclusive;
            model.HasBreakfast = item.HasBreakfast;
            model.NumberChildren = item.ChildsCount;
            model.DateDepart = item.DateDepart;
            model.DateArrive = item.DateArrive;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            User loggedUser = this.HttpContext.Session.GetObject<User>("loggedUser");
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Reservation item = context.Reservations.Where(u => u.Id == model.Id)
                                     .FirstOrDefault();
            if (!ModelState.IsValid)
                return View(model);


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

            Client client = context.Clients.FirstOrDefault(x => x.FirstName == model.ClientFirstName && x.LastName == model.ClientLastName && x.PhoneNumber == model.ClientPhone);

            Room room = context.Rooms.FirstOrDefault(x => x.RoomNumber == model.RoomNumber);

            item.Client = model.Client;
            item.ClientId = item.Client.Id;
            item.Room = room;
            item.RoomId = item.Room.Id;
            item.RoomNumber = room.RoomNumber;
            item.UserId = loggedUser.Id;
            item.Username = loggedUser.Username;
            item.DateArrive = model.DateArrive;
            item.DateDepart = model.DateDepart;
            item.HasBreakfast = model.HasBreakfast;
            item.IsAllInclusive = model.IsAllInclusive;
            item.ChildsCount = model.NumberChildren < 0 ? 0 : model.NumberChildren;
            item.AdultsCount = room.Capacity - model.NumberChildren;

            int dateArrive = item.DateArrive.Year + item.DateArrive.Month + item.DateArrive.Day;
            int dateDepart = item.DateDepart.Year + item.DateDepart.Month + item.DateDepart.Day;
            int daysOfStay = dateDepart - dateArrive;
            var dayPrice = item.Room.PriceForAdult * item.AdultsCount + item.Room.PriceForChild * item.ChildsCount;
            var finalPrice = daysOfStay * dayPrice;

            if (item.IsAllInclusive)
            {
                var priceForChild = (dayPrice + 60) * item.Room.Capacity;
                finalPrice = daysOfStay * dayPrice;
            }
            else if (item.HasBreakfast)
            {
                var priceForChild = (dayPrice + 20) * item.Room.Capacity;
                finalPrice = daysOfStay * dayPrice;
            }

            item.FinalPrice = finalPrice;
            room.IsAvailable = false;

            client.Reservations.Add(item);

            context.Clients.Update(client);
            context.Rooms.Update(room);
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

        public ActionResult Details(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Reservation item = context.Reservations.FirstOrDefault(x => x.Id == id);

            ReservationVM model = new ReservationVM();

            Client client = context.Clients.FirstOrDefault(x => x.Id == item.ClientId);
            Room room = context.Rooms.FirstOrDefault(x => x.Id == item.RoomId);

            model.Id = item.Id;
            model.ClientId=item.ClientId;
            model.ClientName = client.FirstName;
            model.ClientFamilyName = client.LastName;
            model.ClientPhone = client.PhoneNumber;
            model.ClientEmail = client.Email;
            model.RoomId = item.RoomId;
            model.RoomType = room.Type;
            model.RoomNumber = item.RoomNumber;
            model.UserId = item.UserId;
            model.Username = item.Username;
            model.IsAllInclusive = item.IsAllInclusive;
            model.HasBreakfast = item.HasBreakfast;
            model.ChildrenCount = item.ChildsCount;
            model.AdultsCount = item.AdultsCount;
            model.DateDepart = item.DateDepart;
            model.DateArrive = item.DateArrive;
            model.FinalPrice = item.FinalPrice;

            return View(model);
        }
    }
}
