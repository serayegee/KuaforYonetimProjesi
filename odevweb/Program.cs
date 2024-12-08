using Microsoft.EntityFrameworkCore;
using odevweb.Models;

KuaforContext context = new();


//Ýþlemleri ekleme
Islem islem = new()
{
    Ad = "Saç Kesimi",
    Sure = 60,
    Ucret = 350
};

Islem islem2 = new()
{
    Ad = "Saç Boyama",
    Sure = 120,
    Ucret = 600
};

Islem islem3 = new()
{
    Ad = "Saç Bakýmý",
    Sure = 90,
    Ucret = 600
};

Islem islem4 = new()
{
    Ad = "Saç Þekillendirme",
    Sure = 60,
    Ucret = 300
};

Islem islem5 = new()
{
    Ad = "Makyaj",
    Sure = 60,
    Ucret = 350
};

Islem islem6 = new()
{
    Ad = "Manikür-Pedikür",
    Sure = 45,
    Ucret = 200
};

//context.Islems.Add(islem);
//context.Islems.Add(islem2);
context.Islems.Add(islem3);
context.Islems.Add(islem4);
context.Islems.Add(islem5);
context.Islems.Add(islem6);
context.SaveChanges();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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
