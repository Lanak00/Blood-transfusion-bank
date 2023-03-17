// See https://aka.ms/new-console-template for more information
using BloodTransfusionBank.DataAccess;

Console.WriteLine("Hello, World!");


var contextFactory = new BloodTransfusionBankContextFactory();
string connectionString = "server=localhost;database=bloodtrasfusionbank;uid=root;pwd=root;";
var context = contextFactory.CreateDbContext(new string[] {connectionString});
context.Users.Add(new BloodTransfusionBank.DataAccess.Model.User()
{
    Id = Guid.NewGuid(),
    FirstName = "Lana",
    LastName = "Kovacevic",
    Email = "lanakovacevic@gmail.com",
    Address = "Blagoja Parovica 92",
    City = "Gajdobra",
    Country = "Serbia",
    Gender = "Female",
    Occupation = BloodTransfusionBank.DataAccess.Model.Occupation.Student,
    Password = "temppass"
});

context.DonationCenters.Add(new BloodTransfusionBank.DataAccess.Model.DonationCenter()
{
    Id = 5,
    Name = "Nesto",
    Address = "sadas",
    City = "adsa",
    Description = "sdasdas",
    Image = new byte[] { },
    Rating = 6
});

context.SaveChanges();