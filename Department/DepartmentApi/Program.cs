using DepartmentDomain.Entity;
using DepartmentReposatory.Reposatory;
using DepartmentService.EventBus;
using DepartmentService.IServices;
using DepartmentService.Services;
using Microsoft.EntityFrameworkCore;
 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDepartmentAppService, DepartmentService.Services.DepartmentService>();
builder.Services.AddScoped<IEventBus, DepartmentService.EventBus.EventBus>();
builder.Services.AddDbContext<DepartmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();