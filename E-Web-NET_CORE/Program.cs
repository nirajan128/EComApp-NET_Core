using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Adds dbcontext to the application and uses options provided by entity frame work
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("defaultConnection"),
        b => b.MigrationsAssembly("Bulky.DataAccess") // Specify the class library with migrations
    ));

//Always register DEPENDENCY INJECTION service while using Repository
//Types of Dependency: \
//Scoped: state stays same for each request for all dependencies 
//TRansient: Sate changes with each request 
//Singleton: The state stays same for the lifecycle of application
//Add scope parameter takes and Interface and a class as a param
//Anycalass using ICategoryRepository is implemnting CategoryRepository class
builder.Services.AddScoped<IUnitOfWork, UnitofWork>();

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