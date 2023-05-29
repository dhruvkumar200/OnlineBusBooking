using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OBB.Business;
using OBB.Data.Entities;
using OBB.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
.AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
 .AddDataAnnotationsLocalization();
builder.Services.AddScoped<IUserBusiness,UserBusiness>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IBookingBusiness,BookingBusiness>();
builder.Services.AddScoped<IBookingRepository,BookingRepository>();
builder.Services.AddScoped<IBusBusiness,BusBusiness>();
builder.Services.AddScoped<IBusRepository,BusRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => x.LoginPath = new PathString("/User/LoginForm"));
builder.Services.AddSession();
builder.Services.AddDbContext<BookingDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineBusBooking")));
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
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bus}/{action=BusDetails}/{id?}");

app.Run();
