// See https://aka.ms/new-console-template for more information
using BloodTransfusionBank.DataAccess;
using BloodTransfusionBank.DataAccess.Model;

Console.WriteLine("Hello, World!");


var contextFactory = new BloodTransfusionBankContextFactory();
string connectionString = "server=localhost;database=bloodtrasfusionbank;uid=root;pwd=root;";
var context = contextFactory.CreateDbContext(new string[] {connectionString});

var centerAdmins = GetCenterAdmins();
var bloodDonors = GetBloodDonors();
var donationCenters = GetDonationCenters();
var appointments = GetAppointments(donationCenters.First(), centerAdmins.First());


var complaint = new Complaint()
{
    Id = Guid.NewGuid(),
    Appointment = appointments.First(),
    BloodDonor = bloodDonors.First(),
    Content = "Some content bla bla bla bla bla ...",
    ReffersTo = ComplaintReffersTo.Staff,
    Response = null
};

context.CenterAdministrators.AddRange(centerAdmins);
context.BloodDonors.AddRange(bloodDonors);
context.DonationCenters.AddRange(donationCenters);
context.Appointments.AddRange(appointments);
context.Complaints.AddRange(complaint);


context.SaveChanges();


List<DonationCenter> GetDonationCenters()
{
    List<DonationCenter> donationCenters = new List<DonationCenter>();
    donationCenters.Add(new DonationCenter()
    {
        Id = 5,
        Name = "Donation Center 1",
        Address = "Address 1",
        City = "City 1",
        Description = "Desc 1",
        Image = new byte[] { },
        Rating = 1
    });
    donationCenters.Add(new DonationCenter()
    {
        Id = 6,
        Name = "Donation Center 2",
        Address = "Address 2",
        City = "City 2",
        Description = "Desc 2",
        Image = new byte[] { },
        Rating = 2
    });
    donationCenters.Add(new DonationCenter()
    {
        Id = 7,
        Name = "Donation Center 3",
        Address = "Address 3",
        City = "City 3",
        Description = "Desc 3",
        Image = new byte[] { },
        Rating = 3
    });
    donationCenters.Add(new DonationCenter()
    {
        Id = 8,
        Name = "Donation Center 4",
        Address = "Address 4",
        City = "City 4",
        Description = "Desc 4",
        Image = new byte[] { },
        Rating = 4
    });
    donationCenters.Add(new DonationCenter()
    {
        Id = 9,
        Name = "Donation Center 5",
        Address = "Address 5",
        City = "City 5",
        Description = "Desc 5",
        Image = new byte[] { },
        Rating = 1
    });
    return donationCenters;
};


List<Appointment> GetAppointments(DonationCenter donationCenter, CenterAdministrator centerAdmin)
{
    List<Appointment> appointments = new List<Appointment>();
    appointments.Add(new Appointment()
    {
        Id = Guid.NewGuid(),
        DateTime = new DateTime(2023, 5, 30, 10, 0, 0),
        Duration = 30,
        UserId = null,
        DonationCenter = donationCenter,
        Stuff = new List<CenterAdministrator> { centerAdmin }
    });
    appointments.Add(new Appointment()
    {
        Id = Guid.NewGuid(),
        DateTime = new DateTime(2023, 5, 30, 10, 30, 0),
        Duration = 30,
        UserId = null,
        DonationCenter = donationCenter,
        Stuff = new List<CenterAdministrator> { centerAdmin }
    });
    appointments.Add(new Appointment()
    {
        Id = Guid.NewGuid(),
        DateTime = new DateTime(2023, 5, 30, 11, 0, 0),
        Duration = 30,
        UserId = null,
        DonationCenter = donationCenter,
        Stuff = new List<CenterAdministrator> { centerAdmin }
    });
    appointments.Add(new Appointment()
    {
        Id = Guid.NewGuid(),
        DateTime = new DateTime(2023, 5, 27, 11, 30, 0),
        Duration = 30,
        UserId = null,
        DonationCenter = donationCenter,
        Stuff = new List<CenterAdministrator> { centerAdmin }
    });
    return appointments;
}


List<CenterAdministrator> GetCenterAdmins()
{
    List<CenterAdministrator> centerAdministrators = new List<CenterAdministrator>();
    centerAdministrators.Add(new CenterAdministrator()
    {
        Id = Guid.NewGuid(),
        FirstName = "Admin",
        LastName = "Admin",
        Address = "Address 1",
        City = "City 1",
        Country = "Country 1",
        Email = "kovacevicnemanja1997@gmail.com",
        Gender = Gender.Male,
        Occupation = Occupation.Employee,
        IsValidated = true,
        Password = "pass 1"
    });
    return centerAdministrators;
}


List<BloodDonor> GetBloodDonors()
{
    List<BloodDonor> bloodDonors = new List<BloodDonor>();

    var id = Guid.NewGuid();
    var survey = new Survey()
    {
        Alergies = "alergy 1, alergy 2 ...",
        BloodDonorId = id,
        BloodType = "A+",
        Diseases = "disiese 1, disiese 2, ..."
    };
    bloodDonors.Add(new BloodDonor()
    {
        Id = id,
        FirstName = "Lana",
        LastName = "Kovacevic",
        Password = "pass 1",
        Email = "kovacevicnemanja1997@gmail.com",
        Address = "addr 1",
        City = "city 1",
        Country = "country 1",
        Gender = Gender.Female,
        Occupation = Occupation.Student,
        Survey = survey,
        IsValidated = true
    });
    return bloodDonors;
}