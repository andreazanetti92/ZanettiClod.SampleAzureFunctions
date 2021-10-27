using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZanettiClod.Core.Interfaces.Data
{
    public interface IProductRepository<T>
    {
        public Task<IEnumerable<T>> GetProducts();
        public void Create(T model);
    }
}
