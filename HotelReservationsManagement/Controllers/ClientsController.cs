using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationsManagement.ActionFilters;
using HotelReservationsManagement.Models;
using HotelReservationsManagement.Repositories;
using HotelReservationsManagement.ViewModels.Clients;
using HotelReservationsManagement.ViewModels.Reservations;

namespace HotelReservationsManagement.Controllers
{
    [AuthenticationFilter]
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            ClientIndexVM model = new ClientIndexVM();
            model.Items = context.Clients.ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientCreateVM model)
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

            ClientEditVM model = new ClientEditVM();
            model.Id = item.Id;            
            model.FirstName = item.FirstName;            
            model.LastName = item.LastName;            
            model.PhoneNumber = item.PhoneNumber;
            model.Email = item.Email;
            model.IsAdult = item.IsAdult;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ClientEditVM model)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();

            if (!ModelState.IsValid)
                return View(model);

            Client item = context.Clients.Where(u => u.Id == model.Id)
                                     .FirstOrDefault();
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;
            item.PhoneNumber = model.PhoneNumber;
            item.Email = model.Email;
            item.IsAdult = model.IsAdult;

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
        public ActionResult Details(int id)
        {
            HotelReservationsManagementDbContext context = new HotelReservationsManagementDbContext();
            Client item = context.Clients.FirstOrDefault(x => x.Id == id);

            var reservations = new List<Reservation>();
            if (context.Reservations.Any(x => x.ClientId == id))
            {
                foreach (Reservation reservation in context.Reservations)
                {
                    if (reservation.ClientId == id)
                        reservations.Add(reservation);
                }
            }

            ClientVM model = new ClientVM();
            model.Id = item.Id;
            model.FirstName = item.FirstName;
            model.LastName = item.LastName;
            model.PhoneNumber = item.PhoneNumber;
            model.Email = item.Email;
            model.IsAdult = item.IsAdult;
            model.Reservations = reservations;


            return View(model);
        }
    }
}
