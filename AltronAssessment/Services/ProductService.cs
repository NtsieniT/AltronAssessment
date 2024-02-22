using Core.Interfaces;
using Core.Models;
using Core.Requests;
using Core.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService : IProduct
    {
        private readonly AltronContext _productsContext;
        public ProductService(AltronContext productsContext)
        {
            _productsContext = productsContext;
        }

        public async Task<ProductsResponse> AddProduct(ProductsRequest productRequest)
        {
            try
            {
                var product = new Product()
                {
                    Name = productRequest.Name,
                    //Categories = productRequest.Categories
                };

                await _productsContext.Products.AddAsync(product);
                await _productsContext.SaveChangesAsync();

                return new ProductsResponse
                {
                    ProductId = product.Id,
                    Name = product.Name
                };

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _productsContext.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (product != null)
                {
                    _productsContext.Products.Remove(product);
                    await _productsContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productsContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                return product;

            }
            catch (Exception)
            {

                throw;
            }           
            
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _productsContext.Products.ToListAsync();

                return products;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
                
        public async Task<bool> UpdateProduct(int id, ProductsRequest productRequest)
        {
            var product = await _productsContext.Products.FindAsync(id);

            if (product != null)
            {
                product.Name = productRequest.Name;
                _productsContext.Update(product);
                await _productsContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
