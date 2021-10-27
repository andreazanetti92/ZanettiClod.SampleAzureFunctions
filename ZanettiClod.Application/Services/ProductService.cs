using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.Core.Interfaces.Data;
using ZanettiClod.Domain;

namespace ZanettiClod.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository<Product> _repo;

        public ProductService(IProductRepository<Product> repo)
        {
            _repo = repo;
        }

        public void CreateProduct(Product model)
        {
            _repo.Create(model);
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return _repo.GetProducts();
        }
    }
}
