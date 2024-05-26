using E_Trade.DataAccess.Repositories;
using E_Trade.Models;
using E_Trade.Services.Interfaces;
using System.Collections.Generic;

namespace E_Trade.Services.Implementations
{
    public class ProductServices : IProductService
    {
        private readonly IRepository<Product> _productRepository;


        public ProductServices(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Product Details(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        public void Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
