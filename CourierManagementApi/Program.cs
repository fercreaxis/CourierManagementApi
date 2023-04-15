using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Repositories.DB;
using CourierManagementAPI.Repositories.Users;
using CourierManagementAPI.Repositories.UserSessions;
using CourierManagementAPI.Services.Users;
using CourierManagementAPI.Services.UserSessions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
builder.Services.AddDbContextPool<CourierManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));


builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IValidateSessionService, ValidateSessionService>();

builder.Services.AddScoped<IUsersData, UsersDataSql>();
builder.Services.AddScoped<IValidateSessionData, ValidateSessionSql>();

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
