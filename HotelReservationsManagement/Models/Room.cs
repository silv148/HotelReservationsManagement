using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelReservationsManager.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PriceForAdult { get; set; }
        public decimal PriceForChild { get; set; }
    }
}
