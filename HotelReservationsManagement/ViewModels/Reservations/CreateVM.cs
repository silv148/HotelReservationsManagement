using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManagement.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationsManagement.ViewModels.Reservations
{
    public class CreateVM
    {
        public int UserId { get; set; }

        [DisplayName("Дата на пристигане: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public DateTime DateArrive { get; set; }

        [DisplayName("Дата на напускане: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public DateTime DateDepart { get; set; }

        [DisplayName("Има ли закуска: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        [DisplayName("Финална цена: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public decimal FinalPrice { get; set; }

        [DisplayName("Номер на клиента: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public int ClientId { get; set; }

        [DisplayName("Номер на стаята: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public int RoomId { get; set; }
    }
}
