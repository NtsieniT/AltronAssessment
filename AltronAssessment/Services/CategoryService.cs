using Core.Interfaces;
using Core.Models;
using Core.Requests;
using Core.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AltronAssessment.Services
{
    public class CategoryService : ICategories
    {
        private readonly AltronContext _categoriesContext;
        public CategoryService(AltronContext categoriesContext)
        {
            _categoriesContext = categoriesContext;
        }
        public async Task<CategoryResponse> AddCategory(CategoryRequest categoryRequest)
        {
           
            try
            {
                //Get product
                var product = await _categoriesContext.Products.FirstOrDefaultAsync(x => x.Id == categoryRequest.ProductId);
                if (product != null)
                {
                    var category = new Category()
                    {
                        Name = categoryRequest.Name,
                        ProductId = product.Id
                    };

                    await _categoriesContext.Categories.AddAsync(category);
                    await _categoriesContext.SaveChangesAsync();

                    return new CategoryResponse()
                    {
                        CategoryName = category.Name,
                        Id = category.Id
                    };
                }
                else
                {
                    throw new Exception("No product found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryResponse> AddSubCategory(SubCategoryRequest subCategoryRequest)
        {
            try
            {
                //Get product
                var category = await _categoriesContext.Categories.FirstOrDefaultAsync(x => x.Id == subCategoryRequest.CategoryId);
                if (category != null)
                {
                    var subCategory = new SubCategory()
                    {
                        Name = subCategoryRequest.Name,
                        CategoryId = category.Id
                    };

                    await _categoriesContext.Subcategories.AddAsync(subCategory);
                    await _categoriesContext.SaveChangesAsync();

                    return new CategoryResponse()
                    {
                        CategoryName = category.Name,
                        Id = category.Id
                    };
                }
                else
                {
                    throw new Exception("No product found");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            try
            {
                var categories = await _categoriesContext.Categories.ToListAsync();

                return categories;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<CategoryResponse> UpdateCategory(CategoryRequest product)
        {
            throw new NotImplementedException();
        }
    }
}
