using E_Trade.Models;
using System.Collections.Generic;

namespace E_Trade.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product Details(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
