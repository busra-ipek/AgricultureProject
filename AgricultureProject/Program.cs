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
builder.Services.AddDbContext<AgricultureContext>(); // Veritaban� yap�land�rmas� DbContext i�inde yap�l�yor.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AgricultureContext>().AddErrorDescriber<UserIdentityValidator>();
builder.Services.ContainerDependencies(); // AddScoped metotlar� burada bulunur.
builder.Services.AddMvc();

builder.Services.AddControllersWithViews(config =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
	config.Filters.Add(new AuthorizeFilter(policy)); // T�m sayfalar i�in yetkilendirme
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(8); // 8 dakika oturum s�resi
    options.SlidingExpiration = false; // Kullan�c� aktif olsa bile �erez s�resi uzat�lmayacak
    options.Cookie.IsEssential = true; // �erez zorunlu (Giri� zorunlulu�u i�in)
    options.LoginPath = "/Login/Index/"; // Giri� yap�lmam�� kullan�c�lar bu sayfaya y�nlendirilir
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
 - AddAuthentication: Bu k�s�m, uygulamaya kimlik do�rulama i�lemini ekler.
   CookieAuthenticationDefaults.AuthenticationScheme ile cookie tabanl� kimlik do�rulama kullan�laca��n� belirtir.
 - AddCookie: Cookie tabanl� kimlik do�rulamay� yap�land�r�r. Burada, giri� yap�lmas� gerekti�inde kullan�c�lar�n
   y�nlendirilece�i LoginPath "/Login/Index" olarak tan�mlanm��t�r. E�er bir kullan�c� kimli�i do�rulanmam��sa
   ve yetki gerektiren bir sayfaya eri�meye �al���rsa, uygulama bu kullan�c�y� "/Login/Index" sayfas�na y�nlendirir.
*/

/* AddMvc:  MVC (Model-View-Controller) yap�s�n� uygulaman�za ekler. Yani, ASP.NET Core uygulamas�n�n
MVC mimarisini kullanaca��n� belirtir.*/

/*
 - AuthorizationPolicyBuilder: Bu kod, t�m MVC controller'lar�na ve action'lar�na yetkilendirme (authorization) 
   gereksinimi ekler.
 - RequireAuthenticatedUser() ile yaln�zca kimli�i do�rulanm�� kullan�c�lar�n eri�im sa�layabilece�i bir politika 
   olu�turuluyor.
 - config.Filters.Add(new AuthorizeFilter(policy)): Bu sat�r, olu�turulan yetkilendirme politikas�n� t�m controller'lar 
   ve action'lar i�in global bir filtre olarak ekler. Yani, kimli�i do�rulanmam�� kullan�c�lar herhangi bir sayfaya 
   eri�meye �al��t���nda oturum a�ma sayfas�na y�nlendirilir.
*/

/*AddIdentity<AppUser, AppRole>(): IdentityUser ve IdentityRole s�n�flar�n� kullanarak Identity'yi ekler.
AddEntityFrameworkStores<ApplicationDbContext>(): Kimlik hizmetlerinin veritaban� i�lemlerini y�r�tece�i 
Context s�n�f�n� belirler.*/
