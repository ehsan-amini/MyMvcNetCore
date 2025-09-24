
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMvcNetCore.Commen;
using MyMvcNetCore.DataLayer;
using MyMvcNetCore.DataLayer.Context;
using MyMvcNetCore.DataLayer.DbInitializer;
using MyMvcNetCore.DataLayer.Repository;
using MyMvcNetCore.DataLayer.Repository.IRepository;
using MyMvcNetCore.Entities.Identity;
using MyMvcNetCore.Services;
using MyMvcNetCore.Services.EFContracts;
using MyMvcNetCore.Services.EFServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<MyMvcNetCoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMvcNetCoreConnection")));


//builder.Services.AddIdentity<User, Role>(identityOptions =>
//{
//    //SetPasswordOptions(identityOptions.Password);

//    identityOptions.Lockout.AllowedForNewUsers = false;
//    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
//    identityOptions.Lockout.MaxFailedAccessAttempts = 3;

//    identityOptions.SignIn.RequireConfirmedEmail = true;
//    identityOptions.SignIn.RequireConfirmedPhoneNumber = false;
//    identityOptions.SignIn.RequireConfirmedAccount = true;

//    identityOptions.User.RequireUniqueEmail = true;
//});


builder.Services.AddIdentity<ApplicationUser , ApplicationRole >(identityOptions =>
{
    SetPasswordOptions(identityOptions.Password);

    identityOptions.Lockout.AllowedForNewUsers = false;
identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
identityOptions.Lockout.MaxFailedAccessAttempts = 3;

identityOptions.SignIn.RequireConfirmedEmail = false;
identityOptions.SignIn.RequireConfirmedPhoneNumber = false;
identityOptions.SignIn.RequireConfirmedAccount = false;

identityOptions.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MyMvcNetCoreDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
//builder.Services.AddAuthentication().AddFacebook(options =>
//{
//    options.AppId = "1725281671587415";
//    options.AppSecret = "4ae2f2934a32954fe3ad0ed3e2b4f3b0";
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();



SeedDatabase();



app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

app.UseSession();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}")
//    .WithStaticAssets();


app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}
  void SetPasswordOptions(PasswordOptions passwordOptions)
{
    passwordOptions.RequireDigit = false;
    passwordOptions.RequireLowercase = false;
    passwordOptions.RequireUppercase = false;
    passwordOptions.RequireNonAlphanumeric = false;
}