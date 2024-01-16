using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentDomain.Entity
{
    public class DepartmentContext :DbContext

    {
        private readonly IConfiguration _configuration;

        public DepartmentContext()
        {
        }

        public DepartmentContext(DbContextOptions<DepartmentContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;

        }
        public DbSet<Department> Department { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
