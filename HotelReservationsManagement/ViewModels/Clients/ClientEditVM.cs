using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationsManager.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationsManager.ViewModels.Clients
{
    public class ClientEditVM
    {
        public int Id { get; set; }

        [DisplayName("Име: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string FirstName { get; set; }

        [DisplayName("Фамилия: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string LastName { get; set; }

        [DisplayName("Телефонен номер: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Невалиден телефонен номер!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Е-мейл: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Email { get; set; }

        [DisplayName("   Възрастен ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public bool IsAdult { get; set; }
    }
}
