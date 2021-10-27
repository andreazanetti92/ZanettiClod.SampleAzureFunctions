using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.Domain;

namespace ZanettiClod.Core.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public void CreateProduct(Product model);
    }
}
