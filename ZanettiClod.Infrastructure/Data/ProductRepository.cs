using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZanettiClod.Core.Interfaces.Data;
using ZanettiClod.Domain;

namespace ZanettiClod.Infrastructure.Data
{
    public class ProductRepository : IProductRepository<Product>
    {
        private readonly string _connString;
        private SqlConnection DB;
        public ProductRepository(IConfiguration config)
        {
            _connString = config.GetConnectionString("ProductsDB");
            DB = new SqlConnection(_connString);
        }

        public async void Create(Product model)
        {
            try
            {
                await DB.OpenAsync();

                string query = $"INSERT INTO Products(Name, Price) VALUES('{model.Name}', '{model.Price}')";
                
                await DB.ExecuteAsync(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await DB.CloseAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            try
            {
                await DB.OpenAsync();

                string query = $"SELECT * FROM Products";

                var products = DB.Query<Product>(query);

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                await DB.CloseAsync();
            }
        }
    }
}
