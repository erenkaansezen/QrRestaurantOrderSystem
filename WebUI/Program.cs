using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Web.DataAccessLayer.Concrete;
using Web.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy =new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

builder.Services.AddDbContext<WebContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<WebContext>();


builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
builder.Services.ConfigureApplicationCookie(opts=>
{
    opts.LoginPath = "/Login/Index";
    opts.LogoutPath = "/Login/Logout";
    opts.AccessDeniedPath = "/Login/AccessDenied";
    opts.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    opts.SlidingExpiration = true;
    opts.Cookie.HttpOnly = true;
    opts.Cookie.SameSite = SameSiteMode.Strict;
    opts.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
