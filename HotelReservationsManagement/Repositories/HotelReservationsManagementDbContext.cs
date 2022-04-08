using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelReservationsManagement.Models;
using HotelReservationsManagement.ViewModels.Rooms;
using HotelReservationsManagement.ViewModels.Clients;
using HotelReservationsManagement.ViewModels.Reservations;

namespace HotelReservationsManagement.Repositories
{
    public class HotelReservationsManagementDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        public HotelReservationsManagementDbContext()
        {
            this.Users = this.Set<User>();
            this.Clients = this.Set<Client>();
            this.Reservations = this.Set<Reservation>();
            this.Rooms = this.Set<Room>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
             .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelReservationsManagementDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
              new User()
              {
                  Id = 1,
                  Username = "admin",
                  Password = "password",
                  FirstName = "Admin",
                  Surname = "Ist",
                  LastName = "Rator",
                  EGN = "8943789564",
                  PhoneNumber = "0897987987",
                  Email = "admin@hotel-manager.com",
                  DateOfAppointment = new DateTime(2022, 3, 30, 12, 00, 00),
                  IsActive = true,
                  ReleaseDate = null,
              });
        }

        public DbSet<HotelReservationsManagement.ViewModels.Rooms.EditVM> EditVM { get; set; }

        public DbSet<HotelReservationsManagement.ViewModels.Clients.ClientEditVM> EditVM_1 { get; set; }

        public DbSet<HotelReservationsManagement.ViewModels.Reservations.EditVM> EditVM_2 { get; set; }

        public DbSet<HotelReservationsManagement.ViewModels.Reservations.ReservationVM> ReservationVM { get; set; }

        public DbSet<HotelReservationsManagement.ViewModels.Clients.ClientVM> ClientVM { get; set; }
    }
}
