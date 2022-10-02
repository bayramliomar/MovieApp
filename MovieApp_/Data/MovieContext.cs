using Microsoft.EntityFrameworkCore;
using MovieApp_.Entities;

namespace MovieApp_.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Cast> Casts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Title).HasMaxLength(50);
            modelBuilder.Entity<Movie>().Property(x => x.Title).HasAnnotation("DisplayName", "Başlık");

            modelBuilder.Entity<Movie>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Description).HasMaxLength(500);
            modelBuilder.Entity<Movie>().Property(x => x.Description).HasAnnotation("DisplayName", "Açıklama");

            modelBuilder.Entity<Movie>().Property(x => x.ImagePath).IsRequired();
            modelBuilder.Entity<Movie>().Property(x => x.Title).HasAnnotation("DisplayName", "Resim");
        }
    }
}
