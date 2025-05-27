using DataAccessLayer; // DataAccessLayer i�in using ifadesi
using BusinessLayer;   // BusinessLayer i�in using ifadesi
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Servislerinizi burada kaydedin
builder.Services.AddDataAccessLayer(builder.Configuration); // DataAccessLayer'daki DI i�in
builder.Services.AddBusiness();                             // BusinessLayer'daki DI i�in
builder.Services.AddControllers();

// Swagger yap�land�rmas� ekleniyor
builder.Services.AddEndpointsApiExplorer(); // API explorer endpoints ekler
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDersService, DerslerService>();
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IMesajService,MesajService>();
builder.Services.AddScoped<IOdaService,OdaService>();
builder.Services.AddScoped<IFakulteService,FakulteService>();
builder.Services.AddScoped<IBolumService,BolumService>();

var app = builder.Build();

// Development ortam�nda Swagger'� etkinle�tir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();