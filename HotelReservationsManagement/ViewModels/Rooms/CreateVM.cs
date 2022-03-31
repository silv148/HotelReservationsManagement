using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManagement.ViewModels.Rooms
{
    public class CreateVM
    {

        [DisplayName("Тип: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public int Capacity { get; set; }

        [DisplayName("Капацитет: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Type { get; set; }

        [DisplayName("Свободна: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public bool IsAvailable { get; set; }

        [DisplayName("Цена за възрастен: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public decimal PriceForAdult { get; set; }

        [DisplayName("Цена за дете: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public decimal PriceForChild { get; set; }
    }
}
