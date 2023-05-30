using BloodTransfusionBank.DataAccess.Model;
using Microsoft.EntityFrameworkCore;


namespace BloodTransfusionBank.DataAccess
{

    public class BloodTransfusionBankDbContext : DbContext
    {
        public BloodTransfusionBankDbContext()
        { }
        public BloodTransfusionBankDbContext(DbContextOptions<BloodTransfusionBankDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<CenterAdministrator> CenterAdministrators { get; set; }
        public DbSet<BloodDonor> BloodDonors { get; set; }
        public DbSet<DonationCenter> DonationCenters { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Administrator>().ToTable("Administrators");
            modelBuilder.Entity<CenterAdministrator>().ToTable("CenterAdministrators");
            modelBuilder.Entity<BloodDonor>().ToTable("BloodDonors");

            modelBuilder.Entity<User>(x =>
            {

                x.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4");
                x.HasKey(x => x.Id);
                x.Property(x => x.FirstName).IsRequired(true);
                x.Property(x => x.LastName).IsRequired(true);
                x.Property(x => x.Email).IsRequired(true);
                x.Property(x => x.Password).IsRequired(true);
                x.Property(x => x.Address).IsRequired(true);
                x.Property(x => x.City).IsRequired(true);
                x.Property(x => x.Country).IsRequired(true);
            });

            modelBuilder.Entity<Survey>(x =>
            {
                x.HasKey(e => e.BloodDonorId);
                x.HasOne(e => e.BloodDonor).WithOne(e => e.Survey).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
