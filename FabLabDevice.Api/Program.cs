using FabLabDevice.Api.Domains.Persistence.Contexts;
using FabLabDevice.Api.Domains.Persistence.Repositories;
using FabLabDevice.Api.Domains.Repositories;
using FabLabDevice.Api.Domains.Services;
using FabLabDevice.Api.Mapping;
using FabLabDevice.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FabLabDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FabLabDb"));
});

builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
////
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IEquipmentTypeService, EquipmentTypeService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();

builder.Services.AddAutoMapper(typeof(ModelToViewModelProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

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
