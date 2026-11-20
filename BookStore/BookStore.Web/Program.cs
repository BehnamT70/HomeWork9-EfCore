using BookStore.Application;
using BookStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ثبت سرویس‌ها
builder.Services.AddControllersWithViews();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

// ساخت برنامه
var app = builder.Build();

// تنظیم Middlewareها
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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