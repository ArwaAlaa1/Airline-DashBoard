using AirLine.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine.MyDBContext
{
    public class DBContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ARWA-ALAA\\ARWAALAA;Database=AirLine Company;Trusted_Connection=True");
        }
        public DBContext(DbContextOptions<DBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AirCraft>()
                .HasMany(a => a.Craft_Roads)
                .WithOne(/*r => r.AirCraft*/);

            modelBuilder.Entity<Road>()
                .HasMany(o => o.Road_Crafts)
                .WithOne(/*r => r.Road*/);

            modelBuilder.Entity<Road_Craft>().HasKey(RC => new { RC.AirCraftId, RC.RouteId ,RC.DepatureTime});

			modelBuilder.Entity<Airline_Phones>().HasKey(AP => new { AP.AirLineId, AP.Phones});


			modelBuilder.Entity<Emp_Qualification>().HasKey(AP => new { AP.EmployeeId, AP.Qualification });

		}
		public DbSet<Road> Roads { get; set; }
        public DbSet<AirCraft> AirCrafts { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AirLine_Company> AirLine_Companies { get; set; }
        public DbSet<Road_Craft> Road_Crafts { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Airline_Phones> AirLinesPhones { get; set; }
        public DbSet<Emp_Qualification> EmpQualifications { get; set; }

    }
}
