using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManagement.ViewModels.Users
{
    public class CreateVM
    {
        [DisplayName("Потр. име: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Username { get; set; }

        [DisplayName("Парола: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Password { get; set; }

        [DisplayName("Име: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string FirstName { get; set; }

        [DisplayName("Презиме: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Surname { get; set; }

        [DisplayName("Фамилия: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string LastName { get; set; }

        [DisplayName("ЕГН: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string EGN { get; set; }

        [DisplayName("Тел. номер: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string PhoneNumber { get; set; }

        [DisplayName("Е-мейл: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Email { get; set; }

        [DisplayName("Дата на назначаване: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public DateTime DateOfAppointment { get; set; }

        [DisplayName("Активен: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public bool IsActive { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
