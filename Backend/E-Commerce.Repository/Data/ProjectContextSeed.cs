using E_Commerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data
{
    public class ProjectContextSeed
    {
        public async static Task SeedAsync(ProjectContext context)
        {
            if (context.categories.Count() == 0)
            {
                var categoriesData = File.ReadAllText("../E-Commerce.Repository/Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                    {
                        context.Set<Category>().Add(category);
                    }
                    await context.SaveChangesAsync();
                }
            }           

            if (context.products.Count() == 0)
            {
                var productsData = File.ReadAllText("../E-Commerce.Repository/Data/DataSeed/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        context.Set<Product>().Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
