using BloodTransfusionBankShared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodTransfusionBank.Models
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext appDbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            var result = await appDbContext.Appointments.AddAsync(appointment);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            var result = await appDbContext.Appointments
               .FirstOrDefaultAsync(a => a.Id == appointmentId);

            if (result != null)
            {
                appDbContext.Appointments.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await appDbContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetDonationCenterAppointments(int centerId)
        {
            return await appDbContext.Appointments.Where(a => a.DonationCenterId == centerId).ToListAsync();
        }

        public Task<Appointment> UpdateAppointment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }
    }
}
