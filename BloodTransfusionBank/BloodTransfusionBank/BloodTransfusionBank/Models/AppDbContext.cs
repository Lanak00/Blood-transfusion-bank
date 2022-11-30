using BloodTransfusionBankShared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodTransfusionBank.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<DonationCenter> DonationCenters { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed DonationCenters Table
            modelBuilder.Entity<DonationCenter>().HasData(
                new DonationCenter
                {
                    Id = 1,
                    Name = "Donation Center 1",
                    Address = "201 Main St",
                    City = "New York",
                    Description = "Donation Center is a health facility where you can schedule appointment to donate blood. In order to be able to donate blood you have to complete the survey first and also make sure your last bloodd donation was at least six months ago.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG",
                    Rating = 4.8,
                }
            );
            modelBuilder.Entity<DonationCenter>().HasData(
                new DonationCenter
                {
                    Id = 2,
                    Name = "Donation Center 2",
                    Address = "15 Maple St",
                    City = "New York",
                    Description = "Donation Center is a health facility where you can schedule appointment to donate blood. In order to be able to donate blood you have to complete the survey first and also make sure your last bloodd donation was at least six months ago.",
                    Image = "https://i0.wp.com/ctnewsjunkie.com/wp-content/uploads/2020/12/UConn_Health_Center_wikipedia_720x540_720_540_99_sha-100.jpg?fit=720%2C540&ssl=1",
                    Rating = 4.3,
                }
            );
            modelBuilder.Entity<DonationCenter>().HasData(
                new DonationCenter
                {
                    Id = 3,
                    Name = "Donation Center 33",
                    Address = "201 Main St",
                    City = "New York",
                    Description = "Donation Center is a health facility where you can schedule appointment to donate blood. In order to be able to donate blood you have to complete the survey first and also make sure your last bloodd donation was at least six months ago.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG",
                    Rating = 4.1,
                }
            );

            //seed Appointments Table
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    Date = new DateTime(2022, 05, 09, 9, 15, 0),
                    Duration = 30,
                    DonationCenterId = 1,
                }
            );
            modelBuilder.Entity<Appointment>().HasData(
               new Appointment
               {
                   Id = 2,
                   Date = new DateTime(2022, 05, 09, 9, 45, 0),
                   Duration = 30,
                   DonationCenterId = 1,
               }
           );
        }

    }
}
