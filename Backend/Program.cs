using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	WebRootPath = "ClientApp/dist" // ”казываем правильный путь
});

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