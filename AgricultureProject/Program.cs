using AgricultureProject.Models;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AgricultureContext>(); // Veritabaný yapýlandýrmasý DbContext içinde yapýlýyor.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AgricultureContext>().AddErrorDescriber<UserIdentityValidator>();
builder.Services.ContainerDependencies(); // AddScoped metotlarý burada bulunur.
builder.Services.AddMvc();

builder.Services.AddControllersWithViews(config =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	config.Filters.Add(new AuthorizeFilter(policy)); // Tüm sayfalar için yetkilendirme
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(8); // 8 dakika oturum süresi
    options.SlidingExpiration = false; // Kullanýcý aktif olsa bile çerez süresi uzatýlmayacak
    options.Cookie.IsEssential = true; // Çerez zorunlu (Giriþ zorunluluðu için)
    options.LoginPath = "/Login/Index/"; // Giriþ yapýlmamýþ kullanýcýlar bu sayfaya yönlendirilir
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/*
 - AddAuthentication: Bu kýsým, uygulamaya kimlik doðrulama iþlemini ekler.
   CookieAuthenticationDefaults.AuthenticationScheme ile cookie tabanlý kimlik doðrulama kullanýlacaðýný belirtir.
 - AddCookie: Cookie tabanlý kimlik doðrulamayý yapýlandýrýr. Burada, giriþ yapýlmasý gerektiðinde kullanýcýlarýn
   yönlendirileceði LoginPath "/Login/Index" olarak tanýmlanmýþtýr. Eðer bir kullanýcý kimliði doðrulanmamýþsa
   ve yetki gerektiren bir sayfaya eriþmeye çalýþýrsa, uygulama bu kullanýcýyý "/Login/Index" sayfasýna yönlendirir.
*/

/* AddMvc:  MVC (Model-View-Controller) yapýsýný uygulamanýza ekler. Yani, ASP.NET Core uygulamasýnýn
MVC mimarisini kullanacaðýný belirtir.*/

/*
 - AuthorizationPolicyBuilder: Bu kod, tüm MVC controller'larýna ve action'larýna yetkilendirme (authorization) 
   gereksinimi ekler.
 - RequireAuthenticatedUser() ile yalnýzca kimliði doðrulanmýþ kullanýcýlarýn eriþim saðlayabileceði bir politika 
   oluþturuluyor.
 - config.Filters.Add(new AuthorizeFilter(policy)): Bu satýr, oluþturulan yetkilendirme politikasýný tüm controller'lar 
   ve action'lar için global bir filtre olarak ekler. Yani, kimliði doðrulanmamýþ kullanýcýlar herhangi bir sayfaya 
   eriþmeye çalýþtýðýnda oturum açma sayfasýna yönlendirilir.
*/

/*AddIdentity<AppUser, AppRole>(): IdentityUser ve IdentityRole sýnýflarýný kullanarak Identity'yi ekler.
AddEntityFrameworkStores<ApplicationDbContext>(): Kimlik hizmetlerinin veritabaný iþlemlerini yürüteceði 
Context sýnýfýný belirler.*/
