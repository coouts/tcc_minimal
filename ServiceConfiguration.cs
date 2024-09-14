public static class ServiceConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {

        var mongodbconfig = new MongoDbConfig("mongodb://localhost:27017", "tcc");
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddSingleton(mongodbconfig);


        // Registre seus serviços aqui
        services.AddSingleton<IUserService, UserService>();

        services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });


        services.AddControllers();
    }
}