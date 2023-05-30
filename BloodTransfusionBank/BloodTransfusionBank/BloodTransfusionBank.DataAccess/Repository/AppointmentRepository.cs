using BloodTransfusionBank.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BloodTransfusionBank.DataAccess.Repository
{
    public class AppointmentRepository
    {
        private readonly BloodTransfusionBankDbContext _context;

        public AppointmentRepository(BloodTransfusionBankDbContext context) => _context = context;

        public Appointment? Get(Guid id) => _context.Appointments
                                                   .Include(x => x.UsersReservationHistory)
                                                   .Where(x => x.Id == id).FirstOrDefault();

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public Guid Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment.Id;
        }

        public IEnumerable<Appointment> GetAll() => _context.Appointments;

        public IEnumerable<Appointment> GetByCondition(Expression<Func<Appointment, bool>> expression)
        {
            return _context.Appointments
                .Include(x => x.Stuff)
                .Include(x => x.Complaint)
                .Include(x => x.User)
                .Where(expression.Compile());
        }
    }
}
