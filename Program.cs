using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleWebMVC.Data;
using SaleWebMVC.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SaleWebMVCContext>(options =>
 options.UseMySql("server=localhost;initial catalog=CRUD_DOTNET_MVC;uid=root;password=123456;database=saleswebmvcappdb",
 Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"), builder =>
builder.MigrationsAssembly("SaleWebMVC")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
//builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<ISellerService, SellerService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
//builder.Services.AddScoped<SalesRecordService>();
builder.Services.AddScoped<ISalesRecordService, SalesRecordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// falta chamar a função de popular o banco de dados, mas nessa versão mais nova do ASP.NET Core não
// encontrei ainda como fazer, pesquisar e em ultimo caso perguntar pro Chagas como fazer.
app.UseHttpsRedirection();
app.UseStaticFiles();

//void Configure (SeedingService seedingService)
//{
//    seedingService.Seed();
//}



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
