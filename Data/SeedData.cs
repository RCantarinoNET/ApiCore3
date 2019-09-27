using System.Linq;
using PetContoso.Models;

namespace PetContoso.Data
{
    public static class SeedData
    {
        public static void Initialize(ContosoPetsContext petsContext)
        {
            if(petsContext.Products.Any())
                return;
            
            
            petsContext.Products.AddRange(new Product
            {
                    Name = "Squeaky Bone",
                    Price = 20.99m
                },
                new Product
                {
                    Name = "Knotted Rope",
                    Price = 12.99m
                }
            );

            petsContext.SaveChanges();

        }
    }
}