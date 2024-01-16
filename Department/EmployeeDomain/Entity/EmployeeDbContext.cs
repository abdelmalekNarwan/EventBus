using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDomain.Entity
{
    public class EmployeeDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public EmployeeDbContext()
        {
            
        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Employee> Employee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
