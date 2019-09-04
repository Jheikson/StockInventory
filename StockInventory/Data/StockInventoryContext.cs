using StockInventory.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

public class StockInventoryContext : DbContext
{
    public StockInventoryContext() : base("name=StockInventoryContext")
    {
    }

    public DbSet<City> City { get; set; }

    public DbSet<Employee> Employee { get; set; }

    public DbSet<Item> Item { get; set; }

    public DbSet<Department> Department { get; set; }

    public DbSet<Region> Region { get; set; }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        base.OnModelCreating(modelBuilder);
    }
}
