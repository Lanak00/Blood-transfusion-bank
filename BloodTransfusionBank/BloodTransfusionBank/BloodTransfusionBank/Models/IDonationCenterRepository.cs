using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodTransfusionBankShared;

namespace BloodTransfusionBank.Models
{
    public interface IDonationCenterRepository
    {
        Task<IEnumerable<DonationCenter>> GetDonationCenters();
        Task<DonationCenter> GetDonationCenter(int centerId);
        Task<DonationCenter> AddDonationCenter(DonationCenter center);
        Task<DonationCenter> UpdateDonationCenter(DonationCenter center);
        Task DeleteDonationCenter(int centerId);
    }
}
