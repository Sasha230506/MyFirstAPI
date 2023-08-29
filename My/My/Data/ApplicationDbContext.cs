using Table_Tennis_UK.Models;
using Microsoft.EntityFrameworkCore;

namespace Table_Tennis_UK.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TableTennisClub> TableTennisClubs { get; set; }


/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableTennisClub>().HasData(
                    new TableTennisClub()
                    {
                        Id = 1,
                        Name = "Lider",
                        Details = "We should visit the Kiev Villa",
                        YearOfOpening = "rcrcr",
                        HeadCoach = "ff",
                        JuniorCoach = "ff",
                        Square = 150,
                        CoutOfTable = 6,
                        CreateDate = DateTime.Now,
                    });

    }*/
    }
}
