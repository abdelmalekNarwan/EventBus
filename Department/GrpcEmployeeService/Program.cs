using EmployeeDomain.Entity;
using EmployeeReposatory.Repsatory;
using EmployeeService.Services;
using GrpcEmployeeService.Protos;
using GrpcEmployeeService.Services;
using Microsoft.EntityFrameworkCore;

namespace GrpcEmployeeService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

            // Add services to the container.
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeeService));
            builder.Services.AddDbContext<EmployeeDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGrpcService<GrpcEmployeeService.Services.EmployeeService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}