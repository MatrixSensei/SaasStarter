using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Saas;
using Saas.Data;
using TenantResources.Data;
using TenantResources.Data.Repository;
using TenantResources.Data.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);
var addSwagger = true;
//var addSwagger = false;
if (addSwagger == true)
{
    // Requires NuGet Swashbuckle.AspNetCore package installed
    // Also add using Microsoft.OpenApi.Models;
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Saas.Api", Version = "v1" });
    });
}

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Set up application Db Context
builder.Services.SetupApplicationDb(connectionString);

// Set up tenant Db Context(s)
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IDatalinkRepository, DatalinkRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddAndMigrateDatalinkContexts(builder.Configuration);  // in ServiceCollectionExtensions

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() && addSwagger == true)
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//==============================================================
/* NOTES on implementing Areas and Identity at the same time
 * Make sure all controlers are using the [Area=""] annotation
 * Make sure all View folders include a copy of the _ViewImports.cshtml and _ViewStart.cshtml files
 */
//==============================================================
//app.UseMvc();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area=Public}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapRazorPages(); //Routes for pages
    endpoints.MapControllers(); //Routes for my API controllers
});


app.Run();
