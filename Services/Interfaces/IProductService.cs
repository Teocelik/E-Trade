using E_Trade.Models;
using System.Collections.Generic;

namespace E_Trade.Services.Interfaces
{
    /* Hizmet (Service) Tanımlama
       Öncelikle, bir hizmet sınıfı oluşturuyoruz.*/
    public interface IProductService
    {
        List<Product> GetProducts();
        Product Details(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
