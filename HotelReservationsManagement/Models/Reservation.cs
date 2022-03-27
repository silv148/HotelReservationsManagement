using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationsManagement.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public List<Client> Clients { get; set; }
        public DateTime DateArrive { get; set; }
        public DateTime DateDepart { get; set; }
        public bool HasBreakfast { get; set; }
        public bool IsAllInclusive { get; set; }
        public decimal FinalPrice { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public virtual User User { get; set; }
        public virtual Client Client { get; set; }
    }
}
