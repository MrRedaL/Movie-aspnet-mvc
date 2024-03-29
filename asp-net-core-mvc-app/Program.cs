using AspNetCoreMvcApp.Data;
using AspNetCoreMvcApp.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add SQL connection to the Context
string? connection = builder.Configuration.GetConnectionString("DefaultConnectionString");
if (connection != null)
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
}

//Services configuration
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddControllersWithViews();


//Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//App configuration
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed Database
AppDbInitializer.Seed(app);

//Run the app
app.Run();