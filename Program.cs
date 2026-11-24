using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ordella_deliverable2.Data;
using Ordella_deliverable2.Repositories;
using Ordella_deliverable2.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<DapperConnectionFactory>();
builder.Services.AddScoped<IShopRepository, DapperShopRepository>();
builder.Services.AddScoped<IProductRepository, DapperProductRepository>();
builder.Services.AddScoped<IOrderRepository, DapperOrderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = false; options.Password.RequiredLength = 8; options.Password.RequireDigit = true; options.Password.RequireUppercase = true; options.Password.RequireNonAlphanumeric = false; options.Lockout.MaxFailedAccessAttempts = 5; options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10); })
 .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => { options.LoginPath = "/Account/Login"; options.AccessDeniedPath = "/Account/AccessDenied"; });
var app = builder.Build();
if (!app.Environment.IsDevelopment()){app.UseExceptionHandler("/Home/Error");app.UseHsts();}
app.UseHttpsRedirection();app.UseStaticFiles();app.UseRouting();app.UseAuthentication();app.UseAuthorization();
app.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
await SeedData.InitializeAsync(app.Services);
app.Run();
