using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public interface ICategory
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        List<Category> GetCategoryByName(string name);

        Category InsertCategory(Category cat);
        Category UpdateCategory(Category cat);
        void DeleteCategory(int id);
    }
}
