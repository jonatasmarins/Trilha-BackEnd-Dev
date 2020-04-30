using Microsoft.EntityFrameworkCore;
using Nivel1.Data.ConfigurationBuilders;
using Nivel1.Domain.Models;

namespace Nivel1.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }


        public DbSet<User> Users { get; set; }
    }
}