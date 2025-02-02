using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationsManager.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime DateArrive { get; set; }
        public DateTime DateDepart { get; set; }
        public bool HasBreakfast { get; set; }
        public bool IsAllInclusive { get; set; }
        public int ChildsCount { get; set; }
        public int AdultsCount { get; set; }
        public decimal FinalPrice { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }

        [ForeignKey("RoomId")]
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public Client Client { get; set; }
    }
}
