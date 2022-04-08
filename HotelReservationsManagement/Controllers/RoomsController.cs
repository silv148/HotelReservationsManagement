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

            if (model.Capacity < 2 || model.Capacity > 5)
            {
                this.ModelState.AddModelError("dateError", "Капацитетът на стаята трябва да бъде между 2 и 5 легла!");
                return View(model);
            }

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
            Room item = context.Rooms.Where(u => u.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Rooms");

            if (item.Capacity < 2 || item.Capacity > 5)
            {
                this.ModelState.AddModelError("dateError", "Капацитетът на стаята трябва да бъде между 2 и 5 легла!");
                return View(item);
            }

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
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            
            if (!ModelState.IsValid)
                return View(model);

            Room item = context.Rooms.Where((u) => u.Id == model.Id)
                                                .FirstOrDefault();

            item.RoomNumber = model.RoomNumber;
            item.Capacity = model.Capacity;
            item.Type = model.Type;
            item.IsAvailable = model.IsAvailable;
            item.PriceForAdult = model.PriceForAdult;
            item.PriceForChild = model.PriceForChild;

            context.Rooms.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Rooms");
        }

        public IActionResult Delete(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Room item = new Room();
            item.Id = id;

            context.Rooms.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Rooms");
        }
    }
}
