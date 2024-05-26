using E_Trade.Models;
using System.Collections.Generic;
using System.Linq;

namespace E_Trade.DataAccess.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _appDbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
