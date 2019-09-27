using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetContoso.Models;

namespace PetContoso.Data
{
    public class ContosoPetsContext : DbContext
    {
        public ContosoPetsContext(DbContextOptions<ContosoPetsContext> opts) : base(opts)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }

       
    }
}