using Core.Models;
using Core.Requests;
using Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProduct
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task<ProductsResponse> AddProduct(ProductsRequest product);  
        Task<bool> UpdateProduct(int id, ProductsRequest product);
        Task<bool> DeleteProductAsync(int id); 
    }
}
