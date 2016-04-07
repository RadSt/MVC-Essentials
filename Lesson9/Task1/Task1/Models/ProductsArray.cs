using System.Runtime.Hosting;

namespace Task1.Models
{
    public class ProductsArray
    {
        readonly Product[] products = new Product[15];

        public Product[] CreateProductsArray()
        {
            
            for (int i = 0; i < products.Length; i++)
            {
               products[i] = new Product{Id = i, ProductName = "P" + i}; 
            }
            return products;
        } 
    }
}