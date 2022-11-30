using BloodTransfusionBankShared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodTransfusionBank.Models
{
    public class DonationCenterRepository : IDonationCenterRepository
    {
        private readonly AppDbContext appDbContext;
        public DonationCenterRepository(AppDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }
        public async Task<DonationCenter> AddDonationCenter(DonationCenter center)
        {
            var result = await appDbContext.DonationCenters.AddAsync(center);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteDonationCenter(int centerId)
        {
            var result = await appDbContext.DonationCenters
                .FirstOrDefaultAsync(c => c.Id == centerId);

            if(result != null)
            {
                appDbContext.DonationCenters.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<DonationCenter> GetDonationCenter(int centerId)
        {
            return await appDbContext.DonationCenters
             .FirstOrDefaultAsync(c => c.Id == centerId);
        }

        public async Task<IEnumerable<DonationCenter>> GetDonationCenters()
        {
            return await appDbContext.DonationCenters.ToListAsync();
        }


        public async Task<DonationCenter> UpdateDonationCenter(DonationCenter center)
        {
            var result = await appDbContext.DonationCenters
                .FirstOrDefaultAsync(c => c.Id == center.Id);

            if (result != null)
            {
                result.Name = center.Name;
                result.Address = center.Address;
                result.City = center.City;
                result.Image = center.Image;
                result.Rating = center.Rating;
                result.Description = center.Description;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
