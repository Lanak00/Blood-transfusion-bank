using BloodTransfusionBank.DataAccess.Model;
using System.Linq.Expressions;

namespace BloodTransfusionBank.DataAccess.Repository
{
    public class DonationCenterRepository
    {
        private readonly BloodTransfusionBankDbContext _context;

        public DonationCenterRepository(BloodTransfusionBankDbContext context) => _context = context;

        public DonationCenter Get(Guid id) => _context.DonationCenters.Find(id);

        public void Update(DonationCenter donationCenter)
        {
            _context.DonationCenters.Update(donationCenter);
            _context.SaveChanges();
        }

        public int Add(DonationCenter donationCenter)
        {
            _context.DonationCenters.Add(donationCenter);
            _context.SaveChanges();
            return donationCenter.Id;
        }

        public IEnumerable<DonationCenter> GetAll() => _context.DonationCenters;

        public IEnumerable<DonationCenter> GetByCondition(Expression<Func<DonationCenter, bool>> expression)
        {
            return _context.DonationCenters.Where(expression.Compile());
        }
    }
}
