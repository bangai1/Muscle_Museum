using Microsoft.EntityFrameworkCore;
using Muscle_Museum;
using Museum_App;
using Museum_App.Interfaces;
using Museum_App.Services;
using Museum_Domain.Models;
using Museum_Infrastructure;
using System;


var builder = WebApplication.CreateBuilder(args);



// DbContext
builder.Services.AddDbContext<MuseumDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("Default_Connection"),
b => b.MigrationsAssembly("Museum_Domain") 
    ));

builder.Services.AddScoped<ITicketSaleService, TicketSaleService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAppDI();
builder.Services.AddInfrastructureDI();
builder.Services.AddWebDI();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//routing the auth page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


