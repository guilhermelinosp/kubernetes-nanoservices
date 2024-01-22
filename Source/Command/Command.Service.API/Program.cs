using Command.Service.Application;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddApplicationInjection(configuration);
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;
});
services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});
services.AddEndpointsApiExplorer();
services.AddControllers();
services.AddSwaggerGen();
services.AddGrpc();
services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Platform Service", Version = "v1" }); });

Console.WriteLine($"--> CommandService Endpoint {configuration["CommandService"]}");


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	configuration.AddUserSecrets<Program>();
}
else
{
	app.UseHsts();
}

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy" }));
app.UseAuthentication();
app.UseAuthorization();
app.Run();