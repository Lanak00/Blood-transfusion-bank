using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodTransfusionBankShared;

namespace BloodTransfusionBank.Models
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<IEnumerable<Appointment>> GetDonationCenterAppointments(int centerId);
        Task<Appointment> AddAppointment(Appointment appointment);
        Task<Appointment> UpdateAppointment(Appointment appoinment);
        Task DeleteAppointment(int appointmentId);
    }
}
