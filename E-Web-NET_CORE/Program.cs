using E_Web_NET_CORE.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Adds dbcontext to the application and uses options provided by entity frame work
<<<<<<< HEAD
builder.Services.AddDbContext<ApplicationDbContext>(options =>
=======
builder.Services.AddDbContext<ApplicationDbContext>(options => 
>>>>>>> f5a4c4e91e902b344c7c799244c1083944f1533e
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))); //uses GetconnectionSTring method to get connection strings from appsetting.json

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();