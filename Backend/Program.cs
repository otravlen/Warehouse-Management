using Backend;
using Backend.DatabaseLayer;
using Microsoft.EntityFrameworkCore;

var config = new Config();

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	WebRootPath = "ClientApp/dist" 
});

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(config.GetConnectionString()));

builder.WebHost.UseWebRoot("ClientApp/dist"); 

builder.Services.AddControllers();

builder.Services.AddSpaStaticFiles(configuration =>
{
	configuration.RootPath = "ClientApp/dist"; 
});

var app = builder.Build();

app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseSpa(spa =>
{
	spa.Options.SourcePath = "ClientApp";

	if (app.Environment.IsDevelopment())
	{
		System.Threading.Thread.Sleep(2000);
		spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
	}
});

app.MapFallbackToFile("index.html");

app.Run();