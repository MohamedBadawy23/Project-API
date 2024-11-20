using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order;

namespace Talabat.Respository.Data
{
    public static class StoreContextSeed
    {
        public async static Task SeedAsync(StoreDbContext _context)
        {
            if (_context.Brands.Count() == 0)
            {
                // 1. Read Data From Json Files
                var brandsData = File.ReadAllText("../Talabat.Respository/Data/DataSeed/brands.json");

                // 2. Convert Json To List<ProuctBrand>
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);


                // 3. Seed At The Database
                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {
                        _context.Brands.Add(brand);
                    }
                    await _context.SaveChangesAsync();
                }

            }


            if (_context.Types.Count() == 0)
            {
                // 1. Read Data From Json Files
                var categorisData = File.ReadAllText("../Talabat.Respository/Data/DataSeed/categories.json");

                // 2. Convert Json To List<ProuctCategory>
                var categories = JsonSerializer.Deserialize<List<ProductType>>(categorisData);


                // 3. Seed At The Database
                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                    {
                        _context.Types.Add(category);
                    }
                    await _context.SaveChangesAsync();
                }

            }



            if (_context.Products.Count() == 0)
            {
                // 1. Read Data From Json Files
                var productsData = File.ReadAllText("../Talabat.Respository/Data/DataSeed/products.json");

                // 2. Convert Json To List<Product>
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);


                // 3. Seed At The Database
                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        _context.Products.Add(product);
                    }
                    await _context.SaveChangesAsync();
                }

            }



            if (_context.DeliveryMethods.Count() == 0)
            {
                // 1. Read Data From Json Files
                var deliveryData = File.ReadAllText("../Talabat.Respository/Data/DataSeed/delivery.json");

                // 2. Convert Json To List<DeliveryMethod>
                var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);


                // 3. Seed At The Database
                if (deliveryMethods?.Count() > 0)
                {
                    foreach (var deliveryMethod in deliveryMethods)
                    {
                        _context.DeliveryMethods.Add(deliveryMethod);
                    }
                    await _context.SaveChangesAsync();
                }

            }



        }
    }
}
