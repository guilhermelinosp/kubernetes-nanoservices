var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddEndpointsApiExplorer();
services.AddControllers();
services.AddSwaggerGen();

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

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy" }));
app.UseCors(x => x
	.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader()
	.AllowCredentials());
app.UseAuthentication();
app.UseAuthorization();
app.Run();