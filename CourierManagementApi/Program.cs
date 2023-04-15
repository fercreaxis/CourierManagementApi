using ApproveX_API.Controllers.ActionFilters;
using ApproveX_API.Repositories.DB;
using ApproveX_API.Repositories.Devices;
using ApproveX_API.Repositories.Notifications;
using ApproveX_API.Repositories.Users;
using ApproveX_API.Repositories.UserSessions;
using ApproveX_API.Services.Devices;
using ApproveX_API.Services.Notifications;
using ApproveX_API.Services.Users;
using ApproveX_API.Services.UserSessions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddDbContextPool<ApproveXContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));


builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IValidateSessionService, ValidateSessionService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();


builder.Services.AddScoped<IUsersData, UsersDataSql>();
builder.Services.AddScoped<IValidateSessionData, ValidateSessionSql>();
builder.Services.AddScoped<INotificationData, NotificationDataSQL>();
builder.Services.AddScoped<IDeviceData, DeviceDataSql>();

builder.Services.AddScoped<ValidateSessionFilter>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
