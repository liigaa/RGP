using Microsoft.EntityFrameworkCore;
using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;
using RgpWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options 
    => options.UseSqlServer(
        builder.Configuration.GetConnectionString("RgpConnection")
        ));

builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IEntityService<Owner>, EntityService<Owner>>();
builder.Services.AddScoped<IEntityService<Unit>, EntityService<Unit>>();
builder.Services.AddScoped<IEntityService<Property>, EntityService<Property>>();
builder.Services.AddScoped<IEntityService<UnitUseTypes>, EntityService<UnitUseTypes>>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IUnitUseTypesService, UnitUseTypesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
