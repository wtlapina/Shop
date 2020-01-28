using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if(!context.ProductCategories.Any())
            {
                var prodCat = new List<ProductCategory>
                {
                    new ProductCategory { CategoryName = "Shirts" },
                    new ProductCategory { CategoryName = "Jeans" },
                    new ProductCategory { CategoryName = "Shoes" },
                    new ProductCategory { CategoryName = "Shorts" }
                };

                context.ProductCategories.AddRange(prodCat);
                context.SaveChanges();
            }

            if(!context.Products.Any())
            {
                var prod = new List<Product>
                {
                    new Product { ProdName = "Funky Prints", ProdPrice = 250.00M, ProdCategoryId = 1 },
                    new Product { ProdName = "Street Art", ProdPrice = 150.00M, ProdCategoryId = 1 },
                    new Product { ProdName = "Hammer Head", ProdPrice = 550.00M, ProdCategoryId = 2 },
                    new Product { ProdName = "Levi's", ProdPrice = 1150.00M, ProdCategoryId = 2 },
                    new Product { ProdName = "Knee high boots", ProdPrice = 750.00M, ProdCategoryId = 3 },
                    new Product { ProdName = "Air Jordan", ProdPrice = 3050.00M, ProdCategoryId = 3 },
                    new Product { ProdName = "Board Shorts", ProdPrice = 450.00M, ProdCategoryId = 4 },
                    new Product { ProdName = "Cargo Shorts", ProdPrice = 350.00M, ProdCategoryId = 4 }
                };

                context.Products.AddRange(prod);
                context.SaveChanges();
            }
        }
    }
}