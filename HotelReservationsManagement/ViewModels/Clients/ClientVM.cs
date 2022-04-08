using System;
using System.Collections.Generic;
using System.ComponentModel;
using HotelReservationsManagement.ViewModels.Reservations;

namespace HotelReservationsManagement.ViewModels.Clients
{
    public class ClientVM
    {
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

        [DisplayName("Минали резервации: ")]
        public List<ReservationVM> Items { get; set; }
    }
}
