using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelReservationsManagement.Models
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public decimal PriceForAdult { get; set; }
        public decimal PriceForChild { get; set; }

        [ForeignKey("ReservationId")]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
