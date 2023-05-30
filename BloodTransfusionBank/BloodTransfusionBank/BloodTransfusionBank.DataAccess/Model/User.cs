namespace BloodTransfusionBank.DataAccess.Model
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Occupation
    {
        Student,
        Employee,
        Unemployed
    }

    public enum UserRole
    {
        Administrator,
        CenterAdministrator,
        BloodDonor
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public Occupation Occupation { get; set; }
        public UserRole Role { get; set; }
        public bool IsValidated { get; set; }
    }
}
