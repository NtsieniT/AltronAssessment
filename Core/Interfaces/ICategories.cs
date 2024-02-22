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
    public interface ICategories
    {
        Task<List<Category>> GetAllCategories();
        Task<CategoryResponse> AddCategory(CategoryRequest product);
        Task<CategoryResponse> AddSubCategory(SubCategoryRequest product);
        Task<CategoryResponse> UpdateCategory(CategoryRequest product);
        
    }
}
