using KolokwiumABPD.Repositories;
using KolokwiumABPD.Services;

namespace KolokwiumABPD;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        
        builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
        builder.Services.AddScoped<IAppointmentsService, AppointmentsService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}