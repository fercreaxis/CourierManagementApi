using CourierManagementAPI.Controllers.ActionFilters;
using CourierManagementAPI.Repositories.Brands;
using CourierManagementAPI.Repositories.Collectors;
using CourierManagementAPI.Repositories.DB;
using CourierManagementAPI.Repositories.PackageTypes;
using CourierManagementAPI.Repositories.UrgencyTypes;
using CourierManagementAPI.Repositories.Users;
using CourierManagementAPI.Repositories.UserSessions;
using CourierManagementAPI.Repositories.Vendors;
using CourierManagementAPI.Services.Brands;
using CourierManagementAPI.Services.Collectors;
using CourierManagementAPI.Services.PackageTypes;
using CourierManagementAPI.Services.UrgencyTypes;
using CourierManagementAPI.Services.Users;
using CourierManagementAPI.Services.UserSessions;
using CourierManagementAPI.Services.Vendors;
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

builder.Services.AddScoped<IBrandsData, BrandsDataSQL>();
builder.Services.AddScoped<IBrandsService, BrandsService>();

builder.Services.AddScoped<ICollectorsData, CollectorDataSql>();
builder.Services.AddScoped<ICollectorsService, CollectorsService>();

builder.Services.AddScoped<IPackageTypesData, PackageTypeDataSql>();
builder.Services.AddScoped<IPackageTypesService, PackageTypesService>();

builder.Services.AddScoped<IUrgencyTypesData, UrgencyTypeDataSql>();
builder.Services.AddScoped<IUrgencyTypesService, UrgencyTypesService>();

builder.Services.AddScoped<IVendorsData, VendorDataSql>();
builder.Services.AddScoped<IVendorsService, VendorsService>();

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
