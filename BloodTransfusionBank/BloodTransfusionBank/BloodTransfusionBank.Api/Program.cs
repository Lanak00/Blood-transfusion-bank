using BloodTransfusionBank.BussinessLogic.Interfaces;
using BloodTransfusionBank.BussinessLogic.Services;
using BloodTransfusionBank.BussinessLogic.Services.Auth;
using BloodTransfusionBank.DataAccess;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

// Add services to the container.

var mySpecificOrigins = "_mySpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: mySpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var contextFactory = new BloodTransfusionBankContextFactory();
string connectionString = "server=localhost;database=bloodtrasfusionbank;uid=root;pwd=root;";
var context = contextFactory.CreateDbContext(new string[] { connectionString });
var userRepository = new BloodTransfusionBank.DataAccess.Repository.UserRepository(context);
var donationCenterRepository = new BloodTransfusionBank.DataAccess.Repository.DonationCenterRepository(context);
var appointmentRepository = new BloodTransfusionBank.DataAccess.Repository.AppointmentRepository(context);
var surveyRepository = new BloodTransfusionBank.DataAccess.Repository.SurveyRepository(context);
var complaintRepository = new BloodTransfusionBank.DataAccess.Repository.ComplaintRepository(context);


builder.Services.AddScoped<IAuthService>(_ => new AuthService(userRepository));
builder.Services.AddScoped<IDonationCenterService>(_ => new DonationCenterService(donationCenterRepository));
builder.Services.AddScoped<IAppointmentService>(_ => new AppointmentService(appointmentRepository));
builder.Services.AddScoped<IReservationService>(_ => new ReservationService(appointmentRepository, userRepository, surveyRepository));
builder.Services.AddScoped<IComplaintService>(_ => new ComplaintService(complaintRepository, userRepository, appointmentRepository));
builder.Services.AddScoped<ISurveyService>(_ => new SurveyService(surveyRepository));
builder.Services.AddScoped<IUserService>(_ => new UserService(userRepository));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseExceptionHandler("/Error");

app.UseHttpsRedirection();

app.UsePathBase(new PathString("/api/bloodtransfusionbank"));

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.UseCors(mySpecificOrigins);
app.UseCors(builder =>
                builder.WithOrigins(config["ApplicationSettings:Client_URL"].ToString())
                .AllowAnyHeader()
                .AllowAnyMethod()
                );

app.MapControllers();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
