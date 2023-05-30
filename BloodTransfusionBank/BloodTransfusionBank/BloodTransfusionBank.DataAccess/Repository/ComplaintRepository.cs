using BloodTransfusionBank.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BloodTransfusionBank.DataAccess.Repository
{
    public class ComplaintRepository
    {
        private readonly BloodTransfusionBankDbContext _context;

        public ComplaintRepository(BloodTransfusionBankDbContext context) => _context = context;

        public Complaint Get(Guid id) => _context.Complaints.Find(id);

        public void Update(Complaint complaint)
        {
            _context.Complaints.Update(complaint);
            _context.SaveChanges();
        }

        public Guid Add(Complaint complaint)
        {
            _context.Complaints.Add(complaint);
            _context.SaveChanges();
            return complaint.Id;
        }

        public IEnumerable<Complaint> GetAll() => _context.Complaints;

        public IEnumerable<Complaint> GetByCondition(Expression<Func<Complaint, bool>> expression)
        {
            return _context.Complaints
                .Include(x => x.Appointment)
                .Where(expression.Compile());
        }
    }
}
