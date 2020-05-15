using Microsoft.EntityFrameworkCore;
using Nivel1.Data.ConfigurationBuilders;
using Nivel1.Domain.ExternalServices.Marvel.Models;
using Nivel1.Domain.ExternalServices.Models;
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
            modelBuilder.ApplyConfiguration(new CharacterConfiguration());
            modelBuilder.ApplyConfiguration(new CreatorConfiguration());
            modelBuilder.ApplyConfiguration(new ComicConfiguration());
            modelBuilder.ApplyConfiguration(new ComicCharacterConfiguration());
            modelBuilder.ApplyConfiguration(new ComicCreatorConfiguration());
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<ComicCharacter> ComicCharacters { get; set; }
        public DbSet<ComicCreator> ComicCreators { get; set; }
    }
}