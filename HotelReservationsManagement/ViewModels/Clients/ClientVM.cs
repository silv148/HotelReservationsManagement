using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using HotelReservationsManagement.Models;

namespace HotelReservationsManagement.ViewModels.Clients
{
    public class ClientVM
    {
        public int Id { get; set; }

        [DisplayName("Име: ")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия: ")]
        public string LastName { get; set; }

        [DisplayName("Телефонен номер: ")]
        public string PhoneNumber { get; set; }

        [DisplayName("Е-мейл: ")]
        public string Email { get; set; }

        [DisplayName("Възрастен: ")]
        public bool IsAdult { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
