using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Radzen;
using SAT242516005.Components;
using SAT242516005.Data;
using SAT242516005.Models.Providers;
using SAT242516005.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// =================== Razor ===================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// =================== DB ===================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("DefaultConnection yok");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); // Identity DB

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString)); // Asýl DB

// =================== Identity ===================
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication()
    .AddIdentityCookies();

builder.Services.AddAuthorization();

// =================== UI ===================
builder.Services.AddRadzenComponents();

// =================== Services ===================
builder.Services.AddScoped<IVardiyaProvider, VardiyaProvider>();
builder.Services.AddScoped<LogService>();
builder.Services.AddScoped<RaporService>();

builder.Services.AddScoped<
    SAT242516005.Data.Abstract.IMyDbModel_UnitOfWork,
    SAT242516005.Data.Concrete.UnitOfWork>();

// =================== Localization ===================
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

var cultures = new[] { "tr-TR", "en-US" };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedCultures = cultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = cultures.Select(c => new CultureInfo(c)).ToList();
});

var app = builder.Build();

// =================== Pipeline ===================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Dil deðiþtirme endpoint
app.MapGet("/culture/set", (string culture, string redirectUri, HttpContext context) =>
{
    if (culture != null)
    {
        var cookieOptions = new CookieOptions
        {
            Path = "/",
            Expires = DateTimeOffset.UtcNow.AddYears(1),
            SameSite = SameSiteMode.Lax,
            Secure = false, // Localhost uyumu için
            IsEssential = true
        };

        context.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            cookieOptions
        );
    }

    // "LocalRedirect" yerine sadece "Redirect" kullanýyoruz ki tam URL'leri kabul etsin
    return Results.Redirect(string.IsNullOrEmpty(redirectUri) ? "/" : redirectUri);
});
app.UseHttpsRedirection();
app.UseStaticFiles();

var locOptions = app.Services.GetRequiredService<
    Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
