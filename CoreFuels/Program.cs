using CoreFuels.ModelsEF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".App-Web.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Требует HTTPS
    options.Cookie.SameSite = SameSiteMode.Lax; // Или SameSiteMode.Strict
});

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/UserPage";
        options.LogoutPath = "/Authorization/Logout";
  
        options.SlidingExpiration = true;
        // Важные настройки для удаления куки:
        options.Cookie = new CookieBuilder
        {
            Name = "AuthCookie",
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            SecurePolicy = CookieSecurePolicy.Always,
            IsEssential = true
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Принудительное перенаправление с HTTP на HTTPS
app.UseHttpsRedirection();

// Настройка маршрутизации и аутентификации
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseStaticFiles();

// Настройка маршрутов
app.MapControllerRoute(
    name: "login",
    pattern: "login/{action=UserPage}/{login?}",
    defaults: new { controller = "Login" }
);

app.MapControllerRoute(
    name: "authorization",
    pattern: "authorization/{action=Index}/{id?}",
    defaults: new { controller = "Authorization" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "eat",
    pattern: "Eat/{action=Index}/{id?}",
    defaults: new { controller = "Eat" }
);

app.MapControllerRoute(
    name: "training",
    pattern: "Training/{action=Index}/{id?}",
    defaults: new { controller = "Training" }
);

// Применяем миграции (но не создаем админа)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
