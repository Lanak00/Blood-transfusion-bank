using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace BloodTransfusionBank.DataAccess
{

    public class BloodTransfusionBankContextFactory : IDesignTimeDbContextFactory<BloodTransfusionBankDbContext>
    {
        public BloodTransfusionBankDbContext CreateDbContext(string[] args)
        {
            string connectionString = args[0];
            var optionsBuilder = new DbContextOptionsBuilder<BloodTransfusionBankDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            var context = new BloodTransfusionBankDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
