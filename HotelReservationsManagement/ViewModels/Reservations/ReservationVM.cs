using System;
using System.ComponentModel;

namespace HotelReservationsManager.ViewModels.Reservations
{
    public class ReservationVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("Дата на пристигане: ")]
        public DateTime DateArrive { get; set; }

        [DisplayName("Дата на освобождаване: ")]
        public DateTime DateDepart { get; set; }

        [DisplayName("Включена закуска: ")]
        public bool HasBreakfast { get; set; }

        [DisplayName("AllInclusive: ")]
        public bool IsAllInclusive { get; set; }

        [DisplayName("Брой деца: ")]
        public int ChildrenCount { get; set; }

        [DisplayName("Брой възрастни: ")]
        public int AdultsCount { get; set; }
        public int ClientId { get; set; }

        [DisplayName("Име на клиент: ")]
        public string ClientName { get; set; }

        [DisplayName("Фамилия на клиент: ")]
        public string ClientFamilyName { get; set; }

        [DisplayName("Телефонен номер на клиент: ")]
        public string ClientPhone { get; set; }

        [DisplayName("E-мейл номер на клиент: ")]
        public string ClientEmail { get; set; }
        public int RoomId { get; set; }

        [DisplayName("Номер на стая: ")]
        public int RoomNumber { get; set; }

        [DisplayName("Тип на стая: ")]
        public string RoomType { get; set; }

        [DisplayName("Финална цена: ")]
        public decimal FinalPrice { get; set; }

        [DisplayName("Потребител: ")]
        public string Username { get; set; }
    }
}
