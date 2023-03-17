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
        public DbSet<DonationCenter> DonationCenters { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
