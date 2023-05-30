namespace BloodTransfusionBank.DataAccess.Model
{
    public class CenterAdministrator : User
    {
        public CenterAdministrator() => this.Role = UserRole.CenterAdministrator;

        public List<Appointment> Appointments { get; set; }
    }
}
