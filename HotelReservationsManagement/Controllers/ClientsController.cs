using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationsManagement.ActionFilters;
using HotelReservationsManagement.Models;
using HotelReservationsManagement.Repositories;
using HotelReservationsManagement.ViewModels.Clients;

namespace HotelReservationsManagement.Controllers
{
    [AuthenticationFilter]
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            IndexVM model = new IndexVM();
            model.Items = context.Clients.ToList();

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

            Client item = new Client();
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.PhoneNumber = model.PhoneNumber;
            item.Email = model.Email;
            item.IsAdult = model.IsAdult;

            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            context.Clients.Add(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Client item = context.Clients.Where(u => u.Id == id)
                                     .FirstOrDefault();

            if (item == null)
                return RedirectToAction("Index", "Clients");

            EditVM model = new EditVM();
            model.Id = item.Id;            
            model.FirstName = item.FirstName;            
            model.LastName = item.LastName;            
            model.PhoneNumber = item.PhoneNumber;
            model.Email = item.Email;
            model.IsAdult = item.IsAdult;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Client item = new Client();
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.PhoneNumber = model.PhoneNumber;
            item.Email = model.Email;
            item.IsAdult = model.IsAdult;

            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            context.Clients.Update(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        public IActionResult Delete(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Client item = new Client();
            item.Id = id;

            context.Clients.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }
    }
}
