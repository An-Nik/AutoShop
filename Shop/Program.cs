using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.mocks;
using Shop.Data.Models;
using Shop.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICars, /*MockCars*/ CarRepository>();
builder.Services.AddTransient<ICategories, /*MockCategory*/ CategoryRepository>();
builder.Services.AddTransient<IOrders, OrdersRepository>();

builder.Configuration.AddJsonFile("dbsettings.json");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));

//для того, чтобы можно было использовать app.UseMvcWithDefaultRoute(), требуется
builder.Services.AddMvc(opt => opt.EnableEndpointRouting = false);

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

DbObjects.Initial(app);

app.UseStatusCodePages();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseSession();
app.UseMvc(routes =>
{
    routes.MapRoute("default", "{controller=Home}/{Action=Index}/{Id?}");
    routes.MapRoute("categoryFilter", "Cars/{action}/{category?}", defaults: new {Controller = "Cars", action = "List"});
});
//app.UseMvcWithDefaultRoute();
//app.UseRouting();

//app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
