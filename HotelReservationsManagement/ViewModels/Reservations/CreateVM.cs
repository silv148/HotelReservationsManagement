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
        public Client Client { get; set; }

        [DisplayName("Име на клиента: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string ClientFirstName { get; set; }

        [Required(ErrorMessage = "*Това поле е задължително!")]
        [DisplayName("Фамилия на клиента: ")]
        public string ClientLastName { get; set; }

        [DisplayName("Телефонен номер: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Невалиден телефонен номер!")]
        public string ClientPhone { get; set; }

        [DisplayName("Брой възрастни: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public int AdultsCount { get; set; }

        [DisplayName("Брой деца: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public int ChildsCount { get; set; }

        [DisplayName("Дата и час на пристигане: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public DateTime DateArrive { get; set; }

        [DisplayName("Дата и час на напускане: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public DateTime DateDepart { get; set; }

        public bool HasBreakfast { get; set; }

        public bool IsAllInclusive { get; set; }

        [DisplayName("Номер на стаята: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public int RoomNumber { get; set; }
    }
}
