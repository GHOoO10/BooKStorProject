using GhamdanAlYamaniProject.Data;
using GhamdanAlYamaniProject.Models;
using GhamdanAlYamaniProject.Models.Interface;
using GhamdanAlYamaniProject.Models.Repositroy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PGHDb"));
});
builder.Services.AddScoped<IBaseRepository<Catagory>, CatagoryRepositroy>();
builder.Services.AddScoped<IBaseRepository<Books>, BooksRepositroy>();
builder.Services.AddScoped<IBaseRepository<Admin>, AdminRepositroy>();
builder.Services.AddScoped<IBaseRepository<Customer>, CustomerRepositroy>();
builder.Services.AddScoped<IBaseRepository<Orders>, OrdersRepositroy>();

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
