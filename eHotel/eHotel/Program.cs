using eHotel.Database;
using eHotel.eHotel.Services;
using eHotel.eHotel.Services.Interface;
using eHotel.eHotel.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IKorisnikService, KorisnikService>();
builder.Services.AddScoped<IRezervacijeService, RezervacijaService>();
builder.Services.AddScoped<IDodatneUslugeService, DodatneUslugeService>();
builder.Services.AddScoped<IPlacanjeService, PlacanjaService>();
builder.Services.AddScoped<IRecenzijaService, RecenzijeService>();
builder.Services.AddScoped<ISobaService, SobeService>();
builder.Services.AddDbContext<EHotelContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

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
