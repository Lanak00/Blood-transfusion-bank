namespace BloodTransfusionBank.BussinessLogic.DTO
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

    public class BloodDonorRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public Occupation Occupation { get; set; }
    }
}
