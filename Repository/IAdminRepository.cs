using Amazon.Models;

namespace Amazon.Repository
{
    public interface IAdminRepository
    {
        Task<Admin> AddAdmin(Admin Admin);

        Task DeleteAdmin(int AdminId);   
        Task<Category> AddCategory(Category category);
        Task DeleteCategory(int CategoryId);
        Task<List<Category>> GetAllCategories();
    }
}
