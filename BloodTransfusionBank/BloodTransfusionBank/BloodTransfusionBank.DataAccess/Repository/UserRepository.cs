using BloodTransfusionBank.DataAccess.Exceptions;
using BloodTransfusionBank.DataAccess.Model;
using System.Linq.Expressions;


namespace BloodTransfusionBank.DataAccess.Repository
{
    public class UserRepository
    {
        private readonly BloodTransfusionBankDbContext _context;

        public UserRepository(BloodTransfusionBankDbContext context) => _context = context;

        public User Get(Guid id) => _context.Users.Find(id);
        public BloodDonor GetBloodDonor(Guid id) => _context.BloodDonors.Find(id);

        public IEnumerable<User> GetByCondition(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression.Compile());
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public Guid AddBloodDonor(BloodDonor bloodDonor)
        {
            _context.BloodDonors.Add(bloodDonor);
            _context.SaveChanges();
            return bloodDonor.Id;
        }

        public Guid AddAdministrator(Administrator administrator)
        {
            throw new NotImplementedException();
        }

        public Guid AddCenterAdministrator(CenterAdministrator administrator)
        {
            throw new NotImplementedException();
        }
    }
}
