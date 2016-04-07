using System.Collections.Generic;
using System.Runtime.Hosting;

namespace Task1.Models
{
    class ProductsDataBase
    {

        public static IEnumerable<Product> Products
        {
            get
            {
                List<Product> products = new List<Product>();
                int prodQuant = 15;
                for (int i = 0; i < prodQuant; i++)
                {
                    products.Add(new Product { Id = i, ProductName = "P" + i });
                }
                return products;
            }
            
        } 
    }
}