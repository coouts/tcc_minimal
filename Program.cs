var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.ConfigureServices(builder.Services);

var app = builder.Build();

EndpointConfiguration.ConfigureEndpoints(app);

 app.UseCors("AllowAll");

app.Run();