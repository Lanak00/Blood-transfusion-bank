namespace BloodTransfusionBank.DataAccess.Model
{
    public class Administrator : User
    {
        public Administrator() => this.Role = UserRole.Administrator;
    }
}
