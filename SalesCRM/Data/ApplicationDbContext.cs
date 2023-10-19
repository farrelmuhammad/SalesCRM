using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesCRM.Models;

namespace SalesCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<SalesLeadEntity> SalesLead { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
    }
}
