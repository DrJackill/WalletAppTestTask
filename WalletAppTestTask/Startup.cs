
using Microsoft.EntityFrameworkCore;
using WalletAppTestTask.Context;
using WalletAppTestTask.Services;

public class Startup
{
    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        Environment = environment;
        Configuration = configuration;
    }

    private IWebHostEnvironment Environment { get; }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services){
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        
        services.AddDbContextFactory<WalletAppContext>(
                builder =>
                {
                    if (Environment.IsDevelopment())
                        builder.EnableSensitiveDataLogging();

                    builder.UseNpgsql(
                        Configuration.GetConnectionString("DefaultConnection"));
                });
        
        services.ConfigureModelServices();
    }

    public void ConfigureApp(WebApplication app){
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}