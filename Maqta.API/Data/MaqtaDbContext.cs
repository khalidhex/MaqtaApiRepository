using Maqta.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Maqta.API.Data
{
    public class MaqtaDbContext:IdentityDbContext<IdentityUser>
    {
        public MaqtaDbContext() { }
        public MaqtaDbContext(DbContextOptions<MaqtaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasData(
              new Employee { Id = 1, Name = "FirstEmp", Department = "IT"});

        }

        public virtual DbSet<Employee> Employees { get; set; }
    }


}
