using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservationsManager.ViewModels.Rooms
{
    public class EditVM
    {
        public int Id { get; set; }

        [DisplayName("Номер: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        [Range(0, int.MaxValue, ErrorMessage = "Моля въведете валидно число!")]
        public int RoomNumber { get; set; }

        [DisplayName("Тип: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        public string Type { get; set; }

        [DisplayName("Капацитет: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        [Range(0, 20, ErrorMessage = "Моля въведете валидно число!")]
        public int Capacity { get; set; }

        [DisplayName("   Свободна ")]
        public bool IsAvailable { get; set; }

        [DisplayName("Цена за възрастен: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        [Range(0, double.MaxValue, ErrorMessage = "Моля въведете валидна цена!")]
        public decimal PriceForAdult { get; set; }

        [DisplayName("Цена за дете: ")]
        [Required(ErrorMessage = "*Това поле е задължително!")]
        [Range(0, double.MaxValue, ErrorMessage = "Моля въведете валидна цена!")]
        public decimal PriceForChild { get; set; }
    }
}
