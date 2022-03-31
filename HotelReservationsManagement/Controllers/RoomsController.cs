using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManagement.ActionFilters;
using HotelReservationsManagement.Models;
using HotelReservationsManagement.Repositories;
using HotelReservationsManagement.ViewModels.Rooms;

namespace HotelReservationsManagement.Controllers
{
    [AuthenticationFilter]
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            IndexVM model = new IndexVM();
            model.Items = context.Rooms.ToList();

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

            Room item = new Room();
            item.RoomNumber = model.RoomNumber;
            item.Capacity = model.Capacity;
            item.Type = model.Type;
            item.IsAvailable = model.IsAvailable;
            item.PriceForAdult = model.PriceForAdult;
            item.PriceForChild = model.PriceForChild;

            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            context.Rooms.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Rooms");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Room item = context.Rooms.Where(u => u.RoomNumber == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Rooms");

            EditVM model = new EditVM();
            model.RoomNumber = item.RoomNumber;
            model.Capacity = item.Capacity;
            model.Type = item.Type;
            model.IsAvailable = item.IsAvailable;
            model.PriceForAdult = item.PriceForAdult;
            model.PriceForChild = item.PriceForChild;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Room item = new Room();
            item.RoomNumber = model.RoomNumber;
            item.Capacity = model.Capacity;
            item.Type = model.Type;
            item.IsAvailable = model.IsAvailable;
            item.PriceForAdult = model.PriceForAdult;
            item.PriceForChild = model.PriceForChild;

            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            context.Rooms.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Rooms");
        }

        public IActionResult Delete(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Room item = new Room();
            item.RoomNumber = id;

            context.Rooms.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Rooms");
        }
    }
}
