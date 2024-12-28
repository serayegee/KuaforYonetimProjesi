using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using odevweb.Models;

//KuaforContext context = new();

//Personel ekleme
/*
Personel personel = new()
{
    Ad = "Ayþe",
    Soyad = "Yýlmaz",
    Uzmanlik = "Saç Kesimi",
    IslemId = 65
};

context.Personels.Add(personel);
context.SaveChanges();*/



//Ýþlemleri ekleme
/*
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

context.Islems.Add(islem);
context.Islems.Add(islem2);
context.Islems.Add(islem3);
context.Islems.Add(islem4);
context.Islems.Add(islem5);
context.Islems.Add(islem6);
context.SaveChanges();*/
/*

context.Islems.Remove(islem);
context.Islems.Remove(islem2);
context.Islems.Remove(islem3);
context.Islems.Remove(islem4);
context.Islems.Remove();
context.Islems.Remove();*/

/*using (var dbcontext = new KuaforContext())
{
    var allIslems =dbcontext.Islems.ToList();
    dbcontext.Islems.RemoveRange(allIslems);
    dbcontext.SaveChanges();
}*/

/*
using (var context = new KuaforContext())
{
    var admin = new Kullanici
    {
        KullaniciAdi = "b221210069@sakarya.edu.tr",
        Sifre = "sau", 
        IsAdmin = true
    };

    context.Kullanicis.Add(admin);
    context.SaveChanges();
}*/


/*
using (var context = new KuaforContext())
{
    // Eðer admin zaten yoksa ekle
    var admin = new Kullanici
    {
        KullaniciAdi = "b221210069@sakarya.edu.tr",
        Sifre = "sau",
        IsAdmin = true
    };

    context.Kullanicis.Add(admin);
    //    context.SaveChanges();
    }

*/


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Login sayfasý
        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eriþim
    });


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



app.UseAuthentication(); // Authentication middleware
app.UseAuthorization(); // Authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
