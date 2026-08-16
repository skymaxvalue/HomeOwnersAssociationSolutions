using BAL.Contract;
using BAL.Implementation;
using DAL.Contract;
using DAL.Helper;
using DAL.Implementation;
using ParkingAPI.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyWeb = ConfigurationHelper.GetConfig("Parkingconfig:ParkingWeb");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins(MyWeb)
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});


builder.Services.AddSingleton<ISignUpBAL, SignUpBAL>();
builder.Services.AddSingleton<ISignUpDAL, SignUpDAL>();
builder.Services.AddSingleton<ILogInDAL, LogInDAL>();
builder.Services.AddSingleton<ILoginBAL, LoginBAL>();
builder.Services.AddSingleton<IOTPDAL, OTPDAL>();
builder.Services.AddSingleton<IOTPBAL, OTPBAL>();
builder.Services.AddSingleton<IMyProfileBAL, ProfileBAL>();
builder.Services.AddSingleton<IMyProfileDAL, MyProfileDAL>();
builder.Services.AddSingleton<ILayoutDAL, LayoutDAL>();
builder.Services.AddSingleton<ILayoutBAL, LayoutBAL>();
builder.Services.AddSingleton<IParkingBAL, ParkingBAL>();
builder.Services.AddSingleton<IParkingDAL, ParkingDAL>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddControllers(options => {
    options.Filters.Add(typeof(RequestAuthorizationFilter));

});

var app = builder.Build();
app.Lifetime.ApplicationStarted.Register(() =>
{
    ApplicationBot.ApplicationBotIntialise(); // Call static method when the application starts
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Use CORS middleware
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
