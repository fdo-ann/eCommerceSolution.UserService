using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

var app = builder.Build();

//Use exception handling middleware
app.UseExceptionHandlingMiddleware();

//Routing 
app.UseRouting();

//Auth
//app.UseAuthentication();
app.UseAuthorization();

//app.MapGet("/", () => "Hello World!");
//Controller routes
app.MapControllers();
app.Run();
