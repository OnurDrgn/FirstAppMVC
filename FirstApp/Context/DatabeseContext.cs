using FirstApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Context
{
    public class DatabeseContext: DbContext
    {
        public DbSet<Slider> Slider { get; set; }

        public DatabeseContext(DbContextOptions<DatabeseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Slider>(slider =>
            {
                slider.HasKey(s => new { s.Id });
            });
        }

    }
}
