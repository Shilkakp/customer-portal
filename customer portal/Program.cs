using customer_portal.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Inject Dbcontext

        builder.Services.AddDbContext<cPDBContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("RegistersDbConnectionString"),new MySqlServerVersion(new Version(8,0,0))));
        builder.Services.AddCors((setup) =>
        {
            setup.AddPolicy("default", (options) =>
            {
                options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            });
        });

       // logout
       // builder.services.addsession(optioms =>
       // {
           // options.idletimeout = timespan.fromseconds(5);
           // options.cookie.httponly = true;
           // options.cookie.isessential = true;
        //});

        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("default");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}